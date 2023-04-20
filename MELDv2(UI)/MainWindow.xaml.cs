using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace MELDv2_UI_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nextButton.Click += OpenNext;
            
        }

        private void OpenNext(object sender, RoutedEventArgs e)
        {
            Step0CreatingFiles window = new Step0CreatingFiles();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
        }
    }
}
