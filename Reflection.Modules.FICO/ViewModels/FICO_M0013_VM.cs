using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0013_VM : WorkspaceViewModel<ACC_M003_N>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_N>> repository = new WebServiceRepository<List<ACC_M003_N>>();
        WebServiceRepository<MultipleContext_ACC_M003_N> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_N>();
        WebServiceRepository<MultipleContext_ACC_M003_N> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003_N>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0013_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASConditionType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASConditionType
        {
            get { return _ASConditionType; }
            set
            {
                if (_ASConditionType != value)
                {
                    _ASConditionType = value; RaisePropertyChanged("ASConditionType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTransactionKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTransactionKey
        {
            get { return _ASTransactionKey; }
            set
            {
                if (_ASTransactionKey != value)
                {
                    _ASTransactionKey = value; RaisePropertyChanged("ASTransactionKey");
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
                    if (SourceName == "ConditionType")
                    { ASDefault = ASConditionType; }
                    else if (SourceName == "TransactionKey")
                    { ASDefault = ASConditionType; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ACC_M003_N _MC;
        public MultipleContext_ACC_M003_N MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_N _MCTemp;
        public MultipleContext_ACC_M003_N MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ACC_M003_N _MCTemp1;
        public MultipleContext_ACC_M003_N MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ACC_M003_N _MasterEntity;
        public ACC_M003_N MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexPriPro;
        public int dgSelectedIndexPriPro
        {
            get
            { return _dgSelectedIndexPriPro; }
            set
            {
                if (_dgSelectedIndexPriPro != value)
                {
                    _dgSelectedIndexPriPro = value;
                    RaisePropertyChanged("dgSelectedIndexPriPro");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M003_N> _PricingProCollection;
        public ObservableCollection<ACC_M003_N> PricingProCollection
        {
            get { return _PricingProCollection; }
            set
            {
                if (_PricingProCollection != value)
                {
                    _PricingProCollection = value;
                    RaisePropertyChanged("PricingProCollection");
                }
            }
        }

        private List<ACC_M003_N> _SelectedList;
        public List<ACC_M003_N> SelectedList
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
        public RelayCommand<object> CmdConditionType { get; private set; }
        public RelayCommand<object> CmdTransactionKey { get; private set; }
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public FICO_M0013_VM(string ts_code) : base()
        {
            //MasterEntity = new ACC_M003_N();
            PricingProCollection = new ObservableCollection<ACC_M003_N>();

            MC = new MultipleContext_ACC_M003_N();
            MCTemp = new MultipleContext_ACC_M003_N();
            MCTemp1 = new MultipleContext_ACC_M003_N();

            CmdConditionType = new RelayCommand<object>(items => { if (items == null) { return; } InsertConditionType(items, true, true, true); });
            CmdTransactionKey = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransactionKey(items, true, true, true); });

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData";// + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_N>(MC, Request, "PricingProcedure", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                PricingProCollection = MC.PricingProEntity;
                //SelectedList = (MC.TransactionKeyEntity).ToList();
                SelectedList = PricingProCollection.ToList();
                //PricingProCollection.Filter = new Predicate<object>(Filter);   

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ConditionType, TheFilter, SuggestedValue, "condition_type", "con_type", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASConditionType = new AutoSuggestTextViewModel<dynamic>(MC.ConditionType, TheFilter, SuggestedValue, "condition_type", "con_type", true);
                ASConditionType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_E_P)x).trns_key_code);
                TheFilter = (o, prefix) => (((ACC_M003_E_P)o).trns_key_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_E_P)o).trns_key_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTransactionKey = new AutoSuggestTextViewModel<dynamic>(MC.TransactionKey, TheFilter, SuggestedValue, "trns_key_code", "trns_key_code", true);
                ASTransactionKey.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            //    MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            //    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            //    MasterEntity.add_by = AppSessionState.UserID;
            //    MasterEntity.editby = AppSessionState.UserID;
            //    MasterEntity.entry_dt = DateTime.Now;
            //    MasterEntity.active = true;
            //    MasterEntity.doc_cat = "FR";
            //    MasterEntity.doc_type = "FR";
            //    MasterEntity.user_source1 = AppSessionState.UserSource1;
            //    MasterEntity.user_source2 = AppSessionState.UserSource2;
        }

        private void InsertConditionType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ACC_M003_O_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ConditionType.Where(x => x.con_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_O_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_O_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexPriPro >= 0 && PricingProCollection.Count > dgSelectedIndexPriPro)
                    {
                        if (PricingProCollection[dgSelectedIndexPriPro].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            PricingProCollection[dgSelectedIndexPriPro].condition_type = POPUPEntityObject.con_type;
                            PricingProCollection[dgSelectedIndexPriPro].condition_desc = POPUPEntityObject.con_desc;

                        }
                        else if (PricingProCollection[dgSelectedIndexPriPro].condition_type != POPUPEntityObject.con_type)
                        {
                            PricingProCollection[dgSelectedIndexPriPro].condition_type = POPUPEntityObject.con_type;
                            PricingProCollection[dgSelectedIndexPriPro].condition_desc = POPUPEntityObject.con_desc;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void InsertTransactionKey(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ACC_M003_E_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TransactionKey.Where(x => x.trns_key_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_E_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_E_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexPriPro >= 0 && PricingProCollection.Count > dgSelectedIndexPriPro)
                    {
                        if (PricingProCollection[dgSelectedIndexPriPro].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            PricingProCollection[dgSelectedIndexPriPro].trns_key_code = POPUPEntityObject.trns_key_code;
                            PricingProCollection[dgSelectedIndexPriPro].trns_key_desc = POPUPEntityObject.trns_key_desc;
                        }
                        else if (PricingProCollection[dgSelectedIndexPriPro].trns_key_code != POPUPEntityObject.trns_key_code)
                        {
                            PricingProCollection[dgSelectedIndexPriPro].trns_key_code = POPUPEntityObject.trns_key_code;
                            PricingProCollection[dgSelectedIndexPriPro].trns_key_desc = POPUPEntityObject.trns_key_desc;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private bool Validation()
        {
            //    if (MasterEntity.tb_code == null || MasterEntity.tb_code == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Enter the Test Bed No...");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }
            //    else if (MasterEntity.project == null || MasterEntity.project == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Enter the Project...");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }
            return true;
        }

        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_N> result)
        {
            try
            {
                List<ACC_M003_N> RequestList = new List<ACC_M003_N>();
                foreach (ACC_M003_N item in PricingProCollection)
                {
                    if (item.Click == true)
                    {
                        RequestList.Add(item);

                    }
                }
                string strReturn = repository.Save<List<ACC_M003_N>>(RequestList, "PricingProcedure", "Finance");

                if (SelectedList != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                    showMessageService.ShowMessage();
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
                if (MC.PricingProEntity != null)
                {
                    PricingProCollection.Clear();
                    // MC.TransactionKeyEntity = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.TransactionKeyEntity, MC.TransactionKeyEntity);

                }
                else
                {
                    MC.PricingProEntity = new ObservableCollection<ACC_M003_N>();
                }
                //if (MasterEntity.XmlDataDocument_ESEL_T001_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                //{
                //    MC.BackFlipEntity = (List<ESEL_T001_A_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_ESEL_T001_Flip, MC.BackFlipEntity);
                //    FlipGridData.Add(MC.BackFlipEntity[0]);
                //    DataGridCollection.Refresh();
                //}
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_N> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_N> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_N> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_N> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_N> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_N> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_N();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_N> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_N> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_N> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_N> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_N> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_N> result)
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
            if (_PricingProCollection != null)
            {
                //_TransactionKeyCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_N;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.pricing_pro != null && data.pricing_pro.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.condition_type != null && data.condition_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.name != null && data.name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.trns_key_code != null && data.trns_key_code.ToString().ToLower().Contains(_filterString.ToLower())
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
