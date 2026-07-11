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
    class QMS_M009_G_VM : WorkspaceViewModel<QMS_M009_G>
    {
        #region Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool NewRecord = true;
        WebServiceRepository<List<QMS_M009_G>> repository = new WebServiceRepository<List<QMS_M009_G>>();
        //WebServiceRepository<QMS_M009_G> repository = new WebServiceRepository<QMS_M009_G>();
        WebServiceRepository<MultipleContext_QMS_M009_G> repository_MC = new WebServiceRepository<MultipleContext_QMS_M009_G>();
        WebServiceRepository<MultipleContext_QMS_M009_G> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M009_G>();
        WebServiceRepository<MultipleContext_QMS_M009_G> repository_MCTemp1 = new WebServiceRepository<MultipleContext_QMS_M009_G>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_QMS_M009_G _MC = new MultipleContext_QMS_M009_G();
        public MultipleContext_QMS_M009_G MC
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

        private MultipleContext_QMS_M009_G _MCTemp = new MultipleContext_QMS_M009_G();
        public MultipleContext_QMS_M009_G MCTemp
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

        private MultipleContext_QMS_M009_G _MCTemp1 = new MultipleContext_QMS_M009_G();
        public MultipleContext_QMS_M009_G MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value; RaisePropertyChanged("MCTemp1");
                }
            }
        }

        private ObservableCollection<QMS_M009_G> _MasterEntity;
        public ObservableCollection<QMS_M009_G> MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    MasterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterEntity);
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value; RaisePropertyChanged("group_code");
                }
            }
        }

        private string _catlog;
        public string catlog
        {
            get { return _catlog; }
            set
            {
                if (_catlog != value)
                {
                    _catlog = value; RaisePropertyChanged("catlog");
                }
            }
        }

        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set
            {
                if (_group_name != value)
                {
                    _group_name = value; RaisePropertyChanged("group_name");
                }
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

        List<QMS_M009_G> SelectedList = new List<QMS_M009_G>();
        #endregion

        #region AutoSuggest TextBox Decleration
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M009_G_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASGroupCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGroupCode
        {
            get { return _ASGroupCode; }
            set
            {
                if (_ASGroupCode != value)
                {
                    _ASGroupCode = value; RaisePropertyChanged("ASGroupCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefect { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefect
        {
            get { return _ASDefect; }
            set
            {
                if (_ASDefect != value)
                {
                    _ASDefect = value; RaisePropertyChanged("ASDefect");
                }
            }
        }

        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> commandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdGroupCode { get; set; }
        public RelayCommand<object> CmdDefect { get; set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoad { get; private set; }
        #endregion

        #region List
        private List<QMS_M009_GFlip> _FlipGridData;
        public List<QMS_M009_GFlip> FlipGridData
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
        #endregion

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        #endregion

        #region Constructor
        public QMS_M009_G_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ObservableCollection<QMS_M009_G>();
            FlipGridData = new List<QMS_M009_GFlip>();
            MCTemp = new MultipleContext_QMS_M009_G();
            MCTemp1 = new MultipleContext_QMS_M009_G();
            LoadInitialData();
            MasterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterEntity);
        }
        public QMS_M009_G_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ObservableCollection<QMS_M009_G>();
            FlipGridData = new List<QMS_M009_GFlip>();
            MCTemp = new MultipleContext_QMS_M009_G();
            MCTemp1 = new MultipleContext_QMS_M009_G();
            LoadInitialData();
            MasterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterEntity);
        }
        #endregion

        #region User Defined Methods
        private void LoadRecords()
        {
            string RequestParameter = "LoadFromGroupAndCatlog" + "!@" + catlog + "!@" + group_code;
            MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_QMS_M009_G>(MCTemp1, RequestParameter, "ParameterCodeMaster", "QMS", "LoadInitialData", 0, "");

            MasterEntity = MCTemp1.MasterEntity;
        }
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                commandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdGroupCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertGroupCode(items); });
                CmdDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefectClass(cmdPara, false, false, true); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdLoad = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadRecords(); });
                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M009_G>(MC, Request, "ParameterCodeMaster", "QMS", "LoadInitialData", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F_P)x).para_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M009_F_P)o).para_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009_F_P)o).para_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGroupCode = new AutoSuggestTextViewModel<dynamic>(MC.GroupCodeMaster, TheFilter, SuggestedValue, "para_code", true);
                ASGroupCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M031_P)x).defect_class ?? "");
                TheFilter = (o, prefix) => (((QMS_M031_P)o).defect_class ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M031_P)o).defect_class_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefect = new AutoSuggestTextViewModel<dynamic>(MC.DefectClass, TheFilter, SuggestedValue, "defect_class", "defect_class", true);
                ASDefect.AutoSuggestVM.IsEmptyValueAllowed = true;

                FlipGridData = MC.FlipGridData.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);

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
                    //Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    //objRef.Invoke_Documet(Request, Request);
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
        private bool Validation()
        {
            try
            {
                if (catlog == null || catlog == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Enter The Group Code", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (group_code == null || group_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Enter parameter Type", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (SelectedList != null)
                {
                    foreach (var o in SelectedList)
                    {
                        if (o.value_code == null || o.value_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please Enter The Value of Code", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para_value == null || o.para_value == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please Enter Code Name", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                    return true;
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
            return true;
        }
        private void InsertGroupCode(object InputValue)
        {
            string Request = "";
            QMS_M009_F_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GroupCodeMaster.Where(x => x.para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_F_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_F_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    group_code = POPUPEntityObject.para_code;
                    group_name = POPUPEntityObject.para_name;
                    catlog = POPUPEntityObject.para_type;
                }
                string RequestParameter = "LoadFromGroupAndCatlog" + "!@" + catlog + "!@" + group_code;
                MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_QMS_M009_G>(MCTemp1, RequestParameter, "ParameterCodeMaster", "QMS", "LoadInitialData", 0, "");

                if(MCTemp1.MasterEntity.Count > 0 )
                {
                    MasterEntity = MCTemp1.MasterEntity;
                }
                else
                {
                    MasterEntity = new ObservableCollection<QMS_M009_G>();
                }
            }
            catch (Exception ex) { }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {

        }
        private void InsertDefectClass(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M031_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.DefectClass.Where(x => x.defect_class.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M031_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M031_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = MasterEntity.Where(x => x.defect_class == POPUPEntityObject.defect_class.ToString()).FirstOrDefault();
                    var IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.defect_class == POPUPEntityObject.defect_class.ToString()).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex)
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].defect_class = POPUPEntityObject.defect_class;
                            MasterEntity[dgSelectedIndex].defect_desc = POPUPEntityObject.defect_class_name;
                        }
                        else if (MasterEntity[dgSelectedIndex].defect_class != POPUPEntityObject.defect_class.ToString())
                        {
                            MasterEntity[dgSelectedIndex].defect_class = POPUPEntityObject.defect_class;
                            MasterEntity[dgSelectedIndex].defect_desc = POPUPEntityObject.defect_class_name;
                        }
                    }
                }
                #region Clear Empty Row
                QMS_M009_G newObj = new QMS_M009_G();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            QMS_M009_GFlip ParameterEntityObject = null;
            MasterEntity = new ObservableCollection<QMS_M009_G>();


            if (((IEnumerable)ParameterObject).Cast<QMS_M009_GFlip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M009_GFlip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.para_code + "!@" + ParameterEntityObject.para_type;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_QMS_M009_G>(MCTemp, Request, "ParameterCodeMaster", "QMS", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity;
                    //catlog = MasterEntity[dgSelectedIndex].para_type;
                    //group_code = MasterEntity[dgSelectedIndex].para_code;
                    foreach (var item in MasterEntity)
                    {
                        catlog = item.para_type;
                        group_code = item.para_code;
                    }
                }

            }
            SelectedTabControlIndex = 0;
            var msg = new NotificationMessage("QMS_M009_G_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (MasterEntity.Count > i && MasterEntity[dgSelectedIndex].id == 0)
                {
                    MasterEntity.RemoveAt(i);
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
        protected override void OnCreateAction(InquiryActionResult<QMS_M009_G> result)
        {
            NewRecord = true;
            FlipDataGridCollection.Refresh();
            MasterEntity = new ObservableCollection<QMS_M009_G>();
            catlog = "";
            group_code = "";
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M009_G> result)
        { }
        protected override void OnDocumentAction()
        { }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M009_G> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<QMS_M009_G> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<QMS_M009_G> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<QMS_M009_G> result)
        { }
        protected override void OnRemoveAction(InquiryActionResult<QMS_M009_G> result)
        { }
        protected override void OnSaveAction(InquiryActionResult<QMS_M009_G> result)
        {
            try
            {
                SelectedList.Clear();
                foreach (QMS_M009_G item in MasterEntity)
                {
                    if (item.Click == true)
                    {
                        SelectedList.Add(item);
                    }
                }

                if (Validation() == true && SelectedList != null && SelectedList.Count > 0)
                {
                    string strReturn = repository.Save<List<QMS_M009_G>>(SelectedList, "ParameterCodeMaster", "QMS");
                    if (strReturn != "" && strReturn != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();

                        if (SelectedList != null && SelectedList.Count > 0)
                        {
                            MasterEntity.Clear();
                            catlog = "";
                            group_code = "";
                        }
                    }

                }
                if (SelectedList == null || SelectedList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please select the row to Save or Update Records", this.Title);
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M009_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M009_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M009_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M009_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M009_G> result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (MasterEntity.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
            else if (MasterEntity.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false; /* ParameterValueEntity[dgSelectedIndexParaValue].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (MasterEntity.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }

        private void CollectionChangedNotifyForMasterEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_G item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_G item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_G item in e.NewItems)
                    {
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.active = true;
                        item.add_date = System.DateTime.Now;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.t_status = "Draft";
                        item.valid_from = System.DateTime.Now;
                        item.para_code = group_code;
                        item.para_type = catlog;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    QMS_M009_G temp = (QMS_M009_G)e.OldItems[0];
                    var itemToRemove1 = MasterEntity.Where(x => (x.value_code == temp.value_code && x.value_code == "")).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.value_code == "")
                        {
                            MasterEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region Filter For Flip Grid Data
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
            var data = obj as QMS_M009_GFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.para_code != null && data.para_code.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.value_code != null && data.value_code.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.para_value != null && data.para_value.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                            (data.para_type != null && data.para_type.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
