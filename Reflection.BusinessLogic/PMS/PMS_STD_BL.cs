using Reflection.BusinessLogic.PMS;

namespace Reflection.BusinessLogic
{
    public class PMS_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "PMS_T001_BL")
                {
                    PMS_T001_BL GET_OBJ = new PMS_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMS_T002_BL")
                {
                    PMS_T002_BL GET_OBJ = new PMS_T002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMS_T004_BL")
                {
                    PMS_T004_BL GET_OBJ = new PMS_T004_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMS_T008_BL")
                {
                    PMS_T008_BL GET_OBJ = new PMS_T008_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMS_T009_BL")
                {
                    PMS_T009_BL GET_OBJ = new PMS_T009_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMS_R02_BL")
                {
                    PMS_R02_BL GET_OBJ = new PMS_R02_BL();
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
                if (RequestOption == "PMS_T001_BL")
                {
                    PMS_T001_BL INS_OBJ = new PMS_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMS_T002_BL")
                {
                    PMS_T002_BL INS_OBJ = new PMS_T002_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMS_T004_BL")
                {
                    PMS_T004_BL INS_OBJ = new PMS_T004_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMS_T008_BL")
                {
                    PMS_T008_BL INS_OBJ = new PMS_T008_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMS_T009_BL")
                {
                    PMS_T009_BL INS_OBJ = new PMS_T009_BL();
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
                if (RequestOption == "PMS_T001_BL")
                {
                    PMS_T001_BL UPD_OBJ = new PMS_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMS_T002_BL")
                {
                    PMS_T002_BL UPD_OBJ = new PMS_T002_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMS_T004_BL")
                {
                    PMS_T004_BL UPD_OBJ = new PMS_T004_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMS_T008_BL")
                {
                    PMS_T008_BL UPD_OBJ = new PMS_T008_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMS_T009_BL")
                {
                    PMS_T009_BL UPD_OBJ = new PMS_T009_BL();
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
