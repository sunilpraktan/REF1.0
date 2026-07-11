using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.ObjectModel;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using System.IO;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.FICO.ViewModels
{
    class FICO_M0016_VM : WorkspaceViewModel<ACC_M003_T>
    {
        static int i;

        #region .Object Initilization.

        public string TrnsKeyCode;
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_T>> repository = new WebServiceRepository<List<ACC_M003_T>>();
        WebServiceRepository<MultipleContext_ACC_M003_T> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_T>();
        WebServiceRepository<MultipleContext_ACC_M003_T> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003_T>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #endregion

        #region .AutoSuggest TextBox Declaration Region.
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0016_VM));
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
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccVar { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccVar
        {
            get { return _ASAccVar; }
            set
            {
                if (_ASAccVar != value)
                {
                    _ASAccVar = value; RaisePropertyChanged("ASAccVar");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASValueGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValueGroup
        {
            get { return _ASValueGroup; }
            set
            {
                if (_ASValueGroup != value)
                {
                    _ASValueGroup = value; RaisePropertyChanged("ASValueGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASValueClass { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValueClass
        {
            get { return _ASValueClass; }
            set
            {
                if (_ASValueClass != value)
                {
                    _ASValueClass = value; RaisePropertyChanged("ASValueClass");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTaxCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxCode
        {
            get { return _ASTaxCode; }
            set
            {
                if (_ASTaxCode != value)
                {
                    _ASTaxCode = value; RaisePropertyChanged("ASTaxCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBussPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBussPlace
        {
            get { return _ASBussPlace; }
            set
            {
                if (_ASBussPlace != value)
                {
                    _ASBussPlace = value; RaisePropertyChanged("ASBussPlace");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDebit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDebit
        {
            get { return _ASDebit; }
            set
            {
                if (_ASDebit != value)
                {
                    _ASDebit = value; RaisePropertyChanged("ASDebit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCredit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCredit
        {
            get { return _ASCredit; }
            set
            {
                if (_ASCredit != value)
                {
                    _ASCredit = value; RaisePropertyChanged("ASCredit");
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
            try
            {
                if (dgCellInfo != null)
                {
                    var column = dgCellInfo.Column as DataGridColumn;
                    if (column != null)
                    {
                        string headerName = column.Header.ToString();
                        string SourceName = column.SortMemberPath.ToString();

                        if (SourceName == "acc_var")
                        { ASDefault = ASAccVar; }
                        else if (SourceName == "value_group")
                        { ASDefault = ASValueGroup; }
                        else if (SourceName == "value_class")
                        { ASDefault = ASValueClass; }
                        else if (SourceName == "gl_code_d")
                        { ASDefault = ASDebit; }
                        else if (SourceName == "tax_code")
                        { ASDefault = ASTaxCode; }
                        else if (SourceName == "buss_place")
                        { ASDefault = ASBussPlace; }
                        else if (SourceName == "gl_code_c")
                        { ASDefault = ASCredit; }
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

        #endregion

        #region .Variable Declaration.
        private MultipleContext_ACC_M003_T _MC;
        public MultipleContext_ACC_M003_T MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_T _MCTemp;
        public MultipleContext_ACC_M003_T MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ACC_M003_T _MCTemp1;
        public MultipleContext_ACC_M003_T MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ACC_M003_T _MasterEntity;
        public ACC_M003_T MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private ObservableCollection<ACC_M003_T> _DetailEntity;
        public ObservableCollection<ACC_M003_T> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value; RaisePropertyChanged("DetailEntity");
                }
            }
        }

        private ACC_M003_F _PostingRulesEntity;
        public ACC_M003_F PostingRulesEntity
        {
            get { return _PostingRulesEntity; }
            set
            {
                if (_PostingRulesEntity != value)
                {
                    _PostingRulesEntity = value; RaisePropertyChanged("PostingRulesEntity");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            { return _dgSelectedIndex; }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }

        private bool _AccVar_VisibilityFlag;   //visibility of Datagrid Column Account Group 
        public bool AccVar_VisibilityFlag
        {
            get { return _AccVar_VisibilityFlag; }
            set { _AccVar_VisibilityFlag = value; RaisePropertyChanged("AccVar_VisibilityFlag"); }
        }

        private bool _ValueGroup_VisibilityFlag;   //visibility of Datagrid Column value cat
        public bool ValueGroup_VisibilityFlag
        {
            get { return _ValueGroup_VisibilityFlag; }
            set { _ValueGroup_VisibilityFlag = value; RaisePropertyChanged("ValueGroup_VisibilityFlag"); }
        }

        private bool _ValueClass_VisibilityFlag;   //visibility of Datagrid Column Value class
        public bool ValueClass_VisibilityFlag
        {
            get { return _ValueClass_VisibilityFlag; }
            set { _ValueClass_VisibilityFlag = value; RaisePropertyChanged("ValueClass_VisibilityFlag"); }
        }

        private bool _TaxCode_VisibilityFlag;   //visibility of Datagrid Column Value class
        public bool TaxCode_VisibilityFlag
        {
            get { return _TaxCode_VisibilityFlag; }
            set { _TaxCode_VisibilityFlag = value; RaisePropertyChanged("TaxCode_VisibilityFlag"); }
        }

        private bool _BussPlace_VisibilityFlag;   //visibility of Datagrid Column Value class
        public bool BussPlace_VisibilityFlag
        {
            get { return _BussPlace_VisibilityFlag; }
            set { _BussPlace_VisibilityFlag = value; RaisePropertyChanged("BussPlace_VisibilityFlag"); }
        }

        private bool _Debit_VisibilityFlag;   //visibility of Datagrid Column debit
        public bool Debit_VisibilityFlag
        {
            get { return _Debit_VisibilityFlag; }
            set { _Debit_VisibilityFlag = value; RaisePropertyChanged("Debit_VisibilityFlag"); }
        }

        private bool _Credit_VisibilityFlag;   //visibility of Datagrid Column credit
        public bool Credit_VisibilityFlag
        {
            get { return _Credit_VisibilityFlag; }
            set { _Credit_VisibilityFlag = value; RaisePropertyChanged("Credit_VisibilityFlag"); }
        }
        #endregion

        #region .ICollectionView.

        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set
            {
                if (_DataGridCollection != value)
                {
                    _DataGridCollection = value;
                    RaisePropertyChanged("DataGridCollection");
                }
            }
        }

        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }

        private List<ACC_M003_T> _SelectedList;
        public List<ACC_M003_T> SelectedList
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region .Relay Commands Declaration.       
        public RelayCommand<object> cmdDefineRulesforKey { get; private set; }
        public RelayCommand<object> cmdDefinePostingKey { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDetail { get; private set; }

        #region .Relay Commands for Pop_UP.
        public RelayCommand<object> cmdInsertAccGroup { get; private set; }
        public RelayCommand<object> cmdInsertValueGroup { get; private set; }
        public RelayCommand<object> cmdInsertValueClass { get; private set; }
        public RelayCommand<object> cmdInsertDebitAccount { get; private set; }
        public RelayCommand<object> cmdInsertCreditAccount { get; private set; }
        public RelayCommand<object> cmdInsertTaxCode { get; private set; }
        public RelayCommand<object> cmdInsertBussPlace { get; private set; }
        #endregion

        #endregion

        #region .Functions for Datagird Pop_Up.

        private void InsertAccGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_H POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountGroupList.Where(x => x.acc_group.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_H>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_H>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].acc_var = POPUPEntityObject.acc_group;
                    }
                    else if (DetailEntity[dgSelectedIndex].acc_var != POPUPEntityObject.acc_group)
                    {
                        DetailEntity[dgSelectedIndex].acc_var = POPUPEntityObject.acc_group;
                        DetailEntity[dgSelectedIndex].group_desc = POPUPEntityObject.group_desc;
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
        private void InsertValueGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_G POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ValueGroupList.Where(x => x.value_group.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_G>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_G>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].value_group = POPUPEntityObject.value_group;
                    }
                    else if (DetailEntity[dgSelectedIndex].value_group != POPUPEntityObject.value_group)
                    {
                        DetailEntity[dgSelectedIndex].value_group = POPUPEntityObject.value_group;
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
        private void InsertValueClass(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_V POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ValueClassList.Where(x => x.value_class.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_V>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_V>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].value_class = POPUPEntityObject.value_class;
                    }
                    else if (DetailEntity[dgSelectedIndex].value_class != POPUPEntityObject.value_class)
                    {
                        DetailEntity[dgSelectedIndex].value_class = POPUPEntityObject.value_class;
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
        private void InsertDebitAccount(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GLCodeDebitList.Where(x => x.gl_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].gl_code_d = POPUPEntityObject.gl_code;
                        DetailEntity[dgSelectedIndex].gl_desc_d = POPUPEntityObject.gl_name;
                    }
                    else if (DetailEntity[dgSelectedIndex].gl_code_d != POPUPEntityObject.gl_code)
                    {
                        DetailEntity[dgSelectedIndex].gl_code_d = POPUPEntityObject.gl_code;
                        DetailEntity[dgSelectedIndex].gl_desc_d = POPUPEntityObject.gl_name;
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
        private void InsertCreditAccount(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GLCodeCreditList.Where(x => x.gl_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].gl_code_c = POPUPEntityObject.gl_code;
                        DetailEntity[dgSelectedIndex].gl_desc_c = POPUPEntityObject.gl_name;
                    }
                    else if (DetailEntity[dgSelectedIndex].gl_code_c != POPUPEntityObject.gl_code)
                    {
                        DetailEntity[dgSelectedIndex].gl_code_c = POPUPEntityObject.gl_code;
                        DetailEntity[dgSelectedIndex].gl_desc_c = POPUPEntityObject.gl_name;
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
        private void InsertTaxCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M013_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaxCodeList.Where(x => x.tax_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M013_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].tax_code = POPUPEntityObject.tax_code;
                    }
                    else if (DetailEntity[dgSelectedIndex].tax_code != POPUPEntityObject.tax_code)
                    {
                        DetailEntity[dgSelectedIndex].tax_code = POPUPEntityObject.tax_code;
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
        private void InsertBussPlace(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_C_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BussPlaceList.Where(x => x.buss_place.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003_C_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndex].id == 0 && DetailEntity.Count > dgSelectedIndex) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndex].buss_place = POPUPEntityObject.buss_place;
                    }
                    else if (DetailEntity[dgSelectedIndex].buss_place != POPUPEntityObject.buss_place)
                    {
                        DetailEntity[dgSelectedIndex].buss_place = POPUPEntityObject.buss_place;
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

        private void InsertDebitAccount_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GLCodeDebitList.Where(x => x.gl_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    //var InputValueIfExists = DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_name).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true) && DetailEntity.Count == dgSelectedIndex)
                    {
                        DetailEntity.Add(new ACC_M003_T()
                        {

                            id = 0,
                            gl_code_d = POPUPEntityObject.gl_code,
                            gl_desc_d = POPUPEntityObject.gl_name,
                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                            client = AppSessionState.client
                        });
                    }
                    else if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            DetailEntity[dgSelectedIndex].gl_code_d = POPUPEntityObject.gl_code;
                            DetailEntity[dgSelectedIndex].gl_desc_d = POPUPEntityObject.gl_name;
                            DetailEntity[dgSelectedIndex].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                            DetailEntity[dgSelectedIndex].client = AppSessionState.client;
                        }
                        else if (DetailEntity[dgSelectedIndex].gl_code_d != POPUPEntityObject.gl_code)
                        {
                            DetailEntity[dgSelectedIndex].gl_code_d = POPUPEntityObject.gl_code;
                            DetailEntity[dgSelectedIndex].gl_desc_d = POPUPEntityObject.gl_name;
                            DetailEntity[dgSelectedIndex].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                            DetailEntity[dgSelectedIndex].client = AppSessionState.client;
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
        private void InsertCreditAccount_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GLCodeCreditList.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DetailEntity.Where(X => X.gl_code_c == POPUPEntityObject.gl_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.gl_code_c == POPUPEntityObject.gl_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndex].gl_code_c = POPUPEntityObject.gl_code;
                            DetailEntity[dgSelectedIndex].gl_desc_c = POPUPEntityObject.gl_name;
                        }
                        else if (DetailEntity[dgSelectedIndex].gl_desc_c != POPUPEntityObject.gl_code)
                        {
                            DetailEntity[dgSelectedIndex].gl_code_c = POPUPEntityObject.gl_code;
                            DetailEntity[dgSelectedIndex].gl_desc_c = POPUPEntityObject.gl_name;
                        }
                    }

                }
                #region Clear Empty Row
                ACC_M003_T newObj = new ACC_M003_T();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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
        private void InsertAccGroup_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_H POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountGroupList.Where(x => x.acc_group.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_H>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DetailEntity.Where(X => X.acc_var == POPUPEntityObject.acc_group).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.acc_var == POPUPEntityObject.acc_group).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndex].acc_var = POPUPEntityObject.acc_group;
                        }
                        else if (DetailEntity[dgSelectedIndex].acc_var != POPUPEntityObject.acc_group)
                        {
                            DetailEntity[dgSelectedIndex].acc_var = POPUPEntityObject.acc_group;
                        }
                    }

                }
                #region Clear Empty Row
                ACC_M003_T newObj = new ACC_M003_T();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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
        private void InsertValueGroup_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_G POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ValueGroupList.Where(x => x.value_group.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_G>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DetailEntity.Where(X => X.value_group == POPUPEntityObject.value_group).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.value_group == POPUPEntityObject.value_group).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndex].value_group = POPUPEntityObject.value_group;
                        }
                        else if (DetailEntity[dgSelectedIndex].value_group != POPUPEntityObject.value_group)
                        {
                            DetailEntity[dgSelectedIndex].value_group = POPUPEntityObject.value_group;
                        }
                    }

                }
                #region Clear Empty Row
                ACC_M003_T newObj = new ACC_M003_T();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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
        private void InsertValueClass_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M003_V POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ValueClassList.Where(x => x.value_class.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_V>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DetailEntity.Where(X => X.value_class == POPUPEntityObject.value_class).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.value_class == POPUPEntityObject.value_class).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndex].value_class = POPUPEntityObject.value_class;
                        }
                        else if (DetailEntity[dgSelectedIndex].value_class != POPUPEntityObject.value_class)
                        {
                            DetailEntity[dgSelectedIndex].value_class = POPUPEntityObject.value_class;
                        }
                    }

                }
                #region Clear Empty Row
                ACC_M003_T newObj = new ACC_M003_T();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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
        private void InsertTaxCode_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M013_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaxCodeList.Where(x => x.tax_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DetailEntity.Where(X => X.tax_code == POPUPEntityObject.tax_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.tax_code == POPUPEntityObject.tax_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndex].tax_code = POPUPEntityObject.tax_code;
                            DetailEntity[dgSelectedIndex].tax_code_desc = POPUPEntityObject.description;
                        }
                        else if (DetailEntity[dgSelectedIndex].tax_code != POPUPEntityObject.tax_code)
                        {
                            DetailEntity[dgSelectedIndex].tax_code = POPUPEntityObject.tax_code;
                            DetailEntity[dgSelectedIndex].tax_code_desc = POPUPEntityObject.description;
                        }
                    }

                }
                #region Clear Empty Row
                ACC_M003_T newObj = new ACC_M003_T();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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
        private void InsertBussPlace_New(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_C_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BussPlaceList.Where(x => x.buss_place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DetailEntity.Where(X => X.buss_place == POPUPEntityObject.buss_place).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.buss_place == POPUPEntityObject.buss_place).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && DetailEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndex].buss_place = POPUPEntityObject.buss_place;
                            DetailEntity[dgSelectedIndex].buss_Place_desc = POPUPEntityObject.plc_name;
                        }
                        else if (DetailEntity[dgSelectedIndex].buss_place != POPUPEntityObject.buss_place)
                        {
                            DetailEntity[dgSelectedIndex].buss_place = POPUPEntityObject.buss_place;
                            DetailEntity[dgSelectedIndex].buss_Place_desc = POPUPEntityObject.plc_name;
                        }
                    }

                }
                #region Clear Empty Row
                ACC_M003_T newObj = new ACC_M003_T();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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
        #endregion

        #region .Event Handler.

        #endregion

        #region .Constructor.
        public FICO_M0016_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_T();
            DetailEntity = new ObservableCollection<ACC_M003_T>();

            MC = new MultipleContext_ACC_M003_T();
            MCTemp = new MultipleContext_ACC_M003_T();
            MCTemp1 = new MultipleContext_ACC_M003_T();

            #region .Command Initialisation.

            cmdDefineRulesforKey = new RelayCommand<object>(items => { if (items == null) { return; } View_DefineRulesforKey(items); });
            cmdDefinePostingKey = new RelayCommand<object>(items => { if (items == null) { return; } View_DefinePostingKey(items); });
            cmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });

            #region .Command Initialisation for Pop_UP.

            cmdInsertDebitAccount = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDebitAccount_New(cmdPara, true, true, true); });
            cmdInsertCreditAccount = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCreditAccount_New(cmdPara, false, true, true); });
            cmdInsertAccGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccGroup_New(cmdPara, false, true, true); });
            cmdInsertValueGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertValueGroup_New(cmdPara, false, true, true); });
            cmdInsertValueClass = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertValueClass_New(cmdPara, false, true, true); });
            cmdInsertTaxCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTaxCode_New(cmdPara, false, true, true); });
            cmdInsertBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBussPlace_New(cmdPara, false, true, true); });

            //cmdInsertAccGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccGroup(cmdPara, false, true, true); });
            //cmdInsertValueGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertValueGroup(cmdPara, false, true, true); });
            //cmdInsertValueClass = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertValueClass(cmdPara, false, true, true); });
            //cmdInsertDebitAccount = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDebitAccount(cmdPara, false, true, true); });
            //cmdInsertCreditAccount = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCreditAccount(cmdPara, false, true, true); });
            //cmdInsertTaxCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTaxCode(cmdPara, false, true, true); });
            //cmdInsertBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBussPlace(cmdPara, false, true, true); });
            #endregion
            #endregion

            try
            {
                if ((AppSessionState.TransValue != null && AppSessionState.TransValue.ToString() != "")
                    && (AppSessionState.TransParameter != null && AppSessionState.TransParameter.ToString() != "")
                    && (AppSessionState.TransValueType.ToString() == "FROM_ACC_M003_E_VM"))
                {
                    LoadInitialData(AppSessionState.TransValue.ToString(), AppSessionState.TransParameter.ToString());
                    AppSessionState.TransValue = null;
                    AppSessionState.TransParameter = null;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else if ((AppSessionState.TransValue != null && AppSessionState.TransValue.ToString() != "")
                        && (AppSessionState.TransParameter != null && AppSessionState.TransParameter.ToString() != "")
                        && (AppSessionState.TransValueType.ToString() == "FROM_ACC_M003_F_VM"))
                {
                    LoadDataAfterDefiningRules(AppSessionState.TransValue.ToString(), AppSessionState.TransParameter.ToString());
                    AppSessionState.TransValue = null;
                    AppSessionState.TransParameter = null;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = "Please select Transaction Key Code To Define Rules";
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

        #endregion

        #region .User Defined Functions.
        private void LoadInitialData(string TempTrnsKeyCode, string strCOAKey)
        {
            try
            {
                string Request = "LoadPostingDetreminationData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + TempTrnsKeyCode + "!@" + strCOAKey + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_T>(MC, Request, "AccountDeterminationKey", "Finance", "LoadPostingDetreminationData", 0, "");

                MasterEntity.trns_key_code = TempTrnsKeyCode;
                MasterEntity.coa_key = strCOAKey;

                if (MC.DetailEntityList != null)
                {
                    DetailEntity.Clear();
                    DetailEntity = MC.DetailEntityList;

                    if (MC.PostingKeyRulesList != null && MC.PostingKeyRulesList.Count > 0)
                    {

                        PostingRulesEntity = MC.PostingKeyRulesList[0];

                        if (PostingRulesEntity.acc_var == true)
                        {
                            AccVar_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H)x).acc_group);
                            TheFilter = (o, prefix) => (((ACC_M003_H)o).acc_group ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_H)o).acc_group_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASAccVar = new AutoSuggestTextViewModel<dynamic>(MC.AccountGroupList, TheFilter, SuggestedValue, "acc_var", "acc_group", false);
                            ASAccVar.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASAccVar.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            AccVar_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.value_group == true)
                        {
                            ValueGroup_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_G)x).value_group);
                            TheFilter = (o, prefix) => (((ACC_M003_G)o).value_group ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_G)o).val_area ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASValueGroup = new AutoSuggestTextViewModel<dynamic>(MC.ValueGroupList, TheFilter, SuggestedValue, "value_group", "value_group", false);
                            ASValueGroup.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASValueGroup.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            ValueGroup_VisibilityFlag = false;
                        }
                        if (PostingRulesEntity.value_class == true)
                        {
                            ValueClass_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_V)x).value_class);
                            TheFilter = (o, prefix) => (((ACC_M003_V)o).value_class ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_V)o).acc_cat ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASValueClass = new AutoSuggestTextViewModel<dynamic>(MC.ValueClassList, TheFilter, SuggestedValue, "value_class", "value_class", false);
                            ASValueClass.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASValueClass.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            ValueClass_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.tax_code == true)
                        {
                            TaxCode_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).tax_code);
                            TheFilter = (o, prefix) => (((ACC_M013_P)o).tax_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M013_P)o).description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASTaxCode = new AutoSuggestTextViewModel<dynamic>(MC.TaxCodeList, TheFilter, SuggestedValue, "tax_code", "tax_code", false);
                            ASTaxCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASTaxCode.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            TaxCode_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.buss_place == true)
                        {
                            BussPlace_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                            TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASBussPlace = new AutoSuggestTextViewModel<dynamic>(MC.BussPlaceList, TheFilter, SuggestedValue, "buss_place", "buss_place", false);
                            ASBussPlace.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASBussPlace.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            BussPlace_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.drcr == true)
                        {
                            Debit_VisibilityFlag = true;
                            Credit_VisibilityFlag = true;

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.GLCodeDebitList);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASDebit = new AutoSuggestTextViewModel<dynamic>(MC.GLCodeDebitList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", true);
                            ASDebit.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDebit.AutoSuggestVM.IsFreeTextAllowed = false;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASCredit = new AutoSuggestTextViewModel<dynamic>(MC.GLCodeCreditList, TheFilter, SuggestedValue, "gl_code_c", "gl_code", true);
                            ASCredit.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASCredit.AutoSuggestVM.IsFreeTextAllowed = false;

                        }
                        else if (PostingRulesEntity.drcr == false || PostingRulesEntity.drcr == null)
                        {
                            Debit_VisibilityFlag = true;

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.GLCodeDebitList);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASDebit = new AutoSuggestTextViewModel<dynamic>(MC.GLCodeDebitList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", true);
                            ASDebit.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDebit.AutoSuggestVM.IsFreeTextAllowed = false;
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                        TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                        ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.GL_CodeList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", true);
                        ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                    }
                    else
                    {

                        //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //showMessageService.ButtonSetup = DialogButton.Ok;
                        //showMessageService.Caption = "Message";
                        //showMessageService.Text = ("Please Define rules for Transaction Key code");
                        //showMessageService.ShowMessage();

                        AccVar_VisibilityFlag = false;
                        ValueGroup_VisibilityFlag = false;
                        ValueClass_VisibilityFlag = false;
                        TaxCode_VisibilityFlag = false;
                        BussPlace_VisibilityFlag = false;
                        Debit_VisibilityFlag = false;
                        Credit_VisibilityFlag = false;
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
        private void LoadDataAfterDefiningRules(string TempTrnsKeyCode, string strCOAKey)
        {
            try
            {
                string Request = "LoadDataAfterDefiningRules" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + TempTrnsKeyCode + "!@" + strCOAKey + "!@" + AppSessionState.client;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_T>(MCTemp, Request, "AccountDeterminationKey", "Finance", "LoadDataAfterDefiningRules", 0, "");

                DefaultValues();

                MasterEntity.trns_key_code = TempTrnsKeyCode;
                MasterEntity.coa_key = strCOAKey;
                //  MasterEntity.trns_key_code = TempTrnsKeyCode;

                if (MCTemp.DetailEntityList != null)
                {
                    DetailEntity.Clear();
                    DetailEntity = MCTemp.DetailEntityList;

                    if (MCTemp.PostingKeyRulesList != null && MCTemp.PostingKeyRulesList.Count > 0)
                    {
                        PostingRulesEntity = MCTemp.PostingKeyRulesList[0];

                        if (PostingRulesEntity.acc_var == true)
                        {
                            AccVar_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H)x).acc_group);
                            TheFilter = (o, prefix) => (((ACC_M003_H)o).acc_group ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_H)o).acc_group_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASAccVar = new AutoSuggestTextViewModel<dynamic>(MCTemp.AccountGroupList, TheFilter, SuggestedValue, "acc_var", "acc_group", false);
                            ASAccVar.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASAccVar.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            AccVar_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.value_group == true)
                        {
                            ValueGroup_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_G)x).value_group);
                            TheFilter = (o, prefix) => (((ACC_M003_G)o).value_group ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_G)o).val_area ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASValueGroup = new AutoSuggestTextViewModel<dynamic>(MCTemp.ValueGroupList, TheFilter, SuggestedValue, "value_group", "value_group", false);
                            ASValueGroup.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASValueGroup.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            ValueGroup_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.value_class == true)
                        {
                            ValueClass_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_V)x).value_class);
                            TheFilter = (o, prefix) => (((ACC_M003_V)o).value_class ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_V)o).acc_cat ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASValueClass = new AutoSuggestTextViewModel<dynamic>(MCTemp.ValueClassList, TheFilter, SuggestedValue, "value_class", "value_class", false);
                            ASValueClass.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASValueClass.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            ValueClass_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.tax_code == true)
                        {
                            TaxCode_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).tax_code);
                            TheFilter = (o, prefix) => (((ACC_M013_P)o).tax_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M013_P)o).description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASTaxCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.TaxCodeList, TheFilter, SuggestedValue, "tax_code", "tax_code", false);
                            ASTaxCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            /// ASTaxCode.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            TaxCode_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.buss_place == true)
                        {
                            BussPlace_VisibilityFlag = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                            TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASBussPlace = new AutoSuggestTextViewModel<dynamic>(MCTemp.BussPlaceList, TheFilter, SuggestedValue, "buss_place", "buss_place", false);
                            ASBussPlace.AutoSuggestVM.IsEmptyValueAllowed = true;
                            // ASBussPlace.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else
                        {
                            BussPlace_VisibilityFlag = false;
                        }

                        if (PostingRulesEntity.drcr == true)
                        {
                            Debit_VisibilityFlag = true;
                            Credit_VisibilityFlag = true;

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.GLCodeDebitList);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASDebit = new AutoSuggestTextViewModel<dynamic>(MCTemp.GLCodeDebitList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", true);
                            ASDebit.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDebit.AutoSuggestVM.IsFreeTextAllowed = false;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASCredit = new AutoSuggestTextViewModel<dynamic>(MCTemp.GLCodeCreditList, TheFilter, SuggestedValue, "gl_code_c", "gl_code", true);
                            ASCredit.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASCredit.AutoSuggestVM.IsFreeTextAllowed = false;
                        }
                        else if (PostingRulesEntity.drcr == false || PostingRulesEntity.drcr == null)
                        {
                            Debit_VisibilityFlag = true;

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.GLCodeDebitList);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASDebit = new AutoSuggestTextViewModel<dynamic>(MCTemp.GLCodeDebitList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", true);
                            ASDebit.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDebit.AutoSuggestVM.IsFreeTextAllowed = false;
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                        TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                        ASDefault = new AutoSuggestTextViewModel<dynamic>(MCTemp.GLCodeDebitList, TheFilter, SuggestedValue, "gl_code_d", "gl_code", true);
                        ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDefault.AutoSuggestVM.IsFreeTextAllowed = false;
                    }
                    else
                    {

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = ("Please Define rules for Transaction Key code");
                        showMessageService.ShowMessage();

                        AccVar_VisibilityFlag = false;
                        ValueGroup_VisibilityFlag = false;
                        ValueClass_VisibilityFlag = false;
                        TaxCode_VisibilityFlag = false;
                        BussPlace_VisibilityFlag = false;
                        Debit_VisibilityFlag = false;
                        Credit_VisibilityFlag = false;
                    }
                }
                //var msg = new NotificationMessage("FICO_M0016_VM");
                //Messenger.Default.Send<NotificationMessage>(msg);   
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
            //    MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            //    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            //    MasterEntity.add_by = AppSessionState.UserID;
            //    MasterEntity.editby = AppSessionState.UserID;
            //    MasterEntity.entry_dt = DateTime.Now;
            //    MasterEntity.active = true;
            //    MasterEntity.doc_cat = "FR";
            //    MasterEntity.doc_type = "FR";
            //    MasterEntity.user_source1 = AppSessionState.UserSource1;
            //    MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void View_DefineRulesforKey(object InputValue)
        {
            try
            {
                //string tranCode;
                //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                if ((MasterEntity.trns_key_code != null && MasterEntity.trns_key_code != "")
                    && (MasterEntity.coa_key != null && MasterEntity.coa_key != ""))
                {

                    //var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == "ACC_M003_FRules").FirstOrDefault();
                    //userAuth = docdetails;
                    //AppSessionState.UserAuthSingle = userAuth;
                    AppSessionState.ViewTitle = "Account Determination Rules";
                    AppSessionState.TransValue = MasterEntity.trns_key_code + "!@" + MasterEntity.coa_key;
                    AppSessionState.TransValueType = "FROM_FICO_M0016_VM";
                    AppSessionState.TransParameter = "FromAccountDeterminationKey";
                    AppSessionState.ViewOtherRecordAllowed = true;
                    //AppSessionState.TransId = userAuth.id.ToString();
                    //AppSessionState.TransactionCode = userAuth.TranCode;
                }


                //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //{
                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType("Reflection.Modules.Finance.Views.AccountDeterminationRule");
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    // this.Close();
                }
                //}
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
        private void View_DefinePostingKey(object InputValue)
        {
            try
            {
                //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                if (MasterEntity.trns_key_code != null && MasterEntity.trns_key_code != "")
                {

                    //var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == "ACC_M003_I").FirstOrDefault();
                    //userAuth = docdetails;
                    //AppSessionState.UserAuthSingle = userAuth;
                    AppSessionState.ViewTitle = "Define Posting Key";
                    AppSessionState.TransValue = MasterEntity.trns_key_code;// + "!@" + POPUPEntityObject.test_code;
                    AppSessionState.TransValueType = "FROM_FICO_M0016_VM";
                    AppSessionState.TransParameter = "FromAccountDeterminationKey";
                    AppSessionState.ViewOtherRecordAllowed = true;
                    //AppSessionState.TransId = userAuth.id.ToString();
                    //AppSessionState.TransactionCode = userAuth.TranCode;
                }

                //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //{
                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType("Reflection.Modules.Finance.Views.DefinePostingKey");
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    // this.Close();
                }
                //}
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
        private void InsertTransactionKey(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            //string Request = "";
            //ACC_M003_E_P POPUPEntityObject = null;
            //try
            //{
            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            try
            //            { POPUPEntityObject = MC.TransactionKey.Where(x => x.trns_key_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
            //            catch (Exception ex) { }
            //        }
            //    }
            //    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_E_P>().Count() > 0)
            //    {
            //        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_E_P>().ToList()[0];
            //    }
            //    if (POPUPEntityObject != null)
            //    {
            //        //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
            //        var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

            //        if (dgSelectedIndexPriPro >= 0 && PricingProCollection.Count > dgSelectedIndexPriPro)
            //        {
            //            if (PricingProCollection[dgSelectedIndexPriPro].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
            //            {
            //                PricingProCollection[dgSelectedIndexPriPro].trns_key_code = POPUPEntityObject.trns_key_code;
            //                PricingProCollection[dgSelectedIndexPriPro].trns_key_desc = POPUPEntityObject.trns_key_desc;
            //            }
            //            else if (PricingProCollection[dgSelectedIndexPriPro].trns_key_code != POPUPEntityObject.trns_key_code)
            //            {
            //                PricingProCollection[dgSelectedIndexPriPro].trns_key_code = POPUPEntityObject.trns_key_code;
            //                PricingProCollection[dgSelectedIndexPriPro].trns_key_desc = POPUPEntityObject.trns_key_desc;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex) { }
        }
        private bool Validation()
        {
            //    if (MasterEntity.tb_code == null || MasterEntity.tb_code == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Enter the Test Bed No...");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }
            //    else if (MasterEntity.project == null || MasterEntity.project == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Enter the Project...");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }
            return true;
        }

        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity.Count > i && DetailEntity[dgSelectedIndex].id == 0)
                {
                    DetailEntity.RemoveAt(i);
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

        #region .Abstract Command Actions.
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_T> result)
        {
            try
            {
                foreach (ACC_M003_T item in DetailEntity)
                {
                    item.trns_key_code = MasterEntity.trns_key_code;
                    item.coa_key = MasterEntity.coa_key;
                }

                string strReturn = repository.Save<List<ACC_M003_T>>(DetailEntity.ToList(), "AccountDeterminationKey", "Finance");

                if (strReturn != null && strReturn != "")
                {
                    DetailEntity.Clear();
                    MC.DetailEntityList = new ObservableCollection<ACC_M003_T>();
                    MC = (MultipleContext_ACC_M003_T)new ObjectSerializationService().XMLToObject(strReturn, MC);
                    DetailEntity = MC.DetailEntityList;
                }
                else
                {
                    DetailEntity = new ObservableCollection<ACC_M003_T>();
                }


                if (DetailEntity != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                    showMessageService.ShowMessage();
                }

                //  SetBusinessEntitiesAfterLoad("Save", "");

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
                if (MC.postingDetreminationDataList != null)
                {
                    var tempEntity = MC.DetailEntityList;
                }
                else
                {
                    MC.DetailEntityList = new ObservableCollection<ACC_M003_T>();
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
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_T> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_T> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_T> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_T> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_T> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_T> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new ACC_M003_T();

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
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_T> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
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
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_T> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_T> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_T> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_T> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_T> result)
        {

        }

        #endregion

        #region .Filters.

        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as ACC_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemsListPopup))
                {
                    return ((data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                           (data.gl_name != null && data.gl_name.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())));
                }
                return true;
            }
            return false;
        }

        #region .Filters For DataGrid.   

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
            if (DataGridCollection != null)
            {
                //( _postingDetreminationDataCollection.ToList ()).Refresh();
            }
        }
        public bool Filter(object obj)
        {
            //var data = obj as ACC_M003_T;
            //if (data != null)
            //{
            //    if (!string.IsNullOrEmpty(_filterString))
            //    {
            //        return (data.pricing_pro != null && data.pricing_pro.ToString().ToLower().Contains(_filterString.ToLower()) ||
            //                data.condition_type != null && data.condition_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
            //                data.name != null && data.name.ToString().ToLower().Contains(_filterString.ToLower()) ||
            //                data.trns_key_code != null && data.trns_key_code.ToString().ToLower().Contains(_filterString.ToLower())
            //                );
            //    }
            //    return true;
            //}
            return false;
        }



        #endregion

        #endregion

    }
}
