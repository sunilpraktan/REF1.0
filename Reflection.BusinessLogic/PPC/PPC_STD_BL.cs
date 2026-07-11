using Reflection.BusinessLogic.PMS;

namespace Reflection.BusinessLogic.PPC
{
    public class PPC_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "PPC_R01_BL")
                {
                    PPC_R01_BL GET_OBJ = new PPC_R01_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PPC_R02_BL")
                {
                    PPC_R02_BL GET_OBJ = new PPC_R02_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PPC_M0002_BL")
                {
                    PPC_M0002_BL GET_OBJ = new PPC_M0002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "EPR_T001_BL")
                {
                    PPC.EPR_T001_BL GET_OBJ = new PPC.EPR_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "EPR_T002_BL")
                {
                    EPR_T002_BL GET_OBJ = new EPR_T002_BL();
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
                if (RequestOption == "EPR_T002_BL")
                {
                    EPR_T002_BL INS_OBJ = new EPR_T002_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "EPR_T001_BL")
                {
                    EPR_T001_BL INS_OBJ = new EPR_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "PPC_M0002_BL")
                {
                    PPC_M0002_BL INS_OBJ = new PPC_M0002_BL();
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
                if (RequestOption == "EPR_T002_BL")
                {
                    EPR_T002_BL UPD_OBJ = new EPR_T002_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "EPR_T001_BL")
                {
                    EPR_T001_BL UPD_OBJ = new EPR_T001_BL();
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
