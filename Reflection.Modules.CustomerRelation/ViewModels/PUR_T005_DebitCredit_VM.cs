using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows.Controls;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    // public class PUR_T005_DebitCredit_VM : WindowViewModel<PUR_T005_A>, INotifyPropertyChanged
    //{
    //     #region .  .


    //     bool blNew = true;
    //     WebServiceRepository<PUR_T005_A> repository = new WebServiceRepository<PUR_T005_A>();
    //     WebServiceRepository<MultipleContext_PUR_T005_A> repository_MC = new WebServiceRepository<MultipleContext_PUR_T005_A>();

    //     MultipleContext_PUR_T005_A _MC = new MultipleContext_PUR_T005_A();
    //     public MultipleContext_PUR_T005_A MC
    //     {
    //         get { return _MC; }
    //         set
    //         {
    //             if (_MC != value)
    //             {
    //                 _MC = value;

    //                 RaisePropertyChanged("MC");
    //             }
    //         }
    //     }

    //     MultipleContext_PUR_T005_A MC_temp = new MultipleContext_PUR_T005_A();

    //     private string _filterString_AllPOData;
    //     private string _filterString_party;
    //     private string _filterString_requsition;
    //     private string _filterString_Buyer;
    //     private string _filterString_Item;
    //     private string _filterString_payterms;
    //     private string _filterString_warehouse;
    //     private string _filterString_uom;
    //     private string _filterString_billaddr;
    //     private string _filterString_deladdr;
    //     private string _filterString_scheduleItem;
    //     private string _filterString_tax;

    //     decimal tax = 0;
    //     string taxval = "";

    //     private int _dgSelectedIndex;
    //     public int dgSelectedIndex
    //     {
    //         get
    //         {
    //             return _dgSelectedIndex;
    //         }
    //         set
    //         {
    //             if (_dgSelectedIndex != value)
    //             {

    //                 _dgSelectedIndex = value;
    //                 RaisePropertyChanged("dgSelectedIndex");
    //             }
    //         }
    //     }

    //     private int _dgSelectedIndex1;
    //     public int dgSelectedIndex1
    //     {
    //         get
    //         {
    //             return _dgSelectedIndex1;
    //         }
    //         set
    //         {
    //             if (_dgSelectedIndex1 != value)
    //             {

    //                 _dgSelectedIndex1 = value;
    //                 RaisePropertyChanged("dgSelectedIndex1");
    //             }
    //         }
    //     }
    //     private int _dgSelectedIndex2;
    //     public int dgSelectedIndex2
    //     {
    //         get
    //         {
    //             return _dgSelectedIndex2;
    //         }
    //         set
    //         {
    //             if (_dgSelectedIndex2 != value)
    //             {

    //                 _dgSelectedIndex2 = value;
    //                 RaisePropertyChanged("dgSelectedIndex2");
    //             }
    //         }
    //     }



    //     private int _selectedTabIndex;
    //     public int SelectedTabIndex
    //     {
    //         get { return _selectedTabIndex; }
    //         set
    //         {
    //             if (_selectedTabIndex != value)
    //             {
    //                 _selectedTabIndex = value;
    //                 RaisePropertyChanged("SelectedTabIndex");

    //             }
    //         }
    //     }

    //     private Dictionary<string, object> _items;

    //     public Dictionary<string, object> Items
    //     {
    //         get { return _items; }
    //         set
    //         {
    //             if (_items != value)
    //             {
    //                 _items = value;
    //                 RaisePropertyChanged("Items");
    //             }
    //         }
    //     }


    //     private ObservableCollection<PUR_T005_B> _dgPOItems;
    //     public ObservableCollection<PUR_T005_B> dgPEItems
    //     {
    //         get
    //         {
    //             //this.ErrorExist = _dgPOItems.;
    //             return _dgPOItems;
    //         }
    //         set
    //         {
    //             if (_dgPOItems != value)
    //             {
    //                 _dgPOItems = value;

    //                 RaisePropertyChanged("dgPEItems");

    //             }
    //         }
    //     }


    //     private ObservableCollection<PurchaseOrder_deliveryschedule> _dgPOschedule;
    //     public ObservableCollection<PurchaseOrder_deliveryschedule> dgPOschedule
    //     {
    //         get { return _dgPOschedule; }
    //         set
    //         {
    //             if (_dgPOschedule != value)
    //             {
    //                 _dgPOschedule = value;

    //                 RaisePropertyChanged("dgPOschedule");

    //             }
    //         }
    //     }



    //     private ObservableCollection<PurchaseOrder_SingleReport> _dgReportMaster;
    //     public ObservableCollection<PurchaseOrder_SingleReport> dgReportMaster
    //     {
    //         get { return _dgReportMaster; }
    //         set
    //         {
    //             if (_dgReportMaster != value)
    //             {
    //                 _dgReportMaster = value;


    //                 RaisePropertyChanged("dgReportMaster");

    //             }
    //         }
    //     }

    //     private ObservableCollection<ACC_T006_C> _dgPOTaxValues;
    //     public ObservableCollection<ACC_T006_C> dgPOTaxValues
    //     {
    //         get
    //         {
    //             return _dgPOTaxValues;

    //         }
    //         set
    //         {
    //             if (_dgPOTaxValues != value)
    //             {

    //                 _dgPOTaxValues = value;

    //                 RaisePropertyChanged("dgPOTaxValues");


    //             }
    //         }
    //     }
    //     private ObservableCollection<ACC_M013_P> _dgPOTaxAccount;
    //     public ObservableCollection<ACC_M013_P> dgPOTaxAccount
    //     {
    //         get
    //         {
    //             return _dgPOTaxAccount;

    //         }
    //         set
    //         {
    //             if (_dgPOTaxAccount != value)
    //             {

    //                 _dgPOTaxAccount = value;

    //                 RaisePropertyChanged("dgPOTaxAccount");


    //             }
    //         }
    //     }

    //     private ObservableCollection<PUR_T004_B> _dgPOdeliveryschedule;
    //     public ObservableCollection<PUR_T004_B> dgPOdeliveryschedule
    //     {
    //         get
    //         {
    //             return _dgPOdeliveryschedule;

    //         }
    //         set
    //         {
    //             if (_dgPOdeliveryschedule != value)
    //             {

    //                 _dgPOdeliveryschedule = value;

    //                 RaisePropertyChanged("dgPOdeliveryschedule");


    //             }
    //         }
    //     }

    //     private ObservableCollection<ACC_T006_C> _dgPOTotalTaxValues;
    //     public ObservableCollection<ACC_T006_C> dgPOTotalTaxValues
    //     {
    //         get
    //         {
    //             return _dgPOTotalTaxValues;
    //         }
    //         set
    //         {
    //             if (_dgPOTotalTaxValues != value)
    //             {
    //                 try
    //                 {
    //                     tax = Convert.ToDecimal(_dgPOTotalTaxValues[dgSelectedIndex1].tax_amount);
    //                     taxval = _dgPOTotalTaxValues[dgSelectedIndex1].description;
    //                 }
    //                 catch
    //                 {

    //                 }
    //                 _dgPOTotalTaxValues = value;
    //                 RaisePropertyChanged("dgPOTotalTaxValues");

    //             }
    //         }
    //     }
    //     private ObservableCollection<ACC_T006_C> _dgPOTaxValues1;
    //     public ObservableCollection<ACC_T006_C> dgPOTaxValues1
    //     {
    //         get
    //         {
    //             return _dgPOTaxValues1;

    //         }
    //         set
    //         {
    //             if (_dgPOTaxValues1 != value)
    //             {

    //                 _dgPOTaxValues1 = value;

    //                 RaisePropertyChanged("dgPOTaxValues1");

    //             }
    //         }
    //     }
    //     private ObservableCollection<ACC_T006_C> _dgPOTaxValues2;
    //     public ObservableCollection<ACC_T006_C> dgPOTaxValues2
    //     {
    //         get
    //         {
    //             return _dgPOTaxValues2;

    //         }
    //         set
    //         {
    //             if (_dgPOTaxValues2 != value)
    //             {

    //                 _dgPOTaxValues2 = value;

    //                 RaisePropertyChanged("dgPOTaxValues2");

    //             }
    //         }
    //     }
    //     private ObservableCollection<ACC_T006_C> _dgPOTaxValues3;
    //     public ObservableCollection<ACC_T006_C> dgPOTaxValues3
    //     {
    //         get
    //         {
    //             return _dgPOTaxValues3;

    //         }
    //         set
    //         {
    //             if (_dgPOTaxValues3 != value)
    //             {

    //                 _dgPOTaxValues3 = value;

    //                 RaisePropertyChanged("dgPOTaxValues3");

    //             }
    //         }
    //     }
    //     private Dictionary<string, object> _selectedItems;
    //     public Dictionary<string, object> SelectedItems
    //     {
    //         get
    //         {
    //             return _selectedItems;
    //         }
    //         set
    //         {
    //             _selectedItems = value;
    //             RaisePropertyChanged("SelectedItems");
    //         }
    //     }
    //     private PUR_T005_A _SelectedPUR_T002_A;
    //     public PUR_T005_A SelectedPUR_T005_A
    //     {
    //         get
    //         {
    //             this.ErrorExist = _SelectedPUR_T002_A.HasErrors;
    //             return _SelectedPUR_T002_A;
    //         }
    //         set
    //         {
    //             if (_SelectedPUR_T002_A != value)
    //             {
    //                 _SelectedPUR_T002_A = value;
    //                 this.ErrorExist = _SelectedPUR_T002_A.HasErrors;
    //                 RaisePropertyChanged("SelectedPUR_T005_A");
    //                 value.BeginEdit();
    //             }
    //         }
    //     }

    //     private ObservableCollection<PUR_T004_A> _dgscheduledmaster;
    //     public ObservableCollection<PUR_T004_A> dgscheduledmaster
    //     {
    //         get
    //         {

    //             return _dgscheduledmaster;
    //         }
    //         set
    //         {
    //             if (_dgscheduledmaster != value)
    //             {
    //                 _dgscheduledmaster = value;

    //                 RaisePropertyChanged("dgscheduledmaster");

    //             }
    //         }
    //     }

    //     private List<ACC_M013_PopUp> _SelectedTaxList;
    //     public List<ACC_M013_PopUp> SelectedTaxList
    //     {
    //         get { return _SelectedTaxList; }
    //         set
    //         {
    //             if (_SelectedTaxList != value)
    //             {
    //                 _SelectedTaxList = value;

    //                 //if (PropertyChanged != null)
    //                 //{
    //                 RaisePropertyChanged("SelectedTaxList");
    //                 //}
    //             }
    //         }
    //     }


    //     private List<ACC_M013_PopUp> _SelectedChildTaxList;
    //     public List<ACC_M013_PopUp> SelectedChildTaxList
    //     {
    //         get { return _SelectedChildTaxList; }
    //         set
    //         {
    //             if (_SelectedTaxList != value)
    //             {
    //                 _SelectedChildTaxList = value;

    //                 //if (PropertyChanged != null)
    //                 //{
    //                 RaisePropertyChanged("SelectedChildTaxList");
    //                 //}
    //             }
    //         }
    //     }






    //     private List<PUR_T005_A> _SelectedList;
    //     public List<PUR_T005_A> SelectedList
    //     {
    //         get { return _SelectedList; }
    //         set
    //         {
    //             if (_SelectedList != value)
    //             {
    //                 _SelectedList = value;


    //                 RaisePropertyChanged("SelectedList");

    //             }
    //         }
    //     }

    //     ObservableCollection<ADM_M034_PopUp> _SelectedParmetersFrom = new ObservableCollection<ADM_M034_PopUp>();
    //     public ObservableCollection<ADM_M034_PopUp> SelectedParmetersFrom
    //     {
    //         get { return _SelectedParmetersFrom; }
    //         set
    //         {
    //             if (_SelectedParmetersFrom != value)
    //             {
    //                 _SelectedParmetersFrom = value;

    //                 this.RaisePropertyChanged("SelectedParmetersFrom");

    //             }
    //         }
    //     }


    //     ObservableCollection<ADM_M034_PopUp> _TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
    //     public ObservableCollection<ADM_M034_PopUp> TempParmeters
    //     {
    //         get { return _TempParmeters; }
    //         set
    //         {
    //             if (_TempParmeters != value)
    //             {
    //                 _TempParmeters = value;

    //                 this.RaisePropertyChanged("TempParmeters");
    //             }
    //         }
    //     }


    //     List<MM_T001_A_PopUp_PUR> _ItemList = new List<MM_T001_A_PopUp_PUR>();
    //     public List<MM_T001_A_PopUp_PUR> ItemList
    //     {
    //         get { return _ItemList; }
    //         set
    //         {
    //             if (_ItemList != value)
    //             {
    //                 _ItemList = value;

    //                 RaisePropertyChanged("ItemList");
    //             }
    //         }
    //     }
    //     private ObservableCollection<SupplierCatalogueRange> __RateFromSupplierCatalogueCollection;
    //     public ObservableCollection<SupplierCatalogueRange> RateFromSupplierCatalogueCollection
    //     {
    //         get { return __RateFromSupplierCatalogueCollection; }
    //         set
    //         {
    //             if (__RateFromSupplierCatalogueCollection != value)
    //             {
    //                 __RateFromSupplierCatalogueCollection = value;

    //                 RaisePropertyChanged("_RateFromSupplierCatalogueCollection");

    //             }
    //         }
    //     }
    //     private ObservableCollection<ADM_M031_PopUp> __ParameterCodeCollection;
    //     public ObservableCollection<ADM_M031_PopUp> ParameterCodeCollection
    //     {
    //         get { return __ParameterCodeCollection; }
    //         set
    //         {
    //             if (__ParameterCodeCollection != value)
    //             {
    //                 __ParameterCodeCollection = value;

    //                 RaisePropertyChanged("ParameterCodeCollection");

    //             }
    //         }
    //     }
    //     private ICollectionView _dgPOItemsForParameterval;
    //     public ICollectionView dgPOItemsForParameterval
    //     {
    //         get { return _dgPOItemsForParameterval; }
    //         set
    //         {
    //             _dgPOItemsForParameterval = value;
    //             RaisePropertyChanged("dgPOItemsForParameterval");
    //         }
    //     }

    //     private ICollectionView _dgPOItemsFortaxval;
    //     public ICollectionView dgPOItemsFortaxval
    //     {
    //         get { return _dgPOItemsFortaxval; }
    //         set
    //         {
    //             _dgPOItemsFortaxval = value;
    //             RaisePropertyChanged("dgPOItemsFortaxval");
    //         }
    //     }

    //     private ICollectionView _scheduleCollection;
    //     public ICollectionView scheduleCollection
    //     {
    //         get { return _scheduleCollection; }
    //         set
    //         {
    //             _scheduleCollection = value;
    //             RaisePropertyChanged("scheduleCollection");
    //         }
    //     }
    //     #endregion

    //     #region ParameterList
    //     private List<ADM_M034_PopUp> _SelectedParmeters = new List<ADM_M034_PopUp>();
    //     public List<ADM_M034_PopUp> SelectedParmeters
    //     {
    //         get { return _SelectedParmeters; }
    //         set
    //         {
    //             if (_SelectedParmeters != value)
    //             {
    //                 _SelectedParmeters = value;

    //                 RaisePropertyChanged("SelectedParmeters");
    //             }
    //         }
    //     }

    //     private ObservableCollection<ADM_M034_PopUp> _ParamList;
    //     public ObservableCollection<ADM_M034_PopUp> ParamList
    //     {
    //         get { return _ParamList; }
    //         set
    //         {
    //             _ParamList = value;
    //             RaisePropertyChanged("ParamList");
    //         }
    //     }

    //     private ObservableCollection<ADM_M030_P> _ParamValuesList;
    //     public ObservableCollection<ADM_M030_P> ParamValuesList
    //     {
    //         get { return _ParamValuesList; }
    //         set
    //         {
    //             _ParamValuesList = value;
    //             RaisePropertyChanged("ParamValuesList");
    //         }
    //     }




    //     private ObservableCollection<ADM_M030_P> _ParamitemList;
    //     public ObservableCollection<ADM_M030_P> ParamitemList
    //     {
    //         get { return _ParamitemList; }
    //         set
    //         {
    //             _ParamitemList = value;
    //             RaisePropertyChanged("ParamitemList");
    //         }
    //     }
    //     private ObservableCollection<ADM_M030_P> _ParamitemList1;
    //     public ObservableCollection<ADM_M030_P> ParamitemList1
    //     {
    //         get { return _ParamitemList1; }
    //         set
    //         {
    //             _ParamitemList1 = value;
    //             RaisePropertyChanged("ParamitemList1");
    //         }
    //     }
    //     private ObservableCollection<ADM_M030_P> _ParamclearList;
    //     public ObservableCollection<ADM_M030_P> ParamclearList
    //     {
    //         get { return _ParamclearList; }
    //         set
    //         {
    //             _ParamclearList = value;
    //             RaisePropertyChanged("ParamclearList");
    //         }
    //     }

    //     List<ADM_M030_P> _FluteList = new List<ADM_M030_P>();
    //     public List<ADM_M030_P> FluteList
    //     {
    //         get { return _FluteList; }
    //         set
    //         {
    //             if (_FluteList != value)
    //             {
    //                 _FluteList = value;

    //                 RaisePropertyChanged("FluteList");
    //             }
    //         }
    //     }
    //     public string _Flute;
    //     public string Flute
    //     {
    //         get
    //         {
    //             return this._Flute;
    //         }
    //         set
    //         {
    //             if ((this._Flute != value))
    //             {
    //                 this._Flute = value;
    //                 RaisePropertyChanged("Flute");
    //             }
    //         }
    //     }

    //     List<ADM_M030_P> _IndexList = new List<ADM_M030_P>();
    //     public List<ADM_M030_P> IndexList
    //     {
    //         get { return _IndexList; }
    //         set
    //         {
    //             if (_IndexList != value)
    //             {
    //                 _IndexList = value;

    //                 RaisePropertyChanged("IndexList");
    //             }
    //         }
    //     }
    //     public string _Shade;
    //     public string Shade
    //     {
    //         get
    //         {
    //             return this._Shade;
    //         }
    //         set
    //         {
    //             if ((this._Shade != value))
    //             {
    //                 this._Shade = value;
    //                 RaisePropertyChanged("Shade");
    //             }
    //         }
    //     }
    //     List<ParameterSelection> _MakeList = new List<ParameterSelection>();
    //     public List<ParameterSelection> MakeList
    //     {
    //         get { return _MakeList; }
    //         set
    //         {
    //             if (_MakeList != value)
    //             {
    //                 _MakeList = value;

    //                 RaisePropertyChanged("MakeList");
    //             }
    //         }
    //     }
    //     public string _Make;
    //     public string Make
    //     {
    //         get
    //         {
    //             return this._Make;
    //         }
    //         set
    //         {
    //             if ((this._Make != value))
    //             {
    //                 this._Make = value;
    //                 RaisePropertyChanged("Make");
    //             }
    //         }
    //     }

    //     List<ADM_M033_P> _ColourList = new List<ADM_M033_P>();
    //     public List<ADM_M033_P> ColourList
    //     {
    //         get { return _ColourList; }
    //         set
    //         {
    //             if (_ColourList != value)
    //             {
    //                 _ColourList = value;

    //                 RaisePropertyChanged("ColourList");
    //             }
    //         }
    //     }
    //     public string _Colour;
    //     public string Colour
    //     {
    //         get
    //         {
    //             return this._Colour;
    //         }
    //         set
    //         {
    //             if ((this._Colour != value))
    //             {
    //                 this._Colour = value;
    //                 RaisePropertyChanged("Colour");
    //             }
    //         }
    //     }

    //     #endregion

    //     #region ICollection


    //     private ICollectionView _dataGridCollection;
    //     public ICollectionView DataGridCollection
    //     {
    //         get { return _dataGridCollection; }
    //         set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
    //     }
    //     private ICollectionView _partyCollection;
    //     public ICollectionView PartyCollection
    //     {
    //         get { return _partyCollection; }
    //         set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
    //     }
    //     private ICollectionView _buyerCollection;
    //     public ICollectionView BuyerCollection
    //     {
    //         get { return _buyerCollection; }
    //         set { _buyerCollection = value; RaisePropertyChanged("BuyerCollection"); }
    //     }
    //     private ICollectionView _uomCollection;
    //     public ICollectionView UomCollection
    //     {
    //         get { return _uomCollection; }
    //         set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
    //     }
    //     private ICollectionView _itemCollection;
    //     public ICollectionView ItemCollection
    //     {
    //         get { return _itemCollection; }
    //         set { _itemCollection = value; RaisePropertyChanged("ItemCollection"); }
    //     }
    //     private ICollectionView _grnCollection;
    //     public ICollectionView GRNCollection
    //     {
    //         get { return _grnCollection; }
    //         set { _grnCollection = value; RaisePropertyChanged("GRNCollection"); }
    //     }

    //     private ICollectionView _RequisitionItemCollection;
    //     public ICollectionView RequisitionItemCollection
    //     {
    //         get { return _RequisitionItemCollection; }
    //         set { _RequisitionItemCollection = value; RaisePropertyChanged("RequisitionItemCollection"); }
    //     }

    //     private ICollectionView _billAddrCollection;
    //     public ICollectionView BilAdderCollection
    //     {
    //         get { return _billAddrCollection; }
    //         set { _billAddrCollection = value; RaisePropertyChanged("BilAdderCollection"); }
    //     }
    //     private ICollectionView _delAddrCollection;
    //     public ICollectionView DelAddrCollection
    //     {
    //         get { return _delAddrCollection; }
    //         set { _delAddrCollection = value; RaisePropertyChanged("DelAddrCollection"); }
    //     }

    //     private ICollectionView _paytermCollection;
    //     public ICollectionView PayTermCollection
    //     {
    //         get { return _paytermCollection; }
    //         set { _paytermCollection = value; RaisePropertyChanged("PayTermCollection"); }
    //     }


    //     private ICollectionView _warehouseCollection;
    //     public ICollectionView warehouseCollection
    //     {
    //         get { return _warehouseCollection; }
    //         set { _warehouseCollection = value; RaisePropertyChanged("warehouseCollection"); }
    //     }


    //     private ICollectionView _validatedByCollection;
    //     public ICollectionView validatedByCollection
    //     {
    //         get { return _validatedByCollection; }
    //         set { _validatedByCollection = value; RaisePropertyChanged("validatedByCollection"); }
    //     }

    //     private ICollectionView _ParameterCollection;
    //     public ICollectionView ParameterCollection
    //     {
    //         get { return _ParameterCollection; }
    //         set
    //         {
    //             _ParameterCollection = value;
    //             RaisePropertyChanged("ParameterCollection")
    //            ;
    //         }
    //     }


    //     private ICollectionView _TotalParameterCollection;
    //     public ICollectionView TotalParameterCollection
    //     {
    //         get { return _TotalParameterCollection; }
    //         set
    //         {
    //             _TotalParameterCollection = value;
    //             RaisePropertyChanged("TotalParameterCollection")
    //            ;
    //         }
    //     }

    //     private ICollectionView _RequisitionCollection;
    //     public ICollectionView RequisitionCollection
    //     {
    //         get { return _RequisitionCollection; }
    //         set { _RequisitionCollection = value; RaisePropertyChanged("RequisitionCollection"); }
    //     }


    //     private ICollectionView _ParameterCollection1;
    //     public ICollectionView ParameterCollection1
    //     {
    //         get { return _ParameterCollection1; }
    //         set { _ParameterCollection1 = value; RaisePropertyChanged("ParameterCollection1"); }
    //     }

    //     //----------------
    //     private ICollectionView _doc_typeCollection;
    //     public ICollectionView doc_typeCollection
    //     {
    //         get { return _doc_typeCollection; }
    //         set
    //         {
    //             _doc_typeCollection = value;
    //             RaisePropertyChanged("doc_typeCollection");
    //         }
    //     }
    //     private ICollectionView _currencyCollection;
    //     public ICollectionView currencyCollection
    //     {
    //         get { return _currencyCollection; }
    //         set
    //         {
    //             _currencyCollection = value;
    //             RaisePropertyChanged("currencyCollection");
    //         }
    //     }
    //     private ICollectionView _reference_docCollection;
    //     public ICollectionView reference_docCollection
    //     {
    //         get { return _reference_docCollection; }
    //         set
    //         {
    //             _reference_docCollection = value;
    //             RaisePropertyChanged("reference_docCollection");
    //         }
    //     }
    //     private ICollectionView _po_orgCollection;
    //     public ICollectionView po_orgCollection
    //     {
    //         get { return _po_orgCollection; }
    //         set
    //         {
    //             _po_orgCollection = value;
    //             RaisePropertyChanged("po_orgCollection");
    //         }
    //     }
    //     private ICollectionView _distribution_channelCollection;
    //     public ICollectionView distribution_channelCollection
    //     {
    //         get { return _distribution_channelCollection; }
    //         set
    //         {
    //             _distribution_channelCollection = value;
    //             RaisePropertyChanged("distribution_channelCollection");
    //         }
    //     }
    //     private ICollectionView _sales_divisionCollection;
    //     public ICollectionView sales_divisionCollection
    //     {
    //         get { return _sales_divisionCollection; }
    //         set
    //         {
    //             _sales_divisionCollection = value;
    //             RaisePropertyChanged("sales_divisionCollection");
    //         }
    //     }
    //     private ICollectionView _sales_personCollection;
    //     public ICollectionView sales_personCollection
    //     {
    //         get { return _sales_personCollection; }
    //         set
    //         {
    //             _sales_personCollection = value;
    //             RaisePropertyChanged("sales_personCollection");
    //         }
    //     }
    //     private ICollectionView _sales_officeCollection;
    //     public ICollectionView sales_officeCollection
    //     {
    //         get { return _sales_officeCollection; }
    //         set
    //         {
    //             _sales_officeCollection = value;
    //             RaisePropertyChanged("sales_officeCollection");
    //         }
    //     }
    //     private ICollectionView _sales_groupCollection;
    //     public ICollectionView sales_groupCollection
    //     {
    //         get { return _sales_groupCollection; }
    //         set
    //         {
    //             _sales_groupCollection = value;
    //             RaisePropertyChanged("sales_groupCollection");
    //         }
    //     }
    //     private ICollectionView _storage_locCollection;
    //     public ICollectionView storage_locCollection
    //     {
    //         get { return _storage_locCollection; }
    //         set
    //         {
    //             _storage_locCollection = value;
    //             RaisePropertyChanged("storage_locCollection");
    //         }
    //     }
    //     private ICollectionView _storage_locItemCollection;
    //     public ICollectionView storage_locItemCollection
    //     {
    //         get { return _storage_locItemCollection; }
    //         set
    //         {
    //             _storage_locItemCollection = value;
    //             RaisePropertyChanged("storage_locItemCollection");
    //         }
    //     }
    //     private ICollectionView _cost_centerCollection;
    //     public ICollectionView cost_centerCollection
    //     {
    //         get { return _cost_centerCollection; }
    //         set
    //         {
    //             _cost_centerCollection = value;
    //             RaisePropertyChanged("cost_centerCollection");
    //         }
    //     }
    //     private ICollectionView _journalCollection;
    //     public ICollectionView journalCollection
    //     {
    //         get { return _journalCollection; }
    //         set
    //         {
    //             _journalCollection = value;
    //             RaisePropertyChanged("journalCollection");
    //         }
    //     }
    //     private ICollectionView _wtunitCollection;
    //     public ICollectionView wtunitCollection
    //     {
    //         get { return _wtunitCollection; }
    //         set
    //         {
    //             _wtunitCollection = value;
    //             RaisePropertyChanged("wtunitCollection");
    //         }
    //     }
    //     private ICollectionView _volumeunitCollection;
    //     public ICollectionView volumeunitCollection
    //     {
    //         get { return _volumeunitCollection; }
    //         set
    //         {
    //             _volumeunitCollection = value;
    //             RaisePropertyChanged("volumeunitCollection");
    //         }
    //     }
    //     private ICollectionView _countryCollection;
    //     public ICollectionView countryCollection
    //     {
    //         get { return _countryCollection; }
    //         set
    //         {
    //             _countryCollection = value;
    //             RaisePropertyChanged("countryCollection");
    //         }
    //     }
    //     private ICollectionView _itemcategoryCollection;
    //     public ICollectionView itemcategoryCollection
    //     {
    //         get { return _itemcategoryCollection; }
    //         set
    //         {
    //             _itemcategoryCollection = value;
    //             RaisePropertyChanged("itemcategoryCollection");
    //         }
    //     }

    //     #endregion

    //     # region RelayCommands
    //     public RelayCommand<IList> SelectionChangedCommandTotalTax
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> ValidatedBy_SelectionChanged
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> SelectionChangedCommandGRNNo
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> DeleteItemCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> DeleteScheduleCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<Boolean> CheckedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     private RelayCommand _buttonClickCommand;
    //     public RelayCommand ButtonClickCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<object> TaxPopupCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> ParameterPopupCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> TaxChangedCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> ParameterPopupCommand1
    //     {
    //         get;
    //         private set;
    //     }
    //     private RelayCommand _buttonInvoiceCommand;
    //     public RelayCommand ButtonInvoiceCommand
    //     {
    //         get;
    //         private set;
    //     }



    //     public RelayCommand<IList> ItemCellChangedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> ReqCellChangedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<Boolean> ActiveCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> ScheduleCellChangedCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> ParameterNameCommand
    //     {
    //         get;
    //         private set;
    //     }


    //     public RelayCommand<IList> SelectionChangedCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> SelectionChangedCommandTax
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> SelectionCommand_reference_doc
    //     {
    //         get;
    //         private set;
    //     }


    //     public RelayCommand<IList> SelectionChangedCommandParty
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> paytermSelectionChangedCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> WarehouseSelectionChangedCommand
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> ActiveCheckedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> CollectionChangedMethod
    //     {
    //         get;
    //         private set;
    //     }


    //     public RelayCommand<IList> SelectionChangedCommandBuyer
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> SelectionChangedCommandItem
    //     {
    //         get;
    //         private set;
    //     }

    //     public RelayCommand<IList> SelectionChangedCommandItemfordelivery
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> SelectionChangedCommandUom
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> billAddressSelectionChangedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> delAddressSelectionChangedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> CellChangedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     public RelayCommand<IList> SelectionChangedCommandCmbo
    //     {
    //         get;
    //         private set;
    //     }


    //     public RelayCommand<ADM_M030_P> ParameterSelectionChangedCommand
    //     {
    //         get;
    //         private set;
    //     }
    //     //
    //     public RelayCommand<IList> SelectedCommand_doc_type { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_currency { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_reference_doc { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_po_org { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_distribution { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_sales_division { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_sales_person { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_sales_office { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_sales_group { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_storage_loc { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_storage_loc_item { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_cost_center { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_Journal { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_wtunit { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_volumeunit { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_itemcategory { get; private set; }
    //     public RelayCommand<IList> SelectedCommand_country { get; private set; }


    //     #endregion

    //     #region . Constructor .
    //     public PUR_T005_DebitCredit_VM()
    //         : base()
    //     {
    //         dgPOdeliveryschedule = new ObservableCollection<PUR_T004_B>();
    //         dgPOschedule = new ObservableCollection<PurchaseOrder_deliveryschedule>();
    //         SelectedPUR_T005_A = new PUR_T005_A();
    //         MC = new MultipleContext_PUR_T005_A();
    //         dgPEItems = new ObservableCollection<PUR_T005_B>();
    //         SelectedList = new List<PUR_T005_A>();
    //         MC.PEItemsDetails = new ObservableCollection<PUR_T005_B>();
    //         SelectedPUR_T005_A.ValidateAsync().Wait();
    //         TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
    //         FluteList = new List<ADM_M030_P>();
    //         IndexList = new List<ADM_M030_P>();
    //         MakeList = new List<ParameterSelection>();
    //         ColourList = new List<ADM_M033_P>();
    //         SelectedParmeters = new List<ADM_M034_PopUp>();
    //         ParamValuesList = new ObservableCollection<ADM_M030_P>();
    //         ParamitemList = new ObservableCollection<ADM_M030_P>();
    //         dgPOTaxValues = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues1 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues2 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //         CheckedCommand = new RelayCommand<bool>(check);
    //         dgscheduledmaster = new ObservableCollection<PUR_T004_A>();

    //         ButtonClickCommand = new RelayCommand(Load);
    //         ButtonInvoiceCommand = new RelayCommand(RowWiseTaxesLoad);
    //         ActiveCheckedCommand = new RelayCommand<IList>(
    //              items =>
    //              {
    //                  if (items == null)
    //                  {
    //                      return;
    //                  }
    //                  checkstatus(items);
    //              }
    //              );


    //         SelectionChangedCommandGRNNo = new RelayCommand<IList>(
    //          items =>
    //          {
    //              if (items == null)
    //              {
    //                  return;
    //              }
    //              GRNNo(items);

    //          });

    //         //SelectionChangedCommandTotalTax = new RelayCommand<IList>(
    //         // items =>
    //         // {
    //         //     if (items == null)
    //         //     {
    //         //         return;
    //         //     }
    //         //     TableTaxEdit(items);

    //         // });




    //         //TaxChangedCommand = new RelayCommand<IList>(
    //         // items =>
    //         // {
    //         //     if (items == null)
    //         //     {
    //         //         return;
    //         //     }
    //         //     TaxEdit(items);

    //         // });



    //         //     SelectionChangedCommandTax = new RelayCommand<IList>(
    //         //items =>
    //         //{
    //         //    if (items == null)
    //         //    {
    //         //        return;
    //         //    }
    //         //    TaxCellChanged(items);

    //         //});


    //         SelectedCommand_country = new RelayCommand<IList>(
    //items =>
    //{
    //    if (items == null)
    //    {
    //        return;
    //    }
    //    countryChanged(items);

    //});

    //         SelectionCommand_reference_doc = new RelayCommand<IList>(
    //    items =>
    //    {
    //        if (items == null)
    //        {
    //            return;
    //        }
    //        GRNNOChanged(items);

    //    });
    //         ScheduleCellChangedCommand = new RelayCommand<IList>(
    //    items =>
    //    {
    //        if (items == null)
    //        {
    //            return;
    //        }
    //        ScheduleCellChanged(items);

    //    });



    //         CollectionChangedMethod = new RelayCommand<IList>(
    //          items =>
    //          {
    //              if (items == null)
    //              {
    //                  return;
    //              }
    //              CollectionChanged(items);

    //          });


    //         SelectionChangedCommand = new RelayCommand<IList>(
    //         items =>
    //         {
    //             if (items == null)
    //             {
    //                 return;
    //             }
    //             DetailsOfSelectedPO(items);

    //         });



    //         //TaxPopupCommand = new RelayCommand<bool>(TaxCalculation);    
    //         //TaxPopupCommand = new RelayCommand<object>(
    //         //items =>
    //         //{
    //         //    if (items == null)
    //         //    {
    //         //        return;
    //         //    }
    //         //    TaxCalculationChanged(items);

    //         //});


    //         paytermSelectionChangedCommand = new RelayCommand<IList>(
    //          items =>
    //          {
    //              if (items == null)
    //              {
    //                  return;
    //              }
    //              GetPayTerms(items);

    //          });
    //         SelectionChangedCommandParty = new RelayCommand<IList>(
    //          items =>
    //          {
    //              if (items == null)
    //              {
    //                  return;
    //              }
    //              GetSelectedParty(items);

    //          });
    //         SelectionChangedCommandBuyer = new RelayCommand<IList>(
    //         items =>
    //         {
    //             if (items == null)
    //             {
    //                 return;
    //             }
    //             GetSelectedBuyer(items);

    //         });

    //         WarehouseSelectionChangedCommand = new RelayCommand<IList>(
    //        items =>
    //        {
    //            if (items == null)
    //            {
    //                return;
    //            }
    //            AddWarehouse(items);

    //        });
    //         // SelectionChangedCommandItemfordelivery = new RelayCommand<IList>(
    //         //items =>
    //         //{
    //         //    if (items == null)
    //         //    {
    //         //        return;
    //         //    }
    //         //    AddSelectedItemTodeliveryschedule(items);

    //         //});


    //         SelectionChangedCommandItem = new RelayCommand<IList>(
    //        items =>
    //        {
    //            if (items == null)
    //            {
    //                return;
    //            }
    //            AddSelectedItemToCollection(items);

    //        });
    //         SelectionChangedCommandUom = new RelayCommand<IList>(
    //    items =>
    //    {
    //        if (items == null)
    //        {
    //            return;
    //        }
    //        AddSelectedUnitToCollection(items);
    //    });
    //         billAddressSelectionChangedCommand = new RelayCommand<IList>(
    //           items =>
    //           {
    //               if (items == null)
    //               {
    //                   return;
    //               }
    //               SelectBillAddress(items);
    //           });
    //         delAddressSelectionChangedCommand = new RelayCommand<IList>(
    //         items =>
    //         {
    //             if (items == null)
    //             {
    //                 return;
    //             }
    //             SelectedDelAddress(items);
    //         });
    //         CellChangedCommand = new RelayCommand<IList>(
    //         items =>
    //         {
    //             if (items == null)
    //             {
    //                 return;
    //             }
    //             CellChangeUpdate(items);
    //         });
    //         ValidatedBy_SelectionChanged = new RelayCommand<IList>(
    //           items =>
    //           {
    //               if (items == null)
    //               {
    //                   return;
    //               }

    //               GetSelectedValidatedby(items);
    //           });

    //         ParameterSelectionChangedCommand = new RelayCommand<ADM_M030_P>(
    //             items =>
    //             {
    //                 if (items == null)
    //                 {
    //                     return;
    //                 }
    //                 GetSelectedParameter(items);
    //             }
    //             );

    //         ParameterPopupCommand = new RelayCommand<IList>(
    //                items =>
    //                {
    //                    if (items == null)
    //                    {
    //                        return;
    //                    }
    //                    ParameterPopupClosed(items);
    //                }
    //                );

    //         DeleteItemCommand = new RelayCommand<IList>(
    //     items =>
    //     {
    //         if (items == null)
    //         {
    //             return;
    //         }

    //         getSelectedRow(items);

    //     });
    //         DeleteScheduleCommand = new RelayCommand<IList>(
    //    items =>
    //    {
    //        if (items == null)
    //        {
    //            return;
    //        }

    //        deleteSelectedRow(items);

    //    });
    //         ActiveCommand = new RelayCommand<bool>(Active);
    //         SelectedCommand_doc_type = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_doc_type(items); });
    //         SelectedCommand_currency = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_currency(items); });
    //         SelectedCommand_reference_doc = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_reference_doc(items); });
    //         SelectedCommand_po_org = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_sales_org(items); });
    //         SelectedCommand_sales_group = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_sales_group(items); });
    //         SelectedCommand_storage_loc = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_storage_loc(items); });
    //         SelectedCommand_storage_loc_item = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_storage_loc_item(items); });
    //         SelectedCommand_cost_center = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_cost_center(items); });
    //         SelectedCommand_Journal = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_journal(items); });
    //         SelectedCommand_wtunit = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_wtunit(items); });
    //         SelectedCommand_volumeunit = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_volumeunit(items); });
    //         SelectedCommand_itemcategory = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_itemcategory(items); });

    //         LoadInitialData();
    //         Items = new Dictionary<string, object>();
    //         SelectedItems = new Dictionary<string, object>();
    //         Items.Clear();
    //         SelectedPUR_T005_A.doc_date = DateTime.Now;


    //         Items = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);
    //         dgPEItems.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionTaxChangedMethod);
    //         //SelectedPUR_T005_A.po_date = DateTime.Now;
    //     }



    //     private void Load()
    //     {
    //         if ((SelectedPUR_T005_A.party_id == 0) || (SelectedPUR_T005_A.party_id == null))
    //         {
    //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //             showMessageService.ButtonSetup = DialogButton.Ok;
    //             showMessageService.Caption = "Message";
    //             showMessageService.Text = String.Format("Please Select Party First..", this.Title);
    //             showMessageService.ShowMessage();
    //         }
    //         else if ((SelectedPUR_T005_A.grnno == "") || (SelectedPUR_T005_A.grnno == null))
    //         {
    //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //             showMessageService.ButtonSetup = DialogButton.Ok;
    //             showMessageService.Caption = "Message";
    //             showMessageService.Text = String.Format("Please Select GRNNo. First..", this.Title);
    //             showMessageService.ShowMessage();
    //         }
    //         else
    //         {
    //             try
    //             {
    //                 //ItemCollection = CollectionViewSource.GetDefaultView(MC_temp.itemList);
    //                 //ItemCollection.Filter = new Predicate<object>(FilterItem);

    //                 var itemlist = (from o in MC_temp.itemList
    //                                 where o.grnno == SelectedPUR_T005_A.grnno
    //                                 select o).ToList();

    //                 dgPEItems = new ObservableCollection<PUR_T005_B>();
    //                 foreach (var item in itemlist)
    //                 {
    //                     dgPEItems.Add(new PUR_T005_B { amount = item.sub_total, item_cat = item.item_cat, pur_doc_no = item.po_no, grnno = item.grnno, item_id = item.item_id, item_code = item.ItemCode, item_name = item.ItemName, uom = item.unit_id, unit_name = item.unit_name, unit_price = item.rate, qty = item.appr_qty, tax_code = item.tax_id, SubCategCod = Convert.ToString(item.SubCategCod), stockingunit = item.stockingunit, stocking_unit1 = item.stockingunit, active = true });
    //                     SelectedPUR_T005_A.amtinword = item.amt_in_words;
    //                     SelectedPUR_T005_A.untaxedamount = item.amount_untaxed;
    //                     SelectedPUR_T005_A.tax_amount = item.amount_tax;
    //                     SelectedPUR_T005_A.totalamount = item.amount_total;

    //                     SelectedPUR_T005_A.inv_no = item.invoiceNo;
    //                     SelectedPUR_T005_A.inv_date = item.Invoicedate;
    //                     SelectedPUR_T005_A.del_note = item.challanno;
    //                     SelectedPUR_T005_A.del_note_date = item.challandate;
    //                     SelectedPUR_T005_A.pay_terms = item.pay_term_id;
    //                     SelectedPUR_T005_A.p_term = item.p_term;
    //                     SelectedPUR_T005_A.doc_type = item.doc_cat;
    //                     SelectedPUR_T005_A.entry_time = item.entry_time;
    //                     SelectedPUR_T005_A.post_date = item.post_date;

    //                     try
    //                     {
    //                         //if (Selectedpartylist[0].stockingunit != "")
    //                         {
    //                             string[] values1 = item.ItemName.Split('\t');
    //                             string Reqstockingunit = "";
    //                             string[] values = item.stockingunit.Split('/');
    //                             for (int y = values.Count() - 1; y >= 0; y--)
    //                             {
    //                                 var stockingunit = (from o in FluteList
    //                                                     where o.code == Convert.ToInt32(values[y].ToString())
    //                                                     select o).ToList();
    //                                 {
    //                                     Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
    //                                 }
    //                             }
    //                             dgPEItems.Where(l => l.item_id == item.item_id).ToList().ForEach(i => i.description = (""));
    //                             dgPEItems.Where(l => l.item_id == item.item_id).ToList().ForEach(i => i.description = (values1[0] + Reqstockingunit));
    //                         }

    //                     }
    //                     catch
    //                     {

    //                     }

    //                 }
    //                 //var taxlist = (from o in MC_temp.POTotaltaxDetails
    //                 //                where o.grnno == SelectedPUR_T005_A.grnno
    //                 //                select o).ToList();
    //                 //dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //                 //dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //                 //dgPOTaxValues = new ObservableCollection<ACC_T006_C>();
    //                 //foreach (var item in taxlist)
    //                 //{
    //                 //    dgPOTotalTaxValues.Add(new ACC_T006_C
    //                 //    {
    //                 //        _stocking_unit1 = item.stocking_unit1,
    //                 //        accountcollectdid = item.accountcollectdid,
    //                 //        base_amount = item.base_amount,
    //                 //        description = item.description,
    //                 //        grnno = item.grnno,
    //                 //        id = item.id,
    //                 //        item_id = item.item_id,
    //                 //        tax_amount = item.tax_amount,
    //                 //        tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                 //        tax_id = item.tax_id,
    //                 //        taxaccount = item.taxaccount


    //                 //    });
    //                 //    dgPOTaxValues3.Add(new ACC_T006_C
    //                 //    {
    //                 //        _stocking_unit1 = item.stocking_unit1,
    //                 //        accountcollectdid = item.accountcollectdid,
    //                 //        base_amount = item.base_amount,
    //                 //        description = item.description,
    //                 //        grnno = item.grnno,
    //                 //        id = item.id,
    //                 //        item_id = item.item_id,
    //                 //        tax_amount = item.tax_amount,
    //                 //        tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                 //        tax_id = item.tax_id,
    //                 //        taxaccount = item.taxaccount

    //                 //    });

    //                 //    dgPOTaxValues.Add(new ACC_T006_C
    //                 //    {
    //                 //        _stocking_unit1 = item.stocking_unit1,
    //                 //        accountcollectdid = item.accountcollectdid,
    //                 //        base_amount = item.base_amount,
    //                 //        description = item.description,
    //                 //        grnno = item.grnno,
    //                 //        id = item.id,
    //                 //        item_id = item.item_id,
    //                 //        tax_amount = item.tax_amount,
    //                 //        tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                 //        tax_id = item.tax_id,
    //                 //        taxaccount = item.taxaccount,


    //                 //    });


    //                 //}
    //                 try
    //                 {
    //                     TaxRowCalculation();
    //                 }
    //                 catch
    //                 {

    //                 }



    //             }
    //             catch
    //             {

    //             }
    //         }


    //     }
    //     private void getSelectedRow(IList SelectedItems)
    //     {
    //         IList list = SelectedItems as IList;
    //         List<PUR_T005_B> GetSelectedPur_Req_Details = list.Cast<PUR_T005_B>().ToList();

    //         if (GetSelectedPur_Req_Details.Count > 0)
    //         {
    //             //var q = SelectedList.Where(X => X.id == GetSelectedPur_Req_Details[0].req_id).FirstOrDefault();
    //             int x = dgPEItems.IndexOf(dgPEItems.Where(X => X.item_id == GetSelectedPur_Req_Details[0].item_id).Where(X => X.stocking_unit1 == GetSelectedPur_Req_Details[0].stocking_unit1).FirstOrDefault());

    //             //if (SelectedPUR_T005_A.id == 0 && GetSelectedPur_Req_Details[0].po_id == null)
    //             //{
    //             if (GetSelectedPur_Req_Details[0].id == 0)
    //             {
    //                 if (x >= 0 && x != -1)
    //                 {
    //                     dgPEItems.RemoveAt(x);
    //                 }
    //                 MC.itemList.ToList().ForEach(t => t.Select = false);
    //             }

    //         }

    //     }
    //     private void deleteSelectedRow(IList SelectedItems)
    //     {
    //         IList list = SelectedItems as IList;
    //         List<PUR_T004_B> GetSelectedPur_Req_Details = list.Cast<PUR_T004_B>().ToList();

    //         if (GetSelectedPur_Req_Details.Count > 0)
    //         {
    //             //var q = SelectedList.Where(X => X.id == GetSelectedPur_Req_Details[0].req_id).FirstOrDefault();
    //             int x = dgPOdeliveryschedule.IndexOf(dgPOdeliveryschedule.Where(X => X.item_id == GetSelectedPur_Req_Details[0].item_id)
    //                 .Where(X => X.stockingunit == GetSelectedPur_Req_Details[0].stockingunit)
    //                                .Where(X => X.count == GetSelectedPur_Req_Details[0].count).FirstOrDefault());

    //             //if (SelectedPUR_T005_A.id == 0 && GetSelectedPur_Req_Details[0].po_id == null)
    //             //{
    //             if (GetSelectedPur_Req_Details[0].id == 0 || GetSelectedPur_Req_Details[0].id == null)
    //             {
    //                 if (x >= 0 && x != -1)
    //                 {
    //                     dgPOdeliveryschedule.RemoveAt(x);

    //                 }
    //                 try
    //                 {
    //                     ScheduleCellChanged(SelectedItems);
    //                 }
    //                 catch
    //                 {

    //                 }
    //                 //MC.itemList.ToList().ForEach(t => t.Select = false);
    //             }
    //             //scheduleCollection =CollectionViewSource.GetDefaultView(dgPOdeliveryschedule);

    //         }
    //     }

    //     private void checkstatus(IList ItmList)
    //     {
    //         IList list = ItmList as IList;
    //         List<PUR_T004_B> Selectedpartylist = list.Cast<PUR_T004_B>().ToList();
    //         if (Selectedpartylist[0].active == false)
    //         {
    //             dgPOdeliveryschedule.Where(l => l.id == Selectedpartylist[0].id).ToList().ForEach(i => i.active = false);
    //         }
    //         //scheduleCollection.Refresh();

    //     }
    //     private void CollectionTaxChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
    //     {
    //         //different kind of changes that may have occurred in collection
    //         if (e.Action == NotifyCollectionChangedAction.Add)
    //         {
    //             foreach (PUR_T005_B item in e.NewItems)
    //             {
    //                 //Added items


    //                 if (item.tax_code != null)
    //                 {

    //                     {
    //                         try
    //                         {

    //                             int tax_id = Convert.ToInt32(item.tax_code);
    //                             //TaxRowCalculation();

    //                         }
    //                         catch
    //                         {

    //                         }
    //                     }


    //                 }




    //             }


    //         }

    //         if (e.Action == NotifyCollectionChangedAction.Replace)
    //         {

    //         }
    //         if (e.Action == NotifyCollectionChangedAction.Remove)
    //         {
    //             foreach (PUR_T005_B item in e.OldItems)
    //             {
    //                 //Removed items
    //                 //item.PropertyChanged -= EntityViewModelPropertyChanged;
    //             }
    //         }
    //         if (e.Action == NotifyCollectionChangedAction.Move)
    //         {
    //             //your code
    //         }
    //     }
    //     #endregion

    //     #region . PopMethods .

    //     private void getSelectedRow_sales_group(IList items)
    //     {
    //         try
    //         {
    //             List<ADM_M001_H_Popup> items1 = items.Cast<ADM_M001_H_Popup>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 //SelectedPUR_T005_A.pg_code = items1[0].sg_code;
    //                 //SelectedPUR_T005_A.pg_name = items1[0].sg_name;
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_sales_org(IList items)
    //     {
    //         try
    //         {
    //             List<ADM_M001_M_Popup> items1 = items.Cast<ADM_M001_M_Popup>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 //SelectedPUR_T005_A.sales_org = items1[0].po_code;
    //                 //SelectedPUR_T005_A.pur_org_name = items1[0].pur_org;
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_reference_doc(IList items)
    //     {
    //         try
    //         {

    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_currency(IList items)
    //     {
    //         try
    //         {
    //             List<ADM_M037_Popup> items1 = items.Cast<ADM_M037_Popup>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 //SelectedPUR_T005_A.doc_currency = items1[0].id;
    //                 //SelectedPUR_T005_A.currency_name = items1[0].curr_name;
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_doc_type(IList items)
    //     {
    //         try
    //         {
    //             List<SYS_M007_Popup> items1 = items.Cast<SYS_M007_Popup>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 SelectedPUR_T005_A.doc_type = items1[0].doc_type;
    //                 SelectedPUR_T005_A.doc_desc = items1[0].doc_desc;
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_storage_loc(IList items)
    //     {
    //         try
    //         {
    //             List<MM_M001_PopUp> items1 = items.Cast<MM_M001_PopUp>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 //SelectedPUR_T005_A.stock_location_id = items1[0].store_code;
    //                 //SelectedPUR_T005_A.stock_location_name = items1[0].store_name;
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_cost_center(IList items)
    //     {
    //         try
    //         {
    //             List<ACC_M019_Popup> items1 = items.Cast<ACC_M019_Popup>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 //SelectedPUR_T005_A.c = items1[0].id;
    //                 //SelectedPUR_T005_A.cost_center_name = items1[0].cost_center;
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_journal(IList items)
    //     {
    //         try
    //         {
    //             List<ACC_M005_PopUp> items1 = items.Cast<ACC_M005_PopUp>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 //SelectedPUR_T005_A.journal_id = items1[0].id;
    //                 //SelectedPUR_T005_A.journal_name = items1[0].journal_name;
    //             }
    //         }
    //         catch { }
    //     }
    //     private void getSelectedRow_storage_loc_item(IList items)
    //     {
    //         try
    //         {
    //             List<MM_M001_PopUp> items1 = items.Cast<MM_M001_PopUp>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 if (dgPEItems.Count > 0 && dgSelectedIndex != -1 && dgPEItems.Count > dgSelectedIndex)
    //                 {
    //                     //dgPEItems[dgSelectedIndex].storage_loc = items1[0].store_code;
    //                     //dgPEItems[dgSelectedIndex].storage_loc_name = items1[0].store_name;
    //                 }
    //             }
    //         }
    //         catch { }
    //     }
    //     private void getSelectedRow_wtunit(IList items)
    //     {
    //         try
    //         {
    //             List<ADM_M038_B_PopUp> items1 = items.Cast<ADM_M038_B_PopUp>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 if (dgPEItems.Count > 0 && dgSelectedIndex != -1 && dgPEItems.Count > dgSelectedIndex)
    //                 {
    //                     //dgPEItems[dgSelectedIndex].wt_unit = items1[0].id;
    //                     //dgPEItems[dgSelectedIndex].weight_unit_name = items1[0].unit_name;
    //                 }
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_volumeunit(IList items)
    //     {
    //         try
    //         {
    //             List<ADM_M038_B_PopUp> items1 = items.Cast<ADM_M038_B_PopUp>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 if (dgPEItems.Count > 0 && dgSelectedIndex != -1 && dgPEItems.Count > dgSelectedIndex)
    //                 {
    //                     //dgPEItems[dgSelectedIndex].volume_unit = items1[0].id;
    //                     //dgPEItems[dgSelectedIndex].volume_unit_name = items1[0].unit_name;
    //                 }
    //             }
    //         }
    //         catch { }
    //     }

    //     private void getSelectedRow_itemcategory(IList items)
    //     {
    //         try
    //         {
    //             List<SYS_M003_PopUp> items1 = items.Cast<SYS_M003_PopUp>().ToList();
    //             if (items1.Count() > 0)
    //             {
    //                 if (dgPEItems.Count > 0 && dgSelectedIndex != -1 && dgPEItems.Count > dgSelectedIndex)
    //                 {
    //                     dgPEItems[dgSelectedIndex].item_cat = items1[0].sditem_cat_code;
    //                     dgPEItems[dgSelectedIndex].item_cat = items1[0].sditem_cat_code;
    //                 }
    //             }
    //         }
    //         catch { }
    //     }


    //     #endregion

    //     #region . User Defined Function .
    //     private void LoadInitialData()
    //     {
    //         try
    //         {

    //             ////---------------------------------
    //             //DelAddrCollection and bill adrr filter
    //             ////---------------------------------
    //             // ObjectSerializationService obj = new ObjectSerializationService();              
    //             string comp = AppSessionState.CompanyID.ToString()+"@"+AppSessionState.Location;
    //             MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005_A>(MC, "PUR_T002_A_Data", "PurchaseInvoice", "CRM", "DebitCredit_LoadAll", 0, comp);
    //             SelectedList = MC.PEDetails;

    //             FluteList = MC.FluteList;

    //             DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
    //             DataGridCollection.Filter = new Predicate<object>(Filter);

    //             BuyerCollection = CollectionViewSource.GetDefaultView(MC.BuyerList);
    //             BuyerCollection.Filter = new Predicate<object>(FilterBuyer);

    //             PartyCollection = CollectionViewSource.GetDefaultView(MC.partyList);
    //             PartyCollection.Filter = new Predicate<object>(FilterParty);

    //             PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms);
    //             PayTermCollection.Filter = new Predicate<object>(FilterPayTerms);

    //             warehouseCollection = CollectionViewSource.GetDefaultView(MC.WarehouseList);
    //             warehouseCollection.Filter = new Predicate<object>(FilterCollectionWarehouse);


    //             UomCollection = CollectionViewSource.GetDefaultView(MC.unitList);
    //             UomCollection.Filter = new Predicate<object>(FilterUom);

    //             validatedByCollection = CollectionViewSource.GetDefaultView(MC.BuyerList);
    //             validatedByCollection.Filter = new Predicate<object>(FilterBuyer);

    //             //19jan

    //             doc_typeCollection = CollectionViewSource.GetDefaultView(MC.doc_typeList);
    //             // doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);

    //             currencyCollection = CollectionViewSource.GetDefaultView(MC.currencyList);
    //             currencyCollection.Filter = new Predicate<object>(currency_Filter);

    //             //reference_docCollection = CollectionViewSource.GetDefaultView(MC.reference_docList);
    //             //reference_docCollection.Filter = new Predicate<object>(refdocno_Filter);

    //             po_orgCollection = CollectionViewSource.GetDefaultView(MC.purchase_orgList);
    //             po_orgCollection.Filter = new Predicate<object>(saleorg_Filter);

    //             //sales_groupCollection = CollectionViewSource.GetDefaultView(MC.sales_groupList);
    //             //sales_groupCollection.Filter = new Predicate<object>(sales_grp_Filter);

    //             storage_locCollection = CollectionViewSource.GetDefaultView(MC.storage_locList);
    //             storage_locCollection.Filter = new Predicate<object>(storage_loc_Filter);

    //             cost_centerCollection = CollectionViewSource.GetDefaultView(MC.cost_centerList);
    //             cost_centerCollection.Filter = new Predicate<object>(cost_center_Filter);

    //             journalCollection = CollectionViewSource.GetDefaultView(MC.journalList);
    //             journalCollection.Filter = new Predicate<object>(journal_Filter);

    //             DelAddrCollection = CollectionViewSource.GetDefaultView(MC.deladdrList.ToList());
    //             //DelAddrCollection.Filter = new Predicate<object>(Filterdeladdr);

    //             BilAdderCollection = CollectionViewSource.GetDefaultView(MC.billaddrList.ToList());
    //             // BilAdderCollection.Filter = new Predicate<object>(Filterbilladdr);

    //             wtunitCollection = CollectionViewSource.GetDefaultView(MC.unitList);
    //             wtunitCollection.Filter = new Predicate<object>(Filterwtunit);

    //             volumeunitCollection = CollectionViewSource.GetDefaultView(MC.unitList);
    //             volumeunitCollection.Filter = new Predicate<object>(Filtervolumeunit);

    //             itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.itemcatList);
    //             itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);

    //             countryCollection = CollectionViewSource.GetDefaultView(MC.CountryList);
    //             countryCollection.Filter = new Predicate<object>(Filtercountry);

    //             try
    //             {
    //                 if (MC.billaddrList.Count > 0)
    //                 {
    //                     foreach (var item in MC.billaddrList)
    //                     {
    //                         if (item.Location_Id == AppSessionState.LocationID)
    //                         {
    //                             SelectedPUR_T005_A.company_id = Convert.ToInt32(item.Comp_Id);
    //                             SelectedPUR_T005_A.company = item.CompName;
    //                         }
    //                     }

    //                 }

    //             }
    //             catch
    //             {

    //             }
    //             try
    //             {
    //                 if (MC.PayTerms.Count == 1)
    //                 {
    //                     SelectedPUR_T005_A.p_term = MC.PayTerms[0].p_term;
    //                     SelectedPUR_T005_A.pay_terms = MC.PayTerms[0].id;

    //                 }

    //             }
    //             catch
    //             {

    //             }
    //             try
    //             {

    //                 SelectedChildTaxList = MC.TaxList;
    //                 var TaxList = (from o in MC.TaxList
    //                                where o.parent_id == null
    //                                select o).ToList();

    //                 SelectedTaxList = TaxList;
    //             }
    //             catch
    //             {
    //                 SelectedTaxList = MC.TaxList;
    //             }

    //             dgPOItemsFortaxval = CollectionViewSource.GetDefaultView(MC.TaxAccountList);
    //             dgPOItemsFortaxval.Filter = new Predicate<object>(Filtertax);

    //         }
    //         catch (Exception ex)
    //         {
    //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //             showMessageService.ButtonSetup = DialogButton.Ok;
    //             showMessageService.Caption = "Message";
    //             showMessageService.Text = String.Format(ex.Message, this.Title);
    //             showMessageService.ShowMessage();
    //         }
    //     }
    //     private void GetSelectedValidatedby(IList partyList)
    //     {
    //         IList list = partyList as IList;
    //         List<ADM_M024_PopUp> Selectedpartylist = list.Cast<ADM_M024_PopUp>().ToList();
    //         if (Selectedpartylist.Count > 0)
    //         {
    //             //SelectedPUR_T005_A.validator = Selectedpartylist[0].id;
    //             //SelectedPUR_T005_A.validator_name = Selectedpartylist[0].EmpLName;
    //         }
    //     }
    //     private void DetailsOfSelectedPO(IList DataList)
    //     {
    //         IList list = DataList as IList;

    //         dgPOTaxValues1 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //         List<PUR_T005_A> tSelectedPOList = list.Cast<PUR_T005_A>().ToList();
    //         if (tSelectedPOList.Count > 0)
    //         {

    //             SelectedPUR_T005_A = (PUR_T005_A)tSelectedPOList[0];
    //             string supplierid ="";
    //             supplierid = Convert.ToString(SelectedPUR_T005_A.party_id) + "@" + AppSessionState.CompanyID.ToString();
    //             MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005_A>(MC_temp, "PUR_T002_A_Data", "PurchaseInvoice", "CRM", "LoadPEDetails", SelectedPUR_T005_A.id, supplierid);
    //             MC.PEItemsDetails = MC_temp.PEItemsDetails;
    //             MC.ParamvalList = MC_temp.ParamvalList;
    //             MC.PEtaxDetails = MC_temp.PEtaxDetails;

    //             dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //             dgPOTotalTaxValues = MC_temp.POTotaltaxDetails;
    //             FluteList = MC.FluteList;
    //             dgPEItems = MC.PEItemsDetails;
    //             ParameterCodeCollection = MC_temp.ParameterCodeList;
    //             try
    //             {
    //                 ItemCollection = CollectionViewSource.GetDefaultView(MC_temp.itemList);
    //                 ItemCollection.Filter = new Predicate<object>(FilterItem);

    //             }
    //             catch
    //             {

    //             }

    //             //dgPOItemsForParameterval = CollectionViewSource.GetDefaultView(MC_temp.POTotaltaxDetails);
    //             //for (int i = 0; i < dgPOItemsForParameterval.Cast<ACC_T006_C>().ToList().Count(); i++)
    //             //{
    //             //    dgPOTaxValues3.Add(dgPOItemsForParameterval.Cast<ACC_T006_C>().ElementAt(i));
    //             //    dgPOTaxValues.Add(dgPOItemsForParameterval.Cast<ACC_T006_C>().ElementAt(i));
    //             //}

    //             foreach (var item in MC_temp.POTotaltaxDetails)
    //             {

    //                 dgPOTaxValues3.Add(new ACC_T006_C
    //                 {
    //                     _stocking_unit1 = item.stocking_unit1,
    //                     accountcollectdid = item.accountcollectdid,
    //                     base_amount = item.base_amount,
    //                     description = item.description,
    //                     grnno = item.grnno,
    //                     id = item.id,
    //                     item_id = item.item_id,
    //                     tax_amount = item.tax_amount,
    //                     tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                     tax_id = item.tax_id,
    //                     taxaccount = item.taxaccount

    //                 });

    //                 dgPOTaxValues.Add(new ACC_T006_C
    //                 {
    //                     _stocking_unit1 = item.stocking_unit1,
    //                     accountcollectdid = item.accountcollectdid,
    //                     base_amount = item.base_amount,
    //                     description = item.description,
    //                     grnno = item.grnno,
    //                     id = item.id,
    //                     item_id = item.item_id,
    //                     tax_amount = item.tax_amount,
    //                     tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                     tax_id = item.tax_id,
    //                     taxaccount = item.taxaccount,


    //                 });


    //             }

    //             dgPEItems = new ObservableCollection<PUR_T005_B>();
    //             dgPEItems = MC.PEItemsDetails;
    //             foreach (var item in dgPEItems)
    //             {
    //                 dgPEItems.Where(i => i.item_id == item.item_id).Where(i => i.stockingunit == item.stockingunit).ToList().ForEach(L => L.stocking_unit1 = item.stockingunit);
    //             }


    //             blNew = false;
    //             //Update();
    //             try
    //             {
    //                 TaxRowCalculation();
    //             }
    //             catch
    //             {

    //             }

    //         }

    //     }
    //     private void GRNNo(IList BuyerList)
    //     {
    //         if (dgSelectedIndex != -1 && BuyerList.Count > 0)
    //         {

    //             IList list = BuyerList as IList;
    //             List<MM_T001_A_PopUp_PUR> SelectedCatItmDetails = list.Cast<MM_T001_A_PopUp_PUR>().ToList();
    //             //if (SelectedCatItmDetails.Count > 0 || SelectedPUR_T005_A.supplier_id != null)
    //             {

    //                 var q = dgPEItems.Where(X => X.item_id == SelectedCatItmDetails[0].item_id).Where(X => X.stockingunit == SelectedCatItmDetails[0].stockingunit).FirstOrDefault();
    //                 //var q1 = dgPEItems.Where(X => X.requsition_id == SelectedCatItmDetails[0].requsition_id).FirstOrDefault();
    //                 int x = dgPEItems.IndexOf(dgPEItems.Where(X => X.item_id == SelectedCatItmDetails[0].item_id).Where(X => X.stockingunit == SelectedCatItmDetails[0].stockingunit).FirstOrDefault());

    //                 string grnno = SelectedCatItmDetails[0].grnno;
    //                 string stockunit = SelectedCatItmDetails[0].stockingunit;
    //                 int itemid = Convert.ToInt32(SelectedCatItmDetails[0].item_id);
    //                 string itemcode = SelectedCatItmDetails[0].ItemCode;

    //                 if (SelectedCatItmDetails[0].Select == true && dgPEItems.Count == dgSelectedIndex)
    //                 {

    //                     var itemlist = (from o in MC_temp.itemList
    //                                     where o.grnno == grnno && o.item_id == itemid
    //                                     && o.stockingunit == stockunit
    //                                     select o).ToList();

    //                     //dgPEItems = new ObservableCollection<PUR_T005_B>();
    //                     foreach (var item in itemlist)
    //                     {
    //                         dgPEItems.Add(new PUR_T005_B { item_cat = item.item_cat, pono = item.po_no, amount = item.sub_total, pur_doc_no = item.po_no, grnno = item.grnno, item_id = item.item_id, item_code = item.ItemCode, item_name = item.ItemName, uom = item.unit_id, unit_name = item.unit_name, unit_price = item.rate, qty = item.appr_qty, tax_code = item.tax_id, SubCategCod = Convert.ToString(item.SubCategCod), stockingunit = item.stockingunit, stocking_unit1 = item.stockingunit, active = true });

    //                         if (SelectedPUR_T005_A.inv_no != "")
    //                         {
    //                             SelectedPUR_T005_A.amtinword = item.amt_in_words;
    //                             SelectedPUR_T005_A.untaxedamount = item.amount_untaxed;
    //                             SelectedPUR_T005_A.tax_amount = item.amount_tax;
    //                             SelectedPUR_T005_A.totalamount = item.amount_total;
    //                             SelectedPUR_T005_A.inv_no = item.invoiceNo;
    //                             SelectedPUR_T005_A.inv_date = item.Invoicedate;
    //                             SelectedPUR_T005_A.del_note = item.challanno;
    //                             SelectedPUR_T005_A.del_note_date = item.challandate;
    //                             SelectedPUR_T005_A.pay_terms = item.pay_term_id;
    //                             SelectedPUR_T005_A.p_term = item.p_term;
    //                             SelectedPUR_T005_A.doc_type = item.doc_cat;
    //                             SelectedPUR_T005_A.entry_time = item.entry_time;
    //                             SelectedPUR_T005_A.post_date = item.post_date;
    //                         }
    //                         else if (SelectedPUR_T005_A.inv_no == "")
    //                         {
    //                             SelectedPUR_T005_A.amtinword = item.amt_in_words;
    //                             SelectedPUR_T005_A.untaxedamount = item.amount_untaxed;
    //                             SelectedPUR_T005_A.tax_amount = item.amount_tax;
    //                             SelectedPUR_T005_A.totalamount = item.amount_total;
    //                             SelectedPUR_T005_A.inv_no = item.invoiceNo;
    //                             SelectedPUR_T005_A.inv_date = item.Invoicedate;
    //                             SelectedPUR_T005_A.del_note = item.challanno;
    //                             SelectedPUR_T005_A.del_note_date = item.challandate;
    //                             SelectedPUR_T005_A.pay_terms = item.pay_term_id;
    //                             SelectedPUR_T005_A.p_term = item.p_term;
    //                             SelectedPUR_T005_A.doc_type = item.doc_cat;
    //                             SelectedPUR_T005_A.entry_time = item.entry_time;
    //                             SelectedPUR_T005_A.post_date = item.post_date;
    //                         }
    //                         else
    //                         {
    //                             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                             showMessageService.ButtonSetup = DialogButton.Ok;
    //                             showMessageService.Caption = "Message";
    //                             showMessageService.Text = String.Format("Invoice No. is Different", this.Title);
    //                             showMessageService.ShowMessage();
    //                             dgPEItems.RemoveAt(x);
    //                         }

    //                     }
    //                     var taxlist = (from o in MC_temp.POTotaltaxDetails
    //                                    where o.grnno == grnno && o.item_id == itemcode
    //                                     && o.stocking_unit1 == stockunit
    //                                    select o).ToList();
    //                     foreach (var item in taxlist)
    //                     {
    //                         dgPOTotalTaxValues.Add(new ACC_T006_C
    //                         {
    //                             _stocking_unit1 = item.stocking_unit1,
    //                             accountcollectdid = item.accountcollectdid,
    //                             base_amount = item.base_amount,
    //                             description = item.description,
    //                             grnno = item.grnno,
    //                             id = item.id,
    //                             item_id = item.item_id,
    //                             tax_amount = item.tax_amount,
    //                             tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                             tax_id = item.tax_id,
    //                             taxaccount = item.taxaccount

    //                         });
    //                         dgPOTaxValues3.Add(new ACC_T006_C
    //                         {
    //                             _stocking_unit1 = item.stocking_unit1,
    //                             accountcollectdid = item.accountcollectdid,
    //                             base_amount = item.base_amount,
    //                             description = item.description,
    //                             grnno = item.grnno,
    //                             id = item.id,
    //                             item_id = item.item_id,
    //                             tax_amount = item.tax_amount,
    //                             tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                             tax_id = item.tax_id,
    //                             taxaccount = item.taxaccount

    //                         });

    //                         dgPOTaxValues.Add(new ACC_T006_C
    //                         {
    //                             _stocking_unit1 = item.stocking_unit1,
    //                             accountcollectdid = item.accountcollectdid,
    //                             base_amount = item.base_amount,
    //                             description = item.description,
    //                             grnno = item.grnno,
    //                             id = item.id,
    //                             item_id = item.item_id,
    //                             tax_amount = item.tax_amount,
    //                             tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                             tax_id = item.tax_id,
    //                             taxaccount = item.taxaccount

    //                         });


    //                     }
    //                     try
    //                     {
    //                         TaxRowCalculation();
    //                     }
    //                     catch
    //                     {

    //                     }
    //                     try
    //                     {
    //                         //if (Selectedpartylist[0].stockingunit != "")
    //                         {
    //                             string[] values1 = SelectedCatItmDetails[0].ItemName.Split('\t');
    //                             string Reqstockingunit = "";
    //                             string[] values = SelectedCatItmDetails[0].stockingunit.Split('/');
    //                             for (int y = values.Count() - 1; y >= 0; y--)
    //                             {
    //                                 var stockingunit = (from o in FluteList
    //                                                     where o.code == Convert.ToInt32(values[y].ToString())
    //                                                     select o).ToList();
    //                                 {
    //                                     Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
    //                                 }


    //                             }
    //                             dgPEItems.Where(l => l.item_id == SelectedCatItmDetails[0].item_id).ToList().ForEach(i => i.description = (""));
    //                             dgPEItems.Where(l => l.item_id == SelectedCatItmDetails[0].item_id).ToList().ForEach(i => i.description = (values1[0] + Reqstockingunit));
    //                         }

    //                     }
    //                     catch
    //                     {

    //                     }
    //                     try
    //                     {
    //                         //SelectedPUR_T005_A.po_type = SelectedCatItmDetails[0].req_type;
    //                         //SelectedPUR_T005_A.reference = SelectedCatItmDetails[0].req_ref;
    //                         //if (SelectedCatItmDetails[0].appr_qty != 0 && SelectedCatItmDetails[0].rate != 0)
    //                         //{
    //                         //    dgPEItems.Where(l => l.item_id == SelectedCatItmDetails[0].id).ToList().ForEach(i => i.amount = Convert.ToDecimal(SelectedCatItmDetails[0].appr_qty * SelectedCatItmDetails[0].rate));
    //                         //    SelectedPUR_T005_A.amount_untaxed = dgPEItems.Sum(t => t.amount);
    //                         //    SelectedPUR_T005_A.amount_total = SelectedPUR_T005_A.amount_untaxed + SelectedPUR_T005_A.amount_tax;
    //                         //    double amount = Convert.ToDouble(SelectedPUR_T005_A.amount_total);
    //                         //    SelectedPUR_T005_A.amt_in_words = num.AmountInWords(Convert.ToDecimal(amount));

    //                         //}
    //                     }
    //                     catch
    //                     {

    //                     }


    //                 }
    //                 else if (SelectedCatItmDetails[0].Select == false && q != null && dgPEItems[x].id == 0)
    //                 {
    //                     if (x >= 0)
    //                     {
    //                         dgPEItems.RemoveAt(x);

    //                     }
    //                 }
    //                 else if (SelectedCatItmDetails[0].Select == true && (q == null)) // && r != null && r >= 0)
    //                 {
    //                     dgPEItems[dgSelectedIndex].item_id = SelectedCatItmDetails[0].item_id;
    //                     dgPEItems[dgSelectedIndex].item_code = SelectedCatItmDetails[0].ItemCode;
    //                     dgPEItems[dgSelectedIndex].item_name = SelectedCatItmDetails[0].ItemName;
    //                     dgPEItems[dgSelectedIndex].uom = Convert.ToInt32(SelectedCatItmDetails[0].unit_id);
    //                     dgPEItems[dgSelectedIndex].unit_name = SelectedCatItmDetails[0].unit_name;


    //                 }
    //                 else if (SelectedCatItmDetails[0].Select == true && q == null) // && r != null && r >= 0)
    //                 {
    //                     dgPEItems[dgSelectedIndex].item_id = SelectedCatItmDetails[0].item_id;
    //                     dgPEItems[dgSelectedIndex].item_code = SelectedCatItmDetails[0].ItemCode;
    //                     dgPEItems[dgSelectedIndex].item_name = SelectedCatItmDetails[0].ItemName;
    //                     dgPEItems[dgSelectedIndex].uom = Convert.ToInt32(SelectedCatItmDetails[0].unit_id);
    //                     dgPEItems[dgSelectedIndex].unit_name = SelectedCatItmDetails[0].unit_name;


    //                 }
    //                 try
    //                 {

    //                     MC_temp.itemList.Where(t => t.item_id == dgPEItems[dgSelectedIndex - 1].item_id).ToList().ForEach(t => t.Select = false);

    //                 }
    //                 catch
    //                 {

    //                 }

    //             }
    //         }

    //     }
    //     private void GRNNOChanged(IList BuyerList)
    //     {
    //         IList list = BuyerList as IList;
    //         List<MM_T001_GRN_PopUp> Selectedbuyerlist = list.Cast<MM_T001_GRN_PopUp>().ToList();
    //         if (Selectedbuyerlist.Count > 0)
    //         {
    //             if (SelectedPUR_T005_A.supplier_name != "" || SelectedPUR_T005_A.supplier_name != null)
    //             {
    //                 SelectedPUR_T005_A.grnno = Selectedbuyerlist[0].doc_no;

    //                 var grnlist = (from o in MC_temp.itemList
    //                                where o.grnno == SelectedPUR_T005_A.grnno
    //                                select o).ToList();

    //                 ItemCollection = CollectionViewSource.GetDefaultView(grnlist);
    //                 ItemCollection.Filter = new Predicate<object>(FilterItem);
    //             }
    //             else
    //             {
    //                 IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                 showMessageService.ButtonSetup = DialogButton.Ok;
    //                 showMessageService.Caption = "Message";
    //                 showMessageService.Text = String.Format("Please Select Party First..", this.Title);
    //                 showMessageService.ShowMessage();
    //                 SelectedPUR_T005_A.grnno = "";
    //                 ItemCollection = CollectionViewSource.GetDefaultView(MC_temp.itemList);
    //                 ItemCollection.Filter = new Predicate<object>(FilterItem);
    //             }
    //             //SelectedPUR_T005_A.p_term = Selectedbuyerlist[0].p_term;
    //         }
    //     }
    //     private void countryChanged(IList BuyerList)
    //     {
    //         IList list = BuyerList as IList;
    //         List<ADM_M012_PopUp> Selectedbuyerlist = list.Cast<ADM_M012_PopUp>().ToList();
    //         if (Selectedbuyerlist.Count > 0)
    //         {
    //             SelectedPUR_T005_A.supp_country = Selectedbuyerlist[0].CntryCode;
    //             SelectedPUR_T005_A.supp_country_name = Selectedbuyerlist[0].CntryName;
    //         }
    //     }
    //     private void GetPayTerms(IList BuyerList)
    //     {
    //         IList list = BuyerList as IList;
    //         List<ACC_M007_PopUp> Selectedbuyerlist = list.Cast<ACC_M007_PopUp>().ToList();
    //         if (Selectedbuyerlist.Count > 0)
    //         {
    //             //SelectedPUR_T005_A.pay_term_id = Selectedbuyerlist[0].id;
    //             //SelectedPUR_T005_A.p_term = Selectedbuyerlist[0].p_term;
    //         }
    //     }
    //     private void GetSelectedParty(IList partyList)
    //     {
    //         try
    //         {
    //             IList list = partyList as IList;
    //             List<ADM_M028_PopUp> SelectedPartyDetailsTemp = list.Cast<ADM_M028_PopUp>().ToList();
    //             if (SelectedPartyDetailsTemp.Count > 0)
    //             {
    //                 if (SelectedPUR_T005_A.id > 0)
    //                 {
    //                     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                     showMessageService.ButtonSetup = DialogButton.Ok;
    //                     showMessageService.Caption = "Party Selection";
    //                     showMessageService.Text =
    //                         String.Format("Can not change party'{0}'", this.Title);
    //                     showMessageService.ShowMessage();
    //                 }
    //                 else if (SelectedPUR_T005_A.id == 0)
    //                 {
    //                     if (dgPEItems.Count > 0)
    //                     {
    //                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                         showMessageService.ButtonSetup = DialogButton.Ok;
    //                         showMessageService.Caption = "Party Selection";
    //                         showMessageService.Text =
    //                             String.Format(
    //                                 "If You Change The Party Items Will be removed'{0}'",
    //                                     this.Title);

    //                         if (showMessageService.ShowMessage() == DialogResult.Ok)
    //                         {

    //                             dgPEItems = new ObservableCollection<PUR_T005_B>();
    //                             dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //                             //SelectedSEL_T001 = new SEL_T001();
    //                             SelectedPUR_T005_A.grnno ="";
    //                             SelectedPUR_T005_A.tax_amount = 0;
    //                             SelectedPUR_T005_A.totalamount = 0;
    //                             SelectedPUR_T005_A.untaxedamount = 0;
    //                             SelectedPUR_T005_A.supp_country_name ="";
    //                             SelectedPUR_T005_A.supp_country =0;
    //                             //SelectedPUR_T005_A.amt_in_words = "";

    //                             SelectedPUR_T005_A.party_id = Convert.ToInt32(SelectedPartyDetailsTemp[0].id);
    //                             SelectedPUR_T005_A.supplier_name = SelectedPartyDetailsTemp[0].PartyNm;
    //                             AssignParty(partyList);

    //                         }
    //                     }
    //                     else
    //                     {
    //                         AssignParty(partyList);
    //                     }

    //                 }

    //             }

    //         }
    //         catch (Exception ex)
    //         {
    //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //             showMessageService.ButtonSetup = DialogButton.Ok;
    //             showMessageService.Caption = "Message";
    //             showMessageService.Text = String.Format(ex.Message, this.Title);
    //             showMessageService.ShowMessage();
    //         }

    //         //if (SelectedPUR_T005_A.id > 0)
    //         //{
    //         //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //         //    showMessageService.ButtonSetup = DialogButton.Ok;
    //         //    showMessageService.Caption = "Message";
    //         //    showMessageService.Text = String.Format("You can not change party .", this.Title);
    //         //    showMessageService.ShowMessage();
    //         //}
    //         //else if (SelectedPUR_T005_A.id == 0)
    //         //{

    //         //    if (dgPEItems.Count > 0)
    //         //    {                   
    //         //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //         //                showMessageService.ButtonSetup = DialogButton.Ok;
    //         //                showMessageService.Caption = "Party Selection";
    //         //                showMessageService.Text =
    //         //                    String.Format(
    //         //                        "If You Change The Party Items Will be removed'{0}'",
    //         //                            this.Title);

    //         //                if (showMessageService.ShowMessage() == DialogResult.Ok)
    //         //                {
    //         //                    dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //         //                    SelectedPUR_T005_A.supplier_id = 0;
    //         //                    SelectedPUR_T005_A.amount_total = 0;
    //         //                    SelectedPUR_T005_A.amount_untaxed = 0;
    //         //                    SelectedPUR_T005_A.amount_tax = 0;
    //         //                    SelectedPUR_T005_A.amt_in_words = "";
    //         //                    SelectedPUR_T005_A.buyer_id = 0;
    //         //                    SelectedPUR_T005_A.buyer_name = null;

    //         //                    SelectedPUR_T005_A.supplier_name = null;
    //         //                    dgPEItems = new ObservableCollection<PUR_T005_B>();

    //         //                    AssignParty(partyList);
    //         //                } 
    //         //    }
    //         //    else
    //         //    {
    //         //        AssignParty(partyList);
    //         //    }
    //         //}
    //     }
    //     private void AssignParty(IList partyList)
    //     {
    //         IList list = partyList as IList;
    //         List<ADM_M028_PopUp> Selectedpartylist = list.Cast<ADM_M028_PopUp>().ToList();
    //         if (Selectedpartylist.Count > 0)
    //         {
    //             SelectedPUR_T005_A.party_id = Selectedpartylist[0].id;
    //             SelectedPUR_T005_A.supplier_name = Selectedpartylist[0].PartyNm;
    //             string company = "";
    //              company = AppSessionState.CompanyID.ToString() +"@"+ AppSessionState.Location.ToString();
    //             MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005_A>(MC_temp, "PUR_T002_A_Data", "PurchaseInvoice", "CRM", "LoadPartyDetails", Selectedpartylist[0].id, company);

    //             try
    //             {
    //                 ItemCollection = CollectionViewSource.GetDefaultView(MC_temp.itemList);
    //                 ItemCollection.Filter = new Predicate<object>(FilterItem);

    //                 reference_docCollection = CollectionViewSource.GetDefaultView(MC_temp.GRNList);
    //                 reference_docCollection.Filter = new Predicate<object>(refdocno_Filter);

    //             }
    //             catch
    //             {

    //             }
    //             if (MC_temp.currencyListPartyWise.ToList() != null && MC_temp.currencyListPartyWise.ToList().Count == 1)
    //             {
    //                 SelectedPUR_T005_A.doc_curr = MC_temp.currencyListPartyWise[0].id;
    //                 SelectedPUR_T005_A.currency_name = MC_temp.currencyListPartyWise[0].curr_name;
    //                 SelectedPUR_T005_A.exc_rate = MC_temp.currencyListPartyWise[0].rate;
    //             }
    //             else
    //             {
    //                 SelectedPUR_T005_A.doc_curr = null;
    //                 SelectedPUR_T005_A.currency_name = "";
    //                 SelectedPUR_T005_A.exc_rate = 0;

    //             }
    //             ParameterCodeCollection = MC_temp.ParameterCodeList;


    //         }
    //     }
    //     private void AddWarehouse(IList BuyerList)
    //     {
    //         IList list = BuyerList as IList;
    //         List<MM_M002_PopUp> Selectedbuyerlist = list.Cast<MM_M002_PopUp>().ToList();
    //         if (Selectedbuyerlist.Count > 0)
    //         {
    //             //SelectedPUR_T005_A.warehouse_id = Selectedbuyerlist[0].wa_code;
    //             //SelectedPUR_T005_A.warehouse_name = Selectedbuyerlist[0].wa_name;
    //         }
    //     }
    //     private void GetSelectedBuyer(IList BuyerList)
    //     {
    //         IList list = BuyerList as IList;
    //         List<ADM_M024_PopUp> Selectedbuyerlist = list.Cast<ADM_M024_PopUp>().ToList();
    //         if (Selectedbuyerlist.Count > 0)
    //         {
    //             //SelectedPUR_T005_A.buyer_id = Selectedbuyerlist[0].id;
    //             //SelectedPUR_T005_A.buyer_name = Selectedbuyerlist[0].EmpLName;
    //         }
    //     }
    //     private void AddSelectedItemToCollection(IList ItmList)
    //     {
    //         if (dgSelectedIndex != -1 && ItmList.Count > 0)
    //         {

    //             IList list = ItmList as IList;
    //             List<MM_T001_A_PopUp_PUR> SelectedCatItmDetails = list.Cast<MM_T001_A_PopUp_PUR>().ToList();
    //             {
    //                 var q = dgPEItems.Where(X => X.item_id == SelectedCatItmDetails[0].item_id).Where(X => X.stockingunit == SelectedCatItmDetails[0].stockingunit).FirstOrDefault();
    //                 //var q1 = dgPEItems.Where(X => X.requsition_id == SelectedCatItmDetails[0].requsition_id).FirstOrDefault();
    //                 int x = dgPEItems.IndexOf(dgPEItems.Where(X => X.item_id == SelectedCatItmDetails[0].item_id).Where(X => X.stockingunit == SelectedCatItmDetails[0].stockingunit).FirstOrDefault());

    //                 string grnno = SelectedCatItmDetails[0].grnno;
    //                 string stockunit = SelectedCatItmDetails[0].stockingunit;
    //                 int itemid = Convert.ToInt32(SelectedCatItmDetails[0].item_id);
    //                 string itemcode = SelectedCatItmDetails[0].ItemCode;

    //                 if (SelectedCatItmDetails[0].Select == true && dgPEItems.Count == dgSelectedIndex)
    //                 {

    //                     var itemlist = (from o in MC_temp.itemList
    //                                     where o.grnno == grnno && o.item_id == itemid
    //                                     && o.stockingunit == stockunit
    //                                     select o).ToList();

    //                     //dgPEItems = new ObservableCollection<PUR_T005_B>();
    //                     foreach (var item in itemlist)
    //                     {
    //                         dgPEItems.Add(new PUR_T005_B { amount = item.sub_total, item_cat = item.item_cat, pur_doc_no = item.po_no, grnno = item.grnno, item_id = item.item_id, item_code = item.ItemCode, item_name = item.ItemName, uom = item.unit_id, unit_name = item.unit_name, unit_price = item.rate, qty = item.appr_qty, tax_code = item.tax_id, SubCategCod = Convert.ToString(item.SubCategCod), stockingunit = item.stockingunit, stocking_unit1 = item.stockingunit, active = true });

    //                         if (SelectedPUR_T005_A.inv_no != "")
    //                         {
    //                             SelectedPUR_T005_A.amtinword = item.amt_in_words;
    //                             SelectedPUR_T005_A.untaxedamount = item.amount_untaxed;
    //                             SelectedPUR_T005_A.tax_amount = item.amount_tax;
    //                             SelectedPUR_T005_A.totalamount = item.amount_total;
    //                             SelectedPUR_T005_A.inv_no = item.invoiceNo;
    //                             SelectedPUR_T005_A.inv_date = item.Invoicedate;
    //                             SelectedPUR_T005_A.del_note = item.challanno;
    //                             SelectedPUR_T005_A.del_note_date = item.challandate;
    //                             SelectedPUR_T005_A.pay_terms = item.pay_term_id;
    //                             SelectedPUR_T005_A.p_term = item.p_term;
    //                             SelectedPUR_T005_A.doc_type = item.doc_cat;
    //                             SelectedPUR_T005_A.entry_time = item.entry_time;
    //                             SelectedPUR_T005_A.post_date = item.post_date;
    //                         }
    //                         else if (SelectedPUR_T005_A.inv_no == "")
    //                         {
    //                             SelectedPUR_T005_A.amtinword = item.amt_in_words;
    //                             SelectedPUR_T005_A.untaxedamount = item.amount_untaxed;
    //                             SelectedPUR_T005_A.tax_amount = item.amount_tax;
    //                             SelectedPUR_T005_A.totalamount = item.amount_total;
    //                             SelectedPUR_T005_A.inv_no = item.invoiceNo;
    //                             SelectedPUR_T005_A.inv_date = item.Invoicedate;
    //                             SelectedPUR_T005_A.del_note = item.challanno;
    //                             SelectedPUR_T005_A.del_note_date = item.challandate;
    //                             SelectedPUR_T005_A.pay_terms = item.pay_term_id;
    //                             SelectedPUR_T005_A.p_term = item.p_term;
    //                             SelectedPUR_T005_A.doc_type = item.doc_cat;
    //                             SelectedPUR_T005_A.entry_time = item.entry_time;
    //                             SelectedPUR_T005_A.post_date = item.post_date;
    //                         }
    //                         else
    //                         {
    //                             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                             showMessageService.ButtonSetup = DialogButton.Ok;
    //                             showMessageService.Caption = "Message";
    //                             showMessageService.Text = String.Format("Invoice No. is Different", this.Title);
    //                             showMessageService.ShowMessage();
    //                             dgPEItems.RemoveAt(x);
    //                         }
    //                         try
    //                         {
    //                             //if (Selectedpartylist[0].stockingunit != "")
    //                             {
    //                                 string[] values1 = SelectedCatItmDetails[0].ItemName.Split('\t');
    //                                 string Reqstockingunit = "";
    //                                 string[] values = SelectedCatItmDetails[0].stockingunit.Split('/');
    //                                 for (int y = values.Count() - 1; y >= 0; y--)
    //                                 {
    //                                     var stockingunit = (from o in FluteList
    //                                                         where o.code == Convert.ToInt32(values[y].ToString())
    //                                                         select o).ToList();
    //                                     {
    //                                         Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
    //                                     }
    //                                 }
    //                                 dgPEItems.Where(l => l.item_id == SelectedCatItmDetails[0].item_id).ToList().ForEach(i => i.description = (""));
    //                                 dgPEItems.Where(l => l.item_id == SelectedCatItmDetails[0].item_id).ToList().ForEach(i => i.description = (values1[0] + Reqstockingunit));
    //                             }

    //                         }
    //                         catch
    //                         {

    //                         }


    //                     }
    //                     //var taxlist = (from o in MC_temp.POTotaltaxDetails
    //                     //               where o.grnno == grnno && o.item_id == itemcode
    //                     //                && o.stocking_unit1 == stockunit
    //                     //               select o).ToList();
    //                     //foreach (var item in taxlist)
    //                     //{
    //                     //    dgPOTotalTaxValues.Add(new ACC_T006_C { 
    //                     //    _stocking_unit1=item.stocking_unit1,
    //                     //    accountcollectdid = item.accountcollectdid,
    //                     //    base_amount = item.base_amount,
    //                     //    description = item.description,
    //                     //    grnno = item.grnno,
    //                     //    id=item.id,
    //                     //    item_id=item.item_id,
    //                     //    tax_amount = item.tax_amount,
    //                     //    tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                     //    tax_id = item.tax_id,
    //                     //    taxaccount = item.taxaccount                           

    //                     //    });
    //                     //     dgPOTaxValues3.Add(new ACC_T006_C { 
    //                     //    _stocking_unit1=item.stocking_unit1,
    //                     //    accountcollectdid = item.accountcollectdid,
    //                     //    base_amount = item.base_amount,
    //                     //    description = item.description,
    //                     //    grnno = item.grnno,
    //                     //    id=item.id,
    //                     //    item_id=item.item_id,
    //                     //    tax_amount = item.tax_amount,
    //                     //    tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                     //    tax_id = item.tax_id,
    //                     //    taxaccount = item.taxaccount                           

    //                     //    });

    //                     //     dgPOTaxValues.Add(new ACC_T006_C
    //                     //     {
    //                     //         _stocking_unit1 = item.stocking_unit1,
    //                     //         accountcollectdid = item.accountcollectdid,
    //                     //         base_amount = item.base_amount,
    //                     //         description = item.description,
    //                     //         grnno = item.grnno,
    //                     //         id = item.id,
    //                     //         item_id = item.item_id,
    //                     //         tax_amount = item.tax_amount,
    //                     //         tax_amountbeforeedit = item.tax_amountbeforeedit,
    //                     //         tax_id = item.tax_id,
    //                     //         taxaccount = item.taxaccount

    //                     //     });


    //                     //}
    //                     try
    //                     {
    //                         TaxRowCalculation();
    //                     }
    //                     catch
    //                     {

    //                     }


    //                 }
    //                 else if (SelectedCatItmDetails[0].Select == false && q != null && dgPEItems[x].id == 0)
    //                 {
    //                     if (x >= 0)
    //                     {
    //                         dgPEItems.RemoveAt(x);

    //                     }
    //                 }
    //                 else if (SelectedCatItmDetails[0].Select == true && (q == null)) // && r != null && r >= 0)
    //                 {
    //                     dgPEItems[dgSelectedIndex].item_id = SelectedCatItmDetails[0].item_id;
    //                     dgPEItems[dgSelectedIndex].item_code = SelectedCatItmDetails[0].ItemCode;
    //                     dgPEItems[dgSelectedIndex].item_name = SelectedCatItmDetails[0].ItemName;
    //                     dgPEItems[dgSelectedIndex].uom = Convert.ToInt32(SelectedCatItmDetails[0].unit_id);
    //                     dgPEItems[dgSelectedIndex].unit_name = SelectedCatItmDetails[0].unit_name;


    //                 }
    //                 else if (SelectedCatItmDetails[0].Select == true && q == null) // && r != null && r >= 0)
    //                 {
    //                     dgPEItems[dgSelectedIndex].item_id = SelectedCatItmDetails[0].item_id;
    //                     dgPEItems[dgSelectedIndex].item_code = SelectedCatItmDetails[0].ItemCode;
    //                     dgPEItems[dgSelectedIndex].item_name = SelectedCatItmDetails[0].ItemName;
    //                     dgPEItems[dgSelectedIndex].uom = Convert.ToInt32(SelectedCatItmDetails[0].unit_id);
    //                     dgPEItems[dgSelectedIndex].unit_name = SelectedCatItmDetails[0].unit_name;


    //                 }
    //                 try
    //                 {

    //                     MC_temp.itemList.Where(t => t.item_id == dgPEItems[dgSelectedIndex - 1].item_id).ToList().ForEach(t => t.Select = false);

    //                 }
    //                 catch
    //                 {

    //                 }

    //             }


    //         }

    //     }
    //     private void AddSelectedUnitToCollection(IList unitList)
    //     {
    //         IList list = unitList as IList;
    //         List<ADM_M038_B_PopUp> Selectedunitlist = list.Cast<ADM_M038_B_PopUp>().ToList();
    //         if (Selectedunitlist.Count > 0)
    //         {
    //             if (dgPEItems.Count > 0 && dgSelectedIndex != -1 && dgPEItems.Count > dgSelectedIndex)
    //             {
    //                 dgPEItems[dgSelectedIndex].uom = Selectedunitlist[0].id;
    //                 dgPEItems[dgSelectedIndex].unit_name = Selectedunitlist[0].unit_name;
    //             }
    //         }
    //     }
    //     private void SelectBillAddress(IList billaddr)
    //     {
    //         IList list = billaddr as IList;
    //         List<ADM_M002_PopUp> GetSelecteddelbilladdrTemp = list.Cast<ADM_M002_PopUp>().ToList();
    //         if (GetSelecteddelbilladdrTemp.Count > 0)
    //         {
    //             //SelectedPUR_T005_A.bill_address_id = Convert.ToInt32(GetSelecteddelbilladdrTemp[0].Comp_Id);
    //             //SelectedPUR_T005_A.bill_address_type = GetSelecteddelbilladdrTemp[0].CompName;
    //         }
    //     }
    //     private void SelectedDelAddress(IList deladdr)
    //     {
    //         IList list = deladdr as IList;
    //         List<ADM_M003_PopUp> GetSelecteddeladdrTemp = list.Cast<ADM_M003_PopUp>().ToList();
    //         if (GetSelecteddeladdrTemp.Count > 0)
    //         {
    //             //SelectedPUR_T005_A.del_address_id = GetSelecteddeladdrTemp[0].Location_Id;
    //             //SelectedPUR_T005_A.del_address_type = GetSelecteddeladdrTemp[0].LoctnNm;
    //         }
    //     }
    //     private void CellChangeUpdate(IList DataList)
    //     {
    //         IList list = DataList as IList;
    //         if (list == null) return;
    //         List<PUR_T005_B> SelectedItemsDetailsTemp = list.Cast<PUR_T005_B>().ToList();

    //         if (SelectedItemsDetailsTemp.Count > 0)
    //         {
    //             PUR_T005_B SelectedPUR_T005_B = (PUR_T005_B)SelectedItemsDetailsTemp[0];
    //             int x = dgPEItems.IndexOf(dgPEItems.Where(X => X.item_id == SelectedItemsDetailsTemp[0].item_id).FirstOrDefault());
    //             if (x != null && x >= 0)
    //             {

    //                 if (dgPEItems[dgSelectedIndex].unit_price == null)
    //                 {
    //                     dgPEItems[dgSelectedIndex].unit_price = 0;
    //                 }
    //                 if (dgPEItems[dgSelectedIndex].qty == null)
    //                 {
    //                     dgPEItems[dgSelectedIndex].qty = 0;
    //                 }
    //                 dgPEItems[dgSelectedIndex].amount = ((dgPEItems[dgSelectedIndex].qty * dgPEItems[dgSelectedIndex].unit_price));
    //                 SelectedPUR_T005_A.untaxedamount = dgPEItems.Sum(t => t.amount);
    //                 SelectedPUR_T005_A.totalamount = SelectedPUR_T005_A.untaxedamount + SelectedPUR_T005_A.tax_amount;

    //                 //SelectedPUR_T005_A.tax_amount = ;
    //                 try
    //                 {
    //                     string tempTax = SelectedItemsDetailsTemp[dgSelectedIndex].tax_code;
    //                     SelectedItems = GetDict(tempTax);
    //                 }
    //                 catch
    //                 {

    //                 }
    //                 //TaxRowCalculation();

    //             }

    //         }

    //     }
    //     Dictionary<string, object> GetDict(string f)
    //     {
    //         if (string.IsNullOrEmpty(f) || string.IsNullOrWhiteSpace(f)) return null;
    //         Dictionary<string, object> d = new Dictionary<string, object>();

    //         string[] tokens = f.Split(new char[] { '/', ':', ',' },
    //             StringSplitOptions.RemoveEmptyEntries);
    //         for (int i = 0; i < tokens.Length; i += 1)
    //         {
    //             string name = tokens[i];
    //             if (d.ContainsKey(name))
    //             {
    //                 //d[name] += count;
    //             }
    //             else
    //             {
    //                 d.Add(name, "");
    //             }
    //         }
    //         return d;
    //     }      
    //     #endregion

    //     #region · Command Actions ·
    //     protected override void OnSaveAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         try
    //         {
    //             if (dgPEItems.Count > 0)
    //             {
    //                 this.SelectedPUR_T005_A.EndEdit();
    //                 SelectedPUR_T005_A.add_by = Convert.ToString(AppSessionState.UserID);
    //                 SelectedPUR_T005_A.plant_id = Convert.ToString(AppSessionState.Location);
    //                 SelectedPUR_T005_A.company_id  = (AppSessionState.CompanyID);


    //                 ObjectSerializationService obj = new ObjectSerializationService();
    //                 ADM_M030_P productData1 = new ADM_M030_P();
    //                 ADM_M030_P productData = new ADM_M030_P();
    //                 //StockingUnitCalculation();
    //                 try
    //                 {
    //                     int x4 = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.description == null).FirstOrDefault());
    //                     dgPOTotalTaxValues.RemoveAt(x4);
    //                 }
    //                 catch
    //                 {

    //                 }
    //                 dgscheduledmaster.Clear();
    //                 //dgscheduledmaster.Add(new PUR_T004_A() { add_by = AppSessionState.UserID, sch_date = SelectedPUR_T005_A.po_date, supplier_id = SelectedPUR_T005_A.supplier_id, location_id = SelectedPUR_T005_A.location_id });
    //                 //SelectedPUR_T005_A.location_id = AppSessionState.LocationID;
    //                 SelectedPUR_T005_A.XmlDataDocument_PUR_T005_B = obj.ObjectToXML(dgPEItems);
    //                 SelectedPUR_T005_A.XmlDataDocument_PUR_T005_E = obj.ObjectToXML(dgPOTaxValues1);
    //                 SelectedPUR_T005_A.XmlDataDocument_PUR_T005_D = obj.ObjectToXML(dgPOTotalTaxValues);
    //                 //SelectedPUR_T005_A.XmlDataDocument_PUR_T002_F = obj.ObjectToXML(dgPOdeliveryschedule);
    //                 //SelectedPUR_T005_A.XmlDataDocument_PUR_T002_G = obj.ObjectToXML(dgscheduledmaster);

    //                 if (ValidateControls() == true)
    //                 {
    //                     if (blNew == true)
    //                     {
    //                         SelectedPUR_T005_A = repository.SaveWithReturnDomainObject<PUR_T005_A>(SelectedPUR_T005_A, "PurchaseInvoice", "CRM");
    //                         SelectedList.Add(SelectedPUR_T005_A);
    //                         blNew = false;
    //                     }
    //                     else if (blNew == false)
    //                     {
    //                         SelectedPUR_T005_A = repository.UpdateWithReturnDomainObject<PUR_T005_A>(SelectedPUR_T005_A, "PurchaseInvoice", "CRM");
    //                     }
    //                     if (SelectedPUR_T005_A.XmlDataDocument_PUR_T005_E != null)
    //                     {
    //                         MC.PEItemsDetails = (ObservableCollection<PUR_T005_B>)new ObjectSerializationService().XMLToObject(SelectedPUR_T005_A.XmlDataDocument_PUR_T005_B, MC.PEItemsDetails);

    //                         MC.PEtaxDetails = (ObservableCollection<ACC_T006_C>)new ObjectSerializationService().XMLToObject(SelectedPUR_T005_A.XmlDataDocument_PUR_T005_E, MC.POTotaltaxDetails);

    //                     }
    //                     if (SelectedPUR_T005_A.XmlDataDocument_PUR_T005_B != null)
    //                     {
    //                         dgPOTaxValues = new ObservableCollection<ACC_T006_C>();
    //                         dgPOTaxValues1 = new ObservableCollection<ACC_T006_C>();
    //                         dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //                         dgPOTaxValues1 = MC.PEtaxDetails;
    //                         dgPOItemsForParameterval = CollectionViewSource.GetDefaultView(dgPOTaxValues1);

    //                         MC.ParamvalList = MC.ParamvalList;
    //                         for (int i = 0; i < dgPOItemsForParameterval.Cast<ACC_T006_C>().ToList().Count(); i++)
    //                         {
    //                             dgPOTaxValues.Add(dgPOItemsForParameterval.Cast<ACC_T006_C>().ElementAt(i));
    //                         }
    //                         dgPOTotalTaxValues = MC.PEtaxDetails;
    //                         dgPEItems = new ObservableCollection<PUR_T005_B>();
    //                         dgPEItems = MC.PEItemsDetails;
    //                         foreach (var item in dgPEItems)
    //                         {
    //                             dgPEItems.Where(i => i.item_id == item.item_id).Where(i => i.stockingunit == item.stockingunit).ToList().ForEach(L => L.stocking_unit1 = item.stockingunit);
    //                         }
    //                         try
    //                         {
    //                             TaxRowCalculation();
    //                         }
    //                         catch
    //                         {

    //                         }
    //                         //Update();
    //                     }
    //                     //else
    //                     //{
    //                     //    MC.PEItemsDetails = new ObservableCollection<PUR_T005_B>();
    //                     //}
    //                     _dataGridCollection.Refresh();
    //                 }
    //                 else
    //                 {
    //                 }
    //             }
    //             else
    //             {
    //                 IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                 showMessageService.ButtonSetup = DialogButton.Ok;
    //                 showMessageService.Caption = "Message";
    //                 showMessageService.Text = String.Format("Please Select Items", this.Title);
    //                 showMessageService.ShowMessage();
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //             showMessageService.ButtonSetup = DialogButton.Ok;
    //             showMessageService.Caption = "Message";
    //             showMessageService.Text = String.Format(ex.Message, this.Title);
    //             showMessageService.ShowMessage();
    //         }
    //     }
    //     protected override void OnCreateAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         blNew = true;
    //         SelectedPUR_T005_A = new PUR_T005_A();
    //         SelectedPUR_T005_A.doc_date = DateTime.Now;
    //         dgPOdeliveryschedule = new ObservableCollection<PUR_T004_B>();
    //         dgPOschedule = new ObservableCollection<PurchaseOrder_deliveryschedule>();
    //         MC.PEItemsDetails = new ObservableCollection<PUR_T005_B>();
    //         dgPOTaxValues1 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues2 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //         ParamitemList = new ObservableCollection<ADM_M030_P>();
    //         dgPOTaxValues = new ObservableCollection<ACC_T006_C>();
    //         ParamclearList = new ObservableCollection<ADM_M030_P>();
    //         ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
    //         dgPEItems.Clear();
    //         ParamitemList1 = new ObservableCollection<ADM_M030_P>();
    //         _dataGridCollection.Refresh();
    //         foreach (var listItem in MC.itemList.ToList())
    //             listItem.Select = false;


    //         List<MM_T001_A_PopUp_PUR> RequisitionItem = new List<MM_T001_A_PopUp_PUR>();
    //         ItemCollection = CollectionViewSource.GetDefaultView(RequisitionItem);
    //         SelectedPUR_T005_A.ValidateAsync().Wait();
    //         //SelectedPUR_T005_A.po_date = DateTime.Now;
    //     }

    //     protected override void OnRemoveAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //         showMessageService.ButtonSetup = DialogButton.Ok;
    //         showMessageService.Caption = "Delete Changes";
    //         showMessageService.Text =
    //             String.Format(
    //                 "This record will be Deleted forever '{0}'",
    //                     this.Title);

    //         if (showMessageService.ShowMessage() == DialogResult.Ok)
    //         {
    //             this.SelectedPUR_T005_A.EndEdit();
    //             string response = repository.Delete(SelectedPUR_T005_A.id, "PurchaseInvoice", "CRM");
    //             SelectedList.Remove(SelectedPUR_T005_A);
    //             SelectedPUR_T005_A = new PUR_T005_A();

    //             _dataGridCollection.Refresh();
    //         }
    //     }
    //     protected override void OnDiscardAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         SelectedPUR_T005_A.CancelEdit();
    //     }
    //     protected override void OnFevoriteAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         SelectedList = SelectedList;
    //     }
    //     protected override void OnFlipAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         SelectedList = SelectedList;
    //         SelectedPUR_T005_A = SelectedPUR_T005_A;
    //     }
    //     protected override void OnHelpAction(InquiryActionResult<PUR_T005_A> result)
    //     {
    //         SelectedList = SelectedList;
    //         SelectedPUR_T005_A = SelectedPUR_T005_A;
    //     }
    //     protected override void OnPrintAction(InquiryActionResult<PUR_T005_A> result)
    //     {


    //     }
    //     //protected override void OnExportAction(InquiryActionResult<PUR_T005_A> result)
    //     //{
    //     //    try
    //     //    {
    //     //        List<PUR_T005_A> Export_List = new List<PUR_T005_A>();
    //     //        foreach (var o in DataGridCollection)
    //     //        {
    //     //            PUR_T005_A Data = o as PUR_T005_A;
    //     //            Export_List.Add(Data);
    //     //        }

    //     //        //--------------------------------------

    //     //        ExportToExcel<PUR_T005_A, List<PUR_T005_A>> export = new ExportToExcel<PUR_T005_A, List<PUR_T005_A>>();
    //     //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
    //     //        export.dataToPrint = (List<PUR_T005_A>)view.SourceCollection;

    //     //        export.GenerateReport();
    //     //    }
    //     //    catch (Exception ex)
    //     //    {
    //     //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //     //        showMessageService.ButtonSetup = DialogButton.Ok;
    //     //        showMessageService.Caption = "Message";
    //     //        showMessageService.Text = String.Format(ex.Message, this.Title);
    //     //        showMessageService.ShowMessage();
    //     //    }

    //     //}

    //     private bool ValidateControls()
    //     {
    //         try
    //         {
    //             int i = 0;
    //             int count1 = 0;
    //             string[] values = new string[50];
    //             string description1 = "";
    //             try
    //             {
    //                 for (int y = 0; y < dgPEItems.Count; y++)
    //                 {
    //                     try
    //                     {
    //                         description1 = dgPEItems[y].description.ToString();
    //                         values = description1.Split('\t');
    //                     }
    //                     catch
    //                     {

    //                     }

    //                     try
    //                     {
    //                         int item_id = Convert.ToInt32(dgPEItems[y].item_id);
    //                         int subcatcode = Convert.ToInt32(dgPEItems[y].SubCategCod);
    //                         var ParameterType = (from o in MC.ParamvalList
    //                                              where o.SubCatCode == subcatcode
    //                                              select o).ToList();
    //                         for (int i1 = 0; i1 < values.Count(); i1++)
    //                         {
    //                             string[] val = values[i1].Split(':');
    //                             try
    //                             {
    //                                 if (i1 != 0)
    //                                 {
    //                                     if (val[2].ToString() != "")
    //                                     {
    //                                         i = 0;
    //                                     }
    //                                     else
    //                                     {
    //                                         i = 1;

    //                                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                                         showMessageService.ButtonSetup = DialogButton.Ok;
    //                                         showMessageService.Caption = "Message";
    //                                         showMessageService.Text = String.Format("Please Select All Parameter Value", this.Title);
    //                                         showMessageService.ShowMessage();
    //                                         break;
    //                                     }
    //                                 }
    //                             }
    //                             catch
    //                             {

    //                             }
    //                         }
    //                         //if ((values.Count() - 1) == ParameterType.Count)
    //                         //{
    //                         //    i = 0;

    //                         //}
    //                         //else
    //                         //{
    //                         //    i = 1;
    //                         //    break;
    //                         //}

    //                     }
    //                     catch
    //                     {

    //                     }
    //                 }

    //             }
    //             catch (Exception ex)
    //             {

    //             }
    //             {
    //                 foreach (var item in dgPEItems)
    //                 {
    //                     var duplicateitem = (from o in dgPEItems
    //                                          where o.item_id == item.item_id && o.stocking_unit1 == item.stocking_unit1
    //                                          select o).ToList();
    //                     if (duplicateitem.Count > 1)
    //                     {
    //                         i = 1;
    //                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                         showMessageService.ButtonSetup = DialogButton.Ok;
    //                         showMessageService.Caption = "Message";
    //                         showMessageService.Text = String.Format("Duplicate Parameter Value", this.Title);
    //                         showMessageService.ShowMessage();
    //                         break;
    //                     }
    //                 }


    //             }
    //             if (SelectedPUR_T005_A.doc_type == null || SelectedPUR_T005_A.doc_type == "")//
    //             {
    //                 i = 1;
    //                 IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                 showMessageService.ButtonSetup = DialogButton.Ok;
    //                 showMessageService.Caption = "Message";
    //                 showMessageService.Text = String.Format("Please select doc type", this.Title);
    //                 showMessageService.ShowMessage();

    //             }
    //             if (i == 0)
    //             {
    //                 return true;
    //             }
    //             else
    //             {
    //                 return false;
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             return true;
    //         }
    //     }

    //     private void Active(bool select)
    //     {

    //         try
    //         {                
    //             TaxRowCalculation();

    //         }
    //         catch
    //         {

    //         }


    //     }
    //     private bool ValidateControlsRate()
    //     {
    //         try
    //         {
    //             int i = 0;
    //             int count1 = 0;
    //             string[] values = new string[50];
    //             string description1 = "";
    //             try
    //             {
    //                 //for (int y = 0; y < dgPEItems.Count; y++)
    //                 //{
    //                 try
    //                 {
    //                     description1 = dgPEItems[dgSelectedIndex].description.ToString();
    //                     values = description1.Split('\t');
    //                 }
    //                 catch
    //                 {

    //                 }

    //                 try
    //                 {
    //                     int item_id = Convert.ToInt32(dgPEItems[dgSelectedIndex].item_id);
    //                     int subcatcode = Convert.ToInt32(dgPEItems[dgSelectedIndex].SubCategCod);
    //                     var ParameterType = (from o in MC.ParamvalList
    //                                          where o.SubCatCode == subcatcode
    //                                          select o).ToList();
    //                     for (int i1 = 0; i1 < values.Count(); i1++)
    //                     {
    //                         string[] val = values[i1].Split(':');
    //                         try
    //                         {
    //                             if (i1 != 0)
    //                             {
    //                                 if (val[2].ToString() != "")
    //                                 {
    //                                     i = 0;
    //                                 }
    //                                 else
    //                                 {
    //                                     i = 1;
    //                                     break;
    //                                 }
    //                             }
    //                         }
    //                         catch
    //                         {

    //                         }
    //                     }
    //                     //if ((values.Count() - 1) == ParameterType.Count)
    //                     //{
    //                     //    i = 0;

    //                     //}
    //                     //else
    //                     //{
    //                     //    i = 1;
    //                     //    break;
    //                     //}

    //                 }
    //                 catch
    //                 {

    //                 }
    //                 //  }

    //             }
    //             catch (Exception ex)
    //             {

    //             }

    //             if (i == 0)
    //             {
    //                 return true;
    //             }
    //             else
    //             {
    //                 return false;
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             return true;
    //         }
    //     }

    //     #endregion

    //     #region Methods

    //     public event PropertyChangedEventHandler PropertyChanged;
    //     private void RaisePropertyChanged(string propertyname)
    //     {
    //         if (PropertyChanged != null)
    //         {
    //             PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    //         }
    //     }

    //     private void StockingUnitCalculation()
    //     {
    //         string description = "";
    //         int count = 0;

    //         for (int y = 0; y < dgPEItems.Count; y++)
    //         {
    //             try
    //             {
    //                 description = dgPEItems[y].description.ToString();
    //                 if (dgPEItems[y].item_code.Contains(":"))
    //                 {
    //                     string[] splititem = new string[50];
    //                     splititem = dgPEItems[y].item_code.Split(':');
    //                     dgPEItems[y].item_code = splititem[0];

    //                 }
    //             }
    //             catch
    //             {

    //             }
    //             string stockingunit = "";

    //             try
    //             {

    //                 {
    //                     while (description.Contains("\t"))
    //                     {
    //                         try
    //                         {
    //                             string itemcode = description.Substring(0, description.LastIndexOf(":"));
    //                             string itemcode1 = description.Replace(itemcode, "");
    //                             string itemcode2 = itemcode1.Replace(":", "");
    //                             if (count == 0)
    //                             {
    //                                 dgPEItems[y].item_code = dgPEItems[y].item_code + ":" + itemcode2;

    //                             }
    //                             else
    //                             {
    //                                 dgPEItems[y].item_code = dgPEItems[y].item_code + "/" + itemcode2;

    //                             }
    //                             string itemcode3 = itemcode.Substring(0, description.LastIndexOf("\t"));
    //                             description = itemcode3;
    //                             count++;
    //                         }
    //                         catch
    //                         {
    //                             break;
    //                         }
    //                     }
    //                 }
    //                 count = 0;
    //             }
    //             catch
    //             {

    //             }

    //         }



    //     }

    //     #endregion

    //     #region "Filetr String"
    //     //po filter
    //     public string FilterString_AllPOData
    //     {
    //         get { return _filterString_AllPOData; }
    //         set
    //         {
    //             _filterString_AllPOData = value;
    //             RaisePropertyChanged("FilterString_AllPOData");
    //             FilterCollection();
    //         }
    //     }
    //     private void FilterCollection()
    //     {
    //         if (_dataGridCollection != null)
    //         {
    //             _dataGridCollection.Refresh();
    //         }
    //     }
    //     public bool Filter(object obj)
    //     {
    //         var data = obj as PUR_T005_A;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_AllPOData))
    //             {
    //                 return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_AllPOData.ToLower())) ||
    //                     (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_AllPOData.ToLower())) ||
    //                     (data.supplier_name != null && data.supplier_name.ToString().ToLower().Contains(_filterString_AllPOData.ToLower()));

    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //party filter
    //     public string FilterString_party
    //     {
    //         get { return _filterString_party; }
    //         set
    //         {
    //             _filterString_party = value;
    //             RaisePropertyChanged("FilterString_party");
    //             FilterCollectionParty();
    //         }
    //     }
    //     private void FilterCollectionParty()
    //     {
    //         if (_partyCollection != null)
    //         {
    //             _partyCollection.Refresh();
    //         }
    //     }
    //     public bool FilterParty(object obj)
    //     {
    //         var data = obj as ADM_M028_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_party))
    //             {
    //                 return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //buyer filter
    //     public string FilterString_buyer
    //     {
    //         get { return _filterString_Buyer; }
    //         set
    //         {
    //             _filterString_Buyer = value;
    //             RaisePropertyChanged("FilterString_buyer");
    //             FilterCollectionbuyer();
    //         }
    //     }
    //     private void FilterCollectionbuyer()
    //     {
    //         if (_buyerCollection != null)
    //         {
    //             _buyerCollection.Refresh();
    //         }
    //         //validatedByCollection
    //         else if (_validatedByCollection != null)
    //         {
    //             _validatedByCollection.Refresh();
    //         }
    //     }
    //     public bool FilterBuyer(object obj)
    //     {
    //         var data = obj as ADM_M024_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_party))
    //             {
    //                 return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
    //                     data.EmpMName != null && data.EmpMName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
    //                     data.EmpFName != null && data.EmpFName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //item filter
    //     public string FilterString_Item
    //     {
    //         get { return _filterString_Item; }
    //         set
    //         {
    //             _filterString_Item = value;
    //             RaisePropertyChanged("_FilterString_Item");
    //             FilterCollectionItem();
    //         }
    //     }
    //     private void FilterCollectionItem()
    //     {
    //         if (_itemCollection != null)
    //         {
    //             _itemCollection.Refresh();
    //         }
    //     }
    //     public bool FilterItem(object obj)
    //     {
    //         var data = obj as MM_T001_A_PopUp_PUR;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_Item))
    //             {
    //                 return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
    //                        (data.SubCategCod != null && data.SubCategCod.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
    //                         (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
    //                            (data.CustCode != null && data.CustCode.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
    //                               (data.CustDecrName != null && data.CustDecrName.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
    //                         data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }


    //     private string _filterString_grn;
    //     public string FilterString_GRN
    //     {
    //         get { return _filterString_grn; }
    //         set
    //         {
    //             _filterString_grn = value;
    //             RaisePropertyChanged("_FilterString_GRN");
    //             FilterCollectionGRN();
    //         }
    //     }
    //     private void FilterCollectionGRN()
    //     {
    //         if (_grnCollection != null)
    //         {
    //             _grnCollection.Refresh();
    //         }
    //     }
    //     public bool FilterGRN(object obj)
    //     {
    //         var data = obj as MM_T001_A_PopUp_PUR;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_grn))
    //             {
    //                 return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_grn.ToLower()) ||
    //                        (data.SubCategCod != null && data.SubCategCod.ToString().ToLower().Contains(_filterString_grn.ToLower())) ||
    //                         (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_grn.ToLower())) ||
    //                            (data.CustCode != null && data.CustCode.ToString().ToLower().Contains(_filterString_grn.ToLower())) ||
    //                               (data.CustDecrName != null && data.CustDecrName.ToString().ToLower().Contains(_filterString_grn.ToLower())) ||
    //                         data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_grn.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //warehouse
    //     public string FilterString_Warehouse
    //     {
    //         get { return _filterString_warehouse; }
    //         set
    //         {
    //             _filterString_warehouse = value;
    //             RaisePropertyChanged("_filterString_payterms");
    //             FilterCollectionWarehouse();
    //         }
    //     }
    //     private void FilterCollectionWarehouse()
    //     {
    //         if (_warehouseCollection != null)
    //         {
    //             _warehouseCollection.Refresh();
    //         }
    //     }
    //     public bool FilterCollectionWarehouse(object obj)
    //     {
    //         var data = obj as MM_M002_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_warehouse))
    //             {
    //                 return (data.wa_name != null && data.wa_name.ToString().ToLower().Contains(_filterString_warehouse.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //payterm
    //     public string FilterString_Payterms
    //     {
    //         get { return _filterString_payterms; }
    //         set
    //         {
    //             _filterString_payterms = value;
    //             RaisePropertyChanged("_filterString_payterms");
    //             FilterCollectionPayTerm();
    //         }
    //     }
    //     private void FilterCollectionPayTerm()
    //     {
    //         if (_paytermCollection != null)
    //         {
    //             _paytermCollection.Refresh();
    //         }
    //     }
    //     public bool FilterPayTerms(object obj)
    //     {
    //         var data = obj as ACC_M007_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_payterms))
    //             {
    //                 return (data.p_term != null && data.p_term.ToString().ToLower().Contains(_filterString_payterms.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     public string FilterString_scheduleItem
    //     {
    //         get { return _filterString_scheduleItem; }
    //         set
    //         {
    //             _filterString_scheduleItem = value;
    //             RaisePropertyChanged("_FilterString_scheduleItem");
    //             FilterCollectionscheduleItem();
    //         }
    //     }
    //     private void FilterCollectionscheduleItem()
    //     {
    //         if (_itemCollection != null)
    //         {
    //             _itemCollection.Refresh();
    //         }
    //     }
    //     public bool FilterscheduleItem(object obj)
    //     {
    //         var data = obj as PurchaseOrder_deliveryschedule;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_scheduleItem))
    //             {
    //                 return (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
    //                        (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_Item.ToLower())));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //del addr
    //     public string FilterString_deladdr
    //     {
    //         get { return _filterString_deladdr; }
    //         set
    //         {
    //             _filterString_deladdr = value;
    //             RaisePropertyChanged("FilterString_deladdr");
    //             FilterCollectiondeladdr();
    //         }
    //     }
    //     private void FilterCollectiondeladdr()
    //     {
    //         if (_delAddrCollection != null)
    //         {
    //             _delAddrCollection.Refresh();
    //         }
    //         else if (_billAddrCollection != null)
    //         {
    //             _billAddrCollection.Refresh();
    //         }

    //     }
    //     public bool Filterdeladdr(object obj)
    //     {
    //         var data = obj as ADM_M003_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_deladdr))
    //             {
    //                 return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_deladdr.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //bill addr


    //     public string FilterString_billaddr
    //     {
    //         get { return _filterString_billaddr; }
    //         set
    //         {
    //             _filterString_billaddr = value;
    //             RaisePropertyChanged("FilterString_billaddr");
    //             FilterCollectionbilladdr();
    //         }
    //     }
    //     private void FilterCollectionbilladdr()
    //     {
    //         if (_billAddrCollection != null)
    //         {
    //             _billAddrCollection.Refresh();
    //         }
    //         else if (_billAddrCollection != null)
    //         {
    //             _billAddrCollection.Refresh();
    //         }

    //     }
    //     public bool Filterbilladdr(object obj)
    //     {
    //         var data = obj as ADM_M002_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_billaddr))
    //             {
    //                 return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_billaddr.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //unit filter _filterString_uom
    //     public string FilterString_uom
    //     {
    //         get { return _filterString_uom; }
    //         set
    //         {
    //             _filterString_uom = value;
    //             RaisePropertyChanged("FilterString_uom");
    //             FilterCollectionuom();
    //         }
    //     }
    //     private void FilterCollectionuom()
    //     {
    //         if (_uomCollection != null)
    //         {
    //             _uomCollection.Refresh();
    //         }
    //     }
    //     public bool FilterUom(object obj)
    //     {
    //         var data = obj as ADM_M038_B_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_uom))
    //             {
    //                 return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_uom.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //tax
    //     public string FilterString_tax
    //     {
    //         get { return _filterString_tax; }
    //         set
    //         {
    //             _filterString_uom = value;
    //             RaisePropertyChanged("FilterString_tax");
    //             FilterCollectiontax();
    //         }
    //     }
    //     private void FilterCollectiontax()
    //     {
    //         if (_dgPOItemsFortaxval != null)
    //         {
    //             _dgPOItemsFortaxval.Refresh();
    //         }
    //     }
    //     public bool Filtertax(object obj)
    //     {
    //         var data = obj as ACC_M013_P;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_tax))
    //             {
    //                 return (data.taxaccount != null && data.taxaccount.ToString().ToLower().Contains(_filterString_uom.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //ParameterFilter
    //     private string _ParameterFilter;
    //     public string ParameterFilter
    //     {
    //         get { return _ParameterFilter; }
    //         set
    //         {
    //             _ParameterFilter = value;
    //             RaisePropertyChanged("ParameterFilter");
    //             ParameterFilterCollection();
    //         }
    //     }
    //     private void ParameterFilterCollection()
    //     {
    //         if (_ParameterCollection != null)
    //         {
    //             _ParameterCollection.Refresh();
    //         }
    //     }
    //     public bool FilterParam(object obj)
    //     {
    //         var data = obj as ADM_M034_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_ParameterFilter))
    //             {
    //                 return (data.SubCatCode.ToString() != null && data.SubCatCode.ToString().ToLower().Contains(_ParameterFilter.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //Document Type
    //     private void FilterCollection_doctype()
    //     {
    //         if (_doc_typeCollection != null)
    //         {
    //             _doc_typeCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_doctype;
    //     public string FilterString_doctype
    //     {
    //         get { return _filterString_doctype; }
    //         set
    //         {
    //             _filterString_doctype = value;
    //             RaisePropertyChanged("FilterString_doctype");
    //             FilterCollection_doctype();
    //         }
    //     }
    //     public bool doctype_Filter(object obj)
    //     {
    //         var data = obj as SYS_M007_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_doctype))
    //             {
    //                 return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower()) ||
    //                     data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_doctype.ToLower()));

    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     ////Currency Master
    //     private void FilterCollection_currency()
    //     {
    //         if (_currencyCollection != null)
    //         {
    //             _currencyCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_currency;
    //     public string FilterString_currency
    //     {
    //         get { return _filterString_currency; }
    //         set
    //         {
    //             _filterString_currency = value;
    //             RaisePropertyChanged("FilterString_currency");
    //             FilterCollection_currency();
    //         }
    //     }
    //     public bool currency_Filter(object obj)
    //     {
    //         var data = obj as ADM_M037_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_currency))
    //             {
    //                 return (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_currency.ToLower()));

    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //Reference doc no's
    //     private void FilterCollection_refdocno()
    //     {
    //         if (_currencyCollection != null)
    //         {
    //             _currencyCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_refdocno;
    //     public string FilterString_refdocno
    //     {
    //         get { return _filterString_refdocno; }
    //         set
    //         {
    //             _filterString_refdocno = value;
    //             RaisePropertyChanged("FilterString_refdocno");
    //             FilterCollection_refdocno();
    //         }
    //     }
    //     public bool refdocno_Filter(object obj)
    //     {
    //         var data = obj as MM_T001_GRN_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_refdocno))
    //             {
    //                 return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_refdocno.ToLower()));

    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //Sale Organisation
    //     private void FilterCollection_saleorg()
    //     {
    //         if (po_orgCollection != null)
    //         {
    //             po_orgCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_saleorg;
    //     public string FilterString_saleorg
    //     {
    //         get { return _filterString_saleorg; }
    //         set
    //         {
    //             _filterString_saleorg = value;
    //             RaisePropertyChanged("FilterString_saleorg");
    //             FilterCollection_refdocno();
    //         }
    //     }
    //     public bool saleorg_Filter(object obj)
    //     {
    //         var data = obj as ADM_M001_A_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_saleorg))
    //             {
    //                 return (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_saleorg.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Sales Division
    //     private void FilterCollection_saledivision()
    //     {
    //         if (sales_divisionCollection != null)
    //         {
    //             sales_divisionCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_saledivision;
    //     public string FilterString_saledivision
    //     {
    //         get { return _filterString_saledivision; }
    //         set
    //         {
    //             _filterString_saledivision = value;
    //             RaisePropertyChanged("FilterString_saledivision");
    //             FilterCollection_saledivision();
    //         }
    //     }
    //     public bool saledivision_Filter(object obj)
    //     {
    //         var data = obj as ADM_M001_D_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_saledivision))
    //             {
    //                 return (data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterString_saledivision.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Distribution Channel
    //     private void FilterCollection_distChannel()
    //     {
    //         if (distribution_channelCollection != null)
    //         {
    //             distribution_channelCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_distChannel;
    //     public string FilterString_distChannel
    //     {
    //         get { return _filterString_distChannel; }
    //         set
    //         {
    //             _filterString_distChannel = value;
    //             RaisePropertyChanged("FilterString_distChannel");
    //             FilterCollection_distChannel();
    //         }
    //     }
    //     public bool distChannel_Filter(object obj)
    //     {
    //         var data = obj as ADM_M001_C_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_distChannel))
    //             {
    //                 return (data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString_distChannel.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Sales Person
    //     private void FilterCollection_sales_person()
    //     {
    //         if (sales_personCollection != null)
    //         {
    //             sales_personCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_sales_person;
    //     public string FilterString_sales_person
    //     {
    //         get { return _filterString_sales_person; }
    //         set
    //         {
    //             _filterString_sales_person = value;
    //             RaisePropertyChanged("FilterString_sales_person");
    //             FilterCollection_sales_person();
    //         }
    //     }
    //     public bool sales_person_Filter(object obj)
    //     {
    //         var data = obj as ADM_M024_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_sales_person))
    //             {
    //                 return (data.name != null && data.name.ToString().ToLower().Contains(_filterString_sales_person.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Sales Office
    //     private void FilterCollection_sales_ofc()
    //     {
    //         if (sales_officeCollection != null)
    //         {
    //             sales_officeCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_sales_ofc;
    //     public string FilterString_sales_ofc
    //     {
    //         get { return _filterString_sales_ofc; }
    //         set
    //         {
    //             _filterString_sales_ofc = value;
    //             RaisePropertyChanged("FilterString_sales_ofc");
    //             FilterCollection_sales_ofc();
    //         }
    //     }
    //     public bool sales_ofc_Filter(object obj)
    //     {
    //         var data = obj as ADM_M001_I_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_sales_ofc))
    //             {
    //                 return (data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterString_sales_ofc.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Sales Group
    //     private void FilterCollection_sales_grp()
    //     {
    //         if (sales_groupCollection != null)
    //         {
    //             sales_groupCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_sales_grp;
    //     public string FilterString_sales_grp
    //     {
    //         get { return _filterString_sales_grp; }
    //         set
    //         {
    //             _filterString_sales_grp = value;
    //             RaisePropertyChanged("FilterString_sales_grp");
    //             FilterCollection_sales_grp();
    //         }
    //     }
    //     public bool sales_grp_Filter(object obj)
    //     {
    //         var data = obj as ADM_M001_H_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_sales_grp))
    //             {
    //                 return (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_sales_grp.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Storage Location
    //     private void FilterCollection_storage_loc()
    //     {
    //         if (_storage_locCollection != null)
    //         {
    //             _storage_locCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_storage_loc;
    //     public string FilterString_storage_loc
    //     {
    //         get { return _filterString_storage_loc; }
    //         set
    //         {
    //             _filterString_storage_loc = value;
    //             RaisePropertyChanged("FilterString_storage_loc");
    //             FilterCollection_storage_loc();
    //         }
    //     }
    //     public bool storage_loc_Filter(object obj)
    //     {
    //         var data = obj as MM_M001_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_storage_loc))
    //             {
    //                 return (data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_storage_loc.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //Cost Center
    //     private void FilterCollection_cost_center()
    //     {
    //         if (cost_centerCollection != null)
    //         {
    //             cost_centerCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_cost_center;
    //     public string FilterString_cost_center
    //     {
    //         get { return _filterString_cost_center; }
    //         set
    //         {
    //             _filterString_cost_center = value;
    //             RaisePropertyChanged("FilterString_cost_center");
    //             FilterCollection_cost_center();
    //         }
    //     }
    //     public bool cost_center_Filter(object obj)
    //     {
    //         var data = obj as ACC_M019_Popup;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_cost_center))
    //             {
    //                 return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_cost_center.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }

    //     //journal
    //     private void FilterCollection_journal()
    //     {
    //         if (journalCollection != null)
    //         {
    //             journalCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_journal;
    //     public string FilterString_journal
    //     {
    //         get { return _filterString_journal; }
    //         set
    //         {
    //             _filterString_journal = value;
    //             RaisePropertyChanged("FilterString_journal");
    //             FilterCollection_journal();
    //         }
    //     }
    //     public bool journal_Filter(object obj)
    //     {
    //         var data = obj as ACC_M005_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_journal))
    //             {
    //                 return (data.journal_name != null && data.journal_name.ToString().ToLower().Contains(_filterString_journal.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //wtunit
    //     private string _filterString_wtunit;
    //     public string FilterString_wtunit
    //     {
    //         get { return _filterString_wtunit; }
    //         set
    //         {
    //             _filterString_wtunit = value;
    //             RaisePropertyChanged("FilterString_wtunit");
    //             FilterCollectionwtunit();
    //         }
    //     }
    //     private void FilterCollectionwtunit()
    //     {
    //         if (_wtunitCollection != null)
    //         {
    //             _wtunitCollection.Refresh();
    //         }
    //     }
    //     public bool Filterwtunit(object obj)
    //     {
    //         var data = obj as ADM_M038_B_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_wtunit))
    //             {
    //                 return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_wtunit.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //volumeunit
    //     private string _filterString_volumeunit;
    //     public string FilterString_volumeunit
    //     {
    //         get { return _filterString_volumeunit; }
    //         set
    //         {
    //             _filterString_volumeunit = value;
    //             RaisePropertyChanged("FilterString_volumeunit");
    //             FilterCollectionvolumeunit();
    //         }
    //     }
    //     private void FilterCollectionvolumeunit()
    //     {
    //         if (_volumeunitCollection != null)
    //         {
    //             _volumeunitCollection.Refresh();
    //         }
    //     }
    //     public bool Filtervolumeunit(object obj)
    //     {
    //         var data = obj as ADM_M038_B_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_volumeunit))
    //             {
    //                 return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_volumeunit.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     //itemcategory
    //     private string _filterString_itemcategory;
    //     public string FilterString_itemcategory
    //     {
    //         get { return _filterString_itemcategory; }
    //         set
    //         {
    //             _filterString_uom = value;
    //             RaisePropertyChanged("_filterString_itemcategory");
    //             FilterCollectionitemcategory();
    //         }
    //     }
    //     private void FilterCollectionitemcategory()
    //     {
    //         if (_itemcategoryCollection != null)
    //         {
    //             _itemcategoryCollection.Refresh();
    //         }
    //     }
    //     public bool Filteritemcategory(object obj)
    //     {
    //         var data = obj as SYS_M003_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_itemcategory))
    //             {
    //                 return (data.sditem_cat_code != null && data.sditem_cat_code.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }



    //     private string _filterString_country;
    //     public string FilterString_country
    //     {
    //         get { return _filterString_country; }
    //         set
    //         {
    //             _filterString_country = value;
    //             RaisePropertyChanged("_filterString_country");
    //             FilterCollectioncountry();
    //         }
    //     }
    //     private void FilterCollectioncountry()
    //     {
    //         if (_countryCollection != null)
    //         {
    //             _countryCollection.Refresh();
    //         }
    //     }
    //     public bool Filtercountry(object obj)
    //     {
    //         var data = obj as ADM_M012_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_country))
    //             {
    //                 return (data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterString_country.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }



    //     //Storage Location
    //     private void FilterCollection_storage_loc_item()
    //     {
    //         if (_storage_locCollection != null)
    //         {
    //             _storage_locCollection.Refresh();
    //         }
    //     }
    //     private string _filterString_storage_loc_item;
    //     public string FilterString_storage_loc_item
    //     {
    //         get { return _filterString_storage_loc_item; }
    //         set
    //         {
    //             _filterString_storage_loc_item = value;
    //             RaisePropertyChanged("FilterString_storage_loc_item");
    //             FilterCollection_storage_loc_item();
    //         }
    //     }
    //     public bool storage_loc_item_Filter(object obj)
    //     {
    //         var data = obj as MM_M001_PopUp;
    //         if (data != null)
    //         {
    //             if (!string.IsNullOrEmpty(_filterString_storage_loc_item))
    //             {
    //                 return (data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_storage_loc_item.ToLower()));
    //             }
    //             return true;
    //         }
    //         return false;
    //     }
    //     #endregion

    //     #region "Parameter"
    //     private void ParameterPopupClosed(IList param)
    //     {

    //         string strData = "";
    //         string strData1 = "";
    //         ADM_M030_P productData = new ADM_M030_P();
    //         ADM_M030_P productData1 = new ADM_M030_P();
    //         IList list = param as IList;
    //         List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();
    //         if (dgPEItems[dgSelectedIndex].description != null)
    //         {
    //             if (Selectedpartylist.Count > 0 && dgPEItems[dgSelectedIndex].description.Contains('\t'))
    //             {
    //                 if (Selectedpartylist[0].Name != null || dgPEItems[dgSelectedIndex].item_id != null)
    //                 {
    //                     try
    //                     {
    //                         if (Selectedpartylist[0].item_id == dgPEItems[dgSelectedIndex].item_id)
    //                         {

    //                             if (param.Count > 0)
    //                             {
    //                                 try
    //                                 {

    //                                     if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
    //                                     {
    //                                         int itemid = Convert.ToInt32(dgPEItems[dgSelectedIndex].item_id);
    //                                         try
    //                                         {
    //                                             for (int e = 0; e < ParamitemList.Count; e++)
    //                                             {
    //                                                 if (itemid == ParamitemList[e].item_id)
    //                                                 {
    //                                                     if (Selectedpartylist[0].Type == ParamitemList[e].Type)
    //                                                     {
    //                                                         ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == dgPEItems[dgSelectedIndex].stocking_unit1)
    //                                                         .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

    //                                                         ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == dgPEItems[dgSelectedIndex].stocking_unit1)
    //                                                       .ToList().ForEach(i => i.code = 1);

    //                                                     }
    //                                                 }
    //                                             }
    //                                         }
    //                                         catch
    //                                         {

    //                                         }
    //                                     }
    //                                     string code = "";
    //                                     foreach (var item in FluteList)
    //                                     {
    //                                         if (item.Name == Selectedpartylist[0].Name && item.Type == Selectedpartylist[0].Type)
    //                                         {
    //                                             strData = strData + " , " + item.Type + ":" + item.Name;
    //                                             strData = strData.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
    //                                             strData1 = strData1 + " , " + item.Type + ":" + item.code;
    //                                             strData1 = strData1.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
    //                                             code = Convert.ToString(item.code);
    //                                         }

    //                                     }
    //                                     string item1 = "";
    //                                     string description = "";
    //                                     try
    //                                     {
    //                                         item1 = dgPEItems[dgSelectedIndex].item_name.ToString();
    //                                         description = dgPEItems[dgSelectedIndex].description.ToString();
    //                                     }
    //                                     catch
    //                                     {

    //                                     }
    //                                     string[] split = new string[50];
    //                                     string test = "";
    //                                     string test1 = "";
    //                                     if (item1.Contains("\t:" + Selectedpartylist[0].Type + ":"))
    //                                     {
    //                                         test = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
    //                                         string y = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
    //                                         string z = item1.Replace(y, "");
    //                                         split = z.Split(':');
    //                                         //test1 = item1.Replace(split[1], Selectedpartylist[0].Name + "\t");
    //                                         test1 = item1.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + Selectedpartylist[0].Name + "\t");

    //                                         strData = test1;
    //                                         if (description.Contains(Selectedpartylist[0].Type))
    //                                         {
    //                                             string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
    //                                             string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
    //                                             string z1 = description.Replace(y1, "");
    //                                             split = z1.Split(':');
    //                                             //string test2 = description.Replace(split[1], code + "\t");
    //                                             string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");
    //                                             try
    //                                             {
    //                                                 {
    //                                                     strData1 = "";
    //                                                     string[] stockvalues = new string[50];
    //                                                     stockvalues = test2.Split('\t');
    //                                                     for (int r = 0; r < stockvalues.Count(); r++)
    //                                                     {
    //                                                         if (stockvalues[r] != "")
    //                                                         {
    //                                                             if (r == 0)
    //                                                             {
    //                                                                 strData1 = stockvalues[0];
    //                                                             }
    //                                                             else
    //                                                             {
    //                                                                 strData1 = strData1 + "\t" + stockvalues[r];
    //                                                             }
    //                                                         }
    //                                                     }

    //                                                 }
    //                                             }
    //                                             catch
    //                                             {

    //                                             }


    //                                         }
    //                                         dgPEItems[dgSelectedIndex].item_name = (strData);
    //                                         dgPEItems[dgSelectedIndex].description = (strData1);
    //                                         //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (strData));
    //                                         //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (strData1));
    //                                     }
    //                                     else
    //                                     {
    //                                         dgPEItems[dgSelectedIndex].item_name = (dgPEItems[dgSelectedIndex].item_name + "\t" + ":" + strData);
    //                                         dgPEItems[dgSelectedIndex].description = (dgPEItems[dgSelectedIndex].description + "\t" + ":" + strData1);

    //                                         //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + ":" + strData));
    //                                         //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (i.description + "\t" + ":" + strData1));
    //                                     }
    //                                 }
    //                                 catch
    //                                 {

    //                                 }
    //                             }
    //                         }
    //                     }
    //                     catch
    //                     {

    //                     }
    //                     try
    //                     {
    //                         if (ValidateControls123() == true)
    //                         {
    //                             StockingUnitCalculation123();
    //                         }

    //                     }
    //                     catch
    //                     {

    //                     }


    //                 }

    //             }
    //         }

    //     }
    //     private bool ValidateControls123()
    //     {
    //         try
    //         {
    //             int i = 0;
    //             int count1 = 0;
    //             string[] values = new string[50];
    //             string description1 = "";
    //             try
    //             {
    //                 //for (int y = 0; y < dgPEItems.Count; y++)
    //                 {
    //                     try
    //                     {
    //                         description1 = dgPEItems[dgSelectedIndex].description.ToString();
    //                         values = description1.Split('\t');
    //                     }
    //                     catch
    //                     {

    //                     }

    //                     try
    //                     {
    //                         int item_id = Convert.ToInt32(dgPEItems[dgSelectedIndex].item_id);
    //                         int subcatcode = Convert.ToInt32(dgPEItems[dgSelectedIndex].SubCategCod);
    //                         var ParameterType = (from o in MC.ParamvalList
    //                                              where o.SubCatCode == subcatcode
    //                                              select o).ToList();

    //                         for (int i1 = 0; i1 < values.Count(); i1++)
    //                         {
    //                             string[] val = values[i1].Split(':');
    //                             try
    //                             {
    //                                 if (i1 != 0)
    //                                 {
    //                                     if (val[2].ToString() != "")
    //                                     {
    //                                         i = 0;
    //                                     }
    //                                     else
    //                                     {
    //                                         i = 1;
    //                                         break;
    //                                     }
    //                                 }
    //                             }
    //                             catch
    //                             {

    //                             }
    //                         }
    //                         //if ((values.Count() - 1) == ParameterType.Count)
    //                         //{
    //                         //    i = 0;

    //                         //}
    //                         //else
    //                         //{
    //                         //    i = 1;
    //                         //    break;
    //                         //}

    //                     }
    //                     catch
    //                     {

    //                     }
    //                 }

    //             }
    //             catch (Exception ex)
    //             {

    //             }

    //             if (i == 0)
    //             {
    //                 return true;
    //             }
    //             else
    //             {
    //                 return false;
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             return true;
    //         }
    //     }
    //     private void StockingUnitCalculation123()
    //     {
    //         string description = "";
    //         int count = 0;

    //         //for (int y = 0; y < dgcatalogItem.Count; y++)
    //         {
    //             try
    //             {
    //                 description = dgPEItems[dgSelectedIndex].description.ToString();

    //             }
    //             catch
    //             {

    //             }
    //             string stockingunit = "";

    //             try
    //             {
    //                 {
    //                     try
    //                     {
    //                         int index = dgPEItems[dgSelectedIndex].ItemcodeStockUnit.IndexOf(':');
    //                         if (index != -1)
    //                         {
    //                             dgPEItems[dgSelectedIndex].ItemcodeStockUnit = dgPEItems[dgSelectedIndex].ItemcodeStockUnit.Substring(0, index - 1);
    //                         }
    //                     }
    //                     catch
    //                     {

    //                     }
    //                     while (description.Contains("\t"))
    //                     {
    //                         try
    //                         {

    //                             string itemcode = description.Substring(0, description.LastIndexOf(":"));
    //                             string itemcode1 = description.Replace(itemcode, "");
    //                             string itemcode2 = itemcode1.Replace(":", "");
    //                             if (count == 0)
    //                             {
    //                                 if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
    //                                 {
    //                                     dgPEItems[dgSelectedIndex].ItemcodeStockUnit = dgPEItems[dgSelectedIndex].ItemcodeStockUnit + ":" + 0;
    //                                 }
    //                                 else
    //                                 {
    //                                     dgPEItems[dgSelectedIndex].ItemcodeStockUnit = dgPEItems[dgSelectedIndex].ItemcodeStockUnit + ":" + itemcode2;
    //                                 }
    //                             }
    //                             else
    //                             {
    //                                 if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
    //                                 {
    //                                     dgPEItems[dgSelectedIndex].ItemcodeStockUnit = dgPEItems[dgSelectedIndex].ItemcodeStockUnit + "/" + 0;
    //                                 }
    //                                 else
    //                                 {
    //                                     dgPEItems[dgSelectedIndex].ItemcodeStockUnit = dgPEItems[dgSelectedIndex].ItemcodeStockUnit + "/" + itemcode2;
    //                                 }
    //                             }



    //                             string itemcode3 = itemcode.Substring(0, description.LastIndexOf("\t"));
    //                             description = itemcode3;
    //                             count++;
    //                         }
    //                         catch
    //                         {
    //                             break;
    //                         }
    //                     }
    //                     string[] stockvalues = new string[50];
    //                     stockvalues = dgPEItems[dgSelectedIndex].ItemcodeStockUnit.Split(':');
    //                     string test = "";
    //                     dgPEItems[dgSelectedIndex].stocking_unit1 = stockvalues[1];
    //                     ParamitemList.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = stockvalues[1]);

    //                 }
    //                 count = 0;
    //             }
    //             catch
    //             {

    //             }


    //         }
    //     }
    //     private void GetSelectedParameter(ADM_M030_P param)
    //     {
    //         string strData = "";
    //         ADM_M030_P productData = new ADM_M030_P();

    //         FluteList = FluteList;
    //         if (param != null)
    //         {
    //             IList list = param as IList;
    //             List<ADM_M030_P> ItemsList = list.Cast<ADM_M030_P>().ToList();

    //             if (ItemsList.Count > 0)
    //             {
    //                 productData = (ADM_M030_P)ItemsList[0];
    //             }
    //         }

    //         foreach (var item in SelectedParmetersFrom)
    //         {

    //         }
    //         dgPEItems.Where(l => l.CatParamName == productData.Type).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + strData));

    //     }

    //     private void CollectionChanged(IList DataList)
    //     {
    //         IList list = DataList as IList;
    //         try
    //         {
    //             List<PUR_T005_B> Selectedpartylist = list.Cast<PUR_T005_B>().ToList();
    //             ParamitemList1 = new ObservableCollection<ADM_M030_P>();
    //             TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.ParamvalList);
    //             if (ParamValuesList.Count == 0)
    //             {
    //                 for (int i = 0; i < TotalParameterCollection.Cast<ADM_M030_P>().ToList().Count(); i++)
    //                 {
    //                     ParamValuesList.Add(TotalParameterCollection.Cast<ADM_M030_P>().ElementAt(i));
    //                 }
    //             }
    //             if (dgPEItems[dgSelectedIndex].id == 0 || dgPEItems[dgSelectedIndex].id == null)
    //             {
    //                 if (dgPEItems.Count > 0)
    //                 {
    //                     {

    //                         {
    //                             if (dgSelectedIndex != -1)
    //                             {
    //                                 try
    //                                 {

    //                                     int item_id = Convert.ToInt32(Selectedpartylist[0].item_id);
    //                                     int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);
    //                                     FluteList = MC.FluteList;
    //                                     var ParameterType = (from o in ParamValuesList
    //                                                          where o.SubCatCode == subcatcode
    //                                                          select o).ToList();

    //                                     var itemlist = (from o in ParamitemList
    //                                                     where o.item_id == item_id && o.count == dgSelectedIndex
    //                                                     select o).ToList();
    //                                     if (itemlist.Count == 0)
    //                                     {

    //                                         for (int r = 0; r < ParameterType.Count; r++)
    //                                         {
    //                                             ParamitemList.Add(new ADM_M030_P() { count = dgSelectedIndex, stockunit = dgPEItems[dgSelectedIndex].stocking_unit1, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });

    //                                         }

    //                                     }
    //                                     try
    //                                     {
    //                                         string Reqstockingunit = "";

    //                                         string[] values1 = dgPEItems[dgSelectedIndex].description.Split('\t');

    //                                         string[] values = Selectedpartylist[0].stockingunit.Split('/');
    //                                         try
    //                                         {

    //                                             for (int y = values.Count() - 1; y >= 0; y--)
    //                                             {
    //                                                 var stockingunit = (from o in FluteList
    //                                                                     where o.code == Convert.ToInt32(values[y].ToString())
    //                                                                     select o).ToList();
    //                                                 {
    //                                                     Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
    //                                                 }


    //                                             }
    //                                             dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (""));
    //                                             dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (values1[0] + Reqstockingunit));

    //                                         }
    //                                         catch
    //                                         {

    //                                         }
    //                                         int count = values.Length;
    //                                         for (int r = 0; r < count; r++)
    //                                         {
    //                                             var ParameterCollectionMethod = (from o in FluteList
    //                                                                              where o.code == Convert.ToInt32(values[r].ToString())
    //                                                                              select o).ToList();
    //                                             var Parameter = (from o in ParamitemList
    //                                                              where o.Type == (ParameterCollectionMethod[0].Type)
    //                                                              select o).ToList();


    //                                             if (Parameter[0].code == 0)
    //                                             {
    //                                                 if (dgPEItems[dgSelectedIndex].stocking_unit1 == "" || dgPEItems[dgSelectedIndex].stocking_unit1 == null)
    //                                                 {
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = "");
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = "");
    //                                                 }
    //                                                 else
    //                                                 {
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = dgPEItems[dgSelectedIndex].stocking_unit1);
    //                                                 }
    //                                             }
    //                                             else
    //                                             {
    //                                                 if (dgPEItems[dgSelectedIndex].stocking_unit1 == "" || dgPEItems[dgSelectedIndex].stocking_unit1 == null)
    //                                                 {
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = "");
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = "");
    //                                                 }
    //                                                 else
    //                                                 {
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = Parameter[0].Name);
    //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = dgPEItems[dgSelectedIndex].stocking_unit1);
    //                                                 }
    //                                             }
    //                                         }
    //                                     }
    //                                     catch
    //                                     {

    //                                     }
    //                                     ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
    //                                     for (int r = 0; r < ParamitemList.Count; r++)
    //                                     {
    //                                         if (ParamitemList[r].item_id == item_id && ParamitemList[r].count == dgSelectedIndex)
    //                                         {
    //                                             ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
    //                                             ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
    //                                         }
    //                                     }

    //                                     if (dgPEItems[dgSelectedIndex].description == null || dgPEItems[dgSelectedIndex].description == "")
    //                                     {
    //                                         //17Jan
    //                                         MC_temp.itemList = ItemCollection.Cast<MM_T001_A_PopUp_PUR>().ToList();
    //                                         string tnm = (from data in MC_temp.itemList where data.item_id == dgPEItems[dgSelectedIndex].item_id select data.ItemName).ToList()[0].ToString();
    //                                         //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = "");
    //                                         //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = "");
    //                                         dgPEItems[dgSelectedIndex].item_name = "";
    //                                         dgPEItems[dgSelectedIndex].description = "";
    //                                         //-17Jan
    //                                         for (int y = 0; y < ParamitemList1.Count; y++)
    //                                         {
    //                                             if (y == 0)
    //                                             {
    //                                                 //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = tnm +"\t" + ":" + ParamitemList1[y].Type + ":");
    //                                                 //dgPEItems.Where(l => l.item_id == dgPEItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = tnm +"\t" + ":" + ParamitemList1[y].Type + ":");
    //                                                 dgPEItems[dgSelectedIndex].item_name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
    //                                                 dgPEItems[dgSelectedIndex].description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";

    //                                             }
    //                                             else
    //                                             {
    //                                                 dgPEItems[dgSelectedIndex].item_name = dgPEItems[dgSelectedIndex].item_name + "\t" + ":" + ParamitemList1[y].Type + ":";
    //                                                 dgPEItems[dgSelectedIndex].description = dgPEItems[dgSelectedIndex].description + "\t" + ":" + ParamitemList1[y].Type + ":";
    //                                             }
    //                                         }
    //                                     }
    //                                     else
    //                                     {

    //                                     }
    //                                 }
    //                                 catch
    //                                 {

    //                                 }

    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //             else if (dgPEItems[dgSelectedIndex].id != 0 || dgPEItems[dgSelectedIndex].id != null)
    //             {

    //                 if (dgSelectedIndex != -1)
    //                 {
    //                     try
    //                     {
    //                         int item_id = Convert.ToInt32(Selectedpartylist[0].item_id);
    //                         int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);
    //                         FluteList = MC.FluteList;
    //                         var ParameterType = (from o in ParamValuesList
    //                                              where o.SubCatCode == subcatcode
    //                                              select o).ToList();
    //                         var itemlist = (from o in ParamitemList
    //                                         where o.item_id == item_id && o.stockunit == dgPEItems[dgSelectedIndex].stockingunit
    //                                         select o).ToList();
    //                         if (itemlist.Count == 0)
    //                         {
    //                             {
    //                                 for (int r = 0; r < ParameterType.Count; r++)
    //                                 {
    //                                     ParamitemList.Add(new ADM_M030_P() { stockunit = dgPEItems[dgSelectedIndex].stockingunit, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
    //                                 }
    //                             }
    //                         }
    //                         try
    //                         {
    //                             string[] values = Selectedpartylist[0].stockingunit.Split('/');
    //                             int count = values.Length;
    //                             for (int r = 0; r < count; r++)
    //                             {
    //                                 var ParameterCollectionMethod = (from o in FluteList
    //                                                                  where o.code == Convert.ToInt32(values[r].ToString())
    //                                                                  select o).ToList();
    //                                 var Parameter = (from o in ParamitemList
    //                                                  where o.Type == (ParameterCollectionMethod[0].Type) && o.stockunit == dgPEItems[dgSelectedIndex].stockingunit
    //                                                  select o).ToList();
    //                                 if (Parameter[0].code == 0)
    //                                 {
    //                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.stockunit == dgPEItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
    //                                 }
    //                                 else
    //                                 {
    //                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.stockunit == dgPEItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.Name = Parameter[0].Name);
    //                                 }
    //                             }
    //                         }
    //                         catch
    //                         {

    //                         }
    //                         ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
    //                         for (int r = 0; r < ParamitemList.Count; r++)
    //                         {
    //                             if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == dgPEItems[dgSelectedIndex].stockingunit)
    //                             {
    //                                 ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
    //                                 ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
    //                             }
    //                         }

    //                     }
    //                     catch
    //                     { }
    //                 }
    //             }
    //         }
    //         catch
    //         {

    //         }

    //     }

    //     // This Function after save method for collecting parameter collection values
    //     private void Update()
    //     {
    //         if (blNew == false)
    //         {

    //             string taxvalue = "";
    //             try
    //             {
    //                 for (int u = 0; u < MC.PEtaxDetails.Count; u++)
    //                 {
    //                     var ParameterType = (from o in MC.PEtaxDetails
    //                                          where o.line_id == MC.PEtaxDetails[u].line_id
    //                                          select o).ToList();

    //                     for (int y = 0; y < ParameterType.Count; y++)
    //                     {
    //                         if (y == 0)
    //                         {
    //                             taxvalue = Convert.ToString(ParameterType[y].tax_amount);
    //                         }
    //                         else
    //                         {
    //                             taxvalue = taxvalue + "," + Convert.ToString(ParameterType[y].tax_amount);
    //                         }
    //                     }

    //                     //dgPEItems.Where(l => l.item_id == MC.PEtaxDetails[u].item_id).Where(l => l.stocking_unit1 == MC.PEtaxDetails[u].stocking_unit1).ToList().ForEach(i => i.taxamount = (taxvalue));
    //                     u = u + ParameterType.Count - 1;
    //                     taxvalue = "";
    //                 }

    //             }
    //             catch
    //             {

    //             }



    //         }

    //         string parametervale = "";
    //         string parametercode = "";
    //         for (int y = 0; y < dgPEItems.Count; y++)
    //         {

    //             try
    //             {
    //                 parametervale = "";
    //                 parametercode = "";
    //                 string stockingunit = dgPEItems[y].stockingunit;
    //                 string[] tokens = stockingunit.Split('/');
    //                 int count = tokens.Length;
    //                 while (count > 0)
    //                 {
    //                     string value = tokens[count - 1];
    //                     if (value != "")
    //                     {
    //                         var myItem = (from o in MC.FluteList
    //                                       where o.code == Convert.ToInt32(value)
    //                                       select o).ToList();
    //                         if (parametervale == "")
    //                         {
    //                             parametervale = myItem[0].Type + ":" + myItem[0].Name;
    //                             parametercode = myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
    //                         }
    //                         else
    //                         {
    //                             parametervale = parametervale + "\t:" + myItem[0].Type + ":" + myItem[0].Name;
    //                             parametercode = parametercode + "\t:" + myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
    //                         }
    //                     }
    //                     count = count - 1;
    //                 }
    //                 //dgPEItems.Where(l => l.item_id == dgPEItems[y].item_id).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + parametervale));
    //                 dgPEItems.Where(l => l.item_id == dgPEItems[y].item_id).Where(l => l.stockingunit == dgPEItems[y].stockingunit).ToList().ForEach(i => i.description = (i.item_code + "\t:" + parametercode));
    //                 try
    //                 {
    //                     for (int u = 0; u < ParamitemList.Count; u++)
    //                     {
    //                         ParamitemList[u].code = 0;
    //                     }

    //                 }
    //                 catch
    //                 {

    //                 }
    //             }
    //             catch
    //             {

    //             }
    //         }

    //         decimal total_amt2 = 0;
    //         decimal basic_amount1 = 0;

    //         try
    //         {
    //             decimal amount_taxed = 0;
    //             for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
    //             {
    //                 amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
    //             }
    //             for (int i = 0; i < dgPEItems.Count; i++)
    //             {
    //                 dgPEItems[i].amount = ((dgPEItems[i].qty * dgPEItems[i].unit_price));
    //                 SelectedPUR_T005_A.untaxedamount = dgPEItems.Sum(t => t.amount);
    //             }
    //             decimal rounding = 0;
    //             SelectedPUR_T005_A.tax_amount = amount_taxed;
    //             SelectedPUR_T005_A.totalamount = amount_taxed + SelectedPUR_T005_A.untaxedamount;
    //             rounding = Convert.ToDecimal(SelectedPUR_T005_A.totalamount);
    //             SelectedPUR_T005_A.totalamount = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
    //         }
    //         catch
    //         {

    //         }


    //     }
    //     #endregion

    //     #region "Schedule"
    //     private void ScheduleCellChanged(IList DataList)
    //     {

    //         IList list = DataList as IList;

    //         try
    //         {
    //             List<PUR_T004_B> Selectedpartylist = list.Cast<PUR_T004_B>().ToList();
    //             decimal qty = 0;

    //             int x2 = dgPOdeliveryschedule.IndexOf(dgPOdeliveryschedule.Where(X => X.item_id == Selectedpartylist[0].item_id).Where(X => X.stockingunit == Selectedpartylist[0].stockingunit).FirstOrDefault());

    //             if (dgPOdeliveryschedule.Count > 0)
    //             {
    //                 //for (int y = 0; y < dgPOdeliveryschedule.Count; y++)
    //                 {
    //                     if (Selectedpartylist[0].item_id == dgPOdeliveryschedule[x2].item_id && Selectedpartylist[0].stockingunit == dgPOdeliveryschedule[x2].stockingunit)
    //                     {
    //                         if (Selectedpartylist[0].poqty > dgPOdeliveryschedule[x2].qty)
    //                         {
    //                             qty = Convert.ToDecimal(Selectedpartylist[0].poqty - dgPOdeliveryschedule[x2].qty);
    //                         }
    //                         else
    //                         {
    //                             qty = Convert.ToDecimal(dgPOdeliveryschedule[x2].qty - Selectedpartylist[0].poqty);
    //                         }

    //                     }
    //                     else
    //                     {
    //                         qty = Convert.ToDecimal(Selectedpartylist[0].qty);

    //                     }


    //                     if (qty > dgPOdeliveryschedule[x2].poqty)
    //                     {
    //                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
    //                         showMessageService.ButtonSetup = DialogButton.Ok;
    //                         showMessageService.Caption = "Message";
    //                         showMessageService.Text = String.Format("Schedule Quantity Is Greater than PO Quantity", this.Title);
    //                         showMessageService.ShowMessage();
    //                         if (dgPOdeliveryschedule[x2].poqty < qty)
    //                         {
    //                             dgPOdeliveryschedule[x2].qty = dgPOdeliveryschedule[x2].poqty;
    //                         }

    //                         dgPOschedule[x2].ScheduleSelect = true;
    //                     }
    //                     else
    //                     {
    //                         if (Selectedpartylist[0].item_id == dgPOdeliveryschedule[x2].item_id && Selectedpartylist[0].stockingunit == dgPOdeliveryschedule[x2].stockingunit)
    //                         {
    //                             var ParameterType = (from o in dgPOdeliveryschedule
    //                                                  where o.item_id == Selectedpartylist[0].item_id && o.stockingunit == Selectedpartylist[0].stockingunit
    //                                                  select o).ToList();

    //                             dgPOschedule.Where(l => l.item_id == ParameterType[0].item_id).Where(l => l.stockingunit == ParameterType[0].stockingunit).ToList().ForEach(i => i.ScheduleSelect = false);

    //                         }

    //                     }
    //                 }

    //             }
    //         }
    //         catch
    //         {

    //         }
    //         //scheduleCollection = CollectionViewSource.GetDefaultView(dgPOdeliveryschedule);

    //     }



    //     #endregion "Schedule"

    //     #region "Tax Calculation"


    //     private void check(bool select)
    //     {
    //         //TaxRowCalculation();

    //     }
    //     //private void TaxCalculationChanged(object select)
    //     //{
    //     //    try
    //     //    {
    //     //        string tempTax = dgPEItems[dgSelectedIndex].tax_id;
    //     //        SelectedItems = GetDict(tempTax);
    //     //    }
    //     //    catch
    //     //    {

    //     //    }
    //     //    //TaxRowCalculation();
    //     //}
    //     //private void TaxEdit(IList DataList)
    //     //{

    //     //    IList list = DataList as IList;
    //     //    List<ACC_T006_C> Selectedpartylist = list.Cast<ACC_T006_C>().ToList();
    //     //    try
    //     //    {
    //     //        if (Selectedpartylist[0].description != null)
    //     //        {
    //     //            dgPOTotalTaxValues.Where(l => l.description == Selectedpartylist[0].description).ToList().ForEach(i => i.tax_id = 0);
    //     //            dgPOTotalTaxValues.Where(l => l.description == Selectedpartylist[0].description).ToList().ForEach(i => i.base_amount = 0);
    //     //            dgPOTotalTaxValues.Where(l => l.description == Selectedpartylist[0].description).ToList().ForEach(i => i.tax_amount = Selectedpartylist[0].tax_amount);

    //     //        }
    //     //        try
    //     //        {
    //     //            TaxDeletedValuesTableCalculation();
    //     //        }
    //     //        catch
    //     //        {

    //     //        }

    //     //    }
    //     //    catch
    //     //    {

    //     //    }


    //     //}
    //     //private void TaxCellChanged(IList DataList)
    //     //{
    //     //    IList list = DataList as IList;
    //     //    List<ACC_M013_P> Selectedpartylist = list.Cast<ACC_M013_P>().ToList();
    //     //    try
    //     //    {
    //     //        dgPOTotalTaxValues[dgSelectedIndex1].accountcollectdid = Selectedpartylist[0].accountcollectdid;
    //     //        dgPOTotalTaxValues[dgSelectedIndex1].taxaccount = Selectedpartylist[0].taxaccount;

    //     //    }
    //     //    catch
    //     //    {

    //     //    }

    //     //}
    //     //private void TableTaxEdit(IList DataList)
    //     //{

    //     //    IList list = DataList as IList;
    //     //    List<ACC_M013_PopUp> Selectedpartylist = list.Cast<ACC_M013_PopUp>().ToList();
    //     //    try
    //     //    {
    //     //        var q = dgPOTotalTaxValues.Where(X => X.tax_id == Selectedpartylist[0].id).FirstOrDefault();
    //     //        int x = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.tax_id == Selectedpartylist[0].id).FirstOrDefault());
    //     //        if ((q == null) && Selectedpartylist[0].SelectTax == true && dgPOTotalTaxValues.Count == dgSelectedIndex1)
    //     //        {
    //     //            dgPOTotalTaxValues.Insert(dgSelectedIndex1, new ACC_T006_C()
    //     //            {
    //     //                item_id = 0,
    //     //                id = 0,
    //     //                line_id = 0,
    //     //                tax_amount = 0,
    //     //                base_amount = 0,
    //     //                tax_id = Selectedpartylist[0].id,
    //     //                description = Selectedpartylist[0].description

    //     //            }
    //     //        );

    //     //        }
    //     //        else if (Selectedpartylist[0].SelectTax == false && q != null)
    //     //        {
    //     //            if (x >= 0)
    //     //            {
    //     //                dgPOTotalTaxValues.RemoveAt(x);

    //     //            }
    //     //        }

    //     //    }
    //     //    catch
    //     //    {

    //     //    }

    //     //}



    //     private void TaxDeletedValuesTableCalculation()
    //     {
    //         if (dgPOTotalTaxValues.Count > 0)
    //         {
    //             decimal amount_taxed = 0;
    //             for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
    //             {
    //                 amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
    //             }
    //             for (int i = 0; i < dgPEItems.Count; i++)
    //             {
    //                 //SelectedPUR_T005_A.amount_untaxed = dgPEItems.Sum(t => t.amount);
    //             }
    //             //SelectedPUR_T005_A.amount_tax = amount_taxed;
    //             //SelectedPUR_T005_A.amount_total = amount_taxed + SelectedPUR_T005_A.amount_untaxed;
    //             try
    //             {
    //                 //decimal rounding = Convert.ToDecimal(SelectedPUR_T005_A.amount_total);
    //                 //SelectedPUR_T005_A.amount_total = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
    //             }
    //             catch
    //             {

    //             }
    //             try
    //             {
    //                 //double amount = Convert.ToDouble(SelectedPUR_T005_A.amount_total);
    //                 //SelectedPUR_T005_A.amt_in_words = num.AmountInWords(Convert.ToDecimal(amount));
    //             }
    //             catch
    //             {

    //             }
    //         }

    //     }
    //     // We dont have taxamount field in database so after save all calculation done here //
    //     //private void TaxTableCalculation()
    //     //{

    //     //    List<PUR_T005_B> SelectedItemsDetailsTemp = new List<PUR_T005_B>();
    //     //    dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //     //    dgPOTaxValues = new ObservableCollection<ACC_T006_C>();
    //     //    dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //     //    dgPOTaxValues1 = new ObservableCollection<ACC_T006_C>();

    //     //    for (int s = 0; s <= dgPEItems.Count - 1; s++)
    //     //    {
    //     //        if (dgPEItems[s].unit_price != 0 && dgPEItems[s].qty != 0)
    //     //        {

    //     //            string a = dgPEItems[s].tax_id;
    //     //            int length = 0;
    //     //            int count = 0;
    //     //            string b = "";

    //     //            var __list = new List<ACC_T006_C>();
    //     //            if (a != null)
    //     //            {
    //     //                length = a.Length;
    //     //            }
    //     //            try
    //     //            {

    //     //                string taxval = dgPEItems[s].tax_id;
    //     //                int taxvalcount = -1;
    //     //                double taxupdatvalues;
    //     //                double parenttaxvalues = 0;
    //     //                int z = s;
    //     //                while (length != 0)
    //     //                {
    //     //                    if (a.Contains(","))
    //     //                    {

    //     //                        a = a.Substring(0, dgPEItems[s].tax_id.IndexOf(","));
    //     //                    }

    //     //                    var myItem = (from o in SelectedChildTaxList
    //     //                                  where o.id == Convert.ToInt32(a)
    //     //                                  select o).ToList();

    //     //                    if (myItem[0].t_type.ToString() == "Percentage" && myItem[0].child_depend == false)
    //     //                    {
    //     //                        taxupdatvalues = Convert.ToDouble(((dgPEItems[s].amount) * myItem[0].amount) / 100);
    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal(Convert.ToString(Math.Round(taxupdatvalues, 2))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //     //                    }
    //     //                    else if (myItem[0].t_type == "Percentage" && myItem[0].child_depend == true)
    //     //                    {
    //     //                        var parentdetails = (from o in SelectedChildTaxList
    //     //                                             where o.id == myItem[0].parent_id
    //     //                                             select o).ToList();
    //     //                        var parentdetailstaxamt = (from o in dgPOTaxValues
    //     //                                                   where o.tax_id == parentdetails[0].id
    //     //                                                   select o).ToList();

    //     //                        var parentdetailstaxamt1 = (from o in dgPOTaxValues
    //     //                                                    where o.item_id == dgPEItems[s].item_id
    //     //                                                    select o).ToList();


    //     //                        if (parentdetailstaxamt.Count > 0 && parentdetailstaxamt1.Count == 0)
    //     //                        {
    //     //                            parenttaxvalues = Convert.ToDouble(((dgPEItems[s].amount) * parentdetails[0].amount) / 100);
    //     //                            taxupdatvalues = parenttaxvalues;
    //     //                            dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
    //     //                            dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
    //     //                        }
    //     //                        else if (parentdetailstaxamt1.Count == 0)
    //     //                        {
    //     //                            decimal amt = parentdetails[0].amount;
    //     //                            parenttaxvalues = Convert.ToDouble(((dgPEItems[s].amount) * amt) / 100);
    //     //                            taxupdatvalues = parenttaxvalues;
    //     //                            dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails[0].id, description = parentdetails[0].description });
    //     //                            dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails[0].id, description = parentdetails[0].description });


    //     //                        }

    //     //                        if (parentdetailstaxamt1.Count > 0)
    //     //                        {
    //     //                            taxupdatvalues = (Convert.ToDouble(parentdetailstaxamt1[0].tax_amount) * Convert.ToDouble(parentdetails[0].amount)) / 100;
    //     //                            dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                            dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        }
    //     //                        else if (parentdetailstaxamt1.Count == 0)
    //     //                        {
    //     //                            taxupdatvalues = (parenttaxvalues * Convert.ToDouble(parentdetails[0].amount)) / 100;
    //     //                            dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                            dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //     //                        }


    //     //                    }



    //     //                    var parentdetails123 = (from o in SelectedChildTaxList
    //     //                                            where o.parent_id == myItem[0].id
    //     //                                            select o).ToList();

    //     //                    if (myItem[0].t_type == "Percentage" && parentdetails123.Count > 0)
    //     //                    {

    //     //                        parenttaxvalues = Convert.ToDouble(((dgPEItems[s].amount) * myItem[0].amount) / 100);
    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });


    //     //                        for (int r = 0; r < parentdetails123.Count; r++)
    //     //                        {
    //     //                            if (parentdetails123[r].t_type == "Percentage")
    //     //                            {
    //     //                                taxupdatvalues = (Convert.ToDouble(parentdetails123[r].amount) * Convert.ToDouble(parenttaxvalues)) / 100;
    //     //                                dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
    //     //                                dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
    //     //                            }
    //     //                        }



    //     //                    }

    //     //                    else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == true)
    //     //                    {
    //     //                        var parentdetails = (from o in dgPOTaxValues
    //     //                                             where o.tax_id == myItem[0].parent_id
    //     //                                             select o).ToList();

    //     //                        var parentdetails1 = (from o in SelectedChildTaxList
    //     //                                              where o.id == myItem[0].parent_id
    //     //                                              select o).ToList();


    //     //                        if (parentdetails.Count > 0)
    //     //                        {
    //     //                            taxupdatvalues = (Convert.ToDouble(myItem[0].amount) * Convert.ToDouble(parentdetails[0].base_amount)) / 100;
    //     //                        }
    //     //                        else
    //     //                        {
    //     //                            decimal amt = parentdetails1[0].amount;
    //     //                            taxupdatvalues = Convert.ToDouble(amt);
    //     //                            dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
    //     //                            dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
    //     //                        }

    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                    }
    //     //                    else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == false)
    //     //                    {

    //     //                        taxupdatvalues = Convert.ToDouble(myItem[0].amount);

    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                    }
    //     //                    else if (myItem[0].Price_include == true)
    //     //                    {
    //     //                        double formula = 0;
    //     //                        double formulavalues = 0;
    //     //                        taxupdatvalues = Convert.ToDouble(myItem[0].amount);
    //     //                        formula = (Convert.ToDouble(dgPEItems[dgSelectedIndex].amount) / (Convert.ToDouble(taxupdatvalues / 100) + 1));
    //     //                        formulavalues = Convert.ToDouble(formula * Convert.ToDouble(taxupdatvalues / 100));
    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPEItems.Where(l => l.item_id == dgPEItems[s].item_id).ToList().ForEach(i => i.amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))));
    //     //                    }
    //     //                    else if (myItem[0].include_base_amount == true)
    //     //                    {
    //     //                        double vatcalculate = 0;
    //     //                        double vatsum = 0;

    //     //                        var BaseAmount = (from data in dgPOTaxValues3
    //     //                                          where (data.item_id == dgPEItems[dgSelectedIndex].item_id
    //     //                                              && data.stocking_unit1 == dgPEItems[dgSelectedIndex].stocking_unit1)
    //     //                                          select data.tax_amount).Sum();

    //     //                        taxupdatvalues = Convert.ToDouble(myItem[0].amount);
    //     //                        vatsum = ((Convert.ToDouble(dgPEItems[dgSelectedIndex].amount)) + (Convert.ToDouble(BaseAmount)));
    //     //                        vatcalculate = (vatsum * taxupdatvalues) / 100;

    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[dgSelectedIndex].item_id, id = 0, line_id = dgPEItems[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[dgSelectedIndex].item_id, id = 0, line_id = dgPEItems[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //     //                    }
    //     //                    //else if (myItem[0].Price_include == false)
    //     //                    //{
    //     //                    //    try
    //     //                    //    {
    //     //                    //        decimal vatcst = 0;
    //     //                    //        {
    //     //                    //            var BasicExcise = (from data in dgPOTaxValues3 where data.description == "Basic Excise Duty" select data.tax_amount).Sum();
    //     //                    //            var cess = (from data in dgPOTaxValues3 where data.description == "Education CEss" select data.tax_amount).Sum();
    //     //                    //            var hcess = (from data in dgPOTaxValues3 where data.description == "Secondary Higher Edu. Cess" select data.tax_amount).Sum();
    //     //                    //            vatcst = Convert.ToDecimal(BasicExcise + cess + hcess);
    //     //                    //            parenttaxvalues = Convert.ToDouble(((SelectedPUR_T005_A.amount_untaxed + vatcst) * myItem[0].amount) / 100);
    //     //                    //            dgPOTaxValues.Add(new ACC_T006_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T005_A.amount_untaxed + SelectedPUR_T005_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                    //            dgPOTaxValues3.Add(new ACC_T006_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T005_A.amount_untaxed + SelectedPUR_T005_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //     //                    //        }
    //     //                    //    }
    //     //                    //    catch
    //     //                    //    {

    //     //                    //    }

    //     //                    //}

    //     //                    else
    //     //                    {

    //     //                        taxupdatvalues = Convert.ToDouble(((dgPEItems[s].amount) * myItem[0].amount) / 100);
    //     //                        dgPOTaxValues.Add(new ACC_T006_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                        dgPOTaxValues3.Add(new ACC_T006_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //     //                    }

    //     //                    if (b == "")
    //     //                    {
    //     //                        b = b + a;
    //     //                    }
    //     //                    else
    //     //                    {
    //     //                        b = b + ',' + a;
    //     //                    }
    //     //                    if (b.ToString() != dgPEItems[s].tax_code.ToString())
    //     //                    {
    //     //                        a = dgPEItems[s].tax_code.Replace(b + ',', "");
    //     //                    }
    //     //                    else
    //     //                    {
    //     //                        a = dgPEItems[s].tax_code.Replace(b, "");
    //     //                    }


    //     //                    length = a.Length;

    //     //                }


    //     //            }
    //     //            catch
    //     //            {

    //     //            }
    //     //        }

    //     //    }
    //     //}

    //     //RowWise Calculation//
    //     //private void TaxRowCalculation()
    //     //{
    //     //    List<PUR_T005_B> SelectedItemsDetailsTemp = new List<PUR_T005_B>();

    //     //            decimal total_amt1 = 0;
    //     //            decimal basic_amount = 0;

    //     //            for (int m = dgPOTaxValues3.Count - 1; m >= 0; m--)
    //     //            {

    //     //                var totaltaxvalue1 = (from o in dgPOTaxValues3
    //     //                                      where o.tax_id == dgPOTaxValues3[m].tax_id
    //     //                                      select o).ToList();

    //     //                for (int q = dgPOTaxValues3.Count; q >= 0; q--)
    //     //                {
    //     //                    try
    //     //                    {
    //     //                        int x7 = dgPOTaxValues3.IndexOf(dgPOTaxValues3.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
    //     //                        if (x7 != null)
    //     //                        {
    //     //                            dgPOTaxValues3.RemoveAt(x7);
    //     //                            m = dgPOTaxValues3.Count;
    //     //                        }
    //     //                    }
    //     //                    catch
    //     //                    {

    //     //                    }
    //     //                }


    //     //                for (int y = 0; y < totaltaxvalue1.Count; y++)
    //     //                {
    //     //                    total_amt1 = total_amt1 + Convert.ToDecimal(totaltaxvalue1[y].tax_amount);
    //     //                    basic_amount = basic_amount + Convert.ToDecimal(totaltaxvalue1[y].base_amount);
    //     //                }

    //     //                for (int r = dgPOTotalTaxValues.Count; r > 0; r--)
    //     //                {

    //     //                    int x2 = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
    //     //                    if (x2 != null)
    //     //                    {

    //     //                        try
    //     //                        {
    //     //                            dgPOTotalTaxValues.RemoveAt(x2);
    //     //                        }
    //     //                        catch
    //     //                        {

    //     //                        }

    //     //                    }
    //     //                }
    //     //                //if (dgSelectedIndex != -1)
    //     //                {
    //     //                    dgPOTotalTaxValues.Add(new ACC_T006_C()
    //     //                    {
    //     //                        item_id = totaltaxvalue1[0].item_id,
    //     //                        id = 0,
    //     //                        line_id =0,
    //     //                        tax_amount = total_amt1,
    //     //                        base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(basic_amount, 2)))),
    //     //                        tax_id = totaltaxvalue1[0].tax_id,
    //     //                        description = totaltaxvalue1[0].description,
    //     //                        taxaccount = totaltaxvalue1[0].taxaccount,
    //     //                        accountcollectdid = totaltaxvalue1[0].accountcollectdid,
    //     //                        stocking_unit1 = totaltaxvalue1[0].stocking_unit1,


    //     //                    });
    //     //                }

    //     //                total_amt1 = 0;
    //     //                basic_amount = 0;

    //     //            }


    //     //        decimal amount_taxed = 0;
    //     //        for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
    //     //        {
    //     //            amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
    //     //        }
    //     //        for (int i = 0; i < dgPEItems.Count; i++)
    //     //        {
    //     //            dgPEItems[i].amount = ((dgPEItems[i].qty * dgPEItems[i].unit_price));
    //     //            SelectedPUR_T005_A.untaxedamount = dgPEItems.Sum(t => t.amount);
    //     //        }
    //     //        SelectedPUR_T005_A.tax_amount = amount_taxed;
    //     //        SelectedPUR_T005_A.totalamount = amount_taxed + SelectedPUR_T005_A.untaxedamount;
    //     //        try
    //     //        {
    //     //            decimal rounding = Convert.ToDecimal(SelectedPUR_T005_A.totalamount);
    //     //            SelectedPUR_T005_A.totalamount = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
    //     //        }
    //     //        catch
    //     //        {

    //     //        }
    //     //        try
    //     //        {
    //     //            double amount = Convert.ToDouble(SelectedPUR_T005_A.totalamount);
    //     //            SelectedPUR_T005_A.amtinword = num.AmountInWords(Convert.ToDecimal(amount));
    //     //        }
    //     //        catch
    //     //        {

    //     //        }
    //     //    }


    //     private void TaxRowCalculation()
    //     {
    //         List<PUR_T005_B> SelectedItemsDetailsTemp = new List<PUR_T005_B>();
    //         dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues3 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTaxValues1 = new ObservableCollection<ACC_T006_C>();
    //         dgPOTotalTaxValues = new ObservableCollection<ACC_T006_C>();
    //         for (int s = 0; s <= dgPEItems.Count - 1; s++)
    //         {
    //             if (dgPEItems[s].unit_price != 0 && dgPEItems[s].qty != 0)
    //             {
    //                 if (dgPEItems[s].active == true)
    //                 {
    //                     string a = dgPEItems[s].tax_code;
    //                     int length = 0;
    //                     int count = 0;
    //                     string b = "";

    //                     var __list = new List<ACC_T006_C>();
    //                     if (a != null)
    //                     {
    //                         length = a.Length;
    //                     }
    //                     try
    //                     {

    //                         string taxval = dgPEItems[s].tax_code;
    //                         int taxvalcount = -1;
    //                         double taxupdatvalues;
    //                         double parenttaxvalues = 0;
    //                         int z = s;
    //                         string[] split = new string[25];
    //                         split = dgPEItems[s].tax_code.Split(',');
    //                         for (int y = 0; y < split.Count(); y++)
    //                         //while (length != 0)
    //                         {
    //                             //if (a.Contains(","))
    //                             //{

    //                             a = split[y];
    //                             //}

    //                             var myItem = (from o in SelectedChildTaxList
    //                                           where o.id == Convert.ToInt32(a)
    //                                           select o).ToList();

    //                             if (myItem[0].t_type.ToString() == "Percentage" && myItem[0].child_depend == false)
    //                             {
    //                                 taxupdatvalues = Convert.ToDouble(((dgPEItems[s].amount) * myItem[0].amount) / 100);
    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal(Convert.ToString(Math.Round(taxupdatvalues, 2))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //                             }
    //                             else if (myItem[0].t_type == "Percentage" && myItem[0].child_depend == true)
    //                             {
    //                                 var parentdetails = (from o in SelectedChildTaxList
    //                                                      where o.id == myItem[0].parent_id
    //                                                      select o).ToList();
    //                                 var parentdetailstaxamt = (from o in dgPOTaxValues
    //                                                            where o.tax_id == parentdetails[0].id
    //                                                            select o).ToList();

    //                                 var parentdetailstaxamt1 = (from o in dgPOTaxValues
    //                                                             where o.item_id == dgPEItems[s].item_code
    //                                                             select o).ToList();


    //                                 if (parentdetailstaxamt.Count > 0 && parentdetailstaxamt1.Count == 0)
    //                                 {
    //                                     parenttaxvalues = Convert.ToDouble(((dgPEItems[s].amount) * parentdetails[0].amount) / 100);
    //                                     taxupdatvalues = parenttaxvalues;
    //                                     dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
    //                                     dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
    //                                 }
    //                                 else if (parentdetailstaxamt1.Count == 0)
    //                                 {
    //                                     decimal amt = parentdetails[0].amount;
    //                                     parenttaxvalues = Convert.ToDouble(((dgPEItems[s].amount) * amt) / 100);
    //                                     taxupdatvalues = parenttaxvalues;
    //                                     dgPOTaxValues.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = "", id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails[0].id, description = parentdetails[0].description });
    //                                     dgPOTaxValues3.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = "", id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails[0].id, description = parentdetails[0].description });


    //                                 }

    //                                 if (parentdetailstaxamt1.Count > 0)
    //                                 {
    //                                     taxupdatvalues = (Convert.ToDouble(parentdetailstaxamt1[0].tax_amount) * Convert.ToDouble(parentdetails[0].amount)) / 100;
    //                                     dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                     dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 }
    //                                 else if (parentdetailstaxamt1.Count == 0)
    //                                 {
    //                                     taxupdatvalues = (parenttaxvalues * Convert.ToDouble(parentdetails[0].amount)) / 100;
    //                                     dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                     dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //                                 }


    //                             }



    //                             var parentdetails123 = (from o in SelectedChildTaxList
    //                                                     where o.parent_id == myItem[0].id
    //                                                     select o).ToList();

    //                             if (myItem[0].t_type == "Percentage" && parentdetails123.Count > 0)
    //                             {

    //                                 parenttaxvalues = Convert.ToDouble(((dgPEItems[s].amount) * myItem[0].amount) / 100);
    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });


    //                                 for (int r = 0; r < parentdetails123.Count; r++)
    //                                 {
    //                                     if (parentdetails123[r].t_type == "Percentage")
    //                                     {
    //                                         taxupdatvalues = (Convert.ToDouble(parentdetails123[r].amount) * Convert.ToDouble(parenttaxvalues)) / 100;
    //                                         dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
    //                                         dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
    //                                     }
    //                                 }



    //                             }

    //                             else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == true)
    //                             {
    //                                 var parentdetails = (from o in dgPOTaxValues
    //                                                      where o.tax_id == myItem[0].parent_id
    //                                                      select o).ToList();

    //                                 var parentdetails1 = (from o in SelectedChildTaxList
    //                                                       where o.id == myItem[0].parent_id
    //                                                       select o).ToList();


    //                                 if (parentdetails.Count > 0)
    //                                 {
    //                                     taxupdatvalues = (Convert.ToDouble(myItem[0].amount) * Convert.ToDouble(parentdetails[0].base_amount)) / 100;
    //                                 }
    //                                 else
    //                                 {
    //                                     decimal amt = parentdetails1[0].amount;
    //                                     taxupdatvalues = Convert.ToDouble(amt);
    //                                     dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = "", id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
    //                                     dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = "", id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
    //                                 }

    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                             }
    //                             else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == false)
    //                             {

    //                                 taxupdatvalues = Convert.ToDouble(myItem[0].amount);

    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                             }
    //                             else if (myItem[0].Price_include == true)
    //                             {
    //                                 double formula = 0;
    //                                 double formulavalues = 0;
    //                                 taxupdatvalues = Convert.ToDouble(myItem[0].amount);
    //                                 formula = (Convert.ToDouble(dgPEItems[s].amount) / (Convert.ToDouble(taxupdatvalues / 100) + 1));
    //                                 formulavalues = Convert.ToDouble(formula * Convert.ToDouble(taxupdatvalues / 100));
    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPEItems.Where(l => l.item_id == dgPEItems[s].item_id).ToList().ForEach(i => i.amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))));
    //                             }
    //                             else if (myItem[0].Price_include == false)
    //                             {
    //                                 double vatcalculate = 0;
    //                                 double vatsum = 0;

    //                                 var BaseAmount = (from data in dgPOTaxValues3
    //                                                   where (data.item_id == dgPEItems[s].item_code
    //                                                       && data.stocking_unit1 == dgPEItems[s].stocking_unit1 && data.include_base_amount == true)
    //                                                   select data.tax_amount).Sum();

    //                                 taxupdatvalues = Convert.ToDouble(myItem[0].amount);
    //                                 vatsum = ((Convert.ToDouble(dgPEItems[s].amount)) + (Convert.ToDouble(BaseAmount)));
    //                                 vatcalculate = (vatsum * taxupdatvalues) / 100;

    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = dgPEItems[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //                             }
    //                             //else if (myItem[0].Price_include == false)
    //                             //{
    //                             //    try
    //                             //    {
    //                             //        decimal vatcst = 0;
    //                             //        {
    //                             //            var BasicExcise = (from data in dgPOTaxValues3 where data.description == "Basic Excise Duty" select data.tax_amount).Sum();
    //                             //            var cess = (from data in dgPOTaxValues3 where data.description == "Education CEss" select data.tax_amount).Sum();
    //                             //            var hcess = (from data in dgPOTaxValues3 where data.description == "Secondary Higher Edu. Cess" select data.tax_amount).Sum();
    //                             //            vatcst = Convert.ToDecimal(BasicExcise + cess + hcess);
    //                             //            parenttaxvalues = Convert.ToDouble(((SelectedPUR_T002_A.amount_untaxed + vatcst) * myItem[0].amount) / 100);
    //                             //            dgPOTaxValues.Add(new ACC_T006_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                             //            dgPOTaxValues3.Add(new ACC_T006_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_id, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //                             //        }
    //                             //    }
    //                             //    catch
    //                             //    {

    //                             //    }

    //                             //}

    //                             else
    //                             {

    //                                 taxupdatvalues = Convert.ToDouble(((dgPEItems[s].amount) * myItem[0].amount) / 100);
    //                                 dgPOTaxValues.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });
    //                                 dgPOTaxValues3.Add(new ACC_T006_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = dgPEItems[s].item_code, id = 0, line_id = dgPEItems[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = dgPEItems[s].amount, tax_id = Convert.ToInt32(a), description = myItem[0].description });

    //                             }


    //                         }


    //                     }
    //                     catch
    //                     {

    //                     }
    //                 }
    //             }
    //         }

    //         decimal total_amt1 = 0;
    //         decimal basic_amount = 0;

    //         for (int m = dgPOTaxValues3.Count - 1; m >= 0; m--)
    //         {

    //             var totaltaxvalue1 = (from o in dgPOTaxValues3
    //                                   where o.tax_id == dgPOTaxValues3[m].tax_id
    //                                   select o).ToList();

    //             for (int q = dgPOTaxValues3.Count; q >= 0; q--)
    //             {
    //                 try
    //                 {
    //                     int x7 = dgPOTaxValues3.IndexOf(dgPOTaxValues3.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
    //                     if (x7 != null)
    //                     {
    //                         dgPOTaxValues3.RemoveAt(x7);
    //                         m = dgPOTaxValues3.Count;
    //                     }
    //                 }
    //                 catch
    //                 {

    //                 }
    //             }

    //             for (int y = 0; y < totaltaxvalue1.Count; y++)
    //             {
    //                 total_amt1 = total_amt1 + Convert.ToDecimal(totaltaxvalue1[y].tax_amount);
    //                 basic_amount = basic_amount + Convert.ToDecimal(totaltaxvalue1[y].base_amount);
    //             }
    //             dgPOTotalTaxValues.Add(new ACC_T006_C()
    //             {
    //                 item_id = totaltaxvalue1[0].item_id,
    //                 id = 0,
    //                 line_id = 0,
    //                 tax_amount = total_amt1,
    //                 base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(basic_amount, 2)))),
    //                 tax_id = totaltaxvalue1[0].tax_id,
    //                 description = totaltaxvalue1[0].description,
    //                 taxaccount = totaltaxvalue1[0].taxaccount,
    //                 accountcollectdid = totaltaxvalue1[0].accountcollectdid,
    //                 stocking_unit1 = totaltaxvalue1[0].stocking_unit1,
    //             });
    //             total_amt1 = 0;
    //             basic_amount = 0;

    //         }


    //         decimal amount_taxed = 0;
    //         for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
    //         {
    //             amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
    //         }

    //         decimal subtotal = 0;
    //         for (int i = 0; i < dgPEItems.Count; i++)
    //         {
    //             if (dgPEItems[i].active == true)
    //             {

    //                 subtotal = subtotal + Convert.ToDecimal(dgPEItems[i].amount);
    //             }

    //         }

    //         SelectedPUR_T005_A.untaxedamount = subtotal;

    //         SelectedPUR_T005_A.tax_amount = amount_taxed;
    //         SelectedPUR_T005_A.totalamount = amount_taxed + SelectedPUR_T005_A.untaxedamount;
    //         try
    //         {
    //             decimal rounding = Convert.ToDecimal(SelectedPUR_T005_A.totalamount);
    //             SelectedPUR_T005_A.totalamount = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
    //         }
    //         catch
    //         {

    //         }
    //         try
    //         {
    //             double amount = Convert.ToDouble(SelectedPUR_T005_A.totalamount);
    //             SelectedPUR_T005_A.amtinword = num.AmountInWords(Convert.ToDecimal(amount));
    //         }
    //         catch
    //         {

    //         }

    //     }
    //     private void RowWiseTaxesLoad()
    //     {
    //         TaxRowCalculation();
    //         try
    //         {
    //             for (int j = 0; j < dgPOTaxValues.Count; j++)
    //             {
    //                 if (dgPOTaxValues[j].item_id == dgPEItems[dgSelectedIndex].item_code && dgPOTaxValues[j].stocking_unit1 == dgPEItems[dgSelectedIndex].stocking_unit1)
    //                 {
    //                     var parentdetails = (from o in dgPOTaxValues
    //                                          where o.item_id == dgPEItems[dgSelectedIndex].item_code && o.stocking_unit1 == dgPEItems[dgSelectedIndex].stocking_unit1
    //                                          select o).ToList();
    //                     dgPOTaxValues2 = new ObservableCollection<ACC_T006_C>();
    //                     for (int i = 0; i < parentdetails.Count; i++)
    //                     {
    //                         if (Convert.ToDouble(parentdetails[i].base_amount) != 0.0)
    //                         {
    //                             dgPOTaxValues2.Add(new ACC_T006_C() { stocking_unit1 = dgPEItems[dgSelectedIndex].stocking_unit1, id = 0, line_id = 0, tax_amount = parentdetails[i].tax_amount, base_amount = parentdetails[i].base_amount, tax_id = parentdetails[i].tax_id, description = parentdetails[i].description });
    //                         }
    //                     }
    //                     break;
    //                 }
    //                 else
    //                 {
    //                     dgPOTaxValues2 = new ObservableCollection<ACC_T006_C>();
    //                 }
    //             }
    //         }
    //         catch
    //         {

    //         }


    //     }
    //     #endregion "Tax Calculation"
    //}

    public class PUR_T005_DebitCredit_VM : WorkspaceViewModel<PUR_T005_A>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PUR_T005_DebitCredit_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTradeIndicator { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTradeIndicator
        {
            get { return _ASTradeIndicator; }
            set
            {
                if (_ASTradeIndicator != value)
                {
                    _ASTradeIndicator = value; RaisePropertyChanged("ASTradeIndicator");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASIncoTerms { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIncoTerms
        {
            get { return _ASIncoTerms; }
            set
            {
                if (_ASIncoTerms != value)
                {
                    _ASIncoTerms = value; RaisePropertyChanged("ASIncoTerms");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEPCG { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEPCG
        {
            get { return _ASEPCG; }
            set
            {
                if (_ASEPCG != value)
                {
                    _ASEPCG = value; RaisePropertyChanged("ASEPCG");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAdvance { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAdvance
        {
            get { return _ASAdvance; }
            set
            {
                if (_ASAdvance != value)
                {
                    _ASAdvance = value; RaisePropertyChanged("ASAdvance");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCFAgent { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCFAgent
        {
            get { return _ASCFAgent; }
            set
            {
                if (_ASCFAgent != value)
                {
                    _ASCFAgent = value; RaisePropertyChanged("ASCFAgent");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRefDocNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDocNo
        {
            get { return _ASRefDocNo; }
            set
            {
                if (_ASRefDocNo != value)
                {
                    _ASRefDocNo = value; RaisePropertyChanged("ASRefDocNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSuppParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSuppParty
        {
            get { return _ASSuppParty; }
            set
            {
                if (_ASSuppParty != value)
                {
                    _ASSuppParty = value; RaisePropertyChanged("ASSuppParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPayee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPayee
        {
            get { return _ASPayee; }
            set
            {
                if (_ASPayee != value)
                {
                    _ASPayee = value; RaisePropertyChanged("ASPayee");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCode
        {
            get { return _ASItemCode; }
            set
            {
                if (_ASItemCode != value)
                {
                    _ASItemCode = value; RaisePropertyChanged("ASItemCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCategory
        {
            get { return _ASItemCategory; }
            set
            {
                if (_ASItemCategory != value)
                {
                    _ASItemCategory = value; RaisePropertyChanged("ASItemCategory");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWeightUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWeightUnit
        {
            get { return _ASWeightUnit; }
            set
            {
                if (_ASWeightUnit != value)
                {
                    _ASWeightUnit = value; RaisePropertyChanged("ASWeightUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASVolUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVolUnit
        {
            get { return _ASVolUnit; }
            set
            {
                if (_ASVolUnit != value)
                {
                    _ASVolUnit = value; RaisePropertyChanged("ASVolUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTaxacc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxacc
        {
            get { return _ASTaxacc; }
            set
            {
                if (_ASTaxacc != value)
                {
                    _ASTaxacc = value; RaisePropertyChanged("ASTaxacc");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefault1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault1
        {
            get { return _ASDefault1; }
            set
            {
                if (_ASDefault1 != value)
                {
                    _ASDefault1 = value; RaisePropertyChanged("ASDefault1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASConditionType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASConditionType
        {
            get { return _ASConditionType; }
            set
            {
                if (_ASConditionType != value)
                {
                    _ASConditionType = value; RaisePropertyChanged("ASConditionType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdgCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgCurrency
        {
            get { return _ASdgCurrency; }
            set
            {
                if (_ASdgCurrency != value)
                {
                    _ASdgCurrency = value; RaisePropertyChanged("ASdgCurrency");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefault4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault4
        {
            get { return _ASDefault4; }
            set
            {
                if (_ASDefault4 != value)
                {
                    _ASDefault4 = value; RaisePropertyChanged("ASDefault4");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLicence { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLicence
        {
            get { return _ASLicence; }
            set
            {
                if (_ASLicence != value)
                {
                    _ASLicence = value; RaisePropertyChanged("ASLicence");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdgIncoTerms { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgIncoTerms
        {
            get { return _ASdgIncoTerms; }
            set
            {
                if (_ASdgIncoTerms != value)
                {
                    _ASdgIncoTerms = value; RaisePropertyChanged("ASdgIncoTerms");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBussPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBussPlace
        {
            get { return _ASBussPlace; }
            set
            {
                if (_ASBussPlace != value)
                {
                    _ASBussPlace = value; RaisePropertyChanged("ASBussPlace");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdgBussPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgBussPlace
        {
            get { return _ASdgBussPlace; }
            set
            {
                if (_ASdgBussPlace != value)
                {
                    _ASdgBussPlace = value; RaisePropertyChanged("ASdgBussPlace");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdgShipToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgShipToParty
        {
            get { return _ASdgShipToParty; }
            set
            {
                if (_ASdgShipToParty != value)
                {
                    _ASdgShipToParty = value; RaisePropertyChanged("ASdgShipToParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocCurr { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocCurr
        {
            get { return _ASDocCurr; }
            set
            {
                if (_ASDocCurr != value)
                {
                    _ASDocCurr = value; RaisePropertyChanged("ASDocCurr");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPaymentTerm { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPaymentTerm
        {
            get { return _ASPaymentTerm; }
            set
            {
                if (_ASPaymentTerm != value)
                {
                    _ASPaymentTerm = value; RaisePropertyChanged("ASPaymentTerm");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPaymentMethod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPaymentMethod
        {
            get { return _ASPaymentMethod; }
            set
            {
                if (_ASPaymentMethod != value)
                {
                    _ASPaymentMethod = value; RaisePropertyChanged("ASPaymentMethod");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCompanyBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompanyBank
        {
            get { return _ASCompanyBank; }
            set
            {
                if (_ASCompanyBank != value)
                {
                    _ASCompanyBank = value; RaisePropertyChanged("ASCompanyBank");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASNastroBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASNastroBank
        {
            get { return _ASNastroBank; }
            set
            {
                if (_ASNastroBank != value)
                {
                    _ASNastroBank = value; RaisePropertyChanged("ASNastroBank");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPurOrg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurOrg
        {
            get { return _ASPurOrg; }
            set
            {
                if (_ASPurOrg != value)
                {
                    _ASPurOrg = value; RaisePropertyChanged("ASPurOrg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPurGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurGrp
        {
            get { return _ASPurGrp; }
            set
            {
                if (_ASPurGrp != value)
                {
                    _ASPurGrp = value; RaisePropertyChanged("ASPurGrp");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCostCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCostCenter
        {
            get { return _ASCostCenter; }
            set
            {
                if (_ASCostCenter != value)
                {
                    _ASCostCenter = value; RaisePropertyChanged("ASCostCenter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASJournal { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASJournal
        {
            get { return _ASJournal; }
            set
            {
                if (_ASJournal != value)
                {
                    _ASJournal = value; RaisePropertyChanged("ASJournal");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("ASDocType");
                }
            }
        }
        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }
        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "ItemCode")
                    { ASDefault = ASItemCode; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUnit; }
                    else if (SourceName == "item_cat")
                    { ASDefault = ASItemCategory; }
                    else if (SourceName == "weight_unit")
                    { ASDefault = ASWeightUnit; }
                    else if (SourceName == "volume_unit")
                    { ASDefault = ASVolUnit; }

                    else if (SourceName == "gl_code")
                    { ASDefault1 = ASTaxacc; }
                    else if (SourceName == "curr_code")
                    { ASDefault1 = ASdgCurrency; }
                    else if (SourceName == "con_type")
                    { ASDefault1 = ASConditionType; }
                    else if (SourceName == "licence_no")
                    { ASDefault4 = ASLicence; }
                    else if (SourceName == "incoterms")
                    { ASDefault4 = ASdgIncoTerms; }
                    else if (SourceName == "buss_place")
                    { ASDefault = ASdgBussPlace; }
                    else if (SourceName == "ship_to_Party")
                    { ASDefault = ASdgShipToParty; }


                }
            }
        }
        #endregion

        #region Variable Declaration
        bool NewRecord = true;
        string Currency;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string ref_doc_cat { get; set; }
        WebServiceRepository<PUR_T005> repository = new WebServiceRepository<PUR_T005>();
        WebServiceRepository<MultipleContext_PUR_T005> repository_MC = new WebServiceRepository<MultipleContext_PUR_T005>();
        WebServiceRepository<MultipleContext_PUR_T005> repository_MCTemp = new WebServiceRepository<MultipleContext_PUR_T005>();
        ObjectSerializationService obj = new ObjectSerializationService();
        NumberToEnglish num = new NumberToEnglish();

        private MultipleContext_PUR_T005 _MC = new MultipleContext_PUR_T005();
        public MultipleContext_PUR_T005 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");

                }
            }

        }

        private MultipleContext_PUR_T005 _MCTemp = new MultipleContext_PUR_T005();
        public MultipleContext_PUR_T005 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private PUR_T005 _MasterEntity;
        public PUR_T005 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<PUR_T005_A> _ItemsEntity;
        public ObservableCollection<PUR_T005_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                }
            }
        }
        private ObservableCollection<ACC_T006_D> _LicenceDetailsEntity;
        public ObservableCollection<ACC_T006_D> LicenceDetailsEntity
        {
            get
            {
                return _LicenceDetailsEntity;
            }
            set
            {
                if (_LicenceDetailsEntity != value)
                {
                    _LicenceDetailsEntity = value;
                    LicenceDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForLicence);
                    RaisePropertyChanged("LicenceDetailsEntity");
                }
            }
        }

        private ObservableCollection<PUR_T005_B> _dgTotalTaxSummury;
        public ObservableCollection<PUR_T005_B> dgTotalTaxSummury
        {
            get
            {
                return _dgTotalTaxSummury;
            }
            set
            {
                if (_dgTotalTaxSummury != value)
                {
                    _dgTotalTaxSummury = value;

                    RaisePropertyChanged("dgTotalTaxSummury");

                }
            }
        }

        private ObservableCollection<ACC_T006_C> _TotalDocumentTaxes;
        // All Document Taxes including Parent,Child & External
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxes
        {
            get
            {
                return _TotalDocumentTaxes;
            }
            set
            {
                _TotalDocumentTaxes = value;
                TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
                RaisePropertyChanged("TotalDocumentTaxes");
            }
        }

        private ObservableCollection<ACC_T006_C> _TotalDocumentTaxesItem;
        // Taxes for selected item.
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxesItem
        {
            get
            {
                return _TotalDocumentTaxesItem;
            }
            set
            {
                _TotalDocumentTaxesItem = value;
                RaisePropertyChanged("TotalDocumentTaxesItem");
            }
        }

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

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                    FilterLicenceDataGrid();

                }
            }
        }
        private int _dgSelectedIndexItemLicence;
        public int dgSelectedIndexItemLicence
        {
            get
            {
                return _dgSelectedIndexItemLicence;
            }
            set
            {
                if (_dgSelectedIndexItemLicence != value)
                {
                    _dgSelectedIndexItemLicence = value;
                    RaisePropertyChanged("dgSelectedIndexItemLicence");
                }
            }
        }
        private int _dgSelectedIndexTaxSummury;
        public int dgSelectedIndexTaxSummury
        {
            get
            {
                return _dgSelectedIndexTaxSummury;
            }
            set
            {
                if (_dgSelectedIndexTaxSummury != value)
                {

                    _dgSelectedIndexTaxSummury = value;
                    RaisePropertyChanged("dgSelectedIndexTaxSummury");

                }
            }
        }

        //scalar fields
        private decimal _TotalQty;
        public decimal TotalQty
        {
            get { return _TotalQty; }
            set
            {
                if (_TotalQty != value)
                {
                    _TotalQty = value;
                    RaisePropertyChanged("TotalQty");
                }
            }
        }

        private decimal _TotalRate;
        public decimal TotalRate
        {
            get { return _TotalRate; }
            set
            {
                if (_TotalRate != value)
                {
                    _TotalRate = value;
                    RaisePropertyChanged("TotalRate");
                }
            }
        }

        private decimal _TotalValuation;
        public decimal TotalValuation
        {
            get { return _TotalValuation; }
            set
            {
                if (_TotalValuation != value)
                {
                    _TotalValuation = value;
                    RaisePropertyChanged("TotalValuation");
                }
            }
        }

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }
        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        #endregion

        #region List
        private List<PUR_T005_Flip> _FlipGridData;
        // Flip DataGrid Data Source
        public List<PUR_T005_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

        public List<ADM_M001_M_P> _PurchaseOrganisationList;
        public List<ADM_M001_M_P> PurchaseOrganisationList
        {
            get
            {
                return _PurchaseOrganisationList;
            }
            set
            {
                _PurchaseOrganisationList = value;
                RaisePropertyChanged("PurchaseOrganisationList");
            }
        }

        public List<ADM_M001_P_P> _PurchaseGroupList;
        public List<ADM_M001_P_P> PurchaseGroupList
        {
            get
            {
                return _PurchaseGroupList;
            }
            set
            {
                _PurchaseGroupList = value;
                RaisePropertyChanged("PurchaseGroupList");
            }
        }
        public List<PUR_T005_P_PI_ItemsList> _ItemListForPopup;
        public List<PUR_T005_P_PI_ItemsList> ItemListPopup
        {
            get
            {
                return _ItemListForPopup;
            }
            set
            {
                _ItemListForPopup = value;
                RaisePropertyChanged("ItemListPopup");
            }
        }
        List<string> _StringListTaxAcc;
        public List<string> StringListTaxAcc
        {
            get { return _StringListTaxAcc; }
            set
            {
                if (_StringListTaxAcc != value)
                {
                    _StringListTaxAcc = value;
                }
            }
        }
        private List<ACC_M013_P> _SelectedTaxList;
        // Supporting for Filter Data Source for Parent Taxes. * can be remove.
        public List<ACC_M013_P> SelectedTaxList
        {
            get { return _SelectedTaxList; }
            set
            {
                if (_SelectedTaxList != value)
                {
                    _SelectedTaxList = value;
                    RaisePropertyChanged("SelectedTaxList");
                }
            }
        }
        public List<ADM_M002> _CurrancyList;
        public List<ADM_M002> CurrancyList
        {
            get
            {
                return _CurrancyList;
            }
            set
            {
                _CurrancyList = value;
                RaisePropertyChanged("CurrancyList");
            }
        }


        #endregion

        #region Dictionary
        private Dictionary<string, object> _taxDictonery;
        // Tax Popup Data Source
        public Dictionary<string, object> TaxDictonery
        {
            get { return _taxDictonery; }
            set
            {
                if (_taxDictonery != value)
                {
                    _taxDictonery = value;
                    RaisePropertyChanged("TaxDictonery");
                }
            }
        }

        private Dictionary<string, object> _taxDictoneryParent;
        //Parant Tax List data Source for Popup
        public Dictionary<string, object> TaxDictoneryParent
        {
            get { return _taxDictoneryParent; }
            set
            {
                if (_taxDictoneryParent != value)
                {
                    _taxDictoneryParent = value;
                    RaisePropertyChanged("TaxDictoneryParent");
                }
            }
        }
        #endregion

        #region Collection
        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }
        private List<GetItemDetailsEntity> _SalesUnitPriceCollection;
        public List<GetItemDetailsEntity> SalesUnitPriceCollection
        {
            get { return _SalesUnitPriceCollection; }
            set { _SalesUnitPriceCollection = value; RaisePropertyChanged("SalesUnitPriceCollection"); }
        }
        private List<GetItemDetailsEntity> _SalesQFRCollection;
        public List<GetItemDetailsEntity> SalesQFRCollection
        {
            get { return _SalesQFRCollection; }
            set { _SalesQFRCollection = value; RaisePropertyChanged("SalesQFRCollection"); }
        }
        private List<GetItemDetailsEntity> _SalesDispatchCollection;
        public List<GetItemDetailsEntity> SalesDispatchCollection
        {
            get { return _SalesDispatchCollection; }
            set { _SalesDispatchCollection = value; RaisePropertyChanged("SalesDispatchCollection"); }
        }
        private List<GetItemDetailsEntity> _SalesProjDispatchCollection;
        public List<GetItemDetailsEntity> SalesProjDispatchCollection
        {
            get { return _SalesProjDispatchCollection; }
            set { _SalesProjDispatchCollection = value; RaisePropertyChanged("SalesProjDispatchCollection"); }
        }
        private ICollectionView _dgPOItemsFortaxval;
        public ICollectionView dgPOItemsFortaxval
        {
            get { return _dgPOItemsFortaxval; }
            set
            {
                _dgPOItemsFortaxval = value;
                RaisePropertyChanged("dgPOItemsFortaxval");
            }
        }

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }
        private ICollectionView _payeeCollection;
        public ICollectionView PayeeCollection
        {
            get { return _payeeCollection; }
            set { _payeeCollection = value; RaisePropertyChanged("PayeeCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }
        private ICollectionView _itemcategoryCollection;
        public ICollectionView ItemcategoryCollection
        {
            get { return _itemcategoryCollection; }
            set
            {
                _itemcategoryCollection = value;
                RaisePropertyChanged("ItemcategoryCollection");
            }
        }
        private ICollectionView _journalCollection;
        public ICollectionView journalCollection
        {
            get { return _journalCollection; }
            set
            {
                _journalCollection = value;
                RaisePropertyChanged("journalCollection");
            }
        }
        private ICollectionView _payTermCollection;
        public ICollectionView PayTermCollection
        {
            get { return _payTermCollection; }
            set { _payTermCollection = value; RaisePropertyChanged("PayTermCollection"); }
        }
        private ICollectionView _paymethodCollection;
        public ICollectionView PayMethodCollection
        {
            get { return _paymethodCollection; }
            set { _paymethodCollection = value; RaisePropertyChanged("PayMethodCollection"); }
        }
        private ICollectionView _currancyCollection;
        public ICollectionView CurrancyCollection
        {
            get { return _currancyCollection; }
            set { _currancyCollection = value; RaisePropertyChanged("CurrancyCollection"); }
        }

        private ICollectionView _purchase_orgCollection;
        public ICollectionView Purchase_OrgCollection
        {
            get { return _purchase_orgCollection; }
            set { _purchase_orgCollection = value; RaisePropertyChanged("Purchase_OrgCollection"); }
        }

        private ICollectionView _purchase_groupCollection;
        public ICollectionView purchase_groupCollection
        {
            get { return _purchase_groupCollection; }
            set
            {
                _purchase_groupCollection = value;
                RaisePropertyChanged("purchase_groupCollection");
            }
        }
        private ICollectionView _cost_centerCollection;
        public ICollectionView Cost_CenterCollection
        {
            get { return _cost_centerCollection; }
            set
            {
                _cost_centerCollection = value;
                RaisePropertyChanged("Cost_CenterCollection");
            }
        }
        private ICollectionView _bankCollection;
        public ICollectionView BankCollection
        {
            get { return _bankCollection; }
            set
            {
                _bankCollection = value;
                RaisePropertyChanged("BankCollection");
            }
        }
        // collection for reference documents on load of partys details.
        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }
        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }
        private ICollectionView _doc_typeCollection;
        public ICollectionView doc_typeCollection
        {
            get { return _doc_typeCollection; }
            set
            {
                _doc_typeCollection = value;
                RaisePropertyChanged("doc_typeCollection");
            }
        }
        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection");
            }
        }
        private ICollectionView _ParameterValueCollection;
        public ICollectionView ParameterValueCollection
        {
            get { return _ParameterValueCollection; }
            set
            {
                _ParameterValueCollection = value;
                RaisePropertyChanged("ParameterValueCollection");
            }
        }
        private ICollectionView _taxAccountollection;
        public ICollectionView TaxAccountollection
        {
            get { return _taxAccountollection; }
            set { _taxAccountollection = value; RaisePropertyChanged("TaxAccountollection"); }
        }
        private ICollectionView _FormTypeCollection;
        public ICollectionView FormTypeCollection
        {
            get { return _FormTypeCollection; }
            set { _FormTypeCollection = value; RaisePropertyChanged("FormTypeCollection"); }
        }
        private ICollectionView _productDescriptionCollection;
        public ICollectionView ProductDescriptionCollection
        {
            get { return _productDescriptionCollection; }
            set { _productDescriptionCollection = value; RaisePropertyChanged("ProductDescriptionCollection"); }
        }
        private ICollectionView _CollectionPlant;
        public ICollectionView CollectionPlant
        {
            get { return _CollectionPlant; }
            set { _CollectionPlant = value; RaisePropertyChanged("CollectionPlant"); }
        }

        private List<NotificationData> _NotificationDataCollection;
        public List<NotificationData> NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set
            {
                if (_NotificationDataCollection != value)
                {
                    _NotificationDataCollection = value;
                    RaisePropertyChanged("NotificationDataCollection");
                }
            }
        }

        private ICollectionView _CollectionCountry;
        public ICollectionView CollectionCountry
        {
            get { return _CollectionCountry; }
            set { _CollectionCountry = value; RaisePropertyChanged("CollectionCountry"); }
        }
        public List<ADM_M003> _ObjSupply = new List<ADM_M003>();
        private List<ADM_M003> ObjSupply
        {
            get { return _ObjSupply; }
            set
            {
                if (_ObjSupply != value)
                {
                    _ObjSupply = value;
                }
            }
        }
        //ItemListForPopup
        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }

        private ICollectionView _WtUomCollection;
        public ICollectionView WtUomCollection
        {
            get { return _WtUomCollection; }
            set
            {
                _WtUomCollection = value;

                RaisePropertyChanged("WtUomCollection");
            }
        }
        private ICollectionView _VolUomCollection;
        public ICollectionView VolUomCollection
        {
            get { return _VolUomCollection; }
            set
            {
                _VolUomCollection = value;
                RaisePropertyChanged("VolUomCollection");
            }
        }
        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }
        private int _ParadgSelectedIndex;
        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
                }
            }
        }

        private ICollectionView _incotermsCollection;
        public ICollectionView IncotermsCollection
        {
            get { return _incotermsCollection; }
            set { _incotermsCollection = value; RaisePropertyChanged("IncotermsCollection"); }
        }


        private ICollectionView _licenseEPCGCollection;
        public ICollectionView LicenseEPCGCollection
        {
            get { return _licenseEPCGCollection; }
            set { _licenseEPCGCollection = value; RaisePropertyChanged("LicenseEPCG"); }
        }

        private ICollectionView _licenseAdvanceCollection;
        public ICollectionView LicenseAdvanceCollection
        {
            get { return _licenseAdvanceCollection; }
            set { _licenseAdvanceCollection = value; RaisePropertyChanged("LicenseAdvance"); }
        }

        private ICollectionView _serviceProviderCollection;
        public ICollectionView ServiceProviderCollection
        {
            get { return _serviceProviderCollection; }
            set { _serviceProviderCollection = value; RaisePropertyChanged("ServiceProviderCollection"); }
        }
        #endregion

        #region StringList Variables
        private List<string> _strListDocType;
        public List<string> StringListDocumentTypes
        {
            get { return _strListDocType; }
            set
            {
                if (_strListDocType != value)
                {
                    _strListDocType = value;
                }
            }
        }
        private List<string> _StrListParty;
        public List<string> StringListParty
        {
            get { return _StrListParty; }
            set
            {
                if (_StrListParty != value)
                {
                    _StrListParty = value;
                }
            }
        }

        private List<string> _StrListPayee;
        public List<string> StringListPayee
        {
            get { return _StrListPayee; }
            set
            {
                if (_StrListPayee != value)
                {
                    _StrListPayee = value;
                }
            }
        }

        private List<string> _strListServiceProvider;
        public List<string> stringListServiceProvider
        {
            get { return _strListServiceProvider; }
            set
            {
                if (_strListServiceProvider != value)
                {
                    _strListServiceProvider = value;
                }
            }

        }

        private List<string> _strListUOM;
        public List<string> StringListUOM
        {
            get { return _strListUOM; }
            set
            {
                if (_strListUOM != value)
                {
                    _strListUOM = value;
                }
            }
        }
        private List<string> _strListJournal;
        public List<string> StringListJournal
        {
            get { return _strListJournal; }
            set
            {
                if (_strListJournal != value)
                {
                    _strListJournal = value;
                }
            }
        }
        private List<string> _strListPayTerms;
        public List<string> StringListPayTerms
        {
            get { return _strListPayTerms; }
            set
            {
                if (_strListPayTerms != value)
                {
                    _strListPayTerms = value;
                }
            }
        }
        private List<string> _strListPayMethod;
        public List<string> StringListPayMethod
        {
            get { return _strListPayMethod; }
            set
            {
                if (_strListPayMethod != value)
                {
                    _strListPayMethod = value;
                }
            }
        }
        private List<string> _strListCurrency;
        public List<string> StringListCurrency
        {
            get { return _strListCurrency; }
            set
            {
                if (_strListCurrency != value)
                {
                    _strListCurrency = value;
                }
            }
        }
        private List<string> _strListPurchaseOrg;
        public List<string> StringListPurchaseOrg
        {
            get { return _strListPurchaseOrg; }
            set
            {
                if (_strListPurchaseOrg != value)
                {
                    _strListPurchaseOrg = value;
                }
            }
        }
        private List<string> _strListPurchaseGroup;
        public List<string> StringListPurchaseGroup
        {
            get { return _strListPurchaseGroup; }
            set
            {
                if (_strListPurchaseGroup != value)
                {
                    _strListPurchaseGroup = value;
                }
            }
        }
        private List<string> _strListItemCategory;
        public List<string> StringListItemCategory
        {
            get { return _strListItemCategory; }
            set
            {
                if (_strListItemCategory != value)
                {
                    _strListItemCategory = value;
                }
            }
        }
        private List<string> _strListCostCenter;
        public List<string> StringListCostCenter
        {
            get { return _strListCostCenter; }
            set
            {
                if (_strListCostCenter != value)
                {
                    _strListCostCenter = value;
                }
            }
        }
        private List<string> _strListBanks;
        public List<string> StringListBanks
        {
            get { return _strListBanks; }
            set
            {
                if (_strListBanks != value)
                {
                    _strListBanks = value;
                }
            }
        }
        private List<string> _strListTaxAccount;
        public List<string> StringListTaxAccount
        {
            get { return _strListTaxAccount; }
            set
            {
                if (_strListTaxAccount != value)
                {
                    _strListTaxAccount = value;
                }
            }
        }
        private List<string> _strListReferenceDoc;
        public List<string> StringListReferenceDoc
        {
            get { return _strListReferenceDoc; }
            set
            {
                if (_strListReferenceDoc != value)
                {
                    _strListReferenceDoc = value;
                }
            }
        }
        private List<string> _strListItems;
        public List<string> StringListItems
        {
            get { return _strListItems; }
            set
            {
                if (_strListItems != value)
                {
                    _strListItems = value;
                }
            }
        }
        private List<string> _stringListLocations;
        public List<string> StringListLocations
        {
            get { return _stringListLocations; }
            set
            {
                if (_stringListLocations != value)
                {
                    _stringListLocations = value;
                }
            }
        }





        private List<string> _strListProductDescription;
        public List<string> StringListProductDescription
        {
            get { return _strListProductDescription; }
            set
            {
                if (_strListProductDescription != value)
                {
                    _strListProductDescription = value;
                }
            }
        }


        private List<string> _strListReferanceDocNo;
        public List<string> StringListReferanceDocNo
        {
            get { return _strListReferanceDocNo; }
            set
            {
                if (_strListReferanceDocNo != value)
                {
                    _strListReferanceDocNo = value;
                }
            }
        }

        private List<string> _strListCountry;
        public List<string> StringListCountry
        {
            get { return _strListCountry; }
            set
            {
                if (_strListCountry != value)
                {
                    _strListCountry = value;
                }
            }
        }

        private List<string> _strListDistributionChannel;
        public List<string> StringListDistributionChannel
        {
            get { return _strListDistributionChannel; }
            set
            {
                if (_strListDistributionChannel != value)
                {
                    _strListDistributionChannel = value;
                }
            }
        }
        private List<string> _strListFormType;
        public List<string> StringListFormtype
        {
            get { return _strListFormType; }
            set
            {
                if (_strListFormType != value)
                {
                    _strListFormType = value;
                }
            }
        }

        private List<string> _strListBillingAddress;
        public List<string> StringListBillingAddress
        {
            get { return _strListBillingAddress; }
            set
            {
                if (_strListBillingAddress != value)
                {
                    _strListBillingAddress = value;
                }
            }
        }

        private List<string> _StringListWtUom;
        public List<string> StringListWtUom
        {
            get { return _StringListWtUom; }
            set
            {
                if (_StringListWtUom != value)
                {
                    _StringListWtUom = value;
                }
            }
        }
        private List<string> _StringListVolUom;
        public List<string> StringListVolUom
        {
            get { return _StringListVolUom; }
            set
            {
                if (_StringListVolUom != value)
                {
                    _StringListVolUom = value;
                }
            }
        }

        private List<string> _stringListPlant;
        public List<string> stringListPlant
        {
            get { return _stringListPlant; }
            set
            {
                if (_stringListPlant != value)
                {
                    _stringListPlant = value;
                }
            }
        }
        private List<string> _StringListCFAgent;
        public List<string> StringListCFAgent
        {
            get { return _StringListCFAgent; }
            set
            {
                if (_StringListCFAgent != value)
                {
                    _StringListCFAgent = value;
                }
            }
        }



        private List<string> _StringListSupplierparty;
        public List<string> StringListSupplierparty
        {
            get { return _StringListSupplierparty; }
            set
            {
                if (_StringListSupplierparty != value)
                {
                    _StringListSupplierparty = value;
                }
            }
        }

        private List<string> _stringListIncoterms;
        public List<string> StringListIncoterms
        {
            get { return _stringListIncoterms; }
            set
            {
                if (_stringListIncoterms != value)
                {
                    _stringListIncoterms = value;
                }
            }
        }

        private List<string> _stringListLicenseEPCG;
        public List<string> StringListLicenseEPCG
        {
            get { return _stringListLicenseEPCG; }
            set
            {
                if (_stringListLicenseEPCG != value)
                {
                    _stringListLicenseEPCG = value;
                }
            }
        }

        private List<string> _stringListLicenseAdvance;
        public List<string> StringListLicenseAdvance
        {
            get { return _stringListLicenseAdvance; }
            set
            {
                if (_stringListLicenseAdvance != value)
                {
                    _stringListLicenseAdvance = value;
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdInsertSupplierParty { get; private set; }
        public RelayCommand<object> CmdInsertPayee { get; private set; }//check 
        public RelayCommand<object> CmdInsertPurchaseOrg { get; private set; }
        public RelayCommand<object> CmdInsertPurchaseGroup { get; private set; }
        public RelayCommand<object> CmdInsertUOM { get; private set; }
        public RelayCommand<object> CmdInsertPayTerms { get; private set; }
        public RelayCommand<object> CmdInsertPayMethod { get; private set; }
        public RelayCommand<object> CmdInsertCurrency { get; private set; }
        public RelayCommand<object> CmdInsertCostCenter { get; private set; }
        public RelayCommand<object> CmdInsertJournal { get; private set; }
        public RelayCommand<object> CmdInsertBank { get; private set; }
        public RelayCommand<object> CmdInsertTaxAccount { get; private set; }
        public RelayCommand<object> CmdInsertDocType { get; private set; }
        public RelayCommand<object> CmdInsertNastroBank { get; private set; }
        public RelayCommand<object> CmdInsertwtunit { get; private set; }
        public RelayCommand<object> CmdInsertVolUnit { get; private set; }
        public RelayCommand<object> CmdInsertReferenceDoc { get; private set; }
        public RelayCommand<object> CmdInsertItem { get; private set; }
        public RelayCommand<object> CmdInsertItemCategory { get; private set; }
        public RelayCommand<object> CmdLoadDocumentWithReferenceDocumentNumber { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandproductDescription { get; private set; }
        public RelayCommand<object> CommandFormType { get; private set; }
        public RelayCommand<object> CmdInsertPlant { get; private set; }
        public RelayCommand<object> commandSource { get; private set; }
        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> TaxPopupCommand { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandForLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdRefDoc { get; private set; }
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> CMDDocType { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> CmdItemInfo { get; private set; }
        public RelayCommand<object> CmdLicence { get; private set; }
        public RelayCommand<object> CmddgIncoterms { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowLicence { get; private set; }
        public RelayCommand<object> cmdBussPlace { get; private set; }
        public RelayCommand<object> cmddgBussPlace { get; private set; }
        public RelayCommand<object> CmddgShipToParty { get; private set; }
        #endregion

        #region Constructor
        public PUR_T005_DebitCredit_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_PUR_T005();
            MasterEntity = new PUR_T005();
            MCTemp = new MultipleContext_PUR_T005();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            FlipGridData = new List<PUR_T005_Flip>();
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FrmDate = lastDayLastMonth.AddDays(-23);
            MasterEntity.ToDate = System.DateTime.Now;
            //MasterEntity.ValidateAsync().Wait();
            PUR_T005.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            NotificationDataCollection = new List<NotificationData>();
            MoveFlag = true;
            parameter = false;
            LoadInitialData();
        }
        public PUR_T005_DebitCredit_VM(string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_PUR_T005();
            MasterEntity = new PUR_T005();
            MCTemp = new MultipleContext_PUR_T005();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            FlipGridData = new List<PUR_T005_Flip>();
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FrmDate = lastDayLastMonth.AddDays(-23);
            MasterEntity.ToDate = System.DateTime.Now;
            //MasterEntity.ValidateAsync().Wait();
            PUR_T005.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            NotificationDataCollection = new List<NotificationData>();
            MoveFlag = true;
            parameter = false;
            LoadInitialData();
        }
        #endregion

        #region LoadInitialData
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.po_code + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MC, Request, "PurchaseInvoiceDebitCredit", "Procurement", "LoadAll", 0, "");
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdInsertSupplierParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplierParty(items, NewRecord); });
                CmdInsertReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                CmdInsertPayee = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayee(items); });
                CmdInsertPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                CmdInsertPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                CmdInsertPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                CmdInsertPayMethod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayMethod(items); });
                CmdInsertCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CmdInsertBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
                //CmdInsertDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                CmdInsertJournal = new RelayCommand<object>(items => { if (items == null) { return; } InsertJournal(items); });
                CmdInsertItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CmdInsertItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
                CmdInsertUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CmdInsertwtunit = new RelayCommand<object>(items => { if (items == null) { return; } InsertwtUOM(items, false, true, true); });
                CmdInsertVolUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertvolUOM(items, false, true, true); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CmdInsertPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CmdInsertNastroBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertNastroBank(items); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } InsertCollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });
                //CmdInsertTaxAccount = new RelayCommand<object>(items => { if (items == null) { return; } (items); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                TaxPopupCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                CommandForLoadBackFlip = new GalaSoft.MvvmLight.Command.RelayCommand(Load);
                CmdInsertCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });

                cmdRefDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDoc(items); });

                CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
                CommandServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items, true); });
                CMDDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                CmddgCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgCurrency(cmdPara); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                CmdItemInfo = new RelayCommand<object>(items => { if (items == null) { return; } FilterItemSalesData(items); });

                CmdLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicence(cmdPara, false, true, true); });
                CommandDeleteDataGridRowLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemLicence(cmdPara); });// confirm assignment
                CmddgIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgIncoterms(cmdPara, false, true, true); });
                cmdBussPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertBussPlace(items); });
                cmddgBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgBussPlace(cmdPara, false, true, true); });
                CmddgShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgShipToParty(cmdPara, false, true, true); });

                #endregion
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyId.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M028_P)o).PartyNm.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M037)x).ind_trade);
                TheFilter = (o, prefix) => (((SYS_M037)o).ind_trade ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M037)o).trade_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTradeIndicator = new AutoSuggestTextViewModel<dynamic>(MC.Trade_Types, TheFilter, SuggestedValue, "ind_trade", true);
                ASTradeIndicator.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASTradeIndicator.AutoSuggestVM.IsFreeTextAllowed = false;

                //New PopUP - As default
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((PUR_T005_P_PI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((PUR_T005_P_PI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Incoterms
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => ((ADM_M044_P)o).incoterms.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M044_P)o).inco_desc.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", true);
                ASIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - EPCG licence
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => ((ADM_M041_P)o).lic_cod.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASEPCG = new AutoSuggestTextViewModel<dynamic>(MC.LicenseEPCG, TheFilter, SuggestedValue, "lic_cod", true);
                ASEPCG.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Advance Licence
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => ((ADM_M041_P)o).lic_cod.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASAdvance = new AutoSuggestTextViewModel<dynamic>(MC.LicenseAdvance, TheFilter, SuggestedValue, "lic_cod", true);
                ASAdvance.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - C&F Agent
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyId.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M028_P)o).PartyNm.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASCFAgent = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "PartyId", true);
                ASCFAgent.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Reference Document No
                MasterEntity.ref_doc_type = "Purchase Invoice";
                RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PQ" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Supplier Party
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix);
                ASSuppParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASSuppParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payee
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix);
                ASPayee = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "payee_payer", true);
                ASPayee.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Item Category
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M003_P)x).sditem_cat_code);
                TheFilter = (o, prefix) => ((SYS_M003_P)o).sditem_cat_code.ToString().ToLower().Contains(prefix);
                ASItemCategory = new AutoSuggestTextViewModel<dynamic>(MC.ItemCategoryList, TheFilter, SuggestedValue, "item_cat", "sditem_cat_code", true);
                ASItemCategory.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASItemCategory.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M038_B_P)o).unit_name.ToString().ToLower().Contains(prefix);
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUnit.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Weight Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToString().ToLower().Contains(prefix);
                ASWeightUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "weight_unit", "unit_code", true);
                ASWeightUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Volume Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToString().ToLower().Contains(prefix);
                ASVolUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "volume_unit", "unit_code", true);
                ASVolUnit.AutoSuggestVM.IsEmptyValueAllowed = true;


                //New PopUP - Doc. Currency
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => ((ADM_M037_P)o).curr_code.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M037_P)o).curr_name.ToString().ToLower().Contains(prefix);
                ASDocCurr = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", true);
                ASDocCurr.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Plant PayTerms
                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M003)o).LoctnNm.ToString().ToLower().Contains(prefix);
                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjSupply, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payment Terms
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code);
                TheFilter = (o, prefix) => ((ACC_M007_P)o).p_term_code.ToString().ToLower().Contains(prefix) ||
                                           ((ACC_M007_P)o).p_term.ToString().ToLower().Contains(prefix);
                ASPaymentTerm = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", true);
                ASPaymentTerm.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payment Method
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M021_P)x).pay_method);
                TheFilter = (o, prefix) => ((ACC_M021_P)o).pay_method.ToString().ToLower().Contains(prefix) ||
                                           ((ACC_M021_P)o).pay_code.ToString().ToLower().Contains(prefix);
                ASPaymentMethod = new AutoSuggestTextViewModel<dynamic>(MC.PayMethod, TheFilter, SuggestedValue, "pay_method", true);
                ASPaymentMethod.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Company Bank
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => ((ACC_M004_P)o).bank_code.ToString().ToLower().Contains(prefix) ||
                                           ((ACC_M004_P)o).bank_name.ToString().ToLower().Contains(prefix);
                ASCompanyBank = new AutoSuggestTextViewModel<dynamic>(MC.BankList, TheFilter, SuggestedValue, "bank_code", true);
                ASCompanyBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Nastro Bank
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => ((ACC_M004_P)o).bank_code.ToString().ToLower().Contains(prefix) ||
                                           ((ACC_M004_P)o).bank_name.ToString().ToLower().Contains(prefix);
                ASNastroBank = new AutoSuggestTextViewModel<dynamic>(MC.BankList, TheFilter, SuggestedValue, "bank_code", true);
                ASNastroBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Purchase Organisation
                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => ((ADM_M001_M_P)o).po_code.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M001_M_P)o).pur_org.ToString().ToLower().Contains(prefix);
                ASPurOrg = new AutoSuggestTextViewModel<dynamic>(PurchaseOrganisationList, TheFilter, SuggestedValue, "po_code", true);
                ASPurOrg.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Purchase Group
                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code);
                TheFilter = (o, prefix) => ((ADM_M001_P_P)o).pg_code.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M001_P_P)o).pg_name.ToString().ToLower().Contains(prefix);
                ASPurGrp = new AutoSuggestTextViewModel<dynamic>(PurchaseGroupList, TheFilter, SuggestedValue, "pg_code", true);
                ASPurGrp.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Cost Center
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => ((ACC_M019_P)o).cost_center.ToString().ToLower().Contains(prefix) ||
                                           ((ACC_M019_P)o).cost_center_Desc.ToString().ToLower().Contains(prefix);
                ASCostCenter = new AutoSuggestTextViewModel<dynamic>(MC.Cost_Centers, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCenter.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Journal
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M005_P)x).j_code);
                TheFilter = (o, prefix) => ((ACC_M005_P)o).j_code.ToString().ToLower().Contains(prefix) ||
                                           ((ACC_M005_P)o).j_name.ToString().ToLower().Contains(prefix);
                ASJournal = new AutoSuggestTextViewModel<dynamic>(MC.Journals, TheFilter, SuggestedValue, "j_code", true);
                ASJournal.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New Popup -Doc Type
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M007_P)x).doc_type);
                TheFilter = (o, prefix) => ((SYS_M007_P)o).doc_type.Contains(prefix) || ((SYS_M007_P)o).doc_desc.Contains(prefix);
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocTypeData, TheFilter, SuggestedValue, "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Tax Account
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTaxacc = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASTaxacc.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASConditionType = new AutoSuggestTextViewModel<dynamic>(MC.ConditionTypeList, TheFilter, SuggestedValue, "con_type", "con_type", false);
                ASConditionType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault4 = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASDefault4.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault4.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASdgIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M041_P)o).lic_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLicence = new AutoSuggestTextViewModel<dynamic>(MC.LicenceList, TheFilter, SuggestedValue, "licence_no", "lic_cod", true);
                ASLicence.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBussPlace = new AutoSuggestTextViewModel<dynamic>(MC.BussinessPlaceList, TheFilter, SuggestedValue, "buss_place", true);
                ASBussPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgBussPlace = new AutoSuggestTextViewModel<dynamic>(MC.BussinessPlaceList, TheFilter, SuggestedValue, "buss_place", "buss_place", true);
                ASdgBussPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "ship_to_Party", "PartyId", true);
                ASdgShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(Filter_SupplierParty);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                //PayeeCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                //PayeeCollection.Filter = new Predicate<object>(Filter_Payee);
                //StringListPayee = MC.PartyMaster.Select(x => x.PartyId).ToList();

                //RefDocTempData = MC.Purchase_Invoice_Reference.ToList();
                MasterEntity.ref_doc_type = "Goods Receipt Note";
                RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();
                ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData);
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                StringListReferanceDocNo = MC.Purchase_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();

                Cost_CenterCollection = CollectionViewSource.GetDefaultView(MC.Cost_Centers);
                Cost_CenterCollection.Filter = new Predicate<object>(Filter_Cost_Center);
                StringListCostCenter = MC.Cost_Centers.Select(x => x.cost_center).ToList();

                journalCollection = CollectionViewSource.GetDefaultView(MC.Journals);
                journalCollection.Filter = new Predicate<object>(Filter_Journal);
                StringListJournal = MC.Journals.Select(x => x.j_code).ToList();

                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                Purchase_OrgCollection = CollectionViewSource.GetDefaultView(PurchaseOrganisationList);
                Purchase_OrgCollection.Filter = new Predicate<object>(Purorg_Filter);
                StringListPurchaseOrg = PurchaseOrganisationList.Select(x => x.po_code).ToList();
                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }
                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                purchase_groupCollection = CollectionViewSource.GetDefaultView(PurchaseGroupList);
                purchase_groupCollection.Filter = new Predicate<object>(Purchase_grp_Filter);
                StringListPurchaseGroup = PurchaseGroupList.Select(x => x.pg_code).ToList();
                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
                }
                CurrancyCollection = CollectionViewSource.GetDefaultView(MC.CurrencyList);
                CurrancyCollection.Filter = new Predicate<object>(Filter_Currency);
                StringListCurrency = MC.CurrencyList.Select(x => x.curr_code).ToList();

                BankCollection = CollectionViewSource.GetDefaultView(MC.BankList);
                BankCollection.Filter = new Predicate<object>(Filter_Banks);
                StringListBanks = MC.BankList.Select(x => x.bank_code).ToList();

                PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms.ToList());
                PayTermCollection.Filter = new Predicate<object>(Filter_PayTerms);
                StringListPayTerms = MC.PayTerms.Select(x => x.p_term_code).ToList();

                PayMethodCollection = CollectionViewSource.GetDefaultView(MC.PayMethod.ToList());
                PayMethodCollection.Filter = new Predicate<object>(Filter_PayMethod);
                StringListPayMethod = MC.PayMethod.Select(x => x.pay_code).ToList();

                dgPOItemsFortaxval = CollectionViewSource.GetDefaultView(MC.AccountList);
                //dgPOItemsFortaxval.Filter = new Predicate<object>(FiltertaxAcc);
                StringListTaxAcc = MC.AccountList.Select(x => x.gl_code).ToList();

                ItemcategoryCollection = CollectionViewSource.GetDefaultView(MC.ItemCategoryList);
                ItemcategoryCollection.Filter = new Predicate<object>(Filter_ItemCategory);
                StringListItemCategory = MC.ItemCategoryList.Select(x => x.sditem_cat_code).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitList.ToList());
                UomCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUOM = MC.UnitList.Select(x => x.unit_code).ToList();

                WtUomCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
                WtUomCollection.Filter = new Predicate<object>(FilterCollectionWtUom);
                StringListWtUom = MC.UnitList.Select(x => x.unit_code).ToList();

                VolUomCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
                VolUomCollection.Filter = new Predicate<object>(FilterCollectionVolUom);
                StringListVolUom = MC.UnitList.Select(x => x.unit_code).ToList();

                FormTypeCollection = CollectionViewSource.GetDefaultView(MC.FormType);
                FormTypeCollection.Filter = new Predicate<object>(Filter_FormType);
                StringListFormtype = MC.FormType.Select(x => x.description).ToList();

                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                CollectionPlant = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                CollectionPlant.Filter = new Predicate<object>(FilterPlantA);
                stringListPlant = ObjSupply.Select(x => x.location_Id).ToList();

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);


                CurrancyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                MasterEntity.local_curr = CurrancyList[0].curr_code;

                NotificationDataCollection = MC.NotificationData;

                IncotermsCollection = CollectionViewSource.GetDefaultView(MC.Incoterms);
                IncotermsCollection.Filter = new Predicate<object>(Filter_Incoterms);
                StringListIncoterms = MC.Incoterms.Select(x => x.incoterms).ToList();

                LicenseEPCGCollection = CollectionViewSource.GetDefaultView(MC.LicenseEPCG);
                LicenseEPCGCollection.Filter = new Predicate<object>(Filter_EPCGLicense);
                StringListLicenseEPCG = MC.LicenseEPCG.Select(x => x.lic_cod).ToList();

                LicenseAdvanceCollection = CollectionViewSource.GetDefaultView(MC.LicenseAdvance);
                LicenseAdvanceCollection.Filter = new Predicate<object>(Filter_ADVANCELicense);
                StringListLicenseAdvance = MC.LicenseAdvance.Select(x => x.lic_cod).ToList();

                ServiceProviderCollection = CollectionViewSource.GetDefaultView(MC.ServiceProviders);
                ServiceProviderCollection.Filter = new Predicate<object>(Filter_ServiceProvider);
                stringListServiceProvider = MC.ServiceProviders.Select(x => x.PartyId).ToList();
                DefaultValues();
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
        private async void FilterItemSalesData(object InputValue)
        {
            try
            {

                PUR_T005_A ItemsEntityObject = null;

                if (((IEnumerable)InputValue).Cast<PUR_T005_A>().Count() > 0)
                {
                    ItemsEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_A>().ToList()[0];
                    SalesUnitPriceCollection.Clear();
                    SalesQFRCollection.Clear();
                    SalesDispatchCollection.Clear();
                    SalesProjDispatchCollection.Clear();

                    string Request1 = "GetItemPrice" + "!@" + ItemsEntityObject.ItemCode + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.po_no + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                    MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MultipleContext_PUR_T005>(MCTemp, Request1, "PurchaseInvoiceDebitCredit", "Procurement", "", 0, "GetItemPriceData");

                    if (ItemsEntity != null && MCTemp.UnitPriceList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.UnitPriceList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempUnitPrice = MCTemp.UnitPriceList;
                            SalesUnitPriceCollection = tempUnitPrice;
                        }
                    }

                    if (ItemsEntity != null && MCTemp.QFRList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.QFRList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempQFR = MCTemp.QFRList;
                            SalesQFRCollection = tempQFR.ToList();
                        }
                    }

                    if (ItemsEntity != null && MCTemp.DispatchList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.DispatchList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempDispatch = MCTemp.DispatchList;
                            SalesDispatchCollection = tempDispatch;
                        }
                    }

                    if (ItemsEntity != null && MCTemp.ProjectedDispList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.ProjectedDispList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempProj = MCTemp.ProjectedDispList;
                            SalesProjDispatchCollection = tempProj;
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
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            PUR_T005_A EntityObjectParameter = new PUR_T005_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<PUR_T005_A>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@!@!@" + EntityObjectParameter.ItemCode;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = EntityObjectParameter.ItemCode.Replace("/", "--"), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
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

        #region DefaultValues And validation
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "CB";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
            MasterEntity.doc_date = DateTime.Now;
            //MasterEntity.post_date = DateTime.Now;          
            MasterEntity.inv_rec_date = DateTime.Now;
            MasterEntity.entry_time = Convert.ToString(new TimeSpan());
            if (CurrancyList.Count > 0)
            {
                MasterEntity.local_currency = CurrancyList[0].curr_code;
            }
            Currency = AppSessionState.CntryCurncy;
            MasterEntity.Fltr_active = true;
            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            MasterEntity.Fltr_FrmDate = d;
            MasterEntity.Fltr_ToDate = DateTime.UtcNow;
        }
        private bool validation()
        {
            try
            {
                if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Doc Type.......");
                    showMessageService.ShowMessage();

                    return false;
                }

                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Party.......");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.post_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Posting Date.......");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.po_code == null || MasterEntity.po_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Purchase Organisation Code.......");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Purchase Group Code.......");
                    showMessageService.ShowMessage();

                    return false;
                }

                if (MasterEntity.curr_code == null || MasterEntity.curr_code == " ")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Currency Code..");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.local_currency == MasterEntity.curr_code)
                {
                    MasterEntity.exch_rate = 1;
                }
                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Transation Type is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.exch_rate == null || MasterEntity.exch_rate == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Exchange Rate");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.buss_place == null || MasterEntity.buss_place == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Business place is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (ItemsEntity.Count < 1)//when form is blank and we save the record
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("At Least Insert One Item........");
                    showMessageService.ShowMessage();

                    return false;
                }
                else
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.ItemCode != null && o.ItemCode != "" && o.item_desc != null)
                        {
                            int flag = 0;
                            if (o.id == 0)
                            {
                                foreach (var p in ItemsEntity)
                                {
                                    if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.ref_doc_no == p.ref_doc_no && o.po_no == p.po_no && p.active == true)
                                    {
                                        flag++;
                                    }
                                }
                                if (flag > 1)
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                            if (o.qty == null || o.qty == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                            if (o.unit_price == null || o.unit_price == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Unit Price cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                            if (o.tax_id != null || o.tax_id != "")
                            {
                                if (TotalDocumentTaxes.Count > 0)
                                {
                                    for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                                    {

                                        if (TotalDocumentTaxes[i].con_type == null || TotalDocumentTaxes[i].con_type == "")
                                        {

                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Message";
                                            showMessageService.Text = String.Format("Condition Type is Required for Tax {0} ", TotalDocumentTaxes[i].tax_name);
                                            showMessageService.ShowMessage();
                                            return false;

                                        }
                                    }
                                }

                            }

                        }
                        else
                        {

                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("please select Item ........");
                            showMessageService.ShowMessage();
                            return false;
                        }


                        #region . Parameter Validation .
                        // Validation For All Parameter Values Selected or Not

                        if (o.StockUnt == true && o.active == true)
                        {
                            var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                            if (paralist.Count > 0)
                            {
                                string[] SkuList = new string[100];           //string array
                                List<string> SkuListt = new List<string>();    // stringlist

                                if (o.sku != null && o.sku != "")
                                {
                                    SkuList = o.sku.Split('/');
                                    SkuListt = SkuList.ToList();

                                    foreach (var item in SkuList)
                                    {
                                        if (item == "")
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Parameter Validation";
                                            showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not.", o.ItemCode, ItemsEntity.IndexOf(o), SkuList.ToList().IndexOf(item));
                                            showMessageService.ShowMessage();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Parameter Validation";
                                    showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemsEntity.IndexOf(o));
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                        }
                    }

                    #endregion
                }
                if (MasterEntity.t_status == "017")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Invoice Validated...");
                    showMessageService.ShowMessage();
                    return false;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

            return true;

        }
        #endregion

        #region Relay Command Implementation


        private void UpdateQtyInLicence()
        {
            foreach (var m in LicenceDetailsEntity)
            {
                foreach (var o in ItemsEntity)
                {
                    if (o.ItemCode == m.ItemCode)
                    {
                        m.qty = o.qty;
                    }
                }
            }
        }
        private void InsertSupplierParty(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {

                        POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    if (String.IsNullOrEmpty(MasterEntity.doc_no) != true || String.IsNullOrWhiteSpace(MasterEntity.doc_no) != true) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (ItemsEntity.Count > 0 && NewRecord == false && AppSessionState.comp_code != "1")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change party'{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                        else
                        {
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.payee_name = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            //MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                            //ItemsEntity[dgSelectedIndexItem].recon_acc = POPUPEntityObject.recon_acc;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.exch_rate = 1;
                            }
                        }
                    }
                    else if (NewRecord == true && ItemsEntity.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Party Items Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                            MasterEntity.payee_name = POPUPEntityObject.PartyNm;
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.supplier_party_Nm = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            //ItemsEntity[dgSelectedIndexItem].recon_acc = POPUPEntityObject.recon_acc;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.exch_rate = 1;
                            }


                            RequestParameterData = "LoadFromSupplierPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, RequestParameterData, "PurchaseInvoice", "Procurement", "", 0, "");

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                            //New PopUP - Item Code in Data grid
                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemcode.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemdescr.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).MinQty.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).MaxQty.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_total.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).Reorder.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_reserve.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_unr.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_in_transit.ToString().ToLower().Contains(prefix);
                            //ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            //ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                            ItemsEntity.Clear();
                        }
                    }
                    else
                    {
                        MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                        MasterEntity.payee_name = POPUPEntityObject.PartyNm;
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.supplier_party_Nm = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        //ItemsEntity[dgSelectedIndexItem].recon_acc = POPUPEntityObject.recon_acc;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.exch_rate = 1;
                        }

                        RequestParameterData = "LoadFromSupplierPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.PartyId;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, RequestParameterData, "PurchaseInvoice", "Procurement", "", 0, "");

                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                        //New PopUP - Item Code in Data grid
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                        //TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemcode.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemdescr.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).MinQty.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).MaxQty.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_total.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).Reorder.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_reserve.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_unr.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_in_transit.ToString().ToLower().Contains(prefix);
                        //ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        //ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                        ItemsEntity.Clear();
                    }
                }
                var msg = new NotificationMessage("PUR_T005_DebitCredit_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertPayee(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                    MasterEntity.payee_name = POPUPEntityObject.PartyNm;
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
        private void InsertConditiontype(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_O_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ConditionTypeList.Where(x => x.con_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_O_P>().ToList()[0];
                    }
                }
                catch (Exception) { }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {


                            con_type = POPUPEntityObject.con_type,
                            trns_key_code = POPUPEntityObject.con_desc


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].con_type = POPUPEntityObject.con_type;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].trns_key_code = POPUPEntityObject.con_desc;

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
        private void InsertdgCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {


                            curr_code = POPUPEntityObject.curr_code


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].curr_code = POPUPEntityObject.curr_code;

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
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M007_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocTypeData.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M007_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M007_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
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
        private void InsertLicence(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M041_P POPUPEntityObject = null;
                dgSelectedIndexItemLicence = dgSelectedIndexItemLicence;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.LicenceList.Where(x => x.lic_cod.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                }

                #endregion


                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode select o).ToList();
                        temp[dgSelectedIndexItemLicence].licence_no = POPUPEntityObject.lic_cod;
                    }
                }
                #region Clear Empty Row
                ACC_T006_D newObj = new ACC_T006_D();
                for (int i = LicenceDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = LicenceDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (LicenceDetailsEntity[i].ComparePropertiesTo(newObj) == true && LicenceDetailsEntity.Count > 1)
                    {
                        LicenceDetailsEntity.RemoveAt(i);
                        if (LicenceDetailsEntity.Count == 0)
                        {
                            LicenceDetailsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
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
        private void InsertdgIncoterms(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M044_P POPUPEntityObject = null;
                dgSelectedIndexItemLicence = dgSelectedIndexItemLicence;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Incoterms.Where(x => x.incoterms.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M044_P>().ToList()[0];
                }

                #endregion


                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode select o).ToList();
                        temp[dgSelectedIndexItemLicence].incoterms = POPUPEntityObject.incoterms;
                    }
                }
                #region Clear Empty Row
                ACC_T006_D newObj = new ACC_T006_D();
                for (int i = LicenceDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = LicenceDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (LicenceDetailsEntity[i].ComparePropertiesTo(newObj) == true && LicenceDetailsEntity.Count > 1)
                    {
                        LicenceDetailsEntity.RemoveAt(i);
                        if (LicenceDetailsEntity.Count == 0)
                        {
                            LicenceDetailsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
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
        private void InsertBussPlace(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BussinessPlaceList.Where(x => x.buss_place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.plc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.buss_place = POPUPEntityObject.buss_place;
                    MasterEntity.plc_name = POPUPEntityObject.plc_name;
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
        private void InsertdgBussPlace(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BussinessPlaceList.Where(x => x.buss_place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.plc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (ItemsEntity.Count == dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {


                            buss_place = POPUPEntityObject.buss_place


                        });

                    }
                    else if (ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        ItemsEntity[dgSelectedIndexItem].buss_place = POPUPEntityObject.buss_place;

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
        private void InsertdgShipToParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {


                    if (ItemsEntity.Count == dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {


                            ship_to_Party = POPUPEntityObject.PartyId,
                            ship_to_add = POPUPEntityObject.ship_to_add


                        });

                    }
                    else if (ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        ItemsEntity[dgSelectedIndexItem].ship_to_Party = POPUPEntityObject.PartyId;
                        ItemsEntity[dgSelectedIndexItem].ship_to_add = POPUPEntityObject.ship_to_add;

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

        private void InsertReferenceDoc(object InputValue)
        {
            try
            {
                string Request = "";
                PUR_T005_P_RefDoc POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Purchase_Invoice_Reference.Where(x => x.Ref_DocNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PUR_T005_P_RefDoc>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_P_RefDoc>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                    ref_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;

                    if (ref_doc_cat == "GR")
                    {
                        Request = "LoadGRN" + "!@" + MasterEntity.ref_doc_no;
                    }
                    else if (ref_doc_cat == "PO")
                    {
                        Request = "LoadPO" + "!@" + MasterEntity.ref_doc_no;
                    }

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "FlipData");

                    if (MCTemp.ItemListPopup.Count > 0)
                    {
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemsEntity.Select(x => x.ItemCode).ToList();
                    }


                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PUR_T005_P_PI_ItemsList POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MCTemp.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_P_PI_ItemsList>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                    var LineId = ItemsEntity.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            item_desc = POPUPEntityObject.ItemName,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                            ref_doc_no = POPUPEntityObject.Ref_doc_no,
                            // ref_doc_type = MasterEntity.ref_doc_type,
                            ref_doc_type = String.IsNullOrEmpty(MasterEntity.ref_doc_no) ? "" : MasterEntity.ref_doc_type,
                            tax_id = POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            qty = POPUPEntityObject.qty,
                            subtotal = POPUPEntityObject.sub_total,
                            active = true,
                            line_id = LineId,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            item_cat = POPUPEntityObject.item_cat_id,
                            t_status = "001",
                            t_display = (from o in MC.t_statusList where o.t_status == "001" select o.t_display).FirstOrDefault(),
                            po_no = POPUPEntityObject.po_no,
                            //ship_to_Party = MasterEntity.ship_to_party,
                            //ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place

                        });

                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            if (ItemsEntity[dgSelectedIndexItem].line_id == 0)
                            {
                                ItemsEntity[dgSelectedIndexItem].line_id = ItemsEntity.Count;
                            }
                            ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].item_desc = POPUPEntityObject.ItemName;
                            ItemsEntity[dgSelectedIndexItem].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                            ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                            ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                            ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                            ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                            //ItemsEntity[dgSelectedIndexItem].line_id = 0;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_no = POPUPEntityObject.Ref_doc_no;
                            //ItemsEntity[dgSelectedIndexItem].ref_doc_type = MasterEntity.ref_doc_type;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_type = String.IsNullOrEmpty(MasterEntity.ref_doc_no) ? "" : MasterEntity.ref_doc_type;
                            ItemsEntity[dgSelectedIndexItem].tax_id = POPUPEntityObject.tax_id;
                            ItemsEntity[dgSelectedIndexItem].unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemsEntity[dgSelectedIndexItem].unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog;
                            ItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
                            ItemsEntity[dgSelectedIndexItem].subtotal = POPUPEntityObject.sub_total;
                            ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat_id;
                            ItemsEntity[dgSelectedIndexItem].po_no = POPUPEntityObject.po_no;
                            //ItemsEntity[dgSelectedIndexItem].ship_to_Party = MasterEntity.ship_to_party;
                            //ItemsEntity[dgSelectedIndexItem].ship_to_add = MasterEntity.del_address;
                            ItemsEntity[dgSelectedIndexItem].buss_place = MasterEntity.buss_place;
                            ItemsEntity[dgSelectedIndexItem].t_status = "001";
                            ItemsEntity[dgSelectedIndexItem].t_display = (from o in MC.t_statusList where o.t_status == ItemsEntity[dgSelectedIndexItem].t_status select o.t_display).FirstOrDefault();
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemsEntity[dgSelectedIndexItem].item_desc = "";
                        }


                    }
                }
                #region Clear Empty Row
                PUR_T005_A newObj = new PUR_T005_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M003_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.ItemCategoryList.Where(x => x.sditem_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.sditem_cat_code;
                }
                #region Clear Empty Row
                PUR_T005_A newObj = new PUR_T005_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
            }
            #endregion
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());
                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                PUR_T005_A newObj = new PUR_T005_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertwtUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }

                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].weight_unit = POPUPEntityObject.unit_code;
                            MasterEntity.para5 = POPUPEntityObject.unit_code;

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].weight_unit = "";
                        }
                    }
                }

                #region Clear Empty Row
                PUR_T005_A newObj = new PUR_T005_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertvolUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;


                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.volume_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.volume_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].volume_unit = POPUPEntityObject.unit_code;
                            MasterEntity.volume_unit = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].volume_unit = "";
                        }
                    }
                }

                #region Clear Empty Row
                PUR_T005_A newObj = new PUR_T005_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseOrg(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_M_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Purchase_orgList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseGroup(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Purchase_groupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPayTerm(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M007_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PayTerms.Where(x => x.p_term_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M007_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPayMethod(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M021_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PayMethod.Where(x => x.pay_method.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M021_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.pay_method = POPUPEntityObject.pay_method;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertSelectedTax(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.AccountList.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }
                catch (Exception) { }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {

                            gl_code = POPUPEntityObject.gl_code,
                            symbol = MasterEntity.symbol


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code = POPUPEntityObject.gl_code;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].symbol = MasterEntity.symbol;

                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request;
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.symbol = POPUPEntityObject.symbol;
                    if (MasterEntity.curr_code == Currency)
                    {
                        MasterEntity.exch_rate = 1;
                    }

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
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
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
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
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void InsertBank(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BankList.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                        }

                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.bank_code = POPUPEntityObject.bank_code;
                    MasterEntity.bank_name = POPUPEntityObject.bank_name;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertNastroBank(object InputValue)
        {
            try
            {

                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BankList.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.nastro_bank_cd = POPUPEntityObject.bank_code;
                    MasterEntity.nastro_bank_name = POPUPEntityObject.bank_name;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertCostCenter(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M019_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Cost_Centers.Where(x => x.cost_center.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M019_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M019_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cost_center = POPUPEntityObject.cost_center;
                    MasterEntity.cost_center_Desc = POPUPEntityObject.cost_center_Desc;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertJournal(object InputValue)
        {
            try
            {

                string Request = "";
                ACC_M005_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Journals.Where(x => x.j_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M005_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M005_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.j_code = POPUPEntityObject.j_code;
                    MasterEntity.j_name = POPUPEntityObject.j_name;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjSupply.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    //MasterEntity.PlantName = POPUPEntityObject.LoctnNm;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem);

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            Computation(true, dgSelectedIndexItem);
        }
        private void DeleteTax(object InputValue)
        {
            int i = (int)InputValue;
            if (TotalDocumentTaxes.Count > i)
            {
                //TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxes[i].tax_name).Single());
                List<ACC_T006_C> copyLocal = new List<ACC_T006_C>();
                copyLocal = TotalDocumentTaxes.ToList();
                foreach (var tax in copyLocal)
                {
                    if (tax.tax_name == TotalDocumentTaxes[i].tax_name && tax.manual == "Manual")
                    {
                        TotalDocumentTaxes.Remove(tax);
                    }
                }
                Computation(true, dgSelectedIndexItem);
            }
        }
        public List<PUR_T005_A> TempItemList { get; set; }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PUR_T005_Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {

                        if (MasterEntity.ref_doc_no == null || MasterEntity.ref_doc_no == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Refernece Selection";
                            showMessageService.Text = String.Format("Please Select Refernece No", this.Title);
                            showMessageService.ShowMessage();
                        }
                        else
                        {
                            if (ref_doc_cat == "PQ")
                            {
                                Request = "LoadFromInvoiceNo" + "!@" + MasterEntity.ref_doc_no;
                            }
                            else if (ref_doc_cat == "PO")
                            {
                                Request = "LoadDocumentFromPOReferneceNo" + "!@" + MasterEntity.ref_doc_no;
                            }
                            else if (ref_doc_cat == "MO")
                            {
                                Request = "LoadDocumentFromPOReferneceNo" + "!@" + MasterEntity.ref_doc_no;
                            }

                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoiceDebitCredit", "Procurement", "", 0, "FlipData");

                            if (MCTemp.MasterEntity.Count > 0)
                            {
                                MasterEntity = MCTemp.MasterEntity[0];
                            }
                            else
                            {
                                MasterEntity = new PUR_T005();
                            }
                            if (MCTemp.ItemsEntity.Count > 0)
                            {
                                ItemsEntity = MCTemp.ItemsEntity;
                            }
                            else
                            {
                                ItemsEntity = new ObservableCollection<PUR_T005_A>();
                            }

                            //int LineId = 1;
                            //foreach (var item in ItemsEntity)
                            //{
                            //    item.line_id = LineId;
                            //    LineId++;
                            //}

                            //TotalDocumentTaxes = MCTemp.TaxEntity;
                            if (TotalDocumentTaxes.Count() != '0')
                            {

                            }
                            else
                            {
                                MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                            }
                            if (MCTemp.LicenceEntity != null)
                            {
                                LicenceDetailsEntity.Clear();
                                LicenceDetailsEntity = MCTemp.LicenceEntity;
                            }
                            else
                            {
                                MCTemp.LicenceEntity = new ObservableCollection<ACC_T006_D>();
                            }
                            MC.ItemListPopup = MCTemp.ItemListPopup;
                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                            TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                                                       ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                            ASItemCode = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                            AttachmentCollection = MC.Attachment;

                            int count = ItemsEntity.Count();
                            TotalDocumentTaxes.Clear();
                            for (int i = 0; i < count; i++)
                            {
                                Computation(true, i);

                            }


                            DefaultValues();
                            QtyCalculation();
                            if (dgSelectedIndexItem != -1)
                            {
                                if (MasterEntity.loc_curr > 0)
                                {
                                    MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                                }
                            }
                            else
                            {
                                MasterEntity.amt_in_wordsLoc = "";
                            }
                            //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                            MasterEntity.local_curr = CurrancyList[0].curr_code;
                            if (PurchaseOrganisationList.Count != 0)
                            {
                                if (PurchaseOrganisationList.Count == 1)
                                {
                                    MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                                    MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                                }
                            }
                            else
                            {
                                MasterEntity.po_code = "";
                            }
                            if (PurchaseGroupList.Count != 0)
                            {
                                if (PurchaseGroupList.Count == 1)
                                {
                                    MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                                    MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                                }
                            }
                            else
                            {
                                MasterEntity.pg_code = "";
                            }
                            if (MasterEntity.local_currency == MasterEntity.curr_code)
                            {
                                MasterEntity.exch_rate = 1;
                            }
                        }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<PUR_T005_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PUR_T005_Flip>().ToList()[0];
                        NewRecord = false;
                        parameter = false;
                        MoveFlag = false;
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.doc_no + " !@" + ParameterEntityObject.PartyId + "!@" + AppSessionState.comp_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "");
                        MasterEntity = MCTemp.MasterEntity[0];
                        ItemsEntity = MCTemp.ItemsEntity;
                        //int LineId = 1;
                        //foreach (var item in ItemsEntity)
                        //{
                        //    item.line_id = LineId;
                        //    LineId++;
                        //}
                        TotalDocumentTaxes = MCTemp.TaxEntity;

                        if (TotalDocumentTaxes.Count() != '0')
                        {
                            TotalDocumentTaxes = MCTemp.TaxEntity;
                        }
                        else
                        {
                            MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                        }
                        if (MCTemp.LicenceEntity != null)
                        {
                            LicenceDetailsEntity.Clear();
                            LicenceDetailsEntity = MCTemp.LicenceEntity;
                        }
                        else
                        {
                            MCTemp.LicenceEntity = new ObservableCollection<ACC_T006_D>();
                        }
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                        TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                                                   ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                        ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                        NewRecord = false;
                        SelectedTabControlIndex = 0;
                        QtyCalculation();
                        if (dgSelectedIndexItem != -1)
                        {
                            if (MasterEntity.loc_curr > 0)
                            {
                                MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                            }
                        }
                        else
                        {
                            MasterEntity.amt_in_wordsLoc = "";
                        }
                        //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                        MasterEntity.local_curr = CurrancyList[0].curr_code;
                    }
                }
                Computation(true, dgSelectedIndexItem);
                SelectedTabControlIndex = 0;
                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("PUR_T005_DebitCredit_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASRefDocNo.AutoSuggestVM.Suggestion = RefDocTempData.Find(x => x.Ref_DocNo == MasterEntity.ref_doc_no);
            ASDocCurr.AutoSuggestVM.Suggestion = MC.CurrencyList.Find(x => x.curr_code == MasterEntity.curr_code);
            ASPlant.AutoSuggestVM.Suggestion = ObjSupply.Find(x => x.location_Id == MasterEntity.location_Id);
            ASPaymentTerm.AutoSuggestVM.Suggestion = MC.PayTerms.Find(x => x.p_term_code == MasterEntity.p_term_code);
            ASPaymentMethod.AutoSuggestVM.Suggestion = MCTemp.PayMethod.Find(x => x.pay_method == MasterEntity.pay_method);
            ASCompanyBank.AutoSuggestVM.Suggestion = MC.BankList.Find(x => x.bank_code == MasterEntity.bank_code);
            ASNastroBank.AutoSuggestVM.Suggestion = MC.BankList.Find(x => x.bank_code == MasterEntity.nastro_bank_cd);
            ASPurOrg.AutoSuggestVM.Suggestion = PurchaseOrganisationList.Find(x => x.po_code == MasterEntity.po_code);
            ASPurGrp.AutoSuggestVM.Suggestion = PurchaseGroupList.Find(x => x.pg_code == MasterEntity.pg_code);
            ASIncoTerms.AutoSuggestVM.Suggestion = MC.Incoterms.Find(x => x.incoterms == MasterEntity.incoterms);
            ASEPCG.AutoSuggestVM.Suggestion = MC.LicenseEPCG.Find(x => x.lic_cod == MasterEntity.lic_cod);
            ASAdvance.AutoSuggestVM.Suggestion = MC.LicenseAdvance.Find(x => x.lic_cod == MasterEntity.advance_lic);
            ASCFAgent.AutoSuggestVM.Suggestion = MC.ServiceProviders.Find(x => x.PartyId == MasterEntity.cf_agent_cd);
            ASCostCenter.AutoSuggestVM.Suggestion = MC.Cost_Centers.Find(x => x.cost_center == MasterEntity.cost_center);
            ASJournal.AutoSuggestVM.Suggestion = MC.Journals.Find(x => x.j_code == MasterEntity.j_code);

        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_PUR_T005_A != null)
                {
                    MC.ItemsEntity = (ObservableCollection<PUR_T005_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T005_A, MC.ItemsEntity);
                    ItemsEntity = MC.ItemsEntity;
                }
                else
                {
                    MC.ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    ItemsEntity.Clear();
                }
                if (MasterEntity.XmlDataDocument_ACC_T006_C != null)
                {
                    MC.TaxEntity = (ObservableCollection<ACC_T006_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_C, MC.TaxEntity);
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MC.TaxEntity;
                }
                else
                {
                    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                }
                if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<PUR_T005_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));

                }
                if (MasterEntity.XmlDataDocument_ACC_T006_D != null)
                {
                    MC.LicenceEntity = (ObservableCollection<ACC_T006_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_D, MC.LicenceEntity);
                    LicenceDetailsEntity.Clear();
                    LicenceDetailsEntity = MC.LicenceEntity;
                }
                else
                {
                    MC.LicenceEntity = new ObservableCollection<ACC_T006_D>();
                }
                QtyCalculation();
                if (dgSelectedIndexItem != -1)
                {
                    if (MasterEntity.loc_curr > 0)
                    {
                        MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                    }
                }
                else
                {
                    MasterEntity.amt_in_wordsLoc = "";
                }
                //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                MasterEntity.local_curr = CurrancyList[0].curr_code;

                MasterEntity.ts_code = ts_code_vm;
                RemoveRefDoc();
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
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.ref_doc_no != null)
                {
                    RefDocTempData.RemoveAll(X => X.Ref_DocNo == MasterEntity.ref_doc_no);
                    MC.Purchase_Invoice_Reference.RemoveAll(X => X.Ref_DocNo == MasterEntity.ref_doc_no);
                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData);
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Purchase_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();
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
        // below 4 methods are for Parameters and Parameter Values
        private void InsertCollectionChanged(IList DataList)
        {
            try
            {
                IList list = DataList as IList;
                int a = dgSelectedIndexItem;

                if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
                {
                    List<PUR_T005_A> SelectedRowlist = list.Cast<PUR_T005_A>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {

                                    dgselectedindex = dgSelectedIndexItem,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name

                                });
                            }
                            if (ItemsEntity[dgSelectedIndexItem].sku_desc != null)
                            {
                                SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                                foreach (var o in SelectedParaValueCollection)
                                {
                                    foreach (var p in MC.ParamValueList)
                                    {
                                        if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                        {
                                            o.value_code = p.value_code;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (ItemsEntity[dgSelectedIndexItem].id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
                {
                    List<PUR_T005_A> SelectedRowlist = list.Cast<PUR_T005_A>().ToList();
                    string[] TempSkuList = new string[100];
                    List<string> TempParaValueList = new List<string>();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        if (paramlist.Count > 0 && ItemsEntity[dgSelectedIndexItem].sku != "" && ItemsEntity[dgSelectedIndexItem].sku != null)
                        {
                            TempSkuList = ItemsEntity[dgSelectedIndexItem].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                paramlist[i].parametervalue = TempParaValueList[0];
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void GetSelectedParaValue(IList parameter)
        {
            try
            {
                IList list = parameter as IList;
                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
                int a = ParadgSelectedIndex;
                int b = dgSelectedIndexItem;
                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgSelectedIndexItem.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndexItem)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();
                        }
                        #endregion
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].id != 0)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void ItemDetailsSelectionChangedMethod(IList InputList)
        {
            try
            {
                IList list = InputList as IList;

                if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    List<PUR_T005_A> selectedlist = list.Cast<PUR_T005_A>().ToList();

                    if (selectedlist.Count > 0)
                    {

                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void GetSkuDescription()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    ItemsEntity[dgSelectedIndexItem].sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void CalculateSku()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku == null || ItemsEntity[dgSelectedIndexItem].sku == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else
                {
                    ItemsEntity[dgSelectedIndexItem].sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        private void Load()
        {
            if (MasterEntity.FrmDate != null && MasterEntity.ToDate != null)
            {
                string Request = "LoadFromDateToDate" + "!@" + Convert.ToDateTime(MasterEntity.FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.EmpId;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoiceDebitCredit", "Procurement", "LoadAll", 0, " ");
                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Date....", this.Title);
                showMessageService.ShowMessage();

            }
        }
        private List<PUR_T005_P_RefDoc> _RefDocTempData;
        public List<PUR_T005_P_RefDoc> RefDocTempData
        {
            get { return _RefDocTempData; }
            set
            {
                if (_RefDocTempData != value)
                {
                    _RefDocTempData = value;
                    RaisePropertyChanged("RefDocTempData");
                }
            }
        }
        private void InsertRefDoc(object InputValue)
        {
            try
            {
                if (MasterEntity.ref_doc_type == "Purchase Order")
                {
                    RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Purchase_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                    ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                    ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Goods Receipt Note")
                {
                    RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Purchase_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                    ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                    ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                }

                else if (MasterEntity.ref_doc_type == "Purchase Invoice")
                {
                    RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PQ" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Purchase_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                    ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                    ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Purchase Return Order")
                {
                    RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "MO" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferanceDocNo = MC.Purchase_Invoice_Reference.Select(x => x.Ref_DocNo).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                    ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                    ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                }

            }
            catch (Exception ex) { }


        }
        private void DeleteDataGridRow_ItemLicence(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (LicenceDetailsEntity.Count > i)
                {
                    LicenceDetailsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem);
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
        private void InsertIncoterms(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M044_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Incoterms.Where(x => x.incoterms.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M044_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.incoterms = POPUPEntityObject.incoterms;
                    MasterEntity.inco_desc = POPUPEntityObject.inco_desc;
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
        private void InsertLicenseAdvance(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M041_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.LicenseAdvance.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.advance_lic = POPUPEntityObject.lic_cod;
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
        private void InsertLicenseEPCG(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M041_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.LicenseEPCG.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.lic_cod = POPUPEntityObject.lic_cod;
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
        private void InsertServiceProvider(object InputValue, bool OverrideValue)
        {
            string Request = "";
            ADM_M028_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex)
            { }
            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.cf_agent_cd = POPUPEntityObject.PartyId;
                MasterEntity.cf_agent_name = POPUPEntityObject.PartyNm;
            }
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<PUR_T005_A> result)
        {
            NewRecord = true;
            parameter = false;
            MoveFlag = true;
            MasterEntity = new PUR_T005();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            ItemsEntity.Clear();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            //TotalDocumentTaxesSummury.Clear();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_C>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<PUR_T005_A> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<PUR_T005_A> result)
        {
            try
            {
                if (MasterEntity.doc_no != null && MasterEntity.doc_no != "")
                {
                    if (MasterEntity.t_status != "017")
                    {
                        string Request = "ValidateInvoice" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_no + "!@" + AppSessionState.UserID;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoiceDebitCredit", "Procurement", "LoadAll", 0, "");

                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            if (MCTemp.MasterEntity[0].t_status == "017")
                            {
                                MasterEntity.t_status = MCTemp.MasterEntity[0].t_status;
                                MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Invoice Validate Succesfully...");
                                showMessageService.ShowMessage();
                            }
                        }
                    }
                    else if (MasterEntity.t_status == "017")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice Validated...");
                        showMessageService.ShowMessage();
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

        protected override void OnFlipAction(InquiryActionResult<PUR_T005_A> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<PUR_T005_A> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<PUR_T005_A> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PUR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PUR_T005_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PUR_T005_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T005_A> result)
        {
            try
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
                    this.MasterEntity.CancelEdit();
                    string response = repository.Delete(MasterEntity.doc_no, "PurchaseInvoice", "Procurement");

                    MasterEntity = new PUR_T005();
                    ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    NewRecord = true;
                    parameter = false;
                    MoveFlag = true;
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

        protected override void OnSaveAction(InquiryActionResult<PUR_T005_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (MasterEntity.ref_doc_no == null || MasterEntity.ref_doc_no == "")
                {
                    MasterEntity.ref_doc_type = "";
                }
                if (MasterEntity.ind_trade == "L")
                {
                    MasterEntity.export_ind = "L";
                }
                else if (MasterEntity.ind_trade == "I")
                {
                    MasterEntity.export_ind = "E";
                }
                else
                {
                    MasterEntity.export_ind = "L";
                }
                if (validation() == true)
                {
                    MasterEntity.XmlDataDocument_PUR_T005_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_ACC_T006_D = obj.ObjectToXML(LicenceDetailsEntity);
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T005>(MasterEntity, "PurchaseInvoice", "Procurement");
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T005>(MasterEntity, "PurchaseInvoice", "Procurement");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    parameter = false;
                    MoveFlag = false;
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

        private void NotifyMessage(string AlertName)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();

                objNotifyData = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("[OVAL]", MasterEntity.roundup_total.ToString()),
                    new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                    new KeyValuePair<string, string>("[CUST]","M/s: " + MasterEntity.supplier_party_Nm),
                    new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                    new KeyValuePair<string, string>("[DOC]", MC.doc_typeList[0].doc_desc_user),
                    new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                    new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                    new KeyValuePair<string, string>("[Comp]","M/s: " + AppSessionState.CompanyName),
                    new KeyValuePair<string, string>("[Attn]",MC.NotificationData[0].EmpName),
                };
                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);

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

        #region Filter
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as PUR_T005_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.supplier_party_Nm != null && data.supplier_party_Nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }
        //Supplier party

        private string _filterString_Supplier;
        public string filterString_Supplier
        {
            get { return _filterString_Supplier; }
            set
            {
                _filterString_Supplier = value;
                RaisePropertyChanged("filterString_Supplier");
                FilterCollection_Supplier();
            }
        }
        private void FilterCollection_Supplier()
        {
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool Filter_SupplierParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString_Supplier))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Supplier.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Supplier.ToLower()));
                }
                return true;
            }
            return false;
        }
        //private string _filterString_Payee;
        //public string FilterString_Payee
        //{
        //    get { return _filterString_Payee; }
        //    set
        //    {
        //        _filterString_Payee = value;
        //        RaisePropertyChanged("FilterString_Payee");
        //        FilterCollection_payee();
        //    }
        //}
        //private void FilterCollection_payee()
        //{
        //    if (_payeeCollection != null)
        //    {
        //        _payeeCollection.Refresh();
        //    }
        //}
        //public bool Filter_Payee(object obj)
        //{
        //    var data = obj as ADM_M028_P;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(FilterString_Payee))
        //        {
        //            return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Payee.ToLower()) ||
        //                data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Payee.ToLower()));

        //        }
        //        return true;
        //    }
        //    return false;
        //}
        private string _FilterString_ReferenceDoc;
        public string FilterString_ReferenceDoc
        {
            get { return _FilterString_ReferenceDoc; }
            set
            {
                _FilterString_ReferenceDoc = value;
                RaisePropertyChanged("FilterString_ReferenceDoc");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceDoc()
        {
            if (_ReferenceDocCollection != null)
            {
                _ReferenceDocCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as PUR_T005_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.Ref_DocNo != null && data.Ref_DocNo.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_date != null && data.Ref_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_DocType != null && data.Ref_DocType.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())

                       );
                }
                return true;
            }
            return false;
        }
        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as PUR_T005_P_PI_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_ItemsListPopup))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.item_cat_id != null && data.item_cat_id.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_PurOrg;
        public string FilterString_PurOrg
        {
            get { return _filterString_PurOrg; }
            set
            {
                _filterString_PurOrg = value;
                RaisePropertyChanged("FilterString_PurOrg");
                FilterCollection_PurOrg();
            }
        }
        private void FilterCollection_PurOrg()
        {
            if (Purchase_OrgCollection != null)
            {
                Purchase_OrgCollection.Refresh();
            }
        }
        public bool Purorg_Filter(object obj)
        {
            var data = obj as ADM_M001_M_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PurOrg))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString_PurOrg.ToLower())) ||
                       (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString_PurOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_pur_grp;
        public string FilterString_pur_grp
        {
            get { return _filterString_pur_grp; }
            set
            {
                _filterString_pur_grp = value;
                RaisePropertyChanged("FilterString_pur_grp");
                FilterCollection_pur_grp();
            }
        }
        private void FilterCollection_pur_grp()
        {
            if (purchase_groupCollection != null)
            {
                purchase_groupCollection.Refresh();
            }
        }
        public bool Purchase_grp_Filter(object obj)
        {
            var data = obj as ADM_M001_P_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_pur_grp))
                {
                    return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString_pur_grp.ToLower())) ||
                        (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString_pur_grp.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_PayTerms;
        public string FilterString_PayTerms
        {
            get { return _filterString_PayTerms; }
            set
            {
                _filterString_PayTerms = value;
                RaisePropertyChanged("FilterString_PayTerms");
                FilterCollection_PayTerms();
            }
        }
        private void FilterCollection_PayTerms()
        {
            if (_payTermCollection != null)
            {
                _payTermCollection.Refresh();
            }
        }
        public bool Filter_PayTerms(object obj)
        {
            var data = obj as ACC_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PayTerms))
                {
                    return (data.p_term != null && data.p_term.ToString().ToLower().Contains(_filterString_PayTerms.ToLower()) ||
                        data.p_term_code != null && data.p_term_code.ToString().ToLower().Contains(_filterString_PayTerms.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_PayMethod;
        public string FilterString_PayMethod
        {
            get { return _filterString_PayMethod; }
            set
            {
                _filterString_PayMethod = value;
                RaisePropertyChanged("FilterString_PayTerms");
                FilterCollection_PayMethod();
            }
        }
        private void FilterCollection_PayMethod()
        {
            if (_paymethodCollection != null)
            {
                _paymethodCollection.Refresh();
            }
        }
        public bool Filter_PayMethod(object obj)
        {
            var data = obj as ACC_M021_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PayMethod))
                {
                    return (data.pay_code != null && data.pay_code.ToString().ToLower().Contains(_filterString_PayMethod.ToLower()) ||
                        data.pay_method != null && data.pay_method.ToString().ToLower().Contains(_filterString_PayMethod.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Currency;
        public string FilterString_Currency
        {
            get { return _filterString_Currency; }
            set
            {
                _filterString_Currency = value;
                RaisePropertyChanged("FilterString_Currency");
                FilterCollection_Currency();
            }
        }
        private void FilterCollection_Currency()
        {
            if (_currancyCollection != null)
            {
                _currancyCollection.Refresh();
            }
        }
        public bool Filter_Currency(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Currency))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_Currency.ToLower())) ||
                       (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_Currency.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_Banks;
        public string FilterString_Banks
        {
            get { return _filterString_Banks; }
            set
            {
                _filterString_Banks = value;
                RaisePropertyChanged("FilterString_Banks");
                FilterCollection_Banks();
            }
        }
        private void FilterCollection_Banks()
        {
            if (_bankCollection != null)
            {
                _bankCollection.Refresh();
            }
        }
        public bool Filter_Banks(object obj)
        {
            var data = obj as ACC_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Banks))
                {
                    return (data.bank_code != null && data.bank_code.ToString().ToLower().Contains(_filterString_Banks.ToLower()) ||
                         data.bank_name != null && data.bank_name.ToString().ToLower().Contains(_filterString_Banks.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        private string _filterString_Cost_Center;
        public string FilterString_Cost_Center
        {
            get { return _filterString_Cost_Center; }
            set
            {
                _filterString_Cost_Center = value;
                RaisePropertyChanged("FilterString_Cost_Center");
                FilterCollection_Cost_Center();
            }
        }
        private void FilterCollection_Cost_Center()
        {
            if (_cost_centerCollection != null)
            {
                _cost_centerCollection.Refresh();
            }
        }
        public bool Filter_Cost_Center(object obj)
        {
            var data = obj as ACC_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Cost_Center))
                {
                    return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_Cost_Center.ToLower())) ||
                        (data.cost_center_Desc != null && data.cost_center_Desc.ToString().ToLower().Contains(_filterString_Cost_Center.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_Journal;
        public string FilterString_Journal
        {
            get { return _filterString_Journal; }
            set
            {
                _filterString_Journal = value;
                RaisePropertyChanged("_filterString_Journal");
                FilterCollection_Journal();
            }
        }
        private void FilterCollection_Journal()
        {
            if (_journalCollection != null)
            {
                _journalCollection.Refresh();
            }
        }
        public bool Filter_Journal(object obj)
        {
            var data = obj as ACC_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Journal))
                {
                    return (data.j_name != null && data.j_name.ToString().ToLower().Contains(_filterString_Journal.ToLower()) ||
                         data.j_code != null && data.j_code.ToString().ToLower().Contains(_filterString_Journal.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_ItemCategory;
        public string FilterString_ItemCategory
        {
            get { return _filterString_ItemCategory; }
            set
            {
                _filterString_ItemCategory = value;
                RaisePropertyChanged("FilterString_ItemCategory");
                FilterCollection_ItemCategory();
            }
        }
        private void FilterCollection_ItemCategory()
        {
            if (_itemcategoryCollection != null)
            {
                _itemcategoryCollection.Refresh();
            }
        }
        public bool Filter_ItemCategory(object obj)
        {
            var data = obj as SYS_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCategory))
                {
                    return (data.item_cat_desc != null && data.item_cat_desc.ToString().ToLower().Contains(_filterString_ItemCategory.ToLower()));

                }
                return true;
            }
            return false;
        }
        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollection_UOM();
            }
        }
        private void FilterCollection_UOM()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()) ||
                          data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
                }
                return true;
            }
            return false;
        }
        #region Filters For Weight Uom
        private void FilterCollectionWtUom()
        {
            if (_WtUomCollection != null)
            {
                _WtUomCollection.Refresh();
            }
        }
        private string _filterStringWtUom;
        public string FilterStringWtUom
        {
            get { return _filterStringWtUom; }
            set
            {
                _filterStringWtUom = value;
                RaisePropertyChanged("FilterStringWtUom");
                FilterCollectionWtUom();
            }
        }
        public bool FilterCollectionWtUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWtUom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringWtUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters For Volume Uom
        private void FilterCollectionVolUom()
        {
            if (_VolUomCollection != null)
            {
                _VolUomCollection.Refresh();
            }
        }
        private string _filterStringVolUom;
        public string FilterStringVolUom
        {
            get { return _filterStringVolUom; }
            set
            {
                _filterStringVolUom = value;
                RaisePropertyChanged("FilterStringVolUom");
                FilterCollectionVolUom();
            }
        }
        public bool FilterCollectionVolUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringVolUom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringVolUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        private string _filterStringPlant_A;
        private void FilterCollectionPlantA()
        {
            if (_CollectionPlant != null)
            {
                _CollectionPlant.Refresh();
            }
        }
        public string FilterStringPlantA
        {
            get { return _filterStringPlant_A; }
            set
            {
                _filterStringPlant_A = value;
                RaisePropertyChanged("FilterStringPlantA");
                FilterCollectionPlantA();
            }
        }
        private void FilterLicenceDataGrid()
        {
            try
            {
                if (LicenceDetailsEntity != null && LicenceDetailsEntity.Count > 0 && dgSelectedIndexItem >= 0)
                {
                    DataGridViewFilter = CollectionViewSource.GetDefaultView(LicenceDetailsEntity);
                    DataGridViewFilter.Filter = adv => ((ACC_T006_D)adv).ItemCode.Equals(ItemsEntity[dgSelectedIndexItem].ItemCode);
                    DataGridViewFilter.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        public bool FilterPlantA(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant_A))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant_A.ToLower()) ||
                         data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringPlant_A.ToLower()));

                }
                return true;
            }
            return false;
        }
        private string _filterString_FormType;
        public string FilterString_FormType
        {
            get { return _filterString_FormType; }
            set
            {
                _filterString_FormType = value;
                RaisePropertyChanged("FilterString_FormType");
                FilterCollection_FormType();
            }
        }
        private void FilterCollection_FormType()
        {
            if (_FormTypeCollection != null)
            {
                _FormTypeCollection.Refresh();
            }
        }
        public bool Filter_FormType(object obj)
        {
            var data = obj as ACC_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FormType))
                {
                    return (data.description != null && data.description.ToString().ToLower().Contains(_filterString_FormType.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterString_TaxAccount;
        public string FilterString_TaxAccount
        {
            get { return _filterString_TaxAccount; }
            set
            {
                _filterString_TaxAccount = value;
                RaisePropertyChanged("FilterString_FormType");
                FilterCollection_TaxAccount();
            }
        }
        private void FilterCollection_TaxAccount()
        {
            if (_taxAccountollection != null)
            {
                _taxAccountollection.Refresh();
            }
        }
        public bool Filter_TaxAccount(object obj)
        {
            var data = obj as ACC_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FormType))
                {
                    return (data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString_FormType.ToLower()) ||
                   data.gl_name != null && data.gl_name.ToString().ToLower().Contains(_filterString_FormType.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterString_Incoterms;
        public string FilterString_Incoterms
        {
            get { return _filterString_Incoterms; }
            set
            {
                _filterString_Incoterms = value;
                RaisePropertyChanged("FilterString_Incoterms");
                FilterCollection_Incoterms();
            }
        }
        private void FilterCollection_Incoterms()
        {
            if (_incotermsCollection != null)
            {
                _incotermsCollection.Refresh();
            }
        }
        public bool Filter_Incoterms(object obj)
        {
            var data = obj as ADM_M044_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Incoterms))
                {
                    return (data.incoterms != null && data.incoterms.ToString().ToLower().Contains(_filterString_Incoterms.ToLower())) ||
                        (data.inco_desc != null && data.inco_desc.ToString().ToLower().Contains(_filterString_Incoterms.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ADVANCELicense;
        public string FilterString_ADVANCELicense
        {
            get { return _filterString_ADVANCELicense; }
            set
            {
                _filterString_ADVANCELicense = value;
                RaisePropertyChanged("FilterString_ADVANCELicense");
                FilterCollection_ADVANCELicense();
            }
        }
        private void FilterCollection_ADVANCELicense()
        {
            if (_licenseAdvanceCollection != null)
            {
                _licenseAdvanceCollection.Refresh();
            }
        }
        public bool Filter_ADVANCELicense(object obj)
        {
            var data = obj as ADM_M041_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ADVANCELicense))
                {
                    return (data.lic_cod != null && data.lic_cod.ToString().ToLower().Contains(_filterString_ADVANCELicense.ToLower())) ||
                        (data.lic_type != null && data.lic_type.ToString().ToLower().Contains(_filterString_ADVANCELicense.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_EPCGLicense;
        public string FilterString_EPCGLicense
        {
            get { return _filterString_ADVANCELicense; }
            set
            {
                _filterString_ADVANCELicense = value;
                RaisePropertyChanged("FilterString_EPCGLicense");
                FilterCollection_EPCGLicense();
            }
        }
        private void FilterCollection_EPCGLicense()
        {
            if (_licenseEPCGCollection != null)
            {
                _licenseEPCGCollection.Refresh();
            }
        }
        public bool Filter_EPCGLicense(object obj)
        {
            var data = obj as ADM_M041_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_EPCGLicense))
                {
                    return (data.lic_cod != null && data.lic_cod.ToString().ToLower().Contains(_filterString_EPCGLicense.ToLower())) ||
                        (data.lic_type != null && data.lic_type.ToString().ToLower().Contains(_filterString_EPCGLicense.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ServiceProvider;
        public string FilterString_ServiceProvider
        {
            get { return _filterString_ServiceProvider; }
            set
            {
                _filterString_ServiceProvider = value;
                RaisePropertyChanged("FilterString_ServiceProvider");
                FilterCollection_ServiceProvider();
            }
        }
        public void FilterCollection_ServiceProvider()
        {
            if (_serviceProviderCollection != null)
            {
                _serviceProviderCollection.Refresh();
            }
        }
        public bool Filter_ServiceProvider(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ServiceProvider))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_ServiceProvider.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_ServiceProvider.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region         
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "loc_curr")
                {

                    if (MasterEntity.loc_curr > 0)
                    {
                        MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                    }
                    else
                    {
                        MasterEntity.amt_in_wordsLoc = "";
                    }

                }
                if (sender.ToString() == "curr_code")
                {
                    if (MasterEntity.local_currency == MasterEntity.curr_code)
                    {
                        MasterEntity.exch_rate = 1;
                    }
                }
                //This will get called when the property of an object inside the collection changes
                this.ErrorExist = MasterEntity.HasErrors;
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }

        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount")
                {
                    Computation(true, dgSelectedIndexItem);//this is in use 
                    QtyCalculation();
                    UpdateQtyInLicence();
                }



                this.ErrorExist = MasterEntity.HasErrors;
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }

        #endregion

        #region TaxComputation Function
        private void Computation(bool Compute, int ItemRowIndex)
        {
            if (Compute == true)
            {
                decimal? PreviousTaxValueForBasePrice = 0;
                decimal? BasePrice = 0;
                decimal? TaxAmount = 0;
                decimal? BasicItemAmount = 0;
                decimal? TaxValue = 0;
                decimal? TaxtTotal = 0;
                decimal? UnTaxTotal = 0;
                decimal? GrandTotal = 0;

                decimal? net_value = 0;
                decimal? other_charges = 0;
                decimal? local_tax_amt = 0;
                decimal? local_total_amt = 0;
                decimal? local_round_up = 0;
                decimal? local_roundup_total = 0;
                decimal? local_net_value = 0;

                decimal? gross_value = 0;
                decimal? effective_value = 0;
                decimal? disc_amt = 0;

                decimal? gross_value_A = 0;
                decimal? effective_value_A = 0;
                decimal? discount_amt_A = 0;
                decimal? tax_amount_A = 0;
                decimal? net_value_A = 0;


                if (ItemsEntity != null && ItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                {
                    if (ItemsEntity[ItemRowIndex].qty >= 0 && ItemsEntity[ItemRowIndex].unit_price >= 0 && ItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                    {
                        if (ItemsEntity[ItemRowIndex].discount == null)
                        {
                            ItemsEntity[ItemRowIndex].discount = 0;
                        }
                        ItemsEntity[ItemRowIndex].subtotal = (ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price) - ((ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price) * (ItemsEntity[ItemRowIndex].discount / 100));
                        ItemsEntity[ItemRowIndex].local_subtotal = (ItemsEntity[ItemRowIndex].subtotal * MasterEntity.exch_rate);

                        discount_amt_A = ((ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price) - ItemsEntity[ItemRowIndex].subtotal);
                        ItemsEntity[ItemRowIndex].discount_amt = discount_amt_A;
                        ItemsEntity[ItemRowIndex].local_discount = (discount_amt_A * MasterEntity.exch_rate);

                        gross_value_A = (ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price);
                        ItemsEntity[ItemRowIndex].gross_value = gross_value_A;

                        // Code For Effective Value
                        effective_value_A = (ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price);
                        ItemsEntity[ItemRowIndex].effective_value = effective_value_A;

                        // Code For Net Value
                        ItemsEntity[ItemRowIndex].net_value = (ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price) - ((ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price) * (ItemsEntity[ItemRowIndex].discount / 100));
                    }
                    #region Calculate Taxes for New/Edited Items row.
                    if (!String.IsNullOrEmpty(ItemsEntity[ItemRowIndex].tax_id) && ItemsEntity[ItemRowIndex].active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                    {
                        #region Tax Not Null

                        List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                        string[] TaxArray = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                        foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                        {
                            foreach (ACC_M013_P PickTax in MC.TaxList)
                            {
                                if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                {
                                    TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                }
                            }
                        }

                        int?[] TaxListForBaseInclude = new int?[TaxListTemp.Count];
                        for (int i = 0; i < TaxListTemp.Count; i++) // Collect Taxes having property Include_base = true.
                        {
                            if (TaxListTemp[i].include_base_amount == true)
                            {
                                TaxListForBaseInclude[i] = (int?)TaxListTemp[i].id;
                            }
                        }
                        TaxListTemp = TaxListTemp.OrderBy(tax => tax.sequence).ToList(); // Set ascending order of Taxex by sequence column to get Base amount for next/current Tax. Base Amount = Sub Total + Previous Tax Amount. (Previous Tax= Having column Include_Base_amount = True)
                        if (TaxListTemp.Count > 0)
                        {
                            decimal? Temptax_amount_A = 0;
                            foreach (ACC_M013_P SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                            {
                                PreviousTaxValueForBasePrice = 0;
                                BasePrice = 0;
                                TaxAmount = 0;
                                BasicItemAmount = 0;
                                TaxValue = 0;
                                TaxtTotal = 0;
                                UnTaxTotal = 0;
                                GrandTotal = 0;

                                net_value = 0;
                                other_charges = 0;
                                local_tax_amt = 0;
                                local_total_amt = 0;
                                local_round_up = 0;
                                local_roundup_total = 0;
                                local_net_value = 0;

                                gross_value = 0;
                                effective_value = 0;
                                disc_amt = 0;
                                tax_amount_A = 0;
                                net_value_A = 0;

                                #region Percentage
                                if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                {
                                    if (SingleTax.Price_include == true)
                                    {
                                        TaxValue = (SingleTax.amount) / 100 + 1;
                                        BasePrice = ItemsEntity[ItemRowIndex].subtotal / TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = ItemsEntity[ItemRowIndex].subtotal - BasicItemAmount;
                                    }
                                    else if (SingleTax.Price_include == false)
                                    {
                                        TaxValue = (SingleTax.amount) / 100;
                                        if (TaxListForBaseInclude.Length > 0)
                                        {
                                            PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.manual == "Auto" && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                        }
                                        if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                        {
                                            BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.manual == "Auto" && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_row_id == ItemsEntity[ItemRowIndex].id).Single().tax_amount;
                                        }
                                        else // Collect Base Price for this parent Tax.
                                        {
                                            BasePrice = ItemsEntity[ItemRowIndex].subtotal + PreviousTaxValueForBasePrice;
                                        }
                                        BasicItemAmount = ItemsEntity[ItemRowIndex].subtotal;
                                        TaxAmount = BasePrice * TaxValue;
                                    }
                                }
                                #endregion
                                #region Fixed Amount
                                else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                {
                                    TaxValue = SingleTax.amount;
                                    if (SingleTax.Price_include == true)
                                    {
                                        BasePrice = ItemsEntity[ItemRowIndex].subtotal - TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = ItemsEntity[ItemRowIndex].subtotal - BasicItemAmount;
                                    }
                                    else if (SingleTax.Price_include == false)
                                    {
                                        BasePrice = ItemsEntity[ItemRowIndex].subtotal;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = TaxValue;
                                    }
                                }
                                #endregion
                                #region Insert/Update Tax
                                int TaxIndex = 0;
                                var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && (T.item_line_id ?? 0) == ItemsEntity[ItemRowIndex].line_id && T.item_row_id == ItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                TaxIndex = TotalDocumentTaxes.IndexOf(TaxVar);
                                if (TaxVar != null && TaxIndex >= 0)
                                {
                                    TotalDocumentTaxes[TaxIndex].manual = "Auto";
                                    TotalDocumentTaxes[TaxIndex].active = true;
                                    TotalDocumentTaxes[TaxIndex].tax_amount = TaxAmount;
                                    TotalDocumentTaxes[TaxIndex].account_id = 0;
                                    TotalDocumentTaxes[TaxIndex].sequence = SingleTax.sequence;
                                    TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.doc_no;
                                    TotalDocumentTaxes[TaxIndex].base_amount = BasePrice;
                                    TotalDocumentTaxes[TaxIndex].amount = SingleTax.amount;
                                    TotalDocumentTaxes[TaxIndex].tax_code_id = SingleTax.id;
                                    TotalDocumentTaxes[TaxIndex].account_analytic_id = 0;
                                    TotalDocumentTaxes[TaxIndex].base_code_id = SingleTax.id;
                                    TotalDocumentTaxes[TaxIndex].tax_name = SingleTax.description;
                                    TotalDocumentTaxes[TaxIndex].ItemCode = ItemsEntity[ItemRowIndex].ItemCode;
                                    TotalDocumentTaxes[TaxIndex].sku = ItemsEntity[ItemRowIndex].sku;
                                    TotalDocumentTaxes[TaxIndex].item_row_id = ItemsEntity[ItemRowIndex].id;
                                    TotalDocumentTaxes[TaxIndex].item_line_id = ItemsEntity[ItemRowIndex].line_id;
                                    //TotalDocumentTaxes[TaxIndex].fin_year = SingleTax.FinYear;
                                    TotalDocumentTaxes[TaxIndex].location_Id = MasterEntity.location_Id;
                                    TotalDocumentTaxes[TaxIndex].comp_code = MasterEntity.comp_code;
                                    TotalDocumentTaxes[TaxIndex].posting_period = MasterEntity.posting_period;
                                    TotalDocumentTaxes[TaxIndex].trns_key_code = "PTX";

                                    TotalDocumentTaxes[TaxIndex].con_value = TaxAmount;
                                    TotalDocumentTaxes[TaxIndex].tax_code = SingleTax.tax_code;
                                    TotalDocumentTaxes[TaxIndex].PartyId = MasterEntity.PartyId;
                                    TotalDocumentTaxes[TaxIndex].exch_rate = MasterEntity.exch_rate;
                                    TotalDocumentTaxes[TaxIndex].client = AppSessionState.client;
                                    TotalDocumentTaxes[TaxIndex].symbol = MasterEntity.symbol;
                                    TotalDocumentTaxes[TaxIndex].local_curr = AppSessionState.CntryCurncy;
                                }
                                else
                                {
                                    TotalDocumentTaxes.Add(new ACC_T006_C()
                                    {
                                        id = 0,
                                        tax_amount = TaxAmount,
                                        account_id = 0,
                                        sequence = SingleTax.sequence,
                                        doc_no = MasterEntity.doc_no,
                                        manual = "Auto",
                                        base_amount = BasePrice,
                                        amount = SingleTax.amount,
                                        tax_code_id = SingleTax.id,
                                        account_analytic_id = 0,
                                        base_code_id = SingleTax.id,
                                        tax_name = SingleTax.description,
                                        ItemCode = ItemsEntity[ItemRowIndex].ItemCode,
                                        sku = ItemsEntity[ItemRowIndex].sku,
                                        item_row_id = ItemsEntity[ItemRowIndex].id,
                                        item_line_id = ItemsEntity[ItemRowIndex].line_id,
                                        //fin_year = AppSessionState.FinYear,
                                        active = true,
                                        posting_period = MasterEntity.posting_period,
                                        location_Id = AppSessionState.location_Id,
                                        comp_code = AppSessionState.comp_code,
                                        trns_key_code = "PTX",

                                        con_value = TaxAmount,
                                        tax_code = SingleTax.tax_code,
                                        PartyId = MasterEntity.PartyId,
                                        exch_rate = MasterEntity.exch_rate,
                                        client = AppSessionState.client,
                                        symbol = MasterEntity.symbol,
                                        local_curr = AppSessionState.CntryCurncy
                                    });
                                }

                                #endregion
                                Temptax_amount_A = Temptax_amount_A + TaxAmount;
                                tax_amount_A = Temptax_amount_A;

                                ItemsEntity[ItemRowIndex].tax_amount = tax_amount_A;
                                net_value_A = gross_value_A - discount_amt_A + tax_amount_A;
                                ItemsEntity[ItemRowIndex].net_value = net_value_A;
                                ItemsEntity[ItemRowIndex].local_net_value = (net_value_A * MasterEntity.exch_rate);


                            }
                        }

                        #endregion

                        #region Remove Excluded Taxes.
                        string[] TaxArray2 = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            bool DeleteFlag = true;
                            foreach (string SingleTax in TaxArray2)
                            {
                                if ((tax.tax_code_id.ToString() == SingleTax && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto") || tax.manual == "Manual")
                                {
                                    DeleteFlag = false;
                                    break;
                                }
                            }
                            if (!DeleteFlag) continue;
                            var ChildTaxVar = MC.TaxList.FirstOrDefault(T => T.id == tax.tax_code_id);
                            if (ChildTaxVar.parent_id != null)
                            {
                                bool CheckChildParentFlag = true;
                                foreach (string SingleTax in TaxArray2)
                                {
                                    if (ChildTaxVar.parent_id.ToString() == SingleTax && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                    {
                                        CheckChildParentFlag = false;
                                        break;
                                    }
                                }
                                if (!CheckChildParentFlag) continue;
                                //var ParentTaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == ChildTaxVar.parent_id && T.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && T.line_id == ItemsEntity[ItemRowIndex].line_id && T.item_line_id == ItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                //if (ParentTaxVar == null)

                                if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                            else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                            {
                                TotalDocumentTaxes.Remove(tax);
                            }
                        }

                        #endregion

                        effective_value_A = net_value_A;
                        ItemsEntity[ItemRowIndex].effective_value = effective_value_A;
                    }
                    else //if (ItemsEntity[ItemRowIndex].tax_id != null && ItemsEntity[ItemRowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                            {
                                if (tax.id == 0)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                                else
                                {
                                    int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (X.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && X.item_line_id == ItemsEntity[ItemRowIndex].line_id && X.item_row_id == ItemsEntity[ItemRowIndex].id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                    if (Index >= 0)
                                    {
                                        TotalDocumentTaxes.ElementAt(Index).active = false;
                                    }
                                }
                            }
                        }

                        //Code by kalpesh
                        //for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                        //{
                        //    if (TotalDocumentTaxes[i].ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (TotalDocumentTaxes[i].sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && TotalDocumentTaxes[i].item_line_id == ItemsEntity[ItemRowIndex].line_id && TotalDocumentTaxes[i].item_row_id == ItemsEntity[ItemRowIndex].id && TotalDocumentTaxes[i].manual == "Auto")
                        //    {
                        //        if (TotalDocumentTaxes[i].id == 0)
                        //        {
                        //            TotalDocumentTaxes.RemoveAt(i);                                    
                        //        }
                        //        else
                        //        {
                        //            TotalDocumentTaxes[i].active = false;
                        //        }
                        //    }
                        //}

                        //Code ends here

                    }
                    #region Final Computation

                    //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                    TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                    MasterEntity.tax_amount = TaxtTotal;
                    MasterEntity.tax_amount = TaxtTotal;

                    local_tax_amt = (TaxtTotal * MasterEntity.exch_rate);
                    MasterEntity.local_tax_amount = local_tax_amt;

                    //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                    UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                    MasterEntity.acc_amount = UnTaxTotal;


                    net_value = UnTaxTotal + TaxtTotal;
                    MasterEntity.net_value = net_value;
                    other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                    MasterEntity.other_charges = other_charges;

                    local_net_value = (net_value * MasterEntity.exch_rate);
                    MasterEntity.local_net_value = local_net_value;

                    GrandTotal = net_value + other_charges;
                    MasterEntity.total = GrandTotal;

                    local_total_amt = (GrandTotal * MasterEntity.exch_rate);
                    MasterEntity.local_total = local_total_amt;

                    MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                    local_roundup_total = (MasterEntity.roundup_total * MasterEntity.exch_rate);
                    MasterEntity.local_roundup_total = local_roundup_total;

                    MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                    local_round_up = (MasterEntity.round_up * MasterEntity.exch_rate);
                    MasterEntity.local_round_up = local_round_up;

                    gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price);
                    MasterEntity.gross_value = gross_value;

                    effective_value = GrandTotal;
                    MasterEntity.effective_value = effective_value;

                    disc_amt = gross_value - UnTaxTotal;
                    MasterEntity.disc_amt = disc_amt;

                    if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                    {
                        ADM_M037 curr_obj = new ADM_M037();
                        curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                        MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                    }
                    else
                    { MasterEntity.amt_word = ""; }

                    //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                    //                      group wo by wo.tax_name
                    //            into g
                    //                      select new ACC_T006_C
                    //                      {
                    //                          id = g.First().id,
                    //                          tax_amount = g.Sum(wo => wo.tax_amount),
                    //                          base_amount = g.Sum(wo => wo.base_amount),
                    //                          tax_code_id = g.First().tax_code_id,
                    //                          tax_name = g.First().tax_name,
                    //                          gl_code = g.First().gl_code,
                    //                          active = g.First().active,
                    //                          account_id = g.First().account_id,
                    //                      };
                    //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                    #endregion
                    #endregion
                }
            }
        }
        private void TaxComputation_old(bool Compute)
        {
            try
            {
                if (Compute == true)
                {
                    decimal? PreviousTaxValueForBasePrice = 0;
                    decimal? BasePrice = 0;
                    decimal? TaxAmount = 0;
                    decimal? BasicItemAmount = 0;
                    decimal? TaxValue = 0;
                    decimal? TaxtTotal = 0;
                    decimal? UnTaxTotal = 0;
                    decimal? GrandTotal = 0;

                    if (ItemsEntity != null && ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].qty > 0 && ItemsEntity[dgSelectedIndexItem].unit_price > 0 && ItemsEntity[dgSelectedIndexItem].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[dgSelectedIndexItem].discount == null || ItemsEntity[dgSelectedIndexItem].discount.ToString().Trim() == "")
                            {
                                ItemsEntity[dgSelectedIndexItem].discount = 0;
                            }
                            ItemsEntity[dgSelectedIndexItem].subtotal = (ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price) - ((ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price) * (ItemsEntity[dgSelectedIndexItem].discount / 100));
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && dgItemsEntity[dgSelectedIndexItem].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (ItemsEntity[dgSelectedIndexItem].tax_id != null && ItemsEntity[dgSelectedIndexItem].active == true) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        {
                            if (!String.IsNullOrEmpty(ItemsEntity[dgSelectedIndexItem].tax_id.Trim()) && ItemsEntity[dgSelectedIndexItem].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_C> copy = new List<ACC_T006_C>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                #region Tax Not Null

                                List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                                string[] TaxArray = ItemsEntity[dgSelectedIndexItem].tax_id.Trim().Split(',');
                                foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                                {
                                    foreach (ACC_M013_P PickTax in MC.TaxList)
                                    {
                                        if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                        {
                                            TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                        }
                                    }
                                }
                                // pending check index
                                int?[] TaxListForBaseInclude = new int?[TaxListTemp.Count];
                                for (int i = 0; i < TaxListTemp.Count; i++) // Collect Taxes having property Include_base = true.
                                {
                                    if (TaxListTemp[i].include_base_amount == true)
                                    {
                                        TaxListForBaseInclude[i] = (int?)TaxListTemp[i].id;
                                    }
                                }
                                TaxListTemp = TaxListTemp.OrderBy(tax => tax.sequence).ToList(); // Set ascending order of Taxex by sequence column to get Base amount for next/current Tax. Base Amount = Sub Total + Previous Tax Amount. (Previous Tax= Having column Include_Base_amount = True)
                                if (TaxListTemp.Count > 0)
                                {
                                    foreach (ACC_M013_P SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                                    {
                                        PreviousTaxValueForBasePrice = 0;
                                        BasePrice = 0;
                                        TaxAmount = 0;
                                        BasicItemAmount = 0;
                                        TaxValue = 0;
                                        TaxtTotal = 0;
                                        UnTaxTotal = 0;
                                        GrandTotal = 0;
                                        #region Percentage
                                        if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                        {
                                            if (SingleTax.Price_include == true)
                                            {
                                                TaxValue = (SingleTax.amount) / 100 + 1;
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[dgSelectedIndexItem].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = ItemsEntity[dgSelectedIndexItem].subtotal;
                                                TaxAmount = BasePrice * TaxValue;
                                            }
                                        }
                                        #endregion
                                        #region Fixed Amount
                                        else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                        {
                                            TaxValue = SingleTax.amount;
                                            if (SingleTax.Price_include == true)
                                            {
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[dgSelectedIndexItem].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion

                                        TotalDocumentTaxes.Add(new ACC_T006_C() { id = 0, tax_amount = TaxAmount, account_id = 0, sequence = SingleTax.sequence, doc_no = MasterEntity.doc_no, manual = "Auto", base_amount = BasePrice, amount = SingleTax.amount, tax_code_id = SingleTax.id, account_analytic_id = 0, base_code_id = SingleTax.id, tax_name = SingleTax.description, gl_code = "", ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode, sku = ItemsEntity[dgSelectedIndexItem].sku, item_line_id = ItemsEntity[dgSelectedIndexItem].id, fin_year = "2016", active = true, location_Id = AppSessionState.location_Id, comp_code = AppSessionState.comp_code });
                                    }

                                }

                                #endregion


                            }
                            else if (ItemsEntity[dgSelectedIndexItem].tax_id == "" || ItemsEntity[dgSelectedIndexItem].tax_id == null || ItemsEntity[dgSelectedIndexItem].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                            {
                                List<ACC_T006_C> copy2 = new List<ACC_T006_C>();
                                copy2 = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy2)
                                {
                                    if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                            }
                        }

                        else if (ItemsEntity[dgSelectedIndexItem].tax_id != null && ItemsEntity[dgSelectedIndexItem].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_C> copy2 = new List<ACC_T006_C>();
                            copy2 = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy2)
                            {
                                if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }
                        #region Final Computation

                        TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        //UnTaxTotal = dgItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.acc_amount = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.total = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;

                        if (MasterEntity.exch_rate == null && MasterEntity.exch_rate <= 0)
                        {
                            MasterEntity.exch_rate = 1;
                        }
                        MasterEntity.loc_curr = (Convert.ToDecimal(MasterEntity.roundup_total) * Convert.ToDecimal(MasterEntity.exch_rate));

                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_word = ""; }

                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name  // tax_code_id replace with tax_name due to manual Tax integration.
                        //            into g
                        //                      select new PUR_T002_D
                        //                      {
                        //                          id = g.First().id,
                        //                          tax_amount = g.Sum(wo => wo.tax_amount),
                        //                          base_amount = g.Sum(wo => wo.base_amount),
                        //                          tax_code_id = g.First().tax_code_id,
                        //                          tax_name = g.First().tax_name,
                        //                          gl_code = g.First().gl_code,
                        //                          active = g.First().active,
                        //                          account_id = g.First().account_id,
                        //                      };
                        //TotalDocumentTaxesSummury = new ObservableCollection<PUR_T002_D>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void TaxComputationOnReferance_old(bool Compute, int RowIndex)
        {
            try
            {
                if (Compute == true)
                {
                    decimal? PreviousTaxValueForBasePrice = 0;
                    decimal? BasePrice = 0;
                    decimal? TaxAmount = 0;
                    decimal? BasicItemAmount = 0;
                    decimal? TaxValue = 0;
                    decimal? TaxtTotal = 0;
                    decimal? UnTaxTotal = 0;
                    decimal? GrandTotal = 0;

                    if (ItemsEntity != null && ItemsEntity.Count > 0 && RowIndex >= 0 && RowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[RowIndex].qty >= 0 && ItemsEntity[RowIndex].unit_price >= 0 && ItemsEntity[RowIndex].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[RowIndex].discount == null || ItemsEntity[RowIndex].discount.ToString().Trim() == "")
                            {
                                ItemsEntity[RowIndex].discount = 0;
                            }
                            ItemsEntity[RowIndex].subtotal = (ItemsEntity[RowIndex].qty * ItemsEntity[RowIndex].unit_price) - ((ItemsEntity[RowIndex].qty * ItemsEntity[RowIndex].unit_price) * (ItemsEntity[RowIndex].discount / 100));
                            // ItemsEntity[RowIndex].subtotal = ItemsEntity[RowIndex].qty * ItemsEntity[RowIndex].unit_price;
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && ItemsEntity[RowIndex].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (ItemsEntity[RowIndex].tax_id != null && ItemsEntity[RowIndex].active == true) // Remove previously assign Taxes from TotalDocumentTaxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null  and Active status is true.
                        {
                            if (!String.IsNullOrEmpty(ItemsEntity[RowIndex].tax_id.Trim()) && ItemsEntity[RowIndex].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_C> copy = new List<ACC_T006_C>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                #region Tax Not Null

                                List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                                string[] TaxArray = ItemsEntity[RowIndex].tax_id.Trim().Split(',');
                                foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                                {
                                    foreach (ACC_M013_P PickTax in MC.TaxList)
                                    {
                                        if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                        {
                                            TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                        }
                                    }
                                }
                                // pending check index
                                int?[] TaxListForBaseInclude = new int?[TaxListTemp.Count];
                                for (int i = 0; i < TaxListTemp.Count; i++) // Collect Taxes having property Include_base = true.
                                {
                                    if (TaxListTemp[i].include_base_amount == true)
                                    {
                                        TaxListForBaseInclude[i] = (int?)TaxListTemp[i].id;
                                    }
                                }
                                TaxListTemp = TaxListTemp.OrderBy(tax => tax.sequence).ToList(); // Set ascending order of Taxex by sequence column to get Base amount for next/current Tax. Base Amount = Sub Total + Previous Tax Amount. (Previous Tax= Having column Include_Base_amount = True)
                                if (TaxListTemp.Count > 0)
                                {
                                    foreach (ACC_M013_P SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                                    {
                                        PreviousTaxValueForBasePrice = 0;
                                        BasePrice = 0;
                                        TaxAmount = 0;
                                        BasicItemAmount = 0;
                                        TaxValue = 0;
                                        TaxtTotal = 0;
                                        UnTaxTotal = 0;
                                        GrandTotal = 0;
                                        #region Percentage
                                        if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                        {
                                            if (SingleTax.Price_include == true)
                                            {
                                                TaxValue = (SingleTax.amount) / 100 + 1;
                                                BasePrice = ItemsEntity[RowIndex].subtotal / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[RowIndex].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku && tax.item_line_id == ItemsEntity[RowIndex].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku && tax.item_line_id == ItemsEntity[RowIndex].id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = ItemsEntity[RowIndex].subtotal + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = ItemsEntity[RowIndex].subtotal;
                                                TaxAmount = BasePrice * TaxValue;
                                            }
                                        }
                                        #endregion
                                        #region Fixed Amount
                                        else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                        {
                                            TaxValue = SingleTax.amount;
                                            if (SingleTax.Price_include == true)
                                            {
                                                BasePrice = ItemsEntity[RowIndex].subtotal - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[RowIndex].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = ItemsEntity[RowIndex].subtotal;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion

                                        TotalDocumentTaxes.Add(new ACC_T006_C() { id = 0, tax_amount = TaxAmount, account_id = 0, sequence = SingleTax.sequence, doc_no = MasterEntity.doc_no, manual = "Auto", base_amount = BasePrice, amount = SingleTax.amount, tax_code_id = SingleTax.id, account_analytic_id = 0, base_code_id = SingleTax.id, tax_name = SingleTax.description, gl_code = "", ItemCode = ItemsEntity[RowIndex].ItemCode, sku = ItemsEntity[RowIndex].sku, item_line_id = ItemsEntity[RowIndex].id, fin_year = "2015", active = true, location_Id = AppSessionState.location_Id, comp_code = AppSessionState.comp_code });
                                    }

                                }

                                #endregion
                            }
                        }
                        else if (ItemsEntity[RowIndex].tax_id != null && ItemsEntity[RowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_C> copy2 = new List<ACC_T006_C>();
                            copy2 = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy2)
                            {
                                if (tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }
                        #region Final Computation
                        TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        //UnTaxTotal = dgItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.acc_amount = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.total = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        if (MasterEntity.exch_rate == null && MasterEntity.exch_rate <= 0)
                        {
                            MasterEntity.exch_rate = 1;
                        }
                        MasterEntity.loc_curr = (Convert.ToDecimal(MasterEntity.roundup_total) * Convert.ToDecimal(MasterEntity.exch_rate));

                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_word = ""; }

                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name // tax_code_id replace with tax_name due to manual Tax integration.
                        //            into g
                        //                      select new SEL_T003_C
                        //                      {
                        //                          id = g.First().id,
                        //                          tax_amount = g.Sum(wo => wo.tax_amount),
                        //                          base_amount = g.Sum(wo => wo.base_amount),
                        //                          tax_code_id = g.First().tax_code_id,
                        //                          tax_name = g.First().tax_name,
                        //                          gl_code = g.First().gl_code,
                        //                          active = g.First().active,
                        //                          account_id = g.First().account_id,
                        //                      };
                        //TotalDocumentTaxes = new ObservableCollection<SEL_T003_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }


                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        private void QtyCalculation()
        {
            try
            {
                TotalQty = Convert.ToDecimal(ItemsEntity.Where(item => item.active != false).Sum(item => item.qty));
                TotalRate = Convert.ToDecimal(ItemsEntity.Where(item => item.active != false).Sum(item => item.unit_price));
                TotalValuation = TotalQty * TotalRate;
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }


        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_C item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_C item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_C item in e.NewItems)
                    {

                        if (item.tax_code_id > 0)
                        { item.manual = "Auto"; item.con_type = "TAXC"; }
                        else { item.manual = "Manual"; item.sequence = 100; }
                        if (item.tax_name == null || item.tax_name.Trim() == "")
                        { item.tax_name = "CASH"; }
                        item.active = true;
                        item.symbol = MasterEntity.symbol;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                        item.exch_rate = MasterEntity.exch_rate;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;

                        item.client = AppSessionState.client;
                        item.exch_rate = MasterEntity.exch_rate;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
                int c = TotalDocumentTaxes.Count();
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void CollectionChangedNotifyForLicence(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_D item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_D item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_D item in e.NewItems)
                    {
                        item.ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode;
                        item.sku = ItemsEntity[dgSelectedIndexItem].sku;
                        item.item_line_id = ItemsEntity[dgSelectedIndexItem].line_id;
                        item.order_no = MasterEntity.po_no;
                        item.ref_doc_no = MasterEntity.ref_doc_no;
                        item.ref_doc_type = MasterEntity.ref_doc_type;
                        item.ref_doc_date = MasterEntity.ref_date;

                        item.qty = ItemsEntity[dgSelectedIndexItem].qty;
                        item.incoterm_value_doc = ItemsEntity[dgSelectedIndexItem].net_value;
                        item.incoterm_value_local = ItemsEntity[dgSelectedIndexItem].local_net_value;
                        item.PartyId = MasterEntity.PartyId;
                        item.exch_rate = MasterEntity.exch_rate;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.active = true;
                        item.con_type = "LIC";
                        item.trns_key_code = "LIC";
                        item.incoterms = MasterEntity.incoterms;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex) { }

        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T005_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T005_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T005_A item in e.NewItems)
                    {

                        //Added items
                        item.symbol = MasterEntity.symbol;
                        item.PropertyChanged += EntityViewModelPropertyChanged;


                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }

                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = MasterEntity.HasErrors;
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T005_A temp = (PUR_T005_A)e.OldItems[0];
                    ////foreach (var itemToRemove in ItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && x.sku == temp.sku)).ToList())
                    ////{
                    ////    ItemScheduleEntity.Remove(itemToRemove);
                    ////}
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && (tax.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? "") && tax.item_row_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                                Computation(true, dgSelectedIndexItem);
                            }
                        }

                    }



                    foreach (PUR_T005_A item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount")
                {
                    Computation(true, dgSelectedIndexItem);
                }
                if (e.PropertyName == "gross_wt")
                {
                    MasterEntity.gross_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.gross_wt);
                }
                if (e.PropertyName == "volume")
                {
                    MasterEntity.volume = ItemsEntity.Where(item => item.active != false).Sum(item => item.volume);
                }
                if (e.PropertyName == "net_wt")
                {
                    MasterEntity.net_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.net_wt);
                }

                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        



        #endregion


    }
}
