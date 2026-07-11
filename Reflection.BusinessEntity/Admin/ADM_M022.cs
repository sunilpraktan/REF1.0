using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.Finance;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M022 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _Srno;
        public int Srno
        {
            get { return _Srno; }

            set
            {
                if (_Srno != value)
                {
                    _Srno = value; RaisePropertyChanged("Srno");
                }
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }

            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }

            set
            {
                if (_ItemName != value)
                {
                    _ItemName = value; RaisePropertyChanged("ItemName");
                }
            }
        }

        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }

            set
            {
                if (_ItemTypeCd != value)
                {
                    _ItemTypeCd = value; RaisePropertyChanged("ItemTypeCd");
                }
            }
        }

        private string _SubItemTpCd;
        public string SubItemTpCd
        {
            get { return _SubItemTpCd; }

            set
            {
                if (_SubItemTpCd != value)
                {
                    _SubItemTpCd = value; RaisePropertyChanged("SubItemTpCd");
                }
            }
        }

        private string _ProdNmCd;
        public string ProdNmCd
        {
            get { return _ProdNmCd; }

            set
            {
                if (_ProdNmCd != value)
                {
                    _ProdNmCd = value; RaisePropertyChanged("ProdNmCd");
                }
            }
        }

        private string _CommCode;
        public string CommCode
        {
            get { return _CommCode; }

            set
            {
                if (_CommCode != value)
                {
                    _CommCode = value; RaisePropertyChanged("CommCode");
                }
            }
        }

        private string _MateCode;
        public string MateCode
        {
            get { return _MateCode; }

            set
            {
                if (_MateCode != value)
                {
                    _MateCode = value; RaisePropertyChanged("MateCode");
                }
            }
        }

        private Nullable<bool> _BtchFlg;
        public Nullable<bool> BtchFlg
        {
            get { return _BtchFlg; }

            set
            {
                if (_BtchFlg != value)
                {
                    _BtchFlg = value; RaisePropertyChanged("BtchFlg");
                }
            }
        }

        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }

            set
            {
                if (_CatCode != value)
                {
                    _CatCode = value; RaisePropertyChanged("CatCode");
                }
            }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }

            set
            {
                if (_SubCatCode != value)
                {
                    _SubCatCode = value; RaisePropertyChanged("SubCatCode");
                }
            }
        }

        private string _revision;
        public string revision
        {
            get { return _revision; }

            set
            {
                if (_revision != value)
                {
                    _revision = value; RaisePropertyChanged("revision");
                }
            }
        }

        private string _ISCode;
        public string ISCode
        {
            get { return _ISCode; }

            set
            {
                if (_ISCode != value)
                {
                    _ISCode = value; RaisePropertyChanged("ISCode");
                }
            }
        }

        private string _AssetCode;
        public string AssetCode
        {
            get { return _AssetCode; }

            set
            {
                if (_AssetCode != value)
                {
                    _AssetCode = value; RaisePropertyChanged("AssetCode");
                }
            }
        }

        private string _DrwgNo;
        public string DrwgNo
        {
            get { return _DrwgNo; }

            set
            {
                if (_DrwgNo != value)
                {
                    _DrwgNo = value; RaisePropertyChanged("DrwgNo");
                }
            }
        }

        private string _DrgFlNm;
        public string DrgFlNm
        {
            get { return _DrgFlNm; }

            set
            {
                if (_DrgFlNm != value)
                {
                    _DrgFlNm = value; RaisePropertyChanged("DrgFlNm");
                }
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }

            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }

        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }

            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit");
                }
            }
        }

        private Nullable<decimal> _UnitWt;
        public Nullable<decimal> UnitWt
        {
            get { return _UnitWt; }

            set
            {
                if (_UnitWt != value)
                {
                    _UnitWt = value; RaisePropertyChanged("UnitWt");
                }
            }
        }

        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }

            set
            {
                if (_volume_unit != value)
                {
                    _volume_unit = value; RaisePropertyChanged("volume_unit");
                }
            }
        }

        private Nullable<decimal> _UnitVol;
        public Nullable<decimal> UnitVol
        {
            get { return _UnitVol; }

            set
            {
                if (_UnitVol != value)
                {
                    _UnitVol = value; RaisePropertyChanged("UnitVol");
                }
            }
        }

        private Nullable<decimal> _LdTmManf;
        public Nullable<decimal> LdTmManf
        {
            get { return _LdTmManf; }

            set
            {
                if (_LdTmManf != value)
                {
                    _LdTmManf = value; RaisePropertyChanged("LdTmManf");
                }
            }
        }

        private string _SpcFlNm;
        public string SpcFlNm
        {
            get { return _SpcFlNm; }

            set
            {
                if (_SpcFlNm != value)
                {
                    _SpcFlNm = value; RaisePropertyChanged("SpcFlNm");
                }
            }
        }

        private Nullable<bool> _BomAlwd;
        public Nullable<bool> BomAlwd
        {
            get { return _BomAlwd; }

            set
            {
                if (_BomAlwd != value)
                {
                    _BomAlwd = value; RaisePropertyChanged("BomAlwd");
                }
            }
        }

        private string _BomItTp;
        public string BomItTp
        {
            get { return _BomItTp; }

            set
            {
                if (_BomItTp != value)
                {
                    _BomItTp = value; RaisePropertyChanged("BomItTp");
                }
            }
        }

        private Nullable<decimal> _ShrkRate;
        public Nullable<decimal> ShrkRate
        {
            get { return _ShrkRate; }

            set
            {
                if (_ShrkRate != value)
                {
                    _ShrkRate = value; RaisePropertyChanged("ShrkRate");
                }
            }
        }

        private Nullable<bool> _OutPrsng;
        public Nullable<bool> OutPrsng
        {
            get { return _OutPrsng; }

            set
            {
                if (_OutPrsng != value)
                {
                    _OutPrsng = value; RaisePropertyChanged("OutPrsng");
                }
            }
        }

        private Nullable<bool> _BuildWip;
        public Nullable<bool> BuildWip
        {
            get { return _BuildWip; }

            set
            {
                if (_BuildWip != value)
                {
                    _BuildWip = value; RaisePropertyChanged("BuildWip");
                }
            }
        }

        private Nullable<bool> _CostEnbl;
        public Nullable<bool> CostEnbl
        {
            get { return _CostEnbl; }

            set
            {
                if (_CostEnbl != value)
                {
                    _CostEnbl = value; RaisePropertyChanged("CostEnbl");
                }
            }
        }

        private bool _Stockble;
        public bool Stockble
        {
            get { return _Stockble; }

            set
            {
                if (_Stockble != value)
                {
                    _Stockble = value; RaisePropertyChanged("Stockble");
                }
            }
        }

        private Nullable<decimal> _AvgCon;
        public Nullable<decimal> AvgCon
        {
            get { return _AvgCon; }

            set
            {
                if (_AvgCon != value)
                {
                    _AvgCon = value; RaisePropertyChanged("AvgCon");
                }
            }
        }

        private Nullable<decimal> _MaxQty;
        public Nullable<decimal> MaxQty
        {
            get { return _MaxQty; }

            set
            {
                if (_MaxQty != value)
                {
                    _MaxQty = value; RaisePropertyChanged("MaxQty");
                }
            }
        }

        private Nullable<decimal> _MinQty;
        public Nullable<decimal> MinQty
        {
            get { return _MinQty; }

            set
            {
                if (_MinQty != value)
                {
                    _MinQty = value; RaisePropertyChanged("MinQty");
                }
            }
        }

        private string _ItClass;
        public string ItClass
        {
            get { return _ItClass; }

            set
            {
                if (_ItClass != value)
                {
                    _ItClass = value; RaisePropertyChanged("ItClass");
                }
            }
        }

        private Nullable<int> _ShelfDay;
        public Nullable<int> ShelfDay
        {
            get { return _ShelfDay; }

            set
            {
                if (_ShelfDay != value)
                {
                    _ShelfDay = value; RaisePropertyChanged("ShelfDay");
                }
            }
        }

        private Nullable<decimal> _Reorder;
        public Nullable<decimal> Reorder
        {
            get { return _Reorder; }

            set
            {
                if (_Reorder != value)
                {
                    _Reorder = value; RaisePropertyChanged("Reorder");
                }
            }
        }

        private Nullable<bool> _BlkInvnt;
        public Nullable<bool> BlkInvnt
        {
            get { return _BlkInvnt; }

            set
            {
                if (_BlkInvnt != value)
                {
                    _BlkInvnt = value; RaisePropertyChanged("BlkInvnt");
                }
            }
        }

        private Nullable<decimal> _CarrCost;
        public Nullable<decimal> CarrCost
        {
            get { return _CarrCost; }

            set
            {
                if (_CarrCost != value)
                {
                    _CarrCost = value; RaisePropertyChanged("CarrCost");
                }
            }
        }

        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }

            set
            {
                if (_StockUnt != value)
                {
                    _StockUnt = value; RaisePropertyChanged("StockUnt");
                }
            }
        }

        private Nullable<bool> _Prchsble;
        public Nullable<bool> Prchsble
        {
            get { return _Prchsble; }

            set
            {
                if (_Prchsble != value)
                {
                    _Prchsble = value; RaisePropertyChanged("Prchsble");
                }
            }
        }

        private Nullable<bool> _Sob;
        public Nullable<bool> Sob
        {
            get { return _Sob; }

            set
            {
                if (_Sob != value)
                {
                    _Sob = value; RaisePropertyChanged("Sob");
                }
            }
        }

        private Nullable<decimal> _RandQty;
        public Nullable<decimal> RandQty
        {
            get { return _RandQty; }

            set
            {
                if (_RandQty != value)
                {
                    _RandQty = value; RaisePropertyChanged("RandQty");
                }
            }
        }

        private string _PayTerms;
        public string PayTerms
        {
            get { return _PayTerms; }

            set
            {
                if (_PayTerms != value)
                {
                    _PayTerms = value; RaisePropertyChanged("PayTerms");
                }
            }
        }

        private Nullable<bool> _UnRecpt;
        public Nullable<bool> UnRecpt
        {
            get { return _UnRecpt; }

            set
            {
                if (_UnRecpt != value)
                {
                    _UnRecpt = value; RaisePropertyChanged("UnRecpt");
                }
            }
        }

        private Nullable<bool> _Import;
        public Nullable<bool> Import
        {
            get { return _Import; }

            set
            {
                if (_Import != value)
                {
                    _Import = value; RaisePropertyChanged("Import");
                }
            }
        }

        private Nullable<bool> _BlckPurch;
        public Nullable<bool> BlckPurch
        {
            get { return _BlckPurch; }

            set
            {
                if (_BlckPurch != value)
                {
                    _BlckPurch = value; RaisePropertyChanged("BlckPurch");
                }
            }
        }

        private Nullable<int> _RcptErly;
        public Nullable<int> RcptErly
        {
            get { return _RcptErly; }

            set
            {
                if (_RcptErly != value)
                {
                    _RcptErly = value; RaisePropertyChanged("RcptErly");
                }
            }
        }

        private Nullable<int> _RcptLat;
        public Nullable<int> RcptLat
        {
            get { return _RcptLat; }

            set
            {
                if (_RcptLat != value)
                {
                    _RcptLat = value; RaisePropertyChanged("RcptLat");
                }
            }
        }

        private Nullable<bool> _RinReq;
        public Nullable<bool> RinReq
        {
            get { return _RinReq; }

            set
            {
                if (_RinReq != value)
                {
                    _RinReq = value; RaisePropertyChanged("RinReq");
                }
            }
        }

        private Nullable<int> _SlotSize;
        public Nullable<int> SlotSize
        {
            get { return _SlotSize; }

            set
            {
                if (_SlotSize != value)
                {
                    _SlotSize = value; RaisePropertyChanged("SlotSize");
                }
            }
        }

        private string _RgCode;
        public string RgCode
        {
            get { return _RgCode; }

            set
            {
                if (_RgCode != value)
                {
                    _RgCode = value; RaisePropertyChanged("RgCode");
                }
            }
        }

        private Nullable<bool> _Invicble;
        public Nullable<bool> Invicble
        {
            get { return _Invicble; }

            set
            {
                if (_Invicble != value)
                {
                    _Invicble = value; RaisePropertyChanged("Invicble");
                }
            }
        }

        private Nullable<bool> _Trnstble;
        public Nullable<bool> Trnstble
        {
            get { return _Trnstble; }

            set
            {
                if (_Trnstble != value)
                {
                    _Trnstble = value; RaisePropertyChanged("Trnstble");
                }
            }
        }

        private Nullable<decimal> _ExDuty;
        public Nullable<decimal> ExDuty
        {
            get { return _ExDuty; }

            set
            {
                if (_ExDuty != value)
                {
                    _ExDuty = value; RaisePropertyChanged("ExDuty");
                }
            }
        }

        private string _Warranty;
        public string Warranty
        {
            get { return _Warranty; }

            set
            {
                if (_Warranty != value)
                {
                    _Warranty = value; RaisePropertyChanged("Warranty");
                }
            }
        }

        private Nullable<bool> _Taxable;
        public Nullable<bool> Taxable
        {
            get { return _Taxable; }

            set
            {
                if (_Taxable != value)
                {
                    _Taxable = value; RaisePropertyChanged("Taxable");
                }
            }
        }

        private Nullable<int> _SerDays;
        public Nullable<int> SerDays
        {
            get { return _SerDays; }

            set
            {
                if (_SerDays != value)
                {
                    _SerDays = value; RaisePropertyChanged("SerDays");
                }
            }
        }

        private Nullable<bool> _BlckSales;
        public Nullable<bool> BlckSales
        {
            get { return _BlckSales; }

            set
            {
                if (_BlckSales != value)
                {
                    _BlckSales = value; RaisePropertyChanged("BlckSales");
                }
            }
        }

        private string _IdentMrk;
        public string IdentMrk
        {
            get { return _IdentMrk; }

            set
            {
                if (_IdentMrk != value)
                {
                    _IdentMrk = value; RaisePropertyChanged("IdentMrk");
                }
            }
        }

        private Nullable<bool> _CurrSts;
        public Nullable<bool> CurrSts
        {
            get { return _CurrSts; }

            set
            {
                if (_CurrSts != value)
                {
                    _CurrSts = value; RaisePropertyChanged("CurrSts");
                }
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        private string _prod_type;
        public string prod_type
        {
            get { return _prod_type; }

            set
            {
                if (_prod_type != value)
                {
                    _prod_type = value; RaisePropertyChanged("prod_type");
                }
            }
        }

        private Nullable<decimal> _sales_price;
        public Nullable<decimal> sales_price
        {
            get { return _sales_price; }

            set
            {
                if (_sales_price != value)
                {
                    _sales_price = value; RaisePropertyChanged("sales_price");
                }
            }
        }

        private Nullable<decimal> _purchs_price;
        public Nullable<decimal> purchs_price
        {
            get { return _purchs_price; }

            set
            {
                if (_purchs_price != value)
                {
                    _purchs_price = value; RaisePropertyChanged("purchs_price");
                }
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }

            set
            {
                if (_barcode != value)
                {
                    _barcode = value; RaisePropertyChanged("barcode");
                }
            }
        }

        private string _Procur_mthd;
        public string Procur_mthd
        {
            get { return _Procur_mthd; }

            set
            {
                if (_Procur_mthd != value)
                {
                    _Procur_mthd = value; RaisePropertyChanged("Procur_mthd");
                }
            }
        }

        private string _supply_mthd;
        public string supply_mthd
        {
            get { return _supply_mthd; }

            set
            {
                if (_supply_mthd != value)
                {
                    _supply_mthd = value; RaisePropertyChanged("supply_mthd");
                }
            }
        }

        private Nullable<bool> _pr_required;
        public Nullable<bool> pr_required
        {
            get { return _pr_required; }

            set
            {
                if (_pr_required != value)
                {
                    _pr_required = value; RaisePropertyChanged("pr_required");
                }
            }
        }

        private string _purchase_unit;
        public string purchase_unit
        {
            get { return _purchase_unit; }

            set
            {
                if (_purchase_unit != value)
                {
                    _purchase_unit = value; RaisePropertyChanged("purchase_unit");
                }
            }
        }

        private Nullable<decimal> _cust_leadtm;
        public Nullable<decimal> cust_leadtm
        {
            get { return _cust_leadtm; }

            set
            {
                if (_cust_leadtm != value)
                {
                    _cust_leadtm = value; RaisePropertyChanged("cust_leadtm");
                }
            }
        }

        private Nullable<int> _incm_accnt;
        public Nullable<int> incm_accnt
        {
            get { return _incm_accnt; }

            set
            {
                if (_incm_accnt != value)
                {
                    _incm_accnt = value; RaisePropertyChanged("incm_accnt");
                }
            }
        }

        private Nullable<int> _expns_accnt;
        public Nullable<int> expns_accnt
        {
            get { return _expns_accnt; }

            set
            {
                if (_expns_accnt != value)
                {
                    _expns_accnt = value; RaisePropertyChanged("expns_accnt");
                }
            }
        }

        private string _cust_tax;
        public string cust_tax
        {
            get { return _cust_tax; }

            set
            {
                if (_cust_tax != value)
                {
                    _cust_tax = value; RaisePropertyChanged("cust_tax");
                }
            }
        }

        private string _supplier_tax;
        public string supplier_tax
        {
            get { return _supplier_tax; }

            set
            {
                if (_supplier_tax != value)
                {
                    _supplier_tax = value; RaisePropertyChanged("supplier_tax");
                }
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }

            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }

            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }

            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }

            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }

            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1");
                }
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2");
                }
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3");
                }
            }
        }

        private Nullable<int> _para4;
        public Nullable<int> para4
        {
            get { return _para4; }

            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4");
                }
            }
        }

        private Nullable<decimal> _para5;
        public Nullable<decimal> para5
        {
            get { return _para5; }

            set
            {
                if (_para5 != value)
                {
                    _para5 = value; RaisePropertyChanged("para5");
                }
            }
        }

        private Nullable<decimal> _para6;
        public Nullable<decimal> para6
        {
            get { return _para6; }

            set
            {
                if (_para6 != value)
                {
                    _para6 = value; RaisePropertyChanged("para6");
                }
            }
        }

        private string _para7;
        public string para7
        {
            get { return _para7; }

            set
            {
                if (_para7 != value)
                {
                    _para7 = value; RaisePropertyChanged("para7");
                }
            }
        }
        
        private string _value_class;
        public string value_class
        {
            get { return _value_class; }

            set
            {
                if (_value_class != value)
                {
                    _value_class = value; RaisePropertyChanged("value_class");
                }
            }
        }

        private string _acc_group;
        public string acc_group
        {
            get { return _acc_group; }

            set
            {
                if (_acc_group != value)
                {
                    _acc_group = value; RaisePropertyChanged("acc_group");
                }
            }
        }

        private string _recon_acc;
        public string recon_acc
        {
            get { return _recon_acc; }

            set
            {
                if (_recon_acc != value)
                {
                    _recon_acc = value; RaisePropertyChanged("recon_acc");
                }
            }
        }
        private string _gst_item_group;
        public string gst_item_group
        {
            get { return _gst_item_group; }

            set
            {
                if (_gst_item_group != value)
                {
                    _gst_item_group = value; RaisePropertyChanged("gst_item_group");
                }
            }
        }
        private string _tax_cat_code;
        public string tax_cat_code
        {
            get { return _tax_cat_code; }

            set
            {
                if (_tax_cat_code != value)
                {
                    _tax_cat_code = value; RaisePropertyChanged("tax_cat_code");
                }
            }
        }
        private string _hsn;
        public string hsn
        {
            get { return _hsn; }

            set
            {
                if (_hsn != value)
                {
                    _hsn = value; RaisePropertyChanged("hsn");
                }
            }
        }

        private string _base_unit;
        public string base_unit
        {
            get { return _base_unit; }

            set
            {
                if (_base_unit != value)
                {
                    _base_unit = value; RaisePropertyChanged("base_unit");
                }
            }
        }

        private string _issue_unit;
        public string issue_unit
        {
            get { return _issue_unit; }

            set
            {
                if (_issue_unit != value)
                {
                    _issue_unit = value; RaisePropertyChanged("issue_unit");
                }
            }
        }

        private string _target_qm_sys;
        public string target_qm_sys
        {
            get { return _target_qm_sys; }

            set
            {
                if (_target_qm_sys != value)
                {
                    _target_qm_sys = value; RaisePropertyChanged("target_qm_sys");
                }
            }
        }

        private Nullable<bool> _post_insp_stock;
        public Nullable<bool> post_insp_stock
        {
            get { return _post_insp_stock; }

            set
            {
                if (_post_insp_stock != value)
                {
                    _post_insp_stock = value; RaisePropertyChanged("post_insp_stock");
                }
            }
        }

        private string _mat_auth_grp;
        public string mat_auth_grp
        {
            get { return _mat_auth_grp; }

            set
            {
                if (_mat_auth_grp != value)
                {
                    _mat_auth_grp = value; RaisePropertyChanged("mat_auth_grp");
                }
            }
        }

        private string _control_key;
        public string control_key
        {
            get { return _control_key; }

            set
            {
                if (_control_key != value)
                {
                    _control_key = value; RaisePropertyChanged("control_key");
                }
            }
        }

        private string _certi_tp;
        public string certi_tp
        {
            get { return _certi_tp; }

            set
            {
                if (_certi_tp != value)
                {
                    _certi_tp = value; RaisePropertyChanged("certi_tp");
                }
            }
        }

        private Nullable<bool> _qm_pur;
        public Nullable<bool> qm_pur
        {
            get { return _qm_pur; }

            set
            {
                if (_qm_pur != value)
                {
                    _qm_pur = value; RaisePropertyChanged("qm_pur");
                }
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }

            set
            {
                if (_valid_from != value)
                {
                    _valid_from = value; RaisePropertyChanged("valid_from");
                }
            }
        }

        private string _sales_unit;
        public string sales_unit
        {
            get { return _sales_unit; }

            set
            {
                if (_sales_unit != value)
                {
                    _sales_unit = value; RaisePropertyChanged("sales_unit");
                }
            }
        }

        private string _stock_unit;
        public string stock_unit
        {
            get { return _stock_unit; }

            set
            {
                if (_stock_unit != value)
                {
                    _stock_unit = value; RaisePropertyChanged("stock_unit");
                }
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }
        //Scalar


        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }

            set
            {
                if (_gl_name != value)
                {
                    _gl_name = value; RaisePropertyChanged("gl_name");
                }
            }
        }

        private string _value_class_desc;
        public string value_class_desc
        {
            get { return _value_class_desc; }

            set
            {
                if (_value_class_desc != value)
                {
                    _value_class_desc = value; RaisePropertyChanged("value_class_desc");
                }
            }
        }

        private string _group_desc;
        public string group_desc
        {
            get { return _group_desc; }

            set
            {
                if (_group_desc != value)
                {
                    _group_desc = value; RaisePropertyChanged("group_desc");
                }
            }
        }

        private string _acc_group_type;
        public string acc_group_type
        {
            get { return _acc_group_type; }

            set
            {
                if (_acc_group_type != value)
                {
                    _acc_group_type = value; RaisePropertyChanged("acc_group_type");
                }
            }
        }


        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set
            {
                if (_CatName != value)
                {
                    _CatName = value; RaisePropertyChanged("CatName");
                }
            }
        }

        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                if (_SubCatName != value)
                {
                    _SubCatName = value; RaisePropertyChanged("SubCatName");
                }
            }
        }

        private string _ItemTypeNm;
        public string ItemTypeNm
        {
            get { return _ItemTypeNm; }
            set
            {
                if (_ItemTypeNm != value)
                {
                    _ItemTypeNm = value; RaisePropertyChanged("ItemTypeNm");
                }
            }
        }

        private string _SubItemTpNm;
        public string SubItemTpNm
        {
            get { return _SubItemTpNm; }
            set
            {
                if (_SubItemTpNm != value)
                {
                    _SubItemTpNm = value; RaisePropertyChanged("SubItemTpNm");
                }
            }
        }

        private string _ProdNm;
        public string ProdNm
        {
            get { return _ProdNm; }
            set
            {
                if (_ProdNm != value)
                {
                    _ProdNm = value; RaisePropertyChanged("ProdNm");
                }
            }
        }

        private string _CommName;
        public string CommName
        {
            get { return _CommName; }
            set
            {
                if (_CommName != value)
                {
                    _CommName = value; RaisePropertyChanged("CommName");
                }
            }
        }

        private string _MateName;
        public string MateName
        {
            get { return _MateName; }
            set
            {
                if (_MateName != value)
                {
                    _MateName = value; RaisePropertyChanged("MateName");
                }
            }
        }

        private string _AssetNm;
        public string AssetNm
        {
            get { return _AssetNm; }
            set
            {
                if (_AssetNm != value)
                {
                    _AssetNm = value; RaisePropertyChanged("AssetNm");
                }
            }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value; RaisePropertyChanged("unit_name");
                }
            }
        }

        private string _Weightunit_name;
        public string Weightunit_name
        {
            get { return _Weightunit_name; }
            set
            {
                if (_Weightunit_name != value)
                {
                    _Weightunit_name = value; RaisePropertyChanged("Weightunit_name");
                }
            }
        }

        private string _Volumeunit_name;
        public string Volumeunit_name
        {
            get { return _Volumeunit_name; }
            set
            {
                if (_Volumeunit_name != value)
                {
                    _Volumeunit_name = value; RaisePropertyChanged("Volumeunit_name");
                }
            }
        }

        private string _Purchesunit_name;
        public string Purchesunit_name
        {
            get { return _Purchesunit_name; }
            set
            {
                if (_Purchesunit_name != value)
                {
                    _Purchesunit_name = value; RaisePropertyChanged("Purchesunit_name");
                }
            }
        }

        private string _RgName;
        public string RgName
        {
            get { return _RgName; }
            set
            {
                if (_RgName != value)
                {
                    _RgName = value; RaisePropertyChanged("RgName");
                }
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value; RaisePropertyChanged("PartyNm");
                }
            }
        }
        private string _gst_item_group_Nm;
        public string gst_item_group_Nm
        {
            get { return _gst_item_group_Nm; }
            set
            {
                if (_gst_item_group_Nm != value)
                {
                    _gst_item_group_Nm = value; RaisePropertyChanged("gst_item_group_Nm");
                }
            }
        }
        private string _tax_indicator_desc { get; set; }
        public string tax_indicator_desc
        {
            get { return _tax_indicator_desc; }
            set
            {
                if (_tax_indicator_desc != value)
                {
                    _tax_indicator_desc = value; RaisePropertyChanged("tax_indicator_desc");
                }
            }
        }
        private Nullable<bool> _batch_auto;
        public Nullable<bool> batch_auto
        {
            get { return _batch_auto; }

            set
            {
                if (_batch_auto != value)
                {
                    _batch_auto = value; RaisePropertyChanged("batch_auto");
                }
            }
        }
        private string _item_name_ex { get; set; }
        public string item_name_ex
        {
            get { return _item_name_ex; }
            set
            {
                if (_item_name_ex != value)
                {
                    _item_name_ex = value; RaisePropertyChanged("item_name_ex");
                }
            }
        }
        private string _item_name_pi { get; set; }
        public string item_name_pi
        {
            get { return _item_name_pi; }
            set
            {
                if (_item_name_pi != value)
                {
                    _item_name_pi = value; RaisePropertyChanged("item_name_pi");
                }
            }
        }
        private string _item_name_awb { get; set; }
        public string item_name_awb
        {
            get { return _item_name_awb; }
            set
            {
                if (_item_name_awb != value)
                {
                    _item_name_awb = value; RaisePropertyChanged("item_name_awb");
                }
            }
        }
        private string _item_name_pl { get; set; }
        public string item_name_pl
        {
            get { return _item_name_pl; }
            set
            {
                if (_item_name_pl != value)
                {
                    _item_name_pl = value; RaisePropertyChanged("item_name_pl");
                }
            }
        }
        private string _item_name_ci { get; set; }
        public string item_name_ci
        {
            get { return _item_name_ci; }
            set
            {
                if (_item_name_ci != value)
                {
                    _item_name_ci = value; RaisePropertyChanged("item_name_ci");
                }
            }
        }
        private string _ind_price { get; set; }
        public string ind_price
        {
            get { return _ind_price; }
            set
            {
                if (_ind_price != value)
                {
                    _ind_price = value; RaisePropertyChanged("ind_price");
                }
            }
        }
        private string _item_group_code { get; set; }
        public string item_group_code
        {
            get { return _item_group_code; }
            set
            {
                if (_item_group_code != value)
                {
                    _item_group_code = value; RaisePropertyChanged("item_group_code");
                }
            }
        }
        private string _ind_batch_req { get; set; }
        public string ind_batch_req
        {
            get { return _ind_batch_req; }
            set
            {
                if (_ind_batch_req != value)
                {
                    _ind_batch_req = value; RaisePropertyChanged("ind_batch_req");
                }
            }
        }
        private string _ind_adv_batch { get; set; }
        public string ind_adv_batch
        {
            get { return _ind_adv_batch; }
            set
            {
                if (_ind_adv_batch != value)
                {
                    _ind_adv_batch = value; RaisePropertyChanged("ind_adv_batch");
                }
            }
        }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class ADM_M022_B : ObjectBase
    {
        private string _item_group_code;
        public string item_group_code
        {
            get { return _item_group_code; }

            set
            {
                if (_item_group_code != value)
                {
                    _item_group_code = value; RaisePropertyChanged("item_group_code");
                }
            }
        }

        private string _item_group_desc;
        public string item_group_desc
        {
            get { return _item_group_desc; }

            set
            {
                if (_item_group_desc != value)
                {
                    _item_group_desc = value; RaisePropertyChanged("item_group_desc");
                }
            }
        }

        private string _prod_desc;
        public string prod_desc
        {
            get { return _prod_desc; }

            set
            {
                if (_prod_desc != value)
                {
                    _prod_desc = value; RaisePropertyChanged("prod_desc");
                }
            }
        }

        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }

            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
    }
    public class MultipleContext_ADM_M022
    {
        public List<ADM_M0002> COMPANY_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST { get; set; }
        public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<ADM_M022_Flip> BackflipList { get; set; }  //BackFlip List
        public List<ADM_M022> MasterEntity { get; set; }
        public List<ADM_M018_P> CategoryList { get; set; }  //Category Master
        public List<ADM_M019_P> SubCategoryList { get; set; }  //Sub Category Master
        public List<ADM_M015_P> ItemTypeList { get; set; }  //Item Type Master
        public List<ADM_M016_P> SubItemTypeList { get; set; }  //Sub Item Type Master
        public List<ADM_M020_P> ProductList { get; set; }  //Product Name Master
        public List<ADM_M014_P> CommodityList { get; set; }  //Commodity Master
        public List<ADM_M021_P> MaterialList { get; set; }  //Material Master
        public List<ADM_M017_P> AssetList { get; set; }  //Asset Master
        public List<ADM_M038_B_P> UnitList { get; set; }  //UOM Master
        public List<ADM_M023_P> RgGroupList { get; set; }  //RG Group Master
        public List<ADM_M028_P> PartyList { get; set; }  //Party Master
        public List<ACC_M003_V> ValuationClassList { get; set; }
        public List<ACC_M003_P> ReconAccountList { get; set; }
        public List<ACC_M003_H> AccountingGroupList { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
        public List<ADM_M052_P> MaterialGroup { get; set; } //Material Group
        public List<ACC_M013_A_P> TaxCategory { get; set; } //Tax Category 
        public List<SYS_M051> ControlKeyMaster { get; set; }
        public List<QMS_M041_P> QMSystemMaster { get; set; }
        public List<QMS_M042_P> CertificateType { get; set; }
        public List<ADM_M022_B> ItemGroupExport { get; set; }
    }
    public class ADM_M052_P
    {
        public string gst_item_group { get; set; }
        public string gst_item_group_Nm { get; set; }
    }

}
