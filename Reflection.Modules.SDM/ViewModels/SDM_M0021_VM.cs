using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.GEN;
using Reflection.BusinessEntity.FICO;
using Reflection.Presentation.Controls.UserControls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.Core;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0021_VM : WorkspaceViewModel<GEN_M0001>
    {

        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }

        #region AutoSuggest TextBox Declaration Region

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        //private MC_GEN_M0001 MC;
        //private MC_GEN_M0001 MCTEMP;

        private IEnumerable _SAL_LIST { get; set; }
        public IEnumerable SAL_LIST
        {
            get { return _SAL_LIST; }
            set
            {
                if (_SAL_LIST != value)
                {
                    _SAL_LIST = value; RaisePropertyChanged("SAL_LIST");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CURRENCY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURRENCY
        {
            get { return _AS_CURRENCY; }
            set
            {
                if (_AS_CURRENCY != value)
                {
                    _AS_CURRENCY = value; RaisePropertyChanged("AS_CURRENCY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ACC_GROUP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ACC_GROUP
        {
            get { return _AS_ACC_GROUP; }
            set
            {
                if (_AS_ACC_GROUP != value)
                {
                    _AS_ACC_GROUP = value; RaisePropertyChanged("AS_ACC_GROUP");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_RECON_ACC { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_RECON_ACC
        {
            get { return _AS_RECON_ACC; }
            set
            {
                if (_AS_RECON_ACC != value)
                {
                    _AS_RECON_ACC = value; RaisePropertyChanged("AS_RECON_ACC");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_COUNTRY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COUNTRY
        {
            get { return _AS_COUNTRY; }
            set
            {
                if (_AS_COUNTRY != value)
                {
                    _AS_COUNTRY = value; RaisePropertyChanged("AS_COUNTRY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_STATE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATE
        {
            get { return _AS_STATE; }
            set
            {
                if (_AS_STATE != value)
                {
                    _AS_STATE = value; RaisePropertyChanged("AS_STATE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_PAYTERM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PAYTERM
        {
            get { return _AS_PAYTERM; }
            set
            {
                if (_AS_PAYTERM != value)
                {
                    _AS_PAYTERM = value; RaisePropertyChanged("AS_PAYTERM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_BUSS_PLACE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BUSS_PLACE
        {
            get { return _AS_BUSS_PLACE; }
            set
            {
                if (_AS_BUSS_PLACE != value)
                {
                    _AS_BUSS_PLACE = value; RaisePropertyChanged("AS_BUSS_PLACE");
                }
            }
        }

        

        private AutoSuggestTextViewModel<dynamic> _AS_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TYPE
        {
            get { return _AS_TYPE; }
            set
            {
                if (_AS_TYPE != value)
                {
                    _AS_TYPE = value; RaisePropertyChanged("AS_TYPE");
                }
            }
        }



        #endregion

        bool isNewRecord = true;
        WebServiceRepository<GEN_M0001> REPO = new WebServiceRepository<GEN_M0001>();
        WebServiceRepository<MC_GEN_M0001> REPO_MC = new WebServiceRepository<MC_GEN_M0001>();
        WebServiceRepository<MC_GEN_M0001> REPO_MCTEMP = new WebServiceRepository<MC_GEN_M0001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations
        private MC_GEN_M0001 _MC;
        public MC_GEN_M0001 MC
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

        private MC_GEN_M0001 _MCTEMP;
        public MC_GEN_M0001 MCTEMP
        {
            get { return _MCTEMP; }
            set
            {
                if (_MCTEMP != value)
                {
                    _MCTEMP = value;
                    RaisePropertyChanged("MCTEMP");
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

        private GEN_M0001 _MasterEntity;
        public GEN_M0001 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private GEN_M0011 _AddressEntity;
        public GEN_M0011 AddressEntity
        {
            get
            {
                return _AddressEntity;
            }
            set
            {
                if (_AddressEntity != value)
                {
                    _AddressEntity = value; RaisePropertyChanged("AddressEntity");
                }
            }
        }

        private GEN_M0021 _CPEntity;
        public GEN_M0021 CPEntity
        {
            get
            {
                return _CPEntity;
            }
            set
            {
                if (_CPEntity != value)
                {
                    _CPEntity = value; RaisePropertyChanged("CPEntity");
                }
            }
        }

        private GEN_M0031 _CNEntity;
        public GEN_M0031 CNEntity
        {
            get
            {
                return _CNEntity;
            }
            set
            {
                if (_CNEntity != value)
                {
                    _CNEntity = value; RaisePropertyChanged("CNEntity");
                }
            }
        }

        private ObservableCollection<GEN_M0031> _ContactEntity;
        public ObservableCollection<GEN_M0031> ContactEntity
        {
            get
            {
                return _ContactEntity;
            }
            set
            {
                if (_ContactEntity != value)
                {
                    _ContactEntity = value; RaisePropertyChanged("ContactEntity");
                }
            }
        }

        private STD_REQ_PARA_BE _REQ_PARA;
        public STD_REQ_PARA_BE REQ_PARA
        {
            get { return _REQ_PARA; }
            set
            {
                if (_REQ_PARA != value)
                {
                    _REQ_PARA = value;

                    RaisePropertyChanged("REQ_PARA");
                }
            }
        }
        private STD_LIST_BE _OBJ_PARA_PARTY;
        public STD_LIST_BE OBJ_PARA_PARTY
        {
            get { return _OBJ_PARA_PARTY; }
            set
            {
                if (_OBJ_PARA_PARTY != value)
                {
                    _OBJ_PARA_PARTY = value;

                    RaisePropertyChanged("OBJ_PARA_PARTY");
                }
            }
        }
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_BACKFLIP_COL();
            }
        }
        private void FLTR_BACKFLIP_COL()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FILTER_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {

                    return
                        (data.party_code != null && (data.party_code ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.party_name != null && (data.party_name ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.location != null && (data.location ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cp_name != null && (data.cp_name ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cn_name != null && (data.cn_name ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && (data.short_text ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_code != null && (data.cat_code ?? "").ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private IEnumerable _CAT_LIST;
        public IEnumerable CAT_LIST
        {
            get { return _CAT_LIST; }
            set
            { _CAT_LIST = value; RaisePropertyChanged("CAT_LIST"); }
        }

        private Visibility _visibility_induvidual;
        public Visibility visibility_induvidual
        {
            get { return _visibility_induvidual; }
            set
            {
                if (_visibility_induvidual != value)
                {
                    _visibility_induvidual = value;

                    RaisePropertyChanged("visibility_induvidual");
                }
            }
        }
        private Visibility _visibility_entity;
        public Visibility visibility_entity
        {
            get { return _visibility_entity; }
            set
            {
                if (_visibility_entity != value)
                {
                    _visibility_entity = value;

                    RaisePropertyChanged("visibility_entity");
                }
            }
        }
        private string _date_title;
        public string date_title
        {
            get { return _date_title; }
            set
            {
                if (_date_title != value)
                {
                    _date_title = value;

                    RaisePropertyChanged("date_title");
                }
            }
        }

        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadByDocNo { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowAddressEntity { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowContactEntity { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdInsertSalutation { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }
        public RelayCommand<object> cmdClear { get; private set; }
        public RelayCommand<object> cmdSelectCustomer { get; private set; }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@1!@0";
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_GEN_M0001>(MC, Request, "GEN_M0001_BL", "GEN", "LoadInitialData", 0, "");

                CAT_LIST = MC.CATEGORY_LIST; // Indicator Categry
                SAL_LIST = MC.COMON_LIST;
                #region .Autosuggest .

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).group_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).group_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).group_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ACC_GROUP = new AutoSuggestTextViewModel<dynamic>(MC.GROUP_LIST, TheFilter, SuggestedValue, "group_code", true);
                AS_ACC_GROUP.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ACC_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).gl_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).gl_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_RECON_ACC = new AutoSuggestTextViewModel<dynamic>(MC.GL_LIST, TheFilter, SuggestedValue, "gl_code", true);
                AS_RECON_ACC.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0033)x).curr_code);
                TheFilter = (o, prefix) => (((FICO_M0033)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0033)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURR_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ctry_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ctry_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).ctry_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COUNTRY = new AutoSuggestTextViewModel<dynamic>(MC.COUNTRY_LIST, TheFilter, SuggestedValue, "ctry_code", true);
                AS_COUNTRY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COUNTRY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATE = new AutoSuggestTextViewModel<dynamic>(MC.STATE_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_STATE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_STATE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).pt_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).pt_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).pt_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PAYTERM = new AutoSuggestTextViewModel<dynamic>(MC.PAYTERM_LIST, TheFilter, SuggestedValue, "pt_code", true);
                AS_PAYTERM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PAYTERM.AutoSuggestVM.IsFreeTextAllowed = false;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_BUSS_PLACE = new AutoSuggestTextViewModel<dynamic>(MC.COMON_LIST1, TheFilter, SuggestedValue, "value_code", true);
                AS_BUSS_PLACE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BUSS_PLACE.AutoSuggestVM.IsFreeTextAllowed = false;

                ContactEntity = MC.CN_M_LIST_TEMP;


                #endregion

            }
            catch (Exception ex)
            {
                MessageWindowRun(ex, "SYS", "", "");
            }
        }

        private void InsertSalutation(object InputValue)
        {
            string Request = "";
            STD_LIST_BE POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.COMON_LIST.Where(x => x.value_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.short_text.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }

                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.sal_code = POPUPEntityObject.value_code;
                MasterEntity.sal_text = POPUPEntityObject.short_text;
            }
            else
            {
                MasterEntity.sal_code = null;
                MasterEntity.sal_text = null;
            }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData();


                // NOTE: Make this visibility setting as per the default ind_cat value
                visibility_induvidual = Visibility.Collapsed;
                visibility_entity = Visibility.Visible;
                date_title = "DOE";
                DefaultValues();

                if (OBJ_PARA_PARTY != null)
                {
                    if (!string.IsNullOrWhiteSpace(OBJ_PARA_PARTY.party_code))
                    {
                        List<STD_LIST_BE> OBJ_PARTY_LIST = new List<STD_LIST_BE>();
                        OBJ_PARTY_LIST.Add(OBJ_PARA_PARTY);
                        LoadDocumentByDocumentNumber(OBJ_PARTY_LIST, "POS_SYS");
                    }
                }

                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            STD_LIST_BE ParameterEntityObject = null;
            try
            {
                if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                    REQ_PARA.request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@!@!@" + ParameterEntityObject.party_code;
                    MCTEMP = REPO_MCTEMP.GetDataWithReturnDomainObject<MC_GEN_M0001>(MCTEMP, REQ_PARA.request, "GEN_M0001_BL", "GEN", "LOAD_DOC_BY_DOC_NO", 0, "");

                    if (MCTEMP.PARTY_M_LIST != null)
                    {
                        if (MCTEMP.PARTY_M_LIST.Count > 0)
                        {
                            MasterEntity = MCTEMP.PARTY_M_LIST[0];

                            if (MCTEMP.ADDRESS_M_LIST != null)
                            {
                                if (MCTEMP.ADDRESS_M_LIST.Count > 0)
                                {
                                    AddressEntity = MCTEMP.ADDRESS_M_LIST[0];
                                }
                            }
                            if (MCTEMP.CP_M_LIST != null)
                            {
                                if (MCTEMP.CP_M_LIST.Count > 0)
                                {
                                    CPEntity = MCTEMP.CP_M_LIST[0];
                                }
                            }
                            if (MCTEMP.CN_M_LIST != null)
                            {
                                if (MCTEMP.CN_M_LIST.Count > 0)
                                {
                                    ContactEntity = MCTEMP.CN_M_LIST;
                                    CNEntity = MCTEMP.CN_M_LIST[0];
                                }
                            }
                        }
                    }
                    //SetBusinessEntitiesAfterLoad("Save", "");
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                    isNewRecord = false;
                    SelectedTabControlIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageWindowRun(ex, "SYS", "", "");
            }
        }

        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.comp_code))
            {
                MessageWindowRun(null, "TRN", String.Format("Please Select Company Code...", this.Title), "101");
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.curr_code))
            {
                MessageWindowRun(null, "TRN", String.Format("Please Select Currency...", this.Title), "101");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(MasterEntity.party_name))
            {
                MessageWindowRun(null, "TRN", String.Format("Please input Customer name...", this.Title), "101");
                return false;
            }
            else if ((MasterEntity.ind_cat=="P" || MasterEntity.ind_cat == "P") && (string.IsNullOrWhiteSpace(MasterEntity.f_name) || string.IsNullOrWhiteSpace(MasterEntity.l_name)))
            {
                MessageWindowRun(null, "TRN", String.Format("Please input Customer First & Last name...", this.Title), "101");
                return false;
            }
            else if ((MasterEntity.ind_cat == "P" || MasterEntity.ind_cat == "P") && string.IsNullOrWhiteSpace(MasterEntity.ind_gender))
            {
                MessageWindowRun(null, "TRN", String.Format("Please input customer gender...", this.Title), "101");
                return false;
            }
            else if ((MasterEntity.ind_cat == "P" || MasterEntity.ind_cat == "P") && !MasterEntity.doe.HasValue) // NOTE: Make this user define validation.
            {
                MessageWindowRun(null, "TRN", String.Format("Please input customer Date of birth...", this.Title), "101");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(MasterEntity.party_type))
            {
                MessageWindowRun(null, "TRN", String.Format("Please input Customer Type...", this.Title), "101");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(MasterEntity.acc_group))
            {
                MessageWindowRun(null, "TRN", String.Format("Please Select Accounting Group...", this.Title), "101");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(MasterEntity.recon_acc))
            {
                MessageWindowRun(null, "TRN", String.Format("Please Select Reconcelation Special General Account...", this.Title), "101");
                return false;
            }
            //if (string.IsNullOrWhiteSpace(AddressEntity.add_line1))
            //{
            //    MessageWindowRun(null, "TRN", String.Format(String.Format("Please Enter Address Line 1 {0} and Line 2 {1}", AddressEntity.add_line1, AddressEntity.add_line2), this.Title), "101");
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(AddressEntity.ctry_code))
            {
                MessageWindowRun(null, "TRN", String.Format(String.Format("Please Enter Country {0} and State {1}", AddressEntity.ctry_code, AddressEntity.state_code), this.Title), "101");
                return false;
            }
            if (ContactEntity != null)
            {
                if (ContactEntity.Count > 0)
                {
                    var conData = ContactEntity.Where(x => x.type_code == "03").ToList();
                    if(conData != null)
                    {
                        if (conData.Count > 0)
                        {
                            if (string.IsNullOrWhiteSpace(conData[0].cn_text))
                            {
                                MessageWindowRun(null, "TRN", String.Format(String.Format("Please Enter {0} and for {1}", conData[0].type_name, MasterEntity.party_name), this.Title), "101");
                                return false;
                            }
                            else if (conData[0].cn_text.Length != 10)
                            {
                                MessageWindowRun(null, "TRN", String.Format(String.Format("Please Enter {0} digit proper for {1}", conData[0].type_name, MasterEntity.party_name), this.Title), "101");
                                return false;
                            }
                        }

                    }
                }
                    
            }
            

            return true;
        }

        //NOTE: shift this MessageWindowRun function to global class and call from each class. it will reduce common mesage duplication in each vm. make list of standard message with code name and call onle code e.g. 101 for save record successfully.
        public void MessageWindowRun(Exception ex, string sms_cat, string sms_para, string sms_code) // ex: show exception as it is and disply as it is, sms_code: exception or other code,sms_para: additional code, sms_code: message code by which message will get pick. all other details can be fetch by sms_code.
        {
            try
            {
                if (sms_cat == "SYS") // system exception
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                }
                else if (sms_cat == "TRN") // Transactional message
                {
                    if (sms_code == "001")
                    {
                        MessageBox.Show("Record Save successfully!", "Message", MessageBoxButton.OK);
                    }
                    else if (sms_code == "002")
                    {
                        MessageBox.Show("Record Updated successfully!", "Message", MessageBoxButton.OK);
                    }
                    else if (sms_code == "101") // validation message
                    {
                        MessageBox.Show(sms_para, "Validation", MessageBoxButton.OK);
                    }

                }


                ////if (Mouse.OverrideCursor == null)
                ////{
                ////    CursorControl.SetBusyState();

                //AppSessionState.ViewTitle = "Message";
                //AppSessionState.TransactionCode = "SMS";

                //string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.ADM.dll"); // this one is path option
                //Assembly assembly = Assembly.LoadFile(path1);
                //Type type = assembly.GetType("Reflection.Modules.ADM.CustomControl.MessageWindow");
                //if (type != null)
                //{
                //    dynamic instance = Activator.CreateInstance(type, AppSessionState.TransactionCode);
                //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                //}
                ////}
            }
            catch (Exception exn)
            {
                MessageBox.Show(exn.Message, "Error");
            }
        }
        #endregion

        #region Constructor
        public SDM_M0021_VM(string ts_code, string doc_cat) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MC = new MC_GEN_M0001();
            MCTEMP = new MC_GEN_M0001();
            MasterEntity = new GEN_M0001();
            AddressEntity = new GEN_M0011();
            CPEntity = new GEN_M0021();
            CNEntity = new GEN_M0031();
            ContactEntity = new ObservableCollection<GEN_M0031>();
            REQ_PARA = new STD_REQ_PARA_BE();
            OBJ_PARA_PARTY = new STD_LIST_BE();
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadByDocNo = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            cmdInsertSalutation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalutation(items); });
            cmdSave = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Save(cmdPara); });
            GEN_M0001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_M0021_VM(string ts_code, string doc_cat, object OBJ_PARA) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MC = new MC_GEN_M0001();
            MCTEMP = new MC_GEN_M0001();
            MasterEntity = new GEN_M0001();
            AddressEntity = new GEN_M0011();
            CPEntity = new GEN_M0021();
            CNEntity = new GEN_M0031();
            ContactEntity = new ObservableCollection<GEN_M0031>();
            REQ_PARA = new STD_REQ_PARA_BE();
            OBJ_PARA_PARTY = new STD_LIST_BE();
            OBJ_PARA_PARTY = (STD_LIST_BE)OBJ_PARA; // Load selected party on load. send this parameter from POS system
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadByDocNo = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            cmdInsertSalutation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalutation(items); });
            cmdSave = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Save(cmdPara); });
            cmdClear = new RelayCommand<object>(items => { if (items == null) { return; } ClearRecord(items); });
            cmdSelectCustomer = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectCustomer(cmdPara); });
            GEN_M0001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        #endregion

        #region Function

        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "ind_cat")
                {
                    if (MasterEntity.ind_cat == "P")
                    {
                        visibility_induvidual = Visibility.Visible;
                        visibility_entity = Visibility.Collapsed;
                        date_title = "DOB";
                        SetPrefix();
                    }
                    else
                    {
                        visibility_induvidual = Visibility.Collapsed;
                        visibility_entity = Visibility.Visible;
                        date_title = "DOE";
                        MasterEntity.ind_gender = null;
                        SetPrefix();
                    }
                    var TaxListParent = (from o in MC.CATEGORY_LIST where o.ind_cat == MasterEntity.ind_cat select o).ToList();
                    if (TaxListParent == null || TaxListParent.Count == 0)
                    {
                        if (MasterEntity.ind_cat != null)
                        {
                            MasterEntity.ind_cat = null;
                        }
                    }
                }
                if (sender.ToString() == "doe")
                {
                    if (MasterEntity.doe.HasValue)
                    {
                        
                        //MasterEntity.age = Utilities.CalculateAge((DateTime)MasterEntity.doe, DateTime.Now).ToString(); // Commented because circuler stack overflow betweem doe & ege field.
                        SetPrefix();
                    }
                }
                if (sender.ToString() == "age")
                {
                    if (!string.IsNullOrWhiteSpace(MasterEntity.age)) //!MasterEntity.doe.HasValue && 
                    {
                        //var now = new DateTime(DateTime.Now.Year, 7, DateTime.Now.Day);
                        //now.AddYears(-Convert.ToInt32(MasterEntity.age));
                        //MasterEntity.doe = now;
                        MasterEntity.doe = new DateTime((DateTime.Now.Year - Convert.ToInt32(MasterEntity.age)), 7, DateTime.Now.Day);
                    }
                }
                if (sender.ToString() == "ind_gender")
                {
                    if (MasterEntity.ind_gender != "M" && MasterEntity.ind_gender != "F" && MasterEntity.ind_gender != "T" && MasterEntity.ind_gender != null)
                    {
                        MasterEntity.ind_gender = null;
                    }
                    SetPrefix();
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        public static string CapitalizeFirstLetterIfNotUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Check if the first character is already uppercase
            if (char.IsUpper(input[0]))
                return input;

            // Capitalize only if the first character is not uppercase
            return char.ToUpper(input[0]) + input.Substring(1);
        }


        private void SetPrefix()
        {
            if (MasterEntity.doe.HasValue && !string.IsNullOrWhiteSpace(MasterEntity.ind_gender) && MC.COMON_LIST != null && MasterEntity.ind_cat == "P")
            {
                var SalList = MC.COMON_LIST.Where(x => x.ind_gender == MasterEntity.ind_gender && x.ind_cat == MasterEntity.ind_cat && ((x.int_value1 <= Convert.ToInt32(MasterEntity.age ?? "") && x.int_value2 >= Convert.ToInt32(MasterEntity.age ?? "")) || x.int_value1 == null)).ToList();
                if (SalList != null)
                {
                    if (SalList.Count > 0)
                    {
                        if (SalList.Count == 1)
                        {
                            MasterEntity.sal_code = SalList[0].value_code;
                            MasterEntity.sal_text = SalList[0].short_text;
                        }
                        else
                        {
                            var SalList2 = SalList.Where(x => x.ind_default == "1").ToList();
                            if (SalList2 != null)
                            {
                                if (SalList2.Count == 1)
                                {
                                    MasterEntity.sal_code = SalList2[0].value_code;
                                    MasterEntity.sal_text = SalList2[0].short_text;
                                }
                            }
                        }
                        SAL_LIST = SalList;
                    }
                    else
                    {
                        MasterEntity.sal_code = null;
                        MasterEntity.sal_text = null;
                        SAL_LIST = MC.COMON_LIST;
                    }
                }
                else
                {
                    MasterEntity.sal_code = null;
                    MasterEntity.sal_text = null;
                    SAL_LIST = MC.COMON_LIST;
                }

            }
            else if (MC.COMON_LIST != null && MasterEntity.ind_cat != "P")
            {
                SAL_LIST = MC.COMON_LIST;
                var SalListC = MC.COMON_LIST.Where(x => x.ind_cat == "C").ToList();
                if (SalListC.Count > 0)
                {
                    if (SalListC.Count == 1)
                    {
                        MasterEntity.sal_code = SalListC[0].value_code;
                        MasterEntity.sal_text = SalListC[0].short_text;
                    }
                    SAL_LIST = SalListC;
                }
            }
            else if (MC.COMON_LIST != null && MasterEntity.ind_cat != null)
            {
                SAL_LIST = MC.COMON_LIST.Where(x => x.ind_cat == MasterEntity.ind_cat).ToList();
            }
            else 
            {
                SAL_LIST = MC.COMON_LIST;
            }

        }
        private void ClearRecord(object InputValue) // Save invoice and validate
        {
            try
            {
                InquiryActionResult<GEN_M0001> result = new WindowViewModel<GEN_M0001>.InquiryActionResult<GEN_M0001>();
                OnCreateAction(result);

                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity, "TEST_ADD"));
                //AddressControl obj_add = new AddressControl(ts_code_vm, "TEST_ADD", AddressEntity);
                //obj_add.Show();

            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            //if (msg.Notification == ts_code_vm && msg.Sender.ToString() == "TEST_ADD")
            //{
            //    //popup_AccountingGroup.IsOpen = false;

            //}
        }
        private void Save(object InputValue)
        {
            try
            {
                var StringArray = new[] { MasterEntity.f_name, MasterEntity.m_name, MasterEntity.l_name };
                string FullString = string.Join(" ", StringArray.Where(s => !string.IsNullOrEmpty(s)));
                if (!string.IsNullOrWhiteSpace(FullString) && MasterEntity.ind_cat=="P")
                {
                    MasterEntity.party_name = FullString;
                }

                if (Validation() == true)
                {
                    

                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.ts_code = (ts_code_vm ?? AppSessionState.TransactionCode);

                    List<GEN_M0011> AddressList = new List<GEN_M0011>();
                    List<GEN_M0021> CPList = new List<GEN_M0021>();
                    List<GEN_M0031> CNList = new List<GEN_M0031>();
                    AddressList.Add(AddressEntity);
                    CPList.Add(CPEntity);
                    CNList.Add(CNEntity);

                    MasterEntity.XDOC_A = obj.ObjectToXML(AddressList);
                    MasterEntity.XDOC_B = obj.ObjectToXML(CPList);
                    MasterEntity.XDOC_C = obj.ObjectToXML(ContactEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<GEN_M0001>(MasterEntity, "GEN_M0001_BL", "GEN");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<GEN_M0001>(MasterEntity, "GEN_M0001_BL", "GEN");
                    }

                    if (MasterEntity.party_code != null && isNewRecord == true)
                    {
                        MessageWindowRun(null, "TRN", String.Format("Record created successfully", this.Title), "001");
                    }
                    if (MasterEntity.party_code != null && isNewRecord == false)
                    {
                        MessageWindowRun(null, "TRN", String.Format("Record Updated Successfully", this.Title), "002");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;

                    STD_LIST_BE ParameterEntityObject = new STD_LIST_BE();
                    ParameterEntityObject.party_code = MasterEntity.party_code;
                    ParameterEntityObject.party_name = MasterEntity.party_name;
                    ParameterEntityObject.add_code = AddressEntity.add_code;
                    ParameterEntityObject.cp_code = CPEntity.cp_code;
                    ParameterEntityObject.cn_code = CNEntity.cn_code;
                    ParameterEntityObject.cn_name = CNEntity.cn_text;

                    SelectCustomer(ParameterEntityObject);
                }
            }
            catch (Exception ex)
            {
                //MessageWindowRun();
                MessageBox.Show(ex.ToString());
            }
        }
        private void SelectCustomer(object InputValue)
        {
            try
            {
                STD_LIST_BE ParameterEntityObject = new STD_LIST_BE();

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    ParameterEntityObject.type_code = OBJ_PARA_PARTY.type_code;
                    ParameterEntityObject.ts_code = OBJ_PARA_PARTY.ts_code;
                    ParameterEntityObject.party_code = MasterEntity.party_code;
                    ParameterEntityObject.party_name = MasterEntity.party_name;
                    ParameterEntityObject.add_code = AddressEntity.add_code;
                    ParameterEntityObject.cp_code = CPEntity.cp_code;
                    ParameterEntityObject.cn_code = CNEntity.cn_code;
                    ParameterEntityObject.cn_name = CNEntity.cn_text;
                    ParameterEntityObject.pt_code = (OBJ_PARA_PARTY.pt_code ?? MasterEntity.pt_code);
                    ParameterEntityObject.curr_code = (OBJ_PARA_PARTY.curr_code ?? MasterEntity.curr_code);

                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ParameterEntityObject, "POS_CUST"));
                    this.Close();
                }
                else if (InputValue != null)
                {
                    ParameterEntityObject = (STD_LIST_BE)InputValue;
                    ParameterEntityObject.type_code = OBJ_PARA_PARTY.type_code;
                    ParameterEntityObject.ts_code = OBJ_PARA_PARTY.ts_code;
                    if (!string.IsNullOrWhiteSpace(ParameterEntityObject.party_code))
                    {
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ParameterEntityObject, "POS_CUST"));
                        this.Close();
                    }
                }









                
            }
            catch (Exception ex)
            {
                //MessageWindowRun();
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {

                REQ_PARA.request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + REQ_PARA.comp_code + "!@" + REQ_PARA.location_id + "!@" + REQ_PARA.from_date + "!@" + REQ_PARA.active + "!@" + (MasterEntity.party_type ?? "002") + "!@";
                MCTEMP = REPO_MCTEMP.GetDataWithReturnDomainObject<MC_GEN_M0001>(MCTEMP, REQ_PARA.request, "GEN_M0001_BL", "GEN", "LOAD_BACKFLIP", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MCTEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FILTER_BACKFLIP);

            }
            catch (Exception ex)
            {
                MessageWindowRun(ex, "SYS", "", "");
            }

        }
        #endregion

        #region Abstract Command Actions
        private void DefaultValues()
        {
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.active = true;
            MasterEntity.active_code = "1";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.party_type = "002";
            MasterEntity.curr_code = AppSessionState.OBJ_COMPANY.curr_code;
            MasterEntity.place = (AppSessionState.OBJ_LOCATION.place ?? AppSessionState.OBJ_LOCATION.city);
            //MasterEntity.loc = (AppSessionState.OBJ_LOCATION.place ?? AppSessionState.OBJ_LOCATION.city);

            if (MC.CATEGORY_LIST != null) //  Set default value for category
            {
                if (MC.CATEGORY_LIST.Count > 0)
                {
                    var REF_DOC_TEMP = (from o in MC.CATEGORY_LIST where (o.ind_default == "1" || o.ind_default == "Y") select o).ToList();
                    if (REF_DOC_TEMP != null)
                    {
                        MasterEntity.ind_cat = REF_DOC_TEMP[0].ind_cat;
                    }
                }
            }
            if (MC.DEFAULT_VALUE_LIST != null) //  Set default value for category
            {
                if (MC.DEFAULT_VALUE_LIST.Count > 0)
                {
                    //var DV_OBJ = MC.DEFAULT_VALUE_LIST[0];
                    var DV_OBJ = (from o in MC.DEFAULT_VALUE_LIST where (o.party_type == MasterEntity.party_type) select o).ToList();
                    if (DV_OBJ != null)
                    {
                        MasterEntity.recon_acc = DV_OBJ[0].gl_code;
                        MasterEntity.acc_group = DV_OBJ[0].acc_group;
                    }
                }
            }

            if (MC.DEFAULT_VALUE_LIST != null) //  Set default value for category
            {
                if (MC.DEFAULT_VALUE_LIST.Count > 0)
                {
                    //var DV_OBJ = MC.DEFAULT_VALUE_LIST[0];
                    var DV_OBJ = (from o in MC.DEFAULT_VALUE_LIST where (o.party_type == MasterEntity.party_type) select o).ToList();
                    if (DV_OBJ != null)
                    {
                        MasterEntity.recon_acc = DV_OBJ[0].gl_code;
                        MasterEntity.acc_group = DV_OBJ[0].acc_group;
                    }
                }
            }
            if (MC.PAYTERM_LIST != null) //  Set default value for category
            {
                if (MC.PAYTERM_LIST.Count > 0)
                {
                    //var DV_OBJ = MC.DEFAULT_VALUE_LIST[0];
                    var DV_PT = (from o in MC.PAYTERM_LIST where (o.ind_default == "1") select o).ToList().FirstOrDefault();
                    if (DV_PT != null)
                    {
                        MasterEntity.pt_code = DV_PT.pt_code;
                    }
                }
            }

            AddressEntity.doc_cat = "103";
            AddressEntity.doc_type = "103";
            AddressEntity.ctry_code = AppSessionState.OBJ_LOCATION.country_code;
            AddressEntity.state_code = AppSessionState.OBJ_LOCATION.state_code;
            AddressEntity.buss_place = AppSessionState.OBJ_LOCATION.buss_place;
            AddressEntity.place = (AppSessionState.OBJ_LOCATION.place ?? AppSessionState.OBJ_LOCATION.city);
            AddressEntity.city = (AppSessionState.OBJ_LOCATION.city ?? AppSessionState.OBJ_LOCATION.place);
            AddressEntity.active = true;
            AddressEntity.active_code = "1";

            

            ContactEntity = MC.CN_M_LIST_TEMP;

            if (doc_cat_vm == "102")
            {
                MasterEntity.ind_cust = "1";
                MasterEntity.ind_supp = null;
            }
            else
            {
                MasterEntity.ind_cust = null;
                MasterEntity.ind_supp = "1";
            }

            REQ_PARA.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                AddressEntity = new GEN_M0011();
                CPEntity = new GEN_M0021();
                CNEntity = new GEN_M0031();
                if (MasterEntity.XDOC_A != null)
                {
                    MC.ADDRESS_M_LIST = (ObservableCollection<GEN_M0011>)obj.XMLToObject(MasterEntity.XDOC_A, MC.ADDRESS_M_LIST);
                    if(MC.ADDRESS_M_LIST != null)
                    {
                        if (MC.ADDRESS_M_LIST.Count > 0)
                        {
                            AddressEntity = MC.ADDRESS_M_LIST[0];
                        }
                    }
                }
                if (MasterEntity.XDOC_B != null)
                {
                    MC.CP_M_LIST = (ObservableCollection<GEN_M0021>)obj.XMLToObject(MasterEntity.XDOC_B, MC.CP_M_LIST);
                    if (MC.CP_M_LIST != null)
                    {
                        if (MC.CP_M_LIST.Count > 0)
                        {
                            CPEntity = MC.CP_M_LIST[0];
                        }
                    }
                }
                if (MasterEntity.XDOC_C != null)
                {
                    MC.CN_M_LIST = (ObservableCollection<GEN_M0031>)obj.XMLToObject(MasterEntity.XDOC_C, MC.CN_M_LIST);
                    if (MC.CN_M_LIST != null)
                    {
                        if (MC.CN_M_LIST.Count > 0)
                        {
                            ContactEntity = MC.CN_M_LIST;
                            CNEntity = MC.CN_M_LIST[0];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        protected override void OnSaveAction(InquiryActionResult<GEN_M0001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.ts_code = (ts_code_vm ?? AppSessionState.TransactionCode);

                    List<GEN_M0011> AddressList = new List<GEN_M0011>();
                    List<GEN_M0021> CPList = new List<GEN_M0021>();
                    List<GEN_M0031> CNList = new List<GEN_M0031>();
                    AddressList.Add(AddressEntity);
                    CPList.Add(CPEntity);
                    CNList.Add(CNEntity);

                    MasterEntity.XDOC_A = obj.ObjectToXML(AddressList);
                    MasterEntity.XDOC_B = obj.ObjectToXML(CPList);
                    MasterEntity.XDOC_C = obj.ObjectToXML(ContactEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<GEN_M0001>(MasterEntity, "GEN_M0001_BL", "GEN");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<GEN_M0001>(MasterEntity, "GEN_M0001_BL", "GEN");
                    }

                    if (MasterEntity.party_code != null && isNewRecord == true)
                    {
                        MessageWindowRun(null, "TRN", String.Format("Record created successfully", this.Title), "001");
                    }
                    if (MasterEntity.party_code != null && isNewRecord == false)
                    {
                        MessageWindowRun(null, "TRN", String.Format("Record Updated Successfully", this.Title), "002");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
                }
            }
            catch (Exception ex)
            {
                //MessageWindowRun();
                MessageBox.Show(ex.ToString());
            }
        }

        
        protected override void OnCreateAction(InquiryActionResult<GEN_M0001> result)
        {
            isNewRecord = true;
            MasterEntity = new GEN_M0001();
            AddressEntity = new GEN_M0011();
            CPEntity = new GEN_M0021();
            CNEntity = new GEN_M0031();
            ContactEntity = new ObservableCollection<GEN_M0031>();
            ContactEntity = MC.CN_M_LIST_TEMP;

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<GEN_M0001> result)
        {
            if (MasterEntity.party_code != null)
            {
                //MessageBox.Show(null,"Error", String.Format("This record will delete forever", this.Title),);

                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will delete forever", this.Title); sms.ShowMessage();
                //if (sms.ShowMessage() == DialogResult.Ok)
                //{
                //    //this.MasterEntity.CancelEdit();
                //    //string response = repository.Delete(MasterEntity.PartyId, "ADM_M0028_BL", "ADM");
                //    //MasterEntity = new GEN_M0001();
                //    //AddressEntity = new ObservableCollection<ADM_M028_D>();
                //    //ContactEntity = new ObservableCollection<ADM_M028_C>();
                //    //isNewRecord = true;
                //}
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnFevoriteAction(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnFlipAction(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnHelpAction(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnPrintAction(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.party_code.ToString()))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.party_code.ToString().Replace("/", "--"), DocumentList = MCTEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnLedgerViewCommand(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnValidateCommand(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnTraceCommand(InquiryActionResult<GEN_M0001> result)
        {}
        protected override void OnMailCommand(InquiryActionResult<GEN_M0001> result)
        {}
        #endregion
       
    }
}
