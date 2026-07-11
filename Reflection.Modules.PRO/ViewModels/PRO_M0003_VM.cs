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

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_M0003_VM : WorkspaceViewModel<ADM_M001_O>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_O>> repository = new WebServiceRepository<List<ADM_M001_O>>();
        WebServiceRepository<MultipleContext_ADM_M001_O> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_O>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_M0003_VM));
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



        private AutoSuggestTextViewModel<dynamic> _Aspurchaseorganisation { get; set; }
        public AutoSuggestTextViewModel<dynamic> Aspurchaseorganisation
        {
            get { return _Aspurchaseorganisation; }
            set
            {
                if (_Aspurchaseorganisation != value)
                {
                    _Aspurchaseorganisation = value; RaisePropertyChanged("Aspurchaseorganisation");
                }
            }
        }




        private AutoSuggestTextViewModel<dynamic> _AsLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsLocation
        {
            get { return _AsLocation; }
            set
            {
                if (_AsLocation != value)
                {
                    _AsLocation = value; RaisePropertyChanged("AsLocation");
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
                    if (SourceName == "POCode")
                    { ASDefault = Aspurchaseorganisation; }
                    else if (SourceName == "location_Id")
                    { ASDefault = AsLocation; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_O _MC;
        public MultipleContext_ADM_M001_O MC
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

        private MultipleContext_ADM_M001_O _MCTemp;
        public MultipleContext_ADM_M001_O MCTemp
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


        private ADM_M001_O _MasterEntity;
        public ADM_M001_O MasterEntity
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



        private int _dgSelectedIndexAssignPO;
        public int dgSelectedIndexAssignPO
        {
            get
            { return _dgSelectedIndexAssignPO; }
            set
            {
                if (_dgSelectedIndexAssignPO != value)
                {
                    _dgSelectedIndexAssignPO = value;
                    RaisePropertyChanged("dgSelectedIndexAssignPO");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_O> _SOCollection;
        public ObservableCollection<ADM_M001_O> SOCollection
        {
            get { return _SOCollection; }
            set
            {
                if (_SOCollection != value)
                {
                    _SOCollection = value;
                    SOCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("SOCollection");
                }
            }
        }

        private ICollectionView _SOCollection1;
        public ICollectionView SOCollection1
        {
            get { return _SOCollection1; }
            set { _SOCollection1 = value; RaisePropertyChanged("SOCollection1"); }
        }

        private List<ADM_M001_O> _SelectedList;
        public List<ADM_M001_O> SelectedList
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

        public RelayCommand<object> CmdAddPurchaseOrganisation { get; private set; }
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public PRO_M0003_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_O();
            SOCollection = new ObservableCollection<ADM_M001_O>();

            MC = new MultipleContext_ADM_M001_O();
            MCTemp = new MultipleContext_ADM_M001_O();


            CmdAddPurchaseOrganisation = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrganization(items, false, true, true); });
            CmdAddLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items, false, false, true); });
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            SOCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);


            LoadInitialData();
        }



        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_O>(MC, Request, "PurchaseOrgAssignToPlant", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.POCode;
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(SOCollection);
                SOCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.PurOrg, TheFilter, SuggestedValue, "po_code", "po_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Aspurchaseorganisation = new AutoSuggestTextViewModel<dynamic>(MC.PurOrg, TheFilter, SuggestedValue, "po_code", "po_code", true);
                Aspurchaseorganisation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003_P)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsLocation = new AutoSuggestTextViewModel<dynamic>(MC.Location, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                AsLocation.AutoSuggestVM.IsEmptyValueAllowed = true;


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
                MasterEntity = (ADM_M001_O)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_O item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
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
            foreach (var o in SOCollection)
            {
                if (o.po_code == null || o.po_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter PO Code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.location_Id == null || o.location_Id == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Location Id for PO Code {0}", o.po_code);
                    showMessageService.ShowMessage();
                    return false;
                }

            }
            return true;
        }

        private void InsertOrganization(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_M_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.PurOrg.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.pur_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexAssignPO >= 0 && SOCollection.Count > dgSelectedIndexAssignPO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexAssignPO].po_code = POPUPEntityObject.po_code;
                        SOCollection[dgSelectedIndexAssignPO].pur_org = POPUPEntityObject.pur_org;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexAssignPO].po_code != POPUPEntityObject.po_code)
                    {
                        SOCollection[dgSelectedIndexAssignPO].po_code = POPUPEntityObject.po_code;
                        SOCollection[dgSelectedIndexAssignPO].pur_org = POPUPEntityObject.pur_org;
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

        private void InsertLocation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.Location.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexAssignPO >= 0 && SOCollection.Count > dgSelectedIndexAssignPO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexAssignPO].location_Id = POPUPEntityObject.location_Id;
                        SOCollection[dgSelectedIndexAssignPO].LoctnNm = POPUPEntityObject.LoctnNm;
                        SOCollection[dgSelectedIndexAssignPO].comp_code = POPUPEntityObject.comp_code;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexAssignPO].location_Id != POPUPEntityObject.location_Id)
                    {
                        SOCollection[dgSelectedIndexAssignPO].location_Id = POPUPEntityObject.location_Id;
                        SOCollection[dgSelectedIndexAssignPO].LoctnNm = POPUPEntityObject.LoctnNm;
                        SOCollection[dgSelectedIndexAssignPO].comp_code = POPUPEntityObject.comp_code;
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_O> result)
        {
            try
            {
                List<ADM_M001_O> RequestList = new List<ADM_M001_O>();
                foreach (ADM_M001_O item in SOCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M001_O>>(RequestList, "PurchaseOrgAssignToPlant", "Administration");

                    if (strReturn != null)
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_O> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_O> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_O();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_O> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_O> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_O> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_O> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_O> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_O> result)
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
            if (_SOCollection1 != null)
            {
                _SOCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_O;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString.ToLower())
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
