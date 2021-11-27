using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GertUrlFromFirstSearchResult
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".xlsx"; // Required file extension 
            fileDialog.Filter = "Excel Files|*.xlsx;"; // Optional file extensions
            fileDialog.ShowDialog();

            txtFilePath.Text = fileDialog.FileName;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string txtPath = txtFilePath.Text.Trim();
                string pathFolder = new FileInfo(txtPath).Directory.FullName;
                DataTable dataTable = ExcelHelper.ReadExcelReturnDataTable(txtPath);

                foreach (DataRow item in dataTable.Rows)
                {
                    var results = GoogleSearch.Search(item[0].ToString());
                    item[1] = results?.FirstOrDefault()?.Title;
                    item[2] = results?.FirstOrDefault()?.Link;
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dataTable, "Details");
                    wb.Worksheet(1).Column("A").Width = 30;
                    wb.Worksheet(1).Column("B").Width = 50;
                    wb.Worksheet(1).Column("C").Width = 50;

                    string pathFileResult = $@"{pathFolder}\FileDataResult.xlsx";

                    wb.SaveAs(pathFileResult);
                }

                MessageBox.Show("Get data Success", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void SaveFileStream(String path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }
    }
}
