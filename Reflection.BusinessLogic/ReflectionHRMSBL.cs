using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionHRMSBL
    {
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strValue1 = "";
            try
            {
                if (RequestOption == "TerminalMaster")
                {
                    HRM_M015_BL hrm_m015_bl = new HRM_M015_BL();
                    strValue1 = hrm_m015_bl.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "EquipmentMaster")
                {
                    HRM_M016_BL _HRM_M016_BL = new HRM_M016_BL();
                    strValue1 = _HRM_M016_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "EmployeeMaster")
                {
                    HRM_M001_BL _HRM_M001_BL = new HRM_M001_BL();
                    strValue1 = _HRM_M001_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Employee_View")
                {
                    HRM_M001_BL _HRM_M001_BL = new HRM_M001_BL();
                    strValue1 = _HRM_M001_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Attendence_Request")
                {
                    HRM_T001_BL _HRM_T001_BL = new HRM_T001_BL();
                    strValue1 = _HRM_T001_BL.GetData(Request, strType, intValue, strValue);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
        }


        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "TerminalMaster")
                {
                    HRM_M015_BL hrm_m015_bl = new HRM_M015_BL();
                    strValue = hrm_m015_bl.Insert(Request);
                }
                else if (RequestOption == "EquipmentMaster")
                {
                    HRM_M016_BL hrm_M016_BL = new HRM_M016_BL();
                    strValue = hrm_M016_BL.Insert(Request);
                }
                else if (RequestOption == "Attendence_Request")
                {
                    HRM_T001_BL _HRM_T001_BL = new HRM_T001_BL();
                    strValue = _HRM_T001_BL.Insert(Request);
                }
                else if (RequestOption == "Employee_View")
                {
                    HRM_M001_BL _HRM_T001_BL = new HRM_M001_BL();
                    strValue = _HRM_T001_BL.Insert(Request);
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
                if (RequestOption == "EquipmentMaster")
                {
                    HRM_M016_BL _HRM_M016_BL = new HRM_M016_BL();
                    strValue = _HRM_M016_BL.Update(Request);
                }
                else if (RequestOption == "TerminalMaster")
                {
                    HRM_M015_BL hrm_m015_bl = new HRM_M015_BL();
                    strValue = hrm_m015_bl.Update(Request);
                }
                else if (RequestOption == "Attendence_Request")
                {
                    HRM_T001_BL _HRM_T001_BL = new HRM_T001_BL();
                    strValue = _HRM_T001_BL.Update(Request);
                }
                else if(RequestOption== "Employee_View")
                {
                    HRM_M001_BL _HRM_M001_BL = new HRM_M001_BL();
                    strValue = _HRM_M001_BL.Update(Request);
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
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }



    }
}
