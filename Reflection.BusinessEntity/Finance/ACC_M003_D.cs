using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_D:ObjectBase  //COA Assign to the Company	
    {
        private string _coa_key;  
        public string coa_key
        {
            get { return _coa_key; }
            set
            {
                if (_coa_key != value)
                {
                    _coa_key = value;
                    RaisePropertyChanged("coa_key");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
       

        public bool Click { get; set; }
    }
               
    public class MultipleContext_ACC_M003_D
    {
        public ObservableCollection<ACC_M003_D> CoaASToComplist { get; set; }
        public List<ACC_M026_P> Coalist { get; set; }
        public List<ADM_M001_A_P> comp_codelist { get; set; }
    }
}
