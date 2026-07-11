//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Reflection.BusinessEntity.CustomerRelation
//{
//    class ZACC_T001_A
//    {
//    }
//}

using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ZACC_T001_A : ObjectBase
    {
       
        private string _comp_code;
        public string comp_code { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code"); } }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
        private string _wiresz;
        public string wiresz
        {
            get { return _wiresz; }
            set
            {
                if (_wiresz != value)
                {
                    _wiresz = value;
                    RaisePropertyChanged("wiresz");
                }
            }
        }


        private string _wiretp;
        public string wiretp
        {
            get { return _wiretp; }
            set
            {
                if (_wiretp != value)
                {
                    _wiretp = value;
                    RaisePropertyChanged("wiretp");
                }
            }
        }

        private string _balltp;
        public string balltp
        {
            get { return _balltp; }
            set
            {
                if (_balltp != value)
                {
                    _balltp = value;
                    RaisePropertyChanged("balltp");
                }
            }
        }

        private string _tiplen;
        public string tiplen
        {
            get { return _tiplen; }
            set
            {
                if (_tiplen != value)
                {
                    _tiplen = value;
                    RaisePropertyChanged("tiplen");
                }
            }
        }


        private string _unit;
        public string unit
        {
            get { return _unit; }
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    RaisePropertyChanged("unit");
                }
            }
        }


        private Nullable<decimal> _gart;
        public Nullable<decimal> gart
        {
            get { return _gart; }
            set
            {
                if (_gart != value)
                {
                    _gart = value;
                    RaisePropertyChanged("gart");
                }
            }
        }


        private Nullable<decimal> _gbrt;
        public Nullable<decimal> gbrt
        {
            get { return _gbrt; }
            set
            {
                if (_gbrt != value)
                {
                    _gbrt = value;
                    RaisePropertyChanged("gbrt");
                }
            }
        }

        private Nullable<decimal> _gcrt;
        public Nullable<decimal> gcrt
        {
            get { return _gcrt; }
            set
            {
                if (_gcrt != value)
                {
                    _gcrt = value;
                    RaisePropertyChanged("gcrt");
                }
            }
        }



        private string _mon;
        public string mon
        {
            get { return _mon; }
            set
            {
                if (_mon != value)
                {
                    _mon = value;
                    RaisePropertyChanged("mon");
                }
            }
        }

        private string _yr;
        public string yr
        {
            get { return _yr; }
            set
            {
                if (_yr != value)
                {
                    _yr = value;
                    RaisePropertyChanged("yr");
                }
            }
        }



        private string _addby;
        public string addby
        {
            get { return _addby; }
            set
            {
                if (_addby != value)
                {
                    _addby = value;
                    RaisePropertyChanged("addby");
                }
            }
        }
        private Nullable<System.DateTime> _adddt;
        public Nullable<System.DateTime> adddt
        {
            get { return _adddt; }
            set
            {
                if (_adddt != value)
                {
                    _adddt = value;
                    RaisePropertyChanged("adddt");
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
                    _editby = value;
                    RaisePropertyChanged("editby");
                }
            }
        }
        private Nullable<System.DateTime> _editdt;
        public Nullable<System.DateTime> editdt
        {
            get { return _editdt; }
            set
            {
                if (_editdt != value)
                {
                    _editdt = value;
                    RaisePropertyChanged("editdt");
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
                   _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }


        private string _Pre_mon;
        public string Pre_mon
        {
            get { return _Pre_mon; }
            set
            {
                if (_Pre_mon != value)
                {
                    _Pre_mon = value;
                    RaisePropertyChanged("Pre_mon");
                }
            }
        }
            

        private string _Pre_yr;
        public string Pre_yr
        {
            get { return _Pre_yr; }
            set
            {
                if (_Pre_yr != value)
                {
                    _Pre_yr = value;
                    RaisePropertyChanged("Pre_yr");
                }
            }
        }
               

        private string _readonlly;
        public string readonlly
        {
            get { return _readonlly; }
            set
            {
                if (_readonlly != value)
                {
                    _readonlly = value;
                    RaisePropertyChanged("readonlly");
                }
            }
        }
               

        private string _New_mon;
        public string New_mon
        {
            get { return _New_mon; }
            set
            {
                if (_New_mon != value)
                {
                    _New_mon = value;
                    RaisePropertyChanged("New_mon");
                }
            }
        }
               

        private string _New_yr;
        public string New_yr
        {
            get { return _New_yr; }
            set
            {
                if (_New_yr != value)
                {
                    _New_yr = value;
                    RaisePropertyChanged("New_yr");
                }
            }
        }
                



        public string XmlDataDocument_ZACC_T001 { get; set; }
    }
    public class ZACC_T001 : ObjectBase
    {


        private string _Month;
        public string Month
        {
            get { return _Month; }
            set
            {
                if (_Month != value)
                {
                    _Month = value;
                    RaisePropertyChanged("Month");
                }
            }
        }


        private string _Year;
        public string Year
        {
            get { return _Year; }
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    RaisePropertyChanged("Year");
                }
            }
        }
                

    }
    public class MultipleContext_ZACC_T001_A
    {
        public List<ZACC_T001_A> RateEntryDeatils { get; set; }   //ZACC_T001 Carton Data
        public List<ZACC_T001> MonthYear { get; set; }  //ZACC_T001_b Carton Deatils Data
        public List<ZACC_T001_WireSize> WireSize { get; set; }  //Batch Data
        public List<ZACC_T001_WireType> WireType { get; set; }  //Batch Data
        public List<ZACC_T001_BallType> BallType { get; set; }
        public List<ZACC_T001_TipLength> TipLength { get; set; } //Product /Item 
        public List<ZACC_T001_Pre_Year> Pre_Year { get; set; }
        public List<ZACC_T001_Unit> Unit { get; set; }
    }
}
