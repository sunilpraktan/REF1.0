using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity.ADM;
using System.Windows.Data;
using System.Collections.Specialized;
using Reflection.Presentation.Common;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;
using Reflection.BusinessEntity.GEN;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M0033_VM : WorkspaceViewModel<QMS_M0033>
    {
        bool NewRecord = true;
        WebServiceRepository<QMS_M0033> REPO = new WebServiceRepository<QMS_M0033>();
        WebServiceRepository<MC_QMS_M0033> REPO_MC = new WebServiceRepository<MC_QMS_M0033>();
        WebServiceRepository<STD_MC_BE> REPO_STD_MC = new WebServiceRepository<STD_MC_BE>();
        WebServiceRepository<GEN_M0101> REPO_STD_GEN = new WebServiceRepository<GEN_M0101>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private QMS_M0033 _MasterEntity;
        public QMS_M0033 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private QMS_M0033_A _ITEM_OBJ;
        public QMS_M0033_A ITEM_OBJ
        {
            get { return _ITEM_OBJ; }
            set { _ITEM_OBJ = value; RaisePropertyChanged("ITEM_OBJ"); }
        }

        private ObservableCollection<QMS_M0033_A> _ItemsEntity;
        public ObservableCollection<QMS_M0033_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set { _ItemsEntity = value; RaisePropertyChanged("ItemsEntity"); }
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
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
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
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private MC_QMS_M0033 _MC;
        public MC_QMS_M0033 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_QMS_M0033 _MC_TEMP;
        public MC_QMS_M0033 MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private IEnumerable _PROFILE_TYPE_LIST;
        public IEnumerable PROFILE_TYPE_LIST
        {
            get { return _PROFILE_TYPE_LIST; }
            set
            {
                _PROFILE_TYPE_LIST = value;

                RaisePropertyChanged("PROFILE_TYPE_LIST");
            }
        }
        private IEnumerable _DEF_CLASS_LIST;
        public IEnumerable DEF_CLASS_LIST
        {
            get { return _DEF_CLASS_LIST; }
            set
            {
                _DEF_CLASS_LIST = value;

                RaisePropertyChanged("DEF_CLASS_LIST");
            }
        }
        private ICollectionView _CHAR_VALUE_COL;
        public ICollectionView CHAR_VALUE_COL
        {
            get { return _CHAR_VALUE_COL; }
            set { _CHAR_VALUE_COL = value; RaisePropertyChanged("CHAR_VALUE_COL"); }
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
        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }

        #endregion

        #region Style

        private Font _fontName;
        public Font fontName
        {
            get { return _fontName; }
            set { _fontName = value; RaisePropertyChanged("fontName"); }
        }
        private Color _textBackColor;
        public Color textBackColor
        {
            get { return _textBackColor; }
            set { _textBackColor = value; RaisePropertyChanged("textBackColor"); }
        }
        private Color _textForeColor;
        public Color textForeColor
        {
            get { return _textForeColor; }
            set { _textForeColor = value; RaisePropertyChanged("textForeColor"); }
        }


        #endregion

        #region Relay Command Decleration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdInsertProfileType { get; private set; }
        public RelayCommand<object> cmdInsertCharValues { get; private set; }
        public RelayCommand<object> cmdInsertDefectClass { get; private set; }
        public RelayCommand<object> cmdStyleFormating { get; private set; }
        #endregion

        #region Constructor
        public QMS_M0033_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M0033();
            ItemsEntity = new ObservableCollection<QMS_M0033_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyItemsEntity);
            ITEM_OBJ = new QMS_M0033_A();
            MC = new MC_QMS_M0033();
            MC_TEMP = new MC_QMS_M0033();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            InitialzeCommands();
            LoadInitialData();
            DefaultValues();

            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;
        }
        public QMS_M0033_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M0033();
            ItemsEntity = new ObservableCollection<QMS_M0033_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyItemsEntity);
            ITEM_OBJ = new QMS_M0033_A();
            MC = new MC_QMS_M0033();
            MC_TEMP = new MC_QMS_M0033();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            InitialzeCommands();
            LoadInitialData();
            DefaultValues();

            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;
        }
        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = "1";
            MasterEntity.t_status = "01";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.Location_id = AppSessionState.location_Id;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_M0033>(MC, Request, "QMS_M0033_BL", "QMS", "LOAD_INI", 0, "");

                PROFILE_TYPE_LIST = MC.ProfileTypeList;
                DEF_CLASS_LIST = MC.DefectClassList;

                CHAR_VALUE_COL = CollectionViewSource.GetDefaultView(MC.CHAR_VALUE_LIST);
                CHAR_VALUE_COL.Filter = new Predicate<object>(FLTR_CHAR_VALUE);

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
        private void InitialzeCommands()
        {
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdInsertDefectClass = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefectClass(cmdPara, true, true, true); });
            cmdInsertCharValues = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCharValue(cmdPara, ""); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            cmdStyleFormating = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } StyleFormating(cmdPara); });
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
                }
                else
                {
                    DefaultValues();
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
            //if (MasterEntity.para_prof_code == null || MasterEntity.para_prof_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("please Enter Parameter Profile Code...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.short_text == null || MasterEntity.short_text == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Enter Parameter Profile Name...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.prof_type == null || MasterEntity.prof_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Enter Profile Type...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            STD_LIST_BE ParameterEntityObject = null;
            if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ParameterEntityObject.doc_no;
                NewRecord = false;
                Readonly = true;

                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_M0033>(MC_TEMP, Request, "QMS_M0033_BL", "QMS", "LOAD_DOCUMENT", 0, "");

                if (MC_TEMP.MasterList.Count > 0)
                {
                    MasterEntity = MC_TEMP.MasterList[0];
                }
                ItemsEntity = MC_TEMP.ItemsEntity;
            }
            SelectedTabControlIndex = 0;
            //MasterEntity.ts_code = ts_code_vm;
            //var msg = new NotificationMessage(ts_code_vm);
            //Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MC_TEMP.MasterList != null)
            {
                if (MC_TEMP.MasterList.Count > 0)
                {
                    MasterEntity = MC_TEMP.MasterList[0];
                    ItemsEntity.Clear();
                    ItemsEntity = MC_TEMP.ItemsEntity;
                }

            }
            else
            {
                MC.MasterList = new System.Collections.Generic.List<QMS_M0033>();
                MC.ItemsEntity = new ObservableCollection<QMS_M0033_A>();
            }
        }
        private void InsertCharValue(object InputValue, string RequestValue)
        {
            try
            {
                string Request = "";
                Classification POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CHAR_VALUE_LIST.Where(x => x.char_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = ItemsEntity.Where(x => x.char_value == POPUPEntityObject.para_value).FirstOrDefault();
                    //int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.char_value == POPUPEntityObject.para_value).FirstOrDefault());

                    ITEM_OBJ = ItemsEntity.Where(x => x.char_value == POPUPEntityObject.char_value).FirstOrDefault();

                    if (ITEM_OBJ == null)
                    {
                        ItemsEntity.Add(new QMS_M0033_A
                        {
                            id = 0,
                            char_code = POPUPEntityObject.char_code,
                            char_value = POPUPEntityObject.char_value,
                            short_text = POPUPEntityObject.short_text,
                            long_text = POPUPEntityObject.long_text,
                            char_name = POPUPEntityObject.char_name,
                            prof_type = POPUPEntityObject.prof_type,
                            prof_code = POPUPEntityObject.profile_code,
                            prof_name = POPUPEntityObject.profile_name,
                            def_class = POPUPEntityObject.def_class,
                            def_class_name = POPUPEntityObject.def_class_name,
                            active = "1",
                            location_id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            t_status = MasterEntity.t_status
                    });
                    }
                    else if (ITEM_OBJ != null)
                    {
                        ITEM_OBJ.char_code = POPUPEntityObject.char_code;
                        ITEM_OBJ.char_value = POPUPEntityObject.char_value;
                        ITEM_OBJ.char_name = POPUPEntityObject.char_name;
                        ITEM_OBJ.prof_type = POPUPEntityObject.prof_type;
                        ITEM_OBJ.prof_code = POPUPEntityObject.profile_code;
                        ITEM_OBJ.prof_name = POPUPEntityObject.profile_name;
                        ITEM_OBJ.def_class = POPUPEntityObject.def_class;
                        ITEM_OBJ.def_class_name = POPUPEntityObject.def_class_name;
                        ITEM_OBJ.active = "1";
                        ITEM_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;
                        ITEM_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        ITEM_OBJ.t_status = MasterEntity.t_status;
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
        private void InsertDefectClass(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M0031 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.DefectClassList.Where(x => x.def_class.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M031_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M0031>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.def_class == POPUPEntityObject.def_class).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.def_class == POPUPEntityObject.def_class).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndex].id == 0 && AllowDuplicate == true) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndex].def_class = POPUPEntityObject.def_class;
                            ItemsEntity[dgSelectedIndex].def_class_name = POPUPEntityObject.short_text;
                            ItemsEntity[dgSelectedIndex].quality_score = Convert.ToInt32(POPUPEntityObject.quality_score);
                        }
                        else if (ItemsEntity[dgSelectedIndex].def_class != POPUPEntityObject.def_class)
                        {
                            ItemsEntity[dgSelectedIndex].def_class = "";
                        }
                    }
                }
                #region Clear Empty Row
                QMS_M0033_A newObj = new QMS_M0033_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
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

        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + (REQ_PARA_OBJ.active_code ?? "") + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC_TEMP, Request, "QMS_M0033_BL", "QMS", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void StyleFormating(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                if (ITEM_OBJ != null)
                { if (ITEM_OBJ.id > 0)
                    {
                        FontDialog fontDlg = new FontDialog();
                        fontDlg.ShowColor = true;
                        fontDlg.ShowApply = true;
                        fontDlg.ShowEffects = true;
                        fontDlg.ShowHelp = true;
                        fontDlg.MaxSize = 40;
                        fontDlg.MinSize = 22;

                        //fontDlg.Font =  STD_MC.STYLE_LIST[0].font_family;
                        //fontDlg.for = STD_MC.STYLE_LIST[0].color;
                        //fontDlg.Font.Bold = STD_MC.STYLE_LIST[0].bold;
                        //fontDlg.Font.Size = STD_MC.STYLE_LIST[0].font_family;

                        //fontDlg.Font.FontFamily.Name = ITEM_OBJ.font_family;
                        //fontDlg.Color.Name = ITEM_OBJ.color;
                        //fontDlg.Font.Bold= ITEM_OBJ.bold;
                        //fontDlg.Font.Size = ITEM_OBJ.font_size + 10;

                        if (fontDlg.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                        {
                            ITEM_OBJ.font_family = fontDlg.Font.FontFamily.Name;
                            ITEM_OBJ.color = fontDlg.Color.Name;
                            ITEM_OBJ.bold = fontDlg.Font.Bold;
                            ITEM_OBJ.font_size = fontDlg.Font.Size -10;

                            GEN_M0101 OBJ_GEN_M0101 = new GEN_M0101();

                            OBJ_GEN_M0101.client = MasterEntity.client;
                            OBJ_GEN_M0101.comp_code = MasterEntity.comp_code;
                            OBJ_GEN_M0101.obj_type = MasterEntity.prof_type;
                            OBJ_GEN_M0101.obj_code = MasterEntity.prof_code;
                            OBJ_GEN_M0101.row_id = ITEM_OBJ.id;
                            OBJ_GEN_M0101.font_family = ITEM_OBJ.font_family;
                            OBJ_GEN_M0101.font_size = ITEM_OBJ.font_size;
                            OBJ_GEN_M0101.bold = ITEM_OBJ.bold;
                            OBJ_GEN_M0101.color = ITEM_OBJ.color;


                            OBJ_GEN_M0101 = REPO_STD_GEN.SaveWithReturnDomainObject<GEN_M0101>(OBJ_GEN_M0101, "GEN_M0101_BL", "GEN");

                            ////NOTE: save work pending
                            //string Request = "LOAD_STYLE" + "!@" + AppSessionState.client + "!@" + ITEM_OBJ.comp_code + "!@" + (ITEM_OBJ.location_id ?? "") + "!@" + ITEM_OBJ.prof_code + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                            //STD_MC_BE STD_MC = REPO_STD_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, Request, "GEN_M0101_BL", "QMS", "LoadAll", 0, "");

                        }
                    }
                }
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void StyleFormatingOrg(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                if (ITEM_OBJ != null)
                {
                    if (ITEM_OBJ.id > 0)
                    {
                        string Request = "LOAD_STYLE" + "!@" + AppSessionState.client + "!@" + ITEM_OBJ.comp_code + "!@" + (ITEM_OBJ.location_id ?? "") + "!@" + ITEM_OBJ.prof_code + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                        STD_MC_BE STD_MC = REPO_STD_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, Request, "GEN_M0101_BL", "QMS", "LoadAll", 0, "");

                        if (STD_MC.STYLE_LIST != null)
                        {
                            if (STD_MC.STYLE_LIST.Count > 0)
                            {
                                FontDialog fontDlg = new FontDialog();
                                fontDlg.ShowColor = true;
                                fontDlg.ShowApply = true;
                                fontDlg.ShowEffects = true;
                                fontDlg.ShowHelp = true;
                                fontDlg.MaxSize = 40;
                                fontDlg.MinSize = 22;

                                //fontDlg.Font =  STD_MC.STYLE_LIST[0].font_family;
                                //fontDlg.for = STD_MC.STYLE_LIST[0].color;
                                //fontDlg.Font.Bold = STD_MC.STYLE_LIST[0].bold;
                                //fontDlg.Font.Size = STD_MC.STYLE_LIST[0].font_family;

                                if (fontDlg.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                                {
                                    fontName = fontDlg.Font;
                                    //textBackColor = fontDlg.Color;
                                    textForeColor = fontDlg.Color;
                                }
                            }
                            else
                            {
                                //if (fontDlg.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                                //{
                                //    fontName = fontDlg.Font;
                                //    //textBackColor = fontDlg.Color;
                                //    textForeColor = fontDlg.Color;
                                //}
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("first save Record", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CCNotifyItemsEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M0033_A item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_id = AppSessionState.OBJ_LOCATION.location_id;
                        item.t_status = "01";
                        item.valid_from = System.DateTime.Now;
                        item.t_status = MasterEntity.t_status;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove) //NOTE: use this section to remove dependant entries. like if Operation remove then all char data need to remove from Char Entity
                {}
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M0033> result)
        {
            MasterEntity = new QMS_M0033();
            ItemsEntity = new ObservableCollection<QMS_M0033_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyItemsEntity);
            ITEM_OBJ = new QMS_M0033_A();
            DefaultValues();
            NewRecord = true;
            Readonly = false;
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_M0033> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M0033> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_M0033> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_M0033> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_M0033> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_M0033> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_M0033> result)
        {
            try
            {
                CursorControl.SetBusyState();
                
                Logging();
                this.MasterEntity.EndEdit();
                
                if (Validation() == true)
                {
                    MC_TEMP.MasterList = new System.Collections.Generic.List<QMS_M0033>();
                    MC_TEMP.MasterList.Add(MasterEntity);
                    MC_TEMP.ItemsEntity = ItemsEntity;

                    //MasterEntity.XDOC_A = obj.ObjectToXML(ItemsEntity);
                    if (NewRecord == true)
                    {
                        MC_TEMP = REPO_MC.SaveWithReturnDomainObject<MC_QMS_M0033>(MC_TEMP, "QMS_M0033_BL", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MC_TEMP = REPO_MC.UpdateWithReturnDomainObject<MC_QMS_M0033>(MC_TEMP, "QMS_M0033_BL", "QMS");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.prof_code != null && MasterEntity.prof_code != "")
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
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M0033> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Filter For Flip Grid
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.valid_from != null && data.valid_from.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.tl_name != null && data.tl_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Char values
        private string _FLTR_STR_CHAR_VALUE;
        public string FLTR_STR_CHAR_VALUE
        {
            get { return _FLTR_STR_CHAR_VALUE; }
            set
            {
                _FLTR_STR_CHAR_VALUE = value;
                RaisePropertyChanged("FLTR_STR_CHAR_VALUE");
                FLTR_COLL_CHAR_VALUE();
            }
        }
        private void FLTR_COLL_CHAR_VALUE()
        {
            if (_CHAR_VALUE_COL != null)
            {
                _CHAR_VALUE_COL.Refresh();
            }
        }
        public bool FLTR_CHAR_VALUE(object obj)
        {
            var data = obj as Classification;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_CHAR_VALUE))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.char_code != null && data.char_code.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.char_value != null && data.char_value.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.char_name != null && data.char_name.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.char_group != null && data.char_group.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.profile_name != null && data.profile_name.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower())) ||
                        (data.para_type != null && data.para_type.ToString().ToLower().Contains(FLTR_STR_CHAR_VALUE.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
