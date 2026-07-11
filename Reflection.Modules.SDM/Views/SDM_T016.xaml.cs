using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T016.xaml
    /// </summary>
    public partial class SDM_T016 :  WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_T016(string ts_code)//, string doc_cat
        {
            InitializeComponent();
            this.DataContext = new SDM_T016_VM(ts_code, "SM");
        }
        public SDM_T016(string ts_code, string doc_no) //, string doc_cat
        {
            InitializeComponent();
            this.DataContext = new SDM_T016_VM(ts_code, "SM", doc_no);
        }

        private bool isManualEditCommit;

        //This will update the bound object whenever a cell edit is ending, i.e.whenever the cell looses focus.
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

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            //DataGridExportToExcel<TSK_T001_C> exp = new DataGridExportToExcel<TSK_T001_C>();
            
            //var data = (ObservableCollection<TSK_T001_C>)dgVisibilityGrid.ItemsSource;
            //exp.ExportExcel(dgVisibilityGrid,0,0);

            this.dgVisibilityGrid.SelectAllCells();
            this.dgVisibilityGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.dgVisibilityGrid);
            this.dgVisibilityGrid.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                //string newFolder = "TempFiles";
                //string path = System.IO.Path.Combine(
                //   Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                //   newFolder
                //);
                //if (!Directory.Exists(path))
                //{
                //    // Try to create the directory.
                //    DirectoryInfo di = Directory.CreateDirectory(path);
                //}

                //System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
                if (!Directory.Exists("C:\\ReflectionFiles"))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory("C:\\ReflectionFiles");
                }

                System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\ReflectionFiles\\Activity.csv");
                sw.WriteLine(result);
                sw.Close();
                sw.Flush();
                //System.Diagnostics.Process.Start("Activity.csv");
            }
            catch (Exception ex)
            { }


        }


    }
}
