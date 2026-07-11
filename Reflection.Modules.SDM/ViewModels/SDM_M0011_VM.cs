using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Admin;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0011_VM : WorkspaceViewModel<ADM_M001_L>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_L>> repository = new WebServiceRepository<List<ADM_M001_L>>();
        WebServiceRepository<MultipleContext_ADM_M001_L> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_L>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0011_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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
                    _ASDefault = value;
                    RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AsSalesOrganisation { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsSalesOrganisation
        {
            get { return _AsSalesOrganisation; }
            set
            {
                if (_AsSalesOrganisation != value)
                {
                    _AsSalesOrganisation = value;
                    RaisePropertyChanged("AsSalesOrganisation");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AsDistributionChannel { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsDistributionChannel
        {
            get { return _AsDistributionChannel; }
            set
            {
                if (_AsDistributionChannel != value)
                {
                    _AsDistributionChannel = value;
                    RaisePropertyChanged("AsDistributionChannel");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AsDivision { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsDivision
        {
            get { return _AsDivision; }
            set
            {
                if (_AsDivision != value)
                {
                    _AsDivision = value;
                    RaisePropertyChanged("AsDivision");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _AsSalesOffice { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsSalesOffice
        {
            get { return _AsSalesOffice; }
            set
            {
                if (_AsSalesOffice != value)
                {
                    _AsSalesOffice = value;
                    RaisePropertyChanged(" AsSalesOffice");
                }
            }
        }

        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                if (_cellInfo != value)
                {
                    _cellInfo = value;
                    SetAutoTextSource(_cellInfo);
                    RaisePropertyChanged("CellInfo");
                }
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
                    if (SourceName == "SO_Id")
                    { ASDefault = AsSalesOrganisation; }

                    else if (SourceName == "DC_Id")
                    { ASDefault = AsDistributionChannel; }

                    else if (SourceName == "Div_Id")
                    { ASDefault = AsDivision; }

                    else if (SourceName == "Sales_Id")
                    { ASDefault = AsSalesOffice; }

                }
            }
        }

        #endregion

        #region Declarations   

        private MultipleContext_ADM_M001_L _MC;
        public MultipleContext_ADM_M001_L MC
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

        private MultipleContext_ADM_M001_L _MCTemp;
        public MultipleContext_ADM_M001_L MCTemp
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


        private ADM_M001_L _MasterEntity;
        public ADM_M001_L MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }



        private int _dgSelectedIndexAssignToSO;
        public int dgSelectedIndexAssignToSO
        {
            get
            { return _dgSelectedIndexAssignToSO; }
            set
            {
                if (_dgSelectedIndexAssignToSO != value)
                {
                    _dgSelectedIndexAssignToSO = value;
                    RaisePropertyChanged("dgSelectedIndexAssignToSO");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_L> _SO_Collection;
        public ObservableCollection<ADM_M001_L> SO_Collection
        {
            get { return _SO_Collection; }
            set
            {
                if (_SO_Collection != value)
                {
                    _SO_Collection = value;
                    SO_Collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("SO_Collection");
                }
            }
        }

        private ICollectionView _SO_Collection1;
        public ICollectionView SO_Collection1
        {
            get { return _SO_Collection1; }
            set
            {
                if (_SO_Collection1 != value)
                {
                    _SO_Collection1 = value;
                    RaisePropertyChanged("SO_Collection1");
                }
            }
        }

        private List<ADM_M001_L> _SelectedList;
        public List<ADM_M001_L> SelectedList
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

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdAddSalesOrganisation { get; private set; }

        public RelayCommand<object> CmdAddDC_Name { get; private set; }

        public RelayCommand<object> CmdAddDiv_Name { get; private set; }

        public RelayCommand<object> CmdAddSalesOffice_Name { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }

        #endregion

        #region  Constructor

        public SDM_M0011_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_L();
            SO_Collection = new ObservableCollection<ADM_M001_L>();

            MC = new MultipleContext_ADM_M001_L();
            MCTemp = new MultipleContext_ADM_M001_L();

            CmdAddSalesOrganisation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalesOrganisation(items, false, false, true); });
            CmdAddDC_Name = new RelayCommand<object>(items => { if (items == null) { return; } InsertDistributionChannel(items, false, true, true); });
            CmdAddDiv_Name = new RelayCommand<object>(items => { if (items == null) { return; } InsertDivision(items, false, false, true); });
            CmdAddSalesOffice_Name = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalesOffice(items, false, true, true); });
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            SO_Collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions

        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_L>(MC, Request, "AssignSalesOfficeToSalesArea", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SO_Collection = MC.AssignSalesList;
                SelectedList = SO_Collection.ToList();

                SO_Collection1 = CollectionViewSource.GetDefaultView(MC.AssignSalesList);
                SO_Collection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code);
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ChannelList, TheFilter, SuggestedValue, "dc_code", "dc_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsSalesOrganisation = new AutoSuggestTextViewModel<dynamic>(MC.SOlist, TheFilter, SuggestedValue, "so_code", "so_code", true);
                AsSalesOrganisation.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code);
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsDistributionChannel = new AutoSuggestTextViewModel<dynamic>(MC.ChannelList, TheFilter, SuggestedValue, "dc_code", "dc_code", true);
                AsDistributionChannel.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_D_P)x).div_code);
                TheFilter = (o, prefix) => (((ADM_M001_D_P)o).div_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsDivision = new AutoSuggestTextViewModel<dynamic>(MC.DivisionList, TheFilter, SuggestedValue, "div_code", "div_code", true);
                AsDivision.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_I_P)x).soff_code);
                TheFilter = (o, prefix) => (((ADM_M001_I_P)o).soff_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsSalesOffice = new AutoSuggestTextViewModel<dynamic>(MC.SalesOfficeList, TheFilter, SuggestedValue, "soff_code", "soff_code", true);
                AsSalesOffice.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;

        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_L)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_L item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        //item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.Click = true;
                        item.userid = AppSessionState.UserID;
                        //item.ts_code = ts_code_vm;
                        item.active = true;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
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

        private bool Validation()
        {
            foreach (var o in SO_Collection)
            {
                if (o.so_code == null || o.so_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter SO Code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.dc_code == null || o.dc_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter DC Code for SO Code {0}", o.so_code);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (o.soff_code == null || o.soff_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Sales Office Code for SO Code {0}", o.so_code);
                    showMessageService.ShowMessage();
                    return false;
                }

            }

            return true;
        }


        private void InsertSalesOrganisation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SOlist.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignToSO >= 0 && SO_Collection.Count > dgSelectedIndexAssignToSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SO_Collection[dgSelectedIndexAssignToSO].so_code = POPUPEntityObject.so_code;
                        SO_Collection[dgSelectedIndexAssignToSO].sales_org = POPUPEntityObject.sales_org;

                        MasterEntity.active = true;
                    }
                    else if (SO_Collection[dgSelectedIndexAssignToSO].so_code != POPUPEntityObject.so_code)
                    {
                        SO_Collection[dgSelectedIndexAssignToSO].so_code = POPUPEntityObject.so_code;
                        SO_Collection[dgSelectedIndexAssignToSO].sales_org = POPUPEntityObject.sales_org;
                        MasterEntity.active = true;
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

        private void InsertDistributionChannel(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ChannelList.Where(x => x.dc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.dc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_C_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignToSO >= 0 && SO_Collection.Count > dgSelectedIndexAssignToSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SO_Collection[dgSelectedIndexAssignToSO].dc_code = POPUPEntityObject.dc_code;
                        SO_Collection[dgSelectedIndexAssignToSO].dc_name = POPUPEntityObject.dc_name;

                        MasterEntity.active = true;
                    }
                    else if (SO_Collection[dgSelectedIndexAssignToSO].dc_code != POPUPEntityObject.dc_code)
                    {
                        SO_Collection[dgSelectedIndexAssignToSO].dc_code = POPUPEntityObject.dc_code;
                        SO_Collection[dgSelectedIndexAssignToSO].dc_name = POPUPEntityObject.dc_name;
                        MasterEntity.active = true;
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

        private void InsertDivision(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_D_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.DivisionList.Where(x => x.div_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.div_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_D_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignToSO >= 0 && SO_Collection.Count > dgSelectedIndexAssignToSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SO_Collection[dgSelectedIndexAssignToSO].div_code = POPUPEntityObject.div_code;
                        SO_Collection[dgSelectedIndexAssignToSO].div_name = POPUPEntityObject.div_name;

                        MasterEntity.active = true;
                    }
                    else if (SO_Collection[dgSelectedIndexAssignToSO].div_code != POPUPEntityObject.div_code)
                    {
                        SO_Collection[dgSelectedIndexAssignToSO].div_code = POPUPEntityObject.div_code;
                        SO_Collection[dgSelectedIndexAssignToSO].div_name = POPUPEntityObject.div_name;
                        MasterEntity.active = true;
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

        private void InsertSalesOffice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_I_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SalesOfficeList.Where(x => x.soff_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_off.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_I_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignToSO >= 0 && SO_Collection.Count > dgSelectedIndexAssignToSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SO_Collection[dgSelectedIndexAssignToSO].soff_code = POPUPEntityObject.soff_code;
                        SO_Collection[dgSelectedIndexAssignToSO].sales_off = POPUPEntityObject.sales_off;

                        MasterEntity.active = true;
                    }
                    else if (SO_Collection[dgSelectedIndexAssignToSO].soff_code != POPUPEntityObject.soff_code)
                    {
                        SO_Collection[dgSelectedIndexAssignToSO].soff_code = POPUPEntityObject.soff_code;
                        SO_Collection[dgSelectedIndexAssignToSO].sales_off = POPUPEntityObject.sales_off;
                        MasterEntity.active = true;
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


        #endregion

        #region Abstract Command Actions
        string strReturn = "";

        protected override void OnCreateAction(InquiryActionResult<ADM_M001_L> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_L();

            DefaultValues();
        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M001_L> result)
        {
            try
            {
                List<ADM_M001_L> RequestList = new List<ADM_M001_L>();
                foreach (ADM_M001_L item in SO_Collection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);

                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_L>>(RequestList, "AssignSalesOfficeToSalesArea", "Administration");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_L> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_L> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_L> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_L> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_L> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_L> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_L> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M001_L> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M001_L> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M001_L> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_L> result)
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
                if (_filterString != value)
                {
                    _filterString = value;
                    RaisePropertyChanged("FilterString");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_SO_Collection1 != null)
            {
                _SO_Collection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_L;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.dc_code != null && data.dc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.div_code != null && data.div_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.soff_code != null && data.soff_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterString.ToLower())
                             );
                }
                return true;
            }
            return false;
        }



        #endregion

        #endregion
    }
}
