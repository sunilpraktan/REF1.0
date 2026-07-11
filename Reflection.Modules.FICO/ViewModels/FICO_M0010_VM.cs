using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Generic;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.ViewModels
{
    class FICO_M0010_VM : WorkspaceViewModel<ACC_M003_E>
    {
        #region AutoSuggest TextBox Declaration Region
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASModuleGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASModuleGroup
        {
            get { return _ASModuleGroup; }
            set
            {
                if (_ASModuleGroup != value)
                {
                    _ASModuleGroup = value;
                    RaisePropertyChanged("ASModuleGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCOAKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCOAKey
        {
            get { return _ASCOAKey; }
            set
            {
                if (_ASCOAKey != value)
                {
                    _ASCOAKey = value;
                    RaisePropertyChanged("ASCOAKey");
                }
            }
        }

        #endregion

        WebServiceRepository<MultipleContext_ACC_M003_E> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_E>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration

        private ACC_M003_E _MasterEntity;
        public ACC_M003_E MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private MultipleContext_ACC_M003_E _MC;
        public MultipleContext_ACC_M003_E MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_E _MCTemp;
        public MultipleContext_ACC_M003_E MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdViewAllAccountDetermination { get; private set; }
        public RelayCommand<object> CmdFilterDatagrid { get; private set; }
        public RelayCommand<object> cmdInsertModuleGroup { get; private set; }
        public RelayCommand<object> cmdInsertCOAKey { get; private set; }
        #endregion

        #region Constructor
        public FICO_M0010_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_E();
            MC = new MultipleContext_ACC_M003_E();
            MCTemp = new MultipleContext_ACC_M003_E();

            CmdViewAllAccountDetermination = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewAccountDeterminationKey(cmdPara); });
            CmdFilterDatagrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterGL_AccountDeterminationData(cmdPara); });
            cmdInsertModuleGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertModuleGroup(cmdPara); });
            cmdInsertCOAKey = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCOAKey(cmdPara); });

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_E>(MC, Request, "GL_AccountDetermination", "Finance", " ", 0, "");

                //Module Group PopUp
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_E1)x).mod_group);
                TheFilter = (o, prefix) => (((ACC_M003_E1)o).mod_group ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASModuleGroup = new AutoSuggestTextViewModel<dynamic>(MC.ModuleGroupMaster, TheFilter, SuggestedValue, "mod_group", true);
                ASModuleGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_D_P)x).coa_key);
                TheFilter = (o, prefix) => (((ACC_M003_D_P)o).coa_key ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCOAKey = new AutoSuggestTextViewModel<dynamic>(MC.COAKeyList, TheFilter, SuggestedValue, "coa_key", true);
                ASCOAKey.AutoSuggestVM.IsEmptyValueAllowed = true;

                DataGridCollection = CollectionViewSource.GetDefaultView(MC.MasterEntityList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                var msg = new NotificationMessage("FICO_M0010_VM");
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

        private void ViewAccountDeterminationKey(object InputValue)
        {
            try
            {
                ACC_M003_E POPUPEntityObject = null;

                if (MasterEntity.COA_Key != null && MasterEntity.COA_Key != "")
                {
                    if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_E>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_E>().ToList()[0];

                        if (POPUPEntityObject.mod_group.ToLower() == "sales" || POPUPEntityObject.mod_group.ToLower() == "purchase")
                        {
                            AppSessionState.TransValue = POPUPEntityObject.trns_key_code;  //+ "!@" + MasterEntity.COA_Key;
                            AppSessionState.TransParameter = MasterEntity.COA_Key;
                            AppSessionState.TransValueType = "sales_purchase";
                            AppSessionState.ViewTitle = "Account Determination Revenue / Purchase";
                            AppSessionState.ViewOtherRecordAllowed = true;

                            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.FICO.dll");
                            Assembly assembly = Assembly.LoadFile(path1);
                            Type type = assembly.GetType("Reflection.Modules.FICO.Views.FICO_M0018");
                            if (type != null)
                            {
                                dynamic instance = Activator.CreateInstance(type, "FM18");
                                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                            }
                        }

                        //else if (POPUPEntityObject.mod_group.ToLower() == "purchase")
                        //{
                        //    AppSessionState.TransValue = POPUPEntityObject.trns_key_code;
                        //    AppSessionState.TransValueType = "purchase";
                        //    AppSessionState.ViewTitle = "Account Determination Purchase";
                        //    AppSessionState.ViewOtherRecordAllowed = true;

                        //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                        //    Assembly assembly = Assembly.LoadFile(path1);
                        //    Type type = assembly.GetType("Reflection.Modules.Finance.Views.AccountDetermination_Purchase");
                        //    if (type != null)
                        //    {
                        //        dynamic instance = Activator.CreateInstance(type);
                        //        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                        //    }
                        //}
                        else
                        {
                            AppSessionState.TransValue = POPUPEntityObject.trns_key_code;//    + "!@" + MasterEntity.COA_Key;
                            AppSessionState.TransParameter = MasterEntity.COA_Key;
                            AppSessionState.TransValueType = "FROM_ACC_M003_E_VM";
                            AppSessionState.ViewTitle = "Account Determination Key";
                            AppSessionState.ViewOtherRecordAllowed = true;

                            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.FICO.dll");
                            Assembly assembly = Assembly.LoadFile(path1);
                            Type type = assembly.GetType("Reflection.Modules.FICO.Views.FICO_M0034");
                            if (type != null)
                            {
                                dynamic instance = Activator.CreateInstance(type);
                                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                            }
                        }

                    }

                    //ACC_M003_E POPUPEntityObject = null;
                    //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                    //if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_E>().Count() > 0)
                    //{
                    //    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_E>().ToList()[0];
                    //    POPUPEntityObject.TranCode = "ACC_M003_Tkey";
                    //}

                    //var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                    //userAuth = docdetails;
                    //AppSessionState.UserAuthSingle = userAuth;
                    //AppSessionState.ViewTitle = userAuth.DisTitl;
                    //AppSessionState.TransValue = POPUPEntityObject.trns_key_code;// + "!@" + POPUPEntityObject.test_code;
                    //AppSessionState.TransValueType = "FROM_FICO_M0010_VM";
                    //AppSessionState.TransParameter = "FromAC_Key";
                    //AppSessionState.ViewOtherRecordAllowed = true;
                    //AppSessionState.TransId = userAuth.id.ToString();
                    //AppSessionState.TransactionCode = userAuth.TranCode;

                    //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                    //{
                    //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.Nspace);
                    //    Assembly assembly = Assembly.LoadFile(path1);
                    //    Type type = assembly.GetType(userAuth.ClsFileName);
                    //    if (type != null)
                    //    {
                    //        dynamic instance = Activator.CreateInstance(type);
                    //        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    //       // this.Close();
                    //    }
                    //}
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Chart of Accounts (COA) Key...");
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
        private void FilterGL_AccountDeterminationData(object InputValue)
        {
            try
            {
                List<ACC_M003_E> TempMasterEntityList = new List<ACC_M003_E>();
                TempMasterEntityList = (from o in MC.MasterEntityList
                                        where o.mod_group == MasterEntity.mod_group
                                        select o).ToList();

                DataGridCollection = CollectionViewSource.GetDefaultView(TempMasterEntityList);
                DataGridCollection.Filter = new Predicate<object>(FilterModGroup);


            }
            catch (Exception ex) { }
        }

        private void InsertModuleGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_E1 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ModuleGroupMaster.Where(x => x.mod_group.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_E1>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_E1>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.mod_group = POPUPEntityObject.mod_group;
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
        private void InsertCOAKey(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_D_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.COAKeyList.Where(x => x.coa_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_D_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_D_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.COA_Key = POPUPEntityObject.coa_key;
                    MasterEntity.comp_code_P = POPUPEntityObject.comp_code;
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

        #region Filters For DataGrid
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
            var data = obj as ACC_M003_E;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.trns_key_code != null && data.trns_key_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.mod_group != null && data.mod_group.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.trns_code != null && data.trns_code.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }


        #region Filters

        private void FilterCollectionModGroup()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public string FilterStringModGroup
        {
            get { return MasterEntity.mod_group; }
            set
            {
                MasterEntity.mod_group = value;
                RaisePropertyChanged("FilterStringModGroup");
                FilterCollectionModGroup();
            }
        }
        public bool FilterModGroup(object obj)
        {
            var data = obj as ACC_M003_E;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(MasterEntity.mod_group))
                {
                    return (data.mod_group != null && data.mod_group.ToString().ToLower().Contains(MasterEntity.mod_group.ToLower()) ||
                            data.trns_key_desc != null && data.trns_key_desc.ToString().ToLower().Contains(MasterEntity.mod_group.ToLower()) ||
                            data.trns_key_code != null && data.trns_key_code.ToString().ToLower().Contains(MasterEntity.mod_group.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_E> result)
        {
            try
            {
                LoadInitialData();
            }
            catch (Exception ex) { }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_E> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_E> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_E> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_E> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_E> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_E> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_E> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_E> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
