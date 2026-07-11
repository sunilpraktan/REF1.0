using Reflection.BusinessLogic.ADM;
using Reflection.BusinessLogic.HRM;
using Reflection.BusinessLogic.PPC;
using Reflection.BusinessLogic.PRO;
using Reflection.BusinessLogic.SET;

namespace Reflection.BusinessLogic
{
    public class ReflectionWebServiceBL
    {
        public string Insert(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (Module == "Administration")
                {
                    ReflectionAdminBL adminBl = new ReflectionAdminBL();
                    strReturnValue = adminBl.Insert(Request, RequestOption);
                }
                else if (Module == "CRM")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.Insert(Request, RequestOption);
                }
                else if (Module == "SCM")
                {
                    ReflectionSCMBL scmBl = new ReflectionSCMBL();
                    strReturnValue = scmBl.Insert(Request, RequestOption);
                }
                else if (Module == "LoggingControl")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.Insert(Request, RequestOption);
                }
                else if (Module == "Finance")
                {
                    ReflectionFinanceBL crmBl = new ReflectionFinanceBL();
                    strReturnValue = crmBl.Insert(Request, RequestOption);
                }
                else if (Module == "Communication")
                {
                    ReflectionCommunicationBL commBl = new ReflectionCommunicationBL();
                    strReturnValue = commBl.Insert(Request, RequestOption);
                }
                else if (Module == "QMS")
                {
                    QMS_STD_BL INS_OBJ = new QMS_STD_BL();
                    //ReflectionQMSBL qmsBl = new ReflectionQMSBL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "Production")
                {
                    ReflectionProductionBL qmsBl = new ReflectionProductionBL();
                    strReturnValue = qmsBl.Insert(Request, RequestOption);
                }
                else if (Module == "Quality")
                {
                    ReflectionQualityBL qmsBl = new ReflectionQualityBL();
                    strReturnValue = qmsBl.Insert(Request, RequestOption);
                }
                else if (Module == "PM")
                {
                    ReflectionProjectManagementBL pmBl = new ReflectionProjectManagementBL();
                    strReturnValue = pmBl.Insert(Request, RequestOption);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL procumentBl = new ReflectionProcurementBL();
                    strReturnValue = procumentBl.Insert(Request, RequestOption);
                }
                else if (Module == "VMS")
                {
                    ReflectionVMSBL VMS_BL = new ReflectionVMSBL();
                    strReturnValue = VMS_BL.Insert(Request, RequestOption);
                }
                else if (Module == "HRM")
                {
                    HRM_STD_BL HRM_BL = new HRM_STD_BL();
                    strReturnValue = HRM_BL.Insert(Request, RequestOption);
                }
                else if (Module == "HRMS")
                {
                    ReflectionHRMSBL HRM_BL = new ReflectionHRMSBL();
                    strReturnValue = HRM_BL.Insert(Request, RequestOption);
                }
                else if (Module == "SET")
                {
                    //SET_STD_BL INS_OBJ = new SET_STD_BL();
                    //strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "SYS")
                {
                    SYS_STD_BL INS_OBJ = new SYS_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "SDM")
                {
                    SDM_STD_BL INS_OBJ = new SDM_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "PRO")
                {
                    PRO_STD_BL INS_OBJ = new PRO_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "MM")
                {
                    MM_STD_BL INS_OBJ = new MM_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "FICO")
                {
                    FICO_STD_BL INS_OBJ = new FICO_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "ADM")
                {
                    ADM_STD_BL INS_OBJ = new ADM_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "PMS")
                {
                    PMS_STD_BL INS_OBJ = new PMS_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "PPC")
                {
                    PPC_STD_BL INS_OBJ = new PPC_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "PMM")
                {
                    PMM_STD_BL INS_OBJ = new PMM_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "ENG")
                {
                    ENG_STD_BL INS_OBJ = new ENG_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "COM")
                {
                    COM_STD_BL INS_OBJ = new COM_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }
                else if (Module == "GEN")
                {
                    GEN_STD_BL INS_OBJ = new GEN_STD_BL();
                    strReturnValue = INS_OBJ.Insert(Request, RequestOption);
                }

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;

        }
        public string Update(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (Module == "Administration")
                {
                    ReflectionAdminBL adminBl = new ReflectionAdminBL();
                    strReturnValue = adminBl.Update(Request, RequestOption);
                }
                else if (Module == "CRM")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.Update(Request, RequestOption);
                }
                else if (Module == "SCM")
                {
                    ReflectionSCMBL scmBl = new ReflectionSCMBL();
                    strReturnValue = scmBl.Update(Request, RequestOption);
                }
                else if (Module == "Communication")
                {
                    ReflectionCommunicationBL commBl = new ReflectionCommunicationBL();
                    strReturnValue = commBl.Update(Request, RequestOption);
                }
                else if (Module == "Finance")
                {
                    ReflectionFinanceBL crmBl = new ReflectionFinanceBL();
                    strReturnValue = crmBl.Update(Request, RequestOption);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL commBl = new ReflectionProcurementBL();
                    strReturnValue = commBl.Update(Request, RequestOption);
                }
                else if (Module == "QMS")
                {
                    //ReflectionQMSBL qmsBl = new ReflectionQMSBL();
                    QMS_STD_BL UPD_OBJ = new QMS_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "Production")
                {
                    ReflectionProductionBL qmsBl = new ReflectionProductionBL();
                    strReturnValue = qmsBl.Update(Request, RequestOption);
                }
                else if (Module == "PM")
                {
                    ReflectionProjectManagementBL pmBl = new ReflectionProjectManagementBL();
                    strReturnValue = pmBl.Update(Request, RequestOption);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL procumentBl = new ReflectionProcurementBL();
                    strReturnValue = procumentBl.Update(Request, RequestOption);
                }
                else if (Module == "VMS")
                {
                    ReflectionVMSBL VMS_BL = new ReflectionVMSBL();
                    strReturnValue = VMS_BL.Update(Request, RequestOption);
                }
                else if (Module == "HRM")
                {
                    HRM_STD_BL HRM_BL = new HRM_STD_BL();
                    strReturnValue = HRM_BL.Update(Request, RequestOption);
                }
                else if (Module == "HRMS")
                {
                    ReflectionHRMSBL HRM_BL = new ReflectionHRMSBL();
                    strReturnValue = HRM_BL.Update(Request, RequestOption);
                }
                else if (Module == "SYS")
                {
                    SYS_STD_BL UPD_OBJ = new SYS_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "SDM")
                {
                    SDM_STD_BL UPD_OBJ = new SDM_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "PRO")
                {
                    PRO_STD_BL UPD_OBJ = new PRO_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "MM")
                {
                    MM_STD_BL UPD_OBJ = new MM_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "FICO")
                {
                    FICO_STD_BL UPD_OBJ = new FICO_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "ADM")
                {
                    ADM_STD_BL UPD_OBJ = new ADM_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "PMS")
                {
                    PMS_STD_BL UPD_OBJ = new PMS_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "PPC")
                {
                    PPC_STD_BL UPD_OBJ = new PPC_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "PMM")
                {
                    PMM_STD_BL UPD_OBJ = new PMM_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "ENG")
                {
                    ENG_STD_BL UPD_OBJ = new ENG_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "COM")
                {
                    COM_STD_BL UPD_OBJ = new COM_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
                else if (Module == "GEN")
                {
                    GEN_STD_BL UPD_OBJ = new GEN_STD_BL();
                    strReturnValue = UPD_OBJ.Update(Request, RequestOption);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;

        }
        public string Delete(string Request, string RequestOption, string Module)
        {
            string strReturnValue = "";
            try
            {
                if (Module == "Administration")
                {
                    ReflectionAdminBL adminBl = new ReflectionAdminBL();
                    strReturnValue = adminBl.Delete(Request, RequestOption);
                }
                else if (Module == "CRM")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.Delete(Request, RequestOption);
                }
                else if (Module == "Callibration")
                {
                    //ReflectionCalSysBL CalSysBL = new ReflectionCalSysBL();
                    //strReturnValue = CalSysBL.Delete(Request, RequestOption);
                }
                else if (Module == "Production")
                {
                    ReflectionProductionBL qmsBl = new ReflectionProductionBL();
                    strReturnValue = qmsBl.Delete(Request, RequestOption);
                }
                else if (Module == "Finance")
                {
                    ReflectionFinanceBL crmBl = new ReflectionFinanceBL();
                    strReturnValue = crmBl.Delete(Request, RequestOption);
                }
                else if (Module == "PM")
                {
                    ReflectionProjectManagementBL qmsBl = new ReflectionProjectManagementBL();
                    strReturnValue = qmsBl.Delete(Request, RequestOption);
                }
                else if (Module == "SCM")
                {
                    ReflectionSCMBL scmBl = new ReflectionSCMBL();
                    strReturnValue = scmBl.Delete(Request, RequestOption);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL procumentBl = new ReflectionProcurementBL();
                    strReturnValue = procumentBl.Delete(Request, RequestOption);
                }
                else if (Module == "FICO")
                {
                    FICO_STD_BL DEL_OBJ = new FICO_STD_BL();
                    strReturnValue = DEL_OBJ.Delete(Request, RequestOption);
                }
                else if (Module == "HRM")
                {
                    //HRM_STD_BL DEL_OBJ = new HRM_STD_BL();
                    //strReturnValue = DEL_OBJ.Delete(Request, RequestOption);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;

        }
        public string Delete(int Request, string RequestOption, string Module)
        {
            string strReturnValue = "";
            try
            {
                if (Module == "Administration")
                {
                    ReflectionAdminBL adminBl = new ReflectionAdminBL();
                    strReturnValue = adminBl.Delete(Request, RequestOption);
                }
                else if (Module == "CRM")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.Delete(Request, RequestOption);
                }
                else if (Module == "SCM")
                {
                    ReflectionSCMBL scmBl = new ReflectionSCMBL();
                    strReturnValue = scmBl.Delete(Request, RequestOption);
                }
                else if (Module == "Callibration")
                {
                    //ReflectionCalSysBL CalSysBL = new ReflectionCalSysBL();
                    //strReturnValue = CalSysBL.Delete(Request, RequestOption);
                }
                else if (Module == "Communication")
                {
                    ReflectionCommunicationBL commBl = new ReflectionCommunicationBL();
                    strReturnValue = commBl.Delete(Request, RequestOption);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL commBl = new ReflectionProcurementBL();
                    strReturnValue = commBl.Delete(Request, RequestOption);
                }

                else if (Module == "Finance")
                {
                    ReflectionFinanceBL crmBl = new ReflectionFinanceBL();
                    strReturnValue = crmBl.Delete(Request, RequestOption);
                }
                else if (Module == "Communication")
                {
                    ReflectionCommunicationBL commBl = new ReflectionCommunicationBL();
                    strReturnValue = commBl.Delete(Request, RequestOption);
                }
                else if (Module == "QMS")
                {
                    ReflectionQMSBL qmsBl = new ReflectionQMSBL();
                    strReturnValue = qmsBl.Delete(Request, RequestOption);
                }
                //else if (Module == "Production")
                //{
                //    ReflectionProductionBL qmsBl = new ReflectionProductionBL();
                //    strReturnValue = qmsBl.Delete(Request, RequestOption);
                //}
                else if (Module == "PM")
                {
                    ReflectionProjectManagementBL pmBl = new ReflectionProjectManagementBL();
                    strReturnValue = pmBl.Delete(Request, RequestOption);
                }
              
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;

        }
        public string GetData(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            string strReturnValue = "";
            try
            {
                if (Module == "Administration")
                {
                    ReflectionAdminBL adminBl = new ReflectionAdminBL();
                    strReturnValue = adminBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "CRM")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "SCM")
                {
                    ReflectionSCMBL scmBl = new ReflectionSCMBL();
                    strReturnValue = scmBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "Callibration")
                {
                    //ReflectionCalSysBL CalSysBL = new ReflectionCalSysBL();
                    //strReturnValue = CalSysBL.GetData(Request, RequestOption);
                }
                else if (Module == "Communication")
                {
                    ReflectionCommunicationBL commBl = new ReflectionCommunicationBL();
                    strReturnValue = commBl.GetData(Request, RequestOption,strType,intValue,strValue);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL commBl = new ReflectionProcurementBL();
                    strReturnValue = commBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "Finance")
                {
                    ReflectionFinanceBL crmBl = new ReflectionFinanceBL();
                    strReturnValue = crmBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "QMS")
                {
                    QMS_STD_BL GET_OBJ = new QMS_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "Production")
                {
                    ReflectionProductionBL qmsBl = new ReflectionProductionBL();
                    strReturnValue = qmsBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "PM")
                {
                    ReflectionProjectManagementBL pmBl = new ReflectionProjectManagementBL();
                    strReturnValue = pmBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL procumentBl = new ReflectionProcurementBL();
                    strReturnValue = procumentBl.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "VMS")
                {
                    ReflectionVMSBL VMS_BL = new ReflectionVMSBL();
                    strReturnValue = VMS_BL.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "HRM")
                {
                    HRM_STD_BL HRM_BL = new HRM_STD_BL();
                    strReturnValue = HRM_BL.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "HRMS")
                {
                    ReflectionHRMSBL HRM_BL = new ReflectionHRMSBL();
                    strReturnValue = HRM_BL.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "LoggingControl")
                {
                    ReflectionCommunicationBL COM_BL = new ReflectionCommunicationBL();
                    strReturnValue = COM_BL.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "SET")
                {
                    SET_STD_BL GET_OBJ = new SET_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "SYS")
                {
                    SYS_STD_BL GET_OBJ = new SYS_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "SDM")
                {
                    SDM_STD_BL GET_OBJ = new SDM_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "PRO")
                {
                    PRO_STD_BL GET_OBJ = new PRO_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "MM")
                {
                    MM_STD_BL GET_OBJ = new MM_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "FICO")
                {
                    FICO_STD_BL GET_OBJ = new FICO_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "ADM")
                {
                    ADM_STD_BL GET_OBJ = new ADM_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "PMS")
                {
                    PMS_STD_BL GET_OBJ = new PMS_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "PPC")
                {
                    PPC_STD_BL GET_OBJ = new PPC_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "PMM")
                {
                    PMM_STD_BL GET_OBJ = new PMM_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "ENG")
                {
                    ENG_STD_BL GET_OBJ = new ENG_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "COM")
                {
                    COM_STD_BL GET_OBJ = new COM_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }
                else if (Module == "GEN")
                {
                    GEN_STD_BL GET_OBJ = new GEN_STD_BL();
                    strReturnValue = GET_OBJ.GetData(Request, RequestOption, strType, intValue, strValue);
                }

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;

        }


        public string GetData(string Request, string RequestOption, string Module, string strType, int intValue, string strValue, string doc_code, string comp_code, string location_Id, string add_by, string request1, string request2, string request3, string request4, string request5)
        {
            string strReturnValue = "";
            try
            {
                if (Module == "CRM")
                {
                    ReflectionCRMBL crmBl = new ReflectionCRMBL();
                    strReturnValue = crmBl.GetData(Request, RequestOption, strType, intValue, strValue, doc_code, comp_code, location_Id, add_by, request1, request2, request3, request4, request5);
                }               
                else if (Module == "Procurement")
                {
                    ReflectionProcurementBL commBl = new ReflectionProcurementBL();
                    //strReturnValue = commBl.GetData(Request, RequestOption, strType, intValue, strValue, doc_code, comp_code, location_Id, add_by, request1, request2, request3, request4, request5);
                }
                else if (Module == "Production")
                {
                    ReflectionProductionBL qmsBl = new ReflectionProductionBL();
                    strReturnValue = qmsBl.GetData(Request, RequestOption, strType, intValue, strValue, doc_code, comp_code, location_Id, add_by, request1, request2, request3, request4, request5);
                }               
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnValue;

        }

    }

}
