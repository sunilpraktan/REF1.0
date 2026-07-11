using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ZADM_M009_VM : WorkspaceViewModel<ZADM_M009>
    {
        #region Declaration
        bool isNewRecord = true;

        WebServiceRepository<ZADM_M009> repository = new WebServiceRepository<ZADM_M009>();
        WebServiceRepository<MultipleContext_ZADM_M009> repository_MC = new WebServiceRepository<MultipleContext_ZADM_M009>();
        WebServiceRepository<MultipleContext_ZADM_M009> repository_MCTemp = new WebServiceRepository<MultipleContext_ZADM_M009>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ZADM_M009 _MC = new MultipleContext_ZADM_M009();
        public MultipleContext_ZADM_M009 MC
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

        private MultipleContext_ZADM_M009 _MCTemp = new MultipleContext_ZADM_M009();
        public MultipleContext_ZADM_M009 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private ZADM_M009 _MasterEntity;
        public ZADM_M009 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
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

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }
        #endregion

        #region ICollection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        private ICollectionView _WireSizeCollection;
        public ICollectionView WireSizeCollection
        {
            get { return _WireSizeCollection; }
            set
            {
                _WireSizeCollection = value;

                RaisePropertyChanged("WireSizeCollection");
            }
        }
        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region List

        private List<ZADM_M009_Flip> _FlipGridData;
        public List<ZADM_M009_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

        #endregion

        #region StringList

        // WireSize
        List<string> _StringListWireSize;
        public List<string> StringListWireSize
        {
            get { return _StringListWireSize; }
            set
            {
                if (_StringListWireSize != value)
                {
                    _StringListWireSize = value;
                }
            }
        }

        #endregion

        #region Filters

        //Filter BackFlip

        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as ZADM_M009_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.model_id != null && data.model_id.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.modelno != null && data.modelno.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.modeldesc != null && data.modeldesc.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.modlnm != null && data.modlnm.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        //Filter WireSize

        private string _FilterStringWireSize;
        public string FilterStringWireSize
        {
            get { return _FilterStringWireSize; }
            set
            {
                _FilterStringWireSize = value;
                RaisePropertyChanged("FilterStringWireSize");
                Filter_WireSize();
            }
        }
        private void Filter_WireSize()
        {
            if (_WireSizeCollection != null)
            {
                _WireSizeCollection.Refresh();
            }
        }
        public bool Filter_WireSize(object obj)
        {
            var data = obj as ZADM_M003_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringWireSize))
                {
                    return (data.wire_size_id != null && data.wire_size_id.ToString().ToLower().Contains(_FilterStringWireSize.ToLower())) ||
                           (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_FilterStringWireSize.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdAddWireSize { get; private set; }
        public RelayCommand CmdOpenFile { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Constructor
        public ZADM_M009_VM(string ts_code) : base()

        {

            MasterEntity = new ZADM_M009();

            FlipGridData = new List<ZADM_M009_Flip>();
            MC = new MultipleContext_ZADM_M009();
            MCTemp = new MultipleContext_ZADM_M009();
            CmdOpenFile = new RelayCommand(OpenFile);
            MasterEntity.ValidateAsync().Wait();

            CmdAddWireSize = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireSize(items); });
         
            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });

            MoveFlag = true;
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZADM_M009>(MC, Request, "ModelMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                WireSizeCollection = CollectionViewSource.GetDefaultView(MC.wiresize);
                WireSizeCollection.Filter = new Predicate<object>(Filter_WireSize);
                StringListWireSize = MC.wiresize.Select(x => x.wire_size_id.ToString()).ToList();


                DefaultValues();
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
        private void DefaultValues()
        {
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.date = DateTime.Now;
        }
        private bool Validation()
        {
            if (MasterEntity.wire_size == null || MasterEntity.wire_size.ToString() == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Wire Dia...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.basicmodel == null || MasterEntity.basicmodel.ToString() == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Model Name...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.modelno == null || MasterEntity.modelno.ToString() == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Model Number...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        #endregion

        #region Relay Command Implementation
        private void InsertWireSize(object InputValue)
        {
            string Request = "";
            ZADM_M003_PopUp POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.wiresize.Where(x => x.wire_size_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_PopUp>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.wire_size_id = POPUPEntityObject.wire_size_id;
                MasterEntity.wire_size = POPUPEntityObject.wire_size;
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";

                ZADM_M009_Flip ParameterEntityObject = null;
                MasterEntity = new ZADM_M009();

                if (((IEnumerable)ParameterObject).Cast<ZADM_M009_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZADM_M009_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.model_id;
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M009>(MCTemp, Request, "ModelMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                    MasterEntity = MCTemp.MasterEntity[0];

                    

                    AttachmentCollection = MC.AttachmentList;

                    if (MC.AttachmentList != null)
                    {
                        AttachmentCollection = MC.AttachmentList;
                    }
                    else
                    {
                        MC.AttachmentList = new List<COM_T003>();
                    }
                    MoveFlag = false;
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

        #endregion

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ZADM_M009> result)
        {
            try
            {
                if (Validation() == true)
                {

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ZADM_M009>(MasterEntity, "ModelMaster", "Administration");

                        if (MasterEntity.modelno != null || MasterEntity.modelno != " ")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }

                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ZADM_M009>(MasterEntity, "ModelMaster", "Administration");

                        if (MasterEntity.modelno != null || MasterEntity.modelno != " ")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Updated Successfully");
                            showMessageService.ShowMessage();
                        }
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
                    MoveFlag = false;
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

        protected override void OnCreateAction(InquiryActionResult<ZADM_M009> result)
        {
            isNewRecord = true;
            MasterEntity = new ZADM_M009();
            MasterEntity.ValidateAsync().Wait();
            FlipDataGridCollection.Refresh();
            DefaultValues();
            MoveFlag = true;
        }

        protected override void OnRemoveAction(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }
        
        protected override void OnFlipAction(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.model_id.ToString()))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.model_id.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = AppSessionState.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M009> result)
        {
            throw new NotImplementedException();
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<ZADM_M009_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("modelno", ListSortDirection.Descending));
            }
        }
        #endregion

        //#region Open Image
         string imageName;
        private void OpenFile()
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {

                    imageName = fldlg.FileName;

                    MasterEntity.drgflnm = File.ReadAllBytes(imageName);
                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public BitmapImage ImageFromBytearray(byte[] imageData)
        {

            if (imageData == null)
                return null;
            MemoryStream strm = new MemoryStream();
        strm.Write(imageData, 0, imageData.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);

        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
        img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        
        // #endregion
    }
}







