using System;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Controls;
using System.Windows.Data;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using Reflection.BusinessEntity.ADM;
using Reflection.Presentation.Common;
using System.Collections.Specialized;

namespace Reflection.Modules.Settings.ViewModels
{
    public class SYS_S0002_VM : WorkspaceViewModel<STD_LIST_BE>
    {
        bool isNewRecord = true;

        #region Variables Declaration
        IShowMessageViewService sms;
        public string ts_code_vm { get; set; }
        WebServiceRepository<SYS_AUTH> REPOSITORY = new WebServiceRepository<SYS_AUTH>();
        WebServiceRepository<MC_SYS_BE> REPOSITORY_MC = new WebServiceRepository<MC_SYS_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_SYS_BE _MC = new MC_SYS_BE();
        public MC_SYS_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_SYS_BE _MC_TEMP = new MC_SYS_BE();
        public MC_SYS_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }
        private STD_LIST_BE _LIST_OBJ = new STD_LIST_BE();
        public STD_LIST_BE LIST_OBJ
        {
            get { return _LIST_OBJ; }
            set { if (_LIST_OBJ != value) { _LIST_OBJ = value; RaisePropertyChanged("LIST_OBJ"); } }
        }
        private SYS_AUTH _AUTH_OBJ = new SYS_AUTH();
        public SYS_AUTH AUTH_OBJ
        {
            get { return _AUTH_OBJ; }
            set { if (_AUTH_OBJ != value) { _AUTH_OBJ = value; RaisePropertyChanged("AUTH_OBJ"); } }
        }
        private SYS_AUTH _MASTER_TNTITY = new SYS_AUTH();
        public SYS_AUTH MASTER_TNTITY
        {
            get { return _MASTER_TNTITY; }
            set { if (_MASTER_TNTITY != value) { _MASTER_TNTITY = value; RaisePropertyChanged("MASTER_TNTITY"); } }
        }
        private ObservableCollection<SYS_AUTH> _ITEMS_ENTITY = new ObservableCollection<SYS_AUTH>();
        public ObservableCollection<SYS_AUTH> ITEMS_ENTITY
        {
            get { return _ITEMS_ENTITY; }
            set
            {
                if (_ITEMS_ENTITY != value)
                {
                    _ITEMS_ENTITY = value;
                    ITEMS_ENTITY.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_Item);
                    RaisePropertyChanged("ITEMS_ENTITY");
                }
            }
        }
        private ObservableCollection<SYS_AUTH> _AUTH_ENTITY = new ObservableCollection<SYS_AUTH>();
        public ObservableCollection<SYS_AUTH> AUTH_ENTITY
        {
            get { return _AUTH_ENTITY; }
            set
            {
                if (_AUTH_ENTITY != value)
                {
                    _AUTH_ENTITY = value;
                    AUTH_ENTITY.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_Auth);
                    RaisePropertyChanged("AUTH_ENTITY");
                }
            }
        }
        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                _REQ_PARA_OBJ = value;
                RaisePropertyChanged("REQ_PARA_OBJ");
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
                _dgSelectedIndexItem = value;
                RaisePropertyChanged("dgSelectedIndexItem");
            }
        }

        private SYS_AUTH _ITEM_OBJ;
        public SYS_AUTH ITEM_OBJ
        {
            get
            {
                return _ITEM_OBJ;
            }
            set
            {
                if (_ITEM_OBJ != value)
                {
                    _ITEM_OBJ = value;
                    RaisePropertyChanged("ITEM_OBJ");
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
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }

        }
        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SYS_S0002_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        
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
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_TS_CODES { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TS_CODES
        {
            get { return _AS_TS_CODES; }
            set
            {
                if (_AS_TS_CODES != value)
                {
                    _AS_TS_CODES = value; RaisePropertyChanged("AS_TS_CODES");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_AUTHOR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_AUTHOR
        {
            get { return _AS_AUTHOR; }
            set
            {
                if (_AS_AUTHOR != value)
                {
                    _AS_AUTHOR = value; RaisePropertyChanged("AS_AUTHOR");
                }
            }
        }


        #endregion

        #region ICollection
        private ICollectionView _TS_CODE_COLLECTION;
        public ICollectionView TS_CODE_COLLECTION
        {
            get { return _TS_CODE_COLLECTION; }
            private set { _TS_CODE_COLLECTION = value; RaisePropertyChanged("TS_CODE_COLLECTION"); }
        }
        private ICollectionView _ROLE_COLLECTION;
        public ICollectionView ROLE_COLLECTION
        {
            get { return _ROLE_COLLECTION; }
            private set { _ROLE_COLLECTION = value; RaisePropertyChanged("ROLE_COLLECTION"); }
        }

        private ICollectionView _DataGridviewFilter;
        // This DataGridView filter Authorisation Lines for selected TS_CODE item. it will show Authorization only for selected ts_code item.
        public ICollectionView DataGridViewFilter
        {
            get { return _DataGridviewFilter; }
            set { _DataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }
        #endregion

        #region Relay Commands Declarations
        public RelayCommand<object> cmdSelectItem { get; private set; }
        public RelayCommand<object> cmdSelectRecord { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDocument { get; private set; }
        public RelayCommand<object> cmdAuthorisation { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_Item { get; private set; }

        #endregion

        #region Constructor
        public SYS_S0002_VM(string ts_code) : base()
        {
            sms = this.GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            MC = new MC_SYS_BE();
            MC_TEMP = new MC_SYS_BE();
            LIST_OBJ = new STD_LIST_BE();
            AUTH_OBJ = new SYS_AUTH();
            MASTER_TNTITY = new SYS_AUTH();
            ITEMS_ENTITY = new ObservableCollection<SYS_AUTH>();
            AUTH_ENTITY = new ObservableCollection<SYS_AUTH>();
            MC.TSCODE_AUTH_LIST = new ObservableCollection<SYS_AUTH>();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            ITEM_OBJ = new SYS_AUTH();
            REQ_PARA_OBJ.ts_code = ts_code;
            STD_REQ_PARA_BE.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ITEMS_ENTITY.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_Item);
            AUTH_ENTITY.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_Auth);
            cmdSelectItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectItem(items); });
            cmdSelectRecord = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentFromBackFlip(items); });
            cmdDeleteDataGridRowDocument = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDocument(items); });
            cmdAuthorisation = new RelayCommand<object>(items => { if (items == null) { return; } Authorisation(items); });
            cmdSelectionChanged_Item = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_Item(items); });
            LoadInitialData();
            DefaultValues();
        }
        #endregion

        #region User Defined Functions
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "comp_code")
                {
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                    TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                    AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;
                }
                if (sender.ToString() == "posting_period")
                {
                    List<STD_LIST_BE> pp_list2 = MC.POSTING_PERIOD_LIST.Where(o => o.fin_year == REQ_PARA_OBJ.fin_year && o.posting_period == REQ_PARA_OBJ.posting_period).ToList();
                    if (pp_list2 != null)
                    {
                        if (pp_list2.Count > 0)
                        {
                            REQ_PARA_OBJ.para1 = pp_list2[0].display_name;
                            REQ_PARA_OBJ.fin_year = pp_list2[0].fin_year;
                            REQ_PARA_OBJ.posting_period = pp_list2[0].posting_period;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CCN_Item(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SYS_AUTH item in e.NewItems)
                    {
                        item.active = "1";
                        item.t_status = "01";
                        item.client = AppSessionState.client;
                        item.comp_code = (ITEM_OBJ.comp_code ?? AppSessionState.comp_code);
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {}
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {}
                if (e.Action == NotifyCollectionChangedAction.Move)
                {}
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void CCN_Auth(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SYS_AUTH item in e.NewItems)
                    {
                        item.active = "1";
                        item.t_status = "01";
                        item.client = AppSessionState.client;
                        item.comp_code = (ITEM_OBJ.comp_code ?? AppSessionState.comp_code);
                        item.ts_code = ITEM_OBJ.ts_code;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id + "!@" + ts_code_vm;
                MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC, Request, "ADM_S0002", "SYS", " ", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_AUTH)x).ts_code);
                TheFilter = (o, prefix) => (((SYS_AUTH)o).ts_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_AUTH)o).ts_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TS_CODES = new AutoSuggestTextViewModel<dynamic>(MC.TS_CODE_LIST, TheFilter, SuggestedValue, "ts_code", true);
                AS_TS_CODES.AutoSuggestVM.IsEmptyValueAllowed = true; AS_TS_CODES.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_AUTH)x).auth_code);
                TheFilter = (o, prefix) => (((SYS_AUTH)o).auth_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_AUTH)o).auth_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_AUTHOR = new AutoSuggestTextViewModel<dynamic>(MC.STD_AUTH_LIST, TheFilter, SuggestedValue, "auth_code", true);
                AS_AUTHOR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_AUTHOR.AutoSuggestVM.IsFreeTextAllowed = false;



                TS_CODE_COLLECTION = CollectionViewSource.GetDefaultView(MC.TS_CODE_LIST);
                TS_CODE_COLLECTION.Filter = new Predicate<object>(FLTR_TSCODE);

                ROLE_COLLECTION = CollectionViewSource.GetDefaultView(MC.ROLE_LIST);
                ROLE_COLLECTION.Filter = new Predicate<object>(FLTR_ROLE);

            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            try
            {
                isNewRecord = true;
                MASTER_TNTITY = new SYS_AUTH();
                ITEMS_ENTITY = new ObservableCollection<SYS_AUTH>();
                AUTH_ENTITY = new ObservableCollection<SYS_AUTH>();
                MASTER_TNTITY.userid = AppSessionState.UserID;
                MASTER_TNTITY.client = AppSessionState.client;
                ITEM_OBJ = new SYS_AUTH();
                MASTER_TNTITY.t_status = "01";


            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(MASTER_TNTITY.role_code) && string.IsNullOrEmpty(MASTER_TNTITY.role_name))
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Validation";sms.Text = String.Format("Please input Data!");sms.ShowMessage();
                return false;
            }
            return true;
        }
        private void SelectItem(object InputValue)
        {
            try
            {
                SYS_AUTH OBJ_AUTH = new SYS_AUTH();
                foreach (var item in MC.TS_CODE_LIST)
                {
                    if (item.selected == true)
                    {
                        //if(ITEMS_ENTITY.Count > 0)
                        //{
                        //    int obj_count = ITEMS_ENTITY.Where(x => x.ts_code.Equals(item.ts_code, StringComparison.OrdinalIgnoreCase) == true).ToList().Count;
                        //    if(obj_count <= 0)
                        //    {
                        //        var POPUPEntityObject = ITEMS_ENTITY.Where(x => x.ts_code.Equals(item.ts_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        //        OBJ_AUTH.ts_code = POPUPEntityObject.ts_code;
                        //    }
                        //}
                        
                        bool varValue = ITEMS_ENTITY.Any(x => x.ts_code == item.ts_code);
                        if (varValue == false && !string.IsNullOrWhiteSpace(MASTER_TNTITY.role_code)) // && OBJ_AUTH.ts_code == null
                        {
                            item.role_code = MASTER_TNTITY.role_code;
                            item.active = "1";
                            item.row_no = ITEMS_ENTITY.Count + 1;
                            ITEMS_ENTITY.Add(item);
                            FilterAuthDataGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format(ex.Message, this.Title);sms.ShowMessage();
            }
        }
        private void FilterAuthDataGrid()
        {
            try
            {
                int auth_count = AUTH_ENTITY.Where(x => x.role_code == ITEM_OBJ.role_code && x.ts_code == ITEM_OBJ.ts_code).Count();
                if (auth_count <= 0 && !string.IsNullOrWhiteSpace(ITEM_OBJ.ts_code))
                {
                    foreach (SYS_AUTH item in MC.STD_AUTH_LIST)
                    {
                        
                        //item.CopyPropertiesTo<SYS_AUTH>(new_auth_obj);
                        //new_auth_obj = ITEM_OBJ;
                        if (AUTH_ENTITY.Where(x => x.role_code == ITEM_OBJ.role_code && x.ts_code == ITEM_OBJ.ts_code && x.auth_code == item.auth_code).Count()==0)
                        {
                            SYS_AUTH new_auth_obj = new SYS_AUTH();
                            new_auth_obj.ts_code = ITEM_OBJ.ts_code;
                            new_auth_obj.role_code = MASTER_TNTITY.role_code;
                            new_auth_obj.auth_code = item.auth_code;
                            new_auth_obj.auth_name = item.auth_name;
                            new_auth_obj.active = item.active;

                            AUTH_ENTITY.Add(new_auth_obj);
                        }
                    }
                }
                if (AUTH_ENTITY != null && AUTH_ENTITY.Count > 0
                       && ITEMS_ENTITY != null && ITEMS_ENTITY.Count > 0 && ITEM_OBJ != null && !string.IsNullOrWhiteSpace(MASTER_TNTITY.role_code))
                {
                    if (!string.IsNullOrWhiteSpace(ITEM_OBJ.ts_code))
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(AUTH_ENTITY);
                        DataGridViewFilter.Filter = adv => ((SYS_AUTH)adv).role_code.Equals(MASTER_TNTITY.role_code) && ((SYS_AUTH)adv).ts_code.Equals(ITEM_OBJ.ts_code);
                        DataGridViewFilter.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;
                sms.Caption = "Message";
                sms.Text = String.Format(ex.Message, this.Title);
                sms.ShowMessage();
            }
        }
        private void DeleteDataGridRowDocument(object item)
        {

        }
        private void SelectionChanged_Item(object InputValue)
        {
            try
            {
                ITEM_OBJ = (SYS_AUTH)InputValue;
                FilterAuthDataGrid();
            }
            catch (Exception ex) { }
        }
        private void Authorisation(object item)
        {
            try
            {
                if (((IEnumerable)item).Cast<SYS_AUTH>().ToList().Count > 0)
                {
                    SYS_AUTH ParameterEntityObject = ((IEnumerable)item).Cast<SYS_AUTH>().ToList()[0];
                    AppSessionState.ViewTitle = "User Role : Authorisation";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Settings.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.Settings.Views.S0003");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "S0003", ParameterEntityObject.role_code, ParameterEntityObject);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
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
        private void LoadDocumentFromBackFlip(object item)
        {
            SYS_AUTH OBJ = new SYS_AUTH();
            OBJ = (SYS_AUTH)item;
            string Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id + "!@" + OBJ.role_code + "!@" + OBJ.role_code + "!@" + OBJ.role_code;
            MC_TEMP = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC_TEMP, Request, "ADM_S0002", "SYS", " ", 0, "");

            if (MC_TEMP.ROLE_LIST != null)
            {
                if (MC_TEMP.ROLE_LIST.Count > 0)
                {
                    MASTER_TNTITY = MC_TEMP.ROLE_LIST[0];
                }
            }
            if (MC_TEMP.ROLE_TSCODE_LIST != null)
            {
                if(MC_TEMP.ROLE_TSCODE_LIST.Count > 0)
                {
                    ITEMS_ENTITY = MC_TEMP.ROLE_TSCODE_LIST;
                }
            }
            if (MC_TEMP.TSCODE_AUTH_LIST != null)
            {
                if (MC_TEMP.TSCODE_AUTH_LIST.Count > 0)
                {
                    AUTH_ENTITY = MC_TEMP.TSCODE_AUTH_LIST;
                }
            }
            SelectedTabControlIndex = 0;
        }
        #endregion

        #region Abstract Classes Implementation
        protected override void OnDocumentAction()
        {

        }

        protected override void OnSaveAction(InquiryActionResult<STD_LIST_BE> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if (Validation() == true)
                {
                    MASTER_TNTITY.userid = AppSessionState.UserID;
                   
                    this.StatusMessage = "Saving changes, please wait ...";
                    MASTER_TNTITY.XML_DOC_A = obj.ObjectToXML(ITEMS_ENTITY);
                    MASTER_TNTITY.XML_DOC_B = obj.ObjectToXML(AUTH_ENTITY);
                    this.MASTER_TNTITY.EndEdit();

                    if (isNewRecord == true)
                    {
                        MASTER_TNTITY = REPOSITORY.SaveWithReturnDomainObject<SYS_AUTH>(MASTER_TNTITY, "ADM_S0002", "SYS");
                        //MC_TEMP = REPOSITORY_MC.SaveWithReturnDomainObject<MC_SYS_BE>(MC_TEMP, "ADM_S0002", "SYS");
                    }
                    else if (isNewRecord == false)
                    {
                        MASTER_TNTITY = REPOSITORY.UpdateWithReturnDomainObject<SYS_AUTH>(MASTER_TNTITY, "ADM_S0002", "SYS");
                    }

                    if (MASTER_TNTITY.XML_DOC_A != null)
                    {
                        ITEMS_ENTITY.Clear();
                        ITEMS_ENTITY = (ObservableCollection<SYS_AUTH>)new ObjectSerializationService().XMLToObject(MASTER_TNTITY.XML_DOC_A, MC.ROLE_TSCODE_LIST);
                    }
                    else
                    {
                        ITEMS_ENTITY = new ObservableCollection<SYS_AUTH>();
                    }
                    if (MASTER_TNTITY.XML_DOC_B != null)
                    {
                        AUTH_ENTITY.Clear();
                        AUTH_ENTITY = (ObservableCollection<SYS_AUTH>)new ObjectSerializationService().XMLToObject(MASTER_TNTITY.XML_DOC_B, MC.TSCODE_AUTH_LIST);
                    }
                    else
                    {
                        AUTH_ENTITY = new ObservableCollection<SYS_AUTH>();
                    }
                    
                    if (!string.IsNullOrWhiteSpace(MASTER_TNTITY.role_code))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........", this.Title); sms.ShowMessage();
                    }
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
              
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<STD_LIST_BE> result)
        {
            MC_TEMP = new MC_SYS_BE();
            LIST_OBJ = new STD_LIST_BE();
            AUTH_OBJ = new SYS_AUTH();
            MASTER_TNTITY = new SYS_AUTH();
            ITEMS_ENTITY = new ObservableCollection<SYS_AUTH>();
            AUTH_ENTITY = new ObservableCollection<SYS_AUTH>();
            ITEM_OBJ = new SYS_AUTH();
            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Filter Themes
        private string _STR_FLTR_TSCODE;
        public string STR_FLTR_TSCODE
        {
            get { return _STR_FLTR_TSCODE; }
            set
            {
                _STR_FLTR_TSCODE = value;
                RaisePropertyChanged("STR_FLTR_TSCODE");
                FLTR_TSCODE_RFR();
            }
        }
        private void FLTR_TSCODE_RFR()
        {
            if (TS_CODE_COLLECTION != null)
            {
                TS_CODE_COLLECTION.Refresh();
            }
        }
        public bool FLTR_TSCODE(object obj)
        {
            var data = obj as SYS_AUTH;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(STR_FLTR_TSCODE))
                {
                    return (data.ts_code != null && data.ts_code.ToString().ToLower().Contains(STR_FLTR_TSCODE.ToLower()) ||
                            data.module_code != null && data.module_code.ToString().ToLower().Contains(STR_FLTR_TSCODE.ToLower()) ||
                            data.ts_name != null && data.ts_name.ToString().ToLower().Contains(STR_FLTR_TSCODE.ToLower())
                       );
                }
                return true;
            }
            return false;
        }



        private string _STR_FLTR_ROLE;
        public string STR_FLTR_ROLE
        {
            get { return _STR_FLTR_ROLE; }
            set
            {
                _STR_FLTR_ROLE = value;
                RaisePropertyChanged("STR_FLTR_ROLE");
                FLTR_ROLE();
            }
        }
        private void FLTR_ROLE()
        {
            if (ROLE_COLLECTION != null)
            {
                ROLE_COLLECTION.Refresh();
            }
        }
        public bool FLTR_ROLE(object obj)
        {
            var data = obj as SYS_AUTH;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(STR_FLTR_ROLE))
                {
                    return (data.role_code != null && data.role_code.ToString().ToLower().Contains(STR_FLTR_ROLE.ToLower()) ||
                            data.role_name != null && data.role_name.ToString().ToLower().Contains(STR_FLTR_ROLE.ToLower())
                       );
                }
                return true;
            }
            return false;
        }
        #endregion

    }
}

