using System;
using System.Collections.Generic;
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

namespace GetFileNameInFolder
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
            string pathFolder = txtPathFolder.Text;
            try
            {
                if (!string.IsNullOrEmpty(pathFolder))
                {
                    string[] filePaths = Directory.GetFiles(pathFolder, "*.aspx");
                    string textFileName = "";
                    foreach (var item in filePaths)
                    {
                        textFileName += item;
                        textFileName += "\n";
                    }
                    txtAllFileName.Text = textFileName;
                }
                else
                {
                    MessageBox.Show("Thông báo", "Nhập đường dẫn", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi", ex.Message.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
