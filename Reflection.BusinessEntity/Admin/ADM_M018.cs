using System;
using Reflection.BusinessEntity.Finance;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M018 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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

        private string _item_cat_name;
        public string item_cat_name
        {
            get { return _item_cat_name; }
            set
            {
                if (_item_cat_name != value)
                {
                    _item_cat_name = value;
                    RaisePropertyChanged("item_cat_name", ModelEntityUpdated);
                }
            }
        }

        // NOTE: Deprecited
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                if (_CatCode != value)
                {
                    _CatCode = value;
                    RaisePropertyChanged("CatCode", ModelEntityUpdated);
                }
            }
        }

        // NOTE: Deprecited
        private int? _CatId;
        public int? CatId
        {
            get { return _CatId; }
            set
            {
                if (_CatId != value)
                {
                    _CatId = value;
                    RaisePropertyChanged("CatId");
                }
            }
        }

        // NOTE: Deprecited
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


        private string _acc_cat;
        public string acc_cat
        {
            get { return _acc_cat; }
            set
            {
                if (_acc_cat != value)
                {
                    _acc_cat = value;
                    RaisePropertyChanged("acc_cat");
                }
            }
        }

        public string XmlDataDocument_FlipGrid { get; set; }
        //scalar
        private string _short_name;
        public string short_name
        {
            get { return _short_name; }
            set
            {
                if (_short_name != value)
                {
                    _short_name = value;
                    RaisePropertyChanged("short_name");
                }
            }
        }

        private string _cat_desc;
        public string cat_desc
        {
            get { return _cat_desc; }
            set
            {
                if (_cat_desc != value)
                {
                    _cat_desc = value;
                    RaisePropertyChanged("cat_desc");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", item_cat);
        }
    }
    public class MultipleContext_ADM_M018
    {
        public List<ADM_M018> MasterList { get; set; }
        public List<ACC_M003_K> AccountCategoryList { get; set; }
    }
}
