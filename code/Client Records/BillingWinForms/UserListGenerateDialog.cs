using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel; 

using Billing;

namespace BillingWinForms
{
    public partial class UserListGenerateDialog : Form
    {
        private static Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
        private static Microsoft.Office.Interop.Excel.Sheets excelWorksheets;
        private static Microsoft.Office.Interop.Excel.Worksheet excelWorksheet;
        private static Microsoft.Office.Interop.Excel.Application excelApp;

        public UserListGenerateDialog()
        {
                InitializeComponent();
        
                fillTable();        
        }
        private void fillTable()
        {
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbNrExamTot1.Text = BusinessLogic.DB.GetUsersCount().ToString();
            tbNrExamAgeYoung1.Text = BusinessLogic.DB.GetUsersAgeYoung().ToString();
            tbNrExamAgeMid1.Text = BusinessLogic.DB.GetUsersAgeMid().ToString();
            tbNrExamAgeOld1.Text = BusinessLogic.DB.GetUsersAgeOld().ToString();
            tbSexM1.Text = BusinessLogic.DB.GetSexM().ToString();
            tbSexF1.Text = BusinessLogic.DB.GetSexF().ToString();
            tbDozaMedie1.Text = BusinessLogic.DB.GetDosage().ToString();          

        }
        private void filltableAccordingToDatePicker()
        {
            DateTime dateSpecified = this.dtReportDate.Value;
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbNrExamTot1.Text = BusinessLogic.DB.GetUsersCount(dateSpecified).ToString();
            tbNrExamAgeYoung1.Text = BusinessLogic.DB.GetUsersAgeYoung(dateSpecified).ToString();
            tbNrExamAgeMid1.Text = BusinessLogic.DB.GetUsersAgeMid(dateSpecified).ToString();
            tbNrExamAgeOld1.Text = BusinessLogic.DB.GetUsersAgeOld(dateSpecified).ToString();
            tbSexM1.Text = BusinessLogic.DB.GetSexM(dateSpecified).ToString();
            tbSexF1.Text = BusinessLogic.DB.GetSexF(dateSpecified).ToString();
            tbDozaMedie1.Text = BusinessLogic.DB.GetDosage(dateSpecified).ToString();       
        }
        


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //********************************************************************************************EZ OK**********************

            string path = "G:\\ClientRecordsTEMPLATE.xls";
            if(!File.Exists(path))
            {
                MessageBox.Show("Fisierul necesar pentru export " + path + " nu exista.");
                return;
            };
            string savepath = "G:\\ClientRecords.xls";
            object misValue = System.Reflection.Missing.Value;

            excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;

            try
            {
                excelWorkbook = excelApp.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                //Get all the sheets in the workbook
                excelWorksheets = excelWorkbook.Worksheets;

                //Get sheet1
                excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorksheets.get_Item("Sheet1");

                excelWorksheet.Cells[5, "D"] = "bu11mbi";

                excelWorkbook.SaveAs(savepath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                excelWorkbook.Close(misValue, misValue, misValue);

                excelWorksheet = null;

                excelWorkbook = null;

                excelApp.Quit();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("com exception" + ex.Message);
            }
            catch (Exception ex) {
                MessageBox.Show("not com exception" + ex.Message);
            }

            //object misValue = System.Reflection.Missing.Value;

            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //int i = 0;
            //int j = 0;
            //xlWorkSheet.Cells[1, 1] = "EXAMINARI RX DENTARE";

            ////MessageBox.Show(this.tableLayoutPanel1.ColumnCount.ToString());
            ////MessageBox.Show(this.tableLayoutPanel1.RowCount.ToString());

            //for (i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            //{
            //    for (j = 0; j < tableLayoutPanel1.RowCount; j++)
            //    {
            //        Control c = tableLayoutPanel1.GetControlFromPosition(i, j);
                    
            //        if (c != null)
            //        {
            //            xlWorkSheet.Cells[j+1, i+2] = (c.Text);
            //        }
            //    }
            //}

            //string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Records.xls";
            
            //try
            //{
            //    xlWorkBook.SaveAs(savePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //    xlWorkBook.Close(true, misValue, misValue);
            //    xlApp.Quit();

            //    releaseObject(xlWorkSheet);
            //    releaseObject(xlWorkBook);
            //    releaseObject(xlApp);

            //    MessageBox.Show("Fisierul Excel a fost creat pe Desktop");
            //}
            //catch (Exception ex)
            //{
            //    //todo: handle this
            //}
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
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void rbGenerateSettingDate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (this.rbGenerateSettingAll.Checked)
            {
                fillTable();
            }
            if (this.rbGenerateSettingDate.Checked)
            {
                filltableAccordingToDatePicker();
            }
        }
    }
}
