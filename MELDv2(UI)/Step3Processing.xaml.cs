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
    /// Логика взаимодействия для Step3Processing.xaml
    /// </summary>
    public partial class Step3Processing : Window
    {
        public Step3Processing()
        {
            InitializeComponent();
            doneButton.Click += Exit;
            backButton.Click += OpenBack;

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void OpenBack(object sender, RoutedEventArgs e)
        {
            Step2SetupParameters window = new Step2SetupParameters();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            
            this.Close();
        }
    }
}
