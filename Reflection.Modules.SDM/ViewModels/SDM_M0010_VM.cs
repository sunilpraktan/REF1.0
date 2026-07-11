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
    public class SDM_M0010_VM : WorkspaceViewModel<ADM_M001_J>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_J>> repository = new WebServiceRepository<List<ADM_M001_J>>();
        WebServiceRepository<MultipleContext_ADM_M001_J> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_J>();

        ObjectSerializationService obj = new ObjectSerializationService();
        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0010_VM));
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



        private AutoSuggestTextViewModel<dynamic> _Assalesoffice { get; set; }
        public AutoSuggestTextViewModel<dynamic> Assalesoffice
        {
            get { return _Assalesoffice; }
            set
            {
                if (_Assalesoffice != value)
                {
                    _Assalesoffice = value; RaisePropertyChanged("Assalesoffice");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _Assalesgroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> Assalesgroup
        {
            get { return _Assalesgroup; }
            set
            {
                if (_Assalesgroup != value)
                {
                    _Assalesgroup = value; RaisePropertyChanged("Assalesgroup");
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
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "sales")
                    { ASDefault = Assalesoffice; }
                    else if (SourceName == "Group")
                    { ASDefault = Assalesgroup; }


                }
            }
        }

        #endregion
        #region Declarations       

        private MultipleContext_ADM_M001_J _MC;
        public MultipleContext_ADM_M001_J MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_J _MCTemp;
        public MultipleContext_ADM_M001_J MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M001_J _MCTemp1;
        public MultipleContext_ADM_M001_J MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M001_J _MasterEntity;
        public ADM_M001_J MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexSO;
        public int dgSelectedIndexSO
        {
            get
            { return _dgSelectedIndexSO; }
            set
            {
                if (_dgSelectedIndexSO != value)
                {
                    _dgSelectedIndexSO = value;
                    RaisePropertyChanged("dgSelectedIndexSO");
                }
            }
        }

        #endregion
        #region ICollectionView

        private ObservableCollection<ADM_M001_J> _SACollection;
        public ObservableCollection<ADM_M001_J> SACollection
        {
            get { return _SACollection; }
            set
            {
                if (_SACollection != value)
                {
                    _SACollection = value;
                    SACollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("SACollection");
                }
            }
        }

        private ICollectionView _SACollection1;
        public ICollectionView SACollection1
        {
            get { return _SACollection1; }
            set { _SACollection1 = value; RaisePropertyChanged("SACollection1"); }
        }

        private List<ADM_M001_J> _SelectedList;
        public List<ADM_M001_J> SelectedList
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

        public RelayCommand<object> CmdAddSalesOffice { get; private set; }
        public RelayCommand<object> CmdAddSalesGroup { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }

        #endregion
        #region Constructor
        public SDM_M0010_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_J();
            SACollection = new ObservableCollection<ADM_M001_J>();

            MC = new MultipleContext_ADM_M001_J();
            MCTemp = new MultipleContext_ADM_M001_J();
            MCTemp1 = new MultipleContext_ADM_M001_J();

            CmdAddSalesOffice = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalesoffice(items, false, true, true); });
            CmdAddSalesGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalesGroup(items, false, false, true); });
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            SACollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_J>(MC, Request, "AssignSalesGroupToSalesOffice", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SACollection = MC.AssignSalesGrouptoSalesOfficeList;
                SelectedList = SACollection.ToList();

                SACollection1 = CollectionViewSource.GetDefaultView(MC.AssignSalesGrouptoSalesOfficeList);
                SACollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_I_P)x).soff_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_I_P)o).soff_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_I_P)o).sales_off.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.SOList, TheFilter, SuggestedValue, "soff_code", "soff_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_I_P)x).soff_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_I_P)o).soff_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_I_P)o).sales_off.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Assalesoffice = new AutoSuggestTextViewModel<dynamic>(MC.SOList, TheFilter, SuggestedValue, "soff_code", "soff_code", true);
                Assalesoffice.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_H_P)o).sg_name.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Assalesgroup = new AutoSuggestTextViewModel<dynamic>(MC.SGList, TheFilter, SuggestedValue, "sg_code", "sg_code", true);
                Assalesgroup.AutoSuggestVM.IsEmptyValueAllowed = true;


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

        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_J)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_J item in e.NewItems)
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
            foreach (var o in SACollection)
            {
                if (o.sg_code == null || o.sg_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter SG code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.soff_code == null || o.soff_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Sales office code");

                    showMessageService.ShowMessage();
                    return false;

                }



            }

            return true;
        }

        private void InsertSalesoffice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_I_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SOList.Where(x => x.soff_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_off.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_I_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexSO >= 0 && SACollection.Count > dgSelectedIndexSO) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SACollection[dgSelectedIndexSO].soff_code = POPUPEntityObject.soff_code;
                        SACollection[dgSelectedIndexSO].sales_off = POPUPEntityObject.sales_off;

                        MasterEntity.active = true;
                    }
                    else if (SACollection[dgSelectedIndexSO].soff_code != POPUPEntityObject.soff_code)
                    {
                        SACollection[dgSelectedIndexSO].soff_code = POPUPEntityObject.soff_code;
                        SACollection[dgSelectedIndexSO].sales_off = POPUPEntityObject.sales_off;
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



        private void InsertSalesGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M001_H_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SGList.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = SACollection.Where(x => x.sg_code == POPUPEntityObject.sg_code).FirstOrDefault();
                    var IndexOfExistValue = SACollection.IndexOf(SACollection.Where(X => X.sg_code == POPUPEntityObject.sg_code).FirstOrDefault());

                    if (dgSelectedIndexSO >= 0 && SACollection.Count > dgSelectedIndexSO)
                    {

                        SACollection[dgSelectedIndexSO].sg_code = POPUPEntityObject.sg_code;
                        SACollection[dgSelectedIndexSO].sg_name = POPUPEntityObject.sg_name;
                    }
                    else if (SACollection[dgSelectedIndexSO].sg_code != POPUPEntityObject.sg_code)
                    {
                        SACollection[dgSelectedIndexSO].sg_code = POPUPEntityObject.sg_code;
                        SACollection[dgSelectedIndexSO].sg_name = POPUPEntityObject.sg_name;
                    }
                }


            }
            catch (Exception ex) { }
        }


        #endregion
        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_J> result)
        {
            try
            {
                List<ADM_M001_J> RequestList = new List<ADM_M001_J>();
                foreach (ADM_M001_J item in SACollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.OBJ_COMPANY.comp_code;

                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_J>>(RequestList, "AssignSalesGroupToSalesOffice", "Administration");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved  Successfully", this.Title);
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_J> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_J> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_J> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_J> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_J> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_J> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_J();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_J> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_J> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_J> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_J> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_J> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_J> result)
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
            if (_SACollection1 != null)
            {
                _SACollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_J;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.soff_code != null && data.soff_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterString.ToLower())

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
