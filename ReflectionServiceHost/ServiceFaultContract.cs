using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ReflectionServiceHost
{
    [DataContract]
    public class ServiceFaultContract
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public int ErrorID { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string ErrorDetails { get; set; }

        [DataMember]
        public Guid correlationId { get; set; }
        
        [DataMember]
        public Guid CorrelationId
        {
            get { return correlationId; }
            set { correlationId = value; }
        }
    }
}