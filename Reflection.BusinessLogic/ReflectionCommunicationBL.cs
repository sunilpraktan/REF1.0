using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class ReflectionCommunicationBL
    {
        public string Insert(string Request, string RequestOption)
        {
             string strValue = "";
             try
             {
                 if (RequestOption == "TaskManager")
                 {
                     TSK_T001_ABL tSK_T001_ABL = new TSK_T001_ABL();
                     strValue = tSK_T001_ABL.Insert(Request);
                 }
                 
                 else if (RequestOption == "LoggingControl")
                 {
                     COM_T002BL COM_T002BL = new COM_T002BL();
                     strValue = COM_T002BL.Insert(Request);
                 }
                else if (RequestOption == "Approval")
                {
                    ApprovalBL approvalbl = new ApprovalBL();
                    strValue = approvalbl.Update(Request);
                }
                else if (RequestOption == "JobSchedular")
                {
                    COM_T004BL schedular = new COM_T004BL();
                    strValue = schedular.InsertUpdateSchedule(Request);
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
                if (RequestOption == "TaskManager")
                {
                    //EmployeeBL empBL = new EmployeeBL();
                    //strValue = empBL.Insert(Request, RequestOption);
                }
                //else if (RequestOption == "UOM_Master")
                //{
                //    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                //    strValue = aDM_M038_BBL.Update(Request);
                //}
                else if (RequestOption == "LoggingControl")
                {
                    COM_T002BL COM_T002BL = new COM_T002BL();
                    strValue = COM_T002BL.Update(Request);
                }
                else if (RequestOption == "Approval")
                {
                    ApprovalBL approvalbl = new ApprovalBL();
                    strValue = approvalbl.Update(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public string Delete(string  Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "TaskManager")
                {
                    //ADM_M001BL empBL = new ADM_M001BL();
                    //strValue = empBL.Delete(Request);
                }
                //else if (RequestOption == "UOM_Master")
                //{
                //    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                //    strValue = aDM_M038_BBL.Delete(Request);
                //}
                else if (RequestOption == "LoggingControl")
                {
                    COM_T002BL COM_T002BL = new COM_T002BL();
                    strValue = COM_T002BL.Delete(Request);
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
                if (RequestOption == "TaskManager")
                {
                    //ADM_M001BL empBL = new ADM_M001BL();
                    //strValue = empBL.Delete(Request);
                }
                //else if (RequestOption == "UOM_Master")
                //{
                //    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                //    strValue = aDM_M038_BBL.Delete(Request);
                //}
            
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strval = "";
            try
            {
                if (RequestOption == "TaskManager")
                {
                    TSK_T001_ABL tSK_T001_ABL = new TSK_T001_ABL();
                    strval = tSK_T001_ABL.GetData(Request);
                }
                else if (RequestOption == "Approval") 
                {
                    ApprovalBL approvalbl = new ApprovalBL();
                    strval = approvalbl.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ApprovalInsert")
                {
                    ApprovalBL approvalbl = new ApprovalBL();
                    strValue = approvalbl.Insert(Request);
                }

                //else if (RequestOption == "UOM_Master")
                //{
                //    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                //    strval = aDM_M038_BBL.GetData();
                //}
                else if (RequestOption == "LoggingControl")
                {
                    REF_T001BL COM_T002BL = new REF_T001BL();
                    strval = COM_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Masseging")
                {
                    Masseging_BL Msg_BL = new Masseging_BL();
                    strval = Msg_BL.GetData(Request, strType);
                }
                else if (RequestOption == "JobSchedular")
                {
                    COM_T004BL schedularBL = new COM_T004BL();
                    strval = schedularBL.GetData(Request, strType, intValue, strValue);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strval;
        }

        public byte[] GetDataWithReturnByte(string Request, string RequestOption)
        {
            byte[] strValue = null;
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
