using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ADM_M016 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _item_subtype;
        public string item_subtype
        {
            get { return _item_subtype; }
            set
            {
                if (_item_subtype != value)
                {
                    _item_subtype = value;
                    RaisePropertyChanged("item_subtype", ModelEntityUpdated);
                }
            }
        }

        private string _item_subtype_name;
        public string item_subtype_name
        {
            get { return _item_subtype_name; }
            set
            {
                if (_item_subtype_name != value)
                {
                    _item_subtype_name = value;
                    RaisePropertyChanged("item_subtype_name", ModelEntityUpdated);
                }
            }
        }

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


        private string _SubItemTpCd;
        public string SubItemTpCd
        {
            get { return _SubItemTpCd; }
            set
            {
                if (_SubItemTpCd != value)
                {
                    _SubItemTpCd = value; RaisePropertyChanged("SubItemTpCd"); RaisePropertyChanged("SubItemTpNm ", ModelEntityUpdated);
                }
            }
        }


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


        private string _SubItemTpNm;
        public string SubItemTpNm
        {
            get { return _SubItemTpNm; }
            set
            {
                if (_SubItemTpNm != value)
                {
                    _SubItemTpNm = value; RaisePropertyChanged("SubItemTpNm"); RaisePropertyChanged("SubItemTpNm ", ModelEntityUpdated);
                }
            }
        }
        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }
            set
            {
                if (_ItemTypeCd != value)
                {
                    _ItemTypeCd = value; RaisePropertyChanged("ItemTypeCd");
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
                    _add_by = value; RaisePropertyChanged("add_by");
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
                    _add_date = value; RaisePropertyChanged("add_date");
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
                    _editby = value; RaisePropertyChanged("editby");
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
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _ItemTypeNm;
        [Required(ErrorMessage = "Field 'Item Type Code' is required.")]
        public string ItemTypeNm
        {
            get { return _ItemTypeNm; }
            set
            {
                if (_ItemTypeNm != value)
                {
                    _ItemTypeNm = value; RaisePropertyChanged("ItemTypeNm"); RaisePropertyChanged("ItemTypeNm ", ModelEntityUpdated);
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
    public class MultipleContext_ADM_M016
    {
        public List<ADM_M016> SubItmTp { get; set; }   //Sub Item Type Master   
        public ObservableCollection<ADM_M015_P> ItmTp { get; set; }  //Item Type Master      
    }

}
