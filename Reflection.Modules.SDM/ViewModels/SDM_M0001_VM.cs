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
    public class SDM_M0001_VM : WorkspaceViewModel<ADM_M001_A>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_A>> repository = new WebServiceRepository<List<ADM_M001_A>>();
        WebServiceRepository<MultipleContext_ADM_M001_A> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_A>();
        WebServiceRepository<MultipleContext_ADM_M001_A> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M001_A>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0001_VM));
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
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCountry { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCountry
        {
            get { return _ASCountry; }
            set
            {
                if (_ASCountry != value)
                {
                    _ASCountry = value; RaisePropertyChanged("ASCountry");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASState { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASState
        {
            get { return _ASState; }
            set
            {
                if (_ASState != value)
                {
                    _ASState = value; RaisePropertyChanged("ASState");
                }
            }
        }

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
                    if (SourceName == "Country")
                    { ASDefault = ASCountry; }
                    else if (SourceName == "State")
                    { ASDefault = ASState; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_A _MC;
        public MultipleContext_ADM_M001_A MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_A _MCTemp;
        public MultipleContext_ADM_M001_A MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M001_A _MCTemp1;
        public MultipleContext_ADM_M001_A MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M001_A _MasterEntity;
        public ADM_M001_A MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private List<ADM_M013_P> _state;
        public List<ADM_M013_P> state
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    RaisePropertyChanged("state");
                }
            }
        }

        private int _dgSelectedIndexSO;
        public int dgSelectedIndexSO
        {
            get
            { return _dgSelectedIndexSO; }
            set
            {
                if (_dgSelectedIndexSO != value)
                {
                    _dgSelectedIndexSO = value;
                    RaisePropertyChanged("dgSelectedIndexSO");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_A> _SOCollection;
        public ObservableCollection<ADM_M001_A> SOCollection
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

        private List<ADM_M001_A> _SelectedList;
        public List<ADM_M001_A> SelectedList
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdAddCountry { get; private set; }
        public RelayCommand<object> CmdAddState { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public SDM_M0001_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_A();
            SOCollection = new ObservableCollection<ADM_M001_A>();

            MC = new MultipleContext_ADM_M001_A();
            MCTemp = new MultipleContext_ADM_M001_A();
            MCTemp1 = new MultipleContext_ADM_M001_A();

            CmdAddCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items, false, true, true); });
            CmdAddState = new RelayCommand<object>(items => { if (items == null) { return; } InsertState(items, false, false, true); });
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_A>(MC, Request, "SalesOrganisationMaster", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.SOList;
                //SelectedList = (MC.SOList).ToList();
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.SOList);
                SOCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code);
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "country_code", "country_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code);
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCountry = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "country_code", "country_code", true);
                ASCountry.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }

        private bool Validation()
        {
            if (MasterEntity.so_code == null || MasterEntity.so_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the SO Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.sales_org == null || MasterEntity.sales_org == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Sales Organisation...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.country_code == null || MasterEntity.country_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select the Country...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.state_code == null || MasterEntity.state_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select the State...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }

        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_A item in e.NewItems)
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

        private void InsertCountry(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M012_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.CountryList.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = SOCollection.Where(X => X.country_code == POPUPEntityObject.country_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = SOCollection.IndexOf(SOCollection.Where(X => X.country_code == POPUPEntityObject.country_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexSO >= 0 && SOCollection.Count > dgSelectedIndexSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (SOCollection[dgSelectedIndexSO].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {

                            SOCollection[dgSelectedIndexSO].country_code = POPUPEntityObject.country_code;
                            state = (from o in MC.StateList
                                     where o.country_code == SOCollection[dgSelectedIndexSO].country_code
                                     select o).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).state_code);
                            TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASState = new AutoSuggestTextViewModel<dynamic>(state, TheFilter, SuggestedValue, "state_code", "state_code", true);
                            ASState.AutoSuggestVM.IsEmptyValueAllowed = true;

                        }
                        else if (SOCollection[dgSelectedIndexSO].country_code != POPUPEntityObject.country_code)
                        {

                            SOCollection[dgSelectedIndexSO].country_code = POPUPEntityObject.country_code;
                            state = (from o in MC.StateList
                                     where o.country_code == SOCollection[dgSelectedIndexSO].country_code
                                     select o).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).state_code);
                            TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASState = new AutoSuggestTextViewModel<dynamic>(state, TheFilter, SuggestedValue, "state_code", "state_code", true);
                            ASState.AutoSuggestVM.IsEmptyValueAllowed = true;

                        }
                    }

                }
                #region Clear Empty Row
                ADM_M001_A newObj = new ADM_M001_A();
                for (int i = SOCollection.Count - 1; i >= 0; i--)
                {
                    bool xx = SOCollection[i].ComparePropertiesTo(newObj);
                    if (SOCollection[i].ComparePropertiesTo(newObj) == true && SOCollection.Count > 1)
                    {
                        SOCollection.RemoveAt(i);
                        if (SOCollection.Count == 0)
                        {
                            SOCollection.Add(newObj);
                        }
                    }
                }
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
        private void InsertState(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            //string Request = "";
            //ADM_M013_P POPUPEntityObject = null;
            //try
            //{
            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            try
            //            { POPUPEntityObject = state.Where(x => x.StatName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
            //            catch (Exception ex)
            //            {
            //            }
            //        }
            //    }
            //    else if (InputValue != null )
            //    {
            //        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M013_P>().ToList()[0];
            //    }
            //    if (POPUPEntityObject != null)
            //    {
            //        var InputValueIfExists = SOCollection.Where(x => x.state_code == POPUPEntityObject.state_code).FirstOrDefault();
            //        var IndexOfExistValue = SOCollection.IndexOf(SOCollection.Where(X => X.state_code == POPUPEntityObject.state_code).FirstOrDefault());

            //        if (dgSelectedIndexSO >= 0 && SOCollection.Count > dgSelectedIndexSO)
            //        {
            //            if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
            //            {
            //                SOCollection[dgSelectedIndexSO].state_code = POPUPEntityObject.state_code;
            //                //SOCollection[dgSelectedIndexSO].StatName = POPUPEntityObject.StatName;
            //            }
            //            else if (SOCollection[dgSelectedIndexSO].state_code != POPUPEntityObject.state_code)
            //            {
            //                SOCollection[dgSelectedIndexSO].state_code = POPUPEntityObject.state_code;
            //                //SOCollection[dgSelectedIndexSO].StatName = POPUPEntityObject.StatName;
            //            }
            //        }

            //    }
            //}
            //catch (Exception ex) { }
        }


        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_A> result)
        {
            try
            {
                List<ADM_M001_A> RequestList = new List<ADM_M001_A>();
                foreach (ADM_M001_A item in SOCollection)
                {
                    if (item.Click == true)
                    {
                        item.comp_code = MasterEntity.comp_code;
                        item.add_by = MasterEntity.add_by;
                        item.editby = MasterEntity.editby;
                        //item.active = MasterEntity.active;
                        item.user_source1 = MasterEntity.user_source1;
                        item.user_source2 = MasterEntity.user_source2;

                        RequestList.Add(item);

                        MasterEntity.so_code = item.so_code;   //For Validation Purpose
                        MasterEntity.sales_org = item.sales_org;   //For Validation Purpose
                        MasterEntity.country_code = item.country_code;   //For Validation Purpose
                        MasterEntity.state_code = item.state_code;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M001_A>>(RequestList, "SalesOrganisationMaster", "Administration");

                    if (SelectedList != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                //SetBusinessEntitiesAfterLoad("Save", "");
                //isNewRecord = false;
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
                if (MC.SOList != null)
                {
                    SOCollection.Clear();
                    //MC.RevenueList = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.RevenueList, MC.RevenueList);

                }
                else
                {
                    MC.SOList = new ObservableCollection<ADM_M001_A>();
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
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_A> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_A();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_A> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_A> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_A> result)
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
            if (_SOCollection1 != null)
            {
                _SOCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.address != null && data.address.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.city != null && data.city.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.district != null && data.district.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pin != null && data.pin.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.lang != null && data.lang.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.phone != null && data.phone.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ph_ext != null && data.ph_ext.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.fax != null && data.fax.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.fax_ext != null && data.fax_ext.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.email != null && data.email.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.notes != null && data.notes.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString.ToLower())
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
