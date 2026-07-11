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

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M009_VM : WorkspaceViewModel<ADM_M009>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M009> repository = new WebServiceRepository<ADM_M009>();
        WebServiceRepository<MultipleContext_ADM_M009B> repositoryM = new WebServiceRepository<MultipleContext_ADM_M009B>();

        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _FilterStringTrans;
        private string _FilterStringLocation;
        private string _FilterStringAuthFild;

        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M009.HasErrors;
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
        private ICollectionView _TansactionCollection;
        public ICollectionView TansactionCollection
        {
            get { return _TansactionCollection; }
            set { _TansactionCollection = value; RaisePropertyChanged("TansactionCollection"); }
        }
        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }
        private ICollectionView _AuthFildCollection;
        public ICollectionView AuthFildCollection
        {
            get { return _AuthFildCollection; }
            set { _AuthFildCollection = value; RaisePropertyChanged("AuthFildCollection"); }
        }
        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandPopup
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandTransaction
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandLocation
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandAuthFild
        {
            get;
            private set;
        }
        public RelayCommand<object> CmdDeleteDataGridRow
        {
            get;
            private set;
        }
        #endregion

        #region ADM_M009
        private List<ADM_M009> _SelectedList;
        public List<ADM_M009> SelectedList
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
        private ADM_M009 _SelectedADM_M009;
        public ADM_M009 SelectedADM_M009
        {
            get
            {
                this.ErrorExist = _SelectedADM_M009.HasErrors;
                return _SelectedADM_M009;
            }
            set
            {
                if (_SelectedADM_M009 != value)
                {
                    _SelectedADM_M009 = value;
                    this.ErrorExist = _SelectedADM_M009.HasErrors;
                    RaisePropertyChanged("SelectedADM_M009");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ADM_M009B
        List<ADM_M009B> _SelectedADM_M009BList = new List<ADM_M009B>();
        public List<ADM_M009B> SelectedADM_M009BList
        {
            get { return _SelectedADM_M009BList; }
            set
            {
                if (_SelectedADM_M009BList != value)
                {
                    _SelectedADM_M009BList = value;

                    RaisePropertyChanged("SelectedADM_M009BList");
                }
            }
        }
        private static ObservableCollection<ADM_M009B> _RolDetails = new ObservableCollection<ADM_M009B>();
        public ObservableCollection<ADM_M009B> RolDetails
        {
            get { return _RolDetails; }
            set
            {
                if (_RolDetails != value)
                {
                    _RolDetails = value;

                    RaisePropertyChanged("RolDetails");
                }
            }
        }
        public ADM_M009B _SelectedADM_M009B { get; private set; }
        public ADM_M009B SelectedADM_M009B
        {
            get { return _SelectedADM_M009B; }
            set
            {
                if (_SelectedADM_M009B != value)
                {
                    _SelectedADM_M009B = value;
                    RaisePropertyChanged("SelectedADM_M009B");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ADM_M003_P    
        private List<ADM_M003_P> _SelectedLocationList;
        public List<ADM_M003_P> SelectedLocationList
        {
            get { return _SelectedLocationList; }
            set
            {
                if (_SelectedLocationList != value)
                {
                    _SelectedLocationList = value;

                    RaisePropertyChanged("SelectedLocationList");

                }
            }
        }
        #endregion

        #region ADM_M005_P       
        private List<ADM_M005_P> _SelectedAuthFildList;
        public List<ADM_M005_P> SelectedAuthFildList
        {
            get { return _SelectedAuthFildList; }
            set
            {
                if (_SelectedAuthFildList != value)
                {
                    _SelectedAuthFildList = value;

                    RaisePropertyChanged("SelectedAuthFildList");

                }
            }
        }

        #endregion
        #region ADM_M008B_P
        public ADM_M008B_P _SelectedTransDtls { get; private set; }
        public ADM_M008B_P SelectedTransDtls
        {
            get { return _SelectedTransDtls; }
            set
            {
                if (_SelectedTransDtls != value)
                {
                    _SelectedTransDtls = value;
                    RaisePropertyChanged("SelectedTransDtls");
                }
            }
        }
        #endregion
        #region Multiselectedcombo

        string _AuthFldCod;
        public string AuthFldCod
        {
            get { return _AuthFldCod; }
            set
            {
                if (_AuthFldCod != value)
                {
                    _AuthFldCod = value;

                    RaisePropertyChanged("AuthFldCod");
                }
            }
        }

        int _Location_Id;
        public int Location_Id
        {
            get { return _Location_Id; }
            set
            {
                if (_Location_Id != value)
                {
                    _Location_Id = value;

                    RaisePropertyChanged("Location_Id");
                }
            }
        }
        private Dictionary<string, object> _items;
        public Dictionary<string, object> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    RaisePropertyChanged("Items");
                }
            }
        }
        private Dictionary<string, object> _selectedItems;
        public Dictionary<string, object> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                RaisePropertyChanged("SelectedItems");
            }
        }

        private Dictionary<string, object> _Locations;
        public Dictionary<string, object> Locations
        {
            get
            {
                return _Locations;
            }
            set
            {
                _Locations = value;
                RaisePropertyChanged("Locations");
            }
        }

        private Dictionary<string, object> _SelectedLocationLst;
        public Dictionary<string, object> SelectedLocationLst
        {
            get
            {
                return _SelectedLocationLst;
            }
            set
            {
                _SelectedLocationLst = value;
                RaisePropertyChanged("SelectedLocationLst");
            }
        }

        #endregion

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


        private int _dgSelectedIndex;
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
        MultipleContext_ADM_M009B _MC = new MultipleContext_ADM_M009B();
        public MultipleContext_ADM_M009B MC
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
        public ADM_M009_VM()
            : base()
        {
            ADM_M008B.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new List<ADM_M009>();
            SelectedADM_M009BList = new List<ADM_M009B>();
            SelectedADM_M009 = new ADM_M009();
            SelectedADM_M009.ValidateAsync().Wait();
            MC = new MultipleContext_ADM_M009B();
            RolDetails = new ObservableCollection<ADM_M009B>();

            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    SelectedList = null;
                    return;
                }
                GetSelectedRole(items);
            });
            SelectionChangedCommandTransaction = new RelayCommand<object>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedTransDetails(items, true, false, true);
            });
            CmdDeleteDataGridRow = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow(cmdPara); });

            LoadInitialData();
            //this code is used for multiselected combo box for authorisaction and location---------------------
            Items = new Dictionary<string, object>();
            SelectedItems = new Dictionary<string, object>();
            Locations = new Dictionary<string, object>();
            SelectedLocationLst = new Dictionary<string, object>();
            Items.Clear();

            Items = SelectedAuthFildList.ToDictionary(X => X.AuthFldCod.ToString(), X => (object)X.AuthFldNm);
            Locations = SelectedLocationList.ToDictionary(X => X.location_Id.ToString(), X => (object)X.LoctnNm);
            //-----------------------------------------------------------------------------------------------------------  
        }
        private void LoadInitialData()
        {
            try
            {

                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ADM_M009B>(MC, "ADM_M009_Data", "RoleMaster", "Administration", "", 0, "");
                SelectedList = MC.RoleData;
                SelectedAuthFildList = MC.Authorisations;
                SelectedLocationList = MC.Locations;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                TansactionCollection = CollectionViewSource.GetDefaultView(MC.Transactions);
                TansactionCollection.Filter = new Predicate<object>(FilterTrans);
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

        int deletion_id;
        private void GetSelectedTransDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)//Select transaction code
        {
            //try
            //{
            //    string Request = "";
            //    ADM_M008B_P POPUPEntityObject = null;

            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            POPUPEntityObject = MC.Transactions.Where(x => x.TranCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
            //        }
            //    }
            //    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M008B_P>().Count() > 0)
            //    {
            //        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M008B_P>().ToList()[0];
            //    }

            //    if (POPUPEntityObject != null)
            //    {
            //        var InputValueIfExists = RolDetails.Where(x => x.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
            //        int IndexOfExistValue = RolDetails.IndexOf(RolDetails.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault());

            //        if (NewRow == true && (AllowDuplicate == false || IndexOfExistValue == -1) && RolDetails.Count-1 == dgSelectedIndex)
            //        {
            //            RolDetails.Add(new ADM_M009B()
            //            {
            //                TranName = POPUPEntityObject.TranName,
            //                TranCode = POPUPEntityObject.TranCode,
            //                deletion_id = deletion_id++
            //            });
            //        }
            //        else if (dgSelectedIndex >= 0 && RolDetails.Count > dgSelectedIndex)
            //        {
            //            foreach (var a in RolDetails)
            //            {
            //                if (a.SrNo == 0 && a.deletion_id == RolDetails[dgSelectedIndex].deletion_id && (AllowDuplicate == false))
            //                {
            //                    a.TranName = POPUPEntityObject.TranName;
            //                    a.TranCode = POPUPEntityObject.TranCode;
            //                    a.deletion_id = deletion_id++;
            //                }
            //                else if (a.deletion_id == RolDetails[dgSelectedIndex].deletion_id && RolDetails[dgSelectedIndex].TranCode != POPUPEntityObject.TranCode && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
            //                {
            //                    a.TranName = POPUPEntityObject.TranName;
            //                    a.TranCode = POPUPEntityObject.TranCode;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    //showMessageService.ButtonSetup = DialogButton.Ok;
            //    //showMessageService.Caption = "Message";
            //    //showMessageService.Text = String.Format(ex.Message, this.Title);
            //    //showMessageService.ShowMessage();
            //}

            if (dgSelectedIndex != -1)// && TransList.Count > 0)
            {
                IList list = InputValue as IList;
                List<ADM_M008B_P> SelectedTransDetailsTemp = list.Cast<ADM_M008B_P>().ToList();
                if (SelectedTransDetailsTemp.Count > 0)
                {
                    var q = RolDetails.Where(X => X.Tran_Code == SelectedTransDetailsTemp[0].TranCode).FirstOrDefault();
                    int x = RolDetails.IndexOf(RolDetails.Where(X => X.Tran_Code == SelectedTransDetailsTemp[0].TranCode).FirstOrDefault());
                    if (q == null && SelectedTransDetailsTemp[0].Select == true && RolDetails.Count != dgSelectedIndex)
                    {
                        SelectedTransDtls = (ADM_M008B_P)SelectedTransDetailsTemp[0];
                        RolDetails.Add(new ADM_M009B()
                        {
                            TranName = SelectedTransDetailsTemp[0].TranName,
                            TranCode = SelectedTransDetailsTemp[0].TranCode
                        });
                    }
                    else if (SelectedTransDetailsTemp[0].Select == false && q != null && RolDetails[x].SrNo == 0)
                    {
                        if (x >= 0)
                        {
                            RolDetails.RemoveAt(x);
                        }
                    }
                    else if (SelectedTransDetailsTemp[0].Select == true && q == null)
                    {
                        if (RolDetails.Count == dgSelectedIndex)
                        {
                            //SelectedTransDtls = (ADM_M008B_P)SelectedTransDetailsTemp[0];
                            RolDetails.Add(new ADM_M009B()
                            {
                                TranName = SelectedTransDetailsTemp[0].TranName,
                                TranCode = SelectedTransDetailsTemp[0].TranCode,
                                active = true
                            });
                        }
                        else
                        {
                            RolDetails[dgSelectedIndex].TranName = SelectedTransDetailsTemp[0].TranName;
                            RolDetails[dgSelectedIndex].TranCode = SelectedTransDetailsTemp[0].TranCode;
                            RolDetails[dgSelectedIndex].active = true;
                        }
                    }
                }
            }
        }
        private void GetSelectedRole(IList RoleList)//select role
        {
            IList list = RoleList as IList;

            List<ADM_M009> SelectedItemsList2 = list.Cast<ADM_M009>().ToList();

            if (SelectedItemsList2.Count > 0)
            {
                SelectedADM_M009 = (ADM_M009)SelectedItemsList2[0];

            }
            ObservableCollection<ADM_M009B> result = (ObservableCollection<ADM_M009B>)MC.RolDetails.Cast<ADM_M009B>();
            IEnumerable<ADM_M009B> barEnumerable =
                    from data in result
                    where data.RoleCode == SelectedADM_M009.RoleCode
                    select data;

            RolDetails = new ObservableCollection<ADM_M009B>(barEnumerable);
            _dataGridCollection.Refresh();
            blNew = false;
            SelectedTabControlIndex = 0;
        }
        private void DeleteDataGridRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (RolDetails.Count > i && RolDetails[dgSelectedIndex].SrNo == 0)
                {
                    RolDetails.RemoveAt(i);
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

        #region · Command Actions ·      
        protected override void OnSaveAction(InquiryActionResult<ADM_M009> result)
        {
            try
            {
                this.SelectedADM_M009.EndEdit();
                SelectedADM_M009.client = AppSessionState.client;
                SelectedADM_M009.comp_code = AppSessionState.comp_code;
                SelectedADM_M009.add_by = AppSessionState.UserID;
                SelectedADM_M009.editby = AppSessionState.UserID;
                ObjectSerializationService objSer = new ObjectSerializationService();
                SelectedADM_M009.XmlDataDocument = objSer.ObjectToXML(RolDetails);
                if (RolDetails[0].AuthFldCod != null && RolDetails[0].LoctnCode != null)
                {
                    if (blNew == true)
                    {
                        SelectedADM_M009 = repository.SaveWithReturnDomainObject<ADM_M009>(SelectedADM_M009, "RoleMaster", "Administration");
                        SelectedList.Add(SelectedADM_M009);
                        RolDetails = (ObservableCollection<ADM_M009B>)objSer.XMLToObject(SelectedADM_M009.XmlDataDocument, RolDetails);
                        foreach (var sodtel in RolDetails)
                        {
                            MC.RolDetails.Add(sodtel);
                        }
                        _dataGridCollection.Refresh();
                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        int y = 0;
                        if (SelectedADM_M009.active == false)//if master cative false its not display on screen------------------------------
                        {
                            y = 1;
                        }
                        SelectedADM_M009 = repository.UpdateWithReturnDomainObject<ADM_M009>(SelectedADM_M009, "RoleMaster", "Administration");
                        this.SelectedADM_M009.EndEdit();
                        if (y == 1)
                        {
                            SelectedADM_M009 = new ADM_M009();
                        }
                        var toUpdateSO = MC.RolDetails.Where(X => X.RoleCode == SelectedADM_M009.RoleCode).ToList();
                        _dataGridCollection.Refresh();

                    }
                    if (SelectedADM_M009.XmlDataDocument != null)
                    {
                        int x = MC.RolDetails.IndexOf(MC.RolDetails.Where(X => X.RoleCode == SelectedADM_M009.RoleCode).FirstOrDefault());
                        if (x != -1)
                        {
                            if (MC.RolDetails[x].active != false)
                            {
                                MC.RolDetails = (ObservableCollection<ADM_M009B>)new ObjectSerializationService().XMLToObject(SelectedADM_M009.XmlDataDocument, MC.RolDetails);
                            }
                            else
                            {
                                MC.RolDetails = new ObservableCollection<ADM_M009B>();
                            }
                        }
                    }
                    else
                    {
                        MC.RolDetails = new ObservableCollection<ADM_M009B>();
                    }
                    RolDetails = MC.RolDetails;
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Authorization AND Location Code", this.Title);
                    showMessageService.ShowMessage();
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M009> result)
        {
            blNew = true;
            foreach (var listTrans in MC.Transactions.ToList())
                listTrans.Select = false;
            SelectedADM_M009 = new ADM_M009();
            SelectedADM_M009B = new ADM_M009B();
            RolDetails = new ObservableCollection<ADM_M009B>();
            SelectedADM_M009.ValidateAsync().Wait();
            _dataGridCollection.Refresh();
            MC.Transactions = new List<ADM_M008B_P>();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M009> result)
        {
            if (SelectedADM_M009.RoleCode != null)
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
                    this.SelectedADM_M009.CancelEdit();
                    string response = repository.Delete(SelectedADM_M009.RoleCode, "RoleMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M009);
                    SelectedADM_M009 = new ADM_M009();
                    RolDetails = new ObservableCollection<ADM_M009B>();
                    _dataGridCollection.Refresh();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M009> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M009 = SelectedADM_M009;
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M009> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M009> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M009 = SelectedADM_M009;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M009> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M009 = SelectedADM_M009;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M009> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M009 = SelectedADM_M009;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M009> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M009> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For AuthFild
        public string FilterStringAuthFild
        {
            get { return _FilterStringAuthFild; }
            set
            {
                _FilterStringAuthFild = value;
                RaisePropertyChanged("FilterStringAuthFild");
                FilterCollectionAuthFild();
            }
        }
        private void FilterCollectionAuthFild()
        {
            if (_AuthFildCollection != null)
            {
                _AuthFildCollection.Refresh();
            }
        }
        public bool AuthFildFilter(object obj)
        {
            var data = obj as ADM_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringAuthFild))
                {
                    return (data.AuthFldCod != null) ||
                    (data.AuthFldNm != null && data.AuthFldNm.ToString().ToLower().Contains(_FilterStringAuthFild.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For Trans
        public string FilterStringTrans
        {
            get { return _FilterStringTrans; }
            set
            {
                _FilterStringTrans = value;
                RaisePropertyChanged("FilterStringTrans");
                FilterCollectionTrans();
            }
        }
        private void FilterCollectionTrans()
        {
            if (_TansactionCollection != null)
            {
                _TansactionCollection.Refresh();
            }
        }
        public bool FilterTrans(object obj)
        {
            var data = obj as ADM_M008B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringTrans))
                {
                    return (data.TranCode != null && data.TranCode.ToLower().ToString().Contains(_FilterStringTrans.ToLower().ToString())) ||
                           (data.TranName != null && data.TranName.ToLower().ToString().Contains(_FilterStringTrans.ToLower().ToString()));

                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters For Location
        public string FilterStringLocation
        {
            get { return _FilterStringLocation; }
            set
            {
                _FilterStringLocation = value;
                RaisePropertyChanged("FilterStringLocation");
                FilterCollectionLocation();
            }
        }
        private void FilterCollectionLocation()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }
        }
        public bool FilterLocation(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringLocation))
                {
                    return data.location_Id.ToString().ToLower().Contains(_FilterStringLocation.ToLower());
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
            var data = obj as ADM_M009;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.RoleName != null && data.RoleName.ToLower().Contains(_filterString.ToLower())) ||
                            data.RoleCode.ToString().ToLower().Contains(_filterString.ToLower());
                }
                return true;
            }
            return false;
        }

        
    }
}
