using System;


namespace Reflection.EF.Finance
{
    public partial class ACC_M003_V  //valuation class Entity
    {
        public int id { get; set; }
        public string value_class { get; set; }
        public string value_class_desc { get; set; }
        public string acc_cat { get; set; }
        public string client { get; set; }
    }
}
