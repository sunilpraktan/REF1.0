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
using Reflection.BusinessEntity.Production;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{
    class PPC_T004_VM : WorkspaceViewModel<PPC_T004>
    {
        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_T004_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWireSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWireSize
        {
            get { return _ASWireSize; }
            set
            {
                if (_ASWireSize != value)
                {
                    _ASWireSize = value; RaisePropertyChanged("ASWireSize");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWireType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWireType
        {
            get { return _ASWireType; }
            set
            {
                if (_ASWireType != value)
                {
                    _ASWireType = value; RaisePropertyChanged("ASWireType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBallSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBallSize
        {
            get { return _ASBallSize; }
            set
            {
                if (_ASBallSize != value)
                {
                    _ASBallSize = value; RaisePropertyChanged("ASBallSize");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBallType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBallType
        {
            get { return _ASBallType; }
            set
            {
                if (_ASBallType != value)
                {
                    _ASBallType = value; RaisePropertyChanged("ASBallType");
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

        private AutoSuggestTextViewModel<dynamic> _ASMachineNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMachineNo
        {
            get { return _ASMachineNo; }
            set
            {
                if (_ASMachineNo != value)
                {
                    _ASMachineNo = value; RaisePropertyChanged("ASMachineNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDatagridPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDatagridPlant
        {
            get { return _ASDatagridPlant; }
            set
            {
                if (_ASDatagridPlant != value)
                {
                    _ASDatagridPlant = value; RaisePropertyChanged("ASDatagridPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgMachineNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgMachineNo
        {
            get { return _ASDgMachineNo; }
            set
            {
                if (_ASDgMachineNo != value)
                {
                    _ASDgMachineNo = value; RaisePropertyChanged("ASDgMachineNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgUnit
        {
            get { return _ASDgUnit; }
            set
            {
                if (_ASDgUnit != value)
                {
                    _ASDgUnit = value; RaisePropertyChanged("ASDgUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgProductCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgProductCode
        {
            get { return _ASDgProductCode; }
            set
            {
                if (_ASDgProductCode != value)
                {
                    _ASDgProductCode = value; RaisePropertyChanged("ASDgProductCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInk { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInk
        {
            get { return _ASInk; }
            set
            {
                if (_ASInk != value)
                {
                    _ASInk = value; RaisePropertyChanged("ASInk");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASIld { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIld
        {
            get { return _ASIld; }
            set
            {
                if (_ASIld != value)
                {
                    _ASIld = value; RaisePropertyChanged("ASIld");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDgBallMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgBallMake
        {
            get { return _ASDgBallMake; }
            set
            {
                if (_ASDgBallMake != value)
                {
                    _ASDgBallMake = value; RaisePropertyChanged("ASDgBallMake");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgWireMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgWireMake
        {
            get { return _ASDgWireMake; }
            set
            {
                if (_ASDgWireMake != value)
                {
                    _ASDgWireMake = value; RaisePropertyChanged("ASDgWireMake");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgBallSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgBallSize
        {
            get { return _ASDgBallSize; }
            set
            {
                if (_ASDgBallSize != value)
                {
                    _ASDgBallSize = value; RaisePropertyChanged("ASDgBallSize");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgBallType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgBallType
        {
            get { return _ASDgBallType; }
            set
            {
                if (_ASDgBallType != value)
                {
                    _ASDgBallType = value; RaisePropertyChanged("ASDgBallType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgWireSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgWireSize
        {
            get { return _ASDgWireSize; }
            set
            {
                if (_ASDgWireSize != value)
                {
                    _ASDgWireSize = value; RaisePropertyChanged("ASDgWireSize");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDgBomNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDgBomNo
        {
            get { return _ASDgBomNo; }
            set
            {
                if (_ASDgBomNo != value)
                {
                    _ASDgBomNo = value; RaisePropertyChanged("ASDgBomNo");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPkUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPkUnit
        {
            get { return _ASPkUnit; }
            set
            {
                if (_ASPkUnit != value)
                {
                    _ASPkUnit = value; RaisePropertyChanged("ASPkUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASStore_code { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStore_code
        {
            get { return _ASStore_code; }
            set
            {
                if (_ASStore_code != value)
                {
                    _ASStore_code = value; RaisePropertyChanged("ASStore_code");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASFltrt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_status
        {
            get { return _ASFltrt_status; }
            set
            {
                if (_ASFltrt_status != value)
                {
                    _ASFltrt_status = value; RaisePropertyChanged("ASFltrt_status");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_status
        {
            get { return _AS_status; }
            set
            {
                if (_AS_status != value)
                {
                    _AS_status = value; RaisePropertyChanged("AS_status");
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
                    if (SourceName == "production_plant")
                    {
                        ASDefault = ASDatagridPlant;
                    }
                    else if (SourceName == "machine_no")
                    {
                        ASDefault = ASDgMachineNo;
                    }
                    else if (SourceName == "unit_code")
                    {
                        ASDefault = ASDgUnit;
                    }
                    else if (SourceName == "ItemCode")
                    {
                        ASDefault = ASDgProductCode;
                    }
                    else if (SourceName == "ink_SCLR")
                    {
                        ASDefault = ASInk;
                    }
                    else if (SourceName == "ild_SCLR")
                    {
                        ASDefault = ASIld;
                    }
                    else if (SourceName == "BallMake_SCLR")
                    {
                        ASDefault = ASDgBallMake;
                    }
                    else if (SourceName == "WireMake_SCLR")
                    {
                        ASDefault = ASDgWireMake;
                    }
                    else if (SourceName == "para6")
                    {
                        ASDefault = ASDgBallSize;
                    }
                    else if (SourceName == "BallType_SCLR")
                    {
                        ASDefault = ASDgBallType;
                    }
                    else if (SourceName == "WireSize_SCLR")
                    {
                        ASDefault = ASDgWireSize;
                    }
                    else if (SourceName == "bom_no")//para8
                    {
                        ASDefault = ASDgBomNo;
                    }
                }
            }
        }
        #endregion


        #region Declaration
        EPR_T001_New MasterEntityCN = new EPR_T001_New();
        bool isNewRecord = true;
        int? sr_no = 0;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        WebServiceRepository<string> repositoryStr = new WebServiceRepository<string>();
        WebServiceRepository<PPC_T004> repository = new WebServiceRepository<PPC_T004>();
        WebServiceRepository<EPR_T001_New> repositoryCN = new WebServiceRepository<EPR_T001_New>();
        WebServiceRepository<MultipleContext_PPC_T004> repository_MC = new WebServiceRepository<MultipleContext_PPC_T004>();
        WebServiceRepository<MultipleContext_PPC_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_PPC_T004>();
        WebServiceRepository<MultipleContext_EPR_T001> repositoryM = new WebServiceRepository<MultipleContext_EPR_T001>();
        MultipleContext_EPR_T001 MCTempEPR_T001 = new MultipleContext_EPR_T001();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_PPC_T004 _MC = new MultipleContext_PPC_T004();
        public MultipleContext_PPC_T004 MC
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
        private List<PPC_T004_B> _SalesOrderInfo;
        public List<PPC_T004_B> SalesOrderInfo
        {
            get { return _SalesOrderInfo; }
            set { _SalesOrderInfo = value; RaisePropertyChanged("SalesOrderInfo"); }
        }
        private MultipleContext_PPC_T004 _MCTemp = new MultipleContext_PPC_T004();
        public MultipleContext_PPC_T004 MCTemp
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

        private MultipleContext_PPC_T004 _MCTemp2 = new MultipleContext_PPC_T004();
        public MultipleContext_PPC_T004 MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value; RaisePropertyChanged("MCTemp2");
                }
            }
        }

        private List<Rpt_BillOfMaterial> _dsReport;
        public List<Rpt_BillOfMaterial> dsReport
        {
            get { return _dsReport; }
            set
            {
                if (_dsReport != value)
                {
                    _dsReport = value;


                    RaisePropertyChanged("dsReport");

                }
            }
        }


        private PPC_T004 _MasterEntity;
        public PPC_T004 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<PPC_T004_A> _MachineDetailEntity;
        public ObservableCollection<PPC_T004_A> MachineDetailEntity
        {
            get { return _MachineDetailEntity; }
            set
            {
                if (_MachineDetailEntity != value)
                {
                    _MachineDetailEntity = value;
                    MachineDetailEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotify_MachineDetailEntity);
                    RaisePropertyChanged("MachineDetailEntity");
                }
            }
        }

        private ObservableCollection<PPC_T004_A> _MachineDetailEntity1;
        public ObservableCollection<PPC_T004_A> MachineDetailEntity1
        {
            get { return _MachineDetailEntity1; }
            set
            {
                if (_MachineDetailEntity1 != value)
                {
                    _MachineDetailEntity1 = value; RaisePropertyChanged("MachineDetailEntity1");
                }
            }
        }


        private ObservableCollection<PPC_T004_B> _SoDetailEntity;
        public ObservableCollection<PPC_T004_B> SoDetailEntity
        {
            get { return _SoDetailEntity; }
            set
            {
                if (_SoDetailEntity != value)
                {
                    _SoDetailEntity = value; RaisePropertyChanged("SoDetailEntity");
                }
            }
        }

        //For Qty Reservation
        WebServiceRepository<MM_T001> repositoryTO = new WebServiceRepository<MM_T001>();
        private MM_T001 _ObjMM_T001;
        public MM_T001 ObjMM_T001
        {
            get
            {
                return _ObjMM_T001;
            }
            set
            {
                if (_ObjMM_T001 != value)
                {
                    _ObjMM_T001 = value;
                    RaisePropertyChanged("ObjMM_T001");
                }
            }
        }



        private List<MM_T001_A> _ObjMM_T001_A;
        public List<MM_T001_A> ObjMM_T001_A
        {
            get { return _ObjMM_T001_A; }
            set
            {
                if (_ObjMM_T001_A != value)
                {
                    _ObjMM_T001_A = value;

                    RaisePropertyChanged("ObjMM_T001_A");

                }
            }
        }
        private string _plant_main;
        public string plant_main
        {
            get { return _plant_main; }
            set
            {
                if (_plant_main != value)
                {
                    _plant_main = value;

                    RaisePropertyChanged("plant_main");

                }
            }
        }

        private List<MM_T001_B> _ObjMM_T001_B;
        public List<MM_T001_B> ObjMM_T001_B
        {
            get { return _ObjMM_T001_B; }
            set
            {
                if (_ObjMM_T001_B != value)
                {
                    _ObjMM_T001_B = value;

                    RaisePropertyChanged("ObjMM_T001_B");

                }
            }
        }

        // local variable
        List<SEL_T001_P1> TempalesOrders = new List<SEL_T001_P1>();
        List<SEL_T001_P1> result1 = new List<SEL_T001_P1>();
        List<EPR_T001_P1> CurrentList = new List<EPR_T001_P1>();
        //List<EPR_T001_P1> curr = new List<EPR_T001_P1>();
        //private SEL_T001_P1 _SELECTED_ORDER;
        //public SEL_T001_P1 SELECTED_ORDER
        //{
        //    get { return _SELECTED_ORDER; }
        //    set
        //    {
        //        if (_SELECTED_ORDER != value)
        //        {
        //            _SELECTED_ORDER = value;

        //            RaisePropertyChanged("SELECTED_ORDER");

        //        }
        //    }
        //}
        private PPC_T004_A _PPC_T004_A_OBJ;
        public PPC_T004_A PPC_T004_A_OBJ
        {
            get
            {
                return _PPC_T004_A_OBJ;
            }
            set
            {
                if (_PPC_T004_A_OBJ != value)
                {
                    _PPC_T004_A_OBJ = value;
                    RaisePropertyChanged("PPC_T004_A_OBJ");
                }
            }
        }
        private EPR_T001_P1 _EPR_T001_P1_OBJ;
        public EPR_T001_P1 EPR_T001_P1_OBJ
        {
            get
            {
                return _EPR_T001_P1_OBJ;
            }
            set
            {
                if (_EPR_T001_P1_OBJ != value)
                {
                    _EPR_T001_P1_OBJ = value;
                    RaisePropertyChanged("EPR_T001_P1_OBJ");
                }
            }
        }
        public SEL_T001_P1 _SEL_T001_P1_OBJ;
        public SEL_T001_P1 SEL_T001_P1_OBJ
        {
            get { return _SEL_T001_P1_OBJ; }
            set
            {
                _SEL_T001_P1_OBJ = value;
                RaisePropertyChanged("SEL_T001_P1_OBJ");
            }
        }

        #endregion

        #region . Index .
        private int _dgSelectedIndexselectedSODetails;
        public int dgSelectedIndexselectedSODetails
        {
            get { return _dgSelectedIndexselectedSODetails; }
            set
            {
                if (_dgSelectedIndexselectedSODetails != value)
                {
                    _dgSelectedIndexselectedSODetails = value;
                    RaisePropertyChanged("dgSelectedIndexselectedSODetails");

                }
            }
        }

        private int _dgSelectedIndexCurrentMcDetails;
        public int dgSelectedIndexCurrentMcDetails
        {
            get { return _dgSelectedIndexCurrentMcDetails; }
            set
            {
                if (_dgSelectedIndexCurrentMcDetails != value)
                {
                    _dgSelectedIndexCurrentMcDetails = value;
                    RaisePropertyChanged("dgSelectedIndexCurrentMcDetails");

                }
            }
        }

        private int _dgSelectedIndexPlanMCDetail;
        public int dgSelectedIndexPlanMCDetail
        {
            get { return _dgSelectedIndexPlanMCDetail; }
            set
            {
                if (_dgSelectedIndexPlanMCDetail != value)
                {
                    _dgSelectedIndexPlanMCDetail = value;
                    FilterCollectionsOnItemCodeSelection();
                    RaisePropertyChanged("dgSelectedIndexPlanMCDetail");
                }
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

        private int _dgSelectedIndexSoData;
        public int dgSelectedIndexSoData
        {
            get { return _dgSelectedIndexSoData; }
            set
            {
                if (_dgSelectedIndexSoData != value)
                {
                    _dgSelectedIndexSoData = value;
                    RaisePropertyChanged("dgSelectedIndexSoData");
                }
            }
        }
        #endregion

        #region . StringList .

        private string _ItemCodeScalar;
        public string ItemCodeScalar
        {
            get { return _ItemCodeScalar; }
            set
            {
                if (_ItemCodeScalar != value)
                {
                    _ItemCodeScalar = value;
                    RaisePropertyChanged("ItemCodeScalar");
                }
            }
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

        private List<EPR_T004_AMRPReportEntity> _RptMRP;
        public List<EPR_T004_AMRPReportEntity> RptMRP
        {
            get { return _RptMRP; }
            set
            {
                if (_RptMRP != value)
                {
                    _RptMRP = value;
                    RaisePropertyChanged("RptMRP");
                }
            }
        }

        public List<EPR_T001_P1> _CurrentMachineList = new List<EPR_T001_P1>();
        public List<EPR_T001_P1> CurrentMachineList
        {
            get { return _CurrentMachineList; }
            set
            {
                _CurrentMachineList = value;
                RaisePropertyChanged("CurrentMachineList");
            }
        }

        public List<ADM_M003> _plantList;
        public List<ADM_M003> plantList
        {
            get { return _plantList; }
            set
            {
                _plantList = value;
                RaisePropertyChanged("plantList");
            }
        }

        private List<PPC_T004_P> _FlipGridData;
        public List<PPC_T004_P> FlipGridData
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

        private List<SEL_T001_P1> _SalesOrderData;
        public List<SEL_T001_P1> SalesOrderData
        {
            get { return _SalesOrderData; }
            set
            {
                if (_SalesOrderData != value)
                {
                    _SalesOrderData = value;
                    RaisePropertyChanged("SalesOrderData");
                }
            }
        }

        List<string> _StringListIldChartData;
        public List<string> StringListIldChartData
        {
            get { return _StringListIldChartData; }
            set
            {
                if (_StringListIldChartData != value)
                {
                    _StringListIldChartData = value;
                }
            }
        }

        List<string> _StringListSalesOrderData;
        public List<string> StringListSalesOrderData
        {
            get { return _StringListSalesOrderData; }
            set
            {
                if (_StringListSalesOrderData != value)
                {
                    _StringListSalesOrderData = value;
                }
            }
        }

        List<string> _StringListBallSize;
        public List<string> StringListBallSize
        {
            get { return _StringListBallSize; }
            set
            {
                if (_StringListBallSize != value)
                {
                    _StringListBallSize = value;
                }
            }
        }

        List<string> _StringListBallType;
        public List<string> StringListBallType
        {
            get { return _StringListBallType; }
            set
            {
                if (_StringListBallType != value)
                {
                    _StringListBallType = value;
                }
            }
        }

        List<string> _StringListWireSize;
        public List<string> StringListWireSize
        {
            get { return _StringListWireSize; }
            set
            {
                if (_StringListWireSize != value)
                {
                    _StringListWireSize = value;
                }
            }
        }

        List<string> _StringListMachine;
        public List<string> StringListMachine
        {
            get { return _StringListMachine; }
            set
            {
                if (_StringListMachine != value)
                {
                    _StringListMachine = value;
                }
            }
        }

        List<string> _StringListMachine1;
        public List<string> StringListMachine1
        {
            get { return _StringListMachine1; }
            set
            {
                if (_StringListMachine1 != value)
                {
                    _StringListMachine1 = value;
                }
            }
        }


        private List<string> _StringListUnit;
        public List<string> StringListUnit
        {
            get { return _StringListUnit; }
            set
            {
                if (_StringListUnit != value)
                {
                    _StringListUnit = value;
                }
            }
        }

        private List<string> _StringListItem;
        public List<string> StringListItem
        {
            get { return _StringListItem; }
            set
            {
                if (_StringListItem != value)
                {
                    _StringListItem = value;
                }
            }
        }

        private List<string> _StringListInk;
        public List<string> StringListInk
        {
            get { return _StringListInk; }
            set
            {
                if (_StringListInk != value)
                {
                    _StringListInk = value;
                }
            }
        }

        private List<string> _StringListILD;
        public List<string> StringListILD
        {
            get { return _StringListILD; }
            set
            {
                if (_StringListILD != value)
                {
                    _StringListILD = value;
                }
            }
        }

        List<string> _StringListPlant;
        public List<string> StringListPlant
        {
            get { return _StringListPlant; }
            set
            {
                if (_StringListPlant != value)
                {
                    _StringListPlant = value;
                }
            }
        }
        //        

        List<string> _StringListWireType;
        public List<string> StringListWireType
        {
            get { return _StringListWireType; }
            set
            {
                if (_StringListWireType != value)
                {
                    _StringListWireType = value;
                }
            }
        }

        private List<string> _StringListSpecPara;
        public List<string> StringListSpecPara
        {
            get { return _StringListSpecPara; }
            set
            {
                if (_StringListSpecPara != value)
                {
                    _StringListSpecPara = value;
                }
            }
        }

        private List<string> _StringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _StringListBallMake; }
            set
            {
                if (_StringListBallMake != value)
                {
                    _StringListBallMake = value;
                }
            }
        }

        private List<string> _StringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _StringListWireMake; }
            set
            {
                if (_StringListWireMake != value)
                {
                    _StringListWireMake = value;
                }
            }
        }

        private List<string> _StringListBOM_No;
        public List<string> StringListBOM_No
        {
            get { return _StringListBOM_No; }
            set
            {
                if (_StringListBOM_No != value)
                {
                    _StringListBOM_No = value;
                }
            }
        }
        #endregion

        #region . ICollection .

        public ObservableCollection<EPR_T001_P1> _CurrentMachineCollection;
        public ObservableCollection<EPR_T001_P1> CurrentMachineCollection
        {
            get { return _CurrentMachineCollection; }
            set
            {
                _CurrentMachineCollection = value;
                RaisePropertyChanged("CurrentMachineCollection");
            }
        }

        public ICollectionView _SelectedSoDetailCollection;
        public ICollectionView SelectedSoDetailCollection
        {
            get { return _SelectedSoDetailCollection; }
            set
            {
                _SelectedSoDetailCollection = value;
                RaisePropertyChanged("SelectedSoDetailCollection");
            }
        }

        private ICollectionView _BackFlipCollection;
        public ICollectionView BackFlipCollection
        {
            get { return _BackFlipCollection; }
            set { _BackFlipCollection = value; RaisePropertyChanged("BackFlipCollection"); }
        }

        private ICollectionView _IldChartCollection;
        public ICollectionView IldChartCollection
        {
            get { return _IldChartCollection; }
            set { _IldChartCollection = value; RaisePropertyChanged("IldChartCollection"); }
        }

        private ICollectionView _SalesOrderCollection;
        public ICollectionView SalesOrderCollection
        {
            get { return _SalesOrderCollection; }
            set { _SalesOrderCollection = value; RaisePropertyChanged("SalesOrderCollection"); }
        }

        private ICollectionView _BallSizeCollection;
        public ICollectionView BallSizeCollection
        {
            get { return _BallSizeCollection; }
            set { _BallSizeCollection = value; RaisePropertyChanged("BallSizeCollection"); }
        }

        private ICollectionView _BallTypeCollection;
        public ICollectionView BallTypeCollection
        {
            get { return _BallTypeCollection; }
            set { _BallTypeCollection = value; RaisePropertyChanged("BallTypeCollection"); }
        }

        private ICollectionView _WireSizeCollection;
        public ICollectionView WireSizeCollection
        {
            get { return _WireSizeCollection; }
            set { _WireSizeCollection = value; RaisePropertyChanged("WireSizeCollection"); }
        }

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set { _MachineCollection = value; RaisePropertyChanged("MachineCollection"); }
        }

        private ICollectionView _MachineCollection1;
        public ICollectionView MachineCollection1
        {
            get { return _MachineCollection1; }
            set { _MachineCollection1 = value; RaisePropertyChanged("MachineCollection1"); }
        }

        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set { _UnitCollection = value; RaisePropertyChanged("UnitCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set
            {
                _InkCollection = value;
                RaisePropertyChanged("InkCollection");
            }
        }

        private ICollectionView _ILDCollection;
        public ICollectionView ILDCollection
        {
            get { return _ILDCollection; }
            set
            {
                _ILDCollection = value;
                RaisePropertyChanged("ILDCollection");
            }
        }

        private ICollectionView _plantCollection;
        public ICollectionView plantCollection
        {
            get { return _plantCollection; }
            set { _plantCollection = value; RaisePropertyChanged("plantCollection"); }
        }

        private ICollectionView _SoCollection1;
        public ICollectionView SoCollection1
        {
            get { return _SoCollection1; }
            set { _SoCollection1 = value; RaisePropertyChanged("SoCollection1"); }
        }


        private List<PPC_T004_B> _SoCollection;
        public List<PPC_T004_B> SoCollection
        {
            get { return _SoCollection; }
            set { _SoCollection = value; RaisePropertyChanged("SoCollection"); }
        }

        private List<PPC_T004_B> _SoData;
        public List<PPC_T004_B> SoData
        {
            get { return _SoData; }
            set { _SoData = value; RaisePropertyChanged("SoData"); }
        }

        //
        private ICollectionView _BallMakeCollection;
        public ICollectionView BallMakeCollection
        {
            get { return _BallMakeCollection; }
            set
            {
                _BallMakeCollection = value;
                RaisePropertyChanged("BallMakeCollection");
            }
        }

        private ICollectionView _WireMakeCollection;
        public ICollectionView WireMakeCollection
        {
            get { return _WireMakeCollection; }
            set
            {
                _WireMakeCollection = value;
                RaisePropertyChanged("WireMakeCollection");
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

        private ICollectionView _BOM_NoCollection;
        public ICollectionView BOM_NoCollection
        {
            get { return _BOM_NoCollection; }
            set
            {
                _BOM_NoCollection = value;
                RaisePropertyChanged("BOM_NoCollection");
            }
        }

        #endregion

        #region . Relay Command Declaration .  
        public RelayCommand<object> cmdInsert_t_status { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdClearFilterData { get; private set; }
        public RelayCommand<object> cmdProductionOrder { get; private set; }
        public RelayCommand<object> cmdProductionOrderPrint { get; private set; }
        public RelayCommand<object> cmdInsertReservation { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdAddSelectedData { get; private set; }
        public RelayCommand<object> cmdShowMachineStatusForSelectedItem { get; private set; }
        public RelayCommand<object> cmdAddMachineAndPlant { get; private set; }
        public RelayCommand<object> cmdInsertPlanningData { get; private set; }
        public RelayCommand<object> CmdCancleSelectedSO { get; private set; }

        //Machine Detail Entity PopUp Methods

        public RelayCommand<object> cmdInsertPlantOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertMachineOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertUnitOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertItemOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertInkOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertIldOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertBallMakeOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertBallSizeOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertWireMakeOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertWireSizeOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertBallTypeOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertBOMNoOnMachineDetailEntity { get; private set; }

        //for current machine filter

        public RelayCommand<object> cmdInsertBallSize { get; private set; }
        public RelayCommand<object> cmdInsertBallType { get; private set; }
        public RelayCommand<object> cmdInsertWireSize { get; private set; }
        public RelayCommand<object> cmdInsertPlant { get; private set; }
        public RelayCommand<object> cmdInsertPlantMain { get; private set; }
        public RelayCommand<object> cmdInsertWireType { get; private set; }

        //Planning PopUp For Machine And Plant
        public RelayCommand<object> cmdInsertMachine { get; private set; }
        public RelayCommand<object> cmdInsertPlantforPlanning { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowPlanMachine { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> cmdCheckPlanQty { get; private set; }

        //Added By Mayuri
        public GalaSoft.MvvmLight.Command.RelayCommand LoadMRPReports { get; private set; }
        public RelayCommand<object> CommandForAddAttachment { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }

        public RelayCommand<object> cmdToolTipPlanning { get; private set; }
        public RelayCommand<object> cmdToolTipILDChart { get; private set; }
        public RelayCommand<object> cmdToolTipPlanningTemp { get; private set; }
        public RelayCommand<object> cmdSelectionChangeFinalPlant { get; private set; }
        public RelayCommand<object> cmdInsertPkUnitOnMachineDetailEntity { get; private set; }
        public RelayCommand<object> cmdInsertStore_codeOnMachineDetailEntity { get; private set; }

        #endregion

        #region . Constructor .

        public PPC_T004_VM() : base()
        {
            MasterEntity = new PPC_T004();
            FlipGridData = new List<PPC_T004_P>();
            MachineDetailEntity = new ObservableCollection<PPC_T004_A>();
            SoDetailEntity = new ObservableCollection<PPC_T004_B>();
            CurrentMachineCollection = new ObservableCollection<EPR_T001_P1>();
            result1 = new List<SEL_T001_P1>();
            MC.SalesOrderList = new List<SEL_T001_P1>();
            SoCollection = new List<PPC_T004_B>();
            SoData = new List<PPC_T004_B>();
            SalesOrderInfo = new List<PPC_T004_B>();
            MasterEntity.ValidateAsync().Wait();
            TempalesOrders = new List<SEL_T001_P1>();
            EPR_T001_P1_OBJ = new EPR_T001_P1();
            DefaultValues();
            //PPC_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();
        }
        public PPC_T004_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PPC_T004();
            FlipGridData = new List<PPC_T004_P>();
            MachineDetailEntity = new ObservableCollection<PPC_T004_A>();
            SoDetailEntity = new ObservableCollection<PPC_T004_B>();
            CurrentMachineCollection = new ObservableCollection<EPR_T001_P1>();
            result1 = new List<SEL_T001_P1>();
            MC.SalesOrderList = new List<SEL_T001_P1>();
            SoCollection = new List<PPC_T004_B>();
            SoData = new List<PPC_T004_B>();
            SalesOrderInfo = new List<PPC_T004_B>();
            MasterEntity.ValidateAsync().Wait();
            TempalesOrders = new List<SEL_T001_P1>();
            EPR_T001_P1_OBJ = new EPR_T001_P1();
            DefaultValues();
            //PPC_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();
        }
        public PPC_T004_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PPC_T004();
            FlipGridData = new List<PPC_T004_P>();
            MachineDetailEntity = new ObservableCollection<PPC_T004_A>();
            SoDetailEntity = new ObservableCollection<PPC_T004_B>();
            CurrentMachineCollection = new ObservableCollection<EPR_T001_P1>();
            result1 = new List<SEL_T001_P1>();
            MC.SalesOrderList = new List<SEL_T001_P1>();
            SoCollection = new List<PPC_T004_B>();
            SoData = new List<PPC_T004_B>();
            SalesOrderInfo = new List<PPC_T004_B>();
            MasterEntity.ValidateAsync().Wait();
            TempalesOrders = new List<SEL_T001_P1>();
            EPR_T001_P1_OBJ = new EPR_T001_P1();
            DefaultValues();
            //PPC_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();
        }
        #endregion

        #region ModelEntityUpdated
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "production_date_start" && MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty > 0 && MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_date_start != null)
                {
                    PPC_M001_P MCN = MC.MachineList.Where(x => x.wc_code == MachineDetailEntity[dgSelectedIndexPlanMCDetail].wc_code).ToList()[0];
                    //PPC_M001_P MCN = MC.MachineList.Where(x => x.wc_code.Equals(MachineDetailEntity[dgSelectedIndexPlanMCDetail].wc_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    if (MCN.cycle_time > 0)
                    {
                        decimal? days = MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty / (MCN.cycle_time * 60 * 8);
                        int DaysInt = 0;
                        if ((days % 1) == 0)
                        {
                            DaysInt = Convert.ToInt32(days);
                        }
                        else
                        {
                            DaysInt = Convert.ToInt32(days) + 1;
                        }
                        MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_date_finish = Convert.ToDateTime(MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_date_start).AddDays(DaysInt);
                    }
                }
                if (MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail && dgSelectedIndexPlanMCDetail >= 0)
                {
                    this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
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

        #region CollectionChangedNotifyForTestType

        private void CollectionChangedNotify_MachineDetailEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {

                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PPC_T004_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PPC_T004_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PPC_T004_A item in e.NewItems)
                    {
                        item.sr_no = sr_no++;
                        item.line_id = MachineDetailEntity.Count;
                        item.client = AppSessionState.client;
                        item.PropertyChanged += EntityViewModelPropertyChanged;

                        if ((item.location_Id != "" || item.location_Id != null) || (item.wc_code != "" || item.wc_code != null))
                        {
                            foreach (var T in TempalesOrders)
                            {
                                if (item.ItemCode == T.ItemCode && item.comp_code == T.comp_code)
                                {
                                    var InputValueIfExists = SoDetailEntity.Where(X => X.line_id == item.line_id && X.sono == T.sono && X.ItemCode == T.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                                    if (InputValueIfExists == null)
                                    {
                                        SoDetailEntity.Add(new PPC_T004_B()
                                        {
                                            id = 0,
                                            line_id = item.line_id,
                                            active = item.active,
                                            location_Id = item.location_Id,
                                            sono = T.sono,
                                            comp_code = item.comp_code,
                                            add_by = AppSessionState.UserID,
                                            ItemCode = item.ItemCode,
                                            machine_no = item.machine_no,
                                            unit_code = item.unit_code,
                                            so_item_row_id = T.id,
                                            qty = T.plan_qty_for_SO,
                                            plan_item_row_id = item.id
                                        });
                                    }
                                }
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            { }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail && dgSelectedIndexPlanMCDetail >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        #endregion
        private bool ValidationForMRP_Report()
        {
            if (MachineDetailEntity.Count > 0 && dgSelectedIndexPlanMCDetail > -1 && dgSelectedIndexPlanMCDetail < MachineDetailEntity.Count)
            {
                if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no == null || MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select BOM no");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode == null || MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Product Code");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty == null || MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty < 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Total Quantity ");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code == null || MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Unit  ");
                    showMessageService.ShowMessage();
                    return false;
                }
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("No Record is Present For MRP Report....... \n please enter mandatory fields");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }

        //New Logic implemented For MRP Report
        //LOGIC : MRP Report Generation as per BOM no same as BOM Report for MRP 
        private void MRPReport()
        {

            if (ValidationForMRP_Report() == true)
            {

                int plan_qty_Temp = Convert.ToInt32(MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty);

                string RequestParameter = "LoadMRPReports" + "!@" + MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no + "!@" + MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode + "!@" + plan_qty_Temp.ToString() + "!@" + MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code + "!@" + MasterEntity.comp_code;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T004>(MCTemp, RequestParameter, "ProductionPlanning", "Production", "", 0, RequestParameter);

                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[0] = MCTemp.MRPRpt;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;

                objDataSourceName[0] = "dsRpt_BillOfMaterial";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\BillOfMaterialMRP.rdlc", getParametersList(), "");

            }
        }


        private void LoadAttachment(object InputValue)
        {
            try
            {
                string Request = "";
                if (dgSelectedIndexPlanMCDetail != -1)
                {
                    if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode != null)
                    {
                        ItemCodeScalar = MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode;

                        Request = "LoadAttachment" + "!@" + ItemCodeScalar;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T004>(MCTemp, Request, "ProductionPlanning", "Production", "LoadAll", 0, Request);

                        AttachmentCollection = MCTemp.Attachment;

                        if (MCTemp.Attachment != null)
                        {
                            AttachmentCollection = MCTemp.Attachment;
                        }
                        else
                        {
                            MCTemp.Attachment = new List<COM_T003>();
                        }

                        isNewRecord = false;
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

        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                result.Add("doc_no", MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no);
                result.Add("ItemName", MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemName);
                result.Add("ItemCode", MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }

        #region User Defined Functions


        private void Insert_t_status(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.t_statusList.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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
        private void InsertReservation(object InputValue)
        {
            try
            {
                SEL_T001_P1 POPUPEntityObject = null;

                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T001_P1>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P1>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    if (MC.SalesOrderList.Count > 0 && dgSelectedIndexSoData < MC.SalesOrderList.Count)
                    {
                        ObjMM_T001 = new MM_T001();

                        ObjMM_T001.post_date = DateTime.Now;
                        ObjMM_T001.comp_code = AppSessionState.comp_code;
                        ObjMM_T001.client = AppSessionState.client;
                        ObjMM_T001.doc_code = "MI";
                        ObjMM_T001.doc_cat = "MI";
                        ObjMM_T001.doc_type = "MI";
                        ObjMM_T001.doc_date = DateTime.Now;
                        ObjMM_T001.add_date = DateTime.Now;
                        ObjMM_T001.add_by = AppSessionState.UserID;
                        ObjMM_T001.location_Id = AppSessionState.location_Id;
                        ObjMM_T001.active = true;
                        ObjMM_T001.t_status = "001";
                        ObjMM_T001.mov_tp = "114";
                        ObjMM_T001.ts_code = "MM01";
                        ObjMM_T001_A = new List<MM_T001_A>();
                        ObjMM_T001_B = new List<MM_T001_B>();

                        ObjMM_T001_A.Add(new MM_T001_A()
                        {
                            id = 0,
                            line_id = 0,
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,
                            doc_type = "MI",
                            doc_cat = "MI",
                            ItemCode = POPUPEntityObject.ItemCode,
                            unit_code = POPUPEntityObject.unit_code,
                            debcr_ind = "CD",
                            qty = POPUPEntityObject.Reserve_Stock,
                            // qty = POPUPEntityObject.stock_reserve,
                            active = true,
                            store_code = "001",
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            add_date = DateTime.Now,
                            sono = POPUPEntityObject.sono,
                            PartyId = POPUPEntityObject.PartyId,
                        });

                        //ObjMM_T001_B.Add(new MM_T001_B()
                        //{
                        //    id = 0,
                        //    comp_code = AppSessionState.comp_code,
                        //    client = AppSessionState.client,
                        //    item_line_id = 0,
                        //    ItemCode = POPUPEntityObject.ItemCode,
                        //    location_Id = AppSessionState.location_Id,
                        //    unit_code = POPUPEntityObject.unit_code,
                        //    qty = POPUPEntityObject.Reserve_Stock,
                        //    //qty = POPUPEntityObject.stock_reserve,
                        //    add_by = AppSessionState.UserID,
                        //    active = true,
                        //    store_code = "001",

                        //});

                        //Server Trip for Insert in material issue
                        ObjectSerializationService objSer = new ObjectSerializationService();
                        ObjMM_T001.XmlDataDocument_MM_T001 = objSer.ObjectToXML(ObjMM_T001_A);
                        //ObjMM_T001.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(ObjMM_T001_B);

                        ObjMM_T001 = repositoryTO.SaveWithReturnDomainObject<SEL_T004>(ObjMM_T001, "Goods_Issue", "SCM");

                        if (ObjMM_T001.doc_no != null)
                        {

                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Qty Reserve Sucessfully - {0}", ObjMM_T001.doc_no);
                            showMessageService.ShowMessage();
                        }
                    }
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    DefaultValues();
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
        private void ClearFilterData(object InputValue)
        {
            MasterEntity.location_Id3 = null;
            MasterEntity.LocationNm3 = null;
            MasterEntity.wire_size = null;
            MasterEntity.wire_size_id = null;
            MasterEntity.wire_type_id = null;
            MasterEntity.wire_type = null;
            MasterEntity.ball_dia_id = null;
            MasterEntity.Ball_dia = null;
            MasterEntity.ball_type_id = null;
            MasterEntity.ball_type = null;
            FilterForFields();
        }
        private void InsertProductionOrder(object InputValue)
        {
            try
            {
                //EPR_T001_New MasterEntityCN = new EPR_T001_New();
                PPC_T004_A POPUPEntityObject = null;

                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_T004_A>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T004_A>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null && MasterEntity.plan_no != null && POPUPEntityObject.order_exists == false)
                {
                    MasterEntityCN.doc_cat = "CN";
                    MasterEntityCN.doc_type = "CN";
                    MasterEntityCN.order_type = "N";
                    MasterEntityCN.location_Id = POPUPEntityObject.production_plant;
                    MasterEntityCN.comp_code = POPUPEntityObject.comp_code;
                    MasterEntityCN.add_by = AppSessionState.UserID;
                    MasterEntityCN.editby = AppSessionState.UserID;
                    MasterEntityCN.start_dt = POPUPEntityObject.production_date_start;
                    MasterEntityCN.pro_dt = POPUPEntityObject.production_date_start;
                    MasterEntityCN.client = AppSessionState.client;
                    MasterEntityCN.active = true;
                    MasterEntityCN.appr = true;
                    MasterEntityCN.status = "001";

                    MasterEntityCN.ball_dia = POPUPEntityObject.para6;
                    MasterEntityCN.ball_make_id = Convert.ToInt32(POPUPEntityObject.para3);
                    MasterEntityCN.ball_type_id = Convert.ToInt32(POPUPEntityObject.para7);
                    MasterEntityCN.conv = 1; //*****************************************************
                    MasterEntityCN.Conv_lot = ""; //*****************************************************
                    MasterEntityCN.end_dt = POPUPEntityObject.production_date_finish;
                    MasterEntityCN.id = 0;
                    MasterEntityCN.ild_id = Convert.ToInt32(POPUPEntityObject.para5);
                    MasterEntityCN.ink_id = Convert.ToInt32(POPUPEntityObject.para1);
                    MasterEntityCN.ink = POPUPEntityObject.ink_SCLR;
                    MasterEntityCN.ild = POPUPEntityObject.ild_SCLR;
                    MasterEntityCN.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntityCN.ItemName = POPUPEntityObject.ItemName;
                    MasterEntityCN.lifeTest = false;
                    MasterEntityCN.machinecode = POPUPEntityObject.machine_no;
                    MasterEntityCN.machine_id = Convert.ToInt32(POPUPEntityObject.machine_id);
                    MasterEntityCN.prod_plan = POPUPEntityObject.plan_no;
                    MasterEntityCN.qty = POPUPEntityObject.plan_qty;
                    MasterEntityCN.ref_doc_no = POPUPEntityObject.plan_no;
                    MasterEntityCN.ref_doc_type = "PP";
                    MasterEntityCN.unit_code = POPUPEntityObject.unit_code;
                    MasterEntityCN.plan_item_row_id = POPUPEntityObject.id;
                    MasterEntityCN.order_no = POPUPEntityObject.order_no;
                    MasterEntityCN.pre_order_no = POPUPEntityObject.pre_order_no;
                    MasterEntityCN.wc_code = POPUPEntityObject.wc_code;
                    MasterEntityCN.PartyId = POPUPEntityObject.PartyId;
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.para4))
                    {
                        MasterEntityCN.model_id = Convert.ToInt32(POPUPEntityObject.para4);  //Add Sontosh
                        MasterEntityCN.model_code = POPUPEntityObject.para9;
                    }
                    MasterEntityCN.ball_type = POPUPEntityObject.BallType_SCLR;
                    MasterEntityCN.ball_make = POPUPEntityObject.BallMake_SCLR;
                    MasterEntityCN.wire_make = POPUPEntityObject.WireMake_SCLR;
                    MasterEntityCN.wire_size_id = Convert.ToInt32(POPUPEntityObject.para8);
                    MasterEntityCN.wire_size = Convert.ToDecimal(POPUPEntityObject.WireSize_SCLR);
                    MasterEntityCN.pack_style = POPUPEntityObject.pack_style;
                    MasterEntityCN.store_code = POPUPEntityObject.store_code;
                    MasterEntityCN.ts_code = (from o in MC.DocCategoryList where o.doc_cat == MasterEntity.doc_cat select o.ts_code_cn).FirstOrDefault();
                    MasterEntityCN = repositoryCN.SaveWithReturnDomainObject<EPR_T001_New>(MasterEntityCN, "ConversionNote2", "Production");
                    if (MasterEntityCN.order_no != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format(MasterEntityCN.order_no + " Production Order created Successfully!");
                        showMessageService.ShowMessage();
                        MachineDetailEntity[dgSelectedIndexPlanMCDetail].order_exists = true;
                    }

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format(MasterEntityCN.order_no + " Production Order already created or planning data not available!");
                    showMessageService.ShowMessage();
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertProductionOrderPrint(object InputValue)
        {
            try
            {

                PPC_T004_A POPUPEntityObject = null;

                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_T004_A>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T004_A>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null && MasterEntity.plan_no != null && POPUPEntityObject.order_exists == true)
                {
                    string request = "";
                    request = POPUPEntityObject.comp_code.ToString() + "!@" + POPUPEntityObject.location_Id + "!@" + POPUPEntityObject.machine_id.ToString() + "!@" + MasterEntityCN.order_no + "!@" + MasterEntityCN.pre_order_no + "!@" + POPUPEntityObject.id.ToString();

                    MCTempEPR_T001 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTempEPR_T001, "EPR_T001_Data", "ILDChart", "Production", "RPTConversion", 0, request);

                    object[] objDataSource = new object[5];
                    string[] objDataSourceName = new string[5];

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == POPUPEntityObject.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == POPUPEntityObject.location_Id).ToList();
                    var Result1 = MCTempEPR_T001.RPTINK.Where(CN => CN.plan_item_row_id == POPUPEntityObject.id).ToList();
                    var Result2 = MCTempEPR_T001.RPTINK.Where(CN => CN.plan_item_row_id != POPUPEntityObject.id).ToList();
                    //var Result1 = MCTempEPR_T001.RPTINK.Where(CN => CN.order_no == MasterEntityCN.order_no).ToList();
                    //var Result2 = MCTempEPR_T001.RPTINK.Where(CN => CN.order_no != MasterEntityCN.order_no).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = Result1;
                    objDataSource[3] = Result2;
                    objDataSource[4] = MCTempEPR_T001.Rptapproval;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "DSILDInk";
                    objDataSourceName[3] = "DSILDInk1";
                    objDataSourceName[4] = "dsRptapproval";


                    ReportManager ReportManager = new ReportManager();

                    string ReportDisplayName = POPUPEntityObject.order_no;
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\" + MCTempEPR_T001.DocumentTypes[0].report_name, getParametersListOrder(), ReportDisplayName);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format(MasterEntityCN.order_no + " Production Order not generated!");
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
        private Dictionary<string, string> getParametersListOrder()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                var filepath = new Uri(@"E:\Reflection_TFS\Client\Reflection.Shell\Reflection.Presentation.Resources\Images\Emp17.jpg");
                var path = filepath.AbsolutePath;
                result.Add("ImagePath", path);
                //result.Add("prepare_by", AppSessionState.Name);
                //result.Add("doc_no", MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no);
                //result.Add("ItemName", MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemName);
                //result.Add("ItemCode", MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                PPC_T004_P ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<PPC_T004_P>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PPC_T004_P>().ToList()[0];
                        isNewRecord = false;

                        string Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + ParameterEntityObject.plan_no;
                        MasterEntity = repository.GetDataWithReturnDomainObject<MultipleContext_PPC_T004>(MasterEntity, Request, "ProductionPlanning", "Production", "LoadDocumentByDocumentNumber", 0, "");

                        SetBusinessEntitiesAfterLoad("", "");

                        SelectedTabControlIndex = 0;


                        // FilterCollectionsOnItemCodeSelection();
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void PkUnitOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M017_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.PkgUnitList.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M017_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null && PPC_T004_A_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.unit_code))
                    {
                        PPC_T004_A_OBJ.pack_style = POPUPEntityObject.id;
                        PPC_T004_A_OBJ.pk_unit_code = POPUPEntityObject.unit_code;
                    }
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void store_codeOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.store.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].store_code = POPUPEntityObject.store_code;
                            //MachineDetailEntity[dgSelectedIndexPlanMCDetail].pk_unit_code = POPUPEntityObject.unit_code;

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].store_code != POPUPEntityObject.store_code)
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].store_code = POPUPEntityObject.store_code;
                            //MachineDetailEntity[dgSelectedIndexPlanMCDetail].pk_unit_code = POPUPEntityObject.unit_code;

                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadHistory" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.fltr_t_status + "!@" + MasterEntity.Fltr_active + "!@" + AppSessionState.client;
                MCTemp2 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T004>(MCTemp2, Request, "ProductionPlanning", "Production", "LoadHistory", 0, "");

                FlipGridData = MCTemp2.BackflipList.ToList();
                BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackFlipCollection.Filter = new Predicate<object>(Filter_BackFlip);

                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void AddSelectedSoDataOnGrid(object InputValue)
        {
            SEL_T001_P1 POPUPEntityObject = null;
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T001_P1>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P1>().ToList()[0];
                    }
                }

                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = TempalesOrders.Where(x => x.ItemCode == POPUPEntityObject.ItemCode && x.sono == POPUPEntityObject.sono).FirstOrDefault();
                    int IndexOfExistValue = TempalesOrders.IndexOf(TempalesOrders.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sono == POPUPEntityObject.sono).FirstOrDefault());
                    //if (IndexOfExistValue == -1)
                    //{

                    TempalesOrders.Add(POPUPEntityObject);

                    if (TempalesOrders.Count > 0)
                    {
                        result1 = TempalesOrders.GroupBy(l => new { l.ItemCode,l.sku, l.location_Id }).Select(cl => new SEL_T001_P1
                        {
                            ItemCode = cl.First().ItemCode,
                            ItemName = cl.First().ItemName,
                            sku = cl.First().sku,
                            //Balence_Qty = cl.Sum(c => c.Balence_Qty),  //Old Code
                            Balence_Qty = cl.Sum(c => c.plan_qty_for_SO),
                            location_Id = cl.First().location_Id,
                            id = cl.First().id,
                            Ink = cl.First().Ink,
                            Ild = cl.First().Ild,
                            ball_dia = cl.First().ball_dia,
                            ball_type = cl.First().ball_type,
                            wire_size = cl.First().wire_size,
                            PartyId = cl.First().PartyId,
                            party_name = cl.First().party_name,
                            unit_code = cl.First().unit_code,
                            stock_total = cl.First().stock_total,
                            stock_in_transit = cl.First().stock_in_transit,
                            stock_reserve = cl.First().stock_reserve,
                            stock_unr = cl.First().stock_unr,
                            MinQty = cl.First().MinQty,
                            MaxQty = cl.First().MaxQty,
                            Reorder = cl.First().Reorder,
                            sono = cl.First().sono,
                            model_id = cl.First().model_id,
                            model_code = cl.First().model_code

                        }).ToList();

                        SelectedSoDetailCollection = CollectionViewSource.GetDefaultView(result1.ToList());
                    }

                    //if (TempalesOrders.Count > 0)
                    //{
                    //    if (POPUPEntityObject.sono == "" || POPUPEntityObject.sono == null)
                    //    {
                    //        SoDetailEntity.Add(new PPC_T004_B()
                    //        {
                    //            id = 0,
                    //            line_id = 0,
                    //            active = true,
                    //            sono = POPUPEntityObject.sono,
                    //            qty = POPUPEntityObject.plan_qty_for_SO,
                    //            unit_code = POPUPEntityObject.unit_code,
                    //            so_item_row_id = POPUPEntityObject.id,
                    //        });
                    //    }

                    //}
                    //}
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void ShowMachineStatusForSelectedItem(object InputValue)
        {
            try
            {
                if (((IEnumerable)InputValue).Cast<SEL_T001_P1>().Count() > 0)
                {
                    if (result1.Count() > 0)
                    {
                        if (CurrentMachineCollection.Count > 0 && CurrentMachineList.Count > 0)
                        {
                            CurrentMachineCollection.Clear();
                            CurrentMachineList.Clear();
                        }
                        foreach (EPR_T001_P1 item in MC.IldChartList)
                        {
                            if (SEL_T001_P1_OBJ != null)
                            {
                                if (item.location_Id == plant_main)
                                {
                                    if (item.Status == "Close" || item.Status == "003" || item.Status == "Stopped" || item.Status == "015")
                                    {
                                        item.StatusColor = true;
                                    }
                                    if (item.ItemCode == SEL_T001_P1_OBJ.ItemCode)
                                    {
                                        item.IsColour = true;
                                    }
                                    else
                                    {
                                        item.IsColour = false;
                                    }
                                    CurrentMachineCollection.Add(item);
                                }
                            }
                            else
                            {
                                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Record from Selected Order Item List", this.Title); sms.ShowMessage();
                            }
                        }
                        CurrentMachineList = CurrentMachineCollection.ToList();
                    }
                    else
                    {
                        CurrentMachineCollection = new ObservableCollection<EPR_T001_P1>();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format(ex.Message, this.Title);sms.ShowMessage();
            }
        }
        private void AddMachineAndPlant(object InputValue)
        {
            try
            {
                if (EPR_T001_P1_OBJ != null && !string.IsNullOrWhiteSpace(EPR_T001_P1_OBJ.machinecode))
                {
                    MasterEntity.machine_id = EPR_T001_P1_OBJ.machine_id;
                    MasterEntity.MachineCode = EPR_T001_P1_OBJ.machinecode;
                    MasterEntity.wc_code = EPR_T001_P1_OBJ.wc_code;
                    MasterEntity.location_Id = EPR_T001_P1_OBJ.location_Id;
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertPlanningData(object InputValue)
        {
            try
            {
                if (Validation1() == true)
                {
                    if (SEL_T001_P1_OBJ != null)  // && EPR_T001_P1_OBJ != null
                    {
                        MachineDetailEntity.Add(new PPC_T004_A
                        {
                            PartyId = SEL_T001_P1_OBJ.PartyId,
                            machine_id = MasterEntity.machine_id,
                            machine_no = MasterEntity.MachineCode,
                            wc_code = MasterEntity.wc_code,
                            production_plant = MasterEntity.location_Id,
                            planning_plant = MasterEntity.planning_plant,
                            location_Id = MasterEntity.location_Id,
                            ItemCode = SEL_T001_P1_OBJ.ItemCode,
                            ItemName = SEL_T001_P1_OBJ.ItemName,
                            sku = SEL_T001_P1_OBJ.sku,
                            plan_qty = SEL_T001_P1_OBJ.Balence_Qty,
                            order_qty = SEL_T001_P1_OBJ.Balence_Qty,
                            sales_order_no = SEL_T001_P1_OBJ.sono,//delete after sono become allow null in table
                            sono = SEL_T001_P1_OBJ.sono,
                            client = AppSessionState.client,
                            ink_SCLR = SEL_T001_P1_OBJ.Ink,
                            para1 = (from o in MC.InkList where o.ink == SEL_T001_P1_OBJ.Ink select o.ink_id).FirstOrDefault().ToString(),

                            ild_SCLR = SEL_T001_P1_OBJ.Ild,
                            para5 = (from o in MC.ILDList where o.ild == SEL_T001_P1_OBJ.Ild select o.ild_id).FirstOrDefault().ToString(),

                            para6 = SEL_T001_P1_OBJ.ball_dia.ToString(),

                            BallType_SCLR = SEL_T001_P1_OBJ.ball_type,
                            para7 = (from o in MC.BallTypeList where o.ball_type == SEL_T001_P1_OBJ.ball_type select o.ball_type_id).FirstOrDefault().ToString(),

                            WireSize_SCLR = SEL_T001_P1_OBJ.wire_size.ToString(),
                            para8 = (from o in MC.WireSizeList where o.wire_size == SEL_T001_P1_OBJ.wire_size select o.wire_size_id).FirstOrDefault().ToString(),
                            t_status = "001",
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            active = true,
                            line_id = 0,
                            unit_code = SEL_T001_P1_OBJ.unit_code,


                            pre_order_no = (EPR_T001_P1_OBJ!=null ? EPR_T001_P1_OBJ.order_no ?? "" : null),
                            WireMake_SCLR = (EPR_T001_P1_OBJ!=null ? EPR_T001_P1_OBJ.wire_make ?? "" : null),
                            para2 = (from o in MC.MakeList where o.Make == (EPR_T001_P1_OBJ != null ? EPR_T001_P1_OBJ.wire_make ?? "" : null) && o.make_type == "Wire" select o.MakeCode).FirstOrDefault().ToString(),
                            BallMake_SCLR = (EPR_T001_P1_OBJ!=null ? EPR_T001_P1_OBJ.ball_make ?? "" : null),
                            para3 = (from o in MC.MakeList where o.Make == (EPR_T001_P1_OBJ != null ? EPR_T001_P1_OBJ.ball_make ?? "" : null) && o.make_type == "Ball" select o.MakeCode).FirstOrDefault().ToString(),
                            para4 = SEL_T001_P1_OBJ.model_id.ToString(),
                            para9 = SEL_T001_P1_OBJ.model_code,
                            doc_cat = MasterEntity.doc_cat,
                            doc_type = MasterEntity.doc_type,
                            order_type = "OR",
                            pro_type = "E",
                            spl_pro_type = "E",
                            scrap_qty = 0,
                            req_qty = 0,
                            ind_conv = "0",
                            acc_cat = "",
                            po_code = null,
                            pg_code = null,
                            con_posting = null,
                            task_list_group = null,
                            group_counter = 1,
                            task_list_type = null,
                            ind_backflush = "1",
                            req_plan_no = MasterEntity.plan_no,
                            routing_no = null,
                            bom_exp_no = null

                        });
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Please Select Item for Planning");sms.ShowMessage();
                    }
                }
                var msg = new NotificationMessage("PPC_T004_VM");Messenger.Default.Send<NotificationMessage>(msg);
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
        private void CancleSelectedSO(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (MC.SalesOrderList.Count > i) //&& MC.SalesOrderList[dgSelectedIndexSoData].Select == true
                {
                    string reader = repositoryStr.Save<string>("!@" + MC.SalesOrderList[dgSelectedIndexSoData].sono + "!@" + MC.SalesOrderList[dgSelectedIndexSoData].ItemCode, "ProductionPlanninginsert", "Production");

                    if (reader != null && reader != "")
                    {
                        int intreader = Convert.ToInt32(reader);

                        if (intreader > 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Sales order sucessfully canceled", this.Title);
                            showMessageService.ShowMessage();
                            LoadInitialData();
                        }
                        else if (intreader == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Sales order Not canceled ", this.Title);
                            showMessageService.ShowMessage();
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
        private void ToolTipPlanning(object InputValue)
        {
            PPC_T004_A POPUPEntityObject = null;
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_T004_A>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T004_A>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    SalesOrderInfo.Clear();
                    foreach (PPC_T004_B item in SoDetailEntity)
                    {
                        if (item.ItemCode == POPUPEntityObject.ItemCode)
                        {
                            SalesOrderInfo.Add(new PPC_T004_B()
                            {
                                sono = item.sono,
                                sodate = item.sodate,
                                ItemCode = item.ItemCode,
                                PartyNm = item.PartyNm,
                                location_Id = item.location_Id,
                                qty = item.qty,
                                unit_code = item.unit_code
                            });
                        }
                    }
                }
                //SalesOrderInfo = SalesOrderInfo;
                //var msg = new NotificationMessage("PPC_T004_VM");
                //Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {
            }
        }
        private void ToolTipPlanningTemp(object InputValue)
        {
            SEL_T001_P1 POPUPEntityObject = null;
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T001_P1>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P1>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    SalesOrderInfo.Clear();
                    foreach (SEL_T001_P1 item in TempalesOrders)
                    {
                        if (item.ItemCode == POPUPEntityObject.ItemCode)
                        {
                            SalesOrderInfo.Add(new PPC_T004_B()
                            {
                                sono = item.sono,
                                sodate = item.sodate,
                                ItemCode = item.ItemCode,
                                PartyNm = item.party_name,
                                location_Id = item.location_Id,
                                qty = item.plan_qty_for_SO,
                                unit_code = item.unit_code
                            });
                        }
                    }
                }
                //SalesOrderInfo = SalesOrderInfo;
                //var msg = new NotificationMessage("PPC_T004_VM");
                //Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {
            }
        }
        private void ToolTipILDChart(object InputValue)
        {
            EPR_T001_P1 POPUPEntityObject = null;
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<EPR_T001_P1>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001_P1>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    SalesOrderInfo.Clear();
                    foreach (PPC_T004_B item in MC.SoDetailsILDChart)
                    {
                        if (item.order_no == POPUPEntityObject.order_no)
                        {
                            SalesOrderInfo.Add(new PPC_T004_B()
                            {
                                sono = item.sono,
                                sodate = item.sodate,
                                ItemCode = item.ItemCode,
                                PartyNm = item.PartyNm,
                                location_Id = item.location_Id,
                                qty = item.qty,
                                unit_code = item.unit_code
                            });
                        }
                    }
                }
                //var msg = new NotificationMessage("PPC_T004_VM");
                //Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {
            }
        }

        #region  Machine Detail Entity PopUp Methods 
        private void FilterCollectionsOnItemCodeSelection()
        {
            try
            {
                if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode != null && MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode != "")
                    {
                        // Filtering Collections Based On Item Code/Product Code selection

                        List<ENG_T001_P> FilteredBOM_List = (from o in MC.BomNoList
                                                             where o.ItemCode == MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode
                                                             select o).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).doc_no.ToString());
                        TheFilter = (o, prefix) => (((ENG_T001_P)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASDgBomNo = new AutoSuggestTextViewModel<dynamic>(FilteredBOM_List, TheFilter, SuggestedValue, "bom_no", "doc_no", true);
                        ASDgBomNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertPlantOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = plantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
                if (POPUPEntityObject != null)
                {
                    PPC_T004_A_OBJ.machine_no = null;
                    PPC_T004_A_OBJ.machine_id = null;
                    PPC_T004_A_OBJ.wc_code = null;

                    var InputValueIfExists = MachineDetailEntity.Where(x => x.production_plant == POPUPEntityObject.location_Id).FirstOrDefault();
                    var IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.production_plant == POPUPEntityObject.location_Id).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MachineDetailEntity.Count == dgSelectedIndexPlanMCDetail)
                    {
                        MachineDetailEntity.Add(new PPC_T004_A()
                        {
                            id = 0,
                            active = true,
                            production_plant = POPUPEntityObject.location_Id
                        });


                        List<PPC_M001_P> SelectedPlantMachines1 = (from o in MC.MachineList
                                                                   where o.location_Id == POPUPEntityObject.location_Id
                                                                   select o).ToList();


                        MachineCollection1 = CollectionViewSource.GetDefaultView(SelectedPlantMachines1.ToList());
                        MachineCollection1.Filter = new Predicate<object>(Filter_Machine1);
                        // machinecode

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode.ToString());
                        TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASDgMachineNo = new AutoSuggestTextViewModel<dynamic>(SelectedPlantMachines1, TheFilter, SuggestedValue, "machine_no", "machinecode", true);
                        ASDgMachineNo.AutoSuggestVM.IsEmptyValueAllowed = false;

                        StringListMachine1 = SelectedPlantMachines1.Select(x => x.machinecode).ToList();

                    }
                    else if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail)
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_plant = POPUPEntityObject.location_Id;


                            List<PPC_M001_P> SelectedPlantMachines1 = (from o in MC.MachineList
                                                                       where o.location_Id == POPUPEntityObject.location_Id
                                                                       select o).ToList();


                            MachineCollection1 = CollectionViewSource.GetDefaultView(SelectedPlantMachines1.ToList());
                            MachineCollection1.Filter = new Predicate<object>(Filter_Machine1);


                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode.ToString());
                            TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASDgMachineNo = new AutoSuggestTextViewModel<dynamic>(SelectedPlantMachines1, TheFilter, SuggestedValue, "machine_no", "machinecode", true);
                            ASDgMachineNo.AutoSuggestVM.IsEmptyValueAllowed = false;

                            StringListMachine1 = SelectedPlantMachines1.Select(x => x.machinecode).ToList();

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_plant != POPUPEntityObject.location_Id)
                        {

                            List<PPC_M001_P> SelectedPlantMachines1 = (from o in MC.MachineList
                                                                       where o.location_Id == POPUPEntityObject.location_Id
                                                                       select o).ToList();


                            MachineCollection1 = CollectionViewSource.GetDefaultView(SelectedPlantMachines1.ToList());
                            MachineCollection1.Filter = new Predicate<object>(Filter_Machine1);


                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode.ToString());
                            TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASDgMachineNo = new AutoSuggestTextViewModel<dynamic>(SelectedPlantMachines1, TheFilter, SuggestedValue, "machine_no", "machinecode", true);
                            ASDgMachineNo.AutoSuggestVM.IsEmptyValueAllowed = false;

                            StringListMachine1 = SelectedPlantMachines1.Select(x => x.machinecode).ToList();

                        }
                    }
                    //if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail)
                    //{
                    //    if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_plant != "" && MachineDetailEntity[dgSelectedIndexPlanMCDetail].production_plant != null)
                    //    {
                    //        var abc = (from data in MC.MachineList
                    //                   where data.location_Id == POPUPEntityObject.location_Id
                    //                   select data).ToList();

                    //        MachineCollection1 = CollectionViewSource.GetDefaultView(abc.ToList());
                    //        MachineCollection1.Filter = new Predicate<object>(Filter_Machine);
                    //        StringListMachine1 = abc.Select(x => x.machinecode).ToList();
                    //    }
                    //    else
                    //    {
                    //        MachineCollection1 = CollectionViewSource.GetDefaultView(MC.MachineList);
                    //        MachineCollection1.Filter = new Predicate<object>(Filter_Machine);
                    //        StringListMachine1 = MC.MachineList.Select(x => x.machinecode).ToList();
                    //    }
                    //}     
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertMachineOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PPC_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_M001_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.machine_id == POPUPEntityObject.machine_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.machine_id == POPUPEntityObject.machine_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].machine_id = POPUPEntityObject.machine_id;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].machine_no = POPUPEntityObject.machinecode;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].wc_code = POPUPEntityObject.wc_code;

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].machine_id != POPUPEntityObject.machine_id)
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].machine_id = POPUPEntityObject.machine_id;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].machine_no = POPUPEntityObject.machinecode;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].wc_code = POPUPEntityObject.wc_code;
                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void UnitOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        {
                            POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code = POPUPEntityObject.unit_code;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].uom_name = POPUPEntityObject.unit_name;

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code != POPUPEntityObject.unit_code)
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code = POPUPEntityObject.unit_code;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].uom_name = POPUPEntityObject.unit_name;

                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertItemOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode = POPUPEntityObject.ItemCode;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemName = POPUPEntityObject.ItemName;

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode = POPUPEntityObject.ItemCode;
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemName = POPUPEntityObject.ItemName;

                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion

                    FilterCollectionsOnItemCodeSelection();
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
        private void InsertInkOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.InkList.Where(x => x.ink_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para1 == POPUPEntityObject.ink_id.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para1 == POPUPEntityObject.ink_id.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para1 = POPUPEntityObject.ink_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ink_SCLR = POPUPEntityObject.ink;
                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para1 != POPUPEntityObject.ink_id.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para1 = POPUPEntityObject.ink_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ink_SCLR = POPUPEntityObject.ink;

                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertIldOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ILDList.Where(x => x.ild_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para5 == POPUPEntityObject.ild_id.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para5 == POPUPEntityObject.ild_id.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para5 = POPUPEntityObject.ild_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ild_SCLR = POPUPEntityObject.ild;
                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para5 != POPUPEntityObject.ild_id.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para5 = POPUPEntityObject.ild_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].ild_SCLR = POPUPEntityObject.ild;
                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertBallMakeOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M032_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.MakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para3 == POPUPEntityObject.MakeCode.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para3 == POPUPEntityObject.MakeCode.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para3 = POPUPEntityObject.MakeCode.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].BallMake_SCLR = POPUPEntityObject.Make;

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para3 != POPUPEntityObject.MakeCode.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para3 = POPUPEntityObject.MakeCode.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].BallMake_SCLR = POPUPEntityObject.Make;

                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertWireMakeOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M032_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.MakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para2 == POPUPEntityObject.MakeCode.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para2 == POPUPEntityObject.MakeCode.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para2 = POPUPEntityObject.MakeCode.ToString();

                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].WireMake_SCLR = POPUPEntityObject.Make.ToString();
                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para2 != POPUPEntityObject.MakeCode.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para2 = POPUPEntityObject.MakeCode.ToString();

                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].WireMake_SCLR = POPUPEntityObject.Make.ToString();
                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertBallSizeOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.BallSizeList.Where(x => x.Ball_dia.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M001_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para6 == POPUPEntityObject.Ball_dia.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para6 == POPUPEntityObject.Ball_dia.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para6 = POPUPEntityObject.Ball_dia.ToString();

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para6 != POPUPEntityObject.Ball_dia.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para6 = POPUPEntityObject.Ball_dia.ToString();

                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertWireSizeOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.WireSizeList.Where(x => x.wire_size_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M003_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para8 == POPUPEntityObject.wire_size_id.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para8 == POPUPEntityObject.wire_size_id.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para8 = POPUPEntityObject.wire_size_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].WireSize_SCLR = POPUPEntityObject.wire_size.ToString();
                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para8 != POPUPEntityObject.wire_size_id.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para8 = POPUPEntityObject.wire_size_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].WireSize_SCLR = POPUPEntityObject.wire_size.ToString();
                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertSelectionChangeFinalPlant(object InputValue)
        {
            try
            {
                PPC_T004_A_OBJ = (PPC_T004_A)InputValue;
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
        private void InsertBallTypeOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.BallTypeList.Where(x => x.ball_type_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M002_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.para7 == POPUPEntityObject.ball_type_id.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.para7 == POPUPEntityObject.ball_type_id.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para7 = POPUPEntityObject.ball_type_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].BallType_SCLR = POPUPEntityObject.ball_type;
                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].para7 != POPUPEntityObject.ball_type_id.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].para7 = POPUPEntityObject.ball_type_id.ToString();
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].BallType_SCLR = POPUPEntityObject.ball_type;
                        }
                    }
                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void InsertBOMNoOnMachineDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ENG_T001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.BomNoList.Where(x => x.doc_no.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T001_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MachineDetailEntity.Where(X => X.bom_no == POPUPEntityObject.doc_no.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MachineDetailEntity.IndexOf(MachineDetailEntity.Where(X => X.bom_no == POPUPEntityObject.doc_no.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no = POPUPEntityObject.doc_no.ToString();

                        }
                        else if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no != POPUPEntityObject.doc_no.ToString())
                        {
                            MachineDetailEntity[dgSelectedIndexPlanMCDetail].bom_no = POPUPEntityObject.doc_no.ToString();

                        }
                    }

                    #region Clear Empty Row
                    PPC_T004_A newObj = new PPC_T004_A();
                    for (int i = MachineDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MachineDetailEntity[i].ComparePropertiesTo(newObj);
                        if (MachineDetailEntity[i].ComparePropertiesTo(newObj) == true && MachineDetailEntity.Count > 1)
                        {
                            MachineDetailEntity.RemoveAt(i);
                            if (MachineDetailEntity.Count == 0)
                            {
                                MachineDetailEntity.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void CheckPlanQtyDetailEntity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                if (InputValue != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexPlanMCDetail >= 0 && MachineDetailEntity.Count > dgSelectedIndexPlanMCDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0 && MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty != null && MachineDetailEntity[dgSelectedIndexPlanMCDetail].order_qty != null) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            //decimal? PlanQty = MachineDetailEntity.Sum(x => x.plan_qty);
                            decimal? PlanQty = MachineDetailEntity.Where(x => x.ItemCode == MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode).Sum(y => y.plan_qty);
                            decimal? OrderQty = result1.Where(x => x.ItemCode == MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode).Sum(y => y.Balence_Qty);
                            //if ( MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty > MachineDetailEntity[dgSelectedIndexPlanMCDetail].order_qty)
                            if (PlanQty > OrderQty)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Plan Quantity is greater than Total Order Quantity ");
                                showMessageService.ShowMessage();
                            }
                        }
                    }
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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

        private void InsertFltrStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.t_statusList.Where(x => x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0013>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.fltr_t_status = POPUPEntityObject.t_status;
                    MasterEntity.fltr_t_display = POPUPEntityObject.t_display;
                }
            }
            catch (Exception Ex) { }
        }

        #endregion

        #region current machine popup for filter

        private void InsertBallSize(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallSizeList.Where(x => x.ball_dia.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ZADM_M001_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ball_dia_id = POPUPEntityObject.ball_dia_id;
                    MasterEntity.Ball_dia = POPUPEntityObject.ball_dia;

                    FilterForFields();
                }
                else
                {
                    MasterEntity.ball_dia_id = null;
                    MasterEntity.Ball_dia = null;
                    FilterForFields();
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertBallType(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallTypeList.Where(x => x.ball_type.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ZADM_M002_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ball_type_id = POPUPEntityObject.ball_type_id;
                    MasterEntity.ball_type = POPUPEntityObject.ball_type;

                    FilterForFields();
                }
                else
                {
                    MasterEntity.ball_type_id = null;
                    MasterEntity.ball_type = null;
                    FilterForFields();
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertWireSize(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.WireSizeList.Where(x => x.wire_size.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ZADM_M003_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.wire_size_id = POPUPEntityObject.wire_size_id;
                    MasterEntity.wire_size = POPUPEntityObject.wire_size;

                    FilterForFields();
                }
                else
                {
                    MasterEntity.wire_size_id = null;
                    MasterEntity.wire_size = null;
                    FilterForFields();
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = plantList.Where(x => x.location_Id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id3 = POPUPEntityObject.location_Id;
                    MasterEntity.LocationNm3 = POPUPEntityObject.LoctnNm;

                    if (POPUPEntityObject.location_Id != "" || POPUPEntityObject.location_Id != null)
                    {
                        FilterForFields();
                    }
                }
                else
                {
                    MasterEntity.location_Id3 = null;
                    FilterForFields();
                }
                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertPlantMain(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = plantList.Where(x => x.location_Id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    plant_main = POPUPEntityObject.location_Id;
                    MasterEntity.location_Id3 = POPUPEntityObject.location_Id;
                    MasterEntity.LocationNm3 = POPUPEntityObject.LoctnNm;
                    MasterEntity.production_plant = POPUPEntityObject.location_Id;
                    if (POPUPEntityObject.location_Id != "" || POPUPEntityObject.location_Id != null)
                    {
                        List<SEL_T001_P1> TempSalesOrderList = (from o in MC.SalesOrderList where (o.t_status_PPC_B != "Cancelled" || o.t_status_PPC_B != "013") && (string.IsNullOrWhiteSpace(plant_main) ? "" : plant_main) == (string.IsNullOrWhiteSpace(plant_main) ? "" : o.location_Id) select o).ToList();
                        SalesOrderCollection = CollectionViewSource.GetDefaultView(TempSalesOrderList);
                        SalesOrderCollection.Filter = new Predicate<object>(Filter_SoData);
                        SalesOrderCollection.Refresh();
                    }
                    if (POPUPEntityObject.location_Id != "" && POPUPEntityObject.location_Id != null)
                    {

                        List<PPC_M001_P> SelectedPlantMachines = (from o in MC.MachineList
                                                                  where o.location_Id == plant_main
                                                                  select o).ToList();

                        MachineCollection = CollectionViewSource.GetDefaultView(SelectedPlantMachines.ToList());
                        MachineCollection.Filter = new Predicate<object>(Filter_Machine);


                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode.ToString());
                        TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASMachineNo = new AutoSuggestTextViewModel<dynamic>(SelectedPlantMachines, TheFilter, SuggestedValue, "machine_no", "machinecode", true);
                        ASMachineNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                        StringListMachine = SelectedPlantMachines.Select(x => x.machinecode).ToList();

                    }
                    else
                    {
                        MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
                        MachineCollection.Filter = new Predicate<object>(Filter_Machine);

                        List<PPC_M001_P> SelectedPlantMachines = (from o in MC.MachineList
                                                                  where o.location_Id == plant_main
                                                                  select o).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode.ToString());
                        TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASMachineNo = new AutoSuggestTextViewModel<dynamic>(SelectedPlantMachines, TheFilter, SuggestedValue, "machine_no", "machinecode", true);
                        ASMachineNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                        StringListMachine = MC.MachineList.Select(x => x.machinecode).ToList();
                    }
                    FilterForFields();
                }
                else
                {
                    plant_main = null;
                    List<SEL_T001_P1> TempSalesOrderList = (from o in MC.SalesOrderList where (o.t_status_PPC_B != "Cancelled" || o.t_status_PPC_B != "013") && (string.IsNullOrWhiteSpace(plant_main) ? "" : plant_main) == (string.IsNullOrWhiteSpace(plant_main) ? "" : o.location_Id) select o).ToList();
                    //  List<SEL_T001_P1> TempSalesOrderList = MC.SalesOrderList.Where(s => s.t_status_PPC_B != "Cancelled");
                    SalesOrderCollection = CollectionViewSource.GetDefaultView(TempSalesOrderList);
                    SalesOrderCollection.Filter = new Predicate<object>(Filter_SoData);
                    SalesOrderCollection.Refresh();
                }

                var msg = new NotificationMessage("PPC_T004_VM");
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
        private void InsertWireType(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M004_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.WireTypeList.Where(x => x.wire_type.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ZADM_M004_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList()[0];
                        }
                    }
                    var msg = new NotificationMessage("PPC_T004_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.wire_type_id = POPUPEntityObject.wire_type_id;
                    MasterEntity.wire_type = POPUPEntityObject.wire_type;
                    CurrentList = CurrentMachineCollection.ToList();
                    FilterForFields();
                    //if (POPUPEntityObject.wire_type.ToString() != "" || POPUPEntityObject.wire_type.ToString() != null)
                    //{
                    //    CurrentMachineCollection.Clear();
                    //    if (POPUPEntityObject.wire_type.ToString() == "All" || POPUPEntityObject.wire_type_id.ToString() == "0")
                    //    {
                    //        foreach (EPR_T001_P1 item in CurrentMachineList)
                    //        {
                    //            CurrentMachineCollection.Add(item);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        foreach (EPR_T001_P1 item in CurrentList)
                    //        {
                    //            if (item.ball_type == POPUPEntityObject.wire_type.ToString())
                    //            {
                    //                CurrentMachineCollection.Add(item);
                    //            }
                    //            else if (POPUPEntityObject.wire_type_id == 0)
                    //            {
                    //                CurrentMachineCollection.Add(item);
                    //            }
                    //        }
                    //    }
                    //}
                }
                else
                {
                    MasterEntity.wire_type_id = null;
                    MasterEntity.wire_type = null;
                    FilterForFields();
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
        private void FilterForFields()
        {
            List<SEL_T001_P1> obj_list = new List<SEL_T001_P1>();
            obj_list.Add(SEL_T001_P1_OBJ);
            ShowMachineStatusForSelectedItem(obj_list);
            CurrentList = CurrentMachineList;
            //CurrentList = CurrentMachineCollection.ToList(); location_Id3
            CurrentMachineCollection.Clear();

            foreach (EPR_T001_P1 item in CurrentList)
            {
                if (
                       (string.IsNullOrWhiteSpace(plant_main) ? "" : plant_main) == (string.IsNullOrWhiteSpace(plant_main) ? "" : item.location_Id)
                    && (string.IsNullOrWhiteSpace(MasterEntity.location_Id3) ? "" : MasterEntity.location_Id3) == (string.IsNullOrWhiteSpace(MasterEntity.location_Id3) ? "" : item.location_Id)
                    && (string.IsNullOrWhiteSpace(MasterEntity.ball_type) ? "" : MasterEntity.ball_type) == (string.IsNullOrWhiteSpace(MasterEntity.ball_type) ? "" : item.ball_type)
                    && (string.IsNullOrWhiteSpace(MasterEntity.wc_code) ? "" : MasterEntity.wc_code) == (string.IsNullOrWhiteSpace(MasterEntity.wc_code) ? "" : item.wc_code)
                    && (MasterEntity.Ball_dia.HasValue ? "" : "") == (MasterEntity.Ball_dia.HasValue ? item.ball_dia.ToString() : "")
                    && (MasterEntity.wire_size.HasValue ? MasterEntity.wire_size.ToString() : "") == (MasterEntity.wire_size.HasValue ? item.wire_size.ToString() : ""))
                {
                    CurrentMachineCollection.Add(item);
                }
            }
        }
        //&& (string.IsNullOrWhiteSpace(MasterEntity.wire_type) ? "" : MasterEntity.wire_type) == (string.IsNullOrWhiteSpace(MasterEntity.wire_type) ? "" : item.wire_make)
        //&& (string.IsNullOrWhiteSpace(MasterEntity.wc_code) ? "" : MasterEntity.wc_code) == (string.IsNullOrWhiteSpace(MasterEntity.wc_code) ? "" : item.wc_code)

        #endregion

        #region Planning PopUp For Machine And Plant
        private void InsertMachine(object InputValue)
        {
            try
            {
                string Request = "";
                PPC_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.location_Id == MasterEntity.location_Id).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<PPC_M001_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_P>().ToList()[0];
                        }
                    }
                    var msg = new NotificationMessage("PPC_T004_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.machine_id = POPUPEntityObject.machine_id;
                    MasterEntity.MachineCode = POPUPEntityObject.machinecode;
                    MasterEntity.wc_code = POPUPEntityObject.wc_code;

                    FilterForFields();
                }
                else
                {
                    MasterEntity.machine_id = null;
                    MasterEntity.MachineCode = null;
                    MasterEntity.wc_code = null;

                    FilterForFields();
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
        private void InsertPlantforPlanning(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                MasterEntity.wc_code = null;
                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = plantList.Where(x => x.location_Id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.LocationNm = POPUPEntityObject.LoctnNm;

                    if (POPUPEntityObject.location_Id != "" && POPUPEntityObject.location_Id != null)
                    {

                        List<PPC_M001_P> SelectedPlantMachines = (from o in MC.MachineList
                                                                  where o.location_Id == POPUPEntityObject.location_Id
                                                                  select o).ToList();

                        MachineCollection = CollectionViewSource.GetDefaultView(SelectedPlantMachines.ToList());
                        MachineCollection.Filter = new Predicate<object>(Filter_Machine);


                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode.ToString());
                        TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASMachineNo = new AutoSuggestTextViewModel<dynamic>(SelectedPlantMachines, TheFilter, SuggestedValue, "machine_no", "machinecode", true);
                        ASMachineNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                        StringListMachine = SelectedPlantMachines.Select(x => x.machinecode).ToList();

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
        private void PlanWithoutSO()
        {
            try
            {
                foreach (var o in SoDetailEntity)
                {
                    if (SoDetailEntity.Count < 0)
                    {
                        o.sono = "without Order";
                        o.location_Id = AppSessionState.location_Id;
                        o.comp_code = AppSessionState.comp_code;
                        o.add_by = AppSessionState.UserID;
                        o.qty = MachineDetailEntity[dgSelectedIndexPlanMCDetail].plan_qty;
                        o.ItemCode = MachineDetailEntity[dgSelectedIndexPlanMCDetail].ItemCode;
                        o.unit_code = MachineDetailEntity[dgSelectedIndexPlanMCDetail].unit_code;
                    }
                }

            }
            catch (Exception ex)
            {
            }

        }
        private void DeleteDataGridRowPlanMachine(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                int line_row_id = MachineDetailEntity[i].line_id;

                if (MachineDetailEntity.Count > i && MachineDetailEntity[dgSelectedIndexPlanMCDetail].id == 0)
                {
                    MachineDetailEntity.RemoveAt(i);
                }
                if (SoDetailEntity.Count > 0)
                {
                    List<PPC_T004_B> listTemp = SoDetailEntity.ToList();
                    foreach (PPC_T004_B item in listTemp)
                    {
                        if (item.line_id == line_row_id)
                        {
                            SoDetailEntity.Remove(item);
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
        private void LoadInitialData()
        {
            try
            {
                #region .Relay Command Initialisation .
                cmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdClearFilterData = new RelayCommand<object>(items => { if (items == null) { return; } ClearFilterData(items); });
                cmdProductionOrder = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertProductionOrder(cmdPara); });
                cmdProductionOrderPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertProductionOrderPrint(cmdPara); });
                cmdInsertReservation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReservation(cmdPara); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdShowMachineStatusForSelectedItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ShowMachineStatusForSelectedItem(cmdPara); });
                cmdAddSelectedData = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } AddSelectedSoDataOnGrid(cmdPara); });
                cmdAddMachineAndPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } AddMachineAndPlant(cmdPara); });
                CmdCancleSelectedSO = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CancleSelectedSO(cmdPara); });
                cmdToolTipPlanning = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ToolTipPlanning(cmdPara); });
                cmdToolTipPlanningTemp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ToolTipPlanningTemp(cmdPara); });
                cmdToolTipILDChart = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ToolTipILDChart(cmdPara); });

                //Machine Detail Entity PopUp Methods

                cmdInsertPlanningData = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlanningData(cmdPara); });
                cmdInsertPlantOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlantOnMachineDetailEntity(cmdPara, true, true, true); });
                cmdInsertMachineOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachineOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertUnitOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } UnitOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertItemOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertInkOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInkOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertIldOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIldOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertBallMakeOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallMakeOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertWireMakeOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireMakeOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertBallSizeOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallSizeOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertWireSizeOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireSizeOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertBallTypeOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallTypeOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertBOMNoOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBOMNoOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdCheckPlanQty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CheckPlanQtyDetailEntity(cmdPara, false, true, true); });
                cmdSelectionChangeFinalPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectionChangeFinalPlant(cmdPara); });
                //cmdSelectionChangeFinalPlant
                //for current machine filter

                cmdInsertBallSize = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallSize(cmdPara); });
                cmdInsertBallType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallType(cmdPara); });
                cmdInsertWireSize = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireSize(cmdPara); });
                cmdInsertPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlant(cmdPara); });
                cmdInsertPlantMain = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlantMain(cmdPara); });
                cmdInsertWireType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireType(cmdPara); });

                //Planning PopUp For Machine And Plant

                cmdInsertMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
                cmdInsertPlantforPlanning = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlantforPlanning(cmdPara); });

                cmdDeleteDataGridRowPlanMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowPlanMachine(cmdPara); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });

                //Added By Mayuri
                LoadMRPReports = new GalaSoft.MvvmLight.Command.RelayCommand(() => { MRPReport(); });
                CommandForAddAttachment = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadAttachment(cmdPara); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                cmdInsertPkUnitOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PkUnitOnMachineDetailEntity(cmdPara, false, true, true); });
                cmdInsertStore_codeOnMachineDetailEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } store_codeOnMachineDetailEntity(cmdPara, false, true, true); });
                #endregion

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T004>(MC, Request, "ProductionPlanning", "Production", "LoadInitialData", 0, "");

                FlipGridData = MC.BackflipList.ToList();
                BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackFlipCollection.Filter = new Predicate<object>(Filter_BackFlip);

                #region AutoSuggest Initialisation

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M003_P)x).wire_size.ToString());
                TheFilter = (o, prefix) => (((ZADM_M003_P)o).wire_size_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M003_P)o).wire_size.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASWireSize = new AutoSuggestTextViewModel<dynamic>(MC.WireSizeList, TheFilter, SuggestedValue, "wire_size", true);
                ASWireSize.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M004_P)x).wire_type.ToString());
                TheFilter = (o, prefix) => (((ZADM_M004_P)o).wire_type_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M004_P)o).wire_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWireType = new AutoSuggestTextViewModel<dynamic>(MC.WireTypeList, TheFilter, SuggestedValue, "wire_type", true);
                ASWireType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M001_P)x).ball_dia.ToString());
                TheFilter = (o, prefix) => (((ZADM_M001_P)o).ball_dia_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M001_P)o).ball_dia.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASBallSize = new AutoSuggestTextViewModel<dynamic>(MC.BallSizeList, TheFilter, SuggestedValue, "ball_dia", true);
                ASBallSize.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M002_P)x).ball_type.ToString());
                TheFilter = (o, prefix) => (((ZADM_M002_P)o).ball_type_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M002_P)o).ball_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBallType = new AutoSuggestTextViewModel<dynamic>(MC.BallTypeList, TheFilter, SuggestedValue, "ball_type", true);
                ASBallType.AutoSuggestVM.IsEmptyValueAllowed = true;

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "location_Id", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "production_plant", "location_Id", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDatagridPlant = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "production_plant", "location_Id", true);
                ASDatagridPlant.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code.ToString());
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDgUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDgUnit.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode.ToString());
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDgProductCode = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDgProductCode.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M006_P)x).ink_id.ToString());
                TheFilter = (o, prefix) => (((ZADM_M006_P)o).ink_id.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ZADM_M006_P)o).ink ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASInk = new AutoSuggestTextViewModel<dynamic>(MC.InkList, TheFilter, SuggestedValue, "ink_SCLR", "ink", true);
                ASInk.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).ild_id.ToString());
                TheFilter = (o, prefix) => (((ZADM_M007_P)o).ild_id.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ZADM_M007_P)o).ild ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASIld = new AutoSuggestTextViewModel<dynamic>(MC.ILDList, TheFilter, SuggestedValue, "ild_SCLR", "ild", true);
                ASIld.AutoSuggestVM.IsEmptyValueAllowed = true;

                var SuggestedValueWireMake = (from o in MC.MakeList where o.make_type == "Wire" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P)x).MakeCode.ToString());
                TheFilter = (o, prefix) => (((ADM_M032_P)o).MakeCode.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M032_P)o).Make.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDgWireMake = new AutoSuggestTextViewModel<dynamic>(SuggestedValueWireMake, TheFilter, SuggestedValue, "WireMake_SCLR", "Make", true);
                ASDgWireMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                var SuggestedValueBallMake = (from o in MC.MakeList where o.make_type == "Ball" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P)x).MakeCode.ToString());
                TheFilter = (o, prefix) => (((ADM_M032_P)o).MakeCode.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M032_P)o).Make ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDgBallMake = new AutoSuggestTextViewModel<dynamic>(SuggestedValueBallMake, TheFilter, SuggestedValue, "BallMake_SCLR", "Make", true);
                ASDgBallMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M001_P)x).ball_dia.ToString());
                TheFilter = (o, prefix) => (((ZADM_M001_P)o).ball_dia.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M001_P)o).Ball_dia.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDgBallSize = new AutoSuggestTextViewModel<dynamic>(MC.BallSizeList, TheFilter, SuggestedValue, "para6", "ball_dia", true);
                ASDgBallSize.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M002_P)x).ball_type_id.ToString());
                TheFilter = (o, prefix) => (((ZADM_M002_P)o).ball_type_id.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ZADM_M002_P)o).ball_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDgBallType = new AutoSuggestTextViewModel<dynamic>(MC.BallTypeList, TheFilter, SuggestedValue, "BallType_SCLR", "ball_type", true);
                ASDgBallType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M003_P)x).wire_size_id.ToString());
                TheFilter = (o, prefix) => (((ZADM_M003_P)o).wire_size_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M003_P)o).wire_size.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDgWireSize = new AutoSuggestTextViewModel<dynamic>(MC.WireSizeList, TheFilter, SuggestedValue, "WireSize_SCLR", "wire_size", true);
                ASDgWireSize.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                AS_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Filters AutoSuggest 
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "fltr_t_display", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M017_P)x).id.ToString());
                TheFilter = (o, prefix) => (((ZADM_M017_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ZADM_M017_P)o).pkgunit ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPkUnit = new AutoSuggestTextViewModel<dynamic>(MC.PkgUnitList, TheFilter, SuggestedValue, "pack_style", "id", true);
                ASPkUnit.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001_P)x).store_code.ToString());
                TheFilter = (o, prefix) => (((MM_M001_P)o).store_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M001_P)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStore_code = new AutoSuggestTextViewModel<dynamic>(MC.store, TheFilter, SuggestedValue, "store_code", "store_code", true);
                ASStore_code.AutoSuggestVM.IsEmptyValueAllowed = false;
                #endregion

                IldChartCollection = CollectionViewSource.GetDefaultView(MC.IldChartList);

                List<SEL_T001_P1> TempSalesOrderList = (from o in MC.SalesOrderList where (o.t_status_PPC_B != "Cancelled" || o.t_status_PPC_B != "013") && (string.IsNullOrWhiteSpace(plant_main) ? "" : plant_main) == (string.IsNullOrWhiteSpace(plant_main) ? "" : o.location_Id) select o).ToList();
                //  List<SEL_T001_P1> TempSalesOrderList = MC.SalesOrderList.Where(s => s.t_status_PPC_B != "Cancelled");
                SalesOrderCollection = CollectionViewSource.GetDefaultView(TempSalesOrderList);
                SalesOrderCollection.Filter = new Predicate<object>(Filter_SoData);

                BallSizeCollection = CollectionViewSource.GetDefaultView(MC.BallSizeList);
                BallSizeCollection.Filter = new Predicate<object>(Filter_BallSize);
                StringListBallSize = MC.BallSizeList.Select(x => x.Ball_dia.ToString()).ToList();

                BallTypeCollection = CollectionViewSource.GetDefaultView(MC.BallTypeList);
                BallTypeCollection.Filter = new Predicate<object>(Filter_BallType);
                StringListBallType = MC.BallTypeList.Select(x => x.ball_type.ToString()).ToList();

                WireSizeCollection = CollectionViewSource.GetDefaultView(MC.WireSizeList);
                WireSizeCollection.Filter = new Predicate<object>(Filter_WireSize);
                StringListWireSize = MC.WireSizeList.Select(x => x.wire_size.ToString()).ToList();

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
                UnitCollection.Filter = new Predicate<object>(Filter_Unit);
                StringListUnit = MC.UnitList.Select(x => x.unit_code.ToString()).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListItem = MC.ItemList.Select(x => x.ItemCode.ToString()).ToList();

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);
                StringListInk = MC.InkList.Select(x => x.ink.ToString()).ToList();

                ILDCollection = CollectionViewSource.GetDefaultView(MC.ILDList);
                ILDCollection.Filter = new Predicate<object>(Filter_ILD);
                StringListILD = MC.ILDList.Select(x => x.ild.ToString()).ToList();

                var BallMake = (from o in MC.MakeList where o.make_type == "Ball" select o).ToList();
                BallMakeCollection = CollectionViewSource.GetDefaultView(BallMake);
                BallMakeCollection.Filter = new Predicate<object>(Filter_BallMake);
                StringListBallMake = BallMake.Select(x => x.Make.ToString()).ToList();

                var WireMake = (from o in MC.MakeList where o.make_type == "Wire" select o).ToList();
                WireMakeCollection = CollectionViewSource.GetDefaultView(WireMake);
                WireMakeCollection.Filter = new Predicate<object>(Filter_WireMake);
                StringListWireMake = WireMake.Select(x => x.Make.ToString()).ToList();

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                plantCollection = CollectionViewSource.GetDefaultView(plantList);
                plantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListPlant = plantList.Select(x => x.location_Id).ToList();

                WireTypeCollection = CollectionViewSource.GetDefaultView(MC.WireTypeList);
                WireTypeCollection.Filter = new Predicate<object>(Filter_WireType);
                StringListWireType = MC.WireTypeList.Select(x => x.wire_type).ToList();

                BOM_NoCollection = CollectionViewSource.GetDefaultView(MC.BomNoList);
                //  StringListBOM_No.Filter = new Predicate<object>(Filter_WireType);
                StringListBOM_No = MC.BomNoList.Select(x => x.doc_no).ToList();

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
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "PP";
            MasterEntity.doc_type = "PP";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = DateTime.Now;
            MasterEntity.edit_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.source_type = "";
            MasterEntity.source_no = "";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.planning_plant = AppSessionState.location_Id;
            MasterEntity.production_plant = AppSessionState.location_Id;
            plant_main = AppSessionState.location_Id;
            MasterEntity.t_status = "001";     //Draft
            MasterEntity.plan_date = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.ts_code = ts_code_vm;

            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            MasterEntity.Fltr_FrmDate = d;
            MasterEntity.Fltr_ToDate = DateTime.UtcNow;
            MasterEntity.Fltr_active = true;
            MasterEntity.Fltr_active = true;
        }
        private bool Validation1()
        {
            if (MasterEntity.MachineCode == null || MasterEntity.MachineCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Machine Before Planning");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.location_Id == null || MasterEntity.location_Id.ToString() == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Location Before Planning");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private bool Validation()
        {
            if (MachineDetailEntity.Count > 0)
            {
                foreach (var o in MachineDetailEntity)
                {
                    if (o.unit_code == null || o.unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Unit");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if (o.plan_qty == null || o.plan_qty.ToString() == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Total Quantity");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if (string.IsNullOrWhiteSpace(o.machine_no) && string.IsNullOrWhiteSpace(o.wc_code))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Machine");
                        showMessageService.ShowMessage();
                        return false;
                    }

                }
                //}

            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("No Records Present For Planning");
                showMessageService.ShowMessage();
                return false;
            }
            return true;


        }

        #endregion

        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<PPC_T004> result)
        {
            isNewRecord = true;
            MasterEntity = new PPC_T004();
            MachineDetailEntity = new ObservableCollection<PPC_T004_A>();
            SoDetailEntity = new ObservableCollection<PPC_T004_B>();
            MachineDetailEntity.Clear();
            result1 = new List<SEL_T001_P1>();
            MCTemp.SalesOrderList = new List<SEL_T001_P1>();
            SEL_T001_P1_OBJ = null;
            EPR_T001_P1_OBJ = null;

            SelectedSoDetailCollection = CollectionViewSource.GetDefaultView(result1);
            CurrentMachineCollection.Clear();
            foreach (var item in MC.SalesOrderList)
            {
                if (item.Select == true)
                {
                    item.Select = false;
                }
            }
            TempalesOrders.Clear();
            DefaultValues();

        }
        protected override void OnDiscardAction(InquiryActionResult<PPC_T004> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PPC_T004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PPC_T004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PPC_T004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PPC_T004> result)
        {
            try
            {
                //string Request = "LoadDocumentByDocumentNumber" +"!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.plan_no;

                //MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T004>(MCTemp, Request, "ProductionPlanning", "Production", "LoadAll", 0, Request);
                List<PPC_T004> PPMaster = new List<PPC_T004>();
                PPMaster.Add(MasterEntity);
                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = PPMaster;
                objDataSource[3] = MachineDetailEntity;
                objDataSource[4] = SoDetailEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMasterPP";
                objDataSourceName[3] = "dsDetailsPP";
                objDataSourceName[4] = "dsSoDetail";



                ReportManager ReportManager = new ReportManager();
                string ReportName = "";

                string ReportDisplayName = MasterEntity.plan_no + "_" + MasterEntity.plan_date.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\" + MC.DocCategoryList[0].report_name, ReportDisplayName);
            }
            catch (Exception ex)
            {
            }
        }
        protected override void OnRemoveAction(InquiryActionResult<PPC_T004> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<PPC_T004> result)
        {
            try
            {
                if (Validation() == true)
                {
                    foreach (var o in MachineDetailEntity)
                    {
                        if (o.active == false)
                        {
                            foreach (var T in SoDetailEntity)
                            {
                                if (T.line_id == o.line_id)
                                {
                                    T.active = false;
                                }
                            }
                            //SoDetailEntity.Where(x => x.line_id == o.line_id).ForEach(u => u.active = false);
                        }
                        //else if ((o.location_Id != "" || o.location_Id != null) || (o.wc_code != "" || o.wc_code != null) )
                        //{
                        //    foreach (var T in TempalesOrders)
                        //    {
                        //        if (o.ItemCode==T.ItemCode && o.location_Id==T.location_Id && o.comp_code==T.comp_code && o.client == AppSessionState.client)
                        //        {
                        //            var InputValueIfExists = SoDetailEntity.Where(X => X.line_id==o.line_id && X.sono == T.sono && X.ItemCode==T.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        //            if (InputValueIfExists == null)
                        //            {
                        //                SoDetailEntity.Add(new PPC_T004_B()
                        //                {
                        //                    id = 0,
                        //                    line_id = o.line_id,
                        //                    active = o.active,
                        //                    location_Id = AppSessionState.location_Id,
                        //                    sono = T.sono,
                        //                    comp_code = AppSessionState.comp_code,
                        //                    add_by = AppSessionState.UserID,
                        //                    ItemCode = o.ItemCode,
                        //                    machine_no = o.machine_no,
                        //                    unit_code = o.unit_code,
                        //                    so_item_row_id = T.id,
                        //                    qty = T.plan_qty_for_SO,
                        //                    plan_item_row_id=o.id
                        //                });
                        //            }
                        //        }
                        //    }
                        //}

                    }

                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.xdoc_PPC_T004_A = obj.ObjectToXML(MachineDetailEntity);
                    MasterEntity.xdoc_PPC_T004_B = obj.ObjectToXML(SoDetailEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PPC_T004>(MasterEntity, "ProductionPlanning", "Production");
                    }
                    else if (isNewRecord == false) //&& ( MasterEntity.t_status != "003" || MasterEntity.t_status != "Closed")
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PPC_T004>(MasterEntity, "ProductionPlanning", "Production");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
                    MessageBox.Show("Record Saved Successfully");
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.xdoc_SEL_T001_P1 != null)
                {
                    MC.SalesOrderList.Clear();
                    MC.SalesOrderList = (List<SEL_T001_P1>)new ObjectSerializationService().XMLToObject(MasterEntity.xdoc_SEL_T001_P1, MC.SalesOrderList);
                    //MC.SalesOrderList.Clear();
                    //foreach (SEL_T001_P1 item in MCTemp.SalesOrderList)
                    //{
                    //    MC.SalesOrderList.Add(item);
                    //}   
                    List<SEL_T001_P1> TempSalesOrderList = (from o in MC.SalesOrderList where o.t_status_PPC_B != "Cancelled" || o.t_status_PPC_B != "013" select o).ToList();
                    SalesOrderCollection = CollectionViewSource.GetDefaultView(TempSalesOrderList);
                    SalesOrderCollection.Filter = new Predicate<object>(Filter_SoData);
                }

                if (MasterEntity.xdoc_PPC_T004_A != null)
                {
                    MachineDetailEntity.Clear();
                    MachineDetailEntity = (ObservableCollection<PPC_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.xdoc_PPC_T004_A, MC.MachineDetailEntity);
                }
                else
                {
                    MachineDetailEntity = new ObservableCollection<PPC_T004_A>();
                }
                if (MasterEntity.xdoc_PPC_T004_B != null)
                {
                    SoDetailEntity.Clear();
                    SoDetailEntity = (ObservableCollection<PPC_T004_B>)new ObjectSerializationService().XMLToObject(MasterEntity.xdoc_PPC_T004_B, MC.SoDetailEntity);
                }
                else
                {
                    SoDetailEntity = new ObservableCollection<PPC_T004_B>();
                }

                if (MasterEntity.XmlDataDocument_BackFlip != null)
                {
                    MC.BackflipList = (List<PPC_T004_P>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_BackFlip, MC.BackflipList);
                    FlipGridData.Add(MC.BackflipList[0]);
                    BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    BackFlipCollection.Filter = new Predicate<object>(Filter_BackFlip);
                    BackFlipCollection.Refresh();
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("PPC_T004_VM");
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
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.plan_no))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.plan_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<PPC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PPC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PPC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PPC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PPC_T004> result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region . Filters .

        #region . BackFlip .
        private string _filterString_BackFlip;
        public string filterString_BackFlip
        {
            get { return _filterString_BackFlip; }
            set
            {
                _filterString_BackFlip = value;
                RaisePropertyChanged("filterString_BackFlip");
                FilterCollection_BackFlip();
            }
        }
        private void FilterCollection_BackFlip()
        {
            if (BackFlipCollection != null)
            {
                BackFlipCollection.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as PPC_T004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.plan_no != null && data.plan_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.plan_date != null && data.plan_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.start_date != null && data.start_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.finish_date != null && data.finish_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.wc_name != null && data.wc_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.production_plant != null && data.production_plant.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Machine .
        private string _filterString_Machine;
        public string filterString_Machine
        {
            get { return _filterString_Machine; }
            set
            {
                _filterString_Machine = value;
                RaisePropertyChanged("filterString_Machine");
                FilterCollection_Machine();
            }
        }
        private void FilterCollection_Machine()
        {
            if (MachineCollection != null)
            {
                MachineCollection.Refresh();
            }
        }
        public bool Filter_Machine(object obj)
        {
            var data = obj as PPC_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Machine))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                           (data.machinesrno != null && data.machinesrno.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                           (data.machinedesc != null && data.machinedesc.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Machine1 .
        private string _filterString_Machine1;
        public string filterString_Machine1
        {
            get { return _filterString_Machine1; }
            set
            {
                _filterString_Machine1 = value;
                RaisePropertyChanged("filterString_Machine1");
                FilterCollection_Machine1();
            }
        }
        private void FilterCollection_Machine1()
        {
            if (MachineCollection1 != null)
            {
                MachineCollection1.Refresh();
            }
        }
        public bool Filter_Machine1(object obj)
        {
            var data = obj as PPC_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Machine1))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine1.ToLower())) ||
                           (data.machinesrno != null && data.machinesrno.ToString().ToLower().Contains(_filterString_Machine1.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine1.ToLower())) ||
                           (data.machinedesc != null && data.machinedesc.ToString().ToLower().Contains(_filterString_Machine1.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ItemCode .
        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                Filter_ItemList();
            }
        }
        private void Filter_ItemList()
        {
            if (ItemCollection != null)
            {
                ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Ink .
        private string _filterString_Ink;
        public string filterString_Ink
        {
            get { return _filterString_Ink; }
            set
            {
                _filterString_Ink = value;
                RaisePropertyChanged("filterString_Ink");
                FilterCollection_Ink();
            }
        }
        private void FilterCollection_Ink()
        {
            if (_InkCollection != null)
            {
                _InkCollection.Refresh();
            }
        }
        public bool Filter_Ink(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ink))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink.ToLower())) ||
                           (data.ink_id != null && data.ink_id.ToString().ToLower().Contains(_filterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ILD .
        private string _filterString_ILD;
        public string FilterString_ILD
        {
            get { return _filterString_ILD; }
            set
            {
                _filterString_ILD = value;
                RaisePropertyChanged("FilterString_ILD");
                FilterCollection_ILD();
            }
        }
        private void FilterCollection_ILD()
        {
            if (_ILDCollection != null)
            {
                _ILDCollection.Refresh();
            }
        }
        public bool Filter_ILD(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ILD))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_ILD.ToLower())) ||
                           (data.ild_id != null && data.ild_id.ToString().ToLower().Contains(_filterString_ILD.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Unit .
        private string _filterStringUnit;
        public string filterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("filterStringUnit");
                Filter_Unit();
            }
        }
        private void Filter_Unit()
        {
            if (UnitCollection != null)
            {
                UnitCollection.Refresh();
            }
        }
        public bool Filter_Unit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower())) ||
                           (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . BallMake .
        private string _filterString_BallMake;
        public string filterString_BallMake
        {
            get { return _filterString_BallMake; }
            set
            {
                _filterString_BallMake = value;
                RaisePropertyChanged("filterString_BallMake");
                FilterCollection_BallMake();
            }
        }
        private void FilterCollection_BallMake()
        {
            if (BallMakeCollection != null)
            {
                BallMakeCollection.Refresh();
            }
        }
        public bool Filter_BallMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_BallMake.ToLower())) ||
                           (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_BallMake.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . WireMake .
        private string _filterString_WireMake;
        public string filterString_WireMake
        {
            get { return _filterString_WireMake; }
            set
            {
                _filterString_WireMake = value;
                RaisePropertyChanged("filterString_WireMake");
                FilterCollection_WireMake();
            }
        }
        private void FilterCollection_WireMake()
        {
            if (WireMakeCollection != null)
            {
                WireMakeCollection.Refresh();
            }
        }
        public bool Filter_WireMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_WireMake.ToLower())) ||
                           (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_WireMake.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . WireType .
        private string _filterString_WireType;
        public string filterString_WireType
        {
            get { return _filterString_WireType; }
            set
            {
                _filterString_WireType = value;
                RaisePropertyChanged("filterString_WireType");
                FilterCollection_WireType();
            }
        }
        private void FilterCollection_WireType()
        {
            if (WireTypeCollection != null)
            {
                WireTypeCollection.Refresh();
            }
        }
        public bool Filter_WireType(object obj)
        {
            var data = obj as ZADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireType))
                {
                    return (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterString_WireType.ToLower())) ||
                           (data.wire_type_id != null && data.wire_type_id.ToString().ToLower().Contains(_filterString_WireType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Plant .
        private string _filterString_Plant;
        public string FilterString_Plant
        {
            get { return _filterString_Plant; }
            set
            {
                _filterString_Plant = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollection_Plant();
            }
        }
        private void FilterCollection_Plant()
        {
            if (plantCollection != null)
            {
                plantCollection.Refresh();
            }
        }
        public bool Filter_Plant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Plant.ToLower()) ||
                                data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Plant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .WireSize .
        private string _filterString_WireSize;
        public string filterString_WireSize
        {
            get { return _filterString_WireSize; }
            set
            {
                _filterString_WireSize = value;
                RaisePropertyChanged("filterString_WireSize");
                FilterCollection_WireSize();
            }
        }
        private void FilterCollection_WireSize()
        {
            if (WireSizeCollection != null)
            {
                WireSizeCollection.Refresh();
            }
        }
        public bool Filter_WireSize(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireSize))
                {
                    return (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_filterString_WireSize.ToLower())) ||
                           (data.wire_size_id != null && data.wire_size_id.ToString().ToLower().Contains(_filterString_WireSize.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .BallSize .
        private string _filterString_BallSize;
        public string filterString_BallSize
        {
            get { return _filterString_BallSize; }
            set
            {
                _filterString_BallSize = value;
                RaisePropertyChanged("filterString_BallSize");
                FilterCollection_BallSize();
            }
        }
        private void FilterCollection_BallSize()
        {
            if (BallSizeCollection != null)
            {
                BallSizeCollection.Refresh();
            }
        }
        public bool Filter_BallSize(object obj)
        {
            var data = obj as ZADM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallSize))
                {
                    return (data.Ball_dia != null && data.Ball_dia.ToString().ToLower().Contains(_filterString_BallSize.ToLower())) ||
                           (data.ball_dia_id != null && data.ball_dia_id.ToString().ToLower().Contains(_filterString_BallSize.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .BallType .
        private string _filterString_BallType;
        public string filterString_BallType
        {
            get { return _filterString_BallType; }
            set
            {
                _filterString_BallType = value;
                RaisePropertyChanged("filterString_BallType");
                FilterCollection_BallType();
            }
        }
        private void FilterCollection_BallType()
        {
            if (BallTypeCollection != null)
            {
                BallTypeCollection.Refresh();
            }
        }
        public bool Filter_BallType(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallType))
                {
                    return (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterString_BallType.ToLower())) ||
                           (data.ball_type_id != null && data.ball_type_id.ToString().ToLower().Contains(_filterString_BallType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .SalesOrderCollection.
        private string _filterString_SoData;
        public string filterString_SoData
        {
            get { return _filterString_SoData; }
            set
            {
                _filterString_SoData = value;
                RaisePropertyChanged("filterString_SoData");
                FilterCollection_SoData();
            }
        }
        private void FilterCollection_SoData()
        {
            if (_SalesOrderCollection != null)
            {
                _SalesOrderCollection.Refresh();
            }
        }
        public bool Filter_SoData(object obj)
        {
            var data = obj as SEL_T001_P1;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SoData))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           //(data.location_Id != null && data.location_Id.ToString().ToLower().Contains(plant_main.ToLower())) ||
                           (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.Ink != null && data.Ink.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.Ild != null && data.Ild.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.CurrentStock != null && data.CurrentStock.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.ball_dia != null && data.ball_dia.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.MinQty != null && data.MinQty.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.MaxQty != null && data.MaxQty.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.Reorder != null && data.Reorder.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.stock_total != null && data.stock_total.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.stock_reserve != null && data.stock_reserve.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.stock_unr != null && data.stock_unr.ToString().ToLower().Contains(_filterString_SoData.ToLower())) ||
                           (data.stock_in_transit != null && data.stock_in_transit.ToString().ToLower().Contains(_filterString_SoData.ToLower()));
                }
                return true;
            }
            return false;
        }

       
        #endregion

        #endregion


    }
}
