using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionProjectManagementBL
    {
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";

            if (RequestOption == "Project")
            {
                PRO_T001BL proBL = new PRO_T001BL();
                strValue = proBL.Insert(Request);
            }
            else if (RequestOption == "Tasks")
            {

                PRO_T002BL proBL = new PRO_T002BL();
                strValue = proBL.Insert(Request);
            }

            else if (RequestOption == "ProjectTender")
            {
                ZCRM_T004BL pRO_T004BL = new ZCRM_T004BL();
                strValue = pRO_T004BL.Insert(Request);
            }
            else if (RequestOption == "DocumentUploader")
            {
                ZCRM_T004_ABL pRO_T004_ABL = new ZCRM_T004_ABL();
                strValue = pRO_T004_ABL.Insert(Request);
            }
            else if (RequestOption == "Phasemaster")
            {

                PRO_M003BL proBL = new PRO_M003BL();
                strValue = proBL.Insert(Request);
            }
            else if (RequestOption == "ProjectRoleMaster")
            {

                PRO_M004BL proBL = new PRO_M004BL();
                strValue = proBL.Insert(Request);
            }

            else if (RequestOption == "ProjectCheckListMaster")
            {

                PRO_M005BL proBL = new PRO_M005BL();
                strValue = proBL.Insert(Request);
            }

            else if (RequestOption == "Issues")
            {

                PRO_T003BL proBL = new PRO_T003BL();
                strValue = proBL.Insert(Request);
            }

            else if (RequestOption == "ProjectCategoryMaster")
            {

                PRO_M001BL proBL = new PRO_M001BL();
                strValue = proBL.Insert(Request);
            }
            else if (RequestOption == "ProjectSubCategoryMaster")
            {

                PRO_M001_ABL proBL = new PRO_M001_ABL();
                strValue = proBL.Insert(Request);
            }
            else if (RequestOption == "DAS_Controls_InsertAdmin")
            {
                RND_T010BL controlsBL = new RND_T010BL();
                strValue = controlsBL.InsertAdmin(Request);
            }
            else if (RequestOption == "Project_Master01")
            {
                PPC_M0002_BL proBL = new PPC_M0002_BL();
                strValue = proBL.Insert(Request);
            }

            return strValue;
        }
        public string Update(string Request, string RequestOption)
        {
            string strValue = "";

            if (RequestOption == "Project")
            {
                PRO_T001BL proBL = new PRO_T001BL();
                strValue = proBL.Update(Request);
            }
            else if (RequestOption == "Tasks")
            {
                PRO_T002BL proBL = new PRO_T002BL();
                strValue = proBL.Update(Request);
            }

            else if (RequestOption == "ProjectTender")
            {
                ZCRM_T004BL pRO_T004BL = new ZCRM_T004BL();
                strValue = pRO_T004BL.Update(Request);
            }
            else if (RequestOption == "DocumentUploader")
            {
                ZCRM_T004_ABL pRO_T004_ABL = new ZCRM_T004_ABL();
                strValue = pRO_T004_ABL.Update(Request);
            }
            else if (RequestOption == "Phasemaster")
            {
                PRO_M003BL proBL = new PRO_M003BL();
                strValue = proBL.Update(Request);
            }
            else if (RequestOption == "ProjectRoleMaster")
            {
                PRO_M004BL proBL = new PRO_M004BL();
                strValue = proBL.Update(Request);
            }
            else if (RequestOption == "ProjectCheckListMaster")
            {
                PRO_M005BL proBL = new PRO_M005BL();
                strValue = proBL.Update(Request);
            }
            else if (RequestOption == "Issues")
            {
                PRO_T003BL proBL = new PRO_T003BL();
                strValue = proBL.Update(Request);
            }
            else if (RequestOption == "ProjectCategoryMaster")
            {
                PRO_M001BL proBL = new PRO_M001BL();
                strValue = proBL.Update(Request);
            }
            else if (RequestOption == "ProjectSubCategoryMaster")
            {
                PRO_M001_ABL proBL = new PRO_M001_ABL();
                strValue = proBL.Update(Request);
            }
            return strValue;
        }
        public string Delete(int Request, string RequestOption)
        {
            string strValue = "";

            //if (RequestOption == "Project")
            //{
            //    PRO_T001BL proBL = new PRO_T001BL();
            //    strValue = proBL.Delete(Request);
            //}
            //else 
            if (RequestOption == "DocumentUploader")
            {
                ZCRM_T004_ABL pRO_T004_ABL = new ZCRM_T004_ABL();
                strValue = pRO_T004_ABL.Delete(Request);

            }

            return strValue;
        }
        public string Delete(string Request, string RequestOption)
        {
            string strValue = "";

            if (RequestOption == "Project")
            {
                PRO_T001BL proBL = new PRO_T001BL();
                strValue = proBL.Delete(Request);
            }
            else if (RequestOption == "Tasks")

            {
                PRO_T002BL proBL = new PRO_T002BL();
                strValue = proBL.delete(Request);

            }
            if (RequestOption == "ProjectTender")
            {
                ZCRM_T004BL pRO_T004BL = new ZCRM_T004BL();
                strValue = pRO_T004BL.Delete(Request);

            }




            return strValue;
        }
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strValue1 = "";

            if (RequestOption == "Project")
            {
                PRO_T001BL proBL = new PRO_T001BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "Tasks")
            {
                PRO_T002BL proBL = new PRO_T002BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }


            else if (RequestOption == "ProjectTender")
            {
                ZCRM_T004BL pRO_T004BL = new ZCRM_T004BL();
                strValue1 = pRO_T004BL.GetData(Request, strType, intValue, strValue);
            }

            else if (RequestOption == "DocumentUploader")
            {
                ZCRM_T004_ABL pRO_T004_ABL = new ZCRM_T004_ABL();
                strValue1 = pRO_T004_ABL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "Phasemaster")
            {
                PRO_M003BL proBL = new PRO_M003BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "ProjectRoleMaster")
            {
                PRO_M004BL proBL = new PRO_M004BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "ProjectCheckListMaster")
            {
                PRO_M005BL proBL = new PRO_M005BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "Issues")
            {
                PRO_T003BL proBL = new PRO_T003BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "ProjectCategoryMaster")
            {
                PRO_M001BL proBL = new PRO_M001BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "ProjectSubCategoryMaster")
            {
                PRO_M001_ABL proBL = new PRO_M001_ABL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "DAS_Controls")
            {
                RND_T010BL controlsBL = new RND_T010BL();
                strValue1 = controlsBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "DAS_DashBoard")
            {
                RND_T010BL DAS_DashBoardBL = new RND_T010BL();
                strValue1 = DAS_DashBoardBL.GetData(Request, strType, intValue, strValue);
            }

            else if (RequestOption == "DAS_Controls_Synch")
            {
                RND_T010BL DAS_Controls_SynchBL = new RND_T010BL();
                strValue1 = DAS_Controls_SynchBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "MIS_PMS")
            {
                MIS_STD_PMS_1_BL proBL = new MIS_STD_PMS_1_BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            else if (RequestOption == "Project_Master01")
            {
                PPC_M0002_BL proBL = new PPC_M0002_BL();
                strValue1 = proBL.GetData(Request, strType, intValue, strValue);
            }
            return strValue1;
        }
        public string GetDataFromBL(string Request, string NewRequestOption)
        {
            string strValue1 = "";

            if (Request == "DAS_DashBoardFromBL")
            {
                RND_T010BL DAS_DashBoardBL = new RND_T010BL("NewConnectionString");
                strValue1 = DAS_DashBoardBL.GetDataOfDashBoardFromTBsConnection(NewRequestOption);
            }
            return strValue1;
        }
    }
}
