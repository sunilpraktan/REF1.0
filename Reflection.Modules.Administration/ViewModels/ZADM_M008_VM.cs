using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Administration.ViewModels
{
    class ZADM_M008_VM : WorkspaceViewModel<ZADM_M008>
    {
        #region Declaration
        bool NewRecord = true;
        WebServiceRepository<ZADM_M008> repository = new WebServiceRepository<ZADM_M008>();
        WebServiceRepository<MultipleContext_ZADM_M008> repository_MC = new WebServiceRepository<MultipleContext_ZADM_M008>();
        WebServiceRepository<MultipleContext_ZADM_M008> repository_MCTemp = new WebServiceRepository<MultipleContext_ZADM_M008>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_ZADM_M008 _MC = new MultipleContext_ZADM_M008();
        public MultipleContext_ZADM_M008 MC
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
        private MultipleContext_ZADM_M008 _MCTemp = new MultipleContext_ZADM_M008();
        public MultipleContext_ZADM_M008 MCTemp
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

        private ZADM_M008 _MasterEntity;
        public ZADM_M008 MasterEntity
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
                    value.BeginEdit();
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

        #region Relay Command Declaration
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region List
        private List<ZADM_M008Flip> _FlipGridData;
        public List<ZADM_M008Flip> FlipGridData
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
        #endregion

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        #endregion

        #region Constructor
        public ZADM_M008_VM() : base()
        {
            MasterEntity = new ZADM_M008();
            FlipGridData = new List<ZADM_M008Flip>();
            MasterEntity.ValidateAsync().Wait();
            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            LoadInitialData();
        }
        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.edit_by = AppSessionState.UserID;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ZADM_M008Flip ParameterEntityObject = null;
            MasterEntity = new ZADM_M008();


            if (((IEnumerable)ParameterObject).Cast<ZADM_M008Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZADM_M008Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.tot_len_id;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M008>(MCTemp, Request, "TotalLengthMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count>0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                
            }
            SelectedTabControlIndex = 0;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.FlipGridData = (List<ZADM_M008Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.FlipGridData);
                FlipGridData.Add(MC.FlipGridData[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("tot_len_id", ListSortDirection.Descending));
            }
        }
        private bool Validation()
        {
            
            if (MasterEntity.details == null || MasterEntity.details == "")
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
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZADM_M008>(MC, Request, "TotalLengthMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.FlipGridData.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);
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

        //#region Methods
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertychanged(string propertyName)
        //{
        //    // take a copy to prevent thread issues
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //#endregion

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ZADM_M008> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ZADM_M008>(MasterEntity, "TotalLengthMaster", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ZADM_M008>(MasterEntity, "TotalLengthMaster", "Administration");
                    }

                         SetBusinessEntitiesAfterLoad("Save", "");

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();  
                        NewRecord = false;
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M008> result)
        {
            NewRecord = true;
            MasterEntity = new ZADM_M008();
            MasterEntity.ValidateAsync().Wait();
            FlipDataGridCollection.Refresh();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M008> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M008> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M008> result)
        {
           
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M008> result)
        {
            
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M008> result)
        {
          
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M008> result)
        {
            
        }
        protected override void OnDocumentAction()
        {
            
        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M008> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M008> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M008> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M008> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M008> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Filter For Flip Grid Data
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as ZADM_M008Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.tot_len_id != null && data.tot_len_id.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.total_len != null && data.total_len.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.details != null && data.details.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));     
                }
                return true;
            }
            return false;
        }

        

        #endregion

        #endregion

    }
}
