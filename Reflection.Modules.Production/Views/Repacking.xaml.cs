using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for Repacking.xaml
    /// </summary>
    public partial class Repacking : WindowElement
    {
        public Repacking()
        {
            InitializeComponent();
            this.DataContext = new EPR_T003RepackingVM();
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupBall.UnselectAll();
                //dgPopupMachine.UnselectAll();
                dgPopupProduct.UnselectAll();
                dgPopupUnit.UnselectAll();
                dgPopupILD.UnselectAll();
                dgPopupINK.UnselectAll();
                dgPopupPackingUnit.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
