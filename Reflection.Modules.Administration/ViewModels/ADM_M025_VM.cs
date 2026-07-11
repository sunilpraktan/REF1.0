using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M025_VM : WorkspaceViewModel<ADM_M025>
    {
        #region AutoSuggest TextBox Declaration Region

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
      
    
        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }
        #endregion
        #region . Declaration .
        bool isNewRecord = true;

        WebServiceRepository<ADM_M025> repository = new WebServiceRepository<ADM_M025>();
        WebServiceRepository<MultipleContext_ADM_M025> repository_MC = new WebServiceRepository<MultipleContext_ADM_M025>();
        WebServiceRepository<MultipleContext_ADM_M025> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M025>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ADM_M025 _MC = new MultipleContext_ADM_M025();
        public MultipleContext_ADM_M025 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");
                }
            }
        }

        private MultipleContext_ADM_M025 _MCTemp = new MultipleContext_ADM_M025();
        public MultipleContext_ADM_M025 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private ADM_M025 _MasterEntity;
        public ADM_M025 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        #endregion

        #region . StringList .

        private List<ADM_M025_Flip> _FlipGridData;
        public List<ADM_M025_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }     

        #endregion

        #region . ICollection .

        private ICollectionView _BackFlipCollection;
        public ICollectionView BackFlipCollection
        {
            get { return _BackFlipCollection; }
            set { _BackFlipCollection = value; RaisePropertyChanged("BackFlipCollection"); }
        }    

        #endregion

        #region . Relay Command Declaration .
 
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddEmployee { get; private set; }
        #endregion

        #region . Constructor .
        public ADM_M025_VM() : base()
        {
            MasterEntity = new ADM_M025();
            FlipGridData = new List<ADM_M025_Flip>();
            #region . Relay Command Initialisation .
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdAddEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            MoveFlag = true;
            LoadInitialData();
            #endregion
        }
        #endregion
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M025>(MC, Request, "DepartmentMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipList.ToList();
                BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackFlipCollection.Filter = new Predicate<object>(Filter_BackFlip);

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName);
                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M024_P)o).EmpName.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.DepartmentHead, TheFilter, SuggestedValue, "EmpName",true);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

               
             
                #endregion
                DefaultValues();
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.add_date = DateTime.Now;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.edit_date = DateTime.Now;
           
        }

        protected override void OnCreateAction(InquiryActionResult<ADM_M025> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M025();
            DefaultValues();
            MoveFlag = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M025> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M025> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M025> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M025> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M025> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M025> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ADM_M025> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M025>(MasterEntity, "DepartmentMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M025>(MasterEntity, "DepartmentMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.dept_code != null || MasterEntity.dept_code.ToString() == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Can Not Saved Please Try Again");
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                    MoveFlag = false;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.model_id.ToString()))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.model_id.ToString().Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.dept_code == null || MasterEntity.dept_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Department Code");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.DeptName == null || MasterEntity.DeptName == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Department Name");
                    showMessageService.ShowMessage();
                    return false;
                }



            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                ADM_M025_Flip ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ADM_M025_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M025_Flip>().ToList()[0];
                        isNewRecord = false;

                        string Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.dept_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M025>(MC, Request, "DepartmentMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                        MasterEntity = MCTemp.MasterEntity[0];
                        SelectedTabControlIndex = 0;
                        MoveFlag = false;

                        var msg = new NotificationMessage("ADM_M025_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
                    }
                }
            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void InsertEmployee(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DepartmentHead.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackFlipList = (List<ADM_M025_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipList);
                if (MC.BackFlipList.Count > 0)
                {
                    FlipGridData.Add(MC.BackFlipList[0]);
                }

                BackFlipCollection.Refresh();
                BackFlipCollection.SortDescriptions.Add(new SortDescription("dept_code", ListSortDirection.Descending));
            }
        }

        #region . Filters .

        #region . BackFlip .
        private string _filterStringBackFlip;
        public string filterStringBackFlip
        {
            get { return _filterStringBackFlip; }
            set
            {
                _filterStringBackFlip = value;
                RaisePropertyChanged("filterStringBackFlip");
                Filter_BackFlip();
            }
        }
        private void Filter_BackFlip()
        {
            if (BackFlipCollection != null)
            {
                BackFlipCollection.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as ADM_M025_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBackFlip))
                {
                    return (data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion

        #endregion


    }
}
