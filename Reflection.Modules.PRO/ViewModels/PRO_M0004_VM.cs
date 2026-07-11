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
    public class PRO_M0004_VM : WorkspaceViewModel<ADM_M001_Q>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_Q>> repository = new WebServiceRepository<List<ADM_M001_Q>>();
        WebServiceRepository<MultipleContext_ADM_M001_Q> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_Q>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_M0004_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASPurchaseOrganization { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurchaseOrganization
        {
            get { return _ASPurchaseOrganization; }
            set
            {
                if (_ASPurchaseOrganization != value)
                {
                    _ASPurchaseOrganization = value; RaisePropertyChanged("_ASPurchaseOrganization");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGroup
        {
            get { return _ASGroup; }
            set
            {
                if (_ASGroup != value)
                {
                    _ASGroup = value; RaisePropertyChanged("ASGroup");
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
                    if (SourceName == "Group")
                    { ASDefault = ASGroup; }
                    else if (SourceName == "Purchaseorg")
                    { ASDefault = ASPurchaseOrganization; }

                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_Q _MC;
        public MultipleContext_ADM_M001_Q MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_Q _MCTemp;
        public MultipleContext_ADM_M001_Q MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }


        private ADM_M001_Q _MasterEntity;
        public ADM_M001_Q MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }



        private int _dgSelectedIndexAP;
        public int dgSelectedIndexAP
        {
            get
            { return _dgSelectedIndexAP; }
            set
            {
                if (_dgSelectedIndexAP != value)
                {
                    _dgSelectedIndexAP = value;
                    RaisePropertyChanged("_dgSelectedIndexAP");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_Q> _POCollection;
        public ObservableCollection<ADM_M001_Q> POCollection
        {
            get { return _POCollection; }
            set
            {
                if (_POCollection != value)
                {
                    _POCollection = value;
                    POCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("POCollection");
                }
            }
        }

        private ICollectionView _POCollection1;
        public ICollectionView POCollection1
        {
            get { return _POCollection1; }
            set { _POCollection1 = value; RaisePropertyChanged("POCollection1"); }
        }

        private List<ADM_M001_Q> _SelectedList;
        public List<ADM_M001_Q> SelectedList
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
        public RelayCommand<object> CmdAddGroup { get; private set; }
        public RelayCommand<object> CmdAddPurchaseOrganization { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }

        #endregion

        #region Constructor
        public PRO_M0004_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_Q();
            POCollection = new ObservableCollection<ADM_M001_Q>();

            MC = new MultipleContext_ADM_M001_Q();
            MCTemp = new MultipleContext_ADM_M001_Q();


            CmdAddPurchaseOrganization = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrganization(items, false, true, true); });
            CmdAddGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertGroup(items, false, true, true); });
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            POCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);



            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_Q>(MC, Request, "AssignPurGroupToPurOrg", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                POCollection = MC.APList;
                //SelectedList = (MC.SOList).ToList();
                SelectedList = POCollection.ToList();

                POCollection1 = CollectionViewSource.GetDefaultView(MC.APList);
                POCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_P_P)o).pg_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_P_P)o).pg_name.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.PGList, TheFilter, SuggestedValue, "pg_code", "pg_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_P_P)o).pg_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_P_P)o).pg_name.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGroup = new AutoSuggestTextViewModel<dynamic>(MC.PGList, TheFilter, SuggestedValue, "pg_code", "pg_code", true);
                ASGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_M_P)o).pur_org.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPurchaseOrganization = new AutoSuggestTextViewModel<dynamic>(MC.POList, TheFilter, SuggestedValue, "po_code", "po_code", true);
                ASPurchaseOrganization.AutoSuggestVM.IsEmptyValueAllowed = true;




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
                MasterEntity = (ADM_M001_Q)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_Q item in e.NewItems)
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
            foreach (var o in POCollection)
            {
                if (o.pg_code == null || o.pg_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Purchase Group Code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.po_code == null || o.po_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Purchase Organization Code");

                    showMessageService.ShowMessage();
                    return false;

                }

            }


            return true;
        }

        private void InsertGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.PGList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.pg_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAP >= 0 && POCollection.Count > dgSelectedIndexAP) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        POCollection[dgSelectedIndexAP].pg_code = POPUPEntityObject.pg_code;
                        POCollection[dgSelectedIndexAP].pg_name = POPUPEntityObject.pg_name;

                        MasterEntity.active = true;
                    }
                    else if (POCollection[dgSelectedIndexAP].pg_code != POPUPEntityObject.pg_code)
                    {
                        POCollection[dgSelectedIndexAP].pg_code = POPUPEntityObject.pg_code;
                        POCollection[dgSelectedIndexAP].pg_name = POPUPEntityObject.pg_name;
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




        private void InsertPurchaseOrganization(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = MC.POList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.pur_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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


                    if (dgSelectedIndexAP >= 0 && POCollection.Count > dgSelectedIndexAP) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        POCollection[dgSelectedIndexAP].po_code = POPUPEntityObject.po_code;
                        POCollection[dgSelectedIndexAP].pur_org = POPUPEntityObject.pur_org;

                        MasterEntity.active = true;
                    }
                    else if (POCollection[dgSelectedIndexAP].po_code != POPUPEntityObject.po_code)
                    {
                        POCollection[dgSelectedIndexAP].po_code = POPUPEntityObject.po_code;
                        POCollection[dgSelectedIndexAP].pur_org = POPUPEntityObject.pur_org;
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_Q> result)
        {
            try
            {
                List<ADM_M001_Q> RequestList = new List<ADM_M001_Q>();
                foreach (ADM_M001_Q item in POCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_Q>>(RequestList, "AssignPurGroupToPurOrg", "Administration");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
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

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                List<ADM_M001_Q> RequestList = new List<ADM_M001_Q>();
                RequestList = POCollection.ToList();
                foreach (ADM_M001_Q item in RequestList)
                {
                    if (item.Click == true)
                    {
                        POCollection.Remove(item);
                    }
                }
                if (strReturn != "")
                {
                    MC.APList = (ObservableCollection<ADM_M001_Q>)obj.XMLToObject(strReturn, MC.APList);
                    POCollection.Add(MC.APList[0]);
                }
                else
                {
                    MC.APList = new ObservableCollection<ADM_M001_Q>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_Q> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_Q> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_Q> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_Q> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_Q> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_Q> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_Q();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_Q> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_Q> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_Q> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_Q> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_Q> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_Q> result)
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
            if (_POCollection1 != null)
            {
                _POCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_Q;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
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
