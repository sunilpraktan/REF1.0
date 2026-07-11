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
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.PMS;
using Reflection.BusinessEntity.ADM;
using System.Data;

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_T099_VM : WorkspaceViewModel<PMS_T001>, ITS_VIEW_MODEL
    {
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
        private STD_LIST_BE _doc_info_para = new STD_LIST_BE();
        public STD_LIST_BE doc_info_para
        {
            get { return _doc_info_para; }
            set
            {
                if (_doc_info_para != value)
                {
                    _doc_info_para = value; RaisePropertyChanged("doc_info_para");

                }
            }

        }



        #region Constructor
        public PMS_T099_VM(string ts_code, string doc_cat) : base()
        {
            
        }
        public PMS_T099_VM(string ts_code, string doc_cat, STD_LIST_BE para_obj) : base()
        {

        }
        #endregion

     
        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<PMS_T001> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<PMS_T001> result)
        {
        }
        protected override void OnRemoveAction(InquiryActionResult<PMS_T001> result)
        {
        }
        protected override void OnSaveAction(InquiryActionResult<PMS_T001> result)
        {
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
