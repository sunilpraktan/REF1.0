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
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;


namespace Reflection.Modules.SCM.ViewModels
{
    public class ZSCM_T001_A_VM : WorkspaceViewModel<ZSCM_T001_A>
    {
        bool blNew = true;
        WebServiceRepository<ZSCM_T001_A> repository = new WebServiceRepository<ZSCM_T001_A>();
        WebServiceRepository<MultipleContext_ZSCM_T001_A> repositoryM = new WebServiceRepository<MultipleContext_ZSCM_T001_A>();
        MultipleContext_ZSCM_T001_A MCTemp = new MultipleContext_ZSCM_T001_A();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringWireSize;
        private string _filterStringWireType;
        private string _filterStringTotLength;
        private string _filterStringMake;
        private string _filterStringMonth;
        private string _filterStringYear;
        private int _dgSelectedIndex;
        private bool FlagForDuplicate = false;

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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
        private ICollectionView _WireTypeCollection;
        public ICollectionView WireTypeCollection
        {
            get { return _WireTypeCollection; }
            set
            {
                _WireTypeCollection = value;

                RaisePropertyChanged("WireTypeCollection");
            }
        }

        private ICollectionView _TotLengthCollection;
        public ICollectionView TotLengthCollection
        {
            get { return _TotLengthCollection; }
            set
            {
                _TotLengthCollection = value;

                RaisePropertyChanged("TotLengthCollection");
            }
        }

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set
            {
                _MakeCollection = value;

                RaisePropertyChanged("MakeCollection");
            }
        }

        private ICollectionView _MonthCollection;
        public ICollectionView MonthCollection
        {
            get { return _MonthCollection; }
            set
            {
                _MonthCollection = value;

                RaisePropertyChanged("MonthCollection");
            }
        }
        private ICollectionView _YearCollection;
        public ICollectionView YearCollection
        {
            get { return _YearCollection; }
            set
            {
                _YearCollection = value;

                RaisePropertyChanged("YearCollection");
            }
        }

        #endregion

        #region StringList Variables

        private List<string> _StrListMonth;
        public List<string> StringListMonth
        {
            get { return _StrListMonth; }
            set
            {
                if (_StrListMonth != value)
                {
                    _StrListMonth = value;
                }
            }
        }

        private List<string> _StrListYear;
        public List<string> StringListYear
        {
            get { return _StrListYear; }
            set
            {
                if (_StrListYear != value)
                {
                    _StrListYear = value;
                }
            }
        }

        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandAvg_Wt_Details
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandWireSize
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandWireType
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandTotLength
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMake
        {
            get;
            private set;
        }

        public RelayCommand CopyCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMonth
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandYear
        {
            get;
            private set;
        }
        public RelayCommand CellChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand ReportCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionIDCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region ZSCM_T001_A
        private List<ZSCM_T001_A> _SelectedList;
        public List<ZSCM_T001_A> SelectedList
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

