using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M035_VM : WorkspaceViewModel<QMS_M035>
    {
        bool NewRecord = true;
       
        WebServiceRepository<QMS_M035> repository = new WebServiceRepository<QMS_M035>();
        WebServiceRepository<MultipleContext_QMS_M035> repository_MC = new WebServiceRepository<MultipleContext_QMS_M035>();
        WebServiceRepository<MultipleContext_QMS_M035> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M035>();
        WebServiceRepository<MultipleContext_QMS_M035> repository_MCTemp1 = new WebServiceRepository<MultipleContext_QMS_M035>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M035_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASSeverity { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSeverity
        {
            get { return _ASSeverity; }
            set
            {
                if (_ASSeverity != value)
                {
                    _ASSeverity = value; RaisePropertyChanged("ASSeverity");
                }
            }
        }
        #endregion

        #region Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private QMS_M035 _MasterEntity;
        public QMS_M035 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private ObservableCollection<QMS_M035_A> _ItemsEntity;
        public ObservableCollection<QMS_M035_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set { _ItemsEntity = value;
                ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemEntity);
                RaisePropertyChanged("ItemsEntity"); }
        }

        private ObservableCollection<QMS_M035_A> _ItemsEntity1;
        public ObservableCollection<QMS_M035_A> ItemsEntity1
        {
            get { return _ItemsEntity1; }
            set
            {
                _ItemsEntity1 = value;
                ItemsEntity1.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemEntity);
                RaisePropertyChanged("ItemsEntity1");
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get { return _dgSelectedIndex; }
            set
            {
                _dgSelectedIndex = value;

                RaisePropertyChanged("dgSelectedIndex");
            }
        }

        private List<QMS_M035_Flip> _FlipGridData;
        public List<QMS_M035_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }

        private MultipleContext_QMS_M035 _MC;
        public MultipleContext_QMS_M035 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_M035 _MCTemp;
        public MultipleContext_QMS_M035 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_QMS_M035 _MCTemp1;
        public MultipleContext_QMS_M035 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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

        private string _visible;
        public string visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    RaisePropertyChanged("visible");
                }
            }
        }

        private string _visible1;
        public string visible1
        {
            get { return _visible1; }
            set
            {
                if (_visible1 != value)
                {
                    _visible1 = value;
                    RaisePropertyChanged("visible1");
                }
            }
        }

        private bool _Readonly;
        public bool Readonly
        {
            get { return _Readonly; }
            set
            {
                if (_Readonly != value)
                {
                    _Readonly = value;
                    RaisePropertyChanged("Readonly");
                }
            }
        }
        #endregion

        #region Relay Command Decleration 
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdInspSeverity { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdRadioChanged { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdRadio1Changed { get; private set; }
        #endregion

        #region Constructor
        public QMS_M035_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M035();
            ItemsEntity = new ObservableCollection<QMS_M035_A>();
            MC = new MultipleContext_QMS_M035();
            MCTemp = new MultipleContext_QMS_M035();
            MCTemp1 = new MultipleContext_QMS_M035();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemEntity);
            LoadInitialData();
            DefaultValues();
        }
        public QMS_M035_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M035();
            ItemsEntity = new ObservableCollection<QMS_M035_A>();
            MC = new MultipleContext_QMS_M035();
            MCTemp = new MultipleContext_QMS_M035();
            MCTemp1 = new MultipleContext_QMS_M035();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemEntity);
            LoadInitialData();
            DefaultValues();
        }

        #endregion

        #region User Defined Methods
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
        private void InsertSeverity(Object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M038_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SeverityMaster.Where(x => x.insp_severity.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M038_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.severity = POPUPEntityObject.insp_severity;
                    
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
            //if (MasterEntity.sample_scheme == null || MasterEntity.sample_scheme == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Sample Scheme Code...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.desc == null || MasterEntity.desc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Sample Scheme Name...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.severity == null || MasterEntity.severity == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Inspection Severity...");
                showMessageService.ShowMessage();
                return false;
            }
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.lot_size == p.lot_size && p.active == true)
                        {
                            flag++;
                        }
                    }
                }
                if (o.lot_size != null)
                {
                    if (o.lot_size == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Lot Size for the Lot {0}", o.lot_size);
                        showMessageService.ShowMessage();
                        return false;
                    }     
                }
            }
            return true;
        }
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.t_status = "Draft";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.doc_date = System.DateTime.Now;
            visible = "Visible";
            visible1 = "Collapsed";
            MasterEntity.x1 = true;
            MasterEntity.ind_item_level_para = "Y";
            MasterEntity.ind_aql_val = "N";
            MasterEntity.ind_attr_insp = "N";
            MasterEntity.ind_var_insp = "N";
            MasterEntity.without_val_para = "N";
        }
        private void RadioButtonSelectionChanged()
        {
            if (MasterEntity.ind_item_level_para == "Y")
            {
                visible = "Visible";
                visible1 = "Collapsed";
            }
            else if (MasterEntity.ind_aql_val == "Y")
            {
                visible = "Collapsed";
                visible1 = "Visible";
            }
        }
        private void RadioButtonSelectionChanged1()
        {
            if (MasterEntity.r1 == true)
            {
                MasterEntity.ind_attr_insp = "AI";
                MasterEntity.ind_var_insp = null;
                MasterEntity.without_val_para = null;
            }
            else if (MasterEntity.r2 == true)
            {
                MasterEntity.ind_attr_insp = null;
                MasterEntity.ind_var_insp = "VI";
                MasterEntity.without_val_para = null;
            }
            else if (MasterEntity.r3 == true)
            {
                MasterEntity.ind_attr_insp = null;
                MasterEntity.ind_var_insp = null;
                MasterEntity.without_val_para = "WP";
            }
        }
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdInspSeverity = new RelayCommand<object>(items => { if (items == null) { return; } InsertSeverity(items); });
                CmdRadioChanged = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonSelectionChanged(); });
                CmdRadio1Changed = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonSelectionChanged1(); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M035>(MC, Request, "QMS_M0011_BL", "QMS", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipData;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M038_P)x).insp_severity ?? "");
                TheFilter = (o, prefix) => (((QMS_M038_P)o).insp_severity ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M038_P)o).insp_severity_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSeverity = new AutoSuggestTextViewModel<dynamic>(MC.SeverityMaster, TheFilter, SuggestedValue, "insp_severity", true);
                ASSeverity.AutoSuggestVM.IsEmptyValueAllowed = true;

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

        private void method()
        {
            if (MasterEntity.ind_item_level_para == "Y")
            {
                visible = "Visible";
                visible1 = "Collapsed";
            }
            else if (MasterEntity.ind_aql_val == "Y")
            {
                visible = "Collapsed";
                visible1 = "Visible";
            }

            //if (MasterEntity.ind_attr_insp == "AI")
            //{
            //    MasterEntity.r1 = true;
            //    MasterEntity.r2 = false;
            //    MasterEntity.r3 = false;
            //}
            //else if (MasterEntity.ind_var_insp == "VI")
            //{
            //    MasterEntity.r1 = false;
            //    MasterEntity.r2 = true;
            //    MasterEntity.r3 = false;
            //}
            //else if (MasterEntity.without_val_para == "WP")
            //{
            //    MasterEntity.r1 = false;
            //    MasterEntity.r2 = false;
            //    MasterEntity.r3 = true;
            //}

        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            QMS_M035_Flip ParameterEntityObject = null;

            if (((IEnumerable)ParameterObject).Cast<QMS_M035_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M035_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.sample_scheme;
                NewRecord = false;
                Readonly = true;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_QMS_M035>(MCTemp, Request, "QMS_M0011_BL", "QMS", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                    method();
                }
                ItemsEntity = MCTemp.ItemsEntity;
                foreach (var item in ItemsEntity)
                {
                    MasterEntity.severity = item.insp_severity;
                }
            }
            SelectedTabControlIndex = 0;
            MasterEntity.ts_code = ts_code_vm;
            var msg = new NotificationMessage("QMS_M035_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_QMS_M035_A != null)
            {
                ItemsEntity.Clear();
                ItemsEntity = (ObservableCollection<QMS_M035_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M035_A, MC.ItemsEntity);
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<QMS_M035_A>();
            }

            if (MasterEntity.XmlDataDocument_QMS_M035_Flip != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackFlipData = (List<QMS_M035_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M035_Flip, MC.BackFlipData);
                FlipGridData.Add(MC.BackFlipData[0]);
                DataGridCollection.Refresh();
                DataGridCollection.SortDescriptions.Add(new SortDescription("sample_scheme", ListSortDirection.Descending));
            }
            MasterEntity.ts_code = ts_code_vm;
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M035> result)
        {
            visible = "Collapsed";
            visible1 = "Collapsed";
            MasterEntity = new QMS_M035();
            ItemsEntity = new ObservableCollection<QMS_M035_A>();
            NewRecord = true;
            Readonly = false;
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M035> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_M035> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M035> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M035> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M035> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M035> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M035> result)
        {
            try
            {
                ObjectSerializationService obj = new ObjectSerializationService();

                this.MasterEntity.EndEdit();
                MasterEntity.editby = AppSessionState.UserID;
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_QMS_M035_A = obj.ObjectToXML(ItemsEntity);
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M035>(MasterEntity, "QMS_M0011_BL", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M035>(MasterEntity, "QMS_M0011_BL", "QMS");
                    }
                    method();
                    foreach (var item in ItemsEntity)
                    {
                        MasterEntity.severity = item.insp_severity;
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    var msg = new NotificationMessage("QMS_M035_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);

                    if (MasterEntity.sample_scheme != null && MasterEntity.sample_scheme != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();

                        NewRecord = false;
                        Readonly = true;
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M035> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M035> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M035> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M035> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M035> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters
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
            var data = obj as QMS_M035_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.sample_scheme != null && data.sample_scheme.ToLower().Contains(_filterString.ToLower()) ||
                            data.desc != null && data.desc.ToLower().Contains(_filterString.ToLower()) ||
                            data.doc_date != null && data.doc_date.ToString().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ItemsEntity.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
            else if (ItemsEntity.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false; /* ParameterValueEntity[dgSelectedIndexParaValue].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }

        private void CollectionChangedNotifyForItemEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M035_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M035_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M035_A item in e.NewItems)
                    {
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.active = true;
                        item.add_date = System.DateTime.Now;
                        item.edit_date = System.DateTime.Now;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.t_status = "Draft";
                        item.insp_severity = MasterEntity.severity;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    QMS_M035_A temp = (QMS_M035_A)e.OldItems[0];
                    var itemToRemove1 = ItemsEntity.Where(x => (x.sample_scheme == temp.sample_scheme && x.sample_scheme == "")).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.sample_scheme == "")
                        {
                            ItemsEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        
        #endregion
    }
}
