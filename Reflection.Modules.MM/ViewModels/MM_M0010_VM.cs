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
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Services;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0010_VM : WorkspaceViewModel<ADM_M022_A>
    {
        

       


        #region Constructor 
        public MM_M0010_VM(string ts_code) : base()
        {
        }
       
        #endregion


        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ADM_M022_A> result)
        {
            
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M022_A> result)
        {
            
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M022_A> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M022_A> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M022_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M022_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M022_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M022_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M022_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M022_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M022_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M022_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M022_A> result)
        {

        }

        #endregion

      
    }
}
