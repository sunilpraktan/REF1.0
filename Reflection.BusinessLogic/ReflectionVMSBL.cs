using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class ReflectionVMSBL
    {
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "AppointmentByHost")
                {
                    VMS_T001_BL _VMS_T001_BL = new VMS_T001_BL();
                    strValue = _VMS_T001_BL.Insert(Request);
                }
                
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public string Update(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "AppointmentByHost")
                {
                    VMS_T001_BL _VMS_T001_BL = new VMS_T001_BL();
                    strValue = _VMS_T001_BL.Update(Request);
                }
                
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }        
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strval = "";
            try
            {
                if (RequestOption == "AppointmentByHost")
                {
                    VMS_T001_BL _VMS_T001_BL = new VMS_T001_BL();
                    strval = _VMS_T001_BL.GetData(Request, strType, intValue, strValue);
                }
                
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strval;
        }
                
    }
}
