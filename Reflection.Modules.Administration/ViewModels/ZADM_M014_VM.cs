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
using Reflection.BusinessEntity;

namespace Reflection.Modules.Administration.ViewModels
{
    class ZADM_M014_VM : WorkspaceViewModel<ZADM_M014>
    {
        bool blNew = true;
        WebServiceRepository<ZADM_M014> repository = new WebServiceRepository<ZADM_M014>();
        WebServiceRepository<MultipleContext_ZADM_M014> repository_M = new WebServiceRepository<MultipleContext_ZADM_M014>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringMachine;

   
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        #region Relay Commands
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandMachine
        {
            get;
            private set;
        }

        #endregion

        #region Entity Object

        private List<ZADM_M014> _SelectedList;
        public List<ZADM_M014> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private ZADM_M014 _SelectedZADM_M014;
        public ZADM_M014 SelectedZADM_M014
        {
            get
            {
                this.ErrorExist = _SelectedZADM_M014.HasErrors;
                return _SelectedZADM_M014;
            }
            set
            {
                if (_SelectedZADM_M014 != value)
                {
                    _SelectedZADM_M014 = value;
                    RaisePropertyChanged("SelectedZADM_M014");
                    value.BeginEdit();
                }
            }
        }

        #endregion

        #region ICollection view

        private ICollectionView _CollectionMachineList;
        public ICollectionView CollectionMachineList
        {
            get { return _CollectionMachineList; }
            set
            {
                _CollectionMachineList = value;
                RaisePropertyChanged("CollectionMachineList");
            }
        }

        #endregion

        #region Constructor
        public ZADM_M014_VM() : base()
        {
            SelectedList = new List<ZADM_M014>();
            SelectedZADM_M014 = new ZADM_M014();
            SelectedZADM_M014.ValidateAsync().Wait();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });

            SelectionChangedCommandMachine = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }
                 Machine(items);
             });
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                MultipleContext_ZADM_M014 MC = new MultipleContext_ZADM_M014();
                MC = repository_M.GetDataWithReturnDomainObject<MultipleContext_ZADM_M014>(MC, "ZADM_M014_Data", "WritingTestMaster", "Administration", "", 0, "");
                SelectedList = MC.WritingTestMaster_1;

                CollectionMachineList = CollectionViewSource.GetDefaultView(MC.MachineMaster_1);
                
                CollectionMachineList.Filter = new Predicate<Object>(FilterMachine);

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
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

        private void Machine(IList MachineList)
        {
            IList list = MachineList as IList;
            List<ZADM_M013_PopUp> SelectedMachineTemp = list.Cast<ZADM_M013_PopUp>().ToList();
            if (SelectedMachineTemp.Count > 0)
            {
                SelectedZADM_M014.machine_id = SelectedMachineTemp[0].machine_id;
                SelectedZADM_M014.Machine= SelectedMachineTemp[0].machinecode;
            }
        }

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZADM_M014> tSelectedItemsList = list.Cast<ZADM_M014>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZADM_M014 = (ZADM_M014)tSelectedItemsList[0];
                blNew = false;
            }
        }
        #endregion

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ZADM_M014> result)
        {
            try
            {
                this.SelectedZADM_M014.EndEdit();
                if (blNew == true)
                {
                    SelectedZADM_M014.add_by = AppSessionState.UserID;
                    SelectedZADM_M014 = repository.SaveWithReturnDomainObject<ZADM_M014>(SelectedZADM_M014, "WritingTestMaster", "Administration");
                    SelectedList.Add(SelectedZADM_M014);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ZADM_M014>(SelectedZADM_M014, "WritingTestMaster", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M014> result)
        {
            blNew = true;
            SelectedZADM_M014 = new ZADM_M014();
            _dataGridCollection.Refresh();
            SelectedZADM_M014.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M014> result)
        {

            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                SelectedZADM_M014.CancelEdit();
                string response = repository.Delete(SelectedZADM_M014.writingtest_id, "WritingTestMaster", "Administration");
                SelectedList.Remove(SelectedZADM_M014);
                _dataGridCollection.Refresh();
                SelectedZADM_M014 = new ZADM_M014();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M014> result)
        {
            SelectedZADM_M014.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M014> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M014> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M014 = SelectedZADM_M014;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M014> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M014 = SelectedZADM_M014;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M014> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M014 = SelectedZADM_M014;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M014> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M014> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M014> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M014> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M014> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region FilterMethods

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
            var data = obj as ZADM_M014;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.arialrotation != null && data.arialrotation.ToString().Contains(_filterString.ToLower())) ||
                        (data.writspeed != null && data.writspeed.ToString().Contains(_filterString.ToLower())) ||
                        (data.paperfeed != null && data.paperfeed.ToString().Contains(_filterString.ToLower())) ||
                        (data.machine_id != null && data.machine_id.ToString().Contains(_filterString.ToLower())) ||
                        (data.angle != null && data.angle.ToString().Contains(_filterString.ToLower())) ||
                         (data.weight != null && data.weight.ToString().Contains(_filterString.ToLower())) ||
                          (data.effwt != null && data.effwt.ToString().Contains(_filterString.ToLower())) ||
                          (data.papertype != null && data.papertype.ToString().Contains(_filterString.ToLower())) ||
                        (data.remarks != null && data.remarks.ToString().Contains(_filterString.ToLower())) ||
                         (data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        #region Machine Filter
        public bool FilterMachine(object obj)
        {
            var data = obj as ZADM_M013_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterStringMachine.ToLower()) || data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }


        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("CollectionMachineList");
                FilterCollectionMachine();
            }
        }
        private void FilterCollectionMachine()
        {
            if (_CollectionMachineList != null)
            {
                _CollectionMachineList.Refresh();
            }
        }

        

        #endregion

        #endregion
    }
}
