using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Controls;
using System;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0034.xaml
    /// </summary>
    public partial class FICO_M0034 : WindowElement
    {
        public FICO_M0034()
        {
            InitializeComponent();
            this.DataContext = new FICO_M0034_VM();
        }
        public FICO_M0034(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new FICO_M0034_VM();
        }

        private bool isManualEditCommit;
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                int x = grid.Items.Count;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        //proxy class is used for creating dynamic columns of Datagrid
        public class BindingProxy : Freezable
        {
            #region Overrides of Freezable

            protected override Freezable CreateInstanceCore()
            {
                return new BindingProxy();
            }

            #endregion

            public object Data
            {
                get { return (object)GetValue(DataProperty); }
                set { SetValue(DataProperty, value); }
            }

            // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty DataProperty =
             DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
        }
    }
}
