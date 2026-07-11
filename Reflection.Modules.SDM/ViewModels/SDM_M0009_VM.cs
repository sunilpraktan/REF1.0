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
using Reflection.BusinessEntity.Admin;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0009_VM : WorkspaceViewModel<ADM_M001_E>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_E>> repository = new WebServiceRepository<List<ADM_M001_E>>();
        WebServiceRepository<MultipleContext_ADM_M001_E> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_E>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0009_VM));
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


        private AutoSuggestTextViewModel<dynamic> _AsDistributionChannel { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsDistributionChannel
        {
            get { return _AsDistributionChannel; }
            set
            {
                if (_AsDistributionChannel != value)
                {
                    _AsDistributionChannel = value;
                    RaisePropertyChanged("AsDistributionChannel");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _AsSalesOrganisation { get; set; }
        public AutoSuggestTextViewModel<dynamic> AsSalesOrganisation
        {
            get { return _AsSalesOrganisation; }
            set
            {
                if (_AsSalesOrganisation != value)
                {
                    _AsSalesOrganisation = value;
                    RaisePropertyChanged("AsSalesOrganisation");
                }
            }
        }


        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                if (_cellInfo != value)
                {
                    _cellInfo = value;
                    SetAutoTextSource(_cellInfo);
                    RaisePropertyChanged("CellInfo");
                }
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
                    if (SourceName == "DC_Id")
                    { ASDefault = AsDistributionChannel; }
                    else if (SourceName == "SO_Id")
                    { ASDefault = AsSalesOrganisation; }
                }
            }
        }

        #endregion


        #region Declarations   

        private MultipleContext_ADM_M001_E _MC;
        public MultipleContext_ADM_M001_E MC
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

        private MultipleContext_ADM_M001_E _MCTemp;
        public MultipleContext_ADM_M001_E MCTemp
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


        private ADM_M001_E _MasterEntity;
        public ADM_M001_E MasterEntity
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



        private int _dgSelectedIndexAssignToSO;
        public int dgSelectedIndexAssignToSO
        {
            get
            { return _dgSelectedIndexAssignToSO; }
            set
            {
                if (_dgSelectedIndexAssignToSO != value)
                {
                    _dgSelectedIndexAssignToSO = value;
                    RaisePropertyChanged("dgSelectedIndexAssignToSO");
                }
            }
        }

        #endregion


        #region ICollectionView

        private ObservableCollection<ADM_M001_E> _DC_Collection;
        public ObservableCollection<ADM_M001_E> DC_Collection
        {
            get { return _DC_Collection; }
            set
            {
                if (_DC_Collection != value)
                {
                    _DC_Collection = value;
                    DC_Collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("DC_Collection");
                }
            }
        }

        private ICollectionView _DC_Collection1;
        public ICollectionView DC_Collection1
        {
            get { return _DC_Collection1; }
            set
            {
                if (_DC_Collection1 != value)
                {
                    _DC_Collection1 = value; RaisePropertyChanged("DC_Collection1");
                }
            }
        }

        private List<ADM_M001_E> _SelectedList;
        public List<ADM_M001_E> SelectedList
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

        public RelayCommand<object> CmdAddDC_Name { get; private set; }
        public RelayCommand<object> CmdAddSalesOrganisation { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion


        #region  Constructor

        public SDM_M0009_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_E();
            DC_Collection = new ObservableCollection<ADM_M001_E>();

            MC = new MultipleContext_ADM_M001_E();
            MCTemp = new MultipleContext_ADM_M001_E();

            CmdAddDC_Name = new RelayCommand<object>(items => { if (items == null) { return; } InsertDistributionChannel(items, false, true, true); });
            CmdAddSalesOrganisation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalesOrganisation(items, false, false, true); });
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            DC_Collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadinitialData();
        }

        #endregion


        #region User Defined Functions

        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_E>(MC, Request, "AssignDistributionChannelToSO", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                DC_Collection = MC.AssignDClist;
                SelectedList = DC_Collection.ToList();

                DC_Collection1 = CollectionViewSource.GetDefaultView(MC.AssignDClist);
                DC_Collection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code);
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ChannelList, TheFilter, SuggestedValue, "dc_code", "dc_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code);
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsDistributionChannel = new AutoSuggestTextViewModel<dynamic>(MC.ChannelList, TheFilter, SuggestedValue, "dc_code", "dc_code", true);
                AsDistributionChannel.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AsSalesOrganisation = new AutoSuggestTextViewModel<dynamic>(MC.SOlist, TheFilter, SuggestedValue, "so_code", "so_code", true);
                AsSalesOrganisation.AutoSuggestVM.IsEmptyValueAllowed = true;


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
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_E)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_E item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        //item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.Click = true;
                        item.userid = AppSessionState.UserID;
                        //item.ts_code = ts_code_vm;
                        item.active = true;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
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

        private bool Validation()
        {
            return true;
        }

        private void InsertDistributionChannel(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ChannelList.Where(x => x.dc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.dc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_C_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    //var InputValueIfExists = DC_Collection.Where(X => X.dc_code == POPUPEntityObject.dc_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = DC_Collection.IndexOf(DC_Collection.Where(X => X.dc_code == POPUPEntityObject.dc_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexAssignToSO >= 0 && DC_Collection.Count > dgSelectedIndexAssignToSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        DC_Collection[dgSelectedIndexAssignToSO].dc_code = POPUPEntityObject.dc_code;
                        DC_Collection[dgSelectedIndexAssignToSO].dc_name = POPUPEntityObject.dc_name;

                        MasterEntity.active = true;
                    }
                    else if (DC_Collection[dgSelectedIndexAssignToSO].dc_code != POPUPEntityObject.dc_code)
                    {
                        DC_Collection[dgSelectedIndexAssignToSO].dc_code = POPUPEntityObject.dc_code;
                        DC_Collection[dgSelectedIndexAssignToSO].dc_name = POPUPEntityObject.dc_name;
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



        private void InsertSalesOrganisation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SOlist.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    //var InputValueIfExists = DC_Collection.Where(X => X.so_code == POPUPEntityObject.so_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = DC_Collection.IndexOf(DC_Collection.Where(X => X.so_code == POPUPEntityObject.so_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexAssignToSO >= 0 && DC_Collection.Count > dgSelectedIndexAssignToSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        DC_Collection[dgSelectedIndexAssignToSO].so_code = POPUPEntityObject.so_code;
                        DC_Collection[dgSelectedIndexAssignToSO].sales_org = POPUPEntityObject.sales_org;

                        MasterEntity.active = true;
                    }
                    else if (DC_Collection[dgSelectedIndexAssignToSO].so_code != POPUPEntityObject.so_code)
                    {
                        DC_Collection[dgSelectedIndexAssignToSO].so_code = POPUPEntityObject.so_code;
                        DC_Collection[dgSelectedIndexAssignToSO].sales_org = POPUPEntityObject.sales_org;
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

        #endregion


        #region Abstract Command Actions
        string strReturn = "";

        protected override void OnCreateAction(InquiryActionResult<ADM_M001_E> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_E();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_E> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_E> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_E> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_E> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M001_E> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M001_E> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M001_E> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_E> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M001_E> result)
        {
            try
            {
                List<ADM_M001_E> RequestList = new List<ADM_M001_E>();
                foreach (ADM_M001_E item in DC_Collection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);

                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_E>>(RequestList, "AssignDistributionChannelToSO", "Administration");

                    if (strReturn != "")
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

        #endregion

        #region Filters

        #region Filters For DataGrid   

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
            if (_DC_Collection1 != null)
            {
                _DC_Collection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_E;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.dc_code != null && data.dc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower())
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
