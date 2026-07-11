using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionAdminBL
    {
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "BallDiameterMaster")
                {
                    ZADM_M001BL zADM_M001BL = new ZADM_M001BL();
                    strValue = zADM_M001BL.Insert(Request);
                }
                else if (RequestOption == "BusinessPlaceMaster")
                {
                    ADM_M003_C_BL _ADM_M003_C_BL = new ADM_M003_C_BL();
                    strValue = _ADM_M003_C_BL.Insert(Request);
                }
                else if (RequestOption == "BallTypeMaster")
                {
                    ZADM_M002BL zADM_M002BL = new ZADM_M002BL();
                    strValue = zADM_M002BL.Insert(Request);
                }

                else if (RequestOption == "salesorgassigncompany")
                {
                    ADM_M001_B_BL aDM_M001_B_BL = new ADM_M001_B_BL();
                    strValue = aDM_M001_B_BL.Insert(Request);
                }
                else if (RequestOption == "SalesOffice")
                {
                   
                       ADM_M001_I_BL aDM_M001_I_BL = new ADM_M001_I_BL();
                    strValue = aDM_M001_I_BL.Insert(Request);
                }
                else if (RequestOption == "SetUpSalesArea")
                {
                    ADM_M001_K_BL aDM_M001_K_BL = new ADM_M001_K_BL();
                    strValue = aDM_M001_K_BL.Insert(Request);
                }
                else if (RequestOption == "AssignPurGroupToPurOrg")
                {
                    ADM_M001_Q_BL aDM_M001_Q_BL = new ADM_M001_Q_BL();
                    strValue = aDM_M001_Q_BL.Insert(Request);
                }
                else if (RequestOption == "SalesDistributionChannel")
                {
                    ADM_M001_C_BL aDM_M001_C_BL = new ADM_M001_C_BL();
                    strValue = aDM_M001_C_BL.Insert(Request);
                }
                else if (RequestOption == "AssignPlantToSalesOrg_DistriChannel")
                {
                    ADM_M001_G_BL aDM_M001_G_BL = new ADM_M001_G_BL();
                    strValue = aDM_M001_G_BL.Insert(Request);
                }
                else if (RequestOption == "SalesDivision")
                {
                    ADM_M001_D_BL aDM_M001_D_BL = new ADM_M001_D_BL();
                    strValue = aDM_M001_D_BL.Insert(Request);
                }
                else if (RequestOption == "ModelMaster")
                {
                    ZADM_M009BL zADM_M009BL = new ZADM_M009BL();
                    strValue = zADM_M009BL.Insert(Request);
                }
                else if (RequestOption == "WireTypeMaster")
                {
                    ZADM_M004BL zADM_M004BL = new ZADM_M004BL();
                    strValue = zADM_M004BL.Insert(Request);
                }
                else if (RequestOption == "WireSizeMaster")
                {
                    ZADM_M003BL zADM_M003BL = new ZADM_M003BL();
                    strValue = zADM_M003BL.Insert(Request);                     
                }
                else if (RequestOption == "Warehouse")
                {
                    ADM_M011BL aDM_M011_BL = new ADM_M011BL();
                    strValue = aDM_M011_BL.Insert(Request);
                }
                else if (RequestOption == "ParameterValueMaster")
                {
                    ADM_M030BL aDM_M030_BL = new ADM_M030BL();
                    strValue = aDM_M030_BL.Insert(Request);
                }
                else if (RequestOption == "UOM_Master")
                {
                    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                    strValue = aDM_M038_BBL.Insert(Request);
                }
                else if (RequestOption == "UOM_Conversion")
                {
                    ADM_M038_CBL aDM_M038_CBL = new ADM_M038_CBL();
                    strValue = aDM_M038_CBL.Insert(Request);
                }
                else if (RequestOption == "InkMaster")
                {
                    ZADM_M006BL zADM_M006BL = new ZADM_M006BL();
                    strValue = zADM_M006BL.Insert(Request);
                }
                else if (RequestOption == "UsedIn_Master")
                {
                    ZADM_M005BL zADM_M005BL = new ZADM_M005BL();
                    strValue = zADM_M005BL.Insert(Request);
                }
                else if (RequestOption == "TotalLengthMaster")
                {
                    ZADM_M008BL zADM_M008BL = new ZADM_M008BL();
                    strValue = zADM_M008BL.Insert(Request);
                }
                else if (RequestOption == "FinishGoodMaster")
                {
                    ZADM_M010BL zADM_M010BL = new ZADM_M010BL();
                    strValue = zADM_M010BL.Insert(Request);
                }
                else if (RequestOption == "MachineTypeMaster")
                {
                    ZADM_M011BL zADM_M011BL = new ZADM_M011BL();
                    strValue = zADM_M011BL.Insert(Request);
                }
                else if (RequestOption == "MachineSubTypeMaster")
                {
                    ZADM_M012BL zADM_M012BL = new ZADM_M012BL();
                    strValue = zADM_M012BL.Insert(Request);
                }
                else if (RequestOption == "MachineMaster")
                {
                    ZADM_M013BL zADM_M013BL = new ZADM_M013BL();
                    strValue = zADM_M013BL.Insert(Request);
                }

                else if (RequestOption == "LabrotaryMaster")
                {
                    ADM_M003_BBL aDM_LAB_BL = new ADM_M003_BBL();
                    strValue = aDM_LAB_BL.Insert(Request);
                }
                else if (RequestOption == "WritingTestMaster")
                {
                    ZADM_M014BL zADM_M014BL = new ZADM_M014BL();
                    strValue = zADM_M014BL.Insert(Request);
                }
                else if (RequestOption == "DepartmentMaster")
                {
                    ADM_M025BL aDM_M025BL = new ADM_M025BL();
                    strValue = aDM_M025BL.Insert(Request);
                }
                else if (RequestOption == "DesignationMaster")
                {
                    ADM_M026BL aDM_M026BL = new ADM_M026BL();
                    strValue = aDM_M026BL.Insert(Request);
                }
                else if (RequestOption == "CountryMaster")
                {
                    ADM_M012BL aDM_M012BL = new ADM_M012BL();
                    strValue = aDM_M012BL.Insert(Request);
                }
                else if (RequestOption == "LicenseMaster")
                {
                    ADM_M041BL aDM_M041BL = new ADM_M041BL();
                    strValue = aDM_M041BL.Insert(Request);
                }
                else if (RequestOption == "PaymentTerms")
                {
                    ACC_M007BL aCC_M007BL = new ACC_M007BL();
                    strValue = aCC_M007BL.Insert(Request);
                }
                else if (RequestOption == "Tax_Master")
                {
                    ACC_M013BL aCC_M013BL = new ACC_M013BL();
                    strValue = aCC_M013BL.Insert(Request);
                }
                else if (RequestOption == "WithHoldingTaxMaster")
                {
                    ACC_M025_BL aCC_M025BL = new ACC_M025_BL();
                    strValue = aCC_M025BL.Insert(Request);
                }
               

                else if (RequestOption == "UserMaster")
                {
                    ADM_M010BL aDM_M010 = new ADM_M010BL();
                    strValue = aDM_M010.Insert(Request);
                }
                else if (RequestOption == "UserSettings")
                {
                    SYS_S001BL sYS_S001BL = new SYS_S001BL();
                    strValue = sYS_S001BL.Insert(Request);
                }
                //else   if (RequestOption == "SickDeclaration")
                //{
                //    CAL_T002BL empBL = new CAL_T002BL();
                //    strValue = empBL.Insert(Request);
                //}
                else if (RequestOption == "GroupCompany")
                {
                    ADM_M001BL empBL = new ADM_M001BL();
                    strValue = empBL.Insert(Request);
                }
                else if (RequestOption == "Company_Master")
                {
                    ADM_M002BL empBL = new ADM_M002BL();
                    strValue = empBL.Insert(Request);
                }
                else if (RequestOption == "PartyMaster")
                {
                    ADM_M028BL empBL = new ADM_M028BL();
                    strValue = empBL.Insert(Request);
                }
                else if (RequestOption == "GeneralPartyMaster")
                {
                    ADM_M053BL PartyBL = new ADM_M053BL();
                    strValue = PartyBL.Insert(Request);
                }
                else if (RequestOption == "PartyMasterCRM")
                {
                    ADM_M028_F_BL empBL = new ADM_M028_F_BL();
                    strValue = empBL.Insert(Request);
                }
                else if (RequestOption == "ContactMaster")
                {
                    ADM_M054BL ContactBL = new ADM_M054BL();
                    strValue = ContactBL.Insert(Request);
                }
                //else if (RequestOption == "CompanyCatlog")
                //{
                //    //CRM_T001ABL empBL = new CRM_T001ABL();
                //    //strValue = empBL.Insert(Request);
                //}                
                //else if (RequestOption == "AuthorizationFieldMaster")
                //{
                //    ADM_M005BL aDM_M005 = new ADM_M005BL();

                //    strValue = aDM_M005.Insert((Request));
                //}
                //else if (RequestOption == "ModuleGroupMaster")
                //{
                //    ADM_M006BL aDM_M006 = new ADM_M006BL();
                //    strValue = aDM_M006.Insert(Request);
                //}               
                else if (RequestOption == "ViewMaster")
                {
                    ADM_M008BBL aDM_M008 = new ADM_M008BBL();
                    strValue = aDM_M008.Insert(Request);
                }
                else if (RequestOption == "RoleMaster")
                {
                    ADM_M009BL aDM_M009 = new ADM_M009BL();
                    strValue = aDM_M009.Insert(Request);
                }

                else if (RequestOption == "Employee_Master")
                {
                    ADM_M024BL aDM_M024 = new ADM_M024BL();
                    strValue = aDM_M024.Insert(Request);
                }
                else if (RequestOption == "Parameter_Master")
                {
                    ADM_M031BL aDM_M024 = new ADM_M031BL();
                    strValue = aDM_M024.Insert(Request);
                }

                //else if (RequestOption == "ShadeMaster")
                //{
                //    ADM_M031BL aDM_M031 = new ADM_M031BL();
                //    strValue = aDM_M031.Insert(Request);
                //}
                else if (RequestOption == "MakeMaster")
                {
                    ADM_M032BL empBL = new ADM_M032BL();
                    strValue = empBL.Insert(Request);
                }
                //else if (RequestOption == "ColourMaster")
                //{
                //    ADM_M033BL aDM_M033 = new ADM_M033BL();
                //    strValue = aDM_M033.Insert(Request);
                //}
                //else if (RequestOption == "MeasurementClass")
                //{
                //    CAL_M009BL cAL_M009 = new CAL_M009BL();
                //    strValue = cAL_M009.Insert(Request);
                //}

                //else if (RequestOption == "BaseUnitMaster")
                //{
                //    CAL_M011BL cAL_M011 = new CAL_M011BL();
                //    strValue = cAL_M011.Insert(Request);
                //}
                //else if (RequestOption == "ActivityMaster")
                //{
                //    ADM_M004BL empBL = new ADM_M004BL();
                //    strValue = empBL.Insert(Request);
                //}
                else if (RequestOption == "CategoryMaster")
                {
                    ADM_M018BL calBL = new ADM_M018BL();
                    strValue = calBL.Insert(Request);
                }
                else if (RequestOption == "SubCategoryMaster")
                {
                    ADM_M019BL calBL = new ADM_M019BL();
                    strValue = calBL.Insert(Request);
                }
                else if (RequestOption == "ItemMaster")
                {
                    ADM_M022BL calBL = new ADM_M022BL();
                    strValue = calBL.Insert(Request);
                }

                else if (RequestOption == "WorkInstruction")
                {
                    QMS_M007BL Cbl = new QMS_M007BL();
                    strValue = Cbl.Insert(Request);
                }

                else if (RequestOption == "CatParameterMaster")
                {
                    ADM_M034BL calBL = new ADM_M034BL();
                    strValue = calBL.Insert(Request);
                }                
                //else if (RequestOption == "ExternalInstrumentMaster")
                //{
                //    CAL_M004ABL calBL = new CAL_M004ABL();
                //    strValue = calBL.Insert(Request);
                //}
                //else if (RequestOption == "GeneralMaster")
                //{
                //    CAL_M006BL calBL = new CAL_M006BL();
                //    strValue = calBL.Insert(Request);
                //}
                //else if (RequestOption == "RigMaster")
                //{
                //    CAL_M008BL calBL = new CAL_M008BL();
                //    strValue = calBL.Insert(Request);
                //}            

                //else if (RequestOption == "ExternalInstrumentReceipt")
                //{
                //    CAL_M005BL calBL = new CAL_M005BL();
                //    strValue = calBL.Insert(Request);
                //}

                //else if (RequestOption == "CallRevisionMaster")
                //{
                //    //CAL_M007BL calBL = new CAL_M007BL();
                //    //strValue = calBL.Insert(Request);
                //}
                else if (RequestOption == "ItemTypeMaster")
                {
                    ADM_M015BL calBL = new ADM_M015BL();
                    strValue = calBL.Insert(Request);
                }
                else if (RequestOption == "SubItmTpMaster")
                {
                    ADM_M016BL calBL = new ADM_M016BL();
                    strValue = calBL.Insert(Request);
                }
           
                else if (RequestOption == "LocationMaster")
                {
                    ADM_M003BL locBL = new ADM_M003BL();
                    strValue = locBL.Insert(Request);
                }
             
                else if (RequestOption == "AllocationMaster")
                {
                    ADM_M036BL conBL = new ADM_M036BL();
                    strValue = conBL.Insert(Request);
                }
                else if (RequestOption == "ILDMaster")
                {
                    ZADM_M007BL conBL = new ZADM_M007BL();
                    strValue = conBL.Insert(Request);
                }
                else if (RequestOption == "StateMaster")
                {
                    ADM_M013BL aDM_M013 = new ADM_M013BL();
                    strValue = aDM_M013.Insert(Request);
                }
                else if (RequestOption == "WorkFlowMaster")
                {
                    ADM_M043BL aDM_M043BL = new ADM_M043BL();
                    strValue = aDM_M043BL.Insert(Request);
                }
                else if (RequestOption == "InkCatalog")
                {
                    ZADM_M026BL zADM_M026BL = new ZADM_M026BL();
                    strValue = zADM_M026BL.Insert(Request);
                }
                else if (RequestOption == "RateMaster")
                {
                    ZADM_M027BL zADM_M027BL = new ZADM_M027BL();
                    strValue = zADM_M027BL.Insert(Request);
                }
                else if (RequestOption == "HS_CodeMaster")
                {
                    ADM_M022_A_BL aDM_M022_A_BL = new ADM_M022_A_BL();
                    strValue = aDM_M022_A_BL.Insert(Request);
                }
                //------------------------ Calibration ---------
                else if (RequestOption == "InstrumentMaster")
                {
                    QMS_M003BL cAL_M003BL = new QMS_M003BL();
                    strValue = cAL_M003BL.Insert(Request);
                }
                else if (RequestOption == "InstrumentGroupMaster")
                {
                    QMS_M001BL cAL_M001BL = new QMS_M001BL();
                    //strValue = cAL_M001BL.Insert(Request);
                }
                else if (RequestOption == "InstrumentSubGroupMaster")
                {
                    QMS_M002BL cAL_M002BL = new QMS_M002BL();
                    strValue = cAL_M002BL.Insert(Request);
                }
                else if (RequestOption == "RigMaster")
                {
                    QMS_M008BL cAL_M008BL = new QMS_M008BL();
                    strValue = cAL_M008BL.Insert(Request);
                }
                else if (RequestOption == "TestIdentificationMaster")
                {
                    QMS_M009BL cAL_M009BL = new QMS_M009BL();
                    strValue = cAL_M009BL.Insert(Request);
                }
                else if (RequestOption == "TestProcedure")
                {
                    QMS_M006BL cAL_M006BL = new QMS_M006BL();
                    strValue = cAL_M006BL.Insert(Request);
                }
                else if (RequestOption == "TDS_Parameter")
                {
                    ENG_T003BL eNG_T003BL = new ENG_T003BL();
                    strValue = eNG_T003BL.Insert(Request);
                }
                else if (RequestOption == "Sion_Master")
                {
                    ADM_M041_B_BL aDM_M041_B = new ADM_M041_B_BL();
                    strValue = aDM_M041_B.Insert(Request);
                }
                else if (RequestOption == "SalesOrganisationMaster")
                {
                    ADM_M001_A_BL _ADM_M001_A_BL = new ADM_M001_A_BL();
                    strValue = _ADM_M001_A_BL.Insert(Request);
                }
                else if (RequestOption == "SalesGroupMaster")
                {
                    ADM_M001_H_BL _ADM_M001_H_BL = new ADM_M001_H_BL();
                    strValue = _ADM_M001_H_BL.Insert(Request);
                }
                else if (RequestOption == "PurchaseOrganisationMaster")
                {
                    ADM_M001_M_BL _ADM_M001_M_BL = new ADM_M001_M_BL();
                    strValue = _ADM_M001_M_BL.Insert(Request);
                }
                else if (RequestOption == "PurchaseGroupMaster")
                {
                    ADM_M001_P_BL _ADM_M001_P_BL = new ADM_M001_P_BL();
                    strValue = _ADM_M001_P_BL.Insert(Request);
                }
                else if (RequestOption == "PurchaseOrgAssignToPlant")
                {
                    ADM_M001_O1_BL _ADM_M001_O1_BL = new ADM_M001_O1_BL();
                    strValue = _ADM_M001_O1_BL.Insert(Request);
                }
                else if (RequestOption == "AssignDistributionChannelToSO")
                {
                    ADM_M001_E_BL _ADM_M001_E_BL = new ADM_M001_E_BL();
                    strValue = _ADM_M001_E_BL.Insert(Request);
                }

                else if (RequestOption == "AssignSalesOfficeToSalesArea")
                {
                    ADM_M001_L_BL _ADM_M001_L_BL = new ADM_M001_L_BL();
                    strValue = _ADM_M001_L_BL.Insert(Request);
                }
                else if (RequestOption == "AssignSalesOfficeToSalesArea")
                {
                    ADM_M001_L_BL _ADM_M001_L_BL = new ADM_M001_L_BL();
                    strValue = _ADM_M001_L_BL.Insert(Request);
                }
                else if(RequestOption == "AssignDivisionToSO")
                {
                    ADM_M001_F_BL _ADM_M001_F_BL = new ADM_M001_F_BL();
                    strValue = _ADM_M001_F_BL.Insert(Request);
                }
                else if (RequestOption == "CompanyCondition")
                {
                    ADM_M002_A_BL _ADM_M002_A_BL = new ADM_M002_A_BL();
                    strValue = _ADM_M002_A_BL.Insert(Request);
                }
                else if (RequestOption == "AssignItemCategoryToDocumentType")
                {
                    SYS_M023_BL _SYS_M023_BL = new SYS_M023_BL();
                    strValue = _SYS_M023_BL.Insert(Request);
                }
                else if (RequestOption == "GroupMaster")
                {
                    ADM_M058_BL _ADM_M058_BL = new ADM_M058_BL();
                    strValue = _ADM_M058_BL.Insert(Request);
                }
                else if (RequestOption == "PartyBankMaster")
                {
                    ADM_M028_E_BL _ADM_M028_E_BL = new ADM_M028_E_BL();
                    strValue = _ADM_M028_E_BL.Insert(Request);
                }
                else if (RequestOption == "PartyCondition")
                {
                    ADM_M028_H_BL _ADM_M028_H_BL = new ADM_M028_H_BL();
                    strValue = _ADM_M028_H_BL.Insert(Request);
                }
                else if (RequestOption == "WithholdingTaxforParty")
                {
                    ADM_M028_I_BL ADM_M028_I = new ADM_M028_I_BL();
                    strValue = ADM_M028_I.Insert(Request);
                }
                else if (RequestOption == "StatusMaster")
                {
                    SYS_M025_BL SYS_M025 = new SYS_M025_BL();
                    strValue = SYS_M025.Insert(Request);
                }
                else if (RequestOption == "AssignSalesGroupToSalesOffice")
                {
                    ADM_M001_J_BL aDM_M001_J_BL = new ADM_M001_J_BL();
                    strValue = aDM_M001_J_BL.Insert(Request);
                }
                else if (RequestOption == "ProfitCenterMaster")
                {
                    ACC_M020_BL aCC_M020_BL = new ACC_M020_BL();
                    strValue = aCC_M020_BL.Insert(Request);
                }
                else if (RequestOption == "CostCenterMaster")
                {
                    ACC_M019_BL aCC_M019_BL = new ACC_M019_BL();
                    strValue = aCC_M019_BL.Insert(Request);
                }
                else if (RequestOption == "AddressMaster")
                {
                    ADM_M055_BL adm_M055_BL = new ADM_M055_BL();
                    strValue = adm_M055_BL.Insert(Request);
                }
                else if (RequestOption == "CommunicationMaster")
                {
                    ADM_M057_BL adm_M057_BL = new ADM_M057_BL();
                    strValue = adm_M057_BL.Insert(Request);
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
                if (RequestOption == "EmployeeMaster")
                {
                    //EmployeeBL empBL = new EmployeeBL();
                    //strValue = empBL.Insert(Request, RequestOption);
                }
                else if (RequestOption == "ModelMaster")
                {
                    ZADM_M009BL zADM_M009BL = new ZADM_M009BL();
                    strValue = zADM_M009BL.Update(Request);
                }
                else if (RequestOption == "WireTypeMaster")
                {
                    ZADM_M004BL zADM_M004BL = new ZADM_M004BL();
                    strValue = zADM_M004BL.Update(Request);
                }
                else if (RequestOption == "WithHoldingTaxMaster")
                {
                    ACC_M025_BL Acc_M025BL = new ACC_M025_BL();
                    strValue = Acc_M025BL.Update(Request);
                }
               
                else if (RequestOption == "Parameter_Master")
                {
                    ADM_M031BL aDM_M024 = new ADM_M031BL();
                    strValue = aDM_M024.Update(Request);
                }
                else if (RequestOption == "WireSizeMaster")
                {
                    ZADM_M003BL zADM_M003BL = new ZADM_M003BL();
                    strValue = zADM_M003BL.Update(Request);
                }
                else if (RequestOption == "SalesOffice")
                {
                    ADM_M001_I_BL aDM_M001_I_BL = new ADM_M001_I_BL();
                    strValue = aDM_M001_I_BL.Update(Request);
                }
                else if (RequestOption == "Warehouse")
                {
                    ADM_M011BL aDM_M011_BL = new ADM_M011BL();
                    strValue = aDM_M011_BL.Update(Request);
                }
                else if (RequestOption == "ParameterValueMaster")
                {
                    ADM_M030BL aDM_M030_BL = new ADM_M030BL();
                    strValue = aDM_M030_BL.Update(Request);
                }
                else if (RequestOption == "UOM_Master")
                {
                    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                    strValue = aDM_M038_BBL.Update(Request);
                }
                else if (RequestOption == "UOM_Conversion")
                {
                    ADM_M038_CBL aDM_M038_CBL = new ADM_M038_CBL();
                    strValue = aDM_M038_CBL.Update(Request);
                }
                else if (RequestOption == "InkMaster")
                {
                    ZADM_M006BL zADM_M006BL = new ZADM_M006BL();
                    strValue = zADM_M006BL.Update(Request);
                }
                else if (RequestOption == "UserMaster")
                {
                    ADM_M010BL aDM_M010 = new ADM_M010BL();
                    strValue = aDM_M010.Update(Request);
                }
                else if (RequestOption == "Tax_Master")
                {
                    ACC_M013BL aCC_M013BL = new ACC_M013BL();
                    strValue = aCC_M013BL.Update(Request);
                }
                else if (RequestOption == "UserSettings")
                {
                    SYS_S001BL sYS_S001BL = new SYS_S001BL();
                    strValue = sYS_S001BL.Update(Request);
                }
                else if (RequestOption == "UsedIn_Master")
                {
                    ZADM_M005BL zADM_M005BL = new ZADM_M005BL();
                    strValue = zADM_M005BL.Update(Request);
                }
                else if (RequestOption == "TotalLengthMaster")
                {
                    ZADM_M008BL zADM_M008BL = new ZADM_M008BL();
                    strValue = zADM_M008BL.Update(Request);
                }
                else if (RequestOption == "BallDiameterMaster")
                {
                    ZADM_M001BL zADM_M001BL = new ZADM_M001BL();
                    strValue = zADM_M001BL.Update(Request);
                }
                else if (RequestOption == "BallTypeMaster")
                {
                    ZADM_M002BL zADM_M002BL = new ZADM_M002BL();
                    strValue = zADM_M002BL.Update(Request);
                }
                else if (RequestOption == "FinishGoodMaster")
                {
                    ZADM_M010BL zADM_M010BL = new ZADM_M010BL();
                    strValue = zADM_M010BL.Update(Request);
                }
                else if (RequestOption == "MachineTypeMaster")
                {
                    ZADM_M011BL zADM_M011BL = new ZADM_M011BL();
                    strValue = zADM_M011BL.Update(Request);
                }
                else if (RequestOption == "MachineSubTypeMaster")
                {
                    ZADM_M012BL zADM_M012BL = new ZADM_M012BL();
                    strValue = zADM_M012BL.Update(Request);
                }
                else if (RequestOption == "WireSizeMaster")
                {
                    ZADM_M003BL zADM_M003BL = new ZADM_M003BL();
                    strValue = zADM_M003BL.Update(Request);
                }
                else if (RequestOption == "WireTypeMaster")
                {
                    ZADM_M004BL zADM_M004BL = new ZADM_M004BL();
                    strValue = zADM_M004BL.Update(Request);
                }

                else if (RequestOption == "MachineMaster")
                {
                    ZADM_M013BL zADM_M013BL = new ZADM_M013BL();
                    strValue = zADM_M013BL.Update(Request);
                }
                else if (RequestOption == "WritingTestMaster")
                {
                    ZADM_M014BL zADM_M014BL = new ZADM_M014BL();
                    strValue = zADM_M014BL.Update(Request);
                }
                else if (RequestOption == "DepartmentMaster")
                {
                    ADM_M025BL aDM_M025BL = new ADM_M025BL();
                    strValue = aDM_M025BL.Update(Request);
                }
                else if (RequestOption == "LabrotaryMaster")
                {
                    ADM_M003_BBL aDM_LAB_BL = new ADM_M003_BBL();
                    strValue = aDM_LAB_BL.Update(Request);
                }
                else if (RequestOption == "DesignationMaster")
                {
                    ADM_M026BL aDM_M026BL = new ADM_M026BL();
                    strValue = aDM_M026BL.Update(Request);
                }
                else if (RequestOption == "CountryMaster")
                {
                    ADM_M012BL aDM_M012BL = new ADM_M012BL();
                    strValue = aDM_M012BL.Update(Request);
                }
                else if (RequestOption == "LicenseMaster")
                {
                    ADM_M041BL aDM_M041BL = new ADM_M041BL();
                    strValue = aDM_M041BL.Update(Request);
                }
                else if (RequestOption == "GroupCompany")
                {
                    ADM_M001BL empBL = new ADM_M001BL();
                    strValue = empBL.Update(Request);
                }
                else if (RequestOption == "Company_Master")
                {
                    ADM_M002BL empBL = new ADM_M002BL();
                    strValue = empBL.Update(Request);
                }
                else if (RequestOption == "CompanyCatlog")
                {
                    //CRM_T001ABL empBL = new CRM_T001ABL();
                    //strValue = empBL.Update(Request);
                }
                else if (RequestOption == "PartyMaster")
                {
                    ADM_M028BL empBL = new ADM_M028BL();
                    strValue = empBL.Update(Request);
                }
                else if (RequestOption == "GeneralPartyMaster")
                {
                    ADM_M053BL empBL = new ADM_M053BL();
                    strValue = empBL.Update(Request);
                }
                else if (RequestOption == "PartyMasterCRM")
                {
                    ADM_M028_F_BL empBL = new ADM_M028_F_BL();
                    strValue = empBL.Update(Request);
                }
                else if (RequestOption == "MakeMaster")
                {
                    ADM_M032BL empBL = new ADM_M032BL();
                    strValue = empBL.Update(Request);
                }
                else if (RequestOption == "ContactMaster")
                {
                    ADM_M054BL ContactBL = new ADM_M054BL();
                    strValue = ContactBL.Update(Request);
                }
                //else if (RequestOption == "AuthorizationFieldMaster")
                //{
                //    ADM_M005BL aDM_M005 = new ADM_M005BL();

                //    strValue = aDM_M005.Update((Request));
                //}
                else if (RequestOption == "ViewMaster")
                {
                    ADM_M008BBL aDM_M008 = new ADM_M008BBL();
                    strValue = aDM_M008.Update(Request);
                }
                else if (RequestOption == "Employee_Master")
                {
                    ADM_M024BL aDM_M024 = new ADM_M024BL();
                    strValue = aDM_M024.Update(Request);
                }
                //else if (RequestOption == "ModuleGroupMaster")
                //{
                //    ADM_M006BL aDM_M006 = new ADM_M006BL();
                //    strValue = aDM_M006.Update(Request);
                //}

                //else if (RequestOption == "UserTypeMaster")
                //{
                //    ADM_M007BL aDM_M007 = new ADM_M007BL();
                //    strValue = aDM_M007.Update(Request);
                //}               
                else if (RequestOption == "RoleMaster")
                {
                    ADM_M009BL aDM_M009 = new ADM_M009BL();
                    strValue = aDM_M009.Update(Request);
                }
                //else if (RequestOption == "ActivityMaster")
                //{
                //    ADM_M004BL empBL = new ADM_M004BL();
                //    strValue = empBL.Update(Request);
                //}
                else if (RequestOption == "CategoryMaster")
                {
                    ADM_M018BL calBL = new ADM_M018BL();
                    strValue = calBL.Update(Request);
                }
                else if (RequestOption == "SubCategoryMaster")
                {
                    ADM_M019BL calBL = new ADM_M019BL();
                    strValue = calBL.Update(Request);
                }
                else if (RequestOption == "ItemMaster")
                {
                    ADM_M022BL calBL = new ADM_M022BL();
                    strValue = calBL.Update(Request);
                }
                else if (RequestOption == "CatParameterMaster")
                {
                    ADM_M034BL calBL = new ADM_M034BL();
                    strValue = calBL.Update(Request);
                }
                else if (RequestOption == "PaymentTerms")
                {
                    ACC_M007BL aCC_M007BL = new ACC_M007BL();
                    strValue = aCC_M007BL.Update(Request);
                }
                //else if (RequestOption == "FluteMaster")
                //{
                //    ADM_M030BL aDM_M030 = new ADM_M030BL();
                //    strValue = aDM_M030.Update(Request);
                //}
                //else if (RequestOption == "ShadeMaster")
                //{
                //    ADM_M031BL aDM_M031 = new ADM_M031BL();
                //    strValue = aDM_M031.Update(Request);
                //}
                //else if (RequestOption == "ColourMaster")
                //{
                //    ADM_M033BL aDM_M033 = new ADM_M033BL();
                //    strValue = aDM_M033.Update(Request);
                //}
                //else if (RequestOption == "GeneralMaster")
                //{
                //    CAL_M006BL calBL = new CAL_M006BL();
                //    strValue = calBL.Update(Request);
                //}
                //else if (RequestOption == "RigMaster")
                //{
                //    //CAL_M008BL calBL = new CAL_M008BL();
                //    //strValue = calBL.Update(Request);
                //}
                //else if (RequestOption == "MeasurementClass")
                //{
                //    CAL_M009BL cAL_M009 = new CAL_M009BL();
                //    strValue = cAL_M009.Update(Request);
                //}

                //else if (RequestOption == "BaseUnitMaster")
                //{
                //    CAL_M011BL cAL_M011 = new CAL_M011BL();
                //    strValue = cAL_M011.Update(Request);
                //}
                //else if (RequestOption == "ExternalInstrumentMaster")
                //{
                //    CAL_M004ABL calBL = new CAL_M004ABL();
                //    strValue = calBL.Update(Request);
                //}

                else if (RequestOption == "ItemTypeMaster")
                {
                    ADM_M015BL calBL = new ADM_M015BL();
                    strValue = calBL.Update(Request);
                }
                else if (RequestOption == "SubItmTpMaster")
                {
                    ADM_M016BL calBL = new ADM_M016BL();
                    strValue = calBL.Update(Request);
                }

                else if (RequestOption == "AllocationMaster")
                {
                    ADM_M036BL conBL = new ADM_M036BL();
                    strValue = conBL.Update(Request);
                }
                else if (RequestOption == "LocationMaster")
                {
                    ADM_M003BL conBL = new ADM_M003BL();
                    strValue = conBL.Update(Request);
                }
                else if (RequestOption == "ILDMaster")
                {
                    ZADM_M007BL conBL = new ZADM_M007BL();
                    strValue = conBL.Update(Request);
                }

                else if (RequestOption == "StateMaster")
                {
                    ADM_M013BL aDM_M013 = new ADM_M013BL();
                    strValue = aDM_M013.Update(Request);
                }
                else if (RequestOption == "WorkFlowMaster")
                {
                    ADM_M043BL aDM_M043BL = new ADM_M043BL();
                    strValue = aDM_M043BL.Update(Request);
                }
                else if (RequestOption == "InkCatalog")
                {
                    ZADM_M026BL zADM_M026BL = new ZADM_M026BL();
                    strValue = zADM_M026BL.Update(Request);
                }
                else if (RequestOption == "RateMaster")
                {
                    ZADM_M027BL zADM_M027BL = new ZADM_M027BL();
                    strValue = zADM_M027BL.Update(Request);
                }
                else if (RequestOption == "HS_CodeMaster")
                {
                    ADM_M022_A_BL aDM_M022_A_BL = new ADM_M022_A_BL();
                    strValue = aDM_M022_A_BL.Update(Request);
                }
                //------------------------ Calibration ---------
                else if (RequestOption == "InstrumentMaster")
                {
                    QMS_M003BL calBL = new QMS_M003BL();
                    strValue = calBL.Update(Request);
                }
                else if (RequestOption == "InstrumentGroupMaster")
                {
                    QMS_M001BL cAL_M001BL = new QMS_M001BL();
                    strValue = cAL_M001BL.Update(Request);
                }
                else if (RequestOption == "InstrumentSubGroupMaster")
                {
                    QMS_M002BL cAL_M002BL = new QMS_M002BL();
                    strValue = cAL_M002BL.Update(Request);
                }
                else if (RequestOption == "RigMaster")
                {
                    QMS_M008BL cAL_M008BL = new QMS_M008BL();
                    strValue = cAL_M008BL.Update(Request);
                }
                else if (RequestOption == "TestIdentificationMaster")
                {
                    QMS_M009BL cAL_M009BL = new QMS_M009BL();
                    strValue = cAL_M009BL.Update(Request);
                }

                else if (RequestOption == "TestProcedure")
                {
                    QMS_M006BL cAL_M006BL = new QMS_M006BL();
                    strValue = cAL_M006BL.Update(Request);
                }

                else if (RequestOption == "WorkInstruction")
                {
                    QMS_M007BL cAL_M007BL = new QMS_M007BL();
                    strValue = cAL_M007BL.Update(Request);
                }

                else if (RequestOption == "TDS_Parameter")
                {
                    ENG_T003BL eNG_T003BL = new ENG_T003BL();
                    strValue = eNG_T003BL.Update(Request);
                }
                else if (RequestOption == "Sion_Master")
                {
                    ADM_M041_B_BL aDM_M041_B = new ADM_M041_B_BL();
                    strValue = aDM_M041_B.Update(Request);
                }
                else if (RequestOption == "CompanyCondition")
                {
                    ADM_M002_A_BL _ADM_M002_A_BL = new ADM_M002_A_BL();
                    strValue = _ADM_M002_A_BL.Update(Request);
                }
                else if (RequestOption == "GroupMaster")
                {
                    ADM_M058_BL _ADM_M058_BL = new ADM_M058_BL();
                    strValue = _ADM_M058_BL.Update(Request);
                }
                else if (RequestOption == "ProfitCenterMaster")
                {
                    ACC_M020_BL _ACC_M020_BL = new ACC_M020_BL();
                    strValue = _ACC_M020_BL.Update(Request);
                }
                else if (RequestOption == "CostCenterMaster")
                {
                    ACC_M019_BL _ACC_M019_BL = new ACC_M019_BL();
                    strValue = _ACC_M019_BL.Update(Request);
                }
                else if (RequestOption == "AddressMaster")
                {
                    ADM_M055_BL _Adm_M055_BL = new ADM_M055_BL();
                    strValue = _Adm_M055_BL.Update(Request);
                }
                else if (RequestOption == "CommunicationMaster")
                {
                    ADM_M057_BL _Adm_M057_BL = new ADM_M057_BL();
                    strValue = _Adm_M057_BL.Update(Request);
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
                if (RequestOption == "Employee_Master")
                {
                    ADM_M024BL empBL = new ADM_M024BL();
                    strValue = empBL.Delete(Request);
                }
                else if (RequestOption == "UOM_Conversion")
                {
                    ADM_M038_CBL aDM_M038_CBL = new ADM_M038_CBL();
                    strValue = aDM_M038_CBL.Delete(Request);
                }
                else if (RequestOption == "PartyMaster")
                {
                  ADM_M028BL empBL = new ADM_M028BL();
                    strValue = empBL.Delete(Request);
                }
                else if (RequestOption == "RoleMaster")
                {
                    ADM_M009BL aDM_M009 = new ADM_M009BL();
                    strValue = aDM_M009.Delete(Request);
                }

             
                //else if (RequestOption == "DepartmentMaster")
                //{
                //    ADM_M025BL aDM_M025BL = new ADM_M025BL();
                //    strValue = aDM_M025BL.Delete(Request);
                //}
                //else if (RequestOption == "DesignationMaster")
                //{
                //    ADM_M026BL aDM_M026BL = new ADM_M026BL();
                //    strValue = aDM_M026BL.Delete(Request);
                //}
                else if (RequestOption == "ParameterValueMaster")
                {
                    ADM_M030BL aDM_M030_BL = new ADM_M030BL();
                    strValue = aDM_M030_BL.Delete(Request);
                }
                else if (RequestOption == "Parameter_Master")
                {
                    ADM_M031BL zADM_M003BL = new ADM_M031BL();
                    strValue = zADM_M003BL.Delete(Request);
                }
                else if (RequestOption == "CatParameterMaster")
                {
                    ADM_M034BL calBL = new ADM_M034BL();
                    strValue = calBL.Delete(Request);
                }
                else if (RequestOption == "CountryMaster")
                {
                    ADM_M012BL aDM_M012BL = new ADM_M012BL();
                    strValue = aDM_M012BL.Delete(Request);
                }
                else if (RequestOption == "UserMaster")
                {
                    ADM_M010BL aDM_M010 = new ADM_M010BL();
                    strValue = aDM_M010.Delete(Request);
                }
                else if (RequestOption == "ViewMaster")
                {
                    ADM_M008BBL aDM_M008B = new ADM_M008BBL();
                    strValue = aDM_M008B.Delete(Request);
                }
                else if (RequestOption == "ItemTypeMaster")
                {
                    ADM_M015BL calBL = new ADM_M015BL();
                    strValue = calBL.Delete(Request);
                }
                else if (RequestOption == "StateMaster")
                {
                    ADM_M013BL aDM_M013 = new ADM_M013BL();
                    strValue = aDM_M013.Delete(Request);
                }
                else if (RequestOption == "CategoryMaster")
                {
                    ADM_M018BL calBL = new ADM_M018BL();
                    strValue = calBL.Delete(Request);
                }

                else if (RequestOption == "SubCategoryMaster")
                {
                    ADM_M019BL calBL = new ADM_M019BL();
                    strValue = calBL.Delete(Request);
                }

                if (RequestOption == "SubItmTpMaster")
                {
                    ADM_M016BL calBL = new ADM_M016BL();
                    strValue = calBL.Delete(Request);
                }
                else if (RequestOption == "UOM_Master")
                {
                    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                    strValue = aDM_M038_BBL.Delete(Request);
                }

                else if (RequestOption == "GroupCompany")
                {
                    ADM_M001BL empBL = new ADM_M001BL();
                    strValue = empBL.Delete(Request);
                }

                else if (RequestOption == "Company_Master")
                {
                    ADM_M002BL empBL = new ADM_M002BL();
                    strValue = empBL.Delete(Request);
                }
                else if (RequestOption == "LocationMaster")
                {
                    ADM_M003BL aDM_M003BL = new ADM_M003BL();
                    strValue = aDM_M003BL.Delete(Request);
                }

                else if (RequestOption == "WorkFlowMaster")
                {
                    ADM_M043BL aDM_M043BL = new ADM_M043BL();
                    strValue = aDM_M043BL.Delete(Request);
                }
                else if (RequestOption == "RateMaster")
                {
                    ZADM_M027BL zADM_M027BL = new ZADM_M027BL();
                    strValue = zADM_M027BL.Delete(Request);
                }
                else if (RequestOption == "PaymentTerms")
                {
                    ACC_M007BL aCC_M007BL = new ACC_M007BL();
                    strValue = aCC_M007BL.Delete(Request);
                }                
                //else if (RequestOption == "SickDeclaration")
                //{
                //    CAL_T002BL empBL = new CAL_T002BL();
                //    strValue = empBL.Delete(Request);
                //}               

                //else if (RequestOption == "AuthorizationFieldMaster")
                //{
                //    ADM_M005BL aDM_M005 = new ADM_M005BL();

                //    strValue = aDM_M005.Delete((Request));
                //}


                //else if (RequestOption == "ModuleGroupMaster")
                //{
                //    ADM_M006BL aDM_M006 = new ADM_M006BL();
                //    strValue = aDM_M006.Delete(Request);
                //}


                //else if (RequestOption == "CategoryMaster")
                //{
                //    ADM_M018BL calBL = new ADM_M018BL();
                //    strValue = calBL.Delete(Request);
                //}
                //else if (RequestOption == "SubCategoryMaster")
                //{
                //    ADM_M019BL calBL = new ADM_M019BL();
                //    strValue = calBL.Delete(Request);
                //}                


                //else if (RequestOption == "ColourMaster")
                //{
                //    ADM_M033BL aDM_M033 = new ADM_M033BL();
                //    strValue = aDM_M033.Delete(Request);
                //}
                //else if (RequestOption == "RigMaster")
                //{
                //    //CAL_M008BL calBL = new CAL_M008BL();
                //    //strValue = calBL.Delete(Request);
                //}
                //else if (RequestOption == "MeasurementClass")
                //{
                //    CAL_M009BL cAL_M009 = new CAL_M009BL();
                //    strValue = cAL_M009.Delete(Request);
                //}


                //else if (RequestOption == "ItemTypeMaster")
                //{
                //    ADM_M015BL calBL = new ADM_M015BL();
                //    strValue = calBL.Delete(Request);
                //}
                //if (RequestOption == "SubItmTpMaster")
                //{
                //    ADM_M016BL calBL = new ADM_M016BL();
                //    strValue = calBL.Delete(Request);
                //}

                //else if (RequestOption == "AllocationMaster")
                //{
                //    ADM_M036BL conBL = new ADM_M036BL();
                //    strValue = conBL.Insert(Request);
                //}   
                //------------------------ Calibration ---------
                else if (RequestOption == "InstrumentGroupMaster")
                {
                    QMS_M001BL cAL_M001BL = new QMS_M001BL();
                    strValue = cAL_M001BL.Delete(Request);
                }
                else if (RequestOption == "InstrumentSubGroupMaster")
                {
                    QMS_M002BL cAL_M002BL = new QMS_M002BL();
                    strValue = cAL_M002BL.Delete(Request);
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
               
                 if (RequestOption == "ModelMaster")
                {
                    ZADM_M009BL zADM_M009BL = new ZADM_M009BL();
                   // strValue = zADM_M009BL.Delete(Request);
                }
                    
                else if (RequestOption == "WireTypeMaster")
                {
                    ZADM_M004BL zADM_M004BL = new ZADM_M004BL();
                    strValue = zADM_M004BL.Delete(Request);
                }

              
                else if (RequestOption == "WireSizeMaster")
                {
                    ZADM_M003BL zADM_M003BL = new ZADM_M003BL();
                    strValue = zADM_M003BL.Delete(Request);
                }
                
                else if (RequestOption == "Warehouse")
                {
                    ADM_M011BL aDM_M011_BL = new ADM_M011BL();
                    strValue = aDM_M011_BL.Delete(Request);
                }
                else if (RequestOption == "InkCatalog")
                {
                    ZADM_M026BL zADM_M026BL = new ZADM_M026BL();
                    strValue = zADM_M026BL.Delete(Request);
                }



                //else if (RequestOption == "InstrumentMaster")
                //{
                //    CAL_M003BL calBL = new CAL_M003BL();
                //    strValue = calBL.Delete(Request);
                //}
                //else if (RequestOption == "ExternalInstrumentMaster")
                //{
                //    CAL_M004ABL calBL = new CAL_M004ABL();
                //    strValue = calBL.Delete(Request);
                //}
                else if (RequestOption == "InkMaster")
                {
                    ZADM_M006BL zADM_M006BL = new ZADM_M006BL();
                    strValue = zADM_M006BL.Delete(Request);
                }
                else if (RequestOption == "UsedIn_Master")
                {
                    ZADM_M005BL zADM_M005BL = new ZADM_M005BL();
                    strValue = zADM_M005BL.Delete(Request);
                }
                else if (RequestOption == "TotalLengthMaster")
                {
                    ZADM_M008BL zADM_M008BL = new ZADM_M008BL();
                    strValue = zADM_M008BL.Delete(Request);
                }
                else if (RequestOption == "BallDiameterMaster")
                {
                    ZADM_M001BL zADM_M001BL = new ZADM_M001BL();
                    strValue = zADM_M001BL.Delete(Request);
                }
                else if (RequestOption == "BallTypeMaster")
                {
                    ZADM_M002BL zADM_M002BL = new ZADM_M002BL();
                    strValue = zADM_M002BL.Delete(Request);
                }
                else if (RequestOption == "FinishGoodMaster")
                {
                    ZADM_M010BL zADM_M010BL = new ZADM_M010BL();
                    //strValue = zADM_M010BL.Delete(Request);
                }
                else if (RequestOption == "MachineTypeMaster")
                {
                    ZADM_M011BL zADM_M011BL = new ZADM_M011BL();
                    strValue = zADM_M011BL.Delete(Request);
                }
                else if (RequestOption == "MachineSubTypeMaster")
                {
                    ZADM_M012BL zADM_M012BL = new ZADM_M012BL();
                    strValue = zADM_M012BL.Delete(Request);
                }
                else if (RequestOption == "MachineMaster")
                {
                    ZADM_M013BL zADM_M013BL = new ZADM_M013BL();
                    strValue = zADM_M013BL.Delete(Request);
                }
                else if (RequestOption == "WritingTestMaster")
                {
                    ZADM_M014BL zADM_M014BL = new ZADM_M014BL();
                    strValue = zADM_M014BL.Delete(Request);
                }
                
                
          
                


                //else if (RequestOption == "PartyMaster")
                //{
                //  ADM_M028BL empBL = new ADM_M028BL();
                //    strValue = empBL.Delete(Request);
                //}

                //else if (RequestOption == "MakeMaster")
                //{
                //    ADM_M032BL empBL = new ADM_M032BL();
                //    strValue = empBL.Delete(Request);
                //}
                //else if (RequestOption == "ItemMaster")
                //{
                //    ADM_M022BL calBL = new ADM_M022BL();
                //    strValue = calBL.Delete(Request);
                //}


                //else if (RequestOption == "UserTypeMaster")
                //{
                //    ADM_M007BL aDM_M007 = new ADM_M007BL();
                //    strValue = aDM_M007.Delete(Request);
                //}
                //else if (RequestOption == "FluteMaster")
                //{
                //    ADM_M030BL aDM_M030 = new ADM_M030BL();
                //    strValue = aDM_M030.Delete(Request);
                //}
                //else if (RequestOption == "ShadeMaster")
                //{
                //    ADM_M031BL aDM_M031 = new ADM_M031BL();
                //    strValue = aDM_M031.Delete(Request);
                //}
                //else if (RequestOption == "ActivityMaster")
                //{
                //    ADM_M004BL empBL = new ADM_M004BL();
                //    strValue = empBL.Delete(Request);
                //}
                //else if (RequestOption == "BaseUnitMaster")
                //{
                //    CAL_M011BL cAL_M011 = new CAL_M011BL();
                //    strValue = cAL_M011.Delete(Request);
                //}

                else if (RequestOption == "AllocationMaster")
                {
                    ADM_M036BL conBL = new ADM_M036BL();
                    strValue = conBL.Delete(Request);
                }
                else if (RequestOption == "ILDMaster")
                {
                    ZADM_M007BL conBL = new ZADM_M007BL();
                    strValue = conBL.Delete(Request);
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
            string strval = "";
            try
            {
                if (RequestOption == "EmployeeMaster")
                {
                    //EmployeeBL empBL = new EmployeeBL();
                    //strval = empBL.GetData(Request, RequestOption);
                }
                else if (RequestOption == "GetAllFiles")
                {
                    ReflectionFileHandlingServices objFileList = new ReflectionFileHandlingServices();
                    strval = objFileList.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ModelMaster")
                {
                    ZADM_M009BL zADM_M009BL = new ZADM_M009BL();
                    strval = zADM_M009BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SalesOffice")
                {
                    ADM_M001_I_BL aDM_M001_I_BL = new ADM_M001_I_BL();
                    strval = aDM_M001_I_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "WireTypeMaster")
                {
                    ZADM_M004BL zADM_M004BL = new ZADM_M004BL();
                    strval = zADM_M004BL.GetData();
                }
                else if (RequestOption == "WireSizeMaster")
                {
                    ZADM_M003BL zADM_M003BL = new ZADM_M003BL();
                    strval = zADM_M003BL.GetData();
                }
                else if (RequestOption == "Parameter_Master")
                {
                    ADM_M031BL aDM_M024 = new ADM_M031BL();
                    strval = aDM_M024.GetData();
                }
                else if (RequestOption == "SalesDivision")
                {
                    ADM_M001_D_BL aDM_M001_D = new ADM_M001_D_BL();
                    strval = aDM_M001_D.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SetUpSalesArea")
                {
                    ADM_M001_K_BL aDM_M001_K = new ADM_M001_K_BL();
                    strval = aDM_M001_K.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "WithHoldingTaxMaster")
                {
                    ACC_M025_BL acc_M025 = new ACC_M025_BL();
                    strval = acc_M025.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "AssignPurGroupToPurOrg")
                {
                    ADM_M001_Q_BL aDM_M001_Q = new ADM_M001_Q_BL();
                    strval = aDM_M001_Q.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssignPlantToSalesOrg_DistriChannel")
                {
                    ADM_M001_G_BL aDM_M001_G = new ADM_M001_G_BL();
                    strval = aDM_M001_G.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Warehouse")
                {
                    ADM_M011BL aDM_M011_BL = new ADM_M011BL();
                    strval = aDM_M011_BL.GetData();
                }
                else if (RequestOption == "ParameterValueMaster")
                {
                    ADM_M030BL aDM_M030 = new ADM_M030BL();
                    strval = aDM_M030.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "UserVerification")
                {
                    UserVerificationBL userBL = new UserVerificationBL();
                    strval = userBL.GetData(Request);
                }
                else if (RequestOption == "UOM_Master")
                {
                    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                    strval = aDM_M038_BBL.GetData();
                }
                else if (RequestOption == "UOM_Conversion")
                {
                    ADM_M038_CBL aDM_M038_CBL = new ADM_M038_CBL();
                    strval = aDM_M038_CBL.GetData(strType);
                }

                else if (RequestOption == "InkMaster")
                {
                    ZADM_M006BL zADM_M006BL = new ZADM_M006BL();
                    strval = zADM_M006BL.GetData();
                }
                else if (RequestOption == "Tax_Master")
                {
                    ACC_M013BL aCC_M013BL = new ACC_M013BL();
                    strval = aCC_M013BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "UserSettings")
                {
                    SYS_S001BL sYS_S001BL = new SYS_S001BL();
                    strval = sYS_S001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "LicenseMaster")
                {
                    ADM_M041BL aDM_M041BL = new ADM_M041BL();
                    strval = aDM_M041BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "salesorgassigncompany")
                {
                    ADM_M001_B_BL aDM_M001_B_BL = new ADM_M001_B_BL();
                    strval = aDM_M001_B_BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "CompanyCatlog")
                //{
                //    //CRM_T001ABL empBL = new CRM_T001ABL();
                //    //strval = empBL.GetData();
                //}
                else if (RequestOption == "PaymentTerms")
                {
                    ACC_M007BL aCC_M007BL = new ACC_M007BL();
                    strval = aCC_M007BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "FinishGoodMaster")
                {
                    ZADM_M010BL zADM_M010BL = new ZADM_M010BL();
                    strval = zADM_M010BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GroupCompany")
                {
                    ADM_M001BL empBL = new ADM_M001BL();
                    strval = empBL.GetData();
                }

                else if (RequestOption == "Company_Master")
                {
                    ADM_M002BL empBL = new ADM_M002BL();
                    strval = empBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PartyMaster")
                {
                    ADM_M028BL empBL = new ADM_M028BL();
                    strval = empBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GeneralPartyMaster")
                {
                    ADM_M053BL empBL = new ADM_M053BL();
                    strval = empBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PartyMasterCRM")
                {
                    ADM_M028_F_BL empBL = new ADM_M028_F_BL();
                    strval = empBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ContactMaster")
                {
                    ADM_M054BL ContactBL = new ADM_M054BL();
                    strval = ContactBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "InkCatalog")
                {
                    ZADM_M026BL zADM_M026BL = new ZADM_M026BL();
                    strval = zADM_M026BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "RateMaster")
                {
                    ZADM_M027BL zADM_M027BL = new ZADM_M027BL();
                    strval = zADM_M027BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MakeMaster")
                {
                    ADM_M032BL empBL = new ADM_M032BL();
                    strval = empBL.GetData(Request, strType, intValue, strValue);
                }
              
                else if (RequestOption == "Employee_Master")
                {
                    ADM_M024BL aDM_M024 = new ADM_M024BL();
                    strval = aDM_M024.GetData(Request, strType, intValue, strValue);
                }
               
                else if (RequestOption == "ViewMaster")
                {
                    ADM_M008BBL aDM_M008B = new ADM_M008BBL();
                    strval = aDM_M008B.GetData();
                }
                else if (RequestOption == "UserMaster")
                {
                    ADM_M010BL aDM_M010 = new ADM_M010BL();
                    strval = aDM_M010.GetData();
                }
                
                else if (RequestOption == "UsedIn_Master")
                {
                    ZADM_M005BL calBL = new ZADM_M005BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "TotalLengthMaster")
                {
                    ZADM_M008BL calBL = new ZADM_M008BL();
                    strval = calBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BallDiameterMaster")
                {
                    ZADM_M001BL calBL = new ZADM_M001BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "BallTypeMaster")
                {
                    ZADM_M002BL calBL = new ZADM_M002BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "MachineTypeMaster")
                {
                    ZADM_M011BL calBL = new ZADM_M011BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "MachineSubTypeMaster")
                {
                    ZADM_M012BL calBL = new ZADM_M012BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "MachineMaster")
                {
                    ZADM_M013BL calBL = new ZADM_M013BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "WritingTestMaster")
                {
                    ZADM_M014BL calBL = new ZADM_M014BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "DepartmentMaster")
                {
                    ADM_M025BL calBL = new ADM_M025BL();
                    strval = calBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "DesignationMaster")
                {
                    ADM_M026BL calBL = new ADM_M026BL();
                    strval = calBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CountryMaster")
                {
                    ADM_M012BL calBL = new ADM_M012BL();
                    strval = calBL.GetData();
                }

                else if (RequestOption == "SubCategoryMaster")
                {
                    ADM_M019BL calBL = new ADM_M019BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "CategoryMaster")
                {
                    ADM_M018BL calBL = new ADM_M018BL();
                    strval = calBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ItemMaster")
                {
                    ADM_M022BL calBL = new ADM_M022BL();
                    strval = calBL.GetData(Request, strType, intValue, strValue);
                    //strval = calBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "CatParameterMaster")
                {
                    ADM_M034BL aDM_M034 = new ADM_M034BL();
                    //strval = calBL.GetData();
                    strval = aDM_M034.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "CatParameterMaster")
                //{
                //    ADM_M034BL calBL = new ADM_M034BL();
                //    strval = calBL.GetData();
                //}
                else if (RequestOption == "AllocationMaster")
                {
                    ADM_M036BL conBL = new ADM_M036BL();
                    if (strType == "LoadOnParameter")
                    {
                        strval = conBL.GetData(intValue);
                    }
                    else
                    {
                        strval = conBL.GetData();
                    }
                }
                else if (RequestOption == "InstrumentMaster")
                {
                    QMS_M003BL cAL_M003BL = new QMS_M003BL();
                    strval = cAL_M003BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TestIdentificationMaster")
                {
                    QMS_M009BL cAL_M009BL = new QMS_M009BL();
                    strval = cAL_M009BL.GetData(Request, strType, intValue, strValue);
                }
               
                else if (RequestOption == "RoleMaster")
                {
                    ADM_M009BL aDM_M009 = new ADM_M009BL();
                    strval = aDM_M009.GetData();
                }
                else if (RequestOption == "Sion_Master")
                {
                    ADM_M041_B_BL aDM_M041_B = new ADM_M041_B_BL();
                    strval = aDM_M041_B.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssignItemCategoryToDocumentType")
                {
                    SYS_M023_BL _SYS_M023 = new SYS_M023_BL();
                    strval = _SYS_M023.GetData(Request, strType, intValue, strValue);
                }


                
                else if (RequestOption == "ItemTypeMaster")
                {
                    ADM_M015BL calBL = new ADM_M015BL();
                    strval = calBL.GetData();
                }
                else if (RequestOption == "SubItmTpMaster")
                {
                    ADM_M016BL calBL = new ADM_M016BL();
                    strval = calBL.GetData();
                }
                

                else if (RequestOption == "LocationMaster")
                {
                    ADM_M003BL locBL = new ADM_M003BL();
                    strval = locBL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "ILDMaster")
                {
                    ZADM_M007BL conBL = new ZADM_M007BL();
                    strval = conBL.GetData();
                }
                else if (RequestOption == "StateMaster")
                {
                    ADM_M013BL aDM_M013 = new ADM_M013BL();
                    strval = aDM_M013.GetData();
                }
                else if (RequestOption == "AllocationMaster")
                {
                    ADM_M036BL conBL = new ADM_M036BL();
                    if (strType == "LoadOnParameter")
                    {
                        strval = conBL.GetData(intValue);
                    }
                    else
                    {
                        strval = conBL.GetData();
                    }
                }
                else if (RequestOption == "WorkFlowMaster")
                {
                    ADM_M043BL aDM_M043BL = new ADM_M043BL();
                    strval = aDM_M043BL.GetData(strType, intValue, strValue);
                }
                // ------------------------ Calibration ---------
                else if (RequestOption == "LabrotaryMaster")
                {
                    ADM_M003_BBL aDM_LAB_BL = new ADM_M003_BBL();
                    strval = aDM_LAB_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "InstrumentGroupMaster")
                {
                    QMS_M001BL cAL_M001BL = new QMS_M001BL();
                    //strval = cAL_M001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "InstrumentSubGroupMaster")
                {
                    QMS_M002BL cAL_M002BL = new QMS_M002BL();
                    strval = cAL_M002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "RigMaster")
                {
                    QMS_M008BL cAL_M008BL = new QMS_M008BL();
                    strval = cAL_M008BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TestProcedure")
                {
                    QMS_M006BL cAL_M006BL = new QMS_M006BL();
                    strval = cAL_M006BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "WorkInstruction")
                {
                    QMS_M007BL cAL_M007BL = new QMS_M007BL();
                    strval = cAL_M007BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "TDS_Parameter")
                {
                    ENG_T003BL eNG_T003BL = new ENG_T003BL();
                    strval = eNG_T003BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "HS_CodeMaster")
                {
                    ADM_M022_A_BL aDM_M022_A_BL = new ADM_M022_A_BL();
                    strval = aDM_M022_A_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "SalesOrganisationMaster")
                {
                    ADM_M001_A_BL _ADM_M001_A_BL = new ADM_M001_A_BL();
                    strval = _ADM_M001_A_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "SalesGroupMaster")
                {
                    ADM_M001_H_BL _ADM_M001_H_BL = new ADM_M001_H_BL();
                    strval = _ADM_M001_H_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseOrganisationMaster")
                {
                    ADM_M001_M_BL _ADM_M001_M_BL = new ADM_M001_M_BL();
                    strval = _ADM_M001_M_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "PurchaseGroupMaster")
                {
                    ADM_M001_P_BL _ADM_M001_P_BL = new ADM_M001_P_BL();
                    strval = _ADM_M001_P_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BusinessPlaceMaster")
                {
                    ADM_M003_C_BL _ADM_M003_C_BL = new ADM_M003_C_BL();
                    strval = _ADM_M003_C_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseOrgAssignToPlant")
                {
                    ADM_M001_O1_BL _ADM_M001_O1_BL = new ADM_M001_O1_BL();
                    strval = _ADM_M001_O1_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SalesDistributionChannel")
                {
                    ADM_M001_C_BL _ADM_M001_C_BL = new ADM_M001_C_BL();
                    strval = _ADM_M001_C_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssignDivisionToSO")
                {
                    ADM_M001_F_BL _ADM_M001_F_BL = new ADM_M001_F_BL();
                    strval = _ADM_M001_F_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssignDistributionChannelToSO")
                {
                    ADM_M001_E_BL _ADM_M001_E_BL = new ADM_M001_E_BL();
                    strval = _ADM_M001_E_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "AssignSalesOfficeToSalesArea")
                {
                    ADM_M001_L_BL _ADM_M001_L_BL = new ADM_M001_L_BL();
                    strval = _ADM_M001_L_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CompanyCondition")
                {
                    ADM_M002_A_BL _ADM_M002_A_BL = new ADM_M002_A_BL();
                    strval = _ADM_M002_A_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GroupMaster")
                {
                    ADM_M058_BL _ADM_M058_BL = new ADM_M058_BL();
                    strval = _ADM_M058_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PartyBankMaster")
                {
                    ADM_M028_E_BL _ADM_M028_E_BL = new ADM_M028_E_BL();
                    strval = _ADM_M028_E_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PartyCondition")
                {
                    ADM_M028_H_BL _ADM_M028_H_BL = new ADM_M028_H_BL();
                    strval = _ADM_M028_H_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "WithholdingTaxforParty")
                {
                    ADM_M028_I_BL ADM_M028_I = new ADM_M028_I_BL();
                    strval = ADM_M028_I.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "StatusMaster")
                {
                    SYS_M025_BL SYS_M025 = new SYS_M025_BL();
                    strval = SYS_M025.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssignSalesGroupToSalesOffice")
                {
                    ADM_M001_J_BL aDM_M001_J = new ADM_M001_J_BL();
                    strval = aDM_M001_J.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ProfitCenterMaster")
                {
                    ACC_M020_BL aCC_M020 = new ACC_M020_BL();
                    strval = aCC_M020.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CostCenterMaster")
                {
                    ACC_M019_BL aCC_M019 = new ACC_M019_BL();
                    strval = aCC_M019.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AddressMaster")
                {
                    ADM_M055_BL adm_M055 = new ADM_M055_BL();
                    strval = adm_M055.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CommunicationMaster")
                {
                    ADM_M057_BL adm_M057 = new ADM_M057_BL();
                    strval = adm_M057.GetData(Request, strType, intValue, strValue);
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
