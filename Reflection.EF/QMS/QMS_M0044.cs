using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
   public class QMS_M0044 : ObjectBase
    {
        public string cont_code { get; set; }
        public string spec_code { get; set; }
        public string short_text { get; set; }
        public double qty { get; set; }
        public string unit_code { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }
    }
}
