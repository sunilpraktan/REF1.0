using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M028_H : ObjectBase
    {
        private string _tc_code;
        public string tc_code
        {
            get { return _tc_code; }
            set
            {
                if (_tc_code != value)
                {
                    _tc_code = value;
                    RaisePropertyChanged("tc_code");
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

        private Nullable<int> _sequence_code;

        public Nullable<int> sequence_code
        {
            get { return _sequence_code; }
            set
            {
                if (_sequence_code != value)
                {
                    _sequence_code = value;
                    RaisePropertyChanged("sequence_code");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
                }
            }
        }
       
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }
        }
        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value;
                    RaisePropertyChanged("pg_code");
                }
            }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value;
                    RaisePropertyChanged("po_code");
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
        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }
            set
            {
                if (_ItemTypeCd != value)
                {
                    _ItemTypeCd = value;
                    RaisePropertyChanged("ItemTypeCd");
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
                    RaisePropertyChanged(" _ItemCode");
                }
            }
        }
        private Nullable<int> _sequence1;
        public Nullable<int> sequence1
        {
            get { return _sequence1; }
            set
            {
                if (_sequence1 != value)
                {
                    _sequence1 = value;
                    RaisePropertyChanged(" sequence1");
                }
            }
        }
        private Nullable<int> _sequence2;
        public Nullable<int> sequence2
        {
            get { return _sequence2; }
            set
            {
                if (_sequence2 != value)
                {
                    _sequence2 = value;
                    RaisePropertyChanged(" sequence2");
                }
            }
        }
        private Nullable<int> _sequence3;
        public Nullable<int> sequence3
        {
            get { return _sequence3; }
            set
            {
                if (_sequence3 != value)
                {
                    _sequence3 = value;
                    RaisePropertyChanged(" sequence3");
                }
            }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value;
                    RaisePropertyChanged("short_text");
                }
            }
        }
        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value;
                    RaisePropertyChanged("long_text");
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
        private Nullable<bool> _compulsory;
        public Nullable<bool> compulsory
        {
            get { return _compulsory; }
            set
            {
                if (_compulsory != value)
                {
                    _compulsory = value;
                    RaisePropertyChanged(" compulsory");
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
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
        }
        private string _con_group;
        public string con_group
        {
            get { return _con_group; }
            set
            {
                if (_con_group != value)
                {
                    _con_group = value;
                    RaisePropertyChanged("con_group");
                }
            }
        }
        private string _con_type;
        public string con_type
        {
            get { return _con_type; }
            set
            {
                if (_con_type != value)
                {
                    _con_type = value;
                    RaisePropertyChanged("con_type");
                }
            }
        }
        private string _con_desc;
        public string con_desc
        {
            get { return _con_desc; }
            set
            {
                if (_con_desc != value)
                {
                    _con_desc = value;
                    RaisePropertyChanged("con_desc");
                }
            }
        }
        private string _info_group;
        public string info_group
        {
            get { return _info_group; }
            set
            {
                if (_info_group != value)
                {
                    _info_group = value;
                    RaisePropertyChanged("info_group");
                }
            }
        }
        private string _info_desc;
        public string info_desc
        {
            get { return _info_desc; }
            set
            {
                if (_info_desc != value)
                {
                    _info_desc = value;
                    RaisePropertyChanged("info_desc");
                }
            }
        }
        private string _info_sub_group;
        public string info_sub_group
        {
            get { return _info_sub_group; }
            set
            {
                if (_info_sub_group != value)
                {
                    _info_sub_group = value;
                    RaisePropertyChanged("info_sub_group");
                }
            }
        }
        private string _info_sub_desc;
        public string info_sub_desc
        {
            get { return _info_sub_desc; }
            set
            {
                if (_info_sub_desc != value)
                {
                    _info_sub_desc = value;
                    RaisePropertyChanged("info_sub_desc");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged(" active");
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
        private System.DateTime _add_date;
        public System.DateTime add_date
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
        private string _model_code;
        public string model_code
        {
            get { return _model_code; }
            set
            {
                if (_model_code != value)
                {
                    _model_code = value;
                    RaisePropertyChanged("model_code");
                }
            }
        }
        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value;
                    RaisePropertyChanged("PartyNm");
                }
            }
        }
    }
    public class MultipleContext_ADM_M028_H
    {
        public ObservableCollection<ADM_M028_H> PartyConList { get; set; }
        public List<ADM_M028_P> PartyIDList { get; set; }
    }
}
