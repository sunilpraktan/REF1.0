
using System;
using System.ComponentModel;
namespace Reflection.BusinessEntity.Admin
{
    public class ZADM_M003_PopUp : ObjectBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private int _wire_size_id { get; set; }
        [DisplayName("Id")]
        public int wire_size_id { get { return _wire_size_id; } set { _wire_size_id = value; NotifyPropertyChanged("wire_size_id"); } }


        public string _wire_size { get; set; }
        [DisplayName("WireSize")]

        public string wire_size { get { return _wire_size; } set { _wire_size = value; NotifyPropertyChanged("wire_size"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
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
