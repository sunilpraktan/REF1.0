using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.BusinessEntity.Finance;
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
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.BusinessEntity;
using System.IO;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Finance.ViewModels
{
    public class ACC_M003_Z_VM : WorkspaceViewModel<ACC_M003_Z>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_Z>> repository = new WebServiceRepository<List<ACC_M003_Z>>();
        WebServiceRepository<MultipleContext_ACC_M003_Z> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_Z>();
        WebServiceRepository<MultipleContext_ACC_M003_Z> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003_Z>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ACC_M003_Z_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASApplication { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASApplication
        {
            get { return _ASApplication; }
            set
            {
                if (_ASApplication != value)
                {
                    _ASApplication = value; RaisePropertyChanged("ASApplication");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASConType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASConType
        {
            get { return _ASConType; }
            set
            {
                if (_ASConType != value)
                {
                    _ASConType = value; RaisePropertyChanged("ASConType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCOA_Key { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCOA_Key
        {
            get { return _ASCOA_Key; }
            set
            {
                if (_ASCOA_Key != value)
                {
                    _ASCOA_Key = value; RaisePropertyChanged("ASCOA_Key");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPGCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPGCode
        {
            get { return _ASPGCode; }
            set
            {
                if (_ASPGCode != value)
                {
                    _ASPGCode = value; RaisePropertyChanged("ASPGCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPOCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPOCode
        {
            get { return _ASPOCode; }
            set
            {
                if (_ASPOCode != value)
                {
                    _ASPOCode = value; RaisePropertyChanged("ASPOCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccGrParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccGrParty
        {
            get { return _ASAccGrParty; }
            set
            {
                if (_ASAccGrParty != value)
                {
                    _ASAccGrParty = value; RaisePropertyChanged("ASAccGrParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccGrItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccGrItem
        {
            get { return _ASAccGrItem; }
            set
            {
                if (_ASAccGrItem != value)
                {
                    _ASAccGrItem = value; RaisePropertyChanged("ASAccGrItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTransKeyCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTransKeyCode
        {
            get { return _ASTransKeyCode; }
            set
            {
                if (_ASTransKeyCode != value)
                {
                    _ASTransKeyCode = value; RaisePropertyChanged("ASTransKeyCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGLCodeDebit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGLCodeDebit
        {
            get { return _ASGLCodeDebit; }
            set
            {
                if (_ASGLCodeDebit != value)
                {
                    _ASGLCodeDebit = value; RaisePropertyChanged("ASGLCodeDebit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGLCodeCredit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGLCodeCredit
        {
            get { return _ASGLCodeCredit; }
            set
            {
                if (_ASGLCodeCredit != value)
                {
                    _ASGLCodeCredit = value; RaisePropertyChanged("ASGLCodeCredit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCat
        {
            get { return _ASItemCat; }
            set
            {
                if (_ASItemCat != value)
                {
                    _ASItemCat = value; RaisePropertyChanged("ASItemCat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDocCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocCat
        {
            get { return _ASDocCat; }
            set
            {
                if (_ASDocCat != value)
                {
                    _ASDocCat = value; RaisePropertyChanged("ASDocCat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("ASDocType");
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
                    if (SourceName == "Application")
                    { ASDefault = ASApplication; }
                    else if (SourceName == "ConditionType")
                    { ASDefault = ASConType; }
                    else if (SourceName == "COA_Key")
                    { ASDefault = ASCOA_Key; }
                    else if (SourceName == "PGCode")
                    { ASDefault = ASPGCode; }
                    else if (SourceName == "POCode")
                    { ASDefault = ASPOCode; }
                    else if (SourceName == "AccGrParty")
                    { ASDefault = ASAccGrParty; }
                    else if (SourceName == "AccGrItem")
                    { ASDefault = ASAccGrItem; }
                    else if (SourceName == "TransKeyCode")
                    { ASDefault = ASTransKeyCode; }
                    else if (SourceName == "GLCodeDebit")
                    { ASDefault = ASGLCodeDebit; }
                    else if (SourceName == "GLCodeCredit")
                    { ASDefault = ASGLCodeCredit; }
                    else if (SourceName == "ItemCat")
                    { ASDefault = ASItemCat; }
                    else if (SourceName == "DocCat")
                    { ASDefault = ASDocCat; }
                    else if (SourceName == "DocType")
                    { ASDefault = ASDocType; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ACC_M003_Z _MC;
        public MultipleContext_ACC_M003_Z MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_Z _MCTemp;
        public MultipleContext_ACC_M003_Z MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ACC_M003_Z _MCTemp1;
        public MultipleContext_ACC_M003_Z MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ACC_M003_Z _MasterEntity;
        public ACC_M003_Z MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexPurchase;
        public int dgSelectedIndexPurchase
        {
            get
            { return _dgSelectedIndexPurchase; }
            set
            {
                if (_dgSelectedIndexPurchase != value)
                {
                    _dgSelectedIndexPurchase = value;
                    RaisePropertyChanged("dgSelectedIndexPurchase");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M003_Z> _PurchaseCollection;
        public ObservableCollection<ACC_M003_Z> PurchaseCollection
        {
            get { return _PurchaseCollection; }
            set
            {
                if (_PurchaseCollection != value)
                {
                    _PurchaseCollection = value;
                    RaisePropertyChanged("PurchaseCollection");
                }
            }
        }

        private List<ACC_M003_Z> _SelectedList;
        public List<ACC_M003_Z> SelectedList
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

        public RelayCommand<object> cmdDefinePostingKey { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDetail { get; private set; }

        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public ACC_M003_Z_VM() : base()
        {
            MasterEntity = new ACC_M003_Z();
            PurchaseCollection = new ObservableCollection<ACC_M003_Z>();

            MC = new MultipleContext_ACC_M003_Z();
            MCTemp = new MultipleContext_ACC_M003_Z();
            MCTemp1 = new MultipleContext_ACC_M003_Z();

            #region .Command Initialisation.

            cmdDefinePostingKey = new RelayCommand<object>(items => { if (items == null) { return; } View_DefinePostingKey(items); });
            cmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });
            #endregion

            try
            {
                if ((AppSessionState.TransValue != null && AppSessionState.TransValue.ToString() != "") && (AppSessionState.TransValueType.ToString() == "purchase"))
                {
                    LoadInitialData(AppSessionState.TransValue.ToString());
                    AppSessionState.TransValue = null;
                    AppSessionState.TransParameter = null;
                    AppSessionState.ViewOtherRecordAllowed = true;
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

        #region User Defined Functions
        private void LoadInitialData(string strKey)
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + strKey;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_Z>(MC, Request, "AccountDetermination_Purchase", "Finance", "LoadInitialData", 0, "");
                MasterEntity.trns_key_code = strKey;

                PurchaseCollection = MC.PurchaseList;
                //SelectedList = (MC.PurchaseList).ToList();
                SelectedList = PurchaseCollection.ToList();
                //PurchaseCollection.Filter = new Predicate<object>(Filter);  

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_J_P)x).trans_scope);
                TheFilter = (o, prefix) => (((ACC_M003_J_P)o).trans_scope ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ApplicationList, TheFilter, SuggestedValue, "trans_scope", "trans_scope", false);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_J_P)x).trans_scope);
                TheFilter = (o, prefix) => (((ACC_M003_J_P)o).trans_scope ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASApplication = new AutoSuggestTextViewModel<dynamic>(MC.ApplicationList, TheFilter, SuggestedValue, "trans_scope", "trans_scope", false);
                ASApplication.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_S1_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_S1_P)o).con_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASConType = new AutoSuggestTextViewModel<dynamic>(MC.ConTypeList, TheFilter, SuggestedValue, "con_type", "con_type", false);
                ASConType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_D_P)x).coa_key);
                TheFilter = (o, prefix) => (((ACC_M003_D_P)o).coa_key ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCOA_Key = new AutoSuggestTextViewModel<dynamic>(MC.COAKeyList, TheFilter, SuggestedValue, "coa_key", "coa_key", false);
                ASCOA_Key.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code);
                TheFilter = (o, prefix) => (((ADM_M001_P_P)o).pg_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPGCode = new AutoSuggestTextViewModel<dynamic>(MC.PGCodeList, TheFilter, SuggestedValue, "pg_code", "pg_code", false);
                ASPGCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPOCode = new AutoSuggestTextViewModel<dynamic>(MC.POCodeList, TheFilter, SuggestedValue, "po_code", "po_code", false);
                ASPOCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H_P)x).acc_group_type);
                TheFilter = (o, prefix) => (((ACC_M003_H_P)o).acc_group_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccGrParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyAccGroupList, TheFilter, SuggestedValue, "party_acc_group", "acc_group_type", false);
                ASAccGrParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H_P)x).acc_group_type);
                TheFilter = (o, prefix) => (((ACC_M003_H_P)o).acc_group_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccGrItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemAccGroupList, TheFilter, SuggestedValue, "item_acc_group", "acc_group_type", false);
                ASAccGrItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_E_P)x).trns_key_code);
                TheFilter = (o, prefix) => (((ACC_M003_E_P)o).trns_key_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTransKeyCode = new AutoSuggestTextViewModel<dynamic>(MC.TransKeyCodeList, TheFilter, SuggestedValue, "trns_key_code", "trns_key_code", false);
                ASTransKeyCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGLCodeDebit = new AutoSuggestTextViewModel<dynamic>(MC.DebitGLCodeList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", false);
                ASGLCodeDebit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGLCodeCredit = new AutoSuggestTextViewModel<dynamic>(MC.CreditGLCodeList, TheFilter, SuggestedValue, "gl_code_c", "gl_code", false);
                ASGLCodeCredit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M003_P)x).sditem_cat_code);
                TheFilter = (o, prefix) => (((SYS_M003_P)o).sditem_cat_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItemCat = new AutoSuggestTextViewModel<dynamic>(MC.ItemCatList, TheFilter, SuggestedValue, "item_cat", "sditem_cat_code", false);
                ASItemCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M001_P)x).doc_cat);
                TheFilter = (o, prefix) => (((SYS_M001_P)o).doc_cat ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDocCat = new AutoSuggestTextViewModel<dynamic>(MC.DocCatList, TheFilter, SuggestedValue, "doc_cat", "doc_cat", false);
                ASDocCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002_P)x).doc_type);
                TheFilter = (o, prefix) => (((SYS_M002_P)o).doc_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocTypeList, TheFilter, SuggestedValue, "doc_type", "doc_type", false);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                //DefaultValues();
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
            //    MasterEntity.location_Id = AppSessionState.location_Id;
            //    MasterEntity.comp_code = AppSessionState.comp_code;
            //    MasterEntity.add_by = AppSessionState.UserID;
            //    MasterEntity.editby = AppSessionState.UserID;
            //    MasterEntity.entry_dt = DateTime.Now;        
            //    MasterEntity.doc_cat = "FR";
            //    MasterEntity.doc_type = "FR";
            //    MasterEntity.user_source1 = AppSessionState.UserSource1;
            //    MasterEntity.user_source2 = AppSessionState.UserSource2;
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
        private void View_DefinePostingKey(object InputValue)
        {
            try
            {
                if (MasterEntity.trns_key_code != null && MasterEntity.trns_key_code != "")
                {
                    AppSessionState.ViewTitle = "Define Posting Key";
                    AppSessionState.TransValue = MasterEntity.trns_key_code;// + "!@" + POPUPEntityObject.test_code;
                    AppSessionState.TransValueType = "FROM_ACC_M003_Z_VM";
                    AppSessionState.TransParameter = "FromAccountDetermination_purchase";
                    AppSessionState.ViewOtherRecordAllowed = true;
                }

                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType("Reflection.Modules.Finance.Views.DefinePostingKey");
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
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
        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (PurchaseCollection.Count > i && PurchaseCollection[dgSelectedIndexPurchase].line_id  == 0)
                {
                    PurchaseCollection.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_Z> result)
        {
            try
            {
                List<ACC_M003_Z> RequestList = new List<ACC_M003_Z>();
                foreach (ACC_M003_Z item in PurchaseCollection)
                {
                    if (item.Click == true)
                    {
                        if (item.line_id == 0 && item.active == false)
                        {
                            item.active = true;
                        }
                        item.trns_key_code = MasterEntity.trns_key_code;
                        RequestList.Add(item);
                    }
                }
               

                string strReturn = repository.Save<List<ACC_M003_Z>>(RequestList, "AccountDetermination_Purchase", "Finance");

                if (strReturn != null && strReturn != "" )
                {
                    PurchaseCollection.Clear();
                    MC.PurchaseList = new ObservableCollection<ACC_M003_Z>();
                    MC = (MultipleContext_ACC_M003_Z)new ObjectSerializationService().XMLToObject(strReturn, MC);
                    PurchaseCollection = MC.PurchaseList;
                }
                else
                {
                    PurchaseCollection = new ObservableCollection<ACC_M003_Z>();
                }

                if (MC.PurchaseList != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                    showMessageService.ShowMessage();
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_Z> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_Z> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_Z> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_Z> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_Z> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_Z> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_Z();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_Z> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_Z> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_Z> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_Z> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_Z> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_Z> result)
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
            if (_PurchaseCollection != null)
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
