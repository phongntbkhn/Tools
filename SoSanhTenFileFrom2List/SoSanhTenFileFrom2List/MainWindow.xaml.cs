using System;
using System.Collections.Generic;
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

namespace SoSanhTenFileFrom2List
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

        private void btnSoSanh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = "";
                string souce = txtList1.Text.Replace("\r","");
                string target = txtList2.Text.Replace("\r", "");

                string[] pathSource = souce.Split("\n");
                string[] pathTarget = target.Split("\n");
                foreach (var item in pathTarget)
                {
                    string temp = item.Split("\\").Last();
                    if (!souce.Contains(temp))
                    {
                        result += item;
                        result += "\n";
                    }
                }
                txtListResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", ex.Message.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
