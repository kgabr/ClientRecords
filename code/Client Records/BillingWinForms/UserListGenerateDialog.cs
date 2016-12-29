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
            tbNrExamTotal_D1.Text = BusinessLogic.DB.GetRecordsCount().ToString();
            tbNrExamAge1M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 0, 4).ToString();
            tbNrExamAge1F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 0, 4).ToString();
            tbNrExamAge2M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 5, 9).ToString();
            tbNrExamAge2F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 5, 9).ToString();
            tbNrExamAge3M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 10, 14).ToString();
            tbNrExamAge3F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 10, 14).ToString();
            tbNrExamAge4M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 15, 39).ToString();
            tbNrExamAge4F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 15, 39).ToString();
            tbNrExamAge5M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 40, 100).ToString();
            tbNrExamAge5F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 40, 100).ToString();

            tbNrExamTotal.Text = tbNrExamTotal_D1.Text;
            tbNrExamAge1M_Total.Text = tbNrExamAge1M_D1.Text;
            tbNrExamAge1F_Total.Text = tbNrExamAge1F_D1.Text;
            tbNrExamAge2M_Total.Text = tbNrExamAge2M_D1.Text;
            tbNrExamAge2F_Total.Text = tbNrExamAge2F_D1.Text;
            tbNrExamAge3M_Total.Text = tbNrExamAge3M_D1.Text;
            tbNrExamAge3F_Total.Text = tbNrExamAge3F_D1.Text;
            tbNrExamAge4M_Total.Text = tbNrExamAge4M_D1.Text;
            tbNrExamAge4F_Total.Text = tbNrExamAge4F_D1.Text;
            tbNrExamAge5M_Total.Text = tbNrExamAge5M_D1.Text;
            tbNrExamAge5F_Total.Text = tbNrExamAge5F_D1.Text;

        }
        private void filltableAccordingToDatePicker()
        {
            DateTime dateSpecified = this.dtReportDate.Value;
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            tbNrExamTotal_D1.Text = BusinessLogic.DB.GetRecordsCount(dateSpecified).ToString();
            tbNrExamAge1M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 0, 4, dateSpecified).ToString();
            tbNrExamAge1F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 0, 4, dateSpecified).ToString();
            tbNrExamAge2M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 5, 9, dateSpecified).ToString();
            tbNrExamAge2F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 5, 9, dateSpecified).ToString();
            tbNrExamAge3M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 10, 14, dateSpecified).ToString();
            tbNrExamAge3F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 10, 14, dateSpecified).ToString();
            tbNrExamAge4M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 15, 39, dateSpecified).ToString();
            tbNrExamAge4F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 15, 39, dateSpecified).ToString();
            tbNrExamAge5M_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("M", 40, 100, dateSpecified).ToString();
            tbNrExamAge5F_D1.Text = BusinessLogic.DB.GetRecordsCountBySexAndAge("F", 40, 100, dateSpecified).ToString();
        }
        


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            string templatePath = Directory.GetCurrentDirectory() + "\\ClientRecordsTEMPLATE.xlsx"; 
            if(!File.Exists(templatePath))
            {
                MessageBox.Show("Fisierul necesar pentru export " + templatePath + " nu exista.");
                return;
            };
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ClientRecords.xls";
            object misValue = System.Reflection.Missing.Value;
            string currentDir = Directory.GetCurrentDirectory();
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;

            try
            {
                excelWorkbook = excelApp.Workbooks.Open(templatePath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                //Get all the sheets in the workbook
                excelWorksheets = excelWorkbook.Worksheets;

                //Get sheet1
                excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorksheets.get_Item("Sheet1");

                excelWorksheet.Cells[5, "D"] = tbNrExamTotal_D1.Text;
                excelWorksheet.Cells[5, "E"] = tbNrExamAge1M_D1.Text;
                excelWorksheet.Cells[5, "F"] = tbNrExamAge1F_D1.Text;
                excelWorksheet.Cells[5, "G"] = tbNrExamAge2M_D1.Text;
                excelWorksheet.Cells[5, "H"] = tbNrExamAge2F_D1.Text;
                excelWorksheet.Cells[5, "I"] = tbNrExamAge3M_D1.Text;
                excelWorksheet.Cells[5, "J"] = tbNrExamAge3F_D1.Text;
                excelWorksheet.Cells[5, "K"] = tbNrExamAge4M_D1.Text;
                excelWorksheet.Cells[5, "L"] = tbNrExamAge4F_D1.Text;
                excelWorksheet.Cells[5, "M"] = tbNrExamAge5M_D1.Text;
                excelWorksheet.Cells[5, "N"] = tbNrExamAge5F_D1.Text;

                excelWorksheet.Cells[8, "D"] = tbNrExamTotal.Text;
                excelWorksheet.Cells[8, "E"] = tbNrExamAge1M_Total.Text;
                excelWorksheet.Cells[8, "F"] = tbNrExamAge1F_Total.Text;
                excelWorksheet.Cells[8, "G"] = tbNrExamAge2M_Total.Text;
                excelWorksheet.Cells[8, "H"] = tbNrExamAge2F_Total.Text;
                excelWorksheet.Cells[8, "I"] = tbNrExamAge3M_Total.Text;
                excelWorksheet.Cells[8, "J"] = tbNrExamAge3F_Total.Text;
                excelWorksheet.Cells[8, "K"] = tbNrExamAge4M_Total.Text;
                excelWorksheet.Cells[8, "L"] = tbNrExamAge4F_Total.Text;
                excelWorksheet.Cells[8, "M"] = tbNrExamAge5M_Total.Text;
                excelWorksheet.Cells[8, "N"] = tbNrExamAge5F_Total.Text;

                
                

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Microsoft Excel File|*.xlsx";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {  
                    if(!saveFileDialog.FileName.Equals(""))
                    {
                        excelWorkbook.SaveAs(saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    }
                }
                
                excelWorkbook.Close(true, misValue, misValue);
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
                MessageBox.Show("com exception " + ex.Message);
            }
            catch (Exception ex) { 
                MessageBox.Show("not com exception " + ex.Message);
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
