using Reflection.BusinessLogic.QMS;

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "ADM_M0028_BL")
                {
                    ADM_M0028_BL GET_OBJ = new ADM_M0028_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_R02_BL")
                {
                    ADM_R02_BL GET_OBJ = new ADM_R02_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_T001_BL")
                {
                    ADM_T001_BL GET_OBJ = new ADM_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0001_BL")
                {
                    ADM_M0001_BL GET_OBJ = new ADM_M0001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0002_BL")
                {
                    ADM_M0002_BL GET_OBJ = new ADM_M0002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0003_BL")
                {
                    ADM_M0003_BL GET_OBJ = new ADM_M0003_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0061_BL")
                {
                    ADM_M0061_BL GET_OBJ = new ADM_M0061_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0111_BL")
                {
                    ADM_M0111_BL GET_OBJ = new ADM_M0111_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0121_BL")
                {
                    ADM_M0121_BL GET_OBJ = new ADM_M0121_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0123_BL")
                {
                    ADM_M0123_BL GET_OBJ = new ADM_M0123_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0051_BL")
                {
                    ADM_M0051_BL GET_OBJ = new ADM_M0051_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0018_BL")
                {
                    ADM_M0018_BL GET_OBJ = new ADM_M0018_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0110_BL")
                {
                    ADM_M0110_BL GET_OBJ = new ADM_M0110_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0025_BL")
                {
                    ADM_M0025_BL GET_OBJ = new ADM_M0025_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M019_BL")
                {
                    ADM_M019_BL GET_OBJ = new ADM_M019_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ADM_M0126_BL")
                {
                    ADM_M0126_BL GET_OBJ = new ADM_M0126_BL();
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
                if (RequestOption == "ADM_M0028_BL")
                {
                    ADM_M0028_BL INS_OBJ = new ADM_M0028_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_T001_BL")
                {
                    ADM_T001_BL INS_OBJ = new ADM_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "ADM_M0001_BL")
                {
                    ADM_M0001_BL INS_OBJ = new ADM_M0001_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0002_BL")
                {
                    ADM_M0002_BL INS_OBJ = new ADM_M0002_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0003_BL")
                {
                    ADM_M0003_BL INS_OBJ = new ADM_M0003_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0061_BL")
                {
                    ADM_M0061_BL INS_OBJ = new ADM_M0061_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0111_BL")
                {
                    ADM_M0111_BL INS_OBJ = new ADM_M0111_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0121_BL")
                {
                    ADM_M0121_BL INS_OBJ = new ADM_M0121_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0123_BL")
                {
                    ADM_M0123_BL INS_OBJ = new ADM_M0123_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0051_BL")
                {
                    ADM_M0051_BL INS_OBJ = new ADM_M0051_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0018_BL")
                {
                    ADM_M0018_BL INS_OBJ = new ADM_M0018_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0110_BL")
                {
                    ADM_M0110_BL INS_OBJ = new ADM_M0110_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M025_BL")
                {
                    ADM_M0025_BL INS_OBJ = new ADM_M0025_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M019_BL")
                {
                    ADM_M019_BL INS_OBJ = new ADM_M019_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0126_BL")
                {
                    ADM_M0126_BL INS_OBJ = new ADM_M0126_BL();
                    strValue = INS_OBJ.Insert(Request, RequestOption);
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
                if (RequestOption == "ADM_M0028_BL")
                {
                    ADM_M0028_BL UPD_OBJ = new ADM_M0028_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_T001_BL")
                {
                    ADM_T001_BL UPD_OBJ = new ADM_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "ADM_M0001_BL")
                {
                    ADM_M0001_BL UPD_OBJ = new ADM_M0001_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0002_BL")
                {
                    ADM_M0002_BL UPD_OBJ = new ADM_M0002_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0003_BL")
                {
                    ADM_M0003_BL UPD_OBJ = new ADM_M0003_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0061_BL")
                {
                    ADM_M0061_BL UPD_OBJ = new ADM_M0061_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0111_BL")
                {
                    ADM_M0111_BL UPD_OBJ = new ADM_M0111_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0121_BL")
                {
                    ADM_M0121_BL UPD_OBJ = new ADM_M0121_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0123_BL")
                {
                    ADM_M0123_BL UPD_OBJ = new ADM_M0123_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (RequestOption == "ADM_M0051_BL")
                {
                    ADM_M0051_BL UPD_OBJ = new ADM_M0051_BL();
                    strValue = UPD_OBJ.Update(Request, RequestOption);
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
