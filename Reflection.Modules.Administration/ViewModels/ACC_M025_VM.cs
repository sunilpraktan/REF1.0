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
using System.Windows.Controls;
using Reflection.BusinessEntity.Account;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ACC_M025_VM : WorkspaceViewModel<ACC_M025>
    {
        bool NewRecord = true;

        WebServiceRepository<ACC_M025> repository = new WebServiceRepository<ACC_M025>();
        WebServiceRepository<MultipleContext_ACC_M025> repository_MC = new WebServiceRepository<MultipleContext_ACC_M025>();
        WebServiceRepository<MultipleContext_ACC_M025> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M025>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ACC_M025));
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

        private AutoSuggestTextViewModel<dynamic> _ASwithtax { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASwithtax
        {
            get { return _ASwithtax; }
            set
            {
                if (_ASwithtax != value)
                {
                    _ASwithtax = value; RaisePropertyChanged("ASwithtax");
                }
            }
        }

        #endregion
        #region Relay Commands Declaration

        public RelayCommand<object> CmdCountry { get; private set; }
        public RelayCommand<object> Cmdwithtax { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }


        #endregion
        #region Variable Declaration
        private ACC_M025 _MasterEntity;
        public ACC_M025 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    RaisePropertyChanged("MasterEntity");

                }
            }
        }

        private MultipleContext_ACC_M025 _MC;
        public MultipleContext_ACC_M025 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M025 _MCTemp;
        public MultipleContext_ACC_M025 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ObservableCollection<ACC_M025> _TOCollection;
        public ObservableCollection<ACC_M025> TOCollection
        {
            get { return _TOCollection; }
            set
            {
                if (_TOCollection != value)
                {
                    _TOCollection = value;
                    RaisePropertyChanged("TOCollection");
                }
            }
        }

        private ICollectionView _TOCollection1;
        public ICollectionView TOCollection1
        {
            get { return _TOCollection1; }
            set
            {
                if (_TOCollection1 != value)
                {
                    _TOCollection1 = value;
                    RaisePropertyChanged("TOCollection1");
                }
            }
        }

        private List<ACC_M025> _SelectedList;
        public List<ACC_M025> SelectedList
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
        #endregion
        #region Constructor
        public ACC_M025_VM() : base()
        {
            MasterEntity = new ACC_M025();
            MC = new MultipleContext_ACC_M025();
            MCTemp = new MultipleContext_ACC_M025();


            CmdCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            Cmdwithtax = new RelayCommand<object>(items => { if (items == null) { return; } Insertwithholingtaxtype(items); });

            LoadInitialData();

        }

        #endregion
        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.client = AppSessionState.client;
        }

        private bool Validation()
        {
            if (MasterEntity.wtax_code == null || MasterEntity.wtax_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid WithHolding Tax Code", MasterEntity.wtax_code);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.wtax_ncode == null || MasterEntity.wtax_ncode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid National Tax Code", MasterEntity.wtax_ncode);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.wtax_key == null || MasterEntity.wtax_key == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter WithHolding  Tax Key", MasterEntity.wtax_key);
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M025>(MC, Request, "WithHoldingTaxMaster", "Administration", "LoadInitialData", 0, "");

                TOCollection = MC.TaxList;
                SelectedList = TOCollection.ToList();

                TOCollection1 = CollectionViewSource.GetDefaultView(MC.TaxList);
                TOCollection1.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCountry = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "country_code", true);
                ASCountry.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_A_P)x).wtax_type ?? "");
                TheFilter = (o, prefix) => (((ACC_M025_A_P)o).wtax_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASwithtax = new AutoSuggestTextViewModel<dynamic>(MC.withholdingtaxtypeList, TheFilter, SuggestedValue, "ind_wtax_type", true);
                ASwithtax.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefaultValues();
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {

                ACC_M025 ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ACC_M025>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M025>().ToList()[0];

                    if (MC.TaxList.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    NewRecord = false;
                } 
            }
            catch { }

        }
        private void InsertCountry(object InputValue)
        {
            string Request = "";
            ADM_M012_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CountryList.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M012_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.country_code = POPUPEntityObject.country_code;
                    MasterEntity.CntryName = POPUPEntityObject.CntryName;
                }

                
            }
            catch (Exception ex) { }
        }

        private void Insertwithholingtaxtype(object InputValue)
        {
            string Request = "";
            ACC_M025_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.withholdingtaxtypeList.Where(x => x.wtax_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M025_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M025_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ind_wtax_type = POPUPEntityObject.wtax_type;
                }


            }
            catch (Exception ex) { }
        }



        #endregion
        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M025> result)
        {
           
           try
            {
                 if (Validation() == true)
                {
                    MasterEntity.edit_by = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<ACC_M025>>(MasterEntity, "WithHoldingTaxMaster", "Administration");
                    }
                    else if(NewRecord ==false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<List<ACC_M025>>(MasterEntity, "WithHoldingTaxMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.wtax_code != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.wtax_code != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false;
                   

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
                        TOCollection.Add(MasterEntity);
                        //MC.SalesOffList = (List<ADM_M001_I>)obj.XMLToObject(MasterEntity.ToString(), MC.SalesOffList);


                        TOCollection1 = CollectionViewSource.GetDefaultView(TOCollection);

                        TOCollection1.Refresh();
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M025> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M025> result)
        {
           
            MasterEntity = new ACC_M025();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M025> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M025> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M025> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M025> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M025> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M025> result)
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
            if (_TOCollection1 != null)
            {
                _TOCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M025;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.wtax_ncode != null && data.wtax_ncode.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.wtax_code != null && data.wtax_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                              data.wtax_key != null && data.wtax_key.ToString().ToLower().Contains(_filterString.ToLower()))

                             ;
                }
                return true;
            }
            return false;
        }
        
        #endregion

        #endregion
        
    }
}
