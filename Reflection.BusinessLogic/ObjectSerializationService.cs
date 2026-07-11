using Salar.Bois;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Reflection.BusinessLogic
{

    public static class ObjectSerializationService<TDomainObject>
    {
        #region SALAR.BOIS
        //================================================= SALARBOIS......................................
        public static byte[] ObjectToStream(Object oObject)
        {
            var boisSerializer = new BoisSerializer();
            using (var mem = new MemoryStream())
            {
                boisSerializer.Serialize(oObject, mem);
                mem.Seek(0, SeekOrigin.Begin);
                long lenS = mem.Length / 1024;
                return mem.ToArray();
            }
        }
        public static byte[] ObjectToStreamGeneric(TDomainObject oObject)
        {
            var boisSerializer = new BoisSerializer();
            using (var mem = new MemoryStream())
            {
                boisSerializer.Serialize<TDomainObject>(oObject, mem);
                mem.Seek(0, SeekOrigin.Begin);
                return mem.ToArray();
            }
        }

        public static TDomainObject StreamToObject<T>(TDomainObject domainObj, byte[] RequestStream)
        {
            var boisSerializer = new BoisSerializer();
            domainObj = boisSerializer.Deserialize<TDomainObject>(RequestStream.ToArray(), 0, RequestStream.ToArray().Length);
            return domainObj;
        }

        public static TDomainObject StreamToObject<T>(TDomainObject domainObj, Stream RequestStream)
        {
            var boisSerializer = new BoisSerializer();
            domainObj = boisSerializer.Deserialize<TDomainObject>(RequestStream);
            return domainObj;
        }

        //================================================= SALARBOIS......................................
        #endregion

        #region Snipet
        //public static byte[] ObjectToStreamNS(TDomainObject oObject)
        //{
            
        //    using (var mem = new MemoryStream())
        //    {
        //        var ser = new NetSerializer.Serializer(new[] { typeof(TDomainObject) });
        //        ser.Serialize(mem, oObject);
        //        return mem.ToArray();
        //    }
        //}
        //public static TDomainObject StreamToObjectNS<T>(TDomainObject domainObj, byte[] RequestStream)
        //{
        //    var ser = new NetSerializer.Serializer(new[] { typeof(TDomainObject) });
        //    MemoryStream ms = new MemoryStream(RequestStream);
        //    domainObj = (TDomainObject)ser.Deserialize(ms);
        //    return domainObj;
        //}
        //Working code for NetSerializer
        //using (var mem = new MemoryStream())
        //{
        //    var ser = new NetSerializer.Serializer(new[] { typeof(MContext_Authontication) });
        //    ser.Serialize(mem, MCL);
        //    return mem.ToArray();
        //}

        // Working code for Protocol Buffer
        //using (var mem = new MemoryStream())
        //{
        //    ProtoBuf.Serializer.Serialize<MContext_Authontication>(mem, MCL);
        //    ProtoBuf.Serializer.NonGeneric.Serialize(mem, MCL);
        //    ProtoBuf.Serializer.Serialize(mem, MCL);
        //    return mem.ToArray();
        //}

        #endregion

    }


    public static class ObjectSerializationService
    {
        
        // why is this Hashtable? due to the threading semantics!
        private static readonly Hashtable serializerCache = new Hashtable();

        public static string ToXMLString(object obj, string nodeName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            Type type = obj.GetType();
            var cacheKey = new { Type = type, Name = nodeName };
            XmlSerializer xmlSerializer = (XmlSerializer)serializerCache[cacheKey];
            if (xmlSerializer == null)
            {
                lock (serializerCache)
                { // double-checked
                    xmlSerializer = (XmlSerializer)serializerCache[cacheKey];
                    if (xmlSerializer == null)
                    {
                        xmlSerializer = new XmlSerializer(type, new XmlRootAttribute(nodeName));
                        serializerCache.Add(cacheKey, xmlSerializer);
                    }
                }
            }
            try
            {

                StringWriter sw = new StringWriter();
                using (XmlWriter writer = XmlWriter.Create(sw,
                    new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true }))
                {
                    // Don't include XML namespace
                    XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
                    xmlnsEmpty.Add("", "");
                    xmlSerializer.Serialize(writer, obj, xmlnsEmpty);
                    writer.Close();
                }
                return sw.ToString();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
        public static string ObjectToXML(Object oObject)
        {
            // Represents an XML document, Initializes a new instance of the XmlDocument class.
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(oObject.GetType());
            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("","");
            // Creates a stream whose backing store is memory. Initializes a new instance of the MemoryStream class with an expandable capacity initialized to zero.
            using (MemoryStream xmlStream = new MemoryStream())
            {
                /* 
                XmlSerializer.Serialize Method (XmlWriter, Object)
                Serializes the specified Object and writes the XML document to a file using the specified xmlwriter 
            
                Parameters
                xmlWriter-
            
                Type: System.Xml.XmlWriter
 
                The XmlWriter used to write the XML document. 
                Type: System.Object
                The Object to serialize. 
             
                 */
                xmlSerializer.Serialize(xmlStream, oObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public static Object XMLToObject(string XMLString, Object oObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
            //The StringReader will be the stream holder for the existing XML file
            oObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
            //initially deserialized, the data is represented by an object without a defined type
            return oObject;
        }

        public static string ObjectToXMLOrg(Object oObject)
        {
            // Represents an XML document, Initializes a new instance of the XmlDocument class.
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(oObject.GetType());
            // Creates a stream whose backing store is memory. Initializes a new instance of the MemoryStream class with an expandable capacity initialized to zero.
            using (MemoryStream xmlStream = new MemoryStream())
            {
                /* 
                XmlSerializer.Serialize Method (XmlWriter, Object)
                Serializes the specified Object and writes the XML document to a file using the specified xmlwriter 
            
                Parameters
                xmlWriter-
            
                Type: System.Xml.XmlWriter
 
                The XmlWriter used to write the XML document. 
                Type: System.Object
                The Object to serialize. 
             
                 */
                xmlSerializer.Serialize(xmlStream, oObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public static Object XMLToObjectOrg(string XMLString, Object oObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
            //The StringReader will be the stream holder for the existing XML file
            oObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
            //initially deserialized, the data is represented by an object without a defined type
            return oObject;
        }

        /// <summary>
        /// Serializes an object to Xml as a string.
        /// </summary>
        /// <typeparam name="T">Datatype T.</typeparam>
        /// <param name="ToSerialize">Object of type T to be serialized.</param>
        /// <returns>Xml string of serialized type T object.</returns>
        public static string SerializeToXmlString<T>(T ToSerialize)
        {
            string xmlstream = String.Empty;

            using (MemoryStream memstream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute("SEL_T001"));
                XmlTextWriter xmlWriter = new XmlTextWriter(memstream, Encoding.UTF8);

                xmlSerializer.Serialize(xmlWriter, ToSerialize);
                xmlstream = UTF8ByteArrayToString(((MemoryStream)xmlWriter.BaseStream).ToArray());
            }

            return xmlstream;
        }

        /// <summary>
        /// Deserializes Xml string of type T.
        /// </summary>
        /// <typeparam name="T">Datatype T.</typeparam>
        /// <param name="XmlString">Input Xml string from which to read.</param>
        /// <returns>Returns rehydrated object of type T.</returns>
        public static T DeserializeXmlStringOrg<T>(string XmlString)
        {
            T tempObject = default(T);

            using (MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(XmlString)))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                tempObject = (T)xs.Deserialize(memoryStream);
            }

            return tempObject;
        }

        // Convert Array to String
        public static String UTF8ByteArrayToString(Byte[] ArrBytes)
        { return new UTF8Encoding().GetString(ArrBytes); }
        // Convert String to Array
        public static Byte[] StringToUTF8ByteArray(String XmlString)
        { return new UTF8Encoding().GetBytes(XmlString); }
    }
}
