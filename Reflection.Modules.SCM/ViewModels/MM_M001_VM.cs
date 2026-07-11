using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.ViewModel;
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
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_M001_VM : WorkspaceViewModel<MM_M001>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<MM_M001>> repository = new WebServiceRepository<List<MM_M001>>();
        WebServiceRepository<MultipleContext_MM_M001> repository_MC = new WebServiceRepository<MultipleContext_MM_M001>();

        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_M001_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompany
        {
            get { return _ASCompany; }
            set
            {
                if (_ASCompany != value)
                {
                    _ASCompany = value;
                    RaisePropertyChanged("ASCompany");
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
                    _ASLocation = value;
                    RaisePropertyChanged("ASLocation");
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
                    if (SourceName == "comp_code")
                    { ASDefault = ASCompany; }

                    else if (SourceName == "location_Id")
                    { ASDefault = ASLocation; }
                }
            }
        }

        #endregion

        #region Declarations   
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_MM_M001 _MC;
        public MultipleContext_MM_M001 MC
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
        private MultipleContext_MM_M001 _MCTemp;
        public MultipleContext_MM_M001 MCTemp
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
        private MM_M001 _MasterEntity;
        public MM_M001 MasterEntity
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
        private int _dgSelectedIndexStore;
        public int dgSelectedIndexStore
        {
            get
            { return _dgSelectedIndexStore; }
            set
            {
                if (_dgSelectedIndexStore != value)
                {
                    _dgSelectedIndexStore = value;
                    RaisePropertyChanged("dgSelectedIndexStore");
                }
            }
        }
        private List<ADM_M003_P> _location;
        public List<ADM_M003_P> location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    RaisePropertyChanged("location");
                }
            }
        }
        #endregion

        #region ICollectionView

        private ObservableCollection<MM_M001> _StorageCollection;
        public ObservableCollection<MM_M001> StorageCollection
        {
            get { return _StorageCollection; }
            set
            {
                if (_StorageCollection != value)
                {
                    _StorageCollection = value;
                    RaisePropertyChanged("StorageCollection");
                }
            }
        }

        private ICollectionView _StorageCollection1;
        public ICollectionView StorageCollection1
        {
            get { return _StorageCollection1; }
            set
            {
                if (_StorageCollection1 != value)
                {
                    _StorageCollection1 = value;
                    RaisePropertyChanged("StorageCollection1");
                }
            }
        }

        private List<MM_M001> _SelectedList;
        public List<MM_M001> SelectedList
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
        public RelayCommand<object> CmdCompany { get; private set; }
        public RelayCommand<object> CmdLocation { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region  Constructor

        public MM_M001_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new MM_M001();
            StorageCollection = new ObservableCollection<MM_M001>();

            MC = new MultipleContext_MM_M001();
            MCTemp = new MultipleContext_MM_M001();


            LoadinitialData();
        }
        public MM_M001_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.ts_code_vm = doc_no;
            MasterEntity = new MM_M001();
            StorageCollection = new ObservableCollection<MM_M001>();

            MC = new MultipleContext_MM_M001();
            MCTemp = new MultipleContext_MM_M001();
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MM_M001>(MC, Request, "Store_Location", "SCM", "LoadInitialData", 0, "");
                #region Command Initialisation
                CmdCompany = new RelayCommand<object>(items => { if (items == null) { return; } Insert_Company(items, false, true, true); });
                CmdLocation = new RelayCommand<object>(items => { if (items == null) { return; } Insert_Location(items, false, true, true); });
                //cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                DefaultValues();

                StorageCollection = MC.StorageLocationList;
                SelectedList = StorageCollection.ToList();

                StorageCollection1 = CollectionViewSource.GetDefaultView(MC.StorageLocationList);
                StorageCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_P)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002_P)o).CompName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.CompanyList, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_P)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002_P)o).CompName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>(MC.CompanyList, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        }
        private bool Validation()
        {
            //foreach (var o in StorageCollection)
            //{
            //    if (o.location_Id == null || o.location_Id == "")
            //    {

            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Select Location");

            //        showMessageService.ShowMessage();
            //        return false;

            //    }
            //    if (o.store_code == null || o.store_code == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Select Store");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }

            //}

            return true;
        }
        private void Insert_Company(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.CompanyList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.CompName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = StorageCollection.Where(x => x.comp_code == POPUPEntityObject.comp_code).FirstOrDefault();
                    var IndexOfExistValue = StorageCollection.IndexOf(StorageCollection.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault());

                    if (dgSelectedIndexStore >= 0 && StorageCollection.Count > dgSelectedIndexStore)
                    {
                        //if (StorageCollection[dgSelectedIndexStore].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            StorageCollection[dgSelectedIndexStore].comp_code = POPUPEntityObject.comp_code;
                            StorageCollection[dgSelectedIndexStore].CompName = POPUPEntityObject.CompName;

                            location = (from o in MC.LocationList
                                        where o.comp_code == StorageCollection[dgSelectedIndexStore].comp_code
                                        select o).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id ?? "");
                            TheFilter = (o, prefix) => (((ADM_M003_P)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_P)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASLocation = new AutoSuggestTextViewModel<dynamic>(location, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                            ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                        else if (StorageCollection[dgSelectedIndexStore].comp_code != POPUPEntityObject.comp_code)
                        {
                            StorageCollection[dgSelectedIndexStore].comp_code = POPUPEntityObject.comp_code;
                            StorageCollection[dgSelectedIndexStore].CompName = POPUPEntityObject.CompName;

                            location = (from o in MC.LocationList
                                        where o.comp_code == StorageCollection[dgSelectedIndexStore].comp_code
                                        select o).ToList();


                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id ?? "");
                            TheFilter = (o, prefix) => (((ADM_M003_P)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_P)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASLocation = new AutoSuggestTextViewModel<dynamic>(location, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                            ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        //private void Insert_Comapny(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M002_P POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                {
        //                    POPUPEntityObject = MC.CompanyList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.CompName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
        //                }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_P>().ToList()[0];
        //        }

        //        #endregion

        //        if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
        //        {
        //            var InputValueIfExists = StorageCollection.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
        //            int IndexOfExistValue = StorageCollection.IndexOf(StorageCollection.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

        //            if (dgSelectedIndexStore >= 0 && StorageCollection.Count > dgSelectedIndexStore) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
        //            {
        //                if (StorageCollection[dgSelectedIndexStore].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
        //                {

        //                    StorageCollection[dgSelectedIndexStore].comp_code = POPUPEntityObject.comp_code;
        //                    StorageCollection[dgSelectedIndexStore].CompName = POPUPEntityObject.CompName;

        //                    location = (from o in MC.LocationList
        //                                where o.comp_code == StorageCollection[dgSelectedIndexStore].comp_code
        //                                select o).ToList();

        //                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id);
        //                    TheFilter = (o, prefix) => (((ADM_M003_P)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
        //                    ASLocation = new AutoSuggestTextViewModel<dynamic>(location, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
        //                    ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

        //                }
        //                else if (StorageCollection[dgSelectedIndexStore].comp_code != POPUPEntityObject.comp_code)
        //                {

        //                    StorageCollection[dgSelectedIndexStore].comp_code = POPUPEntityObject.comp_code;
        //                    StorageCollection[dgSelectedIndexStore].CompName = POPUPEntityObject.CompName;

        //                    location = (from o in MC.LocationList
        //                                where o.comp_code == StorageCollection[dgSelectedIndexStore].comp_code
        //                                select o).ToList();

        //                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id);
        //                    TheFilter = (o, prefix) => (((ADM_M003_P)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
        //                    ASLocation = new AutoSuggestTextViewModel<dynamic>(location, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
        //                    ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

        //                }
        //            }

        //        }
        //        #region Clear Empty Row
        //        MM_M001 newObj = new MM_M001();
        //        for (int i = StorageCollection.Count - 1; i >= 0; i--)
        //        {
        //            bool xx = StorageCollection[i].ComparePropertiesTo(newObj);
        //            if (StorageCollection[i].ComparePropertiesTo(newObj) == true && StorageCollection.Count > 1)
        //            {
        //                StorageCollection.RemoveAt(i);
        //                if (StorageCollection.Count == 0)
        //                {
        //                    StorageCollection.Add(newObj);
        //                }
        //            }
        //        }
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        private void Insert_Location(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = location.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    var InputValueIfExists = StorageCollection.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = StorageCollection.IndexOf(StorageCollection.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexStore >= 0 && StorageCollection.Count > dgSelectedIndexStore) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            StorageCollection[dgSelectedIndexStore].location_Id = POPUPEntityObject.location_Id;
                            StorageCollection[dgSelectedIndexStore].LoctnNm = POPUPEntityObject.LoctnNm;
                        }

                        else if (StorageCollection[dgSelectedIndexStore].location_Id != POPUPEntityObject.location_Id)
                        {
                            StorageCollection[dgSelectedIndexStore].location_Id = POPUPEntityObject.location_Id;
                            StorageCollection[dgSelectedIndexStore].LoctnNm = POPUPEntityObject.LoctnNm;
                        }

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
        //private void WindowEvetCall(object InputValue)
        //{
        //    try
        //    {
        //        if (doc_no_vm != null && ts_code_vm != null)
        //        {
        //            LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
        //            isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
        //            AppSessionState.ViewOtherRecordAllowed = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<MM_M001> result)
        {
            isNewRecord = true;
            MasterEntity = new MM_M001();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MM_M001> result)
        {
            try
            {
                List<MM_M001> RequestList = new List<MM_M001>();
                foreach (MM_M001 item in StorageCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = "";
                    strReturn = repository.Save<List<MM_M001>>(RequestList, "Store_Location", "SCM");

                    if (SelectedList != null)
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
        protected override void OnRefreshCommand(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_M001> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

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
            if (_StorageCollection1 != null)
            {
                _StorageCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString.ToLower())
                             );
                }
                return true;
            }
            return false;
        }

      
        #endregion
    }
}
