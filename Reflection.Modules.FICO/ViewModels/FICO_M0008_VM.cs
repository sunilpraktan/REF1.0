using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.ObjectModel;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0008_VM : WorkspaceViewModel<ACC_M003_B>
    {
        bool NewRecord = true;

        WebServiceRepository<ACC_M003_B> repository = new WebServiceRepository<ACC_M003_B>();
        WebServiceRepository<MultipleContext_ACC_M003_B> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_B>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0008_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASId { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASId
        {
            get { return _ASId; }
            set
            {
                if (_ASId != value)
                {
                    _ASId = value; RaisePropertyChanged("_ASId");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSgCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSgCode
        {
            get { return _ASSgCode; }
            set
            {
                if (_ASSgCode != value)
                {
                    _ASSgCode = value; RaisePropertyChanged("ASSgCode");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdId { get; private set; }

        public RelayCommand<object> CmdSg { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }


        #endregion
        #region Variable Declaration
        private ACC_M003_B _MasterEntity;
        public ACC_M003_B MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    RaisePropertyChanged("MasterEntity");

                }
            }
        }

        private MultipleContext_ACC_M003_B _MC;
        public MultipleContext_ACC_M003_B MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }



        private ObservableCollection<ACC_M003_B> _TOList;
        public ObservableCollection<ACC_M003_B> TOList
        {
            get { return _TOList; }
            set
            {
                if (_TOList != value)
                {
                    _TOList = value;
                    RaisePropertyChanged("TOList");
                }
            }
        }

        private ICollectionView _TOCollection1;
        public ICollectionView TOCollection1
        {
            get { return _TOCollection1; }
            set
            {
                if (_TOCollection1 != value)
                {
                    _TOCollection1 = value;
                    RaisePropertyChanged("TOCollection1");
                }
            }
        }

        private List<ACC_M003_B> _SelectedList;
        public List<ACC_M003_B> SelectedList
        {
            get
            {
                return _SelectedList;
            }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
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
        #region Constructor
        public FICO_M0008_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_B();
            MC = new MultipleContext_ACC_M003_B();



            CmdId = new RelayCommand<object>(items => { if (items == null) { return; } InsertId(items); });
            CmdSg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSg(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });


            LoadInitialData();

        }

        #endregion
        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

        }

        private bool Validation()
        {
            if (MasterEntity.ac_group_code == null || MasterEntity.ac_group_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid Account Group Code", MasterEntity.ac_group_code);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ac_sg_code == null || MasterEntity.ac_sg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid Account SubGroup Code", MasterEntity.ac_sg_code);
                showMessageService.ShowMessage();
                return false;
            }

            else
            {
                return true;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.UserSource1;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_B>(MC, Request, "AccountSubGroupCode", "Finance", "LoadInitialData", 0, "");

                TOList = MC.ACList;
                SelectedList = TOList.ToList();

                TOCollection1 = CollectionViewSource.GetDefaultView(MC.ACList);
                TOCollection1.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_B_P)x).ac_sg_code ?? "");
                TheFilter = (o, prefix) => (((ACC_M003_B_P)o).ac_sg_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_B_P)o).ac_sg_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASId = new AutoSuggestTextViewModel<dynamic>(MC.IDList, TheFilter, SuggestedValue, "sg_parent_code", true);
                ASId.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_A_P)x).ac_group_code ?? "");
                TheFilter = (o, prefix) => (((ACC_M003_A_P)o).ac_group_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_A_P)o).ac_group_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSgCode = new AutoSuggestTextViewModel<dynamic>(MC.SGList, TheFilter, SuggestedValue, "ac_group_code", true);
                ASSgCode.AutoSuggestVM.IsEmptyValueAllowed = true;



                DefaultValues();
                #endregion


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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {

                ACC_M003_B ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ACC_M003_B>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M003_B>().ToList()[0];

                    if (MC.ACList.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    NewRecord = false;

                }


            }
            catch { }

        }
        private void InsertId(object InputValue)
        {
            string Request = "";
            ACC_M003_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.IDList.Where(x => x.ac_sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_B_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sg_parent_code = POPUPEntityObject.ac_sg_code;
                    MasterEntity.sg_parent_Id = POPUPEntityObject.id;
                    // MasterEntity.ac_sg_name = POPUPEntityObject.ac_sg_name;
                }
            }
            catch (Exception ex) { }
        }

        private void InsertSg(object InputValue)
        {
            string Request = "";
            ACC_M003_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SGList.Where(x => x.ac_group_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ac_group_code = POPUPEntityObject.ac_group_code;


                }
            }
            catch (Exception ex) { }
        }

        #endregion
        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_B> result)
        {

            try
            {
                if (Validation() == true)
                {
                    MasterEntity.edit_by = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<ACC_M003_B>>(MasterEntity, "AccountSubGroupCode", "Finance");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<ACC_M003_B>>(MasterEntity, "AccountSubGroupCode", "Finance");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.ac_sg_code != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.ac_sg_code != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();

                    }
                    NewRecord = false;
                    var msg = new NotificationMessage("FICO_M0008_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
            try
            {
                if (MasterEntity != null)
                {

                    TOList.Add(MasterEntity);

                    TOCollection1 = CollectionViewSource.GetDefaultView(TOList);
                    TOCollection1.Refresh();


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

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_B> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_B> result)
        {
            MasterEntity = new ACC_M003_B();

            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_B> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_B> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ACC_M003_B> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ACC_M003_B> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ACC_M003_B> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_B> result)
        {

        }



        #endregion
        #region Filters

        #region Filters For DataGrid   

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_TOCollection1 != null)
            {
                _TOCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.ac_group_code != null && data.ac_group_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.sg_parent_code != null && data.sg_parent_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.sg_parent_Id != null && data.sg_parent_Id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.seq_no != null && data.seq_no.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.ac_sg_code != null && data.ac_sg_code.ToString().Contains(_filterString.ToLower()) ||
                             data.ac_sg_name != null && data.ac_sg_name.ToString().Contains(_filterString.ToLower()));


                }
                return true;
            }
            return false;
        }








        #endregion

        #endregion
    }
}
