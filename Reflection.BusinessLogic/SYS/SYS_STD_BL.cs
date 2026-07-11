using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class SYS_STD_BL
    {
        string ReturnValue = "";
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            try
            {
                if (RequestOption == "ADM_S0001_BL")
                {
                    ADM_S0001_BL BL_OBJ = new ADM_S0001_BL();
                    ReturnValue = BL_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_S0002")
                {
                    ADM_S0002_BL BL_OBJ = new ADM_S0002_BL();
                    ReturnValue = BL_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SYS_C0101_BL")
                {
                    SYS_C0101_BL BL_OBJ = new SYS_C0101_BL();
                    ReturnValue = BL_OBJ.GetData(Request, strType, intValue, strValue);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return ReturnValue;
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                if (RequestOption == "ADM_S0001_BL")
                {
                    ADM_S0001_BL BL_OBJ = new ADM_S0001_BL();
                    ReturnValue = BL_OBJ.Insert(Request);
                }
                else if (RequestOption == "ADM_S0002")
                {
                    ADM_S0002_BL BL_OBJ = new ADM_S0002_BL();
                    ReturnValue = BL_OBJ.Insert(Request);
                }
                else if (RequestOption == "SYS_C0101_BL")
                {
                    SYS_C0101_BL BL_OBJ = new SYS_C0101_BL();
                    ReturnValue = BL_OBJ.Insert(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return ReturnValue;
        }
        public string Update(string Request, string RequestOption)
        {
            try
            {
                if (RequestOption == "ADM_S0001_BL")
                {
                    ADM_S0001_BL BL_OBJ = new ADM_S0001_BL();
                    ReturnValue = BL_OBJ.Update(Request);
                }
                else if (RequestOption == "ADM_S0002")
                {
                    ADM_S0002_BL BL_OBJ = new ADM_S0002_BL();
                    ReturnValue = BL_OBJ.Update(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return ReturnValue;
        }
    }
}
