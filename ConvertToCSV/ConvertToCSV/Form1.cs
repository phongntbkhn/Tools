using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertToCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = txtPathFile.Text;

            string text = File.ReadAllText(filePath);

            var mathRegex = Regex.Matches(text, @"""[^""]*""");
            foreach (var item in mathRegex)
            {
                string replate = item.ToString().Replace(@"""", "");
                replate = replate.Replace(",", ".");
                text = text.Replace(item.ToString(), replate);
            }

            File.WriteAllText(filePath, text);

            MessageBox.Show("Xong!!!");
        }
    }
}
