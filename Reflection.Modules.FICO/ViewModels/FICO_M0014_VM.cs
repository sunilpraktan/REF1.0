using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0014_VM : WorkspaceViewModel<ACC_M003_O>
    {
        bool NewRecord = true;

        WebServiceRepository<ACC_M003_O> repository = new WebServiceRepository<ACC_M003_O>();
        WebServiceRepository<MultipleContext_ACC_M003_O> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_O>();
        WebServiceRepository<MultipleContext_ACC_M003_O> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003_O>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration        

        private ACC_M003_O _MasterEntity;
        public ACC_M003_O MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                }
            }
        }

        private MultipleContext_ACC_M003_O _MC;
        public MultipleContext_ACC_M003_O MC
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

        private bool _ReadOnlyFlag;   //movement type enable disable
        public bool ReadOnlyFlag
        {
            get { return _ReadOnlyFlag; }
            set { _ReadOnlyFlag = value; RaisePropertyChanged("ReadOnlyFlag"); }
        }

        private List<ACC_M003_O> _FlipGridData;
        public List<ACC_M003_O> FlipGridData
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

        #region Collection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        #endregion

        #region StringList

        List<string> _stringListView;
        public List<string> StringListView
        {
            get { return _stringListView; }
            set
            {
                if (_stringListView != value)
                {
                    _stringListView = value;
                }
            }
        }

        #endregion

        #region Relay Command Decalration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }

        #endregion

        #region Relay Command Actions

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ACC_M003_O ParameterEntityObject = null;


                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ACC_M003_O>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M003_O>().ToList()[0];
                        Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.con_type;
                        MC = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_O>(MC, Request, "TaxConditionMaster", "Finance", "LoadDocumentByDocumentNumber", 0, "");
                        MasterEntity = MC.MasterEntity[0];

                        SelectedTabControlIndex = 0;
                        NewRecord = false;
                        ReadOnlyFlag = true;
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
                if (MasterEntity.XmlDataDocument_ACC_M003_O_FLIP != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.FlipGridData = (List<ACC_M003_O>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_M003_O_FLIP, MC.FlipGridData);
                    FlipGridData.Add(MC.FlipGridData[0]);
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

        #endregion

        #region Constructor 
        public FICO_M0014_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_O();
            FlipGridData = new List<ACC_M003_O>();
            MC = new MultipleContext_ACC_M003_O();
            MasterEntity.ValidateAsync().Wait();

            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });

            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                ReadOnlyFlag = false;
                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_O>(MC, Request, "TaxConditionMaster", "Finance", "LoadAll", 0, "");

                FlipGridData = MC.FlipGridData.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

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

        #region Validation
        private bool Validation()
        {
            if (MasterEntity.con_type == null || MasterEntity.con_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Condition Type...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.con_cat == null || MasterEntity.con_cat == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Condition Cat...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.con_desc == null || MasterEntity.con_desc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Description...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        #endregion

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_O> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M003_O>(MasterEntity, "TaxConditionMaster", "Finance");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_M003_O>(MasterEntity, "TaxConditionMaster", "Finance");
                    }

                    if (NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    if (NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    ReadOnlyFlag = true;
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
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_O> result)
        {
            NewRecord = true;
            MasterEntity = new ACC_M003_O();
            ReadOnlyFlag = false;
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_O> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_O> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_O> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_O> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_O> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_O> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_O> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_O> result)
        {

        }

        #endregion

        #region Filters
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
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
            var data = obj as ACC_M003_O;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return

                        (data.con_cat != null && data.con_cat.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.con_type != null && data.con_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }



        #endregion
    }
}
