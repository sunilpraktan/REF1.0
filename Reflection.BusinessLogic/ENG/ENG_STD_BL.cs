using Reflection.BusinessLogic.PMM;
using Reflection.BusinessLogic.PMS;

namespace Reflection.BusinessLogic
{
    public class ENG_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "ENG_T001_BL")
                {
                    ENG_T001_BL GET_OBJ = new ENG_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ENG_T005_BL")
                {
                    ENG_T005_BL GET_OBJ = new ENG_T005_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ENG_M0005_BL")
                {
                    ENG_M0005_BL GET_OBJ = new ENG_M0005_BL();
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
                if (RequestOption == "ENG_T001_BL")
                {
                    ENG_T001_BL INS_OBJ = new ENG_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "ENG_T005_BL")
                {
                    ENG_T005_BL INS_OBJ = new ENG_T005_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "ENG_M0005_BL")
                {
                    ENG_M0005_BL INS_OBJ = new ENG_M0005_BL();
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
                if (RequestOption == "ENG_T001_BL")
                {
                    ENG_T001_BL UPD_OBJ = new ENG_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "ENG_T005_BL")
                {
                    ENG_T005_BL UPD_OBJ = new ENG_T005_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "ENG_M0005_BL")
                {
                    ENG_M0005_BL UPD_OBJ = new ENG_M0005_BL();
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
