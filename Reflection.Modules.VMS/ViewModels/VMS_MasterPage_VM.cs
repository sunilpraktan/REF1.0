using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections.Specialized;
using System.Windows;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.BusinessEntity.VMS;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.Modules.VMS.ViewModels
{
    public class VMS_MasterPage_VM : WorkspaceViewModel<TSK_T001_C>
    {
        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<TSK_T001_C> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<TSK_T001_C> result)
        {

        }

        #endregion
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public VMS_MasterPage_VM() : base()
        {
           
        }
        public VMS_MasterPage_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;

        }
        public VMS_MasterPage_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;

        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }
    }
}
