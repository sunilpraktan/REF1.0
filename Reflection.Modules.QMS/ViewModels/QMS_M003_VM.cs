using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using System.Collections.Specialized;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M003_VM : WorkspaceViewModel<QMS_M003>
    {
        bool isNewRecord = true;
        WebServiceRepository<QMS_M003> repository = new WebServiceRepository<QMS_M003>();
        WebServiceRepository<MultipleContext_QMS_M003> repository_MC = new WebServiceRepository<MultipleContext_QMS_M003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M003_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASDefault1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault1
        {
            get { return _ASDefault1; }
            set
            {
                if (_ASDefault1 != value)
                {
                    _ASDefault1 = value; RaisePropertyChanged("ASDefault1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASValueUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValueUnit
        {
            get { return _ASValueUnit; }
            set
            {
                if (_ASValueUnit != value)
                {
                    _ASValueUnit = value; RaisePropertyChanged("ASValueUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDatagridItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDatagridItem
        {
            get { return _ASDatagridItem; }
            set
            {
                if (_ASDatagridItem != value)
                {
                    _ASDatagridItem = value; RaisePropertyChanged("ASDatagridItem");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASAccScope { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccScope
        {
            get { return _ASAccScope; }
            set
            {
                if (_ASAccScope != value)
                {
                    _ASAccScope = value; RaisePropertyChanged("ASAccScope");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSupplier { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSupplier
        {
            get { return _ASSupplier; }
            set
            {
                if (_ASSupplier != value)
                {
                    _ASSupplier = value; RaisePropertyChanged("ASSupplier");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMasterInst { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMasterInst
        {
            get { return _ASMasterInst; }
            set
            {
                if (_ASMasterInst != value)
                {
                    _ASMasterInst = value; RaisePropertyChanged("ASMasterInst");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPI { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPI
        {
            get { return _ASPI; }
            set
            {
                if (_ASPI != value)
                {
                    _ASPI = value; RaisePropertyChanged("ASPI");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASReqNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReqNo
        {
            get { return _ASReqNo; }
            set
            {
                if (_ASReqNo != value)
                {
                    _ASReqNo = value; RaisePropertyChanged("ASReqNo");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPO { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPO
        {
            get { return _ASPO; }
            set
            {
                if (_ASPO != value)
                {
                    _ASPO = value; RaisePropertyChanged("ASPO");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRig { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRig
        {
            get { return _ASRig; }
            set
            {
                if (_ASRig != value)
                {
                    _ASRig = value; RaisePropertyChanged("ASRig");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCat
        {
            get { return _ASCat; }
            set
            {
                if (_ASCat != value)
                {
                    _ASCat = value; RaisePropertyChanged("ASCat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSubCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSubCat
        {
            get { return _ASSubCat; }
            set
            {
                if (_ASSubCat != value)
                {
                    _ASSubCat = value; RaisePropertyChanged("ASSubCat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLab { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLab
        {
            get { return _ASLab; }
            set
            {
                if (_ASLab != value)
                {
                    _ASLab = value; RaisePropertyChanged("ASLab");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTracibility { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTracibility
        {
            get { return _ASTracibility; }
            set
            {
                if (_ASTracibility != value)
                {
                    _ASTracibility = value; RaisePropertyChanged("ASTracibility");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRangeUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRangeUnit
        {
            get { return _ASRangeUnit; }
            set
            {
                if (_ASRangeUnit != value)
                {
                    _ASRangeUnit = value; RaisePropertyChanged("ASRangeUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUpperUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUpperUnit
        {
            get { return _ASUpperUnit; }
            set
            {
                if (_ASUpperUnit != value)
                {
                    _ASUpperUnit = value; RaisePropertyChanged("ASUpperUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLowerUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLowerUnit
        {
            get { return _ASLowerUnit; }
            set
            {
                if (_ASLowerUnit != value)
                {
                    _ASLowerUnit = value; RaisePropertyChanged("ASLowerUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccUpUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccUpUnit
        {
            get { return _ASAccUpUnit; }
            set
            {
                if (_ASAccUpUnit != value)
                {
                    _ASAccUpUnit = value; RaisePropertyChanged("ASAccUpUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccDownUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccDownUnit
        {
            get { return _ASAccDownUnit; }
            set
            {
                if (_ASAccDownUnit != value)
                {
                    _ASAccDownUnit = value; RaisePropertyChanged("ASAccDownUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASResUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASResUnit
        {
            get { return _ASResUnit; }
            set
            {
                if (_ASResUnit != value)
                {
                    _ASResUnit = value; RaisePropertyChanged("ASResUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLcUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLcUnit
        {
            get { return _ASLcUnit; }
            set
            {
                if (_ASLcUnit != value)
                {
                    _ASLcUnit = value; RaisePropertyChanged("ASLcUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUncertaintyUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUncertaintyUnit
        {
            get { return _ASUncertaintyUnit; }
            set
            {
                if (_ASUncertaintyUnit != value)
                {
                    _ASUncertaintyUnit = value; RaisePropertyChanged("ASUncertaintyUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASParaName { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParaName
        {
            get { return _ASParaName; }
            set
            {
                if (_ASParaName != value)
                {
                    _ASParaName = value; RaisePropertyChanged("ASParaName");
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
                    if (SourceName == "ItemCode")
                    { ASDefault = ASDatagridItem; }
                    else if (SourceName == "para_name")
                    { ASDefault1 = ASParaName; }
                    else if (SourceName == "value_unit")
                    { ASDefault1 = ASValueUnit; }
                    
                }
            }
        }

        #endregion

        #region Declarations
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_QMS_M003 _MC;
        public MultipleContext_QMS_M003 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_M003 _MCTemp;
        public MultipleContext_QMS_M003 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private QMS_M003 _MasterEntity;
        public QMS_M003 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private ObservableCollection<QMS_M003_A> _AccessoryEntity;
        public ObservableCollection<QMS_M003_A> AccessoryEntity
        {
            get { return _AccessoryEntity; }
            set
            {
                if (_AccessoryEntity != value)
                {
                    _AccessoryEntity = value;
                    RaisePropertyChanged("AccessoryEntity");
                }
            }
        }
        private ObservableCollection<QMS_M003_B> _DetailEntity;
        public ObservableCollection<QMS_M003_B> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value;
                    DetailEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForDetails);
                    RaisePropertyChanged("DetailEntity");
                }
            }
        }

        private List<QMS_M003Flip> _FlipGridData;
        public List<QMS_M003Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

        private List<ADM_M019_P> _Sgroup;
        public List<ADM_M019_P> Sgroup
        {
            get { return _Sgroup; }
            set
            {
                if (_Sgroup != value)
                {
                    _Sgroup = value;
                    RaisePropertyChanged("Sgroup");
                }
            }
        }

        private int _dgSelectedIndexAcc;
        public int dgSelectedIndexAcc
        {
            get
            { return _dgSelectedIndexAcc; }
            set
            {
                if (_dgSelectedIndexAcc != value)
                {
                    _dgSelectedIndexAcc = value;
                    RaisePropertyChanged("dgSelectedIndexAcc");
                }
            }
        }
        private int _dgSelectedIndexDetails;
        public int dgSelectedIndexDetails
        {
            get
            { return _dgSelectedIndexDetails; }
            set
            {
                if (_dgSelectedIndexDetails != value)
                {
                    _dgSelectedIndexDetails = value;
                    RaisePropertyChanged("dgSelectedIndexDetails");
                }
            }
        }
        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddLab { get; private set; }
        public RelayCommand<object> CmdAddCat { get; private set; }
        public RelayCommand<object> CmdAddSubCat { get; private set; }
        public RelayCommand<object> CmdAddRig { get; private set; }
        public RelayCommand<object> CmdAddPO { get; private set; }
        public RelayCommand<object> CmdAddReqNo { get; private set; }
        public RelayCommand<object> CmdAddPI { get; private set; }
        public RelayCommand<object> CmdAddSupplier { get; private set; }
        public RelayCommand<object> CmdAddMasterInst { get; private set; }
        public RelayCommand<object> CmdAddAccessory { get; private set; }
        public RelayCommand<object> CmdAddEmployee { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowAccEntity { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddTracibility { get; private set; }
        public RelayCommand<object> CmdAddrangeUnit { get; private set; }
        public RelayCommand<object> CmdAddupperRangeUnit { get; private set; }
        public RelayCommand<object> CmdAddlowerRangeUnit { get; private set; }
        public RelayCommand<object> CmdAddaccUnit { get; private set; }
        public RelayCommand<object> CmdAddresUnit { get; private set; }
        public RelayCommand<object> CmdAddlcUnit { get; private set; }
        public RelayCommand<object> CmdAddParaName { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowParameter { get; private set; }

        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M003_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M003_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M003_B item in e.NewItems)
                    {
                        item.para_type = "IM";
                        item.inst_code = MasterEntity.inst_code;
                        item.valid_from = MasterEntity.cal_lastdate;
                        item.valid_to = MasterEntity.due_date;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.editby = AppSessionState.UserID;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (sender.ToString() == "cal_lastdate" || sender.ToString() == "calfreq" || sender.ToString() == "calperiod")
            {
                CalDueDate();
            }
        }
        private void CalDueDate()
        {
            if (MasterEntity.cal_lastdate != null)
            {
                MasterEntity.due_date = MasterEntity.cal_lastdate;
                if (MasterEntity.calperiod == "Days")
                {
                    MasterEntity.due_date = Convert.ToDateTime(MasterEntity.cal_lastdate).AddDays(Convert.ToDouble(MasterEntity.calfreq));
                }
                else if (MasterEntity.calperiod == "Months")
                {
                    MasterEntity.due_date = Convert.ToDateTime(MasterEntity.cal_lastdate).AddMonths(Convert.ToInt32(MasterEntity.calfreq));
                }
                else if (MasterEntity.calperiod == "Years")
                {
                    MasterEntity.due_date = Convert.ToDateTime(MasterEntity.cal_lastdate).AddYears(Convert.ToInt32(MasterEntity.calfreq));
                }
                MasterEntity.next_date = MasterEntity.due_date;
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (DetailEntity.Count > dgSelectedIndexDetails && dgSelectedIndexDetails >= 0)
            {
                this.ErrorExist = false;
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (DetailEntity.Count > dgSelectedIndexDetails && dgSelectedIndexDetails >= 0)
            {
                this.ErrorExist = false;
            }
        }

        #endregion

        #region Constructor
        public QMS_M003_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MasterEntity = new QMS_M003();
            AccessoryEntity = new ObservableCollection<QMS_M003_A>();
            DetailEntity = new ObservableCollection<QMS_M003_B>();
            MC = new MultipleContext_QMS_M003();
            MCTemp = new MultipleContext_QMS_M003();
            QMS_M003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            LoadInitialData();
        }
        public QMS_M003_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MasterEntity = new QMS_M003();
            AccessoryEntity = new ObservableCollection<QMS_M003_A>();
            DetailEntity = new ObservableCollection<QMS_M003_B>();
            MC = new MultipleContext_QMS_M003();
            MCTemp = new MultipleContext_QMS_M003();
            QMS_M003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CmdAddLab = new RelayCommand<object>(items => { if (items == null) { return; } InsertLab(items); });
                CmdAddCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertCat(items); });
                CmdAddSubCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCat(items); });
                CmdAddRig = new RelayCommand<object>(items => { if (items == null) { return; } InsertRig(items); });
                CmdAddPO = new RelayCommand<object>(items => { if (items == null) { return; } InsertPO(items); });
                CmdAddReqNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertReqNo(items); });
                CmdAddPI = new RelayCommand<object>(items => { if (items == null) { return; } InsertPI(items); });
                CmdAddSupplier = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplier(items); });
                CmdAddMasterInst = new RelayCommand<object>(items => { if (items == null) { return; } InsertMasterInst(items); });
                CmdAddAccessory = new RelayCommand<object>(items => { if (items == null) { return; } InsertAccessory(items, true, true, true); });
                CmdAddEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CmdDeleteDataGridRowAccEntity = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowAccEntity(items); });
                CmdAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CmdAddTracibility = new RelayCommand<object>(items => { if (items == null) { return; } InsertTracibility(items); });
                CmdAddParaName = new RelayCommand<object>(items => { if (items == null) { return; } InsertParaName(items, true, true, true); });
                CmdDeleteDataGridRowParameter = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowParameter(items); });

                #endregion
                
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M003>(MC, Request, "InstrumentMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initialization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_B_P)x).lab_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_B_P)o).lab_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_B_P)o).lab_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLab = new AutoSuggestTextViewModel<dynamic>(MC.Laboratory, TheFilter, SuggestedValue, "lab_name", true);
                ASLab.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M018_P)x).CatName ?? "");
                TheFilter = (o, prefix) => (((ADM_M018_P)o).CatCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M018_P)o).CatName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCat = new AutoSuggestTextViewModel<dynamic>(MC.Cat, TheFilter, SuggestedValue, "CatName", true);
                ASCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M008_P)x).rig_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M008_P)o).rig_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M008_P)o).rig_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRig = new AutoSuggestTextViewModel<dynamic>(MC.Rig, TheFilter, SuggestedValue, "rig_name", true);
                ASRig.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Inst_Pur_Details_P)x).po_no ?? "");
                TheFilter = (o, prefix) => (((Inst_Pur_Details_P)o).po_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPO = new AutoSuggestTextViewModel<dynamic>(MC.PurOrder, TheFilter, SuggestedValue, "po_no", true);
                ASPO.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Inst_Pur_Details_P)x).req_no ?? "");
                TheFilter = (o, prefix) => (((Inst_Pur_Details_P)o).req_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASReqNo = new AutoSuggestTextViewModel<dynamic>(MC.ReqNo, TheFilter, SuggestedValue, "req_no", true);
                ASReqNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Inst_Pur_Details_P)x).doc_no ?? "");
                TheFilter = (o, prefix) => (((Inst_Pur_Details_P)o).doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPI = new AutoSuggestTextViewModel<dynamic>(MC.PurInvoice, TheFilter, SuggestedValue, "doc_no", true);
                ASPI.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm ?? "");
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSupplier = new AutoSuggestTextViewModel<dynamic>(MC.Supplier, TheFilter, SuggestedValue, "PartyNm", true);
                ASSupplier.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMasterInst = new AutoSuggestTextViewModel<dynamic>(MC.CalInst, TheFilter, SuggestedValue, "inst_name", true);
                ASMasterInst.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.Employees, TheFilter, SuggestedValue, "EmpName", true);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.AccItem, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M009_F)o).para_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009_F)o).para_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.ParameterCode, TheFilter, SuggestedValue, "para_name", "para_name", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASValueUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASValueUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<ADM_M022_P> astitem = (from o in MC.AccItem where o.CatCode == "AST" select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(astitem, TheFilter, SuggestedValue, "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<ADM_M022_P> accitem = (from o in MC.AccItem where o.CatCode == "ACC" select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDatagridItem = new AutoSuggestTextViewModel<dynamic>(accitem, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDatagridItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M004_P)x).ItemScope ?? "");
                TheFilter = (o, prefix) => (((QMS_M004_P)o).ItemScope ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccScope = new AutoSuggestTextViewModel<dynamic>(MC.AccScope, TheFilter, SuggestedValue, "ItemScope", "ItemScope", true);
                ASAccScope.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M010_P)x).tr_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M010_P)o).tr_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M010_P)o).tr_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTracibility = new AutoSuggestTextViewModel<dynamic>(MC.Tracibility, TheFilter, SuggestedValue, "tr_name", true);
                ASTracibility.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRangeUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "range_unit", true);
                ASRangeUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUpperUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "upper_range_unit", true);
                ASUpperUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLowerUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "lower_range_unit", true);
                ASLowerUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccUpUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "accuracy_up_unit", "unit_code", true);
                ASAccUpUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccDownUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "accuracy_down_unit", "unit_code", true);
                ASAccDownUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASResUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "resolution_unit", true);
                ASResUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLcUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "least_count_unit", true);
                ASLcUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUncertaintyUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "uncertainty_unit", true);
                ASUncertaintyUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M009_F)o).para_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009_F)o).para_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParaName = new AutoSuggestTextViewModel<dynamic>(MC.ParameterCode, TheFilter, SuggestedValue, "para_name", "para_name", true);
                ASParaName.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

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
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.cal_lastdate = DateTime.Now;
            MasterEntity.t_status = "Available";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            QMS_M003Flip ParameterEntityObject = new QMS_M003Flip();
            try
            {
                CursorControl.SetBusyState();
                if (((IEnumerable)ParameterObject).Cast<QMS_M003Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M003Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + ParameterEntityObject.inst_code;

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M003>(MCTemp, Request, "InstrumentMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    AccessoryEntity = MCTemp.Accessory;
                    DetailEntity = MCTemp.DetailEntity;
                    SetBusinessEntitiesAfterLoad("Save", "");

                    Sgroup = (from o in MC.SubCat
                              where o.CatCode == MasterEntity.CatCode
                              select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M019_P)x).SubCatName ?? "");
                    TheFilter = (o, prefix) => (((ADM_M019_P)o).SubCatCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M019_P)o).SubCatName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASSubCat = new AutoSuggestTextViewModel<dynamic>(Sgroup, TheFilter, SuggestedValue, "SubCatName", true);
                    ASSubCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                    if (MCTemp.Attachment != null)
                    {
                        AttachmentCollection = MCTemp.Attachment;
                    }
                    else
                    {
                        MCTemp.Attachment = new List<COM_T003>();
                    }

                    SelectedTabControlIndex = 0;
                    isNewRecord = false;
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("QMS_M003_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void InsertLab(object InputValue)
        {
            string Request = "";
            ADM_M003_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Laboratory.Where(x => x.lab_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_B_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.lab_code = POPUPEntityObject.lab_code;
                    MasterEntity.lab_name = POPUPEntityObject.lab_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertCat(object InputValue)
        {
            string Request = "";
            ADM_M018_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Cat.Where(x => x.CatName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M018_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.CatCode = POPUPEntityObject.CatCode;
                MasterEntity.CatName = POPUPEntityObject.CatName;

                Sgroup = (from o in MC.SubCat
                          where o.CatCode == MasterEntity.CatCode
                          select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M019_P)x).SubCatName ?? "");
                TheFilter = (o, prefix) => (((ADM_M019_P)o).SubCatCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M019_P)o).SubCatName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSubCat = new AutoSuggestTextViewModel<dynamic>(Sgroup, TheFilter, SuggestedValue, "SubCatName", true);
                ASSubCat.AutoSuggestVM.IsEmptyValueAllowed = true;
            }
        }
        private void InsertSubCat(object InputValue)
        {
            string Request = "";
            ADM_M019_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = Sgroup.Where(x => x.SubCatName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M019_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M019_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.SubCatName = POPUPEntityObject.SubCatName;
                MasterEntity.SubCatCode = POPUPEntityObject.SubCatCode;
            }
        }
        private void InsertRig(object InputValue)
        {
            string Request = "";
            QMS_M008_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Rig.Where(x => x.rig_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M008_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M008_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.rig_code = POPUPEntityObject.rig_code;
                MasterEntity.rig_name = POPUPEntityObject.rig_name;
            }
        }
        private void InsertPO(object InputValue)
        {
            string Request = "";
            Inst_Pur_Details_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PurOrder.Where(x => x.po_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<Inst_Pur_Details_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Inst_Pur_Details_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.po_no = POPUPEntityObject.po_no;
                    MasterEntity.po_date = POPUPEntityObject.po_date;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertReqNo(object InputValue)
        {
            string Request = "";
            Inst_Pur_Details_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ReqNo.Where(x => x.req_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<Inst_Pur_Details_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Inst_Pur_Details_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.req_no = POPUPEntityObject.req_no;
                    MasterEntity.date_start = POPUPEntityObject.date_start;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertPI(object InputValue)
        {
            string Request = "";
            Inst_Pur_Details_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PurInvoice.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<Inst_Pur_Details_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Inst_Pur_Details_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.inv_no = POPUPEntityObject.doc_no;
                    MasterEntity.inv_date = POPUPEntityObject.doc_date;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertSupplier(object InputValue)
        {
            string Request = "";
            ADM_M028_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Supplier.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertMasterInst(object InputValue)
        {
            string Request = "";
            QMS_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CalInst.Where(x => x.inst_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cal_inst = POPUPEntityObject.inst_code;
                    MasterEntity.cal_inst_name = POPUPEntityObject.inst_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertAccessory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccItem.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexAcc >= 0 && AccessoryEntity.Count > dgSelectedIndexAcc)
                    {
                        if (AccessoryEntity[dgSelectedIndexAcc].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            AccessoryEntity[dgSelectedIndexAcc].ItemCode = POPUPEntityObject.ItemCode;
                            AccessoryEntity[dgSelectedIndexAcc].ItemName = POPUPEntityObject.ItemName;
                            AccessoryEntity[dgSelectedIndexAcc].location_Id = AppSessionState.location_Id;
                            AccessoryEntity[dgSelectedIndexAcc].comp_code = AppSessionState.comp_code;
                            AccessoryEntity[dgSelectedIndexAcc].add_by = AppSessionState.UserID;
                            AccessoryEntity[dgSelectedIndexAcc].editby = AppSessionState.UserID;
                            AccessoryEntity[dgSelectedIndexAcc].active = true;
                            AccessoryEntity[dgSelectedIndexAcc].user_source1 = AppSessionState.UserSource1;
                            AccessoryEntity[dgSelectedIndexAcc].user_source2 = AppSessionState.UserSource2;
                        }
                        else if (AccessoryEntity[dgSelectedIndexAcc].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            AccessoryEntity[dgSelectedIndexAcc].ItemCode = POPUPEntityObject.ItemCode;
                            AccessoryEntity[dgSelectedIndexAcc].ItemName = POPUPEntityObject.ItemName;
                            AccessoryEntity[dgSelectedIndexAcc].location_Id = AppSessionState.location_Id;
                            AccessoryEntity[dgSelectedIndexAcc].comp_code = AppSessionState.comp_code;
                            AccessoryEntity[dgSelectedIndexAcc].add_by = AppSessionState.UserID;
                            AccessoryEntity[dgSelectedIndexAcc].editby = AppSessionState.UserID;
                            AccessoryEntity[dgSelectedIndexAcc].user_source1 = AppSessionState.UserSource1;
                            AccessoryEntity[dgSelectedIndexAcc].user_source2 = AppSessionState.UserSource2;
                            AccessoryEntity[dgSelectedIndexAcc].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertEmployee(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }
        private void DeleteDataGridRowAccEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (AccessoryEntity.Count > i && AccessoryEntity[dgSelectedIndexAcc].id == 0)
                {
                    AccessoryEntity.RemoveAt(i);
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
        private void InsertItem(object InputValue)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccItem.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.inst_code = POPUPEntityObject.ItemCode;
                    MasterEntity.inst_name = POPUPEntityObject.ItemName;
                    MasterEntity.CatCode = POPUPEntityObject.CatCode;
                    MasterEntity.SubCatCode = POPUPEntityObject.SubCatCode;
                    MasterEntity.CatName = POPUPEntityObject.CatName;
                    MasterEntity.SubCatName = POPUPEntityObject.SubCatName;
                }
                var msg = new NotificationMessage("QMS_M003_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void InsertTracibility(object InputValue)
        {
            string Request = "";
            QMS_M010_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Tracibility.Where(x => x.tr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M010_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M010_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.tr_code = POPUPEntityObject.tr_code;
                    MasterEntity.tr_name = POPUPEntityObject.tr_name;
                }
            }
            catch (Exception ex) { }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_QMS_M003_A != null)
                {
                    AccessoryEntity.Clear();
                    MC.Accessory = (ObservableCollection<QMS_M003_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M003_A, MC.Accessory);
                    AccessoryEntity = MC.Accessory;
                }
                else
                {
                    MC.Accessory = new ObservableCollection<QMS_M003_A>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M003_B != null)
                {
                    DetailEntity.Clear();
                    MC.DetailEntity = (ObservableCollection<QMS_M003_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M003_B, MC.DetailEntity);
                    DetailEntity = MC.DetailEntity;
                }
                else
                {
                    MC.DetailEntity = new ObservableCollection<QMS_M003_B>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M003FLIP != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<QMS_M003Flip>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M003FLIP, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }
                MasterEntity.ts_code = ts_code_vm;
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
            if (MasterEntity.lab_code == null || MasterEntity.lab_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Laboratory...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please select Item...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.inst_name == null || MasterEntity.inst_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Instrument Name...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.CatCode == null || MasterEntity.CatCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Category...");
                showMessageService.ShowMessage();
                return false;
            }
            foreach (var o in AccessoryEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in AccessoryEntity)
                    {
                        if (o.ItemCode == p.ItemCode)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Cannot Save Duplicate Acceessory: {0} ", o.ItemName);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASCat.AutoSuggestVM.Suggestion = MC.Cat.Find(x => x.CatCode == MasterEntity.CatCode);
            ASSubCat.AutoSuggestVM.Suggestion = MC.SubCat.Find(x => x.SubCatCode == MasterEntity.SubCatCode);
            ASLab.AutoSuggestVM.Suggestion = MC.Laboratory.Find(x => x.lab_code == MasterEntity.lab_code);
            ASRig.AutoSuggestVM.Suggestion = MC.Rig.Find(x => x.rig_code == MasterEntity.rig_code);
            ASPO.AutoSuggestVM.Suggestion = MC.PurOrder.Find(x => x.po_no == MasterEntity.po_no);
            ASPI.AutoSuggestVM.Suggestion = MC.PurInvoice.Find(x => x.doc_no == MasterEntity.inv_no);
            ASReqNo.AutoSuggestVM.Suggestion = MC.ReqNo.Find(x => x.req_no == MasterEntity.req_no);
            ASSupplier.AutoSuggestVM.Suggestion = MC.Supplier.Find(x => x.PartyId == MasterEntity.PartyId);
            ASMasterInst.AutoSuggestVM.Suggestion = MC.CalInst.Find(x => x.inst_code == MasterEntity.cal_inst);
            ASEmployee.AutoSuggestVM.Suggestion = MC.Employees.Find(x => x.EmpId == MasterEntity.EmpId);
            ASItem.AutoSuggestVM.Suggestion = MC.AccItem.Find(x => x.ItemCode == MasterEntity.inst_code);
            ASTracibility.AutoSuggestVM.Suggestion = MC.Tracibility.Find(x => x.tr_code == MasterEntity.tr_code);
        }
        private void InsertParaName(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            QMS_M009_F POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ParameterCode.Where(x => x.para_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_F>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_F>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DetailEntity.Where(x => x.para_code == POPUPEntityObject.para_code).FirstOrDefault();
                    var IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.para_code == POPUPEntityObject.para_code).FirstOrDefault());

                    if (dgSelectedIndexDetails >= 0 && DetailEntity.Count > dgSelectedIndexDetails)
                    {
                        if (DetailEntity[dgSelectedIndexDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndexDetails].para_code = POPUPEntityObject.para_code;
                            DetailEntity[dgSelectedIndexDetails].para_name = POPUPEntityObject.para_name;
                        }
                        else
                        {
                            DetailEntity[dgSelectedIndexDetails].para_code = POPUPEntityObject.para_code;
                            DetailEntity[dgSelectedIndexDetails].para_name = POPUPEntityObject.para_name;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void DeleteDataGridRowParameter(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity.Count > i && DetailEntity[dgSelectedIndexDetails].id == 0)
                {
                    DetailEntity.RemoveAt(i);
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
        protected override void OnSaveAction(InquiryActionResult<QMS_M003> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_QMS_M003_A = obj.ObjectToXML(AccessoryEntity);
                MasterEntity.XmlDataDocument_QMS_M003_B = obj.ObjectToXML(DetailEntity);

                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M003>(MasterEntity, "InstrumentMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M003>(MasterEntity, "InstrumentMaster", "Administration");
                    }

                    if (MasterEntity.inst_code != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.inst_code != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
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
            if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M003> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<QMS_M003> result)
        {
            isNewRecord = true;
            MasterEntity = new QMS_M003();
            AccessoryEntity = new ObservableCollection<QMS_M003_A>();
            DetailEntity = new ObservableCollection<QMS_M003_B>();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_M003> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "InstrumentMaster", "Administration");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_M003> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M003> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_M003> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_M003> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_M003> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid
        private string _filterString;
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
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
        public bool Filter(object obj)
        {
            var data = obj as QMS_M003Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.inst_code != null && data.inst_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.inst_name != null && data.inst_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.lab_name != null && data.lab_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString.ToLower())
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
