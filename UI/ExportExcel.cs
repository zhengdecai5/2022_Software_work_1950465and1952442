using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;


namespace UI
{
    class ExportExcel
    {
        public void ExcelExport(ListView lv, string fileName)
        {
            int rowNum = lv.Items.Count;
            int column = lv.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(fileName))
            {
                return;
            }
            if (rowNum > 0)
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();//创建EXCEL
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表的第一行
                foreach (ColumnHeader dc in lv.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入到Excel中
                for (rowIndex = 2; rowIndex < lv.Items.Count + 2; rowIndex++)
                {
                    xlApp.Cells[rowIndex, 1] = lv.Items[rowIndex - 2].Text;
                    for (columnIndex = 2; columnIndex <= lv.Columns.Count; columnIndex++)
                    {
                        xlApp.Cells[rowIndex, columnIndex] = lv.Items[rowIndex - 2].SubItems[columnIndex - 1].Text;
                    }
                }
                 
                xlBook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;
                MessageBox.Show("导出成功！");
            }
        }
    }
}

