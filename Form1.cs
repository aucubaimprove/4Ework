using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            date.Text = dt.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            app.Visible = false;
            Excel.Workbooks excelBooks = app.Workbooks;
            Excel.Workbook excelBook = excelBooks.Open("C:\\Users\\hesti\\source\\repos\\WindowsFormsApp1\\testb"); //指定された場所のExcelファイルを開く
            Excel.Worksheet sheet = app.Worksheets["sheet1"];

            try{

                string sday=null;

                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (count == 2) sday += date.Text[i];
                    if (date.Text[i] == '/') count++;
                }
                
                var tempera = temperature.Text;
                int iday = int.Parse(sday);
                sheet.Cells[number.Text, iday] = tempera; //指定されたセルに体温データを保存する

                excelBook.Save(); //Excelファイルの上書き保存
                number.Text = null;
                temperature.Text = null;
                MessageBox.Show("保存しました");
            }
            catch
            {
                throw;
            }
            finally{
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }
    }
}
