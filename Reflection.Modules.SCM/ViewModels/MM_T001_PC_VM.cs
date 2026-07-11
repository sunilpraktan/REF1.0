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

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_PC_VM //: WindowViewModel<MM_T001>, INotifyPropertyChanged
    {//
        //bool blNew = true;
        //WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        //WebServiceRepository<MultipleContext_MM_T001> repositoryM = new WebServiceRepository<MultipleContext_MM_T001>();
        //MultipleContext_MM_T001 MCTemp = new MultipleContext_MM_T001();
      
        //private int _dgSelectedIndex;
        //private string _filterString;
        //private string _filterStringMovType;
        //private string _filterStringItem;
        //private string _filterStringItemS;
        //private string _filterStringItemD;
        //private string _filterStringuom;
        //private string _filterStringuomD;
        //private string _filterStringStock;
        //private string _filterStringJobCart;

        //#region . Methods .
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertychanged(string propertyName)
        //{
        //    // take a copy to prevent thread issues
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        //#endregion
        //#region . ICollection .
        //private ICollectionView _dataGridCollection;
        //public ICollectionView DataGridCollection
        //{
        //    get { return _dataGridCollection; }
        //    set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        //}
        //private ICollectionView _CollectionMovType;
        //public ICollectionView CollectionMovType
        //{
        //    get { return _CollectionMovType; }
        //    set { _CollectionMovType = value; RaisePropertychanged("CollectionMovType"); }
        //}
        //private ICollectionView _CollectionItem;
        //public ICollectionView CollectionItem
        //{
        //    get { return _CollectionItem; }
        //    set { _CollectionItem = value; RaisePropertychanged("CollectionItem"); }
        //}
        //private ICollectionView _CollectionItemS;
        //public ICollectionView CollectionItemS
        //{
        //    get { return _CollectionItemS; }
        //    set { _CollectionItemS = value; RaisePropertychanged("CollectionItemS"); }
        //}
        //private ICollectionView _CollectionItemD;
        //public ICollectionView CollectionItemD
        //{
        //    get { return _CollectionItemD; }
        //    set { _CollectionItemD = value; RaisePropertychanged("CollectionItemD"); }
        //}
        //private ICollectionView _uomCollection;
        //public ICollectionView uomCollection
        //{
        //    get { return _uomCollection; }
        //    set
        //    {
        //        _uomCollection = value;

        //        RaisePropertychanged("uomCollection");
        //    }
        //}
        //private ICollectionView _uomCollectionD;
        //public ICollectionView uomCollectionD
        //{
        //    get { return _uomCollectionD; }
        //    set
        //    {
        //        _uomCollectionD = value;

        //        RaisePropertychanged("uomCollectionD");
        //    }
        //}
        //private ICollectionView _itemBatches;//list of batches of selected item in Item Details
        //public ICollectionView itemBatches
        //{
        //    get { return _itemBatches; }
        //    set { _itemBatches = value; RaisePropertychanged("itemBatches"); }
        //}

        //private ICollectionView _ParameterCollection;
        //public ICollectionView ParameterCollection
        //{
        //    get { return _ParameterCollection; }
        //    set
        //    {
        //        _ParameterCollection = value;
        //        RaisePropertychanged("ParameterCollection")
        //        ;
        //    }
        //}

        //private ICollectionView _ParameterCollectionDesti;
        //public ICollectionView ParameterCollectionDesti
        //{
        //    get { return _ParameterCollectionDesti; }
        //    set
        //    {
        //        _ParameterCollectionDesti = value;
        //        RaisePropertychanged("ParameterCollectionDesti")
        //        ;
        //    }
        //}

        //private ICollectionView _TotalParameterCollection;
        //public ICollectionView TotalParameterCollection
        //{
        //    get { return _TotalParameterCollection; }
        //    set
        //    {
        //        _TotalParameterCollection = value;
        //        RaisePropertychanged("TotalParameterCollection")
        //       ;
        //    }
        //}
        //private ICollectionView _StockCollection;
        //public ICollectionView StockCollection
        //{
        //    get { return _StockCollection; }
        //    set
        //    {
        //        _StockCollection = value;

        //        RaisePropertychanged("StockCollection");
        //    }
        //}
        //private ICollectionView _JobCartCollection;
        //public ICollectionView JobCartCollection
        //{
        //    get { return _JobCartCollection; }
        //    set
        //    {
        //        _JobCartCollection = value;

        //        RaisePropertychanged("JobCartCollection");
        //    }
        //}
        //#endregion
        //#region . RelayCommand .
        //public RelayCommand<IList> SelectionChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandGoodsIssueDetails
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandMovType
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandItem
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandItemD
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommanduom
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommanduomD
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectedItems
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> DeleteItemCommand
        //{
        //    get;
        //    private set;
        //}
        ////public RelayCommand<IList> selectionItemChanged_command
        ////{
        ////    get;
        ////    private set;
        ////}
        //public RelayCommand<IList> SelectionChangedCommandStock
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> ParameterPopupCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> ParameterPopupCommandDesti
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> CollectionChangedMethod
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> CollectionChangedMethodDesti
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandItemSource
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandJobCart
        //{
        //    get;
        //    private set;
        //}
        //#endregion
        //#region .  .
        //#region MM_T001
        //private List<MM_T001> _SelectedList;
        //public List<MM_T001> SelectedList
        //{
        //    get { return _SelectedList; }
        //    set
        //    {
        //        if (_SelectedList != value)
        //        {
        //            _SelectedList = value;
        //            RaisePropertychanged("SelectedList");
        //        }
        //    }
        //}
        //private MM_T001 _SelectedMM_T001;
        //public MM_T001 SelectedMM_T001
        //{
        //    get
        //    {
        //        this.ErrorExist = _SelectedMM_T001.HasErrors;
        //        return _SelectedMM_T001;
        //    }
        //    set
        //    {
        //        if (_SelectedMM_T001 != value)
        //        {
        //            _SelectedMM_T001 = value;
        //            //this.ErrorExist = _SelectedMM_T001.HasErrors;
        //            RaisePropertychanged("SelectedMM_T001");
        //            value.BeginEdit();
        //        }
        //    }
        //}
        //#endregion
        //#region MM_T001_A
        //private static ObservableCollection<MM_T001_A> _GoodsA = new ObservableCollection<MM_T001_A>();
        //public ObservableCollection<MM_T001_A> GoodsA
        //{
        //    get { return _GoodsA; }
        //    set
        //    {
        //        if (_GoodsA != value)
        //        {
        //            _GoodsA = value;

        //            RaisePropertychanged("GoodsA");
        //        }
        //    }
        //}
        //public MM_T001_A _SelectedMM_T001_A { get; private set; }
        //public MM_T001_A SelectedMM_T001_A
        //{
        //    get { return _SelectedMM_T001_A; }
        //    set
        //    {
        //        if (_SelectedMM_T001_A != value)
        //        {
        //            _SelectedMM_T001_A = value;
        //            RaisePropertychanged("SelectedMM_T001_A");
        //            // value.BeginEdit();
        //        }
        //    }
        //}
        //private List<MM_T001_A> _SelectedMM_T001_A_List;
        //public List<MM_T001_A> SelectedMM_T001_A_List
        //{
        //    get
        //    {
        //        return _SelectedMM_T001_A_List;
        //    }
        //    set
        //    {
        //        _SelectedMM_T001_A_List = value;
        //        RaisePropertychanged("SelectedMM_T001_A_List");
        //    }
        //}

        //#endregion
        //#region MM_M004_Popup
        //public MM_M004_Popup _Selectedmov_tpDtls { get; private set; }
        //public MM_M004_Popup Selectedmov_tpDtls
        //{
        //    get { return _Selectedmov_tpDtls; }
        //    set
        //    {
        //        if (_Selectedmov_tpDtls != value)
        //        {
        //            _Selectedmov_tpDtls = value;
        //            RaisePropertychanged("Selectedmov_tpDtls");
        //        }
        //    }
        //}
        //private ObservableCollection<MM_M004_Popup> _mov_tpList;
        //public ObservableCollection<MM_M004_Popup> mov_tpList
        //{
        //    get { return _mov_tpList; }
        //    set
        //    {
        //        _mov_tpList = value;
        //        RaisePropertychanged("mov_tpList");
        //    }
        //}

        //private List<MM_M004_Popup> _Selectedmov_tpList;
        //public List<MM_M004_Popup> Selectedmov_tpList
        //{
        //    get { return _Selectedmov_tpList; }
        //    set
        //    {
        //        if (_Selectedmov_tpList != value)
        //        {
        //            _Selectedmov_tpList = value;

        //            //if (PropertyChanged != null)
        //            //{
        //            RaisePropertychanged("Selectedmov_tpList");
        //            //}
        //        }
        //    }
        //}
        //#endregion
        ////#region ADM_M022_PopUp_Inst
        ////public ADM_M022_PopUp_Inst _SelectedItemsDtls { get; private set; }
        ////public ADM_M022_PopUp_Inst SelectedItemsDtls
        ////{
        ////    get { return _SelectedItemsDtls; }
        ////    set
        ////    {
        ////        if (_SelectedItemsDtls != value)
        ////        {
        ////            _SelectedItemsDtls = value;
        ////            RaisePropertychanged("SelectedItemsDtls");
        ////        }
        ////    }
        ////}
        ////private ObservableCollection<ADM_M022_PopUp_Inst> _ItemsList;
        ////public ObservableCollection<ADM_M022_PopUp_Inst> ItemsList
        ////{
        ////    get { return _ItemsList; }
        ////    set
        ////    {
        ////        _ItemsList = value;
        ////        RaisePropertychanged("ItemsList");
        ////    }
        ////}
        ////private List<ADM_M022_PopUp_Inst> _SelectedItemsList;
        ////public List<ADM_M022_PopUp_Inst> SelectedItemsList
        ////{
        ////    get { return _SelectedItemsList; }
        ////    set
        ////    {
        ////        if (_SelectedItemsList != value)
        ////        {
        ////            _SelectedItemsList = value;
        ////            RaisePropertychanged("SelectedItemsList");                  
        ////        }
        ////    }
        ////}
        ////#endregion
        //#region ADM_M038_B_PopUp
        //public Reflection.BusinessEntity.ADM_M038_B_PopUp _SelectedUomDtls { get; private set; }
        //public Reflection.BusinessEntity.ADM_M038_B_PopUp SelectedUomDtls
        //{
        //    get { return _SelectedUomDtls; }
        //    set
        //    {
        //        if (_SelectedUomDtls != value)
        //        {
        //            _SelectedUomDtls = value;
        //            RaisePropertychanged("SelectedUomDtls");
        //        }
        //    }
        //}
        //private ObservableCollection<Reflection.BusinessEntity.ADM_M038_B_PopUp> _UomList;
        //public ObservableCollection<Reflection.BusinessEntity.ADM_M038_B_PopUp> UomList
        //{
        //    get { return _UomList; }
        //    set
        //    {
        //        _UomList = value;
        //        RaisePropertychanged("UomList");
        //    }
        //}

        //private List<Reflection.BusinessEntity.ADM_M038_B_PopUp> _SelectedUomList;
        //public List<Reflection.BusinessEntity.ADM_M038_B_PopUp> SelectedUomList
        //{
        //    get { return _SelectedUomList; }
        //    set
        //    {
        //        if (_SelectedUomList != value)
        //        {
        //            _SelectedUomList = value;

        //            //if (PropertyChanged != null)
        //            //{
        //            RaisePropertychanged("SelectedUomList");
        //            //}
        //        }
        //    }
        //}
        //#endregion
        ////#region MM_S003_PopUp
        ////private MM_S003_PopUp _SelectedStock;
        ////public MM_S003_PopUp SelectedStock
        ////{
        ////    get { return _SelectedStock; }
        ////    set
        ////    {
        ////        if (_SelectedStock != value)
        ////        {
        ////            _SelectedStock = value;
        ////            RaisePropertychanged("SelectedStock");

        ////        }
        ////    }
        ////}
        ////private List<MM_S003_PopUp> _SelectedListOfStockList;
        ////public List<MM_S003_PopUp> SelectedListOfStockList
        ////{
        ////    get { return _SelectedListOfStockList; }
        ////    set
        ////    {
        ////        if (_SelectedListOfStockList != value)
        ////        {
        ////            _SelectedListOfStockList = value;
        ////            RaisePropertychanged("SelectedListOfStockList");
        ////        }
        ////    }
        ////}
        ////private ObservableCollection<MM_S003_PopUp> _StockDtls;
        ////public ObservableCollection<MM_S003_PopUp> StockDtls
        ////{
        ////    get { return _StockDtls; }
        ////    set
        ////    {
        ////        _StockDtls = value;
        ////        RaisePropertychanged("StockDtls");
        ////    }
        ////}


        ////#endregion
        //#region PPC_T001_PopUp
        //private PPC_T001_PopUp _SelectedJobCart;
        //public PPC_T001_PopUp SelectedJobCart
        //{
        //    get { return _SelectedJobCart; }
        //    set
        //    {
        //        if (_SelectedJobCart != value)
        //        {
        //            _SelectedJobCart = value;
        //            RaisePropertychanged("SelectedJobCart");

        //        }
        //    }
        //}
        //private List<PPC_T001_PopUp> _SelectedListOfJobCartList;
        //public List<PPC_T001_PopUp> SelectedListOfJobCartList
        //{
        //    get { return _SelectedListOfJobCartList; }
        //    set
        //    {
        //        if (_SelectedListOfJobCartList != value)
        //        {
        //            _SelectedListOfJobCartList = value;
        //            RaisePropertychanged("SelectedListOfJobCartList");
        //        }
        //    }
        //}
        //private ObservableCollection<PPC_T001_PopUp> _JobCartDtls;
        //public ObservableCollection<PPC_T001_PopUp> JobCartDtls
        //{
        //    get { return _JobCartDtls; }
        //    set
        //    {
        //        _JobCartDtls = value;
        //        RaisePropertychanged("JobCartDtls");
        //    }
        //}


        //#endregion
        //#region ParameterList
        //private List<ADM_M034_PopUp> _SelectedParmeters = new List<ADM_M034_PopUp>();
        //public List<ADM_M034_PopUp> SelectedParmeters
        //{
        //    get { return _SelectedParmeters; }
        //    set
        //    {
        //        if (_SelectedParmeters != value)
        //        {
        //            _SelectedParmeters = value;

        //            RaisePropertychanged("SelectedParmeters");
        //        }
        //    }
        //}

        //private ObservableCollection<ADM_M034_PopUp> _ParamList;
        //public ObservableCollection<ADM_M034_PopUp> ParamList
        //{
        //    get { return _ParamList; }
        //    set
        //    {
        //        _ParamList = value;
        //        RaisePropertychanged("ParamList");
        //    }
        //}

        //ObservableCollection<ADM_M034_PopUp> _SelectedParmetersFrom = new ObservableCollection<ADM_M034_PopUp>();
        //public ObservableCollection<ADM_M034_PopUp> SelectedParmetersFrom
        //{
        //    get { return _SelectedParmetersFrom; }
        //    set
        //    {
        //        if (_SelectedParmetersFrom != value)
        //        {
        //            _SelectedParmetersFrom = value;

        //            this.RaisePropertychanged("SelectedParmetersFrom");
        //        }
        //    }
        //}

        //ObservableCollection<ADM_M034_PopUp> _TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
        //public ObservableCollection<ADM_M034_PopUp> TempParmeters
        //{
        //    get { return _TempParmeters; }
        //    set
        //    {
        //        if (_TempParmeters != value)
        //        {
        //            _TempParmeters = value;

        //            this.RaisePropertychanged("TempParmeters");
        //        }
        //    }
        //}

        //private ObservableCollection<ADM_M030_P> _ParamValuesList;
        //public ObservableCollection<ADM_M030_P> ParamValuesList
        //{
        //    get { return _ParamValuesList; }
        //    set
        //    {
        //        _ParamValuesList = value;
        //        RaisePropertychanged("ParamValuesList");
        //    }
        //}

        //private ObservableCollection<ADM_M030_P> _ParamitemList;
        //public ObservableCollection<ADM_M030_P> ParamitemList
        //{
        //    get { return _ParamitemList; }
        //    set
        //    {
        //        _ParamitemList = value;
        //        RaisePropertychanged("ParamitemList");
        //    }
        //}

        //private ObservableCollection<ADM_M030_P> _ParamitemList1;
        //public ObservableCollection<ADM_M030_P> ParamitemList1
        //{
        //    get { return _ParamitemList1; }
        //    set
        //    {
        //        _ParamitemList1 = value;
        //        RaisePropertychanged("ParamitemList1");
        //    }
        //}
        //private ObservableCollection<ADM_M030_P> _ParamclearList;
        //public ObservableCollection<ADM_M030_P> ParamclearList
        //{
        //    get { return _ParamclearList; }
        //    set
        //    {
        //        _ParamclearList = value;
        //        RaisePropertychanged("ParamclearList");
        //    }
        //}

        //List<ADM_M030_P> _FluteList = new List<ADM_M030_P>();
        //public List<ADM_M030_P> FluteList
        //{
        //    get { return _FluteList; }
        //    set
        //    {
        //        if (_FluteList != value)
        //        {
        //            _FluteList = value;

        //            RaisePropertychanged("FluteList");
        //        }
        //    }
        //}
        //public string _Flute;
        //public string Flute
        //{
        //    get
        //    {
        //        return this._Flute;
        //    }
        //    set
        //    {
        //        if ((this._Flute != value))
        //        {
        //            this._Flute = value;
        //            RaisePropertychanged("Flute");
        //        }
        //    }
        //}

        //List<ADM_M030_P> _IndexList = new List<ADM_M030_P>();
        //public List<ADM_M030_P> IndexList
        //{
        //    get { return _IndexList; }
        //    set
        //    {
        //        if (_IndexList != value)
        //        {
        //            _IndexList = value;

        //            RaisePropertychanged("IndexList");
        //        }
        //    }
        //}

        //public string _Shade;
        //public string Shade
        //{
        //    get
        //    {
        //        return this._Shade;
        //    }
        //    set
        //    {
        //        if ((this._Shade != value))
        //        {
        //            this._Shade = value;
        //            RaisePropertychanged("Shade");
        //        }
        //    }
        //}
        //List<ParameterSelection> _MakeList = new List<ParameterSelection>();
        //public List<ParameterSelection> MakeList
        //{
        //    get { return _MakeList; }
        //    set
        //    {
        //        if (_MakeList != value)
        //        {
        //            _MakeList = value;

        //            RaisePropertychanged("MakeList");
        //        }
        //    }
        //}
        //public string _Make;
        //public string Make
        //{
        //    get
        //    {
        //        return this._Make;
        //    }
        //    set
        //    {
        //        if ((this._Make != value))
        //        {
        //            this._Make = value;
        //            RaisePropertychanged("Make");
        //        }
        //    }
        //}
        //List<ADM_M033> _ColourList = new List<ADM_M033>();
        //public List<ADM_M033> ColourList
        //{
        //    get { return _ColourList; }
        //    set
        //    {
        //        if (_ColourList != value)
        //        {
        //            _ColourList = value;

        //            RaisePropertychanged("ColourList");
        //        }
        //    }
        //}
        //public string _Colour;
        //public string Colour
        //{
        //    get
        //    {
        //        return this._Colour;
        //    }
        //    set
        //    {
        //        if ((this._Colour != value))
        //        {
        //            this._Colour = value;
        //            RaisePropertychanged("Colour");
        //        }
        //    }
        //}

        //#endregion
        //public int dgSelectedIndex
        //{
        //    get
        //    {
        //        return _dgSelectedIndex;
        //    }
        //    set
        //    {
        //        if (_dgSelectedIndex != value)
        //        {
        //            _dgSelectedIndex = value;
        //            RaisePropertychanged("dgSelectedIndex");
        //        }
        //    }
        //}

        //MultipleContext_MM_T001 _MC = new MultipleContext_MM_T001();
        //public MultipleContext_MM_T001 MC
        //{
        //    get { return _MC; }
        //    set
        //    {
        //        if (_MC != value)
        //        {
        //            _MC = value;

        //            RaisePropertychanged("MC");
        //        }
        //    }
        //}
        //#endregion
        //#region . Constructor .
        //public MM_T001_PC_VM()
        //    : base()
        //{
        //    SelectedList = new List<MM_T001>();
        //    SelectedMM_T001 = new MM_T001();

        //    SelectedMM_T001_A = new MM_T001_A();
        //    GoodsA = new ObservableCollection<MM_T001_A>();
        //    Selectedmov_tpList = new List<MM_M004_Popup>();
        //    // SelectedItemsList = new List<ADM_M022_PopUp_Inst>();

        //    TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
        //    FluteList = new List<ADM_M030_P>();
        //    IndexList = new List<ADM_M030_P>();
        //    MakeList = new List<ParameterSelection>();
        //    ColourList = new List<ADM_M033>();
        //    SelectedParmeters = new List<ADM_M034_PopUp>();
        //    ParamValuesList = new ObservableCollection<ADM_M030_P>();
        //    ParamitemList = new ObservableCollection<ADM_M030_P>();


        //    MC = new MultipleContext_MM_T001();
        //    SelectedMM_T001.ValidateAsync().Wait();

        //    SelectionChangedCommand = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }
        //        GetSelectedList(items);
        //    });
        //    SelectionChangedCommandGoodsIssueDetails = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedGoodsIssueDetails(items);
        //    });

        //    SelectionChangedCommandMovType = new RelayCommand<IList>(
        //     items =>
        //     {
        //         if (items == null)
        //         {
        //             return;
        //         }

        //         GetSelectedMovtype(items);
        //     });
        //     SelectionChangedCommandItem = new RelayCommand<IList>(
        //     items =>
        //     {
        //         if (items == null)
        //         {
        //             return;
        //         }

        //         GetSelectedItem(items);
        //     });
        //    SelectionChangedCommandItemD = new RelayCommand<IList>(
        //     items =>
        //     {
        //         if (items == null)
        //         {
        //             return;
        //         }

        //         GetSelectedItemD(items);
        //     });
        //    SelectionChangedCommanduom = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedUomDetails(items);
        //    });
        //    SelectionChangedCommanduomD = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedUomDetailsD(items);
        //    });
        //    SelectionChangedCommandItemSource = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedSourceItemDetails(items);
        //    });

        //    SelectionChangedCommandStock = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedBatchDetails(items);
        //    });
        //    SelectionChangedCommandJobCart = new RelayCommand<IList>(
        //     items =>
        //     {
        //         if (items == null)
        //         {
        //             return;
        //         }

        //         GetSelectedJobCart(items);
        //     });
        //    DeleteItemCommand = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } Deleteitemfromdetails(items); });
        //    CollectionChangedMethod = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } CollectionChanged(items); });
        //    CollectionChangedMethodDesti = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } CollectionChangedDesti(items); });
        //    ParameterPopupCommand = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } ParameterPopupClosed(items); });
        //    ParameterPopupCommandDesti = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } ParameterPopupClosedDesti(items); });
        //    //selectionItemChanged_command = new RelayCommand<IList>(
        //    //   items => { if (items == null) { return; } selectionItemChanged(items); });

        //    SelectedMM_T001.doc_date = DateTime.Now;
        //    SelectedMM_T001.doc_cat = "";
        //    SelectedMM_T001.doc_code = "PC";
        //    LoadInitialData();
        //    SelectedMM_T001.source_doc = "";
        //    SelectedMM_T001.vendor_name = "";
        //    SelectedMM_T001.mov_tp = "";
        //    //GoodsA[dgSelectedIndex].qty = 0;
        //    SelectedMM_T001.mov_name = "";        
        //    SelectedMM_T001.ref_doc = "";
        //    // GoodsA[dgSelectedIndex].item_id=""; //SelectedMM_T001.source_doc = "";
        //    //SelectedMM_T001.source_doc = "";
        //}
        //private void 
        //    LoadInitialData()
        //{
        //    try
        //    {
        //        string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString();
        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_T001>(MC, "MM_T001_Data", "ProductConversion", "SCM", "LoadProdConv",0, company);
        //        SelectedList = MC.Goods;

        //        //parameter_value_list = MC.parameter_value_list;

        //        GoodsA = new ObservableCollection<MM_T001_A>();

        //        CollectionMovType = CollectionViewSource.GetDefaultView(MC.MovType);
        //        CollectionMovType.Filter = new Predicate<object>(FilterMovType);

        //        DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
        //        DataGridCollection.Filter = new Predicate<object>(Filter);

        //        uomCollection = CollectionViewSource.GetDefaultView(MC.uom);
        //        uomCollection.Filter = new Predicate<object>(uomFilter);

        //        CollectionItem = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        CollectionItem.Filter = new Predicate<object>(FilterJobCart);

        //        uomCollectionD = CollectionViewSource.GetDefaultView(MC.uom);
        //        uomCollectionD.Filter = new Predicate<object>(uomFilterD);               

        //        JobCartCollection = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        JobCartCollection.Filter = new Predicate<object>(FilterJobCart);

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
        //#endregion
        //#region . User Defined Funtion .
        //private void GetSelectedList(IList DataList)
        //{
        //    try
        //    {
        //        IList list = DataList as IList;

        //        List<MM_T001> SelectedItemsList2 = list.Cast<MM_T001>().ToList();

        //        if (SelectedItemsList2.Count > 0)
        //        {
        //            SelectedMM_T001 = (MM_T001)SelectedItemsList2[0];
        //            MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_T001>(MCTemp, "MM_T001_A_Data", "ProductConversion", "SCM", "Load_ProdConv_Detail", 0, SelectedMM_T001.id.ToString());
                    
                    
        //            if (SelectedMM_T001 != null)
        //            {
        //                //ObservableCollection<MM_T001_A> result = (ObservableCollection<MM_T001_A>)MCTemp.GoodsA.Cast<MM_T001_A>();

        //                //IEnumerable<MM_T001_A> barEnumerable =
        //                //        from data in result
        //                //        where data.doc_no == SelectedMM_T001.doc_no
        //                //        select data;

        //                //GoodsA = new ObservableCollection<MM_T001_A>(barEnumerable);    
        //                MC.GoodsA = MCTemp.GoodsA;
        //                GoodsA = MCTemp.GoodsA;         
        //            }
        //            blNew = false;
        //            generateDesc();
        //            updateDescription();
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
        //private void generateDesc()
        //{
        //    string parametervale = "";
        //    string parametercode = "";


        //    for (int y = 0; y < GoodsA.Count; y++)
        //    {
        //        try
        //        {
        //            parametervale = "";
        //            parametercode = "";
        //            string stockingunit = GoodsA[y].sku;
        //            string[] tokens = stockingunit.Split('/');
        //            int count = tokens.Length;
        //            while (count > 0)
        //            {
        //                string value = tokens[count - 1];
        //                if (value != "")
        //                {
        //                    var myItem = (from o in MC.parameter_value_list
        //                                  where o.code == Convert.ToInt32(value)
        //                                  select o).ToList();
        //                    if (parametervale == "")
        //                    {
        //                        parametervale = myItem[0].Type + ":" + myItem[0].Name;
        //                        parametercode = myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
        //                    }
        //                    else
        //                                                                                                                                       {
        //                        parametervale = parametervale + "\t:" + myItem[0].Type + ":" + myItem[0].Name;
        //                        parametercode = parametercode + "\t:" + myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
        //                    }
        //                }
        //                count = count - 1;
        //            }
        //            if (GoodsA[y].item_Name != "" || GoodsA[y] != null)
        //            {
        //                string t_itemname;
        //                if (GoodsA[y].item_Name.Contains("\t"))
        //                {
        //                    t_itemname = GoodsA[y].item_Name.Substring(0, GoodsA[y].item_Name.IndexOf("\t"));
        //                }
        //                else
        //                {
        //                    t_itemname = GoodsA[y].item_Name;
        //                }
        //                GoodsA[y].Description = t_itemname + "\t:" + parametercode;
        //                GoodsA[y].item_Name = t_itemname + "\t:" + parametervale;
        //            }
        //        }
        //        catch
        //        {

        //        }

        //    }
        //}     
        //private void GetSelectedGoodsIssueDetails(IList IssueList)
        //{
        //    IList list = IssueList as IList;

        //    List<MM_T001> SelectedItemsList2 = list.Cast<MM_T001>().ToList();

        //    if (SelectedItemsList2.Count > 0)
        //    {
        //        SelectedMM_T001 = (MM_T001)SelectedItemsList2[0];

        //    }
        //    if (SelectedMM_T001 != null)
        //    {
        //        ObservableCollection<MM_T001_A> result = (ObservableCollection<MM_T001_A>)MC.GoodsA.Cast<MM_T001_A>();
        //        IEnumerable<MM_T001_A> barEnumerable =
        //                from data in result
        //                where data.id == SelectedMM_T001.id
        //                select data;
        //        GoodsA = new ObservableCollection<MM_T001_A>(barEnumerable);
        //        updateDescription();
        //    }
        //    blNew = false;
        //}      
        //private void GetSelectedUomDetails(IList UomList)
        //{
        //    try
        //    {
        //        IList list = UomList as IList;
        //        List<ADM_M038_B_PopUp> SelectedUomDetailsTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

        //        if (SelectedUomDetailsTemp.Count > 0 && dgSelectedIndex != -1)
        //        {
        //            var q = GoodsA.Where(X => X.unit_code == SelectedUomDetailsTemp[0].unit_code).FirstOrDefault();

        //            if (q != null)
        //            {
        //                if (GoodsA.Count() > dgSelectedIndex)
        //                {
        //                    GoodsA[dgSelectedIndex].unit_code = SelectedUomDetailsTemp[0].unit_code;
        //                    GoodsA[dgSelectedIndex].unit_Name = SelectedUomDetailsTemp[0].unit_name;
        //                }
        //            }
        //            else
        //            {
        //                if (GoodsA.Count() <= dgSelectedIndex)
        //                {
        //                    GoodsA.Add(new MM_T001_A() { unit_code = SelectedUomDetailsTemp[0].unit_code, unit_Name = SelectedUomDetailsTemp[0].unit_name });
        //                }
        //                else
        //                {
        //                    GoodsA[dgSelectedIndex].unit_code = SelectedUomDetailsTemp[0].unit_code;
        //                    GoodsA[dgSelectedIndex].unit_Name = SelectedUomDetailsTemp[0].unit_name;
        //                }
        //            }
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
        //private void GetSelectedUomDetailsD(IList UomList)
        //{
        //    try
        //    {
        //        IList list = UomList as IList;
        //        List<ADM_M038_B_PopUp> SelectedUomDetailsTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

        //        if (SelectedUomDetailsTemp.Count > 0 && dgSelectedIndex != -1)
        //        {
        //            var q = GoodsA.Where(X => X.ri_unit_cd == SelectedUomDetailsTemp[0].unit_code).FirstOrDefault();

        //            if (q != null)
        //            {
        //                if (GoodsA.Count() > dgSelectedIndex)
        //                {
        //                    GoodsA[dgSelectedIndex].ri_unit_cd = SelectedUomDetailsTemp[0].unit_code;
        //                    GoodsA[dgSelectedIndex].unit_NameD = SelectedUomDetailsTemp[0].unit_name;
        //                }
        //            }
        //            else
        //            {
        //                if (GoodsA.Count() <= dgSelectedIndex)
        //                {
        //                    GoodsA.Add(new MM_T001_A() { ri_unit_cd = SelectedUomDetailsTemp[0].unit_code, unit_NameD = SelectedUomDetailsTemp[0].unit_name });
        //                }
        //                else
        //                {
        //                    GoodsA[dgSelectedIndex].ri_unit_cd = SelectedUomDetailsTemp[0].unit_code;
        //                    GoodsA[dgSelectedIndex].unit_NameD = SelectedUomDetailsTemp[0].unit_name;
        //                }
        //            }
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
        //private void GetSelectedMovtype(IList MovTypeList)
        //{
        //    IList list = MovTypeList as IList;
        //    List<MM_M004_Popup> GetSelectedMovTypeTemp = list.Cast<MM_M004_Popup>().ToList();
        //    if (GetSelectedMovTypeTemp.Count > 0)
        //    {
        //        SelectedMM_T001.mov_tp = GetSelectedMovTypeTemp[0].mov_tp;              
        //    }
        //}
        //private void GetSelectedItem(IList itemList)
        //{
        //    IList list = itemList as IList;
        //    List<PPC_T001_PopUp> GetSelectedItemTemp = list.Cast<PPC_T001_PopUp>().ToList();
        //    if (GetSelectedItemTemp.Count > 0)
        //    {
        //        if (SelectedMM_T001.id == 0)
        //        {
        //            if (GoodsA.Count > 0)
        //            {
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Item Selection";
        //                showMessageService.Text =
        //                    String.Format(
        //                        "If You Change The Item Details Will be removed'{0}'",
        //                            this.Title);

        //                if (showMessageService.ShowMessage() == DialogResult.Ok)
        //                {
        //                    GoodsA = new ObservableCollection<MM_T001_A>();
        //                    SelectedMM_T001.item_code_batchSplit = GetSelectedItemTemp[0].ItemCode;
        //                    SelectedMM_T001.sono = GetSelectedItemTemp[0].so_no;

        //                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_T001>(MC, "MM_T001_Data", "ProductConversion", "SCM", "LoadBatchNo", 0, SelectedMM_T001.item_code_batchSplit);
        //                    if (GoodsA != null)
        //                    {
        //                        var q = GoodsA.Where(X => X.ItemCode == GetSelectedItemTemp[0].ItemCode).FirstOrDefault();
        //                        int x = GoodsA.IndexOf(GoodsA.Where(X => X.ItemCode == GetSelectedItemTemp[0].ItemCode).FirstOrDefault());

        //                        //if (GoodsA.Count == dgSelectedIndex)
        //                        //{
        //                        SelectedJobCart = (PPC_T001_PopUp)GetSelectedItemTemp[0];
        //                        if (GetSelectedItemTemp[0].batch_no == null)
        //                        {
        //                            GoodsA.Add(new MM_T001_A()
        //                            {
        //                                ItemCode = GetSelectedItemTemp[0].ItemCode,
        //                                item_Name = GetSelectedItemTemp[0].description

        //                            });
        //                        }
        //                        else
        //                        {
        //                            GoodsA.Add(new MM_T001_A()
        //                            {
        //                                ItemCode = GetSelectedItemTemp[0].ItemCode

        //                            });
        //                        }
        //                        //}
        //                    }
        //                    StockCollection = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //                    StockCollection.Filter = new Predicate<object>(FilterJobCart);
        //                }
        //            }
        //            else if (GoodsA.Count == 0)
        //            {
        //                SelectedMM_T001.item_code_batchSplit = GetSelectedItemTemp[0].ItemCode;
        //                //SelectedMM_T001.sono = GetSelectedItemTemp[0].so_no;

        //                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_T001>(MC, "MM_T001_Data", "ProductConversion", "SCM", "LoadBatchNo", 0, SelectedMM_T001.item_code_batchSplit);
        //                if (GoodsA != null)
        //                {
        //                    var q = GoodsA.Where(X => X.ItemCode == GetSelectedItemTemp[0].ItemCode).FirstOrDefault();
        //                    int x = GoodsA.IndexOf(GoodsA.Where(X => X.ItemCode == GetSelectedItemTemp[0].ItemCode).FirstOrDefault());
        //                    _dataGridCollection.Refresh();
        //                    //if (GoodsA.Count == 0 )
        //                    //{
        //                    //    SelectedJobCart = (PPC_T001_PopUp)GetSelectedItemTemp[0];
        //                    if (GetSelectedItemTemp[0].batch_no == null)
        //                    {
        //                        GoodsA.Add(new MM_T001_A()
        //                        {
        //                            ItemCode = GetSelectedItemTemp[0].ItemCode,
        //                            item_Name = GetSelectedItemTemp[0].description
        //                        });
        //                    }
        //                    else
        //                    {
        //                        GoodsA.Add(new MM_T001_A()
        //                        {
        //                            ItemCode = GetSelectedItemTemp[0].ItemCode

        //                        });
        //                    }
        //                    //}
        //                }
        //                StockCollection = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //                StockCollection.Filter = new Predicate<object>(FilterJobCart);
        //            }
        //        }
        //    }
        //}
        //private void GetSelectedItemD(IList itemList)
        //{
        //    try
        //    {
        //        if (dgSelectedIndex != -1 && itemList.Count > 0)
        //        {
        //            IList list = itemList as IList;
        //            List<PPC_T001_PopUp> SelectedItemDetailsTemp = list.Cast<PPC_T001_PopUp>().ToList();
        //            if (SelectedItemDetailsTemp.Count > 0)
        //            {
        //                if (GoodsA != null)
        //                {
        //                    var q = GoodsA.Where(X => X.ri_item == SelectedItemDetailsTemp[0].ItemCode).FirstOrDefault();
        //                    int x = GoodsA.IndexOf(GoodsA.Where(X => X.ri_item == SelectedItemDetailsTemp[0].ItemCode).FirstOrDefault());

        //                    if (GoodsA.Count == dgSelectedIndex)
        //                    {

        //                        SelectedJobCart = (PPC_T001_PopUp)SelectedItemDetailsTemp[0];
        //                        GoodsA.Add(new MM_T001_A()
        //                        {
        //                            //ri_item = SelectedItemDetailsTemp[0].item_id,
        //                            ri_item = Convert.ToString(SelectedItemDetailsTemp[0].item_srno),
        //                            item_codeD = SelectedItemDetailsTemp[0].ItemCode,
        //                            item_NameD = SelectedItemDetailsTemp[0].description,
        //                            DescriptionDesti = SelectedItemDetailsTemp[0].description,
        //                            ri_unit_cd = SelectedItemDetailsTemp[0].unit_name,
        //                            unit_NameD = SelectedItemDetailsTemp[0].unit_name,
        //                            Stockable = Convert.ToBoolean(SelectedItemDetailsTemp[0].Stockable),
        //                            ri_sku = SelectedItemDetailsTemp[0].sku,                                    
        //                            SubCategCod = SelectedItemDetailsTemp[0].SubCategCod,
        //                            ri_batch_no = SelectedItemDetailsTemp[0].batch_no

        //                        });
        //                        GoodsA.Where(l => l.item_codeD == SelectedItemDetailsTemp[0].ItemCode).ToList().ForEach(i => i.DescriptionDesti = (""));
        //                    }
        //                    else if (SelectedItemDetailsTemp[0].Select == false)//&& GoodsA[x].id == 0
        //                    {
        //                        if (x >= 0)
        //                        {
        //                            GoodsA.RemoveAt(x);
        //                        }
        //                    }
        //                    else if (SelectedItemDetailsTemp[0].Select == true) // && r != null && r >= 0)
        //                    {
        //                        GoodsA[dgSelectedIndex].ri_item = Convert.ToString(SelectedItemDetailsTemp[0].item_srno);
        //                        GoodsA[dgSelectedIndex].item_codeD = SelectedItemDetailsTemp[0].ItemCode;
        //                        GoodsA[dgSelectedIndex].item_NameD = SelectedItemDetailsTemp[0].description;
        //                        GoodsA[dgSelectedIndex].DescriptionDesti = SelectedItemDetailsTemp[0].description;
        //                        GoodsA[dgSelectedIndex].ri_unit_cd = SelectedItemDetailsTemp[0].unit_name;
        //                        GoodsA[dgSelectedIndex].unit_NameD = SelectedItemDetailsTemp[0].unit_name;
        //                        GoodsA[dgSelectedIndex].Stockable = Convert.ToBoolean(SelectedItemDetailsTemp[0].Stockable);
        //                        GoodsA[dgSelectedIndex].SubCategCod = SelectedItemDetailsTemp[0].SubCategCod;
        //                        GoodsA[dgSelectedIndex].ri_sku = SelectedItemDetailsTemp[0].sku;
        //                        GoodsA[dgSelectedIndex].ri_batch_no = SelectedItemDetailsTemp[0].batch_no;

        //                    }
        //                    updateDescription();
        //                }
        //                uomCollection = CollectionViewSource.GetDefaultView(MC.uom);
        //                uomCollection.Filter = new Predicate<object>(uomFilter);
        //                try
        //                {
        //                    MC.JobCart.Where(t => t.ItemCode == GoodsA[dgSelectedIndex - 1].item_codeD).ToList().ForEach(t => t.Select = false);

        //                    //MC.JobCart.Where(t => t.item_id == SelectedItemDetailsTemp[0].item_id && t.Stockable == true).ToList().ForEach(t => t.Select = false);
                            
        //                }
        //                catch
        //                {

        //                }
        //                foreach (var item in GoodsA)
        //                {
        //                    GoodsA.Where(i => i.ri_item == item.ri_item).Where(i => i.ri_sku == item.ri_sku).ToList().ForEach(L => L.stocking_unit1 = item.ri_sku);
        //                }
        //            }
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
        //private void GetSelectedSourceItemDetails(IList itemList)
        //{
        //    try
        //    {
        //        if (dgSelectedIndex != -1 && itemList.Count > 0)
        //        {
        //            IList list = itemList as IList;
        //            List<PPC_T001_PopUp> SelectedItemDetailsTemp = list.Cast<PPC_T001_PopUp>().ToList();
        //            if (SelectedItemDetailsTemp.Count > 0)
        //            {
        //                if (GoodsA != null)
        //                {
        //                    var q = GoodsA.Where(X => X.ItemCode == SelectedItemDetailsTemp[0].ItemCode).FirstOrDefault();
        //                    int x = GoodsA.IndexOf(GoodsA.Where(X => X.ItemCode == SelectedItemDetailsTemp[0].ItemCode).FirstOrDefault());

        //                    if (GoodsA.Count == dgSelectedIndex)
        //                    {

        //                        SelectedJobCart= (PPC_T001_PopUp)SelectedItemDetailsTemp[0];
        //                        GoodsA.Add(new MM_T001_A()
        //                        {
        //                            //item_id = Convert.ToString(SelectedItemDetailsTemp[0].item_srno),
        //                            ItemCode = SelectedItemDetailsTemp[0].ItemCode,                                   
        //                            item_Name = SelectedItemDetailsTemp[0].description,
        //                            Description = SelectedItemDetailsTemp[0].description,
        //                            unit_code = SelectedItemDetailsTemp[0].unit_name,
        //                            unit_Name = SelectedItemDetailsTemp[0].unit_name,
        //                            Stockable = Convert.ToBoolean(SelectedItemDetailsTemp[0].Stockable),
        //                            SubCategCod = SelectedItemDetailsTemp[0].SubCategCod,
        //                            batch_no = SelectedItemDetailsTemp[0].batch_no,
        //                            sku = SelectedItemDetailsTemp[0].sku                                    
        //                        });

        //                        GoodsA.Where(l => l.ItemCode == SelectedItemDetailsTemp[0].ItemCode).ToList().ForEach(i => i.Description = (""));
        //                    }
        //                    else if (SelectedItemDetailsTemp[0].Select == false)
        //                    {
        //                        if (x >= 0)
        //                        {
        //                            GoodsA.RemoveAt(x);
        //                        }
        //                    }
        //                    else if (SelectedItemDetailsTemp[0].Select == true) // && r != null && r >= 0)
        //                    {
        //                        //GoodsA[dgSelectedIndex].item_id = Convert.ToString(SelectedItemDetailsTemp[0].item_srno);   //chk                        

        //                        GoodsA[dgSelectedIndex].ItemCode = SelectedItemDetailsTemp[0].ItemCode;
        //                        GoodsA[dgSelectedIndex].item_Name = SelectedItemDetailsTemp[0].description; 
        //                        GoodsA[dgSelectedIndex].Description = SelectedItemDetailsTemp[0].description;                               
        //                        GoodsA[dgSelectedIndex].unit_code = SelectedItemDetailsTemp[0].unit_name;
        //                        GoodsA[dgSelectedIndex].unit_Name = SelectedItemDetailsTemp[0].unit_name;//chk
        //                        GoodsA[dgSelectedIndex].Stockable = Convert.ToBoolean(SelectedItemDetailsTemp[0].Stockable);
        //                        GoodsA[dgSelectedIndex].SubCategCod = SelectedItemDetailsTemp[0].SubCategCod;
        //                        GoodsA[dgSelectedIndex].batch_no = SelectedItemDetailsTemp[0].batch_no;
        //                        GoodsA[dgSelectedIndex].sku = SelectedItemDetailsTemp[0].sku;                                
        //                    }
        //                    generateDesc();
        //                }
        //                uomCollection = CollectionViewSource.GetDefaultView(MC.uom);
        //                uomCollection.Filter = new Predicate<object>(uomFilter);
        //                try
        //                {
        //                    MC.JobCart.Where(t => t.ItemCode == GoodsA[dgSelectedIndex - 1].ItemCode).ToList().ForEach(t => t.Select = false);         
        //                }
        //                catch
        //                {

        //                }
        //                foreach (var item in GoodsA)
        //                {
        //                    GoodsA.Where(i => i.ItemCode == item.ItemCode).Where(i => i.sku == item.sku).ToList().ForEach(L => L.stocking_unit1 = item.sku);
        //                }
        //            }
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
        //private void Deleteitemfromdetails(IList items)
        //{
        //    try
        //    {
        //        IList list = items as IList;
        //        List<MM_T001_A> GetSelectedSupp_Details = list.Cast<MM_T001_A>().ToList();

        //        if (GetSelectedSupp_Details.Count > 0)
        //        {
        //            int x = GoodsA.IndexOf(GoodsA.Where(X => X.ItemCode == GetSelectedSupp_Details[0].ItemCode && X.batch_no == GetSelectedSupp_Details[0].batch_no).FirstOrDefault());
        //            if (SelectedMM_T001.doc_no == "" && GetSelectedSupp_Details[0].doc_no == null)
        //            {
        //                if (x >= 0 && x != -1)
        //                {
        //                    GoodsA.RemoveAt(x);
        //                }
        //            }

        //            //if (GetSelectedSupp_Details[0].id == 0)
        //            //{
        //            //    int index = GoodsA.IndexOf(GoodsA.Where(o => o.sr_no == GetSelectedSupp_Details[0].sr_no).FirstOrDefault());
        //            //    GoodsA.RemoveAt(index);
        //            //    if (index != -1)
        //            //    {
        //            //        SelectedMM_T001.item_code_batchSplit = "";
        //            //        SelectedMM_T001.item_id_batchSplit = 0;
        //            //        SelectedMM_T001.item_name_batchSplit = "";
        //            //        SelectedMM_T001.sr_no_batchSplit = 0;
        //            //        SelectedMM_T001.pono_batchSplit = "";
        //            //    }
        //            //    //----------------------------------set srno sequence    
        //            //    if (GoodsA.Count() > 0)
        //            //    {
        //            //        sr_no = 1;
        //            //        for (int i = 0; i < GoodsA.Count(); i++)
        //            //        {
        //            //            GoodsA[i].sr_no = sr_no;
        //            //            sr_no++;
        //            //        }
        //            //    }
        //            //}
        //        }
        //    }
        //    catch { }
        //}
        //private void GetSelectedBatchDetails(IList BatchList)
        //{
        //    try
        //    {
        //        if (dgSelectedIndex != -1 && BatchList.Count > 0)
        //        {
        //            IList list = BatchList as IList;
        //            List<PPC_T001_PopUp> SelectedBatchDetailsTemp = list.Cast<PPC_T001_PopUp>().ToList();
        //            if (SelectedBatchDetailsTemp.Count > 0)
        //            {
        //                if (GoodsA != null)
        //                {
        //                    var q = GoodsA.Where(X => X.batch_no == SelectedBatchDetailsTemp[0].batch_no && X.ItemCode == SelectedBatchDetailsTemp[0].ItemCode).FirstOrDefault();
        //                    int x = GoodsA.IndexOf(GoodsA.Where(X => X.batch_no == SelectedBatchDetailsTemp[0].batch_no && X.ItemCode == SelectedBatchDetailsTemp[0].ItemCode).FirstOrDefault());

        //                    if (q == null && SelectedBatchDetailsTemp[0].Select == true && GoodsA.Count == dgSelectedIndex)//|| GoodsA.Count >= dgSelectedIndex
        //                    {                                
        //                        GoodsA.Add(new MM_T001_A()
        //                        {
        //                            //ItemCode = Convert.ToString(SelectedBatchDetailsTemp[0].item_srno),
        //                            ItemCode = SelectedBatchDetailsTemp[0].ItemCode,
                                   
        //                            item_Name = SelectedBatchDetailsTemp[0].description,
        //                            Description = SelectedBatchDetailsTemp[0].description,

        //                            unit_code = SelectedBatchDetailsTemp[0].unit_name,
        //                            unit_Name = SelectedBatchDetailsTemp[0].unit_name,//chk

        //                            Stockable = Convert.ToBoolean(SelectedBatchDetailsTemp[0].Stockable),
        //                            SubCategCod = SelectedBatchDetailsTemp[0].SubCategCod,

        //                            batch_no = SelectedBatchDetailsTemp[0].batch_no,
        //                            sku = SelectedBatchDetailsTemp[0].sku,                                   
        //                        });
        //                        GoodsA.Where(l => l.ItemCode == SelectedBatchDetailsTemp[0].ItemCode).ToList().ForEach(i => i.Description = (""));
        //                    }
        //                    else if (SelectedBatchDetailsTemp[0].Select == false)//&& GoodsA[x].id == 0
        //                    {
        //                        if (x >= 0)
        //                        {
        //                            GoodsA.RemoveAt(x);
        //                        }
        //                    }
        //                    else if (SelectedBatchDetailsTemp[0].Select == true) // && r != null && r >= 0)
        //                    {
        //                        //GoodsA[dgSelectedIndex].ItemCode = Convert.ToString(SelectedBatchDetailsTemp[0].item_srno);//chk                               
        //                        GoodsA[dgSelectedIndex].ItemCode = SelectedBatchDetailsTemp[0].ItemCode;
        //                        GoodsA[dgSelectedIndex].item_Name = SelectedBatchDetailsTemp[0].description;
        //                        GoodsA[dgSelectedIndex].Description = SelectedBatchDetailsTemp[0].description;
        //                        GoodsA[dgSelectedIndex].unit_code = SelectedBatchDetailsTemp[0].unit_name;
        //                        GoodsA[dgSelectedIndex].unit_Name = SelectedBatchDetailsTemp[0].unit_name;//chk
        //                        GoodsA[dgSelectedIndex].Stockable = Convert.ToBoolean(SelectedBatchDetailsTemp[0].Stockable);
        //                        GoodsA[dgSelectedIndex].SubCategCod = SelectedBatchDetailsTemp[0].SubCategCod;
        //                        GoodsA[dgSelectedIndex].batch_no = SelectedBatchDetailsTemp[0].batch_no;
        //                        GoodsA[dgSelectedIndex].sku = SelectedBatchDetailsTemp[0].sku;                             

        //                    }
        //                    generateDesc();
        //                }
        //                uomCollection = CollectionViewSource.GetDefaultView(MC.uom);
        //                uomCollection.Filter = new Predicate<object>(uomFilter);
        //                try
        //                {
        //                    MC.JobCart.Where(t => t.ItemCode == GoodsA[dgSelectedIndex - 1].ItemCode).ToList().ForEach(t => t.Select = false);
        //                }
        //                catch
        //                {

        //                }
        //                foreach (var item in GoodsA)
        //                {
        //                    GoodsA.Where(i => i.ItemCode == item.ItemCode).Where(i => i.sku == item.sku).ToList().ForEach(L => L.stocking_unit1 = item.sku);
        //                }
        //            }
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
        //private void GetSelectedJobCart(IList JobCartList)
        //{
        //    IList list = JobCartList as IList;
        //    List<PPC_T001_PopUp> GetSelectedJobCartTemp = list.Cast<PPC_T001_PopUp>().ToList();
        //    if (GetSelectedJobCartTemp.Count > 0)
        //    {
        //        SelectedMM_T001.source_doc_no = GetSelectedJobCartTemp[0].source_doc_no;
        //        //GoodsA = new ObservableCollection<MM_T001_A>();
        //        //SelectedMM_T001.item_code_batchSplit = Convert.ToString(MC.JobCart.ToList()[0].item_code);
        //        //SelectedMM_T001.item_code_batchSplit = "";
        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_T001>(MC, "MM_T001_Data", "ProductConversion", "SCM", "LoadItemFrmJobCart", 0, SelectedMM_T001.source_doc_no);
        //        //if (MC.JobCart.ToList() != null && MC.JobCart.ToList().Count == 1)
        //        //{
        //        //    SelectedMM_T001.item_code_batchSplit = Convert.ToString(MC.JobCart.ToList()[0].item_code);
        //        //    for (int i = 0; i < MC.JobCart.Count(); i++)
        //        //    {
        //        //        GoodsA.Add(new MM_T001_A
        //        //        {
        //        //            item_id = MC.JobCart[i].item_code,
        //        //            item_code = MC.JobCart[i].item_code,
        //        //            item_Name = MC.JobCart[i].description,

        //        //            batch_no = MC.JobCart[i].batch_no,

        //        //            ri_item = MC.JobCart[i].item_code,
        //        //            item_codeD = MC.JobCart[i].item_code,
        //        //            item_NameD = MC.JobCart[i].description,
        //        //            sku =MC.JobCart [i].sku,
        //        //            ri_sku = MC.JobCart[i].sku,                             
        //        //        });
        //        //        StockCollection = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        //        StockCollection.Filter = new Predicate<object>(FilterJobCart);
        //        //    };

        //        //}
        //        //else
        //        //{ 

        //        CollectionItem = (ICollectionView)CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        CollectionItem.Filter = new Predicate<object>(FilterJobCart);

        //        CollectionItemD = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        CollectionItemD.Filter = new Predicate<object>(FilterItemsD);

        //        CollectionItemS = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        CollectionItemS.Filter = new Predicate<object>(FilterItemsS);

        //        //    StockCollection = CollectionViewSource.GetDefaultView(MC.JobCart.ToList());
        //        //    StockCollection.Filter = new Predicate<object>(FilterJobCart);
        //        //}
        //    }
        //}

        //#endregion

        //#region Item Description with parameter for Source
        //private void ParameterPopupClosed(IList param)
        //{

        //    string strData = "";
        //    string strData1 = "";
        //    ADM_M030_P productData = new ADM_M030_P();
        //    ADM_M030_P productData1 = new ADM_M030_P();
        //    IList list = param as IList;
        //    List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();

        //    if (dgSelectedIndex != -1)
        //    {
        //        if (GoodsA[dgSelectedIndex].Description != null)
        //        {
        //            if (Selectedpartylist.Count > 0 && GoodsA[dgSelectedIndex].Description.Contains('\t'))
        //            {
        //                if (Selectedpartylist[0].Name != null)
        //                {
        //                    try
        //                    {
        //                        if (Selectedpartylist[0].item_code == GoodsA[dgSelectedIndex].ItemCode) 
        //                        {
        //                            if (param.Count > 0)
        //                            {
        //                                try
        //                                {
        //                                    if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
        //                                    {
        //                                        int itemid = Convert.ToInt32(GoodsA[dgSelectedIndex].ItemCode); 
        //                                        try
        //                                        {
        //                                            for (int e = 0; e < ParamitemList.Count; e++)
        //                                            {
        //                                                if (itemid == ParamitemList[e].item_id)
        //                                                {
        //                                                    if (Selectedpartylist[0].Type == ParamitemList[e].Type && dgSelectedIndex == ParamitemList[e].count)
        //                                                    {
        //                                                        ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == GoodsA[dgSelectedIndex].sku)
        //                                                        .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

        //                                                        ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == GoodsA[dgSelectedIndex].sku)
        //                                                      .ToList().ForEach(i => i.code = dgSelectedIndex);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                        catch
        //                                        {

        //                                        }
        //                                    }
        //                                    string code = "";
        //                                    foreach (var item in FluteList)
        //                                    {
        //                                        if (item.Name == Selectedpartylist[0].Name && item.Type == Selectedpartylist[0].Type)
        //                                        {
        //                                            strData = strData + " , " + item.Type + ":" + item.Name;
        //                                            strData = strData.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
        //                                            strData1 = strData1 + " , " + item.Type + ":" + item.code;
        //                                            strData1 = strData1.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
        //                                            code = Convert.ToString(item.code);
        //                                        }
        //                                    }
        //                                    string item1 = "";
        //                                    string description = "";
        //                                    try
        //                                    {
        //                                        //item1 = Pur_Req_Details[dgSelectedIndex].ItemName.ToString();
        //                                        //description = Pur_Req_Details[dgSelectedIndex].description.ToString();
        //                                        description = GoodsA[dgSelectedIndex].item_Name.ToString();
        //                                        item1 = GoodsA[dgSelectedIndex].Description.ToString();
        //                                    }
        //                                    catch
        //                                    {

        //                                    }
        //                                    string[] split = new string[50];
        //                                    string test = "";
        //                                    string test1 = "";
        //                                    if (item1.Contains("\t:" + Selectedpartylist[0].Type + ":"))
        //                                    {
        //                                        test = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                        string y = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                        string z = item1.Replace(y, "");
        //                                        split = z.Split(':');
        //                                        //test1 = item1.Replace(split[1], Selectedpartylist[0].Name + "\t");
        //                                        test1 = item1.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + Selectedpartylist[0].Name + "\t");

        //                                        strData = test1;
        //                                        if (description.Contains(Selectedpartylist[0].Type))
        //                                        {
        //                                            string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                            string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                            string z1 = description.Replace(y1, "");
        //                                            split = z1.Split(':');
        //                                            //string test2 = description.Replace(split[1], code + "\t");
        //                                            string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");
        //                                            try
        //                                            {
        //                                                {
        //                                                    strData1 = "";
        //                                                    string[] stockvalues = new string[50];
        //                                                    stockvalues = test2.Split('\t');
        //                                                    for (int r = 0; r < stockvalues.Count(); r++)
        //                                                    {
        //                                                        if (stockvalues[r] != "")
        //                                                        {
        //                                                            if (r == 0)
        //                                                            {
        //                                                                strData1 = stockvalues[0];
        //                                                            }
        //                                                            else
        //                                                            {
        //                                                                strData1 = strData1 + "\t" + stockvalues[r];
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                            catch
        //                                            {

        //                                            }
        //                                        }

        //                                        //Pur_Req_Details.Where(l => l.item_id == Pur_Req_Details[dgSelectedIndex].item_id).ToList().ForEach(i => i.ItemName = (strData));
        //                                        //Pur_Req_Details.Where(l => l.item_id == Pur_Req_Details[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (strData1));
        //                                        //Pur_Req_Details.Where(l => l.item_id == Pur_Req_Details[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (strData));
        //                                        //Pur_Req_Details.Where(l => l.item_id == Pur_Req_Details[dgSelectedIndex].item_id).ToList().ForEach(i => i.ItemName = (strData1));
        //                                        GoodsA[dgSelectedIndex].Description = (strData);
        //                                        GoodsA[dgSelectedIndex].item_Name = (strData1); //Priya
        //                                    }
        //                                    else
        //                                    {
        //                                        //Pur_Req_Details.Where(l => l.item_id == Pur_Req_Details[dgSelectedIndex].item_id).ToList().ForEach(i => i.ItemName = (i.ItemName + "\t" + ":" + strData));
        //                                        //Pur_Req_Details.Where(l => l.item_id == Pur_Req_Details[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (i.description + "\t" + ":" + strData1));

        //                                        //GoodsA.Where(l => l.item_id == GoodsA[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (i.Description + "\t" + ":" + strData));
        //                                        //GoodsA.Where(l => l.item_id == GoodsA[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_Name = (i.item_Name + "\t" + ":" + strData1));

        //                                        GoodsA[dgSelectedIndex].Description = (GoodsA[dgSelectedIndex].Description + "\t" + ":" + strData);
        //                                        GoodsA[dgSelectedIndex].item_Name = (GoodsA[dgSelectedIndex].item_Name + "\t" + ":" + strData1); //Priya
        //                                    }
        //                                }
        //                                catch
        //                                {

        //                                }
        //                            }
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                    //Check stocking unit already exist or not
        //                    try
        //                    {
        //                        //if (ValidateControls123() == true)
        //                        //{
        //                        //    StockingUnitCalculation123();
        //                        //}
        //                    }
        //                    catch
        //                    {

        //                    }
                            
        //                }

        //            }
        //        }
        //    }
        //}
        //private void CollectionChanged(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    try
        //    {
        //        List<MM_T001_A> Selectedpartylist = list.Cast<MM_T001_A>().ToList();
        //        if (Selectedpartylist[0].Stockable == true)
        //        {
        //            ParamitemList1 = new ObservableCollection<ADM_M030_P>();
        //            TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.parameter_list);
        //            if (ParamValuesList.Count == 0)
        //            {
        //                for (int i = 0; i < TotalParameterCollection.Cast<ADM_M030_P>().ToList().Count(); i++)
        //                {
        //                    ParamValuesList.Add(TotalParameterCollection.Cast<ADM_M030_P>().ElementAt(i));
        //                }
        //            }
        //            if (GoodsA[dgSelectedIndex].id == 0 || GoodsA[dgSelectedIndex].id == null)
        //            {
        //                if (GoodsA.Count > 0)
        //                {
        //                    {
        //                        {
        //                            if (dgSelectedIndex != -1)
        //                            {
        //                                try
        //                                {
        //                                    int item_id = Convert.ToInt32(Selectedpartylist[0].ItemCode);
        //                                    int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);

        //                                    FluteList = MC.parameter_value_list;

        //                                    var ParameterType = (from o in ParamValuesList
        //                                                         where o.SubCatCode == subcatcode
        //                                                         select o).ToList();

        //                                    var itemlist = (from o in ParamitemList
        //                                                    where o.item_id == item_id && o.count == dgSelectedIndex
        //                                                    select o).ToList();
        //                                    if (itemlist.Count == 0)
        //                                    {
        //                                        {
        //                                            for (int r = 0; r < ParameterType.Count; r++)
        //                                            {
        //                                                ParamitemList.Add(new ADM_M030_P() { count = dgSelectedIndex, stockunit = GoodsA[dgSelectedIndex].sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                                            }
        //                                        }
        //                                    }
        //                                    try
        //                                    {
        //                                        string[] values = Selectedpartylist[0].sku.Split('/');
        //                                        int count = values.Length;
        //                                        for (int r = 0; r < count; r++)
        //                                        {
        //                                            var ParameterCollectionMethod = (from o in FluteList
        //                                                                             where o.code == Convert.ToInt32(values[r].ToString())
        //                                                                             select o).ToList();

        //                                            ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == GoodsA[dgSelectedIndex].sku)
        //                                                           .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                                            GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                                        }
        //                                    }
        //                                    catch
        //                                    {

        //                                    }
        //                                    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);

        //                                    for (int r = 0; r < ParamitemList.Count; r++)
        //                                    {
        //                                        if (ParamitemList[r].item_id == item_id && ParamitemList[r].count == dgSelectedIndex)
        //                                        {
        //                                            ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                                            ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                                        }
        //                                    }
        //                                    if (!GoodsA[dgSelectedIndex].Description.Contains('\t'))
        //                                    {

        //                                        MC.JobCart = CollectionItem.Cast<PPC_T001_PopUp>().ToList();
        //                                        //MC.batch_stock = CollectionItem.Cast<MM_S003_PopUp>().ToList();
        //                                        //string tnm = (from data in MC.batch_stock where data.item_id == GoodsA[dgSelectedIndex].item_id select data.item_Name).ToList()[0].ToString();
        //                                        string tnm = (from data in MC.JobCart where data.ItemCode == GoodsA[dgSelectedIndex].ItemCode select data.description).ToList()[0].ToString();
        //                                        GoodsA[dgSelectedIndex].item_Name = "";
        //                                        GoodsA[dgSelectedIndex].Description = "";

        //                                        for (int y = 0; y < ParamitemList1.Count; y++)
        //                                        {
        //                                            if (y == 0)
        //                                            {
        //                                                GoodsA[dgSelectedIndex].item_Name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                                GoodsA[dgSelectedIndex].Description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";

        //                                            }
        //                                            else
        //                                            {
        //                                                GoodsA[dgSelectedIndex].item_Name = GoodsA[dgSelectedIndex].item_Name + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                                GoodsA[dgSelectedIndex].Description = GoodsA[dgSelectedIndex].Description + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                catch
        //                                {

        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            else if (GoodsA[dgSelectedIndex].id != 0 || GoodsA[dgSelectedIndex].id != null)
        //            {

        //                if (dgSelectedIndex != -1)
        //                {
        //                    try
        //                    {
        //                        int item_id = Convert.ToInt32(Selectedpartylist[0].item_srno);
        //                        int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);

        //                        FluteList = MC.parameter_value_list;



        //                        var ParameterType = (from o in ParamValuesList
        //                                             where o.SubCatCode == subcatcode
        //                                             select o).ToList();

        //                        var itemlist = (from o in ParamitemList
        //                                        where o.item_id == item_id && o.stockunit == GoodsA[dgSelectedIndex].sku
        //                                        select o).ToList();
        //                        if (itemlist.Count == 0)
        //                        {
        //                            {
        //                                for (int r = 0; r < ParameterType.Count; r++)
        //                                {
        //                                    ParamitemList.Add(new ADM_M030_P() { code = dgSelectedIndex, stockunit = GoodsA[dgSelectedIndex].sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                                }
        //                            }
        //                        }
        //                        try
        //                        {
        //                            string[] values = Selectedpartylist[0].sku.Split('/');
        //                            int count = values.Length;
        //                            for (int r = 0; r < count; r++)
        //                            {

        //                                var ParameterCollectionMethod = (from o in FluteList
        //                                                                 where o.code == Convert.ToInt32(values[r].ToString())
        //                                                                 select o).ToList();

        //                                ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == GoodsA[dgSelectedIndex].sku)
        //                                                            .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                                FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                                FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                                GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                            }
        //                        }
        //                        catch
        //                        {

        //                        }
        //                        ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
        //                        for (int r = 0; r < ParamitemList.Count; r++)
        //                        {
        //                            if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == GoodsA[dgSelectedIndex].sku)
        //                            {
        //                                ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                                ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                            }
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
     
        ////private bool ValidateControls123()
        ////{
        ////    try
        ////    {
        ////        int i = 0;
        ////        int count1 = 0;
        ////        string[] values = new string[50];
        ////        string description1 = "";
        ////        try
        ////        {
        ////            //for (int y = 0; y < Pur_Req_Details.Count; y++)
        ////            {
        ////                try
        ////                {
        ////                    description1 = GoodsA[dgSelectedIndex].Description.ToString();
        ////                    values = description1.Split('\t');
        ////                }
        ////                catch
        ////                {

        ////                }

        ////                try
        ////                {
        ////                    int item_id = Convert.ToInt32(GoodsA[dgSelectedIndex].item_id);
        ////                    int subcatcode = Convert.ToInt32(GoodsA[dgSelectedIndex].SubCategCod);
        ////                    var ParameterType = (from o in MC.ParamList
        ////                                         where o.SubCatCode == subcatcode
        ////                                         select o).ToList();

        ////                    for (int i1 = 0; i1 < values.Count(); i1++)
        ////                    {
        ////                        string[] val = values[i1].Split(':');
        ////                        try
        ////                        {
        ////                            if (i1 != 0)
        ////                            {
        ////                                if (val[2].ToString() != "")
        ////                                {
        ////                                    i = 0;
        ////                                }
        ////                                else
        ////                                {
        ////                                    i = 1;
        ////                                    break;
        ////                                }
        ////                            }
        ////                        }
        ////                        catch
        ////                        {

        ////                        }
        ////                    }
        ////                }
        ////                catch
        ////                {

        ////                }
        ////            }

        ////        }
        ////        catch (Exception ex)
        ////        {

        ////        }

        ////        if (i == 0)
        ////        {
        ////            return true;
        ////        }
        ////        else
        ////        {
        ////            return false;
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return true;
        ////    }
        ////}
        ////private void StockingUnitCalculation123()
        ////{
        ////    string description = "";
        ////    int count = 0;

        ////    //for (int y = 0; y < dgcatalogItem.Count; y++)
        ////    {
        ////        try
        ////        {
        ////            description = GoodsA[dgSelectedIndex].item_Name.ToString();
        ////        }
        ////        catch
        ////        {

        ////        }
        ////        string stockingunit = "";

        ////        try
        ////        {
        ////            {
        ////                try
        ////                {
        ////                    int index = GoodsA[dgSelectedIndex].sku.IndexOf(':');
        ////                    if (index != -1)
        ////                    {
        ////                        GoodsA[dgSelectedIndex].sku = GoodsA[dgSelectedIndex].sku.Substring(0, index - 1);
        ////                    }
        ////                }
        ////                catch
        ////                {

        ////                }
        ////                while (description.Contains("\t"))
        ////                {
        ////                    try
        ////                    {

        ////                        string itemcode = description.Substring(0, description.LastIndexOf(":"));
        ////                        string itemcode1 = description.Replace(itemcode, "");
        ////                        string itemcode2 = itemcode1.Replace(":", "");
        ////                        if (count == 0)
        ////                        {
        ////                            if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
        ////                            {
        ////                                //GoodsA[dgSelectedIndex].sku = GoodsA[dgSelectedIndex].sku + ":" + 0;
        ////                                GoodsA[dgSelectedIndex].sku = "0";
        ////                            }
        ////                            else
        ////                            {
        ////                                // GoodsA[dgSelectedIndex].sku = GoodsA[dgSelectedIndex].sku + ":" + itemcode2;
        ////                                GoodsA[dgSelectedIndex].sku = itemcode2;
        ////                            }
        ////                        }
        ////                        else
        ////                        {
        ////                            if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
        ////                            {
        ////                                //GoodsA[dgSelectedIndex].sku = GoodsA[dgSelectedIndex].sku + "/" + 0;
        ////                                GoodsA[dgSelectedIndex].sku = "0";

        ////                            }
        ////                            else
        ////                            {
        ////                                //GoodsA[dgSelectedIndex].sku = GoodsA[dgSelectedIndex].sku + "/" + itemcode2;
        ////                                GoodsA[dgSelectedIndex].sku = itemcode2;

        ////                            }
        ////                        }
        ////                        string itemcode3 = itemcode.Substring(0, description.LastIndexOf("\t"));
        ////                        description = itemcode3;
        ////                        count++;
        ////                    }
        ////                    catch
        ////                    {
        ////                        break;
        ////                    }
        ////                }
        ////                string[] stockvalues = new string[50];
        ////                stockvalues = GoodsA[dgSelectedIndex].sku.Split(':');
        ////                string test = "";
        ////                GoodsA[dgSelectedIndex].stockingunit = GoodsA[dgSelectedIndex].sku;
        ////                ParamitemList.Where(l => l.item_id == Convert.ToInt32(GoodsA[dgSelectedIndex].item_id)).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = GoodsA[dgSelectedIndex].sku);

        ////            }
        ////            count = 0;
        ////        }
        ////        catch
        ////        {

        ////        }


        ////    }
        ////}

        //#endregion

        //#region Item Description with parameter for destination      
        //private void ParameterPopupClosedDesti(IList param)
        //{

        //    string strData = "";
        //    string strData1 = "";
        //    ADM_M030_P productData = new ADM_M030_P();
        //    ADM_M030_P productData1 = new ADM_M030_P();
        //    IList list = param as IList;
        //    List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();

        //    if (dgSelectedIndex != -1)
        //    {
        //        if (GoodsA[dgSelectedIndex].DescriptionDesti != null)
        //        {
        //            if (Selectedpartylist.Count > 0 && GoodsA[dgSelectedIndex].DescriptionDesti.Contains('\t'))
        //            {
        //                if (Selectedpartylist[0].Name != null)
        //                {
        //                    try
        //                    {
        //                        if (Selectedpartylist[0].item_id == Convert.ToInt32(GoodsA[dgSelectedIndex].ri_item)) 
        //                        {
        //                            if (param.Count > 0)
        //                            {
        //                                try
        //                                {
        //                                    if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
        //                                    {
        //                                        int itemid = Convert.ToInt32(GoodsA[dgSelectedIndex].ri_item); 
        //                                        try
        //                                        {
        //                                            for (int e = 0; e < ParamitemList.Count; e++)
        //                                            {
        //                                                if (itemid == ParamitemList[e].item_id)
        //                                                {
        //                                                    if (Selectedpartylist[0].Type == ParamitemList[e].Type && dgSelectedIndex == ParamitemList[e].count)
        //                                                    {
        //                                                        ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == GoodsA[dgSelectedIndex].ri_sku)
        //                                                        .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

        //                                                        ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == GoodsA[dgSelectedIndex].ri_sku)
        //                                                      .ToList().ForEach(i => i.code = dgSelectedIndex);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                        catch
        //                                        {

        //                                        }
        //                                    }
        //                                    string code = "";
        //                                    foreach (var item in FluteList)
        //                                    {
        //                                        if (item.Name == Selectedpartylist[0].Name && item.Type == Selectedpartylist[0].Type)
        //                                        {
        //                                            strData = strData + " , " + item.Type + ":" + item.Name;
        //                                            strData = strData.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
        //                                            strData1 = strData1 + " , " + item.Type + ":" + item.code;
        //                                            strData1 = strData1.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
        //                                            code = Convert.ToString(item.code);
        //                                        }
        //                                    }
        //                                    string item1 = "";
        //                                    string description = "";
        //                                    try
        //                                    {                                               
        //                                        item1 = GoodsA[dgSelectedIndex].item_NameD.ToString();
        //                                        description = GoodsA[dgSelectedIndex].DescriptionDesti.ToString();
        //                                    }
        //                                    catch
        //                                    {

        //                                    }
        //                                    string[] split = new string[50];
        //                                    string test = "";
        //                                    string test1 = "";
        //                                    if (item1.Contains("\t:" + Selectedpartylist[0].Type + ":"))
        //                                    {
        //                                        test = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                        string y = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                        string z = item1.Replace(y, "");
        //                                        split = z.Split(':');                                              
        //                                        test1 = item1.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + Selectedpartylist[0].Name + "\t");

        //                                        strData = test1;
        //                                        if (description.Contains(Selectedpartylist[0].Type))
        //                                        {
        //                                            string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                            string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                            string z1 = description.Replace(y1, "");
        //                                            split = z1.Split(':');                                                 
        //                                            string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");
        //                                            try
        //                                            {
        //                                                {
        //                                                    strData1 = "";
        //                                                    string[] stockvalues = new string[50];
        //                                                    stockvalues = test2.Split('\t');
        //                                                    for (int r = 0; r < stockvalues.Count(); r++)
        //                                                    {
        //                                                        if (stockvalues[r] != "")
        //                                                        {
        //                                                            if (r == 0)
        //                                                            {
        //                                                                strData1 = stockvalues[0];
        //                                                            }
        //                                                            else
        //                                                            {
        //                                                                strData1 = strData1 + "\t" + stockvalues[r];
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                            catch
        //                                            {

        //                                            }
        //                                        }
        //                                        GoodsA[dgSelectedIndex].DescriptionDesti = (strData1);
        //                                        GoodsA[dgSelectedIndex].item_NameD = (strData); 
        //                                    }
        //                                    else
        //                                    {                                              

        //                                        GoodsA[dgSelectedIndex].DescriptionDesti = (GoodsA[dgSelectedIndex].DescriptionDesti + "\t" + ":" + strData1);
        //                                        GoodsA[dgSelectedIndex].item_NameD = (GoodsA[dgSelectedIndex].item_NameD + "\t" + ":" + strData); 
        //                                    }
        //                                }
        //                                catch
        //                                {

        //                                }
        //                            }
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                    //Check stocking unit already exist or not
        //                    try
        //                    {
        //                        if (ValidateControls123() == true)
        //                        {
        //                            StockingUnitCalculation123();
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }                            
        //                }

        //            }
        //        }
        //    }

        //}
        //private void CollectionChangedDesti(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    try
        //    {
        //        List<MM_T001_A> Selectedpartylist = list.Cast<MM_T001_A>().ToList();
        //        if (Selectedpartylist[0].Stockable == true)
        //        {
        //            ParamitemList1 = new ObservableCollection<ADM_M030_P>();
        //            TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.parameter_list);
        //            if (ParamValuesList.Count == 0)
        //            {
        //                for (int i = 0; i < TotalParameterCollection.Cast<ADM_M030_P>().ToList().Count(); i++)
        //                {
        //                    ParamValuesList.Add(TotalParameterCollection.Cast<ADM_M030_P>().ElementAt(i));
        //                }
        //            }
        //            if (GoodsA[dgSelectedIndex].id == 0 || GoodsA[dgSelectedIndex].id == null)
        //            {
        //                if (GoodsA.Count > 0)
        //                {
        //                    {
        //                        {
        //                            if (dgSelectedIndex != -1)
        //                            {
        //                                try
        //                                {
        //                                    int item_id = Convert.ToInt32(Selectedpartylist[0].ri_item);                                           
        //                                    int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);

        //                                    FluteList = MC.parameter_value_list;

        //                                    var ParameterType = (from o in ParamValuesList
        //                                                         where o.SubCatCode == subcatcode
        //                                                         select o).ToList();

        //                                    var itemlist = (from o in ParamitemList
        //                                                    where o.item_id == item_id && o.count == dgSelectedIndex
        //                                                    select o).ToList();
        //                                    if (itemlist.Count == 0)
        //                                    {                                               
        //                                        {   
        //                                            for (int r = 0; r < ParameterType.Count; r++)
        //                                            {   
        //                                                ParamitemList.Add(new ADM_M030_P() { count = dgSelectedIndex, stockunit = GoodsA[dgSelectedIndex].ri_sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                                            }
        //                                        }
        //                                    }
        //                                    try
        //                                    {                                                
        //                                        string[] values = Selectedpartylist[0].ri_sku.Split('/');
        //                                        int count = values.Length;
        //                                        for (int r = 0; r < count; r++)
        //                                        {
        //                                            var ParameterCollectionMethod = (from o in FluteList
        //                                                                             where o.code == Convert.ToInt32(values[r].ToString())
        //                                                                             select o).ToList();

        //                                            ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == GoodsA[dgSelectedIndex].ri_sku)
        //                                                           .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                                            GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                                        }
        //                                    }
        //                                    catch
        //                                    {

        //                                    }
        //                                    ParameterCollectionDesti = CollectionViewSource.GetDefaultView(ParamclearList);

        //                                    for (int r = 0; r < ParamitemList.Count; r++)
        //                                    {
        //                                        if (ParamitemList[r].item_id == item_id && ParamitemList[r].count == dgSelectedIndex)
        //                                        {
        //                                            ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                                            ParameterCollectionDesti = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                                        }
        //                                    }
        //                                    if (!GoodsA[dgSelectedIndex].DescriptionDesti.Contains('\t'))
        //                                    {

        //                                        MC.items = CollectionItem.Cast<ADM_M022_PopUp_Inst>().ToList();

        //                                        string tnm = (from data in MC.items where data.item_id == Convert.ToInt32(GoodsA[dgSelectedIndex].ItemCode) select data.ItemName).ToList()[0].ToString();
                                               
        //                                        GoodsA[dgSelectedIndex].item_NameD = "";
        //                                        GoodsA[dgSelectedIndex].DescriptionDesti = "";                                              
        //                                        for (int y = 0; y < ParamitemList1.Count; y++)
        //                                        {
        //                                            if (y == 0)
        //                                            {                                                      
        //                                                GoodsA[dgSelectedIndex].item_NameD = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                                GoodsA[dgSelectedIndex].DescriptionDesti = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                            }
        //                                            else
        //                                            {                                                       
        //                                                GoodsA[dgSelectedIndex].item_NameD = GoodsA[dgSelectedIndex].item_NameD + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                                GoodsA[dgSelectedIndex].DescriptionDesti = GoodsA[dgSelectedIndex].DescriptionDesti + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                catch
        //                                {

        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            else if (GoodsA[dgSelectedIndex].id != 0 || GoodsA[dgSelectedIndex].id != null)
        //            {

        //                if (dgSelectedIndex != -1)
        //                {
        //                    try
        //                    {
        //                        int item_id = Convert.ToInt32(Selectedpartylist[0].ri_item);
        //                        int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);

        //                        FluteList = MC.parameter_value_list;



        //                        var ParameterType = (from o in ParamValuesList
        //                                             where o.SubCatCode == subcatcode
        //                                             select o).ToList();

        //                        var itemlist = (from o in ParamitemList                                                
        //                                        where o.item_id == item_id && o.stockunit == GoodsA[dgSelectedIndex].ri_sku
        //                                        select o).ToList();
        //                        if (itemlist.Count == 0)
        //                        {
        //                            {
        //                                for (int r = 0; r < ParameterType.Count; r++)
        //                                {
        //                                    ParamitemList.Add(new ADM_M030_P() { code = dgSelectedIndex, stockunit = GoodsA[dgSelectedIndex].ri_sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });                                          
        //                                }
        //                            }
        //                        }
        //                        try
        //                        {                                   
        //                            string[] values = Selectedpartylist[0].ri_sku.Split('/');
        //                            int count = values.Length;
        //                            for (int r = 0; r < count; r++)
        //                            {

        //                                var ParameterCollectionMethod = (from o in FluteList
        //                                                                 where o.code == Convert.ToInt32(values[r].ToString())
        //                                                                 select o).ToList();

        //                                ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == GoodsA[dgSelectedIndex].ri_sku)
        //                                                            .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);                                      

        //                                FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                                FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                                GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                            }
        //                        }
        //                        catch
        //                        {

        //                        }
        //                        ParameterCollectionDesti = CollectionViewSource.GetDefaultView(ParamclearList);
        //                        for (int r = 0; r < ParamitemList.Count; r++)
        //                        {                                   
        //                            if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == GoodsA[dgSelectedIndex].ri_sku)
        //                            {
        //                                ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                                ParameterCollectionDesti = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                            }
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ParameterCollectionDesti = CollectionViewSource.GetDefaultView(ParamclearList);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        //private void StockingUnitCalculationDesti()
        //{
        //    string ItemName = "";
        //    int count = 0;

        //    for (int y = 0; y < GoodsA.Count; y++)
        //    {
        //        try
        //        {
        //            ItemName = GoodsA[y].DescriptionDesti.ToString();
        //            if (GoodsA[y].ItemCode.Contains(":"))
        //            {
        //                string[] splititem = new string[50];
        //                splititem = GoodsA[y].ItemCode.Split(':');
        //                GoodsA.Where(l => l.ri_item == GoodsA[y].ri_item)
        //                                             .ToList().ForEach(i => i.ItemCode = splititem[0]);

        //            }                   
        //        }
        //        catch
        //        {

        //        }
        //        string stockingunit = "";

        //        try
        //        {

        //            {
        //                while (ItemName.Contains("\t"))
        //                {
        //                    try
        //                    {
        //                        string itemcode = ItemName.Substring(0, ItemName.LastIndexOf(":"));
        //                        string itemcode1 = ItemName.Replace(itemcode, "");
        //                        string itemcode2 = itemcode1.Replace(":", "");
        //                        if (count == 0)
        //                        {
        //                            GoodsA[y].ri_sku = itemcode2;

        //                        }
        //                        else
        //                        {
        //                            GoodsA[y].ri_sku = GoodsA[y].ri_sku + "/" + itemcode2;

        //                        }
        //                        string itemcode3 = itemcode.Substring(0, ItemName.LastIndexOf("\t"));
        //                        ItemName = itemcode3;
        //                        count++;
        //                    }
        //                    catch
        //                    {
        //                        break;
        //                    }
        //                }
        //            }
        //            count = 0;
        //        }
        //        catch
        //        {

        //        }
        //    }

        //}      
        //private void updateDescription()
        //{
        //    string parametervale = "";
        //    string parametercode = "";
            
            
        //    for (int y = 0; y < GoodsA.Count; y++)
        //    {
        //        try
        //        {
        //            parametervale = "";
        //            parametercode = "";                 
        //            string stockingunit = GoodsA[y].ri_sku;
        //            string[] tokens = stockingunit.Split('/');
        //            int count = tokens.Length;
        //            while (count > 0)
        //            {
        //                string value = tokens[count - 1];
        //                if (value != "")
        //                {
        //                    var myItem = (from o in MC.parameter_value_list
        //                                  where o.code == Convert.ToInt32(value)
        //                                  select o).ToList();
        //                    if (parametervale == "")
        //                    {
        //                        parametervale = myItem[0].Type + ":" + myItem[0].Name;
        //                        parametercode = myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
        //                    }
        //                    else
        //                    {
        //                        parametervale = parametervale + "\t:" + myItem[0].Type + ":" + myItem[0].Name;
        //                        parametercode = parametercode + "\t:" + myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
        //                    }
        //                }
        //                count = count - 1;
        //            }
        //            if (GoodsA[y].item_NameD != "" || GoodsA[y] != null)
        //            {
        //                string t_itemname;
        //                if (GoodsA[y].item_NameD.Contains("\t"))
        //                {
        //                    t_itemname = GoodsA[y].item_NameD.Substring(0, GoodsA[y].item_NameD.IndexOf("\t"));
        //                }
        //                else
        //                {
        //                    t_itemname = GoodsA[y].item_NameD;
        //                }
        //                GoodsA[y].DescriptionDesti = t_itemname + "\t:" + parametercode;
        //                GoodsA[y].item_NameD = t_itemname + "\t:" + parametervale;
        //            }
        //        }
        //        catch
        //        {

        //        }

        //    }
        //}
        //private bool ValidateControls123()
        //{
        //    try
        //    {
        //        int i = 0;
        //        int count1 = 0;
        //        string[] values = new string[50];
        //        string description1 = "";
        //        try
        //        {                    
        //            {
        //                try
        //                {
        //                    description1 = GoodsA[dgSelectedIndex].item_NameD.ToString();
        //                    values = description1.Split('\t');
        //                }
        //                catch
        //                {

        //                }

        //                try
        //                {
        //                    int item_id = Convert.ToInt32(GoodsA[dgSelectedIndex].ri_item);
        //                    int subcatcode = Convert.ToInt32(GoodsA[dgSelectedIndex].SubCategCod);
        //                    var ParameterType = (from o in MC.ParamList
        //                                         where o.SubCatCode == subcatcode
        //                                         select o).ToList();

        //                    for (int i1 = 0; i1 < values.Count(); i1++)
        //                    {
        //                        string[] val = values[i1].Split(':');
        //                        try
        //                        {
        //                            if (i1 != 0)
        //                            {
        //                                if (val[2].ToString() != "")
        //                                {
        //                                    i = 0;
        //                                }
        //                                else
        //                                {
        //                                    i = 1;
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                        catch
        //                        {

        //                        }
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //        if (i == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return true;
        //    }
        //}
        //private void StockingUnitCalculation123()
        //{
        //    string description = "";
        //    int count = 0;

        //    //for (int y = 0; y < dgcatalogItem.Count; y++)
        //    {
        //        try
        //        {
        //            description = GoodsA[dgSelectedIndex].DescriptionDesti.ToString();
        //        }
        //        catch
        //        {

        //        }
        //        string stockingunit = "";

        //        try
        //        {
        //            {
        //                try
        //                {
        //                    int index = GoodsA[dgSelectedIndex].ri_sku.IndexOf(':');
        //                    if (index != -1)
        //                    {
        //                        GoodsA[dgSelectedIndex].ri_sku = GoodsA[dgSelectedIndex].ri_sku.Substring(0, index - 1);
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //                while (description.Contains("\t"))
        //                {
        //                    try
        //                    {

        //                        string itemcode = description.Substring(0, description.LastIndexOf(":"));
        //                        string itemcode1 = description.Replace(itemcode, "");
        //                        string itemcode2 = itemcode1.Replace(":", "");
        //                        if (count == 0)
        //                        {
        //                            if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
        //                            {                                       
        //                                GoodsA[dgSelectedIndex].ri_sku = "0";
        //                            }
        //                            else
        //                            {                                        
        //                                GoodsA[dgSelectedIndex].ri_sku = itemcode2;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
        //                            {                                       
        //                                GoodsA[dgSelectedIndex].ri_sku = "0";

        //                            }
        //                            else
        //                            {                                        
        //                                GoodsA[dgSelectedIndex].ri_sku = itemcode2;

        //                            }
        //                        }
        //                        string itemcode3 = itemcode.Substring(0, description.LastIndexOf("\t"));
        //                        description = itemcode3;
        //                        count++;
        //                    }
        //                    catch
        //                    {
        //                        break;
        //                    }
        //                }
        //                string[] stockvalues = new string[50];
        //                stockvalues = GoodsA[dgSelectedIndex].ri_sku.Split(':');
        //                string test = "";
        //                GoodsA[dgSelectedIndex].stockingunit = GoodsA[dgSelectedIndex].ri_sku;
        //                ParamitemList.Where(l => l.item_id == Convert.ToInt32(GoodsA[dgSelectedIndex].ri_item)).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = GoodsA[dgSelectedIndex].ri_sku);

        //            }
        //            count = 0;
        //        }
        //        catch
        //        {

        //        }


        //    }
        //}
        //private bool ValidateControls()
        //{
        //    try
        //    {
        //        int i = 0;
        //        int count1 = 0;
        //        string[] values = new string[50];
        //        string description1 = "";
        //        try
        //        {
        //            for (int y = 0; y < GoodsA.Count; y++)
        //            {
        //                try
        //                {
        //                    description1 = GoodsA[y].item_NameD.ToString();
        //                    values = description1.Split('\t');
        //                }
        //                catch
        //                {

        //                }
                        
        //                try
        //                {
        //                    int item_id = Convert.ToInt32(GoodsA[y].ri_item);
        //                    int subcatcode = Convert.ToInt32(GoodsA[y].SubCategCod);
        //                    var ParameterType = (from o in MC.ParamList
        //                                         where o.SubCatCode == subcatcode
        //                                         select o).ToList();
        //                    for (int i1 = 0; i1 < values.Count(); i1++)
        //                    {
        //                        string[] val = values[i1].Split(':');
        //                        try
        //                        {
        //                            if (i1 != 0)
        //                            {
        //                                if (val[2].ToString() != "")
        //                                {
        //                                    i = 0;
        //                                }
        //                                else
        //                                {
        //                                    i = 1;

        //                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                                    showMessageService.ButtonSetup = DialogButton.Ok;
        //                                    showMessageService.Caption = "Message";
        //                                    showMessageService.Text = String.Format("Please Select All Parameter Value", this.Title);
        //                                    showMessageService.ShowMessage();
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                        catch
        //                        {

        //                        }
        //                    }

        //                }
        //                catch
        //                {

        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        {
        //            foreach (var item in GoodsA)
        //            {
        //                var duplicateitem = (from o in GoodsA
        //                                     where o.ri_item == item.ri_item && o.stocking_unit1 == item.stocking_unit1
        //                                     && o.ri_batch_no == item.ri_batch_no

        //                                     select o).ToList();
        //                if (duplicateitem.Count > 1)
        //                {
        //                    i = 1;
        //                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                    showMessageService.ButtonSetup = DialogButton.Ok;
        //                    showMessageService.Caption = "Message";
        //                    showMessageService.Text = String.Format("Duplicate Parameter Value", this.Title);
        //                    showMessageService.ShowMessage();
        //                    break;
        //                }
        //            }


        //        }
                
        //        if (i == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return true;
        //    }
        //    // quantityCompare();

        //}
        //private bool ItemUnitCompare()
        //{
        //    try
        //    {
        //        int i = 0;               
        //        try
        //        {
        //            for (int y = 0; y < GoodsA.Count; y++)
        //            {
        //                try
        //                {
        //                    var MatchItem_Unit = (from data in GoodsA
        //                                          where data.ItemCode == GoodsA[dgSelectedIndex].item_codeD && data.unit_code == GoodsA[dgSelectedIndex].ri_unit_cd && data.batch_no == GoodsA[dgSelectedIndex].ri_batch_no
        //                                          select data).ToList();//.qty).Sum();

        //                    if (MatchItem_Unit.Count > 0)
        //                    {
        //                        i = 0;

        //                    }
        //                    else
        //                    {
        //                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                        showMessageService.ButtonSetup = DialogButton.Ok;
        //                        showMessageService.Caption = "Item And Unit Match";
        //                        showMessageService.Text =
        //                            String.Format("Source Item,Unit and Batch no. Must Same With Destination'{0}'", this.Title);
        //                        showMessageService.ShowMessage();
        //                        i = 1;
        //                    }                            
        //                }
        //                catch (Exception ex)
        //                {

        //                }
        //            }
        //            if (i == 0)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }


        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //        if (i == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return true;
        //    }

        //}
        //#endregion

        //#region · Command Actions ·
        //protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        //{
        //    try
        //    {
        //        this.SelectedMM_T001.EndEdit();
        //        ObjectSerializationService objSer = new ObjectSerializationService();
        //        SelectedMM_T001.comp_code = AppSessionState.comp_code;
        //        SelectedMM_T001.location_Id = AppSessionState.location_Id;
        //        SelectedMM_T001.add_by = Convert.ToString(AppSessionState.UserID);
                

        //        try
        //        {
        //            //StockingUnitCalculation();
        //            StockingUnitCalculationDesti();
        //        }
        //        catch
        //        {

        //        }
        //        SelectedMM_T001.XmlDataDocument_MM_T001 = objSer.ObjectToXML(GoodsA);
        //        if (ValidateControls() == true)
        //        {
                 
        //            if(ItemUnitCompare()==true)
        //            {
        //                if (blNew == true)
        //                {
        //                    SelectedMM_T001 = repository.SaveWithReturnDomainObject<MM_T001>(SelectedMM_T001, "ProductConversion", "SCM");
        //                    SelectedList.Add(SelectedMM_T001);
        //                    GoodsA = (ObservableCollection<MM_T001_A>)objSer.XMLToObject(SelectedMM_T001.XmlDataDocument_MM_T001, GoodsA);
        //                    foreach (var sodtel in GoodsA)
        //                    {
        //                        MC.GoodsA.Add(sodtel);
        //                    }
        //                    _dataGridCollection.Refresh();
        //                    blNew = false;
        //                }
        //                else if (blNew == false)
        //                {
        //                    int y = 0;
        //                    if (SelectedMM_T001.AiSts == false)
        //                    {
        //                        y = 1;
        //                    }
        //                    string response = repository.Update<MM_T001>(SelectedMM_T001, "ProductConversion", "SCM");
        //                    GoodsA = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(SelectedMM_T001.XmlDataDocument_MM_T001, GoodsA);
        //                    if (y == 1)
        //                    {
        //                        SelectedMM_T001 = new  MM_T001();
        //                        GoodsA = new ObservableCollection<MM_T001_A>();
        //                    }
        //                    _dataGridCollection.Refresh();
        //                }
        //                updateDescription();
        //            }
        //            else
        //            {
                    
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Item And Unit Match";
        //                showMessageService.Text =
        //                    String.Format("Source Item,Unit and Batch no. Must Same With Destination'{0}'", this.Title);
        //                showMessageService.ShowMessage();                               
        //            }
        //        }
        //        else
        //        {
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Message";
        //            showMessageService.Text = String.Format("Please Select All Parameter", this.Title);
        //            showMessageService.ShowMessage();
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
        //protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        //{
        //    blNew = true;         
        //    try
        //    {
        //        MC.JobCart.ToList().ForEach(t => t.Select = false);
        //    }
        //    catch { }

        //    MCTemp.pono_List = new List<SEL_T001_Popup>();
        //    SelectedMM_T001 = new MM_T001();

        //    GoodsA = new ObservableCollection<MM_T001_A>();
        //    SelectedMM_T001.edit_date = DateTime.Now;
        //    SelectedMM_T001.doc_date = DateTime.Now;
        //    SelectedMM_T001.doc_cat = "";
        //    SelectedMM_T001.doc_code = "PC";
        //    ParameterCollection = CollectionViewSource.GetDefaultView(new ObservableCollection<ADM_M030_P>());
        //    ParameterCollectionDesti = CollectionViewSource.GetDefaultView(new ObservableCollection<ADM_M030_P>());


        //    ParamitemList = new ObservableCollection<ADM_M030_P>();
        //    ParamValuesList = new ObservableCollection<ADM_M030_P>();
        //    ParamclearList = new ObservableCollection<ADM_M030_P>();
        //    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
        //    ParameterCollectionDesti = CollectionViewSource.GetDefaultView(ParamclearList);
        //    ParamitemList1 = new ObservableCollection<ADM_M030_P>();
        //    List<PPC_T001_PopUp> JobCart = new List<PPC_T001_PopUp>();

        //    SelectedMM_T001.ValidateAsync().Wait();
        //    _dataGridCollection.Refresh();
        //}
        //protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        //{
        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //    showMessageService.ButtonSetup = DialogButton.Ok;
        //    showMessageService.Caption = "Delete Changes";
        //    showMessageService.Text =
        //        String.Format(
        //            "This record will delete forever '{0}'",
        //                this.Title);

        //    if (showMessageService.ShowMessage() == DialogResult.Ok)
        //    {
        //        this.SelectedMM_T001.CancelEdit();
        //        string response = repository.Delete(SelectedMM_T001.id, "ProductConversion", "SCM");
        //        SelectedList.Remove(SelectedMM_T001);
        //        _dataGridCollection.Refresh();
        //        SelectedMM_T001 = new MM_T001();
        //        GoodsA = new ObservableCollection<MM_T001_A>();
        //    }
        //}
        //protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        //{
        //    SelectedMM_T001.CancelEdit();
        //}
        //protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        //{
        //    SelectedList = SelectedList;
        //}
        //protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_T001 = SelectedMM_T001;
        //}
        //protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_T001 = SelectedMM_T001;
        //}
        //protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_T001 = SelectedMM_T001;
        //}
        ////protected override void OnExportAction(InquiryActionResult<MM_T001> result)
        ////{
        ////    try
        ////    {
        ////        List<MM_T001> Export_List = new List<MM_T001>();
        ////        foreach (var o in DataGridCollection)
        ////        {
        ////            MM_T001 Data = o as MM_T001;
        ////            Export_List.Add(Data);
        ////        }

        ////        //--------------------------------------

        ////        ExportToExcel<MM_T001, List<MM_T001>> export = new ExportToExcel<MM_T001, List<MM_T001>>();
        ////        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        ////        export.dataToPrint = (List<MM_T001>)view.SourceCollection;

        ////        export.GenerateReport();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        ////        showMessageService.ButtonSetup = DialogButton.Ok;
        ////        showMessageService.Caption = "Message";
        ////        showMessageService.Text = String.Format(ex.Message, this.Title);
        ////        showMessageService.ShowMessage();
        ////    }

        ////}

        //#endregion

        //#region . Filters .

        //#region Filters For Movement Type
        //private void FilterCollectionMovType()
        //{
        //    if (_CollectionMovType != null)
        //    {
        //        _CollectionMovType.Refresh();
        //    }
        //}
        //public string FilterStringMovType
        //{
        //    get { return _filterStringMovType; }
        //    set
        //    {
        //        _filterStringMovType = value;
        //        RaisePropertychanged("FilterStringMovType");
        //        FilterCollectionMovType();
        //    }
        //}
        //public bool FilterMovType(object obj)
        //{
        //    var data = obj as MM_M004_Popup;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringMovType))
        //        {
        //            return (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterStringMovType.ToLower()) ||
        //                (data.mov_name != null && data.mov_name.ToString().ToLower().Contains(_filterStringItem.ToLower())));

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        ////#region Filters For Items
        ////private void FilterCollectionItem()
        ////{
        ////    if (_CollectionItem != null)
        ////    {
        ////        _CollectionItem.Refresh();
        ////    }
        ////}
        ////public string FilterStringItem
        ////{
        ////    get { return _filterStringItem; }
        ////    set
        ////    {
        ////        _filterStringItem = value;
        ////        RaisePropertychanged("FilterStringItem");
        ////        FilterCollectionItem();
        ////    }
        ////}
        ////public bool FilterItems(object obj)
        ////{
        ////    var data = obj as ADM_M022_PopUp_Inst;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterStringItem))
        ////        {
        ////            return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
        ////                   (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()));

        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}

        ////#endregion
        //#region Filters For ItemsS
        //private void FilterCollectionItemS()
        //{
        //    if (_CollectionItemS != null)
        //    {
        //        _CollectionItemS.Refresh();
        //    }
        //}
        //public string FilterStringItemS
        //{
        //    get { return _filterStringItemS; }
        //    set
        //    {
        //        _filterStringItemS = value;
        //        RaisePropertychanged("FilterStringItemS");
        //        FilterCollectionItemD();
        //    }
        //}
        //public bool FilterItemsS(object obj)
        //{
        //    var data = obj as PPC_T001_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringItemS))
        //        {
        //            return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterStringItemS.ToLower())) ||
        //                 (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItemS.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion
        //#region Filters For ItemsD
        //private void FilterCollectionItemD()
        //{
        //    if (_CollectionItemD != null)
        //    {
        //        _CollectionItemD.Refresh();
        //    }
        //}
        //public string FilterStringItemD
        //{
        //    get { return _filterStringItemD; }
        //    set
        //    {
        //        _filterStringItemD = value;
        //        RaisePropertychanged("FilterStringItemD");
        //        FilterCollectionItemD();
        //    }
        //}
        //public bool FilterItemsD(object obj)
        //{
        //    var data = obj as PPC_T001_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringItemD))
        //        {
        //            return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterStringItemD.ToLower())) ||
        //                 (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItemD.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For uom
        //private void FilterCollectionuom()
        //{
        //    if (_uomCollection != null)
        //    {
        //        _uomCollection.Refresh();
        //    }

        //}
        //public string FilterStringuom
        //{
        //    get { return _filterStringuom; }
        //    set
        //    {
        //        _filterStringuom = value;
        //        RaisePropertychanged("FilterStringuom");
        //        FilterCollectionuom();
        //    }
        //}
        //public bool uomFilter(object obj)
        //{
        //    var data = obj as Reflection.BusinessEntity.ADM_M038_B_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringuom))
        //        {
        //            return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringuom.ToLower()));

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion
        //#region Filters For uomD
        //private void FilterCollectionuomD()
        //{
        //    if (_uomCollectionD != null)
        //    {
        //        _uomCollectionD.Refresh();
        //    }

        //}
        //public string FilterStringuomD
        //{
        //    get { return _filterStringuomD; }
        //    set
        //    {
        //        _filterStringuomD = value;
        //        RaisePropertychanged("FilterStringuomD");
        //        FilterCollectionuomD();
        //    }
        //}
        //public bool uomFilterD(object obj)
        //{
        //    var data = obj as Reflection.BusinessEntity.ADM_M038_B_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringuomD))
        //        {
        //            return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringuomD.ToLower()));

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion
        ////#region Filters For Stock
        ////private void FilterCollectionStock()
        ////{
        ////    if (_StockCollection != null)
        ////    {
        ////        _StockCollection.Refresh();
        ////    }
        ////}
        ////public string FilterStringStock
        ////{
        ////    get { return _filterStringStock; }
        ////    set
        ////    {
        ////        _filterStringStock = value;
        ////        RaisePropertychanged("FilterStringStock");
        ////        FilterCollectionStock();
        ////    }
        ////}
        ////public bool FilterStock(object obj)
        ////{
        ////    var data = obj as PPC_T001_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterStringStock))
        ////        {
        ////            return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterStringStock.ToLower())) ||
        ////                 (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterStringStock.ToLower())) ||
        ////                 (data.description != null && data.description.ToString().ToLower().Contains(_filterStringItem.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}

        ////#endregion
        //#region Filters For JobCart
        //private void FilterCollectionJobCart()
        //{
        //    if (_JobCartCollection != null)
        //    {
        //        _JobCartCollection.Refresh();
        //    }
        //}
        //public string FilterStringJobCart
        //{
        //    get { return _filterStringJobCart; }
        //    set
        //    {
        //        _filterStringJobCart = value;
        //        RaisePropertychanged("FilterStringJobCart");
        //        FilterCollectionJobCart();
        //    }
        //}
        //public bool FilterJobCart(object obj)
        //{
        //    var data = obj as PPC_T001_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringJobCart))
        //        {
        //            return (data.source_doc_no != null && data.source_doc_no.ToString().ToLower().Contains(_filterStringJobCart.ToLower()))||
        //                (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterStringJobCart.ToLower())) ||
        //                (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringJobCart.ToLower())) ||
        //                (data.description != null && data.description.ToString().ToLower().Contains(_filterStringJobCart.ToLower())); 
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region "Filter for Back Content Datagrid"
        //public string FilterString
        //{
        //    get { return _filterString; }
        //    set
        //    {
        //        _filterString = value;
        //        RaisePropertychanged("FilterString");
        //        FilterCollection();
        //    }
        //}
        //private void FilterCollection()
        //{
        //    if (_dataGridCollection != null)
        //    {
        //        _dataGridCollection.Refresh();
        //    }
        //}
        //public bool Filter(object obj)
        //{
        //    var data = obj as MM_T001;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString))
        //        {
        //            return (data.post_date != null && data.post_date.ToString().Contains(_filterString.ToLower())) ||
        //            (data.mov_name != null && data.mov_name.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //                 (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString.ToLower()));
        //            //(data.average_wt_dt != null);
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        //#endregion

        //#endregion

    }
}
