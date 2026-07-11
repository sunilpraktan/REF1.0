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
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.BusinessEntity.Account;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0001_VM : WorkspaceViewModel<ACC_M013>
    {
        bool isNewRecord = true;
        WebServiceRepository<ACC_M013> repository = new WebServiceRepository<ACC_M013>();
        WebServiceRepository<MultipleContext_ACC_M013> repository_MC = new WebServiceRepository<MultipleContext_ACC_M013>();
        WebServiceRepository<MultipleContext_ACC_M013> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M013>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0001_VM));
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
                    _ASDefault = value;
                    RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInvocTaxAcc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInvocTaxAcc
        {
            get { return _ASInvocTaxAcc; }
            set
            {
                if (_ASInvocTaxAcc != value)
                {
                    _ASInvocTaxAcc = value;
                    RaisePropertyChanged("ASInvocTaxAcc");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccBaseCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccBaseCode
        {
            get { return _ASAccBaseCode; }
            set
            {
                if (_ASAccBaseCode != value)
                {
                    _ASAccBaseCode = value;
                    RaisePropertyChanged("ASAccBaseCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccTaxCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccTaxCode
        {
            get { return _ASAccTaxCode; }
            set
            {
                if (_ASAccTaxCode != value)
                {
                    _ASAccTaxCode = value;
                    RaisePropertyChanged("ASAccTaxCode");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASRefundTaxAcc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefundTaxAcc
        {
            get { return _ASRefundTaxAcc; }
            set
            {
                if (_ASRefundTaxAcc != value)
                {
                    _ASRefundTaxAcc = value;
                    RaisePropertyChanged("ASRefundTaxAcc");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASRefBaseCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefBaseCode
        {
            get { return _ASRefBaseCode; }
            set
            {
                if (_ASRefBaseCode != value)
                {
                    _ASRefBaseCode = value;
                    RaisePropertyChanged("ASRefBaseCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRefTaxCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefTaxCode
        {
            get { return _ASRefTaxCode; }
            set
            {
                if (_ASRefTaxCode != value)
                {
                    _ASRefTaxCode = value;
                    RaisePropertyChanged("ASRefTaxCode");
                }
            }
        }

        #endregion

        #region Declarations   

        private MultipleContext_ACC_M013 _MC;
        public MultipleContext_ACC_M013 MC
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

        private MultipleContext_ACC_M013 _MCTemp;
        public MultipleContext_ACC_M013 MCTemp
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


        private ACC_M013 _MasterEntity;
        public ACC_M013 MasterEntity
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

        private ObservableCollection<ACC_M013> _Tax_Collection;
        public ObservableCollection<ACC_M013> Tax_Collection
        {
            get { return _Tax_Collection; }
            set
            {
                if (_Tax_Collection != value)
                {
                    _Tax_Collection = value;
                    RaisePropertyChanged("Tax_Collection");
                }
            }
        }

        private ICollectionView _Tax_Collection1;
        public ICollectionView Tax_Collection1
        {
            get { return _Tax_Collection1; }
            set
            {
                if (_Tax_Collection1 != value)
                {
                    _Tax_Collection1 = value;
                    RaisePropertyChanged("Tax_Collection1");
                }
            }
        }

        private List<ACC_M013> _SelectedList;
        public List<ACC_M013> SelectedList
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

        public RelayCommand<object> CmdInvocTaxAcc { get; private set; }

        public RelayCommand<object> CmdAccBaseCode { get; private set; }

        public RelayCommand<object> CmdAccTaxCode { get; private set; }

        public RelayCommand<object> CmdRefundTaxAcc { get; private set; }

        public RelayCommand<object> CmdRefBaseCode { get; private set; }

        public RelayCommand<object> CmdRefTaxCode { get; private set; }

        public RelayCommand<object> CmdLoadDocByDocNumber { get; private set; }

        #endregion

        #region  Constructor

        public FICO_M0001_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M013();
            Tax_Collection = new ObservableCollection<ACC_M013>();

            MC = new MultipleContext_ACC_M013();
            MCTemp = new MultipleContext_ACC_M013();

            CmdInvocTaxAcc = new RelayCommand<object>(items => { if (items == null) { return; } Insert_InvocTaxAcc(items); });
            CmdAccBaseCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_AccBaseCode(items); });
            CmdAccTaxCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_AccTaxCode(items); });
            CmdRefundTaxAcc = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefundTaxAcc(items); });
            CmdRefBaseCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefBaseCode(items); });
            CmdRefTaxCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefTaxCode(items); });
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M013>(MC, Request, "Tax_Master", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                Tax_Collection = MC.Tax_Master;
                SelectedList = Tax_Collection.ToList();

                Tax_Collection1 = CollectionViewSource.GetDefaultView(MC.Tax_Master);
                Tax_Collection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).p_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).p_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Acc_AccountDtls, TheFilter, SuggestedValue, "p_code", "p_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).p_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).p_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInvocTaxAcc = new AutoSuggestTextViewModel<dynamic>(MC.Acc_AccountDtls, TheFilter, SuggestedValue, "p_code", true);
                ASInvocTaxAcc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M014_P)x).t_code);
                TheFilter = (o, prefix) => (((ACC_M014_P)o).t_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccBaseCode = new AutoSuggestTextViewModel<dynamic>(MC.Acc_Tax_CodeDtls, TheFilter, SuggestedValue, "t_code", true);
                ASAccBaseCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M014_P)x).t_code);
                TheFilter = (o, prefix) => (((ACC_M014_P)o).t_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccTaxCode = new AutoSuggestTextViewModel<dynamic>(MC.Acc_Tax_CodeDtls, TheFilter, SuggestedValue, "t_code", true);
                ASAccTaxCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).p_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).p_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRefundTaxAcc = new AutoSuggestTextViewModel<dynamic>(MC.Acc_AccountDtls, TheFilter, SuggestedValue, "p_code", true);
                ASRefundTaxAcc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M014_P)x).t_code);
                TheFilter = (o, prefix) => (((ACC_M014_P)o).t_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRefBaseCode = new AutoSuggestTextViewModel<dynamic>(MC.Acc_Tax_CodeDtls, TheFilter, SuggestedValue, "t_code", true);
                ASRefBaseCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M014_P)x).t_code);
                TheFilter = (o, prefix) => (((ACC_M014_P)o).t_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRefTaxCode = new AutoSuggestTextViewModel<dynamic>(MC.Acc_Tax_CodeDtls, TheFilter, SuggestedValue, "t_code", true);
                ASRefTaxCode.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.edit_by = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.client = AppSessionState.client; 

        }

        private bool Validation()
        {
            if (MasterEntity.tax_code == null || MasterEntity.tax_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid Tax Code", MasterEntity.tax_code);
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
                ACC_M013 ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ACC_M013>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M013>().ToList()[0];

                    if (MC.Tax_Master.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

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
                if (MasterEntity != null)
                {
                    Tax_Collection.Add(MasterEntity);
                    Tax_Collection1 = CollectionViewSource.GetDefaultView(Tax_Collection);
                    Tax_Collection1.Refresh();
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


        private void Insert_InvocTaxAcc(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.Acc_AccountDtls.Where(x => x.p_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.p_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.account_collected_id = POPUPEntityObject.id;
                    MasterEntity.InvocTaxAcc = POPUPEntityObject.p_name;


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

        private void Insert_AccBaseCode(object InputValue)
        {
            string Request = "";
            ACC_M014_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Acc_Tax_CodeDtls.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    MasterEntity.base_code_id = POPUPEntityObject.id;
                    MasterEntity.AccBaseCd = POPUPEntityObject.t_name;
                }
            }
            catch (Exception ex) { }
        }

        private void Insert_AccTaxCode(object InputValue)
        {
            string Request = "";
            ACC_M014_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Acc_Tax_CodeDtls.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {

                    MasterEntity.tax_code_id = POPUPEntityObject.id;
                    MasterEntity.AccTaxCd = POPUPEntityObject.t_name;
                }
            }
            catch (Exception ex) { }
        }

        private void Insert_RefundTaxAcc(object InputValue)
        {
            string Request = "";
            ACC_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Acc_AccountDtls.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.p_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {

                    MasterEntity.account_paid_id = POPUPEntityObject.id;
                    MasterEntity.RefTaxAcc = POPUPEntityObject.p_name;
                }
            }
            catch (Exception ex) { }
        }

        private void Insert_RefBaseCode(object InputValue)
        {
            string Request = "";
            ACC_M014_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Acc_Tax_CodeDtls.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {

                    MasterEntity.ref_base_code_id = POPUPEntityObject.id;
                    MasterEntity.RefBaseCd = POPUPEntityObject.t_name;
                }
            }
            catch (Exception ex) { }
        }


        private void Insert_RefTaxCode(object InputValue)
        {
            string Request = "";
            ACC_M014_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Acc_Tax_CodeDtls.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {

                    MasterEntity.ref_tax_code_id = POPUPEntityObject.id;
                    MasterEntity.RefTaxCd = POPUPEntityObject.t_name;
                }
            }
            catch (Exception ex) { }
        }


        #endregion

        #region Abstract Command Actions
        string strReturn = "";

        protected override void OnSaveAction(InquiryActionResult<ACC_M013> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.edit_by = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M013>(MasterEntity, "Tax_Master", "Administration");

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_M013>(MasterEntity, "Tax_Master", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ACC_M013> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M013();

            DefaultValues();
        }

        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M013> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M013> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M013> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M013> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M013> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M013> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<ACC_M013> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ACC_M013> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ACC_M013> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ACC_M013> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ACC_M013> result)
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
            if (_Tax_Collection1 != null)
            {
                _Tax_Collection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M013;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.t_name != null && data.t_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.tax_code != null && data.tax_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.applicable_type != null && data.applicable_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.type_tax_use != null && data.type_tax_use.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.t_type != null && data.t_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.description != null && data.description.ToString().ToLower().Contains(_filterString.ToLower())

                            );
                }
                return true;
            }
            return false;
        }





        #endregion
    }
}
