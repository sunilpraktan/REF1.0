using Reflection.BusinessLogic.PMM;
using Reflection.BusinessLogic.PMS;

namespace Reflection.BusinessLogic
{
    public class PMM_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "PMM_M0001_BL")
                {
                    PMM_M0001_BL GET_OBJ = new PMM_M0001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMM_M0002_BL")
                {
                    PMM_M0002_BL GET_OBJ = new PMM_M0002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMM_M0003_BL")
                {
                    PMM_M0003_BL GET_OBJ = new PMM_M0003_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMM_M0005_BL")
                {
                    PMM_M0005_BL GET_OBJ = new PMM_M0005_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMM_T001_BL")
                {
                    PMM_T001_BL GET_OBJ = new PMM_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMM_T005_BL")
                {
                    PMM_T005_BL GET_OBJ = new PMM_T005_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PMM_R02_BL")
                {
                    PMM_R02_BL GET_OBJ = new PMM_R02_BL();
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
                if (RequestOption == "PMM_M0001_BL")
                {
                    PMM_M0001_BL INS_OBJ = new PMM_M0001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMM_M0003_BL")
                {
                    PMM_M0003_BL INS_OBJ = new PMM_M0003_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMM_M0005_BL")
                {
                    PMM_M0005_BL INS_OBJ = new PMM_M0005_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMM_T001_BL")
                {
                    PMM_T001_BL INS_OBJ = new PMM_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PMM_T005_BL")
                {
                    PMM_T005_BL INS_OBJ = new PMM_T005_BL();
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
                if (RequestOption == "PMM_M0001_BL")
                {
                    PMM_M0001_BL UPD_OBJ = new PMM_M0001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMM_M0003_BL")
                {
                    PMM_M0003_BL UPD_OBJ = new PMM_M0003_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMM_M0005_BL")
                {
                    PMM_M0005_BL UPD_OBJ = new PMM_M0005_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMM_T001_BL")
                {
                    PMM_T001_BL UPD_OBJ = new PMM_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PMM_T005_BL")
                {
                    PMM_T005_BL UPD_OBJ = new PMM_T005_BL();
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
