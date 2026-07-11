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
    class SDM_M0007_VM : WorkspaceViewModel<ADM_M001_G>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_G>> repository = new WebServiceRepository<List<ADM_M001_G>>();
        WebServiceRepository<MultipleContext_ADM_M001_G> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_G>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0007_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASSalesOrganization { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesOrganization
        {
            get { return _ASSalesOrganization; }
            set
            {
                if (_ASSalesOrganization != value)
                {
                    _ASSalesOrganization = value; RaisePropertyChanged("ASSalesOrganization");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASChannel { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASChannel
        {
            get { return _ASChannel; }
            set
            {
                if (_ASChannel != value)
                {
                    _ASChannel = value; RaisePropertyChanged("ASChannel");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
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
                    if (SourceName == "SalesOrg")
                    { ASDefault = ASSalesOrganization; }
                    else if (SourceName == "DistChannel")
                    { ASDefault = ASChannel; }
                    else if (SourceName == "locName")
                    { ASDefault = ASLocation; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_G _MC;
        public MultipleContext_ADM_M001_G MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_G _MCTemp;
        public MultipleContext_ADM_M001_G MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }


        private ADM_M001_G _MasterEntity;
        public ADM_M001_G MasterEntity
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



        private int _dgSelectedIndexsp;
        public int dgSelectedIndexsp
        {
            get
            { return _dgSelectedIndexsp; }
            set
            {
                if (_dgSelectedIndexsp != value)
                {
                    _dgSelectedIndexsp = value;
                    RaisePropertyChanged("dgSelectedIndexsp");
                }
            }
        }

        #endregion


        #region ICollectionView

        private ObservableCollection<ADM_M001_G> _SOCollection;
        public ObservableCollection<ADM_M001_G> SOCollection
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

        private List<ADM_M001_G> _SelectedList;
        public List<ADM_M001_G> SelectedList
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
        public RelayCommand<object> CmdAddChannel { get; private set; }
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public SDM_M0007_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_G();
            SOCollection = new ObservableCollection<ADM_M001_G>();

            MC = new MultipleContext_ADM_M001_G();
            MCTemp = new MultipleContext_ADM_M001_G();


            CmdAddSalesOrganization = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrganization(items, false, true, true); });
            CmdAddChannel = new RelayCommand<object>(items => { if (items == null) { return; } InsertChannel(items, false, true, true); });
            CmdAddLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items, false, true, true); });
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_G>(MC, Request, "AssignPlantToSalesOrg_DistriChannel", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.SPList;
                //SelectedList = (MC.SOList).ToList();
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.SPList);
                SOCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_A_P)o).sales_org.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.SOList, TheFilter, SuggestedValue, "so_code", "so_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_A_P)o).sales_org.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSalesOrganization = new AutoSuggestTextViewModel<dynamic>(MC.SOList, TheFilter, SuggestedValue, "sales_org", "sales_org", true);
                ASSalesOrganization.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_C_P)o).dc_name.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASChannel = new AutoSuggestTextViewModel<dynamic>(MC.DCList, TheFilter, SuggestedValue, "dc_code", "dc_code", true);
                ASChannel.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_P)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_P)o).LoctnNm.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(MC.PntList, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;


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
                MasterEntity = (ADM_M001_G)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_G item in e.NewItems)
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
            //if (MasterEntity.so_code == null || MasterEntity.so_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Select the Sales Organization Code");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.so_code == null || MasterEntity.so_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Select the Company Code");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

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
                            POPUPEntityObject = MC.SOList.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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

                    if (dgSelectedIndexsp >= 0 && SOCollection.Count > dgSelectedIndexsp) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexsp].so_code = POPUPEntityObject.so_code;
                        SOCollection[dgSelectedIndexsp].sales_org = POPUPEntityObject.sales_org;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexsp].so_code != POPUPEntityObject.so_code)
                    {
                        SOCollection[dgSelectedIndexsp].so_code = POPUPEntityObject.so_code;
                        SOCollection[dgSelectedIndexsp].sales_org = POPUPEntityObject.sales_org;
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




        private void InsertChannel(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = MC.DCList.Where(x => x.dc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.dc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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


                    if (dgSelectedIndexsp >= 0 && SOCollection.Count > dgSelectedIndexsp) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexsp].dc_code = POPUPEntityObject.dc_code;
                        SOCollection[dgSelectedIndexsp].dc_name = POPUPEntityObject.dc_name;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexsp].dc_code != POPUPEntityObject.dc_code)
                    {
                        SOCollection[dgSelectedIndexsp].dc_code = POPUPEntityObject.dc_code;
                        SOCollection[dgSelectedIndexsp].dc_name = POPUPEntityObject.dc_name;
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
            string Request = "";
            ADM_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.PntList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {

                    if (dgSelectedIndexsp >= 0 && SOCollection.Count > dgSelectedIndexsp)
                    {

                        SOCollection[dgSelectedIndexsp].location_Id = POPUPEntityObject.location_Id;
                        SOCollection[dgSelectedIndexsp].LoctnNm = POPUPEntityObject.LoctnNm;
                    }
                    else if (SOCollection[dgSelectedIndexsp].location_Id != POPUPEntityObject.location_Id)
                    {
                        SOCollection[dgSelectedIndexsp].location_Id = POPUPEntityObject.location_Id;
                        SOCollection[dgSelectedIndexsp].LoctnNm = POPUPEntityObject.LoctnNm;
                    }
                }


            }
            catch (Exception ex) { }
        }

        #endregion



        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_G> result)
        {
            try
            {
                List<ADM_M001_G> RequestList = new List<ADM_M001_G>();
                foreach (ADM_M001_G item in SOCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_G>>(RequestList, "AssignPlantToSalesOrg_DistriChannel", "Administration");

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
                List<ADM_M001_G> RequestList = new List<ADM_M001_G>();
                RequestList = SOCollection.ToList();
                foreach (ADM_M001_G item in RequestList)
                {
                    if (item.Click == true)
                    {
                        SOCollection.Remove(item);
                    }
                }
                if (strReturn != "")
                {
                    MC.SPList = (ObservableCollection<ADM_M001_G>)obj.XMLToObject(strReturn, MC.SPList);
                    SOCollection.Add(MC.SPList[0]);
                }
                else
                {
                    MC.SPList = new ObservableCollection<ADM_M001_G>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_G> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_G> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_G();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_G> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_G> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_G> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_G> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_G> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_G> result)
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
            var data = obj as ADM_M001_G;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.dc_code != null && data.dc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString.ToLower())
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
