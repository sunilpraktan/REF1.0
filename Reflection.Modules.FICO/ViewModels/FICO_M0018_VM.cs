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
using Reflection.BusinessEntity;
using System.IO;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services.Convertors;
using System.Collections;
using System.ComponentModel;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0018_VM : WorkspaceViewModel<ACC_M003_Y>
    {
        string strTemp = "";
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_Y>> repository = new WebServiceRepository<List<ACC_M003_Y>>();
        WebServiceRepository<MultipleContext_ACC_M003_Y> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_Y>();
        WebServiceRepository<MultipleContext_ACC_M003_Y> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003_Y>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0018_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASSGCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSGCode
        {
            get { return _ASSGCode; }
            set
            {
                if (_ASSGCode != value)
                {
                    _ASSGCode = value; RaisePropertyChanged("ASSGCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSOCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSOCode
        {
            get { return _ASSOCode; }
            set
            {
                if (_ASSOCode != value)
                {
                    _ASSOCode = value; RaisePropertyChanged("ASSOCode");
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
                    else if (SourceName == "SGCode")
                    { ASDefault = ASSGCode; }
                    else if (SourceName == "SOCode")
                    { ASDefault = ASSOCode; }
                    else if (SourceName == "party_acc_group")
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

        private MultipleContext_ACC_M003_Y _MC;
        public MultipleContext_ACC_M003_Y MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_Y _MCTemp;
        public MultipleContext_ACC_M003_Y MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ACC_M003_Y _MCTemp1;
        public MultipleContext_ACC_M003_Y MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ACC_M003_Y _MasterEntity;
        public ACC_M003_Y MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexRevenue;
        public int dgSelectedIndexRevenue
        {
            get
            { return _dgSelectedIndexRevenue; }
            set
            {
                if (_dgSelectedIndexRevenue != value)
                {
                    _dgSelectedIndexRevenue = value;
                    RaisePropertyChanged("dgSelectedIndexRevenue");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M003_Y> _RevenueCollection;
        public ObservableCollection<ACC_M003_Y> RevenueCollection
        {
            get { return _RevenueCollection; }
            set
            {
                if (_RevenueCollection != value)
                {
                    _RevenueCollection = value;
                    RaisePropertyChanged("RevenueCollection");
                }
            }
        }

        private List<ACC_M003_Y> _SelectedList;
        public List<ACC_M003_Y> SelectedList
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


        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }

        #endregion

        #region Relay Commands Declaration       
        public RelayCommand<object> cmdDefinePostingKey { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDetail { get; private set; }

        #region Relay Commands Declaration : Datagrid    
        public RelayCommand<object> CmdInsertApplication { get; private set; }
        public RelayCommand<object> CmdInsertConType { get; private set; }
        public RelayCommand<object> CmdInsertCOA_Key { get; private set; }
        public RelayCommand<object> CmdInsertSGCode { get; private set; }
        public RelayCommand<object> CmdInsertSOCode { get; private set; }
        public RelayCommand<object> CmdInsertAccGrParty { get; private set; }
        public RelayCommand<object> CmdInsertAccGrItem { get; private set; }
        public RelayCommand<object> CmdInsertTransKeyCode { get; private set; }
        public RelayCommand<object> CmdInsertGLCodeDebit { get; private set; }
        public RelayCommand<object> CmdInsertGLCodeCredit { get; private set; }
        public RelayCommand<object> CmdInsertItemCat { get; private set; }
        public RelayCommand<object> CmdInsertDocCat { get; private set; }
        public RelayCommand<object> CmdInsertDocType { get; private set; }
        #endregion
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public FICO_M0018_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_Y();
            RevenueCollection = new ObservableCollection<ACC_M003_Y>();

            MC = new MultipleContext_ACC_M003_Y();
            MCTemp = new MultipleContext_ACC_M003_Y();
            MCTemp1 = new MultipleContext_ACC_M003_Y();

            cmdDefinePostingKey = new RelayCommand<object>(items => { if (items == null) { return; } View_DefinePostingKey(items); });
            cmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });

            #region .Command Initialisation : Datagrid.

            // CmdInsertGenLedgerDetail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGeneralLedger(cmdPara, true, true, true); });
            CmdInsertApplication = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertApplication_New(cmdPara, true, true, true); });
            //CmdInsertConType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReferenceDocDetail(cmdPara, false, true, true); });
            //CmdInsertCOA_Key = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertSGCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertSOCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertAccGrParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertAccGrItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertTransKeyCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertGLCodeDebit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertGLCodeCredit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertItemCat = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertDocCat = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            //CmdInsertDocType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });
            #endregion

            try
            {
                if ((AppSessionState.TransValue != null && AppSessionState.TransValue.ToString() != "")
                    && (AppSessionState.TransParameter != null && AppSessionState.TransParameter.ToString() != "")
                    && (AppSessionState.TransValueType.ToString() == "sales_purchase"))
                {
                    LoadInitialData(AppSessionState.TransValue.ToString(), AppSessionState.TransParameter.ToString());
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

        #region Relay Command Actions : Datagrid
        private void InsertApplication_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_J_P POPUPEntityObject = null;
                List<ADM_M001_A_P> listSO_Code = new List<ADM_M001_A_P>();

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ApplicationList.Where(x => x.trans_scope.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_J_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_J_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    //var InputValueIfExists = DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_name).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    var LineId = RevenueCollection.Count + 1;

                    if (NewRow == true && (AllowDuplicate == true) && RevenueCollection.Count == dgSelectedIndexRevenue)
                    {
                        RevenueCollection.Add(new ACC_M003_Y()
                        {
                            trans_scope = POPUPEntityObject.trans_scope,
                            trans_scope_desc = POPUPEntityObject.desc_app,
                            line_id = LineId,
                            active = true,
                            client = AppSessionState.client,
                        });


                        if (POPUPEntityObject.trans_scope == "SD")
                        {
                            listSO_Code = (from o in MC.SOCodeList where o.org_type == "sales_org" select o).ToList();
                        }
                        else if (POPUPEntityObject.trans_scope == "PR")
                        {
                            listSO_Code = (from o in MC.SOCodeList where o.org_type == "pur_org" select o).ToList();
                        }
                        else
                        {
                            listSO_Code = (from o in MC.SOCodeList select o).ToList();
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                        TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                        ASSOCode = new AutoSuggestTextViewModel<dynamic>(listSO_Code, TheFilter, SuggestedValue, "so_code", "so_code", false);
                        ASSOCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (dgSelectedIndexRevenue >= 0 && RevenueCollection.Count > dgSelectedIndexRevenue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (RevenueCollection[dgSelectedIndexRevenue].line_id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            RevenueCollection[dgSelectedIndexRevenue].trans_scope = POPUPEntityObject.trans_scope;
                            RevenueCollection[dgSelectedIndexRevenue].trans_scope_desc = POPUPEntityObject.desc_app;
                            RevenueCollection[dgSelectedIndexRevenue].client = AppSessionState.client;
                            RevenueCollection[dgSelectedIndexRevenue].active = true;

                            if (RevenueCollection[dgSelectedIndexRevenue].trans_scope == "SD")
                            {
                                listSO_Code = (from o in MC.SOCodeList where o.org_type == "sales_org" select o).ToList();
                            }
                            else if (RevenueCollection[dgSelectedIndexRevenue].trans_scope == "PR")
                            {
                                listSO_Code = (from o in MC.SOCodeList where o.org_type == "pur_org" select o).ToList();
                            }
                            else
                            {
                                listSO_Code = (from o in MC.SOCodeList select o).ToList();
                            }

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                            TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASSOCode = new AutoSuggestTextViewModel<dynamic>(listSO_Code, TheFilter, SuggestedValue, "so_code", "so_code", false);
                            ASSOCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                        else if (RevenueCollection[dgSelectedIndexRevenue].trans_scope != POPUPEntityObject.trans_scope)
                        {
                            RevenueCollection[dgSelectedIndexRevenue].trans_scope = POPUPEntityObject.trans_scope;
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


        #endregion

        #region User Defined Functions
        private void LoadInitialData(string tempTrns_key_code, string tempCoaKey)
        {
            try
            {
                //string tempTrns_key_code = strKey.Split('!')[0];
                //string tempCoaKey = strKey.Split('!')[1];

                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + tempTrns_key_code + "!@" + tempCoaKey + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_Y>(MC, Request, "AccountDetermination_Revenue", "Finance", "LoadInitialData", 0, "");

                MasterEntity.trns_key_code = tempTrns_key_code;
                MasterEntity.coa_key = tempCoaKey;
                //  MasterEntity.trns_key_code = strKey;

                RevenueCollection = MC.RevenueList;

                //SelectedList = (MC.RevenueList).ToList();
                SelectedList = RevenueCollection.ToList();
                //RevenueCollection.Filter = new Predicate<object>(Filter);  

                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ApplicationList);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M026_P)x).coa_key);
                TheFilter = (o, prefix) => (((ACC_M026_P)o).coa_key ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCOA_Key = new AutoSuggestTextViewModel<dynamic>(MC.COAKeyList, TheFilter, SuggestedValue, "coa_key", "coa_key", false);
                ASCOA_Key.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSGCode = new AutoSuggestTextViewModel<dynamic>(MC.SGCodeList, TheFilter, SuggestedValue, "sg_code", "sg_code", false);
                ASSGCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSOCode = new AutoSuggestTextViewModel<dynamic>(MC.SOCodeList, TheFilter, SuggestedValue, "so_code", "so_code", false);
                ASSOCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                //var SuggestedValueWireMake = (from o in MC.PartyAccGroupList where o.acc_group_type == "Wire" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H_P)x).acc_group);
                TheFilter = (o, prefix) => (((ACC_M003_H_P)o).acc_group ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccGrParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyAccGroupList, TheFilter, SuggestedValue, "party_acc_group", "acc_group", false);
                ASAccGrParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H_P)x).acc_group);
                TheFilter = (o, prefix) => (((ACC_M003_H_P)o).acc_group ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccGrItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemAccGroupList, TheFilter, SuggestedValue, "item_acc_group", "acc_group", false);
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

                DefaultValues();
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
            MasterEntity.active = true;
        }
        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (RevenueCollection.Count > i && RevenueCollection[dgSelectedIndexRevenue].line_id == 0)
                {
                    RevenueCollection.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void View_DefinePostingKey(object InputValue)
        {
            try
            {
                if (MasterEntity.trns_key_code != null && MasterEntity.trns_key_code != "")
                {
                    AppSessionState.ViewTitle = "Define Posting Key";
                    AppSessionState.TransValue = MasterEntity.trns_key_code;// + "!@" + POPUPEntityObject.test_code;
                    AppSessionState.TransValueType = "FROM_FICO_M0018_VM";
                    AppSessionState.TransParameter = "FromAccountDetermination_sales";
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
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_Y> result)
        {
            try
            {
                List<ACC_M003_Y> RequestList = new List<ACC_M003_Y>();

                foreach (ACC_M003_Y item in RevenueCollection)
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

                if (RequestList.Count > 0)
                {
                    string strReturn = repository.Save<List<ACC_M003_Y>>(RequestList, "AccountDetermination_Revenue", "Finance");

                    if (strReturn != null && strReturn != "")
                    {
                        RevenueCollection.Clear();
                        MC.RevenueList = new ObservableCollection<ACC_M003_Y>();
                        MC = (MultipleContext_ACC_M003_Y)new ObjectSerializationService().XMLToObject(strReturn, MC);
                        RevenueCollection = MC.RevenueList;
                    }
                    else
                    {
                        RevenueCollection = new ObservableCollection<ACC_M003_Y>();
                    }

                    if (MC.RevenueList != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please select the Rows to Add/Update ");
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_Y> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_Y> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_Y> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_Y> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_Y> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_Y> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_Y();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_Y> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_Y> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_Y> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_Y> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_Y> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_Y> result)
        {

        }

        #endregion

        #region Filters

        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as ACC_M003_J_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemsListPopup))
                {
                    return ((data.trans_scope != null && data.trans_scope.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())));
                }
                return true;
            }
            return false;
        }

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
            if (_RevenueCollection != null)
            {
                //RevenueCollection.Remove();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_Y;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.coa_key != null && data.coa_key.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.gl_code_d != null && data.gl_code_d.ToString().ToLower().Contains(_filterString.ToLower()) ||
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
