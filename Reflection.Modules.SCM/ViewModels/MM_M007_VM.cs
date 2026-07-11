using GalaSoft.MvvmLight.Command;
using Reflection.Modules.SCM.Views;
using Reflection.Presentation.ViewModel;
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
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_M007_VM //: WindowViewModel<MM_M007>, INotifyPropertyChanged
    {
        //bool blNew = true;
        //WebServiceRepository<MM_M007> repository = new WebServiceRepository<MM_M007>();
        //WebServiceRepository<MultipleContext_MM_M007> repositoryM = new WebServiceRepository<MultipleContext_MM_M007>();
        //MultipleContext_MM_M007 MCTemp = new MultipleContext_MM_M007();
        //private string _PartyId_Temp;
        //public string PartyId_Temp
        //{
        //    get { return _PartyId_Temp; }
        //    set
        //    {
        //        _PartyId_Temp = value;
        //        RaisePropertychanged("PartyId_Temp");
        //    }
        //}

        //private ICollectionView _dataGridCollection;
        //private string _filterString;
        //private string _filterStringProdct;
        //private string _filterStringBatch;
        //private string _filterStringStock_Chart;
        //private string _filterStringStock_Chart1;


        //#region "ICollectionView"
        //public ICollectionView DataGridCollection
        //{
        //    get { return _dataGridCollection; }
        //    set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        //}
        //private ICollectionView _ProdctCollection;
        //public ICollectionView ProdctCollection
        //{
        //    get { return _ProdctCollection; }
        //    set
        //    {
        //        _ProdctCollection = value;

        //        RaisePropertychanged("ProdctCollection");
        //    }
        //}
        //private ICollectionView _BatchCollection;
        //public ICollectionView BatchCollection
        //{
        //    get { return _BatchCollection; }
        //    set
        //    {
        //        _BatchCollection = value;

        //        RaisePropertychanged("BatchCollection");
        //    }
        //}
        //private ICollectionView _Stock_ChartCollection;
        //public ICollectionView Stock_ChartCollection
        //{
        //    get { return _Stock_ChartCollection; }
        //    set
        //    {
        //        _Stock_ChartCollection = value;

        //        RaisePropertychanged("Stock_ChartCollection");
        //    }
        //}
        //private ICollectionView _Stock_ChartCollection1;
        //public ICollectionView Stock_ChartCollection1
        //{
        //    get { return _Stock_ChartCollection1; }
        //    set
        //    {
        //        _Stock_ChartCollection1 = value;

        //        RaisePropertychanged("Stock_ChartCollection1");
        //    }
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
        //#endregion

        //#region "RelayCommand"
        //public RelayCommand<IList> SelectionChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandProdct
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandBatch
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandStock_Chart
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandStock_Chart1
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> ParameterPopupCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> CollectionChangedMethod
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandItemSource
        //{
        //    get;
        //    private set;
        //}
        //#endregion
        //#region MM_M007
        //private List<MM_M007> _SelectedList;
        //public List<MM_M007> SelectedList
        //{
        //    get { return _SelectedList; }
        //    set
        //    {
        //        if (_SelectedList != value)
        //        {
        //            _SelectedList = value;

        //            //if (PropertyChanged != null)
        //            //{
        //            RaisePropertychanged("SelectedList");
        //            //}
        //        }
        //    }
        //}

        //private MM_M007 _SelectedMM_M007;
        //public MM_M007 SelectedMM_M007
        //{
        //    get
        //    {
        //        this.ErrorExist = _SelectedMM_M007.HasErrors;
        //        return _SelectedMM_M007;
        //    }
        //    set
        //    {
        //        if (_SelectedMM_M007 != value)
        //        {
        //            _SelectedMM_M007 = value;


        //            RaisePropertychanged("SelectedMM_M007");
        //            if (_SelectedMM_M007 != null)
        //            {
        //                value.BeginEdit();
        //            }

        //            //}
        //        }
        //    }
        //}
        //private ObservableCollection<MM_M007> _StckJurnlDtls;
        //public ObservableCollection<MM_M007> StckJurnlDtls
        //{
        //    get { return _StckJurnlDtls; }
        //    set
        //    {
        //        _StckJurnlDtls = value;
        //        RaisePropertychanged("StckJurnlDtls");
        //    }
        //}
        //#endregion
        //#region MM_S003_PopUp
        //private MM_S003_PopUp _SelectedProdct;
        //public MM_S003_PopUp SelectedProdct
        //{
        //    get { return _SelectedProdct; }
        //    set
        //    {
        //        if (_SelectedProdct != value)
        //        {
        //            _SelectedProdct = value;
        //            RaisePropertychanged("SelectedProdct");

        //        }
        //    }
        //}
        //private List<MM_S003_PopUp> _SelectedListOfProdctList;
        //public List<MM_S003_PopUp> SelectedListOfProdctList
        //{
        //    get { return _SelectedListOfProdctList; }
        //    set
        //    {
        //        if (_SelectedListOfProdctList != value)
        //        {
        //            _SelectedListOfProdctList = value;
        //            RaisePropertychanged("SelectedListOfProdctList");
        //        }
        //    }
        //}
        //private ObservableCollection<MM_S003_PopUp> _ProdctDtls;
        //public ObservableCollection<MM_S003_PopUp> ProdctDtls
        //{
        //    get { return _ProdctDtls; }
        //    set
        //    {
        //        _ProdctDtls = value;
        //        RaisePropertychanged("ProdctDtls");
        //    }
        //}


        //#endregion
        //#region MM_M005_PopUp
        //private MM_M005_PopUp _SelectedStock_Chart;
        //public MM_M005_PopUp SelectedStock_Chart
        //{
        //    get { return _SelectedStock_Chart; }
        //    set
        //    {
        //        if (_SelectedStock_Chart != value)
        //        {
        //            _SelectedStock_Chart = value;
        //            RaisePropertychanged("SelectedStock_Chart");

        //        }
        //    }
        //}
        //private List<MM_M005_PopUp> _SelectedListOfStock_ChartList;
        //public List<MM_M005_PopUp> SelectedListOfStock_ChartList
        //{
        //    get { return _SelectedListOfStock_ChartList; }
        //    set
        //    {
        //        if (_SelectedListOfStock_ChartList != value)
        //        {
        //            _SelectedListOfStock_ChartList = value;
        //            RaisePropertychanged("SelectedListOfStock_ChartList");
        //        }
        //    }
        //}
        //private ObservableCollection<MM_M005_PopUp> _Stock_ChartDtls;
        //public ObservableCollection<MM_M005_PopUp> Stock_ChartDtls
        //{
        //    get { return _Stock_ChartDtls; }
        //    set
        //    {
        //        _Stock_ChartDtls = value;
        //        RaisePropertychanged("Stock_ChartDtls");
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

        //private ObservableCollection<Parameter_PopUp> _ParamValuesList;
        //public ObservableCollection<Parameter_PopUp> ParamValuesList
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

        //MultipleContext_MM_M007 _MC = new MultipleContext_MM_M007();
        //public MultipleContext_MM_M007 MC
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
        //public MM_M007_VM()
        //    : base()
        //{
        //    SelectedList = new List<MM_M007>();
        //    SelectedMM_M007 = new MM_M007();
        //    SelectedMM_M007.ValidateAsync().Wait();
        //    StckJurnlDtls = new ObservableCollection<MM_M007>();
        //    TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
        //    FluteList = new List<ADM_M030_P>();
        //    IndexList = new List<ADM_M030_P>();
        //    MakeList = new List<ParameterSelection>();
        //    ColourList = new List<ADM_M033>();
        //    SelectedParmeters = new List<ADM_M034_PopUp>();
        //    ParamValuesList = new ObservableCollection<Parameter_PopUp>();
        //    ParamitemList = new ObservableCollection<ADM_M030_P>();

        //    SelectionChangedCommand = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            //SelectedList = null;
        //            return;
        //        }
        //        GetSelectedList(items);
        //    });
        //    SelectionChangedCommandProdct = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedProdctDetails(items);
        //    });
        //    SelectionChangedCommandStock_Chart = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedStock_ChartDetails(items);
        //    });
        //    SelectionChangedCommandStock_Chart1 = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedStock_ChartDetails1(items);
        //    });
        //    SelectionChangedCommandBatch = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedBatch(items);
        //    });
        //    CollectionChangedMethod = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } CollectionChanged(); });
        //    ParameterPopupCommand = new RelayCommand<IList>(
        //   items => { if (items == null) { return; } ParameterPopupClosed(items); });

        //    LoadInitialData();
        //    SelectedMM_M007.SourceLoc = PartyId_Temp;

        //}

        //private void GetSelectedBatch(IList items)
        //{
        //    try
        //    {
        //         IList list = items as IList;
        //    List<MM_S003_PopUp> SelectedProdctDetailsTemp = list.Cast<MM_S003_PopUp>().ToList();
        //    if (SelectedProdctDetailsTemp.Count > 0)
        //    {
        //        SelectedMM_M007.batch_no = SelectedProdctDetailsTemp[0].batch_no;
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
       
        //private void LoadInitialData()
        //{

        //    try
        //    {
        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_M007>(MC, "MM_M007_Data", "Stock_Journal", "SCM", AppSessionState.comp_code, 0, AppSessionState.location_Id);
        //        SelectedList = MC.StckJurnl;

        //        ProdctCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
        //        ProdctCollection.Filter = new Predicate<object>(ProdctFilter);

        //        Stock_ChartCollection = CollectionViewSource.GetDefaultView(MC.Stock_Chart);
        //        Stock_ChartCollection.Filter = new Predicate<object>(Stock_ChartFilter);


        //        Stock_ChartCollection1 = CollectionViewSource.GetDefaultView(MC.Stock_Chart);
        //        Stock_ChartCollection1.Filter = new Predicate<object>(Stock_ChartFilter1); 
                
        //        DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
        //        DataGridCollection.Filter = new Predicate<object>(Filter);
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
        //private void GetSelectedList(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<MM_M007> tSelectedItemsList = list.Cast<MM_M007>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedMM_M007 = (MM_M007)tSelectedItemsList[0];
        //        //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_M007>(MCTemp, "MM_M007_Data", "Stock_Journal", "SCM", "Stock_Journal_Detail", 0, SelectedMM_M007.trnsID.ToString());
        //        //if (SelectedMM_M007 != null)
        //        //{
        //        //    MC.StckJurnl = MCTemp.StckJurnl;
        //        //    SelectedList = MCTemp.StckJurnl;
        //        //}
        //        blNew = false;
        //        updateDescription();
        //        CollectionChanged();
        //    }
        //}
        //private void GetSelectedProdctDetails(IList ProdctList)
        //{
        //    IList list = ProdctList as IList;
        //    List<MM_S003_PopUp> SelectedProdctDetailsTemp = list.Cast<MM_S003_PopUp>().ToList();
        //    if (SelectedProdctDetailsTemp.Count > 0)
        //    {
        //        SelectedMM_M007.item_id =Convert.ToString(SelectedProdctDetailsTemp[0].item_srno);
        //        SelectedMM_M007.ItemCode = SelectedProdctDetailsTemp[0].item_id;
        //        SelectedMM_M007.item_Name = SelectedProdctDetailsTemp[0].item_Name;
        //        SelectedMM_M007.Description = SelectedProdctDetailsTemp[0].item_Name;
        //        SelectedMM_M007.Stockable = SelectedProdctDetailsTemp[0].Stockable;
        //        SelectedMM_M007.SubCategCod = SelectedProdctDetailsTemp[0].SubCategCod;
        //        //SelectedMM_M007.batch_no = SelectedProdctDetailsTemp[0].batch_no;
        //        //SelectedMM_M007.sku = SelectedProdctDetailsTemp[0].sku;
        //        updateDescription();
        //        CollectionChanged();
                
        //    }
        //}
        //private void GetSelectedStock_ChartDetails(IList Stock_ChartList)
        //{
        //    IList list = Stock_ChartList as IList;
        //    List<MM_M005_PopUp> SelectedStock_ChartDetailsTemp = list.Cast<MM_M005_PopUp>().ToList();
        //    if (SelectedStock_ChartDetailsTemp.Count > 0)
        //    {
        //        SelectedMM_M007.SourceLoc = SelectedStock_ChartDetailsTemp[0].QuantName;
        //    }
        //}
        //private void GetSelectedStock_ChartDetails1(IList Stock_ChartList)
        //{
        //    IList list = Stock_ChartList as IList;
        //    List<MM_M005_PopUp> SelectedStock_ChartDetailsTemp = list.Cast<MM_M005_PopUp>().ToList();
        //    if (SelectedStock_ChartDetailsTemp.Count > 0)
        //    {
        //        SelectedMM_M007.DestLoc = SelectedStock_ChartDetailsTemp[0].QuantName;
        //    }
        //}

        //#region Methods
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

        //#region Item Description with parameter for Source
        //private void ParameterPopupClosed(IList param)
        //{

        //    string strData = "";
        //    string strData1 = "";
        //    ADM_M030_P productData = new ADM_M030_P();
        //    ADM_M030_P productData1 = new ADM_M030_P();
        //    IList list = param as IList;
        //    List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();

        //    if (SelectedMM_M007.Description != null)
        //        {
        //            if (SelectedMM_M007.Description.Contains('\t'))//Selectedpartylist.Count > 0 &&
        //            {
        //                if (Selectedpartylist[0].Name != null)
        //                {
        //                    try
        //                    {
        //                        if (Selectedpartylist[0].item_id == Convert.ToInt32(SelectedMM_M007.item_id)) //Item_id
        //                        {
        //                            if (param.Count > 0)
        //                            {
        //                                try
        //                                {
        //                                    if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
        //                                    {
        //                                        int itemid = Convert.ToInt32(SelectedMM_M007.item_id); //Item_id
        //                                        try
        //                                        {
        //                                            for (int e = 0; e < ParamitemList.Count; e++)
        //                                            {
        //                                                if (itemid == ParamitemList[e].item_id)
        //                                                {
        //                                                    if (Selectedpartylist[0].Type == ParamitemList[e].Type)// && dgSelectedIndex == ParamitemList[e].count)
        //                                                    {
        //                                                        ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == SelectedMM_M007.sku)
        //                                                        .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

        //                                                        ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == SelectedMM_M007.sku)
        //                                                      .ToList().ForEach(i => i.code = Selectedpartylist[0].code);
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
        //                                        item1 = SelectedMM_M007.item_Name.ToString();
        //                                        description = SelectedMM_M007.Description.ToString();
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
                                               
        //                                        SelectedMM_M007.Description = (strData1);
        //                                        SelectedMM_M007.item_Name = (strData);
        //                                    }
        //                                    else
        //                                    {

        //                                        SelectedMM_M007.Description = (SelectedMM_M007.Description + "\t" + ":" + strData1);
        //                                        SelectedMM_M007.item_Name = (SelectedMM_M007.item_Name + "\t" + ":" + strData);
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
           

        //}
        //private void CollectionChanged()//IList DataList
        //{
        //    //IList list = DataList as IList;
        //    try
        //    {
        //        //List<MM_M007> Selectedpartylist = list.Cast<MM_M007>().ToList();
        //        if (SelectedMM_M007.Stockable == true)
        //        {
        //            ParamitemList1 = new ObservableCollection<ADM_M030_P>();
        //            TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.parameter_list);
        //            if (ParamValuesList.Count == 0)
        //            {
        //                for (int i = 0; i < TotalParameterCollection.Cast<Parameter_PopUp>().ToList().Count(); i++)
        //                {
        //                    ParamValuesList.Add(TotalParameterCollection.Cast<Parameter_PopUp>().ElementAt(i));
        //                }
        //            }
        //            if (SelectedMM_M007.trnsID == 0 || SelectedMM_M007.trnsID == null)
        //            {
        //                //if (GoodsA.Count > 0)
        //                //{
                            
        //                            //if (dgSelectedIndex != -1)
        //                            //{
        //                                try
        //                                {
        //                                    int item_id = Convert.ToInt32(SelectedMM_M007.item_id);
        //                                    int subcatcode = Convert.ToInt32(SelectedMM_M007.SubCategCod);

        //                                    FluteList = MC.parameter_value_list;

        //                                    var ParameterType = (from o in ParamValuesList
        //                                                         where o.SubCatCode == subcatcode
        //                                                         select o).ToList();

        //                                    var itemlist = (from o in ParamitemList
        //                                                    where o.item_id == item_id //&& o.count == dgSelectedIndex
        //                                                    select o).ToList();
        //                                    if (itemlist.Count == 0)
        //                                    {
        //                                        {
        //                                            for (int r = 0; r < ParameterType.Count; r++)
        //                                            {
        //                                                ParamitemList.Add(new ADM_M030_P() { stockunit = SelectedMM_M007.sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                                            }//count = dgSelectedIndex,
        //                                        }
        //                                    }
        //                                    try
        //                                    {
        //                                        string[] values = SelectedMM_M007.sku.Split('/');
        //                                        int count = values.Length;
        //                                        for (int r = 0; r < count; r++)
        //                                        {
        //                                            var ParameterCollectionMethod = (from o in FluteList
        //                                                                             where o.code == Convert.ToInt32(values[r].ToString())
        //                                                                             select o).ToList();

        //                                            ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == SelectedMM_M007.sku)
        //                                                           .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                                            //GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                                        }
        //                                    }
        //                                    catch
        //                                    {

        //                                    }
        //                                    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);

        //                                    for (int r = 0; r < ParamitemList.Count; r++)
        //                                    {
        //                                        if (ParamitemList[r].item_id == item_id) //&& ParamitemList[r].count == dgSelectedIndex)
        //                                        {
        //                                            ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                                            ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                                        }
        //                                    }
        //                                    if (!SelectedMM_M007.item_Name.Contains('\t'))
        //                                    {

        //                                        MC.ItemList = ProdctCollection.Cast<MM_S003_PopUp>().ToList();

        //                                        string tnm = (from data in MC.ItemList where data.item_id == SelectedMM_M007.ItemCode select data.item_Name).ToList()[0].ToString();
        //                                        SelectedMM_M007.item_Name = "";
        //                                        SelectedMM_M007.Description = "";

        //                                        for (int y = 0; y < ParamitemList1.Count; y++)
        //                                        {
        //                                            if (y == 0)
        //                                            {
        //                                                SelectedMM_M007.item_Name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                                SelectedMM_M007.Description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";

        //                                            }
        //                                            else
        //                                            {
        //                                                SelectedMM_M007.item_Name = SelectedMM_M007.item_Name + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                                SelectedMM_M007.Description = SelectedMM_M007.Description + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                catch
        //                                {

        //                                }

        //                            //}
                               
        //                //}
        //            }

        //            else if (SelectedMM_M007.trnsID != 0 || SelectedMM_M007.trnsID != null)
        //            {
                   

        //                //if (dgSelectedIndex != -1)
        //                //{
        //                    try
        //                    {
        //                        int item_id = Convert.ToInt32(SelectedMM_M007.item_id);
        //                        int subcatcode = Convert.ToInt32(SelectedMM_M007.SubCategCod);

        //                        FluteList = MC.parameter_value_list;



        //                        var ParameterType = (from o in ParamValuesList
        //                                             where o.SubCatCode == subcatcode
        //                                             select o).ToList();

        //                        var itemlist = (from o in ParamitemList
        //                                        where o.item_id == item_id && o.stockunit == SelectedMM_M007.sku
        //                                        select o).ToList();
        //                        if (itemlist.Count == 0)
        //                        {
        //                            {
        //                                for (int r = 0; r < ParameterType.Count; r++)
        //                                {
        //                                    ParamitemList.Add(new ADM_M030_P() {  stockunit = SelectedMM_M007.sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                                }//code = dgSelectedIndex,
        //                            }
        //                        }
        //                        try
        //                        {
        //                            string[] values = SelectedMM_M007.sku.Split('/');
        //                            int count = values.Length;
        //                            for (int r = 0; r < count; r++)
        //                            {

        //                                var ParameterCollectionMethod = (from o in FluteList
        //                                                                 where o.code == Convert.ToInt32(values[r].ToString())
        //                                                                 select o).ToList();

        //                                ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == SelectedMM_M007.sku)
        //                                                            .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                                FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                                FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                               // GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                            }
        //                        }
        //                        catch
        //                        {

        //                        }
        //                        ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
        //                        for (int r = 0; r < ParamitemList.Count; r++)
        //                        {
        //                            if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == SelectedMM_M007.sku)
        //                            {
        //                                ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                                ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                            }
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                //}
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
        //private void updateDescription()
        //{
        //    string parametervale = "";
        //    string parametercode = "";


        //    //for (int y = 0; y < StckJurnl.Count; y++)
        //    //{
        //        try
        //        {
        //            parametervale = "";
        //            parametercode = "";
        //            string stockingunit = SelectedMM_M007.sku;
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
        //            if (SelectedMM_M007.item_Name != "" || SelectedMM_M007 != null)
        //            {
        //                string t_itemname;
        //                if (SelectedMM_M007.item_Name.Contains("\t"))
        //                {
        //                    t_itemname = SelectedMM_M007.item_Name.Substring(0, SelectedMM_M007.item_Name.IndexOf("\t"));
        //                }
        //                else
        //                {
        //                    t_itemname = SelectedMM_M007.item_Name;
        //                }
        //                SelectedMM_M007.Description = t_itemname + "\t:" + parametercode;
        //                SelectedMM_M007.item_Name = t_itemname + "\t:" + parametervale;
        //            }
        //        }
        //        catch
        //        {

        //        }

        //    //}
        //}
        //private void StockingUnitCalculationDesti()
        //{
        //    string ItemName = "";
        //    int count = 0;

        //    //for (int y = 0; y < GoodsA.Count; y++)
        //    //{
        //        try
        //        {
        //            ItemName = SelectedMM_M007.Description.ToString();
        //            if (SelectedMM_M007.ItemCode.Contains(":"))
        //            {
        //                string[] splititem = new string[50];
        //                splititem = SelectedMM_M007.ItemCode.Split(':');
        //                StckJurnlDtls.Where(l => l.ItemCode == SelectedMM_M007.ItemCode)
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
        //                            SelectedMM_M007.sku = itemcode2;

        //                        }
        //                        else
        //                        {
        //                            SelectedMM_M007.sku = SelectedMM_M007.sku + "/" + itemcode2;

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
        //    //}

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
        //            //for (int y = 0; y < GoodsA.Count; y++)
        //            //{
        //                try
        //                {
        //                    description1 = SelectedMM_M007.item_Name.ToString();
        //                    values = description1.Split('\t');
        //                }
        //                catch
        //                {

        //                }

        //                try
        //                {
        //                    int item_id = Convert.ToInt32(SelectedMM_M007.item_id);
        //                    int subcatcode = Convert.ToInt32(SelectedMM_M007.SubCategCod);
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
        //                            if (i == 1)
        //                            {
        //                                break;
        //                            }
        //                        }
        //                        catch
        //                        {

        //                        }
        //                        if(i==1)
        //                        {
        //                            break;
        //                        }
        //                    }                           

        //                }
        //                catch
        //                {

        //                }
        //            //}

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        {
        //            foreach (var item in StckJurnlDtls)
        //            {
        //                var duplicateitem = (from o in StckJurnlDtls
        //                                     where o.item_id == item.item_id && o.stocking_unit1 == item.stocking_unit1
        //                                     && o.batch_no == item.batch_no

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
        //            if (SelectedMM_M007.ItemCode == "" || SelectedMM_M007.ItemCode == null)
        //            {
        //                i = 1;
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("Please Select Item Code", this.Title);
        //                showMessageService.ShowMessage();
        //            }
        //        }
        //        if (i == 0)
        //        {
        //            if (SelectedMM_M007.item_Name == "" || SelectedMM_M007.item_Name == null)
        //            {
        //                i = 1;
        //            }
        //        }
        //        if (i == 0)
        //        {
        //            if (SelectedMM_M007.Qty == 0 || SelectedMM_M007.Qty == null)
        //            {
        //                i = 1;
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("Please Select Qty", this.Title);
        //                showMessageService.ShowMessage();
        //            }
        //        }
        //        if (i == 0)
        //        {
        //            if (SelectedMM_M007.SourceLoc == "" || SelectedMM_M007.SourceLoc == null)
        //            {
        //                i = 1;
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("Please Select Source Location", this.Title);
        //                showMessageService.ShowMessage();
        //            }
        //        }
        //        if (i == 0)
        //        {
        //            if (SelectedMM_M007.TrnsType == "Stock Move")
        //            {
        //                if (SelectedMM_M007.DestLoc == "" || SelectedMM_M007.DestLoc == null)
        //                {
        //                    i = 1;
        //                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                    showMessageService.ButtonSetup = DialogButton.Ok;
        //                    showMessageService.Caption = "Message";
        //                    showMessageService.Text = String.Format("Please Select DEstination Location", this.Title);
        //                    showMessageService.ShowMessage();
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
        //        return false;
        //    }
        //    // quantityCompare();

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
        //                    description1 = SelectedMM_M007.item_Name.ToString();
        //                    values = description1.Split('\t');
        //                }
        //                catch
        //                {

        //                }

        //                try
        //                {
        //                    int item_id = Convert.ToInt32(SelectedMM_M007.item_id);
        //                    int subcatcode = Convert.ToInt32(SelectedMM_M007.SubCategCod);
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
        //            description = SelectedMM_M007.Description.ToString();
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
        //                    int index = SelectedMM_M007.sku.IndexOf(':');
        //                    if (index != -1)
        //                    {
        //                        SelectedMM_M007.sku = SelectedMM_M007.sku.Substring(0, index - 1);
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
        //                                SelectedMM_M007.sku = "0";
        //                            }
        //                            else
        //                            {
        //                                SelectedMM_M007.sku = itemcode2;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
        //                            {
        //                                SelectedMM_M007.sku = "0";

        //                            }
        //                            else
        //                            {
        //                                SelectedMM_M007.sku = itemcode2;

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
        //                stockvalues = SelectedMM_M007.sku.Split(':');
        //                string test = "";
        //                SelectedMM_M007.stockingunit = SelectedMM_M007.sku;
        //                ParamitemList.Where(l => l.item_id == Convert.ToInt32(SelectedMM_M007.item_id)).Where(l => l.stockunit == SelectedMM_M007.sku);//chk

        //            }
        //            count = 0;
        //        }
        //        catch
        //        {

        //        }


        //    }
        //    //---------------------Batch inCollection
        //    if (SelectedMM_M007.sku != null || SelectedMM_M007.sku != "")
        //    {
        //        var batches = (from data in MC.Batch_Stock where data.item_id == SelectedMM_M007.ItemCode && data.sku == SelectedMM_M007.sku select data ).ToList();
                
        //        BatchCollection = CollectionViewSource.GetDefaultView(batches);
        //        BatchCollection.Filter = new Predicate<object>(BatchFilter);
        //        SelectedMM_M007.batch_no = null;
        //    }

        //}
        //#endregion

        //#region · Command Actions ·
        //protected override void OnSaveAction(InquiryActionResult<MM_M007> result)
        //{
        //    try
        //    {
        //        this.SelectedMM_M007.EndEdit();
        //        SelectedMM_M007.add_by = AppSessionState.UserID;
        //        SelectedMM_M007.comp_code = AppSessionState.comp_code;
        //        SelectedMM_M007.location_Id = AppSessionState.location_Id;

        //        try
        //        {
                    
        //            StockingUnitCalculationDesti();
        //        }
        //        catch
        //        {

        //        }
        //         if (ValidateControls() == true)
        //        {                 
        //            if (blNew == true)
        //            {
        //                //if (SelectedMM_M007.TrnsType == "Stock Enter")
        //                {
        //                    SelectedMM_M007 = repository.SaveWithReturnDomainObject<MM_M007>(SelectedMM_M007, "Stock_Journal", "SCM");
        //                    SelectedList.Add(SelectedMM_M007);
        //                    DataGridCollection.Refresh();
        //                    blNew = false;
        //                }  
        //                //else
        //                {
        //                    //SelectedMM_M007 = repository.UpdateWithReturnDomainObject<MM_M007>(SelectedMM_M007, "Stock_Journal", "SCM");
        //                    //SelectedList.Add(SelectedMM_M007);
        //                    //DataGridCollection.Refresh();
        //                    //blNew = false;
        //                }
        //            }
        //            else if (blNew == false)
        //            {
        //                //if (SelectedMM_M007.TrnsType == "Stock Remove" || SelectedMM_M007.TrnsType == "Stock Move")
        //                {
        //                    //SelectedMM_M007 = repository.UpdateWithReturnDomainObject<MM_M007>(SelectedMM_M007, "Stock_Journal", "SCM");
        //                    //SelectedList.Add(SelectedMM_M007);
        //                    //DataGridCollection.Refresh();
        //                   // blNew = false;
        //                }
        //            }
        //            updateDescription();
        //            DataGridCollection.Refresh();
        //        }
        //         else
        //         {                    
        //         }
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
        ////protected override void OnExportAction(InquiryActionResult<MM_M007> result)
        ////{
        ////    try
        ////    {
        ////        ExportToExcel<MM_M007, List<MM_M007>> export = new ExportToExcel<MM_M007, List<MM_M007>>();
        ////        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        ////        export.dataToPrint = (List<MM_M007>)view.SourceCollection;
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
        //protected override void OnCreateAction(InquiryActionResult<MM_M007> result)
        //{
        //    SelectedMM_M007 = new MM_M007();
        //    blNew = true;
        //    ParameterCollection = CollectionViewSource.GetDefaultView(new ObservableCollection<ADM_M030_P>());
        //    ParamitemList = new ObservableCollection<ADM_M030_P>();
        //    ParamValuesList = new ObservableCollection<Parameter_PopUp>();
        //    ParamclearList = new ObservableCollection<ADM_M030_P>();
        //    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
        //    ParamitemList1 = new ObservableCollection<ADM_M030_P>();
        //    SelectedMM_M007.ValidateAsync().Wait();
        //    _dataGridCollection.Refresh();
        //}
        //protected override void OnRemoveAction(InquiryActionResult<MM_M007> result)
        //{
        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //    showMessageService.ButtonSetup = DialogButton.Ok;
        //    showMessageService.Caption = "Delete Changes";
        //    showMessageService.Text =
        //        String.Format(
        //            "This record will Be Deleted forever '{0}'",
        //                this.Title);

        //    if (showMessageService.ShowMessage() == DialogResult.Ok)
        //    {
        //        string response = repository.Delete(SelectedMM_M007.trnsID, "Stock_Journal", "SCM");
        //        SelectedList.Remove(SelectedMM_M007);
        //        _dataGridCollection.Refresh();
        //        SelectedMM_M007 = new MM_M007();
        //    }
        //}
        //protected override void OnDiscardAction(InquiryActionResult<MM_M007> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_M007 = SelectedMM_M007;
        //}
        //protected override void OnFevoriteAction(InquiryActionResult<MM_M007> result)
        //{
        //    SelectedList = SelectedList;
        //}
        //protected override void OnFlipAction(InquiryActionResult<MM_M007> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_M007 = SelectedMM_M007;
        //}
        //protected override void OnHelpAction(InquiryActionResult<MM_M007> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_M007 = SelectedMM_M007;
        //}
        //protected override void OnPrintAction(InquiryActionResult<MM_M007> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_M007 = SelectedMM_M007;
        //}

        //#endregion

        //#region "Filter"
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
        //    var data = obj as MM_M007;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString))
        //        {
        //            return (data.TrnsType != null && data.TrnsType.ToLower().Contains(_filterString.ToLower())) ||
        //                (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //               (data.sku != null && data.sku.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //               (data.SourceLoc != null && data.SourceLoc.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //             (data.DestLoc != null && data.DestLoc.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        ////country filter
        ////public string FilterStringcountry
        ////{
        ////    get { return _filterStringcountry; }
        ////    set
        ////    {
        ////        _filterStringcountry = value;
        ////        RaisePropertychanged("FilterStringcountry");
        ////        FilterCollectioncountry();
        ////    }
        ////}
        ////private void FilterCollectioncountry()
        ////{
        ////    if (_countryCollection != null)
        ////    {
        ////        _countryCollection.Refresh();
        ////    }
        ////}
        ////public bool Filtercountry(object obj)
        ////{
        ////    var data = obj as Reflection.BusinessEntity.ADM_M012_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterStringcountry))
        ////        {
        ////            return (data.CntryName != null && data.CntryName.ToLower().Contains(_filterStringcountry.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}
        ////state filter        
        //#endregion
        //#region Filters For Prodct
        //private void FilterCollectionProdct()
        //{
        //    if (_ProdctCollection != null)
        //    {
        //        _ProdctCollection.Refresh();
        //    }

        //}
        //public string FilterStringProdct
        //{
        //    get { return _filterStringProdct; }
        //    set
        //    {
        //        _filterStringProdct = value;
        //        RaisePropertychanged("FilterStringProdct");
        //        FilterCollectionProdct();
        //    }
        //}
        //public bool ProdctFilter(object obj)
        //{
        //    var data = obj as MM_S003_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringProdct))
        //        {
        //            return (

        //                (data.item_id != null && data.item_id.ToString().ToLower().Contains(_filterStringProdct.ToLower()))

        //                );

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region 'batch'
        //private void FilterCollectionBatch()
        //{
        //    if (_BatchCollection != null)
        //    {
        //        _BatchCollection.Refresh();
        //    }

        //}
        //public string FilterStringBatch
        //{
        //    get { return _filterStringBatch; }
        //    set
        //    {
        //        _filterStringBatch = value;
        //        RaisePropertychanged("FilterStringBatch");
        //        FilterCollectionBatch();
        //    }
        //}
        //public bool BatchFilter(object obj)
        //{
        //    var data = obj as MM_S003_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringBatch))
        //        {
        //            return (

        //                (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterStringBatch.ToLower()))

        //                );

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion


        //#region Filters For Stock_Chart
        //private void FilterCollectionStock_Chart()
        //{
        //    if (_Stock_ChartCollection != null)
        //    {
        //        _Stock_ChartCollection.Refresh();
        //    }

        //}
        //public string FilterStringStock_Chart
        //{
        //    get { return _filterStringStock_Chart; }
        //    set
        //    {
        //        _filterStringStock_Chart = value;
        //        RaisePropertychanged("FilterStringStock_Chart");
        //        FilterCollectionStock_Chart();
        //    }
        //}
        //public bool Stock_ChartFilter(object obj)
        //{
        //    var data = obj as MM_M005_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringStock_Chart))
        //        {
        //            return (

        //                (data.QuantName != null && data.QuantName.ToString().ToLower().Contains(_filterStringStock_Chart.ToLower()))

        //                );

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion
        //#region Filters For Stock_Chart1
        //private void FilterCollectionStock_Chart1()
        //{
        //    if (_Stock_ChartCollection1 != null)
        //    {
        //        _Stock_ChartCollection1.Refresh();
        //    }

        //}
        //public string FilterStringStock_Chart1
        //{
        //    get { return _filterStringStock_Chart1; }
        //    set
        //    {
        //        _filterStringStock_Chart1 = value;
        //        RaisePropertychanged("FilterStringStock_Chart1");
        //        FilterCollectionStock_Chart1();
        //    }
        //}
        //public bool Stock_ChartFilter1(object obj)
        //{
        //    var data = obj as MM_M005_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringStock_Chart1))
        //        {
        //            return (

        //                (data.QuantName != null && data.QuantName.ToString().ToLower().Contains(_filterStringStock_Chart.ToLower()))

        //                );

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion
    }

}
