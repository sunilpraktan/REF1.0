using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.GEN;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;

namespace Reflection.Presentation.Controls.ViewModel
{
   
    public class AddessControl_VM : WorkspaceViewModel<GEN_M0011> //ViewModelBase //WorkspaceViewModel<GEN_M0011>
    {
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string object_id { get; set; }

        private GEN_M0011 _MasterEntity;
        public GEN_M0011 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                }
            }
        }
        public RelayCommand<object> cmdSavePayment { get; private set; }
        #region Constructor
        
        public AddessControl_VM(string ts_code, string uid, GEN_M0011 OBJ_ADD) : base()
        {
            ts_code_vm = ts_code;
            object_id = uid;
            MasterEntity = OBJ_ADD;
            cmdSavePayment = new RelayCommand<object>(items => { if (items == null) { return; } SavePayment(items); });
        }

        #endregion

        private void SavePayment(object InputValue)
        {
            MasterEntity.add_code = "TEST_ADD";
            if (!string.IsNullOrWhiteSpace(MasterEntity.add_code)) // Update inventory after save payment successfully.
            {
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity, object_id));
            }
        }

        #region Abstract Command

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<GEN_M0011> result)
        {


        }

        protected override void OnCreateAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<GEN_M0011> result)
        {
            throw new NotImplementedException();
        }


        #endregion
  
    }
}
