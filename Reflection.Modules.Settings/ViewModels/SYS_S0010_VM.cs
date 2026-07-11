using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Microsoft.Win32;
using System.IO;
using Reflection.BusinessEntity;
using System.Linq;

namespace Reflection.Modules.Settings.ViewModels
{
    public class SYS_S0010_VM : WorkspaceViewModel<SYS_C0101>
    {
        bool blNew = true;
        WebServiceRepository<SYS_C0101> REPOSITORY = new WebServiceRepository<SYS_C0101>();
        WebServiceRepository<MC_SYS_BE> REPOSITORY_MC = new WebServiceRepository<MC_SYS_BE>();

   
        private int _dgSelectedIndex;

        #region Declaration
        IShowMessageViewService sms;

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                if (_ReportCode != value)
                {
                    _ReportCode = value;

                    RaisePropertyChanged("ReportCode");
                }
            }
        }
        private string _DocCat;
        public string DocCat
        {
            get { return _DocCat; }
            set
            {
                if (_DocCat != value)
                {
                    _DocCat = value;
                    DocumentChanged(null);
                    RaisePropertyChanged("DocCat");
                }
            }
        }

        private string _imageNameH;
        public string imageNameH
        {
            get { return _imageNameH; }
            set
            {
                if (_imageNameH != value)
                {
                    _imageNameH = value;

                    RaisePropertyChanged("imageNameH");
                }
            }
        }
        private string _imageNameF;
        public string imageNameF
        {
            get { return _imageNameF; }
            set
            {
                if (_imageNameF != value)
                {
                    _imageNameF = value;

                    RaisePropertyChanged("imageNameF");
                }
            }
        }

        public string ts_code_vm { get; set; }

        #endregion

        #region Relay Commands Declarations
        public RelayCommand cmdHeadeImage { get; private set; }
        public RelayCommand cmdFooterImage { get; private set; }
        public RelayCommand<object> cmdSelectItem { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdUpdateSetting { get; private set; }
        public RelayCommand<object> cmdDocumentChanged { get; private set; }

        #endregion

        #region SYS_C0101

        private SYS_C0101 _MasterEntity;
        public SYS_C0101 MasterEntity
        {
            get
            {
                this.ErrorExist = _MasterEntity.HasErrors;
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private List<string> _DisplayTypes;
        public List<string> DisplayTypes
        {
            get
            {
                return _DisplayTypes;
            }
            set
            {
                _DisplayTypes = value;
                RaisePropertyChanged("DisplayTypes");
            }
        }
        
        private List<string> _AlignmentList;
        public List<string> AlignmentList
        {
            get
            {
                return _AlignmentList;
            }
            set
            {
                _AlignmentList = value;
                RaisePropertyChanged("AlignmentList");
            }
        }

        private List<string> _DocList;
        public List<string> DocList
        {
            get
            {
                return _DocList;
            }
            set
            {
                _DocList = value;
                RaisePropertyChanged("DocList");
            }
        }
        private List<string> _ReportList;
        public List<string> ReportList
        {
            get
            {
                return _ReportList;
            }
            set
            {
                _ReportList = value;
                RaisePropertyChanged("ReportList");
            }
        }

        #endregion
        #region ADM_M010B



        #endregion

        private MC_SYS_BE _MC;
        public MC_SYS_BE MC
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
        private MC_SYS_BE _MC_TEMP;
        public MC_SYS_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value;

                    RaisePropertyChanged("MC_TEMP");
                }
            }
        }
        public SYS_S0010_VM(string ts_code)
            : base()
        {
            ts_code_vm = ts_code;
            sms = this.GetViewService<IShowMessageViewService>();
            MC = new MC_SYS_BE();
            MC_TEMP = new MC_SYS_BE();
            MasterEntity = new SYS_C0101();
            SYS_C0101.ModelEntityUpdated += new EventHandler(Model_Updated);
            cmdHeadeImage = new RelayCommand(OpenHeaderImage);
            cmdFooterImage = new RelayCommand(OpenFooterImage);
            //cmdLoadDocument = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentFromBackFlip(items); });
            cmdUpdateSetting = new RelayCommand<object>(items => { if (items == null) { return; } UpdateSetting(items); });
            cmdDocumentChanged = new RelayCommand<object>(items => { if (items == null) { return; } DocumentChanged(items); });

            DisplayTypes = new List<string>() { "Stretch", "Fit", "Original" };
            AlignmentList = new List<string>() { "Left", "Center", "Right" };
            DocList = new List<string>() { "Certificate", "Invoice" };
            ReportList = new List<string>() { "R001", "R002", "R002", "R004" };

            LoadInitialData();
        }





        #region Open Image
        private void OpenHeaderImage()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    imageNameH = fldlg.FileName;
                    //MasterEntity.header_img = File.ReadAllBytes(imageNameH);
                }
                fldlg = null;
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
        private void OpenFooterImage()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    imageNameF = fldlg.FileName;
                    //MasterEntity.footer_img = File.ReadAllBytes(imageNameF);
                }
                fldlg = null;
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
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC, Request, "SYS_C0101_BL", "SYS", "LOAD_INI", 0, "");


            

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void UpdateSetting(object obj)
        {
            try
            {
                InquiryActionResult<SYS_C0101> result = new WindowViewModel<SYS_C0101>.InquiryActionResult<SYS_C0101>();
                OnSaveAction(result);

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void DocumentChanged(object obj)
        {
            try
            {
                if (DocCat == "Certificate")
                {
                    MasterEntity.doc_cat = "IL";
                    MasterEntity.rpt_code = "R001";
                }
                string Request = "LOAD_DOC" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + (MasterEntity.rpt_code ?? "") + "!@" + (MasterEntity.doc_cat ?? "");
                MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC, Request, "SYS_C0101_BL", "SYS", "LOAD_DOC", 0, "");

                if (MC.RPT_SETTING_LIST != null)
                {
                    if (MC.RPT_SETTING_LIST.Count > 0)
                    {
                        MasterEntity = MC.RPT_SETTING_LIST[0];
                    }
                }



            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadDocument()
        {
            try
            {
                string Request = "LOAD_DOC" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC, Request, "SYS_C0101_BL", "SYS", "LOAD_INI", 0, "");



            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            try
            {
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.active = "1";
                MasterEntity.client = AppSessionState.client;
                MasterEntity.ts_code = ts_code_vm;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        void Model_Updated(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MasterEntity.doc_cat))
            {
                //if (MasterEntity.doc_cat == "Certificate")
                //{
                //    DocCat = "IL";
                //    ReportCode = "R001";
                //}
                //string Request = "LOAD_DOC" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + (ReportCode ?? "") + "!@" + (DocCat ?? "");
                //MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_SYS_BE>(MC, Request, "SYS_C0101_BL", "SYS", "LOAD_DOC", 0, "");

                //if (MC.RPT_SETTING_LIST != null)
                //{
                //    if (MC.RPT_SETTING_LIST.Count > 0)
                //    {
                //        MasterEntity = MC.RPT_SETTING_LIST[0];
                //    }
                //}
            }
        }
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<SYS_C0101> result)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.doc_cat))
                {
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    MasterEntity.client = AppSessionState.client;
                    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    MasterEntity.loc_code = AppSessionState.OBJ_LOCATION.location_id;
                    MasterEntity.ts_code = ts_code_vm;

                    MasterEntity = REPOSITORY.SaveWithReturnDomainObject<SYS_C0101>(MasterEntity, "SYS_C0101_BL", "SYS");

                    //if (blNew == true)
                    //{
                    //    MasterEntity = REPOSITORY.SaveWithReturnDomainObject<SYS_C0101>(MasterEntity, "SYS_C0101_BL", "SYS");

                    //    blNew = false;
                    //}
                    //else if (blNew == false)
                    //{
                    //    string response = REPOSITORY.Update<SYS_C0101>(MasterEntity, "SYS_C0101_BL", "SYS");
                    //}
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("User name required", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<SYS_C0101> result)
        {
            blNew = true;
            MasterEntity = new SYS_C0101();
        }
        protected override void OnRemoveAction(InquiryActionResult<SYS_C0101> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<SYS_C0101> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<SYS_C0101> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<SYS_C0101> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<SYS_C0101> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<SYS_C0101> result)
        {
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<SYS_C0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SYS_C0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SYS_C0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SYS_C0101> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SYS_C0101> result)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
