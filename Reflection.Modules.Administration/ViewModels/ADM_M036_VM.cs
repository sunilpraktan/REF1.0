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
    public class ADM_M036_VM : WorkspaceViewModel<ADM_M036>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M036> repository = new WebServiceRepository<ADM_M036>();
        WebServiceRepository<ObservableCollection<ADM_M036>> repository_aDM_M036 = new WebServiceRepository<ObservableCollection<ADM_M036>>();

        WebServiceRepository<MultipleContext_ADM_M036> repository_M = new WebServiceRepository<MultipleContext_ADM_M036>();
        MultipleContext_ADM_M036 MC = new MultipleContext_ADM_M036();
        ObjectSerializationService objSer = new ObjectSerializationService();
        private string _filterStringItm;
        private string _filterStringloc;

        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M036.HasErrors;
        }
        public RelayCommand<IList> SelectionChangedCommandItem
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandloc
        {
            get;
            private set;
        }
        public RelayCommand SelectionChangedCommandLoc
        {
            get;
            private set;
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
        private ADM_M036 _SelectedADM_M036;
        public ADM_M036 SelectedADM_M036
        {
            get
            {
                this.ErrorExist = _SelectedADM_M036.HasErrors;
                return _SelectedADM_M036;
            }
            set
            {
                if (_SelectedADM_M036 != value)
                {
                    _SelectedADM_M036 = value;
                    RaisePropertyChanged("SelectedADM_M036");
                    value.BeginEdit();
                }
            }
        }

        ObservableCollection<ADM_M036> _SelectedList = new ObservableCollection<ADM_M036>();
        public ObservableCollection<ADM_M036> SelectedList
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

        List<ADM_M003_popup1> _SelectedLocationList = new List<ADM_M003_popup1>();
        public List<ADM_M003_popup1> SelectedLocationList
        {
            get { return _SelectedLocationList; }
            set
            {
                if (_SelectedLocationList != value)
                {
                    _SelectedLocationList = value;

                    RaisePropertyChanged("SelectedLocationList ");
                }
            }
        }
        ObservableCollection<ADM_M036> _SelectedItemList = new ObservableCollection<ADM_M036>();
        public ObservableCollection<ADM_M036> SelectedItemList
        {
            get { return _SelectedItemList; }
            set
            {
                if (_SelectedItemList != value)
                {
                    _SelectedItemList = value;

                    RaisePropertyChanged("SelectedItemList");
                }
            }
        }
        private ICollectionView _ItemListCollection;
        public ICollectionView ItemListCollection
        {
            get { return _ItemListCollection; }
            set { _ItemListCollection = value; RaisePropertyChanged("ItemListCollection"); }
        }
        private ICollectionView _locCollection;
        public ICollectionView locCollection
        {
            get { return _locCollection; }
            set { _locCollection = value; RaisePropertyChanged("locCollection"); }
        }


        //public event PropertyChangedEventHandler PropertyChanged;
        //private void RaisePropertyChanged(string propertyname)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        //    }
        //}
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand CommandLoadLocationItem
        {
            get;
            private set;
        }
        public ADM_M036_VM(string ts_code) : base()
        {
            ADM_M036.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new ObservableCollection<ADM_M036>();
            SelectedADM_M036 = new ADM_M036();
            SelectedLocationList = new List<ADM_M003_popup1>();
            SelectedADM_M036.ValidateAsync().Wait();
            SelectionChangedCommandItem = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }
                  GetSelectedItem(items);
              });
            SelectionChangedCommandloc = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedlocation(items);
            });
            SelectionChangedCommandLoc = new RelayCommand(() => GetSelectedLoc(), () => true);
            CommandLoadLocationItem = new RelayCommand(() => GetSelectedLocationItem(), () => true);
            LoadInitialData();
        }
        private void GetSelectedLoc()
        {
            SelectedList = new ObservableCollection<ADM_M036>();
        }
        private void GetSelectedLocationItem()
        {
            ADM_M036 aDM_M036 = new ADM_M036();
            //SelectedList = repository_aDM_M036.GetDataWithReturnDomainObject<ObservableCollection<ADM_M036>>(SelectedList, "ADM_M036_Data", "AllocationMaster", "Administration", "LoadOnParameter", SelectedADM_M036.location_id, "");
            aDM_M036 = repository.GetDataWithReturnDomainObject<ADM_M036>(SelectedADM_M036, "ADM_M036_Data", "AllocationMaster", "Administration", "LoadOnParameter", SelectedADM_M036.location_id, "");
            SelectedList = (ObservableCollection<ADM_M036>)objSer.XMLToObject(aDM_M036.XmlDataDocument, SelectedList);
            blNew = false;
        }
        private void LoadInitialData()
        {
            try
            {
                MC = repository_M.GetDataWithReturnDomainObject<MultipleContext_ADM_M036>(MC, "ADM_M036_Data", "AllocationMaster", "Administration", "", 0, "");
                //SelectedLocationList = MC.location_master;
                ItemListCollection = CollectionViewSource.GetDefaultView(MC.item_master);
                ItemListCollection.Filter = new Predicate<object>(FilterItm);
                locCollection = CollectionViewSource.GetDefaultView(MC.location_master);
                locCollection.Filter = new Predicate<object>(Filterloc);
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
        private void GetSelectedItem(IList ItmList)
        {
            IList list = ItmList as IList;
            List<ADM_M022_PP_1> SelectedItmDetailsTemp = list.Cast<ADM_M022_PP_1>().ToList();
            if (SelectedItmDetailsTemp.Count > 0 && dgSelectedIndex != -1)
            {
                var q = SelectedList.Where(X => X.item_code == SelectedItmDetailsTemp[0].SrNo).FirstOrDefault();
                int x = SelectedList.IndexOf(SelectedList.Where(X => X.item_code == SelectedItmDetailsTemp[0].SrNo).FirstOrDefault());

                if (q == null && SelectedItmDetailsTemp[0].Select == true && SelectedList.Count == dgSelectedIndex)
                {
                    SelectedList.Add(new ADM_M036() { item_code = SelectedItmDetailsTemp[0].SrNo, item_name = SelectedItmDetailsTemp[0].ItemName });//, so_id = SelectedItmDetailsTemp[0].po_id                                       
                }
                else if (SelectedItmDetailsTemp[0].Select == false && q != null && SelectedList[x].id == 0)//&& SelectedList[x] == null
                {
                    if (x >= 0)
                    {
                        SelectedList.RemoveAt(x);
                    }
                }
                else if (SelectedItmDetailsTemp[0].Select == true && q == null) // && r != null && r >= 0)
                {
                    SelectedList[dgSelectedIndex].item_code = SelectedItmDetailsTemp[0].SrNo;
                    SelectedList[dgSelectedIndex].item_name = SelectedItmDetailsTemp[0].ItemName;
                }
            }
        }
        private void GetSelectedlocation(IList ItmList)
        {
            IList list = ItmList as IList;
            List<ADM_M003_popup1> SelectedItmDetailsTemp = list.Cast<ADM_M003_popup1>().ToList();
            if (SelectedItmDetailsTemp.Count > 0)
            {
                SelectedADM_M036.location_id = SelectedItmDetailsTemp[0].Location_Id;
                SelectedADM_M036.location_name = SelectedItmDetailsTemp[0].LoctnNm;
                SelectedList = new ObservableCollection<ADM_M036>();
            }
        }

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M036> result)
        {
            try
            {
                this.SelectedADM_M036.EndEdit();
                SelectedADM_M036.add_by = AppSessionState.UserID.ToString();
                SelectedADM_M036.XmlDataDocument = objSer.ObjectToXML(SelectedList);
                if (blNew == true)
                {
                    SelectedADM_M036 = repository.SaveWithReturnDomainObject<ADM_M036>(SelectedADM_M036, "AllocationMaster", "Administration");
                    SelectedList = (ObservableCollection<ADM_M036>)objSer.XMLToObject(SelectedADM_M036.XmlDataDocument, SelectedList);
                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedADM_M036 = repository.UpdateWithReturnDomainObject<ADM_M036>(SelectedADM_M036, "AllocationMaster", "Administration");
                    SelectedList = (ObservableCollection<ADM_M036>)objSer.XMLToObject(SelectedADM_M036.XmlDataDocument, SelectedList);
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M036> result)
        {
            blNew = true;
            foreach (var listItem in MC.item_master.ToList())
                listItem.Select = false;
            SelectedADM_M036 = new ADM_M036();
            SelectedList = new ObservableCollection<ADM_M036>();
            SelectedADM_M036.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M036> result)
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
                SelectedADM_M036.CancelEdit();
                string response = repository.Delete(SelectedADM_M036.location_id, "AllocationMaster", "Administration");
                SelectedList.Remove(SelectedADM_M036);
                SelectedADM_M036 = new ADM_M036();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M036> result)
        {
            SelectedADM_M036.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M036> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M036> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M036 = SelectedADM_M036;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M036> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M036 = SelectedADM_M036;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M036> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M036 = SelectedADM_M036;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M036> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M036> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M036> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M036> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M036> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region FilterMethods   
        private void FilterCollection1()
        {
            if (_ItemListCollection != null)
            {
                _ItemListCollection.Refresh();
            }
        }
        public string FilterStringItm
        {
            get { return _filterStringItm; }
            set
            {
                _filterStringItm = value;
                RaisePropertyChanged("FilterStringItm");
                FilterCollection1();
            }
        }
        public bool FilterItm(object obj)
        {
            var data = obj as ADM_M022_PP_1;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItm))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().Contains(_filterStringItm.ToLower())) ||
                            data.ItemName.ToString().ToLower().Contains(_filterStringItm.ToLower());
                }
                return true;
            }
            return false;
        }
        private void FilterCollectionloc()
        {
            if (_locCollection != null)
            {
                _locCollection.Refresh();
            }
        }
        public string FilterStringloc
        {
            get { return _filterStringloc; }
            set
            {
                _filterStringloc = value;
                RaisePropertyChanged("FilterStringloc");
                FilterCollectionloc();
            }
        }
        public bool Filterloc(object obj)
        {
            var data = obj as ADM_M003_popup1;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringloc))
                {
                    return (data.Location_Id != null && data.Location_Id.ToString().Contains(_filterStringloc.ToLower())) ||
                            data.LoctnNm.ToString().ToLower().Contains(_filterStringloc.ToLower());
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
