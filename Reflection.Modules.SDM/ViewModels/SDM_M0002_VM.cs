using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Admin;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0002_VM : WorkspaceViewModel<ADM_M001_H>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_H>> repository = new WebServiceRepository<List<ADM_M001_H>>();
        WebServiceRepository<MultipleContextADM_M001_H> repository_MC = new WebServiceRepository<MultipleContextADM_M001_H>();
        WebServiceRepository<MultipleContextADM_M001_H> repository_MCTemp = new WebServiceRepository<MultipleContextADM_M001_H>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0002_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASSalesGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesGrp
        {
            get { return _ASSalesGrp; }
            set
            {
                if (_ASSalesGrp != value)
                {
                    _ASSalesGrp = value; RaisePropertyChanged("ASSalesGrp");
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
                    if (SourceName == "SalesGroup")
                    { ASDefault = ASSalesGrp; }

                }
            }
        }

        #endregion

        #region Declarations       

        private MultipleContextADM_M001_H _MC;
        public MultipleContextADM_M001_H MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContextADM_M001_H _MCTemp;
        public MultipleContextADM_M001_H MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContextADM_M001_H _MCTemp1;
        public MultipleContextADM_M001_H MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M001_H _MasterEntity;
        public ADM_M001_H MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexSalesGrp;
        public int dgSelectedIndexSalesGrp
        {
            get
            { return _dgSelectedIndexSalesGrp; }
            set
            {
                if (_dgSelectedIndexSalesGrp != value)
                {
                    _dgSelectedIndexSalesGrp = value;
                    RaisePropertyChanged("dgSelectedIndexSalesGrp");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_H> _SalesGroupCollection;
        public ObservableCollection<ADM_M001_H> SalesGroupCollection
        {
            get { return _SalesGroupCollection; }
            set
            {
                if (_SalesGroupCollection != value)
                {
                    _SalesGroupCollection = value;
                    SalesGroupCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("SalesGroupCollection");
                }
            }
        }

        private ICollectionView _SGCollection1;
        public ICollectionView SGCollection1
        {
            get { return _SGCollection1; }
            set { _SGCollection1 = value; RaisePropertyChanged("SGCollection1"); }
        }

        private List<ADM_M001_H> _SelectedList;
        public List<ADM_M001_H> SelectedList
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

        #region Constructor
        public SDM_M0002_VM(string ts_code) : base()
        {
            SalesGroupCollection = new ObservableCollection<ADM_M001_H>();
            MasterEntity = new ADM_M001_H();

            MC = new MultipleContextADM_M001_H();
            MCTemp = new MultipleContextADM_M001_H();
            MCTemp1 = new MultipleContextADM_M001_H();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            SalesGroupCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextADM_M001_H>(MC, Request, "SalesGroupMaster", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SalesGroupCollection = MC.SalesGroupList;
                SelectedList = SalesGroupCollection.ToList();

                SGCollection1 = CollectionViewSource.GetDefaultView(MC.SalesGroupList);
                SGCollection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.SalesOrgList, TheFilter, SuggestedValue, "so_code", "so_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSalesGrp = new AutoSuggestTextViewModel<dynamic>(MC.SalesOrgList, TheFilter, SuggestedValue, "so_code", "so_code", true);
                ASSalesGrp.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.client = AppSessionState.client; ;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_H)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_H item in e.NewItems)
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
            if (MasterEntity.sg_code == null || MasterEntity.sg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the SG Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.sg_name == null || MasterEntity.sg_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the SG Name...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.so_code == null || MasterEntity.so_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select the SO Code...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_H> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_H();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M001_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_H> result)
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

        protected override void OnSaveAction(InquiryActionResult<ADM_M001_H> result)
        {
            try
            {
                List<ADM_M001_H> RequestList = new List<ADM_M001_H>();
                foreach (ADM_M001_H item in SalesGroupCollection)
                {
                    if (item.Click == true)
                    {
                        RequestList.Add(item);

                        MasterEntity.sg_code = item.sg_code;   //For Validation Purpose
                        MasterEntity.sg_name = item.sg_name;   //For Validation Purpose
                        MasterEntity.so_code = item.so_code;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M001_H>>(RequestList, "SalesGroupMaster", "Administration");

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
                if (MC.SalesGroupList != null)
                {
                    //SalesGroupCollection.Clear();
                    var tempEntity = MC.SalesGroupList;
                }
                else
                {
                    MC.SalesGroupList = new ObservableCollection<ADM_M001_H>();
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

        #region Filter String
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
            if (_SGCollection1 != null)
            {
                _SGCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_H;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.sg_desc != null && data.sg_desc.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString.ToString().ToLower()));

                }
                return true;
            }
            return false;
        }



        #endregion

        #endregion
    }
}
