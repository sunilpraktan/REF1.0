using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionQMSBL
    {
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "QMS_Parameter")
                {
                    EQCR_T001BL qMS_M002BL = new EQCR_T001BL();
                    strValue = qMS_M002BL.Insert(Request);
                }
                else if (RequestOption == "Inspector_Qualification")
                {
                    QMS_M022BL qMS_M003BL = new QMS_M022BL();
                    strValue = qMS_M003BL.Insert(Request);
                }
                else if (RequestOption == "Inspection_Method")
                {
                    QMS_M023BL qMS_M004BL = new QMS_M023BL();
                    strValue = qMS_M004BL.Insert(Request);
                }
                else if (RequestOption == "QCR")
                {
                    EQCR_T001BL ILdBL = new EQCR_T001BL();
                    strValue = ILdBL.Insert(Request);
                }
                else if (RequestOption == "RejectionNote")
                {
                    EQCR_T001BL ILdBL = new EQCR_T001BL();
                    strValue = ILdBL.Insert(Request);
                }
                else if (RequestOption == "ServiceRequest")
                {
                    QMS_T002BL cAL_T002BL = new QMS_T002BL();
                    strValue = cAL_T002BL.Insert(Request);
                }
                //else if (RequestOption == "InspectionMasterView")
                //{
                //    QMS_InspectionMaster_BL cAL_T002BL = new QMS_InspectionMaster_BL();
                //    strValue = cAL_T002BL.GetData(Request);
                //}
                else if (RequestOption == "CalibrationView")
                {
                    QMS_T001BL cAL_T001BL = new QMS_T001BL();
                    strValue = cAL_T001BL.Insert(Request);
                }
                else if (RequestOption == "TaskListMaster")
                {
                    QMS_M024BL qMS_M024BL = new QMS_M024BL();
                    strValue = qMS_M024BL.Insert(Request);
                }
                else if (RequestOption == "CalibrationCalender")
                {
                    QMS_CALBL qMS_CALBL = new QMS_CALBL();
                    strValue = qMS_CALBL.Insert(Request);
                }
                else if (RequestOption == "TracabilityMaster")
                {
                    QMS_M010BL qMS_M010BL = new QMS_M010BL();
                    strValue = qMS_M010BL.Insert(Request);
                }
                else if (RequestOption == "ParameterGroupMaster")
                {
                    QMS_M009_F_BL qMS_M009_F_BL = new QMS_M009_F_BL();
                    strValue = qMS_M009_F_BL.Insert(Request);
                }
                else if (RequestOption == "ParameterCodeMaster")
                {
                    QMS_M009_G_BL qMS_M009_G_BL = new QMS_M009_G_BL();
                    strValue = qMS_M009_G_BL.Insert(Request);
                }
                else if (RequestOption == "ParameterProfile")
                {
                    QMS_M033_BL qMS_M033_BL = new QMS_M033_BL();
                    strValue = qMS_M033_BL.Insert(Request);
                }
                else if (RequestOption == "SamplingScheme")
                {
                    QMS_M035_BL qMS_M035_BL = new QMS_M035_BL();
                    strValue = qMS_M035_BL.Insert(Request);
                }
                //else if (RequestOption == "SampleProcedure")
                //{
                //    QMS_M034_BL qMS_M034_BL = new QMS_M034_BL();
                //    strValue = qMS_M034_BL.Insert(Request);
                //}
                else if (RequestOption == "InspectorQualificationMaster")
                {
                    QMS_M022BL qms_m022_bl = new QMS_M022BL();
                    strValue = qms_m022_bl.Insert(Request);
                }

                else if (RequestOption == "InspectionMethod")
                {
                    QMS_M030_G_BL qMS_M030_G_BL = new QMS_M030_G_BL();
                    strValue = qMS_M030_G_BL.Insert(Request);
                }

                else if (RequestOption == "InspectionPlan")
                {
                    QMS_M030_BL qMS_M030_BL = new QMS_M030_BL();
                    strValue = qMS_M030_BL.Insert(Request);
                }
                else if (RequestOption == "MasterInspectionCharacteristics")
                {
                    QMS_M030_I_BL qMS_M030_I_BL = new QMS_M030_I_BL();
                    strValue = qMS_M030_I_BL.Insert(Request);
                }
                //else if (RequestOption == "ItemMasterQualityView")
                //{
                //    QMS_M040_BL qMS_M040_BL = new QMS_M040_BL();
                //    strValue = qMS_M040_BL.Insert(Request);
                //}
                //else if (RequestOption == "InspectionLot")
                //{
                //    QMS_T003_BL qMS_T003_BL = new QMS_T003_BL();
                //    strValue = qMS_T003_BL.Insert(Request);
                //}
                //else if (RequestOption == "InspectionLot_Process")
                //{
                //    QMS_T003_IP_BL qMS_T003_BL = new QMS_T003_IP_BL();
                //    strValue = qMS_T003_BL.Insert(Request);
                //}
                //else if (RequestOption == "InspectionLot_Process_RR")
                //{
                //    QMS_T003_IP_RR_BL qMS_T003_BL = new QMS_T003_IP_RR_BL();
                //    strValue = qMS_T003_BL.Insert(Request);
                //}
                //else if (RequestOption == "InspectionLot_Process_DR")
                //{
                //    QMS_T003_IP_DR_BL qMS_T003_BL = new QMS_T003_IP_DR_BL();
                //    strValue = qMS_T003_BL.Insert(Request);
                //}
                //else if (RequestOption == "InspectionLot_Process_UD")
                //{
                //    QMS_T003_IP_UD_BL qMS_T003_BL = new QMS_T003_IP_UD_BL();
                //    strValue = qMS_T003_BL.Insert(Request);
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
                if (RequestOption == "QCR")
                {
                    EQCR_T001BL ILdBL = new EQCR_T001BL();
                    strValue = ILdBL.Update(Request);
                }
                else if (RequestOption == "RejectionNote")
                {
                    EQCR_T001BL ILdBL = new EQCR_T001BL();
                    strValue = ILdBL.Update(Request);
                }
                else
                if (RequestOption == "QMS_Parameter")
                {
                    QMS_M021BL qMS_M002BL = new QMS_M021BL();
                    strValue = qMS_M002BL.Update(Request);
                }
                else if (RequestOption == "Inspector_Qualification")
                {
                    QMS_M022BL qMS_M003BL = new QMS_M022BL();
                    strValue = qMS_M003BL.Update(Request);
                }
                else if (RequestOption == "Inspection_Method")
                {
                    QMS_M023BL qMS_M004BL = new QMS_M023BL();
                    strValue = qMS_M004BL.Update(Request);
                }
                else if (RequestOption == "ServiceRequest")
                {
                    QMS_T002BL cAL_T002BL = new QMS_T002BL();
                    strValue = cAL_T002BL.Update(Request);
                }
                else if (RequestOption == "CalibrationView")
                {
                    QMS_T001BL cAL_T001BL = new QMS_T001BL();
                    strValue = cAL_T001BL.Update(Request);
                }
                else if (RequestOption == "TaskListMaster")
                {
                    QMS_M024BL qMS_M024BL = new QMS_M024BL();
                    strValue = qMS_M024BL.Update(Request);
                }
                else if (RequestOption == "CalibrationCalender")
                {
                    QMS_CALBL qMS_CALBL = new QMS_CALBL();
                    strValue = qMS_CALBL.Update(Request);
                }
                else if (RequestOption == "TracabilityMaster")
                {
                    QMS_M010BL qMS_M010BL = new QMS_M010BL();
                    strValue = qMS_M010BL.Update(Request);
                }
                else if (RequestOption == "ParameterGroupMaster")
                {
                    QMS_M009_F_BL qMS_M009_F_BL = new QMS_M009_F_BL();
                    strValue = qMS_M009_F_BL.Update(Request);
                }
                else if (RequestOption == "ParameterCodeMaster")
                {
                    QMS_M009_G_BL qMS_M009_G_BL = new QMS_M009_G_BL();
                    strValue = qMS_M009_G_BL.Update(Request);
                }
                else if (RequestOption == "ParameterProfile")
                {
                    QMS_M033_BL qMS_M033_BL = new QMS_M033_BL();
                    strValue = qMS_M033_BL.Update(Request);
                }
                else if (RequestOption == "SamplingScheme")
                {
                    QMS_M035_BL qMS_M035_BL = new QMS_M035_BL();
                    strValue = qMS_M035_BL.Update(Request);
                }
                //else if (RequestOption == "SampleProcedure")
                //{
                //    QMS_M034_BL qMS_M034_BL = new QMS_M034_BL();
                //    strValue = qMS_M034_BL.Update(Request);
                //}
                else if (RequestOption == "InspectorQualificationMaster")
                {
                    QMS_M022BL qms_m022_bl = new QMS_M022BL();
                    strValue = qms_m022_bl.Update(Request);
                }
                else if (RequestOption == "InspectionMethod")
                {
                    QMS_M030_G_BL qMS_M030_G_BL = new QMS_M030_G_BL();
                    strValue = qMS_M030_G_BL.Update(Request);
                }

                else if (RequestOption == "InspectionPlan")
                {
                    QMS_M030_BL qMS_M030_BL = new QMS_M030_BL();
                    strValue = qMS_M030_BL.Update(Request);
                }
                else if (RequestOption == "MasterInspectionCharacteristics")
                {
                    QMS_M030_I_BL qMS_M030_I_BL = new QMS_M030_I_BL();
                    strValue = qMS_M030_I_BL.Update(Request);
                }
                //else if (RequestOption == "ItemMasterQualityView")
                //{
                //    QMS_M040_BL qMS_M040_BL = new QMS_M040_BL();
                //    strValue = qMS_M040_BL.Update(Request);
                //}
                //else if (RequestOption == "InspectionLot")
                //{
                //    QMS_T003_BL qMS_T003_BL = new QMS_T003_BL();
                //    strValue = qMS_T003_BL.Update(Request);
                //}
                //else if (RequestOption == "InspectionLot_Process")
                //{
                //    QMS_T003_IP_BL qMS_T003_BL = new QMS_T003_IP_BL();
                //    strValue = qMS_T003_BL.Update(Request);
                //}
                //else if (RequestOption == "InspectionMasterView")
                //{
                //    QMS_InspectionMaster_BL qMS_T003_BL = new QMS_InspectionMaster_BL();
                //    strValue = qMS_T003_BL.Update(Request);
                //}

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
                if (RequestOption == "QCR")
                {
                    EQCR_T001BL eSO_T001BL = new EQCR_T001BL();
                    strValue = eSO_T001BL.Delete(Request);
                }
                else if (RequestOption == "RejectionNote")
                {
                    EQCR_T001BL eSO_T001BL = new EQCR_T001BL();
                    strValue = eSO_T001BL.Delete(Request);
                }
                else
                if (RequestOption == "QMS_Parameter")
                {
                    QMS_M021BL qMS_M002BL = new QMS_M021BL();
                    strValue = qMS_M002BL.Delete(Request);
                }
                /*  else if (RequestOption == "Inspector_Qualification")
                  {
                      QMS_M022BL qMS_M003BL = new QMS_M022BL();
                      strValue = qMS_M003BL.Delete(Request);
                  } */
                else if (RequestOption == "Inspection_Method")
                {
                    QMS_M023BL qMS_M004BL = new QMS_M023BL();
                    strValue = qMS_M004BL.Delete(Request);
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
            string strValue1 = "";
            try
            {
                if (RequestOption == "QCR")
                {
                    EQCR_T001BL eePR_T001BL = new EQCR_T001BL();
                    strValue1 = eePR_T001BL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "RejectionNote")
                {
                    EQCR_T001BL eePR_T001BL = new EQCR_T001BL();
                    strValue1 = eePR_T001BL.GetData(strType, intValue, strValue);
                }
                else
                if (RequestOption == "QMS_Parameter")
                {
                    QMS_M021BL qMS_M002BL = new QMS_M021BL();
                    strValue1 = qMS_M002BL.GetData();
                }

                else if (RequestOption == "Inspection_Method")
                {
                    QMS_M023BL qMS_M004BL = new QMS_M023BL();
                    strValue1 = qMS_M004BL.GetData();
                }
                else if (RequestOption == "CalibrationView")
                {
                    QMS_T001BL cAL_T001BL = new QMS_T001BL();
                    strValue1 = cAL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ServiceRequest")
                {
                    QMS_T002BL cAL_T002BL = new QMS_T002BL();
                    strValue1 = cAL_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TaskListMaster")
                {
                    QMS_M024BL qMS_M024BL = new QMS_M024BL();
                    strValue1 = qMS_M024BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CalibrationCalender")
                {
                    QMS_CALBL qMS_CALBL = new QMS_CALBL();
                    strValue1 = qMS_CALBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_QMS_CTReport")
                {
                    MIS_QMS_CTBL mIS_QMS_CTBL = new MIS_QMS_CTBL();
                    strValue1 = mIS_QMS_CTBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TracabilityMaster")
                {
                    QMS_M010BL qMS_M010BL = new QMS_M010BL();
                    strValue1 = qMS_M010BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ParameterGroupMaster")
                {
                    QMS_M009_F_BL qMS_M009_F_BL = new QMS_M009_F_BL();
                    strValue1 = qMS_M009_F_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ParameterCodeMaster")
                {
                    QMS_M009_G_BL qMS_M009_G_BL = new QMS_M009_G_BL();
                    strValue1 = qMS_M009_G_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ParameterProfile")
                {
                    QMS_M033_BL qMS_M033_BL = new QMS_M033_BL();
                    strValue1 = qMS_M033_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SamplingScheme")
                {
                    QMS_M035_BL qMS_M035_BL = new QMS_M035_BL();
                    strValue1 = qMS_M035_BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "SampleProcedure")
                //{
                //    QMS_M034_BL qMS_M034_BL = new QMS_M034_BL();
                //    strValue1 = qMS_M034_BL.GetData(Request, strType, intValue, strValue);
                //}
                else if (RequestOption == "InspectorQualificationMaster")
                {
                    QMS_M022BL qms_m022_bl = new QMS_M022BL();
                    strValue1 = qms_m022_bl.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "InspectionMethod")
                {
                    QMS_M030_G_BL qMS_M030_G_BL = new QMS_M030_G_BL();
                    strValue1 = qMS_M030_G_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "InspectionPlan")
                {
                    QMS_M030_BL qMS_M030_BL = new QMS_M030_BL();
                    strValue1 = qMS_M030_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MasterInspectionCharacteristics")
                {
                    QMS_M030_I_BL qMS_M030_I_BL = new QMS_M030_I_BL();
                    strValue1 = qMS_M030_I_BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "ItemMasterQualityView")
                //{
                //    QMS_M040_BL qMS_M040_BL = new QMS_M040_BL();
                //    strValue1 = qMS_M040_BL.GetData(Request, strType, intValue, strValue);
                //}
                //else if (RequestOption == "InspectionLot")
                //{
                //    QMS_T003_BL qMS_T003_BL = new QMS_T003_BL();
                //    strValue1 = qMS_T003_BL.GetData(Request, strType, intValue, strValue);
                //}
                //else if (RequestOption == "InspectionLot_Process")
                //{
                //    QMS_T003_IP_BL qMS_T003_BL = new QMS_T003_IP_BL();
                //    strValue1 = qMS_T003_BL.GetData(Request, strType, intValue, strValue);
                //}
                //else if (RequestOption == "InspectionMasterView")
                //{
                //    QMS_InspectionMaster_BL cAL_T002BL = new QMS_InspectionMaster_BL();
                //    strValue1 = cAL_T002BL.GetData(Request);
                //}
                else if (RequestOption == "To_Be_Check")
                {
                    To_Be_CheckBL becheck = new To_Be_CheckBL();
                    strValue1 = becheck.GetData(Request, strType, intValue, strValue);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
        }
    }
}
