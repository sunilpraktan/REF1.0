using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Finance;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using System.Collections;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0007_VM : WorkspaceViewModel<ACC_M003_A>
    {
        bool isNewRecord = true;
        WebServiceRepository<ACC_M003_A> repository = new WebServiceRepository<ACC_M003_A>();
        WebServiceRepository<MultipleContext_ACC_M003_A> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_A>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0007_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AsAccGrouplist { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsAccGrouplist
        {
            get { return _AsAccGrouplist; }
            set
            {
                if (_AsAccGrouplist != value)
                {
                    _AsAccGrouplist = value;
                    RaisePropertyChanged("AsAccGrouplist");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AsParentGrouplist { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsParentGrouplist
        {
            get { return _AsParentGrouplist; }
            set
            {
                if (_AsParentGrouplist != value)
                {
                    _AsParentGrouplist = value;
                    RaisePropertyChanged("AsParentGrouplist");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCoaKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCoaKey
        {
            get { return _ASCoaKey; }
            set
            {
                if (_ASCoaKey != value)
                {
                    _ASCoaKey = value; RaisePropertyChanged("ASCoaKey");
                }
            }
        }

        #endregion

        #region Declarations   

        private MultipleContext_ACC_M003_A _MC;
        public MultipleContext_ACC_M003_A MC
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

        private MultipleContext_ACC_M003_A _MCTemp;
        public MultipleContext_ACC_M003_A MCTemp
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


        private ACC_M003_A _MasterEntity;
        public ACC_M003_A MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }
        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M003_A> _Acc_Collection;
        public ObservableCollection<ACC_M003_A> Acc_Collection
        {
            get { return _Acc_Collection; }
            set
            {
                if (_Acc_Collection != value)
                {
                    _Acc_Collection = value;
                    RaisePropertyChanged("Acc_Collection");
                }
            }
        }

        private ICollectionView _Acc_Collection1;
        public ICollectionView Acc_Collection1
        {
            get { return _Acc_Collection1; }
            set
            {
                if (_Acc_Collection1 != value)
                {
                    _Acc_Collection1 = value;
                    RaisePropertyChanged("Acc_Collection1");
                }
            }
        }

        private List<ACC_M003_A> _SelectedList;
        public List<ACC_M003_A> SelectedList
        {
            get
            {
                return _SelectedList;
            }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return _SelectedTabControlIndex;
            }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdAccGrpCategory { get; private set; }
        public RelayCommand<object> CmdAccParentGroup { get; private set; }
        public RelayCommand<object> CmdCOAKey { get; private set; }
        public RelayCommand<object> CmdLoadDocByDocNumber { get; private set; }

        #endregion

        #region  Constructor

        public FICO_M0007_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_A();
            Acc_Collection = new ObservableCollection<ACC_M003_A>();

            MC = new MultipleContext_ACC_M003_A();
            MCTemp = new MultipleContext_ACC_M003_A();

            CmdAccGrpCategory = new RelayCommand<object>(items => { if (items == null) { return; } Insert_AccGrpCategry(items); });
            CmdAccParentGroup = new RelayCommand<object>(items => { if (items == null) { return; } Insert_AccParentGroup(items); });
            CmdCOAKey = new RelayCommand<object>(items => { if (items == null) { return; } Insert_COAKey(items); });
            CmdLoadDocByDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions

        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_A>(MC, Request, "AccountGroupCode", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                Acc_Collection = MC.AccGrouplist;
                SelectedList = Acc_Collection.ToList();

                Acc_Collection1 = CollectionViewSource.GetDefaultView(MC.AccGrouplist);
                Acc_Collection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_C_P)x).group_cat);
                TheFilter = (o, prefix) => (((ACC_M003_C_P)o).group_cat ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsAccGrouplist = new AutoSuggestTextViewModel<dynamic>(MC.GrpCategoryList, TheFilter, SuggestedValue, "group_cat", true);
                AsAccGrouplist.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_A)x).ac_group_code);
                TheFilter = (o, prefix) => (((ACC_M003_A)o).ac_group_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsParentGrouplist = new AutoSuggestTextViewModel<dynamic>(MC.AccGrouplist, TheFilter, SuggestedValue, "group_code", true);
                AsParentGrouplist.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M026_P)x).coa_key);
                TheFilter = (o, prefix) => (((ACC_M026_P)o).coa_key ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCoaKey = new AutoSuggestTextViewModel<dynamic>(MC.COAKeyList, TheFilter, SuggestedValue, "coa_key", true);
                ASCoaKey.AutoSuggestVM.IsEmptyValueAllowed = true;
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
            MasterEntity.active = true;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
        }
        private bool Validation()
        {
            if (MasterEntity.ac_group_code == null || MasterEntity.ac_group_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid Account Group Code", MasterEntity.ac_group_code);
                showMessageService.ShowMessage();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                ACC_M003_A ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ACC_M003_A>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M003_A>().ToList()[0];

                    if (MC.AccGrouplist.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;

                }
                var msg = new NotificationMessage("FICO_M0007_VM");
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity != null)
                {
                    if (isNewRecord == true)
                    {
                        Acc_Collection.Add(MasterEntity);
                        Acc_Collection1 = CollectionViewSource.GetDefaultView(Acc_Collection);
                        Acc_Collection1.Refresh();
                    }
                    else if (isNewRecord == false)
                    {
                        Acc_Collection1 = CollectionViewSource.GetDefaultView(Acc_Collection);
                        Acc_Collection1.Filter = new Predicate<object>(Filter);
                        Acc_Collection1.Refresh();
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

        private void Insert_AccGrpCategry(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_C_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.GrpCategoryList.Where(x => x.group_cat.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.group_cat_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.group_cat = POPUPEntityObject.group_cat;
                    MasterEntity.group_cat_name = POPUPEntityObject.group_cat_name;


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

        private void Insert_AccParentGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_A POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.AccGrouplist.Where(x => x.ac_group_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.ac_group_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_A>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.parent_group_code = POPUPEntityObject.ac_group_code;


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

        private void Insert_COAKey(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M026_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.COAKeyList.Where(x => x.coa_key.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M026_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.coa_key = POPUPEntityObject.coa_key;
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

        #region Abstract Command Actions
        string strReturn = "";

        protected override void OnCreateAction(InquiryActionResult<ACC_M003_A> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_A();

            DefaultValues();
        }
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M003_A>(MasterEntity, "AccountGroupCode", "Finance");

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_M003_A>(MasterEntity, "AccountGroupCode", "Finance");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
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
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_A> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_A> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_A> result)
        {

        }

        #endregion

        #region Filters

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                if (_filterString != value)
                {
                    _filterString = value;
                    RaisePropertyChanged("FilterString");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_Acc_Collection1 != null)
            {
                _Acc_Collection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {

                    return (data.ac_group_code != null && data.ac_group_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ac_group_name != null && data.ac_group_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.group_cat != null && data.group_cat.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.coa_key != null && data.coa_key.ToString().ToLower().Contains(_filterString.ToLower())

                            );
                }
                return true;
            }
            return false;
        }



        #endregion
    }
}
