using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Production;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using System.Data;

namespace Reflection.Modules.Production.ViewModels
{
    class EPR_T005_AVM : WorkspaceViewModel<EPR_T005_A>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(EPR_T005_A));
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

        private AutoSuggestTextViewModel<dynamic> _ASPara1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPara1
        {
            get { return _ASPara1; }
            set
            {
                if (_ASPara1 != value)
                {
                    _ASPara1 = value; RaisePropertyChanged("ASPara1");
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
                    if (SourceName == "value")
                    {
                        var content = dgCellInfo.Column.GetCellContent(dgCellInfo.Item);
                        EPR_T005_B para_code_value = (EPR_T005_B)content.DataContext;

                        //List<ADM_M030_P> ParaValues = (from o in MC.ParameterValues where o.para_code == para_code_value.para_code select o).ToList();
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                        //TheFilter = (o, prefix) => (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M030_P)o).para_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                        //ASDefault = new AutoSuggestTextViewModel<dynamic>((from o in MC.ParameterValues where o.para_code == para_code_value.para_code select o).ToList(), TheFilter, SuggestedValue, "value", "parametervalue", true);
                        //ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                        List<ADM_M030_P> ParaValues = (from o in MC.ParameterValues where o.para_code == (para_code_value.para_code ?? "") select o).ToList();
                        ParaValueCollection = CollectionViewSource.GetDefaultView(ParaValues);
                        ParaValueCollection.Filter = new Predicate<object>(Filter_ParaValue);
                        StringListParaValue = ParaValues.Select(x => x.parametervalue).ToList();
                    }
                }
            }
        }
        #endregion
        void ModelEntityUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
        }
        #region Declaration
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public static int i = 0;
        WebServiceRepository<EPR_T005_A> repository = new WebServiceRepository<EPR_T005_A>();
        WebServiceRepository<MultipleContext_EPR_T005_A> repository_MC = new WebServiceRepository<MultipleContext_EPR_T005_A>();
        WebServiceRepository<MultipleContext_EPR_T005_A> repository_MCTemp = new WebServiceRepository<MultipleContext_EPR_T005_A>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_EPR_T005_A _MC = new MultipleContext_EPR_T005_A();
        public MultipleContext_EPR_T005_A MC
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

        private MultipleContext_EPR_T005_A _MCTemp = new MultipleContext_EPR_T005_A();
        public MultipleContext_EPR_T005_A MCTemp
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

        private EPR_T005_A _MasterEntity;
        public EPR_T005_A MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }

        private string _rpt_type;
        public string rpt_type
        {
            get { return _rpt_type; }
            set
            {
                if (_rpt_type != value)
                {
                    _rpt_type = value;
                    RaisePropertyChanged("rpt_type");
                }
            }
        }

        private ObservableCollection<EPR_T005_B> _ItemsEntity;
        public ObservableCollection<EPR_T005_B> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private ObservableCollection<RptSampleLabel> _SampleLabel;
        public ObservableCollection<RptSampleLabel> SampleLabel
        {
            get { return _SampleLabel; }
            set
            {
                if (_SampleLabel != value)
                {
                    _SampleLabel = value; RaisePropertyChanged("SampleLabel");
                }
            }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        private ICollectionView _ParaValueCollection;
        public ICollectionView ParaValueCollection
        {
            get { return _ParaValueCollection; }
            set { _ParaValueCollection = value; RaisePropertyChanged("ParaValueCollection"); }
        }
        private List<string> _stringListParaValue;
        public List<string> StringListParaValue
        {
            get { return _stringListParaValue; }
            set
            {
                if (_stringListParaValue != value)
                {
                    _stringListParaValue = value;
                }
            }
        }
        #endregion

        #region List
        private List<EPR_T005_A_Flip> _FlipGridData;
        public List<EPR_T005_A_Flip> FlipGridData
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                _AttachmentCollection = value;
                RaisePropertyChanged("AttachmentCollection");
            }
        }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");

                }
            }
        }
        #endregion

        #region Collection

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _ParameterCollection;
        private ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }

        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdTypeChange { get; private set; }
        public RelayCommand<object> cmdParameterValue { get; private set; }
        public RelayCommand<object> CmdFontChange { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public EPR_T005_AVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T005_A();
            FlipGridData = new List<EPR_T005_A_Flip>();
            ItemsEntity = new ObservableCollection<EPR_T005_B>();
            SampleLabel = new ObservableCollection<RptSampleLabel>();
            EPR_T005_B.ModelEntityUpdated += new EventHandler(ModelEntityUpdated);
            MasterEntity.ValidateAsync().Wait();


            LoadInitialData();
            DefaultValues();
        }
        public EPR_T005_AVM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new EPR_T005_A();
            FlipGridData = new List<EPR_T005_A_Flip>();
            ItemsEntity = new ObservableCollection<EPR_T005_B>();
            SampleLabel = new ObservableCollection<RptSampleLabel>();
            EPR_T005_B.ModelEntityUpdated += new EventHandler(ModelEntityUpdated);
            MasterEntity.ValidateAsync().Wait();


            LoadInitialData();
            DefaultValues();
        }
        private void LoadInitialData()
        {
            DefaultValues();
            string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
            MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T005_A>(MC, Request, "SampleLabel", "Production", "LoadInitialData", 0, "");

            #region Command Initialisation
            cmdParameterValue = new RelayCommand<object>(items => { if (items == null) { return; } InsertParameterValue(items); });
            CmdTypeChange = new RelayCommand<object>(items => { if (items == null) { return; } ReportTypeChanged(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

            #endregion
            FlipGridData = MC.DocumentDataFlipGrid.ToList();
            FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
            FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);
            DefaultValues();
        }
        #endregion

        #region User Define Functions
        private void DefaultValues()
        {
            MasterEntity.doc_type = "SL";
            MasterEntity.doc_cat = "SL";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.t_status = "001";
            MasterEntity.label_used_flag = false;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.prod_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.fin_year = "16-17";
            MasterEntity.posting_period = "1";
            MasterEntity.ts_code = ts_code_vm;
        }
        private void ReportTypeChanged(object InputValue)
        {
            try
            {
                char[] delimiters = new char[] { ',', '/' };
                if (InputValue != null)
                {
                    string rpt_type = InputValue.ToString();

                    var abc = from data in MC.ParameterDetails
                              where data.report_type == rpt_type
                              select data;

                    if (abc != null && abc.ToList().Count > 0 && ItemsEntity != null)
                    {
                        foreach (var o in abc.ToList())
                        {
                            ItemsEntity.Clear();

                            if (o.para1 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para1,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 0) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(0) : ""
                                });
                            }

                            if (o.para2 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para2,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 1) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(1) : ""
                                });
                            }

                            if (o.para3 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para3,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 2) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(2) : ""
                                });
                            }

                            if (o.para4 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para4,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 3) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(3) : ""
                                });
                            }

                            if (o.para5 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para5,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 4) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(4) : ""
                                });
                            }

                            if (o.para6 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para6,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 5) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(5) : ""
                                });
                            }

                            if (o.para7 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para7,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 6) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(6) : ""
                                });
                            }

                            if (o.para8 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para8,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 7) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(7) : ""
                                });
                            }

                            if (o.para9 != null)
                            {
                                ItemsEntity.Add(new EPR_T005_B()
                                {
                                    para = o.para9,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id,
                                    add_by = AppSessionState.UserID,
                                    active = true,
                                    report_type = MasterEntity.report_type,
                                    para_code = (abc.ToList()[0].para_code.Split(delimiters).Count() > 8) ? abc.ToList()[0].para_code.Split(delimiters).ElementAt(8) : ""
                                });
                            }
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
        private void DeleteDataGridRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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
            string Request = "";
            string ParametersStringValue = "";
            EPR_T005_A_Flip ParameterEntityObject = null;
            MasterEntity = new EPR_T005_A();
            ItemsEntity = new ObservableCollection<EPR_T005_B>();
            if (((IEnumerable)ParameterObject).Cast<EPR_T005_A_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<EPR_T005_A_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T005_A>(MCTemp, Request, "SampleLabel", "Production", "LoadDocumentByDocumentNumber", 0, "");
                MasterEntity = MCTemp.MasterEntity[0];
                ItemsEntity = MCTemp.ItemsEntity;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");
                AttachmentCollection = MCTemp.AttachmentData;
                if (MCTemp.AttachmentData != null)
                {
                    AttachmentCollection = MCTemp.AttachmentData;
                }
                else
                {
                    MCTemp.AttachmentData = new List<COM_T003>();
                }
                SelectedTabControlIndex = 0;
                MasterEntity.ts_code = ts_code_vm;
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_EPR_T005_B != null)
            {
                MC.ItemsEntity = (ObservableCollection<EPR_T005_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T005_B, MC.ItemsEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemsEntity;
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<EPR_T005_B>();
            }

            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<EPR_T005_A_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
            }
        }
        private bool Validation()
        {
            foreach (var o in ItemsEntity)
            {
                //if (o.value == null || o.value == "")
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Enter Value for {0}", o.para);
                //    showMessageService.ShowMessage();
                //    return false;
                //}
            }

            return true;
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

        private void InsertParameterValue(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ParameterValues.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].value = POPUPEntityObject.parametervalue;
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

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<EPR_T005_A> result)
        {
            NewRecord = true;
            MasterEntity = new EPR_T005_A();
            MC.ItemsEntity = new ObservableCollection<EPR_T005_B>();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            FlipDataGridCollection.Refresh();
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T005_A> result)
        {
            MasterEntity.CancelEdit();
            MasterEntity = new EPR_T005_A();
            ItemsEntity = new ObservableCollection<EPR_T005_B>();
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T005_A> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<EPR_T005_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T005_A> result)
        {

        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("FontSize", MasterEntity.font.ToString());
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T005_A> result)
        {
            string ReportName = "";
            object[] objDataSource = new object[2];
            string[] objDataSourceName = new string[2];
            ReportManager ReportManager = new ReportManager();
            if (MasterEntity.report_type == "SAMPLE")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                objDataSource[0] = ItemsEntity;
                objDataSourceName[0] = "dsSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel2.rdlc", "SampleLabel");
            }
            else if (MasterEntity.report_type == "Ink Details")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                objDataSource[0] = ItemsEntity;
                objDataSourceName[0] = "dsSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel4.rdlc", "SampleLabel");
            }
            else if (MasterEntity.report_type == "Shipping Mark")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                objDataSource[0] = ItemsEntity;
                objDataSourceName[0] = "dsSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel6.rdlc", "SampleLabel");
            }
            else if (MasterEntity.report_type == "As Per Font")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                objDataSource[0] = ItemsEntity;
                objDataSourceName[0] = "dsSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel3.rdlc", "SampleLabel");
            }
            else if (MasterEntity.report_type == "Local/Export Packing" || MasterEntity.report_type == "Shipping Mark")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                List<EPR_T005_B> ItemEntityList = new List<EPR_T005_B>(ItemsEntity);
                SampleLabel.Clear();
                int Total = ItemsEntity.Count;
                int Total1 = Total - 1;
                int Total2 = Convert.ToInt32(ItemsEntity[Total1].value);
                for (int i = 1; i <= Total2; i++)
                {
                    RptSampleLabel SL1 = new RptSampleLabel();
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[0].value))
                    {
                        SL1.para = ItemEntityList[0].para.ToString();
                        SL1.value = ItemEntityList[0].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[1].value))
                    {
                        SL1.para1 = ItemEntityList[1].para.ToString();
                        SL1.value1 = ItemEntityList[1].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[2].value))
                    {
                        SL1.para2 = ItemEntityList[2].para.ToString();
                        SL1.value2 = i.ToString();
                    }
                    SL1.font = ItemEntityList[0].font.ToString();
                    SampleLabel.Add(SL1);
                }
                objDataSource[0] = SampleLabel;
                objDataSourceName[0] = "dsRptSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel.rdlc", "SampleLabel");
            }

            else if (MasterEntity.report_type == "Export Dispatch 2")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                List<EPR_T005_B> ItemEntityList = new List<EPR_T005_B>(ItemsEntity);
                SampleLabel.Clear();
                int Total = ItemsEntity.Count;
                int Total1 = Total - 3;
                int Total2 = Convert.ToInt32(ItemsEntity[Total1].value);
                ItemsEntity[0].id = Convert.ToInt32(MasterEntity.font);
                for (int i = 1; i <= Total2; i++)
                {
                    RptSampleLabel SL1 = new RptSampleLabel();

                    if (!string.IsNullOrWhiteSpace(ItemEntityList[0].value))
                    {
                        SL1.para = ItemEntityList[0].para.ToString();
                        SL1.value = ItemEntityList[0].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[1].value))
                    {
                        SL1.para1 = ItemEntityList[1].para.ToString();
                        SL1.value1 = ItemEntityList[1].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[2].value))
                    {
                        SL1.para2 = ItemEntityList[2].para.ToString();
                        SL1.value2 = i.ToString() + "/" + Total2.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[3].value))
                    {
                        SL1.para3 = ItemEntityList[3].para.ToString();
                        SL1.value3 = ItemEntityList[3].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[4].value))
                    {
                        SL1.para4 = ItemEntityList[4].para.ToString();
                        SL1.value4 = ItemEntityList[4].value.ToString();
                    }

                    SL1.font = ItemEntityList[0].font.ToString();
                    SampleLabel.Add(SL1);
                }
                objDataSource[0] = SampleLabel;
                objDataSourceName[0] = "dsRptSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel1.rdlc", "");
            }
            else if (MasterEntity.report_type == "Export Dispatch")
            {
                ItemsEntity[0].font = MasterEntity.font + "pt";
                List<EPR_T005_B> ItemEntityList = new List<EPR_T005_B>(ItemsEntity);
                SampleLabel.Clear();
                int Total = ItemsEntity.Count;
                int Total1 = Total - 3;
                int Total2 = Convert.ToInt32(ItemsEntity[Total1].value);
                for (int i = 1; i <= Total2; i++)
                {
                    RptSampleLabel SL1 = new RptSampleLabel();
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[0].value))
                    {
                        SL1.para = ItemEntityList[0].para.ToString();
                        SL1.value = ItemEntityList[0].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[1].value))
                    {
                        SL1.para1 = ItemEntityList[1].para.ToString();
                        SL1.value1 = i.ToString() + "/" + Total2.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[2].value))
                    {
                        SL1.para2 = ItemEntityList[2].para.ToString();
                        SL1.value2 = ItemEntityList[2].value.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(ItemEntityList[3].value))
                    {
                        SL1.para3 = ItemEntityList[3].para.ToString();
                        SL1.value3 = ItemEntityList[3].value.ToString();
                    }
                    SL1.font = ItemEntityList[0].font.ToString();
                    SampleLabel.Add(SL1);
                }
                objDataSource[0] = SampleLabel;
                objDataSourceName[0] = "dsRptSampleLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\SampleLabel5.rdlc", "");
            }

        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T005_A> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever '{0}'", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.EndEdit();
                string response = repository.Delete(MasterEntity.doc_no, "SampleLabel", "Production");
                MasterEntity = new EPR_T005_A();
                ItemsEntity = new ObservableCollection<EPR_T005_B>();
                NewRecord = true;
                FlipDataGridCollection.Refresh();
                DefaultValues();
            }
        }
        protected override void OnSaveAction(InquiryActionResult<EPR_T005_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    ObjectSerializationService obj = new ObjectSerializationService();
                    this.MasterEntity.EndEdit();
                    //DefaultValues();
                    MasterEntity.XmlDataDocument_EPR_T005_B = obj.ObjectToXML(ItemsEntity);
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<EPR_T005_A>(MasterEntity, "SampleLabel", "Production");
                    }

                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<EPR_T005_A>(MasterEntity, "SampleLabel", "Production");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.doc_no != null && MasterEntity.doc_no != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                        NewRecord = false;
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
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T005_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filter
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as EPR_T005_A_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.report_type != null && data.report_type.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.prod_date != null && data.prod_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.value != null && data.value.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ParaValue;
        public string FilterString_ParaValue
        {
            get { return _filterString_ParaValue; }
            set
            {
                _filterString_ParaValue = value;
                RaisePropertyChanged("FilterString_ParaValue");
                FilterCollection_ParaValue();
            }
        }
        private void FilterCollection_ParaValue()
        {
            if (_ParaValueCollection != null)
            {
                _ParaValueCollection.Refresh();
            }
        }
        public bool Filter_ParaValue(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ParaValue))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterString_ParaValue.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
    }
}
