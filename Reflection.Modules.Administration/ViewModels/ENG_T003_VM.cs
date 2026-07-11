using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity.Admin;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Modules.Administration.ViewModels


{
    public class ENG_T003_VM : WorkspaceViewModel<ENG_T003>

    {

        bool NewRecord = true;
        WebServiceRepository<ENG_T003> repository = new WebServiceRepository<ENG_T003>();
        WebServiceRepository<MultipleContext_ENG_T003> repository_MC = new WebServiceRepository<MultipleContext_ENG_T003>();
        WebServiceRepository<MultipleContext_ENG_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_ENG_T003>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration 

        private ENG_T003 _MasterEntity;
        public ENG_T003 MasterEntity
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
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private MultipleContext_ENG_T003 _MC;
        public MultipleContext_ENG_T003 MC
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


        private MultipleContext_ENG_T003 _MCTemp;
        public MultipleContext_ENG_T003 MCTemp
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

        private int _dgSelectedIndexDetails;
        public int dgSelectedIndexDetails
        {
            get { return _dgSelectedIndexDetails; }
            set
            {
                if (_dgSelectedIndexDetails != value)
                {
                    _dgSelectedIndexDetails = value;
                    RaisePropertyChanged("dgSelectedIndexDetails");
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

        private List<ENG_T003Flip> _FlipGridData;
        public List<ENG_T003Flip> FlipGridData
        {
            get
            {
                return _FlipGridData;
            }
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
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.posting_period = "9";
            MasterEntity.fin_year = "16-17";
            MasterEntity.active = true;
            MasterEntity.t_status = "Draft"; 
        }
        #endregion

        #region Constructor 
        public ENG_T003_VM() : base()
        {
            MasterEntity = new ENG_T003();
            //ItemsEntity = new ObservableCollection<ACC_M007B>();
            FlipGridData = new List<ENG_T003Flip>();
            MC = new MultipleContext_ENG_T003();
            MasterEntity.ValidateAsync().Wait();

            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            //CmdDeleteDataGridRowEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowEntity(cmdPara); });


            // MoveFlag = true;
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MC_ACC_M007>(MC, Request, "TDS_Parameter", "Administration", "LoadAll", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);


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

        #region Relay Command Actions      
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ENG_T003Flip ParameterEntityObject = null;
                // MasterEntity = new CAL_M002();
                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ENG_T003Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ENG_T003Flip>().ToList()[0];
                        Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.spec_para_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ENG_T003>(MC, Request, "TDS_Parameter", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                        MasterEntity = MCTemp.MasterList[0];
                        SelectedTabControlIndex = 0;
                        NewRecord = false;
                        //  MoveFlag = false;

                        if (MCTemp.MasterList.Count > 0)
                        {
                            MasterEntity = MCTemp.MasterList[0];
                        }
                        // ItemsEntity = MCTemp.ItemsList;

                    }
                    if (MasterEntity.id != 0)
                    {
                        NewRecord = false;
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
                if (MasterEntity.XmlDataDocument_ENG_T003FLIP != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ENG_T003Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T003FLIP, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
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

        #region Relay Command Decalration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ENG_T003> result)
        {
            NewRecord = true;
            MasterEntity = new ENG_T003();

            DefaultValues();
        }
            

        protected override void OnDiscardAction(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ENG_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ENG_T003> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will be Deleted forever '{0}'",
                        this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.EndEdit();
                string response = repository.Delete(MasterEntity.spec_para_code, "TDS_Parameter", "Administration");

                MasterEntity = new ENG_T003();
                NewRecord = true;
            }
        }
        protected override void OnSaveAction(InquiryActionResult<ENG_T003> result)
        {
            try
            {
                
                    this.MasterEntity.EndEdit();

                   
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ENG_T003>(MasterEntity, "TDS_Parameter", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_M007>(MasterEntity, "TDS_Parameter", "Administration");
                    }

                    if (MasterEntity.id != 0 && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.id != 0 && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    //MoveFlag = false;
                
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
            var data = obj as ENG_T003Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return

                        (data.t_status!=null &&data.parameter != null && data.spec_para_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion

    }


}
