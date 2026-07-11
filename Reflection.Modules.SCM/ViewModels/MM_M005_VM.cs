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
using Reflection.Modules.SCM.Views; 

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_M005_VM //: WindowViewModel<MM_M005>, INotifyPropertyChanged
    {
        //bool blNew = true;
        //Stock_Journal StckJurnl;
        //WebServiceRepository<MM_M005> repository = new WebServiceRepository<MM_M005>();
        //WebServiceRepository<MultipleContext_MM_M005> repositoryM = new WebServiceRepository<MultipleContext_MM_M005>();
        //MultipleContext_MM_M005 MCTemp = new MultipleContext_MM_M005();

        //private int _dgSelectedIndex;
        //private string _filterString;
        

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

        //#region MM_M005
        //private List<MM_M005> _SelectedList;
        //public List<MM_M005> SelectedList
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
        //private MM_M005 _SelectedMM_M005;
        //public MM_M005 SelectedMM_M005
        //{
        //    get
        //    {
        //        this.ErrorExist = _SelectedMM_M005.HasErrors;
        //        return _SelectedMM_M005;
        //    }
        //    set
        //    {
        //        if (_SelectedMM_M005 != value)
        //        {
        //            _SelectedMM_M005 = value;
        //            this.ErrorExist = _SelectedMM_M005.HasErrors;
        //            RaisePropertychanged("SelectedMM_M005");
        //            value.BeginEdit();
        //        }
        //    }
        //}
        //private static ObservableCollection<MM_M005> _Quant_Dtails = new ObservableCollection<MM_M005>();
        //public ObservableCollection<MM_M005> Quant_Dtails
        //{
        //    get { return _Quant_Dtails; }
        //    set
        //    {
        //        if (_Quant_Dtails != value)
        //        {
        //            _Quant_Dtails = value;

        //            RaisePropertychanged("Quant_Dtails");
        //        }
        //    }
        //}

        //private List<MM_M007> _SelectedStckJurnlData;
        //public List<MM_M007> SelectedStckJurnlData
        //{
        //    get
        //    {

        //        return _SelectedStckJurnlData;
        //    }
        //    set
        //    {
        //        if (_SelectedStckJurnlData != value)
        //        {
        //            _SelectedStckJurnlData = value;

        //            RaisePropertychanged("SelectedStckJurnlData");

        //        }
        //    }
        //}
        //#endregion
        //#region MM_M007
      
        //private List<MM_M007> _SelectedStckJurnlList;
        //public List<MM_M007> SelectedStckJurnlList
        //{
        //    get { return _SelectedStckJurnlList; }
        //    set
        //    {
        //        if (_SelectedStckJurnlList != value)
        //        {
        //            _SelectedStckJurnlList = value;
        //            RaisePropertychanged("SelectedStckJurnlList");

        //        }
        //    }
        //}
        //private static ObservableCollection<MM_M007_PopUp> _StckJurnl_Dtails = new ObservableCollection<MM_M007_PopUp>();
        //public ObservableCollection<MM_M007_PopUp> StckJurnl_Dtails
        //{
        //    get { return _StckJurnl_Dtails; }
        //    set
        //    {
        //        if (_StckJurnl_Dtails != value)
        //        {
        //            _StckJurnl_Dtails = value;

        //            RaisePropertychanged("StckJurnl_Dtails");
        //        }
        //    }
        //}

        //#endregion

        //#region ICollectionView
        //private ICollectionView _dataGridCollection;
        //public ICollectionView DataGridCollection
        //{
        //    get { return _dataGridCollection; }
        //    set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        //}
        //#endregion

        //#region RelayCommand
        //public RelayCommand<IList> SelectionChanged_godown_loation
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<object> SelectionChangedCommandItemDetails
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> ParameterPopupCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand CollectionChangedMethod
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandProdct
        //{
        //    get;
        //    private set;
        //}
        //#endregion

        //#region . Multiple Context . 
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
        //MultipleContext_MM_M005 _MC = new MultipleContext_MM_M005();
        //public MultipleContext_MM_M005 MC
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


        //#region . Item PopUp .

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

        //public MM_M005_VM() : base()
        //{
        //    SelectedList = new List<MM_M005>();
        //    SelectedMM_M005 = new MM_M005();  
        //    SelectedMM_M005.ValidateAsync().Wait();
        //    SelectedStckJurnlData = new List<MM_M007>();
        //    MC = new MultipleContext_MM_M005();
        //    ParamitemList = new ObservableCollection<ADM_M030_P>();
        //    ParamValuesList = new ObservableCollection<Parameter_PopUp>();

        //    SelectionChangedCommandItemDetails = new RelayCommand<object>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }
        //        LoadItemDetails(items);
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
        //    ParameterPopupCommand = new RelayCommand<IList>(
        //    items => { if (items == null) { return; } ParameterPopupClosed(items); });

        //    CollectionChangedMethod = new RelayCommand(CollectionChanged);            

        //    LoadInitialData();

        //}
        //private void GetSelectedProdctDetails(IList ProdctList)
        //{
        //    IList list = ProdctList as IList;
        //    List<MM_S003_PopUp> SelectedProdctDetailsTemp = list.Cast<MM_S003_PopUp>().ToList();
        //    if (SelectedProdctDetailsTemp.Count > 0)
        //    {
        //        SelectedMM_M005.item_id = Convert.ToString(SelectedProdctDetailsTemp[0].item_srno);
        //        SelectedMM_M005.ItemCode = SelectedProdctDetailsTemp[0].item_id;
        //        SelectedMM_M005.item_Name = SelectedProdctDetailsTemp[0].item_Name;
        //        SelectedMM_M005.Description = SelectedProdctDetailsTemp[0].item_Name;
        //        SelectedMM_M005.Stockable = SelectedProdctDetailsTemp[0].Stockable;
        //        SelectedMM_M005.SubCategCod = SelectedProdctDetailsTemp[0].SubCategCod;
        //        //SelectedMM_M005.batch_no = SelectedProdctDetailsTemp[0].batch_no;
        //        //SelectedMM_M005.sku = SelectedProdctDetailsTemp[0].sku;
        //        updateDescription();
        //        CollectionChanged();
                


        //    }
        //}

        //#region . User Defined Functions .
        //private void LoadInitialData()
        //{
        //    try
        //    {

        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_MM_M005>(MC, "MM_M005_Data", "StockChart", "SCM", "LoadAll", 0, "");
        //        SelectedList = MC.QuantMaster;


        //        //DataGridCollection = CollectionViewSource.GetDefaultView(MC.StockJournal);
        //        //DataGridCollection.Filter = new Predicate<object>(Filter);            

        //        ProdctCollection = CollectionViewSource.GetDefaultView(MC.Batch_Stock);
        //        ProdctCollection.Filter = new Predicate<object>(ProdctFilter);

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

        //private bool validateControls()
        //{
        //      int i = 0;
        //        if(SelectedMM_M005.ItemCode==null || SelectedMM_M005.ItemCode=="")
        //        {
        //             i = 1;
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Message";
        //            showMessageService.Text = String.Format("Please Item", this.Title);
        //            showMessageService.ShowMessage();
                   
        //        }
        //        else if (SelectedMM_M005.Stockable == true)
        //        {
        //            if (SelectedMM_M005.stockingunit == null || SelectedMM_M005.stockingunit == "")
        //            {
        //                i = 1;
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("Please Select Parameters", this.Title);
        //                showMessageService.ShowMessage();
                       
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
               
        //}
        //private void LoadItemDetails(object items)
        //{
        //    try
        //    {
        //        if (validateControls()==true)
        //        {

        //            string data_str;
        //            data_str = (string)items;

        //            List<MM_M007_PopUp> templist = new List<MM_M007_PopUp>();
        //            foreach (var temp in MC.StockJournal)
        //            {
        //                if (temp.ItemCode == SelectedMM_M005.ItemCode && temp.sku == SelectedMM_M005.stockingunit)
        //                {
        //                    templist.Add(temp);

        //                }
        //            }
        //            DataGridCollection = CollectionViewSource.GetDefaultView(templist);
        //            DataGridCollection.Filter = new Predicate<object>(Filter);
        //        }
        //    }
        //    catch { }
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

        //    if (SelectedMM_M005.Description != null)
        //    {
        //        if (SelectedMM_M005.Description.Contains('\t'))//Selectedpartylist.Count > 0 &&
        //        {
        //            if (Selectedpartylist[0].Name != null)
        //            {
        //                try
        //                {
        //                    if (Selectedpartylist[0].item_id == Convert.ToInt32(SelectedMM_M005.item_id)) //Item_id
        //                    {
        //                        if (param.Count > 0)
        //                        {
        //                            try
        //                            {
        //                                if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
        //                                {
        //                                    int itemid = Convert.ToInt32(SelectedMM_M005.item_id); //Item_id
        //                                    try
        //                                    {
        //                                        for (int e = 0; e < ParamitemList.Count; e++)
        //                                        {
        //                                            if (itemid == ParamitemList[e].item_id)
        //                                            {
        //                                                if (Selectedpartylist[0].Type == ParamitemList[e].Type)// && dgSelectedIndex == ParamitemList[e].count)
        //                                                {
        //                                                    ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == SelectedMM_M005.sku)
        //                                                    .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

        //                                                    ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == SelectedMM_M005.sku)
        //                                                  .ToList().ForEach(i => i.code = Selectedpartylist[0].code);
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                    catch
        //                                    {

        //                                    }
        //                                }
        //                                string code = "";
        //                                foreach (var item in FluteList)
        //                                {
        //                                    if (item.Name == Selectedpartylist[0].Name && item.Type == Selectedpartylist[0].Type)
        //                                    {
        //                                        strData = strData + " , " + item.Type + ":" + item.Name;
        //                                        strData = strData.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
        //                                        strData1 = strData1 + " , " + item.Type + ":" + item.code;
        //                                        strData1 = strData1.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
        //                                        code = Convert.ToString(item.code);
        //                                    }
        //                                }
        //                                string item1 = "";
        //                                string description = "";
        //                                try
        //                                {
        //                                    item1 = SelectedMM_M005.item_Name.ToString();
        //                                    description = SelectedMM_M005.Description.ToString();
        //                                }
        //                                catch
        //                                {

        //                                }
        //                                string[] split = new string[50];
        //                                string test = "";
        //                                string test1 = "";
        //                                if (item1.Contains("\t:" + Selectedpartylist[0].Type + ":"))
        //                                {
        //                                    test = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                    string y = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                    string z = item1.Replace(y, "");
        //                                    split = z.Split(':');
        //                                    test1 = item1.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + Selectedpartylist[0].Name + "\t");

        //                                    strData = test1;
        //                                    if (description.Contains(Selectedpartylist[0].Type))
        //                                    {
        //                                        string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                        string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
        //                                        string z1 = description.Replace(y1, "");
        //                                        split = z1.Split(':');
        //                                        string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");
        //                                        try
        //                                        {
        //                                            {
        //                                                strData1 = "";
        //                                                string[] stockvalues = new string[50];
        //                                                stockvalues = test2.Split('\t');
        //                                                for (int r = 0; r < stockvalues.Count(); r++)
        //                                                {
        //                                                    if (stockvalues[r] != "")
        //                                                    {
        //                                                        if (r == 0)
        //                                                        {
        //                                                            strData1 = stockvalues[0];
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            strData1 = strData1 + "\t" + stockvalues[r];
        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                        catch
        //                                        {

        //                                        }
        //                                    }

        //                                    SelectedMM_M005.Description = (strData1);
        //                                    SelectedMM_M005.item_Name = (strData);
        //                                }
        //                                else
        //                                {

        //                                    SelectedMM_M005.Description = (SelectedMM_M005.Description + "\t" + ":" + strData1);
        //                                    SelectedMM_M005.item_Name = (SelectedMM_M005.item_Name + "\t" + ":" + strData);
        //                                }
        //                            }
        //                            catch
        //                            {

        //                            }
        //                        }
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //                //Check stocking unit already exist or not
        //                try
        //                {
        //                    if (ValidateControls123() == true)
        //                    {
        //                        StockingUnitCalculation123();
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //            }

        //        }
        //    }


        //}
        //private void CollectionChanged()//IList DataList
        //{
        //    //IList list = DataList as IList;
        //    try
        //    {
        //        //List<MM_M007> Selectedpartylist = list.Cast<MM_M007>().ToList();
        //        if (SelectedMM_M005.Stockable == true)
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
        //            if (SelectedMM_M005.QuantID == 0 || SelectedMM_M005.QuantID == null)
        //            {
        //                //if (GoodsA.Count > 0)
        //                //{

        //                //if (dgSelectedIndex != -1)
        //                //{
        //                try
        //                {
        //                    int item_id = Convert.ToInt32(SelectedMM_M005.item_id);
        //                    int subcatcode = Convert.ToInt32(SelectedMM_M005.SubCategCod);

        //                    FluteList = MC.parameter_value_list;

        //                    var ParameterType = (from o in ParamValuesList
        //                                         where o.SubCatCode == subcatcode
        //                                         select o).ToList();

        //                    var itemlist = (from o in ParamitemList
        //                                    where o.item_id == item_id //&& o.count == dgSelectedIndex
        //                                    select o).ToList();
        //                    if (itemlist.Count == 0)
        //                    {
        //                        {
        //                            for (int r = 0; r < ParameterType.Count; r++)
        //                            {
        //                                ParamitemList.Add(new ADM_M030_P() { stockunit = SelectedMM_M005.sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                            }//count = dgSelectedIndex,
        //                        }
        //                    }
        //                    try
        //                    {
        //                        string[] values = SelectedMM_M005.sku.Split('/');
        //                        int count = values.Length;
        //                        for (int r = 0; r < count; r++)
        //                        {
        //                            var ParameterCollectionMethod = (from o in FluteList
        //                                                             where o.code == Convert.ToInt32(values[r].ToString())
        //                                                             select o).ToList();

        //                            ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == SelectedMM_M005.sku)
        //                                           .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                            //GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);

        //                    for (int r = 0; r < ParamitemList.Count; r++)
        //                    {
        //                        if (ParamitemList[r].item_id == item_id) //&& ParamitemList[r].count == dgSelectedIndex)
        //                        {
        //                            ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                            ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                        }
        //                    }
        //                    if (!SelectedMM_M005.item_Name.Contains('\t'))
        //                    {

        //                        MC.Batch_Stock = ProdctCollection.Cast<MM_S003_PopUp>().ToList();

        //                        string tnm = (from data in MC.Batch_Stock where data.item_id == SelectedMM_M005.ItemCode select data.item_Name).ToList()[0].ToString();
        //                        SelectedMM_M005.item_Name = "";
        //                        SelectedMM_M005.Description = "";

        //                        for (int y = 0; y < ParamitemList1.Count; y++)
        //                        {
        //                            if (y == 0)
        //                            {
        //                                SelectedMM_M005.item_Name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                SelectedMM_M005.Description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";

        //                            }
        //                            else
        //                            {
        //                                SelectedMM_M005.item_Name = SelectedMM_M005.item_Name + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                                SelectedMM_M005.Description = SelectedMM_M005.Description + "\t" + ":" + ParamitemList1[y].Type + ":";
        //                            }
        //                        }
        //                    }
        //                }
        //                catch
        //                {

        //                }

        //                //}

        //                //}
        //            }

        //            else if (SelectedMM_M005.QuantID != 0 || SelectedMM_M005.QuantID != null)
        //            {


        //                //if (dgSelectedIndex != -1)
        //                //{
        //                try
        //                {
        //                    int item_id = Convert.ToInt32(SelectedMM_M005.item_id);
        //                    int subcatcode = Convert.ToInt32(SelectedMM_M005.SubCategCod);

        //                    FluteList = MC.parameter_value_list;



        //                    var ParameterType = (from o in ParamValuesList
        //                                         where o.SubCatCode == subcatcode
        //                                         select o).ToList();

        //                    var itemlist = (from o in ParamitemList
        //                                    where o.item_id == item_id && o.stockunit == SelectedMM_M005.sku
        //                                    select o).ToList();
        //                    if (itemlist.Count == 0)
        //                    {
        //                        {
        //                            for (int r = 0; r < ParameterType.Count; r++)
        //                            {
        //                                ParamitemList.Add(new ADM_M030_P() { stockunit = SelectedMM_M005.sku, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
        //                            }//code = dgSelectedIndex,
        //                        }
        //                    }
        //                    try
        //                    {
        //                        string[] values = SelectedMM_M005.sku.Split('/');
        //                        int count = values.Length;
        //                        for (int r = 0; r < count; r++)
        //                        {

        //                            var ParameterCollectionMethod = (from o in FluteList
        //                                                             where o.code == Convert.ToInt32(values[r].ToString())
        //                                                             select o).ToList();

        //                            ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.item_id == item_id).Where(l => l.stockunit == SelectedMM_M005.sku)
        //                                                        .ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);

        //                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedValue = (ParameterCollectionMethod[0].Name));
        //                            FluteList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.selectedindex = (ParameterCollectionMethod[0].selectedindex));
        //                            // GoodsA[dgSelectedIndex].SelectedIndex = 0;
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
        //                    for (int r = 0; r < ParamitemList.Count; r++)
        //                    {
        //                        if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == SelectedMM_M005.sku)
        //                        {
        //                            ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
        //                            ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
        //                        }
        //                    }
        //                }
        //                catch
        //                {

        //                }
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
        //    try
        //    {
        //        parametervale = "";
        //        parametercode = "";
        //        string stockingunit = SelectedMM_M005.sku;
        //        string[] tokens = stockingunit.Split('/');
        //        int count = tokens.Length;
        //        while (count > 0)
        //        {
        //            string value = tokens[count - 1];
        //            if (value != "")
        //            {
        //                var myItem = (from o in MC.parameter_value_list
        //                              where o.code == Convert.ToInt32(value)
        //                              select o).ToList();
        //                if (parametervale == "")
        //                {
        //                    parametervale = myItem[0].Type + ":" + myItem[0].Name;
        //                    parametercode = myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
        //                }
        //                else
        //                {
        //                    parametervale = parametervale + "\t:" + myItem[0].Type + ":" + myItem[0].Name;
        //                    parametercode = parametercode + "\t:" + myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
        //                }
        //            }
        //            count = count - 1;
        //        }
        //        if (SelectedMM_M005.item_Name != "" || SelectedMM_M005 != null)
        //        {
        //            string t_itemname;
        //            if (SelectedMM_M005.item_Name.Contains("\t"))
        //            {
        //                t_itemname = SelectedMM_M005.item_Name.Substring(0, SelectedMM_M005.item_Name.IndexOf("\t"));
        //            }
        //            else
        //            {
        //                t_itemname = SelectedMM_M005.item_Name;
        //            }
        //            SelectedMM_M005.Description = t_itemname + "\t:" + parametercode;
        //            SelectedMM_M005.item_Name = t_itemname + "\t:" + parametervale;
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    //}
        //}
        //private void StockingUnitCalculationDesti()
        //{
        //    string ItemName = "";
        //    int count = 0;

        //    //for (int y = 0; y < GoodsA.Count; y++)
        //    //{
        //    try
        //    {
        //        ItemName = SelectedMM_M005.Description.ToString();
        //        if (SelectedMM_M005.ItemCode.Contains(":"))
        //        {
        //            string[] splititem = new string[50];
        //            splititem = SelectedMM_M005.ItemCode.Split(':');
        //            StckJurnlDtls.Where(l => l.ItemCode == SelectedMM_M005.ItemCode)
        //                                         .ToList().ForEach(i => i.ItemCode = splititem[0]);

        //        }
        //    }
        //    catch
        //    {

        //    }
        //    string stockingunit = "";

        //    try
        //    {

        //        {
        //            while (ItemName.Contains("\t"))
        //            {
        //                try
        //                {
        //                    string itemcode = ItemName.Substring(0, ItemName.LastIndexOf(":"));
        //                    string itemcode1 = ItemName.Replace(itemcode, "");
        //                    string itemcode2 = itemcode1.Replace(":", "");
        //                    if (count == 0)
        //                    {
        //                        SelectedMM_M005.sku = itemcode2;

        //                    }
        //                    else
        //                    {
        //                        SelectedMM_M005.sku = SelectedMM_M005.sku + "/" + itemcode2;

        //                    }
        //                    string itemcode3 = itemcode.Substring(0, ItemName.LastIndexOf("\t"));
        //                    ItemName = itemcode3;
        //                    count++;
        //                }
        //                catch
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //        count = 0;
        //    }
        //    catch
        //    {

        //    }
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
        //            try
        //            {
        //                description1 = SelectedMM_M005.item_Name.ToString();
        //                values = description1.Split('\t');
        //            }
        //            catch
        //            {

        //            }

        //            try
        //            {
        //                int item_id = Convert.ToInt32(SelectedMM_M005.item_id);
        //                int subcatcode = Convert.ToInt32(SelectedMM_M005.SubCategCod);
        //                var ParameterType = (from o in MC.ParamList
        //                                     where o.SubCatCode == subcatcode
        //                                     select o).ToList();
        //                for (int i1 = 0; i1 < values.Count(); i1++)
        //                {
        //                    string[] val = values[i1].Split(':');
        //                    try
        //                    {
        //                        if (i1 != 0)
        //                        {
        //                            if (val[2].ToString() != "")
        //                            {
        //                                i = 0;
        //                            }
        //                            else
        //                            {
        //                                i = 1;

        //                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                                showMessageService.ButtonSetup = DialogButton.Ok;
        //                                showMessageService.Caption = "Message";
        //                                showMessageService.Text = String.Format("Please Select All Parameter Value", this.Title);
        //                                showMessageService.ShowMessage();
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //            }
        //            catch
        //            {

        //            }
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
        //                    description1 = SelectedMM_M005.item_Name.ToString();
        //                    values = description1.Split('\t');
        //                }
        //                catch
        //                {

        //                }

        //                try
        //                {
        //                    int item_id = Convert.ToInt32(SelectedMM_M005.item_id);
        //                    int subcatcode = Convert.ToInt32(SelectedMM_M005.SubCategCod);
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
        //            description = SelectedMM_M005.Description.ToString();
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
        //                    int index = SelectedMM_M005.sku.IndexOf(':');
        //                    if (index != -1)
        //                    {
        //                        SelectedMM_M005.sku = SelectedMM_M005.sku.Substring(0, index - 1);
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
        //                                SelectedMM_M005.sku = "0";
        //                            }
        //                            else
        //                            {
        //                                SelectedMM_M005.sku = itemcode2;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
        //                            {
        //                                SelectedMM_M005.sku = "0";

        //                            }
        //                            else
        //                            {
        //                                SelectedMM_M005.sku = SelectedMM_M005.sku +"/"+itemcode2;

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
        //                stockvalues = SelectedMM_M005.sku.Split(':');
        //                string test = "";
        //                SelectedMM_M005.stockingunit = SelectedMM_M005.sku;
        //                ParamitemList.Where(l => l.item_id == Convert.ToInt32(SelectedMM_M005.item_id)).Where(l => l.stockunit == SelectedMM_M005.sku);//chk

        //            }
        //            count = 0;
        //        }
        //        catch
        //        {

        //        }


        //    }
        //}
        //#endregion
    
        //#region LoadAddressMaster
        //private void ShowChildWindow()
        //{
        //    StckJurnl = new  Stock_Journal();
        //    StckJurnl.ShowDialog();
        //}       

        //#endregion

        //#region · Command Actions ·
        //protected override void OnSaveAction(InquiryActionResult<MM_M005> result)
        //{
        //    try
        //    {

        //        //if (Avg_Wt_Details.Count > 0)
        //        //{
        //            //if (ValidateControls123() == false)
        //            //{
        //                SelectedMM_M005.add_by = AppSessionState.UserID;
        //                SelectedMM_M005.location_Id = AppSessionState.location_Id;

        //                ObjectSerializationService objSer = new ObjectSerializationService();
        //                //SelectedMM_M005.XmlDataDocument_ZSCM_T001_B = objSer.ObjectToXML(Avg_Wt_Details);

        //                if (blNew == true)
        //                {
        //                    SelectedMM_M005 = repository.SaveWithReturnDomainObject<MM_M005>(SelectedMM_M005, "StockChart", "SCM");
        //                    SelectedList.Add(SelectedMM_M005);
        //                    this.SelectedMM_M005.EndEdit();
        //                    blNew = false;
        //                }
        //                else if (blNew == false)
        //                {
        //                    SelectedMM_M005 = repository.UpdateWithReturnDomainObject<MM_M005>(SelectedMM_M005, "StockChart", "SCM");
        //                    this.SelectedMM_M005.EndEdit();
        //                }
        //                //if (SelectedMM_M005.XmlDataDocument_ZSCM_T001_B != null)
        //                //{
        //                //    MC.Avg_Wt_Details = (ObservableCollection<ZSCM_T001_B>)new ObjectSerializationService().XMLToObject(SelectedMM_M005.XmlDataDocument_ZSCM_T001_B, MC.Avg_Wt_Details);

        //                //}
        //                //else
        //                //{
        //                //    MC.Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();

        //                //}
        //                //Avg_Wt_Details = MC.Avg_Wt_Details;
        //                //_dataGridCollection.Refresh();
        //                MessageBox.Show("Record Saved Successfully");
        //            //}
        //        //}
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
        //protected override void OnCreateAction(InquiryActionResult<MM_M005> result)
        //{
        //    blNew = true;
        //    SelectedMM_M005 = new MM_M005();
        //    //SelectedZSCM_T001_B = new ZSCM_T001_B();
        //    SelectedMM_M005.ValidateAsync().Wait();
        //    //Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
        //    //WireSizeList = new ObservableCollection<ZADM_M003_PopUp>();
        //    //WireTypeList = new ObservableCollection<ZADM_M004_PopUp>();
        //    //TotLengthList = new ObservableCollection<ZADM_M008_PopUp>();
        //    //MakeList = new ObservableCollection<ADM_M0032_PopUp>();
        //    //_dataGridCollection.Refresh();
        //    //SelectedMM_M005.average_wt_dt = DateTime.Now;
        //}
        //protected override void OnRemoveAction(InquiryActionResult<MM_M005> result)
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
        //        this.SelectedMM_M005.CancelEdit();
        //        string response = repository.Delete(SelectedMM_M005.QuantID, "StockChart", "SCM");
        //        SelectedList.Remove(SelectedMM_M005);
        //        //_dataGridCollection.Refresh();
        //        SelectedMM_M005 = new MM_M005();
        //        //Avg_Wt_Details = new ObservableCollection<ZSCM_T001_B>();
        //    }
        //}
        //protected override void OnDiscardAction(InquiryActionResult<MM_M005> result)
        //{
        //    SelectedMM_M005.CancelEdit();
        //}
        //protected override void OnFevoriteAction(InquiryActionResult<MM_M005> result)
        //{
        //    SelectedList = SelectedList;
        //}
        //protected override void OnFlipAction(InquiryActionResult<MM_M005> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_M005 = SelectedMM_M005;
        //}
        //protected override void OnHelpAction(InquiryActionResult<MM_M005> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedMM_M005 = SelectedMM_M005;
        //}
        //protected override void OnPrintAction(InquiryActionResult<MM_M005> result)
        //{

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
        //        //_dataGridCollection.Refresh();
        //    }
        //}

        //public bool Filter(object obj)
        //{
        //    var data = obj as MM_M007_PopUp;
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

        ////ItemPopUp
        //private void FilterCollectionProdct()
        //{
        //    if (_ProdctCollection != null)
        //    {
        //        _ProdctCollection.Refresh();
        //    }

        //}
        //private string _filterStringProdct;
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
    }
}
