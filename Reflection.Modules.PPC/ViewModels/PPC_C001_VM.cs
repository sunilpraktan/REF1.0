using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using System.Reflection;
using System.IO;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_C001_VM : WorkspaceViewModel<STD_LIST_BE>
    {

        WebServiceRepository<MC_PPC_BE> REPO_MC = new WebServiceRepository<MC_PPC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();
        IShowMessageViewService sms;

        private EPR_T001 _MasterEntity;
        public EPR_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }
        private ObservableCollection<EPR_T001_A> _EPR_T001_A_OBJ_OC;
        public ObservableCollection<EPR_T001_A> EPR_T001_A_OBJ_OC
        {
            get
            {
                return _EPR_T001_A_OBJ_OC;
            }
            set
            {
                if (_EPR_T001_A_OBJ_OC != value)
                {
                    _EPR_T001_A_OBJ_OC = value;
                    RaisePropertyChanged("EPR_T001_A_OBJ_OC");
                }
            }
        }

        private MC_PPC_BE _MC = new MC_PPC_BE();
        private MC_PPC_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private ICollectionView _GRID_COLLECTION;
        public ICollectionView GRID_COLLECTION
        {
            get { return _GRID_COLLECTION; }
            set
            {
                if (_GRID_COLLECTION != value)
                {
                    _GRID_COLLECTION = value;

                    RaisePropertyChanged("GRID_COLLECTION");

                }
            }
        }
        private STD_LIST_BE _STD_LIST_OBJECT;
        public STD_LIST_BE STD_LIST_OBJECT
        {
            get
            {
                return _STD_LIST_OBJECT;
            }
            set
            {
                if (_STD_LIST_OBJECT != value)
                {
                    _STD_LIST_OBJECT = value; RaisePropertyChanged("STD_LIST_OBJECT");
                }
            }
        }

        private STD_LIST_BE _MASTER_OBJECT;
        public STD_LIST_BE MASTER_OBJECT
        {
            get
            {
                return _MASTER_OBJECT;
            }
            set
            {
                if (_MASTER_OBJECT != value)
                {
                    _MASTER_OBJECT = value; RaisePropertyChanged("MASTER_OBJECT");
                }
            }
        }

        #region . Relay Commands .

        //public RelayCommand<object> cmdExecuteOrders { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        public PPC_C001_VM(STD_LIST_BE STD_LIST_OBJ) : base()
        {
            MC = new MC_PPC_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
            LoadInitialData(STD_LIST_OBJ);

        }

        public void LoadInitialData(STD_LIST_BE STD_LIST_OBJ)
        {
            MC = new MC_PPC_BE();
            string Request = "LOAD_SO_FOR_PPC" + "!@" + AppSessionState.client + "!@" + STD_LIST_OBJ.comp_code + "!@" + STD_LIST_OBJ.location_id + "!@" + STD_LIST_OBJ.doc_cat + "!@" + STD_LIST_OBJ.doc_type + "!@" + STD_LIST_OBJ.ref_doc_no + "!@" + STD_LIST_OBJ.ref_doc_cat + "!@" + STD_LIST_OBJ.emp_id + "!@" + STD_LIST_OBJ.userid;
            MC = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC, Request, "EPR_T001_BL", "PPC", "LoadAll", 0, "");

            GRID_COLLECTION = CollectionViewSource.GetDefaultView(MC.GRID_COLLECTION);
        }

        private void InitializeCommands()
        {
            try
            {
                #region . Command Initialization .
                //cmdExecuteOrders = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteOrders(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion

            }
            catch (Exception ex)
            { }
        }

        private void ExecuteOrders(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (MC.GRID_COLLECTION != null)
                {
                    if (MC.GRID_COLLECTION.Count > 0)
                    {
                        foreach (var item in MC.GRID_COLLECTION)
                        {
                            if(item.selected == true)
                            {
                                //CreateDocument(item);
                            }
                        }
                    }

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Reference Document Number!", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        

        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = MASTER_OBJECT.client + "!@" + MASTER_OBJECT.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        #region Abstract


        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreateAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
