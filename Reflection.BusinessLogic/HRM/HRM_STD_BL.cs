namespace Reflection.BusinessLogic.HRM
{
    public class HRM_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "HRM_M0002_BL")
                {
                    HRM_M0002_BL GET_OBJ = new HRM_M0002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "HRM_M0024_BL")
                {
                    HRM_M0024_BL _HRM_T001_BL = new HRM_M0024_BL();
                    strReturnValue = _HRM_T001_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "HRM_M0026_BL")
                {
                    HRM_M0026_BL _HRM_T001_BL = new HRM_M0026_BL();
                    strReturnValue = _HRM_T001_BL.GetData(Request, strType, intValue, strValue);
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
                if (RequestOption == "HRM_M0002_BL")
                {
                    HRM_M0002_BL INS_OBJ = new HRM_M0002_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "HRM_M0024_BL")
                {
                    HRM_M0024_BL _HRM_T001_BL = new HRM_M0024_BL();
                    strValue = _HRM_T001_BL.Insert(Request, RequestOption);
                }
                else if (RequestOption == "HRM_M0026_BL")
                {
                    HRM_M0026_BL _HRM_T001_BL = new HRM_M0026_BL();
                    strValue = _HRM_T001_BL.Insert(Request, RequestOption);
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
                if (RequestOption == "HRM_M0002_BL")
                {
                    //HRM_M0002_BL UPD_OBJ = new HRM_M0002_BL();
                    //strValue = UPD_OBJ.Update(Request, RequestOption);
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
