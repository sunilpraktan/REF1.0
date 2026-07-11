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
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Admin;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0003_VM : WorkspaceViewModel<ACC_M019>
    {
        bool NewRecord = true;

        WebServiceRepository<ACC_M019> repository = new WebServiceRepository<ACC_M019>();
        WebServiceRepository<MultipleContext_ACC_M019> repository_MC = new WebServiceRepository<MultipleContext_ACC_M019>();
        WebServiceRepository<MultipleContext_ACC_M019> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M019>();
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
        private AutoSuggestTextViewModel<dynamic> _ASProfit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProfit
        {
            get { return _ASProfit; }
            set
            {
                if (_ASProfit != value)
                {
                    _ASProfit = value; RaisePropertyChanged("ASProfit");
                }
            }
        }

        #endregion
        #region Relay Commands Declaration

        public RelayCommand<object> CmdDepartment { get; private set; }
        public RelayCommand<object> CmdCurrency { get; private set; }
        public RelayCommand<object> CmdProfit { get; private set; }

        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdAddAddress { get; private set; }


        #endregion
        #region Variable Declaration
        private ACC_M019 _MasterEntity;
        public ACC_M019 MasterEntity
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
        private ADM_M055 _MasterEntityRef;
        public ADM_M055 MasterEntityRef
        {
            get
            {
                return _MasterEntityRef;
            }
            set
            {
                if (_MasterEntityRef != value)
                {
                    _MasterEntityRef = value;
                }
            }
        }

        private MultipleContext_ACC_M019 _MC;
        public MultipleContext_ACC_M019 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M019 _MCTemp;
        public MultipleContext_ACC_M019 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ObservableCollection<ACC_M019> _COCollection;
        public ObservableCollection<ACC_M019> COCollection
        {
            get { return _COCollection; }
            set
            {
                if (_COCollection != value)
                {
                    _COCollection = value;
                    RaisePropertyChanged("COCollection");
                }
            }
        }

        private ICollectionView _COCollection1;
        public ICollectionView COCollection1
        {
            get { return _COCollection1; }
            set
            {
                if (_COCollection1 != value)
                {
                    _COCollection1 = value;
                    RaisePropertyChanged("COCollection1");
                }
            }
        }

        private List<ACC_M019> _SelectedList;
        public List<ACC_M019> SelectedList
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
        public FICO_M0003_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M019();
            MC = new MultipleContext_ACC_M019();
            MCTemp = new MultipleContext_ACC_M019();


            CmdDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items); });
            CmdCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
            CmdProfit = new RelayCommand<object>(items => { if (items == null) { return; } InsertProfit(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            cmdAddAddress = new GalaSoft.MvvmLight.Command.RelayCommand(() => { AddAddress(); });



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
            if (MasterEntity.cost_center == null || MasterEntity.cost_center == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Cost Center Code", MasterEntity.cost_center);
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M019>(MC, Request, "CostCenterMaster", "Administration", "LoadInitialData", 0, "");

                COCollection = MC.CostList;
                SelectedList = COCollection.ToList();

                COCollection1 = CollectionViewSource.GetDefaultView(MC.CostList);
                COCollection1.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).DeptName ?? "");
                TheFilter = (o, prefix) => (((ADM_M025_P)o).dept_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M025_P)o).DeptName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDepartment = new AutoSuggestTextViewModel<dynamic>(MC.DepartmentList, TheFilter, SuggestedValue, "cc_dept_code", true);
                ASDepartment.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "cc_curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M020_P)x).profit_center_Desc ?? "");
                TheFilter = (o, prefix) => (((ACC_M020_P)o).profit_center ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M020_P)o).profit_center_Desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASProfit = new AutoSuggestTextViewModel<dynamic>(MC.ProfitList, TheFilter, SuggestedValue, "cc_profit_center", true);
                ASProfit.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        private void SetDefaultReferenceDataForLead(ADM_M055 MasterEntityRef)
        {
            MasterEntity.cost_center = MasterEntityRef.parent_id;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {

                ACC_M019 ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ACC_M019>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M019>().ToList()[0];

                    if (MC.CostList.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    NewRecord = false;

                }


            }
            catch { }

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
                    MasterEntity.cc_dept_code = POPUPEntityObject.dept_code;
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
                    MasterEntity.cc_curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.curr_name = POPUPEntityObject.curr_name;

                }


            }
            catch (Exception ex) { }
        }
        private void InsertProfit(object InputValue)
        {
            string Request = "";
            ACC_M020_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ProfitList.Where(x => x.profit_center_Desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M020_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M020_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cc_profit_center = POPUPEntityObject.profit_center;
                    MasterEntity.profit_center_Desc = POPUPEntityObject.profit_center_Desc;

                }


            }
            catch (Exception ex) { }
        }
        private void AddAddress()
        {
            try
            {

                AppSessionState.ViewTitle = "";
                AppSessionState.ViewTitle = "Address Master";
                string userAuth = "Reflection.Modules.Administration.Views.AddressMaster"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Administration.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);

                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type, MasterEntity, "");
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion
        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M019> result)
        {

            try
            {
                if (Validation() == true)
                {

                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<ACC_M019>>(MasterEntity, "CostCenterMaster", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<List<ACC_M019>>(MasterEntity, "CostCenterMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.cost_center != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    NewRecord = false;


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
                        COCollection.Add(MasterEntity);
                        COCollection1 = CollectionViewSource.GetDefaultView(COCollection);
                        COCollection1.Refresh();
                    }
                    else if (NewRecord == false)
                    {
                        COCollection1 = CollectionViewSource.GetDefaultView(COCollection);
                        COCollection1.Filter = new Predicate<object>(Filter);
                        COCollection1.Refresh();
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M019> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M019> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M019> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M019> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M019> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M019> result)
        {

            MasterEntity = new ACC_M019();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M019> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M019> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M019> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M019> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M019> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M019> result)
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
            if (_COCollection1 != null)
            {
                _COCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M019;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.cc_dept_code != null && data.cc_dept_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                              data.cc_profit_center != null && data.cc_profit_center.ToString().ToLower().Contains(_filterString.ToLower()))

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
