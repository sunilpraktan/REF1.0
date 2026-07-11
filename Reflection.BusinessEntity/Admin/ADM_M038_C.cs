using System;
using System.Collections.Generic;
namespace Reflection.BusinessEntity
{
    public class ADM_M038_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;

                    RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _base_unit_code;
        public string base_unit_code
        {
            get { return _base_unit_code; }
            set
            {
                if (_base_unit_code != value)
                {
                    _base_unit_code = value;

                    RaisePropertyChanged("base_unit_code");
                }
            }
        }
        private Nullable<decimal> _c_factor;
        public Nullable<decimal> c_factor
        {
            get { return _c_factor; }
            set
            {
                if (_c_factor != value)
                {
                    _c_factor = value;

                    RaisePropertyChanged("c_factor");
                }
            }
        }
        private Nullable<decimal> _round_precision;
        public Nullable<decimal> round_precision
        {
            get { return _round_precision; }
            set
            {
                if (_round_precision != value)
                {
                    _round_precision = value;

                    RaisePropertyChanged("round_precision");
                }
            }
        }
        private string _conv_type;
        public string conv_type
        {
            get { return _conv_type; }
            set
            {
                if (_conv_type != value)
                {
                    _conv_type = value;

                    RaisePropertyChanged("conv_type");
                }
            }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
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
                    _add_by = value;

                    RaisePropertyChanged("add_by");
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
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
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
        private string _base_unit;
        public string base_unit
        {
            get { return _base_unit; }
            set
            {
                if (_base_unit != value)
                {
                    _base_unit = value;

                    RaisePropertyChanged("base_unit");
                }
            }
        }
        private string _class_name;
        public string class_name
        {
            get { return _class_name; }
            set
            {
                if (_class_name != value)
                {
                    _class_name = value;

                    RaisePropertyChanged("class_name");
                }
            }
        }
        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value;

                    RaisePropertyChanged(" para1");
                }
               
            }
        }
        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value;

                    RaisePropertyChanged(" para2");
                }

            }
        }
        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value;

                    RaisePropertyChanged(" para3");
                }

            }
        }

       
    }
    public class ADM_M038_D : ObjectBase
    {
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
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value;

                    RaisePropertyChanged("ItemCode");
                }
            }
        }
        private string _source_unit_code;
        public string source_unit_code
        {
            get { return _source_unit_code; }
            set
            {
                if (_source_unit_code != value)
                {
                    _source_unit_code = value;

                    RaisePropertyChanged("source_unit_code");
                }
            }
        }
        private string _dest_base_unit_code;
        public string dest_base_unit_code
        {
            get { return _dest_base_unit_code; }
            set
            {
                if (_dest_base_unit_code != value)
                {
                    _dest_base_unit_code = value;

                    RaisePropertyChanged("dest_base_unit_code");
                }
            }
        }
        private decimal _c_factor;
        public decimal c_factor
        {
            get { return _c_factor; }
            set
            {
                if (_c_factor != value)
                {
                    _c_factor = value;

                    RaisePropertyChanged("c_factor");
                }
            }
        }
        private Nullable<decimal> _round_precision;
        public Nullable<decimal> round_precision
        {
            get { return _round_precision; }
            set
            {
                if (_round_precision != value)
                {
                    _round_precision = value;

                    RaisePropertyChanged("round_precision");
                }
            }
        }
        private string _conv_type;
        public string conv_type
        {
            get { return _conv_type; }
            set
            {
                if (_conv_type != value)
                {
                    _conv_type = value;

                    RaisePropertyChanged("conv_type");
                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
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
                    _add_by = value;

                    RaisePropertyChanged("add_by");
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
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
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
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;

                    RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value;

                    RaisePropertyChanged(" para1");
                }

            }
        }
        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value;

                    RaisePropertyChanged(" para2");
                }

            }
        }
        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value;

                    RaisePropertyChanged(" para3");
                }

            }
        }
        
    }
    public class ADM_M038_E : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value;

                    RaisePropertyChanged("ItemCode");
                }
            }
        }
        private string _dest_base_unit_code;
        public string dest_base_unit_code
        {
            get { return _dest_base_unit_code; }
            set
            {
                if (_dest_base_unit_code != value)
                {
                    _dest_base_unit_code = value;

                    RaisePropertyChanged("dest_base_unit_code");
                }
            }
        }
        private string _source_base_unit_code;
        public string source_base_unit_code
        {
            get { return _source_base_unit_code; }
            set
            {
                if (_source_base_unit_code != value)
                {
                    _source_base_unit_code = value;

                    RaisePropertyChanged("source_base_unit_code");
                }
            }
        }
        private decimal _c_factor;
        public decimal c_factor
        {
            get { return _c_factor; }
            set
            {
                if (_c_factor != value)
                {
                    _c_factor = value;

                    RaisePropertyChanged("c_factor");
                }
            }
        }
        private Nullable<decimal> _round_precision;
        public Nullable<decimal> round_precision
        {
            get { return _round_precision; }
            set
            {
                if (_round_precision != value)
                {
                    _round_precision = value;

                    RaisePropertyChanged("round_precision");
                }
            }
        }
        private string _conv_type;
        public string conv_type
        {
            get { return _conv_type; }
            set
            {
                if (_conv_type != value)
                {
                    _conv_type = value;

                    RaisePropertyChanged("conv_type");
                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
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
                    _add_by = value;

                    RaisePropertyChanged("add_by");
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
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
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
        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value;

                    RaisePropertyChanged(" para1");
                }

            }
        }
        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value;

                    RaisePropertyChanged(" para2");
                }

            }
        }
        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value;

                    RaisePropertyChanged(" para3");
                }

            }
        }
        

    }
    public class MultipleContext_ADM_M038_C
    {
        public List<ADM_M038_C> UOM_Convrsn_Stand { get; set; }//UOM Conversion - Standard         
        public List<ADM_M038_A_P> Measur_Cls { get; set; }//Measurement Class    
        public List<ADM_M038_B_P> UOM_Master { get; set; }//UOM Master        
    }
    public class MultipleContext_ADM_M038_D
    {
        public List<ADM_M038_D> UOM_Convrsn_Intra { get; set; }//UOM Conversion - Intra 
        public List<ADM_M022_P> Items { get; set; }//Item Master      
        public List<ADM_M038_B_P> UOM_Master { get; set; }//UOM Master 

    }
    public class MultipleContext_ADM_M038_E
    {
        public List<ADM_M038_E> UOM_Convrsn_Inter { get; set; }//UOM Conversion - Inter 
        public List<ADM_M022_P> Items { get; set; }//Item Master      
        public List<ADM_M038_B_P> UOM_Master { get; set; }//UOM Master 

    }

    public class ADM_M038 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _Index;
        public int Index
        {
            get { return _Index; }
            set
            {
                if (_Index != value)
                {
                    _Index = value;

                    RaisePropertyChanged("Index");
                }
            }
        }
        public string XmlDataDocument { get; set; }
    }
    public class ADM_M038_Delete : ObjectBase
    {
        private int _Index;
        public int Index
        {
            get { return _Index; }
            set
            {
                if (_Index != value)
                {
                    _Index = value;

                    RaisePropertyChanged("Index");
                }
            }
        }
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

    }
}
