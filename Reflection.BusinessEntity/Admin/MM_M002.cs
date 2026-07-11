using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class MM_M002 : ObjectBase
    {
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set
            {
                _wa_code = value;
                RaisePropertyChanged("wa_code");
            }
        }
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
       
        private string _wa_name;      
        public string wa_name
        {
            get { return _wa_name; }
            set
            {
                _wa_name = value;
                RaisePropertyChanged("wa_name");
            }
        }
        private string _wa_desc;
        public string wa_desc
        {
            get { return _wa_desc; }
            set
            {
                _wa_desc = value;
                RaisePropertyChanged("wa_desc");
            }
        }
       
        private string _region;
        public string region
        {
            get { return _region; }
            set
            {
                _region = value;
                RaisePropertyChanged("region");
            }
        }       
        
    }
    public class MultipleContext_MM_M002
    {
        public List<MM_M002> Warehouse { get; set; }//Warehouse Master            
    }
   
}
