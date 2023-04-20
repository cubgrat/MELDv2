using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace MELDv2_UI_
{
    /// <summary>
    /// Логика взаимодействия для Step1SelectingFiles.xaml
    /// </summary>
    public partial class Step1SelectingFiles : Window
    {
        public Step1SelectingFiles()
        {
            InitializeComponent();
            nextButton.Click += OpenNext;
            backButton.Click += OpenBack;

        }

        private void OpenNext(object sender, RoutedEventArgs e)
        {
            Step2SetupParameters window = new Step2SetupParameters();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
        }
        private void OpenBack(object sender, RoutedEventArgs e)
        {
            Step0CreatingFiles window = new Step0CreatingFiles();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
        }
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            var test = new OpenFileDialog();
            test.Multiselect = false;
            test.InitialDirectory = "C:\\";
            if (test.ShowDialog() == true)
                MessageBox.Show(test.FileName);
        }
    }
}