        private ZSCM_T001_A _SelectedZSCM_T001_A;
        public ZSCM_T001_A SelectedZSCM_T001_A
        {
            get
            {
                this.ErrorExist = _SelectedZSCM_T001_A.HasErrors;
                return _SelectedZSCM_T001_A;
            }
            set
            {
                if (_SelectedZSCM_T001_A != value)
                {
                    _SelectedZSCM_T001_A = value;
                    this.ErrorExist = _SelectedZSCM_T001_A.HasErrors;
                    RaisePropertyChanged("SelectedZSCM_T001_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ZSCM_T001_B
        private static ObservableCollection<ZSCM_T001_B> _Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
        public ObservableCollection<ZSCM_T001_B> Avg_Wt_Details
        {
            get { return _Avg_Wt_Details; }
            set
            {
                if (_Avg_Wt_Details != value)
                {
                    _Avg_Wt_Details = value;

                    RaisePropertyChanged("Avg_Wt_Details");
                }
            }
        }

        private static ObservableCollection<ZSCM_T001_B> _Temp_Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
        public ObservableCollection<ZSCM_T001_B> Temp_Avg_Wt_Details
        {
            get { return _Temp_Avg_Wt_Details; }
            set
            {
                if (_Temp_Avg_Wt_Details != value)
                {
                    _Temp_Avg_Wt_Details = value;

                    RaisePropertyChanged("Temp_Avg_Wt_Details");
                }
            }
        }
        public ZSCM_T001_B _SelectedZSCM_T001_B { get; private set; }
        public ZSCM_T001_B SelectedZSCM_T001_B
        {
            get { return _SelectedZSCM_T001_B; }
            set
            {
                if (_SelectedZSCM_T001_B != value)
                {
                    _SelectedZSCM_T001_B = value;
                    RaisePropertyChanged("SelectedZSCM_T001_B");
                    // value.BeginEdit();
                }
            }
        }
        private List<ZSCM_T001_B> _SelectedZSCM_T001_B_List;
        public List<ZSCM_T001_B> SelectedZSCM_T001_B_List
        {
            get
            {
                return _SelectedZSCM_T001_B_List;
            }
            set
            {
                _SelectedZSCM_T001_B_List = value;
                RaisePropertyChanged("SelectedZSCM_T001_B_List");
            }
        }

        #endregion

        #region ZADM_M003_P          

        private List<ZADM_M003_P> _SelectedWireSizeList;
        public List<ZADM_M003_P> SelectedWireSizeList
        {
            get { return _SelectedWireSizeList; }
            set
            {
                if (_SelectedWireSizeList != value)
                {
                    _SelectedWireSizeList = value;
                    RaisePropertyChanged("SelectedWireSizeList");

                }
            }
        }
        #endregion

        #region ZADM_M004_P
        private List<ZADM_M004_P> _SelectedListOfWireTypeDtls;
        public List<ZADM_M004_P> SelectedListOfWireTypeDtls
        {
            get { return _SelectedListOfWireTypeDtls; }
            set
            {
                if (_SelectedListOfWireTypeDtls != value)
                {
                    _SelectedListOfWireTypeDtls = value;
                    RaisePropertyChanged("SelectedListOfWireTypeDtls");
                }
            }
        }

        #endregion

        #region ZADM_M008_P     
        private List<ZADM_M008_P> _SelectedTotLengthList;
        public List<ZADM_M008_P> SelectedTotLengthList
        {
            get { return _SelectedTotLengthList; }
            set
            {
                if (_SelectedTotLengthList != value)
                {
                    _SelectedTotLengthList = value;
                    RaisePropertyChanged("SelectedTotLengthList");

                }
            }
        }
        #endregion

        #region ADM_M0032_P       

        private List<ADM_M0032_P> _SelectedMakeList;
        public List<ADM_M0032_P> SelectedMakeList
        {
            get { return _SelectedMakeList; }
            set
            {
                if (_SelectedMakeList != value)
                {
                    _SelectedMakeList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertyChanged("SelectedMakeList");
                    //}
                }
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
        MultipleContext_ZSCM_T001_A _MC = new MultipleContext_ZSCM_T001_A();
        public MultipleContext_ZSCM_T001_A MC
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

        public ZSCM_T001_A_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SelectedList = new List<ZSCM_T001_A>();
            SelectedZSCM_T001_A = new ZSCM_T001_A();
            Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            Temp_Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            SelectedWireSizeList = new List<ZADM_M003_P>();
            SelectedListOfWireTypeDtls = new List<ZADM_M004_P>();
            SelectedTotLengthList = new List<ZADM_M008_P>();
            SelectedMakeList = new List<ADM_M0032_P>();
            SelectedZSCM_T001_A.average_wt_dt = DateTime.Now;
            SelectedZSCM_T001_B = new ZSCM_T001_B();
            SelectedZSCM_T001_A.ValidateAsync().Wait();
            MC = new MultipleContext_ZSCM_T001_A();

            LoadInitialData();
        }
        public ZSCM_T001_A_VM(string ts_code, string doc_no)
           : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<ZSCM_T001_A>();
            SelectedZSCM_T001_A = new ZSCM_T001_A();
            Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            Temp_Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            SelectedWireSizeList = new List<ZADM_M003_P>();
            SelectedListOfWireTypeDtls = new List<ZADM_M004_P>();
            SelectedTotLengthList = new List<ZADM_M008_P>();
            SelectedMakeList = new List<ADM_M0032_P>();
            SelectedZSCM_T001_A.average_wt_dt = DateTime.Now;
            SelectedZSCM_T001_B = new ZSCM_T001_B();
            SelectedZSCM_T001_A.ValidateAsync().Wait();
            MC = new MultipleContext_ZSCM_T001_A();

            LoadInitialData();
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZSCM_T001_A> tSelectedItemsList = list.Cast<ZSCM_T001_A>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZSCM_T001_A = (ZSCM_T001_A)tSelectedItemsList[0];
                blNew = false;
                SelectedZSCM_T001_A.ts_code = ts_code_vm;
            }
        }
        private void GetSelectedAvg_Wt_DetailsList(IList Avg_Wt_DetailsList)
        {
            try
            {
                IList list = Avg_Wt_DetailsList as IList;

                List<ZSCM_T001_A> GetSelectedAvg_Wt_Details = list.Cast<ZSCM_T001_A>().ToList();

                if (GetSelectedAvg_Wt_Details.Count > 0)
                {
                    SelectedZSCM_T001_A = (ZSCM_T001_A)GetSelectedAvg_Wt_Details[0];
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZSCM_T001_A>(MCTemp, "ZSCM_T001_A_Data", "Average_Blank_Weight", "SCM", "LoadDetails", SelectedZSCM_T001_A.id, "");
                    if (SelectedZSCM_T001_A != null)
                    {
                        ObservableCollection<ZSCM_T001_B> result = (ObservableCollection<ZSCM_T001_B>)MCTemp.Avg_Wt_Details.Cast<ZSCM_T001_B>();
                        IEnumerable<ZSCM_T001_B> barEnumerable =
                                from data in result
                                where data.average_wt_id == SelectedZSCM_T001_A.id
                                select data;

                        Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>(barEnumerable);
                    }
                    DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
                    blNew = false;
                }
                SelectedTabControlIndex = 0;
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
        private void GetSelectedWireSizeDetails(IList WireSizeList)
        {
            //try
            //{
            //    IList list = WireSizeList as IList;
            //    List<ZADM_M003_P> SelectedWireSizeDetailsTemp = list.Cast<ZADM_M003_P>().ToList();

            //    if (SelectedWireSizeDetailsTemp.Count > 0 && dgSelectedIndex != -1)
            //    {
            //        var q = Avg_Wt_Details.Where(X => X.wire_size_id == SelectedWireSizeDetailsTemp[0].wire_size_id).FirstOrDefault();

            //        if (q != null)
            //        {
            //            if (Avg_Wt_Details.Count() > dgSelectedIndex)
            //            {
            //                Avg_Wt_Details[dgSelectedIndex].wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id;
            //                Avg_Wt_Details[dgSelectedIndex].WireDia = SelectedWireSizeDetailsTemp[0].wire_size;
            //            }
            //        }
            //        else
            //        {
            //            if (Avg_Wt_Details.Count() <= dgSelectedIndex)
            //            {
            //                Avg_Wt_Details.Add(new ZSCM_T001_B() { wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id, WireDia = SelectedWireSizeDetailsTemp[0].wire_size });
            //            }
            //            else
            //            {
            //                Avg_Wt_Details[dgSelectedIndex].wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id;
            //                Avg_Wt_Details[dgSelectedIndex].WireDia = SelectedWireSizeDetailsTemp[0].wire_size;
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

            try
            {
                IList list = WireSizeList as IList;
                List<ZADM_M003_P> SelectedWireSizeDetailsTemp = list.Cast<ZADM_M003_P>().ToList();

                if (SelectedWireSizeDetailsTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = Avg_Wt_Details.Where(X => X.WireDia == (SelectedWireSizeDetailsTemp[0].wire_size)).FirstOrDefault();

                    if (q != null)
                    {
                        if (Avg_Wt_Details.Count() > dgSelectedIndex)
                        {
                            //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                            try
                            {
                                if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                       //|| (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                {
                                    Avg_Wt_Details[dgSelectedIndex].WireDia = 0;
                                    Avg_Wt_Details[dgSelectedIndex].wire_size_id = null;
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                        && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                        //&& (Avg_Wt_Details[dgSelectedIndex].WireDia != 0) 
                                        && (Avg_Wt_Details[dgSelectedIndex].Make != "")
                                        && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireType)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(SelectedWireSizeDetailsTemp[0].wire_size)
                                            + Avg_Wt_Details[dgSelectedIndex].Make
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireDia = (SelectedWireSizeDetailsTemp[0].wire_size);
                                            Avg_Wt_Details[dgSelectedIndex].wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id;
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireDia = 0;
                                            Avg_Wt_Details[dgSelectedIndex].wire_size_id = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireDia = (SelectedWireSizeDetailsTemp[0].wire_size);
                                        Avg_Wt_Details[dgSelectedIndex].wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id;
                                    }

                                    //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (Avg_Wt_Details.Count() <= dgSelectedIndex)
                        {
                            //Avg_Wt_Details.Add(new ZACC_T001_A() { wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType) });
                            try
                            {
                                if (Avg_Wt_Details.Count == 0)
                                {
                                    Avg_Wt_Details.Add(new ZSCM_T001_B()
                                    {
                                        WireDia = (SelectedWireSizeDetailsTemp[0].wire_size),
                                        wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id,
                                        entry_date = DateTime.Now.Date
                                    });
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                       //|| (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireDia = 0;// Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        Avg_Wt_Details[dgSelectedIndex].wire_size_id = null;
                                    }
                                    else
                                    {
                                        Avg_Wt_Details.Add(new ZSCM_T001_B()
                                        {
                                            WireDia = (SelectedWireSizeDetailsTemp[0].wire_size),
                                            wire_size_id = SelectedWireSizeDetailsTemp[0].wire_size_id,
                                            entry_date = DateTime.Now
                                        });
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (dgSelectedIndex > 0)
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                       //|| (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireDia = 0;// Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        Avg_Wt_Details[dgSelectedIndex].wire_size_id = null;
                                    }
                                    else
                                    {
                                        if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                       && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                       //&& (Avg_Wt_Details[dgSelectedIndex].WireDia != 0) 
                                       && (Avg_Wt_Details[dgSelectedIndex].Make != "")
                                       && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                        {

                                            string ChkItem = "";
                                            ChkItem = Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireType)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(SelectedWireSizeDetailsTemp[0].wire_size)
                                            + Avg_Wt_Details[dgSelectedIndex].Make
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].WireDia = (SelectedWireSizeDetailsTemp[0].wire_size);
                                                Avg_Wt_Details[dgSelectedIndex].wire_size_id = (SelectedWireSizeDetailsTemp[0].wire_size_id);
                                            }
                                            else
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].WireDia = 0;
                                                Avg_Wt_Details[dgSelectedIndex].wire_size_id = null;
                                            }
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireDia = (SelectedWireSizeDetailsTemp[0].wire_size);
                                            Avg_Wt_Details[dgSelectedIndex].wire_size_id = (SelectedWireSizeDetailsTemp[0].wire_size_id);
                                        }
                                        //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                        && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                        //&& (Avg_Wt_Details[dgSelectedIndex].WireDia != 0) 
                                        && (Avg_Wt_Details[dgSelectedIndex].Make != "")
                                        && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireType)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(SelectedWireSizeDetailsTemp[0].wire_size)
                                            + Avg_Wt_Details[dgSelectedIndex].Make
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireDia = (SelectedWireSizeDetailsTemp[0].wire_size);
                                            Avg_Wt_Details[dgSelectedIndex].wire_size_id = (SelectedWireSizeDetailsTemp[0].wire_size_id);
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireDia = 0;
                                            Avg_Wt_Details[dgSelectedIndex].wire_size_id = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireDia = (SelectedWireSizeDetailsTemp[0].wire_size);
                                        Avg_Wt_Details[dgSelectedIndex].wire_size_id = (SelectedWireSizeDetailsTemp[0].wire_size_id);
                                    }
                                    //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                }
                            }
                            catch
                            {

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

        private bool CheckDuplicate(string CheckItem)
        {
            int x = 0;
            FlagForDuplicate = false;
            int tempIndex;
            tempIndex = 0;
            foreach (var item in Avg_Wt_Details)
            {


                if (dgSelectedIndex != tempIndex)
                {
                    if (CheckItem == item.WireType + item.entry_date + item.WireDia + (string.IsNullOrWhiteSpace(item.Make) ? "" : item.Make) + item.BlankLength)
                    {
                        x = x + 1;
                        break;
                    }
                    else
                    {
                        x = 0;
                    }
                }
                tempIndex = tempIndex + 1;

            }
            if (x > 0 && x != -1)
            {
                FlagForDuplicate = true;
                MessageBox.Show("Wire_Type + Entry_Date + Wire_Size + Wire_Make +Blank_Length Combination is Already Exists");
            }
            else
            {
                FlagForDuplicate = false;
            }
            return FlagForDuplicate;
        }
        private void GetSelectedWireTypeDetails(IList WireTypeList)
        {
            //try
            //{
            //    IList list = WireTypeList as IList;
            //    List<ZADM_M004_P> SelectedWireTypeDetailsTemp = list.Cast<ZADM_M004_P>().ToList();

            //    if (SelectedWireTypeDetailsTemp.Count > 0 && dgSelectedIndex != -1)
            //    {
            //        var q = Avg_Wt_Details.Where(X => X.wire_type_id == SelectedWireTypeDetailsTemp[0].wire_type_id).FirstOrDefault();

            //        if (q != null)
            //        {
            //            if (Avg_Wt_Details.Count() > dgSelectedIndex)
            //            {
            //                Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
            //                Avg_Wt_Details[dgSelectedIndex].WireType = SelectedWireTypeDetailsTemp[0].wire_type;
            //            }
            //        }
            //        else
            //        {
            //            if (Avg_Wt_Details.Count() <= dgSelectedIndex)
            //            {
            //                Avg_Wt_Details.Add(new ZSCM_T001_B() { wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id, WireType = SelectedWireTypeDetailsTemp[0].wire_type });
            //            }
            //            else
            //            {
            //                Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
            //                Avg_Wt_Details[dgSelectedIndex].WireType = SelectedWireTypeDetailsTemp[0].wire_type;
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

            try
            {
                IList list = WireTypeList as IList;
                List<ZADM_M004_P> SelectedWireTypeDetailsTemp = list.Cast<ZADM_M004_P>().ToList();

                if (SelectedWireTypeDetailsTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = Avg_Wt_Details.Where(X => X.WireType == Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type)).FirstOrDefault();

                    if (q != null)
                    {
                        if (Avg_Wt_Details.Count() > dgSelectedIndex)
                        {
                            //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                            try
                            {
                                if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    //|| (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                {
                                    Avg_Wt_Details[dgSelectedIndex].WireType = "";
                                    Avg_Wt_Details[dgSelectedIndex].wire_type_id = null;
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null) && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0) && (Avg_Wt_Details[dgSelectedIndex].Make != "") && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                            + Avg_Wt_Details[dgSelectedIndex].Make
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type);
                                            Avg_Wt_Details[dgSelectedIndex].wire_type_id = (SelectedWireTypeDetailsTemp[0].wire_type_id);
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireType = "";
                                            Avg_Wt_Details[dgSelectedIndex].wire_type_id = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type);
                                        Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
                                    }

                                    //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (Avg_Wt_Details.Count() <= dgSelectedIndex)
                        {
                            //Avg_Wt_Details.Add(new ZACC_T001_A() { wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType) });
                            try
                            {
                                if (Avg_Wt_Details.Count == 0)
                                {
                                    Avg_Wt_Details.Add(new ZSCM_T001_B()
                                    {
                                        WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type),
                                        wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id,
                                        entry_date = DateTime.Now
                                    });
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    //|| (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireType = "";// Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        Avg_Wt_Details[dgSelectedIndex].wire_type_id = null;
                                    }
                                    else
                                    {
                                        Avg_Wt_Details.Add(new ZSCM_T001_B()
                                        {
                                            WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type),
                                            wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id,
                                            entry_date = DateTime.Now
                                        });
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (dgSelectedIndex > 0)
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    //|| (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireType = "";// Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        Avg_Wt_Details[dgSelectedIndex].wire_type_id = null;
                                    }
                                    else
                                    {
                                        if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                            //&& (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                            && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)
                                       && (Avg_Wt_Details[dgSelectedIndex].Make != "")
                                       && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                        {

                                            string ChkItem = "";
                                            ChkItem = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type) + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date) + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia) + Avg_Wt_Details[dgSelectedIndex].Make + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type);
                                                Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
                                            }
                                            else
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].WireType = "";
                                                Avg_Wt_Details[dgSelectedIndex].wire_type_id = null;
                                            }
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type);
                                            Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
                                        }
                                        //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                        //&& (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                        && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)
                                       && (Avg_Wt_Details[dgSelectedIndex].Make != "")
                                       && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type) + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date) + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia) + Avg_Wt_Details[dgSelectedIndex].Make + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type);
                                            Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].WireType = "";
                                            Avg_Wt_Details[dgSelectedIndex].wire_type_id = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].WireType = Convert.ToString(SelectedWireTypeDetailsTemp[0].wire_type);
                                        Avg_Wt_Details[dgSelectedIndex].wire_type_id = SelectedWireTypeDetailsTemp[0].wire_type_id;
                                    }
                                    //Avg_Wt_Details[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                }
                            }
                            catch
                            {

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
        private void GetSelectedTotLengthDetails(IList TotLengthList)
        {
            try
            {
                IList list = TotLengthList as IList;
                List<ZADM_M008_P> SelectedTotLengthDetailsTemp = list.Cast<ZADM_M008_P>().ToList();

                if (SelectedTotLengthDetailsTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = Avg_Wt_Details.Where(X => X.BlankLength == Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len)).FirstOrDefault();

                    if (q != null)
                    {
                        if (Avg_Wt_Details.Count() > dgSelectedIndex)
                        {
                            try
                            {
                                if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       )
                                {
                                    Avg_Wt_Details[dgSelectedIndex].BlankLength = "";
                                    Avg_Wt_Details[dgSelectedIndex].blank_len = null;
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                              && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                              && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)
                                        && (Avg_Wt_Details[dgSelectedIndex].Make != "")
                                        )
                                    {

                                        string ChkItem = "";
                                        ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                             + Avg_Wt_Details[dgSelectedIndex].Make
                                        + Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);

                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                            Avg_Wt_Details[dgSelectedIndex].blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id;
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].BlankLength = "";
                                            Avg_Wt_Details[dgSelectedIndex].blank_len = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                        Avg_Wt_Details[dgSelectedIndex].blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id;
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (Avg_Wt_Details.Count() <= dgSelectedIndex)
                        {
                            try
                            {
                                if (Avg_Wt_Details.Count == 0)
                                {
                                    Avg_Wt_Details.Add(new ZSCM_T001_B()
                                    {
                                        BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len),
                                        blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id,
                                        entry_date = DateTime.Now.Date
                                    });
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)
                                       )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].BlankLength = "";
                                        Avg_Wt_Details[dgSelectedIndex].blank_len = null;
                                    }
                                    else
                                    {
                                        Avg_Wt_Details.Add(new ZSCM_T001_B()
                                        {
                                            BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len),
                                            blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id,
                                            entry_date = DateTime.Now
                                        });
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (dgSelectedIndex > 0)
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                     || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                     || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)
                                     || (Avg_Wt_Details[dgSelectedIndex - 1].Make == "") || (Avg_Wt_Details[dgSelectedIndex - 1].Make == null)

                                        )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].BlankLength = "";
                                        Avg_Wt_Details[dgSelectedIndex].blank_len = null;
                                    }
                                    else
                                    {
                                        if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                             && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                             && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)
                                       && (Avg_Wt_Details[dgSelectedIndex].Make != "")

                                       )
                                        {

                                            string ChkItem = "";
                                            ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                             + Avg_Wt_Details[dgSelectedIndex].Make
                                        + Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);

                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                                Avg_Wt_Details[dgSelectedIndex].blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id;
                                            }
                                            else
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].BlankLength = "";
                                                Avg_Wt_Details[dgSelectedIndex].blank_len = null;
                                            }
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                            Avg_Wt_Details[dgSelectedIndex].blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id;
                                        }

                                    }
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                              && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                              && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)
                                        && (Avg_Wt_Details[dgSelectedIndex].Make != "")

                                        )
                                    {
                                        string ChkItem = "";
                                        ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                             + Avg_Wt_Details[dgSelectedIndex].Make
                                        + Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                            Avg_Wt_Details[dgSelectedIndex].blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id;
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].BlankLength = "";
                                            Avg_Wt_Details[dgSelectedIndex].blank_len = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].BlankLength = Convert.ToString(SelectedTotLengthDetailsTemp[0].total_len);
                                        Avg_Wt_Details[dgSelectedIndex].blank_len = SelectedTotLengthDetailsTemp[0].tot_len_id;
                                    }

                                }
                            }
                            catch
                            {

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
        private void GetSelectedCopyDetails()
        {
            IList list = Temp_Avg_Wt_Details as IList;

            List<ZSCM_T001_B> SelectedCopyDetailsTemp = list.Cast<ZSCM_T001_B>().ToList();

            if (SelectedCopyDetailsTemp.Count > 0 && dgSelectedIndex != -1)
            {
                Avg_Wt_Details.Add(new ZSCM_T001_B()
                {
                    wire_type_id = SelectedCopyDetailsTemp[0].wire_type_id,
                    WireType = SelectedCopyDetailsTemp[0].WireType,
                    entry_date = SelectedCopyDetailsTemp[0].entry_date,//DateTime.Now.Date,
                    wire_size_id = SelectedCopyDetailsTemp[0].wire_size_id,
                    WireDia = SelectedCopyDetailsTemp[0].WireDia,
                    make_id = SelectedCopyDetailsTemp[0].make_id,
                    Make = SelectedCopyDetailsTemp[0].Make,
                    blank_len = SelectedCopyDetailsTemp[0].blank_len,
                    BlankLength = SelectedCopyDetailsTemp[0].BlankLength
                });
            }
        }
        private void GetSelectedMakeDetails(IList MakeList)
        {

            try
            {
                IList list = MakeList as IList;
                List<ADM_M0032_P> SelectedMakeDetailsTemp = list.Cast<ADM_M0032_P>().ToList();

                if (SelectedMakeDetailsTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = Avg_Wt_Details.Where(X => X.Make == Convert.ToString(SelectedMakeDetailsTemp[0].Make)).FirstOrDefault();

                    if (q != null)
                    {
                        if (Avg_Wt_Details.Count() > dgSelectedIndex)
                        {
                            try
                            {
                                if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)

                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                {
                                    Avg_Wt_Details[dgSelectedIndex].Make = "";
                                    Avg_Wt_Details[dgSelectedIndex].make_id = null;
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                              && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                              && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)

                                         && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                            + Convert.ToString(SelectedMakeDetailsTemp[0].Make)
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make);
                                            Avg_Wt_Details[dgSelectedIndex].make_id = SelectedMakeDetailsTemp[0].MakeCode;
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].Make = "";
                                            Avg_Wt_Details[dgSelectedIndex].make_id = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make);
                                        Avg_Wt_Details[dgSelectedIndex].make_id = SelectedMakeDetailsTemp[0].MakeCode;
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (Avg_Wt_Details.Count() <= dgSelectedIndex)
                        {
                            try
                            {
                                if (Avg_Wt_Details.Count == 0)
                                {
                                    Avg_Wt_Details.Add(new ZSCM_T001_B()
                                    {
                                        Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make),
                                        make_id = SelectedMakeDetailsTemp[0].MakeCode,
                                        entry_date = DateTime.Now
                                    }
                                        );
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                    || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)

                                       || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                       )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].Make = "";
                                        Avg_Wt_Details[dgSelectedIndex].make_id = null;
                                    }
                                    else
                                    {
                                        Avg_Wt_Details.Add(new ZSCM_T001_B()
                                        {
                                            Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make),
                                            make_id = SelectedMakeDetailsTemp[0].MakeCode,
                                            entry_date = DateTime.Now.Date
                                        });
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (dgSelectedIndex > 0)
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex - 1].entry_date == null)
                                   || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == "") || (Avg_Wt_Details[dgSelectedIndex - 1].WireType == null)
                                   || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == 0) || (Avg_Wt_Details[dgSelectedIndex - 1].WireDia == null)

                                      || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == "") || (Avg_Wt_Details[dgSelectedIndex - 1].BlankLength == null)
                                      )
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].Make = "";
                                        Avg_Wt_Details[dgSelectedIndex].make_id = null;
                                    }
                                    else
                                    {
                                        if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                            && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                            && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)

                                       && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                        {

                                            string ChkItem = "";
                                            ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                            + Convert.ToString(SelectedMakeDetailsTemp[0].Make)
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make);
                                                Avg_Wt_Details[dgSelectedIndex].make_id = SelectedMakeDetailsTemp[0].MakeCode;
                                            }
                                            else
                                            {
                                                Avg_Wt_Details[dgSelectedIndex].Make = "";
                                                Avg_Wt_Details[dgSelectedIndex].make_id = null;
                                            }
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make);
                                            Avg_Wt_Details[dgSelectedIndex].make_id = SelectedMakeDetailsTemp[0].MakeCode;
                                        }

                                    }
                                }
                                else
                                {
                                    if ((Avg_Wt_Details[dgSelectedIndex].entry_date != null)
                                             && (Avg_Wt_Details[dgSelectedIndex].WireType != "")
                                             && (Avg_Wt_Details[dgSelectedIndex].WireDia != 0)

                                        && (Avg_Wt_Details[dgSelectedIndex].BlankLength != ""))
                                    {
                                        string ChkItem = "";
                                        ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                                            + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                                            + Convert.ToString(SelectedMakeDetailsTemp[0].Make)
                                            + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make);
                                            Avg_Wt_Details[dgSelectedIndex].make_id = SelectedMakeDetailsTemp[0].MakeCode;
                                        }
                                        else
                                        {
                                            Avg_Wt_Details[dgSelectedIndex].Make = "";
                                            Avg_Wt_Details[dgSelectedIndex].make_id = null;
                                        }
                                    }
                                    else
                                    {
                                        Avg_Wt_Details[dgSelectedIndex].Make = Convert.ToString(SelectedMakeDetailsTemp[0].Make);
                                        Avg_Wt_Details[dgSelectedIndex].make_id = SelectedMakeDetailsTemp[0].MakeCode;
                                    }

                                }
                            }
                            catch
                            {

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
        private void CellChangeUpdate()
        {

            string ChkItem = "";
            if (Avg_Wt_Details[dgSelectedIndex].WireType != null && Avg_Wt_Details[dgSelectedIndex].WireType != ""
                && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date) != null && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date) != ""
                && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia) != null && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia) != ""
                && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].Make) != null && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].Make) != ""
                && Avg_Wt_Details[dgSelectedIndex].BlankLength != null && Avg_Wt_Details[dgSelectedIndex].BlankLength != "")
            {
                ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                    + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                    + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                    + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].Make)
                    + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                if (!CheckDuplicate(ChkItem) == true)
                {
                    if (dgSelectedIndex != -1 && Avg_Wt_Details.Count > 0 && Avg_Wt_Details.Count >= dgSelectedIndex)
                    {
                        if (Avg_Wt_Details[dgSelectedIndex].wt1 != null && Avg_Wt_Details[dgSelectedIndex].wt2 == 0 || Avg_Wt_Details[dgSelectedIndex].wt3 == 0)
                        {
                            Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = (Avg_Wt_Details[dgSelectedIndex].wt1 + Avg_Wt_Details[dgSelectedIndex].wt2 + Avg_Wt_Details[dgSelectedIndex].wt3) / 8;
                        }
                        else if (Avg_Wt_Details[dgSelectedIndex].wt2 != null && Avg_Wt_Details[dgSelectedIndex].wt1 == 0 || Avg_Wt_Details[dgSelectedIndex].wt3 == 0)
                        {
                            Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = (Avg_Wt_Details[dgSelectedIndex].wt1 + Avg_Wt_Details[dgSelectedIndex].wt2 + Avg_Wt_Details[dgSelectedIndex].wt3) / 8;
                        }
                        else if (Avg_Wt_Details[dgSelectedIndex].wt3 != null)
                        {
                            Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = (Avg_Wt_Details[dgSelectedIndex].wt1 + Avg_Wt_Details[dgSelectedIndex].wt2 + Avg_Wt_Details[dgSelectedIndex].wt3) / 8;
                        }
                    }
                }
                else
                {
                    Avg_Wt_Details[dgSelectedIndex].wt1 = 0;
                    Avg_Wt_Details[dgSelectedIndex].wt2 = 0;
                    Avg_Wt_Details[dgSelectedIndex].wt3 = 0;
                    Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = 0;

                }
            }
        }
        private void CellChangeUpdate2()
        {

            string ChkItem = "";
            if (Avg_Wt_Details[dgSelectedIndex].WireType != null && Avg_Wt_Details[dgSelectedIndex].WireType != ""
                && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date) != null && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date) != ""
                && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia) != null && Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia) != ""
                && Avg_Wt_Details[dgSelectedIndex].BlankLength != null && Avg_Wt_Details[dgSelectedIndex].BlankLength != "")
            {
                ChkItem = Avg_Wt_Details[dgSelectedIndex].WireType
                    + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].entry_date)
                    + Convert.ToString(Avg_Wt_Details[dgSelectedIndex].WireDia)
                    + Avg_Wt_Details[dgSelectedIndex].BlankLength;
                if (!CheckDuplicate(ChkItem) == true)
                {
                    if (dgSelectedIndex != -1 && Avg_Wt_Details.Count > 0 && Avg_Wt_Details.Count >= dgSelectedIndex)
                    {
                        if (Avg_Wt_Details[dgSelectedIndex].wt1 != null && Avg_Wt_Details[dgSelectedIndex].wt2 == 0 || Avg_Wt_Details[dgSelectedIndex].wt3 == 0)
                        {
                            Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = ((Avg_Wt_Details[dgSelectedIndex].wt1 + Avg_Wt_Details[dgSelectedIndex].wt2 + Avg_Wt_Details[dgSelectedIndex].wt3) / 1000) / 8;
                        }
                        else if (Avg_Wt_Details[dgSelectedIndex].wt2 != null && Avg_Wt_Details[dgSelectedIndex].wt1 == 0 || Avg_Wt_Details[dgSelectedIndex].wt3 == 0)
                        {
                            Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = ((Avg_Wt_Details[dgSelectedIndex].wt1 + Avg_Wt_Details[dgSelectedIndex].wt2 + Avg_Wt_Details[dgSelectedIndex].wt3) / 1000) / 8;
                        }
                        else if (Avg_Wt_Details[dgSelectedIndex].wt3 != null)
                        {
                            Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = ((Avg_Wt_Details[dgSelectedIndex].wt1 + Avg_Wt_Details[dgSelectedIndex].wt2 + Avg_Wt_Details[dgSelectedIndex].wt3) / 1000) / 8;
                        }
                    }
                }
                else
                {
                    Avg_Wt_Details[dgSelectedIndex].wt1 = 0;
                    Avg_Wt_Details[dgSelectedIndex].wt2 = 0;
                    Avg_Wt_Details[dgSelectedIndex].wt3 = 0;
                    Avg_Wt_Details[dgSelectedIndex].avg_blank_wt = 0;

                }
            }
        }
        private void LoadInitialData()
        {
            try
            {
                DefaultValues();
                string request = "";

                SelectedZSCM_T001_A.Year = Convert.ToString(System.DateTime.Now.Year);
                SelectedZSCM_T001_A.Month = Convert.ToString(System.DateTime.Now.ToString("MMMM"));

                request = SelectedZSCM_T001_A.Month + "!@" + SelectedZSCM_T001_A.Year + "!@" + Convert.ToString(SelectedZSCM_T001_A.location_Id);

                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZSCM_T001_A>(MC, "ZSCM_T001_A_Data", "Average_Blank_Weight", "SCM", "LoadAll", 0, request);
                SelectedList = MC.Avg_Wt;

                #region Command Initialisation
                SelectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedList(items); });
                SelectionChangedCommandWireSize = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedWireSizeDetails(items); });
                SelectionChangedCommandWireType = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedWireTypeDetails(items); });
                SelectionChangedCommandTotLength = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedTotLengthDetails(items); });
                SelectionChangedCommandMake = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedMakeDetails(items); });
                CopyCommand = new RelayCommand(GetSelectedCopyDetails);
                SelectionChangedCommandAvg_Wt_Details = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedAvg_Wt_DetailsList(items); });

                if (AppSessionState.comp_code == "1")
                {
                    CellChangedCommand = new RelayCommand(() => { CellChangeUpdate(); });
                }
                else
                {
                    CellChangedCommand = new RelayCommand(() => { CellChangeUpdate2(); });
                }
                SelectionChangedCommandMonth = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedMonth_Details(items); });
                SelectionChangedCommandYear = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedYear_Details(items); });
                SelectionIDCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedID(items); });
                ReportCommand = new RelayCommand(Load);
                //cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                WireSizeCollection = CollectionViewSource.GetDefaultView(MC.wiresize);
                WireSizeCollection.Filter = new Predicate<object>(WireSizeFilter);

                WireTypeCollection = CollectionViewSource.GetDefaultView(MC.wiretype);
                WireTypeCollection.Filter = new Predicate<object>(WireTypeFilter);

                TotLengthCollection = CollectionViewSource.GetDefaultView(MC.TotLength);
                TotLengthCollection.Filter = new Predicate<object>(TotLengthFilter);

                MakeCollection = CollectionViewSource.GetDefaultView(MC.Make);
                MakeCollection.Filter = new Predicate<object>(MakeFilter);

                MonthCollection = CollectionViewSource.GetDefaultView(MC.Month);
                MonthCollection.Filter = new Predicate<object>(MonthFilter);
                StringListMonth = MC.Month.Select(x => x.Month).ToList();

                YearCollection = CollectionViewSource.GetDefaultView(MC.Year);
                YearCollection.Filter = new Predicate<object>(YearFilter);
                StringListYear = MC.Year.Select(x => x.Year).ToList();
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
        //private void WindowEvetCall(object InputValue)
        //{
        //    try
        //    {
        //        if (doc_no_vm != null && ts_code_vm != null)
        //        {
        //            LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
        //            isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
        //            AppSessionState.ViewOtherRecordAllowed = true;
        //        }
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
                    Request = SelectedZSCM_T001_A.client + "!@" + SelectedZSCM_T001_A.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private bool ValidateControls123()
        {
            int cnt = 0;
            try
            {
                if (Avg_Wt_Details.Count > 0)
                {
                    foreach (var item in Avg_Wt_Details)
                    {

                        if (AppSessionState.comp_code == "1" && (item.wire_type_id == null || item.WireType == "" || item.WireType == null || item.entry_date == null || item.wire_size_id == null || item.WireDia == 0 || item.WireDia == null || item.make_id == null || item.Make == "" || item.Make == null || item.blank_len == null || item.BlankLength == "" || item.BlankLength == null || item.wt1 == null || item.wt2 == null || item.wt3 == null))
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Wire Type, Entry Date, Wire Make, Blank Length Should be Compalsary.", this.Title);
                            showMessageService.ShowMessage();
                            cnt = cnt + 1;
                            break;
                        }
                        else if (AppSessionState.comp_code != "1" && (item.wire_type_id == null || item.WireType == "" || item.WireType == null || item.entry_date == null || item.wire_size_id == null || item.WireDia == 0 || item.WireDia == null || item.blank_len == null || item.BlankLength == "" || item.BlankLength == null || item.wt1 == null || item.wt2 == null || item.wt3 == null))
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Wire Type, Entry Date, Blank Length Should be Compalsary.", this.Title);
                            showMessageService.ShowMessage();
                            cnt = cnt + 1;
                            break;
                        }
                        else if (item.wt1 == 0 || item.wt2 == 0 || item.wt3 == 0 || item.avg_blank_wt == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Weight1, Weight2, Weight3, Avg Blank weight Should be Greater Than Zero.", this.Title);
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
        private void GetSelectedMonth_Details(IList MonthList)
        {
            IList list = MonthList as IList;
            List<ZSCM_T001_A_Mon> SelectedMonthDetailsTemp = list.Cast<ZSCM_T001_A_Mon>().ToList();
            if (SelectedMonthDetailsTemp.Count > 0)
            {
                SelectedZSCM_T001_A.Month = SelectedMonthDetailsTemp[0].Month;
            }
        }

        private void GetSelectedID(IList Avg_WTDetailsList)
        {
            try
            {
                if (Avg_Wt_Details.Count > 0)
                {
                    IList list = Avg_WTDetailsList as IList;

                    List<ZSCM_T001_B> GetSelectedWTDetails = list.Cast<ZSCM_T001_B>().ToList();


                    if (GetSelectedWTDetails.Count > 0)
                    {

                        Temp_Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
                        {
                            try
                            {
                                Temp_Avg_Wt_Details.Add(new ZSCM_T001_B()
                                {
                                    wire_type_id = GetSelectedWTDetails[0].wire_type_id,
                                    WireType = GetSelectedWTDetails[0].WireType,
                                    entry_date = GetSelectedWTDetails[0].entry_date,
                                    wire_size_id = GetSelectedWTDetails[0].wire_size_id,
                                    WireDia = GetSelectedWTDetails[0].WireDia,
                                    make_id = GetSelectedWTDetails[0].make_id,
                                    Make = GetSelectedWTDetails[0].Make,
                                    blank_len = GetSelectedWTDetails[0].blank_len,
                                    BlankLength = GetSelectedWTDetails[0].BlankLength
                                });
                            }
                            catch
                            { }

                        }

                    }
                }
            }
            catch
            {

            }
        }
        private void GetSelectedYear_Details(IList YearList)
        {
            IList list = YearList as IList;
            List<ZSCM_T001_A_YR> SelectedYearDetailsTemp = list.Cast<ZSCM_T001_A_YR>().ToList();
            if (SelectedYearDetailsTemp.Count > 0)
            {
                SelectedZSCM_T001_A.Year = SelectedYearDetailsTemp[0].Year;
            }
        }
        private void Load()
        {
            SelectedZSCM_T001_A.location_Id = AppSessionState.location_Id;
            string request = "";

            request = SelectedZSCM_T001_A.Month + "!@" + SelectedZSCM_T001_A.Year + "!@" + Convert.ToString(SelectedZSCM_T001_A.location_Id);

            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZSCM_T001_A>(MC, "ZSCM_T001_A_Data", "Average_Blank_Weight", "SCM", "LoadAll", 0, request);//request

            SelectedList = MC.Avg_Wt;

            DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
            DataGridCollection.Filter = new Predicate<object>(Filter);

            Avg_Wt_Details = MC.Avg_Wt_Details;
        }

        private void DefaultValues()
        {
            SelectedZSCM_T001_A.add_by = AppSessionState.UserID;
            SelectedZSCM_T001_A.editby = AppSessionState.UserID;
            SelectedZSCM_T001_A.location_Id = AppSessionState.location_Id;
            SelectedZSCM_T001_A.finyr = "16-17";
            SelectedZSCM_T001_A.add_date = DateTime.Now;
            SelectedZSCM_T001_A.average_wt_dt = DateTime.Now;
            SelectedZSCM_T001_A.active = true;
            SelectedZSCM_T001_A.ts_code = ts_code_vm;
            SelectedZSCM_T001_A.client = AppSessionState.client;
            SelectedZSCM_T001_A.comp_code = AppSessionState.comp_code;
            SelectedZSCM_T001_A.client = AppSessionState.client;
            SelectedZSCM_T001_A.user_source1 = AppSessionState.UserSource1;
            SelectedZSCM_T001_A.user_source2 = AppSessionState.UserSource2;
            SelectedZSCM_T001_A.userid = AppSessionState.UserID;
            SelectedZSCM_T001_B.add_by = AppSessionState.UserID;
            SelectedZSCM_T001_B.add_date = DateTime.Now;
            SelectedZSCM_T001_B.editby = AppSessionState.UserID;
            SelectedZSCM_T001_B.location_Id = AppSessionState.location_Id;
            SelectedZSCM_T001_B.finyr = "16-17";
            SelectedZSCM_T001_B.active = true;
        }
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ZSCM_T001_A> result)
        {
            try
            {

                if (Avg_Wt_Details.Count > 0)
                {
                    if (ValidateControls123() == false)
                    {

                        ObjectSerializationService objSer = new ObjectSerializationService();
                        SelectedZSCM_T001_A.XmlDataDocument_ZSCM_T001_B = objSer.ObjectToXML(Avg_Wt_Details);

                        if (blNew == true)
                        {
                            SelectedZSCM_T001_A = repository.SaveWithReturnDomainObject<ZSCM_T001_A>(SelectedZSCM_T001_A, "Average_Blank_Weight", "SCM");
                            var tempSelectRemove = SelectedList.Where(x => x.id == SelectedZSCM_T001_A.id).FirstOrDefault();
                            SelectedList.Remove(tempSelectRemove);
                            SelectedList.Add(SelectedZSCM_T001_A);

                            this.SelectedZSCM_T001_A.EndEdit();
                            blNew = false;
                        }
                        else if (blNew == false)
                        {
                            SelectedZSCM_T001_A = repository.UpdateWithReturnDomainObject<ZSCM_T001_A>(SelectedZSCM_T001_A, "Average_Blank_Weight", "SCM");
                            var tempSelectRemove = SelectedList.Where(x => x.id == SelectedZSCM_T001_A.id).FirstOrDefault();
                            SelectedList.Remove(tempSelectRemove);
                            SelectedList.Add(SelectedZSCM_T001_A);
                            this.SelectedZSCM_T001_A.EndEdit();
                        }
                        if (SelectedZSCM_T001_A.XmlDataDocument_ZSCM_T001_B != null)
                        {
                            MC.Avg_Wt_Details = (ObservableCollection<ZSCM_T001_B>)new ObjectSerializationService().XMLToObject(SelectedZSCM_T001_A.XmlDataDocument_ZSCM_T001_B, MC.Avg_Wt_Details);

                        }
                        else
                        {
                            MC.Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();

                        }
                        SelectedZSCM_T001_A.ts_code = ts_code_vm;
                        DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                        DataGridCollection.Filter = new Predicate<object>(Filter);
                        Avg_Wt_Details = MC.Avg_Wt_Details;
                        _dataGridCollection.Refresh();
                        MessageBox.Show("Record Saved Successfully");
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
        protected override void OnCreateAction(InquiryActionResult<ZSCM_T001_A> result)
        {

            blNew = true;
            SelectedZSCM_T001_A = new ZSCM_T001_A();
            SelectedZSCM_T001_B = new ZSCM_T001_B();
            SelectedZSCM_T001_A.ValidateAsync().Wait();
            Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            Temp_Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            SelectedWireSizeList = new List<ZADM_M003_P>();
            SelectedListOfWireTypeDtls = new List<ZADM_M004_P>();
            SelectedTotLengthList = new List<ZADM_M008_P>();
            SelectedMakeList = new List<ADM_M0032_P>();
            _dataGridCollection.Refresh();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZSCM_T001_A> result)
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
                this.SelectedZSCM_T001_A.CancelEdit();
                string response = repository.Delete(SelectedZSCM_T001_A.id, "Average_Blank_Weight", "SCM");
                SelectedList.Remove(SelectedZSCM_T001_A);
                _dataGridCollection.Refresh();
                SelectedZSCM_T001_A = new ZSCM_T001_A();
                Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZSCM_T001_A> result)
        {
            SelectedZSCM_T001_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZSCM_T001_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZSCM_T001_A> result)
        {
            SelectedList = SelectedList;
            SelectedZSCM_T001_A = SelectedZSCM_T001_A;
        }
        protected override void OnHelpAction(InquiryActionResult<ZSCM_T001_A> result)
        {
            SelectedList = SelectedList;
            SelectedZSCM_T001_A = SelectedZSCM_T001_A;
        }
        protected override void OnPrintAction(InquiryActionResult<ZSCM_T001_A> result)
        {


            //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZSCM_T001_A>(MC, "ZSCM_T001_A_Data", "Average_Blank_Weight", "SCM", "LoadRPT_Details", 0, request);//request
            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZSCM_T001_A>(MC, "ZSCM_T001_A_Data", "Average_Blank_Weight", "SCM", "LoadRPT_Details", 0, Convert.ToString(SelectedZSCM_T001_A.id));//request

            object objDS;
            objDS = MC.AvgB_Wt_Rpt;

            ReportManager ReportManager = new ReportingServices.ReportManager();
            //ReportManager.DisplayReport(objDS, "AvgBlnkWt_DS", "\\Store\\AvgBlnkWt.rdlc");
            ReportManager.DisplayReport(objDS, "AvgBlnkWt_DS", "\\Store\\AvgBlankWtReport.rdlc");
        }
        protected override void OnDocumentAction()
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<ZSCM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZSCM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZSCM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZSCM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZSCM_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Filters For WireSize
        private void FilterCollectionWireSize()
        {
            if (_WireSizeCollection != null)
            {
                _WireSizeCollection.Refresh();
            }
        }
        public string FilterStringWireSize
        {
            get { return _filterStringWireSize; }
            set
            {
                _filterStringWireSize = value;
                RaisePropertyChanged("FilterStringWireSize");
                FilterCollectionWireSize();
            }
        }
        public bool WireSizeFilter(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireSize))
                {
                    return (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_filterStringWireSize.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For WireType
        private void FilterCollectionWireType()
        {
            if (_WireTypeCollection != null)
            {
                _WireTypeCollection.Refresh();
            }
        }
        public string FilterStringWireType
        {
            get { return _filterStringWireType; }
            set
            {
                _filterStringWireType = value;
                RaisePropertyChanged("FilterStringWireType");
                FilterCollectionWireType();
            }
        }
        public bool WireTypeFilter(object obj)
        {
            var data = obj as ZADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireType))
                {
                    return (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterStringWireType.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For TotLength
        private void FilterCollectionTotLength()
        {
            if (_TotLengthCollection != null)
            {
                _TotLengthCollection.Refresh();
            }
        }
        public string FilterStringTotLength
        {
            get { return _filterStringTotLength; }
            set
            {
                _filterStringTotLength = value;
                RaisePropertyChanged("FilterStringTotLength");
                FilterCollectionTotLength();
            }
        }
        public bool TotLengthFilter(object obj)
        {
            var data = obj as ZADM_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTotLength))
                {
                    return (data.total_len != null && data.total_len.ToString().ToLower().Contains(_filterStringTotLength.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For Make
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
        public string FilterStringMake
        {
            get { return _filterStringMake; }
            set
            {
                _filterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterCollectionMake();
            }
        }
        public bool MakeFilter(object obj)
        {
            var data = obj as ADM_M0032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringMake.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For Month
        private void FilterCollectionMonth()
        {
            if (_MonthCollection != null)
            {
                _MonthCollection.Refresh();
            }
        }
        public string FilterStringMonth
        {
            get { return _filterStringMonth; }
            set
            {
                _filterStringMonth = value;
                RaisePropertyChanged("FilterStringMonth");
                FilterCollectionMonth();
            }
        }
        public bool MonthFilter(object obj)
        {
            //var data = obj as ZSCM_T001_A;
            var data = obj as ZSCM_T001_A_Mon;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMonth))
                {
                    return (data.Month != null && data.Month.ToString().ToLower().Contains(_filterStringMonth.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For Year
        private void FilterCollectionYear()
        {
            if (_YearCollection != null)
            {
                _YearCollection.Refresh();
            }
        }
        public string FilterStringYear
        {
            get { return _filterStringYear; }
            set
            {
                _filterStringYear = value;
                RaisePropertyChanged("FilterStringYear");
                FilterCollectionYear();
            }
        }
        public bool YearFilter(object obj)
        {
            //var data = obj as ZSCM_T001_A;
            var data = obj as ZSCM_T001_A_YR;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringYear))
                {
                    return (data.Year != null && data.Year.ToString().ToLower().Contains(_filterStringYear.ToLower()));

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
            var data = obj as ZSCM_T001_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return
                    (data.average_wt_no != null && data.average_wt_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.average_wt_dt != null);
                }
                return true;
            }
            return false;
        }

       
        #endregion
    }
}
