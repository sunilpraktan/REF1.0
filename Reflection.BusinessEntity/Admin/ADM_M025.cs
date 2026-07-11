using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M025 : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set { _dept_code = value; RaisePropertyChanged("dept_code"); }
        }

        private string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; RaisePropertyChanged("DeptName"); }

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
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }



        /// <summary>
        ///  all bellow depricated
        /// </summary>
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }

        }

        private DateTime _add_date;
        public DateTime add_date
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

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; RaisePropertyChanged("EmpId"); }
        }
        private string _PhNo;
        public string PhNo
        {
            get { return _PhNo; }
            set { _PhNo = value; RaisePropertyChanged("PhNo"); }
        }
        private string _PhExt;
        public string PhExt
        {
            get { return _PhExt; }
            set { _PhExt = value; RaisePropertyChanged("PhExt"); }
        }
        private string _FaxNo;
        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; RaisePropertyChanged("FaxNo"); }
        }
        private string _EmailId;
        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; RaisePropertyChanged("EmailId"); }
        }

        //scalar EmpNm
        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set { _EmpNm = value; RaisePropertyChanged("EmpNm"); }
        }
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    // Depricated
    public class MultipleContext_ADM_M025
    {
        public List<ADM_M025> MasterEntity { get; set; }
        public List<ADM_M025_Flip> BackFlipList { get; set; }
        public List<ADM_M024_P> DepartmentHead { get; set; }
    }

    // New MC Class
    public class MC_ADM_M0025 : MC_ADM_BE
    {
        public ObservableCollection<ADM_M025> MASTER_LIST { get; set; }
    }
}
