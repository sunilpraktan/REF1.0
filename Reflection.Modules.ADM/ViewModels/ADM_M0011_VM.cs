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

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0011_VM : WorkspaceViewModel<ADM_M038_B>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M038_B> repository = new WebServiceRepository<ADM_M038_B>();
        WebServiceRepository<MultipleContext_ADM_M038_B> repositoryM = new WebServiceRepository<MultipleContext_ADM_M038_B>();

        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringMeasurCls;

        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M038_B.HasErrors;
        }


        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _MeasurClsCollection;
        public ICollectionView MeasurClsCollection
        {
            get { return _MeasurClsCollection; }
            set
            {
                _MeasurClsCollection = value;

                RaisePropertyChanged("MeasurClsCollection");
            }
        }
        #endregion
        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMeasurCls
        {
            get;
            private set;
        }
        #endregion
        #region ADM_M038_B
        private List<ADM_M038_B> _SelectedList;
        public List<ADM_M038_B> SelectedList
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
        private ADM_M038_B _SelectedADM_M038_B;
        public ADM_M038_B SelectedADM_M038_B
        {
            get
            {
                this.ErrorExist = _SelectedADM_M038_B.HasErrors;
                return _SelectedADM_M038_B;
            }
            set
            {
                if (_SelectedADM_M038_B != value)
                {
                    _SelectedADM_M038_B = value;
                    this.ErrorExist = _SelectedADM_M038_B.HasErrors;
                    RaisePropertyChanged("SelectedADM_M038_B");
                    value.BeginEdit();
                }
            }
        }
        #endregion
        #region ADM_M038_A_P         
        private List<ADM_M038_A_P> _SelectedMeasurClsList;
        public List<ADM_M038_A_P> SelectedMeasurClsList
        {
            get { return _SelectedMeasurClsList; }
            set
            {
                if (_SelectedMeasurClsList != value)
                {
                    _SelectedMeasurClsList = value;
                    RaisePropertyChanged("SelectedMeasurClsList");

                }
            }
        }
        #endregion

        MultipleContext_ADM_M038_B _MC = new MultipleContext_ADM_M038_B();
        public MultipleContext_ADM_M038_B MC
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
        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set { _SelectedTabControlIndex = value; RaisePropertyChanged("SelectedTabControlIndex"); }
        }
        public ADM_M0011_VM(string ts_code)
            : base()
        {
            ADM_M038_B.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new List<ADM_M038_B>();
            SelectedADM_M038_B = new ADM_M038_B();
            SelectedMeasurClsList = new List<ADM_M038_A_P>();
            SelectedADM_M038_B.ValidateAsync().Wait();
            MC = new MultipleContext_ADM_M038_B();
            SelectedADM_M038_B.client = AppSessionState.client;
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            SelectionChangedCommandMeasurCls = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedMeasurClsDetails(items);
            });
            LoadInitialData();
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M038_B> tSelectedItemsList = list.Cast<ADM_M038_B>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M038_B = (ADM_M038_B)tSelectedItemsList[0];
                blNew = false;
            }
            SelectedTabControlIndex = 0;
        }
        private void GetSelectedMeasurClsDetails(IList MeasurClsList)
        {
            IList list = MeasurClsList as IList;
            List<ADM_M038_A_P> GetSelectedMeasurClsDetailsTemp = list.Cast<ADM_M038_A_P>().ToList();
            if (GetSelectedMeasurClsDetailsTemp.Count > 0)
            {
                SelectedADM_M038_B.class_id = (GetSelectedMeasurClsDetailsTemp[0].id);
                SelectedADM_M038_B.class_name = GetSelectedMeasurClsDetailsTemp[0].class_name;
                SelectedADM_M038_B.unit_code = GetSelectedMeasurClsDetailsTemp[0].base_unit;
            }

        }
        private void LoadInitialData()
        {
            try
            {
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ADM_M038_B>(MC, "ADM_M038_B_Data", "UOM_Master", "Administration", "", 0, "");
                SelectedList = MC.UOM_Master;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                MeasurClsCollection = CollectionViewSource.GetDefaultView(MC.Measur_Cls);
                MeasurClsCollection.Filter = new Predicate<object>(MeasurClsFilter);

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
        protected override void OnSaveAction(InquiryActionResult<ADM_M038_B> result)
        {
            try
            {
                SelectedADM_M038_B.add_by = AppSessionState.UserID;
                if (blNew == true)
                {
                    SelectedADM_M038_B = repository.SaveWithReturnDomainObject<ADM_M038_B>(SelectedADM_M038_B, "UOM_Master", "Administration");
                    SelectedList.Add(SelectedADM_M038_B);
                    this.SelectedADM_M038_B.EndEdit();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    int y = 0;
                    if (SelectedADM_M038_B.active == false)
                    {
                        y = 1;
                    }
                    SelectedADM_M038_B = repository.UpdateWithReturnDomainObject<ADM_M038_B>(SelectedADM_M038_B, "UOM_Master", "Administration");
                    this.SelectedADM_M038_B.EndEdit();
                    if (y == 1)
                    {
                        SelectedADM_M038_B = new ADM_M038_B();
                    }
                    _dataGridCollection.Refresh();
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M038_B> result)
        {
            blNew = true;
            SelectedADM_M038_B = new ADM_M038_B();
            SelectedADM_M038_B.ValidateAsync().Wait();
            SelectedMeasurClsList = new List<ADM_M038_A_P>();
            SelectedADM_M038_B.client = AppSessionState.client;
            _dataGridCollection.Refresh();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M038_B> result)
        {
            if (SelectedADM_M038_B.unit_code != null)
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
                    this.SelectedADM_M038_B.CancelEdit();
                    string response = repository.Delete(SelectedADM_M038_B.unit_code, "UOM_Master", "Administration");
                    SelectedList.Remove(SelectedADM_M038_B);
                    _dataGridCollection.Refresh();
                    SelectedADM_M038_B = new ADM_M038_B();
                    blNew = true;

                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M038_B> result)
        {
            SelectedADM_M038_B.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M038_B> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M038_B> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M038_B = SelectedADM_M038_B;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M038_B> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M038_B = SelectedADM_M038_B;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M038_B> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M038_B = SelectedADM_M038_B;
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M038_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M038_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M038_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M038_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M038_B> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For MeasurCls
        private void FilterCollectionMeasurCls()
        {
            if (_MeasurClsCollection != null)
            {
                _MeasurClsCollection.Refresh();
            }
        }
        public string FilterStringMeasurCls
        {
            get { return _filterStringMeasurCls; }
            set
            {
                _filterStringMeasurCls = value;
                RaisePropertyChanged("FilterStringMeasurCls");
                FilterCollectionMeasurCls();
            }
        }
        public bool MeasurClsFilter(object obj)
        {
            var data = obj as ADM_M038_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMeasurCls))
                {
                    return (data.class_name != null && data.class_name.ToString().ToLower().Contains(_filterStringMeasurCls.ToLower())) ||
                        (data.base_unit != null && data.base_unit.ToString().ToLower().Contains(_filterStringMeasurCls.ToLower())) ||
                        (data.id != null && data.id.ToString().ToLower().Contains(_filterStringMeasurCls.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region "Filter for Back Content Datagrid"
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
            var data = obj as ADM_M038_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.unit_abbrv != null && data.unit_abbrv.ToLower().Contains(_filterString.ToLower())) ||
                            (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.unit_desc != null && data.unit_desc.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.class_name != null && data.class_name.ToString().ToLower().Contains(_filterString.ToLower()));

                }
                return true;
            }
            return false;
        }


        #endregion
    }
}
