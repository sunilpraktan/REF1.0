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
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using Reflection.BusinessEntity;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Settings.ViewModels
{
    public class SYS_S0001_VM : WorkspaceViewModel<SYS_AUTH>
    {
        bool blNew = true;
        WebServiceRepository<SYS_AUTH> REPOSITORY = new WebServiceRepository<SYS_AUTH>();
        WebServiceRepository<MC_SYS_BE> REPOSITORY_MC = new WebServiceRepository<MC_SYS_BE>();

        #region AutoSuggest TextBox Region
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        
        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }
       
        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EMPLOYEE
        {
            get { return _AS_EMPLOYEE; }
            set
            {
                if (_AS_EMPLOYEE != value)
                {
                    _AS_EMPLOYEE = value; RaisePropertyChanged("AS_EMPLOYEE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ROLE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ROLE
        {
            get { return _AS_ROLE; }
            set
            {
                if (_AS_ROLE != value)
                {
                    _AS_ROLE = value; RaisePropertyChanged("AS_ROLE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_USER_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_USER_TYPE
        {
            get { return _AS_USER_TYPE; }
            set
            {
                if (_AS_USER_TYPE != value)
                {
                    _AS_USER_TYPE = value; RaisePropertyChanged("AS_USER_TYPE");
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
                    if (SourceName == "role_code")
                    { AS_DEFAULT = AS_ROLE; }
                    else if (SourceName == "user_type")
                    { AS_DEFAULT = AS_USER_TYPE; }
                    //else if (SourceName == "price_qty_uom")
                    //{ AS_DEFAULT = AS_ROLE; }

                }
            }
        }
        #endregion

        private int _dgSelectedIndex;
        string imageName;
        #region Declaration
        IShowMessageViewService sms;
        private bool _EntityChangeEnable;
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                {
                    _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable");
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
        public string ts_code_vm { get; set; }

        #endregion
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
            if(string.IsNullOrWhiteSpace(MasterEntity.title))
            {
                if(MC.PERSONNEL_LIST != null && MasterEntity != null)
                {
                    if (MC.PERSONNEL_LIST.Count > 0 && !string.IsNullOrWhiteSpace(MasterEntity.emp_id))
                    {
                        List<STD_PERSONNEL> obj = MC.PERSONNEL_LIST.Where(x => x.emp_id == MasterEntity.emp_id).ToList();
                        if(obj != null)
                        {
                            if (obj.Count > 0)
                            {
                                MasterEntity.title = obj[0].emp_name;
                            }
                        }
                        
                    }
                }
            }
        }

        #region ICollection
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }


        #endregion
        #region Relay Commands Declarations
        public RelayCommand<object> cmdSelectItem { get; private set; }
        public RelayCommand<object> cmdSelectRecord { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDocument { get; private set; }
        public RelayCommand<object> cmdAuthorisation { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_Item { get; private set; }
        public RelayCommand<object> cmdInsertRole { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand OpenCommand
        {
            get;
            private set;
        }

        #endregion
        
        #region SYS_AUTH
        
        private SYS_AUTH _MasterEntity;
        public SYS_AUTH MasterEntity
        {
            get
            {
                this.ErrorExist = _MasterEntity.HasErrors;
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }
        private ObservableCollection<SYS_AUTH> _ItemsEntity;
        public ObservableCollection<SYS_AUTH> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private SYS_AUTH _ItemEntityObject;
        public SYS_AUTH ItemEntityObject
        {
            get
            {
                return _ItemEntityObject;
            }
            set
            {
                if (_ItemEntityObject != value)
                {
                    _ItemEntityObject = value;
                    RaisePropertyChanged("ItemEntityObject");
                }
            }
        }
        #endregion
        #region ADM_M010B



        #endregion
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }
        private MC_SYS_BE _MC;
        public MC_SYS_BE MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }
        private MC_SYS_BE _MC_TEMP;
        public MC_SYS_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value;

                    RaisePropertyChanged("MC_TEMP");
                }
            }
        }
        public SYS_S0001_VM(string ts_code)
            : base()
        {
            ts_code_vm = ts_code;
            SYS_AUTH.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            sms = this.GetViewService<IShowMessageViewService>();
            MC = new MC_SYS_BE();
            MC_TEMP = new MC_SYS_BE();
            MasterEntity = new SYS_AUTH();
            ItemsEntity = new ObservableCollection<SYS_AUTH>();
            OpenCommand = new RelayCommand(OpenFile);
            cmdSelectionChanged_Item = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_Item(items); });
            cmdInsertRole = new RelayCommand<object>(items => { if (items == null) { return; } InsertRole(items); });
            cmdLoadDocument = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentFromBackFlip(items); });
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        private void SelectionChanged_Item(object InputValue)
        {
            try
            {
                ItemEntityObject = (SYS_AUTH)InputValue;
            }
            catch (Exception ex) { }
        }
        private void InsertRole(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_AUTH POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.ROLE_LIST.Where(x => x.role_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.role_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_AUTH>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ItemEntityObject.role_code = POPUPEntityObject.role_code;
                    ItemEntityObject.role_name = POPUPEntityObject.role_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void LoadDocumentFromBackFlip(object ParameterObject)
        {
            EntityChangeEnable = false;
            CursorControl.SetBusyState();
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                SYS_AUTH ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                     if (((IEnumerable)ParameterObject).Cast<SYS_AUTH>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SYS_AUTH>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + (ParameterEntityObject.location_id ?? "") + "!@!@!@" + ParameterEntityObject.userid + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                        MC_TEMP = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC_TEMP, Request, "ADM_S0001_BL", "SYS", "LOAD_DOC_BY_DOC_NO", 0, "");
                        blNew = false;
                    }
                }

                if (MC_TEMP.USER_LIST != null)
                {
                    MasterEntity = MC_TEMP.USER_LIST[0];
                }
                else
                {
                    MasterEntity = new SYS_AUTH();
                }
                if (MC_TEMP.ROLE_USER_LIST != null)
                {
                    ItemsEntity.Clear();
                    ItemsEntity = MC_TEMP.ROLE_USER_LIST;
                }
                else
                {
                    ItemsEntity = new ObservableCollection<SYS_AUTH>();
                }

                SelectedTabControlIndex = 0;
                EntityChangeEnable = true;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SYS_AUTH item in e.NewItems)
                    {

                        
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code);
                        item.t_status = MasterEntity.t_status;
                        item.t_display = MasterEntity.t_display;
                        item.userid = MasterEntity.userid;

                        DateTime d = DateTime.UtcNow;
                        item.from_date = DateTime.UtcNow;
                        item.to_date = d.AddMonths(120);
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }


        #region Open Image

        private void OpenFile()
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.Gif)|*.jpg;*.bmp;*.Gif";
                fldlg.ShowDialog();
                {

                    imageName = fldlg.FileName;

                    MasterEntity.user_image = File.ReadAllBytes(imageName);

                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public BitmapImage ImageFromBytearray(byte[] imageData)
        {

            if (imageData == null)
                return null;
            MemoryStream strm = new MemoryStream();
            strm.Write(imageData, 0, imageData.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Gif);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
        #endregion
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC,Request, "ADM_S0001_BL", "SYS", "LOAD_INI", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.USER_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_AUTH)x).role_code);
                TheFilter = (o, prefix) => (((SYS_AUTH)o).role_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_AUTH)o).role_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ROLE = new AutoSuggestTextViewModel<dynamic>(MC.ROLE_LIST, TheFilter, SuggestedValue, "role_code", true);
                AS_ROLE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ROLE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_AUTH)x).user_type);
                TheFilter = (o, prefix) => (((SYS_AUTH)o).user_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_AUTH)o).user_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_USER_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.USER_TYPE_LIST, TheFilter, SuggestedValue, "user_type", true);
                AS_USER_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_USER_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;

                //MasterEntity.ts_code = this.ts_code_vm;
                //MasterEntity.doc_cat = doc_cat_vm;

                //MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                //MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                //MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.active = "1";
                MasterEntity.client = AppSessionState.client;
                MasterEntity.ts_code = ts_code_vm;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<SYS_AUTH> result)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.title))
                {
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    MasterEntity.XML_DOC_A = objSer.ObjectToXML(ItemsEntity);
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    MasterEntity.client = AppSessionState.client;
                    MasterEntity.ts_code = ts_code_vm;

                    if (blNew == true)
                    {
                        MasterEntity = REPOSITORY.SaveWithReturnDomainObject<SYS_AUTH>(MasterEntity, "ADM_S0001_BL", "SYS");
                        ItemsEntity = (ObservableCollection<SYS_AUTH>)objSer.XMLToObject(MasterEntity.XML_DOC_A, ItemsEntity);

                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        string response = REPOSITORY.Update<SYS_AUTH>(MasterEntity, "ADM_S0001_BL", "SYS");
                        ItemsEntity = (ObservableCollection<SYS_AUTH>)objSer.XMLToObject(MasterEntity.XML_DOC_A, ItemsEntity);
                    }
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("User name required", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<SYS_AUTH> result)
        {
            blNew = true;
            MasterEntity = new SYS_AUTH();
            ItemsEntity = new ObservableCollection<SYS_AUTH>();
        }
        protected override void OnRemoveAction(InquiryActionResult<SYS_AUTH> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<SYS_AUTH> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<SYS_AUTH> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<SYS_AUTH> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<SYS_AUTH> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<SYS_AUTH> result)
        {
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<SYS_AUTH> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SYS_AUTH> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SYS_AUTH> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SYS_AUTH> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SYS_AUTH> result)
        {
            throw new NotImplementedException();
        }
        #endregion

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
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as SYS_AUTH;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.userid != null && data.userid.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.username != null && data.username.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.emp_id != null && data.emp_id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.emp_name != null && data.emp_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.title != null && data.title.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.role_name != null && data.role_name.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }


    }
}
