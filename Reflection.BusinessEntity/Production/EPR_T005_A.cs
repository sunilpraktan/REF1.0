using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Production
{
    public partial class EPR_T005_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                _gl_code = value;
                RaisePropertyChanged("gl_code");
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        private string _report_type;
        public string report_type
        {
            get { return _report_type; }
            set
            {
                _report_type = value;
                RaisePropertyChanged("report_type");
            }
        }

        private Nullable<int> _font;
        public Nullable<int> font
        {
            get { return _font; }
            set
            {
                _font = value;
                RaisePropertyChanged("font");
            }
        }

        private Nullable<System.DateTime> _prod_date;
        public Nullable<System.DateTime> prod_date
        {
            get { return _prod_date; }
            set
            {
                _prod_date = value;
                RaisePropertyChanged("prod_date");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private Nullable<bool> _label_used_flag;
        public Nullable<bool> label_used_flag
        {
            get { return _label_used_flag; }
            set
            {
                _label_used_flag = value;
                RaisePropertyChanged("label_used_flag");
            }
        }

        public string XmlDataDocument_EPR_T005_B { get; set; }
      public string XmlDataDocument_FlipGrid { get; set; }
    }

    public partial class EPR_T005_B:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("_doc_no");
            }
        }

        private string _report_type;
        public string report_type
        {
            get { return _report_type; }
            set
            {
                _report_type = value;
                RaisePropertyChanged("report_type");
            }
        }

        private string _para;
        public string para
        {
            get { return _para; }
            set
            {
                _para = value;
                RaisePropertyChanged("para");
            }
        }

        private string _value;
        public string value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged("value");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("_edit_date");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set
            {
                _para_code = value;
                RaisePropertyChanged("para_code");
            }
        }
        private string _font;
        public string font
        {
            get { return _font; }
            set
            {
                _font = value;
                RaisePropertyChanged("font");
            }
        }
    }
    public class EPR_T005:ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
            }
        }

        private string _para4;
        public string para4
        {
            get { return _para4; }
            set
            {
                _para4 = value;
                RaisePropertyChanged("para4");
            }
        }

        private string _para5;
        public string para5
        {
            get { return _para5; }
            set
            {
                _para5 = value;
                RaisePropertyChanged("para5");
            }
        }

        private string _para6;
        public string para6
        {
            get { return _para6; }
            set
            {
                _para6 = value;
                RaisePropertyChanged("para6");
            }
        }

        private string _para7;
        public string para7
        {
            get { return _para7; }
            set
            {
                _para7 = value;
                RaisePropertyChanged("para7");
            }
        }

        private string _para8;
        public string para8
        {
            get { return _para8; }
            set
            {
                _para8 = value;
                RaisePropertyChanged("para8");
            }
        }

        private string _para9;
        public string para9
        {
            get { return _para9; }
            set
            {
                _para9 = value;
                RaisePropertyChanged("para9");
            }
        }

        private string _text1;
        public string text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                RaisePropertyChanged("text1");
            }
        }

        private string _text2;
        public string text2
        {
            get { return _text2; }
            set
            {
                _text2 = value;
                RaisePropertyChanged("text2");
            }
        }

        private string _report_type;
        public string report_type
        {
            get { return _report_type; }
            set
            {
                _report_type = value;
                RaisePropertyChanged("report_type");
            }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set
            {
                _para_code = value;
                RaisePropertyChanged("para_code");
            }
        }
        
    }

    public class MultipleContext_EPR_T005_A
    {
        public List<EPR_T005_A_Flip> DocumentDataFlipGrid { get; set; }
        public List<EPR_T005> ParameterDetails { get; set; }
        public List<EPR_T005_A> MasterEntity { get; set; }
        public ObservableCollection<EPR_T005_B> ItemsEntity { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M030_P> ParameterValues { get; set; }
    }
}
