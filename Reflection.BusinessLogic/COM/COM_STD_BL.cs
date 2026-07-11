using Reflection.BusinessLogic.COM;
using Reflection.BusinessLogic.PMM;
using Reflection.BusinessLogic.PMS;

namespace Reflection.BusinessLogic
{
    public class COM_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "COM_M0002_BL")
                {
                    COM_M0002_BL GET_OBJ = new COM_M0002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "COM_T001_BL")
                {
                    COM_T001_BL GET_OBJ = new COM_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "COM_R05_BL")
                {
                    COM_R05_BL GET_OBJ = new COM_R05_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }


            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;
        }
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "COM_M0002_BL")
                {
                    COM_M0002_BL INS_OBJ = new COM_M0002_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "COM_T001_BL")
                {
                    COM_T001_BL INS_OBJ = new COM_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
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
                if (RequestOption == "COM_M0002_BL")
                {
                    COM_M0002_BL UPD_OBJ = new COM_M0002_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "COM_T001_BL")
                {
                    COM_T001_BL UPD_OBJ = new COM_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }


            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
    }
}
