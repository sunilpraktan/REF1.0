using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Admin;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0005_VM : WorkspaceViewModel<ADM_M001_I>
    {
        bool NewRecord = true;

        WebServiceRepository<ADM_M001_I> repository = new WebServiceRepository<ADM_M001_I>();
        WebServiceRepository<MultipleContext_ADM_M001_I> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_I>();
        WebServiceRepository<MultipleContext_ADM_M001_I> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M001_I>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0005_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASState { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASState
        {
            get { return _ASState; }
            set
            {
                if (_ASState != value)
                {
                    _ASState = value; RaisePropertyChanged("ASState");
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

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdAddCountry { get; private set; }
        public RelayCommand<object> CmdAddState { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Variable Declaration
        private ADM_M001_I _MasterEntity;
        public ADM_M001_I MasterEntity
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

        private MultipleContext_ADM_M001_I _MC;
        public MultipleContext_ADM_M001_I MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }



        private List<ADM_M001_I> _SOCollection;
        public List<ADM_M001_I> SOCollection
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

        private List<ADM_M013_P> _state;
        public List<ADM_M013_P> state
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    RaisePropertyChanged("state");
                }
            }
        }




        private List<ADM_M001_I> _SelectedList;
        public List<ADM_M001_I> SelectedList
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
        public SDM_M0005_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_I();
            MC = new MultipleContext_ADM_M001_I();

            CmdAddState = new RelayCommand<object>(items => { if (items == null) { return; } InsertState(items); });
            CmdAddCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });

            LoadInitialData();

        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

        }

        private bool Validation()
        {
            foreach (var o in SOCollection)
            {
                if (o.soff_code == null || o.soff_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Sales Office Code");

                    showMessageService.ShowMessage();
                    return false;
                }
            }

            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_I>(MC, Request, "SalesOffice", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.SalesOffList;
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.SalesOffList);
                SOCollection1.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).CntryName ?? "");
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "country_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCountry = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "country_code", true);
                ASCountry.AutoSuggestVM.IsEmptyValueAllowed = true;
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
                        catch (Exception ex)
                        {
                        }
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

                    state = (from o in MC.StateList
                             where o.country_code == POPUPEntityObject.country_code
                             select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).StatName ?? "");
                    TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M013_P)o).StatName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASState = new AutoSuggestTextViewModel<dynamic>(state, TheFilter, SuggestedValue, "state_code", true);
                    ASState.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASState.AutoSuggestVM.IsFreeTextAllowed = true;

                }
                var msg = new NotificationMessage("SDM_M0005_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void InsertState(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.StateList.Where(x => x.StatName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M013_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.state_code = POPUPEntityObject.state_code;
                        MasterEntity.StatName = POPUPEntityObject.StatName;
                    }
                }
                catch (Exception ex) { }
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
                string Request = "";
                ADM_M001_I ParameterEntityObject = null;


                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ADM_M001_I>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M001_I>().ToList()[0];


                        if (MC.SalesOffList.Count > 0)
                        {
                            MasterEntity = ParameterEntityObject;

                        }



                        SelectedTabControlIndex = 0;
                        NewRecord = false;


                        var msg = new NotificationMessage("SDM_M0005_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_I> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M001_I>(MasterEntity, "SalesOffice", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M001_I>(MasterEntity, "SalesOffice", "Administration");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.soff_code != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.soff_code != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false;
                    var msg = new NotificationMessage("SDM_M0005_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
                    if (NewRecord == true)
                    {
                        SOCollection.Add(MasterEntity);
                        SOCollection1 = CollectionViewSource.GetDefaultView(SOCollection);
                        SOCollection1.Refresh();
                    }
                    else if (NewRecord == false)
                    {
                        SOCollection1 = CollectionViewSource.GetDefaultView(SOCollection);
                        SOCollection1.Filter = new Predicate<object>(Filter);
                        SOCollection1.Refresh();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_I> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_I> result)
        {

            MasterEntity = new ADM_M001_I();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_I> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_I> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_I> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_I> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_I> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_I> result)
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
            var data = obj as ADM_M001_I;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.soff_code != null && data.soff_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.city != null && data.city.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.district != null && data.district.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterString.ToLower())
                             );
                }
                return true;
            }
            return false;
        }





        #endregion

        #endregion
    }
}
