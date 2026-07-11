using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{  
    public class ReflectionQualityBL
    {

        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "QCR")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Insert(Request);
                }
                else if (RequestOption == "RejectionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Insert(Request);
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
                if (RequestOption == "QCR")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Update(Request);
                }
                else if (RequestOption == "RejectionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Update(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

        public string Delete(int Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                //if (RequestOption == "QCR")
                //{
                //    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                //    strValue = eSO_T001BL.Delete(Request);
                //}
                // else if (RequestOption == "RejectionNote")
                //{
                //    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                //    strValue = eSO_T001BL.Delete(Request);
                //}
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
                if (RequestOption == "QCR")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Delete(Request);
                }
                 else if (RequestOption == "RejectionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Delete(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strVal = "";
            try
            {
                if (RequestOption == "QCR")
                {
                    EPR_T001BL eePR_T001BL = new EPR_T001BL();
                    strVal = eePR_T001BL.GetData(strType, strValue, intValue);
                }        
                   else if (RequestOption == "RejectionNote")
                {
                    EPR_T001BL eePR_T001BL = new EPR_T001BL();
                    strVal = eePR_T001BL.GetData(strType, strValue, intValue);
                }  
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strVal;
        }

    }

}
