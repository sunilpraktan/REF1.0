namespace Reflection.BusinessLogic.PRO
{
    public class PRO_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "PRO_T001_BL")
                {
                    PRO_T001_BL GET_OBJ = new PRO_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PRO_T002_BL")
                {
                    PRO_T002_BL GET_OBJ = new PRO_T002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PRO_R01_BL")
                {
                    PRO_R01_BL GET_OBJ = new PRO_R01_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PRO_R02_BL")
                {
                    PRO_R02_BL GET_OBJ = new PRO_R02_BL();
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
                if (RequestOption == "PRO_T001_BL")
                {
                    PRO_T001_BL INS_OBJ = new PRO_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PRO_T002_BL")
                {
                    PRO_T002_BL INS_OBJ = new PRO_T002_BL();
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
                if (RequestOption == "PRO_T001_BL")
                {
                    PRO_T001_BL UPD_OBJ = new PRO_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PRO_T002_BL")
                {
                    PRO_T002_BL UPD_OBJ = new PRO_T002_BL();
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
