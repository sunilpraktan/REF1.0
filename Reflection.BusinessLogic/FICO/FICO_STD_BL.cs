using Reflection.BusinessLogic.FICO;

namespace Reflection.BusinessLogic
{
    public class FICO_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "ACC_T006_BL")
                {
                    ACC_T006_BL GET_OBJ = new ACC_T006_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ACC_T001_BL")
                {
                    ACC_T001_BL GET_OBJ = new ACC_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SEL_T003_BL")
                {
                    SEL_T003_BL GET_OBJ = new SEL_T003_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SEL_T003_BL_DEV")
                {
                    SEL_T003_BL_DEV GET_OBJ = new SEL_T003_BL_DEV();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PUR_T005_BL")
                {
                    PUR_T005_BL GET_OBJ = new PUR_T005_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_R02")
                {
                    FICO_R02_BL GET_OBJ = new FICO_R02_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_R03")
                {
                    FICO_R03_BL GET_OBJ = new FICO_R03_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_M0032_BL")
                {
                    FICO_M0032_BL GET_OBJ = new FICO_M0032_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_M0033_BL")
                {
                    FICO_M0033_BL GET_OBJ = new FICO_M0033_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_M0004_BL")
                {
                    FICO_M0004_BL GET_OBJ = new FICO_M0004_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_M0004_A_BL")
                {
                    FICO_M0004_A_BL GET_OBJ = new FICO_M0004_A_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FICO_M0004_B_BL")
                {
                    FICO_M0004_B_BL GET_OBJ = new FICO_M0004_B_BL();
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
                if (RequestOption == "ACC_T006_BL")
                {
                    ACC_T006_BL INS_OBJ = new ACC_T006_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "ACC_T001_BL")
                {
                    ACC_T001_BL INS_OBJ = new ACC_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "SEL_T003_BL")
                {
                    SEL_T003_BL INS_OBJ = new SEL_T003_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "SEL_T003_BL_DEV")
                {
                    SEL_T003_BL_DEV INS_OBJ = new SEL_T003_BL_DEV();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PUR_T005_BL")
                {
                    PUR_T005_BL INS_OBJ = new PUR_T005_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "FICO_M0032_BL")
                {
                    FICO_M0032_BL INS_OBJ = new FICO_M0032_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "FICO_M0033_BL")
                {
                    FICO_M0033_BL INS_OBJ = new FICO_M0033_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "FICO_M0004_BL")
                {
                    FICO_M0004_BL INS_OBJ = new FICO_M0004_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "FICO_M0004_A_BL")
                {
                    FICO_M0004_A_BL INS_OBJ = new FICO_M0004_A_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "FICO_M0004_B_BL")
                {
                    FICO_M0004_B_BL INS_OBJ = new FICO_M0004_B_BL();
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
                if (RequestOption == "ACC_T006_BL")
                {
                    ACC_T006_BL UPD_OBJ = new ACC_T006_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "ACC_T001_BL")
                {
                    ACC_T001_BL UPD_OBJ = new ACC_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "SEL_T003_BL")
                {
                    SEL_T003_BL UPD_OBJ = new SEL_T003_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "SEL_T003_BL_DEV")
                {
                    SEL_T003_BL_DEV UPD_OBJ = new SEL_T003_BL_DEV();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "PUR_T005_BL")
                {
                    PUR_T005_BL UPD_OBJ = new PUR_T005_BL();
                    strValue = UPD_OBJ.Update(Request);
                }

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public string Delete(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "SEL_T003_BL")
                {
                    SEL_T003_BL DEL_OBJ = new SEL_T003_BL();
                    strValue = DEL_OBJ.Delete(Request);
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
