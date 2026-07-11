using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M019 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _item_subcat;
        public string item_subcat
        {
            get { return _item_subcat; }
            set
            {
                if (_item_subcat != value)
                {
                    _item_subcat = value;
                    RaisePropertyChanged("item_subcat", ModelEntityUpdated);
                }
            }
        }

        private string _item_subcat_name;
        public string item_subcat_name
        {
            get { return _item_subcat_name; }
            set
            {
                if (_item_subcat_name != value)
                {
                    _item_subcat_name = value;
                    RaisePropertyChanged("item_subcat_name", ModelEntityUpdated);
                }
            }
        }
        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set
            {
                if (_item_cat != value)
                {
                    _item_cat = value;
                    RaisePropertyChanged("item_cat", ModelEntityUpdated);
                }
            }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }
        private bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }
        // NOTE: Deprecited
        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                if (_SubCatCode != value)
                {
                    _SubCatCode = value;
                    RaisePropertyChanged("SubCatCode"); RaisePropertyChanged("SubCatCode", ModelEntityUpdated);
                }
            }
        }

        // NOTE: Deprecited
        private int? _SubCatId;
        public int? SubCatId
        {
            get { return _SubCatId; }
            set
            {
                if (_SubCatId != value)
                {
                    _SubCatId = value;
                    RaisePropertyChanged("SubCatId");
                }
            }
        }
        // NOTE: Deprecited
        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                if (_SubCatName != value)
                {
                    _SubCatName = value;
                    RaisePropertyChanged("SubCatName"); RaisePropertyChanged("SubCatName", ModelEntityUpdated);
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
                    _CatCode = value;
                    RaisePropertyChanged("CatCode");
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



        private DateTime? _add_date;
        public DateTime? add_date
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

        private DateTime? _edit_date;
        public DateTime? edit_date
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

        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set
            {
                if (_CatName != value)
                {
                    _CatName = value;
                    RaisePropertyChanged("CatName"); RaisePropertyChanged("CatName", ModelEntityUpdated);
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
    }
    public class MultipleContext_ADM_M019
    {
        public List<ADM_M019> SubCategory_1 { get; set; }   //Sub Category Master   
        public ObservableCollection<ADM_M018_P> Category_1 { get; set; }  //Category Master       
    }

    public class MC_ADM_M019 : MC_ADM_BE
    {
        public ObservableCollection<ADM_M019> MASTER_LIST { get; set; }
    }

}

