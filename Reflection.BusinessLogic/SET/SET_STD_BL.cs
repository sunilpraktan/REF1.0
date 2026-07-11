using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic.SET
{
    public class SET_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "SET_R02")
                {
                    ADM_S0002_BL SDM_R02_OBJ = new ADM_S0002_BL();
                    strReturnValue = SDM_R02_OBJ.GetData(Request, strType, intValue, strValue);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;
        }
    }
}
