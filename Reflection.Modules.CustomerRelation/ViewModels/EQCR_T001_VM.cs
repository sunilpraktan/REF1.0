using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.QMS;

namespace Reflection.Modules.Quality.ViewModels
{
    public class EQCR_T001_VM : WorkspaceViewModel<EQCR_T001_A>
    {
        bool blNew = true;
        WebServiceRepository<MultipleContext_EQCR> repositoryM = new WebServiceRepository<MultipleContext_EQCR>();
        WebServiceRepository<EQCR_T001_A> repository = new WebServiceRepository<EQCR_T001_A>();
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
        private int _dgSelectedIndex1;
        public int dgSelectedIndex1
        {
            get
            {
                return _dgSelectedIndex1;
            }
            set
            {
                if (_dgSelectedIndex1 != value)
                {
                    _dgSelectedIndex1 = value;
                    RaisePropertyChanged("dgSelectedIndex1");
                }
            }
        }
        private EQCR_T001_A _SelectedEQCR_T001;
        public EQCR_T001_A SelectedEQCR_T001
        {
            get
            {
                //this.ErrorExist = _SelectedEPR_T001.HasErrors;
                return _SelectedEQCR_T001;
            }
            set
            {
                if (_SelectedEQCR_T001 != value)
                {
                    _SelectedEQCR_T001 = value;
                    //this.ErrorExist = _SelectedEPR_T001.HasErrors;
                    RaisePropertyChanged("SelectedEQCR_T001");
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<EQCR_T001_B> _dgdetail_B = new ObservableCollection<EQCR_T001_B>();
        public ObservableCollection<EQCR_T001_B> dgdetail_B
        {
            get
            { return _dgdetail_B; }
            set
            {
                if (_dgdetail_B != value)
                {
                    _dgdetail_B = value;

                    RaisePropertyChanged("dgdetail_B");
                }
            }
        }
        private ObservableCollection<EQCR_T001_C> _dgdetail_C = new ObservableCollection<EQCR_T001_C>();
        public ObservableCollection<EQCR_T001_C> dgdetail_C
        {
            get
            { return _dgdetail_C; }
            set
            {
                if (_dgdetail_C != value)
                {
                    _dgdetail_C = value;

                    RaisePropertyChanged("dgdetail_C");
                }
            }
        }
        private ObservableCollection<EQCR_T001_A> _SelectedList;
        public ObservableCollection<EQCR_T001_A> SelectedList
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

        MultipleContext_EQCR _MC_EQCR_T001_A = new MultipleContext_EQCR();
        public MultipleContext_EQCR MC_EQCR_T001_A
        {
            get
            {
                return _MC_EQCR_T001_A;
            }
            set
            {
                if (_MC_EQCR_T001_A != value)
                {
                    _MC_EQCR_T001_A = value;
                    RaisePropertyChanged("MC_EQCR_T001_A");
                }
            }

        }        
        public EQCR_T001_VM()
            : base()
        {
            SelectedEQCR_T001 = new EQCR_T001_A();
            dgdetail_B = new ObservableCollection<EQCR_T001_B>();
            dgdetail_C = new ObservableCollection<EQCR_T001_C>();
            repositoryM = new WebServiceRepository<MultipleContext_EQCR>();
            MC_EQCR_T001_A = new MultipleContext_EQCR();

            SelectedCommand_supplier = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_supplier(items); });
            SelectedCommand_material = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_material(items); });
            SelectedCommand_UOM = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_UOM(items); });
            SelectedCommand_defect = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_defect(items); });
            SelectedCommand_smple_det = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_smple_det(items); });
            SelectedCommand_item = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_item(items); });
            SelectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } getSelected_BackContent(items); });

            LoadInitialData();
            SelectedEQCR_T001.doc_date = DateTime.Now;
            SelectedEQCR_T001.user_source1 = AppSessionState.UserSource1;
            SelectedEQCR_T001.user_source2 = AppSessionState.UserSource2;
            SelectedEQCR_T001.userid = AppSessionState.UserID;
            SelectedEQCR_T001.client = AppSessionState.client;

        }   

        #region . Uesr Defined Functions.
        private void LoadInitialData()
        {
            try
            {
                string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString();
                MC_EQCR_T001_A = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EQCR>(MC_EQCR_T001_A, "EQCR_T001_A_Data", "QCR", "QMS", "LoadAll", 1, company);//1 for party type only suppliers
                SelectedList = MC_EQCR_T001_A.masterList;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                supplier_Collection = CollectionViewSource.GetDefaultView(MC_EQCR_T001_A.SupplierList);
                //supplier_Collection.Filter = new Predicate<object>(Filtersupplier);

                UOM_Collection = CollectionViewSource.GetDefaultView(MC_EQCR_T001_A.uomList);
                //UOM_Collection.Filter = new Predicate<object>(FilterUOM);

                defect_Collection = CollectionViewSource.GetDefaultView(MC_EQCR_T001_A.defectList);
                //defect_Collection.Filter = new Predicate<object>(Filterdefect);

                item_Collection = CollectionViewSource.GetDefaultView(MC_EQCR_T001_A.itemList);
                //item_Collection.Filter = new Predicate<object>(Filteritem);

                smple_det_Collection = CollectionViewSource.GetDefaultView(MC_EQCR_T001_A.sample_DetailsList);
                //smple_det_Collection.Filter = new Predicate<object>(Filtersmple_det);
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
        private void getSelected_BackContent(IList items)
        {
            try
            {
                IList list = items as IList;

                List<EQCR_T001_A> SelectedSOList = list.Cast<EQCR_T001_A>().ToList();

                if (SelectedSOList.Count > 0)
                {
                    SelectedEQCR_T001 = (EQCR_T001_A)SelectedSOList[0];
                    MC_EQCR_T001_A = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EQCR>(MC_EQCR_T001_A, "EQCR_T001_A_Data", "QCR", "QMS", "LoadDetail", SelectedEQCR_T001.id,"");
                    if (SelectedEQCR_T001 != null)
                    {
                        dgdetail_B = MC_EQCR_T001_A.details_B_List;
                        dgdetail_C = MC_EQCR_T001_A.detail_C_List;
                        blNew = false;
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
            }
        }  
        private void getSelected_UOM(IList items)
        {
            try
            {
                IList list = items as IList;
                List<ADM_M038_B_PopUp> GetSelectedPlantTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

                if (GetSelectedPlantTemp.Count > 0)
                {
                    SelectedEQCR_T001.unit = GetSelectedPlantTemp[0].id;
                    SelectedEQCR_T001.unit_nm = GetSelectedPlantTemp[0].unit_name;
                }
            }
            catch { }
        }

        private void getSelected_material(IList items)
            {
            try
            {
                IList list = items as IList;
                List<ADM_M021_PopUp> GetSelectedPlantTemp = list.Cast<ADM_M021_PopUp>().ToList();

                if (GetSelectedPlantTemp.Count > 0)
                {
                    //SelectedEQCR_T001.wire_mat = GetSelectedPlantTemp[0].id;
                    //SelectedEQCR_T001.wire = GetSelectedPlantTemp[0].MateName;
                }
            }
            catch { }
        }

        private void getSelected_supplier(IList items)
        {
            try
            {
                IList list = items as IList;
                List<ADM_M028_PopUp> GetSelectedPlantTemp = list.Cast<ADM_M028_PopUp>().ToList();

                if (GetSelectedPlantTemp.Count > 0)
                {
                    SelectedEQCR_T001.supplier_id = GetSelectedPlantTemp[0].id;
                    SelectedEQCR_T001.supplier_nm = GetSelectedPlantTemp[0].PartyNm;
                }
            }
            catch { }
        }

        private void getSelected_item(IList items)
        {
            try
            {
                IList list = items as IList;
                List<ADM_M022_ESSEM_PopUp> GetSelectedPlantTemp = list.Cast<ADM_M022_ESSEM_PopUp>().ToList();

                if (GetSelectedPlantTemp.Count > 0)
                {
                    SelectedEQCR_T001.item_code = GetSelectedPlantTemp[0].ItemCode;
                    SelectedEQCR_T001.item_nm = GetSelectedPlantTemp[0].ItemName;
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

        private void getSelected_defect(IList items)
        {           
            try
            {
                if (dgSelectedIndex != -1 && items.Count > 0)
                {
                    IList list = items as IList;
                    List<ZADM_M016_PopUp> SelectedItemsDetailsTemp = list.Cast<ZADM_M016_PopUp>().ToList();
                    if (SelectedItemsDetailsTemp.Count > 0)
                    {
                        if (dgdetail_B != null)
                        {
                            var q = dgdetail_B.Where(X => X.defect == SelectedItemsDetailsTemp[0].id).FirstOrDefault();
                            int x = dgdetail_B.IndexOf(dgdetail_B.Where(X => X.defect == SelectedItemsDetailsTemp[0].id).FirstOrDefault());

                            if (q==null  &&  dgdetail_B.Count == dgSelectedIndex)
                            {
                                dgdetail_B.Add(new EQCR_T001_B()
                                {
                                    defect = SelectedItemsDetailsTemp[0].id,defect_nm = SelectedItemsDetailsTemp[0].dfctdsc,
                                    comp_code = AppSessionState.comp_code,location_Id = AppSessionState.location_Id
                                });                                
                            }
                            else if (SelectedItemsDetailsTemp[0].Select == false && q != null && dgdetail_B[x].id == 0)//&& SO_Dtails[x].id == 0
                            {
                                if (x >= 0)
                                {
                                    dgdetail_B.RemoveAt(x);
                                }
                            }
                            else if (SelectedItemsDetailsTemp[0].Select == true) // && r != null && r >= 0)
                            {
                                dgdetail_B[dgSelectedIndex].defect = SelectedItemsDetailsTemp[0].id;
                                dgdetail_B[dgSelectedIndex].defect_nm = SelectedItemsDetailsTemp[0].dfctdsc;
                                dgdetail_B[dgSelectedIndex].comp_code  = AppSessionState.comp_code;
                                dgdetail_B[dgSelectedIndex].location_Id = AppSessionState.location_Id;                                
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
            }
        }

        private void getSelected_smple_det(IList items)
        {
            try
            {
                if (dgSelectedIndex1 != -1 && items.Count > 0)
                {
                    IList list = items as IList;
                    List<ADM_M021_PopUp> SelectedItemsDetailsTemp = list.Cast<ADM_M021_PopUp>().ToList();
                    if (SelectedItemsDetailsTemp.Count > 0)
                    {
                        if (dgdetail_C != null)
                        {
                            var q = dgdetail_C.Where(X => X.item == SelectedItemsDetailsTemp[0].id).FirstOrDefault();
                            int x = dgdetail_C.IndexOf(dgdetail_C.Where(X => X.item == SelectedItemsDetailsTemp[0].id).FirstOrDefault());

                            if (q == null && dgdetail_C.Count == dgSelectedIndex1)
                            {
                                dgdetail_C.Add(new EQCR_T001_C()
                                {
                                    item = SelectedItemsDetailsTemp[0].id,
                                    item_nm = SelectedItemsDetailsTemp[0].MateCode,
                                    comp_code = AppSessionState.comp_code,
                                    location_Id = AppSessionState.location_Id
                                });
                            }
                            else if (SelectedItemsDetailsTemp[0].Select == false && q != null && dgdetail_C[x].id == 0)//&& SO_Dtails[x].id == 0
                            {
                                if (x >= 0)
                                {
                                    dgdetail_C.RemoveAt(x);
                                }
                            }
                            else if (SelectedItemsDetailsTemp[0].Select == true) // && r != null && r >= 0)
                            {
                                dgdetail_C[dgSelectedIndex1].item = SelectedItemsDetailsTemp[0].id;
                                dgdetail_C[dgSelectedIndex1].item_nm = SelectedItemsDetailsTemp[0].MateCode;
                                dgdetail_C[dgSelectedIndex1].comp_code = AppSessionState.comp_code;
                                dgdetail_C[dgSelectedIndex1].location_Id = AppSessionState.location_Id;
                            }
                            else 
                            {
                                try
                                {
                                    MC_EQCR_T001_A.defectList.Where(t => t.id == dgdetail_C[dgSelectedIndex - 1].item).ToList().ForEach(t => t.Select = false);
                                }
                                catch
                                {

                                }
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
            }
        }
        #endregion       

        

        #region . Supplier  .
        private ICollectionView _supplier_Collection;
        public ICollectionView supplier_Collection
        {
            get { return _supplier_Collection; }
            set
            {
                _supplier_Collection = value;
                RaisePropertyChanged("supplier_Collection");
            }
        }
        public RelayCommand<IList> SelectedCommand_supplier
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        private string _filterString_supplier;
        public string FilterString_supplier
        {
            get { return _filterString_supplier; }
            set
            {
                _filterString_supplier = value;
                RaisePropertyChanged("FilterString_supplier");
                FilterCollectionsupplier();
            }
        }
        private void FilterCollectionsupplier()
        {
            if (_supplier_Collection != null)
            {
                _supplier_Collection.Refresh();
            }
        }
        public bool Filtersupplier(object obj)
        {
            var data = obj as ADM_M028_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_supplier))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_supplier.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . material  .
        private ICollectionView _material_Collection;
        public ICollectionView material_Collection
        {
            get { return _material_Collection; }
            set
            {
                _material_Collection = value;
                RaisePropertyChanged("material_Collection");
            }
        }
        public RelayCommand<IList> SelectedCommand_material
        {
            get;
            private set;
        }

        private string _filterString_material;
        public string FilterString_material
        {
            get { return _filterString_material; }
            set
            {
                _filterString_material = value;
                RaisePropertyChanged("FilterString_material");
                FilterCollectionmaterial();
            }
        }
        private void FilterCollectionmaterial()
        {
            if (_material_Collection != null)
            {
                _material_Collection.Refresh();
            }
        }
        public bool Filtermaterial(object obj)
        {
            var data = obj as ADM_M021_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_material))
                {
                    return (data.MateName != null && data.MateName.ToString().ToLower().Contains(_filterString_material.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . UOM  .
        private ICollectionView _UOM_Collection;
        public ICollectionView UOM_Collection
        {
            get { return _UOM_Collection; }
            set
            {
                _UOM_Collection = value;
                RaisePropertyChanged("UOM_Collection");
            }
        }
        public RelayCommand<IList> SelectedCommand_UOM
        {
            get;
            private set;
        }

        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollectionUOM();
            }
        }
        private void FilterCollectionUOM()
        {
            if (_UOM_Collection != null)
            {
                _UOM_Collection.Refresh();
            }
        }
        public bool FilterUOM(object obj)
        {
            var data = obj as ADM_M038_B_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_abbrv != null && data.unit_abbrv.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . defect  .

        private ICollectionView _defect_Collection;
        public ICollectionView defect_Collection
        {
            get { return _defect_Collection; }
            set
            {
                _defect_Collection = value;
                RaisePropertyChanged("defect_Collection");
            }
        }
        public RelayCommand<IList> SelectedCommand_defect
        {
            get;
            private set;
        }

        private string _filterString_defect;
        public string FilterString_defect
        {
            get { return _filterString_defect; }
            set
            {
                _filterString_defect = value;
                RaisePropertyChanged("FilterString_defect");
                FilterCollectiondefect();
            }
        }
        private void FilterCollectiondefect()
        {
            if (_defect_Collection != null)
            {
                _defect_Collection.Refresh();
            }
        }
        public bool Filterdefect(object obj)
        {
            var data = obj as ZADM_M016_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_defect))
                {
                    return (data.dfctdsc != null && data.dfctdsc.ToString().ToLower().Contains(_filterString_defect.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . item  .

        private ICollectionView _item_Collection;
        public ICollectionView item_Collection
        {
            get { return _item_Collection; }
            set
            {
                _item_Collection = value;
                RaisePropertyChanged("item_Collection");
            }
        }
        public RelayCommand<IList> SelectedCommand_item
        {
            get;
            private set;
        }

        private string _filterString_item;
        public string FilterString_item
        {
            get { return _filterString_item; }
            set
            {
                _filterString_item = value;
                RaisePropertyChanged("FilterString_item");
                FilterCollectionitem();
            }
        }
        private void FilterCollectionitem()
        {
            if (_item_Collection != null)
            {
                _item_Collection.Refresh();
            }
        }
        public bool Filteritem(object obj)
        {
            var data = obj as ADM_M022_ESSEM_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_item.ToLower())||
                            data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_item.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion	

        #region . smple_det  .
        private ICollectionView _smple_det_Collection;
        public ICollectionView smple_det_Collection
        {
            get { return _smple_det_Collection; }
            set
            {
                _smple_det_Collection = value;
                RaisePropertyChanged("smple_det_Collection");
            }
        }
        public RelayCommand<IList> SelectedCommand_smple_det
        {
            get;
            private set;
        }

        private string _filterString_smple_det;
        public string FilterString_smple_det
        {
            get { return _filterString_smple_det; }
            set
            {
                _filterString_smple_det = value;
                RaisePropertyChanged("FilterString_smple_det");
                FilterCollectionsmple_det();
            }
        }
        private void FilterCollectionsmple_det()
        {
            if (_smple_det_Collection != null)
            {
                _smple_det_Collection.Refresh();
            }
        }
        public bool Filtersmple_det(object obj)
        {
            var data = obj as ADM_M028_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_smple_det))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_smple_det.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion	

        #region . DataGridCollection .
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private string _filterString;
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
            var data = obj as EQCR_T001_A;
            if (data != null)
            {
                //if (!string.IsNullOrEmpty(_filterString))
                //{
                //    return (data.id != null && data.id.ToString().ToLower().Contains(_filterString.ToLower())) ||
                //        (data.cat_date != null && data.cat_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                //        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString.ToLower()));
                //}
                return true;
            }
            return false;
        }

        #endregion

        #region · Command Actions ·

        //private bool ValidationShift()
        //{
        //    try
        //    {
        //for (int i = 0; i < GoodsDetails.Count; i++)
        //{
        //    if (GoodsDetails[i].shift == null)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format("Field 'Shift' is required.", this.Title);
        //        showMessageService.ShowMessage();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //foreach (EPR_T001 item in GoodsDetails)
        //{
        //    if (item.shift == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        protected override void OnSaveAction(InquiryActionResult<EQCR_T001_A> result)
            {
            try
            {
                this.SelectedEQCR_T001.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();

                if (dgdetail_B.Count() > 0)
                {
                    SelectedEQCR_T001.add_by = AppSessionState.UserID;
                    SelectedEQCR_T001.doc_type = "QC";
                    SelectedEQCR_T001.location_Id = AppSessionState.location_Id;
                    SelectedEQCR_T001.comp_code = AppSessionState.comp_code;
                    
                    SelectedEQCR_T001.XmlDataDocument_EQCR_T001_B = objSer.ObjectToXML(dgdetail_B);
                    SelectedEQCR_T001.XmlDataDocument_EQCR_T001_C = objSer.ObjectToXML(dgdetail_C);
                    if (blNew == true)  
                    {                       
                        SelectedEQCR_T001 = repository.SaveWithReturnDomainObject<EQCR_T001_A>(SelectedEQCR_T001, "QCR", "QMS");
                        SelectedList.Add(SelectedEQCR_T001);
                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        SelectedEQCR_T001 = repository.UpdateWithReturnDomainObject<EQCR_T001_A>(SelectedEQCR_T001, "QCR", "QMS");                        
                    }

                    dgdetail_B = (ObservableCollection<EQCR_T001_B>)new ObjectSerializationService().XMLToObject(SelectedEQCR_T001.XmlDataDocument_EQCR_T001_B, dgdetail_B);
                    dgdetail_C = (ObservableCollection<EQCR_T001_C>)new ObjectSerializationService().XMLToObject(SelectedEQCR_T001.XmlDataDocument_EQCR_T001_C, dgdetail_C);
                    _dataGridCollection.Refresh();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Atleast One Record", this.Title);
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
        protected override void OnCreateAction(InquiryActionResult<EQCR_T001_A> result)
        {
            blNew = true;
            foreach (var listItem in MC_EQCR_T001_A.sample_DetailsList.ToList())
                listItem.Select = false;
            foreach (var listItem in MC_EQCR_T001_A.defectList.ToList())
                listItem.Select = false;
            dgdetail_B = new ObservableCollection<EQCR_T001_B>();
            dgdetail_C = new ObservableCollection<EQCR_T001_C>();
            SelectedEQCR_T001=new EQCR_T001_A();
            SelectedEQCR_T001 = new EQCR_T001_A();
            _dataGridCollection.Refresh();
            SelectedEQCR_T001.doc_type = "QCR";
            SelectedEQCR_T001.doc_date = DateTime.Now;
            SelectedEQCR_T001.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<EQCR_T001_A> result)
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

                this.SelectedEQCR_T001.EndEdit();
                //ObjectSerializationService objSer = new ObjectSerializationService();
                //SelectedEQCR_T001.XmlDataDocument_EQCR_T001_B = objSer.ObjectToXML(dgdetail_B);
                //SelectedEQCR_T001.XmlDataDocument_EQCR_T001_C = objSer.ObjectToXML(dgdetail_C);
                //string xdoc = objSer.ObjectToXML(SelectedEQCR_T001);
                string response = repository.Delete(SelectedEQCR_T001.id, "QCR", "QMS");
                SelectedList = new ObservableCollection<EQCR_T001_A>();
                SelectedList.Add(SelectedEQCR_T001);
                dgdetail_B = new ObservableCollection<EQCR_T001_B>();
                dgdetail_C = new ObservableCollection<EQCR_T001_C>();
                _dataGridCollection.Refresh();
                SelectedEQCR_T001.doc_date = DateTime.Now.Date;
                foreach (var listItem in MC_EQCR_T001_A.sample_DetailsList.ToList())
                    listItem.Select = false;
                foreach (var listItem in MC_EQCR_T001_A.defectList.ToList())
                    listItem.Select = false;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<EQCR_T001_A> result)
        {
            //SelectedEPR_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<EQCR_T001_A> result)
        {
            //SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<EQCR_T001_A> result)
        {
            //SelectedList = SelectedList;
            //SelectedEPR_T001 = SelectedEPR_T001;
        }
        protected override void OnHelpAction(InquiryActionResult<EQCR_T001_A> result)
        {
            //SelectedList = SelectedList;
            //SelectedEPR_T001 = SelectedEPR_T001;
        }
        protected override void OnPrintAction(InquiryActionResult<EQCR_T001_A> result)
        {
            try
            {
                if (SelectedEQCR_T001.id > 0)
                {
                    string Request = "LoadDocumentDetailsFromBackFlip" + "!@" + SelectedEQCR_T001.doc_no;
                    
                    MC_EQCR_T001_A = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EQCR>(MC_EQCR_T001_A,Request, "QCR", "QMS", "LoadDocumentDetailsFromBackFlip", SelectedEQCR_T001.id, "");

                    object[] objDS = new object[3];
                    objDS[0] = MC_EQCR_T001_A.masterList;
                    objDS[1] = MC_EQCR_T001_A.details_B_List;
                    objDS[2] = MC_EQCR_T001_A.detail_C_List;

                    object[] obj_DS = new object[3];
                    obj_DS[0] = "DS_QCR";
                    obj_DS[1] = "DS_QCR_B";
                    obj_DS[2] = "DS_QCR_C";



                    ReportManager ReportManager = new ReportingServices.ReportManager();
                    ReportManager.DisplayReport(objDS, "DS_QCR", "\\QMS\\QCR.rdlc");
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
        //protected override void OnExportAction(InquiryActionResult<EQCR_T001_A> result)
        //{
        //    try
        //    {
        //        List<EQCR_T001_A> Export_List = new List<EQCR_T001_A>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            EQCR_T001_A Data = o as EQCR_T001_A;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<EQCR_T001_A, List<EQCR_T001_A>> export = new ExportToExcel<EQCR_T001_A, List<EQCR_T001_A>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<EQCR_T001_A>)view.SourceCollection;

        //        export.GenerateReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }

        //}
        protected override void OnDocumentAction()
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<EQCR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EQCR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EQCR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EQCR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EQCR_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
