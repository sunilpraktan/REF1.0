using System;
using System.Windows;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.WebServices.Gateway;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using System.IO;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.SCM;
using Reflection.BusinessEntity.Settings;
using Reflection.BusinessEntity.Finance;
using System.Globalization;
using System.Threading;
using System.Windows.Markup;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity.ADM;
using Reflection.Presentation.Common;

namespace Reflection.Shell.ViewModel
{
    /// <summary>
    /// Login view view model class
    /// </summary>
    public sealed class LoginViewModel
        : WindowViewModel<ADM_M010>, INotifyPropertyChanged
    {
        WebServiceRepository<ADM_M010> repository = new WebServiceRepository<ADM_M010>();
        WebServiceRepository<MContext_Authontication> repository_M = new WebServiceRepository<MContext_Authontication>();


        MContext_Authontication _MC = new MContext_Authontication();
        public MContext_Authontication MC
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

        ObjectSerializationService objSerialization = new ObjectSerializationService();
        ADM_M010 UserDetails = new ADM_M010();
        bool _ResultValue;
        public bool ResultValue
        {
            get { return _ResultValue; }
            set
            {
                if (_ResultValue != value)
                {
                    _ResultValue = value;
                }
            }
        }

        private SYS_C005 _SettingEntity = new SYS_C005();
        public SYS_C005 SettingEntity
        {
            get { return _SettingEntity; }
            set
            {
                if (_SettingEntity != value)
                {
                    _SettingEntity = value;
                    RaisePropertyChanged("SettingEntity");
                }
            }
        }


        public event EventHandler<EventArgs> RequestClose;
        public event EventHandler<EventArgs> RequestLogin;
        public RelayCommand CloseLoginCommand { get; private set; }
        public RelayCommand LoginCommand { get; private set; }

        #region · Data Properties ·

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    RaisePropertyChanged("UserId");


                }
            }
        }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    RaisePropertyChanged("Password");

                }
            }
        }
        /// <summary>
        /// Gets or sets the Client
        /// </summary>
        private string _Location;
        public string Location
        {
            get { return _Location; }
            set
            {
                if (_Location != value)
                {
                    this._Location = value;
                    RaisePropertyChanged("Location");

                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class
        /// </summary>
        public LoginViewModel()
            : base()
        {

            MC = new MContext_Authontication();
            CloseLoginCommand = new RelayCommand(() =>
            {
                var handler = RequestClose;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            });
            LoginCommand = new RelayCommand(() =>
            {
                LoginAction();
                var handler = RequestLogin;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            });

        }
        public class COM_T002_G
        {
            public int id { get; set; }
            public string host { get; set; }
            public Nullable<int> port { get; set; }
            public Nullable<bool> enableSSL { get; set; }
            public Nullable<int> timeOut { get; set; }
            public string deliveryMethod { get; set; }
            public Nullable<bool> defaultCredentials { get; set; }
            public string mailID { get; set; }
            public string displayName { get; set; }
            public string password { get; set; }
            public string domain { get; set; }
        }
        public class MContext_Authontication
        {
            public List<ADM_S0001> MODULE_LIST { get; set; }
            public List<ADM_M0002> COMPANY_LIST { get; set; }
            public List<ADM_M0003> LOCATION_LIST { get; set; }
            public List<SYS_AUTH> USER_AUTHORISATIONS { get; set; }
            public List<SYS_AUTH> Authorisations { get; set; }
            public List<SYS_AUTH> Permissions { get; set; }// Create, Modify, View.....etc
            public List<ADM_M010> UserData { get; set; }//UserMaster
            public List<COM_T002_G> AccountData { get; set; }
            public string comp_code { get; set; }
            public string location_Id { get; set; }
            public string so_code { get; set; }
            public string sg_code { get; set; }
            public string po_code { get; set; }
            public string pg_code { get; set; }
            public string EmpId { get; set; }
            public string EmpEmailId { get; set; }
            public string EmpName { get; set; }
            public string store_code { get; set; }
            public List<ADM_M002> ADM_M002_List { get; set; }
            public List<ADM_M003> ADM_M003_List { get; set; }
            public List<MM_M001> StorageLocation { get; set; }

            public List<ADM_M001_H_P> SalesGroup { get; set; }
            public List<ADM_M001_A_P> SalesOrganisation { get; set; }
            public List<ADM_M001_P_P> PurchaseGroup { get; set; }
            public List<ADM_M001_M_P> PurchasOrganisation { get; set; }
            public List<UserLevelSettings> UserLevelSetting { get; set; }
            public List<SYS_M018> Popup_alerts { get; set; }
            public List<ADM_M037> CurrencyList { get; set; }

            //G/L Account Determination preload data start
            public List<ACC_M003_D> ACC_M003_D_List { get; set; }
            public List<ACC_M003_E> ACC_M003_E_List { get; set; }
            public List<ACC_M003_F> ACC_M003_F_List { get; set; }
            public List<ACC_M003_G> ACC_M003_G_List { get; set; }
            public List<ACC_M003_X_Variant> Account_Variant_Mov_Type { get; set; }
            public List<ACC_M003_Y_Acc_Determination> GL_Acc_Determination_Material { get; set; }
            public List<ACC_M003_N> ACC_M003_N_List { get; set; }
            public List<ACC_M003_S2> ACC_M003_S2_List { get; set; }
            public List<ACC_M003_Y_Acc_Determination> GL_Acc_Determination_Application { get; set; }
            public List<ADM_M002_A> ACC_M003_Q_List { get; set; }
            //G/L Account Determination preload data End
            public List<SYS_C005> Setting { get; set; }
        }
        #endregion
        public void LoginAction()
        {
            try
            {
                UserCredentials uc = new UserCredentials();
                uc.SetUserCredentials();

                UserDetails.UserId = UserId;
                UserDetails.Password = Password;
                UserDetails.EmpNm = Location;

                //NOTE: Temporory field, make request variable as we use in GET SP.
                string Request = "USER_AUTH" + "!@" + Location + "!@!@!@" + UserId + "!@" + Password + "!@!@" + AppSessionState.UserSource1 + "!@" + AppSessionState.UserSource2;
                UserDetails.user_source1 = Request;

                string request = objSerialization.ObjectToXML(UserDetails);
                MC = repository_M.GetDataWithReturnDomainObject<MContext_Authontication>(MC, request, "UserVerification", "Administration", "", 0, "");

                UserDetails = MC.UserData[0];
                AppSessionState.UserID = UserDetails.UserId;
                AppSessionState.session_id = UserDetails.session_id;
                AppSessionState.password = UserDetails.Password;
                AppSessionState.user_type = UserDetails.user_type;
                AppSessionState.user_level = UserDetails.user_level;
                AppSessionState.user_type_name = UserDetails.user_type_name;
                AppSessionState.client = Location;
                AppSessionState.IsUserLogin = true;
                AppSessionState.Name = (UserDetails.Title ?? UserDetails.EmpNm); // Depricated: replace emp_name with user name

                if (MC.USER_AUTHORISATIONS != null)
                {
                    if (MC.USER_AUTHORISATIONS.Count > 0)
                    {
                        AppSessionState.ADM_AUTH_LIST = MC.USER_AUTHORISATIONS;
                    }
                    else
                    {
                        AppSessionState.ADM_AUTH_LIST = MC.Authorisations;
                    }
                }
                else
                {
                    AppSessionState.ADM_AUTH_LIST = MC.Authorisations;
                }

                // Create Section for Org structure and set if data available and required. It also set only if employee record exists.
                AppSessionState.COMPANY_LIST = MC.COMPANY_LIST;
                AppSessionState.LOCATION_LIST = MC.LOCATION_LIST;
                AppSessionState.MODULE_LIST = MC.MODULE_LIST;
                

                // NOTE: Depricated assignments below
                AppSessionState.Name = UserDetails.EmpNm; // Depricated: replace emp_name with user name
                AppSessionState.dept_code = UserDetails.dept_code;
                AppSessionState.comp_code = MC.comp_code;
                AppSessionState.location_Id = MC.location_Id;

                // NOTE: Allow this info only if Employee record available otherwise all required things can manage by authorisations and user default values.
                // NOTE: for default values, if single record then automatically assign default values,no need to set default values manually and no need to check count == 1 and set, so logic will be the one only.
                if (MC.COMPANY_LIST != null)
                {
                    if (MC.COMPANY_LIST.Count == 1)
                    {
                        AppSessionState.OBJ_COMPANY = MC.COMPANY_LIST[0];
                        AppSessionState.CntryCurncy = AppSessionState.OBJ_COMPANY.curr_code;
                        AppSessionState.curr_code = AppSessionState.OBJ_COMPANY.curr_code;
                        AppSessionState.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        AppSessionState.CompanyName = AppSessionState.OBJ_COMPANY.comp_name;
                        AppSessionState.LogoUrl = AppSessionState.OBJ_COMPANY.logo_url;
                    }
                    else if(MC.COMPANY_LIST.Count > 0 && AppSessionState.comp_code != null)
                    {
                        AppSessionState.OBJ_COMPANY = MC.COMPANY_LIST.Where(item => item.comp_code == AppSessionState.comp_code).ToList()[0];
                        AppSessionState.CntryCurncy = AppSessionState.OBJ_COMPANY.curr_code;
                        AppSessionState.curr_code = AppSessionState.OBJ_COMPANY.curr_code;
                        AppSessionState.CompanyName = AppSessionState.OBJ_COMPANY.comp_name;
                        AppSessionState.LogoUrl = AppSessionState.OBJ_COMPANY.logo_url;
                    }
                }
                if (MC.LOCATION_LIST != null)
                {
                    if (MC.LOCATION_LIST.Count == 1)
                    {
                        AppSessionState.OBJ_LOCATION = MC.LOCATION_LIST[0];
                    }
                    else if (MC.LOCATION_LIST.Count > 0 && AppSessionState.location_Id != null)
                    {
                        AppSessionState.OBJ_LOCATION = MC.LOCATION_LIST.Where(item => item.location_id == AppSessionState.location_Id && item.comp_code == AppSessionState.comp_code).ToList()[0];
                    }
                }

                // Note required for UI open
                if (MC.StorageLocation != null && AppSessionState.OBJ_COMPANY != null && AppSessionState.OBJ_LOCATION != null)
                {
                    if (MC.StorageLocation.Count > 0 && AppSessionState.OBJ_COMPANY.comp_code != null && AppSessionState.OBJ_LOCATION.location_id != null)
                    {
                        AppSessionState.store_location = MC.StorageLocation;
                        AppSessionState.OBJ_STORE = MC.StorageLocation.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code && item.location_Id == AppSessionState.OBJ_LOCATION.location_id && item.default_storage_loc == Convert.ToBoolean(1)).ToList()[0];
                    }
                }

                AppSessionState.ADM_M002_List = MC.ADM_M002_List; // Depricated. remove all reference and delete
                AppSessionState.ADM_M003_List = MC.ADM_M003_List;

                AppSessionState.so_code = MC.so_code;
                AppSessionState.sg_code = MC.sg_code;
                AppSessionState.po_code = MC.po_code;
                AppSessionState.pg_code = MC.pg_code;
                AppSessionState.EmpName = MC.EmpName;
                AppSessionState.EmpId = MC.EmpId;
                AppSessionState.EmpEmailId = MC.EmpEmailId;
                AppSessionState.ADM_M001_H_List = MC.SalesGroup;
                AppSessionState.ADM_M001_A_List = MC.SalesOrganisation;
                AppSessionState.ADM_M001_P_List = MC.PurchaseGroup;
                AppSessionState.ADM_M001_M_List = MC.PurchasOrganisation;
                AppSessionState.CurrencyList = MC.CurrencyList;
                AppSessionState.TS_AUTH_OBJ = MC.Permissions;

                if (MC.UserLevelSetting != null) // Required for UI open
                {
                    if (MC.UserLevelSetting.Count > 0)
                    {
                        AppSessionState.UserLanguage = MC.UserLevelSetting[0].lang_key;
                        AppSessionState.UserTheme = MC.UserLevelSetting[0].theme_name;
                        SaveDesktopSetting(MC.UserLevelSetting[0].desktop_file);
                    }
                }
                //Load All Settings
                if (MC.Setting != null) // Required for UI open
                {
                    if (MC.Setting.Count > 0)
                    {
                        SettingEntity = MC.Setting[0];
                        Settings.def_culture = SettingEntity.def_culture;
                        Settings.date_format = SettingEntity.date_format;
                        Settings.date_separator = SettingEntity.date_separator;
                        Settings.decimal_digits = SettingEntity.decimal_digits;
                        Settings.round_up_method_code = SettingEntity.round_up_method_code;
                        Settings.round_up = SettingEntity.round_up;
                        Settings.curr_notation = SettingEntity.curr_notation;
                        Settings.value_suffix = SettingEntity.value_suffix;
                    }
                }


                if (MC.AccountData != null) // Note required for UI open
                {
                    if (MC.AccountData.Count > 0)
                    {
                        MailAccount mail_account = new MailAccount();
                        mail_account.Host = MC.AccountData[0].host;
                        mail_account.Port = Convert.ToInt32(MC.AccountData[0].port);
                        mail_account.EnableSSL = Convert.ToBoolean(MC.AccountData[0].enableSSL);
                        mail_account.TimeOut = Convert.ToInt32(MC.AccountData[0].timeOut);
                        mail_account.DefaultCredentials = Convert.ToBoolean(MC.AccountData[0].defaultCredentials);
                        mail_account.MailID = MC.AccountData[0].mailID;
                        mail_account.DisplayName = MC.AccountData[0].displayName;
                        mail_account.Password = MC.AccountData[0].password;
                        mail_account.Domain = MC.AccountData[0].domain;
                        AppSessionState.MailAccount = mail_account;
                    }
                }
                LoadLanguageResources(); // Note required for UI open
                AppSessionState.WebReportDirectory = repository_M.GetEndpointAddress();
                AppSessionState.RootDirectory = repository_M.GetRootDirectory();
                if (MC.Popup_alerts != null) // Note required for UI open
                {
                    if (MC.Popup_alerts.Count > 0)
                    {
                        DisplayReport(MC.Popup_alerts);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Error!";
                //showMessageService.Text = String.Format(ex.Message);
                //showMessageService.ShowMessage();
            }

        }
        private void LoadLanguageResources()
        {
            try
            {
                CultureInfo ci = new CultureInfo(SettingEntity.def_culture);
                ci.DateTimeFormat.ShortDatePattern = SettingEntity.date_format;
                //ci.DateTimeFormat.DateSeparator = SettingEntity.date_separator;

                // Assign the all setting to the Settings1 file...
                Reflection.Presentation.Resources.Properties.Settings1.Default.Language = Settings.def_culture;
                Reflection.Presentation.Resources.Properties.Settings1.Default.DateFormat = Settings.date_format;
                Reflection.Presentation.Resources.Properties.Settings1.Default.Save();

                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                ci.NumberFormat.NumberDecimalDigits = SettingEntity.decimal_digits;

                FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            }
            catch (Exception Ex) { }
        }
        public void DisplayReport(List<SYS_M018> PopupCollection)
        {
            try
            {
                CursorControl.SetBusyState();
                string RequestParameter = "";
                ReportManager ReportManager = new ReportManager();
                if (PopupCollection[0].popup_alert_name == "Non Visited Client List")
                {
                    //Sales Activity
                    WebServiceRepository<MultipleContextMISReports> repository_MC = new WebServiceRepository<MultipleContextMISReports>();
                    MultipleContextMISReports MC_Sales = new MultipleContextMISReports();
                    RequestParameter = "Report" + "!@" + "R012" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + Convert.ToDateTime(DateTime.Now.AddDays(-PopupCollection[0].PeriodDays)).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "!@" + "" + "!@" + "" + "!@" + AppSessionState.EmpId + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.UserID + "!@" + "" + "!@" + "0";
                    MC_Sales = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports>(MC_Sales, RequestParameter, "MIS_CRMSalesReports", "CRM", "", 0, "MIS_CRM_Sales2");


                    object[] objDataSource = new object[1];
                    string[] objDataSourceName = new string[1];

                    objDataSource[0] = MC_Sales.RptMIS_CRMSales_List2;
                    objDataSourceName[0] = "dsMIS_CRM_Sales2";


                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + PopupCollection[0].popup_alert_file, getParametersList(), "");

                }
                else if (PopupCollection[0].popup_alert_name == "Reorder Level Report")
                {
                    //Reorder Level
                    MultipleContext_MIS_SCM_Store MCTemp = new MultipleContext_MIS_SCM_Store();
                    WebServiceRepository<MultipleContext_MIS_SCM_Store> repository_MC = new WebServiceRepository<MultipleContext_MIS_SCM_Store>();

                    RequestParameter = "Report" + "!@" + "R002" + "!@" + "" + "!@" + "" + "!@" + Convert.ToDateTime(DateTime.Now.AddDays(-PopupCollection[0].PeriodDays)).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + "";

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Store>(MCTemp, RequestParameter, "MIS_SCM_Store", "SCM", "", 0, "");
                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.StoreList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == AppSessionState.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == AppSessionState.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsMIS_SCM_StoreRpt";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\SCM\\" + PopupCollection[0].popup_alert_file, getParametersList(), "");
                }
                else if (PopupCollection[0].popup_alert_name == "Activity Reminder")
                {


                    STD_LIST_BE MIS_OBJ = new STD_LIST_BE();
                    WebServiceRepository<STD_MIS_MC_BE> repository_MC = new WebServiceRepository<STD_MIS_MC_BE>();
                    STD_MIS_MC_BE MC_TEMP = new STD_MIS_MC_BE();
                    STD_REQ_PARA_BE REQ_PARA_OBJ = new STD_REQ_PARA_BE();
                    MIS_OBJ.obj_code = "1";
                    MIS_OBJ.obj_name = "Sales Activity Report";
                    MIS_OBJ.obj_path = "\\REPORTS_STD\\MIS\\";
                    MIS_OBJ.obj_file = "SDM_M031.rdlc";
                    MIS_OBJ.ts_code = "SR02";
                    MIS_OBJ.view_code = "R0031";
                    MIS_OBJ.sql_code = "R0031";
                    MIS_OBJ.obj_code = "";
                    MIS_OBJ.obj_code = "";
                    MIS_OBJ.obj_code = "";

                    RequestParameter = "REPORT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@!@!@!@!@" + MIS_OBJ.sql_code + "!@!@!@!@!@" + AppSessionState.EmpId + "!@!@!@!@!@!@!@!@!@!@!@!@!@!@02!@!@!@!@!@ASC!@!@!@";
                    MC_TEMP = repository_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, RequestParameter, "SDM_R02", "SDM", " ", 0, "");

                    REQ_PARA_OBJ.obj_code = MIS_OBJ.obj_code;
                    REQ_PARA_OBJ.obj_name = MIS_OBJ.obj_name;
                    REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    REQ_PARA_OBJ.comp_name = AppSessionState.COMPANY_LIST.Where(x => x.comp_code == REQ_PARA_OBJ.comp_code).ToList()[0].comp_name;
                    object[] objDataSource = new object[1];
                    string[] objDataSourceName = new string[1];

                    if (MC_TEMP.STD_MIS_LIST != null)
                    {
                        if (MC_TEMP.STD_MIS_LIST.Count > 0)
                        {
                            objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                            objDataSourceName[0] = "dsMIS_1";

                            ReportManager.DisplayReport(objDataSource, objDataSourceName, MIS_OBJ.obj_path + MIS_OBJ.obj_file, getParametersListActivity(), MIS_OBJ.obj_name);

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
        private Dictionary<string, string> getParametersListActivity()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("from_date", Convert.ToString(DateTime.Now));
                result.Add("to_date", Convert.ToString(DateTime.Now));
                result.Add("rpt_title", Convert.ToString("Pending Activity Reminder"));
                result.Add("comp_code", Convert.ToString(AppSessionState.OBJ_COMPANY.comp_code));
                result.Add("comp_name", Convert.ToString(AppSessionState.OBJ_COMPANY.comp_name));
                result.Add("para1", Convert.ToString(""));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();

            }
            return result;
        }
        private Dictionary<string, string> getParametersList()
        {

            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {

                result.Add("EmpName", AppSessionState.EmpName);
                result.Add("ReportNm", MC.Popup_alerts[0].popup_alert_name);
                //result.Add("FromDate", Convert.ToDateTime(DateTime.Now.AddDays(-MC.Popup_alerts[0].PeriodDays)).ToString("MM/dd/yyyy"));
                //result.Add("ToDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy"));


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
        private void SaveDesktopSetting(byte[] DesktopFile)
        {
            var tempFilePath = System.Environment.CurrentDirectory + "/VirtualDesktop01.xaml";
            if (DesktopFile != null)
            {
                MemoryStream stream = new MemoryStream(DesktopFile);
                var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.ReadWrite);
                stream.CopyTo(fileStream);
                fileStream.Dispose();
            }

        }
        #region · Overriden Methods ·

        public override bool CanClose()
        {
            return (this.ViewMode != ViewModeType.Busy);
        }

        public override void Close()
        {
            this.GetService<IVirtualDesktopManager>().CloseDialog();
            Application.Current.Shutdown();
        }

        protected override void InitializePropertyStates()
        {
            this.PropertyStates.Add(e => e.UserId);
            this.PropertyStates.Add(e => e.Password);
        }

        protected override void OnViewModeChanged()
        {
            base.OnViewModeChanged();

            if (this.PropertyStates.Count > 0)
            {
                this.PropertyStates[x => x.UserId].IsEditable = (this.ViewMode != ViewModeType.Busy);
                this.PropertyStates[x => x.Password].IsEditable = (this.ViewMode != ViewModeType.Busy);
            }
        }

        #endregion

        #region · Command Actions ·

        protected override bool CanInquiryData()
        {
            return (!String.IsNullOrEmpty(this.UserId) &&
                    !String.IsNullOrEmpty(this.Password) &&
                    this.ViewMode != ViewModeType.Busy);
        }


        protected override void OnSaveAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;

        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M010> result)
        {
            result.Data = this.Entity;
            result.Result = InquiryActionResultType.DataFetched;
        }
        protected override void OnInquiryActionComplete(InquiryActionResult<ADM_M010> result)
        {
            //if (result.Result == InquiryActionResultType.DataFetched)
            //{
            //    Channel<AuthenticationInfo>.Public.OnNext(
            //        new AuthenticationInfo
            //        {
            //            Action = AuthenticationAction.LoggedIn,
            //            UserId = this.UserId
            //        }, true);

            //    ServiceLocator.GetService<IVirtualDesktopManager>().CloseDialog();
            //}
            //else if (result.Result == InquiryActionResultType.DataNotFound)
            //{
            //    this.NotificationMessage = "Username and password do not match.";

            //    this.ViewMode = ViewModeType.Default;
            //}
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }
        //protected override void OnExportAction(InquiryActionResult<ADM_M010> result)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}


        #endregion
    }
}
