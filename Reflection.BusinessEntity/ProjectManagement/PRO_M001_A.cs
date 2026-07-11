using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_M001_A : ObjectBase
    {
        
        private string _sub_cat_code;
        public string sub_cat_code
        {
            get { return _sub_cat_code; }
            set
            {
                if (_sub_cat_code != value)
                {
                    _sub_cat_code = value; RaisePropertyChanged("sub_cat_code");
                }
            }
        }
        private string _sub_cat;
        public string sub_cat
        {
            get { return _sub_cat; }
            set
            {
                if (_sub_cat != value)
                {
                    _sub_cat = value; RaisePropertyChanged("sub_cat");
                }
            }
        }
        private string _cat_id { get; set; }
        public string cat_id
        {
            get { return _cat_id; }
            set
            {
                if (_cat_id != value)
                {
                    _cat_id = value; RaisePropertyChanged("cat_id");
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
        
        private bool _active;
        public bool active
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
        private string _cat_title;
        public string cat_title
        {
            get { return _cat_title; }
            set
            {
                if (_cat_title != value)
                {
                    _cat_title = value; RaisePropertyChanged("cat_title");
                }
            }
        }

        public string XmlDataDocument_DataGridView { get; set; }
    }
    public class MultipleContext_PRO_M001_A
    {    
        public List<PRO_M001_A> ProjectSubCategoryList { get; set; }
        public List<PRO_M001_P> ProjectCategoryList { get; set; }
    }
}
