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
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0009_VM : WorkspaceViewModel<ADM_M012>
    {
        bool blNew = true;
        WebServiceRepository<List<ADM_M012>> repository_list = new WebServiceRepository<List<ADM_M012>>();
        WebServiceRepository<ADM_M012> repository = new WebServiceRepository<ADM_M012>();
        private ICollectionView _dataGridCollection;
        private string _filterString;


        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M012.HasErrors;
        }



        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get;
            private set;
        }

        private List<ADM_M012> _SelectedList;
        public List<ADM_M012> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private ADM_M012 _SelectedADM_M012;
        public ADM_M012 SelectedADM_M012
        {
            get
            {
                this.ErrorExist = _SelectedADM_M012.HasErrors;
                return _SelectedADM_M012;
            }
            set
            {
                if (_SelectedADM_M012 != value)
                {
                    _SelectedADM_M012 = value;
                    RaisePropertyChanged("SelectedADM_M012");
                    value.BeginEdit();
                }
            }
        }
        private int _selectedTabControlIndex { get; set; }
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
        public ADM_M0009_VM(string ts_code) : base()
        {
            ADM_M012.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new List<ADM_M012>();
            SelectedADM_M012 = new ADM_M012();
            SelectedADM_M012.ValidateAsync().Wait();
            OpenCommand = new RelayCommand(OpenFile);
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            LoadInitialData();
        }

        #region Open Image
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
                    SelectedADM_M012.CntryFlag = File.ReadAllBytes(imageName);
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
        #endregion

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M012> tSelectedItemsList = list.Cast<ADM_M012>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M012 = (ADM_M012)tSelectedItemsList[0];
                blNew = false;
                SelectedTabControlIndex = 0;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                SelectedList = repository_list.GetDataWithReturnDomainObject<List<ADM_M012>>(SelectedList, "ADM_M012_Data", "CountryMaster", "Administration", "", 0, "");
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);
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

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ADM_M012> result)
        {
            try
            {
                this.SelectedADM_M012.EndEdit();
                if (blNew == true)
                {
                    SelectedADM_M012.add_by = AppSessionState.UserID;

                    SelectedADM_M012 = repository.SaveWithReturnDomainObject<ADM_M012>(SelectedADM_M012, "CountryMaster", "Administration");
                    SelectedList.Add(SelectedADM_M012);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedADM_M012.editby = AppSessionState.UserID;
                    string response = repository.Update<ADM_M012>(SelectedADM_M012, "CountryMaster", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M012> result)
        {
            blNew = true;
            SelectedADM_M012 = new ADM_M012();
            _dataGridCollection.Refresh();
            SelectedADM_M012.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M012> result)
        {
            if (SelectedADM_M012.country_code != null)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will delete forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    SelectedADM_M012.CancelEdit();
                    string response = repository.Delete(SelectedADM_M012.country_code, "CountryMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M012);
                    _dataGridCollection.Refresh();
                    SelectedADM_M012 = new ADM_M012();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M012> result)
        {
            SelectedADM_M012.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M012> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M012> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M012 = SelectedADM_M012;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M012> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M012 = SelectedADM_M012;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M012> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M012 = SelectedADM_M012;
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M012> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M012> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M012> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M012> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M012> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region FilterMethods

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }

        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as ADM_M012;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.CntryAbbre != null && data.CntryAbbre.ToString().Contains(_filterString.ToLower())) ||
                         (data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                          (data.CntryCurncy != null && data.CntryCurncy.ToString().ToLower().Contains(_filterString.ToLower())) ||
                          (data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }




        #endregion
    }
}
