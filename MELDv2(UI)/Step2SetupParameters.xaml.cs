using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для Step2SetupParameters.xaml
    /// </summary>
    public partial class Step2SetupParameters : Window
    {
        public Step2SetupParameters()
        {
            InitializeComponent();
            nextButton.Click += OpenNext;
            backButton.Click += OpenBack;

        }

        private void FillData() 
        {
            ConfigRepository.Config.MeltConfiguration.ConnectionName = connectionName.Text;
            ConfigRepository.Config.MeltConfiguration.EndpointDB = endpointDB.Text;
            ConfigRepository.Config.MeltConfiguration.EndpointOffset = Int32.Parse(endpointOffset.Text);
            ConfigRepository.Config.MeltConfiguration.StartIndex = Int32.Parse(startIndex.Text);
            ConfigRepository.Config.MeltConfiguration.Types = new int[]
            {
                Int32.Parse(typeF.Text),
                Int32.Parse(typeW.Text),
                Int32.Parse(typeB.Text),
            };
        }
        private void OpenNext(object sender, RoutedEventArgs e)
        {
            if (connectionName.Text != "" && endpointDB.Text != "" && startIndex.Text != "")
            {
                FillData();
                Step3Processing window = new Step3Processing();
                window.Left = Left;
                window.Top = Top;
                window.Show();
                this.Close();
            }
            else 
            {
                connectionName.Background = new SolidColorBrush(Colors.Red);
                endpointDB.Background = new SolidColorBrush(Colors.Red);
                startIndex.Background = new SolidColorBrush(Colors.Red);
            }
            
        }
        private void OpenBack(object sender, RoutedEventArgs e)
        {
            Step1SelectingFiles window = new Step1SelectingFiles();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
        }
    }
}
