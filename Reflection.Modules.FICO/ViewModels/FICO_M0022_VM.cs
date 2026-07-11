using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.Finance;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Collections;
using Reflection.Presentation.Common;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0022_VM : WorkspaceViewModel<ACC_M001_A>
    {
        bool isNewRecord = true;
        WebServiceRepository<ACC_M001_A> repository = new WebServiceRepository<ACC_M001_A>();
        WebServiceRepository<MultipleContext_ACC_M001_A> repository_MC = new WebServiceRepository<MultipleContext_ACC_M001_A>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations   

        private MultipleContext_ACC_M001_A _MC;
        public MultipleContext_ACC_M001_A MC
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

        private MultipleContext_ACC_M001_A _MCTemp;
        public MultipleContext_ACC_M001_A MCTemp
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


        private ACC_M001_A _MasterEntity;
        public ACC_M001_A MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }
        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M001_A> _PO_Collection;
        public ObservableCollection<ACC_M001_A> PO_Collection
        {
            get { return _PO_Collection; }
            set
            {
                if (_PO_Collection != value)
                {
                    _PO_Collection = value;
                    RaisePropertyChanged("PO_Collection");
                }
            }
        }

        private ICollectionView _PO_Collection1;
        public ICollectionView PO_Collection1
        {
            get { return _PO_Collection1; }
            set
            {
                if (_PO_Collection1 != value)
                {
                    _PO_Collection1 = value;
                    RaisePropertyChanged("PO_Collection1");
                }
            }
        }

        private List<ACC_M001_A> _SelectedList;
        public List<ACC_M001_A> SelectedList
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

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return _SelectedTabControlIndex;
            }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdLoadDocByDocNumber { get; private set; }
        #endregion

        #region  Constructor
        public FICO_M0022_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M001_A();
            PO_Collection = new ObservableCollection<ACC_M001_A>();

            MC = new MultipleContext_ACC_M001_A();
            MCTemp = new MultipleContext_ACC_M001_A();

            CmdLoadDocByDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M001_A>(MC, Request, "PostingPeriod", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                PO_Collection = MC.PostPeriodList;
                SelectedList = PO_Collection.ToList();

                PO_Collection1 = CollectionViewSource.GetDefaultView(MC.PostPeriodList);
                PO_Collection1.Filter = new Predicate<object>(Filter);
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
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.active = true;
        }
        private bool Validation()
        {
            if (MasterEntity.fin_year == null || MasterEntity.fin_year == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Final Year", MasterEntity.fin_year);
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.posting_period == null || MasterEntity.posting_period == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Posting Period", MasterEntity.posting_period);
                showMessageService.ShowMessage();
                return false;
            }
            else
            {
                return true;
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                ACC_M001_A ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ACC_M001_A>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M001_A>().ToList()[0];

                    if (MC.PostPeriodList.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

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
                if (MasterEntity != null)
                {
                    PO_Collection.Add(MasterEntity);
                    // MC.PostPeriodList = (List<ACC_M001_A>)obj.XMLToObject(MasterEntity.ToString(), MC.PostPeriodList);


                    PO_Collection1 = CollectionViewSource.GetDefaultView(PO_Collection);

                    PO_Collection1.Refresh();
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

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnCreateAction(InquiryActionResult<ACC_M001_A> result)
        {

            isNewRecord = true;
            MasterEntity = new ACC_M001_A();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ACC_M001_A> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M001_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M001_A> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ACC_M001_A> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ACC_M001_A> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ACC_M001_A> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ACC_M001_A> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ACC_M001_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M001_A>(MasterEntity, "PostingPeriod", "Finance");

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M001_A>(MasterEntity, "PostingPeriod", "Finance");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
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
        #endregion

        #region Filters

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                if (_filterString != value)
                {
                    _filterString = value;
                    RaisePropertyChanged("FilterString");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_PO_Collection1 != null)
            {
                _PO_Collection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M001_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {

                    return (data.group_comp != null && data.group_comp.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.post_year != null && data.post_year.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.fin_year != null && data.fin_year.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }



        #endregion
    }
}
