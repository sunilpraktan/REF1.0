namespace Reflection.BusinessEntity.Finance
{
    class ACC_M004_C : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    RaisePropertyChanged("id");
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
                    RaisePropertyChanged("PartyId");
                }
            }
        }
    }
}
