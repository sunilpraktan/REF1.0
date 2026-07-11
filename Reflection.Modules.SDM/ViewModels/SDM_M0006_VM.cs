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
    public class SDM_M0006_VM : WorkspaceViewModel<ADM_M001_B>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_B>> repository = new WebServiceRepository<List<ADM_M001_B>>();
        WebServiceRepository<MultipleContext_ADM_M001_B> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_B>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0006_VM));
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



        private AutoSuggestTextViewModel<dynamic> _Assalesorganization { get; set; }
        public AutoSuggestTextViewModel<dynamic> Assalesorganization
        {
            get { return _Assalesorganization; }
            set
            {
                if (_Assalesorganization != value)
                {
                    _Assalesorganization = value; RaisePropertyChanged("Assalesorganization");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _Ascompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> Ascompany
        {
            get { return _Ascompany; }
            set
            {
                if (_Ascompany != value)
                {
                    _Ascompany = value; RaisePropertyChanged("Ascompany");
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
                    if (SourceName == "Sales_Org")
                    { ASDefault = Assalesorganization; }
                    else if (SourceName == "company_name")
                    { ASDefault = Ascompany; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_B _MC;
        public MultipleContext_ADM_M001_B MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private ADM_M001_B _MasterEntity;
        public ADM_M001_B MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }



        private int _dgSelectedIndexAssignSO;
        public int dgSelectedIndexAssignSO
        {
            get
            { return _dgSelectedIndexAssignSO; }
            set
            {
                if (_dgSelectedIndexAssignSO != value)
                {
                    _dgSelectedIndexAssignSO = value;
                    RaisePropertyChanged("dgSelectedIndexAssignSO");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_B> _SOCollection;
        public ObservableCollection<ADM_M001_B> SOCollection
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
            set
            {
                if (_SOCollection1 != value)
                {
                    _SOCollection1 = value; RaisePropertyChanged("SOCollection1");
                }
            }
        }

        private List<ADM_M001_B> _SelectedList;
        public List<ADM_M001_B> SelectedList
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

        public RelayCommand<object> CmdAddSalesOrganization { get; private set; }
        public RelayCommand<object> CmdAddCompany { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public SDM_M0006_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_B();
            SOCollection = new ObservableCollection<ADM_M001_B>();

            MC = new MultipleContext_ADM_M001_B();

            CmdAddSalesOrganization = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrganization(items, false, true, true); });
            CmdAddCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items, false, true, true); });
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_B>(MC, Request, "salesorgassigncompany", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.organizationassignlist;
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.organizationassignlist);
                SOCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_A_P)o).sales_org.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.sorganizationlist, TheFilter, SuggestedValue, "so_code", "so_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_A_P)o).sales_org.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Assalesorganization = new AutoSuggestTextViewModel<dynamic>(MC.sorganizationlist, TheFilter, SuggestedValue, "sales_org", "sales_org", true);
                Assalesorganization.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_P)x).comp_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M002_P)o).comp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M002_P)o).CompName.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Ascompany = new AutoSuggestTextViewModel<dynamic>(MC.companylist, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                Ascompany.AutoSuggestVM.IsEmptyValueAllowed = true;




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
                MasterEntity = (ADM_M001_B)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_B item in e.NewItems)
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


            return true;
        }

        private void InsertOrganization(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = MC.sorganizationlist.Where(x => x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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

                    if (dgSelectedIndexAssignSO >= 0 && SOCollection.Count > dgSelectedIndexAssignSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexAssignSO].so_code = POPUPEntityObject.so_code;
                        SOCollection[dgSelectedIndexAssignSO].sales_org = POPUPEntityObject.sales_org;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexAssignSO].so_code != POPUPEntityObject.so_code)
                    {
                        SOCollection[dgSelectedIndexAssignSO].so_code = POPUPEntityObject.so_code;
                        SOCollection[dgSelectedIndexAssignSO].sales_org = POPUPEntityObject.sales_org;
                        MasterEntity.active = true;
                    }


                }
                #region Clear Empty Row
                ADM_M001_B newObj = new ADM_M001_B();
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
        private void InsertCompany(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M002_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.companylist.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.CompName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M002_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {

                    if (dgSelectedIndexAssignSO >= 0 && SOCollection.Count > dgSelectedIndexAssignSO)
                    {

                        SOCollection[dgSelectedIndexAssignSO].comp_code = POPUPEntityObject.comp_code;
                        SOCollection[dgSelectedIndexAssignSO].CompName = POPUPEntityObject.CompName;
                    }
                    else if (SOCollection[dgSelectedIndexAssignSO].comp_code != POPUPEntityObject.comp_code)
                    {
                        SOCollection[dgSelectedIndexAssignSO].comp_code = POPUPEntityObject.comp_code;
                        SOCollection[dgSelectedIndexAssignSO].CompName = POPUPEntityObject.CompName;
                    }
                }


            }
            catch (Exception ex) { }
        }


        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_B> result)
        {
            try
            {
                List<ADM_M001_B> RequestList = new List<ADM_M001_B>();
                foreach (ADM_M001_B item in SOCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_B>>(RequestList, "salesorgassigncompany", "Administration");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                //  SetBusinessEntitiesAfterLoad("Save", "");
                // isNewRecord = false;
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
                List<ADM_M001_B> RequestList = new List<ADM_M001_B>();
                RequestList = SOCollection.ToList();
                foreach (ADM_M001_B item in RequestList)
                {
                    if (item.Click == true)
                    {
                        SOCollection.Remove(item);
                    }
                }
                if (strReturn != "")
                {
                    MC.organizationassignlist = (ObservableCollection<ADM_M001_B>)obj.XMLToObject(strReturn, MC.organizationassignlist);
                    SOCollection.Add(MC.organizationassignlist[0]);
                }
                else
                {
                    MC.organizationassignlist = new ObservableCollection<ADM_M001_B>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_B> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_B> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_B();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_B> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_B> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_B> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_B> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_B> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_B> result)
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
            var data = obj as ADM_M001_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString.ToLower())
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
