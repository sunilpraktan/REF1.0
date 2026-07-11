using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class DocumentViewerPayload
    {
        public string DocumentNumber { get; set; }
        public string Row_ID { get; set; }
        public List<COM_T003> DocumentList { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
    }
}
