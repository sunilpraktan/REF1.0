using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.Administration.ViewModels
{
    class ADM_M032_VM : WorkspaceViewModel<ADM_M032>
    {

        #region Declaration
        bool NewRecord = true;
        WebServiceRepository<ADM_M032> repository = new WebServiceRepository<ADM_M032>();
        WebServiceRepository<MultipleContext_ADM_M032> repository_MC = new WebServiceRepository<MultipleContext_ADM_M032>();
        WebServiceRepository<MultipleContext_ADM_M032> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M032>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_ADM_M032 _MC = new MultipleContext_ADM_M032();
        public MultipleContext_ADM_M032 MC
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
        private MultipleContext_ADM_M032 _MCTemp = new MultipleContext_ADM_M032();
        public MultipleContext_ADM_M032 MCTemp
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

        private ADM_M032 _MasterEntity;
        public ADM_M032 MasterEntity
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

        #region Relay Command Declareation
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region List
        private List<ADM_M032Flip> _FlipGridData;
        public List<ADM_M032Flip> FlipGridData
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
        public ADM_M032_VM():base()
        {
            MasterEntity = new ADM_M032();
            FlipGridData = new List<ADM_M032Flip>();
            MasterEntity.ValidateAsync().Wait();
            LoadInitialData();

            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
        }
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M032>(MC, Request, "MakeMaster", "Administration", "LoadInitialData", 0, "");

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

        #region User Defined Mehods
        private void DefaultValues()
        {
            
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.ink = "Ink";

        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ADM_M032Flip ParameterEntityObject = null;
            MasterEntity = new ADM_M032();
           

            if (((IEnumerable)ParameterObject).Cast<ADM_M032Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M032Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.MakeCode;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M032>(MCTemp, Request, "MakeMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                
                MasterEntity = MCTemp.MasterEntity[0];
                
                //SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");

               
            }
            SelectedTabControlIndex = 0;
        }
       private bool Validation()
        {
            if (MasterEntity.Make ==null || MasterEntity.Make =="")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Make...");
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.make_type ==null || MasterEntity.make_type =="")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Make Type...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.Descriptn == null || MasterEntity.Descriptn == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Description...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.FlipGridData = (List<ADM_M032Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.FlipGridData);
                FlipGridData.Add(MC.FlipGridData[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("MakeCode", ListSortDirection.Descending));
            }
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ADM_M032> result)
        {
            NewRecord = true;
            MasterEntity = new ADM_M032();
            MasterEntity.ValidateAsync().Wait();
            FlipDataGridCollection.Refresh();
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M032> result)
        {
            
        }

        protected override void OnDocumentAction()
        {
            
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M032> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M032> result)
        {
           
        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M032> result)
        {
            
        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M032> result)
        {
            
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M032> result)
        {
            
        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M032> result)
        {
          
        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M032> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M032>(MasterEntity, "MakeMaster", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M032>(MasterEntity, "MakeMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.Make !=null || MasterEntity.Make !="")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Can Not Saved Please Try Again");
                        showMessageService.ShowMessage();
                    }
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
            var data = obj as ADM_M032Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData)) 
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.make_type != null && data.make_type.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.Descriptn != null && data.Descriptn.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion
        #endregion
    }
}
