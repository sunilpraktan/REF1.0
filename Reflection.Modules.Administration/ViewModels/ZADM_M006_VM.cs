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
    public class ZADM_M006_VM : WorkspaceViewModel<ZADM_M006>
    {
        bool blNew = true;
        WebServiceRepository<ZADM_M006> repository = new WebServiceRepository<ZADM_M006>();
        WebServiceRepository<MultipleContext_ZADM_M006> repository_M = new WebServiceRepository<MultipleContext_ZADM_M006>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringMake;

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set
            {
                _MakeCollection = value;

                RaisePropertyChanged("MakeCollection");
            }
        }
        
        #endregion      
        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMake
        {
            get;
            private set;
        }       
        #endregion       
        #region ZADM_M006
        private List<ZADM_M006> _SelectedList;
        public List<ZADM_M006> SelectedList
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
        private ZADM_M006 _SelectedZADM_M006;
        public ZADM_M006 SelectedZADM_M006
        {
            get
            {
                this.ErrorExist = _SelectedZADM_M006.HasErrors;
                return _SelectedZADM_M006;
            }
            set
            {
                if (_SelectedZADM_M006 != value)
                {
                    _SelectedZADM_M006 = value;
                    RaisePropertyChanged("SelectedZADM_M006");
                    value.BeginEdit();
                }
            }
        }
        #endregion
        #region ADM_M032_P
        private List<ADM_M032_P> _SelectedMakeDtls;
        public List<ADM_M032_P> SelectedMakeDtls
        {
            get { return _SelectedMakeDtls; }
            set
            {
                if (_SelectedMakeDtls != value)
                {
                    _SelectedMakeDtls = value;
                    RaisePropertyChanged("SelectedMakeDtls");
                }
            }
        }
        private ICollectionView _MakeList;
        public ICollectionView MakeList
        {
            get { return _MakeList; }
            set
            {
                _MakeList = value;
                RaisePropertyChanged("MakeList");
            }
        }

        private ADM_M032_P _SelectedMakeList;
        public ADM_M032_P SelectedMakeList
        {
            get { return _SelectedMakeList; }
            set
            {
                if (_SelectedMakeList != value)
                {
                    _SelectedMakeList = value;                   
                    RaisePropertyChanged("SelectedMakeList");
                    
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
        public ZADM_M006_VM(string ts_code)
            : base()
        {
            SelectedList = new List<ZADM_M006>();
            SelectedZADM_M006 = new ZADM_M006();
            SelectedZADM_M006.ValidateAsync().Wait();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {                    
                    return;
                }
                GetSelectedList(items);
            });
           
            SelectionChangedCommandMake = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }
                 GetSelectedMakeDetails(items);
             });
            LoadInitialData();
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZADM_M006> SelectedInkList = list.Cast<ZADM_M006>().ToList();
            if (SelectedInkList.Count > 0)
            {
                SelectedZADM_M006 = (ZADM_M006)SelectedInkList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }
        private void GetSelectedMakeDetails(IList MakeList)
        {
            IList list = MakeList as IList;
            List<ADM_M032_P> SelectedMakeDetailsTemp = list.Cast<ADM_M032_P>().ToList();
            if (SelectedMakeDetailsTemp.Count > 0)
            {
                SelectedZADM_M006.make_id = Convert.ToInt32(SelectedMakeDetailsTemp[0].MakeCode);
                SelectedZADM_M006.Make = SelectedMakeDetailsTemp[0].Make;
            }

        }
        private void LoadInitialData()
        {
            try
            {
                MultipleContext_ZADM_M006 MC = new  MultipleContext_ZADM_M006();
                MC = repository_M.GetDataWithReturnDomainObject<MultipleContext_ZADM_M006>(MC, "ZADM_M006_Data", "InkMaster", "Administration", "", 0, "");
                SelectedList = MC.Ink_Master;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                MakeCollection = CollectionViewSource.GetDefaultView(MC.Make_Dtls);
                MakeCollection.Filter = new Predicate<object>(MakeFilter);   
               
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
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ZADM_M006> result)
        {
            try
            {
                this.SelectedZADM_M006.EndEdit();
                SelectedZADM_M006.add_by = AppSessionState.UserID;
                if (blNew == true)
                {
                    SelectedZADM_M006 = repository.SaveWithReturnDomainObject<ZADM_M006>(SelectedZADM_M006, "InkMaster", "Administration");
                    SelectedList.Add(SelectedZADM_M006);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ZADM_M006>(SelectedZADM_M006, "InkMaster", "Administration");
                }
                if (SelectedZADM_M006.ink_id.ToString() != null || SelectedZADM_M006.ink_id.ToString() == "")
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M006> result)
        {
            blNew = true;
            SelectedZADM_M006 = new ZADM_M006();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M006> result)
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
                this.SelectedZADM_M006.EndEdit();
                string response = repository.Delete(SelectedZADM_M006.ink_id, "InkMaster", "Administration");
                SelectedList.Remove(SelectedZADM_M006);
                _dataGridCollection.Refresh();
                SelectedZADM_M006 = new ZADM_M006();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M006> result)
        {
            SelectedZADM_M006.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M006> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M006> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M006 = SelectedZADM_M006;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M006> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M006 = SelectedZADM_M006;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M006> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M006 = SelectedZADM_M006;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M006> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Filters For Make
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
        public string FilterStringMake
        {
            get { return _filterStringMake; }
            set
            {
                _filterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterCollectionMake();
            }
        }
        public bool MakeFilter(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMake))
                {
                    return (data.Make != null && data.Make.ToLower().Contains(_filterStringMake.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion
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
            var data = obj as ZADM_M006;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.ink != null && data.ink.ToLower().Contains(_filterString.ToLower())) ||
                         (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString.ToLower())
                         || data.desc != null && data.desc.ToString().Contains(_filterString.ToLower()));                   
                }
                return true;
            }
            return false;
        }

        
    }
}
