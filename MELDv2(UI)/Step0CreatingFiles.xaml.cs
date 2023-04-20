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
    /// Логика взаимодействия для Step0CreatingFiles.xaml
    /// </summary>
    public partial class Step0CreatingFiles : Window
    {
        public Step0CreatingFiles()
        {
            InitializeComponent();
            nextButton.Click += OpenNext;
            backButton.Click += OpenBack;
        }

        private void OpenNext(object sender, RoutedEventArgs e)
        {
            Step1SelectingFiles window = new Step1SelectingFiles();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
        }
        private void OpenBack(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
        }
    }
}
