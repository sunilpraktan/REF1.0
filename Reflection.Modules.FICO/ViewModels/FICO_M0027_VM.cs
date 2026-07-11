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
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using System.Windows;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0027_VM : WorkspaceViewModel<ADM_M058>
    {
        bool isNewRecord = true;
        WebServiceRepository<ADM_M058> repository = new WebServiceRepository<ADM_M058>();
        WebServiceRepository<MultipleContext_ADM_M058> repository_MC = new WebServiceRepository<MultipleContext_ADM_M058>();
        WebServiceRepository<MultipleContext_ADM_M058> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M058>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0027_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASQtyUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQtyUnit
        {
            get { return _ASQtyUnit; }
            set
            {
                if (_ASQtyUnit != value)
                {
                    _ASQtyUnit = value; RaisePropertyChanged("ASQtyUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWtUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWtUnit
        {
            get { return _ASWtUnit; }
            set
            {
                if (_ASWtUnit != value)
                {
                    _ASWtUnit = value; RaisePropertyChanged("ASWtUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCode
        {
            get { return _ASItemCode; }
            set
            {
                if (_ASItemCode != value)
                {
                    _ASItemCode = value; RaisePropertyChanged("ASItemCode");
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
                    if (SourceName == "QtyUnit")
                    { ASDefault = ASQtyUnit; }
                    else if (SourceName == "WtUnit")
                    { ASDefault = ASWtUnit; }
                    else if (SourceName == "ItemCode")
                    { ASDefault = ASItemCode; }
                }
            }
        }

        #endregion

        #region Declarations

        private MultipleContext_ADM_M058 _MC;
        public MultipleContext_ADM_M058 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M058 _MCTemp;
        public MultipleContext_ADM_M058 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M058 _MCTemp1;
        public MultipleContext_ADM_M058 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M058 _MasterEntity;
        public ADM_M058 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private ObservableCollection<ADM_M058_A> _DetailEntity;
        public ObservableCollection<ADM_M058_A> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value;
                    DetailEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForDetails);
                    RaisePropertyChanged("DetailEntity");
                }
            }
        }

        private List<ADM_M058_BackFlip> _FlipGridData;
        public List<ADM_M058_BackFlip> FlipGridData
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

        private int _dgSelectedIndexDetail;
        public int dgSelectedIndexDetail
        {
            get
            { return _dgSelectedIndexDetail; }
            set
            {
                if (_dgSelectedIndexDetail != value)
                {
                    _dgSelectedIndexDetail = value;
                    RaisePropertyChanged("dgSelectedIndexDetail");
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

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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

        #region Relay Commands Declaration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddQtyUnit { get; private set; }
        public RelayCommand<object> CmdAddWtUnit { get; private set; }
        public RelayCommand<object> CmdAddItemCode { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowDetail { get; private set; }

        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ADM_M058_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ADM_M058_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M058_A item in e.NewItems)
                    {
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.client = AppSessionState.client;
                        item.add_by = AppSessionState.UserID;
                        item.edit_by = AppSessionState.UserID;
                        item.active = true;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;

                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (DetailEntity.Count > dgSelectedIndexDetail && dgSelectedIndexDetail >= 0)
            {
                this.ErrorExist = false;
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (DetailEntity.Count > dgSelectedIndexDetail && dgSelectedIndexDetail >= 0)
            {
                this.ErrorExist = false;
            }
        }

        #endregion

        #region Constructor
        public FICO_M0027_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M058();
            DetailEntity = new ObservableCollection<ADM_M058_A>();

            MC = new MultipleContext_ADM_M058();
            MCTemp = new MultipleContext_ADM_M058();
            MCTemp1 = new MultipleContext_ADM_M058();

            //ADM_M028_G.ModelEntityUpdated += new EventHandler(ModelUpdated_Detail);

            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdAddQtyUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertQtyUnit(items, true, true, true); });
            CmdAddWtUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertWtUnit(items, true, true, true); });
            CmdAddItemCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemCode(items, true, true, true); });
            CmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M028_F>(MC, Request, "GroupMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Item, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItemCode = new AutoSuggestTextViewModel<dynamic>(MC.Item, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_C_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_C_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_C_P)o).base_unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASQtyUnit = new AutoSuggestTextViewModel<dynamic>(MC.Unit, TheFilter, SuggestedValue, "qty_unit", "unit_code", true);
                ASQtyUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_C_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_C_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_C_P)o).base_unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWtUnit = new AutoSuggestTextViewModel<dynamic>(MC.Unit, TheFilter, SuggestedValue, "wt_unit", "unit_code", true);
                ASWtUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        private void DefaultValues()
        {
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.edit_by = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.client = AppSessionState.client;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            ADM_M058_BackFlip ParameterEntityObject = new ADM_M058_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<ADM_M058_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M058_BackFlip>().ToList()[0];

                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.group_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M058>(MCTemp, Request, "GroupMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterData.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterData[0];
                    }
                    DetailEntity = MCTemp.DetailData;

                    SetBusinessEntitiesAfterLoad("Save", "");

                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("FICO_M0027_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
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
        private void InsertQtyUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Unit.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_C_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_C_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail)
                    {
                        if (DetailEntity[dgSelectedIndexDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndexDetail].qty_unit = POPUPEntityObject.unit_code;
                        }
                        else if (DetailEntity[dgSelectedIndexDetail].qty_unit != POPUPEntityObject.unit_code)
                        {
                            DetailEntity[dgSelectedIndexDetail].qty_unit = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertWtUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Unit.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_C_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_C_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail)
                    {
                        if (DetailEntity[dgSelectedIndexDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndexDetail].wt_unit = POPUPEntityObject.unit_code;
                        }
                        else if (DetailEntity[dgSelectedIndexDetail].qty_unit != POPUPEntityObject.unit_code)
                        {
                            DetailEntity[dgSelectedIndexDetail].wt_unit = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertItemCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Item.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail)
                    {
                        if (DetailEntity[dgSelectedIndexDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity[dgSelectedIndexDetail].ItemCode = POPUPEntityObject.ItemCode;
                        }
                        else if (DetailEntity[dgSelectedIndexDetail].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            DetailEntity[dgSelectedIndexDetail].ItemCode = POPUPEntityObject.ItemCode;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private bool Validation()
        {
            if (MasterEntity.group_code == null || MasterEntity.group_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Party ID...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.group_name == null || MasterEntity.group_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Party Name...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity.Count > i && DetailEntity[dgSelectedIndexDetail].id == 0)
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_ADM_M058_A != null)
                {
                    DetailEntity.Clear();
                    MC.DetailData = (ObservableCollection<ADM_M058_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_ADM_M058_A, MC.DetailData);
                    DetailEntity = MC.DetailData;
                }
                else
                {
                    MC.DetailData = new ObservableCollection<ADM_M058_A>();
                }
                if (MasterEntity.XmlDataDocument_ADM_M058_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<ADM_M058_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_ADM_M058_Flip, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    DataGridCollection.Refresh();
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
            //ASCountry.AutoSuggestVM.Suggestion = MC.Country.Find(x => x.country_code == MasterEntity.country_code);
            //ASState.AutoSuggestVM.Suggestion = MC.State.Find(x => x.state_code == MasterEntity.state_code);
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ADM_M058> result)
        {
            try
            {
                MasterEntity.edit_by = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_ADM_M058_A = obj.ObjectToXML(DetailEntity);
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M058>(MasterEntity, "GroupMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M058>(MasterEntity, "GroupMaster", "Administration");
                    }

                    if (MasterEntity.group_code != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.group_code != null && isNewRecord == false)
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
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M058> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M058> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M058> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M058> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M058> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M058> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M058();
            DetailEntity = new ObservableCollection<ADM_M058_A>();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M058> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M058> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M058> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M058> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M058> result)
        {

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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M058_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.group_code != null && data.group_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.group_name != null && data.group_name.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M058> result)
        {

        }


        #endregion
    }
}
