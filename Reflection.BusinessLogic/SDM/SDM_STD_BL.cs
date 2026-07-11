using Reflection.BusinessLogic.SDM;

namespace Reflection.BusinessLogic
{
    public class SDM_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "SDM_R02")
                {
                    SDM_R02_BL GET_OBJ = new SDM_R02_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SEL_T001_BL")
                {
                    SEL_T001_BL GET_OBJ = new SEL_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                
                else if (RequestOption == "SEL_T002_BL")
                {
                    SEL_T002_BL GET_OBJ = new SEL_T002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SEL_T004_BL")
                {
                    SEL_T004_BL GET_OBJ = new SEL_T004_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "LOG_T001_BL")
                {
                    LOG_T001_BL GET_OBJ = new LOG_T001_BL();
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
                if (RequestOption == "SEL_T001_BL")
                {
                    SEL_T001_BL INS_OBJ = new SEL_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                
                else if (RequestOption == "SEL_T002_BL")
                {
                    SEL_T002_BL INS_OBJ = new SEL_T002_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "SEL_T004_BL")
                {
                    SEL_T004_BL INS_OBJ = new SEL_T004_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "LOG_T001_BL")
                {
                    LOG_T001_BL INS_OBJ = new LOG_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "LOG_T001_BL_POST")
                {
                    LOG_T001_BL INS_OBJ = new LOG_T001_BL();
                    strValue = INS_OBJ.Insert_Post(Request);
                }
                else if (RequestOption == "SEL_T001_IMPORT")
                {
                    SEL_T001_BL INS_OBJ = new SEL_T001_BL();
                    strValue = INS_OBJ.InsertImportedLead(Request);
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
                if (RequestOption == "SEL_T001_BL")
                {
                    SEL_T001_BL UPD_OBJ = new SEL_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                
                else if (RequestOption == "SEL_T002_BL")
                {
                    SEL_T002_BL UPD_OBJ = new SEL_T002_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "SEL_T004_BL")
                {
                    SEL_T004_BL UPD_OBJ = new SEL_T004_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "LOG_T001_BL")
                {
                    LOG_T001_BL UPD_OBJ = new LOG_T001_BL();
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
