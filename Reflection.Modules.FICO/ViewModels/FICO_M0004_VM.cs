using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.BusinessEntity.Admin;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0004_VM : WorkspaceViewModel<ACC_M020>
    {
        bool NewRecord = true;

        WebServiceRepository<ACC_M020> repository = new WebServiceRepository<ACC_M020>();
        WebServiceRepository<MultipleContext_ACC_M020> repository_MC = new WebServiceRepository<MultipleContext_ACC_M020>();
        WebServiceRepository<MultipleContext_ACC_M020> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M020>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ACC_M019));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }

        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                }
            }
        }


        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDepartment { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDepartment
        {
            get { return _ASDepartment; }
            set
            {
                if (_ASDepartment != value)
                {
                    _ASDepartment = value; RaisePropertyChanged("ASDepartment");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCurrency
        {
            get { return _ASCurrency; }
            set
            {
                if (_ASCurrency != value)
                {
                    _ASCurrency = value; RaisePropertyChanged("ASCurrency");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdDepartment { get; private set; }
        public RelayCommand<object> CmdCurrency { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Variable Declaration
        private ACC_M020 _MasterEntity;
        public ACC_M020 MasterEntity
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

        private MultipleContext_ACC_M020 _MC;
        public MultipleContext_ACC_M020 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M020 _MCTemp;
        public MultipleContext_ACC_M020 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ObservableCollection<ACC_M020> _PCCollection;
        public ObservableCollection<ACC_M020> PCCollection
        {
            get { return _PCCollection; }
            set
            {
                if (_PCCollection != value)
                {
                    _PCCollection = value;
                    RaisePropertyChanged("PCCollection");
                }
            }
        }

        private ICollectionView _PCCollection1;
        public ICollectionView PCCollection1
        {
            get { return _PCCollection1; }
            set
            {
                if (_PCCollection1 != value)
                {
                    _PCCollection1 = value;
                    RaisePropertyChanged("PCCollection1");
                }
            }
        }

        private List<ACC_M020> _SelectedList;
        public List<ACC_M020> SelectedList
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
        public FICO_M0004_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M020();
            MC = new MultipleContext_ACC_M020();
            MCTemp = new MultipleContext_ACC_M020();


            CmdDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items); });
            CmdCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });

            LoadInitialData();

        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

        }

        private bool Validation()
        {
            if (MasterEntity.profit_center == null || MasterEntity.profit_center == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Profit Center", MasterEntity.profit_center);
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M020>(MC, Request, "ProfitCenterMaster", "Administration", "LoadInitialData", 0, "");

                PCCollection = MC.ProfitList;
                SelectedList = PCCollection.ToList();

                PCCollection1 = CollectionViewSource.GetDefaultView(MC.ProfitList);
                PCCollection1.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).DeptName ?? "");
                TheFilter = (o, prefix) => (((ADM_M025_P)o).dept_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M025_P)o).DeptName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDepartment = new AutoSuggestTextViewModel<dynamic>(MC.DepartmentList, TheFilter, SuggestedValue, "pc_dept_code", true);
                ASDepartment.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "pc_curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                string Request = "";
                ACC_M020 ParameterEntityObject = null;


                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ACC_M020>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M020>().ToList()[0];


                        if (MC.ProfitList.Count > 0)
                        {
                            MasterEntity = ParameterEntityObject;

                        }



                        SelectedTabControlIndex = 0;
                        NewRecord = false;


                        var msg = new NotificationMessage("FICO_M0004_VM");
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
        private void InsertDepartment(object InputValue)
        {
            string Request = "";
            ADM_M025_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DepartmentList.Where(x => x.DeptName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.pc_dept_code = POPUPEntityObject.dept_code;
                    MasterEntity.DeptName = POPUPEntityObject.DeptName;
                }
            }
            catch (Exception ex) { }
        }

        private void InsertCurrency(object InputValue)
        {
            string Request = "";
            ADM_M037_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M037_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.pc_curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.curr_name = POPUPEntityObject.curr_name;
                }


            }
            catch (Exception ex) { }
        }
        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M020> result)
        {

            try
            {
                if (Validation() == true)
                {

                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<ACC_M020>>(MasterEntity, "ProfitCenterMaster", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<List<ACC_M020>>(MasterEntity, "ProfitCenterMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.profit_center != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.profit_center != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    NewRecord = false;
                    var msg = new NotificationMessage("ACC_M020");
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
                    if (NewRecord == true)
                    {
                        PCCollection.Add(MasterEntity);
                        PCCollection1 = CollectionViewSource.GetDefaultView(PCCollection);
                        PCCollection1.Refresh();
                    }
                    else if (NewRecord == false)
                    {
                        PCCollection1 = CollectionViewSource.GetDefaultView(PCCollection);
                        PCCollection1.Filter = new Predicate<object>(Filter);
                        PCCollection1.Refresh();
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


        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M020> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M020> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M020> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M020> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M020> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M020> result)
        {

            MasterEntity = new ACC_M020();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M020> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M020> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M020> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M020> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M020> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M020> result)
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
            if (_PCCollection1 != null)
            {
                _PCCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M020;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.profit_center != null && data.profit_center.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.pc_dept_code != null && data.pc_dept_code.ToString().ToLower().Contains(_filterString.ToLower()))
                             ;
                }
                return true;
            }
            return false;
        }





        #endregion

        #endregion
    }
}
