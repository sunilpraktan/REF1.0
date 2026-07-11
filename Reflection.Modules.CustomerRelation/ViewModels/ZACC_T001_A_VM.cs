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
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Globalization;


namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ZACC_T001_A_VM : WorkspaceViewModel<ZACC_T001_A>
    {


        bool blNew = true;
        WebServiceRepository<ZACC_T001_A> repository = new WebServiceRepository<ZACC_T001_A>();
        WebServiceRepository<MultipleContext_ZACC_T001_A> repositoryM = new WebServiceRepository<MultipleContext_ZACC_T001_A>();
        MultipleContext_ZACC_T001_A MCTemp = new MultipleContext_ZACC_T001_A();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private ICollectionView _dataGridCollection;
        private int _dgSelectedIndex;
        private string _filterString;
        private string _filterStringPre_Year;
        private string _filterStringUnit;

        private string _filterStringWireSize;
        private string _filterStringWireType;
        private string _filterStringBallType;
        private string _filterStringTipLength;
        private bool FlagForDuplicate = false;


        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionWireSize;
        public ICollectionView CollectionWireSize
        {
            get { return _CollectionWireSize; }
            set { _CollectionWireSize = value; RaisePropertyChanged("CollectionWireSize"); }
        }

        private ICollectionView _CollectionWireType;
        public ICollectionView CollectionWireType
        {
            get { return _CollectionWireType; }
            set { _CollectionWireType = value; RaisePropertyChanged("CollectionWireType"); }
        }

        private ICollectionView _CollectionBallType;
        public ICollectionView CollectionBallType
        {
            get { return _CollectionBallType; }
            set { _CollectionBallType = value; RaisePropertyChanged("CollectionBallType"); }
        }

        private ICollectionView _CollectionTipLength;
        public ICollectionView CollectionTipLength
        {
            get { return _CollectionTipLength; }
            set { _CollectionTipLength = value; RaisePropertyChanged("CollectionTipLength"); }
        }

        private ICollectionView _CollectionPre_Year;
        public ICollectionView CollectionPre_Year
        {
            get { return _CollectionPre_Year; }
            set { _CollectionPre_Year = value; RaisePropertyChanged("CollectionPre_Year"); }
        }

        private ICollectionView _CollectionUnit;
        public ICollectionView CollectionUnit
        {
            get { return _CollectionUnit; }
            set { _CollectionUnit = value; RaisePropertyChanged("CollectionUnit"); }
        }


        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandWireType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandWireSize
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandTipLength
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandPre_Year
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandNew_Month
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandUnit
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectedRowDeleteCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> CellChangedCommand
        {
            get;
            private set;
        }

        private RelayCommand _buttonClickCommand;
        public RelayCommand ButtonClickCommand
        {
            get;
            private set;
        }

        public RelayCommand ButtonWireTypeCommand
        {
            get;
            private set;
        }



        #endregion

        #region ZACC_T001_A
        private List<ZACC_T001_A> _SelectedList;
        public List<ZACC_T001_A> SelectedList
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

        private ZACC_T001_A _SelectedZACC_T001_A;
        public ZACC_T001_A SelectedZACC_T001_A
        {
            get
            {
                //this.ErrorExist = _SelectedZACC_T001_A.HasErrors;
                return _SelectedZACC_T001_A;
            }
            set
            {
                if (_SelectedZACC_T001_A != value)
                {
                    _SelectedZACC_T001_A = value;
                    //this.ErrorExist = _SelectedZACC_T001_A.HasErrors;
                    RaisePropertyChanged("SelectedZACC_T001_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ZACC_T001_A
        private static ObservableCollection<ZACC_T001_A> _RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
        public ObservableCollection<ZACC_T001_A> RateEntryDeatils
        {
            get { return _RateEntryDeatils; }
            set
            {
                if (_RateEntryDeatils != value)
                {
                    _RateEntryDeatils = value;

                    RaisePropertyChanged("RateEntryDeatils");
                }
            }
        }
        #endregion

        #region ZACC_T001_A
        private static ObservableCollection<ZACC_T001_A> _GetSelectedForDuplicate = new ObservableCollection<ZACC_T001_A>();
        public ObservableCollection<ZACC_T001_A> GetSelectedForDuplicate
        {
            get { return _GetSelectedForDuplicate; }
            set
            {
                if (_GetSelectedForDuplicate != value)
                {
                    _GetSelectedForDuplicate = value;

                    RaisePropertyChanged("GetSelectedForDuplicate");
                }
            }
        }
        #endregion



        #region Temp_ZACC_T001_A
        private static ObservableCollection<ZACC_T001_A> _Temp_RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
        public ObservableCollection<ZACC_T001_A> Temp_RateEntryDeatils
        {
            get { return _Temp_RateEntryDeatils; }
            set
            {
                if (_Temp_RateEntryDeatils != value)
                {
                    _Temp_RateEntryDeatils = value;

                    RaisePropertyChanged("Temp_RateEntryDeatils");
                }
            }
        }


        #endregion

        #region ZACC_T001_WireType
        private List<ZACC_T001_WireType> _dgPopupWireType;
        public List<ZACC_T001_WireType> dgPopupWireType
        {
            get
            {
                return _dgPopupWireType;

            }
            set
            {
                if (_dgPopupWireType != value)
                {

                    _dgPopupWireType = value;

                    RaisePropertyChanged("dgPopupWireType");


                }
            }
        }
        #endregion
        #region ZACC_T001_WireSize
        private List<ZACC_T001_WireSize> _SelectedWireSizeList;
        public List<ZACC_T001_WireSize> SelectedWireSizeList
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

        #region ZACC_T001_WireType
        private List<ZACC_T001_WireType> _SelectedWireTypeList;
        public List<ZACC_T001_WireType> SelectedWireTypeList
        {
            get { return _SelectedWireTypeList; }
            set
            {
                if (_SelectedWireTypeList != value)
                {
                    _SelectedWireTypeList = value;
                    RaisePropertyChanged("SelectedWireTypeList");
                }
            }
        }
        #endregion

        #region ZACC_T001_BallType
        private List<ZACC_T001_BallType> _SelectedBallTypeList;
        public List<ZACC_T001_BallType> SelectedBallTypeList
        {
            get { return _SelectedBallTypeList; }
            set
            {
                if (_SelectedBallTypeList != value)
                {
                    _SelectedBallTypeList = value;
                    RaisePropertyChanged("SelectedMCList");
                }
            }
        }
        #endregion

        #region ZACC_T001_TipLength
        private List<ZACC_T001_TipLength> _SelectedTipLengthList;
        public List<ZACC_T001_TipLength> SelectedTipLengthList
        {
            get { return _SelectedTipLengthList; }
            set
            {
                if (_SelectedTipLengthList != value)
                {
                    _SelectedTipLengthList = value;
                    RaisePropertyChanged("SelectedTipLengthList");
                }
            }
        }
        #endregion

        #region ZACC_T001_Pre_Year
        private List<ZACC_T001_Pre_Year> _SelectedPre_YearList;
        public List<ZACC_T001_Pre_Year> SelectedPre_YearList
        {
            get { return _SelectedPre_YearList; }
            set
            {
                if (_SelectedPre_YearList != value)
                {
                    _SelectedPre_YearList = value;
                    RaisePropertyChanged("SelectedPre_YearList");
                }
            }
        }
        #endregion


        #region ZACC_T001_Unit
        private List<ZACC_T001_Unit> _SelectedUnitList;
        public List<ZACC_T001_Unit> SelectedUnitList
        {
            get { return _SelectedUnitList; }
            set
            {
                if (_SelectedUnitList != value)
                {
                    _SelectedUnitList = value;
                    RaisePropertyChanged("SelectedUnitList");
                }
            }
        }
        #endregion


        #region ZACC_T001_Moth_Year
        private List<ZACC_T001> _SelectedMonthYearList;
        public List<ZACC_T001> SelectedMonthYearList
        {
            get { return _SelectedMonthYearList; }
            set
            {
                if (_SelectedMonthYearList != value)
                {
                    _SelectedMonthYearList = value;
                    RaisePropertyChanged("SelectedMonthYearList");
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



        MultipleContext_ZACC_T001_A _MC = new MultipleContext_ZACC_T001_A();
        public MultipleContext_ZACC_T001_A MC
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
        public ZACC_T001_A_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SelectedList = new List<ZACC_T001_A>();
            SelectedZACC_T001_A = new ZACC_T001_A();
            SelectedWireSizeList = new List<ZACC_T001_WireSize>();
            SelectedWireTypeList = new List<ZACC_T001_WireType>();
            dgPopupWireType = new List<ZACC_T001_WireType>();

            SelectedBallTypeList = new List<ZACC_T001_BallType>();
            SelectedTipLengthList = new List<ZACC_T001_TipLength>();
            SelectedMonthYearList = new List<ZACC_T001>();
            SelectedPre_YearList = new List<ZACC_T001_Pre_Year>();
            SelectedUnitList = new List<ZACC_T001_Unit>();
            MC = new MultipleContext_ZACC_T001_A();
            RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
            RateEntryDeatils.Clear();
            Temp_RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
            Temp_RateEntryDeatils.Clear();
            SelectedZACC_T001_A.ValidateAsync().Wait();
            LoadInitialData();
        }
        public ZACC_T001_A_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<ZACC_T001_A>();
            SelectedZACC_T001_A = new ZACC_T001_A();
            SelectedWireSizeList = new List<ZACC_T001_WireSize>();
            SelectedWireTypeList = new List<ZACC_T001_WireType>();
            dgPopupWireType = new List<ZACC_T001_WireType>();

            SelectedBallTypeList = new List<ZACC_T001_BallType>();
            SelectedTipLengthList = new List<ZACC_T001_TipLength>();
            SelectedMonthYearList = new List<ZACC_T001>();
            SelectedPre_YearList = new List<ZACC_T001_Pre_Year>();
            SelectedUnitList = new List<ZACC_T001_Unit>();
            MC = new MultipleContext_ZACC_T001_A();
            RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
            RateEntryDeatils.Clear();
            Temp_RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
            Temp_RateEntryDeatils.Clear();
            SelectedZACC_T001_A.ValidateAsync().Wait();
            LoadInitialData();
        }

        #endregion

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZACC_T001_A> tSelectedItemsList = list.Cast<ZACC_T001_A>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZACC_T001_A = (ZACC_T001_A)tSelectedItemsList[0];
                blNew = false;
            }
        }

        //private void GetSelectedGoodDetails(IList IssueList)
        //{
        //    try
        //    {
        //        IList list = IssueList as IList;

        //        List<ZACC_T001_A> SelectedItemsList2 = list.Cast<ZACC_T001_A>().ToList();
        //        if (SelectedItemsList2.Count > 0)
        //        {
        //            SelectedZACC_T001_A = (ZACC_T001_A)SelectedItemsList2[0];
        //            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZACC_T001_A>(MC, "ZACC_T001_A_Data", "ILDChart", "CustomerRelation", "LoadAll", 0, "");
        //            MC.GoodsDetails = MCTemp.GoodsDetails;
        //            GoodsDetails = new ObservableCollection<ZACC_T001_A>();
        //            blNew = false;
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

        private bool CheckDuplicate(string CheckItem)
        {
            int x = 0;
            FlagForDuplicate = false;
            foreach (var item in RateEntryDeatils)
            {
                if (CheckItem == item.wiresz + item.wiretp + item.balltp + item.tiplen)
                {
                    x = x + 1;
                    break;
                }
                else
                {
                    x = 0;
                }

            }
            if (x > 0 && x != -1)
            {
                FlagForDuplicate = true;
                MessageBox.Show("Wire_Size + Wire_Type + Ball_Type + Tip_Length Combination is already exists");
            }
            else
            {
                FlagForDuplicate = false;
            }
            return FlagForDuplicate;
        }
        private void GetSelectedWireSize(IList WireSizeList)
        {
            try
            {
                IList list = WireSizeList as IList;
                List<ZACC_T001_WireSize> GetSelectedWireSizeTemp = list.Cast<ZACC_T001_WireSize>().ToList();
                //if (RateEntryDeatils[dgSelectedIndex].id == null || RateEntryDeatils[dgSelectedIndex].id == 0 || RateEntryDeatils[dgSelectedIndex].id.ToString() == "")
                {


                    if (GetSelectedWireSizeTemp.Count > 0 && dgSelectedIndex != -1)
                    {
                        var q = RateEntryDeatils.Where(X => X.wiresz == Convert.ToString(GetSelectedWireSizeTemp[0].WireSize)).FirstOrDefault();

                        if (q != null)
                        {
                            if (RateEntryDeatils.Count() > dgSelectedIndex)
                            {
                                try
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                           || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                           || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                           )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].wiresz = "";
                                    }
                                    else
                                    {
                                        if ((RateEntryDeatils[dgSelectedIndex].wiretp != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].balltp != ""))
                                        {
                                            //RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                            string ChkItem = "";
                                            ChkItem = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize) + RateEntryDeatils[dgSelectedIndex].wiretp + RateEntryDeatils[dgSelectedIndex].balltp + RateEntryDeatils[dgSelectedIndex].tiplen;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                            }
                                            else
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiresz = "";
                                            }
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
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
                            if (RateEntryDeatils.Count() <= dgSelectedIndex)
                            {
                                try
                                {
                                    if (RateEntryDeatils.Count == 0)
                                    {
                                        RateEntryDeatils.Add(new ZACC_T001_A() { wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize) });
                                    }
                                    else
                                    {

                                        if ((RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                            )
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiresz = "";// Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                        }
                                        else
                                        {
                                            RateEntryDeatils.Add(new ZACC_T001_A() { wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize) });
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
                                        if ((RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                                || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                                || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                                )
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiresz = "";// Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                        }
                                        else
                                        {
                                            if ((RateEntryDeatils[dgSelectedIndex].wiretp != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].balltp != ""))
                                            {
                                                string ChkItem = "";
                                                ChkItem = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize) + RateEntryDeatils[dgSelectedIndex].wiretp + RateEntryDeatils[dgSelectedIndex].balltp + RateEntryDeatils[dgSelectedIndex].tiplen;
                                                CheckDuplicate(ChkItem);
                                                if (FlagForDuplicate != true)
                                                {
                                                    RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                                }
                                                else
                                                {
                                                    RateEntryDeatils[dgSelectedIndex].wiresz = "";
                                                }
                                            }
                                            else
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((RateEntryDeatils[dgSelectedIndex].wiretp != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].balltp != ""))
                                        {
                                            string ChkItem = "";
                                            ChkItem = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize) + RateEntryDeatils[dgSelectedIndex].wiretp + RateEntryDeatils[dgSelectedIndex].balltp + RateEntryDeatils[dgSelectedIndex].tiplen;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
                                            }
                                            else
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiresz = "";
                                            }
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiresz = Convert.ToString(GetSelectedWireSizeTemp[0].WireSize);
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

        private void GetSelectedWireType(IList WireTypeList)
        {
            try
            {
                IList list = WireTypeList as IList;
                List<ZACC_T001_WireType> GetSelectedWireTypeTemp = list.Cast<ZACC_T001_WireType>().ToList();

                if (GetSelectedWireTypeTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = RateEntryDeatils.Where(X => X.wiretp == Convert.ToString(GetSelectedWireTypeTemp[0].WireType)).FirstOrDefault();

                    if (q != null)
                    {
                        if (RateEntryDeatils.Count() > dgSelectedIndex)
                        {
                            //RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                            try
                            {
                                if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                       )
                                {
                                    RateEntryDeatils[dgSelectedIndex].wiretp = "";
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].balltp != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + Convert.ToString(GetSelectedWireTypeTemp[0].WireType) + RateEntryDeatils[dgSelectedIndex].balltp + RateEntryDeatils[dgSelectedIndex].tiplen;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiretp = "";
                                        }
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }

                                    //RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (RateEntryDeatils.Count() <= dgSelectedIndex)
                        {
                            //RateEntryDeatils.Add(new ZACC_T001_A() { wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType) });
                            try
                            {
                                if (RateEntryDeatils.Count == 0)
                                {
                                    RateEntryDeatils.Add(new ZACC_T001_A() { wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType) });
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                        )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].wiretp = "";// Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }
                                    else
                                    {
                                        RateEntryDeatils.Add(new ZACC_T001_A() { wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType) });
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
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                                || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                                || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                                )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].wiretp = "";// Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }
                                    else
                                    {
                                        if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].balltp != ""))
                                        {

                                            string ChkItem = "";
                                            ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + Convert.ToString(GetSelectedWireTypeTemp[0].WireType) + RateEntryDeatils[dgSelectedIndex].balltp + RateEntryDeatils[dgSelectedIndex].tiplen;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                            }
                                            else
                                            {
                                                RateEntryDeatils[dgSelectedIndex].wiretp = "";
                                            }
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        }
                                        //RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].balltp != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + Convert.ToString(GetSelectedWireTypeTemp[0].WireType) + RateEntryDeatils[dgSelectedIndex].balltp + RateEntryDeatils[dgSelectedIndex].tiplen;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].wiretp = "";
                                        }
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
                                    }
                                    //RateEntryDeatils[dgSelectedIndex].wiretp = Convert.ToString(GetSelectedWireTypeTemp[0].WireType);
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

        private void RowWiseWireTypeLoad()
        {
            try
            {
                var WireType = (from o in dgPopupWireType
                                where o.WireType == (RateEntryDeatils[dgSelectedIndex].wiretp)
                                select o).ToList();
                MC.WireType = WireType;
                _CollectionWireType = CollectionViewSource.GetDefaultView(MC.WireType);
            }
            catch
            {

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
                    Request = SelectedZACC_T001_A.client + "!@" + SelectedZACC_T001_A.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void GetSelectedBallType(IList BallTypeList)
        {
            try
            {
                IList list = BallTypeList as IList;
                List<ZACC_T001_BallType> GetSelectedBallTypeTemp = list.Cast<ZACC_T001_BallType>().ToList();

                if (GetSelectedBallTypeTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = RateEntryDeatils.Where(X => X.balltp == Convert.ToString(GetSelectedBallTypeTemp[0].BallType)).FirstOrDefault();

                    if (q != null)
                    {
                        if (RateEntryDeatils.Count() > dgSelectedIndex)
                        {
                            //RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(SelectedBallTypeTemp[0].BallType);
                            try
                            {
                                if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                       )
                                {
                                    RateEntryDeatils[dgSelectedIndex].balltp = "";
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].wiretp != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + RateEntryDeatils[dgSelectedIndex].wiretp + Convert.ToString(GetSelectedBallTypeTemp[0].BallType) + RateEntryDeatils[dgSelectedIndex].tiplen;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].balltp = "";
                                        }
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                    }

                                    //RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (RateEntryDeatils.Count() <= dgSelectedIndex)
                        {
                            //RateEntryDeatils.Add(new ZACC_T001_A() { balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType) });
                            try
                            {
                                if (RateEntryDeatils.Count == 0)
                                {
                                    RateEntryDeatils.Add(new ZACC_T001_A() { balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType) });
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                        )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                    }
                                    else
                                    {
                                        RateEntryDeatils.Add(new ZACC_T001_A() { balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType) });
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
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                            )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].balltp = "";// Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                    }
                                    else
                                    {
                                        //RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                        if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].wiretp != ""))
                                        {

                                            string ChkItem = "";
                                            ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + RateEntryDeatils[dgSelectedIndex].wiretp + Convert.ToString(GetSelectedBallTypeTemp[0].BallType) + RateEntryDeatils[dgSelectedIndex].tiplen;
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                            }
                                            else
                                            {
                                                RateEntryDeatils[dgSelectedIndex].balltp = "";
                                            }
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                        }
                                    }
                                }
                                else
                                {
                                    //RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                    if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].tiplen != "") && (RateEntryDeatils[dgSelectedIndex].wiretp != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + RateEntryDeatils[dgSelectedIndex].wiretp + Convert.ToString(GetSelectedBallTypeTemp[0].BallType) + RateEntryDeatils[dgSelectedIndex].tiplen;
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].balltp = "";
                                        }
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].balltp = Convert.ToString(GetSelectedBallTypeTemp[0].BallType);
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

        private void GetSelectedTipLength(IList TipLengthList)
        {
            try
            {
                IList list = TipLengthList as IList;
                List<ZACC_T001_TipLength> GetSelectedTipLengthTemp = list.Cast<ZACC_T001_TipLength>().ToList();

                if (GetSelectedTipLengthTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = RateEntryDeatils.Where(X => X.tiplen == Convert.ToString(GetSelectedTipLengthTemp[0].TipLength)).FirstOrDefault();

                    if (q != null)
                    {
                        if (RateEntryDeatils.Count() > dgSelectedIndex)
                        {
                            //RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                            try
                            {
                                if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                       )
                                {
                                    RateEntryDeatils[dgSelectedIndex].tiplen = "";
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].balltp != "") && (RateEntryDeatils[dgSelectedIndex].wiretp != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + RateEntryDeatils[dgSelectedIndex].wiretp + RateEntryDeatils[dgSelectedIndex].balltp + Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].tiplen = "";
                                        }
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                    //RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }

                    else
                    {
                        if (RateEntryDeatils.Count() <= dgSelectedIndex)
                        {
                            //RateEntryDeatils.Add(new ZACC_T001_A() { tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength) });
                            try
                            {
                                if (RateEntryDeatils.Count == 0)
                                {
                                    RateEntryDeatils.Add(new ZACC_T001_A() { tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength) });
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                        )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].tiplen = "";// Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                    else
                                    {
                                        RateEntryDeatils.Add(new ZACC_T001_A() { tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength) });
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
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                            )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].tiplen = "";// Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                    else
                                    {
                                        if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].balltp != "") && (RateEntryDeatils[dgSelectedIndex].wiretp != ""))
                                        {

                                            string ChkItem = "";
                                            ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + RateEntryDeatils[dgSelectedIndex].wiretp + RateEntryDeatils[dgSelectedIndex].balltp + Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                            CheckDuplicate(ChkItem);
                                            if (FlagForDuplicate != true)
                                            {
                                                RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                            }
                                            else
                                            {
                                                RateEntryDeatils[dgSelectedIndex].tiplen = "";
                                            }
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                        }
                                        //RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex].wiresz != "") && (RateEntryDeatils[dgSelectedIndex].balltp != "") && (RateEntryDeatils[dgSelectedIndex].wiretp != ""))
                                    {

                                        string ChkItem = "";
                                        ChkItem = RateEntryDeatils[dgSelectedIndex].wiresz + RateEntryDeatils[dgSelectedIndex].wiretp + RateEntryDeatils[dgSelectedIndex].balltp + Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                        CheckDuplicate(ChkItem);
                                        if (FlagForDuplicate != true)
                                        {
                                            RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                        }
                                        else
                                        {
                                            RateEntryDeatils[dgSelectedIndex].tiplen = "";
                                        }
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                    //RateEntryDeatils[dgSelectedIndex].tiplen = Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
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

        private void GetSelectedPre_Year(IList Pre_YearList)
        {
            IList list = Pre_YearList as IList;
            List<ZACC_T001_Pre_Year> GetSelectedPre_YearTemp = list.Cast<ZACC_T001_Pre_Year>().ToList();

            if (GetSelectedPre_YearTemp.Count > 0)
            {
                SelectedZACC_T001_A.Pre_yr = GetSelectedPre_YearTemp[0].Pre_Year;
            }


        }
        private void GetSelectedNew_Month(IList New_MonthList)
        {
            if (New_MonthList != null)
            {
                for (int i = 0; i < RateEntryDeatils.Count; i++)
                {
                    RateEntryDeatils[i].mon = New_MonthList.ToString();
                }

                blNew = false;
            }
        }


        private void GetSelectedUnit(IList UnitList)
        {
            try
            {
                IList list = UnitList as IList;
                List<ZACC_T001_Unit> GetSelectedUnitTemp = list.Cast<ZACC_T001_Unit>().ToList();

                if (GetSelectedUnitTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = RateEntryDeatils.Where(X => X.unit == Convert.ToString(GetSelectedUnitTemp[0].Unit)).FirstOrDefault();

                    if (q != null)
                    {
                        if (RateEntryDeatils.Count() > dgSelectedIndex)
                        {
                            //RateEntryDeatils[dgSelectedIndex].unit = Convert.ToString(GetSelectedUnitTemp[0].Unit);
                            try
                            {
                                if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                       || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                    || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                       )
                                {
                                    RateEntryDeatils[dgSelectedIndex].unit = "";
                                }
                                else
                                {
                                    RateEntryDeatils[dgSelectedIndex].unit = Convert.ToString(GetSelectedUnitTemp[0].Unit);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (RateEntryDeatils.Count() <= dgSelectedIndex)
                        {
                            //RateEntryDeatils.Add(new ZACC_T001_A() { unit = Convert.ToString(GetSelectedUnitTemp[0].Unit) });
                            try
                            {
                                if (RateEntryDeatils.Count == 0)
                                {
                                    RateEntryDeatils.Add(new ZACC_T001_A() { unit = Convert.ToString(GetSelectedUnitTemp[0].Unit) });
                                }
                                else
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                        )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].unit = "";// Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                    else
                                    {
                                        RateEntryDeatils.Add(new ZACC_T001_A() { unit = Convert.ToString(GetSelectedUnitTemp[0].Unit) });
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            //RateEntryDeatils[dgSelectedIndex].unit = Convert.ToString(GetSelectedUnitTemp[0].Unit);
                            try
                            {
                                if (dgSelectedIndex > 0)
                                {
                                    if ((RateEntryDeatils[dgSelectedIndex - 1].wiresz == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiresz == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == "") || (RateEntryDeatils[dgSelectedIndex - 1].wiretp == null)
                                            || (RateEntryDeatils[dgSelectedIndex - 1].balltp == "") || (RateEntryDeatils[dgSelectedIndex - 1].balltp == null)
                                        || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == "") || (RateEntryDeatils[dgSelectedIndex - 1].tiplen == null)
                                            )
                                    {
                                        RateEntryDeatils[dgSelectedIndex].unit = "";// Convert.ToString(GetSelectedTipLengthTemp[0].TipLength);
                                    }
                                    else
                                    {
                                        RateEntryDeatils[dgSelectedIndex].unit = Convert.ToString(GetSelectedUnitTemp[0].Unit);
                                    }
                                }
                                else
                                {
                                    RateEntryDeatils[dgSelectedIndex].unit = Convert.ToString(GetSelectedUnitTemp[0].Unit);
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


        private void GetDeleteSelectedRow(IList SelectedItems)
        {
            IList list = SelectedItems as IList;
            List<ZACC_T001_A> GetSelectedForDelete = list.Cast<ZACC_T001_A>().ToList();

            if (GetSelectedForDelete.Count > 0)
            {
                int x = RateEntryDeatils.IndexOf(RateEntryDeatils.Where(X => X.wiresz + X.wiretp + X.balltp + X.tiplen == GetSelectedForDelete[0].wiresz + GetSelectedForDelete[0].wiretp + GetSelectedForDelete[0].balltp + GetSelectedForDelete[0].tiplen).FirstOrDefault());
                if (GetSelectedForDelete[0].id == 0)
                {
                    if (x >= 0 && x != -1)
                    {
                        RateEntryDeatils.RemoveAt(x);
                    }
                }
            }
        }
        private void GetRateDeatils()
        {
            try
            {
                //SelectedZACC_T001_A.mon = Convert.ToString(AppSessionState.LocationID);
                //SelectedZACC_T001_A. = DateTime.Now.Date;

                string Request;
                Request = "";
                Request = "LoadRateDetailData" + "!@" + SelectedZACC_T001_A.Pre_mon + "!@" + SelectedZACC_T001_A.Pre_yr;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZACC_T001_A>(MCTemp, "ZACC_T001_A_Data", "RateTransfer", "CRM", "LoadRateDetailData", 0, Request);
                SelectedList = MCTemp.RateEntryDeatils;

                if (SelectedList != null)
                {
                    RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
                    RateEntryDeatils.Clear();
                    RateEntryDeatils = new ObservableCollection<ZACC_T001_A>(SelectedList);
                    Temp_RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
                    Temp_RateEntryDeatils.Clear();
                    Temp_RateEntryDeatils = new ObservableCollection<ZACC_T001_A>(SelectedList);
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
                string Request;
                Request = "";
                Request = "LoadALL" + "!@" + "" + "!@" + "";
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                ButtonClickCommand = new RelayCommand(GetRateDeatils);
                ButtonWireTypeCommand = new RelayCommand(RowWiseWireTypeLoad);
                SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });


                SelectionChangedCommandWireSize = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedWireSize(items);
              });

                SelectionChangedCommandWireType = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedWireType(items);
            });

                SelectionChangedCommandBallType = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedBallType(items);
           });

                SelectionChangedCommandTipLength = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedTipLength(items);
              });

                SelectionChangedCommandPre_Year = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedPre_Year(items);
              });



                SelectionChangedCommandNew_Month = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedNew_Month(items);
              });

                SelectionChangedCommandUnit = new RelayCommand<IList>(
         items =>
         {
             if (items == null)
             {
                 return;
             }

             GetSelectedUnit(items);
         });

                SelectedRowDeleteCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetDeleteSelectedRow(items);
                });
                #endregion
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZACC_T001_A>(MC, "ZACC_T001_A_Data", "RateTransfer", "CRM", "LoadALL", 0, Request);
                SelectedList = MC.RateEntryDeatils;
                //SelectedZACC_T001_A.plant = SelectedList[0].plant;

                CollectionWireSize = CollectionViewSource.GetDefaultView(MC.WireSize);
                CollectionWireSize.Filter = new Predicate<object>(FilterWireSize);

                CollectionWireType = CollectionViewSource.GetDefaultView(MC.WireType);
                CollectionWireType.Filter = new Predicate<object>(FilterWireType);

                dgPopupWireType = MC.WireType;

                CollectionBallType = CollectionViewSource.GetDefaultView(MC.BallType);
                CollectionBallType.Filter = new Predicate<object>(FilterBallType);

                CollectionTipLength = CollectionViewSource.GetDefaultView(MC.TipLength);
                CollectionTipLength.Filter = new Predicate<object>(FilterTipLength);

                CollectionPre_Year = CollectionViewSource.GetDefaultView(MC.Pre_Year);
                CollectionPre_Year.Filter = new Predicate<object>(FilterPre_Year);

                CollectionUnit = CollectionViewSource.GetDefaultView(MC.Unit);
                CollectionUnit.Filter = new Predicate<object>(FilterUnit);

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                int Monthindex = 0; Monthindex = System.DateTime.Now.Month;
                int Temp_Year = 0; Temp_Year = System.DateTime.Now.Year;
                int New_Monthindex = 0; New_Monthindex = Monthindex;
                int New_Temp_Year = 0; New_Temp_Year = Temp_Year;
                if (Monthindex == 1)
                {
                    Monthindex = 12;
                    Temp_Year = Temp_Year - 1;
                }
                else
                {
                    Monthindex = Monthindex - 1;
                    Temp_Year = Temp_Year - 0;
                }
                SelectedZACC_T001_A.Pre_mon = DateTimeFormatInfo.CurrentInfo.GetMonthName(Monthindex);
                SelectedZACC_T001_A.Pre_yr = Convert.ToString(Temp_Year);
                SelectedZACC_T001_A.New_mon = DateTimeFormatInfo.CurrentInfo.GetMonthName(New_Monthindex);
                SelectedZACC_T001_A.New_yr = Convert.ToString(New_Temp_Year);
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

        //foreach (ZACC_T001_A item in GoodsDetails)
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

        protected override void OnSaveAction(InquiryActionResult<ZACC_T001_A> result)
        {
            try
            {
                this.SelectedZACC_T001_A.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();

                //if (ValidateControls() == true)
                {
                    if (ValidateControls123() == false)
                    {
                        SelectedZACC_T001_A.addby = AppSessionState.UserID;
                        SelectedZACC_T001_A.mon = SelectedZACC_T001_A.New_mon;
                        SelectedZACC_T001_A.yr = SelectedZACC_T001_A.New_yr;
                        //if (blNew == true)
                        {
                            SelectedZACC_T001_A.XmlDataDocument_ZACC_T001 = objSer.ObjectToXML(RateEntryDeatils);
                            SelectedZACC_T001_A = repository.SaveWithReturnDomainObject<ZACC_T001_A>(SelectedZACC_T001_A, "RateTransfer", "CRM");
                            SelectedList.Add(SelectedZACC_T001_A);
                            _dataGridCollection.Refresh();
                            blNew = false;
                            MessageBox.Show("Record Saved Successfully");
                            int Monthindex = 0; Monthindex = System.DateTime.Now.Month;
                            int Temp_Year = 0; Temp_Year = System.DateTime.Now.Year;
                            int New_Monthindex = 0; New_Monthindex = Monthindex;
                            int New_Temp_Year = 0; New_Temp_Year = Temp_Year;
                            if (Monthindex == 1)
                            {
                                Monthindex = 12;
                                Temp_Year = Temp_Year - 1;
                            }
                            else
                            {
                                Monthindex = Monthindex - 1;
                                Temp_Year = Temp_Year - 0;
                            }
                            SelectedZACC_T001_A.Pre_mon = DateTimeFormatInfo.CurrentInfo.GetMonthName(Monthindex);
                            SelectedZACC_T001_A.Pre_yr = Convert.ToString(Temp_Year);
                            SelectedZACC_T001_A.New_mon = DateTimeFormatInfo.CurrentInfo.GetMonthName(New_Monthindex);
                            SelectedZACC_T001_A.New_yr = Convert.ToString(New_Temp_Year);
                            RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();
                            RateEntryDeatils.Clear();
                            //SelectedZACC_T001_A.XmlDataDocument_ZACC_T001 = objSer.ObjectToXML(RateEntryDeatils);
                            //SelectedZACC_T001_A = repository.UpdateWithReturnDomainObject<ZACC_T001_A>(SelectedZACC_T001_A, "RateTransfer", "CRM");
                            //SelectedList.Add(SelectedZACC_T001_A);
                        }
                        //else if (blNew == false)
                        //{                        
                        //      SelectedZACC_T001_A.XmlDataDocument_ZACC_T001_A = objSer.ObjectToXML(GoodsDetails);
                        //      SelectedZACC_T001_A = repository.UpdateWithReturnDomainObject<ZACC_T001_A>(SelectedZACC_T001_A, "ILDChart", "CustomerRelation");
                        //      SelectedList.Add(SelectedZACC_T001_A);                                              
                        //}
                        //_dataGridCollection.Refresh();
                    }
                }
                //else
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Select Atleast One Record", this.Title);
                //    showMessageService.ShowMessage();
                //}

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
        protected override void OnCreateAction(InquiryActionResult<ZACC_T001_A> result)
        {
            blNew = true;
            SelectedZACC_T001_A = new ZACC_T001_A();
            SelectedZACC_T001_A.ValidateAsync().Wait();
            RateEntryDeatils = new ObservableCollection<ZACC_T001_A>();

            RateEntryDeatils.Clear();

            //CollectionWireSize = CollectionViewSource.GetDefaultView(MCTemp.WireSize.ToList());
            //CollectionWireType = CollectionViewSource.GetDefaultView(MCTemp.WireType.ToList());
            //CollectionBallType = CollectionViewSource.GetDefaultView(MCTemp.BallType.ToList());
            //CollectionTipLength = CollectionViewSource.GetDefaultView(MCTemp.TipLength.ToList());


            _dataGridCollection.Refresh();

            int Monthindex = 0; Monthindex = System.DateTime.Now.Month;
            int Temp_Year = 0; Temp_Year = System.DateTime.Now.Year;
            int New_Monthindex = 0; New_Monthindex = Monthindex;
            int New_Temp_Year = 0; New_Temp_Year = Temp_Year;
            if (Monthindex == 1)
            {
                Monthindex = 12;
                Temp_Year = Temp_Year - 1;
            }
            else
            {
                Monthindex = Monthindex - 1;
                Temp_Year = Temp_Year - 0;
            }
            SelectedZACC_T001_A.Pre_mon = DateTimeFormatInfo.CurrentInfo.GetMonthName(Monthindex);
            SelectedZACC_T001_A.Pre_yr = Convert.ToString(Temp_Year);
            SelectedZACC_T001_A.New_mon = DateTimeFormatInfo.CurrentInfo.GetMonthName(New_Monthindex);
            SelectedZACC_T001_A.New_yr = Convert.ToString(New_Temp_Year);
            SelectedZACC_T001_A.client = AppSessionState.client;
        }
        protected override void OnRemoveAction(InquiryActionResult<ZACC_T001_A> result)
        {
            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //showMessageService.ButtonSetup = DialogButton.Ok;
            //showMessageService.Caption = "Delete Changes";
            //showMessageService.Text =
            //    String.Format(
            //        "This record will delete forever '{0}'",
            //            this.Title);

            //if (showMessageService.ShowMessage() == DialogResult.Ok)
            //{                

            //    this.SelectedZACC_T001_A.EndEdit();
            //    ObjectSerializationService objSer = new ObjectSerializationService();
            //    SelectedZACC_T001_A.XmlDataDocument_ZACC_T001_A = objSer.ObjectToXML(GoodsDetails);
            //    string xdoc = objSer.ObjectToXML(SelectedZACC_T001_A);
            //    string response = repository.Delete(xdoc, "ILDChart", "CustomerRelation");
            //    SelectedList = new List<ZACC_T001_A>();
            //    SelectedList.Add(SelectedZACC_T001_A);
            //    GoodsDetails = new ObservableCollection<ZACC_T001_A>(SelectedList);
            //    _dataGridCollection.Refresh();
            //    SelectedZACC_T001_A.start_dt = DateTime.Now.Date;    
            //}
        }
        protected override void OnDiscardAction(InquiryActionResult<ZACC_T001_A> result)
        {
            SelectedZACC_T001_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZACC_T001_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZACC_T001_A> result)
        {
            SelectedList = SelectedList;
            SelectedZACC_T001_A = SelectedZACC_T001_A;
        }
        protected override void OnHelpAction(InquiryActionResult<ZACC_T001_A> result)
        {
            SelectedList = SelectedList;
            SelectedZACC_T001_A = SelectedZACC_T001_A;
        }
        protected override void OnPrintAction(InquiryActionResult<ZACC_T001_A> result)
        {
            SelectedList = SelectedList;
            SelectedZACC_T001_A = SelectedZACC_T001_A;

            // MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZACC_T001_A>(MC, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "PurchaseOrder", 0, "");
            //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ZACC_T001_A>(MCTemp, "ZACC_T001_A_Data", "ILDChart", "CustomerRelation", "RPTINK", AppSessionState.LocationID, SelectedZACC_T001_A.start_dt.ToString());
            //RPTDetails = MCTemp.RPTINK;
            //object objDS = new object();
            //objDS = MCTemp.RPTINK;
            //ReportManager ReportManager = new ReportingServices.ReportManager();
            //if (SelectedZACC_T001_A.ReportType == "Ink Chart")
            //{
            //    //Ink chart
            //    ReportManager.DisplayReport(objDS, "DSILDInk", "\\CustomerRelation\\Rpt_ILD_Ink.rdlc");
            //}
            //else if (SelectedZACC_T001_A.ReportType == "Ball Chart")
            //{
            //    //Ball Chart
            //    ReportManager.DisplayReport(objDS, "DsILDBall", "\\CustomerRelation\\Rpt_ILD_Ball.rdlc");
            //}
            //else if (SelectedZACC_T001_A.ReportType == "Diamensional Chart")
            //{
            //    //Diamensional Chart
            //    ReportManager.DisplayReport(objDS, "DsILDDiamensional", "\\CustomerRelation\\Rpt_ILD_Diamensional.rdlc");
            //}
            //else if (SelectedZACC_T001_A.ReportType == "Report")
            //{
            //    if (AppSessionState.LocationID == 1)
            //    {
            //        ReportManager.DisplayReport(objDS, "DsILDReport1", "\\CustomerRelation\\RPT_ILDProcessReportForUnit1.rdlc");
            //    }
            //    else if (AppSessionState.LocationID == 2)
            //    {
            //        ReportManager.DisplayReport(objDS, "DsILDReport1", "\\CustomerRelation\\RPT_ILDProcessReportForUnit2.rdlc");
            //    }
            //    else if (AppSessionState.LocationID == 3)
            //    {
            //        ReportManager.DisplayReport(objDS, "DsILDReport1", "\\CustomerRelation\\RPT_ILDProcessReportForUnit3.rdlc");
            //    }
            //}
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZACC_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZACC_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZACC_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZACC_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZACC_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For Wire Size
        private void FilterCollectionWireSize()
        {
            if (_CollectionWireSize != null)
            {
                _CollectionWireSize.Refresh();
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
        public bool FilterWireSize(object obj)
        {
            var data = obj as ZACC_T001_WireSize;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireSize))
                {
                    return (data.WireSize != null && data.WireSize.ToString().ToLower().Contains(_filterStringWireSize.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Wire Type
        private void FilterCollectionWireType()
        {
            if (_CollectionWireType != null)
            {
                _CollectionWireType.Refresh();
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
        public bool FilterWireType(object obj)
        {
            var data = obj as ZACC_T001_WireType;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireType))
                {
                    return (data.WireType != null && data.WireType.ToString().ToLower().Contains(_filterStringWireType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Ball Type
        private void FilterCollectionBallType()
        {
            if (_CollectionBallType != null)
            {
                _CollectionBallType.Refresh();
            }
        }
        public string FilterStringBallType
        {
            get { return _filterStringBallType; }
            set
            {
                _filterStringBallType = value;
                RaisePropertyChanged("FilterStringBallType");
                FilterCollectionBallType();
            }
        }
        public bool FilterBallType(object obj)
        {
            var data = obj as ZACC_T001_BallType;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallType))
                {
                    return (data.BallType != null && data.BallType.ToString().ToLower().Contains(_filterStringBallType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For TipLength
        private void FilterCollectionTipLength()
        {
            if (_CollectionTipLength != null)
            {
                _CollectionTipLength.Refresh();
            }
        }
        public string FilterStringTipLength
        {
            get { return _filterStringTipLength; }
            set
            {
                _filterStringTipLength = value;
                RaisePropertyChanged("FilterStringTipLength");
                FilterCollectionTipLength();
            }
        }
        public bool FilterTipLength(object obj)
        {
            var data = obj as ZACC_T001_TipLength;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTipLength))
                {
                    return (data.TipLength != null && data.TipLength.ToString().ToLower().Contains(_filterStringTipLength.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Pre_Year
        private void FilterCollectionPre_Year()
        {
            if (_CollectionPre_Year != null)
            {
                _CollectionPre_Year.Refresh();
            }
        }
        public string FilterStringPre_Year
        {
            get { return _filterStringPre_Year; }
            set
            {
                _filterStringPre_Year = value;
                RaisePropertyChanged("FilterStringPre_Year");
                FilterCollectionPre_Year();
            }
        }
        public bool FilterPre_Year(object obj)
        {
            var data = obj as ZACC_T001_Pre_Year;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPre_Year))
                {
                    return (data.Pre_Year != null && data.Pre_Year.ToString().ToLower().Contains(_filterStringPre_Year.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion



        #region Filters For Unit
        private void FilterCollectionUnit()
        {
            if (_CollectionUnit != null)
            {
                _CollectionUnit.Refresh();
            }
        }
        public string FilterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("FilterStringUnit");
                FilterCollectionUnit();
            }
        }
        public bool FilterUnit(object obj)
        {
            var data = obj as ZACC_T001_Unit;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (data.Unit != null && data.Unit.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
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
            var data = obj as ZACC_T001_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    //return (data.ref_doc != null && data.ref_doc.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.post_date != null && data.post_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.PlantName != null && data.PlantName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.Dept_Name != null && data.Dept_Name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.notes != null && data.notes.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.Req_Name != null && data.Req_Name.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        private bool ValidateControls()
        {
            //int cnt = 0;
            try
            {
                if (RateEntryDeatils.Count > 0)
                {
                    int cnt = 0;
                    //foreach (var item in RateEntryDeatils)
                    //{
                    //    var duplicateitem = (from o in RateEntryDeatils
                    //                         where o.wiresz + o.wiretp + o.balltp + o.tiplen == item.wiresz + item.wiretp + item.balltp + item.tiplen
                    //                         select o).ToList();
                    //    if (duplicateitem.Count > 1)
                    //    {
                    //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    //        showMessageService.ButtonSetup = DialogButton.Ok;
                    //        showMessageService.Caption = "Message";
                    //        showMessageService.Text = String.Format("Duplicate Parameter Value", this.Title);
                    //        showMessageService.ShowMessage();
                    //        cnt = cnt + 1;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        cnt = 0;
                    //    }
                    //}

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

        private bool ValidateControls123()
        {
            int cnt = 0;
            try
            {
                if (RateEntryDeatils.Count > 0)
                {
                    foreach (var item in RateEntryDeatils)
                    {

                        if (item.wiresz == null || item.wiresz == "" || item.wiretp == null || item.wiretp == "" || item.balltp == null || item.balltp == "" || item.tiplen == null || item.tiplen == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Wire Size, Wire Type, Ball Type, Tip Length Should be Compalsary.", this.Title);
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

        
    }
}
