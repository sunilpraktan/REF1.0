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

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0023_VM : WorkspaceViewModel<ADM_M003_C>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M003_C>> repository = new WebServiceRepository<List<ADM_M003_C>>();
        WebServiceRepository<MultipleContext_ADM_M003_C> repository_MC = new WebServiceRepository<MultipleContext_ADM_M003_C>();
        WebServiceRepository<MultipleContext_ADM_M003_C> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M003_C>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0023_VM));
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

        private MultipleContext_ADM_M003_C _MC;
        public MultipleContext_ADM_M003_C MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M003_C _MCTemp;
        public MultipleContext_ADM_M003_C MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M003_C _MCTemp1;
        public MultipleContext_ADM_M003_C MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M003_C _MasterEntity;
        public ADM_M003_C MasterEntity
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

        private int _dgSelectedIndexBP;
        public int dgSelectedIndexBP
        {
            get
            { return _dgSelectedIndexBP; }
            set
            {
                if (_dgSelectedIndexBP != value)
                {
                    _dgSelectedIndexBP = value;
                    RaisePropertyChanged("dgSelectedIndexBP");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M003_C> _BPCollection;
        public ObservableCollection<ADM_M003_C> BPCollection
        {
            get { return _BPCollection; }
            set
            {
                if (_BPCollection != value)
                {
                    _BPCollection = value;
                    RaisePropertyChanged("BPCollection");
                }
            }
        }

        private ICollectionView _BPCollection1;
        public ICollectionView BPCollection1
        {
            get { return _BPCollection1; }
            set { _BPCollection1 = value; RaisePropertyChanged("BPCollection1"); }
        }

        private List<ADM_M003_C> _SelectedList;
        public List<ADM_M003_C> SelectedList
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
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public FICO_M0023_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M003_C();
            BPCollection = new ObservableCollection<ADM_M003_C>();

            MC = new MultipleContext_ADM_M003_C();
            MCTemp = new MultipleContext_ADM_M003_C();
            MCTemp1 = new MultipleContext_ADM_M003_C();

            CmdAddCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items, false, true, true); });
            CmdAddState = new RelayCommand<object>(items => { if (items == null) { return; } InsertState(items, false, false, true); });


            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M003_C>(MC, Request, "BusinessPlaceMaster", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                BPCollection = MC.BPList;
                //SelectedList = (MC.BPList).ToList();
                SelectedList = BPCollection.ToList();

                BPCollection1 = CollectionViewSource.GetDefaultView(MC.BPList);
                BPCollection1.Filter = new Predicate<object>(Filter);

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
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.edit_by = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }

        private bool Validation()
        {
            //if (MasterEntity.buss_place == null || MasterEntity.buss_place == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter the Business Place...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}            
            if (MasterEntity.country_code == null || MasterEntity.country_code == "")
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
                    var InputValueIfExists = BPCollection.Where(X => X.country_code == POPUPEntityObject.country_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = BPCollection.IndexOf(BPCollection.Where(X => X.country_code == POPUPEntityObject.country_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexBP >= 0 && BPCollection.Count > dgSelectedIndexBP) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (BPCollection[dgSelectedIndexBP].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {

                            BPCollection[dgSelectedIndexBP].country_code = POPUPEntityObject.country_code;
                            state = (from o in MC.StateList
                                     where o.country_code == BPCollection[dgSelectedIndexBP].country_code
                                     select o).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).state_code);
                            TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASState = new AutoSuggestTextViewModel<dynamic>(state, TheFilter, SuggestedValue, "state_code", "state_code", true);
                            ASState.AutoSuggestVM.IsEmptyValueAllowed = true;

                        }
                        else if (BPCollection[dgSelectedIndexBP].country_code != POPUPEntityObject.country_code)
                        {

                            BPCollection[dgSelectedIndexBP].country_code = POPUPEntityObject.country_code;
                            state = (from o in MC.StateList
                                     where o.country_code == BPCollection[dgSelectedIndexBP].country_code
                                     select o).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).state_code);
                            TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASState = new AutoSuggestTextViewModel<dynamic>(state, TheFilter, SuggestedValue, "state_code", "state_code", true);
                            ASState.AutoSuggestVM.IsEmptyValueAllowed = true;

                        }
                    }

                }
                #region Clear Empty Row
                ADM_M003_C newObj = new ADM_M003_C();
                for (int i = BPCollection.Count - 1; i >= 0; i--)
                {
                    bool xx = BPCollection[i].ComparePropertiesTo(newObj);
                    if (BPCollection[i].ComparePropertiesTo(newObj) == true && BPCollection.Count > 1)
                    {
                        BPCollection.RemoveAt(i);
                        if (BPCollection.Count == 0)
                        {
                            BPCollection.Add(newObj);
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
            //    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M013_P>().Count() > 0)
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M003_C> result)
        {
            try
            {
                List<ADM_M003_C> RequestList = new List<ADM_M003_C>();
                foreach (ADM_M003_C item in BPCollection)
                {
                    if (item.Click == true)
                    {
                        item.comp_code = MasterEntity.comp_code;
                        item.location_Id = MasterEntity.location_Id;
                        item.add_by = MasterEntity.add_by;
                        item.edit_by = MasterEntity.edit_by;
                        item.client = AppSessionState.client;
                        //item.active = MasterEntity.active;
                        item.user_source1 = MasterEntity.user_source1;
                        item.user_source2 = MasterEntity.user_source2;

                        RequestList.Add(item);

                        MasterEntity.buss_place = item.buss_place;   //For Validation Purpose
                        MasterEntity.country_code = item.country_code;   //For Validation Purpose
                        MasterEntity.state_code = item.state_code;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M003_C>>(RequestList, "BusinessPlaceMaster", "Administration");

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
                if (MC.BPList != null)
                {
                    BPCollection.Clear();
                    //MC.RevenueList = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.RevenueList, MC.RevenueList);

                }
                else
                {
                    MC.BPList = new ObservableCollection<ADM_M003_C>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M003_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M003_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M003_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M003_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M003_C> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M003_C> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M003_C();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M003_C> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M003_C> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M003_C> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M003_C> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M003_C> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M003_C> result)
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
            if (_BPCollection1 != null)
            {
                _BPCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M003_C;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.buss_place != null && data.buss_place.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.plc_name != null && data.plc_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.plc_desc != null && data.plc_desc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.state_tax_code != null && data.state_tax_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterString.ToLower())
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
