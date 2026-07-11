using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.ComponentModel;
using Reflection.ReportingServices;

namespace Reflection.Modules.Production.ViewModels
{
    public class ESO_T001_VM : WorkspaceViewModel<ESO_T001>
    {
        #region . Declaration . 
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool blNew = true;
        WebServiceRepository<ESO_T001> repository = new WebServiceRepository<ESO_T001>();
        WebServiceRepository<MultipleContext_ESO_T001> repositoryM = new WebServiceRepository<MultipleContext_ESO_T001>();
        MultipleContext_ESO_T001 MCTemp = new MultipleContext_ESO_T001();

        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringMachine;
        private string _filterStringUOM;
        private string _filterStringDefect;
        private string _filterStringSorting;

        private int _dgSelectedIndex;
        private Dictionary<string, object> _items;
        private Dictionary<string, object> _selectedItems;

        private List<ESO_T001_rpt> _dgReportMaster;
        public List<ESO_T001_rpt> dgReportMaster
        {
            get { return _dgReportMaster; }
            set
            {
                if (_dgReportMaster != value)
                {
                    _dgReportMaster = value;


                    RaisePropertychanged("dgReportMaster");

                }
            }
        }
        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertychanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        }
        private ICollectionView _LoctnCollection;


        private ICollectionView _MachineCollection;//machine
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertychanged("MachineCollection");
            }
        }

        private ICollectionView _UOMCollection;//UOM
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set
            {
                _UOMCollection = value;
                RaisePropertychanged("UOMCollection");
            }
        }

        private ICollectionView _DefectCollection;//Defect
        public ICollectionView DefectCollection
        {
            get { return _DefectCollection; }
            set
            {
                _DefectCollection = value;
                RaisePropertychanged("DefectCollection");
            }
        }

        private ICollectionView _SortingCollection;//ILD
        public ICollectionView SortingCollection
        {
            get { return _SortingCollection; }
            set
            {
                _SortingCollection = value;
                RaisePropertychanged("SortingCollection");
            }
        }
        private ICollectionView _BatchCollection;
        public ICollectionView BatchCollection
        {
            get { return _BatchCollection; }
            set
            {
                _BatchCollection = value;
                RaisePropertychanged("BatchCollection");
            }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set
            {
                _ShiftCollection = value;
                RaisePropertychanged("ShiftCollection");
            }
        }

        private ICollectionView _ShiftInchargeCollection;
        public ICollectionView ShiftInchargeCollection
        {
            get { return _ShiftInchargeCollection; }
            set
            {
                _ShiftInchargeCollection = value;
                RaisePropertychanged("ShiftInchargeCollection");
            }
        }

        private ICollectionView _OperatorCollection;
        public ICollectionView OperatorCollection
        {
            get { return _OperatorCollection; }
            set
            {
                _OperatorCollection = value;
                RaisePropertychanged("OperatorCollection");
            }
        }
        private ICollectionView _BatchCollectiondg;
        public ICollectionView BatchCollectiondg
        {
            get { return _BatchCollectiondg; }
            set
            {
                _BatchCollectiondg = value;
                RaisePropertychanged("BatchCollectiondg");
            }
        }

        private ICollectionView _OperatorCollectiondg;
        public ICollectionView OperatorCollectiondg
        {
            get { return _OperatorCollectiondg; }
            set
            {
                _OperatorCollectiondg = value;
                RaisePropertychanged("OperatorCollectiondg");
            }
        }





        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    RaisePropertychanged("SelectedTabIndex");

                    if (SelectedTabIndex == 2)
                    {
                        //LoadSelectedTab();
                    }

                }
            }
        }
        #endregion

        #region RelayCommand

        public RelayCommand<IList> SelectionChangedCommandMachines //machine
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandUOM //UOM
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandDefect//ILD
        {
            get;
            private set;
        }

        public RelayCommand<IList> CellChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<Boolean> ManualSortingChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<Boolean> AutomaticSortingChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandGetBack
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandOperatordg
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBatchdg
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandOperator
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandShiftIncharge
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBatch
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandShift
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region ESO_T001
        private List<ESO_T001> _SelectedList;
        public List<ESO_T001> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertychanged("SelectedList");

                    //}
                }
            }
        }
        private ESO_T001 _SelectedESO_T001;
        public ESO_T001 SelectedESO_T001
        {
            get
            {
                this.ErrorExist = _SelectedESO_T001.HasErrors;
                return _SelectedESO_T001;
            }
            set
            {
                if (_SelectedESO_T001 != value)
                {
                    _SelectedESO_T001 = value;
                    this.ErrorExist = _SelectedESO_T001.HasErrors;
                    RaisePropertychanged("SelectedESO_T001");
                    value.BeginEdit();
                }
            }
        }
        private static ObservableCollection<ESO_T001> _SortingDetails = new ObservableCollection<ESO_T001>();
        public ObservableCollection<ESO_T001> SortingDetails
        {
            get { return _SortingDetails; }
            set
            {
                if (_SortingDetails != value)
                {
                    _SortingDetails = value;
                    RaisePropertychanged("SortingDetails");
                }
            }
        }
        #endregion

        #region ZADM_M013_P
        private List<ZADM_M013_P> _SelectedListOfMachines;
        public List<ZADM_M013_P> SelectedListOfMachines
        {
            get { return _SelectedListOfMachines; }
            set
            {
                if (_SelectedListOfMachines != value)
                {
                    _SelectedListOfMachines = value;
                    RaisePropertychanged("SelectedListOfMachines");
                }
            }
        }

        private ObservableCollection<ZADM_M013_P> _MachineList;
        public ObservableCollection<ZADM_M013_P> MachineList
        {
            get { return _MachineList; }
            set
            {
                _MachineList = value;
                RaisePropertychanged("MachineList");
            }
        }

        private ZADM_M013_P _SelectedMachineList;
        public ZADM_M013_P SelectedMachineList
        {
            get { return _SelectedMachineList; }
            set
            {
                if (_SelectedMachineList != value)
                {
                    _SelectedMachineList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertychanged("SelectedMachineList");
                    //}
                }
            }
        }
        #endregion

        #region ADM_M038_B_P
        private List<ADM_M038_B_P> _SelectedListOfUOM;
        public List<ADM_M038_B_P> SelectedListOfUOM
        {
            get { return _SelectedListOfUOM; }
            set
            {
                if (_SelectedListOfUOM != value)
                {
                    _SelectedListOfUOM = value;
                    RaisePropertychanged("SelectedListOfUOM");
                }
            }
        }
        private ObservableCollection<ADM_M038_B_P> _UOMList;
        public ObservableCollection<ADM_M038_B_P> UOMList
        {
            get { return _UOMList; }
            set
            {
                _UOMList = value;
                RaisePropertychanged("UOMList");
            }
        }

        private ADM_M038_B_P _SelectedUOMList;
        public ADM_M038_B_P SelectedUOMList
        {
            get { return _SelectedUOMList; }
            set
            {
                if (_SelectedUOMList != value)
                {
                    _SelectedUOMList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertychanged("SelectedUOMList");
                    //}
                }
            }
        }
        #endregion

        #region ZADM_M016_P
        private List<ZADM_M016_P> _SelectedListOfDefects;
        public List<ZADM_M016_P> SelectedListOfDefects
        {
            get { return _SelectedListOfDefects; }
            set
            {
                if (_SelectedListOfDefects != value)
                {
                    _SelectedListOfDefects = value;
                    RaisePropertychanged("SelectedListOfDefects");
                }
            }
        }

        private ObservableCollection<ZADM_M016_P> _DefectList;
        public ObservableCollection<ZADM_M016_P> DefectList
        {
            get { return _DefectList; }
            set
            {
                _DefectList = value;
                RaisePropertychanged("DefectList");
            }
        }

        private ZADM_M016_P _SelectedDefectList;
        public ZADM_M016_P SelectedDefectList
        {
            get { return _SelectedDefectList; }
            set
            {
                if (_SelectedDefectList != value)
                {
                    _SelectedDefectList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertychanged("SelectedDefectList");
                    //}
                }
            }
        }
        #endregion

        #region ESO_T001_P
        private List<ESO_T001_P> _SelectedListOfSort;
        public List<ESO_T001_P> SelectedListOfSort
        {
            get { return _SelectedListOfSort; }
            set
            {
                if (_SelectedListOfSort != value)
                {
                    _SelectedListOfSort = value;
                    RaisePropertychanged("SelectedListOfSort");
                }
            }
        }

        private ObservableCollection<ESO_T001_P> _SortList;
        public ObservableCollection<ESO_T001_P> SortList
        {
            get { return _SortList; }
            set
            {
                _SortList = value;
                RaisePropertychanged("SortList");
            }
        }

        private ESO_T001_P _SelectedSortList;
        public ESO_T001_P SelectedSortList
        {
            get { return _SelectedSortList; }
            set
            {
                if (_SelectedSortList != value)
                {
                    _SelectedSortList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertychanged("SelectedSortList");
                    //}
                }
            }
        }
        #endregion

        public Dictionary<string, object> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    RaisePropertychanged("Items");
                }
            }
        }
        public Dictionary<string, object> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                NotifyPropertyChanged("SelectedItems");
            }
        }
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
                    RaisePropertychanged("dgSelectedIndex");
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
                    RaisePropertychanged("dgSelectedIndex1");
                }
            }
        }

        MultipleContext_ESO_T001 _MC = new MultipleContext_ESO_T001();
        public MultipleContext_ESO_T001 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertychanged("MC");
                }
            }
        }
        #endregion

        public ESO_T001_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;

            SelectedList = new List<ESO_T001>();
            SelectedESO_T001 = new ESO_T001();
            SortingDetails = new ObservableCollection<ESO_T001>();
            SelectedESO_T001.ValidateAsync().Wait();
            MC = new MultipleContext_ESO_T001();
            ManualSortingChangedCommand = new RelayCommand<bool>(ManualSortingChangeUpdate);
            AutomaticSortingChangedCommand = new RelayCommand<bool>(AutomaticSortingChangeUpdate);
            SelectedESO_T001.client = AppSessionState.client;
            SelectedESO_T001.user_source1 = AppSessionState.UserSource1;
            SelectedESO_T001.user_source2 = AppSessionState.UserSource2;
            SelectedESO_T001.userid = AppSessionState.UserID;
            LoadInitialData();
            Items = new Dictionary<string, object>();
            SelectedItems = new Dictionary<string, object>();
            Items.Clear();
        }
        public ESO_T001_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<ESO_T001>();
            SelectedESO_T001 = new ESO_T001();
            SortingDetails = new ObservableCollection<ESO_T001>();
            SelectedESO_T001.ValidateAsync().Wait();
            MC = new MultipleContext_ESO_T001();
            ManualSortingChangedCommand = new RelayCommand<bool>(ManualSortingChangeUpdate);
            AutomaticSortingChangedCommand = new RelayCommand<bool>(AutomaticSortingChangeUpdate);
            SelectedESO_T001.client = AppSessionState.client;
            SelectedESO_T001.user_source1 = AppSessionState.UserSource1;
            SelectedESO_T001.user_source2 = AppSessionState.UserSource2;
            SelectedESO_T001.userid = AppSessionState.UserID;
            LoadInitialData();
            Items = new Dictionary<string, object>();
            SelectedItems = new Dictionary<string, object>();
            Items.Clear();
        }

        #region . User Defined Function .
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ESO_T001> tSelectedItemsList = list.Cast<ESO_T001>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedESO_T001 = (ESO_T001)tSelectedItemsList[0];
                blNew = false;
                SelectedESO_T001.ts_code = ts_code_vm;
            }
        }
        private void GetSelectedMachine(IList machineList)
        {
            IList list = machineList as IList;
            List<ZADM_M013_P> Selectedmachinelist = list.Cast<ZADM_M013_P>().ToList();
            if (Selectedmachinelist.Count > 0)
            {
                SelectedESO_T001.machinecode = Selectedmachinelist[0].machinecode;
                if (SelectedESO_T001.machinecode != null && SelectedESO_T001.doc_cat != null && SelectedESO_T001.prod_dt != null && SelectedESO_T001.machinecode != "" && SelectedESO_T001.doc_cat != "")
                {
                    string request = "";
                    request = SelectedESO_T001.machinecode + "!@" + SelectedESO_T001.doc_cat + "!@" + AppSessionState.location_Id.ToString() + "!@" + Convert.ToDateTime(SelectedESO_T001.prod_dt).ToString("MM/dd/yyyy");
                    MultipleContext_ESO_T001 temp_MC = new MultipleContext_ESO_T001();
                    //temp_MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ESO_T001>(temp_MC, "ESO_T001_Data", "Sorting", "Production", "LoadMachineDetail", 0, "", "", AppSessionState.comp_code, AppSessionState.location_Id, AppSessionState.UserID, SelectedESO_T001.machinecode, Convert.ToDateTime(SelectedESO_T001.prod_dt).ToString("MM/dd/yyyy"), SelectedESO_T001.defects, SelectedESO_T001.EmpId, SelectedESO_T001.doc_cat);
                    MC.Sorting = temp_MC.Sorting;
                    SelectedList = MC.Sorting;
                    SortingDetails = new ObservableCollection<ESO_T001>();
                    SortingDetails.Clear();
                    SortingDetails = new ObservableCollection<ESO_T001>(SelectedList);

                    var TempUnit_Id = (from o in MC.UOMList
                                       where o.unit_name == "PICs"
                                       select o).ToList();

                    //SelectedESO_T001.unit_code = TempUnit_Id[0].unit_code;

                    for (int C = 0; C < SortingDetails.Count - 1; C++)
                    {
                        if (MC.Sorting.Count > 0)
                        {
                            SortingDetails[C].Col = "Chnaged";

                            blNew = false;
                            cal();
                        }
                        else
                        {
                            SortingDetails[C].Col = "NotChnaged";
                            blNew = true;
                            foreach (var o in MC.DefectList)
                                o.Select = false;
                        }
                    }
                    if (SortingDetails.Count() == 0)
                    {
                        foreach (var o in MC.DefectList)
                            o.Select = false;
                        //SelectedESO_T001.unit_code = "";
                        //SelectedESO_T001.machinecode = "";
                        SelectedESO_T001.Total = 0;
                    }
                }
            }
        }
        private void GetSelectedUomDetails(IList UomList)
        {
            try
            {
                IList list = UomList as IList;
                List<ADM_M038_B_P> SelectedUomDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();

                if (SelectedUomDetailsTemp.Count > 0)
                {
                    {
                        SelectedESO_T001.unit_code = SelectedUomDetailsTemp[0].unit_code;

                    }
                    if (SortingDetails.Count() > 0)
                    {
                        foreach (var o in SortingDetails)
                            o.unit_code = SelectedESO_T001.unit_code;
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
        private void GetSelectedDefectDetails(IList defectList)
        {
            try
            {
                if (dgSelectedIndex != -1 && defectList.Count > 0)
                {
                    IList list = defectList as IList;
                    List<ZADM_M016_P> SelectedDefectDetailsTemp = list.Cast<ZADM_M016_P>().ToList();
                    if (SelectedDefectDetailsTemp.Count > 0)
                    {
                        var q = SortingDetails.Where(X => X.defects == SelectedDefectDetailsTemp[0].dfctdsc).FirstOrDefault();
                        int x = SortingDetails.IndexOf(SortingDetails.Where(X => X.defects == SelectedDefectDetailsTemp[0].dfctdsc).FirstOrDefault());

                        if (q == null && SelectedDefectDetailsTemp[0].Select == true && SortingDetails.Count == dgSelectedIndex)
                        {
                            SortingDetails.Add(new ESO_T001()
                            {
                                defects = SelectedDefectDetailsTemp[0].dfctdsc,
                                rej_qty_1 = 0,
                                rej_qty_2 = 0,
                                rej_qty_3 = 0,
                                tot_rej = 0,
                                unit_code = SelectedESO_T001.unit_code
                            }

                                );
                            if (SelectedESO_T001.ButtonBIsChecked == true)
                            {
                                SortingDetails[dgSelectedIndex - 1].sort_by = "JAM";
                            }
                            else
                            {
                                SortingDetails[dgSelectedIndex - 1].sort_by = SelectedESO_T001.sort_by;
                            }
                        }
                        else if (SelectedDefectDetailsTemp[0].Select == false && q != null && SortingDetails[x].id == 0)
                        {
                            if (x >= 0)
                            {
                                var childCascadeDelete = SelectedDefectDetailsTemp;
                                foreach (var itm in childCascadeDelete.ToList())
                                {
                                    var item = SortingDetails.FirstOrDefault(X => X.defects == itm.dfctdsc);
                                    if (item != null)
                                    {
                                        SortingDetails.Remove(item);
                                    }
                                }
                                //SortingDetails.RemoveAt(x);
                            }
                        }
                        else if (SelectedDefectDetailsTemp[0].Select == true && q == null && (dgSelectedIndex < SortingDetails.Count || SortingDetails.Count == 0)) // && r != null && r >= 0)
                        {
                            SortingDetails[dgSelectedIndex].defects = SelectedDefectDetailsTemp[0].dfctdsc;
                            SortingDetails[dgSelectedIndex].unit_code = SelectedESO_T001.unit_code;

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
            //--------------------------------------------------------------------
            //try
            //{
            //    if (dgSelectedIndex != -1 && defectList.Count > 0)
            //    {
            //        IList list = defectList as IList;
            //        List<ZADM_M016_P> SelectedDefectDetailsTemp = list.Cast<ZADM_M016_P>().ToList();
            //        if (SelectedDefectDetailsTemp.Count > 0)
            //        {

            //            var q = SortingDetails.Where(X => X.defects == SelectedDefectDetailsTemp[0].dfctdsc).FirstOrDefault();
            //            int x = SortingDetails.IndexOf(SortingDetails.Where(X => X.defects == SelectedDefectDetailsTemp[0].dfctdsc).FirstOrDefault());

            //            if (q != null)
            //            {

            //            }
            //            else
            //            {
            //                if (SortingDetails.Count == dgSelectedIndex && SelectedDefectDetailsTemp[0].Select == true)
            //                {

            //                    SelectedDefectList = (ZADM_M016_P)SelectedDefectDetailsTemp[0];
            //                    SortingDetails.Add(new ESO_T001()
            //                    {
            //                        defects = SelectedDefectDetailsTemp[0].dfctdsc,
            //                        rej_qty_1 = 0,
            //                        rej_qty_2 = 0,
            //                        tot_rej = 0
            //                    });

            //                    //SelectedDefectDetailsTemp.Where(l => l.dfctdsc == SelectedDefectDetailsTemp[0].dfctdsc).ToList().ForEach(i => i.Description = (""));
            //                }
            //                else if (SelectedDefectDetailsTemp[0].Select == false)//&& SortingDetails[x].id == 0
            //                {
            //                    if (x >= 0)
            //                    {
            //                        SortingDetails.RemoveAt(x);
            //                    }
            //                }
            //                else if (SelectedDefectDetailsTemp[0].Select == true) // && r != null && r >= 0)
            //                {

            //                    SortingDetails[dgSelectedIndex].defects = SelectedDefectDetailsTemp[0].dfctdsc;

            //                }
            //                if (SelectedESO_T001.ButtonBIsChecked == true)
            //                {
            //                    SortingDetails[dgSelectedIndex - 1].sort_by = "JAM";
            //                }
            //                else
            //                {
            //                    SortingDetails[dgSelectedIndex - 1].sort_by = SelectedESO_T001.sort_by;
            //                }

            //                try
            //                {
            //                    MC.DefectList.Where(t => t.dfctdsc == SortingDetails[dgSelectedIndex - 1].defects).ToList().ForEach(t => t.Select = false);
            //                }
            //                catch
            //                {

            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();
            //}




        }
        private void CellChangeUpdate(IList DataList)
        {
            IList list = DataList as IList;
            if (list == null) return;
            List<ESO_T001> SelectedItemsDetailsTemp = list.Cast<ESO_T001>().ToList();

            if (SelectedItemsDetailsTemp.Count > 0)
            {
                ESO_T001 SelectedESO_T001 = (ESO_T001)SelectedItemsDetailsTemp[0];
                {

                    if (SortingDetails[dgSelectedIndex].rej_qty_2 == 0 && SortingDetails[dgSelectedIndex].rej_qty_1 != null)
                    {
                        SortingDetails[dgSelectedIndex].rej_qty_2 = 0;
                        SelectedESO_T001.shift = "I";
                    }
                    else if (SortingDetails[dgSelectedIndex].rej_qty_1 == 0 && SortingDetails[dgSelectedIndex].rej_qty_2 != null)
                    {
                        SortingDetails[dgSelectedIndex].rej_qty_1 = 0;
                        SelectedESO_T001.shift = "II";
                    }
                    else if (SortingDetails[dgSelectedIndex].rej_qty_1 == 0 && SortingDetails[dgSelectedIndex].rej_qty_2 == 0 && SortingDetails[dgSelectedIndex].rej_qty_3 != null)
                    {
                        SortingDetails[dgSelectedIndex].rej_qty_1 = 0;
                        SortingDetails[dgSelectedIndex].rej_qty_2 = 0;
                        SelectedESO_T001.shift = "III";
                    }
                    else if (SortingDetails[dgSelectedIndex].rej_qty_1 > 0 && SortingDetails[dgSelectedIndex].rej_qty_2 > 0)
                    {
                        SelectedESO_T001.shift = "I and II";
                    }
                    SortingDetails[dgSelectedIndex].tot_rej = (SortingDetails[dgSelectedIndex].rej_qty_1 + SortingDetails[dgSelectedIndex].rej_qty_2 + SortingDetails[dgSelectedIndex].rej_qty_3);
                }
            }
            cal();

        }
        private void cal()
        {
            SelectedESO_T001.Total = 0;
            for (int i = 0; i < SortingDetails.Count; i++)
            {
                if (SortingDetails[i].tot_rej == null)
                {
                    SortingDetails[i].tot_rej = 0;
                }
                SelectedESO_T001.Total = SelectedESO_T001.Total + SortingDetails[i].tot_rej;

            }
        }
        private void ManualSortingChangeUpdate(bool check)
        {
            if (SelectedESO_T001.ButtonAIsChecked == true)
            {
                SelectedESO_T001.doc_cat = "MS";

                if (MC.DefectList.Count > 0) //DefectCollection
                {
                    SortingDetails = new ObservableCollection<ESO_T001>();
                    SortingDetails.Clear();

                    var DefectList1 = (from o in MC.DefectList
                                       where o.scope == "Manual"
                                       select o).ToList();
                    DefectCollection = CollectionViewSource.GetDefaultView(DefectList1);
                    DefectCollection.Filter = new Predicate<object>(DefectFilter);

                }
            }
        }
        private void AutomaticSortingChangeUpdate(bool check)
        {
            if (SelectedESO_T001.ButtonBIsChecked == true)
            {
                SelectedESO_T001.doc_cat = "AS";
                //SortingDetails[dgSelectedIndex].sort_by = "JAM";
                try
                {
                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001>();
                        SortingDetails.Clear();

                        var DefectList1 = (from o in MC.DefectList
                                           where o.scope == "Automatic"
                                           select o).ToList();
                        DefectCollection = CollectionViewSource.GetDefaultView(DefectList1);
                        DefectCollection.Filter = new Predicate<object>(DefectFilter);

                        //----------------------------


                        SortingDetails.Add(new ESO_T001()
                        {
                            defects = DefectList1[0].dfctdsc,
                            rej_qty_1 = 0,
                            rej_qty_2 = 0,
                            rej_qty_3 = 0,
                            tot_rej = 0

                        });
                    }
                }
                catch
                { }
            }
        }
        private void GetBack(IList SOList)
        {
            try
            {
                IList list = SOList as IList;

                List<ESO_T001_P> SelectedSOList = list.Cast<ESO_T001_P>().ToList();

                if (SelectedSOList.Count > 0)
                {
                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ESO_T001>(MCTemp, "ESO_T001_Data", "Sorting", "Production", "LoadDetail", 0, "", "", AppSessionState.comp_code, AppSessionState.location_Id, AppSessionState.UserID, SelectedSOList[0].machinecode, SelectedSOList[0].prod_dt.ToString("MM/dd/yyyy"), "", "", "");
                    if (SelectedESO_T001 != null)
                    {
                        MC.Sorting = MCTemp.Sorting;
                        SelectedList = MC.Sorting;

                        if (MCTemp.Sorting[0].doc_cat == "AS")
                        {
                            SelectedESO_T001.ButtonBIsChecked = true;
                            SelectedESO_T001.ButtonAIsChecked = false;
                        }
                        else if (MCTemp.Sorting[0].doc_cat == "MS")
                        {
                            SelectedESO_T001.ButtonBIsChecked = false;
                            SelectedESO_T001.ButtonAIsChecked = true;
                        }
                        SelectedESO_T001.prod_dt = MCTemp.Sorting[0].prod_dt;
                        SelectedESO_T001.entry_dt = MCTemp.Sorting[0].entry_dt;
                        SelectedESO_T001.machinecode = MCTemp.Sorting[0].machinecode;
                        SelectedESO_T001.unit_code = MCTemp.Sorting[0].unit_code;
                        SelectedESO_T001.active = MCTemp.Sorting[0].active;
                        SelectedESO_T001.shift_incharge = MCTemp.Sorting[0].shift_incharge;
                        SelectedESO_T001.ShiftInchargeName = MCTemp.Sorting[0].ShiftInchargeName;
                        SelectedESO_T001.shift = MCTemp.Sorting[0].shift;
                        SelectedESO_T001.EmpId = MCTemp.Sorting[0].EmpId;
                        SelectedESO_T001.OperatorName = MCTemp.Sorting[0].OperatorName;
                        SelectedESO_T001.ItemCode = MCTemp.Sorting[0].ItemCode;
                        SelectedESO_T001.batch_no = MCTemp.Sorting[0].batch_no;
                        decimal sum = 0;

                        for (int i = 0; i < MCTemp.Sorting.Count; i++)
                        {
                            sum = Convert.ToInt32(sum + MCTemp.Sorting[i].tot_rej);
                        }
                        SelectedESO_T001.Total = sum;
                        SortingDetails = new ObservableCollection<ESO_T001>(SelectedList);
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


        //private void InsertOperatordg(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ADM_M024_P> tSelectedItemsList = list.Cast<ADM_M024_P>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedESO_T001.EmpId = tSelectedItemsList[0].EmpId;
        //        SelectedESO_T001.Operator = tSelectedItemsList[0].EmpName;

        //    }
        //}
        //private void InsertBatchdg(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<PPC_T001_P> tSelectedItemsList = list.Cast<PPC_T001_P>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedESO_T001.batch_no = tSelectedItemsList[0].batch_no;



        //    }
        //}

        private void InsertOperator(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M024_P> tSelectedItemsList = list.Cast<ADM_M024_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedESO_T001.EmpId = tSelectedItemsList[0].EmpId;
                SelectedESO_T001.OperatorName = tSelectedItemsList[0].EmpName;

            }
        }
        private void InsertShiftIncharge(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M024_P> tSelectedItemsList = list.Cast<ADM_M024_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedESO_T001.shift_incharge = tSelectedItemsList[0].EmpId;
                SelectedESO_T001.ShiftInchargeName = tSelectedItemsList[0].EmpName;
            }
        }
        private void InsertBatch(IList DataList)
        {
            IList list = DataList as IList;
            List<PPC_T001_P> tSelectedItemsList = list.Cast<PPC_T001_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedESO_T001.batch_no = tSelectedItemsList[0].batch_no;
                SelectedESO_T001.EmpId = tSelectedItemsList[0].m_operator;
                SelectedESO_T001.OperatorName = tSelectedItemsList[0].OperatorName;
                SelectedESO_T001.shift_incharge = tSelectedItemsList[0].shift_incharge;
                SelectedESO_T001.ShiftInchargeName = tSelectedItemsList[0].ShiftInchargeName;
                SelectedESO_T001.ItemCode = tSelectedItemsList[0].ItemCode;
                SelectedESO_T001.shift = tSelectedItemsList[0].shift1;
                SelectedESO_T001.ref_doc_no = tSelectedItemsList[0].doc_no;
                SelectedESO_T001.machinecode = tSelectedItemsList[0].machinecode;
                SelectedESO_T001.machine_id = tSelectedItemsList[0].machine_id;


            }
        }
        private void InsertShift(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M042_P> tSelectedItemsList = list.Cast<ADM_M042_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedESO_T001.shift = tSelectedItemsList[0].shift;

            }
        }

        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //GetSelectedList();
                    
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
                    Request = SelectedESO_T001.client + "!@" + SelectedESO_T001.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void LoadInitialData()
        {
            try
            {
                SelectedESO_T001.doc_cat = "SR";
                SelectedESO_T001.doc_type = "SR";
                SelectedESO_T001.t_status = "002";
                SelectedESO_T001.active = true;

                //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ESO_T001>(MC, "ESO_T001_Data", "Sorting", "Production", "LoadAll", 0, "", "", AppSessionState.comp_code, AppSessionState.location_Id, AppSessionState.UserID, SelectedESO_T001.machinecode, "", "", "", "SR");
                SelectedListOfSort = MC.SortList;
                #region Command Initialisation
                SelectionChangedCommandMachines = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedMachine(items);
                });


                SelectionChangedCommandUOM = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedUomDetails(items);
                });

                SelectionChangedCommandDefect = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedDefectDetails(items);
                });
                CellChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    CellChangeUpdate(items);
                });
                SelectionChangedCommandGetBack = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }
                   GetBack(items);
               });

                //SelectionChangedCommandOperatordg=new RelayCommand<IList>(
                // items =>
                // {
                //     if (items == null)
                //     {
                //         return;
                //     }
                //     InsertOperatordg(items);
                // });

                //SelectionChangedCommandBatchdg = new RelayCommand<IList>(
                //items =>
                //{
                //    if (items == null)
                //    {
                //        return;
                //    }
                //    InsertBatchdg(items);
                //});

                SelectionChangedCommandOperator = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    InsertOperator(items);
                });

                SelectionChangedCommandShiftIncharge = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    InsertShiftIncharge(items);
                });

                SelectionChangedCommandBatch = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    InsertBatch(items);
                });

                SelectionChangedCommandShift = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    InsertShift(items);
                });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineCodeList);
                MachineCollection.Filter = new Predicate<object>(MachineFilter);

                UOMCollection = CollectionViewSource.GetDefaultView(MC.UOMList);
                UOMCollection.Filter = new Predicate<object>(UOMFilter);

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectList);
                DefectCollection.Filter = new Predicate<object>(DefectFilter);

                DataGridCollection = CollectionViewSource.GetDefaultView(MC.SortList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                BatchCollection = CollectionViewSource.GetDefaultView(MC.BatchNo);
                BatchCollection.Filter = new Predicate<object>(FilterBatchNo);

                ShiftCollection = CollectionViewSource.GetDefaultView(MC.Shift);
                ShiftCollection.Filter = new Predicate<object>(FilterShift);

                OperatorCollection = CollectionViewSource.GetDefaultView(MC.ShiftIncharge);
                OperatorCollection.Filter = new Predicate<object>(FilterOperator);

                ShiftInchargeCollection = CollectionViewSource.GetDefaultView(MC.ShiftIncharge);
                ShiftInchargeCollection.Filter = new Predicate<object>(FilterShiftIncharge);


                SelectedESO_T001.entry_dt = System.DateTime.Now;
                SelectedESO_T001.prod_dt = System.DateTime.Now;
               


                DateTime now = DateTime.Now;
                DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
                SelectedESO_T001.FrmDate = lastDayLastMonth.AddDays(-60);
                SelectedESO_T001.SortingDate = lastDayLastMonth.AddDays(-60);
                SelectedESO_T001.client = AppSessionState.client;
                SelectedESO_T001.ToDate = DateTime.Now;

                var TempUnit_Id = (from o in MC.UOMList
                                   where o.unit_name == "PICs"
                                   select o).ToList();

                SelectedESO_T001.unit_code = TempUnit_Id[0].unit_code;
                SelectedESO_T001.ButtonAIsChecked = true;

                if (SelectedESO_T001.ButtonAIsChecked == true)
                {
                    SelectedESO_T001.doc_cat = "MS";

                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001>();
                        SortingDetails.Clear();

                        var DefectList1 = (from o in MC.DefectList
                                           where o.scope == "Manual"
                                           select o).ToList();
                        DefectCollection = CollectionViewSource.GetDefaultView(DefectList1);
                        DefectCollection.Filter = new Predicate<object>(DefectFilter);

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

        #region · Command Actions ·
        private bool ValidateControls()
        {
            int cnt = 0;
            try
            {
                if (SelectedESO_T001.machinecode == null || SelectedESO_T001.machinecode == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Machine No", this.Title);
                    showMessageService.ShowMessage();
                    cnt = cnt + 1;
                }
                else if (SelectedESO_T001.unit_code == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter UOM", this.Title);
                    showMessageService.ShowMessage();
                    cnt = cnt + 1;
                }

                if (cnt == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool Validation()
        {
            try
            {

                if (SelectedESO_T001.shift == null)
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Shift", this.Title);
                    showMessageService.ShowMessage();
                    return false;

                }
                else if (SelectedESO_T001.ShiftInchargeName == null)
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Shift Incharge", this.Title);
                    showMessageService.ShowMessage();
                    return false;

                }

                //else if (SelectedESO_T001.OperatorName == null)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Enter Operator Name", this.Title);
                //    showMessageService.ShowMessage();
                //    return false;
                //}
                //else if (SelectedESO_T001.ItemCode == null)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Enter Item Code", this.Title);
                //    showMessageService.ShowMessage();
                //    return false;

                //}

                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private bool ValidateControlsDeatils()
        {
            int cnt = 0;
            try
            {
                if (SortingDetails.Count > 0)
                {
                    foreach (var item in SortingDetails)
                    {

                        if (item.defects == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter the Defect", this.Title);
                            showMessageService.ShowMessage();
                            cnt = cnt + 1;
                            break;
                        }
                        else if (item.rej_qty_1 == 0 && item.rej_qty_2 == 0 && item.rej_qty_3 == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Defected Qty Should be greater than Zero", this.Title);
                            showMessageService.ShowMessage();
                            cnt = cnt + 1;
                            break;
                        }



                    }
                    if (cnt == 0)
                    {
                        return false;

                    }
                    else
                    {
                        return true;

                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected override void OnSaveAction(InquiryActionResult<ESO_T001> result)
        {
            try
            {
                this.SelectedESO_T001.EndEdit();
                if (ValidateControls() == false)
                {
                    if (ValidateControlsDeatils() == false)
                    {
                        if (Validation() == true)
                        {
                            if (blNew == true)
                            {
                                ObjectSerializationService obj = new ObjectSerializationService();
                                SelectedESO_T001.XmlDataDocument_ESO_T001 = obj.ObjectToXML(SortingDetails);
                                SelectedESO_T001.add_by = AppSessionState.UserID;
                                SelectedESO_T001.doc_type = "SR";
                                SelectedESO_T001.location_Id = AppSessionState.location_Id;
                                SelectedESO_T001.comp_code = AppSessionState.comp_code; // 02 nov
                                SelectedESO_T001.client = AppSessionState.client;

                                SelectedESO_T001 = repository.SaveWithReturnDomainObject<ESO_T001>(SelectedESO_T001, "Sorting", "Production");

                                SelectedListOfSort.Add(new ESO_T001_P()
                                {
                                    machinecode = SelectedESO_T001.machinecode,
                                    prod_dt = Convert.ToDateTime(SelectedESO_T001.prod_dt)
                                });
                                _dataGridCollection.Refresh();
                                SortingDetails = (ObservableCollection<ESO_T001>)new ObjectSerializationService().XMLToObject(SelectedESO_T001.XmlDataDocument_ESO_T001, SortingDetails);
                                cal();
                                MessageBox.Show("Record Saved Successfully");

                                blNew = false;
                            }
                            else if (blNew == false)
                            {
                                ObjectSerializationService obj = new ObjectSerializationService();
                                SelectedESO_T001.XmlDataDocument_ESO_T001 = obj.ObjectToXML(SortingDetails);
                                SelectedESO_T001.add_by = AppSessionState.UserID;
                                SelectedESO_T001.location_Id = AppSessionState.location_Id;
                                SelectedESO_T001.comp_code = AppSessionState.comp_code;
                                SelectedESO_T001 = repository.UpdateWithReturnDomainObject<ESO_T001>(SelectedESO_T001, "Sorting", "Production");
                                SortingDetails = (ObservableCollection<ESO_T001>)new ObjectSerializationService().XMLToObject(SelectedESO_T001.XmlDataDocument_ESO_T001, SortingDetails);
                                cal();
                                MessageBox.Show("Record Updated Successfully");
                            }
                            if (SelectedESO_T001.doc_cat == "MS")
                            {
                                SelectedESO_T001.ButtonAIsChecked = true;
                            }
                            else
                            {
                                SelectedESO_T001.ButtonBIsChecked = true;
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
        protected override void OnCreateAction(InquiryActionResult<ESO_T001> result)
        {
            try
            {
                blNew = true;
                SortingDetails = new ObservableCollection<ESO_T001>();
                //SortingDetails.Clear();
                SelectedESO_T001.ts_code = ts_code_vm;
                SelectedESO_T001 = new ESO_T001();
                SelectedESO_T001.ValidateAsync().Wait();
                SelectedESO_T001.entry_dt = System.DateTime.Now;
                SelectedESO_T001.prod_dt = System.DateTime.Now;
                SelectedESO_T001.ButtonAIsChecked = true;
                SelectedESO_T001.client = AppSessionState.client;
                
                var TempUnit_Id = (from o in MC.UOMList
                                   where o.unit_name == "PICs"
                                   select o).ToList();
                if (MC.UOMList.Count() > 0)
                {
                    SelectedESO_T001.unit_code = TempUnit_Id[0].unit_code;
                    SelectedESO_T001.ButtonAIsChecked = true;
                }
                foreach (var o in MC.DefectList)
                    o.Select = false;
                if (SelectedESO_T001.ButtonAIsChecked == true)
                {
                    SelectedESO_T001.doc_cat = "MS";

                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001>();
                        SortingDetails.Clear();

                        var DefectList1 = (from o in MC.DefectList
                                           where o.scope == "Manual"
                                           select o).ToList();
                        DefectCollection = CollectionViewSource.GetDefaultView(DefectList1);
                        DefectCollection.Filter = new Predicate<object>(DefectFilter);

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
        protected override void OnRemoveAction(InquiryActionResult<ESO_T001> result)
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
                SelectedESO_T001.CancelEdit();
                string response = repository.Delete(SortingDetails[dgSelectedIndex].id, "Sorting", "Production");
                SelectedList.Remove(SelectedESO_T001);
                _dataGridCollection.Refresh();
                SelectedESO_T001 = new ESO_T001();
                SortingDetails = new ObservableCollection<ESO_T001>();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ESO_T001> result)
        {
            SelectedESO_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ESO_T001> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ESO_T001> result)
        {
            SelectedList = SelectedList;
            SelectedESO_T001 = SelectedESO_T001;
        }
        protected override void OnHelpAction(InquiryActionResult<ESO_T001> result)
        {
            SelectedList = SelectedList;
            SelectedESO_T001 = SelectedESO_T001;
        }
        protected override void OnPrintAction(InquiryActionResult<ESO_T001> result)
        {

            SelectedESO_T001 = SelectedESO_T001;
            if (SelectedESO_T001.shift == null) { SelectedESO_T001.shift = "Both"; }
            if (SelectedESO_T001.Engineer == null) { SelectedESO_T001.Engineer = "ALL"; }
            if (SelectedESO_T001.machinecode == null) { SelectedESO_T001.machinecode = "ALL"; }
            if (SelectedESO_T001.defects == null) { SelectedESO_T001.defects = "ALL"; }

            string request1 = "";
            request1 = SelectedESO_T001.shift + "!@" + Convert.ToDateTime(SelectedESO_T001.SortingDate).ToString("dd/MM/yyyy") + "!@" + Convert.ToDateTime(SelectedESO_T001.FrmDate).ToString("dd/MM/yyyy") + "!@" + Convert.ToDateTime(SelectedESO_T001.ToDate).ToString("dd/MM/yyyy");

            //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ESO_T001>(MC, "ESO_T001_Data", "SortingReport", "Production", "DatewiseDefectReport", 0, request1, "", AppSessionState.comp_code, AppSessionState.location_Id, AppSessionState.UserID, SelectedESO_T001.machinecode, Convert.ToDateTime(SelectedESO_T001.prod_dt).ToString("dd/MM/yyyy"), SelectedESO_T001.defects, SelectedESO_T001.EmpId, SelectedESO_T001.doc_cat);
            dgReportMaster = MC.sorting_rpt;
            object[] objDS = new object[1];

            objDS[0] = MC.sorting_rpt;
            ReportManager ReportManager = new ReportingServices.ReportManager();
            ReportManager.DisplayReport(objDS[0], "DatewiseDefect_DS", "\\Production\\DatewiseDefectRpt.rdlc", getParametersList());

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("FrmDate", Convert.ToString(SelectedESO_T001.FrmDate));
            result.Add("ToDate", Convert.ToString(SelectedESO_T001.ToDate));
            result.Add("EntryDate", Convert.ToString(SelectedESO_T001.entry_dt));

            if (SelectedESO_T001.shift == null) { SelectedESO_T001.shift = "Both"; }
            if (SelectedESO_T001.Engineer == null) { SelectedESO_T001.Engineer = "ALL"; }
            if (SelectedESO_T001.machinecode == null) { SelectedESO_T001.machinecode = "ALL"; }
            if (SelectedESO_T001.defects == null) { SelectedESO_T001.defects = "ALL"; }

            result.Add("shift", (SelectedESO_T001.shift));
            result.Add("Engineer", (SelectedESO_T001.Engineer));
            result.Add("machine", (SelectedESO_T001.machinecode));
            result.Add("defect", (SelectedESO_T001.defects));
            return result;
        }
        //protected override void OnExportAction(InquiryActionResult<ESO_T001> result)
        //{
        //    try
        //    {
        //        List<ESO_T001> Export_List = new List<ESO_T001>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            ESO_T001 Data = o as ESO_T001;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<ESO_T001, List<ESO_T001>> export = new ExportToExcel<ESO_T001, List<ESO_T001>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<ESO_T001>)view.SourceCollection;

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
        #endregion

        #region . Filters .

        #region Filters For Machine
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertychanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For UOM
        private void FilterCollectionUOM()
        {
            if (_UOMCollection != null)
            {
                _UOMCollection.Refresh();
            }
        }
        public string FilterStringUOM
        {
            get { return _filterStringUOM; }
            set
            {
                _filterStringUOM = value;
                RaisePropertychanged("FilterStringUOM");
                FilterCollectionUOM();
            }
        }
        public bool UOMFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUOM))
                {
                    return ((data.unit_code != null) && data.unit_code.ToLower().Contains(_filterStringUOM.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Defect
        private void FilterCollectionDefect()
        {
            if (_DefectCollection != null)
            {
                _DefectCollection.Refresh();
            }
        }
        public string FilterStringDefect
        {
            get { return _filterStringDefect; }
            set
            {
                _filterStringDefect = value;
                RaisePropertychanged("FilterStringDefect");
                FilterCollectionDefect();
            }
        }
        public bool DefectFilter(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDefect))
                {
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringDefect.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region "Filter for Back Content Datagrid"
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertychanged("FilterString");
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
            var data = obj as ESO_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.prod_dt != null && data.prod_dt.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion


        #region "Filter string Batch"
        private string _FilterStringBatch;
        public string FilterStringBatch
        {
            get { return _FilterStringBatch; }
            set
            {
                _FilterStringBatch = value;
                RaisePropertychanged("FilterStringBatch");
                FilterCollectionBatch();
            }
        }
        private void FilterCollectionBatch()
        {
            if (_BatchCollection != null)
            {
                _BatchCollection.Refresh();
            }
        }
        public bool FilterBatchNo(object obj)
        {
            var data = obj as PPC_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringBatch))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.m_operator != null && data.m_operator.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift1 != null && data.shift1.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift2 != null && data.shift2.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift3 != null && data.shift3.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift_incharge != null && data.shift_incharge.ToString().ToLower().Contains(_FilterStringBatch.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region "Filter string Operator"
        private string _FilterStringOperator;
        public string FilterStringOperator
        {
            get { return _FilterStringOperator; }
            set
            {
                _FilterStringOperator = value;
                RaisePropertychanged("FilterStringOperator");
                FilterCollectionOperator();
            }
        }
        private void FilterCollectionOperator()
        {
            if (_OperatorCollection != null)
            {
                _OperatorCollection.Refresh();
            }
        }
        public bool FilterOperator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringOperator.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringOperator.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region "Filter string Shift Incharge"
        private string _FilterStringShiftIncharge;
        public string FilterStringShiftIncharge
        {
            get { return _FilterStringShiftIncharge; }
            set
            {
                _FilterStringShiftIncharge = value;
                RaisePropertychanged("FilterStringShiftIncharge");
                FilterCollectionShiftIncharge();
            }
        }
        private void FilterCollectionShiftIncharge()
        {
            if (_ShiftInchargeCollection != null)
            {
                _ShiftInchargeCollection.Refresh();
            }
        }
        public bool FilterShiftIncharge(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringShiftIncharge))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringShiftIncharge.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringShiftIncharge.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region "Filter string Shift"
        private string _FilterStringShift;
        public string FilterStringShift
        {
            get { return _FilterStringShift; }
            set
            {
                _FilterStringShift = value;
                RaisePropertychanged("FilterStringShift");
                FilterCollectionShift();
            }
        }
        private void FilterCollectionShift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public bool FilterShift(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(_FilterStringShift.ToLower()));

                }
                return true;
            }
            return false;
        }

        
        #endregion





    }
}
