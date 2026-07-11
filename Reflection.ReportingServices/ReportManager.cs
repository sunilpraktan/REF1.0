using Microsoft.Reporting.WinForms;
using Reflection.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.ReportingServices
{
    public class ReportManager
    {
        //Type:Absolute. Status:Deletion Pending. Reference:EQCR_T001_VM
        public void DisplayReport(object objDataSourceValue, string rptDataSourceName, string strReportName)
        {
            ReportWindow rptWin = new ReportWindow(objDataSourceValue, rptDataSourceName, strReportName);
            rptWin.Show();
        }

        //Type:Absolute. Status:Deletion Pending. Reference:EQCR_T001_VM
        public void DisplayReport(object objDataSourceValue, string rptDataSourceName, string strReportName, Dictionary<string, string> Parameters)
        {
            ReportWindow rptWin = new ReportWindow(objDataSourceValue, rptDataSourceName, strReportName, Parameters);
            rptWin.Show();
        }
        //Type:Absolute. Status:Deletion Pending. Reference:EQCR_T001_VM
        public void DisplayReport(object[] objDataSourceValue, string rptDataSourceName, string strReportName)
        {
            ReportWindow rptWin = new ReportWindow(objDataSourceValue, rptDataSourceName, strReportName);
            rptWin.Show();
        }



        //========================================WORKING======================================================
        // 1
        public void DisplayReport(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, string DisplayName) 
        {
            ReportWindow rptWin = new ReportWindow(objDataSourceValue, rptDataSourceName, strReportName, DisplayName);
            rptWin.Show();
        }
        //2
        public void DisplayReport(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters, string DisplayName)
        {
            ReportWindow rptWin = new ReportWindow(objDataSourceValue, rptDataSourceName, strReportName, Parameters, DisplayName);
            rptWin.Show();
        }
        // 3 Same as 2 with additional byte[] parameter. NOTE: use this for rdlc file at web service folder
        public void DisplayReport(object[] objDataSourceValue, string[] rptDataSourceName, string strReportName, Dictionary<string, string> Parameters, string DisplayName,byte[] StreamObject)
        {
            ReportWindow rptWin = new ReportWindow(objDataSourceValue, rptDataSourceName, strReportName, Parameters, DisplayName,StreamObject);
            rptWin.Show();
        }
        public void Mail(string To, string Cc, string Bcc, object[] objDataSourceValue, string[] rptDataSourceName, Dictionary<string, string> Parameters, string strReportName, string DisplayName, string subject, string message, string file_name, string file_extension)
        {
            //ReportWindow rptWin = new ReportWindow(To, Cc, Bcc, objDataSourceValue, rptDataSourceName, Parameters, strReportName, DisplayName, subject, message, file_name, file_extension);
            //rptWin.Show();
            MailReport(To, Cc, Bcc, objDataSourceValue, rptDataSourceName, Parameters, strReportName, DisplayName, subject, message, file_name, file_extension);
        }

        private void MailReport(string To, string Cc, string Bcc, object[] objDataSourceValue, string[] rptDataSourceName, Dictionary<string, string> Parameters, string strReportName, string DisplayName, string subject, string message, string file_name, string file_extension)
        {
            Microsoft.Reporting.WinForms.ReportViewer _reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();

            string exeFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            for (int i = 0; i < rptDataSourceName.Length; i++)
            {
                _reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(rptDataSourceName[i], objDataSourceValue[i]));
            }
            _reportViewer.LocalReport.DisplayName = DisplayName;
            _reportViewer.LocalReport.ReportPath = exeFolder + strReportName;
            if (Parameters != null)
            {
                if (Parameters.Count > 0)
                {
                    _reportViewer.LocalReport.SetParameters(GetReportParametersFromDictionary(Parameters));
                }
            }
            _reportViewer.RefreshReport();

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            string filename = System.IO.Path.Combine(System.IO.Path.GetTempPath(), DisplayName + file_extension);
            byte[] bytes = _reportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = File.Create(Path.Combine(filename)))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            string str_mail = To.ToString();
            Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, To, Cc, Bcc, subject, message, filename);
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
