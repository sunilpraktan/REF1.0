using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
  public  class ReflectionFinanceBL
    {

        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "PaymentEntry")
                {
                    ACC_T001BL aCC_T001BL = new ACC_T001BL();
                    strValue = aCC_T001BL.Insert(Request);
                }
                else if (RequestOption == "PaymentProcess")
                {
                    ACC_T001BL_PaymentPocess aCC_T001_PayProcessBL = new ACC_T001BL_PaymentPocess();
                    strValue = aCC_T001_PayProcessBL.Insert(Request);
                }
                else if (RequestOption == "ACC_T001_STD_IN")
                {
                    ACC_T001_STD_BL aCC_T001_PayProcessBL = new ACC_T001_STD_BL();
                    strValue = aCC_T001_PayProcessBL.Insert(Request);
                }
                else if (RequestOption == "JournalVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Insert(Request);
                }
                else if (RequestOption == "AccountingDocument")
                {
                    ACC_T006BL aCC_T002BL_2 = new ACC_T006BL();
                    strValue = aCC_T002BL_2.Insert(Request);
                }
                else if (RequestOption == "ExpensesVoucher")
                {
                    ACC_T003BL aCC_T003BL = new ACC_T003BL();
                    strValue = aCC_T003BL.Insert(Request);
                }
                else if (RequestOption == "Opening_Balance")
                {
                    ACC_T004BL aCC_T004BL = new ACC_T004BL();
                    strValue = aCC_T004BL.Insert(Request);
                }
                else if (RequestOption == "ExpectedPayment")
                {
                    ACC_T005BL aCC_T005BL = new ACC_T005BL();
                    strValue = aCC_T005BL.Insert(Request);
                }
                else if (RequestOption == "CashVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Insert(Request);
                }

                else if (RequestOption == "ContraVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Insert(Request);
                }

                else if (RequestOption == "BankVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Insert(Request);
                }

                else if (RequestOption == "AccountDeterminationKey")
                {
                    ACC_M003_T_BL aCC_M003_T_BL = new ACC_M003_T_BL();
                    strValue = aCC_M003_T_BL.Insert(Request);
                }
                else if (RequestOption == "AccountModifierForMT")
                {
                    ACC_M003_X_BL aCC_M003_X_BL = new ACC_M003_X_BL();
                    strValue = aCC_M003_X_BL.Insert(Request);
                }
                else if (RequestOption == "PricingProcedure")
                {
                    ACC_M003_N_BL aCC_M003_N_BL = new ACC_M003_N_BL();
                    strValue = aCC_M003_N_BL.Insert(Request);
                }
                else if (RequestOption == "TaxConditionMaster")
                {
                    ACC_M003_O_BL aCC_M003_O_BL = new ACC_M003_O_BL();
                    strValue = aCC_M003_O_BL.Insert(Request);
                }

                else if (RequestOption == "PostingKeyMaster")
                {
                    ACC_M003_Q_BL aCC_M003_Q_BL = new ACC_M003_Q_BL();
                    strValue = aCC_M003_Q_BL.Insert(Request);
                }
                else if (RequestOption == "DefinePostingKey")
                {
                    ACC_M003_I_BL aCC_M003_I_BL = new ACC_M003_I_BL();
                    strValue = aCC_M003_I_BL.Insert(Request);
                }
                else if (RequestOption == "AccountDetermination_Revenue")
                {
                    ACC_M003_Y_BL aCC_M003_Y_BL = new ACC_M003_Y_BL();
                    strValue = aCC_M003_Y_BL.Insert(Request);
                }
                else if (RequestOption == "AccountDetermination_Purchase")
                {
                    ACC_M003_Z_BL aCC_M003_Z_BL = new ACC_M003_Z_BL();
                    strValue = aCC_M003_Z_BL.Insert(Request);
                }
                else if (RequestOption == "MethodAssignment")
                {
                    ACC_M023_BL _ACC_M023_BL = new ACC_M023_BL();
                    strValue = _ACC_M023_BL.Insert(Request);
                }
                else if (RequestOption == "AssetClassMaster")
                {
                    ACC_M002_C_BL _ACC_M002_C_BL = new ACC_M002_C_BL();
                    strValue = _ACC_M002_C_BL.Insert(Request);
                }
                else if (RequestOption == "MaintainDepKey")
                {
                    ACC_M002_K_BL _ACC_M002_K_BL = new ACC_M002_K_BL();
                    strValue = _ACC_M002_K_BL.Insert(Request);
                }
                else if (RequestOption == "AssetMaster")
                {
                    ACC_M002_BL _ACC_M002_BL = new ACC_M002_BL();
                    strValue = _ACC_M002_BL.Insert(Request);
                }
                else if (RequestOption == "AssetClassAreaAssi")
                {
                    ACC_M002_D_BL _ACC_M002_D_BL = new ACC_M002_D_BL();
                    strValue = _ACC_M002_D_BL.Insert(Request);
                }
                else if (RequestOption == "AccountLedger")
                {
                    ACC_M003_BL _ACC_M003_BL = new ACC_M003_BL();
                    strValue = _ACC_M003_BL.Insert(Request);
                }
                else if (RequestOption == "AccountGroupCode")
                {
                    ACC_M003_A_BL _ACC_M003_A_BL = new ACC_M003_A_BL();
                    strValue = _ACC_M003_A_BL.Insert(Request);
                }
                else if (RequestOption == "AccountSubGroupCode")
                {
                    ACC_M003_B_BL aCC_M003BBL = new ACC_M003_B_BL();
                    strValue = aCC_M003BBL.Insert(Request);
                }
                else if (RequestOption == "BankMaster")
                {
                    ACC_M004_BL _ACC_M004_BL = new ACC_M004_BL();
                    strValue = _ACC_M004_BL.Insert(Request);
                }
                else if (RequestOption == "AccountCategoryMaster")
                {
                    ACC_M003_K_BL aCC_M003KBL = new ACC_M003_K_BL();
                    strValue = aCC_M003KBL.Insert(Request);
                }
                else if (RequestOption == "AccountGroupMaster")
                {
                    ACC_M003_H_BL _ACC_M003_H_BL = new ACC_M003_H_BL();
                    strValue = _ACC_M003_H_BL.Insert(Request);
                }
                else if (RequestOption == "CoaAssignToCompany1")
                {
                    ACC_M003_D_BL _ACC_M003_D_BL = new ACC_M003_D_BL();
                    strValue = _ACC_M003_D_BL.Insert(Request);
                }
                else if (RequestOption == "CompanyBank")
                {
                    ACC_M004_A_BL _ACC_M004_A_BL = new ACC_M004_A_BL();
                    strValue = _ACC_M004_A_BL.Insert(Request);
                }
                else if (RequestOption == "CompanyBankAccount")
                {
                    ACC_M004_B_BL _ACC_M004_B_BL = new ACC_M004_B_BL();
                    strValue = _ACC_M004_B_BL.Insert(Request);
                }
                else if (RequestOption == "PostingPeriod")
                {
                    ACC_M001_A_BL _ACC_M001_A_BL = new ACC_M001_A_BL();
                    strValue = _ACC_M001_A_BL.Insert(Request);
                }
                else if (RequestOption == "AssetAreaMaster")
                {
                    ACC_M002_R_BL _ACC_M002_R_BL = new ACC_M002_R_BL();
                    strValue = _ACC_M002_R_BL.Insert(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public byte[] Insert(string Request, string RequestOption, string strType)
        {
            byte[] strValue;
            try
            {

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }


            return strValue = null;
        }
        public string Update(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "PaymentEntry")
                {
                    ACC_T001BL aCC_T001BL = new ACC_T001BL();
                    strValue = aCC_T001BL.Update(Request);
                }
                else if (RequestOption == "PaymentProcess")
                {
                    ACC_T001BL_PaymentPocess aCC_T001_PayProcessBL = new ACC_T001BL_PaymentPocess();
                    strValue = aCC_T001_PayProcessBL.Update(Request);
                }
                else if (RequestOption == "ACC_T001_STD_IN")
                {
                    ACC_T001_STD_BL aCC_T001_PayProcessBL = new ACC_T001_STD_BL();
                    strValue = aCC_T001_PayProcessBL.Update(Request);
                }
                else if (RequestOption == "JournalVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Update(Request);
                }
                else if (RequestOption == "AccountingDocument")
                {
                    ACC_T006BL aCC_T002BL_2 = new ACC_T006BL();
                    strValue = aCC_T002BL_2.Update(Request);
                }
                else if (RequestOption == "ExpensesVoucher")
                {
                    ACC_T003BL aCC_T003BL = new ACC_T003BL();
                    strValue = aCC_T003BL.Update(Request);
                }
                else if (RequestOption == "Opening_Balance")
                {
                    ACC_T004BL aCC_T004BL = new ACC_T004BL();
                    strValue = aCC_T004BL.Update(Request);
                }
                else if (RequestOption == "ExpectedPayment")
                {
                    ACC_T005BL aCC_T005BL = new ACC_T005BL();
                    strValue = aCC_T005BL.Update(Request);
                }
                else if (RequestOption == "CashVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Update(Request);
                }

                else if (RequestOption == "ContraVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Update(Request);
                }

                else if (RequestOption == "BankVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Update(Request);
                }
                else if (RequestOption == "BankReco")
                {
                   BankReco_BL _BankReco_BL = new BankReco_BL();
                    strValue = _BankReco_BL.Update(Request);
                }

                else if (RequestOption == "AccountDeterminationKey")
                {
                    ACC_M003_T_BL _ACC_M003_T_BL = new ACC_M003_T_BL();
                    strValue = _ACC_M003_T_BL.Update(Request);
                }
                else if (RequestOption == "TaxConditionMaster")
                {
                    ACC_M003_O_BL _ACC_M003_O_BL = new ACC_M003_O_BL();
                    strValue = _ACC_M003_O_BL.Update(Request);
                }
                else if (RequestOption == "PostingKeyMaster")
                {
                    ACC_M003_Q_BL _ACC_M003_Q_BL = new ACC_M003_Q_BL();
                    strValue = _ACC_M003_Q_BL.Update(Request);
                }
                else if (RequestOption == "AccountDeterminationRule")
                {
                    ACC_M003_F_BL _ACC_M003_F_BL = new ACC_M003_F_BL();
                    strValue = _ACC_M003_F_BL.Update(Request);
                }
                else if (RequestOption == "MethodAssignment")
                {
                    ACC_M023_BL _ACC_M023_BL = new ACC_M023_BL();
                    strValue = _ACC_M023_BL.Update(Request);
                }
                else if (RequestOption == "AssetClassMaster")
                {
                    ACC_M002_C_BL _ACC_M002_C_BL = new ACC_M002_C_BL();
                    strValue = _ACC_M002_C_BL.Update(Request);
                }
                else if (RequestOption == "MaintainDepKey")
                {
                    ACC_M002_K_BL _ACC_M002_K_BL = new ACC_M002_K_BL();
                    strValue = _ACC_M002_K_BL.Update(Request);
                }
                else if (RequestOption == "AssetMaster")
                {
                    ACC_M002_BL _ACC_M002_BL = new ACC_M002_BL();
                    strValue = _ACC_M002_BL.Update(Request);
                }
                else if (RequestOption == "AssetClassAreaAssi")
                {
                    ACC_M002_D_BL _ACC_M002_D_BL = new ACC_M002_D_BL();
                    strValue = _ACC_M002_D_BL.Update(Request);
                }
                else if (RequestOption == "AccountLedger")
                {
                    ACC_M003_BL _ACC_M003_BL = new ACC_M003_BL();
                    strValue = _ACC_M003_BL.Update(Request);
                }
                else if (RequestOption == "BankMaster")
                {
                    ACC_M004_BL _ACC_M004_BL = new ACC_M004_BL();
                    strValue = _ACC_M004_BL.Update(Request);
                }
                else if (RequestOption == "AssetAreaMaster")
                {
                    ACC_M002_R_BL _ACC_M002_R_BL = new ACC_M002_R_BL();
                    strValue = _ACC_M002_R_BL.Update(Request);
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
                if (RequestOption == "PaymentEntry")
                {
                    ACC_T001BL aCC_T001BL = new ACC_T001BL();
                    strValue = aCC_T001BL.Delete(Request);
                }
                else if (RequestOption == "PaymentProcess")
                {
                    ACC_T001BL_PaymentPocess aCC_T001_PayProcessBL = new ACC_T001BL_PaymentPocess();
                    strValue = aCC_T001_PayProcessBL.Delete(Request);
                }
                else if (RequestOption == "ACC_T001_STD_IN")
                {
                    ACC_T001_STD_BL aCC_T001_PayProcessBL = new ACC_T001_STD_BL();
                    strValue = aCC_T001_PayProcessBL.Delete(Request);
                }
                else if (RequestOption == "JournalVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue = aCC_T002BL.Delete(Request);
                }
                else if (RequestOption == "AccountingDocument")
                {
                    ACC_T006BL aCC_T002BL_2 = new ACC_T006BL();
                    strValue = aCC_T002BL_2.Delete(Request);
                }
                else if (RequestOption == "ExpensesVoucher")
                {
                    ACC_T003BL aCC_T003BL = new ACC_T003BL();
                    strValue = aCC_T003BL.Delete(Request);
                }
                else if (RequestOption == "Opening_Balance")
                {
                    ACC_T004BL aCC_T004BL = new ACC_T004BL();
                    strValue = aCC_T004BL.Delete(Request);
                }
                else if (RequestOption == "ExpectedPayment")
                {
                    ACC_T005BL aCC_T005BL = new ACC_T005BL();
                    strValue = aCC_T005BL.Delete(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }


            return strValue;
        }
        public string Delete(int Request, int Request1, string RequestOption)
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
        public string Delete(int Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "PaymentEntry")
                {
                    //ACC_T001BL aCC_T001BL = new ACC_T001BL();
                    //strValue = aCC_T001BL.Delete(Request);
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
                if (RequestOption == "PaymentEntry")
                {
                    ACC_T001BL aCC_T001BL = new ACC_T001BL();
                    strValue1 = aCC_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PaymentProcess")
                {
                    ACC_T001BL_PaymentPocess aCC_T001_PayProcessBL = new ACC_T001BL_PaymentPocess();
                    strValue1 = aCC_T001_PayProcessBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ACC_T001_STD_IN")
                {
                    ACC_T001_STD_BL aCC_T001_PayProcessBL = new ACC_T001_STD_BL();
                    strValue1 = aCC_T001_PayProcessBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_PaymentRpt")
                {
                    MIS_FinancePaymentBL mIS_FinancePaymentBL = new MIS_FinancePaymentBL();
                    strValue1 = mIS_FinancePaymentBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance3")
                {
                    MIS_Finance3BL mIS_Finance3BL = new MIS_Finance3BL();
                    strValue1 = mIS_Finance3BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance4")
                {
                    MIS_Finance4BL mIS_Finance4BL = new MIS_Finance4BL();
                    strValue1 = mIS_Finance4BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "JournalVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue1= aCC_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountingDocument")
                {
                    ACC_T006BL aCC_T002BL_2 = new ACC_T006BL();
                    strValue1 = aCC_T002BL_2.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ExpensesVoucher")
                {
                    ACC_T003BL aCC_T003BL = new ACC_T003BL();
                    strValue1 = aCC_T003BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_PaymentRpt2")
                {
                    MIS_FinancePayment2BL mIS_FinanacePayment2BL = new MIS_FinancePayment2BL();
                    strValue1 = mIS_FinanacePayment2BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Expence")
                {
                    MIS_Finance_ExpenceBL mIS_Finance_ExpenceBL = new MIS_Finance_ExpenceBL();
                    strValue1 = mIS_Finance_ExpenceBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Bank")
                {
                    MIS_Finance_BankBL mIS_Finance_BankBL = new MIS_Finance_BankBL();
                    strValue1 = mIS_Finance_BankBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Opening_Balance")
                {
                    ACC_T004BL aCC_T004BL = new ACC_T004BL();
                    strValue1 = aCC_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ExpectedPayment")
                {
                    ACC_T005BL aCC_T005BL = new ACC_T005BL();
                    strValue1 = aCC_T005BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Tour_Management")
                {
                    MIS_Tour_ManagementBL mIS_Tour_ManagementBL = new MIS_Tour_ManagementBL();
                    strValue1 = mIS_Tour_ManagementBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CashVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue1 = aCC_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if(RequestOption=="ContraVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue1 = aCC_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BankVoucher")
                {
                    ACC_T002BL aCC_T002BL = new ACC_T002BL();
                    strValue1 = aCC_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BankReco")
                {
                    BankReco_BL _BankReco_BL = new BankReco_BL();
                    strValue1 = _BankReco_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountDeterminationKey")
                {
                    ACC_M003_T_BL _ACC_M003_T_BL = new ACC_M003_T_BL();
                    strValue1 = _ACC_M003_T_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountModifierForMT")
                {
                    ACC_M003_X_BL _ACC_M003_X_BL = new ACC_M003_X_BL();
                    strValue1 = _ACC_M003_X_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GL_AccountDetermination")
                {
                    ACC_M003_E_BL _ACC_M003_E_BL = new ACC_M003_E_BL();
                    strValue1 = _ACC_M003_E_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PricingProcedure")
                {
                    ACC_M003_N_BL _ACC_M003_N_BL = new ACC_M003_N_BL();
                    strValue1 = _ACC_M003_N_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TaxConditionMaster")
                {
                    ACC_M003_O_BL _ACC_M003_O_BL = new ACC_M003_O_BL();
                    strValue1 = _ACC_M003_O_BL.GetData(Request, strType, intValue, strValue);
                }            
                else if (RequestOption == "PostingKeyMaster")
                {
                    ACC_M003_Q_BL _ACC_M003_Q_BL = new ACC_M003_Q_BL();
                    strValue1 = _ACC_M003_Q_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountDeterminationRule")
                {
                    ACC_M003_F_BL _ACC_M003_F_BL = new ACC_M003_F_BL();
                    strValue1 = _ACC_M003_F_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "DefinePostingKey")
                {
                    ACC_M003_I_BL _ACC_M003_I_BL = new ACC_M003_I_BL();
                    strValue1 = _ACC_M003_I_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountDetermination_Revenue")
                {
                    ACC_M003_Y_BL _ACC_M003_Y_BL = new ACC_M003_Y_BL();
                    strValue1 = _ACC_M003_Y_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountDetermination_Purchase")
                {
                    ACC_M003_Z_BL _ACC_M003_Z_BL = new ACC_M003_Z_BL();
                    strValue1 = _ACC_M003_Z_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssetMaster")
                {
                    ACC_M002_BL _ACC_M002_BL = new ACC_M002_BL();
                    strValue1 = _ACC_M002_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssetClassMaster")
                {
                    ACC_M002_C_BL _ACC_M002_C_BL = new ACC_M002_C_BL();
                    strValue1 = _ACC_M002_C_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BaseMethod")
                {
                    ACC_M002_M_BL _ACC_M002_M_BL = new ACC_M002_M_BL();
                    strValue1 = _ACC_M002_M_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MethodAssignment")
                {
                    ACC_M023_BL _ACC_M023_BL = new ACC_M023_BL();
                    strValue1 = _ACC_M023_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MaintainDepKey")
                {
                    ACC_M002_K_BL _ACC_M002_K_BL = new ACC_M002_K_BL();
                    strValue1 = _ACC_M002_K_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssetClassAreaAssi")
                {
                    ACC_M002_D_BL _ACC_M002_D_BL = new ACC_M002_D_BL();
                    strValue1 = _ACC_M002_D_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountLedger")
                {
                    ACC_M003_BL _ACC_M003_BL = new ACC_M003_BL();
                    strValue1 = _ACC_M003_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountGroupCode")
                {
                    ACC_M003_A_BL _ACC_M003_A_BL = new ACC_M003_A_BL();
                    strValue1 = _ACC_M003_A_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountSubGroupCode")
                {
                    ACC_M003_B_BL acc_M003B = new ACC_M003_B_BL();
                    strValue1 = acc_M003B.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountCategoryMaster")
                {
                    ACC_M003_K_BL acc_M003K = new ACC_M003_K_BL();
                    strValue1 = acc_M003K.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BankMaster")
                {
                    ACC_M004_BL _ACC_M004_BL = new ACC_M004_BL();
                    strValue1 = _ACC_M004_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AccountGroupMaster")
                {
                    ACC_M003_H_BL _ACC_M003_H_BL = new ACC_M003_H_BL();
                    strValue1 = _ACC_M003_H_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CoaAssignToCompany1")
                {
                    ACC_M003_D_BL _ACC_M003_D_BL = new ACC_M003_D_BL();
                    strValue1 = _ACC_M003_D_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CompanyBank")
                {
                    ACC_M004_A_BL _ACC_M004_A_BL = new ACC_M004_A_BL();
                    strValue1 = _ACC_M004_A_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CompanyBankAccount")
                {
                    ACC_M004_B_BL _ACC_M004_B_BL = new ACC_M004_B_BL();
                    strValue1 = _ACC_M004_B_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PostingPeriod")
                {
                    ACC_M001_A_BL _ACC_M001_A_BL = new ACC_M001_A_BL();
                    strValue1 = _ACC_M001_A_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "AssetAreaMaster")
                {
                    ACC_M002_R_BL _ACC_M002_R_BL = new ACC_M002_R_BL();
                    strValue1 = _ACC_M002_R_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_LedgerGroupwiseReport")
                {
                    MIS_Finance_LedgerGroupwiseReportBL _MIS_Finance_LedgerGroupwiseReportBL = new MIS_Finance_LedgerGroupwiseReportBL();
                    strValue1 = _MIS_Finance_LedgerGroupwiseReportBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_LedgerDetails")
                {
                    MIS_Finance_LedgerGroupwiseReportBL _MIS_Finance_LedgerGroupwiseReportBL = new MIS_Finance_LedgerGroupwiseReportBL();
                    strValue1 = _MIS_Finance_LedgerGroupwiseReportBL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_Finance_LedgerReport")
                {
                    MIS_Finance_LedgerReport_BL _MIS_Finance_LedgerReport_BL = new MIS_Finance_LedgerReport_BL();
                    strValue1 = _MIS_Finance_LedgerReport_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_LedgerView")
                {
                    MIS_Finance_LedgerView_BL _MIS_Finance_LedgerView_BL = new MIS_Finance_LedgerView_BL();
                    strValue1 = _MIS_Finance_LedgerView_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_Finance_TrialBalance")
                {
                    MIS_Finance_TrialBalance_BL _MIS_Finance_TrialBalance_BL = new MIS_Finance_TrialBalance_BL();
                    strValue1 = _MIS_Finance_TrialBalance_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_GroupReport")
                {
                    MIS_Finance_LedgerGroupwiseReportBL _MIS_Finance_LedgerGroupwiseReportBL = new MIS_Finance_LedgerGroupwiseReportBL();
                    strValue1 = _MIS_Finance_LedgerGroupwiseReportBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_ProfitAndLoss")
                {
                    MIS_Finance_ProfitAndLoss_BL _MIS_Finance_ProfitAndLoss_BL = new MIS_Finance_ProfitAndLoss_BL();
                    strValue1 = _MIS_Finance_ProfitAndLoss_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_BalanceSheet")
                {
                    MIS_Finance_BalanceSheet_BL _MIS_Finance_BalanceSheet_BL = new MIS_Finance_BalanceSheet_BL();
                    strValue1 = _MIS_Finance_BalanceSheet_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Finance_DayBook")
                {
                    MIS_Finance_DayBook_BL _MIS_Finance_DayBook_BL = new MIS_Finance_DayBook_BL();
                    strValue1 = _MIS_Finance_DayBook_BL.GetData(Request, strType, intValue, strValue);
                }

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
        }
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue, string doc_code, string company, string plant, string user, string request1, string request2, string request3, string request4, string request5)
        {
            string strValue1 = "";
            try
            {
                if (RequestOption == "PaymentEntry")
                {
                    //SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    //strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue, doc_code, company, plant, user, request1, request2, request3, request4, request5);
                }
               
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
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
