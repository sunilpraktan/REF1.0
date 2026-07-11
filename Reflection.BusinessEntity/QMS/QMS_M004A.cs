using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Calibration
{
    public class CAL_M004A : ObjectBase, IDataErrorInfo
    {
        private int _ExtInst_Id;
        public int ExtInst_Id
        {
            get { return _ExtInst_Id; }
            set { _ExtInst_Id = value; RaisePropertyChanged("ExtInst_Id"); }
        }
        private int _ExtInstCod;
        public int ExtInstCod
        {
            get { return _ExtInstCod; }
            set { _ExtInstCod = value; RaisePropertyChanged("ExtInstCod"); }
        }
        private int _PrtyId;
        public int PrtyId
        {
            get { return _PrtyId; }
            set { _PrtyId = value; RaisePropertyChanged("PrtyId"); }
        }
        private string _ExtInstIdNo;
        public string ExtInstIdNo
        {
            get { return _ExtInstIdNo; }
            set { _ExtInstIdNo = value; RaisePropertyChanged("ExtInstIdNo"); }
        }
        private string _LabCode;
        public string LabCode
        {
            get { return _LabCode; }
            set { _LabCode = value; RaisePropertyChanged("LabCode"); }
        }
        private string _InstMake;
        public string InstMake
        {
            get { return _InstMake; }
            set { _InstMake = value; RaisePropertyChanged("InstMake"); }
        }
        private string _Range;
        public string Range
        {
            get { return _Range; }
            set { _Range = value; RaisePropertyChanged("Range"); }
        }
        private string _CalSrc;
        public string CalSrc
        {
            get { return _CalSrc; }
            set { _CalSrc = value; RaisePropertyChanged("CalSrc"); }
        }
        private string _FileName;
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; RaisePropertyChanged("FileName"); }
        }
        private string _Accuracy;
        public string Accuracy
        {
            get { return _Accuracy; }
            set { _Accuracy = value; RaisePropertyChanged("Accuracy"); }
        }
        private string _LeastCnt;
        public string LeastCnt
        {
            get { return _LeastCnt; }
            set { _LeastCnt = value; RaisePropertyChanged("LeastCnt"); }
        }
        private Nullable<decimal> _CalFreq;
        public Nullable<decimal> CalFreq
        {
            get { return _CalFreq; }
            set { _CalFreq = value; RaisePropertyChanged("CalFreq"); }
        }
        private string _CalPerid;
        public string CalPerid
        {
            get { return _CalPerid; }
            set { _CalPerid = value; RaisePropertyChanged("CalPerid"); }
        }
        private string _CalInstNo;
        public string CalInstNo
        {
            get { return _CalInstNo; }
            set { _CalInstNo = value; RaisePropertyChanged("CalInstNo"); }
        }
        private string _TechSpec;
        public string TechSpec
        {
            get { return _TechSpec; }
            set { _TechSpec = value; RaisePropertyChanged("TechSpec"); }
        }
        private string _CalRptNo;
        public string CalRptNo
        {
            get { return _CalRptNo; }
            set { _CalRptNo = value; RaisePropertyChanged("CalRptNo"); }
        }
        private Nullable<decimal> _CalChrgs;
        public Nullable<decimal> CalChrgs
        {
            get { return _CalChrgs; }
            set { _CalChrgs = value; RaisePropertyChanged("CalChrgs"); }
        }
        private bool _AiSts;
        public bool AiSts
        {
            get { return _AiSts; }
            set { _AiSts = value; RaisePropertyChanged("AiSts"); }
        }
        private Nullable<int> _UserId;
        public Nullable<int> UserId
        {
            get { return _UserId; }
            set { _UserId = value; RaisePropertyChanged("UserId"); }
        }
        private Nullable<System.DateTime> _AddDate;
        public Nullable<System.DateTime> AddDate
        {
            get { return _AddDate; }
            set { _AddDate = value; RaisePropertyChanged("AddDate"); }
        }
        private Nullable<int> _EditBy;
        public Nullable<int> EditBy
        {
            get { return _EditBy; }
            set { _EditBy = value; RaisePropertyChanged("EditBy"); }
        }
        private Nullable<System.DateTime> _EditDate;
        public Nullable<System.DateTime> EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; RaisePropertyChanged("EditDate"); }
        }

        public string Xdoc_CAL_M004_A { get; set; }

        public string _instName;
        public string instName
        {
            get { return _instName; }
            set { _instName = value; RaisePropertyChanged("instName"); }
        }
        public string _PartyName;
        public string PartyName
        {
            get { return _PartyName; }
            set { _PartyName = value; RaisePropertyChanged("PartyName"); }
        }
        public string _LabName;
        public string LabName
        {
            get { return _LabName; }
            set { _LabName = value; RaisePropertyChanged("LabName"); }
        }

        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class CAL_M004B : ObjectBase, IDataErrorInfo
    {
        private int _SrNo;
        public int SrNo
        {
            get { return _SrNo; }
            set { _SrNo = value; RaisePropertyChanged("SrNo"); }
        }
        private int _EAccCod;
        public int EAccCod
        {
            get { return _EAccCod; }
            set { _EAccCod = value; RaisePropertyChanged("EAccCod"); }
        }
        private string _EAccScop;
        public string EAccScop
        {
            get { return _EAccScop; }
            set { _EAccScop = value; RaisePropertyChanged("EAccScop"); }
        }
        private string _AccTyp;
        public string AccTyp
        {
            get { return _AccTyp; }
            set { _AccTyp = value; RaisePropertyChanged("AccTyp"); }
        }
        private int _ExtInst_id;
        public int ExtInst_id
        {
            get { return _ExtInst_id; }
            set { _ExtInst_id = value; RaisePropertyChanged("ExtInst_id"); }
        }
        public string _EAccName;
        public string EAccName
        {
            get { return _EAccName; }
            set { _EAccName = value; RaisePropertyChanged("EAccName"); }
        }
        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class MultipleContext_CAL_M004A
    {
        public List<CAL_M004A> Instr1 { get; set; }                                     //Intrument Master
        public ObservableCollection<CAL_M004B> Acc1 { get; set; }                       //Accessory Master
        public ObservableCollection<ADM_M022_PopUp_Inst> Item1 { get; set; }            //item Master
        public ObservableCollection<ADM_M028_PopUp> PrtyMstr1 { get; set; }             //Party Master
        public ObservableCollection<ADM_M003_B_P> Labr1 { get; set; }                  //labrotory Master 
        public ObservableCollection<ADM_M022_PopUp_Inst> AccItem1 { get; set; }      //Accessories from item Master       
    }

}
