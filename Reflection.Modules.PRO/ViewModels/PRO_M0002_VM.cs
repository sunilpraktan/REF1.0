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
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_M0002_VM : WorkspaceViewModel<ADM_M001_P>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_P>> repository = new WebServiceRepository<List<ADM_M001_P>>();
        WebServiceRepository<MultipleContext_ADM_M001_P> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_P>();
        WebServiceRepository<MultipleContext_ADM_M001_P> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M001_P>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_M0002_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASPOCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPOCode
        {
            get { return _ASPOCode; }
            set
            {
                if (_ASPOCode != value)
                {
                    _ASPOCode = value; RaisePropertyChanged("ASPOCode");
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
                    if (SourceName == "PO_Code")
                    { ASDefault = ASPOCode; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContext_ADM_M001_P _MC;
        public MultipleContext_ADM_M001_P MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_P _MCTemp;
        public MultipleContext_ADM_M001_P MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M001_P _MCTemp1;
        public MultipleContext_ADM_M001_P MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M001_P _MasterEntity;
        public ADM_M001_P MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexPG;
        public int dgSelectedIndexPG
        {
            get
            { return _dgSelectedIndexPG; }
            set
            {
                if (_dgSelectedIndexPG != value)
                {
                    _dgSelectedIndexPG = value;
                    RaisePropertyChanged("dgSelectedIndexPG");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_P> _PGCollection;
        public ObservableCollection<ADM_M001_P> PGCollection
        {
            get { return _PGCollection; }
            set
            {
                if (_PGCollection != value)
                {
                    _PGCollection = value;
                    PGCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("PGCollection");
                }
            }
        }

        private ICollectionView _PGCollection1;
        public ICollectionView PGCollection1
        {
            get { return _PGCollection1; }
            set { _PGCollection1 = value; RaisePropertyChanged("PGCollection1"); }
        }

        private List<ADM_M001_P> _SelectedList;
        public List<ADM_M001_P> SelectedList
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

        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public PRO_M0002_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_P();
            PGCollection = new ObservableCollection<ADM_M001_P>();

            MC = new MultipleContext_ADM_M001_P();
            MCTemp = new MultipleContext_ADM_M001_P();
            MCTemp1 = new MultipleContext_ADM_M001_P();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            PGCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_P>(MC, Request, "PurchaseGroupMaster", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                PGCollection = MC.PGList;
                //SelectedList = (MC.PGList).ToList();
                SelectedList = PGCollection.ToList();

                PGCollection1 = CollectionViewSource.GetDefaultView(MC.PGList);
                PGCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.POList, TheFilter, SuggestedValue, "po_code", "po_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPOCode = new AutoSuggestTextViewModel<dynamic>(MC.POList, TheFilter, SuggestedValue, "po_code", "po_code", true);
                ASPOCode.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_P)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_P item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        //item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.Click = true;
                        item.userid = AppSessionState.UserID;
                        item.add_by= AppSessionState.UserID;
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
            if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the PG Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.pg_name == null || MasterEntity.pg_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the PG Name...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.po_code == null || MasterEntity.po_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please select the PO Code...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }

        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_P> result)
        {
            try
            {
                List<ADM_M001_P> RequestList = new List<ADM_M001_P>();
                foreach (ADM_M001_P item in PGCollection)
                {
                    if (item.Click == true)
                    {
                        item.add_by = AppSessionState.UserID;
                        item.editby = MasterEntity.editby;
                        //item.active = MasterEntity.active;
                        item.user_source1 = MasterEntity.user_source1;
                        item.user_source2 = MasterEntity.user_source2;
                        item.client = AppSessionState.client;

                        RequestList.Add(item);
                        MasterEntity.client = AppSessionState.client;
                        MasterEntity.pg_code = item.pg_code;   //For Validation Purpose
                        MasterEntity.pg_name = item.pg_name;   //For Validation Purpose
                        MasterEntity.po_code = item.po_code;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M001_A>>(RequestList, "PurchaseGroupMaster", "Administration");

                    if (SelectedList != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                //SetBusinessEntitiesAfterLoad("Save", "");
                //isNewRecord = false;
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
                if (MC.PGList != null)
                {
                    PGCollection.Clear();
                    //MC.PGList = (ObservableCollection<ADM_M001_P>)obj.XMLToObject(MC.PGList, MC.PGList);

                }
                else
                {
                    MC.PGList = new ObservableCollection<ADM_M001_P>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_P> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_P> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_P> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_P> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_P> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_P> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_P();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_P> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_P> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_P> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_P> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_P> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_P> result)
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
            if (_PGCollection1 != null)
            {
                _PGCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pg_desc != null && data.pg_desc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString.ToLower())
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
