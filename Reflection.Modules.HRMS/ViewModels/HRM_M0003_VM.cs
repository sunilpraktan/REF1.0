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

namespace Reflection.Modules.HRMS.ViewModels
{
    public class HRMS_M0003_VM : WorkspaceViewModel<ADM_M026>
    {
        #region . Declaration .
        bool isNewRecord = true;

        WebServiceRepository<ADM_M026> repository = new WebServiceRepository<ADM_M026>();
        WebServiceRepository<MultipleContext_ADM_M026> repository_MC = new WebServiceRepository<MultipleContext_ADM_M026>();
        WebServiceRepository<MultipleContext_ADM_M026> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M026>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ADM_M026 _MC = new MultipleContext_ADM_M026();
        public MultipleContext_ADM_M026 MC
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

        private MultipleContext_ADM_M026 _MCTemp = new MultipleContext_ADM_M026();
        public MultipleContext_ADM_M026 MCTemp
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

        private ADM_M026 _MasterEntity;
        public ADM_M026 MasterEntity
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

        private List<ADM_M026_Flip> _FlipGridData;
        public List<ADM_M026_Flip> FlipGridData
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
        #endregion

        #region . Constructor .
        public HRMS_M0003_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M026();
            FlipGridData = new List<ADM_M026_Flip>();
            #region . Relay Command Initialisation .
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });

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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M026>(MC, Request, "DesignationMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipList.ToList();
                BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackFlipCollection.Filter = new Predicate<object>(Filter_BackFlip);

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
        protected override void OnCreateAction(InquiryActionResult<ADM_M026> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M026();
            DefaultValues();
            MoveFlag = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M026> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M026> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M026> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M026> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M026> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M026> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ADM_M026> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M026>(MasterEntity, "DesignationMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M026>(MasterEntity, "DesignationMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.desig_code != null || MasterEntity.desig_code.ToString() == "")
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M026> result)
        {
            throw new NotImplementedException();
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.desig_code == null || MasterEntity.desig_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Department Code");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.DesigName == null || MasterEntity.DesigName == "")
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
                ADM_M026_Flip ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ADM_M026_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M026_Flip>().ToList()[0];
                        isNewRecord = false;

                        string Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.desig_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M026>(MC, Request, "DesignationMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                        MasterEntity = MCTemp.MasterEntity[0];
                        SelectedTabControlIndex = 0;
                        MoveFlag = false;
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackFlipList = (List<ADM_M026_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipList);
                if (MC.BackFlipList.Count > 0)
                {
                    FlipGridData.Add(MC.BackFlipList[0]);
                }

                BackFlipCollection.Refresh();
                BackFlipCollection.SortDescriptions.Add(new SortDescription("desig_code", ListSortDirection.Descending));
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
            var data = obj as ADM_M026_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBackFlip))
                {
                    return (data.desig_code != null && data.desig_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.DesigName != null && data.DesigName.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #endregion


    }
}
