using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace LINQtoSQL
{
    /// <summary>
    /// Static class for create xlsx files
    /// </summary>
    public static class CreateXLSX
    {
        /// <summary>
        /// Method for create table in .xlsx file
        /// </summary>
        /// <param name="mas">String array</param>
        /// <param name="path">Path and file name</param>
        /// <param name="c">Numbers columns</param>
        private static void CreateExcelDifferentColumn(string[] mas, string path, int c)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //Вывод в ячейки используя номер строки и столбца Cells[строка, столбец]
            int ind;
            int row = 1;
            for (int i = 1; i <= mas.Length; i += c)
            {
                ind = 1;
                for (int j = i; j < i + c; j++)
                {
                    var excelcells = (Excel.Range)xlWorkSheet.Cells[row, ind];
                    excelcells.Value2 = mas[j - 1];
                    ind++;
                }
                row++;
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        /// <summary>
        /// Create report about examiner grades
        /// </summary>
        /// <param name="path">Path and file name</param>
        public static void CreateExaminerListExcel(string path = "Examiner.xlsx")
        {
            CreateExcelDifferentColumn(CreateList.ExaminerGrades(), path, 2);
        }

        /// <summary>
        /// Create report about specialty grades
        /// </summary>
        /// <param name="path">Path and file name</param>
        public static void CreateSpecialtyListExcel(string path = "Specialty.xlsx")
        {
            CreateExcelDifferentColumn(CreateList.SpecialtyGrades(), path, 2);
        }

        /// <summary>
        /// Create report aboud min/middle/max grades
        /// </summary>
        /// <param name="path">Path and file name</param>
        public static void CreateMiddleGradesListExcel(string path = "MiddleGrades.xlsx")
        {
            CreateExcelDifferentColumn(CreateList.MiddleGrades(), path, 4);
        }

        /// <summary>
        /// Create report about result session
        /// </summary>
        /// <param name="path">Path and file name</param>
        public static void CreateResultSessionListExcel(string path = "ResultSession.xlsx")
        {
            CreateExcelDifferentColumn(CreateList.ResultSession(), path, 5);
        }

        /// <summary>
        /// Create report about out students
        /// </summary>
        /// <param name="path">Path and file name</param>
        public static void CreateOutStudentsListExcel(string path = "OutStudents.xlsx")
        {
            CreateExcelDifferentColumn(CreateList.OutStudents(), path, 2);
        }

        /// <summary>
        /// Create any others reports 
        /// </summary>
        /// <param name="mas">User string array</param>
        /// <param name="path">Path and file name</param>
        /// <param name="column">Numbers columns in table</param>
        public static void CreateMyListExcel(string[] mas, string path, int column)
        {
            CreateExcelDifferentColumn(mas, path, column);
        }

    }
}
