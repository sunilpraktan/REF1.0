using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System.Collections;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M031_VM : WorkspaceViewModel<ADM_M031>
    {
        bool blNew = true;
        WebServiceRepository<List<ADM_M031>> repository_list = new WebServiceRepository<List<ADM_M031>>();
        WebServiceRepository<ADM_M031> repository = new WebServiceRepository<ADM_M031>();


        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M031.HasErrors;
        }
       
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        private List<ADM_M031> _SelectedList;
        public List<ADM_M031> SelectedList
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

        private ADM_M031 _SelectedADM_M031;
        public ADM_M031 SelectedADM_M031
        {
            get
            {
                this.ErrorExist = _SelectedADM_M031.HasErrors;
                return _SelectedADM_M031;
            }
            set
            {
                if (_SelectedADM_M031 != value)
                {
                    _SelectedADM_M031 = value;
                    RaisePropertyChanged("SelectedADM_M031");
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


        public ADM_M031_VM() : base()
        {
            ADM_M031.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new List<ADM_M031>();
            SelectedADM_M031 = new ADM_M031();
            SelectedADM_M031.ValidateAsync().Wait();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            LoadInitialData();
        }

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M031> tSelectedItemsList = list.Cast<ADM_M031>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M031 = (ADM_M031)tSelectedItemsList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                SelectedList = repository_list.GetDataWithReturnDomainObject<List<ADM_M031>>(SelectedList, "ADM_M031_Data", "Parameter_Master", "Administration", "", 0, "");
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

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ADM_M031> result)
        {
            try
            {
                this.SelectedADM_M031.EndEdit();
                if (blNew == true)
                {
                    SelectedADM_M031.add_by = AppSessionState.UserID;
                    SelectedADM_M031 = repository.SaveWithReturnDomainObject<ADM_M031>(SelectedADM_M031, "Parameter_Master", "Administration");
                    SelectedList.Add(SelectedADM_M031);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedADM_M031.editby = AppSessionState.UserID;
                    string response = repository.Update<ADM_M031>(SelectedADM_M031, "Parameter_Master", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M031> result)
        {
            blNew = true;
            SelectedADM_M031 = new ADM_M031();
            _dataGridCollection.Refresh();
            SelectedADM_M031.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M031> result)
        {
            if (SelectedADM_M031.para_code != null)
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
                    SelectedADM_M031.CancelEdit();
                    string response = repository.Delete(SelectedADM_M031.para_code, "Parameter_Master", "Administration");
                    SelectedList.Remove(SelectedADM_M031);
                    _dataGridCollection.Refresh();
                    SelectedADM_M031 = new ADM_M031();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M031> result)
        {
            SelectedADM_M031.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M031> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M031> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M031 = SelectedADM_M031;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M031> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M031 = SelectedADM_M031;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M031> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M031 = SelectedADM_M031;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M031> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M031> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M031> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M031> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M031> result)
        {
            throw new NotImplementedException();
        }
        //protected override void OnExportAction(InquiryActionResult<ADM_M031> result)
        //{
        //    try
        //    {
        //        ExportToExcel<ADM_M031, List<ADM_M031>> export = new ExportToExcel<ADM_M031, List<ADM_M031>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        //        export.dataToPrint = (List<ADM_M031>)view.SourceCollection;
        //        export.GenerateReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }

        //}

        #endregion

        #region FilterMethods
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
            var data = obj as ADM_M031;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.para_code != null && data.para_code.ToString().Contains(_filterString.ToLower())) ||
                         (data.para_name != null && data.para_name.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        


        #endregion
    }

}
