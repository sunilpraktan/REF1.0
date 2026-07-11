using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.Admin;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Collections.Specialized;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0003_VM : WorkspaceViewModel<ADM_M001_D>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_D>> repository = new WebServiceRepository<List<ADM_M001_D>>();
        WebServiceRepository<MultipleContext_ADM_M001_D> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_D>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declarations       

        private MultipleContext_ADM_M001_D _MC;
        public MultipleContext_ADM_M001_D MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_D _MCTemp;
        public MultipleContext_ADM_M001_D MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ADM_M001_D _MasterEntity;
        public ADM_M001_D MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexsd;
        public int dgSelectedIndexsd
        {
            get
            { return _dgSelectedIndexsd; }
            set
            {
                if (_dgSelectedIndexsd != value)
                {
                    _dgSelectedIndexsd = value;
                    RaisePropertyChanged("dgSelectedIndexsd");
                }
            }
        }

        #endregion


        #region ICollectionView

        private ObservableCollection<ADM_M001_D> _SOCollection;
        public ObservableCollection<ADM_M001_D> SOCollection
        {
            get { return _SOCollection; }
            set
            {
                if (_SOCollection != value)
                {
                    _SOCollection = value;
                    SOCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("SOCollection");
                }
            }
        }


        private ICollectionView _SOCollection1;
        public ICollectionView SOCollection1
        {
            get { return _SOCollection1; }
            set
            {
                if (_SOCollection1 != value)
                {
                    _SOCollection1 = value; RaisePropertyChanged("SOCollection1");

                }
            }
        }



        private List<ADM_M001_D> _SelectedList;
        public List<ADM_M001_D> SelectedList
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

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public SDM_M0003_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_D();
            SOCollection = new ObservableCollection<ADM_M001_D>();

            MC = new MultipleContext_ADM_M001_D();
            MCTemp = new MultipleContext_ADM_M001_D();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            SOCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }

        #endregion


        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_D>(MC, Request, "SalesDivision", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                SOCollection = MC.SDlist;
                //SelectedList = (MC.SOList).ToList();
                SelectedList = SOCollection.ToList();

                SOCollection1 = CollectionViewSource.GetDefaultView(MC.SDlist);
                SOCollection1.Filter = new Predicate<object>(Filter);

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
            MasterEntity.client = AppSessionState.client;

        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_D)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_D item in e.NewItems)
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
            return true;
        }

        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_D> result)
        {
            try
            {
                List<ADM_M001_D> RequestList = new List<ADM_M001_D>();
                foreach (ADM_M001_D item in SOCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;

                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M001_D>>(RequestList, "SalesDivision", "Administration");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                //  SetBusinessEntitiesAfterLoad("Save", "");
                // isNewRecord = false;
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
                if (MC.SDlist != null)
                {
                    SOCollection.Clear();
                    //MC.RevenueList = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.RevenueList, MC.RevenueList);

                }
                else
                {
                    MC.SDlist = new ObservableCollection<ADM_M001_D>();
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
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_D> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_D> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_D> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_D();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_D> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_D> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_D> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_D> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_D> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_D> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid   

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
            if (_SOCollection1 != null)
            {
                _SOCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_D;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.div_code != null && data.div_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.div_desc != null && data.div_desc.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }



        #endregion

        #endregion
    }
}
