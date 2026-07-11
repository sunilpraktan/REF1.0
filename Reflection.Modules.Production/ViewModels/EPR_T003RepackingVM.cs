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

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T003RepackingVM //: WindowViewModel<EPR_T003_A>, INotifyPropertyChanged
    {

        //bool blNew = true;
        //WebServiceRepository<EPR_T003_A> repository = new WebServiceRepository<EPR_T003_A>();
        //WebServiceRepository<MultipleContext_EPR_T003> repositoryM = new WebServiceRepository<MultipleContext_EPR_T003>();
        //MultipleContext_EPR_T003 MCTemp = new MultipleContext_EPR_T003();

        //private ICollectionView _dataGridCollection;

        //private string _filterString;
        //private string _filterStringProduct;
        //private string _filterStringINK;
        //private string _filterStringILD;
        //private string _filterStringUnit;
        //private string _filterStringPackingUnit;
        //private string _filterStringBallMake;
        //private string _filterStringWireMake;

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

        //#region ICollection

        //public ICollectionView DataGridCollection
        //{
        //    get { return _dataGridCollection; }
        //    set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        //}       

        //private ICollectionView _MachineCollection;
        //public ICollectionView MachineCollection
        //{
        //    get { return _MachineCollection; }
        //    set
        //    {
        //        _MachineCollection = value;

        //        RaisePropertychanged("MachineCollection");
        //    }
        //}

        //private ICollectionView _ProductCollection;
        //public ICollectionView ProductCollection
        //{
        //    get { return _ProductCollection; }
        //    set
        //    {
        //        _ProductCollection = value;

        //        RaisePropertychanged("ProductCollection");
        //    }
        //}

        //private ICollectionView _CollectionINK;
        //public ICollectionView CollectionINK
        //{
        //    get { return _CollectionINK; }
        //    set { _CollectionINK = value; RaisePropertychanged("CollectionINK"); }
        //}

        //private ICollectionView _CollectionILD;
        //public ICollectionView CollectionILD
        //{
        //    get { return _CollectionILD; }
        //    set { _CollectionILD = value; RaisePropertychanged("CollectionILD"); }
        //}

        //private ICollectionView _CollectionUnit;
        //public ICollectionView CollectionUnit
        //{
        //    get { return _CollectionUnit; }
        //    set { _CollectionUnit = value; RaisePropertychanged("CollectionUnit"); }
        //}

        //private ICollectionView _CollectionPackingUnit;
        //public ICollectionView CollectionPackingUnit
        //{
        //    get { return _CollectionPackingUnit; }
        //    set
        //    {
        //        _CollectionPackingUnit = value;

        //        RaisePropertychanged("CollectionPackingUnit");
        //    }
        //}

        //private ICollectionView _CollectionBallMake;
        //public ICollectionView CollectionBallMake
        //{
        //    get { return _CollectionBallMake; }
        //    set { _CollectionBallMake = value; RaisePropertychanged("CollectionBallMake"); }
        //}

        //private ICollectionView _CollectionWireMake;
        //public ICollectionView CollectionWireMake
        //{
        //    get { return _CollectionWireMake; }
        //    set { _CollectionWireMake = value; RaisePropertychanged("CollectionWireMake"); }
        //}

        //#endregion

        //#region RelayCommand
        //public RelayCommand<IList> SelectionChangedCommandInk
        //{
        //    get;
        //    private set;
        //}
     
        //public RelayCommand<IList> SelectionChangedCommandInk1
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandInk2
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandWireMake
        //{
        //    get;
        //    private set;
        //}

        ////public RelayCommand<IList> TaxChangedCommand
        ////{
        ////    get;
        ////    private set;
        ////}

        ////public RelayCommand<IList> ParameterPopupCommand1
        ////{
        ////    get;
        ////    private set;
        ////}
        ////public RelayCommand<IList> ScheduleCellChangedCommand
        ////{
        ////    get;
        ////    private set;
        ////}

        //private RelayCommand _txtChangedCommand;
        //public RelayCommand txtChangedCommand
        //{
        //    get;
        //    private set;
        //}


        //private RelayCommand _buttonClickCommand;
        //public RelayCommand ButtonClickCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand ButtonClickCommand1
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> CheckedCommand
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> ParameterNameCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionCommand_doc_type
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> SelectionChangedCommandTax
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandLoctn
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandILD
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandILD1
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandILD2
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandMachine
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandMachine1
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandBallMake
        //{
        //    get;
        //    private set;
        //}


        //public RelayCommand<IList> SelectionChangedCommandUnit
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> SelectedCammand_sales_group
        //{
        //    get;
        //    private set;
        //}



        //public RelayCommand<IList> SelectionChangedCommandPackUom
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandPackUom1
        //{
        //    get;
        //    private set;
        //}

        //private RelayCommand _buttonInvoiceCommand;
        //public RelayCommand ButtonInvoiceCommand
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> SelectionChangedCommandItems
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> CollectionChangedMethod
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> SelectionChangedCommandSOdetails
        //{
        //    get;
        //    private set;
        //}


        //public RelayCommand<IList> SelectionChangedCommandProduct
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandProduct1
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand<IList> CellChangedCommand
        //{
        //    get;
        //    private set;
        //}

        //public RelayCommand TestCommand { get; private set; }
        //public RelayCommand<IList> SelectionChangedCommandItemfordelivery
        //{
        //    get;
        //    private set;
        //}


        //public RelayCommand<string> SelectionChangedCommandBarcode
        //{
        //    get;
        //    private set;
        //}

        //#endregion

        //#region EPR_T003
        //private List<EPR_T003_A> _SelectedList;
        //public List<EPR_T003_A> SelectedList
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
        //private EPR_T003_A _SelectedEPR_T003;
        //public EPR_T003_A SelectedEPR_T003
        //{
        //    get
        //    {
        //        //this.ErrorExist = _SelectedEPR_T002.HasErrors;
        //        return _SelectedEPR_T003;
        //    }
        //    set
        //    {
        //        if (_SelectedEPR_T003 != value)
        //        {
        //            _SelectedEPR_T003 = value;
        //            //this.ErrorExist = _SelectedEPR_T002.HasErrors;
        //            RaisePropertychanged("SelectedEPR_T003");
        //            value.BeginEdit();
        //        }
        //    }
        //}
        //#endregion

        //#region EPR_T002
        //private static ObservableCollection<EPR_T003_A> _SCDetails = new ObservableCollection<EPR_T003_A>();
        //public ObservableCollection<EPR_T003_A> SCDetails
        //{
        //    get { return _SCDetails; }
        //    set
        //    {
        //        if (_SCDetails != value)
        //        {
        //            _SCDetails = value;

        //            RaisePropertychanged("SCDetails");
        //        }
        //    }
        //}

        //private static ObservableCollection<EPR_T003_A> _SCDetailsUpdate = new ObservableCollection<EPR_T003_A>();
        //public ObservableCollection<EPR_T003_A> SCDetailsUpdate
        //{
        //    get { return _SCDetailsUpdate; }
        //    set
        //    {
        //        if (_SCDetailsUpdate != value)
        //        {
        //            _SCDetailsUpdate = value;

        //            RaisePropertychanged("SCDetailsUpdate");
        //        }
        //    }
        //}
        //private static ObservableCollection<EPR_T003_Batch_Data> _BatchDataDetails1 = new ObservableCollection<EPR_T003_Batch_Data>();
        //public ObservableCollection<EPR_T003_Batch_Data> BatchDataDetails1
        //{
        //    get { return _BatchDataDetails1; }
        //    set
        //    {
        //        if (_BatchDataDetails1 != value)
        //        {
        //            _BatchDataDetails1 = value;

        //            RaisePropertychanged("BatchDataDetails1");
        //        }
        //    }
        //}

        //private static ObservableCollection<EPR_T003_B> _BatchDataDetails = new ObservableCollection<EPR_T003_B>();
        //public ObservableCollection<EPR_T003_B> BatchDataDetails
        //{
        //    get { return _BatchDataDetails; }
        //    set
        //    {
        //        if (_BatchDataDetails != value)
        //        {
        //            _BatchDataDetails = value;

        //            RaisePropertychanged("BatchDataDetails");
        //        }
        //    }
        //}
        ////private EPR_T002_A _SelectedEPR_T002_ADtList;
        ////public EPR_T002_A SelectedEPR_T002_ADtList
        ////{
        ////    get { return _SelectedEPR_T002_ADtList; }
        ////    set
        ////    {
        ////        if (_SelectedEPR_T002_ADtList != value)
        ////        {
        ////            _SelectedEPR_T002_ADtList = value;

        ////            //if (PropertyChanged != null)
        ////            //{
        ////            RaisePropertychanged("SelectedEPR_T002_ADtList");
        ////            //}
        ////        }
        ////    }
        ////}

        //#endregion

        //#region ADM_M003 poup Plant
        //private List<ADM_M003_PopUp1> _SelectedPlantList;
        //public List<ADM_M003_PopUp1> SelectedPalntList
        //{
        //    get { return _SelectedPlantList; }
        //    set
        //    {
        //        if (_SelectedPlantList != value)
        //        {
        //            _SelectedPlantList = value;
        //            RaisePropertychanged("SelectedPalntList");
        //        }
        //    }
        //}
        //#endregion

        //#region ZADM_M013 poup Machine Type
        //private List<ZADM_M013_Popup1> _SelectedMachineList;
        //public List<ZADM_M013_Popup1> SelectedMachineList
        //{
        //    get { return _SelectedMachineList; }
        //    set
        //    {
        //        if (_SelectedMachineList != value)
        //        {
        //            _SelectedMachineList = value;
        //            RaisePropertychanged("SelectedMachineList");
        //        }
        //    }
        //}
        //#endregion

        //#region ZADM_M013 poup Machine
        //private List<ZADM_M013_PopUp> _SelectedMCList;
        //public List<ZADM_M013_PopUp> SelectedMCList
        //{
        //    get { return _SelectedMCList; }
        //    set
        //    {
        //        if (_SelectedMCList != value)
        //        {
        //            _SelectedMCList = value;
        //            RaisePropertychanged("SelectedMCList");
        //        }
        //    }
        //}
        //#endregion

        //#region ADM_M022 poup Product
        //private List<ADM_M022_ESSEM_PopUp> _SelectedProductList;
        //public List<ADM_M022_ESSEM_PopUp> SelectedProductList
        //{
        //    get { return _SelectedProductList; }
        //    set
        //    {
        //        if (_SelectedProductList != value)
        //        {
        //            _SelectedProductList = value;
        //            RaisePropertychanged("SelectedProductList");
        //        }
        //    }
        //}
        //#endregion

        //#region ZADM_M006_PopUp  INK
        //private List<ZADM_M006_PopUp> _SelectedINKList;
        //public List<ZADM_M006_PopUp> SelectedINKList
        //{
        //    get { return _SelectedINKList; }
        //    set
        //    {
        //        if (_SelectedINKList != value)
        //        {
        //            _SelectedINKList = value;
        //            RaisePropertychanged("SelectedINKList");
        //        }
        //    }
        //}
        //#endregion

        //#region ZADM_M007_PopUp  ILD
        //private List<ZADM_M007_PopUp> _SelectedILDList;
        //public List<ZADM_M007_PopUp> SelectedILDList
        //{
        //    get { return _SelectedILDList; }
        //    set
        //    {
        //        if (_SelectedILDList != value)
        //        {
        //            _SelectedILDList = value;
        //            RaisePropertychanged("SelectedILDList");
        //        }
        //    }
        //}
        //#endregion

        //#region ADM_M038_B_PopUp poup Unit
        //private List<ADM_M038_B_PopUp> _SelectedUnitList;
        //public List<ADM_M038_B_PopUp> SelectedUnitList
        //{
        //    get { return _SelectedUnitList; }
        //    set
        //    {
        //        if (_SelectedUnitList != value)
        //        {
        //            _SelectedUnitList = value;
        //            RaisePropertychanged("SelectedUnitList");
        //        }
        //    }
        //}
        //#endregion

        //#region ADM_M032_P  BallMake
        //private List<ADM_M032_P> _SelectedBallMakeList;
        //public List<ADM_M032_P> SelectedBallMakeList
        //{
        //    get { return _SelectedBallMakeList; }
        //    set
        //    {
        //        if (_SelectedBallMakeList != value)
        //        {
        //            _SelectedBallMakeList = value;
        //            RaisePropertychanged("SelectedBallMakeList");
        //        }
        //    }
        //}
        //#endregion

        //#region ADM_M032_P  WireMake
        //private List<ADM_M032_P> _SelectedWireMakeList;
        //public List<ADM_M032_P> SelectedWireMakeList
        //{
        //    get { return _SelectedWireMakeList; }
        //    set
        //    {
        //        if (_SelectedWireMakeList != value)
        //        {
        //            _SelectedWireMakeList = value;
        //            RaisePropertychanged("SelectedWireMakeList");
        //        }
        //    }
        //}
        //#endregion

        //#region ZADM_M017_Popup  Packing Unit
        //private List<ZADM_M017_Popup> _SelectedPackUnitList;
        //public List<ZADM_M017_Popup> SelectedPackUnitList
        //{
        //    get { return _SelectedPackUnitList; }
        //    set
        //    {
        //        if (_SelectedPackUnitList != value)
        //        {
        //            _SelectedPackUnitList = value;
        //            RaisePropertychanged("SelectedPackUnitList");
        //        }
        //    }
        //}
        //#endregion

        //private int _dgSelectedIndex;
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

        //private int _dgSelectedIndex1;
        //public int dgSelectedIndex1
        //{
        //    get
        //    {
        //        return _dgSelectedIndex1;
        //    }
        //    set
        //    {
        //        if (_dgSelectedIndex1 != value)
        //        {
        //            _dgSelectedIndex1 = value;
        //            RaisePropertychanged("dgSelectedIndex1");
        //        }
        //    }
        //}
        //MultipleContext_EPR_T003 _MC = new MultipleContext_EPR_T003();
        //public MultipleContext_EPR_T003 MC
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


        //#region
        //public EPR_T003RepackingVM()
        //    : base()
        //{
        //    SelectedList = new List<EPR_T003_A>();
        //    SelectedEPR_T003 = new EPR_T003_A();
        //    SelectedPalntList = new List<ADM_M003_PopUp1>();
        //    SelectedMachineList = new List<ZADM_M013_Popup1>();
        //    SelectedMCList = new List<ZADM_M013_PopUp>();

        //    SelectedProductList = new List<ADM_M022_ESSEM_PopUp>();
        //    SelectedINKList = new List<ZADM_M006_PopUp>();
        //    SelectedILDList = new List<ZADM_M007_PopUp>();
        //    SelectedUnitList = new List<ADM_M038_B_PopUp>();
        //    SelectedPackUnitList = new List<ZADM_M017_Popup>();
        //    SelectedBallMakeList = new List<ADM_M032_P>();
        //    SelectedWireMakeList = new List<ADM_M032_P>();

        //    SCDetails = new ObservableCollection<EPR_T003_A>();
        //    MC = new MultipleContext_EPR_T003();
        //    SCDetailsUpdate = new ObservableCollection<EPR_T003_A>();
        //    BatchDataDetails1 = new ObservableCollection<EPR_T003_Batch_Data>();
        //    BatchDataDetails = new ObservableCollection<EPR_T003_B>();
        //    //SelectedEPR_T002.ValidateAsync().Wait();         

        //    ButtonClickCommand = new RelayCommand(Load);
        //    //ButtonClickCommand1 = new RelayCommand(Load1);
        //    txtChangedCommand = new RelayCommand(Load1);

        //    SelectionChangedCommandWireMake = new RelayCommand<IList>(
        //   items =>
        //   {
        //       if (items == null)
        //       {
        //           return;
        //       }

        //       GetSelectedWireMake(items);
        //   });
        //    SelectionChangedCommand = new RelayCommand<IList>(
        //   items =>
        //   {
        //       if (items == null)
        //       {
        //           return;
        //       }
        //       DetailsOfSelectedCarton(items);

        //   });

        //    SelectionChangedCommandBallMake = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedBallMake(items);
        //    });
        //    SelectionChangedCommandPackUom = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedPackUOM(items);
        //    });
        //    SelectionChangedCommandPackUom1 = new RelayCommand<IList>(
        //  items =>
        //  {
        //      if (items == null)
        //      {
        //          return;
        //      }

        //      GetSelectedPackUOM1(items);
        //  });
        //    CellChangedCommand = new RelayCommand<IList>(
        //   items =>
        //   {
        //       if (items == null)
        //       {
        //           return;
        //       }
        //       CellChangeUpdate(items);
        //   });
           

        //    SelectionChangedCommandUnit = new RelayCommand<IList>(
        //   items =>
        //   {
        //       if (items == null)
        //       {
        //           return;
        //       }

        //       GetSelectedUOM(items);
        //   });

        //    SelectionChangedCommandILD = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedILD(items);
        //    });

          
        //    SelectionChangedCommandILD1 = new RelayCommand<IList>(
        //      items =>
        //      {
        //          if (items == null)
        //          {
        //              return;
        //          }

        //          GetSelectedILD1(items);
        //      });

        //    SelectionChangedCommandILD2 = new RelayCommand<IList>(
        //     items =>
        //     {
        //         if (items == null)
        //         {
        //             return;
        //         }

        //         GetSelectedILD2(items);
        //     });
        //    SelectionChangedCommandInk = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedINK(items);
        //    });

           

        //    SelectionChangedCommandInk1 = new RelayCommand<IList>(
        //  items =>
        //  {
        //      if (items == null)
        //      {
        //          return;
        //      }

        //      GetSelectedINK1(items);
        //  });
        //    SelectionChangedCommandInk2 = new RelayCommand<IList>(
        // items =>
        // {
        //     if (items == null)
        //     {
        //         return;
        //     }

        //     GetSelectedINK2(items);
        // });
        //    SelectionChangedCommandProduct = new RelayCommand<IList>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }
        //        GetSelectedProduct(items);
        //    });

        //    SelectionChangedCommandProduct1 = new RelayCommand<IList>(
        //  items =>
        //  {
        //      if (items == null)
        //      {
        //          return;
        //      }
        //      GetSelectedProduct1(items);
        //  });


        //    SelectionChangedCommandMachine = new RelayCommand<IList>(
        //      items =>
        //      {
        //          if (items == null)
        //          {
        //              return;
        //          }

        //          GetSelectedMachine(items);
        //      });
        //    SelectionChangedCommandMachine1 = new RelayCommand<IList>(
        //      items =>
        //      {
        //          if (items == null)
        //          {
        //              return;
        //          }

        //          GetSelectedMachine1(items);
        //      });




        //    SelectionChangedCommandBarcode = new RelayCommand<string>(
        //    items =>
        //    {
        //        if (items == null)
        //        {
        //            return;
        //        }

        //        GetSelectedBarcode(items);
        //    });

        //    LoadInitialData();

        //    SelectedEPR_T003.carton_pack_dt = DateTime.Now;

        //}

        //#endregion

        //private void GetSelectedList(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<EPR_T003_A> tSelectedItemsList = list.Cast<EPR_T003_A>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedEPR_T003 = (EPR_T003_A)tSelectedItemsList[0];
        //        SCDetails = new ObservableCollection<EPR_T003_A>();
        //        blNew = false;
        //    }
        //}
        //private void GetSelectedMachine(IList MachineList)
        //{

        //    try
        //    {
        //        IList list = MachineList as IList;
        //        List<MM_T001_GRN_PopUp> SelectedMachineTemp = list.Cast<MM_T001_GRN_PopUp>().ToList();
        //        if (SelectedMachineTemp.Count > 0 && dgSelectedIndex != -1)
        //        {

        //            {
        //                SelectedEPR_T003.prod_desc_id = SelectedMachineTemp[0].id;
        //                SelectedEPR_T003.prod_desc = SelectedMachineTemp[0].doc_no;
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
        //private void GetSelectedWireMake(IList WireMakeList)
        //{
        //    try
        //    {
        //        IList list = WireMakeList as IList;
        //        List<ADM_M032_P> GetSelectedWireMakeTemp = list.Cast<ADM_M032_P>().ToList();

        //        if (GetSelectedWireMakeTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.wire_make = GetSelectedWireMakeTemp[0].Make;
        //            SelectedEPR_T003.wire_make_id = GetSelectedWireMakeTemp[0].MakeCode;
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
        //private void DetailsOfSelectedCarton(IList DataList)
        //{
        //    IList list = DataList as IList;

        //    List<EPR_T003_A> tSelectedPOList = list.Cast<EPR_T003_A>().ToList();
        //    if (tSelectedPOList.Count > 0)
        //    {

        //        SelectedEPR_T003 = (EPR_T003_A)tSelectedPOList[0];
        //        int supplierid = (SelectedEPR_T003.id);

        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, "EPR_T003_A", "SmallCarton", "Production", "LoadCartonDetails", supplierid, "");

        //        //BatchDataDetails = MC.CartonGenerationDetails;
        //        try
        //        {
        //            foreach (var items in MC.CartonGenerationDetails)
        //            {
        //                BatchDataDetails.Add(new EPR_T003_B()
        //                {
        //                    id = items.id,
        //                    batch_no = items.batch_no,
        //                    qty = items.qty,
        //                    noofbags = 1,
        //                    active = true,
        //                    note = items.note,
        //                    comp_code = AppSessionState.comp_code

        //                });
        //            }
        //        }
        //        catch
        //        {

        //        }

        //    }
        //    blNew = false;

        //}
        //private void GetSelectedBallMake(IList BallMakeList)
        //{

        //    try
        //    {
        //        IList list = BallMakeList as IList;
        //        List<ADM_M032_P> GetSelectedBallMakeTemp = list.Cast<ADM_M032_P>().ToList();

        //        if (GetSelectedBallMakeTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.ball_make = GetSelectedBallMakeTemp[0].Make;
        //            SelectedEPR_T003.ball_make_id = GetSelectedBallMakeTemp[0].MakeCode;
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
        //private void GetSelectedPackUOM(IList PackUOMList)
        //{

        //    try
        //    {
        //        IList list = PackUOMList as IList;
        //        List<ZADM_M017_Popup> SelectedPACKUomDetailsTemp = list.Cast<ZADM_M017_Popup>().ToList();

        //        if (SelectedPACKUomDetailsTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.pack_style = SelectedPACKUomDetailsTemp[0].packing_id;
        //            SelectedEPR_T003.pkgunit = SelectedPACKUomDetailsTemp[0].pkgunit;
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
        //private void CellChangeUpdate(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    if (list == null) return;
        //    decimal noofbags = 0;
        //     decimal qtyperbag = 0;
        //    decimal packedqty = 0;
        //    {
        //        {
        //            foreach (var item in BatchDataDetails)
        //            {
        //                noofbags = noofbags + Convert.ToDecimal(item.noofbags);                        
        //            }
        //                qtyperbag = Convert.ToDecimal(BatchDataDetails[0].qty);
        //        }
        //        SelectedEPR_T003.tot_no_bags = noofbags;               
        //        try
        //        {
        //            string[] split = new string[25];
        //            try
        //            {
        //                split = SelectedEPR_T003.pkgunit.Split('/');
        //                packedqty = Convert.ToDecimal(split[0]);                       
        //                SelectedEPR_T003.qty_per_bag = packedqty;
        //            }
        //            catch
        //            {
        //                SelectedEPR_T003.qty_per_bag = qtyperbag;
        //            }                   
                
        //            SelectedEPR_T003.tot_qty = (SelectedEPR_T003.qty_per_bag) * (SelectedEPR_T003.tot_no_bags);
        //        }
        //        catch
        //        {

        //        }
        //        try
        //        {
        //            if (dgSelectedIndex > 1)
        //            {
        //                if (BatchDataDetails[dgSelectedIndex].qty == BatchDataDetails[dgSelectedIndex - 1].qty)
        //                {

        //                }
        //                else
        //                {
        //                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                    showMessageService.ButtonSetup = DialogButton.Ok;
        //                    showMessageService.Caption = "Message";
        //                    showMessageService.Text = String.Format("Quantity MissMatch!", this.Title);
        //                    showMessageService.ShowMessage();
        //                }
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }

        //}
        //private void GetSelectedUOM(IList UomList)
        //{

        //    try
        //    {  
        //        IList list = UomList as IList;
        //        List<ADM_M038_B_PopUp> SelectedUomDetailsTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

        //        if (SelectedUomDetailsTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.unit_id = SelectedUomDetailsTemp[0].id;
        //            SelectedEPR_T003.UOM = SelectedUomDetailsTemp[0].unit_name;
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
        //private void GetSelectedILD2(IList MachineList)
        //{

        //    try
        //    {
        //        IList list = MachineList as IList;
        //        List<ZADM_M007_PopUp> SelectedMachineTemp = list.Cast<ZADM_M007_PopUp>().ToList();

        //        if (SelectedMachineTemp.Count > 0 && dgSelectedIndex != -1)
        //        {


        //            {
        //                //LGDetailsUpdate[dgSelectedIndex1].ild_id = SelectedMachineTemp[0].ild_id;
        //                //LGDetailsUpdate[dgSelectedIndex1].ILD = SelectedMachineTemp[0].ild;

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
        //private void GetSelectedILD(IList ILDList)
        //{

        //    try
        //    {
        //        IList list = ILDList as IList;
        //        List<ZADM_M007_PopUp> GetSelectedILDTemp = list.Cast<ZADM_M007_PopUp>().ToList();

        //        if (GetSelectedILDTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.ild = GetSelectedILDTemp[0].ild;
        //            SelectedEPR_T003.ild_id = GetSelectedILDTemp[0].ild_id;
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
        //private void GetSelectedINK(IList INKList)
        //{

        //    try
        //    {
        //        IList list = INKList as IList;
        //        List<ZADM_M006_PopUp> GetSelectedINKTemp = list.Cast<ZADM_M006_PopUp>().ToList();

        //        if (GetSelectedINKTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.ink = GetSelectedINKTemp[0].ink;
        //            SelectedEPR_T003.ink_id = GetSelectedINKTemp[0].ink_id;
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
        //private void GetSelectedINK2(IList MachineList)
        //{
        //    try
        //    {
        //        IList list = MachineList as IList;
        //        List<ZADM_M006_PopUp> SelectedMachineTemp = list.Cast<ZADM_M006_PopUp>().ToList();
        //        if (SelectedMachineTemp.Count > 0 && dgSelectedIndex != -1)
        //        {
        //            {
        //                //LGDetailsUpdate[dgSelectedIndex1].ink_id = SelectedMachineTemp[0].ink_id;
        //                //LGDetailsUpdate[dgSelectedIndex1].INK = SelectedMachineTemp[0].ink;
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
        //private void GetSelectedProduct(IList ProductList)
        //{
        //    try
        //    {               
        //        IList list = ProductList as IList;
        //        List<ADM_M022_ESSEM_PopUp> GetSelectedProdTemp = list.Cast<ADM_M022_ESSEM_PopUp>().ToList();

        //        if (GetSelectedProdTemp.Count > 0)
        //        {
        //            SelectedEPR_T003.itemcode = GetSelectedProdTemp[0].ItemCode;                   
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
        //private void GetSelectedProduct1(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ADM_M022_ESSEM_PopUp> tSelectedItemsList = list.Cast<ADM_M022_ESSEM_PopUp>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        //SelectedEPR_T002.itemcode = tSelectedItemsList[0].ItemCode;
        //    }

        //}
        //private void GetSelectedMachine1(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ZADM_M013_PopUp> tSelectedItemsList = list.Cast<ZADM_M013_PopUp>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        //SelectedEPR_T002.machine_id = tSelectedItemsList[0].machine_id;
        //        //SelectedEPR_T002.Machine = tSelectedItemsList[0].machinecode;
        //    }

        //}
        //private void GetSelectedINK1(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ZADM_M006_PopUp> tSelectedItemsList = list.Cast<ZADM_M006_PopUp>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        //SelectedEPR_T002.ink_id = tSelectedItemsList[0].ink_id;
        //        //SelectedEPR_T002.INK = tSelectedItemsList[0].ink;
        //    }

        //}
        //private void GetSelectedILD1(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ZADM_M007_PopUp> tSelectedItemsList = list.Cast<ZADM_M007_PopUp>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        //SelectedEPR_T002.ild_id = tSelectedItemsList[0].ild_id;
        //        //SelectedEPR_T002.ILD = tSelectedItemsList[0].ild;
        //    }

        //}
        //private void GetSelectedPackUOM1(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ADM_M038_B_PopUp> tSelectedItemsList = list.Cast<ADM_M038_B_PopUp>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        //SelectedEPR_T002.pack_style = tSelectedItemsList[0].id;
        //        //SelectedEPR_T002.PackingUnit = tSelectedItemsList[0].unit_name;
        //    }

        //}
        //private void Load()
        //{
        //    SCDetails = new ObservableCollection<EPR_T003_A>();
        //    string date = "";//(SelectedEPR_T003_A..ToString());
        //    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, "EPR_T003_A", "SmallCarton", "Production", "LoadBatchData", 0, date);
        //    //BatchDataDetails = MC.BatchData;
        //    if (BatchDataDetails.Count > 0)
        //    {
        //        foreach (var item in BatchDataDetails)
        //        {
        //            SCDetails.Add(new EPR_T003_A()
        //            {
        //                //ItemCode = item.itemcode,
        //                //grade = item.grade,
        //                //ball_make = item.ball_make_id,
        //                //BallMake = item.ball_make,
        //                //c_qty = item.c_qty,
        //                //counter_qty = item.counterqty,
        //                //ILD = item.ild,
        //                //ild_id = item.ild_id,
        //                //INK = item.ink,
        //                //ink_id = item.ink_id,
        //                //itemcode = item.itemcode,
        //                //Machine = item.machinecode,
        //                //machine_id = item.machine_id,
        //                //pack_style = item.pack_style,
        //                //PackingUnit = item.unit_name,
        //                //shift = item.shift,
        //                //tip_ave_wt = item.tip_ave_wt,
        //                //tip_wt_1 = item.tip_wt_1,
        //                //tip_wt_2 = item.tip_wt_2,
        //                //tip_wt_3 = item.tip_wt_3,
        //                //Unit = item.Unit,
        //                //wire_make = item.wire_make_id,
        //                //WireMake = item.wire_make,
        //                //conversion = item.conv,
        //                //blank_wt = item.avg_blank_wt

        //            });
        //        }
        //    }
        //    blNew = true;

        //}
        //private void GetSelectedBarcode(string barcode)
        //{
        //    try
        //    {
        //        if (barcode.ToString() != "")
        //        {

        //        }
        //        string strExp;
        //        string strSort;
        //        string Barcodevalue = "";
        //        Barcodevalue = barcode.ToString().Trim();
        //        if (Barcodevalue == "")
        //        {

        //        }
        //        else
        //        {
        //            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, "EPR_T003_Data", "SmallCarton", "Production", "LoadBatchData", 0, Barcodevalue);
        //            BatchDataDetails1 = MC.BatchData;
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
        //private void Load1()
        //{
        //    BatchDataDetails1 = new ObservableCollection<EPR_T003_Batch_Data>();
        //    //string date = (SelectedEPR_T002.prod_dt.ToString());
        //    string request1 = SelectedEPR_T003.batch_no;
        //    //string request1 = SelectedEPR_T002.itemcode + "!@" + SelectedEPR_T002.ink_id + "!@" + SelectedEPR_T002.ild_id
        //    //    + "!@" + SelectedEPR_T002.shift + "!@" + SelectedEPR_T002.pack_style + "!@" + SelectedEPR_T002.machine_id
        //    //    + "!@" + SelectedEPR_T002.prod_dt + "!@" + SelectedEPR_T002.grade + "!@" + AppSessionState.LocationID + "!@" + SelectedEPR_T002.conversion;
        //    if (request1 != null)
        //    {
        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, "EPR_T003_Batch_Data", "SmallCarton", "Production", "LoadBatchData",0, request1);
        //        BatchDataDetails1 = MC.BatchData;
        //        try
        //        {
        //            SelectedEPR_T003.itemcode = BatchDataDetails1[0].itemcode;
        //            SelectedEPR_T003.ink_id = BatchDataDetails1[0].ink_id;
        //            SelectedEPR_T003.ink = BatchDataDetails1[0].ink;
        //            SelectedEPR_T003.ild_id = BatchDataDetails1[0].ild_id;
        //            SelectedEPR_T003.ild = BatchDataDetails1[0].ild;
        //            SelectedEPR_T003.UOM = BatchDataDetails1[0].uom;
        //            SelectedEPR_T003.unit_id = BatchDataDetails1[0].unit_id;
        //            SelectedEPR_T003.pack_style = BatchDataDetails1[0].pack_style;
        //            SelectedEPR_T003.pkgunit = BatchDataDetails1[0].pkgunit;
        //            SelectedEPR_T003.wire_make_id = BatchDataDetails1[0].wire_make_id;
        //            SelectedEPR_T003.wire_make = BatchDataDetails1[0].wire_make;
        //            SelectedEPR_T003.ball_make_id = BatchDataDetails1[0].ball_make_id;
        //            SelectedEPR_T003.ball_make = BatchDataDetails1[0].ball_make;
        //            SelectedEPR_T003.net_wt = Convert.ToDecimal(BatchDataDetails1[0].NetWt);
        //            SelectedEPR_T003.gross_wt = Convert.ToDecimal(BatchDataDetails1[0].GrossWt);
        //            SelectedEPR_T003.grade = BatchDataDetails1[0].grade;

        //        }
        //        catch
        //        {

        //        }
        //        try
        //        {
        //            foreach (var item in BatchDataDetails1)
        //                BatchDataDetails.Add(new EPR_T003_B()
        //                {
        //                    //blank_wt = item.avg_blank_wt
        //                    batch_no = item.batch_no,
        //                    qty = item.label_qty
        //                });
        //        }
        //        catch
        //        {

        //        }

        //    }

        //}

        //private void LoadInitialData()
        //{
        //    try
        //    {
        //       // string plant = AppSessionState.Location;
        //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, "EPR_T003_A", "SmallCarton", "Production", "LoadAllRepacking", 0, AppSessionState.location_Id);
        //        SelectedList = MC.CartonGeneration;
        //        DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
        //        DataGridCollection.Filter = new Predicate<object>(Filter);
        //        BatchDataDetails = new ObservableCollection<EPR_T003_B>();

        //        MachineCollection = CollectionViewSource.GetDefaultView(MC.ProddescData);
        //        MachineCollection.Filter = new Predicate<object>(machine_Filter);

        //        ProductCollection = CollectionViewSource.GetDefaultView(MC.Product);
        //        ProductCollection.Filter = new Predicate<object>(FilterProduct);

        //        CollectionINK = CollectionViewSource.GetDefaultView(MC.INK);
        //        CollectionINK.Filter = new Predicate<object>(FilterINK);

        //        CollectionILD = CollectionViewSource.GetDefaultView(MC.ILD);
        //        CollectionILD.Filter = new Predicate<object>(FilterILD);

        //        CollectionUnit = CollectionViewSource.GetDefaultView(MC.uom);
        //        CollectionUnit.Filter = new Predicate<object>(FilterUnit);

        //        CollectionPackingUnit = CollectionViewSource.GetDefaultView(MC.PackUOM);
        //        CollectionPackingUnit.Filter = new Predicate<object>(FilterPackingUnit);

        //        CollectionBallMake = CollectionViewSource.GetDefaultView(MC.BallMake);
        //        CollectionBallMake.Filter = new Predicate<object>(FilterBallMake);

        //        CollectionWireMake = CollectionViewSource.GetDefaultView(MC.WireMake);
        //        CollectionWireMake.Filter = new Predicate<object>(FilterWireMake);

        //        _dataGridCollection.Refresh();
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

        //#region · Command Actions ·

        //protected override void OnSaveAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    #region done
        //    try
        //    {
        //        this.SelectedEPR_T003.EndEdit();
        //        ObjectSerializationService objSer = new ObjectSerializationService();

        //        //StockingUnitCalculation();
        //        SelectedEPR_T003.comp_code  = AppSessionState.comp_code;
        //        SelectedEPR_T003.location_Id = AppSessionState.location_Id;
        //        SelectedEPR_T003.add_by = Convert.ToInt32(AppSessionState.UserID);
        //        SelectedEPR_T003.bal_qty = Convert.ToDecimal(0.00);
        //        SelectedEPR_T003.packing_type = "Repacking";
        //        //SelectedEPR_T003.XmlDataDocument_EPR_T003_A = objSer.ObjectToXML(SelectedEPR_T003);
        //        SelectedEPR_T003.XmlDataDocument_EPR_T003_B = objSer.ObjectToXML(BatchDataDetails);

        //        //if (ValidateControls() == true)
        //        //{
        //        if (blNew == true)
        //        {
        //            SelectedEPR_T003 = repository.SaveWithReturnDomainObject<EPR_T003_A>(SelectedEPR_T003, "SmallCarton", "Production");
        //            SelectedList.Add(SelectedEPR_T003);
        //            BatchDataDetails = (ObservableCollection<EPR_T003_B>)objSer.XMLToObject(SelectedEPR_T003.XmlDataDocument_EPR_T003_B, BatchDataDetails);
        //            _dataGridCollection.Refresh();
        //            blNew = false;
        //        }
        //        else if (blNew == false)
        //        {
        //            SelectedEPR_T003 = repository.UpdateWithReturnDomainObject<EPR_T003_A>(SelectedEPR_T003, "SmallCarton", "Production");
        //            this.SelectedEPR_T003.EndEdit();
        //        }
        //        try
        //        {
        //            BatchDataDetails = (ObservableCollection<EPR_T003_B>)objSer.XMLToObject(SelectedEPR_T003.XmlDataDocument_EPR_T003_B, BatchDataDetails);
        //            //SCDetailsUpdate = (ObservableCollection<EPR_T003_A>)objSer.XMLToObject(SelectedEPR_T003.XmlDataDocument_EPR_T003_B, SCDetailsUpdate);
        //        }
        //        catch
        //        {

        //        }               
        //        _dataGridCollection.Refresh();               
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //    #endregion
        //}
        //protected override void OnCreateAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    blNew = true;
        //    BatchDataDetails = new ObservableCollection<EPR_T003_B>();
        //    BatchDataDetails1 = new ObservableCollection<EPR_T003_Batch_Data>();
        //    _dataGridCollection.Refresh();
        //    SelectedEPR_T003 = new EPR_T003_A();
        //    SelectedEPR_T003.ValidateAsync().Wait();
        //}
        //protected override void OnRemoveAction(InquiryActionResult<EPR_T003_A> result)
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
                
        //        this.SelectedEPR_T003.EndEdit();
        //        ObjectSerializationService objSer = new ObjectSerializationService();
        //        SelectedEPR_T003.XmlDataDocument_EPR_T003_B = objSer.ObjectToXML(SelectedEPR_T003);
        //        string xdoc = objSer.ObjectToXML(SelectedEPR_T003);
        //        string response = repository.Delete(SelectedEPR_T003.id, "SmallCarton", "Production");
        //        SelectedList.Remove(SelectedEPR_T003);
        //        SelectedEPR_T003 = new EPR_T003_A();               
        //        _dataGridCollection.Refresh();

        //    }
        //}
        //protected override void OnDiscardAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    SelectedEPR_T003.CancelEdit();
        //}
        //protected override void OnFevoriteAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    SelectedList = SelectedList;
        //}
        //protected override void OnFlipAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedEPR_T003 = SelectedEPR_T003;
        //}
        //protected override void OnHelpAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedEPR_T003 = SelectedEPR_T003;
        //}
        //protected override void OnPrintAction(InquiryActionResult<EPR_T003_A> result)
        //{
        //    SelectedList = SelectedList;
        //    SelectedEPR_T003 = SelectedEPR_T003;
        //}

        //#endregion

        //#region Filters For Plant

        //private void FilterCollection_Machine()
        //{
        //    if (MachineCollection != null)
        //    {
        //        MachineCollection.Refresh();
        //    }
        //}
        //private string _filterString_machine;
        //public string FilterString_machine
        //{
        //    get { return _filterString_machine; }
        //    set
        //    {
        //        _filterString_machine = value;
        //        RaisePropertychanged("FilterString_machine");
        //        FilterCollection_Machine();
        //    }
        //}
        //public bool machine_Filter(object obj)
        //{
        //    var data = obj as MM_T001_GRN_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString_machine))
        //        {
        //            return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_machine.ToLower())
        //               );
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //private void FilterCollection_Machine1()
        //{
        //    if (MachineCollection != null)
        //    {
        //        MachineCollection.Refresh();
        //    }
        //}
        //private string _filterString_machine1;
        //public string FilterString_machine1
        //{
        //    get { return _filterString_machine1; }
        //    set
        //    {
        //        _filterString_machine1 = value;
        //        RaisePropertychanged("FilterString_machine1");
        //        FilterCollection_Machine1();
        //    }
        //}
        //public bool machine_Filter1(object obj)
        //{
        //    var data = obj as ZADM_M013_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString_machine1))
        //        {
        //            return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_machine1.ToLower()) ||
        //                data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_machine1.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

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
        //    var data = obj as EPR_T003_A;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString))
        //        {
        //            return (data.itemcode != null && data.itemcode.ToLower().Contains(_filterString.ToLower())) ||
        //            (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.ild != null && data.ild.ToLower().Contains(_filterString.ToLower())) ||
        //            (data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.UOM != null && data.UOM.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.wire_make != null && data.wire_make.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.ball_make != null && data.ball_make.ToString().ToLower().Contains(_filterString.ToLower())) ||
        //            (data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        ////Sales Person
        ////private void FilterCollection_product()
        ////{
        ////    if (ProductCollection != null)
        ////    {
        ////        ProductCollection.Refresh();
        ////    }
        ////}
        ////private string _filterString_product;
        ////public string FilterString_product
        ////{
        ////    get { return _filterString_product; }
        ////    set
        ////    {
        ////        _filterString_product = value;
        ////        RaisePropertychanged("FilterString_product");
        ////        FilterCollection_product();
        ////    }
        ////}
        ////public bool product_Filter(object obj)
        ////{
        ////    var data = obj as ADM_M022_ESSEM_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterString_product))
        ////        {
        ////            return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_product.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}

        ////private void FilterCollection_product1()
        ////{
        ////    if (ProductCollection != null)
        ////    {
        ////        ProductCollection.Refresh();
        ////    }
        ////}
        ////private string _filterString_product1;
        ////public string FilterString_product1
        ////{
        ////    get { return _filterString_product1; }
        ////    set
        ////    {
        ////        _filterString_product1 = value;
        ////        RaisePropertychanged("FilterString_product1");
        ////        FilterCollection_product1();
        ////    }
        ////}


        ////public bool product_Filter1(object obj)
        ////{
        ////    var data = obj as ADM_M022_ESSEM_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterString_product1))
        ////        {
        ////            return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_product1.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}



        ////Sales Office
        ////private void FilterCollection_ink()
        ////{
        ////    if (InkCollection != null)
        ////    {
        ////        InkCollection.Refresh();
        ////    }
        ////}
        ////private string _filterString_ink;
        ////public string FilterString_ink
        ////{
        ////    get { return _filterString_ink; }
        ////    set
        ////    {
        ////        _filterString_ink = value;
        ////        RaisePropertychanged("FilterString_ink");
        ////        FilterCollection_ink();
        ////    }
        ////}
        ////public bool ink_Filter(object obj)
        ////{
        ////    var data = obj as ZADM_M006_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterString_ink))
        ////        {
        ////            return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_ink.ToLower()) ||
        ////                data.make != null && data.make.ToString().ToLower().Contains(_filterString_ink.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}

        ////Sales Group

        ////private void FilterCollection_unit()
        ////{
        ////    if (UnitCollection != null)
        ////    {
        ////        UnitCollection.Refresh();
        ////    }
        ////}
        ////private string _filterString_unit;
        ////public string FilterString_unit
        ////{
        ////    get { return _filterString_unit; }
        ////    set
        ////    {
        ////        _filterString_unit = value;
        ////        RaisePropertychanged("FilterString_unit");
        ////        FilterCollection_unit();
        ////    }
        ////}
        ////public bool unit_Filter(object obj)
        ////{
        ////    var data = obj as ADM_M038_B_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterString_unit))
        ////        {
        ////            return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_ild.ToLower()) ||
        ////                data.unit_abbrv != null && data.unit_abbrv.ToString().ToLower().Contains(_filterString_ild.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}




        ////private void FilterCollection_packunit()
        ////{
        ////    if (PackunitCollection != null)
        ////    {
        ////        PackunitCollection.Refresh();
        ////    }
        ////}
        ////private string _filterString_packunit;
        ////public string FilterString_packunit
        ////{
        ////    get { return _filterString_packunit; }
        ////    set
        ////    {
        ////        _filterString_packunit = value;
        ////        RaisePropertychanged("FilterString_packunit");
        ////        FilterCollection_unit();
        ////    }
        ////}
        ////public bool packunit_Filter(object obj)
        ////{
        ////    var data = obj as ADM_M038_B_PopUp;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterString_packunit))
        ////        {
        ////            return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_ild.ToLower()) ||
        ////                data.unit_abbrv != null && data.unit_abbrv.ToString().ToLower().Contains(_filterString_ild.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}


        ////private void FilterCollection_make()
        ////{
        ////    if (MakeCollection != null)
        ////    {
        ////        MakeCollection.Refresh();
        ////    }
        ////}
        ////private string _filterString_make;
        ////public string FilterString_make
        ////{
        ////    get { return _filterString_make; }
        ////    set
        ////    {
        ////        _filterString_make = value;
        ////        RaisePropertychanged("FilterString_make");
        ////        FilterCollection_make();
        ////    }
        ////}
        ////public bool make_Filter(object obj)
        ////{
        ////    var data = obj as ADM_M032_P;
        ////    if (data != null)
        ////    {
        ////        if (!string.IsNullOrEmpty(_filterString_make))
        ////        {
        ////            return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_ild.ToLower()));
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}


        //// cost_centre
        //#endregion

        //#region Filters For Product
        //private void FilterCollectionProduct()
        //{
        //    if (_ProductCollection != null)
        //    {
        //        _ProductCollection.Refresh();
        //    }
        //}
        //public string FilterStringProduct
        //{
        //    get { return _filterStringProduct; }
        //    set
        //    {
        //        _filterStringProduct = value;
        //        RaisePropertychanged("FilterStringProduct");
        //        FilterCollectionProduct();
        //    }
        //}
        //public bool FilterProduct(object obj)
        //{
        //    var data = obj as ADM_M022_ESSEM_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringProduct))
        //        {
        //            return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringProduct.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For INK
        //private void FilterCollectionINK()
        //{
        //    if (_CollectionINK != null)
        //    {
        //        _CollectionINK.Refresh();
        //    }
        //}
        //public string FilterStringINK
        //{
        //    get { return _filterStringINK; }
        //    set
        //    {
        //        _filterStringINK = value;
        //        RaisePropertychanged("FilterStringINK");
        //        FilterCollectionINK();
        //    }
        //}
        //public bool FilterINK(object obj)
        //{
        //    var data = obj as ZADM_M006_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringINK))
        //        {
        //            return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterStringINK.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For ILD
        //private void FilterCollectionILD()
        //{
        //    if (_CollectionILD != null)
        //    {
        //        _CollectionILD.Refresh();
        //    }
        //}
        //public string FilterStringILD
        //{
        //    get { return _filterStringILD; }
        //    set
        //    {
        //        _filterStringILD = value;
        //        RaisePropertychanged("FilterStringILD");
        //        FilterCollectionILD();
        //    }
        //}
        //public bool FilterILD(object obj)
        //{
        //    var data = obj as ZADM_M007_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringILD))
        //        {
        //            return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterStringILD.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For Unit
        //private void FilterCollectionUnit()
        //{
        //    if (_CollectionUnit != null)
        //    {
        //        _CollectionUnit.Refresh();
        //    }
        //}
        //public string FilterStringUnit
        //{
        //    get { return _filterStringUnit; }
        //    set
        //    {
        //        _filterStringUnit = value;
        //        RaisePropertychanged("FilterStringUnit");
        //        FilterCollectionUnit();
        //    }
        //}
        //public bool FilterUnit(object obj)
        //{
        //    var data = obj as ADM_M038_B_PopUp;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringUnit))
        //        {
        //            return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For PackingUnit
        //private void FilterCollectionPackingUnit()
        //{
        //    if (_CollectionPackingUnit != null)
        //    {
        //        _CollectionPackingUnit.Refresh();
        //    }
        //}
        //public string FilterStringPackingUnit
        //{
        //    get { return _filterStringPackingUnit; }
        //    set
        //    {
        //        _filterStringPackingUnit = value;
        //        RaisePropertychanged("FilterStringPackingUnit");
        //        FilterCollectionPackingUnit();
        //    }
        //}
        //public bool FilterPackingUnit(object obj)
        //{
        //    var data = obj as ZADM_M017_Popup;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringPackingUnit))
        //        {
        //            return (data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterStringPackingUnit.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For BallMake
        //private void FilterCollectionBallMake()
        //{
        //    if (_CollectionBallMake != null)
        //    {
        //        _CollectionBallMake.Refresh();
        //    }
        //}
        //public string FilterStringBallMake
        //{
        //    get { return _filterStringBallMake; }
        //    set
        //    {
        //        _filterStringBallMake = value;
        //        RaisePropertychanged("FilterStringBallMake");
        //        FilterCollectionBallMake();
        //    }
        //}
        //public bool FilterBallMake(object obj)
        //{
        //    var data = obj as ADM_M032_P;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringBallMake))
        //        {
        //            return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringBallMake.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region Filters For WireMake
        //private void FilterCollectionWireMake()
        //{
        //    if (_CollectionWireMake != null)
        //    {
        //        _CollectionWireMake.Refresh();
        //    }
        //}
        //public string FilterStringWireMake
        //{
        //    get { return _filterStringWireMake; }
        //    set
        //    {
        //        _filterStringWireMake = value;
        //        RaisePropertychanged("FilterStringWireMake");
        //        FilterCollectionWireMake();
        //    }
        //}
        //public bool FilterWireMake(object obj)
        //{
        //    var data = obj as ADM_M032_P;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringWireMake))
        //        {
        //            return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringWireMake.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        //#region "Filter for Back Content Datagrid"


        //#endregion
    }
}
