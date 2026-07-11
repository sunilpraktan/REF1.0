using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Reflection.Presentation.Services;

namespace Reflection.ReportingServices
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        Microsoft.Reporting.WinForms.ReportDataSource rptDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
        private bool _isReportViewerLoaded;


        public ReportWindow()
        {
            InitializeComponent();
            //_reportViewer.Load += ReportViewer_Load;
        }

        /// <summary>
        /// Type:Absolute. Status:Deletion Pending.
        /// </summary>
        public ReportWindow(object objDataSourceValue, string rptDataSourceName, string strReportName)
        {
            InitializeComponent();
            ShowReport(objDataSourceValue, rptDataSourceName, strReportName);
        }

        /// <summary>
        /// Type:Absolute. Status:Deletion Pending.
        /// </summary>
        public ReportWindow(object objDataSourceValue, string rptDataSourceName, string strReportName, Dictionary<string, string> Parameters)
        {
            InitializeComponent();
            ShowReport(objDataSourceValue, rptDataSourceName, strReportName, Parameters);
        }

        /// <summary>
        /// Type:Absolute. Status:Deletion Pending.
        /// </summary>
        public ReportWindow(object[] objDataSourceValue, string rptDataSourceName, string strReportName)
        {
            InitializeComponent();
            ShowReport(objDataSourceValue, rptDataSourceName, strReportName);
        }

        

        /// <summary>
        /// Type:Absolute. Status:Deletion Pending.
        /// </summary>
        private void ShowReport(object objDataSourceValue, string rptDataSourceName, string strReportName, Dictionary<string, string> Parameters)
        {
            if (!_isReportViewerLoaded)
            {
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                rptDataSource.Name = rptDataSourceName;
                rptDataSource.Value = objDataSourceValue;
                this._reportViewer.LocalReport.DataSources.Add(rptDataSource);
                //this._reportViewer.LocalReport.ReportEmbeddedResource = strReportName;
                this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName; // @"\Admin\ItemMasterReport.rdlc";              
                _reportViewer.LocalReport.SetParameters(GetReportParametersFromDictionary(Parameters));
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }

        /// <summary>
        /// Type:Absolute. Status:Deletion Pending.
        /// </summary>
        private void ShowReport(object objDataSourceValue, string rptDataSourceName, string strReportName)
        {
            if (!_isReportViewerLoaded)
            {
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                rptDataSource.Name = rptDataSourceName;
                rptDataSource.Value = objDataSourceValue;
                this._reportViewer.LocalReport.DataSources.Add(rptDataSource);
                this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName;
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }

        private void ShowReport(object[] objDataSourceValue, string rptDataSourceName, string strReportName)
        {
            if (!_isReportViewerLoaded)
            {
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                rptDataSource.Name = rptDataSourceName;
                rptDataSource.Value = objDataSourceValue;
                //this._reportViewer.LocalReport.DataSources.Add(rptDataSource);

                ReportDataSource rd2 = new ReportDataSource("dsPurchaseOrder1", objDataSourceValue[1]);
                ReportDataSource rd1 = new ReportDataSource("dsPurchaseOrder", objDataSourceValue[0]);
                this._reportViewer.LocalReport.DataSources.Add(rd2);
                this._reportViewer.LocalReport.DataSources.Add(rd1);

                //this._reportViewer.LocalReport.ReportEmbeddedResource = strReportName;               
                this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName; // @"\Admin\ItemMasterReport.rdlc";            

                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }

        //===================================WORKING METHODS SECTION=====================================================

        /// <summary>
        /// Report Mehod without Parameter input.
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        public ReportWindow(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName,string DisplayName)
        {
            InitializeComponent();
            ShowReport(objDataSourceValue, rptDataSourceName, strReportName, DisplayName);
        }
        /// <summary>
        /// Report Mehod without Parameter input.
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        private void ShowReport(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, string DisplayName) 
        {
            if (!_isReportViewerLoaded)
            {
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                for (int i = 0; i < rptDataSourceName.Length; i++)
                {
                    this._reportViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSourceName[i], objDataSourceValue[i]));
                }
                this._reportViewer.LocalReport.DisplayName = DisplayName;
                this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName;            
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
        /// <summary>
        /// Report Mehod with Parameter input.
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        public ReportWindow(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters,string DisplayName)
        {
            InitializeComponent();
            ShowReport(objDataSourceValue, rptDataSourceName, strReportName, Parameters, DisplayName);
        }
        /// <summary>
        /// Report Mehod with Parameter input. and Stream Object 
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        public ReportWindow(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters, string DisplayName, byte[] StreamObject)
        {
            InitializeComponent();
            ShowReport(objDataSourceValue, rptDataSourceName, strReportName, Parameters, DisplayName, StreamObject);
        }
        /// <summary>
        /// Report Mehod without Parameter input.
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        private void ShowReport(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters, string DisplayName)
        {
            if (!_isReportViewerLoaded)
            {
                //string exeFolder = AppSessionState.WebReportDirectory; //NOTE: use this path if report folder in host project.
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                for (int i = 0; i < rptDataSourceName.Length; i++)
                {
                    this._reportViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSourceName[i].ToString(), objDataSourceValue[i]));
                }
                this._reportViewer.LocalReport.EnableExternalImages = true;
                this._reportViewer.LocalReport.DisplayName = DisplayName;
                this._reportViewer.LocalReport.EnableHyperlinks = true;
                this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName;
                _reportViewer.LocalReport.SetParameters(GetReportParametersFromDictionary(Parameters));
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
        /// <summary>
        /// Report Mehod without Parameter input. and additional stream object
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        private void ShowReport(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters, string DisplayName,byte[] StreamObject)
        {
            if (!_isReportViewerLoaded)
            {
                //string exeFolder = AppSessionState.WebReportDirectory; //NOTE: use this path if report folder in host project.
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                for (int i = 0; i < rptDataSourceName.Length; i++)
                {
                    this._reportViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSourceName[i].ToString(), objDataSourceValue[i]));
                }
                this._reportViewer.LocalReport.EnableExternalImages = true;
                this._reportViewer.LocalReport.DisplayName = DisplayName;
                //this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName;
                using (MemoryStream reportStream = new MemoryStream(StreamObject)) // Assuming reportBytes is the byte array
                {
                    this._reportViewer.LocalReport.LoadReportDefinition(reportStream);
                }
                _reportViewer.LocalReport.SetParameters(GetReportParametersFromDictionary(Parameters));
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
        /// <summary>
        /// Report Mehod without Parameter input.
        /// Parameters : Array of DataSource and Datasource Name.
        /// </summary>
        private void ShowReportOrg(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters, string DisplayName)
        {
            if (!_isReportViewerLoaded)
            {
                //string exeFolder = AppSessionState.WebReportDirectory; //NOTE: use this path if report folder in host project.
                string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                for (int i = 0; i < rptDataSourceName.Length; i++)
                {
                    this._reportViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSourceName[i].ToString(), objDataSourceValue[i]));
                }
                this._reportViewer.LocalReport.EnableExternalImages = true;
                this._reportViewer.LocalReport.DisplayName = DisplayName;
                this._reportViewer.LocalReport.ReportPath = exeFolder + strReportName;
                _reportViewer.LocalReport.SetParameters(GetReportParametersFromDictionary(Parameters));
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }

        public static List<ReportParameter> GetReportParametersFromDictionary(Dictionary<string, string> source)
        {
            List<ReportParameter> result = new List<ReportParameter>();
            foreach (KeyValuePair<string, string> pair in source)
            {
                ReportParameter param = new ReportParameter(pair.Key, pair.Value);
                result.Add(param);
            }
            return result;
        }

    }
}
