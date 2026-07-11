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
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M010_VM : WorkspaceViewModel<ADM_M010>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M010> repository = new WebServiceRepository<ADM_M010>();
        WebServiceRepository<MultipleContext_ADM_M010> repositoryM = new WebServiceRepository<MultipleContext_ADM_M010>();

        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringRol;
        private string _filterStringUserType;
        private string _filterStringEmp;
        private int _dgSelectedIndex;
        string imageName;


        #region Declaration

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


        #endregion
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M010.HasErrors;
        }
        
        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _RoleCollection;
        public ICollectionView RoleCollection
        {
            get { return _RoleCollection; }
            set
            {
                _RoleCollection = value;

                RaisePropertyChanged("RoleCollection");
            }
        }

        private ICollectionView _UserTypeCollection;
        public ICollectionView UserTypeCollection
        {
            get { return _UserTypeCollection; }
            set
            {
                _UserTypeCollection = value;

                RaisePropertyChanged("UserTypeCollection");
            }
        }

        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set
            {
                _EmpCollection = value;

                RaisePropertyChanged("EmpCollection");
            }
        }

        #endregion
        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandRoles
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandUserType
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandEmp
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandUserdetails
        {
            get;
            private set;
        }

        private RelayCommand _OpenCommand;
        public RelayCommand OpenCommand
        {
            get;
            private set;
        }

        #endregion
        #region ADM_M010
        private List<ADM_M010> _SelectedList;
        public List<ADM_M010> SelectedList
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
        private ADM_M010 _SelectedADM_M010;
        public ADM_M010 SelectedADM_M010
        {
            get
            {
                _SelectedADM_M010.ValidateAsync().Wait();
                this.ErrorExist = _SelectedADM_M010.HasErrors;
                return _SelectedADM_M010;
            }
            set
            {
                if (_SelectedADM_M010 != value)
                {
                    _SelectedADM_M010 = value;


                    RaisePropertyChanged("SelectedADM_M010");
                    value.BeginEdit();

                }
            }
        }
        #endregion
        #region ADM_M010B
        private ObservableCollection<ADM_M010B> _UserDtls;
        public ObservableCollection<ADM_M010B> UserDtls
        {
            get { return _UserDtls; }
            set
            {
                if (_UserDtls != value)
                {
                    _UserDtls = value;

                    RaisePropertyChanged("UserDtls");
                }
            }
        }


        #endregion
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }
        private MultipleContext_ADM_M010 _MC;
        public MultipleContext_ADM_M010 MC
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
        public ADM_M010_VM()
            : base()
        {
            ADM_M010.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);

            SelectedList = new List<ADM_M010>();

            SelectedADM_M010 = new ADM_M010();

            SelectedADM_M010.ValidateAsync().Wait();

            MC = new MultipleContext_ADM_M010();

            UserDtls = new ObservableCollection<ADM_M010B>();

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
            SelectionChangedCommandUserdetails = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedUser(items);
            });
            SelectionChangedCommandRoles = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedRoleDetails(items);
            });
            SelectionChangedCommandUserType = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedUserTypeDetails(items);
            });
            SelectionChangedCommandEmp = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedEmpDetails(items);
            });

            LoadInitialData();
        }

        #region Open Image

        private void OpenFile()
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.Gif)|*.jpg;*.bmp;*.Gif";
                fldlg.ShowDialog();
                {

                    imageName = fldlg.FileName;

                    SelectedADM_M010.Photo = File.ReadAllBytes(imageName);

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
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Gif);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
        #endregion
        private void LoadInitialData()
        {
            try
            {
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ADM_M010>(MC, "ADM_M010_Data", "UserMaster", "Administration", "", 0, "");
                SelectedList = MC.Users;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                RoleCollection = CollectionViewSource.GetDefaultView(MC.RoleData);
                RoleCollection.Filter = new Predicate<object>(RoleFilter);

                UserTypeCollection = CollectionViewSource.GetDefaultView(MC.UserTypes);
                UserTypeCollection.Filter = new Predicate<object>(UserTypeFilter);

                EmpCollection = CollectionViewSource.GetDefaultView(MC.Employees);
                EmpCollection.Filter = new Predicate<object>(EmpFilter);
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

        private void GetSelectedRoleDetails(IList RoleList)
        {
            if (dgSelectedIndex != -1 && RoleList.Count > 0)
            {
                IList list = RoleList as IList;
                List<ADM_M009_P> SelectedRoleDetailsTemp = list.Cast<ADM_M009_P>().ToList();
                if (SelectedRoleDetailsTemp.Count > 0)
                {
                    var q = UserDtls.Where(X => X.RoleCode == SelectedRoleDetailsTemp[0].RoleCode).FirstOrDefault();
                    int x = UserDtls.IndexOf(UserDtls.Where(X => X.RoleCode == SelectedRoleDetailsTemp[0].RoleCode).FirstOrDefault());

                    if (q == null && SelectedRoleDetailsTemp[0].Select == true && UserDtls.Count == dgSelectedIndex)
                    {

                        //SelectedRoleDtls = SelectedRoleDetailsTemp[0];
                        UserDtls.Add(new ADM_M010B()
                        {
                            RoleCode = SelectedRoleDetailsTemp[0].RoleCode,
                            RoleName = SelectedRoleDetailsTemp[0].RoleName,
                        });
                    }
                    else if (SelectedRoleDetailsTemp[0].Select == false && q != null && UserDtls[x].SrNo == 0)
                    {
                        if (x >= 0)
                        {
                            UserDtls.RemoveAt(x);
                        }
                    }
                    else if (SelectedRoleDetailsTemp[0].Select == true && q == null) // && r != null && r >= 0)
                    {
                        UserDtls[dgSelectedIndex].RoleCode = SelectedRoleDetailsTemp[0].RoleCode;
                        UserDtls[dgSelectedIndex].RoleName = SelectedRoleDetailsTemp[0].RoleName;
                    }
                }
            }
        }
        private void GetSelectedUser(IList UserList)
        {

            IList list = UserList as IList;

            List<ADM_M010> SelectedItemsList2 = list.Cast<ADM_M010>().ToList();

            if (SelectedItemsList2.Count > 0)
            {
                SelectedADM_M010 = (ADM_M010)SelectedItemsList2[0];

            }
            if (SelectedADM_M010 != null)
            {
                ObservableCollection<ADM_M010B> result = (ObservableCollection<ADM_M010B>)MC.UserDtls.Cast<ADM_M010B>();
                IEnumerable<ADM_M010B> barEnumerable =
                        from data in result
                        where data.UserId == SelectedADM_M010.UserId
                        select data;

                UserDtls = new ObservableCollection<ADM_M010B>(barEnumerable);
            }
            blNew = false;
            SelectedTabControlIndex = 0;
        }
        private void GetSelectedUserTypeDetails(IList UserTypeList)
        {
            IList list = UserTypeList as IList;
            List<ADM_M007_P> GetSelectedUserTypeDetailsTemp = list.Cast<ADM_M007_P>().ToList();
            if (GetSelectedUserTypeDetailsTemp.Count > 0)
            {
                SelectedADM_M010.UserTypCode = Convert.ToInt32(GetSelectedUserTypeDetailsTemp[0].UserTypCode);
                SelectedADM_M010.UserTyp = GetSelectedUserTypeDetailsTemp[0].UserTyp;
            }

        }
        private void GetSelectedEmpDetails(IList EmpList)
        {
            IList list = EmpList as IList;
            List<ADM_M024_P> GetSelectedEmpDetailsTemp = list.Cast<ADM_M024_P>().ToList();
            if (GetSelectedEmpDetailsTemp.Count > 0)
            {
                SelectedADM_M010.EmpId = GetSelectedEmpDetailsTemp[0].EmpId;
                SelectedADM_M010.EmpNm = GetSelectedEmpDetailsTemp[0].EmpName;

                SelectedADM_M010.Photo = GetSelectedEmpDetailsTemp[0].Photo;


            }

        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M010> tSelectedItemsList = list.Cast<ADM_M010>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M010 = (ADM_M010)tSelectedItemsList[0];
                        
                blNew = false;
                

            }
        }

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M010> result)
        {
            try
            {
                this.SelectedADM_M010.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();
                SelectedADM_M010.XmlDataDocument = objSer.ObjectToXML(UserDtls);
                SelectedADM_M010.client = AppSessionState.client;
                SelectedADM_M010.comp_code = AppSessionState.comp_code;
                SelectedADM_M010.add_by = AppSessionState.UserID;
                SelectedADM_M010.editby = AppSessionState.UserID;
                if (blNew == true)
                {
                    SelectedADM_M010 = repository.SaveWithReturnDomainObject<ADM_M010>(SelectedADM_M010, "UserMaster", "Administration");
                    SelectedList.Add(SelectedADM_M010);
                    UserDtls = (ObservableCollection<ADM_M010B>)objSer.XMLToObject(SelectedADM_M010.XmlDataDocument, UserDtls);
                    foreach (var sodtel in UserDtls)
                    {
                        MC.UserDtls.Add(sodtel);
                    }
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ADM_M010>(SelectedADM_M010, "UserMaster", "Administration");
                    UserDtls = (ObservableCollection<ADM_M010B>)new ObjectSerializationService().XMLToObject(SelectedADM_M010.XmlDataDocument, UserDtls);

                    var toUpdateuser = MC.UserDtls.Where(X => X.UserId == SelectedADM_M010.UserId).ToList();
                    foreach (var itm in UserDtls)
                    {

                        int x = MC.UserDtls.IndexOf(MC.UserDtls.Where(X => X.UserId == SelectedADM_M010.UserId).FirstOrDefault());
                        if (x != -1)
                        {
                            if (itm != null) { MC.UserDtls.RemoveAt(x); }
                        }

                    }
                    foreach (var itm in UserDtls)
                    {
                        MC.UserDtls.Add(itm);
                    }
                    _dataGridCollection.Refresh();

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
        protected override void OnCreateAction(InquiryActionResult<ADM_M010> result)
        {
            blNew = true;
            SelectedADM_M010 = new ADM_M010();
            //SelectedADM_M010B = new ADM_M010B();
            UserDtls = new ObservableCollection<ADM_M010B>();
            SelectedADM_M010.ValidateAsync().Wait();
            _dataGridCollection.Refresh();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M010> result)
        {
            if (SelectedADM_M010.UserId != null)
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
                    this.SelectedADM_M010.CancelEdit();
                    string response = repository.Delete(SelectedADM_M010.UserId, "UserMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M010);
                    SelectedADM_M010 = new ADM_M010();
                    UserDtls = new ObservableCollection<ADM_M010B>();
                    _dataGridCollection.Refresh();
                    blNew = true;
                }
            }

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M010> result)
        {
            SelectedADM_M010.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M010> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M010> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M010 = SelectedADM_M010;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M010> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M010 = SelectedADM_M010;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M010> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M010 = SelectedADM_M010;
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M010> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Filters For Role
        private void FilterCollectionRol()
        {
            if (_RoleCollection != null)
            {
                _RoleCollection.Refresh();
            }
        }
        public string FilterStringRol
        {
            get { return _filterStringRol; }
            set
            {
                _filterStringRol = value;
                RaisePropertyChanged("FilterStringRol");
                FilterCollectionRol();
            }
        }
        public bool RoleFilter(object obj)
        {
            var data = obj as ADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringRol))
                {
                    return (data.RoleCode != null && data.RoleCode.ToString().ToLower().Contains(_filterStringRol.ToLower())) ||
                     (data.RoleName != null && data.RoleName.ToString().ToLower().Contains(_filterStringRol.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters For UserType
        private void FilterCollectionUserType()
        {
            if (_UserTypeCollection != null)
            {
                _UserTypeCollection.Refresh();
            }
        }
        public string FilterStringUserType
        {
            get { return _filterStringUserType; }
            set
            {
                _filterStringUserType = value;
                RaisePropertyChanged("FilterStringUserType");
                FilterCollectionUserType();
            }
        }
        public bool UserTypeFilter(object obj)
        {
            var data = obj as ADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUserType))
                {
                    return (data.UserTyp != null && data.UserTyp.ToString().ToLower().Contains(_filterStringUserType.ToLower())) ||
                    (data.UserTypCode != null && data.UserTypCode.ToString().ToLower().Contains(_filterStringUserType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters For Emp
        private void FilterCollectionEmp()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        public string FilterStringEmp
        {
            get { return _filterStringEmp; }
            set
            {
                _filterStringEmp = value;
                RaisePropertyChanged("FilterStringEmp");
                FilterCollectionEmp();
            }
        }
        public bool EmpFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmp))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringEmp.ToLower())) ||

                          (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmp.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion
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
            var data = obj as ADM_M010;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.UserId != null && data.UserId.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.Title != null && data.Title.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.UserTyp != null && data.UserTyp.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.EmpNm != null && data.EmpNm.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.LockStat != null && data.LockStat.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    data.LockBy != null && data.LockBy.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        
    }
}
