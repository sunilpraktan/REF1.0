using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class EQCR_T001_A : ObjectBase 
    {
        private int _id { get; set; }
        public int id { get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
               

        private string _doc_type { get; set; }
        public string doc_type { get { return _doc_type; }
            set {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
              


        private string _doc_no { get; set; }
        public string doc_no { get { return _doc_no; }
            set {
                if (_doc_no !=value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
               


        private string _ref_doc_no { get; set; }
        public string ref_doc_no { get { return _ref_doc_no; }
            set {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
                }
            }
        }
               


        private Nullable<System.DateTime> _doc_date { get; set; }
        public Nullable<System.DateTime> doc_date { get { return _doc_date; }
            set {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
                


        private Nullable<int> _supplier_id { get; set; }
        public Nullable<int> supplier_id { get { return _supplier_id; }
            set {
                if (_supplier_id != value)
                {
                    _supplier_id = value; RaisePropertyChanged("supplier_id");
                }
            }
        }
              

        private string _item_code { get; set; }
        public string  item_code { get { return _item_code; }
            set {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
              

        private string _invoice_no { get; set; }
        public string invoice_no { get { return _invoice_no; }
            set {
                if (_invoice_no != value)
                {
                    _invoice_no = value; RaisePropertyChanged("invoice_no");
                }
            }
        }
                

        private Nullable<System.DateTime> _invoice_date { get; set; }
        public Nullable<System.DateTime> invoice_date { get { return _invoice_date; }
            set {
                if (_invoice_date != value)
                {
                    _invoice_date = value; RaisePropertyChanged("invoice_date");
                }
            }
        }

        private decimal _ship_qty { get; set; }
        public decimal ship_qty { get { return _ship_qty; }
            set {
                if (_ship_qty != value)
                {
                    _ship_qty = value; RaisePropertyChanged("ship_qty");
                }
            }
        }
               


        private decimal _qty_used { get; set; }
        public decimal qty_used { get { return _qty_used; }
            set {
                if (_qty_used != value)
                {
                    _qty_used = value; RaisePropertyChanged("qty_used");
                }
            }
        }
             


        private decimal _defect_qty { get; set; }
        public decimal defect_qty { get { return _defect_qty; }
            set {
                if (_defect_qty != value)
                {
                    _defect_qty = value; RaisePropertyChanged("defect_qty");
                }
            }
        }
             


        private Nullable<int> _unit { get; set; }
        public Nullable<int> unit { get { return _unit; }
            set {
                if (_unit != value)
                {
                    _unit = value; RaisePropertyChanged("unit");
                }
            }
        }
               


        private string _batch_no { get; set; }
        public string batch_no { get { return _batch_no; }
            set {
                if (_batch_no != value)
                {
                    _batch_no = value; RaisePropertyChanged("batch_no");
                }
            }
        }
                


        private string _observation { get; set; }
        public string observation { get { return _observation; }
            set {
                if (_observation != value)
                {
                    _observation = value; RaisePropertyChanged("observation");
                }
            }
        }
           


        private string _comp_code { get; set; }
        public string comp_code { get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
               


        private string _location_Id { get; set; }
        public string location_Id { get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
               


        private Nullable<bool> _active { get; set; }
        public Nullable<bool> active { get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
               


        private string _add_by { get; set; }
        public string add_by { get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
               


        private Nullable<System.DateTime> _add_date { get; set; }
        public Nullable<System.DateTime> add_date { get { return _add_date; }
            set {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        } 


        private Nullable<int> _edit_by { get; set; }
        public Nullable<int> edit_by { get { return _edit_by; }
            set {
                if (_edit_by != value)
                {
                    _edit_by = value; RaisePropertyChanged("edit_by");
                }
            }

        }


        private Nullable<System.DateTime> _edit_date { get; set; }
        public Nullable<System.DateTime> edit_date { get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
              


        private string _supplier_nm { get; set; }
        public string supplier_nm { get { return _supplier_nm; }
            set {
                if (_supplier_nm != value)
                {
                    _supplier_nm = value; RaisePropertyChanged("supplier_nm");
                }
            }
        }
               


        private string _wire { get; set; }
        public string wire { get { return _wire; }
            set {
                if (_wire != value)
                {
                    _wire = value; RaisePropertyChanged("wire");
                }
            }
        }
               


        private string _unit_nm { get; set; }
        public string unit_nm { get { return _unit_nm; }
            set {
                if (_unit_nm != value)
                {
                    _unit_nm = value; RaisePropertyChanged("unit_nm");
                }
            }
        }
                

        private string _item_nm { get; set; }
        public string item_nm { get { return _item_nm; }
            set {
                if (_item_nm != value)
                {
                    _item_nm = value; RaisePropertyChanged("item_nm");
                }
            }
        }
                

        private string _wire_mat { get; set; }
        public string wire_mat { get { return _wire_mat; }
            set {
                if (_wire_mat != value)
                {
                    _wire_mat = value; RaisePropertyChanged("wire_mat");
                }
            }
        }
              
        
        private string _wire_dia { get; set; }
        public string wire_dia { get { return _wire_dia; }
            set {
                if (_wire_dia != value)
                {
                    _wire_dia = value; RaisePropertyChanged("wire_dia");
                }
            }
        } 
        
        private string _grade { get; set; }
        public string grade { get { return _grade; }
            set {
                if (_grade != value)
                {
                    _grade = value; RaisePropertyChanged("grade");
                }
            }
        }
               

        private string _CompName { get; set; }
        public string CompName { get { return _CompName; }
            set {
                if (_CompName != value)
                {
                    _CompName = value; RaisePropertyChanged("CompName");
                }
            }
        }
               

        private string _title { get; set; }
        public string title { get { return _title; }
            set {
                if (_title != value)
                {
                    _title = value; RaisePropertyChanged("title");
                }
            }
        }
                
        
        public string XmlDataDocument_EQCR_T001_B { get; set; }
        public string XmlDataDocument_EQCR_T001_C { get; set; }
    }
    public  class EQCR_T001_B : ObjectBase
    {
        private int _id { get; set; }
        public int id { get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
              


        private string _doc_no { get; set; }
        public string doc_no { get { return _doc_no; }
            set {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
               

        private Nullable<int> _defect { get; set; }
        public Nullable<int> defect { get { return _defect; }
            set {
                if (_defect != value)
                {
                    _defect = value; RaisePropertyChanged("defect");
                }
            }
        }
               


        private string _defect_nm { get; set; }
        public string defect_nm { get { return _defect_nm; }
            set {
                if (_defect_nm != value)
                {
                    _defect_nm = value; RaisePropertyChanged("defect_nm");
                }
            }
        }
           


        private string _remark { get; set; }
        public string remark { get { return _remark; }
            set {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }
               


        private string _comp_code { get; set; }
        public string comp_code { get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
             

        private string _location_Id { get; set; }
        public string location_Id { get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
                


        private Nullable<bool> _active { get; set; }
        public Nullable<bool> active { get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
            


        private Nullable<int> _add_by { get; set; }
        public Nullable<int> add_by { get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
               


        private Nullable<System.DateTime> _add_date { get; set; }
        public Nullable<System.DateTime> add_date { get { return _add_date; }
            set {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
               


        private Nullable<int> _edit_by { get; set; }
        public Nullable<int> edit_by { get { return _edit_by; }
            set {
                if (_edit_by != value)
                {
                    _edit_by = value; RaisePropertyChanged("edit_by");
                }
            }
        }
               


        private Nullable<System.DateTime> _edit_date { get; set; }
        public Nullable<System.DateTime> edit_date { get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
           

    }
    public  class EQCR_T001_C : ObjectBase
    {
        private int _id { get; set; }
        public int id { get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
              


        private string _doc_no { get; set; }
        public string doc_no { get { return _doc_no; }
            set {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
              

        private Nullable<int> _item { get; set; }
        public Nullable<int> item { get { return _item; }
            set {
                if (_item != value)
                {
                    _item = value; RaisePropertyChanged("item");
                }
            }
        }
            

        private string _item_nm { get; set; }
        public string item_nm { get { return _item_nm; }
            set {
                if (_item_nm != value)
                {
                    _item_nm = value; RaisePropertyChanged("item_nm");
                }
            }
        }
               


        private decimal _ok_qty { get; set; }
        public decimal ok_qty { get { return _ok_qty; }
            set {
                if (_ok_qty != value)
                {
                    _ok_qty = value; RaisePropertyChanged("ok_qty");
                }
            }
        }
               


        private decimal _rejected_qty { get; set; }
        public decimal rejected_qty { get { return _rejected_qty; }
            set {
                if (_rejected_qty != value)
                {
                    _rejected_qty = value; RaisePropertyChanged("rejected_qty");
                }
            }
        }
        


        private byte[] _image { get; set; }
        public byte[] image { get { return _image; }
            set {
                if (_image != value)
                {
                    _image = value; RaisePropertyChanged("image");
                }
            }

        }


        private string _comp_code { get; set; }
        public string comp_code { get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
              


        private string _location_Id { get; set; }
        public string location_Id { get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }



        private Nullable<bool> _active { get; set; }
        public Nullable<bool> active { get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
               


        private Nullable<int> _add_by { get; set; }
        public Nullable<int> add_by { get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
               


        private Nullable<System.DateTime> _add_date { get; set; }
        public Nullable<System.DateTime> add_date { get { return _add_date; }
            set {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
             


        private Nullable<int> _edit_by { get; set; }
        public Nullable<int> edit_by { get { return _edit_by; }
            set {
                if (_edit_by != value)
                {
                    _edit_by = value; RaisePropertyChanged("edit_by");
                }
            }
        }
             


        private Nullable<System.DateTime> _edit_date { get; set; }
        public Nullable<System.DateTime> edit_date { get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
               


    }

    public class MultipleContext_EQCR
    {
        public ObservableCollection<EQCR_T001_A> masterList { get; set; }
        public ObservableCollection<EQCR_T001_B> details_B_List { get; set; }
        public ObservableCollection<EQCR_T001_C> detail_C_List { get; set; }
        public List<ADM_M028_PopUp> SupplierList { get; set; }
        public List<ADM_M021_PopUp> materialList { get; set; }
        public List<ADM_M038_B_PopUp> uomList { get; set; }
        public List<ZADM_M016_PopUp> defectList { get; set; }
        public List<ADM_M022_ESSEM_PopUp> itemList { get; set; }
        public List<ADM_M021_PopUp> sample_DetailsList { get; set; }

    }
}
