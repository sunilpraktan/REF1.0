using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Services.Convertors;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.SCM;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.SCM.ViewModels
{
    class GEN_T009_VM : WorkspaceViewModel<GEN_T009>
    {
        bool isNewRecord = true;
        WebServiceRepository<GEN_T009> repository = new WebServiceRepository<GEN_T009>();
        WebServiceRepository<MultipleContext_GEN_T009> repository_MC = new WebServiceRepository<MultipleContext_GEN_T009>();
        WebServiceRepository<MultipleContext_GEN_T009> repository_MCTemp = new WebServiceRepository<MultipleContext_GEN_T009>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ref_doc_cat { get; set; }
       
        

        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(GEN_T009_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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
                }
            }
        }


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

        private AutoSuggestTextViewModel<dynamic> _ASStatus { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStatus
        {
            get { return _ASStatus; }
            set
            {
                if (_ASStatus != value)
                {
                    _ASStatus = value; RaisePropertyChanged("ASStatus");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWay { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWay
        {
            get { return _ASWay; }
            set
            {
                if (_ASWay != value)
                {
                    _ASWay = value; RaisePropertyChanged("ASWay");
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
        private ICollectionView _SalesdataCollection;
        public ICollectionView SalesdataCollection
        {
            get { return _SalesdataCollection; }
            set { _SalesdataCollection = value; RaisePropertyChanged("SalesdataCollection"); }
        }

        private ICollectionView _ItemdetailsCollection;
        public ICollectionView ItemdetailsCollection
        {
            get { return _ItemdetailsCollection; }
            set { _ItemdetailsCollection = value; RaisePropertyChanged("ItemdetailsCollection"); }
        }


        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }
        #endregion

        #region . StringList Variables .
        private List<string> _strListReferanceDocNo;
        public List<string> StringListReferanceDocNo
        {
            get { return _strListReferanceDocNo; }
            set
            {
                if (_strListReferanceDocNo != value)
                {
                    _strListReferanceDocNo = value;
                }
            }
        }
        #endregion

        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private GEN_T009 _MasterEntity;
        public GEN_T009 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }
        private List<SEL_T003_A> _ItemsEntity;
        public List<SEL_T003_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                }
            }

        }
        private List<SEL_T003> _SalesData;
        public List<SEL_T003> SalesData
        {
            get { return _SalesData; }
            set
            {
                if (_SalesData != value)
                {
                    _SalesData = value; RaisePropertyChanged("SalesData");
                    //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                }
            }

        }
        

        //private ObservableCollection<HRM_M015_A> _DetailEntity;
        //public ObservableCollection<HRM_M015_A> DetailEntity
        //{
        //    get { return _DetailEntity; }
        //    set
        //    {
        //        if (_DetailEntity != value)
        //        {
        //            _DetailEntity = value;
        //            DetailEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForDetails);
        //            RaisePropertyChanged("DetailEntity");
        //        }
        //    }
        //}
        private List<GEN_T009_BackFlip> _FlipGridData;
        public List<GEN_T009_BackFlip> FlipGridData
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
        private int _dgSelectedIndexDetail;
        public int dgSelectedIndexDetail
        {
            get
            { return _dgSelectedIndexDetail; }
            set
            {
                if (_dgSelectedIndexDetail != value)
                {
                    _dgSelectedIndexDetail = value;
                    RaisePropertyChanged("dgSelectedIndexDetail");
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
        private MultipleContext_GEN_T009 _MC;
        public MultipleContext_GEN_T009 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_GEN_T009 _MCTemp;
        public MultipleContext_GEN_T009 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        //private MultipleContext_HRM_M015 _MCTemp1;
        //public MultipleContext_HRM_M015 MCTemp1
        //{
        //    get { return _MCTemp1; }
        //    set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        //}

        private List<GEN_T009> _SelectedList;
        public List<GEN_T009> SelectedList
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

        public RelayCommand<object> CmdStatus { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdWay { get; private set; }
        public RelayCommand<object> cmdRefDoc { get; private set; }
        public RelayCommand<object> cmdInsertReferenceDoc { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public GEN_T009_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new GEN_T009();
            //DetailEntity = new ObservableCollection<HRM_M015_A>();

            MC = new MultipleContext_GEN_T009();
            MCTemp = new MultipleContext_GEN_T009();
            //MCTemp1 = new MultipleContext_HRM_M015();
            

            LoadInitialData();

        }
        public GEN_T009_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new GEN_T009();
            //DetailEntity = new ObservableCollection<HRM_M015_A>();

            MC = new MultipleContext_GEN_T009();
            MCTemp = new MultipleContext_GEN_T009();
            //MCTemp1 = new MultipleContext_HRM_M015();


            LoadInitialData();

        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.way_bill_date= DateTime.Now;
            MasterEntity.validity_from = DateTime.Now;
            MasterEntity.validity_to = DateTime.Now;
            MasterEntity.rec_date = DateTime.Now;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.doc_cat = "WR";
            MasterEntity.doc_type = "WR";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private bool Validation()
        {
            //if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter The Document Number...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_GEN_T009>(MC, Request, "Waybill", "SCM", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
                cmdLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdWay = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefWaybill(items); });
                cmdRefDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDoc(items); });
                cmdInsertReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M0013)o).t_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_name", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((GEN_T009_P)x).doc_no ?? "");
                TheFilter = (o, prefix) => (((GEN_T009_P)o).doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower()) ;
                ASWay = new AutoSuggestTextViewModel<dynamic>(MC.waybill, TheFilter, SuggestedValue, "doc_no", true);
                ASWay.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefaultValues();
                #endregion

                FlipGridData = MC.BackFlipEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.Sales_Invoice_Reference);
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                StringListReferanceDocNo = MC.Sales_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();
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

        private void InsertStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.StatusList.Where(x => x.t_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_name = POPUPEntityObject.t_name;
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

        private void InsertRefWaybill(object InputValue)
        {
            try
            {
                string Request = "";
                GEN_T009_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.waybill.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<GEN_T009_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_no = POPUPEntityObject.doc_no;
                    
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                GEN_T009_BackFlip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        {
                            if (MasterEntity.ref_doc_no == null || MasterEntity.ref_doc_no == "")
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Refernece Selection";
                                showMessageService.Text = String.Format("Please Select Refernece No", this.Title);
                                showMessageService.ShowMessage();
                            }
                            else
                            {

                                if (ref_doc_cat == "DN")
                                {
                                    Request = "LoadDocumentFromDeliveryNumber" + "!@" + MasterEntity.ref_doc_no;
                                }
                                else if (ref_doc_cat == "SI")
                                {
                                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.ref_doc_no;
                                }
                                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_GEN_T009>(MCTemp, Request, "Waybill", "SCM", "", 0, "FlipData");
                                
                                ItemsEntity = MCTemp.ItemsEntity;
                                foreach (var item in ItemsEntity)
                                {
                                    if (item.id != 0)
                                    {
                                        item.id = 0;
                                    }
                                }


                                //if (MCTemp.SalesData.Count > 0)
                                //{
                                //    SalesData = MCTemp.SalesData;
                                //}
                                //SalesData.doc_type = "";
                                //SalesData.doc_desc = "";
                                //ItemsEntity = MCTemp.ItemsEntity;
                                //foreach (var item in ItemsEntity)
                                //{
                                //    if (item.id != 0)
                                //    {
                                //        item.id = 0;
                                //    }
                                //}

                                //TotalDocumentTaxes = MCTemp.TaxEntity;
                                //if (TotalDocumentTaxes.Count() != '0')
                                //{ }
                                //else
                                //{
                                //    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                                //}

                                //MC.ItemListPopup = MCTemp.ItemListPopup;
                                //PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                                //PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                                //StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                                //if (ParametersStringValue == "ReferenceDocument" && ref_doc_cat == "SI")
                                //{
                                //    MasterEntity.ref_doc_no = MasterEntity.bill_doc;
                                //    MasterEntity.bill_doc = "";

                                //    // SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
                                //}
                                //DefaultValues();
                                //int count = ItemsEntity.Count();
                                //TotalDocumentTaxes.Clear();
                                //for (int i = 0; i < count; i++)
                                //{
                                //    Computation(true, i);
                                //}
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<GEN_T009_BackFlip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<GEN_T009_BackFlip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.doc_no + " !@" + "" + "!@" + AppSessionState.comp_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_GEN_T009>(MCTemp, Request, "Waybill", "SCM", "", 0, "FlipData");
                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            MasterEntity = MCTemp.MasterEntity[0];
                            MasterEntity.ts_code = ts_code_vm;
                        }
                        //ItemsEntity = MCTemp.ItemsEntity;
                        
                        //TotalDocumentTaxes = MCTemp.TaxEntity;

                        //if (TotalDocumentTaxes.Count() != '0')
                        //{

                        //    TotalDocumentTaxes = MCTemp.TaxEntity;
                            
                        //}
                        //else
                        //{
                        //    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                        //}
                        //PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        //PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        //StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                        //AttachmentCollection = MC.Attachment;
                        //SelectedTabControlIndex = 0;
                        isNewRecord = false;

                    }
                }
                //Computation(true, dgSelectedIndexItem);
                ////SetPopupSuggestionDataAfterLoad();
                //AssignExchangeRatetoItem();
                var msg = new NotificationMessage("GEN_T009_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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

        private void InsertRefDoc(object InputValue)
        {
            try
            {
                
                if (MasterEntity.ref_doc_type == "Sales Invoice")
                {
                    
                    var refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SI" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Sales_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();
                    

                }
                else if (MasterEntity.ref_doc_type == "Delivery Note")
                {
                    var refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Sales_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();
                    StringListReferanceDocNo = MC.Sales_Invoice_Reference.Select(x => x.Ref_DocType).ToList();

                }
                
            }
            catch (Exception ex) { }


        }

        private void InsertReferenceDoc(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T003_P_RefDoc POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Sales_Invoice_Reference.Where(x => x.Ref_DocNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().ToList()[0];
                        }

                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                    ref_doc_cat = POPUPEntityObject.doc_cat;
                    
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
                //if (MasterEntity.XmlDataDocument_HRM_M015_A != null)
                //{
                //    DetailEntity.Clear();
                //    MC.DetailData = (ObservableCollection<HRM_M015_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_M015_A, MC.DetailData);
                //    DetailEntity = MC.DetailData;
                //}
                //else
                //{
                //    MC.DetailData = new ObservableCollection<HRM_M015_A>();
                //}
                //if (MasterEntity.XmlDataDocument_HRM_M015_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                //{
                //    MC.BackFlipEntity = (List<HRM_M015_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_M015_Flip, MC.BackFlipEntity);
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<GEN_T009> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MasterEntity.editby = AppSessionState.UserID;
                //MasterEntity.XmlDataDocument_HRM_M015_A = obj.ObjectToXML(DetailEntity);
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<GEN_T009>(MasterEntity, "Waybill", "SCM");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<GEN_T009>(MasterEntity, "Waybill", "SCM");
                    }

                    if (MasterEntity.doc_no != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.doc_no != null && isNewRecord == false)
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
        }
        protected override void OnCreateAction(InquiryActionResult<GEN_T009> result)
        {
            isNewRecord = true;
            MasterEntity = new GEN_T009();
            //DetailEntity = new ObservableCollection<HRM_M015_A>();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<GEN_T009> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<GEN_T009> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<GEN_T009> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<GEN_T009> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<GEN_T009> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<GEN_T009> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<GEN_T009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<GEN_T009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<GEN_T009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<GEN_T009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<GEN_T009> result)
        {
            throw new NotImplementedException();
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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as GEN_T009_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString.ToLower()) 
                            //data.ter_desc != null && data.ter_desc.ToString().ToLower().Contains(_filterString.ToLower()
                           
                             );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Referance document .
        private string _FilterString_ReferenceDoc;
        public string FilterString_ReferenceDoc
        {
            get { return _FilterString_ReferenceDoc; }
            set
            {
                _FilterString_ReferenceDoc = value;
                RaisePropertyChanged("FilterString_ReferenceDoc");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceDoc()
        {
            if (_ReferenceDocCollection != null)
            {
                _ReferenceDocCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as SEL_T003_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.Ref_DocNo != null && data.Ref_DocNo.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_date != null && data.Ref_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
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
