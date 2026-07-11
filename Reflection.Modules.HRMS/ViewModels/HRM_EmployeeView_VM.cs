using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.HRMS;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;

using GalaSoft.MvvmLight.Messaging;
using System.Collections.Specialized;
using Microsoft.Win32;
using System.IO;
using GalaSoft.MvvmLight.Messaging;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using System.Windows.Media.Imaging;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.HRMS.ViewModels
{
    public class HRM_EmployeeView_VM : WorkspaceViewModel<ADM_M024>
    {

        bool isNewRecord = true;
        WebServiceRepository<ADM_M024> repository = new WebServiceRepository<ADM_M024>();
        WebServiceRepository<MultipleContext_HRM_M001> repository_MC = new WebServiceRepository<MultipleContext_HRM_M001>();
        WebServiceRepository<MultipleContext_HRM_M001> repository_MCTemp = new WebServiceRepository<MultipleContext_HRM_M001>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(HRM_M001_VM));
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
                    if (SourceName == "language_key")
                    { ASDefault = ASLanguage; }
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

        private AutoSuggestTextViewModel<dynamic> _ASSalutation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalutation
        {
            get { return _ASSalutation; }
            set
            {
                if (_ASSalutation != value)
                {
                    _ASSalutation = value; RaisePropertyChanged("ASSalutation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCountry { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCountry
        {
            get { return _ASCountry; }
            set
            {
                if (_ASCountry != value)
                {
                    _ASCountry = value; RaisePropertyChanged("ASCountry");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASReligion { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReligion
        {
            get { return _ASReligion; }
            set
            {
                if (_ASReligion != value)
                {
                    _ASReligion = value; RaisePropertyChanged("ASReligion");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCast { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCast
        {
            get { return _ASCast; }
            set
            {
                if (_ASCast != value)
                {
                    _ASCast = value; RaisePropertyChanged("ASCast");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCategory
        {
            get { return _ASCategory; }
            set
            {
                if (_ASCategory != value)
                {
                    _ASCategory = value; RaisePropertyChanged("ASCategory");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASNation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASNation
        {
            get { return _ASNation; }
            set
            {
                if (_ASNation != value)
                {
                    _ASNation = value; RaisePropertyChanged("ASNation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASNation1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASNation1
        {
            get { return _ASNation1; }
            set
            {
                if (_ASNation1 != value)
                {
                    _ASNation1 = value; RaisePropertyChanged("ASNation1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPhyDis { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPhyDis
        {
            get { return _ASPhyDis; }
            set
            {
                if (_ASPhyDis != value)
                {
                    _ASPhyDis = value; RaisePropertyChanged("ASPhyDis");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASHeightUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASHeightUnit
        {
            get { return _ASHeightUnit; }
            set
            {
                if (_ASHeightUnit != value)
                {
                    _ASHeightUnit = value; RaisePropertyChanged("ASHeightUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWeightUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWeightUnit
        {
            get { return _ASWeightUnit; }
            set
            {
                if (_ASWeightUnit != value)
                {
                    _ASWeightUnit = value; RaisePropertyChanged("ASWeightUnit");
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



        #endregion


        #region Variable Declaration
        private ADM_M024 _MasterEntity;
        public ADM_M024 MasterEntity
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

        private List<ADM_M024_P> _EmpCollection;
        public List<ADM_M024_P> EmpCollection
        {
            get { return _EmpCollection; }
            set
            {
                if (_EmpCollection != value)
                {
                    _EmpCollection = value;
                    RaisePropertyChanged("EmpCollection");
                }
            }
        }
        private ObservableCollection<HRM_M001_D> _LaguageKnown;
        public ObservableCollection<HRM_M001_D> LaguageKnown
        {
            get { return _LaguageKnown; }
            set
            {
                if (_LaguageKnown != value)
                {
                    _LaguageKnown = value;
                    RaisePropertyChanged("LaguageKnown");
                }
            }
        }

        private int _dgSelectedIndexlanguage;
        public int dgSelectedIndexlanguage
        {
            get
            { return _dgSelectedIndexlanguage; }
            set
            {
                if (_dgSelectedIndexlanguage != value)
                {
                    _dgSelectedIndexlanguage = value;
                    RaisePropertyChanged("dgSelectedIndexlanguage");
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

        private MultipleContext_HRM_M001 _MC;
        public MultipleContext_HRM_M001 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_HRM_M001 _MCTemp;
        public MultipleContext_HRM_M001 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }
        


        #endregion

        #region Relay Commands
        public RelayCommand<object> CmdSalutation { get; private set; }
        public RelayCommand<object> CmdCountry { get; private set; }
        public RelayCommand<object> CmdReligion { get; private set; }
        public RelayCommand<object> CmdCast { get; private set; }
        public RelayCommand<object> CmdCategory { get; private set; }
        public RelayCommand<object> CmdNationality { get; private set; }
        public RelayCommand<object> CmdNationality1 { get; private set; }
        public RelayCommand<object> CmdPhyDis { get; private set; }
        public RelayCommand<object> CmdHeight { get; private set; }
        public RelayCommand<object> CmdWeight { get; private set; }
        public RelayCommand<object> CmdStatus { get; private set; }

        public RelayCommand<object> CmdLanguage { get; private set; }

        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand cmdOpenSignature { get; private set; }
        public RelayCommand<object> CmdSave { get; private set; }
        public RelayCommand<object> CmdClear { get; private set; }



        #endregion

        #region Constructor
        public HRM_EmployeeView_VM() : base()
        {
            MasterEntity = new ADM_M024();
            LaguageKnown = new ObservableCollection<HRM_M001_D>();

            MC = new MultipleContext_HRM_M001();
            MCTemp = new MultipleContext_HRM_M001();

            CmdSalutation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalutation(items); });
            CmdCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items); });
            CmdReligion = new RelayCommand<object>(items => { if (items == null) { return; } InsertReligion(items); });
            CmdCast = new RelayCommand<object>(items => { if (items == null) { return; } InsertCast(items); });
            CmdCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });

            CmdNationality = new RelayCommand<object>(items => { if (items == null) { return; } InsertNationality(items); });
            CmdNationality1 = new RelayCommand<object>(items => { if (items == null) { return; } InsertNationality1(items); });
            CmdPhyDis = new RelayCommand<object>(items => { if (items == null) { return; } InsertPhyDisability(items); });
            CmdHeight = new RelayCommand<object>(items => { if (items == null) { return; } InsertHeightUnit(items); });
            CmdWeight = new RelayCommand<object>(items => { if (items == null) { return; } InsertWeightUnit(items); });
            CmdStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });

            CmdLanguage = new RelayCommand<object>(items => { if (items == null) { return; } InsertLanguage(items, false, false, true); });


            cmdOpenSignature = new RelayCommand(OpenSignature);
            OpenCommand = new RelayCommand(OpenFile);
            CmdSave = new RelayCommand<object>(items => { if (items == null) { return; } Click_SaveButton(items); });
            CmdClear = new RelayCommand<object>(items => { if (items == null) { return; } Click_ClearData(items); });
            


            LoadInitialData();
            if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == "")
            {
                LoadWindowWithEmployeeId(AppSessionState.TransValue, "EmployeeId");
                AppSessionState.TransValue = null;
                AppSessionState.TransParameter = null;
                AppSessionState.ViewOtherRecordAllowed = true;
            }
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);


        }

        #endregion

        #region User Defined Methods

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_HRM_M001>(MC, Request, "Employee_View", "HRMS", "LoadInitialData", 0, "");

                EmpCollection = MC.BackFlipEntity.ToList();

                #region AutoSuggest Initalization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M022_P)x).language_desc ?? "");
                TheFilter = (o, prefix) => (((HRM_M022_P)o).language_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M022_P)o).language_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.LanguageList, TheFilter, SuggestedValue, "language_key", "language_key", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M050_P)x).sal_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M050_P)o).sal_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M050_P)o).sal_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSalutation = new AutoSuggestTextViewModel<dynamic>(MC.SalList, TheFilter, SuggestedValue, "sal_code", true);
                ASSalutation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).CntryName ?? "");
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCountry = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "country_code", true);
                ASCountry.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M010_P)x).reli_name ?? "");
                TheFilter = (o, prefix) => (((HRM_M010_P)o).reli_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M010_P)o).reli_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASReligion = new AutoSuggestTextViewModel<dynamic>(MC.ReligionList, TheFilter, SuggestedValue, "reli_code", true);
                ASReligion.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M012_P)x).cast_name ?? "");
                TheFilter = (o, prefix) => (((HRM_M012_P)o).cast_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M012_P)o).cast_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCast = new AutoSuggestTextViewModel<dynamic>(MC.CastList, TheFilter, SuggestedValue, "cast_code", true);
                ASCast.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M011_P)x).cat_name?? "");
                TheFilter = (o, prefix) => (((HRM_M011_P)o).cat_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M011_P)o).cat_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCategory = new AutoSuggestTextViewModel<dynamic>(MC.CatList, TheFilter, SuggestedValue, "cat_code", true);
                ASCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M051_P)x).nation_desc ?? "");
                TheFilter = (o, prefix) => (((ADM_M051_P)o).nation_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M051_P)o).nation_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASNation = new AutoSuggestTextViewModel<dynamic>(MC.NationalityList, TheFilter, SuggestedValue, "nation_code", true);
                ASNation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M051_P)x).nation_desc ?? "");
                TheFilter = (o, prefix) => (((ADM_M051_P)o).nation_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M051_P)o).nation_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASNation1 = new AutoSuggestTextViewModel<dynamic>(MC.NationalityList, TheFilter, SuggestedValue, "nation_code1", true);
                ASNation1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M021_P)x).phy_dis_nm ?? "");
                TheFilter = (o, prefix) => (((HRM_M021_P)o).phy_dis ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M021_P)o).phy_dis_nm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPhyDis = new AutoSuggestTextViewModel<dynamic>(MC.PhyDisList, TheFilter, SuggestedValue, "phy_dis", true);
                ASPhyDis.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_abbrv ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_B_P)o).unit_abbrv ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASHeightUnit = new AutoSuggestTextViewModel<dynamic>(MC.HeightList, TheFilter, SuggestedValue, "unit_code", true);
                ASHeightUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_abbrv ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_B_P)o).unit_abbrv ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWeightUnit = new AutoSuggestTextViewModel<dynamic>(MC.WeightList, TheFilter, SuggestedValue, "unit_code", true);
                ASWeightUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M0013)o).t_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_name", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;
                DefaultValues();



                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M022_P)x).language_desc ?? "");
                TheFilter = (o, prefix) => (((HRM_M022_P)o).language_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M022_P)o).language_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLanguage = new AutoSuggestTextViewModel<dynamic>(MC.LanguageList, TheFilter, SuggestedValue, "language_key","language_key", true);
                ASLanguage.AutoSuggestVM.IsEmptyValueAllowed = true;
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


        private void InsertSalutation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M050_P POPUPEntityObject = null;
                
                
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.SalList.Where(x => x.sal_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M050_P>().ToList()[0];
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
        private void InsertCountry(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M012_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.CountryList.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.emp_cob = POPUPEntityObject.country_code;
                    //MasterEntity.sal_desc = POPUPEntityObject.sal_desc;
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
        private void InsertReligion(object InputValue)
        {
            try
            {
                string Request = "";
                HRM_M010_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.ReligionList.Where(x => x.reli_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M010_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.reli_code = POPUPEntityObject.reli_code;
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
        private void InsertCast(object InputValue)
        {
            try
            {
                string Request = "";
                HRM_M012_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.CastList.Where(x => x.cast_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M012_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.cast_code= POPUPEntityObject.cast_code;
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
        private void InsertCategory(object InputValue)
        {
            try
            {
                string Request = "";
                HRM_M011_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.CatList.Where(x => x.cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M011_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.cat_code = POPUPEntityObject.cat_code;
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
        private void InsertNationality(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M051_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.NationalityList.Where(x => x.nation_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M051_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.nation_code = POPUPEntityObject.nation_code;
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
        private void InsertNationality1(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M051_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.NationalityList.Where(x => x.nation_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M051_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.nation_code1 = POPUPEntityObject.nation_code;
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
        private void InsertPhyDisability(object InputValue)
        {
            try
            {
                string Request = "";
                HRM_M021_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.PhyDisList.Where(x => x.phy_dis.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M021_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.phy_dis = POPUPEntityObject.phy_dis;
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
        private void InsertHeightUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.HeightList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.height_unit = POPUPEntityObject.unit_code;
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
        private void InsertWeightUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.WeightList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.weight_unit = POPUPEntityObject.unit_code;
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




        private void InsertLanguage(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            HRM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.LanguageList.Where(x => x.language_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<HRM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M022_P>().ToList()[0];
                }
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexlanguage >= 0 && LaguageKnown.Count > dgSelectedIndexlanguage) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        LaguageKnown[dgSelectedIndexlanguage].language_key = POPUPEntityObject.language_key;
                        LaguageKnown[dgSelectedIndexlanguage].language_desc = POPUPEntityObject.language_desc;

                        MasterEntity.active = true;
                    }
                    else if (LaguageKnown[dgSelectedIndexlanguage].language_key != POPUPEntityObject.language_key)
                    {
                        LaguageKnown[dgSelectedIndexlanguage].language_key = POPUPEntityObject.language_key;
                        LaguageKnown[dgSelectedIndexlanguage].language_desc = POPUPEntityObject.language_desc;
                        MasterEntity.active = true;
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


        private void Click_ClearData(object InputValue)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new ADM_M024();

                LaguageKnown = new ObservableCollection<HRM_M001_D>();
                

                DefaultValues();
                var msg = new NotificationMessage("HRM_EmployeeView_VM");
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



        #region Open Image

        string imageName;
        private void OpenFile()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png";
                fldlg.ShowDialog();
                {
                    imageName = fldlg.FileName;
                    MasterEntity.Photo = File.ReadAllBytes(imageName);
                }

                fldlg = null;
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

        private void OpenSignature()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png";
                fldlg.ShowDialog();
                {
                    imageName = fldlg.FileName;
                    MasterEntity.digi_sign = File.ReadAllBytes(imageName);
                }
                fldlg = null;
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
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        #endregion



        private void Click_SaveButton(object InputValue)
        {

            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();

                    ObjectSerializationService obj = new ObjectSerializationService();
                    MasterEntity.XmlDataDocument_HRM_M001_D = obj.ObjectToXML(LaguageKnown);
                    if(MasterEntity.ind_phy_dis==false)
                    {
                        MasterEntity.phy_dis = null;
                    }


                    if (isNewRecord == true)
                    {

                        MasterEntity = repository.SaveWithReturnDomainObject<List<ADM_M024>>(MasterEntity, "Employee_View", "HRMS");
             
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<List<ADM_M024>>(MasterEntity, "Employee_View", "HRMS");

                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.EmpId != null && isNewRecord == true && MasterEntity.EmpId != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.EmpId != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;

                    //var msg = new NotificationMessage("HRM_EmployeeView_VM");
                    //Messenger.Default.Send<NotificationMessage>(msg);

                    //var msg2 = new NotificationMessage(MC.BackFlipEntity, "Load Employee BackFlip Record");
                    //Messenger.Default.Send<NotificationMessage>(msg2);



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
                if (MasterEntity.XmlDataDocument_HRM_M001_D != null)
                {
                    LaguageKnown.Clear();
                    LaguageKnown = (ObservableCollection<HRM_M001_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_HRM_M001_D, MC.LaguageKnown);
                    MasterEntity = MasterEntity;
                }
                else
                {
                    LaguageKnown = new ObservableCollection<HRM_M001_D>();
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


        private void LoadWindowWithEmployeeId(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                ADM_M024_P ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                    {
                        Request = "LoadWindowWithEmployeeId" + "!@" + ParameterObject;

                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_HRM_M001>(MCTemp, Request, "Employee_View", "HRMS", "LoadWindowWithEmployeeId", 0, "Employee_View");

                MasterEntity = MCTemp.Employees[0];
                if (MCTemp.LaguageKnown != null)
                {
                    LaguageKnown = MCTemp.LaguageKnown;
                }
                else
                {
                    MCTemp.LaguageKnown = new ObservableCollection<HRM_M001_D>();
                }


                SelectedTabControlIndex = 0;
                isNewRecord = false;

                SetPopupSuggestionDataAfterLoad();

                var msg = new NotificationMessage("HRM_EmployeeView_VM");
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



        private void SetPopupSuggestionDataAfterLoad()
        {

            ASSalutation.AutoSuggestVM.Suggestion = MC.SalList.Find(x => x.sal_desc == MasterEntity.sal_desc);
            ASCountry.AutoSuggestVM.Suggestion = MC.CountryList.Find(x => x.CntryName == MasterEntity.emp_cob);
            ASReligion.AutoSuggestVM.Suggestion = MC.ReligionList.Find(x => x.reli_name == MasterEntity.reli_code);
            ASCast.AutoSuggestVM.Suggestion = MC.CastList.Find(x => x.cast_name == MasterEntity.cast_code);
            ASCategory.AutoSuggestVM.Suggestion = MC.CatList.Find(x => x.cat_name == MasterEntity.cat_code);
            ASNation.AutoSuggestVM.Suggestion = MC.NationalityList.Find(x => x.nation_desc == MasterEntity.nation_code);
            ASNation1.AutoSuggestVM.Suggestion = MC.NationalityList.Find(x => x.nation_desc == MasterEntity.nation_code1);
            ASPhyDis.AutoSuggestVM.Suggestion = MC.PhyDisList.Find(x => x.phy_dis_nm == MasterEntity.phy_dis);
            ASHeightUnit.AutoSuggestVM.Suggestion = MC.HeightList.Find(x => x.unit_abbrv == MasterEntity.height_unit);
            ASWeightUnit.AutoSuggestVM.Suggestion = MC.WeightList.Find(x => x.unit_abbrv == MasterEntity.weight_unit);
            ASStatus.AutoSuggestVM.Suggestion = MC.StatusList.Find(x => x.t_name == MasterEntity.t_name);
        }

        private bool Validation()
        {
            if (MasterEntity.EmpId == null || MasterEntity.EmpId == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Employee Id", MasterEntity.EmpId);
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
        }

        #endregion

        #region Abstract Command Actions

        protected override void OnCreateAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }


        protected override void OnSaveAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        #endregion



    }
}
