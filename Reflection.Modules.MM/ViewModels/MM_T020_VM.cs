using System;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_T020_VM : WorkspaceViewModel<MM_T001>
    {
        
        #region . Variable Declaration And Object .
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MC = new WebServiceRepository<MC_MM_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();
        MC_MM_T001 _MC = new MC_MM_T001();
        public MC_MM_T001 MC
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

        MC_MM_T001 _MCTemp = new MC_MM_T001();
        public MC_MM_T001 MCTemp
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

        private STD_LIST_BE _STD_LIST_OBJ;
        public STD_LIST_BE STD_LIST_OBJ
        {
            get
            {
                return _STD_LIST_OBJ;
            }
            set
            {
                if (_STD_LIST_OBJ != value)
                {
                    _STD_LIST_OBJ = value;
                    RaisePropertyChanged("STD_LIST_OBJ");
                }
            }
        }

        private MM_T001_B _BATCH_OBJ;
        public MM_T001_B BATCH_OBJ
        {
            get
            {
                return _BATCH_OBJ;
            }
            set
            {
                if (_BATCH_OBJ != value)
                {
                    _BATCH_OBJ = value;
                    RaisePropertyChanged("BATCH_OBJ");
                }
            }
        }

        private ObservableCollection<MM_T001_B> _BatchDetailsEntity;
        public ObservableCollection<MM_T001_B> BatchDetailsEntity
        {
            get
            {
                return _BatchDetailsEntity;
            }
            set
            {
                if (_BatchDetailsEntity != value)
                {
                    _BatchDetailsEntity = value;
                    RaisePropertyChanged("BatchDetailsEntity");
                }
            }
        }

        #endregion
        #region . Relay Commands .
        public RelayCommand cmdBatchSplit { get; private set; }
        public RelayCommand<object> cmdInvokeDocument { get; private set; }
        #endregion

        #region . Constructor .
        
        public MM_T020_VM(STD_LIST_BE STD_OBJ) : base()
        {
            MC = new MC_MM_T001();
            MCTemp = new MC_MM_T001();
            STD_LIST_OBJ = STD_OBJ;
            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
            CommandInitialization();
            LoadInitialData();
        }
        #endregion

        #region . User Defined Functions .
        private void SplitBatch(object InputValue) // This will split selected batch in to two part for seperate container of speciman sample with new batch number.
        {
            try
            {
                CursorControl.SetBusyState();
                string strSplitQty = (string)InputValue;
                if (BATCH_OBJ != null)
                {
                    if (!string.IsNullOrWhiteSpace(BATCH_OBJ.batch_no))
                    {
                        string Request = "SPLIT_BATCH" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@GR!@GR!@" + BATCH_OBJ.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@MM00!@"; // NITE: + strSplitQty;????
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T007_BL", "MM", "LoadAll", 0, "");

                        //if (ITEMS_ENTITY_HU_LIST != null)
                        //{
                        //    if (ITEMS_ENTITY_HU_LIST.Count > 0)
                        //    {
                        //        ITEMS_ENTITY_HU_LIST.Remove(ITEMS_ENTITY_HU);
                        //    }

                        //}
                    }
                    else
                    { }
                }
                else
                { }
            }
            catch (Exception ex) { }
        }

        private void LoadInitialData()
        {
            try
            { 
                string Request = "LOAD_BATCHES" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@GR!@GR!@" + STD_LIST_OBJ.order_no;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL", "MM", "LoadAll", 0, "");
                BatchDetailsEntity = MCTemp.BatchDetailsList;
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
        
        
        private void CommandInitialization()
        {
            try
            {
                cmdBatchSplit = new RelayCommand(() => { SplitBatch(BATCH_OBJ); });
                cmdInvokeDocument = new RelayCommand<object>(items => { if (items == null) { return; } InvokeDocument(items); });
            }
            catch (Exception ex)
            {}
        }

        void ModelUpdated_Batch(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "para2" || sender.ToString() == "para3" || sender.ToString() == "para4")
                {
                    foreach (var o in BatchDetailsEntity)
                    {
                        if (o.para2 != null && o.para3 != null && o.para4 != null)
                        {
                            o.para1 = Convert.ToDecimal(o.para3 / o.para2);
                            o.para5 = Convert.ToDecimal(o.para3 * o.para4);
                        }
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
        //Validation Function
        private bool Validations()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
                return false;
            }

        }
        private void InvokeDocument(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = BATCH_OBJ.client + "!@" + BATCH_OBJ.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion      
        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {}
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {}
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {}
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {}
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {}
        protected override void OnDocumentAction()
        {}
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        private void OnExportAction()
        { }

    }
}
