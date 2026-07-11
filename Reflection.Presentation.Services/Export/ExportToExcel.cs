using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Windows.Controls;
using Reflection.BusinessEntity.CustomerRelation;
using System.Data;
using Reflection.BusinessEntity;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// Class for generator of Excel file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class ExportToExcel<T, U>
        where T : class
        where U : List<T>
    {
        public List<T> ListCollectionData;
        // Excel object references.
        private Microsoft.Office.Interop.Excel.Application _excelApp = null;
        private Microsoft.Office.Interop.Excel.Workbooks _books = null;
        private Microsoft.Office.Interop.Excel._Workbook _book = null;
        private Microsoft.Office.Interop.Excel.Sheets _sheets = null;
        private Microsoft.Office.Interop.Excel._Worksheet _sheet = null;
        private Microsoft.Office.Interop.Excel.Range _range = null;
        private Microsoft.Office.Interop.Excel.Font _font = null;
        // Optional argument variable
        private object _optionalValue = Missing.Value;

        /// <summary>
        /// Generate report and sub functions
        /// </summary>
        public void GenerateReport()
        {
            try
            {
                if (ListCollectionData != null)
                {
                    if (ListCollectionData.Count != 0)
                    {
                        Mouse.SetCursor(Cursors.Wait);
                        CreateExcelRef();
                        FillSheet();
                        OpenReport();
                        Mouse.SetCursor(Cursors.Arrow);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while generating Excel report");
            }
            finally
            {
                ReleaseObject(_sheet);
                ReleaseObject(_sheets);
                ReleaseObject(_book);
                ReleaseObject(_books);
                ReleaseObject(_excelApp);
            }
        }

        /// <summary>
        /// Make MS Excel application visible
        /// </summary>
        private void OpenReport()
        {
            _excelApp.Visible = true;
        }
        /// <summary>
        /// Populate the Excel sheet
        /// </summary>
        private void FillSheet()
        {
            object[] header = CreateHeader();
            WriteData(header);
        }
        /// <summary>
        /// Write data into the Excel sheet
        /// </summary>
        /// <param name="header"></param>
        private void WriteData(object[] header)
        {
            object[,] objData = new object[ListCollectionData.Count, header.Length];

            for (int j = 0; j < ListCollectionData.Count; j++)
            {
                var item = ListCollectionData[j];
                for (int i = 0; i < header.Length; i++)
                {
                    var y = typeof(T).InvokeMember(header[i].ToString(), BindingFlags.GetProperty, null, item, null);
                    objData[j, i] = (y == null) ? "" : y.ToString();
                }
            }
            AddExcelRows("A2", ListCollectionData.Count, header.Length, objData);
            AutoFitColumns("A1", ListCollectionData.Count + 1, header.Length);
        }
        /// <summary>
        /// Method to make columns auto fit according to data
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        private void AutoFitColumns(string startRange, int rowCount, int colCount)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.Columns.AutoFit();
        }
        /// <summary>
        /// Create header from the properties
        /// </summary>
        /// <returns></returns>
        private object[] CreateHeader()
        {
            PropertyInfo[] headerInfo = typeof(T).GetProperties();

            // Create an array for the headers and add it to the
            // worksheet starting at cell A1.
            List<object> objHeaders = new List<object>();
            for (int n = 0; n < headerInfo.Length; n++)
            {
                objHeaders.Add(headerInfo[n].Name);
            }

            var headerToAdd = objHeaders.ToArray();
            AddExcelRows("A1", 1, headerToAdd.Length, headerToAdd);
            SetHeaderStyle();

            return headerToAdd;
        }
        /// <summary>
        /// Set Header style as bold
        /// </summary>
        private void SetHeaderStyle()
        {
            _font = _range.Font;
            _font.Bold = true;
        }
        /// <summary>
        /// Method to add an excel rows
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <param name="values"></param>
        private void AddExcelRows(string startRange, int rowCount, int colCount, object values)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.set_Value(_optionalValue, values);
        }
        /// <summary>
        /// Create Excel applicaiton parameters instances
        /// </summary>
        private void CreateExcelRef()
        {
            _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _books = (Microsoft.Office.Interop.Excel.Workbooks)_excelApp.Workbooks;
            _book = (Microsoft.Office.Interop.Excel._Workbook)(_books.Add(_optionalValue));
            _sheets = (Microsoft.Office.Interop.Excel.Sheets)_book.Worksheets;
            _sheet = (Microsoft.Office.Interop.Excel._Worksheet)(_sheets.get_Item(1));
        }
        /// <summary>
        /// Release unused COM objects
        /// </summary>
        /// <param name="obj"></param>
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }


    /// <summary>
    /// Class for generator of Excel file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class ExportToExcelFromOC<T, U>
        where T : class
        where U : List<T>
    {
        public ObservableCollection<T> OCCollectionData;
        // Excel object references.
        private Microsoft.Office.Interop.Excel.Application _excelApp = null;
        private Microsoft.Office.Interop.Excel.Workbooks _books = null;
        private Microsoft.Office.Interop.Excel._Workbook _book = null;
        private Microsoft.Office.Interop.Excel.Sheets _sheets = null;
        private Microsoft.Office.Interop.Excel._Worksheet _sheet = null;
        private Microsoft.Office.Interop.Excel.Range _range = null;
        private Microsoft.Office.Interop.Excel.Font _font = null;
        // Optional argument variable
        private object _optionalValue = Missing.Value;

        /// <summary>
        /// Generate report and sub functions
        /// </summary>
        public void GenerateReport()
        {
            try
            {
                if (OCCollectionData != null)
                {
                    if (OCCollectionData.Count != 0)
                    {
                        Mouse.SetCursor(Cursors.Wait);
                        CreateExcelRef();
                        FillSheet();
                        OpenReport();
                        Mouse.SetCursor(Cursors.Arrow);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while generating Excel report");
            }
            finally
            {
                ReleaseObject(_sheet);
                ReleaseObject(_sheets);
                ReleaseObject(_book);
                ReleaseObject(_books);
                ReleaseObject(_excelApp);
            }
        }

        /// <summary>
        /// Make MS Excel application visible
        /// </summary>
        private void OpenReport()
        {
            _excelApp.Visible = true;
        }
        /// <summary>
        /// Populate the Excel sheet
        /// </summary>
        private void FillSheet()
        {
            object[] header = CreateHeader();
            WriteData(header);
        }
        /// <summary>
        /// Write data into the Excel sheet
        /// </summary>
        /// <param name="header"></param>
        private void WriteData(object[] header)
        {
            object[,] objData = new object[OCCollectionData.Count, header.Length];

            for (int j = 0; j < OCCollectionData.Count; j++)
            {
                var item = OCCollectionData[j];
                for (int i = 0; i < header.Length; i++)
                {
                    var y = typeof(T).InvokeMember(header[i].ToString(), BindingFlags.GetProperty, null, item, null);
                    objData[j, i] = (y == null) ? "" : y.ToString();
                }
            }
            AddExcelRows("A2", OCCollectionData.Count, header.Length, objData);
            AutoFitColumns("A1", OCCollectionData.Count + 1, header.Length);
        }
        /// <summary>
        /// Method to make columns auto fit according to data
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        private void AutoFitColumns(string startRange, int rowCount, int colCount)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.Columns.AutoFit();
        }
        /// <summary>
        /// Create header from the properties
        /// </summary>
        /// <returns></returns>
        private object[] CreateHeader()
        {
            PropertyInfo[] headerInfo = typeof(T).GetProperties();

            // Create an array for the headers and add it to the
            // worksheet starting at cell A1.
            List<object> objHeaders = new List<object>();
            for (int n = 0; n < headerInfo.Length; n++)
            {
                objHeaders.Add(headerInfo[n].Name);
            }

            var headerToAdd = objHeaders.ToArray();
            AddExcelRows("A1", 1, headerToAdd.Length, headerToAdd);
            SetHeaderStyle();

            return headerToAdd;
        }
        /// <summary>
        /// Set Header style as bold
        /// </summary>
        private void SetHeaderStyle()
        {
            _font = _range.Font;
            _font.Bold = true;
        }
        /// <summary>
        /// Method to add an excel rows
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <param name="values"></param>
        private void AddExcelRows(string startRange, int rowCount, int colCount, object values)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.set_Value(_optionalValue, values);
        }
        /// <summary>
        /// Create Excel applicaiton parameters instances
        /// </summary>
        private void CreateExcelRef()
        {
            _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _books = (Microsoft.Office.Interop.Excel.Workbooks)_excelApp.Workbooks;
            _book = (Microsoft.Office.Interop.Excel._Workbook)(_books.Add(_optionalValue));
            _sheets = (Microsoft.Office.Interop.Excel.Sheets)_book.Worksheets;
            _sheet = (Microsoft.Office.Interop.Excel._Worksheet)(_sheets.get_Item(1));
        }
        /// <summary>
        /// Release unused COM objects
        /// </summary>
        /// <param name="obj"></param>
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }

    // <summary>
    /// Class for generator of Excel file. add by Sunil on 28/11/2017 new additional class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class ExportToExcelNew
    {
        public bool CheckWhetherOfficeInstalled()
        {
            // Checking whether excel is installed on system
            RegistryKey TargetKey = default(RegistryKey);
            TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application");
            if (TargetKey == null)
            {
                // MessageBox.Show("Install Office", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }
            else
            {
                return true;
            }
        }

        public void ExportExcel(System.Windows.Forms.DataGridView dgv, string rptName, int inFirstRow, int inFirstCol, string Format, object dtFromDate, object dtToDate, string header)//, string credit, string debit, string closing)
        {
            try
            {
                if (CheckWhetherOfficeInstalled())
                {
                    int inColN = 1;
                    //System.Windows.Input.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    string strName = "", strAddress = "", strPhone = "";

                    Excel.Range range = null;
                    Excel.Application excel = new Excel.Application();

                    Excel.Workbook wb = excel.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
                    Excel.Worksheet ws = (Excel.Worksheet)excel.ActiveSheet;


                    strAddress = "Maharashtra, India"; //dtblCompany.Rows[0].ItemArray[3].ToString().Replace("\r\n", " ");
                    strPhone = "9422246722";
                    strName = "Praktan Technologies";

                    //BranchInfo InfoBranch = new BranchInfo();
                    //BranchSP SpBranch = new BranchSP();
                    //InfoBranch = SpBranch.BranchView(PublicVariables._branchId);
                    //strAddress = InfoBranch.Address.Replace("\r\n", " ");
                    //if (InfoBranch.PhoneNo == "")
                    //{
                    //    strPhone = InfoBranch.Mobile;
                    //}
                    //else
                    //{
                    //    strPhone = InfoBranch.PhoneNo;
                    //}
                    //strName = InfoBranch.BranchName;

                    //**************Report Header ***************************************
                    //range = (Excel.Range)ws.Cells[1, 1];
                    range = ws.get_Range("A1", "I1");
                    range.MergeCells = true;
                    range.Font.Size = 15;
                    range.RowHeight = 27;
                    range.Interior.Color = ColorTranslator.ToWin32(Color.LightGray);
                    range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    range.Value2 = strName;

                    range = ws.get_Range("A2", "I2");
                    range.MergeCells = true;
                    range.Font.Size = 10;

                    range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.Value2 = strAddress;

                    range = ws.get_Range("A3", "I3");
                    range.MergeCells = true;
                    range.Font.Size = 10;

                    range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.Value2 = "Phone No :" + strPhone;

                    range = ws.get_Range("A5", "G5");
                    range.MergeCells = true;
                    range.Font.Size = 11;
                    range.Value2 = rptName;
                    range.Font.Underline = true;
                    range.Font.Bold = true;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    range = ws.get_Range("A6", "G6");
                    range.MergeCells = true;
                    //range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.Font.Size = 11;
                    if (dtFromDate != null && dtToDate != null)
                    {
                        range.Value2 = "(" + DateTime.Parse(dtFromDate.ToString()).Date.ToString("dd-MMM-yyyy") + "  To  " + DateTime.Parse(dtToDate.ToString()).Date.ToString("dd-MMM-yyyy") + ")";
                    }
                    else if (dtFromDate != null)
                    {
                        range.Value2 = DateTime.Parse(dtFromDate.ToString()).Date.ToString("dd-MMM-yyyy");
                    }
                    range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.MergeCells = true;
                    range.Font.Bold = true;


                    range = ws.get_Range("H5", "H5");
                    range.Value2 = "Date :";
                    range.Font.Bold = true;

                    range = ws.get_Range("I5", "I5");
                    range.Value2 =  DateTime.Now.ToShortDateString(); //PublicVariables._dtCurrentDate.Date.ToString("dd-MMM-yyyy");
                    range.Font.Bold = true;




                    int inNewRow = 0;
                    inNewRow = inFirstRow;


                    for (int inRow = inFirstRow; inRow < dgv.Rows.Count; inRow++)
                    {
                        if (dgv.Rows[inRow].Visible != false)
                        {
                            for (int inCol = inFirstCol; inCol < dgv.Columns.Count; inCol++)
                            {
                                if (inRow == 0)
                                {
                                    if (dgv.Columns[inCol].Visible == true)
                                    {
                                        range = (Excel.Range)ws.Cells[inNewRow + 8, inColN];
                                        range.Font.Bold = true;
                                        range.Interior.Color = ColorTranslator.ToWin32(Color.LightGray);
                                        range.Value2 = dgv.Columns[inCol].HeaderText;
                                    }
                                }
                                range = (Excel.Range)ws.Cells[inNewRow + 9, inColN];

                                if (dgv[inCol, inRow].Style.Font != null)
                                {
                                    if (dgv[inCol, inRow].Style.Font.Bold)
                                    {
                                        range.Font.Bold = true;
                                    }
                                }
                                if (dgv.Rows[inRow].DefaultCellStyle.BackColor == Color.LightSkyBlue)
                                {
                                    range.Font.Bold = true;
                                    range.Interior.Color = ColorTranslator.ToWin32(Color.LightGray);

                                }
                                if (dgv.Rows[inRow].DefaultCellStyle.ForeColor == Color.Red)
                                {
                                    range.Font.Bold = true;
                                    range.Interior.Color = ColorTranslator.ToWin32(Color.LightGray);

                                }

                                //if (dgv.Rows[inRow].Visible != false)
                                //{
                                if (dgv.Columns[inCol].Visible == true)
                                {

                                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                                    if (dgv[inCol, inRow].Value != null)
                                    {
                                        string str = dgv[inCol, inRow].Value.ToString();

                                        try
                                        {
                                            if (dgv.Columns[inCol].HeaderText.Replace(" ", "").ToLower() == "phoneno" || dgv.Columns[inCol].HeaderText.Replace(" ", "").ToLower() == "phonenumber")
                                                range.NumberFormat = "@";
                                            else
                                            {
                                                decimal.Parse(str);
                                                decimal dc = Math.Round(decimal.Parse(str), 2);
                                                str = dc.ToString();
                                                if (dgv.Columns[inCol].Name.ToLower() == "debit" || dgv.Columns[inCol].Name.ToLower() == "credit")
                                                    range.NumberFormat = "#00.00#";
                                                else
                                                    range.NumberFormat = "General";
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            try
                                            {
                                                DateTime.Parse(str);
                                                range.NumberFormat = "dd-MMM-yyyy";
                                                range.NumberFormat = "General";
                                            }
                                            catch (Exception)
                                            {
                                                range.NumberFormat = "@";
                                            }
                                        }
                                        if (str.Contains("Dr") || str.Contains("Cr"))

                                            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                                        //try
                                        //{
                                        //    if (dgv.Columns[inCol].HeaderText.Replace(" ", "").ToLower() == "phoneno" || dgv.Columns[inCol].HeaderText.Replace(" ", "").ToLower() == "phonenumber")
                                        //        range.NumberFormat = "@";
                                        //    else
                                        //    {
                                        //        decimal.Parse(str);
                                        //        decimal dc = Math.Round(decimal.Parse(str), 2);
                                        //        str = dc.ToString();
                                        //    }
                                        //}
                                        //catch (Exception)
                                        //{
                                        //    try
                                        //    {
                                        //        DateTime.Parse(str);
                                        //        range.NumberFormat = "dd-MMM-yyyy";
                                        //        range.NumberFormat = "General";
                                        //    }
                                        //    catch (Exception)
                                        //    {
                                        //        //range.NumberFormat = "@";
                                        //        range.NumberFormat = "General";
                                        //    }
                                        //}
                                        //------------------------------------
                                        //------------------------------------
                                        range.Value2 = str;// dgv[inCol, inRow].Value;

                                    }
                                    inColN++;
                                }
                                //}
                            }
                            inColN = 1;
                            inNewRow++;
                        }
                    }
                    inNewRow = inNewRow + 10;


                    ws.Columns.AutoFit();

                    if (Format == "Excel")
                    {
                        excel.Visible = true;
                    }
                    //else if (Format == "Html")
                    //{
                    //    //***********Deleting all format*************
                    //    ws.Columns.AutoFit();
                    //    FileInfo infoHtml = new FileInfo(Application.StartupPath + "\\Report.html");
                    //    if (infoHtml.Exists)
                    //    {
                    //        infoHtml.Delete();
                    //    }
                    //    //*******************************************

                    //    ws.SaveAs(Application.StartupPath + "\\Report.html", Excel.XlFileFormat.xlHtml, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    //    excel.Quit();
                    //    System.Diagnostics.Process.Start("IExplore.exe", Application.StartupPath + "\\Report.html");
                    //}
                    //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Install office", "Reflection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Reflection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

    }


    /// <summary>
    /// Class for generator of Excel file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class DataGridExportToExcel<T>
    {
        public ObservableCollection<T> OCCollectionData;
        public void ExportExcel(System.Windows.Controls.DataGrid dg, int inFirstRow, int inFirstCol)//, string credit, string debit, string closing)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range rangeToHoldHyperlink;
            Excel.Range CellInstance;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;
            //Dummy initialisation to prevent errors.
            rangeToHoldHyperlink = xlWorkSheet.get_Range("A1", Type.Missing);
            CellInstance = xlWorkSheet.get_Range("A1", Type.Missing);

            var data = (ObservableCollection<TSK_T001_C>)dg.ItemsSource;

            
            //    //for (int i = 0; i < data.Count; i++)
            //    //{
            //    foreach (System.Windows.Forms.DataGridViewRow row in dg.Rows)
            //    {
            //        int counter = 0;
            //        for (int j = 0; j < dg.Columns.Count; j++)
            //        {
            //            //do not count the header
            //            if (counter >= 0)
            //            {
            //                xlWorkSheet.Cells[counter + 1, j + 1] = row.Cells[j].Value;
            //            }
            //        }
            //        counter++;
            //    }
            ////}

            //for (int i = 0; i < data.Count; i++)
            //{
            //    var row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(i);

            //    for (int j = 0; j < dg.Columns.Count; j++)
            //    {
            //        string xx = data[]
            //        TextBlock selectTextBlockInCell = dg.Columns[j].GetCellContent(data[i]) as TextBlock;
            //        xlWorkSheet.Cells[i + 1, j + 1] = selectTextBlockInCell.Text;
            //    }
            //}

            //for (int i = 0; i < data.Count; i++)
            //{
            //    var row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(i);

            //    for (int j = 0; j < dg.Columns.Count; j++)
            //    {
            //        TextBlock selectTextBlockInCell = dg.Columns[j].GetCellContent(data[i]) as TextBlock;
            //        xlWorkSheet.Cells[i + 1, j + 1] = selectTextBlockInCell.Text;
            //    }
            //}




            //for (int inCol = inFirstCol; inCol < dg.Columns.Count; inCol++)
            //{
            //    for (int inRow = inFirstRow; inRow <= dg.RowCount; inRow++)
            //    {
            //        xlWorkSheet.Cells[inRow + 1, inCol + 1] = dgv[inCol, inRow];
            //    }
            //}

            //for (int i = 0; i < NumberOfCols; i++)
            //{
            //    for (int j = 0; j <= NumberOfRows; j++)
            //    {
            //        xlWorkSheet.Cells[j + 1, i + 1] = DataToWrite[j][i];
            //    }
            //}


            //If you want the first row to be the header, you can highlight them as follows:

            Excel.Range Range1 = xlWorkSheet.get_Range("A1");
            Range1.EntireRow.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            Range1.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
            Range1.EntireRow.Font.Size = 14;
            Range1.EntireRow.AutoFit();

            //Finally to Save the excel in a desired path:

            //xlWorkBook.SaveAs(@FilePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //xlWorkBook.Close();
            
            //=================================
            xlWorkBook.SaveAs("ActivityData.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            //===================================
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        //The reference to the interop is added as follows:
        //Right Click on the Project name -> Click "Add reference" -> Goto "COM" tab -> Search for "Microsoft Excel Object Library" click "OK" to add the reference.


        //You must be using the following namespace :
        //using Excel = Microsoft.Office.Interop.Excel;
        //using System.Runtime.InteropServices;
    }
    

}

//Class use for Import Excel file to Datagrid
namespace Reflection.Presentation.Services
{

    /// <summary>
    /// Class for import Excel file to datagrid
    /// </summary>

    public class ImportExcelToDataGrid
    {
        public DataTable ImportExcelFile(string File)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //Static File From Base Path...........
            //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "TestExcel.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //Dynamic File Using Uploader...........
            Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(File, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
            Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

            string strCellData = "";
            double douCellData;
            int rowCnt = 0;
            int colCnt = 0;

            DataTable dt = new DataTable();
            for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
            {
                string strColumn = "";
                strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                dt.Columns.Add(strColumn, typeof(string));
            }


            for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
            {
                string strData = "";
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    try
                    {
                        strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        strData += strCellData + "|";
                    }
                    catch (Exception ex)
                    {
                        if (colCnt==2)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            double d = double.Parse(douCellData.ToString());
                            DateTime conv = DateTime.FromOADate(d);
                            strData += conv.ToString() + "|";
                        }
                        else
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                       
                    }
                }
                strData = strData.Remove(strData.Length - 1, 1);
                dt.Rows.Add(strData.Split('|'));
            }

            

            excelBook.Close(true, null, null);
            excelApp.Quit();

            //dtGrid.ItemsSource = dt.DefaultView;
            return dt;
        }

        public List<SEL_T001> ImportExcelLead(string File) // This method is specific for Sales Lead Data import form excell  in specific format.
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //Static File From Base Path...........
            //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "TestExcel.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //Dynamic File Using Uploader...........
            Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(File, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
            Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

            List<SEL_T001> ROW_COL_OBJ = new List<SEL_T001>();
            List<TABLE_INFO> TABLE_COL_OBJ = new List<TABLE_INFO>();

            string strCellData = "";
            int intCellData;
            double douCellData;
            DateTime dtCellData;
            int rowCnt = 0;
            int colCnt = 0;

            for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
            {
                string strColumn = "";
                TABLE_INFO OBJ_TBL = new TABLE_INFO();
                strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                OBJ_TBL.col_name = strColumn;

                if (OBJ_TBL.col_name == "SL")
                {
                    OBJ_TBL.col_no = 1;
                    OBJ_TBL.data_type = "INT";
                    OBJ_TBL.data_length = null;
                }
                else if (OBJ_TBL.col_name == "DATE")
                {
                    OBJ_TBL.col_no = 2;
                    OBJ_TBL.data_type = "DATETIME";
                    OBJ_TBL.data_length = null;
                }
                else if (OBJ_TBL.col_name == "EMP_ID")
                {
                    OBJ_TBL.col_no = 3;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 20;
                }
                else if (OBJ_TBL.col_name == "SALES_PERSON")
                {
                    OBJ_TBL.col_no = 4;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 50;
                }
                else if (OBJ_TBL.col_name == "ADDRESS")
                {
                    OBJ_TBL.col_no = 5;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 250;
                }
                else if (OBJ_TBL.col_name == "PARTY_NAME")
                {
                    OBJ_TBL.col_no = 6;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 100;
                }
                else if (OBJ_TBL.col_name == "CONTACT_PERSON")
                {
                    OBJ_TBL.col_no = 7;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 100;
                }
                else if (OBJ_TBL.col_name == "MOBILE")
                {
                    OBJ_TBL.col_no = 8;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 20;
                }
                else if (OBJ_TBL.col_name == "EMAIL")
                {
                    OBJ_TBL.col_no = 9;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 50;
                }
                else if (OBJ_TBL.col_name == "LEAD_TITLE")
                {
                    OBJ_TBL.col_no = 10;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 50;
                }
                else if (OBJ_TBL.col_name == "SO_CODE")
                {
                    OBJ_TBL.col_no = 11;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 5;
                }
                else if (OBJ_TBL.col_name == "SG_CODE")
                {
                    OBJ_TBL.col_no = 12;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 5;
                }
                else if (OBJ_TBL.col_name == "STATUS")
                {
                    OBJ_TBL.col_no = 13;
                    OBJ_TBL.data_type = "VARCHAR";
                    OBJ_TBL.data_length = 20;
                }
                TABLE_COL_OBJ.Add(OBJ_TBL);
            }


            for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
            {
                if (rowCnt >= 11)
                {

                }
                SEL_T001 ROW_OBJ = new SEL_T001();
                ROW_OBJ.doc_cat = "SN";
                ROW_OBJ.doc_type = "SN";
                ROW_OBJ.client = AppSessionState.client;
                ROW_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                ROW_OBJ.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                ROW_OBJ.so_code = AppSessionState.OBJ_LOCATION.location_id;
                ROW_OBJ.sg_code = AppSessionState.OBJ_LOCATION.location_id;
                ROW_OBJ.userid = AppSessionState.UserID;
                ROW_OBJ.add_by = AppSessionState.UserID;
                ROW_OBJ.add_date = DateTime.Now.Date;
                ROW_OBJ.curr_code = AppSessionState.OBJ_COMPANY.curr_code;
                ROW_OBJ.ex_rate = 1;
                ROW_OBJ.ind_trade = "D";
                ROW_OBJ.org_country_cd = AppSessionState.OBJ_COMPANY.ctr_code;
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    try
                    {
                        TABLE_INFO OBJ_TBL_T = new TABLE_INFO();
                        OBJ_TBL_T = TABLE_COL_OBJ[colCnt - 1];

                        if (OBJ_TBL_T.data_type == "VARCHAR")
                        {
                            //strCellData = (string)((excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2 ?? "");
                            //strCellData = String.Format((string)((excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2 ?? "")).ToString();
                            //strCellData = (string)excelRange.Cells[rowCnt, colCnt];
                            strCellData = (excelRange.Cells[rowCnt, colCnt] as Excel.Range).Value2.ToString();

                            if (OBJ_TBL_T.col_name == "EMP_ID")
                            {
                                ROW_OBJ.sales_person_cd = strCellData; //NOTE: replace name with empid code.
                            }
                            else if (OBJ_TBL_T.col_name == "SALES_PERSON")
                            {
                                ROW_OBJ.seller_name = strCellData; //NOTE: replace name with empid code.
                            }
                            else if (OBJ_TBL_T.col_name == "ADDRESS")
                            {
                                ROW_OBJ.address = strCellData; //NOTE: replace name with empid code.
                            }
                            else if (OBJ_TBL_T.col_name == "PARTY_NAME")
                            {
                                ROW_OBJ.party_name = strCellData; //NOTE: replace name with empid code.
                            }
                            else if (OBJ_TBL_T.col_name == "CONTACT_PERSON")
                            {
                                ROW_OBJ.buyer_name = strCellData; //NOTE: replace name with empid code.
                            }
                            else if (OBJ_TBL_T.col_name == "MOBILE")
                            {
                                ROW_OBJ.mobile_no = strCellData; //NOTE: replace name with empid code.
                            }
                            else if (OBJ_TBL_T.col_name == "EMAIL")
                            {
                                ROW_OBJ.mail_id = strCellData;
                            }
                            else if (OBJ_TBL_T.col_name == "LEAD_TITLE")
                            {
                                ROW_OBJ.title = strCellData;
                            }
                            else if (OBJ_TBL_T.col_name == "SO_CODE")
                            {
                                ROW_OBJ.so_code = strCellData;
                            }
                            else if (OBJ_TBL_T.col_name == "SG_CODE")
                            {
                                ROW_OBJ.sg_code = strCellData;
                            }
                            else if (OBJ_TBL_T.col_name == "STATUS")
                            {
                                ROW_OBJ.t_status = strCellData;
                            }
                        }
                        else if (OBJ_TBL_T.data_type == "INT")
                        {
                            intCellData = (int)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            if (OBJ_TBL_T.col_name == "SL")
                            {
                                ROW_OBJ.id = intCellData;
                            }
                        }
                        else if (OBJ_TBL_T.data_type == "DATETIME")
                        {
                            douCellData = (double)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            double d = double.Parse(douCellData.ToString());
                            DateTime dtConvert = DateTime.FromOADate(d);
                            //strData += conv.ToString() + "|";

                            if (OBJ_TBL_T.col_name == "DATE")
                            {
                                ROW_OBJ.sodate = dtConvert;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                }
                ROW_COL_OBJ.Add(ROW_OBJ);
            }

            excelBook.Close(true, null, null);
            excelApp.Quit();

            return ROW_COL_OBJ;
        }

    }

    public class TABLE_INFO
    {
        public int? col_no { get; set; }
        public string col_name { get; set; }
        public string data_type { get; set; }
        public int? data_length { get; set; }

    }

}
