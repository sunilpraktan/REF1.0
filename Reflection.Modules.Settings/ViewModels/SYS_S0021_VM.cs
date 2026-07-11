using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using Reflection.BusinessEntity.GEN;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ENG;

namespace Reflection.Modules.MM.ViewModels
{
    public class SYS_S0021_VM : WorkspaceViewModel<GEN_M0101>
    {
        WebServiceRepository<List<GEN_M0101>> repository = new WebServiceRepository<List<GEN_M0101>>();
        WebServiceRepository<GEN_M0101_MC> repository_MC = new WebServiceRepository<GEN_M0101_MC>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declarations       

        private GEN_M0101_MC _MC;
        public GEN_M0101_MC MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }


        private GEN_M0101 _MasterEntity;
        public GEN_M0101 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private ENG_T005_B _CharObject;
        public ENG_T005_B CharObject
        {
            get
            { return _CharObject; }
            set
            {
                _CharObject = value;
                RaisePropertyChanged("CharObject");
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<GEN_M0101> _ITCollection;
        public ObservableCollection<GEN_M0101> ITCollection
        {
            get { return _ITCollection; }
            set
            {
                if (_ITCollection != value)
                {
                    _ITCollection = value;
                    ITCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ITCollection");
                }
            }
        }
        #endregion
        #region Relay Commands Declaration


        #endregion
        #region Constructor
        public SYS_S0021_VM(ENG_T005_B OBJ_CHAR) : base()
        {
            CharObject = OBJ_CHAR;
            MasterEntity = new GEN_M0101();
            MC = new GEN_M0101_MC();
            ITCollection = new ObservableCollection<GEN_M0101>();
            ITCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + CharObject.comp_code + "!@" + (CharObject.location_id ?? "") + "!@" + CharObject.doc_no + "!@" + CharObject.char_code + "!@" + CharObject.id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<GEN_M0101_MC>(MC, Request, "GEN_M0101_BL", "GEN", "LOAD_INI", 0, "");
                
                if(MC.STYLE_LIST != null)
                {
                    if (MC.STYLE_LIST.Count > 0)
                    {
                        ITCollection = MC.MASTER_ENTITY_LIST;
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
        private bool Validation()
        {
            return true;

        }

        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (GEN_M0101 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = CharObject.comp_code;
                        item.obj_type = CharObject.doc_cat;
                        item.obj_code = CharObject.doc_no;
                        item.row_id = CharObject.id;
                        item.char_code = CharObject.char_code;
                        item.selected = true;
                        item.userid = AppSessionState.UserID;
                        item.active = "1";
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
        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<GEN_M0101> result)
        {
            try
            {
                List<GEN_M0101> RequestList = new List<GEN_M0101>();
                foreach (GEN_M0101 item in ITCollection)
                {
                    if (item.selected == true)
                    {
                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<GEN_M0101>>(RequestList, "GEN_M0101_BL", "GEN");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
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


        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<GEN_M0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<GEN_M0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<GEN_M0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<GEN_M0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<GEN_M0101> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<GEN_M0101> result)
        {
            MasterEntity = new GEN_M0101();
        }
        protected override void OnRemoveAction(InquiryActionResult<GEN_M0101> result)
        {}
        protected override void OnDiscardAction(InquiryActionResult<GEN_M0101> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<GEN_M0101> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<GEN_M0101> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<GEN_M0101> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<GEN_M0101> result)
        {

        }

        #endregion
        
    }
}
