
using System;
using System.ComponentModel;
namespace Reflection.BusinessEntity.Admin
{
    public class ZADM_M004_PopUp : ObjectBase, INotifyPropertyChanged, IDataErrorInfo
    {
        public int _wire_type_id { get; set; }
        [DisplayName("Id")]
        public int wire_type_id { get { return _wire_type_id; } set { _wire_type_id = value; NotifyPropertyChanged("wire_type_id"); } }

       
        public string _wire_type { get; set; }
         [DisplayName("WireType")]

        public string wire_type { get { return _wire_type; } set { _wire_type = value; NotifyPropertyChanged("wire_type"); } }
         public event PropertyChangedEventHandler PropertyChanged;
         private void NotifyPropertyChanged(string p)
         {
             if(PropertyChanged!=null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(p));

             }
         }
         string IDataErrorInfo.Error
         {
             get { throw new NotImplementedException(); }
         }

         string IDataErrorInfo.this[string columnName]
         {
             get { throw new NotImplementedException(); }
         }


        
    }
}
