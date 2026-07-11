using Reflection.BusinessLogic.MM;

namespace Reflection.BusinessLogic
{
    public class MM_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "MM_T001_BL")
                {
                    MM_T001_BL GET_OBJ = new MM_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "MM_T001_BL_NEW")
                {
                    MM_T001_BL_NEW GET_OBJ = new MM_T001_BL_NEW();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T001_BL_GR")
                {
                    MM_T001_BL_GR GET_OBJ = new MM_T001_BL_GR();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T001_BL_GM")
                {
                    MM_T001_BL_GM GET_OBJ = new MM_T001_BL_GM();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T003_BL")
                {
                    MM_T003_BL GET_OBJ = new MM_T003_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T005_BL")
                {
                    MM_T005_BL GET_OBJ = new MM_T005_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T007_BL")
                {
                    MM_T007_BL GET_OBJ = new MM_T007_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_R02")
                {
                    MM_R02_BL GET_OBJ = new MM_R02_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_R03")
                {
                    MM_R03_BL GET_OBJ = new MM_R03_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_R04")
                {
                    MM_R04_BL GET_OBJ = new MM_R04_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_R05")
                {
                    MM_R05_BL GET_OBJ = new MM_R05_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_M0031_BL")
                {
                    MM_M0031_BL GET_OBJ = new MM_M0031_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_M0032_BL")
                {
                    MM_M0032_BL GET_OBJ = new MM_M0032_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_M0011_BL")
                {
                    MM_M0011_BL GET_OBJ = new MM_M0011_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T011_BL")
                {
                    MM_T011_BL GET_OBJ = new MM_T011_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_S010_BL")
                {
                    MM_S010_BL GET_OBJ = new MM_S010_BL();
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
                if (RequestOption == "MM_T001_BL")
                {
                    MM_T001_BL INS_OBJ = new MM_T001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                if (RequestOption == "MM_T001_BL_NEW")
                {
                    MM_T001_BL_NEW INS_OBJ = new MM_T001_BL_NEW();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_T001_BL_GR")
                {
                    MM_T001_BL_GR INS_OBJ = new MM_T001_BL_GR();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_T001_BL_GM")
                {
                    MM_T001_BL_GM INS_OBJ = new MM_T001_BL_GM();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_T003_BL")
                {
                    MM_T003_BL INS_OBJ = new MM_T003_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_T005_BL")
                {
                    MM_T005_BL INS_OBJ = new MM_T005_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_T007_BL")
                {
                    MM_T007_BL INS_OBJ = new MM_T007_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                //else if (RequestOption == "PRO_T002_BL")
                //{
                //    PRO_T002_BL INS_OBJ = new PRO_T002_BL();
                //    strValue = INS_OBJ.Insert(Request);
                //}
                else if (RequestOption == "MM_M0031_BL")
                {
                    MM_M0031_BL INS_OBJ = new MM_M0031_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_M0032_BL")
                {
                    MM_M0032_BL INS_OBJ = new MM_M0032_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_M0011_BL")
                {
                    MM_M0011_BL INS_OBJ = new MM_M0011_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_T011_BL")
                {
                    MM_T011_BL INS_OBJ = new MM_T011_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "MM_S010_BL")
                {
                    MM_S010_BL INS_OBJ = new MM_S010_BL();
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
                if (RequestOption == "MM_T001_BL")
                {
                    MM_T001_BL UPD_OBJ = new MM_T001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                if (RequestOption == "MM_T001_BL_NEW")
                {
                    MM_T001_BL_NEW UPD_OBJ = new MM_T001_BL_NEW();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_T001_BL_GR")
                {
                    MM_T001_BL_GR UPD_OBJ = new MM_T001_BL_GR();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_T001_BL_GM")
                {
                    MM_T001_BL_GM UPD_OBJ = new MM_T001_BL_GM();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_T003_BL")
                {
                    MM_T003_BL UPD_OBJ = new MM_T003_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_T005_BL")
                {
                    MM_T005_BL UPD_OBJ = new MM_T005_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_T007_BL")
                {
                    MM_T007_BL UPD_OBJ = new MM_T007_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                //else if (RequestOption == "MM_T003_BL_STS")
                //{
                //    MM_T003_BL UPD_OBJ = new MM_T003_BL();
                //    strValue = UPD_OBJ.UpdateStatus(Request);
                //}
                //else if (RequestOption == "PRO_T002_BL")
                //{
                //    PRO_T002_BL UPD_OBJ = new PRO_T002_BL();
                //    strValue = UPD_OBJ.Update(Request);
                //}
                else if (RequestOption == "MM_M0031_BL")
                {
                    MM_M0031_BL UPD_OBJ = new MM_M0031_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_M0032_BL")
                {
                    MM_M0032_BL UPD_OBJ = new MM_M0032_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "MM_S010_BL")
                {
                    MM_S010_BL UPD_OBJ = new MM_S010_BL();
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
