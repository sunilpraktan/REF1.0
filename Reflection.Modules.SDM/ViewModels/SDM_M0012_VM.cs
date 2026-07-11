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
    public class SDM_M0012_VM : WorkspaceViewModel<ADM_M001_K>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_K>> repository = new WebServiceRepository<List<ADM_M001_K>>();
        WebServiceRepository<MultipleContext_ADM_M001_K> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_K>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0012_VM));
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



        private AutoSuggestTextViewModel<dynamic> _Assalesorganization { get; set; }
        public AutoSuggestTextViewModel<dynamic> Assalesorganization
        {
            get { return _Assalesorganization; }
            set
            {
                if (_Assalesorganization != value)
                {
                    _Assalesorganization = value; RaisePropertyChanged("Assalesorganization");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _Ascompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> Ascompany
        {
            get { return _Ascompany; }
            set
            {
                if (_Ascompany != value)
                {
                    _Ascompany = value; RaisePropertyChanged("Ascompany");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _Asdistributionchannel { get; set; }
        public AutoSuggestTextViewModel<dynamic> Asdistributionchannel
        {
            get { return _Asdistributionchannel; }
            set
            {
                if (_Asdistributionchannel != value)
                {
                    _Asdistributionchannel = value; RaisePropertyChanged("_Asdistributionchannel");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _Asdivision { get; set; }
        public AutoSuggestTextViewModel<dynamic> Asdivision
        {
            get { return _Asdivision; }
            set
            {
                if (_Asdivision != value)
                {
                    _Asdivision = value; RaisePropertyChanged("_Asdivision");
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
                    { ASDefault = Assalesorganization; }
                    else if (SourceName == "company")
                    { ASDefault = Ascompany; }
                    else if (SourceName == "channel")
                    { ASDefault = Asdistributionchannel; }
                    else if (SourceName == "division")
                    { ASDefault = Asdivision; }

                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_K _MC;
        public MultipleContext_ADM_M001_K MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_K _MCTemp;
        public MultipleContext_ADM_M001_K MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M001_K _MCTemp1;
        public MultipleContext_ADM_M001_K MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M001_K _MasterEntity;
        public ADM_M001_K MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexSA;
        public int dgSelectedIndexSA
        {
            get
            { return _dgSelectedIndexSA; }
            set
            {
                if (_dgSelectedIndexSA != value)
                {
                    _dgSelectedIndexSA = value;
                    RaisePropertyChanged("_dgSelectedIndexSA");
                }
            }
        }

        #endregion
        #region ICollectionView

        private ObservableCollection<ADM_M001_K> _SACollection;
        public ObservableCollection<ADM_M001_K> SACollection
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

        private List<ADM_M001_K> _SelectedList;
        public List<ADM_M001_K> SelectedList
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

        public RelayCommand<object> CmdAddSalesOrganization { get; private set; }
        public RelayCommand<object> CmdAddCompany { get; private set; }
        public RelayCommand<object> CmdAddChannel { get; private set; }
        public RelayCommand<object> CmdAddDivision { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion


        #region Constructor
        public SDM_M0012_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_K();
            SACollection = new ObservableCollection<ADM_M001_K>();

            MC = new MultipleContext_ADM_M001_K();
            MCTemp = new MultipleContext_ADM_M001_K();
            MCTemp1 = new MultipleContext_ADM_M001_K();

            CmdAddSalesOrganization = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrganization(items, false, true, true); });
            CmdAddCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items, false, false, true); });
            CmdAddChannel = new RelayCommand<object>(items => { if (items == null) { return; } InsertChannel(items, false, false, true); });
            CmdAddDivision = new RelayCommand<object>(items => { if (items == null) { return; } InsertDivision(items, false, false, true); });
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_K>(MC, Request, "SetUpSalesArea", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SACollection = MC.SAList;
                //SelectedList = (MC.SOList).ToList();
                SelectedList = SACollection.ToList();

                SACollection1 = CollectionViewSource.GetDefaultView(MC.SAList);
                SACollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_P)x).comp_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M002_P)o).comp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M002_P)o).CompName.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.CCList, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_P)x).comp_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M002_P)o).comp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M002_P)o).CompName.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Ascompany = new AutoSuggestTextViewModel<dynamic>(MC.CCList, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                Ascompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                //TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                //Assalesorganization = new AutoSuggestTextViewModel<dynamic>(MC.SOList, TheFilter, SuggestedValue, "so_code", "so_code", true);
                //Assalesorganization.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_A_P)o).sales_org.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Assalesorganization = new AutoSuggestTextViewModel<dynamic>(MC.SOList, TheFilter, SuggestedValue, "sales_org", "sales_org", true);
                Assalesorganization.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_C_P)o).dc_name.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Asdistributionchannel = new AutoSuggestTextViewModel<dynamic>(MC.DCList, TheFilter, SuggestedValue, "dc_code", "dc_code", true);
                Asdistributionchannel.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_D_P)x).div_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M001_D_P)o).div_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M001_D_P)o).div_name.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                Asdivision = new AutoSuggestTextViewModel<dynamic>(MC.DivList, TheFilter, SuggestedValue, "div_name", "div_name", true);
                Asdivision.AutoSuggestVM.IsEmptyValueAllowed = true;


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
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.active = true;

        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_K)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_K item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
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
                if (o.so_code == null || o.so_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter SO code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.comp_code == null || o.comp_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Company  code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.div_code == null || o.div_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Division code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.dc_code == null || o.dc_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Distribution Channel code");

                    showMessageService.ShowMessage();
                    return false;

                }

            }

            return true;
        }

        private void InsertOrganization(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = MC.SOList.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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

                    if (dgSelectedIndexSA >= 0 && SACollection.Count > dgSelectedIndexSA) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        SACollection[dgSelectedIndexSA].so_code = POPUPEntityObject.so_code;
                        SACollection[dgSelectedIndexSA].sales_org = POPUPEntityObject.sales_org;

                        MasterEntity.active = true;
                    }
                    else if (SACollection[dgSelectedIndexSA].so_code != POPUPEntityObject.so_code)
                    {
                        SACollection[dgSelectedIndexSA].so_code = POPUPEntityObject.so_code;
                        SACollection[dgSelectedIndexSA].sales_org = POPUPEntityObject.sales_org;
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



        private void InsertChannel(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M001_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DCList.Where(x => x.dc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M001_C_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_C_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = SACollection.Where(x => x.dc_code == POPUPEntityObject.dc_code).FirstOrDefault();
                    var IndexOfExistValue = SACollection.IndexOf(SACollection.Where(X => X.dc_code == POPUPEntityObject.dc_code).FirstOrDefault());

                    if (dgSelectedIndexSA >= 0 && SACollection.Count > dgSelectedIndexSA)
                    {

                        SACollection[dgSelectedIndexSA].dc_code = POPUPEntityObject.dc_code;
                        SACollection[dgSelectedIndexSA].dc_name = POPUPEntityObject.dc_name;
                    }
                    else if (SACollection[dgSelectedIndexSA].dc_code != POPUPEntityObject.dc_code)
                    {
                        SACollection[dgSelectedIndexSA].dc_code = POPUPEntityObject.dc_code;
                        SACollection[dgSelectedIndexSA].dc_name = POPUPEntityObject.dc_name;
                    }
                }


            }
            catch (Exception ex) { }
        }
        private void InsertCompany(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M002_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CCList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M002_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = SACollection.Where(x => x.comp_code == POPUPEntityObject.comp_code).FirstOrDefault();
                    var IndexOfExistValue = SACollection.IndexOf(SACollection.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault());

                    if (dgSelectedIndexSA >= 0 && SACollection.Count > dgSelectedIndexSA)
                    {

                        SACollection[dgSelectedIndexSA].comp_code = POPUPEntityObject.comp_code;
                        SACollection[dgSelectedIndexSA].CompName = POPUPEntityObject.CompName;
                    }
                    else if (SACollection[dgSelectedIndexSA].comp_code != POPUPEntityObject.comp_code)
                    {
                        SACollection[dgSelectedIndexSA].comp_code = POPUPEntityObject.comp_code;
                        SACollection[dgSelectedIndexSA].CompName = POPUPEntityObject.CompName;
                    }
                }


            }
            catch (Exception ex) { }
        }

        private void InsertDivision(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M001_D_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DivList.Where(x => x.div_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.div_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M001_D_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_D_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = SACollection.Where(x => x.div_code == POPUPEntityObject.div_code).FirstOrDefault();
                    var IndexOfExistValue = SACollection.IndexOf(SACollection.Where(X => X.div_code == POPUPEntityObject.div_code).FirstOrDefault());

                    if (dgSelectedIndexSA >= 0 && SACollection.Count > dgSelectedIndexSA)
                    {

                        SACollection[dgSelectedIndexSA].div_code = POPUPEntityObject.div_code;
                        SACollection[dgSelectedIndexSA].div_name = POPUPEntityObject.div_name;
                    }
                    else if (SACollection[dgSelectedIndexSA].div_code != POPUPEntityObject.div_code)
                    {
                        SACollection[dgSelectedIndexSA].div_code = POPUPEntityObject.div_code;
                        SACollection[dgSelectedIndexSA].div_name = POPUPEntityObject.div_name;
                    }
                }


            }
            catch (Exception ex) { }
        }
        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_K> result)
        {
            try
            {
                List<ADM_M001_K> RequestList = new List<ADM_M001_K>();
                foreach (ADM_M001_K item in SACollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.OBJ_COMPANY.comp_code;

                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_K>>(RequestList, "SetUpSalesArea", "Administration");

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

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                List<ADM_M001_K> RequestList = new List<ADM_M001_K>();
                RequestList = SACollection.ToList();
                foreach (ADM_M001_K item in RequestList)
                {
                    if (item.Click == true)
                    {
                        SACollection.Remove(item);
                    }
                }
                if (strReturn != "")
                {
                    MC.SAList = (ObservableCollection<ADM_M001_K>)obj.XMLToObject(strReturn, MC.SAList);
                    SACollection.Add(MC.SAList[0]);
                }
                else
                {
                    MC.SAList = new ObservableCollection<ADM_M001_K>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreateAction(InquiryActionResult<ADM_M001_K> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_K();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_K> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_K> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_K> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_K> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_K> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_K> result)
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
            var data = obj as ADM_M001_K;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.dc_code != null && data.dc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
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
