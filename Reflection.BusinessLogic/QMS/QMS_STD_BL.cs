using Reflection.BusinessLogic.QMS;

namespace Reflection.BusinessLogic
{
    public class QMS_STD_BL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (RequestOption == "QMS_R02_BL")
                {
                    QMS_R02_BL GET_OBJ = new QMS_R02_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_T003_BL")
                {
                    QMS_T003_BL GET_OBJ = new QMS_T003_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_T012_BL")
                {
                    QMS_T012_BL GET_OBJ = new QMS_T012_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_T013_BL")
                {
                    QMS_T013_BL GET_OBJ = new QMS_T013_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_T014_BL")
                {
                    QMS_T014_BL GET_OBJ = new QMS_T014_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0001_BL")
                {
                    QMS_M0001_BL GET_OBJ = new QMS_M0001_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "QMS_T001_BL")
                //{
                //    QMS_T001_BL GET_OBJ = new QMS_T001_BL();
                //    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                //}
                //else if (RequestOption == "QMS_T002_BL")
                //{
                //    QMS_T001_BL GET_OBJ = new QMS_T001_BL();
                //    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                //}
                else if (RequestOption == "QMS_M0040_BL")
                {
                    QMS_M0040_BL GET_OBJ = new QMS_M0040_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0033_BL")
                {
                    QMS_M0033_BL GET_OBJ = new QMS_M0033_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0034_BL")
                {
                    QMS_M0034_BL GET_OBJ = new QMS_M0034_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CalibrationView")
                {
                    ReflectionQMSBL GET_OBJ = new ReflectionQMSBL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0044_BL")
                {
                    QMS_M0044_BL GET_OBJ = new QMS_M0044_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0048_BL")
                {
                    QMS_M0048_BL GET_OBJ = new QMS_M0048_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0002_BL")
                {
                    QMS_M0002_BL GET_OBJ = new QMS_M0002_BL();
                    strReturnValue = GET_OBJ.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "QMS_M0003_BL")
                {
                    QMS_M0003_BL GET_OBJ = new QMS_M0003_BL();
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
                if (RequestOption == "QMS_T003_BL")
                {
                    QMS_T003_BL INS_OBJ = new QMS_T003_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_T012_BL")
                {
                    QMS_T012_BL INS_OBJ = new QMS_T012_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_T013_BL")
                {
                    QMS_T013_BL INS_OBJ = new QMS_T013_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_T014_BL")
                {
                    QMS_T014_BL INS_OBJ = new QMS_T014_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0001_BL")
                {
                    QMS_M0001_BL INS_OBJ = new QMS_M0001_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0040_BL")
                {
                    QMS_M0040_BL INS_OBJ = new QMS_M0040_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0033_BL")
                {
                    QMS_M0033_BL INS_OBJ = new QMS_M0033_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0034_BL")
                {
                    QMS_M0034_BL INS_OBJ = new QMS_M0034_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0044_BL")
                {
                    QMS_M0044_BL INS_OBJ = new QMS_M0044_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0048_BL")
                {
                    QMS_M0048_BL INS_OBJ = new QMS_M0048_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0002_BL")
                {
                    QMS_M0002_BL INS_OBJ = new QMS_M0002_BL();
                    strValue = INS_OBJ.Insert(Request);
                }
                else if (RequestOption == "QMS_M0003_BL")
                {
                    QMS_M0003_BL INS_OBJ = new QMS_M0003_BL();
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
                if (RequestOption == "QMS_T003_BL")
                {
                    QMS_T003_BL UPD_OBJ = new QMS_T003_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_T012_BL")
                {
                    QMS_T012_BL UPD_OBJ = new QMS_T012_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_T013_BL")
                {
                    QMS_T013_BL UPD_OBJ = new QMS_T013_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_T014_BL")
                {
                    QMS_T014_BL UPD_OBJ = new QMS_T014_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_M0040_BL")
                {
                    QMS_M0040_BL UPD_OBJ = new QMS_M0040_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_M0033_BL")
                {
                    QMS_M0033_BL UPD_OBJ = new QMS_M0033_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_M0034_BL")
                {
                    QMS_M0034_BL UPD_OBJ = new QMS_M0034_BL();
                    strValue = UPD_OBJ.Update(Request);
                }
                else if (RequestOption == "QMS_M0003_BL")
                {
                    QMS_M0003_BL UPD_OBJ = new QMS_M0003_BL();
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
