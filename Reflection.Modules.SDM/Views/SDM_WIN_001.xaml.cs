using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Reflection.BusinessEntity;
using MessageBox = System.Windows.MessageBox;
using Microsoft.Win32;
using System.Data;
using Reflection.Presentation.Services;
using Reflection.Presentation.Common;
using Reflection.WebServices.Gateway;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for WIN_001.xaml
    /// </summary>
    public partial class SDM_WIN_001 : Window
    {
        WebServiceRepository<List<SEL_T001>> REPO_MC = new WebServiceRepository<List<SEL_T001>>();
        public string ts_code_vm { get; set; }
        private MC_SDM_BE _MC = new MC_SDM_BE();
        public MC_SDM_BE MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;
                }
            }
        }
        private List<SEL_T001> _OBJ_COL;
        public List<SEL_T001> OBJ_COL
        {
            get
            {
                return _OBJ_COL;
            }
            set
            {
                if (_OBJ_COL != value)
                {
                    _OBJ_COL = value;
                }
            }
        }

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                }
            }
        }

        public SDM_WIN_001(string ts_code)
        {
            this.ts_code_vm = ts_code;
            OBJ_COL = new List<SEL_T001>();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            InitializeComponent();
        }
        public SDM_WIN_001(string ts_code,List<STD_LIST_BE> list_object)
        {
            this.ts_code_vm = ts_code;
            OBJ_COL = new List<SEL_T001>();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            InitializeComponent();

        }


        /// <summary>
        /// this method will choose and read the excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void BtnFile_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
        //    if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file chosen by the user
        //    {
        //        string fileExt = Path.GetExtension(file.FileName); //get the file extension
        //        if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
        //        {
        //            try
        //            {
        //                //DataTable dtExcel = ReadExcel(file.FileName); //read excel file
        //                //dataGrdView.Visible = true;
        //                //dataGrdView.DataSource = dtExcel;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message.ToString());
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning"); //custom messageBox to show error. //, MessageBoxButtons.OK, MessageBoxIcon.Error
        //        }
        //    }
        //}


        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openfile = new Microsoft.Win32.OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                txtFilePath.Text = openfile.FileName;

                ImportExcelToDataGrid objimport = new ImportExcelToDataGrid();
                OBJ_COL = objimport.ImportExcelLead(txtFilePath.Text);
                DataLV.ItemsSource = OBJ_COL; // objimport.ImportExcelLead(txtFilePath.Text);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CursorControl.SetBusyState();

                //string Request = "IMPORT_LEAD" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "SN" + "!@" + "SN" + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                string strReturn = REPO_MC.Save<List<SEL_T001>>(OBJ_COL, "SEL_T001_IMPORT", "SDM");
                MessageBox.Show("Import process completed successfully!", "Update Message", MessageBoxButton.OK);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error Message",MessageBoxButton.OK); }

        }
    }
}
