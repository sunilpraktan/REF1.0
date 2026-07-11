using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public partial class ACC_T005: ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }

        }
        private string _place;
        public string place
        {
            get { return _place; }
            set { _place = value; RaisePropertyChanged("place"); }

        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }

        }
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set { _party_name = value; RaisePropertyChanged("party_name"); }


        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }

        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }

        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }

        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }

        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }

        }
        private string _para1;
        public string para1
        {
            get { return _para1; }
            set { _para1 = value; RaisePropertyChanged("para1"); }

        }
        private string _para2;
        public string para2
        {
            get { return _para2; }
            set { _para2 = value; RaisePropertyChanged("para2"); }

        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3"); }

        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set { _para4 = value; RaisePropertyChanged("para4"); }

        }
        private string _para5;
        public string para5
        {
            get { return _para5; }
            set { _para5 = value; RaisePropertyChanged("para5"); }

        }
        private Nullable<System.DateTime> _pay_expected_date;
        public Nullable<System.DateTime> pay_expected_date
        {
            get { return _pay_expected_date; }
            set { _pay_expected_date = value; RaisePropertyChanged("pay_expected_date"); }

        }
        private Nullable<decimal> _payment;
        public Nullable<decimal> payment
        {
            get { return _payment; }
            set { _payment = value; RaisePropertyChanged("payment", ModelEntityUpdated); }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }

        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }

        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }

        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }

        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set { _so_code = value; RaisePropertyChanged("so_code"); }

        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set { _sg_code = value; RaisePropertyChanged("sg_code"); }

        }

        private string _project_name;
        public string project_name
        {
            get { return _project_name; }
            set { _project_name = value; RaisePropertyChanged("project_name"); }

        }
        private string _project_location;
        public string project_location
        {
            get { return _project_location; }
            set { _project_location = value; RaisePropertyChanged("project_location"); }

        }
        private string _project_type;
        public string project_type
        {
            get { return _project_type; }
            set { _project_type = value; RaisePropertyChanged("project_type"); }

        }
        private Nullable<decimal> _out_amt;
        public Nullable<decimal> out_amt
        {
            get { return _out_amt; }
            set { _out_amt = value; RaisePropertyChanged("out_amt"); }

        }
        private Nullable<decimal> _non_finalise;
        public Nullable<decimal> non_finalise
        {
            get { return _non_finalise; }
            set { _non_finalise = value; RaisePropertyChanged("non_finalise"); }

        }
        private Nullable<decimal> _prospectus_amt;
        public Nullable<decimal> prospectus_amt
        {
            get { return _prospectus_amt; }
            set { _prospectus_amt = value; RaisePropertyChanged("prospectus_amt"); }

        }
        private Nullable<decimal> _PO_rec_amt;
        public Nullable<decimal> PO_rec_amt
        {
            get { return _PO_rec_amt; }
            set { _PO_rec_amt = value; RaisePropertyChanged("PO_rec_amt"); }

        }
        private Nullable<decimal> _Total;
        public Nullable<decimal> Total
        {
            get { return _Total; }
            set { _Total = value; RaisePropertyChanged("Total"); }

        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }

        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }

        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }

        }
        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get { return _ref_doc_date; }
            set { _ref_doc_date = value; RaisePropertyChanged("ref_doc_date"); }

        }
        private string _Emp_Id;
        public string Emp_Id
        {
            get { return _Emp_Id; }
            set { _Emp_Id = value; RaisePropertyChanged("Emp_Id"); }

        }
  
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; RaisePropertyChanged("EmpName"); }

        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }
        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                _sg_name = value;
                RaisePropertyChanged("sg_name");
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                _sales_org = value;
                RaisePropertyChanged("sales_org");
            }
        }
        public string XmlDataDocument_ACC_T005_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class ACC_T005_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }

        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private string _place;
        public string place
        {
            get { return _place; }
            set { _place = value; RaisePropertyChanged("place"); }

        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }

        }
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set { _party_name = value; RaisePropertyChanged("party_name"); }


        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }

        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }

        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }

        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }

        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }

        }
        private string _para1;
        public string para1
        {
            get { return _para1; }
            set { _para1 = value; RaisePropertyChanged("para1"); }

        }
        private string _para2;
        public string para2
        {
            get { return _para2; }
            set { _para2 = value; RaisePropertyChanged("para2"); }

        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3"); }

        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set { _para4 = value; RaisePropertyChanged("para4"); }

        }
        private string _para5;
        public string para5
        {
            get { return _para5; }
            set { _para5 = value; RaisePropertyChanged("para5"); }

        }
        private Nullable<System.DateTime> _pay_expected_date;
        public Nullable<System.DateTime> pay_expected_date
        {
            get { return _pay_expected_date; }
            set { _pay_expected_date = value; RaisePropertyChanged("pay_expected_date"); }

        }
        private Nullable<decimal> _payment;
        public Nullable<decimal> payment
        {
            get { return _payment; }
            set { _payment = value; RaisePropertyChanged("payment", ModelEntityUpdated); }

        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }

        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }

        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }

        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }

        }
        private string _project_name;
        public string project_name
        {
            get { return _project_name; }
            set { _project_name = value; RaisePropertyChanged("project_name"); }

        }
        private string _project_location;
        public string project_location
        {
            get { return _project_location; }
            set { _project_location = value; RaisePropertyChanged("project_location"); }

        }
        private string _project_type;
        public string project_type
        {
            get { return _project_type; }
            set { _project_type = value; RaisePropertyChanged("project_type"); }

        }
        private Nullable<decimal> _out_amt;
        public Nullable<decimal> out_amt
        {
            get { return _out_amt; }
            set { _out_amt = value; RaisePropertyChanged("out_amt"); }

        }
        private Nullable<decimal> _non_finalise;
        public Nullable<decimal> non_finalise
        {
            get { return _non_finalise; }
            set { _non_finalise = value; RaisePropertyChanged("non_finalise"); }

        }
        private Nullable<decimal> _prospectus_amt;
        public Nullable<decimal> prospectus_amt
        {
            get { return _prospectus_amt; }
            set { _prospectus_amt = value; RaisePropertyChanged("prospectus_amt"); }

        }
        private Nullable<decimal> _PO_rec_amt;
        public Nullable<decimal> PO_rec_amt
        {
            get { return _PO_rec_amt; }
            set { _PO_rec_amt = value; RaisePropertyChanged("PO_rec_amt"); }

        }
        private Nullable<decimal> _Total;
        public Nullable<decimal> Total
        {
            get { return _Total; }
            set { _Total = value; RaisePropertyChanged("Total"); }

        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }

        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }

        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }

        }
        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get { return _ref_doc_date; }
            set { _ref_doc_date = value; RaisePropertyChanged("ref_doc_date"); }

        }
        private string _Emp_Id;
        public string Emp_Id
        {
            get { return _Emp_Id; }
            set { _Emp_Id = value; RaisePropertyChanged("Emp_Id"); }

        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }
        private string _CustomerNm;
        public string CustomerNm
        {
            get { return _CustomerNm; }
            set { _CustomerNm = value; RaisePropertyChanged("CustomerNm"); }
        }
        private Nullable<decimal> _pending;
        public Nullable<decimal> pending
        {
            get { return _pending; }
            set { _pending = value; RaisePropertyChanged("pending"); }

        }
        private string _Order_type;
        public string Order_type
        {
            get { return _Order_type; }
            set { _Order_type = value; RaisePropertyChanged("Order_type"); }
        }


    }
    public class MultipleContext_ACC_T005
    {
        public List<ACC_T005> MasterEntity { get; set; }
        public ObservableCollection<ACC_T005_A> ItemsEntity { get; set; }
        public List<ACC_T005_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<ACC_T003_B_P> HeadDetailsForGrid { get; set; }
        public List<ACC_M003_P> GlcodeDetails { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M024_POP> EmpDetails { get; set; }
        public List<SEL_T001_QN> SalesOrderAndQuotation { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ACC_T005Rpt> ExpectedPaymentRpt { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
    public class ACC_T005_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string t_status { get; set; }
        public string Emp_Id { get; set; }
        public string EmpName { get; set; }

    }

}
