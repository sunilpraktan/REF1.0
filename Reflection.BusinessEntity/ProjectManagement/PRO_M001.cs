using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_M001 : ObjectBase
    {

        private string _cat_id;
        public string cat_id
        {
            get { return _cat_id; }
            set {
                if (_cat_id != value)
                {
                    _cat_id = value; RaisePropertyChanged("cat_id");
                }
            }              
        }

        private string _cat_title;
        public string cat_title
        { get
            { return _cat_title; }
            set {
                if (_cat_title != value)
                {
                    _cat_title = value; RaisePropertyChanged("cat_title");
                }
            }               
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }                         
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }                
        }

       
       
        private System.DateTime _add_date;
        public System.DateTime add_date
        { get
            { return _add_date; }
            set {
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
            set {
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
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
          

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
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
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
                
        public string XmlDataDocument_DataGridView { get; set; }
        

    }
   //public partial class PRO_M001_A : ObjectBase
   // {
   //     private string _cat_id { get; set; }
   //     public string cat_id
   //     {
   //         get { return _cat_id; }
   //         set
   //         {
   //             if (_cat_id != value)
   //             {
   //                 _cat_id = value; RaisePropertyChanged("cat_id");
   //             }
   //         }
   //     }
   //     private string _sub_cat_code;
   //     public string sub_cat_code
   //     {
   //         get { return _sub_cat_code; }
   //         set
   //         {
   //             if (_sub_cat_code != value)
   //             {
   //                 _sub_cat_code = value; RaisePropertyChanged("sub_cat_code");
   //             }
   //         }
   //     }
   //     private string _sub_cat;
   //     public string sub_cat
   //     {
   //         get { return _sub_cat; }
   //         set
   //         {
   //             if (_sub_cat != value)
   //             {
   //                 _sub_cat = value; RaisePropertyChanged("sub_cat");
   //             }
   //         }
   //     }
   //     private string _comp_code;
   //     public string comp_code
   //     {
   //         get { return _comp_code; }
   //         set
   //         {
   //             if (_comp_code != value)
   //             {
   //                 _comp_code = value; RaisePropertyChanged("comp_code");
   //             }
   //         }
   //     }
   //     private string _client { get; set; }
   //     public string client
   //     {
   //         get { return _client; }
   //         set
   //         {
   //             if (_client != value)
   //             {
   //                 _client = value; RaisePropertyChanged("client");
   //             }
   //         }
   //     }
   //     private bool _active;
   //     public bool active
   //     {
   //         get { return _active; }
   //         set
   //         {
   //             if (_active != value)
   //             {
   //                 _active = value; RaisePropertyChanged("active");
   //             }
   //         }
   //     }
   // }
    public class MultipleContext_PRO_M001
    {
        public List<PRO_M001> ProjectCategoryList { get; set; }
        //public List<COM_T003> Attachment { get; set; }
        
    }
}
