using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
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
using Reflection.Presentation.Services;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using System.Collections.Specialized;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.Admin;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0024_VM : WorkspaceViewModel<ADM_M028_I>
    {
        bool isNewRecord = true;
        WebServiceRepository<ADM_M028_I> repository = new WebServiceRepository<ADM_M028_I>();
        WebServiceRepository<MultipleContext_ADM_M028_I> repository_MC = new WebServiceRepository<MultipleContext_ADM_M028_I>();
        WebServiceRepository<MultipleContext_ADM_M028_I> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M028_I>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0024_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParty
        {
            get { return _ASParty; }
            set
            {
                if (_ASParty != value)
                {
                    _ASParty = value; RaisePropertyChanged("ASParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWTaxCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWTaxCode
        {
            get { return _ASWTaxCode; }
            set
            {
                if (_ASWTaxCode != value)
                {
                    _ASWTaxCode = value; RaisePropertyChanged("ASWTaxCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWtaxType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWtaxType
        {
            get { return _ASWtaxType; }
            set
            {
                if (_ASWtaxType != value)
                {
                    _ASWtaxType = value; RaisePropertyChanged("ASWtaxType");
                }
            }
        }

        private string _party;
        public string party
        {
            get { return _party; }
            set
            {
                if (_party != value)
                {
                    _party = value; RaisePropertyChanged("party");
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
                    if (SourceName == "TaxCode")
                    { ASDefault = ASWTaxCode; }
                    else if (SourceName == "type_name")
                    { ASDefault = ASWtaxType; }
                }
            }
        }

        private ADM_M028_I _SelectedList;
        public ADM_M028_I SelectedList
        {
            get
            { return _SelectedList; }
            set
            {
                _SelectedList = value;
                RaisePropertyChanged("SelectedList");
            }
        }
        #endregion



        #region Declarations
        private MultipleContext_ADM_M028_I _MC;
        public MultipleContext_ADM_M028_I MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;
                    RaisePropertyChanged("MC");
                }
            }
        }

        private MultipleContext_ADM_M028_I _MCTemp;
        public MultipleContext_ADM_M028_I MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private int _dgSelectedIndextax;
        public int dgSelectedIndextax
        {
            get
            {
                return _dgSelectedIndextax;
            }
            set
            {
                if (_dgSelectedIndextax != value)
                {
                    _dgSelectedIndextax = value;
                    RaisePropertyChanged("dgSelectedIndextax");
                }
            }
        }

        private ObservableCollection<ADM_M028_I> _MasterEntity;
        public ObservableCollection<ADM_M028_I> MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    MasterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItems);
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private List<ADM_M028_I_Flip> _FlipGridData;
        public List<ADM_M028_I_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;

                    RaisePropertyChanged("FlipGridData");

                }
            }
        }
        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
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


        #region ICollectionView

        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set { _DataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        #endregion

        #region RelayCommand

        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdInsertParty { get; private set; }
        public RelayCommand<object> CmdInsertWtaxCode { get; private set; }
        public RelayCommand<object> CmdInsertWTaxType { get; private set; }
        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ADM_M028_I item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ADM_M028_I item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M028_I item in e.NewItems)
                    {
                        if (party != null && party != "")
                        {

                            item.PartyId = party;
                            item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                            item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                            item.client = AppSessionState.client;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.active = true;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;

                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }

                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select Party ID...");
                            showMessageService.ShowMessage();
                        }

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (MasterEntity.Count > dgSelectedIndextax && dgSelectedIndextax >= 0)
            {
                this.ErrorExist = false;
            }
            else if (MasterEntity.Count > dgSelectedIndextax && dgSelectedIndextax >= 0)
            {
                this.ErrorExist = false;
            }
        }

        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (MasterEntity.Count > dgSelectedIndextax && dgSelectedIndextax >= 0)
            {
                this.ErrorExist = false;
            }
        }

        #endregion



        #region Constructor
        public FICO_M0024_VM(string ts_code) : base()
        {
            MC = new MultipleContext_ADM_M028_I();
            MCTemp = new MultipleContext_ADM_M028_I();
            MasterEntity = new ObservableCollection<ADM_M028_I>();
            FlipGridData = new List<ADM_M028_I_Flip>();


            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            cmdInsertParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, true, true, true); });
            CmdInsertWtaxCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertWTaxCode(items, true, true, true); });
            CmdInsertWTaxType = new RelayCommand<object>(items => { if (items == null) { return; } InsertWTaxType(items, true, true, true); });

            LoadInitialData();
        }

        #endregion


        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M028_I>(MC, Request, "WithholdingTaxforParty", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region .Autosuggest .

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code ?? "");
                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.TaxTypeCodeList, TheFilter, SuggestedValue, "wtax_code", "wtax_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyList, TheFilter, SuggestedValue, "PartyId", "PartyId", true);
                ASParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWTaxCode = new AutoSuggestTextViewModel<dynamic>(MC.TaxTypeCodeList, TheFilter, SuggestedValue, "wtax_code", "wtax_code", true);
                ASWTaxCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_A_P)x).wtax_type);
                TheFilter = (o, prefix) => (((ACC_M025_A_P)o).wtax_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWtaxType = new AutoSuggestTextViewModel<dynamic>(MC.TaxTypeList, TheFilter, SuggestedValue, "wtax_type", "wtax_type", true);
                ASWtaxType.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefaultValues();
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
        private void DefaultValues()
        {
            //MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            //MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            //MasterEntity1.add_by = AppSessionState.UserID;
            //MasterEntity1.editby = AppSessionState.UserID;
            //MasterEntity1.active = true;
            //MasterEntity1.user_source1 = AppSessionState.UserSource1;
            //MasterEntity1.user_source2 = AppSessionState.UserSource2;
            //MasterEntity1.client = AppSessionState.client;
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ADM_M028_I_Flip ParameterEntityObject = null;
            MasterEntity = new ObservableCollection<ADM_M028_I>();


            if (((IEnumerable)ParameterObject).Cast<ADM_M028_I_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M028_I_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.PartyId;
                isNewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M028_I>(MCTemp, Request, "WithholdingTaxforParty", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity;
                    foreach (var item in MasterEntity)
                    {
                        party = item.PartyId;
                    }
                }

            }
            SelectedTabControlIndex = 0;
            var msg = new NotificationMessage("FICO_M0024_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        private void InsertParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M028_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    party = POPUPEntityObject.PartyId;
                }
                string RequestParameter = "LoadDocumentByDocumentNumber" + "!@" + party;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M028_I>(MCTemp, RequestParameter, "WithholdingTaxforParty", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity;
                }
                else
                {
                    MasterEntity = new ObservableCollection<ADM_M028_I>();
                }
            }
            catch (Exception ex) { }
        }

        private void InsertWTaxCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ACC_M025_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaxTypeCodeList.Where(x => x.wtax_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M025_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {

                    var IndexOfExistValue = -1;

                    if (dgSelectedIndextax >= 0 && MasterEntity.Count > dgSelectedIndextax)
                    {
                        if (MasterEntity[dgSelectedIndextax].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndextax].wtax_code = POPUPEntityObject.wtax_code;
                        }
                        else if (MasterEntity[dgSelectedIndextax].wtax_code != POPUPEntityObject.wtax_code)
                        {
                            MasterEntity[dgSelectedIndextax].wtax_code = POPUPEntityObject.wtax_code;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }


        private void InsertWTaxType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.TaxTypeList.Where(x => x.wtax_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M025_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M025_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var IndexOfExistValue = -1;

                    if (dgSelectedIndextax >= 0 && MasterEntity.Count > dgSelectedIndextax)
                    {
                        if (MasterEntity[dgSelectedIndextax].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndextax].wtax_type = POPUPEntityObject.wtax_type;
                        }
                        else if (MasterEntity[dgSelectedIndextax].wtax_type != POPUPEntityObject.wtax_type)
                        {
                            MasterEntity[dgSelectedIndextax].wtax_type = POPUPEntityObject.wtax_type;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private bool Validation()
        {
            try
            {
                if (party == null || party == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter The Party ID...");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity1 != null)
                {
                    if (party == null || party == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Enter The Party ID", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    return true;
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
            return true;
        }


        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity1.XmlDataDocument_ADM_M028_I != null)
                {
                    MasterEntity.Clear();
                    MasterEntity = (ObservableCollection<ADM_M028_I>)obj.XMLToObject(MasterEntity1.XmlDataDocument_ADM_M028_I, MasterEntity);

                }
                else
                {
                    MC.MasterEntity = new ObservableCollection<ADM_M028_I>();
                }
                if (MasterEntity1.XmlDataDocument_ADM_M028_I != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ADM_M028_I_Flip>)obj.XMLToObject(MasterEntity1.XmlDataDocument_ADM_M028_I, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
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

        private void SetPopupSuggestionDataAfterLoad()
        {

        }
        #endregion


        #region Abstract Command Actions
        ADM_M028_I MasterEntity1 = new ADM_M028_I();

        protected override void OnSaveAction(InquiryActionResult<ADM_M028_I> result)
        {
            try
            {
                MasterEntity1.editby = AppSessionState.UserID;
                if (Validation() == true)
                {
                    MasterEntity1.XmlDataDocument_ADM_M028_I = obj.ObjectToXML(MasterEntity);
                    if (isNewRecord == true)
                    {
                        MasterEntity1 = repository.SaveWithReturnDomainObject<ADM_M028_I>(MasterEntity1, "WithholdingTaxforParty", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity1 = repository.SaveWithReturnDomainObject<ADM_M028_I>(MasterEntity1, "WithholdingTaxforParty", "Administration");
                    }

                    if (party != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (party != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
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
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M028_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M028_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M028_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M028_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M028_I> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M028_I> result)
        {
            isNewRecord = true;
            DataGridCollection.Refresh();
            MasterEntity = new ObservableCollection<ADM_M028_I>();
            party = "";
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M028_I> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M028_I> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M028_I> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M028_I> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M028_I> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M028_I> result)
        {
            throw new NotImplementedException();
        }
        #endregion

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
            if (_DataGridCollection != null)
            {
                _DataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M028_I_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }


        #endregion
    }
}
