using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.BusinessEntity.Finance;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0011_VM : WorkspaceViewModel<ACC_M003_H>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_H>> repository = new WebServiceRepository<List<ACC_M003_H>>();
        WebServiceRepository<MultipleContext_ACC_M003_H> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_H>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations       

        private MultipleContext_ACC_M003_H _MC;
        public MultipleContext_ACC_M003_H MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private ACC_M003_H _MasterEntity;
        public ACC_M003_H MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }



        private int _dgSelectedIndexAccGrp;
        public int dgSelectedIndexAccGrp
        {
            get
            { return _dgSelectedIndexAccGrp; }
            set
            {
                if (_dgSelectedIndexAccGrp != value)
                {
                    _dgSelectedIndexAccGrp = value;
                    RaisePropertyChanged("dgSelectedIndexAccGrp");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ACC_M003_H> _AccGrpCollection;
        public ObservableCollection<ACC_M003_H> AccGrpCollection
        {
            get { return _AccGrpCollection; }
            set
            {
                if (_AccGrpCollection != value)
                {
                    _AccGrpCollection = value;
                    RaisePropertyChanged("AccGrpCollection");
                }
            }
        }

        private ICollectionView _AccGrpCollection1;
        public ICollectionView AccGrpCollection1
        {
            get { return _AccGrpCollection1; }
            set
            {
                if (_AccGrpCollection1 != value)
                {
                    _AccGrpCollection1 = value; RaisePropertyChanged("AccGrpCollection1");
                }
            }
        }

        private List<ACC_M003_H> _SelectedList;
        public List<ACC_M003_H> SelectedList
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

        #region Constructor
        public FICO_M0011_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_H();
            AccGrpCollection = new ObservableCollection<ACC_M003_H>();

            MC = new MultipleContext_ACC_M003_H();

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_H>(MC, Request, "AccountGroupMaster", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                AccGrpCollection = MC.AccountGroupList;
                SelectedList = AccGrpCollection.ToList();

                AccGrpCollection1 = CollectionViewSource.GetDefaultView(MC.AccountGroupList);
                AccGrpCollection1.Filter = new Predicate<object>(Filter);
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
        }

        private bool Validation()
        {
            foreach (var o in AccGrpCollection)
            {
                if (o.acc_group == null || o.acc_group == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Account Group Code");

                    showMessageService.ShowMessage();
                    return false;

                }
                if (o.acc_group_type == null || o.acc_group_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Account Group Type for Account Group Code {0}", o.acc_group);
                    showMessageService.ShowMessage();
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_H> result)
        {
            try
            {
                List<ACC_M003_H> RequestList = new List<ACC_M003_H>();
                foreach (ACC_M003_H item in AccGrpCollection)
                {
                    if (item.Click == true)
                    {

                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        RequestList.Add(item);



                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ACC_M003_H>>(RequestList, "AccountGroupMaster", "Finance");

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
                List<ACC_M003_H> RequestList = new List<ACC_M003_H>();
                RequestList = AccGrpCollection.ToList();
                foreach (ACC_M003_H item in RequestList)
                {
                    if (item.Click == true)
                    {
                        AccGrpCollection.Remove(item);
                    }
                }
                if (strReturn != "")
                {
                    MC.AccountGroupList = (ObservableCollection<ACC_M003_H>)obj.XMLToObject(strReturn, MC.AccountGroupList);
                    AccGrpCollection.Add(MC.AccountGroupList[0]);
                }
                else
                {
                    MC.AccountGroupList = new ObservableCollection<ACC_M003_H>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_H> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_H> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_H();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_H> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {

            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_H> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_H> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_H> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_H> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_H> result)
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
            if (AccGrpCollection1 != null)
            {
                _AccGrpCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_H;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.acc_group != null && data.acc_group.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.group_desc != null && data.group_desc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.acc_group_type != null && data.acc_group_type.ToString().ToLower().Contains(_filterString.ToLower())
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
