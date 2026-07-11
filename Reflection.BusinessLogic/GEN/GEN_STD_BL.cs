using Reflection.BusinessLogic.GEN;
using Reflection.BusinessLogic.MM;

namespace Reflection.BusinessLogic
{
    public class GEN_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "GEN_M0001_BL")
                {
                    GEN_M0001_BL GET_OBJ = new GEN_M0001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "REF_T001_BL")
                {
                    REF_T001_BL GET_OBJ = new REF_T001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GEN_T021_BL")
                {
                    GEN_T021_BL GET_OBJ = new GEN_T021_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GEN_M0101_BL")
                {
                    GEN_M0101_BL GET_OBJ = new GEN_M0101_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GEN_M0101")
                {
                    GEN_M0101_BL GET_OBJ = new GEN_M0101_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "GEN_M0011_BL")
                //{
                //    GEN_M0011_BL GET_OBJ = new GEN_M0011_BL();
                //    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                //}
                //else if (RequestOption == "GEN_M0021_BL")
                //{
                //    GEN_M0021_BL GET_OBJ = new GEN_M0021_BL();
                //    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                //}
                //else if (RequestOption == "GEN_M0031_BL")
                //{
                //    GEN_M0031_BL GET_OBJ = new GEN_M0031_BL();
                //    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                //}


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
                if (RequestOption == "GEN_M0001_BL")
                {
                    GEN_M0001_BL INS_OBJ = new GEN_M0001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "GEN_T021_BL")
                {
                    GEN_T021_BL GET_OBJ = new GEN_T021_BL();
                    strValue = GET_OBJ.Insert(Request);
                }
                else if (RequestOption == "GEN_M0101_BL")
                {
                    GEN_M0101_BL GET_OBJ = new GEN_M0101_BL();
                    strValue = GET_OBJ.Insert(Request);
                }
                //else if (RequestOption == "GEN_M0011_BL")
                //{
                //    GEN_M0011_BL INS_OBJ = new GEN_M0011_BL();
                //    strValue = INS_OBJ.Insert(Request);
                //}
                //else if (RequestOption == "GEN_M0021_BL")
                //{
                //    GEN_M0021_BL INS_OBJ = new GEN_M0021_BL();
                //    strValue = INS_OBJ.Insert(Request);
                //}
                //else if (RequestOption == "GEN_M0031_BL")
                //{
                //    GEN_M0031_BL INS_OBJ = new GEN_M0031_BL();
                //    strValue = INS_OBJ.Insert(Request);
                //}


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
                if (RequestOption == "GEN_M0001_BL")
                {
                    GEN_M0001_BL UPD_OBJ = new GEN_M0001_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                //else if (RequestOption == "GEN_M0011_BL")
                //{
                //    GEN_M0011_BL UPD_OBJ = new GEN_M0011_BL();
                //    strValue = UPD_OBJ.Update(Request);
                //}
                //else if (RequestOption == "GEN_M0021_BL")
                //{
                //    GEN_M0021_BL UPD_OBJ = new GEN_M0021_BL();
                //    strValue = UPD_OBJ.Update(Request);
                //}
                //else if (RequestOption == "GEN_M0031_BL")
                //{
                //    GEN_M0031_BL UPD_OBJ = new GEN_M0031_BL();
                //    strValue = UPD_OBJ.Update(Request);
                //}

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
    }
}
