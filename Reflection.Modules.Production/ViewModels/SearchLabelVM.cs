using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Production.ViewModels
{
    public class Search_LabelVM : WindowViewModel<EPR_T003_A>, INotifyPropertyChanged
    {

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<MultipleContext_SearchLabel> repository_MCS = new WebServiceRepository<MultipleContext_SearchLabel>();

        MultipleContext_SearchLabel _MCS = new MultipleContext_SearchLabel();
        public MultipleContext_SearchLabel MCS
        {
            get { return _MCS; }
            set
            {
                if (_MCS != value)
                {
                    _MCS = value;

                    RaisePropertyChanged("MCS");
                }
            }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
                }
            }
        }

        private bool? _LabelIsChecked;
        public bool? LabelIsChecked
        {
            get { return _LabelIsChecked; }
            set
            {
                if (_LabelIsChecked != value)
                {
                    _LabelIsChecked = value;
                    RaisePropertyChanged("LabelIsChecked");
                }
            }
        }

        private bool? _CartonIsChecked;
        public bool? CartonIsChecked
        {
            get { return _CartonIsChecked; }
            set
            {
                if (_CartonIsChecked != value)
                {
                    _CartonIsChecked = value;
                    RaisePropertyChanged("CartonIsChecked");
                }
            }
        }

        private EPR_T002_Flip _LabelEntity;
        public EPR_T002_Flip LabelEntity
        {
            get
            {
                return _LabelEntity;
            }
            set
            {
                if (_LabelEntity != value)
                {
                    _LabelEntity = value;
                    RaisePropertyChanged(nameof(LabelEntity));
                    value.BeginEdit();
                }
            }
        }

        private EPR_T003_A_Flip _SmallCartonEntity;
        public EPR_T003_A_Flip SmallCartonEntity
        {
            get
            {
                return _SmallCartonEntity;
            }
            set
            {
                if (_SmallCartonEntity != value)
                {
                    _SmallCartonEntity = value;
                    RaisePropertyChanged(nameof(SmallCartonEntity));
                    value.BeginEdit();
                }
            }
        }

        private EPR_T003_A_Flip _OuterCartonEntity;
        public EPR_T003_A_Flip OuterCartonEntity
        {
            get
            {
                return _OuterCartonEntity;
            }
            set
            {
                if (_OuterCartonEntity != value)
                {
                    _OuterCartonEntity = value;
                    RaisePropertyChanged(nameof(OuterCartonEntity));
                    value.BeginEdit();
                }
            }
        }

        private LOG_T001_A_P _DispatchEntity;
        public LOG_T001_A_P DispatchEntity
        {
            get
            {
                return _DispatchEntity;
            }
            set
            {
                if (_DispatchEntity != value)
                {
                    _DispatchEntity = value;
                    RaisePropertyChanged(nameof(DispatchEntity));
                   // value.BeginEdit();
                }
            }
        }

        private SEL_T003_P _InvoiceEntity;
        public SEL_T003_P InvoiceEntity
        {
            get
            {
                return _InvoiceEntity;
            }
            set
            {
                if (_InvoiceEntity != value)
                {
                    _InvoiceEntity = value;
                    RaisePropertyChanged(nameof(InvoiceEntity));
                    //value.BeginEdit();
                }
            }
        }
        #endregion

        #region Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region RelayCommand Actions

        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand cmdnew { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region ICollectionView
        private ICollectionView _MergeBatch;
        public ICollectionView MergeBatch
        {
            get { return _MergeBatch; }
            set
            {
                _MergeBatch = value;
                RaisePropertyChanged("MergeBatch");
            }
        }

        private ICollectionView _SmallCartonDetails;
        public ICollectionView SmallCartonDetails
        {
            get { return _SmallCartonDetails; }
            set
            {
                _SmallCartonDetails = value;
                RaisePropertyChanged("SmallCartonDetails");
            }
        }
        #endregion

        #region Constructor

        public Search_LabelVM(string ts_code)
        {
            this.ts_code_vm = ts_code;
            MCS = new MultipleContext_SearchLabel();
            LabelEntity = new EPR_T002_Flip();
            SmallCartonEntity = new EPR_T003_A_Flip();
            OuterCartonEntity = new EPR_T003_A_Flip();
            DispatchEntity = new LOG_T001_A_P();
            InvoiceEntity = new SEL_T003_P();

            LabelIsChecked = true;
            CartonIsChecked = false;
            #region Command Initialisation
            cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } GetAllData(items); });
            cmdnew = new RelayCommand(() => { NewMethod(); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

            #endregion
        }
        #endregion

        #region User Defined Functions
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    NewMethod();
              
                    AppSessionState.ViewOtherRecordAllowed = true;
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
                    Request = LabelEntity.client + "!@" + LabelEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void NewMethod()
        {
            barcode = "";
            MCS = new MultipleContext_SearchLabel();
            MergeBatch = CollectionViewSource.GetDefaultView(MCS.MergeList);
            SmallCartonDetails = CollectionViewSource.GetDefaultView(MCS.SmallCartonDetails);
            LabelEntity = new EPR_T002_Flip();
            SmallCartonEntity = new EPR_T003_A_Flip();
            OuterCartonEntity = new EPR_T003_A_Flip();
            DispatchEntity = new LOG_T001_A_P();
            InvoiceEntity = new SEL_T003_P();
            var msg = new NotificationMessage("Search_LabelVM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void GetAllData(object InputValue)
        {
            try
            {
                barcode = InputValue.ToString();

                if (LabelIsChecked == false && CartonIsChecked == false)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Label or Carton Then Scan", this.Title);
                    showMessageService.ShowMessage();

                    if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                    {
                        barcode = "";
                    }
                }
                else if (barcode.Length > 9) // condition change from Fix 9 to from DB
                {
                    string LabelType = "";

                    if (LabelIsChecked == true)
                    {
                        LabelType = "Label";

                        #region Label Batch Wise

                        string Request = LabelType + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + barcode;
                        MCS = repository_MCS.GetDataWithReturnDomainObject<MultipleContext_SearchLabel>(MCS, Request, "SearchLabel", "Production", "LoadAll", 0, "");

                        if (MCS.LabelEntity.Count > 0)
                        {
                            LabelEntity = MCS.LabelEntity[0];
                        }
                        MergeBatch = CollectionViewSource.GetDefaultView(MCS.MergeList);

                        if (MCS.SmallCartonEntity.Count > 0)
                        {
                            SmallCartonEntity = MCS.SmallCartonEntity[0];
                        }
                        if (MCS.OuterCartonEntity.Count > 0)
                        {
                            OuterCartonEntity = MCS.OuterCartonEntity[0];
                        }
                        if (MCS.DispatchEntity.Count > 0)
                        {
                            DispatchEntity = MCS.DispatchEntity[0];
                        }
                        if (MCS.InvoiceEntity.Count > 0)
                        {
                            InvoiceEntity = MCS.InvoiceEntity[0];
                        }

                        SelectedTabControlIndex = 0;

                        #endregion

                    }
                    else if (CartonIsChecked == true)
                    {
                        LabelType = "Carton";
                        
                        string Request = LabelType + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + barcode;
                        MCS = repository_MCS.GetDataWithReturnDomainObject<MultipleContext_SearchLabel>(MCS, Request, "SearchLabel", "Production", "LoadAll", 0, "");

                        if (MCS.SmallCartonEntity.Count > 0)
                        {                        
                          
                            if (MCS.SmallCartonEntity[0].doc_type == "SC")
                            {
                                #region Small Carton No Wise Search
                                SmallCartonEntity = MCS.SmallCartonEntity[0];

                                if (MCS.SmallCartonDetails.Count > 0)
                                {
                                    SmallCartonDetails = CollectionViewSource.GetDefaultView(MCS.SmallCartonDetails);
                                }

                                if (MCS.OuterCartonEntity.Count > 0)
                                {
                                    OuterCartonEntity = MCS.OuterCartonEntity[0];
                                }
                                if (MCS.DispatchEntity.Count > 0)
                                {
                                    DispatchEntity = MCS.DispatchEntity[0];
                                }
                                if (MCS.InvoiceEntity.Count > 0)
                                {
                                    InvoiceEntity = MCS.InvoiceEntity[0];
                                }

                                SelectedTabControlIndex = 1;
                                #endregion
                            }
                            else
                            {
                                #region Outer Carton Wise Search
                                if (MCS.SmallCartonEntity.Count > 0)
                                {
                                    OuterCartonEntity = MCS.SmallCartonEntity[0];
                                }
                                if (MCS.SmallCartonDetails.Count > 0)
                                {
                                    SmallCartonDetails = CollectionViewSource.GetDefaultView(MCS.SmallCartonDetails);
                                }
                                if (MCS.DispatchEntity.Count > 0)
                                {
                                    DispatchEntity = MCS.DispatchEntity[0];
                                }
                                if (MCS.InvoiceEntity.Count > 0)
                                {
                                    InvoiceEntity = MCS.InvoiceEntity[0];
                                }

                                SelectedTabControlIndex = 2;
                                #endregion
                            }

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
                barcode = "";
            }
            
        }
        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T003_A> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T003_A> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
