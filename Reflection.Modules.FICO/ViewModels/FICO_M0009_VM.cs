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
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.Finance;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0009_VM : WorkspaceViewModel<ACC_M003_D>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_D>> repository = new WebServiceRepository<List<ACC_M003_D>>();
        WebServiceRepository<MultipleContext_ACC_M003_D> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_D>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0009_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASCompCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompCode
        {
            get { return _ASCompCode; }
            set
            {
                if (_ASCompCode != value)
                {
                    _ASCompCode = value; RaisePropertyChanged("ASCompCode");
                }
            }
        }

        private DataGridCellInfo _CellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _CellInfo; }
            set
            {
                _CellInfo = value;
                SetAutoTextSource(_CellInfo);
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
                    if (SourceName == "COA_KEY")
                    { ASDefault = ASCoaKey; }
                    else if (SourceName == "comp_code")
                    { ASDefault = ASCompCode; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ACC_M003_D _MC;
        public MultipleContext_ACC_M003_D MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_D _MCTemp;
        public MultipleContext_ACC_M003_D MCTemp
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

        private ACC_M003_D _MasterEntity;
        public ACC_M003_D MasterEntity
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



        private int _DgSelectedIndexCoa;
        public int DgSelectedIndexCoa
        {
            get
            { return _DgSelectedIndexCoa; }
            set
            {
                if (_DgSelectedIndexCoa != value)
                {
                    _DgSelectedIndexCoa = value;
                    RaisePropertyChanged("DgSelectedIndexCoa");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M003_D> _SOCollection;
        public ObservableCollection<ACC_M003_D> SOCollection
        {
            get { return _SOCollection; }
            set
            {
                if (_SOCollection != value)
                {
                    _SOCollection = value;
                    RaisePropertyChanged("SOCollection");
                }
            }
        }
        private ICollectionView _SOCollection1;
        public ICollectionView SOCollection1
        {
            get { return _SOCollection1; }
            set
            {
                if (_SOCollection1 != value)
                {
                    _SOCollection1 = value;
                    RaisePropertyChanged("SOCollection1");
                }
            }
        }



        private List<ACC_M026_P> _Coalist;
        public List<ACC_M026_P> Coalist
        {
            get
            {
                return _Coalist;
            }
            set
            {
                if (_Coalist != value)
                {
                    _Coalist = value;
                    RaisePropertyChanged("Coalist");
                }
            }
        }

        private List<ADM_M001_A_P> _comp_codelist;
        public List<ADM_M001_A_P> comp_codelist
        {
            get { return _comp_codelist; }
            set
            {
                if (_comp_codelist != value)
                {
                    _comp_codelist = value;
                    RaisePropertyChanged("comp_codelist");
                }
            }
        }
        private List<ACC_M003_D> _SelectedList;
        public List<ACC_M003_D> SelectedList
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

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdAddcoa_key { get; private set; }
        public RelayCommand<object> CmdAddcomp_code { get; private set; }
        #endregion

        #region Constructor
        public FICO_M0009_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_D();
            SOCollection = new ObservableCollection<ACC_M003_D>();

            MC = new MultipleContext_ACC_M003_D();
            MCTemp = new MultipleContext_ACC_M003_D();


            CmdAddcoa_key = new RelayCommand<object>(items => { if (items == null) { return; } Insertcoa_key(items, false, true, true); });
            CmdAddcomp_code = new RelayCommand<object>(items => { if (items == null) { return; } Insertcomp_code(items, false, false, true); });


            LoadinitialData();
        }


        #endregion

        #region User Defined Functions

        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_D>(MC, Request, "CoaAssignToCompany1", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.CoaASToComplist;
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.CoaASToComplist);
                SOCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M026_P)x).coa_key);
                TheFilter = (o, prefix) => (((ACC_M026_P)o).coa_key ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Coalist, TheFilter, SuggestedValue, "coa_key", "coa_key", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M026_P)x).coa_key);
                TheFilter = (o, prefix) => (((ACC_M026_P)o).coa_key ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCoaKey = new AutoSuggestTextViewModel<dynamic>(MC.Coalist, TheFilter, SuggestedValue, "coa_key", "coa_key", true);
                ASCoaKey.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).comp_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCompCode = new AutoSuggestTextViewModel<dynamic>(MC.comp_codelist, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                ASCompCode.AutoSuggestVM.IsEmptyValueAllowed = true;


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
            MasterEntity.client = AppSessionState.client;
        }

        private bool Validation()
        {
            foreach (var o in SOCollection)
            {
                if (o.coa_key == null || o.coa_key == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select coa_key...");
                    showMessageService.ShowMessage();
                    return false;
                }

            }

            return true;
        }

        private void Insertcoa_key(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M026_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.Coalist.Where(x => x.coa_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M026_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DgSelectedIndexCoa >= 0 && SOCollection.Count > DgSelectedIndexCoa) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[DgSelectedIndexCoa].coa_key = POPUPEntityObject.coa_key;


                        MasterEntity.active = true;
                    }
                    else if (SOCollection[DgSelectedIndexCoa].coa_key != POPUPEntityObject.coa_key)
                    {
                        SOCollection[DgSelectedIndexCoa].coa_key = POPUPEntityObject.coa_key;

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

        private void Insertcomp_code(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.comp_codelist.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = SOCollection.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = SOCollection.IndexOf(SOCollection.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (DgSelectedIndexCoa >= 0 && SOCollection.Count > DgSelectedIndexCoa)     //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[DgSelectedIndexCoa].comp_code = POPUPEntityObject.comp_code;


                    }
                    else if (SOCollection[DgSelectedIndexCoa].comp_code != POPUPEntityObject.comp_code)
                    {
                        SOCollection[DgSelectedIndexCoa].comp_code = POPUPEntityObject.comp_code;
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

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_D> result)
        {
            try
            {
                List<ACC_M003_D> RequestList = new List<ACC_M003_D>();
                foreach (ACC_M003_D item in SOCollection)
                {
                    if (item.Click == true)
                    {

                        RequestList.Add(item);
                        MasterEntity.comp_code = item.comp_code;   //For Validation Purpose
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ACC_M003_D>>(RequestList, "CoaAssignToCompany1", "Finance");

                    if (strReturn != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
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


        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_D> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_D> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_D();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_D> result)
        {


        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_D> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_D> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_D> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_D> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_D> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid   

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
            if (_SOCollection1 != null)
            {
                _SOCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_D;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.coa_key != null && data.coa_key.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }




        #endregion

        #endregion
    }
}
