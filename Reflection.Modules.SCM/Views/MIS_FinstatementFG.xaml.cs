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
    /// Interaction logic for MIS_FinstatementFG.xaml
    /// </summary>
  
    public partial class MIS_FinstatementFG : WindowElement
    {
        public MIS_FinstatementFG(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_FinStatement_FG_VM(ts_code);
        }
        //public MIS_FinstatementFG(string ts_code)
        //{
        //    InitializeComponent();
        //    this.DataContext = new MIS_FinStatement_FG_VM();
        //}


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
                dgPopupWireSz.UnselectAll();
                dgFin.UnselectAll();
                dgPost1.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MC16.Text = "";
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (PrevOpenQty.Text == null || PrevOpenQty.Text == "") { PrevOpenQty.Text = "0"; }
            if (PrevOpenValue.Text == null || PrevOpenValue.Text == "") { PrevOpenValue.Text = "0"; }
            if (CurOpenQty.Text == null || CurOpenQty.Text == "") { CurOpenQty.Text = "0"; }
            if (CurOpenValue.Text == null || CurOpenValue.Text == "") { CurOpenValue.Text = "0"; }

            if (PrevProdQty.Text == null || PrevProdQty.Text == "") { PrevProdQty.Text = "0"; }
            if (PrevProdValue.Text == null || PrevProdValue.Text == "") { PrevProdValue.Text = "0"; }
            if (CurProdQty.Text == null || CurProdQty.Text == "") { CurProdQty.Text = "0"; }
            if (CurProdValue.Text == null || CurProdValue.Text == "") { CurProdValue.Text = "0"; }

            if (PrevSalesRtnQty.Text == null || PrevSalesRtnQty.Text == "") { PrevSalesRtnQty.Text = "0"; }
            if (PrevSalesRtnValue.Text == null || PrevSalesRtnValue.Text == "") { PrevSalesRtnValue.Text = "0"; }
            if (CurSalesRtnQty.Text == null || CurSalesRtnQty.Text == "") { CurSalesRtnQty.Text = "0"; }
            if (CurSalesRtnValue.Text == null || CurSalesRtnValue.Text == "") { CurSalesRtnValue.Text = "0"; }


            if (PrevSalesQty.Text == null || PrevSalesQty.Text == "") { PrevSalesQty.Text = "0"; }
            if (PrevSalesValue.Text == null || PrevSalesValue.Text == "") { PrevSalesValue.Text = "0"; }
            if (CurSalesQty.Text == null || CurSalesQty.Text == "") { CurSalesQty.Text = "0"; }
            if (CurSalesValue.Text == null || CurSalesValue.Text == "") { CurSalesValue.Text = "0"; }

            if (PrevSampleQty.Text == null || PrevSampleQty.Text == "") { PrevSampleQty.Text = "0"; }
            if (PrevSampleValue.Text == null || PrevSampleValue.Text == "") { PrevSampleValue.Text = "0"; }
            if (CurSampleQty.Text == null || CurSampleQty.Text == "") { CurSampleQty.Text = "0"; }
            if (CurSampleValue.Text == null || CurSampleValue.Text == "") { CurSampleValue.Text = "0"; }

            if (PrevClosingQty.Text == null || PrevClosingQty.Text == "") { PrevClosingQty.Text = "0"; }
            if (PrevClosingValue.Text == null || PrevClosingValue.Text == "") { PrevClosingValue.Text = "0"; }
            if (CurClosingQty.Text == null || CurClosingQty.Text == "") { CurClosingQty.Text = "0"; }
            if (CurClosingValue.Text == null || CurClosingValue.Text == "") { CurClosingValue.Text = "0"; }

            if (PrevShortageQty.Text == null || PrevShortageQty.Text == "") { PrevShortageQty.Text = "0"; }
            if (PrevShortageValue.Text == null || PrevShortageValue.Text == "") { PrevShortageValue.Text = "0"; }
            if (CurShortageQty.Text == null || CurShortageQty.Text == "") { CurShortageQty.Text = "0"; }
            if (CurShortageValue.Text == null || CurShortageValue.Text == "") { CurShortageValue.Text = "0"; }

            UptoOpenQty.Text =(Convert.ToDecimal(PrevOpenQty.Text)).ToString();
            UptoOpenValue.Text = (Convert.ToDecimal(PrevOpenValue.Text)).ToString();

            UptoProdQty.Text = (Convert.ToDecimal(PrevProdQty.Text) + Convert.ToDecimal(CurProdQty.Text)).ToString();
            UptoProdValue.Text = (Convert.ToDecimal(PrevProdValue.Text) + Convert.ToDecimal(CurProdValue.Text)).ToString();

            UptoSalesRtnQty.Text = (Convert.ToDecimal(PrevSalesRtnQty.Text) + Convert.ToDecimal(CurSalesRtnQty.Text)).ToString();
            UptoSalesRtnValue.Text = (Convert.ToDecimal(PrevSalesRtnValue.Text) + Convert.ToDecimal(CurSalesRtnValue.Text)).ToString();

            UptoSalesQty.Text = (Convert.ToDecimal(PrevSalesQty.Text) + Convert.ToDecimal(CurSalesQty.Text)).ToString();
            UptoSalesValue.Text = (Convert.ToDecimal(PrevSalesValue.Text) + Convert.ToDecimal(CurSalesValue.Text)).ToString();

            UptoSampleQty.Text = (Convert.ToDecimal(PrevSampleQty.Text) + Convert.ToDecimal(CurSampleQty.Text)).ToString();
            UptoSampleValue.Text = (Convert.ToDecimal(PrevSampleValue.Text) + Convert.ToDecimal(CurSampleValue.Text)).ToString();

            UptoClosingQty.Text =  (Convert.ToDecimal(CurClosingQty.Text)).ToString();
            UptoClosingValue.Text = (Convert.ToDecimal(CurClosingValue.Text)).ToString();

            UptoShortageQty.Text = (Convert.ToDecimal(PrevShortageQty.Text) + Convert.ToDecimal(CurShortageQty.Text)).ToString();
            UptoShortageValue.Text = (Convert.ToDecimal(PrevShortageValue.Text) + Convert.ToDecimal(CurShortageValue.Text)).ToString();

      



        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        
    }

}
