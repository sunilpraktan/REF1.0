using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Settings;
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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Settings.ViewModels
{
    public class SYS_S001VM : WorkspaceViewModel<UserLevelSettings>
    {
        bool isNewRecord = true;
        WebServiceRepository<UserLevelSettings> repository = new WebServiceRepository<UserLevelSettings>();
        WebServiceRepository<MultipleContext_UserLevelSettings> repository_MC = new WebServiceRepository<MultipleContext_UserLevelSettings>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SYS_S001VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        
        private List<ADM_M0003> _LOCATION_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST
        {
            get { return _LOCATION_LIST; }
            set
            {
                if (_LOCATION_LIST != value)
                {
                    _LOCATION_LIST = value; RaisePropertyChanged("LOCATION_LIST");
                }
            }
        }





        private AutoSuggestTextViewModel<dynamic> _ASLanguage { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLanguage
        {
            get { return _ASLanguage; }
            set
            {
                if (_ASLanguage != value)
                {
                    _ASLanguage = value; RaisePropertyChanged("ASLanguage");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDateFormat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDateFormat
        {
            get { return _ASDateFormat; }
            set
            {
                if (_ASDateFormat != value)
                {
                    _ASDateFormat = value; RaisePropertyChanged("ASDateFormat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRoundUpMethod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRoundUpMethod
        {
            get { return _ASRoundUpMethod; }
            set
            {
                if (_ASRoundUpMethod != value)
                {
                    _ASRoundUpMethod = value; RaisePropertyChanged("ASRoundUpMethod");
                }
            }
        }

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

        private AutoSuggestTextViewModel<dynamic> _ASRoundingMethod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRoundingMethod
        {
            get { return _ASRoundingMethod; }
            set
            {
                if (_ASRoundingMethod != value)
                {
                    _ASRoundingMethod = value; RaisePropertyChanged("ASRoundingMethod");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASField { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASField
        {
            get { return _ASField; }
            set
            {
                if (_ASField != value)
                {
                    _ASField = value; RaisePropertyChanged("ASField");
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
                    if (SourceName == "doc_cat")
                    { ASDefault = ASDocCat; }
                    if (SourceName == "field_name")
                    { ASDefault = ASField; }
                    if (SourceName == "round_up_method_code")
                    { ASDefault = ASRoundingMethod; }
                }
            }
        }

        #endregion

        #region Declaration
        private MultipleContext_UserLevelSettings _MC;
        public MultipleContext_UserLevelSettings MC
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

        private int _FirstListViewSelectedIndex = 0;
        public int FirstListViewSelectedIndex
        {
            get { return _FirstListViewSelectedIndex; }
            set
            {
                if (_FirstListViewSelectedIndex != value)
                {
                    _FirstListViewSelectedIndex = value;
                    UpdateSecondListView();
                    RaisePropertyChanged("FirstListViewSelectedIndex");
                }
            }
        }

        private int _SecondListViewSelectedIndex;
        public int SecondListViewSelectedIndex
        {
            get { return _SecondListViewSelectedIndex; }
            set
            {
                if (_SecondListViewSelectedIndex != value)
                {
                    _SecondListViewSelectedIndex = value;
                    UpdateMasterEntity();
                    RaisePropertyChanged("SecondListViewSelectedIndex");
                }
            }
        }

        private object _SecondList;
        public object SecondList
        {
            get { return _SecondList; }
            set
            {
                if (_SecondList != value)
                {
                    _SecondList = value;
                    UpdateMasterEntity();
                    RaisePropertyChanged("SecondList");
                }
            }
        }

        private MultipleContext_UserLevelSettings _MCTemp;
        public MultipleContext_UserLevelSettings MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private UserLevelSettings _MasterEntity;
        public UserLevelSettings MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private SYS_C005 _SettingEntity;
        public SYS_C005 SettingEntity
        {
            get
            { return _SettingEntity; }
            set
            {
                _SettingEntity = value;
                RaisePropertyChanged("SettingEntity");
            }
        }

        private ObservableCollection<SYS_C005> _DocumentEntity;
        public ObservableCollection<SYS_C005> DocumentEntity
        {
            get
            { return _DocumentEntity; }
            set
            {
                _DocumentEntity = value;
                RaisePropertyChanged("DocumentEntity");
            }
        }

        private int _dgSelectedIndexDoc;
        public int dgSelectedIndexDoc
        {
            get
            { return _dgSelectedIndexDoc; }
            set
            {
                if (_dgSelectedIndexDoc != value)
                {
                    _dgSelectedIndexDoc = value;
                    RaisePropertyChanged("dgSelectedIndexDoc");
                }
            }
        }
        #endregion

        #region ICollection
        private ICollectionView _ThemesCollection;
        public ICollectionView ThemesCollection
        {
            get { return _ThemesCollection; }
            private set { _ThemesCollection = value; RaisePropertyChanged("ThemesCollection"); }
        }

        private ICollectionView _LanguageCollection;
        public ICollectionView LanguageCollection
        {
            get { return _LanguageCollection; }
            private set { _LanguageCollection = value; RaisePropertyChanged("LanguageCollection"); }
        }
        #endregion

        #region StringLists

        List<string> _StringListThemes;
        public List<string> StringListThemes
        {
            get { return _StringListThemes; }
            set
            {
                if (_StringListThemes != value)
                {
                    _StringListThemes = value;
                }
            }
        }

        List<string> _StringListLanguage;
        public List<string> StringListLanguage
        {
            get { return _StringListLanguage; }
            set
            {
                if (_StringListLanguage != value)
                {
                    _StringListLanguage = value;
                }
            }
        }
        #endregion       

        #region Relay Commands Declarations
        public RelayCommand<object> cmdResetLocation { get; private set; }
        public RelayCommand<object> cmdChangePassword { get; private set; }

        public RelayCommand<object> CmdAddThemes { get; private set; }
        public RelayCommand<object> CmdAddLanguage { get; private set; }
        public RelayCommand<object> CmdAddDateFormat { get; private set; }
        public RelayCommand<object> CmdAddRoundUpMethod { get; private set; }
        public RelayCommand<object> CmdAddDocCat { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowDocument { get; private set; }

        #endregion

        void ModelUpdated_Settings(object sender, EventArgs e)
        {
            if (sender.ToString() == "decimal_digits")
            {
                SampleDecimal();
            }
            if (sender.ToString() == "curr_notation" || sender.ToString() == "value_suffix")
            {
                SampleCurrency();
            }
            if (sender.ToString() == "def_culture")
            {
                SetDefaultSetting();
            }
        }
        private void SetDefaultSetting()
        {
            try
            {
                if (SettingEntity.def_culture != null)
                {
                    CultureInfo ci = new CultureInfo(SettingEntity.def_culture);

                    SettingEntity.def_culture_name = ci.DisplayName;
                    SettingEntity.date_format = ci.DateTimeFormat.ShortDatePattern.ToString();
                    SettingEntity.decimal_digits = ci.NumberFormat.NumberDecimalDigits;
                    SettingEntity.round_up_method_code = "A";
                }

            }
            catch (Exception ex) { }
        }
        private void SampleDecimal()
        {
            try
            {
                if (SettingEntity.decimal_digits == 0)
                {
                    SettingEntity.sample_decimal_value = "1234";
                }
                else if (SettingEntity.decimal_digits == 1)
                {
                    SettingEntity.sample_decimal_value = "1234.0";
                }
                else if (SettingEntity.decimal_digits == 2)
                {
                    SettingEntity.sample_decimal_value = "1234.00";
                }
                else if (SettingEntity.decimal_digits == 3)
                {
                    SettingEntity.sample_decimal_value = "1234.000";
                }
                else if (SettingEntity.decimal_digits == 4)
                {
                    SettingEntity.sample_decimal_value = "1234.0000";
                }
                else if (SettingEntity.decimal_digits == 5)
                {
                    SettingEntity.sample_decimal_value = "1234.00000";
                }
                else if (SettingEntity.decimal_digits == 6)
                {
                    SettingEntity.sample_decimal_value = "1234.000000";
                }
                else if (SettingEntity.decimal_digits == 7)
                {
                    SettingEntity.sample_decimal_value = "1234.0000000";
                }
                else if (SettingEntity.decimal_digits == 8)
                {
                    SettingEntity.sample_decimal_value = "1234.00000000";
                }
                else if (SettingEntity.decimal_digits == 9)
                {
                    SettingEntity.sample_decimal_value = "1234.000000000";
                }
                else if (SettingEntity.decimal_digits == 10)
                {
                    SettingEntity.sample_decimal_value = "1234.0000000000";
                }
                else if (SettingEntity.decimal_digits == 11)
                {
                    SettingEntity.sample_decimal_value = "1234.00000000000";
                }
                else if (SettingEntity.decimal_digits == 12)
                {
                    SettingEntity.sample_decimal_value = "1234.000000000000";
                }
            }
            catch (Exception ex) { }
        }
        private void SampleCurrency()
        {
            var nfi = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            if (SettingEntity.curr_notation == false)
            {
                nfi.CurrencySymbol = "₹";
            }
            else if (SettingEntity.curr_notation == true)
            {
                nfi.CurrencySymbol = "INR";
            }
            //if prefix currency
            if (SettingEntity.value_suffix == false)
            {
                nfi.CurrencyPositivePattern = 2;
                nfi.CurrencyNegativePattern = 2;
            }
            //if suffix currency
            else if (SettingEntity.value_suffix == true)
            {
                nfi.CurrencyPositivePattern = 3;
                nfi.CurrencyNegativePattern = 3;
            }
            SettingEntity.sample_curr = string.Format(nfi, "{0:C}", 1234.00);
        }

        #region Constructor
        public SYS_S001VM() : base()
        {
            MC = new MultipleContext_UserLevelSettings();
            MCTemp = new MultipleContext_UserLevelSettings();
            MasterEntity = new UserLevelSettings();
            SettingEntity = new SYS_C005();
            DocumentEntity = new ObservableCollection<SYS_C005>();

            SYS_C005.ModelEntityUpdated += new EventHandler(ModelUpdated_Settings);
            cmdResetLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ResetLocation(cmdPara); });
            cmdChangePassword = new RelayCommand<object>(items => { if (items == null) { return; } ChangePassword(items); });

            CmdAddThemes = new RelayCommand<object>(items => { if (items == null) { return; } InsertThemes(items); });
            CmdAddLanguage = new RelayCommand<object>(items => { if (items == null) { return; } InsertLanguage(items); });
            CmdAddDateFormat = new RelayCommand<object>(items => { if (items == null) { return; } InsertDateFormat(items); });
            CmdAddRoundUpMethod = new RelayCommand<object>(items => { if (items == null) { return; } InsertRoundMethod(items); });
            CmdAddDocCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocCat(items); });
            CmdDeleteDataGridRowDocument = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDocument(items); });

            LoadInitialData();

            
        }
        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_UserLevelSettings>(MC, Request, "UserSettings", "Administration", "LoadInitialData", 0, "");

                if (MC.MasterEntity.Count > 0)
                {
                    MasterEntity = MC.MasterEntity[0];
                }
                SettingEntity = MC.SettingEntity[0];
                DocumentEntity = MC.DocumentEntity;

                ThemesCollection = CollectionViewSource.GetDefaultView(MC.Themes);
                ThemesCollection.Filter = new Predicate<object>(FilterThemes);
                StringListThemes = MC.Themes.Select(x => x.theme_title.ToString()).ToList();

                LanguageCollection = CollectionViewSource.GetDefaultView(MC.Language);
                LanguageCollection.Filter = new Predicate<object>(FilterLanguage);
                StringListLanguage = MC.Language.Select(x => x.lang_desc.ToString()).ToList();

                #region AutoSuggest Initialisation
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_C002)x).lang_key ?? "");
                TheFilter = (o, prefix) => (((SYS_C002)o).lang_key ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLanguage = new AutoSuggestTextViewModel<dynamic>(MC.Language, TheFilter, SuggestedValue, "lang_key", true);
                ASLanguage.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_C007)x).date_format ?? "");
                TheFilter = (o, prefix) => (((SYS_C007)o).date_format ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDateFormat = new AutoSuggestTextViewModel<dynamic>(MC.DateFormats, TheFilter, SuggestedValue, "date_format", true);
                ASDateFormat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_C006)x).round_up_method_name ?? "");
                TheFilter = (o, prefix) => (((SYS_C006)o).round_up_method_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRoundUpMethod = new AutoSuggestTextViewModel<dynamic>(MC.RoundUpMethod, TheFilter, SuggestedValue, "round_up_method_name", true);
                ASRoundUpMethod.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_C006)x).round_up_method_code ?? "");
                TheFilter = (o, prefix) => (((SYS_C006)o).round_up_method_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_C006)o).round_up_method_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRoundingMethod = new AutoSuggestTextViewModel<dynamic>(MC.RoundUpMethod, TheFilter, SuggestedValue, "round_up_method_code", "round_up_method_code", true);
                ASRoundingMethod.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_C011)x).doc_cat ?? "");
                TheFilter = (o, prefix) => (((SYS_C011)o).doc_cat ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_C011)o).doc_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDocCat = new AutoSuggestTextViewModel<dynamic>(MC.DocCategory, TheFilter, SuggestedValue, "doc_cat", "doc_cat", true);
                ASDocCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_D001)x).field_name ?? "");
                TheFilter = (o, prefix) => (((SYS_D001)o).field_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASField = new AutoSuggestTextViewModel<dynamic>(MC.DocumentField, TheFilter, SuggestedValue, "field_name", "field_name", true);
                ASField.AutoSuggestVM.IsEmptyValueAllowed = true;

                LOCATION_LIST = AppSessionState.LOCATION_LIST;


                #endregion

                DefaultValues();
                isNewRecord = false;
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
            MasterEntity.UserId = AppSessionState.UserID;
            MasterEntity.client = AppSessionState.client;
            SampleDecimal();
            SampleCurrency();
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(MasterEntity.old_password) == false && string.IsNullOrEmpty(MasterEntity.new_password) == false && MasterEntity.new_password != MasterEntity.conf_password)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("New Password and Confirm Password not equal!");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void ResetLocation(object InputValue)
        {
            try
            {
                ADM_M0003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue != null)
                    {
                        POPUPEntityObject = (ADM_M0003)InputValue;
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    AppSessionState.comp_code = POPUPEntityObject.comp_code;
                    AppSessionState.location_Id = POPUPEntityObject.location_id;

                    AppSessionState.OBJ_COMPANY = AppSessionState.COMPANY_LIST.Where(item => item.comp_code == POPUPEntityObject.comp_code).ToList()[0];
                    AppSessionState.OBJ_LOCATION = AppSessionState.LOCATION_LIST.Where(item => item.location_id == POPUPEntityObject.location_id && item.comp_code == POPUPEntityObject.comp_code).ToList()[0];
                    //AppSessionState.AppsessionNotifyobject.CurrenctCompany = AppSessionState.OBJ_COMPANY.comp_name;

                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RESET"));

                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void ChangePassword(object InputValue)
        {
            try
            {
                if(MasterEntity.new_password == MasterEntity.conf_password && AppSessionState.password == MasterEntity.old_password)
                {
                    string Request = "RESET_PASSWORD" + "!@" + AppSessionState.client + "!@" + AppSessionState.UserID + "!@" + MasterEntity.new_password;
                    MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_UserLevelSettings>(MC, Request, "UserSettings", "Administration", "LoadInitialData", 0, "");

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Password reset successfully", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Password not match or old password not correct", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex) { }
        }
        private void InsertThemes(object InputValue)
        {
            string Request = "";
            SYS_C001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Themes.Where(x => x.theme_title.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_C001_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_C001_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.theme_code = POPUPEntityObject.theme_code;
                    MasterEntity.theme_title = POPUPEntityObject.theme_title;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertLanguage(object InputValue)
        {
            string Request = "";
            SYS_C002 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Language.Where(x => x.lang_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_C002>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_C002>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    SettingEntity.def_culture = POPUPEntityObject.lang_key;
                    SettingEntity.def_culture_name = POPUPEntityObject.lang_desc;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertDateFormat(object InputValue)
        {
            string Request = "";
            SYS_C007 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DateFormats.Where(x => x.date_format.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_C007>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_C007>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    SettingEntity.date_format = POPUPEntityObject.date_format;
                    SettingEntity.date_sample = POPUPEntityObject.date_sample;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertRoundMethod(object InputValue)
        {
            string Request = "";
            SYS_C006 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RoundUpMethod.Where(x => x.round_up_method_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_C006>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_C006>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    SettingEntity.round_up_method_code = POPUPEntityObject.round_up_method_code;
                    SettingEntity.round_up_method_name = POPUPEntityObject.round_up_method_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertDocCat(object InputValue)
        {
            string Request = "";
            SYS_C011 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocCategory.Where(x => x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_C011>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_C011>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    DocumentEntity[dgSelectedIndexDoc].doc_cat = POPUPEntityObject.doc_cat;
                    DocumentEntity[dgSelectedIndexDoc].doc_desc = POPUPEntityObject.doc_desc;
                    DocumentEntity[dgSelectedIndexDoc].active = true;
                    DocumentEntity[dgSelectedIndexDoc].UserId = AppSessionState.UserID;

                    var sysfields = from o in MC.DocumentField where o.doc_cat == POPUPEntityObject.doc_cat select o;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_D001)x).field_name ?? "");
                    TheFilter = (o, prefix) => (((SYS_D001)o).field_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASField = new AutoSuggestTextViewModel<dynamic>(sysfields, TheFilter, SuggestedValue, "field_name", "field_name", true);
                    ASField.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
            }
            catch (Exception ex) { }
        }
        private void DeleteDataGridRowDocument(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DocumentEntity.Count > i && DocumentEntity[dgSelectedIndexDoc].id == 0)
                {
                    DocumentEntity.RemoveAt(i);
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
        private void UpdateSecondListView()
        {
            try
            {
                SecondList = null;
                if (FirstListViewSelectedIndex == 0)
                {
                    SecondList = MC.Language.ToList();
                    if (SettingEntity.def_culture != null)
                    {
                        SecondListViewSelectedIndex = MC.Language.IndexOf(MC.Language.Where(X => X.lang_key == SettingEntity.def_culture).First());
                    }
                }
                else if (FirstListViewSelectedIndex == 1)
                {
                    SecondList = MC.DateFormats.ToList();
                    if (SettingEntity.date_format != null)
                    {
                        SecondListViewSelectedIndex = MC.DateFormats.IndexOf(MC.DateFormats.Where(X => X.date_format == SettingEntity.date_format).First());
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void UpdateMasterEntity()
        {
            try
            {
                if (FirstListViewSelectedIndex == 0)
                {
                    SettingEntity.def_culture = MC.Language[SecondListViewSelectedIndex].lang_key;
                }
                else if (FirstListViewSelectedIndex == 1)
                {
                    SettingEntity.date_format = MC.DateFormats[SecondListViewSelectedIndex].date_format;
                }
            }
            catch (Exception ex) { }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_SYS_C005 != null)
                {
                    SettingEntity = new SYS_C005();
                    MC.SettingEntity = (List<SYS_C005>)obj.XMLToObject(MasterEntity.XmlDataDocument_SYS_C005, MC.SettingEntity);
                    if (MC.SettingEntity.Count > 0)
                    {
                        SettingEntity = MC.SettingEntity[0];
                    }
                }
                else
                {
                    SettingEntity = new SYS_C005();
                }
                if (MasterEntity.XmlDataDocument_SET_M005 != null)
                {
                    //DocumentEntity.Clear(); NOTE: commented temporary because following line throwing exception.
                    MC.DocumentEntity = (ObservableCollection<SYS_C005>)obj.XMLToObject(MasterEntity.XmlDataDocument_SET_M005, MC.SettingEntity);
                    DocumentEntity = MC.DocumentEntity;
                }
                else
                {
                    DocumentEntity = new ObservableCollection<SYS_C005>();
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        #endregion

        #region Abstract Command Actions
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<UserLevelSettings> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<UserLevelSettings> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<UserLevelSettings> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<UserLevelSettings> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<UserLevelSettings> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<UserLevelSettings> result)
        {
            MasterEntity.XmlDataDocument_SYS_C005 = obj.ObjectToXML(SettingEntity);
            MasterEntity.XmlDataDocument_SET_M005 = obj.ObjectToXML(DocumentEntity);
            if (Validation() == true)
            {
                if (isNewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<UserLevelSettings>(MasterEntity, "UserSettings", "Administration");
                }
                else if (isNewRecord == false)
                {
                    MasterEntity = repository.UpdateWithReturnDomainObject<UserLevelSettings>(MasterEntity, "UserSettings", "Administration");
                }
                SetBusinessEntitiesAfterLoad("Save", "");

                var msg = new NotificationMessage("SYS_S001VM");
                Messenger.Default.Send<NotificationMessage>(msg);

                if (MasterEntity.id != 0 && isNewRecord == true)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                    showMessageService.ShowMessage();
                }
                if (MasterEntity.id != 0 && isNewRecord == false)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                    showMessageService.ShowMessage();
                }
                isNewRecord = false;
            }
        }
        protected override void OnCreateAction(InquiryActionResult<UserLevelSettings> result)
        {
            isNewRecord = true;
            MasterEntity = new UserLevelSettings();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<UserLevelSettings> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<UserLevelSettings> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<UserLevelSettings> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<UserLevelSettings> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<UserLevelSettings> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<UserLevelSettings> result)
        {
        }
        #endregion

        #region Filters

        #region Filter Themes
        private string _filterStringThemes;
        public bool FilterThemes(object obj)
        {

            var data = obj as SYS_C001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringThemes))
                {
                    return (data.theme_code != null && data.theme_code.ToString().ToLower().Contains(_filterStringThemes.ToLower()) ||
                        data.theme_title != null && data.theme_title.ToString().ToLower().Contains(_filterStringThemes.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringThemes
        {
            get { return _filterStringThemes; }
            set
            {
                _filterStringThemes = value;
                RaisePropertyChanged("FilterStringThemes");
                FilterCollectionThemes();
            }
        }
        private void FilterCollectionThemes()
        {
            if (_ThemesCollection != null)
            {
                _ThemesCollection.Refresh();
            }
        }
        #endregion

        #region Filter Language
        private string _filterStringLanguage;
        public bool FilterLanguage(object obj)
        {
            var data = obj as SYS_C002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringLanguage))
                {
                    return (data.lang_desc != null && data.lang_desc.ToString().ToLower().Contains(_filterStringLanguage.ToLower()) ||
                        data.lang_key != null && data.lang_key.ToString().ToLower().Contains(_filterStringLanguage.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringLanguage
        {
            get { return _filterStringLanguage; }
            set
            {
                _filterStringLanguage = value;
                RaisePropertyChanged("FilterStringLanguage");
                FilterCollectionLanguage();
            }
        }
        private void FilterCollectionLanguage()
        {
            if (_LanguageCollection != null)
            {
                _LanguageCollection.Refresh();
            }
        }

       
        #endregion

        #endregion

    }
}

