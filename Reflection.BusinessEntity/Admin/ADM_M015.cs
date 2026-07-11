using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M015 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _item_type;
        public string item_type
        {
            get { return _item_type; }
            set
            {
                if (_item_type != value)
                {
                    _item_type = value;
                    RaisePropertyChanged("item_type", ModelEntityUpdated);
                }
            }
        }

        private string _item_type_name;
        public string item_type_name
        {
            get { return _item_type_name; }
            set
            {
                if (_item_type_name != value)
                {
                    _item_type_name = value;
                    RaisePropertyChanged("item_type_name", ModelEntityUpdated);
                }
            }
        }

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

        // NOTE: Deprecited
        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }
            set
            {
                if (_ItemTypeCd != value)
                {
                    _ItemTypeCd = value;
                    RaisePropertyChanged("ItemTypeCd"); RaisePropertyChanged("ItemTypeCd", ModelEntityUpdated);
                }
            }
        }

        // NOTE: Deprecited
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        // NOTE: Deprecited
        private string _ItemTypeNm;
        public string ItemTypeNm
        {
            get { return _ItemTypeNm; }
            set
            {
                if (_ItemTypeNm != value)
                {
                    _ItemTypeNm = value; RaisePropertyChanged("ItemTypeNm"); RaisePropertyChanged("ItemTypeNm", ModelEntityUpdated);
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

                    RaisePropertyChanged("SubCatCode");
                }
            }
        }

        // NOTE: Deprecited
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        // NOTE: Deprecited
        private DateTime? _add_date;
        public DateTime? add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }

        // NOTE: Deprecited
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }
        // NOTE: Deprecited
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
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
                    _SubCatName = value; RaisePropertyChanged("SubCatName"); RaisePropertyChanged("SubCatName", ModelEntityUpdated);
                }
            }
        }
        // NOTE: Deprecited
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

    public class MultipleContext_ADM_M015
    {
        public ObservableCollection<ADM_M015> ItemTypeList { get; set; }  //SubItmTp Master    
        public List<ADM_M019_P> SubCategoryList { get; set; }  //Sub catagory Master       
    }

}
