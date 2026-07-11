using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;


namespace Reflection.Modules.ADM.ViewModels
{
    // This Class is for Terms & Condition Master for Company, Customer, Supplier for Sales & Purchase Process.
    public class ADM_M0004_VM : WorkspaceViewModel<ADM_M003>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M003> repository = new WebServiceRepository<ADM_M003>();
        WebServiceRepository<MultipleContextADM_M003> repositoryM = new WebServiceRepository<MultipleContextADM_M003>();
        
        
        public ADM_M0004_VM(string ts_code)
            : base()
        {
            
            
        }
        
       

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M003> result)
        {
           
        }
        
        protected override void OnCreateAction(InquiryActionResult<ADM_M003> result)
        {
           
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M003> result)
        {
            
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M003> result)
        {
            
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M003> result)
        {
            
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M003> result)
        {
           
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M003> result)
        {
            
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M003> result)
        {
            
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }
      
        #endregion

     
    }
}
