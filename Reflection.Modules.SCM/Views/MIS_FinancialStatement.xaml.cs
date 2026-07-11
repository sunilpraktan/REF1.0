using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Modules.SCM.Views;
using Reflection.BusinessEntity;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for MIS_FinancialStatement.xaml
    /// </summary>
    public partial class MIS_FinancialStatement : WindowElement
    {
        public MIS_FinancialStatement(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_FinStatement_VM(ts_code);
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupplant.UnselectAll();
                dgPopupcomp.UnselectAll();
                dgCategory.UnselectAll();
                dgSubCategory.UnselectAll();
                dgunit.UnselectAll();
                dgPopUpmake.UnselectAll();
                dgFin.UnselectAll();
                dgPost1.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MC5.Text = "";
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (PrevOpenQtyLoc.Text == null || PrevOpenQtyLoc.Text == "") { PrevOpenQtyLoc.Text = "0"; }
            if (PrevOpenQtyImp.Text == null || PrevOpenQtyImp.Text == "") { PrevOpenQtyImp.Text = "0"; }
            if (PrevOpenValueLoc.Text == null || PrevOpenValueLoc.Text == "") { PrevOpenValueLoc.Text = "0"; }
            if (PrevOpenValueImp.Text == null || PrevOpenValueImp.Text == "") { PrevOpenValueImp.Text = "0"; }
            if (CurOpenQtyLoc.Text == null || CurOpenQtyLoc.Text == "") { CurOpenQtyLoc.Text = "0"; }
            if (CurOpenQtyImp.Text == null || CurOpenQtyImp.Text == "") { CurOpenQtyImp.Text = "0"; }
            if (CurOpenValueLoc.Text == null || CurOpenValueLoc.Text == "") { CurOpenValueLoc.Text = "0"; }
            if (CurOpenValueImp.Text == null || CurOpenValueImp.Text == "") { CurOpenValueImp.Text = "0"; }

            if (PrevPurQtyLoc.Text == null || PrevPurQtyLoc.Text == "") { PrevPurQtyLoc.Text = "0"; }
            if (PrevPurQtyImp.Text == null || PrevPurQtyImp.Text == "") { PrevPurQtyImp.Text = "0"; }
            if (PrevPurValueLoc.Text == null || PrevPurValueLoc.Text == "") { PrevPurValueLoc.Text = "0"; }
            if (PrevPurValueImp.Text == null || PrevPurValueImp.Text == "") { PrevPurValueImp.Text = "0"; }
            if (CurPurQtyLoc.Text == null || CurPurQtyLoc.Text == "") { CurPurQtyLoc.Text = "0"; }
            if (CurPurQtyImp.Text == null || CurPurQtyImp.Text == "") { CurPurQtyImp.Text = "0"; }
            if (CurPurValueLoc.Text == null || CurPurValueLoc.Text == "") { CurPurValueLoc.Text = "0"; }
            if (CurPurValueImp.Text == null || CurPurValueImp.Text == "") { CurPurValueImp.Text = "0"; }

            if (PrevDebitQtyLoc.Text == null || PrevDebitQtyLoc.Text == "") { PrevDebitQtyLoc.Text = "0"; }
            if (PrevDebitQtyImp.Text == null || PrevDebitQtyImp.Text == "") { PrevDebitQtyImp.Text = "0"; }
            if (PrevDebitValueLoc.Text == null || PrevDebitValueLoc.Text == "") { PrevDebitValueLoc.Text = "0"; }
            if (PrevDebitValueImp.Text == null || PrevDebitValueImp.Text == "") { PrevDebitValueImp.Text = "0"; }
            if (CurDebitQtyLoc.Text == null || CurDebitQtyLoc.Text == "") { CurDebitQtyLoc.Text = "0"; }
            if (CurDebitQtyImp.Text == null || CurDebitQtyImp.Text == "") { CurDebitQtyImp.Text = "0"; }
            if (CurDebitValueLoc.Text == null || CurDebitValueLoc.Text == "") { CurDebitValueLoc.Text = "0"; }
            if (CurDebitValueImp.Text == null || CurDebitValueImp.Text == "") { CurDebitValueImp.Text = "0"; }

            if (PrevIssueQtyLoc.Text == null || PrevIssueQtyLoc.Text == "") { PrevIssueQtyLoc.Text = "0"; }
            if (PrevIssueQtyImp.Text == null || PrevIssueQtyImp.Text == "") { PrevIssueQtyImp.Text = "0"; }
            if (PrevIssueValueLoc.Text == null || PrevIssueValueLoc.Text == "") { PrevIssueValueLoc.Text = "0"; }
            if (PrevIssueValueImp.Text == null || PrevIssueValueImp.Text == "") { PrevIssueValueImp.Text = "0"; }
            if (CurIssueQtyLoc.Text == null || CurIssueQtyLoc.Text == "") { CurIssueQtyLoc.Text = "0"; }
            if (CurIssueQtyImp.Text == null || CurIssueQtyImp.Text == "") { CurIssueQtyImp.Text = "0"; }
            if (CurIssueValueLoc.Text == null || CurIssueValueLoc.Text == "") { CurIssueValueLoc.Text = "0"; }
            if (CurIssueValueImp.Text == null || CurIssueValueImp.Text == "") { CurIssueValueImp.Text = "0"; }

            if (PrevRecieptQtyLoc.Text == null || PrevRecieptQtyLoc.Text == "") { PrevRecieptQtyLoc.Text = "0"; }
            if (PrevRecieptQtyImp.Text == null || PrevRecieptQtyImp.Text == "") { PrevRecieptQtyImp.Text = "0"; }
            if (PrevRecieptValueLoc.Text == null || PrevRecieptValueLoc.Text == "") { PrevRecieptValueLoc.Text = "0"; }
            if (PrevRecieptValueImp.Text == null || PrevRecieptValueImp.Text == "") { PrevRecieptValueImp.Text = "0"; }
            if (CurRecieptQtyLoc.Text == null || CurRecieptQtyLoc.Text == "") { CurRecieptQtyLoc.Text = "0"; }
            if (CurRecieptQtyImp.Text == null || CurRecieptQtyImp.Text == "") { CurRecieptQtyImp.Text = "0"; }
            if (CurRecieptValueLoc.Text == null || CurRecieptValueLoc.Text == "") { CurRecieptValueLoc.Text = "0"; }
            if (CurRecieptValueImp.Text == null || CurRecieptValueImp.Text == "") { CurRecieptValueImp.Text = "0"; }

            if (PrevSalesQtyLoc.Text == null || PrevSalesQtyLoc.Text == "") { PrevSalesQtyLoc.Text = "0"; }
            if (PrevSalesQtyImp.Text == null || PrevSalesQtyImp.Text == "") { PrevSalesQtyImp.Text = "0"; }
            if (PrevSalesValueLoc.Text == null || PrevSalesValueLoc.Text == "") { PrevSalesValueLoc.Text = "0"; }
            if (PrevSalesValueImp.Text == null || PrevSalesValueImp.Text == "") { PrevSalesValueImp.Text = "0"; }
            if (CurSalesQtyLoc.Text == null || CurSalesQtyLoc.Text == "") { CurSalesQtyLoc.Text = "0"; }
            if (CurSalesQtyImp.Text == null || CurSalesQtyImp.Text == "") { CurSalesQtyImp.Text = "0"; }
            if (CurSalesValueLoc.Text == null || CurSalesValueLoc.Text == "") { CurSalesValueLoc.Text = "0"; }
            if (CurSalesValueImp.Text == null || CurSalesValueImp.Text == "") { CurSalesValueImp.Text = "0"; }


            if (PrevShortageQtyLoc.Text == null || PrevShortageQtyLoc.Text == "") { PrevShortageQtyLoc.Text = "0"; }
            if (PrevShortageQtyImp.Text == null || PrevShortageQtyImp.Text == "") { PrevShortageQtyImp.Text = "0"; }
            if (PrevShortageValueLoc.Text == null || PrevShortageValueLoc.Text == "") { PrevShortageValueLoc.Text = "0"; }
            if (PrevShortageValueImp.Text == null || PrevShortageValueImp.Text == "") { PrevShortageValueImp.Text = "0"; }
            if (CurShortageQtyLoc.Text == null || CurShortageQtyLoc.Text == "") { CurShortageQtyLoc.Text = "0"; }
            if (CurShortageQtyImp.Text == null || CurShortageQtyImp.Text == "") { CurShortageQtyImp.Text = "0"; }
            if (CurShortageValueLoc.Text == null || CurShortageValueLoc.Text == "") { CurShortageValueLoc.Text = "0"; }
            if (CurShortageValueImp.Text == null || CurShortageValueImp.Text == "") { CurShortageValueImp.Text = "0"; }

            if (PrevClosingQtyLoc.Text == null || PrevClosingQtyLoc.Text == "") { PrevClosingQtyLoc.Text = "0"; }
            if (PrevClosingQtyImp.Text == null || PrevClosingQtyImp.Text == "") { PrevClosingQtyImp.Text = "0"; }
            if (PrevClosingValueLoc.Text == null || PrevClosingValueLoc.Text == "") { PrevClosingValueLoc.Text = "0"; }
            if (PrevClosingValueImp.Text == null || PrevClosingValueImp.Text == "") { PrevClosingValueImp.Text = "0"; }
            if (CurClosingQtyLoc.Text == null || CurClosingQtyLoc.Text == "") { CurClosingQtyLoc.Text = "0"; }
            if (CurClosingQtyImp.Text == null || CurClosingQtyImp.Text == "") { CurClosingQtyImp.Text = "0"; }
            if (CurClosingValueLoc.Text == null || CurClosingValueLoc.Text == "") { CurClosingValueLoc.Text = "0"; }
            if (CurClosingValueImp.Text == null || CurClosingValueImp.Text == "") { CurClosingValueImp.Text = "0"; }

            UptoOpenQtyLoc.Text = (Convert.ToDecimal(PrevOpenQtyLoc.Text)).ToString();
            UptoOpenQtyImp.Text = (Convert.ToDecimal(PrevOpenQtyImp.Text)).ToString();
            UptoOpenValueLoc.Text = (Convert.ToDecimal(PrevOpenValueLoc.Text)).ToString();
            UptoOpenValueImp.Text = (Convert.ToDecimal(PrevOpenValueImp.Text)).ToString();

            UptoPurQtyLoc.Text = (Convert.ToDecimal(PrevPurQtyLoc.Text) + Convert.ToDecimal(CurPurQtyLoc.Text)).ToString();
            UptoPurQtyImp.Text = (Convert.ToDecimal(PrevPurQtyImp.Text) + Convert.ToDecimal(CurPurQtyImp.Text)).ToString();
            UptoPurValueLoc.Text = (Convert.ToDecimal(PrevPurValueLoc.Text) + Convert.ToDecimal(CurPurValueLoc.Text)).ToString();
            UptoPurValueImp.Text = (Convert.ToDecimal(PrevPurValueImp.Text) + Convert.ToDecimal(CurPurValueImp.Text)).ToString();

            UptoDebitQtyLoc.Text = (Convert.ToDecimal(PrevDebitQtyLoc.Text) + Convert.ToDecimal(CurDebitQtyLoc.Text)).ToString();
            UptoDebitQtyImp.Text = (Convert.ToDecimal(PrevDebitQtyImp.Text) + Convert.ToDecimal(CurDebitQtyImp.Text)).ToString();
            UptoDebitValueLoc.Text = (Convert.ToDecimal(PrevDebitValueLoc.Text) + Convert.ToDecimal(CurDebitValueLoc.Text)).ToString();
            UptoDebitValueImp.Text = (Convert.ToDecimal(PrevDebitValueImp.Text) + Convert.ToDecimal(CurDebitValueImp.Text)).ToString();

            UptoIssueQtyLoc.Text = (Convert.ToDecimal(PrevIssueQtyLoc.Text) + Convert.ToDecimal(CurIssueQtyLoc.Text)).ToString();
            UptoIssueQtyImp.Text = (Convert.ToDecimal(PrevIssueQtyImp.Text) + Convert.ToDecimal(CurIssueQtyImp.Text)).ToString();
            UptoIssueValueLoc.Text = (Convert.ToDecimal(PrevIssueValueLoc.Text) + Convert.ToDecimal(CurIssueValueLoc.Text)).ToString();
            UptoIssueValueImp.Text = (Convert.ToDecimal(PrevIssueValueImp.Text) + Convert.ToDecimal(CurIssueValueImp.Text)).ToString();

            UptoRecieptQtyLoc.Text = (Convert.ToDecimal(PrevRecieptQtyLoc.Text) + Convert.ToDecimal(CurRecieptQtyLoc.Text)).ToString();
            UptoRecieptQtyImp.Text = (Convert.ToDecimal(PrevRecieptQtyImp.Text) + Convert.ToDecimal(CurRecieptQtyImp.Text)).ToString();
            UptoRecieptValueLoc.Text = (Convert.ToDecimal(PrevRecieptValueLoc.Text) + Convert.ToDecimal(CurRecieptValueLoc.Text)).ToString();
            UptoRecieptValueImp.Text = (Convert.ToDecimal(PrevRecieptValueImp.Text) + Convert.ToDecimal(CurRecieptValueImp.Text)).ToString();

            UptoSalesQtyLoc.Text = (Convert.ToDecimal(PrevSalesQtyLoc.Text) + Convert.ToDecimal(CurSalesQtyLoc.Text)).ToString();
            UptoSalesQtyImp.Text = (Convert.ToDecimal(PrevSalesQtyImp.Text) + Convert.ToDecimal(CurSalesQtyImp.Text)).ToString();
            UptoSalesValueLoc.Text = (Convert.ToDecimal(PrevSalesValueLoc.Text) + Convert.ToDecimal(CurSalesValueLoc.Text)).ToString();
            UptoSalesValueImp.Text = (Convert.ToDecimal(PrevSalesValueImp.Text) + Convert.ToDecimal(CurSalesValueImp.Text)).ToString();

            UptoShortageQtyLoc.Text = (Convert.ToDecimal(PrevShortageQtyLoc.Text) + Convert.ToDecimal(CurShortageQtyLoc.Text)).ToString();
            UptoShortageQtyImp.Text = (Convert.ToDecimal(PrevShortageQtyImp.Text) + Convert.ToDecimal(CurShortageQtyImp.Text)).ToString();
            UptoShortageValueLoc.Text = (Convert.ToDecimal(PrevShortageValueLoc.Text) + Convert.ToDecimal(CurShortageValueLoc.Text)).ToString();
            UptoShortageValueImp.Text = (Convert.ToDecimal(PrevShortageValueImp.Text) + Convert.ToDecimal(CurShortageValueImp.Text)).ToString();

            UptoClosingQtyLoc.Text = (Convert.ToDecimal(CurClosingQtyLoc.Text)).ToString();
            UptoClosingQtyImp.Text = (Convert.ToDecimal(CurClosingQtyImp.Text)).ToString();
            UptoClosingValueLoc.Text = (Convert.ToDecimal(CurClosingValueLoc.Text)).ToString();
            UptoClosingValueImp.Text = (Convert.ToDecimal(CurClosingValueImp.Text)).ToString();

            UptoTotalOpenQty.Text = (Convert.ToDecimal(UptoOpenQtyLoc.Text) + Convert.ToDecimal(UptoOpenQtyImp.Text)).ToString();
            UptoTotalOpenValue.Text = (Convert.ToDecimal(UptoOpenValueLoc.Text) + Convert.ToDecimal(UptoOpenValueImp.Text)).ToString();

            UptoTotalPurQty.Text = (Convert.ToDecimal(UptoPurQtyLoc.Text) + Convert.ToDecimal(UptoPurQtyImp.Text)).ToString();
            UptoTotalPurValue.Text = (Convert.ToDecimal(UptoPurValueLoc.Text) + Convert.ToDecimal(UptoPurValueImp.Text)).ToString();

            UptoTotalDebitQty.Text = (Convert.ToDecimal(UptoDebitQtyLoc.Text) + Convert.ToDecimal(UptoDebitQtyImp.Text)).ToString();
            UptoTotalDebitValue.Text = (Convert.ToDecimal(UptoDebitValueLoc.Text) + Convert.ToDecimal(UptoDebitValueImp.Text)).ToString();

            UptoTotalIssueQty.Text = (Convert.ToDecimal(UptoIssueQtyLoc.Text) + Convert.ToDecimal(UptoIssueQtyImp.Text)).ToString();
            UptoTotalIssueValue.Text = (Convert.ToDecimal(UptoIssueValueLoc.Text) + Convert.ToDecimal(UptoIssueValueImp.Text)).ToString();

            UptoTotalRecieptQty.Text = (Convert.ToDecimal(UptoRecieptQtyLoc.Text) + Convert.ToDecimal(UptoRecieptQtyImp.Text)).ToString();
            UptoTotalRecieptValue.Text = (Convert.ToDecimal(UptoRecieptValueLoc.Text) + Convert.ToDecimal(UptoRecieptValueImp.Text)).ToString();

            UptoTotalSalesQty.Text = (Convert.ToDecimal(UptoSalesQtyLoc.Text) + Convert.ToDecimal(UptoSalesQtyImp.Text)).ToString();
            UptoTotalSalesValue.Text = (Convert.ToDecimal(UptoSalesValueLoc.Text) + Convert.ToDecimal(UptoSalesValueImp.Text)).ToString();

            UptoTotalShortageQty.Text = (Convert.ToDecimal(UptoShortageQtyLoc.Text) + Convert.ToDecimal(UptoShortageQtyImp.Text)).ToString();
            UptoTotalShortageValue.Text = (Convert.ToDecimal(UptoShortageValueLoc.Text) + Convert.ToDecimal(UptoShortageValueImp.Text)).ToString();

            UptoTotalClosingQty.Text = (Convert.ToDecimal(UptoClosingQtyLoc.Text) + Convert.ToDecimal(UptoClosingQtyImp.Text)).ToString();
            UptoTotalClosingValue.Text = (Convert.ToDecimal(UptoClosingValueLoc.Text) + Convert.ToDecimal(UptoClosingValueImp.Text)).ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UptoTotalOpenQty.Text = "";
            UptoTotalOpenValue.Text = "";
            UptoTotalPurQty.Text = "";
            UptoTotalPurValue.Text = "";
            UptoTotalDebitQty.Text = "";
            UptoTotalDebitValue.Text = "";
            UptoTotalIssueQty.Text = "";
            UptoTotalIssueValue.Text = "";
            UptoTotalRecieptQty.Text = "";
            UptoTotalRecieptValue.Text = "";
            UptoTotalSalesQty.Text = "";
            UptoTotalSalesValue.Text = "";
            UptoTotalShortageQty.Text = "";
            UptoTotalShortageValue.Text = "";
            UptoTotalClosingQty.Text = "";
            UptoTotalClosingValue.Text = "";
        }
        
    }
}
