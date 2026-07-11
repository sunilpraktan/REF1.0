using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Reflection.Modules.Finance.ViewModels
{
    public class GLAccountPostingBL : WorkspaceViewModel<ACC_T006>
    {
        #region Declaration

        WebServiceRepository<List<ACC_T006_A>> repository = new WebServiceRepository<List<ACC_T006_A>>();
        WebServiceRepository<MultipleContext_ACC_T006> repository_MC = new WebServiceRepository<MultipleContext_ACC_T006>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ACC_T006 _MC;
        public MultipleContext_ACC_T006 MC
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

        private ACC_T006 _AccountDocumentEntityHeader;
        public ACC_T006 AccountDocumentEntityHeader
        {
            get { return _AccountDocumentEntityHeader; }
            set
            {
                if (_AccountDocumentEntityHeader != value)
                {
                    _AccountDocumentEntityHeader = value;
                    //RaisePropertyChanged("AccountDocumentEntityHeader");
                }
            }
        }

        private ObservableCollection<ACC_T006_A> _AccountDocumentEntityItemLine;
        public ObservableCollection<ACC_T006_A> AccountDocumentEntityItemLine
        {
            get { return _AccountDocumentEntityItemLine; }
            set
            {
                if ( _AccountDocumentEntityItemLine != value)
                {
                    _AccountDocumentEntityItemLine = value;
                }
            }
        }

        
        #endregion
      
        #region Constructor
        public GLAccountPostingBL( string DocumentNumber)
        {
            MC = new MultipleContext_ACC_T006();
            AccountDocumentEntityHeader = new ACC_T006();
            AccountDocumentEntityItemLine = new ObservableCollection<ACC_T006_A>();
            LoadInitialData(DocumentNumber);
           
        }

        #endregion

        #region User Defined Function
        private void LoadInitialData( string documentNumber)
        {
            try
            {

                string Request = "GetLedgerView" + "!@" + documentNumber;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MC, Request, "AccountingDocument", "Finance", "GetLedgerView", 0, "");
                AccountDocumentEntityHeader = MC.MasterData[0]; 
                AccountDocumentEntityItemLine = MC.DetailData;
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

        #region Abstract command



        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreateAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


}
