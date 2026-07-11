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
    public class SDM_M0008_VM : WorkspaceViewModel<ADM_M001_F>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_F>> repository = new WebServiceRepository<List<ADM_M001_F>>();
        WebServiceRepository<MultipleContext_ADM_M001_F> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_F>();
        WebServiceRepository<MultipleContext_ADM_M001_F> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M001_F>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0008_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASDivCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDivCode
        {
            get { return _ASDivCode; }
            set
            {
                if (_ASDivCode != value)
                {
                    _ASDivCode = value; RaisePropertyChanged("ASDivCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSOCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSOCode
        {
            get { return _ASSOCode; }
            set
            {
                if (_ASSOCode != value)
                {
                    _ASSOCode = value; RaisePropertyChanged("ASSOCode");
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
                    if (SourceName == "DivCode")
                    { ASDefault = ASDivCode; }
                    else if (SourceName == "Socode")
                    { ASDefault = ASSOCode; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_F _MC;
        public MultipleContext_ADM_M001_F MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_F _MCTemp;
        public MultipleContext_ADM_M001_F MCTemp
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

        private ADM_M001_F _MasterEntity;
        public ADM_M001_F MasterEntity
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



        private int _dgSelectedIndexADSo;
        public int dgSelectedIndexSO
        {
            get
            { return _dgSelectedIndexADSo; }
            set
            {
                if (_dgSelectedIndexADSo != value)
                {
                    _dgSelectedIndexADSo = value;
                    RaisePropertyChanged("dgSelectedIndexADSo");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_F> _SOCollection;
        public ObservableCollection<ADM_M001_F> SOCollection
        {
            get { return _SOCollection; }
            set
            {
                if (_SOCollection != value)
                {
                    _SOCollection = value;
                    SOCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
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

        private List<ADM_M001_F> _SelectedList;
        public List<ADM_M001_F> SelectedList
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

        private List<ADM_M001_D_P> _divlist;
        public List<ADM_M001_D_P> divlist
        {
            get
            {
                return _divlist;
            }
            set
            {
                if (_divlist != value)
                {
                    _divlist = value;
                    RaisePropertyChanged("_divlist");
                }
            }
        }

        private List<ADM_M001_A_P> _solist;
        public List<ADM_M001_A_P> solist
        {
            get { return _solist; }
            set
            {
                if (_solist != value)
                {
                    _solist = value;
                    RaisePropertyChanged("_solist");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdAdddiv_code { get; private set; }
        public RelayCommand<object> CmdAddso_code { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public SDM_M0008_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_F();
            SOCollection = new ObservableCollection<ADM_M001_F>();

            MC = new MultipleContext_ADM_M001_F();
            MCTemp = new MultipleContext_ADM_M001_F();


            CmdAdddiv_code = new RelayCommand<object>(items => { if (items == null) { return; } Insertdiv_code(items, false, true, true); });
            CmdAddso_code = new RelayCommand<object>(items => { if (items == null) { return; } Insertso_code(items, false, false, true); });
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            SOCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadinitialData();
        }


        #endregion
        #region User Defined Functions

        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_F>(MC, Request, "AssignDivisionToSO", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.DivAsSolist;
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.DivAsSolist);
                SOCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_D_P)x).div_code);
                TheFilter = (o, prefix) => (((ADM_M001_D_P)o).div_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.divlist, TheFilter, SuggestedValue, "div_code", "div_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_D_P)x).div_code);
                TheFilter = (o, prefix) => (((ADM_M001_D_P)o).div_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDivCode = new AutoSuggestTextViewModel<dynamic>(MC.divlist, TheFilter, SuggestedValue, "div_code", "div_code", true);
                ASDivCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSOCode = new AutoSuggestTextViewModel<dynamic>(MC.solist, TheFilter, SuggestedValue, "so_code", "so_code", true);
                ASSOCode.AutoSuggestVM.IsEmptyValueAllowed = true;


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
                MasterEntity = (ADM_M001_F)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_F item in e.NewItems)
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
            if (MasterEntity.div_code == null || MasterEntity.div_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Div Code...");
                showMessageService.ShowMessage();
                return false;
            }



            return true;
        }

        private void Insertdiv_code(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_D_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.divlist.Where(x => x.div_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.div_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_D_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {


                    if (dgSelectedIndexADSo >= 0 && SOCollection.Count > dgSelectedIndexADSo) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexADSo].div_code = POPUPEntityObject.div_code;
                        SOCollection[dgSelectedIndexADSo].div_name = POPUPEntityObject.div_name;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexADSo].div_code != POPUPEntityObject.div_code)
                    {
                        SOCollection[dgSelectedIndexADSo].div_code = POPUPEntityObject.div_code;
                        SOCollection[dgSelectedIndexADSo].div_name = POPUPEntityObject.div_name;
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



        private void Insertso_code(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = MC.solist.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    var InputValueIfExists = SOCollection.Where(X => X.so_code == POPUPEntityObject.so_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = SOCollection.IndexOf(SOCollection.Where(X => X.so_code == POPUPEntityObject.so_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexADSo >= 0 && SOCollection.Count > dgSelectedIndexADSo)     //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SOCollection[dgSelectedIndexADSo].so_code = POPUPEntityObject.so_code;
                        SOCollection[dgSelectedIndexADSo].sales_org = POPUPEntityObject.sales_org;

                        MasterEntity.active = true;
                    }
                    else if (SOCollection[dgSelectedIndexADSo].so_code != POPUPEntityObject.so_code)
                    {
                        SOCollection[dgSelectedIndexADSo].so_code = POPUPEntityObject.so_code;
                        SOCollection[dgSelectedIndexADSo].sales_org = POPUPEntityObject.sales_org;
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_F> result)
        {
            try
            {
                List<ADM_M001_F> RequestList = new List<ADM_M001_F>();
                foreach (ADM_M001_F item in SOCollection)
                {
                    if (item.Click == true)
                    {
                        item.client = AppSessionState.client;

                        RequestList.Add(item);
                        MasterEntity.div_code = item.div_code;   //For Validation Purpose
                        MasterEntity.so_code = item.so_code;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_F>>(RequestList, "AssignDivisionToSO", "Administration");

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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_F> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_F> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_F();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_F> result)
        {


        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_F> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_F> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_F> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_F> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_F> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid   

        private string _filterString;
        private int dgSelectedIndexADSo;

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
            var data = obj as ADM_M001_F;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.div_code != null && data.div_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterString.ToLower())

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
