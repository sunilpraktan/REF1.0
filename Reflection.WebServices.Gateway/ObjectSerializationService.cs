using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Salar.Bois;
using System.Linq;

namespace Reflection.WebServices.Gateway
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

        //================================================= SALARBOIS......................................
        #endregion

        #region Snipet
        //public static byte[] ObjectToStreamNS(Object oObject)
        //{
        //    using (var mem = new MemoryStream())
        //    {
        //        var ser = new NetSerializer.Serializer(new[] { typeof(Object) });
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



    public class ObjectSerializationService
    {
        public string ObjectToXML(Object oObject)
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
         
        public Object XMLToObjectRev(string XMLString, Object oObject)
        {
            try
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "SalesOrder";
                xRoot.IsNullable = true;
                XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType(), xRoot);
                //XmlReader xRdr = XmlReader.Create(new StringReader(XMLString));
                //The StringReader will be the stream holder for the existing XML file
                oObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
                //initially deserialized, the data is represented by an object without a defined type
                
            }
            catch (Exception ex)
            {

            }
            return oObject;
        }

      
        public static T DeserializeXmlString<T>(string XmlString)
        {
            T tempObject = default(T);

            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(XmlString));

            XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                tempObject = (T)xs.Deserialize(memoryStream);
            

            return tempObject;
        }

 

        public Object XMLToObject(string XMLString, Object oObject)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
                //The StringReader will be the stream holder for the existing XML file

                oObject = oXmlSerializer.Deserialize(new StringReader(XMLString));

                //initially deserialized, the data is represented by an object without a defined type
                
            }
            catch (Exception ex)
            {
                
            }
            return oObject;
        }


        public Object XMLToObjectRead(string XMLString, Object oObject)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
                XmlDocument doc = new XmlDocument();
                XmlNode node = doc.SelectSingleNode(@"C:\Users\praktan1\Desktop\L&T06 11 09 Old file.XML");
                XmlNodeList nodelist = doc.SelectNodes(@"C:\Users\praktan1\Desktop\L&T06 11 09 Old file.XML");

                string var = doc.Attributes.GetNamedItem("MDCUSTOMER").Value.ToString();
                //using (StreamReader _reader = new StreamReader(XMLString))
                //{



                //       string var = _reader.ReadToEnd();


                //       var.Replace("<ENVELOPE>", "<ENVELOPE xmlns:xsi=" + " http://www.w3.org/2001/XMLSchema-instance" + " xmlns:xsd=" + "http://www.w3.org/2001/XMLSchema" + ">");
                       oObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
                      // using (StreamReader _reader1 = new StreamReader(var))
                      // {
                      //     var = _reader1.ReadToEnd();
                               
                           
                    //}

                 
              
            }
            catch (Exception ex)
            {

            }
            return oObject;
        }


      
        public Object XMLToObjectOrg(string XMLString, Object oObject)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
                //The StringReader will be the stream holder for the existing XML file
                oObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
                //initially deserialized, the data is represented by an object without a defined type

            }
            catch (Exception ex)
            {

            }
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
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
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
