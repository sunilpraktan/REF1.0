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

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ZADM_M018_VM:WorkspaceViewModel<ZADM_M018>
    {
        bool blNew = true;
        WebServiceRepository<ZADM_M018> repository = new WebServiceRepository<ZADM_M018>();
        WebServiceRepository<MultipleContext_ZADM_M018> repositoryM = new WebServiceRepository<MultipleContext_ZADM_M018>();
        MultipleContext_ZADM_M018 MCTemp = new MultipleContext_ZADM_M018();

        private ICollectionView _dataGridCollection;
        private int _dgSelectedIndex;
        private string _filterString;
        private string _filterStringProduct;
        private string _filterStringCustomer;
        private string _filterStringINK;
        private string _filterStringILD;
        private string _filterStringPlant;

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionPlant;
        public ICollectionView CollectionPlant
        {
            get { return _CollectionPlant; }
            set { _CollectionPlant = value; RaisePropertyChanged("CollectionPlant"); }
        }

        private ICollectionView _CollectionProduct;
        public ICollectionView CollectionProduct
        {
            get { return _CollectionProduct; }
            set { _CollectionProduct = value; RaisePropertyChanged("CollectionProduct"); }
        }

        private ICollectionView _CollectionINK;
        public ICollectionView CollectionINK
        {
            get { return _CollectionINK; }
            set { _CollectionINK = value; RaisePropertyChanged("CollectionINK"); }
        }

        private ICollectionView _CollectionILD;
        public ICollectionView CollectionILD
        {
            get { return _CollectionILD; }
            set { _CollectionILD = value; RaisePropertyChanged("CollectionILD"); }
        }    

        private ICollectionView _CollectionCustomer;
        public ICollectionView CollectionCustomer
        {
            get { return _CollectionCustomer; }
            set { _CollectionCustomer = value; RaisePropertyChanged("CollectionCustomer"); }
        }
        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandGoodsDetails
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandPlant
        {
            get;
            private set;
        }
      
        public RelayCommand<IList> SelectionChangedCommandProduct
        {
            get;
            private set;
        }
      
        public RelayCommand<IList> SelectionChangedCommandINK
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILD
        {
            get;
            private set;
        }
       
        public RelayCommand<IList> SelectionChangedCommandCustomer
        {
            get;
            private set;
        }       

        #endregion

        #region ZADM_M018
        private List<ZADM_M018> _SelectedList;
        public List<ZADM_M018> SelectedList
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

        private ZADM_M018 _SelectedZADM_M018;
        public ZADM_M018 SelectedZADM_M018
        {
            get
            {
                this.ErrorExist = _SelectedZADM_M018.HasErrors;
                return _SelectedZADM_M018;
            }
            set
            {
                if (_SelectedZADM_M018 != value)
                {
                    _SelectedZADM_M018 = value;
                    this.ErrorExist = _SelectedZADM_M018.HasErrors;
                    RaisePropertyChanged("SelectedZADM_M018");
                    value.BeginEdit();
                }
            }
        }

       
        #endregion

        #region ZADM_M018
        private static ObservableCollection<ZADM_M018> _GoodsDetails = new ObservableCollection<ZADM_M018>();
        public ObservableCollection<ZADM_M018> GoodsDetails
        {
            get { return _GoodsDetails; }
            set
            {
                if (_GoodsDetails != value)
                {
                    _GoodsDetails = value;

                    RaisePropertyChanged("GoodsDetails");
                }
            }
        }
        #endregion     

        #region ADM_M003 poup Plant
        private List<ADM_M003_PopUp> _SelectedPlantList;
        public List<ADM_M003_PopUp> SelectedPalntList
        {
            get { return _SelectedPlantList; }
            set
            {
                if (_SelectedPlantList != value)
                {
                    _SelectedPlantList = value;
                    RaisePropertyChanged("SelectedPalntList");
                }
            }
        }
        #endregion

        #region ADM_M022 poup Product
        private List<ADM_M022_ESSEM_PopUp> _SelectedProductList;
        public List<ADM_M022_ESSEM_PopUp> SelectedProductList
        {
            get { return _SelectedProductList; }
            set
            {
                if (_SelectedProductList != value)
                {
                    _SelectedProductList = value;
                    RaisePropertyChanged("SelectedProductList");
                }
            }
        }
        #endregion

        #region ZADM_M006_PopUp  INK
        private List<ZADM_M006_PopUp> _SelectedINKList;
        public List<ZADM_M006_PopUp> SelectedINKList
        {
            get { return _SelectedINKList; }
            set
            {
                if (_SelectedINKList != value)
                {
                    _SelectedINKList = value;
                    RaisePropertyChanged("SelectedINKList");
                }
            }
        }
        #endregion

        #region ZADM_M007_PopUp  ILD
        private List<ZADM_M007_PopUp> _SelectedILDList;
        public List<ZADM_M007_PopUp> SelectedILDList
        {
            get { return _SelectedILDList; }
            set
            {
                if (_SelectedILDList != value)
                {
                    _SelectedILDList = value;
                    RaisePropertyChanged("SelectedILDList");
                }
            }
        }
        #endregion

        #region ADM_M028_popup  cutomer
        private List<ADM_M028_PopUp> _SelectedCustomerList;
        public List<ADM_M028_PopUp> SelectedCustomerList
        {
            get { return _SelectedCustomerList; }
            set
            {
                if (_SelectedCustomerList != value)
                {
                    _SelectedCustomerList = value;
                    RaisePropertyChanged("SelectedCustomerList");
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

        MultipleContext_ZADM_M018 _MC = new MultipleContext_ZADM_M018();
        public MultipleContext_ZADM_M018 MC
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

        #region 
        public ZADM_M018_VM()
            : base()
        {
            SelectedList = new List<ZADM_M018>();
            SelectedZADM_M018 = new ZADM_M018();
            SelectedPalntList = new List<ADM_M003_PopUp>();          
            SelectedProductList= new List<ADM_M022_ESSEM_PopUp>();           
            SelectedINKList = new List<ZADM_M006_PopUp>();
            SelectedILDList = new List<ZADM_M007_PopUp>();       
            SelectedCustomerList = new List<ADM_M028_PopUp>();          

            GoodsDetails = new ObservableCollection<ZADM_M018>();

            MC = new MultipleContext_ZADM_M018();
           
            SelectedZADM_M018.ValidateAsync().Wait();           

            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });

            SelectionChangedCommandGoodsDetails = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
               // GetSelectedGoodDetails(items);
                GetSelectedList(items);
               
            });

            SelectionChangedCommandPlant = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedPlant(items);
              });

              SelectionChangedCommandProduct = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedProduct(items);
              });
              SelectionChangedCommandINK = new RelayCommand<IList>(
                 items =>
                 {
                     if (items == null)
                     {
                         return;
                     }

                     GetSelectedINK(items);
                 });
              SelectionChangedCommandILD = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedILD(items);
                });
                SelectionChangedCommandCustomer = new RelayCommand<IList>(
                  items =>
                     {
                          if (items == null)
                          {
                              return;
                          }

                          GetSelectedCustomer(items);
                    });
            
          SelectedZADM_M018.entry_dt = DateTime.Now.Date;
          LoadInitialData();
        }

         #endregion

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZADM_M018> tSelectedItemsList = list.Cast<ZADM_M018>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZADM_M018 = (ZADM_M018)tSelectedItemsList[0];
                blNew = false;
            }
        }

        private void GetSelectedGoodDetails(IList IssueList)
        {
            try
            {
                IList list = IssueList as IList;

                List<ZADM_M018> SelectedItemsList2 = list.Cast<ZADM_M018>().ToList();
                if (SelectedItemsList2.Count > 0)
                {
                    SelectedZADM_M018 = (ZADM_M018)SelectedItemsList2[0];
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZADM_M018>(MCTemp, "ZADM_M018_Data", "FG_DebitCredit", "CRM", "LoadAll", 0, "");
                    MC.GoodsDetails = MCTemp.GoodsDetails;
                    GoodsDetails = new ObservableCollection<ZADM_M018>();
                    blNew = false;
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

        private void GetSelectedPlant(IList PlantList)
        {
            IList list = PlantList as IList;
            List<ADM_M003_PopUp> GetSelectedPlantTemp = list.Cast<ADM_M003_PopUp>().ToList();

            if (GetSelectedPlantTemp.Count > 0)
            {
                SelectedZADM_M018.location_Id = GetSelectedPlantTemp[0].location_Id;
                SelectedZADM_M018.PlantName = GetSelectedPlantTemp[0].LoctnNm;
            }

        }
        private void GetSelectedProduct(IList ProductList)
        {
            try
            {
                IList list = ProductList as IList;
                List<ADM_M022_ESSEM_PopUp> GetSelectedProdTemp = list.Cast<ADM_M022_ESSEM_PopUp>().ToList();

                if (GetSelectedProdTemp.Count > 0)
                {
                    SelectedZADM_M018.item_code = GetSelectedProdTemp[0].ItemCode;                
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
        private void GetSelectedINK(IList INKList)
        {
            try
            {
                IList list = INKList as IList;
                List<ZADM_M006_PopUp> GetSelectedINKTemp = list.Cast<ZADM_M006_PopUp>().ToList();

                if (GetSelectedINKTemp.Count > 0)
                {
                    SelectedZADM_M018.ink = GetSelectedINKTemp[0].ink;
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
        private void GetSelectedILD(IList ILDList)
        {
            try
            {
                IList list = ILDList as IList;
                List<ZADM_M007_PopUp> GetSelectedILDTemp = list.Cast<ZADM_M007_PopUp>().ToList();

                if (GetSelectedILDTemp.Count > 0)
                {
                    SelectedZADM_M018.ild = GetSelectedILDTemp[0].ild;                    
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
        private void GetSelectedCustomer(IList CutomerList)
        {
            try
            {
                IList list = CutomerList as IList;
                List<ADM_M028_PopUp> GetSelectedSOTemp = list.Cast<ADM_M028_PopUp>().ToList();

                if (GetSelectedSOTemp.Count > 0)
                {
                    SelectedZADM_M018.party_id = GetSelectedSOTemp[0].id;
                    SelectedZADM_M018.PartyName = GetSelectedSOTemp[0].PartyNm;
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

        private void LoadInitialData()
        {
            try
            {
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZADM_M018>(MC, "ZADM_M018_Data", "FG_DebitCredit", "CRM", "LoadAll", 0, "");
                SelectedList = MC.DebitCreditDetails;

                GoodsDetails = new ObservableCollection<ZADM_M018>();

                CollectionPlant = CollectionViewSource.GetDefaultView(MC.plant);
                CollectionPlant.Filter = new Predicate<object>(FilterPlant);              

                CollectionProduct = CollectionViewSource.GetDefaultView(MC.Product);
                CollectionProduct.Filter = new Predicate<object>(FilterProduct);               

                CollectionINK = CollectionViewSource.GetDefaultView(MC.INK);
                CollectionINK.Filter = new Predicate<object>(FilterINK);

                CollectionILD = CollectionViewSource.GetDefaultView(MC.ILD);
                CollectionILD.Filter = new Predicate<object>(FilterILD);

                CollectionCustomer = CollectionViewSource.GetDefaultView(MC.Customer);
                CollectionCustomer.Filter = new Predicate<object>(FilterCustomer);

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

        protected override void OnSaveAction(InquiryActionResult<ZADM_M018> result)
        {
            try
            {
                this.SelectedZADM_M018.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();
              
                SelectedZADM_M018.add_by = AppSessionState.UserID;
                SelectedZADM_M018.plant = Convert.ToString(AppSessionState.location_Id);
                SelectedZADM_M018.comp_code = AppSessionState.comp_code;
               

                if (blNew == true)
                {
                    //SelectedZADM_M018.XmlDataDocument_ZADM_M018 = objSer.ObjectToXML(GoodsDetails);
                    SelectedZADM_M018.XmlDataDocument_ZADM_M018 = objSer.ObjectToXML(SelectedZADM_M018);
                    SelectedZADM_M018 = repository.SaveWithReturnDomainObject<ZADM_M018>(SelectedZADM_M018, "FG_DebitCredit", "CRM");
                    SelectedList.Add(SelectedZADM_M018);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedZADM_M018.XmlDataDocument_ZADM_M018 = objSer.ObjectToXML(SelectedZADM_M018);
                    SelectedZADM_M018 = repository.UpdateWithReturnDomainObject<ZADM_M018>(SelectedZADM_M018, "FG_DebitCredit", "CRM");
                    //SelectedList.Add(SelectedZADM_M018);                     
                }
               
                _dataGridCollection.Refresh();
               
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M018> result)
        {
            blNew = true;

            GoodsDetails = new ObservableCollection<ZADM_M018>();
            GoodsDetails.Clear();

            _dataGridCollection.Refresh();
            SelectedZADM_M018 = new ZADM_M018();
        
            SelectedZADM_M018.entry_dt = DateTime.Now.Date;
            //SelectedZADM_M018_New.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M018> result)
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

                //this.SelectedZADM_M018.EndEdit();
                //ObjectSerializationService objSer = new ObjectSerializationService();               
                //SelectedZADM_M018.XmlDataDocument_ZADM_M018 = objSer.ObjectToXML(SelectedZADM_M018);
                //string xdoc = objSer.ObjectToXML(SelectedZADM_M018);
                //string response = repository.Delete(xdoc, "FG_DebitCredit", "CRM");
                //SelectedList.Remove(SelectedZADM_M018);
                //SelectedZADM_M018 = new ZADM_M018();
                //GoodsDetails = new ObservableCollection<ZADM_M018>();
                //GoodsDetails.Clear();
                //_dataGridCollection.Refresh();

                this.SelectedZADM_M018.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();
                SelectedZADM_M018.XmlDataDocument_ZADM_M018 = objSer.ObjectToXML(SelectedZADM_M018);
                string xdoc = objSer.ObjectToXML(SelectedZADM_M018);
                string response = repository.Delete(SelectedZADM_M018.id, "FG_DebitCredit", "CRM");
                SelectedList.Remove(SelectedZADM_M018);
                SelectedZADM_M018 = new ZADM_M018();
                GoodsDetails = new ObservableCollection<ZADM_M018>();
                GoodsDetails.Clear();
                _dataGridCollection.Refresh();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M018> result)
        {
            SelectedZADM_M018.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M018> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M018> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M018 = SelectedZADM_M018;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M018> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M018 = SelectedZADM_M018;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M018> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M018 = SelectedZADM_M018;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M018> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For Plant
        private void FilterCollectionPlant()
        {
            if (_CollectionPlant != null)
            {
                _CollectionPlant.Refresh();
            }
        }
        public string FilterStringPlant
        {
            get { return _filterStringPlant; }
            set
            {
                _filterStringPlant = value;
                RaisePropertyChanged("FilterStringPlant");
                FilterCollectionPlant();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Product
        private void FilterCollectionProduct()
        {
            if (_CollectionProduct != null)
            {
                _CollectionProduct.Refresh();
            }
        }
        public string FilterStringProduct
        {
            get { return _filterStringProduct; }
            set
            {
                _filterStringProduct = value;
                RaisePropertyChanged("FilterStringProduct");
                FilterCollectionProduct();
            }
        }
        public bool FilterProduct(object obj)
        {
            var data = obj as ADM_M022_ESSEM_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProduct))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringProduct.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For INK
        private void FilterCollectionINK()
        {
            if (_CollectionINK != null)
            {
                _CollectionINK.Refresh();
            }
        }
        public string FilterStringINK
        {
            get { return _filterStringINK; }
            set
            {
                _filterStringINK = value;
                RaisePropertyChanged("FilterStringINK");
                FilterCollectionINK();
            }
        }
        public bool FilterINK(object obj)
        {
            var data = obj as ZADM_M006_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringINK))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterStringINK.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For ILD
        private void FilterCollectionILD()
        {
            if (_CollectionILD != null)
            {
                _CollectionILD.Refresh();
            }
        }
        public string FilterStringILD
        {
            get { return _filterStringILD; }
            set
            {
                _filterStringILD = value;
                RaisePropertyChanged("FilterStringILD");
                FilterCollectionILD();
            }
        }
        public bool FilterILD(object obj)
        {
            var data = obj as ZADM_M007_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterStringILD.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Customer
        private void FilterCollectionCustomer()
        {
            if (_CollectionCustomer != null)
            {
                _CollectionCustomer.Refresh();
            }
        }
        public string FilterStringCustomer
        {
            get { return _filterStringCustomer; }
            set
            {
                _filterStringCustomer = value;
                RaisePropertyChanged("FilterStringCustomer");
                FilterCollectionCustomer();
            }
        }
        public bool FilterCustomer(object obj)
        {
            var data = obj as ADM_M028_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCustomer))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringCustomer.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region "Filter for Back Content Datagrid"
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
            var data = obj as ZADM_M018;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.entry_dt != null && data.entry_dt.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.entry_no != null && data.entry_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.PartyName != null && data.PartyName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
