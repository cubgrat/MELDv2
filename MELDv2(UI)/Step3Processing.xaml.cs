using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            submitButton.Click += StartConvert;
            openFolder.Click += OpenExplorer;

        }

        private void OpenExplorer(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", ConfigRepository.Config.MeltConfiguration.FolderPath);
        }

        private void StartConvert(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            progressBar.Value = 5;
           var status = new MELDv2.MeldProcessor(ConfigRepository.Config.MeltConfiguration).Run();
            if (status == -1)
            {
                statusText.Background = new SolidColorBrush(Colors.Red);
                statusText.Text = "Завершено с ошибкой!";
                progressBar.Value = 0;
            }
            else 
            {
                statusText.Text = String.Format($"Выгружено {status} тегов!");
                openFolder.Visibility = Visibility.Visible;
                for (int i = (int)progressBar.Value; i <= 100; i++)
                {
                    progressBar.Value++;
                    Thread.SpinWait(100);
                }
            }
            
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
