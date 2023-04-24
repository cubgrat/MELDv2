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
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
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
            seqFileButton.Click += SelectSeqFile;
            messFileButton.Click += SelectTxtFile;
            tagFileButton.Click += SelectCsvFile;
            folderButton.Click += SelectFolder;
            
        }

        private void OpenNext(object sender, RoutedEventArgs e)
        {
            if (ConfigRepository.Config.MeltConfiguration.S5SeqPath != null ||
                ConfigRepository.Config.MeltConfiguration.MessageFilePath != null ||
                ConfigRepository.Config.MeltConfiguration.TagFilePath != null ||
                ConfigRepository.Config.MeltConfiguration.FolderPath != null
                )
            {
                Step2SetupParameters window = new Step2SetupParameters();
                window.Left = Left;
                window.Top = Top;
                window.Show();
                this.Close();
            }
            else 
            {
                seqFileIsSelected.Text = "Выберите файл!";
                seqFileIsSelected.Foreground = new SolidColorBrush(Colors.Red);

                messFileIsSelected.Text = "Выберите файл!";
                messFileIsSelected.Foreground = new SolidColorBrush(Colors.Red);

                tagFileIsSelected.Text = "Выберите файл!";
                tagFileIsSelected.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void OpenBack(object sender, RoutedEventArgs e)
        {
            Step0CreatingFiles window = new Step0CreatingFiles();
            window.Left = Left;
            window.Top = Top;
            window.Show();
            this.Close();
            tagFileIsSelected.Visibility = Visibility.Hidden;
        }
        private void SelectSeqFile(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog();
            file.Multiselect = false;
            file.InitialDirectory = "C:\\";
            if (file.ShowDialog() == true) 
            {
                seqFileIsSelected.Text = file.SafeFileName;
                ConfigRepository.Config.MeltConfiguration.S5SeqPath = file.FileName;
            }
                
        }
        private void SelectTxtFile(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog();
            file.Multiselect = false;
            file.InitialDirectory = "C:\\";
            if (file.ShowDialog() == true) 
            {
                messFileIsSelected.Text = file.SafeFileName;
                ConfigRepository.Config.MeltConfiguration.MessageFilePath = file.FileName;
            }
                
        }
        private void SelectCsvFile(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog();
            file.Multiselect = false;
            file.InitialDirectory = "C:\\";
            if (file.ShowDialog() == true)
            {
                tagFileIsSelected.Text = file.SafeFileName;
                ConfigRepository.Config.MeltConfiguration.TagFilePath = file.FileName;
            }
        }
        private void SelectFolder(object sender, RoutedEventArgs e)
        {
            var folderBrowsing = new FolderBrowserDialog();
            folderBrowsing.InitialDirectory = "C:\\";
            if (folderBrowsing.ShowDialog()  == System.Windows.Forms.DialogResult.OK) 
            {
                folderPath.Text = folderBrowsing.SelectedPath;
                ConfigRepository.Config.MeltConfiguration.FolderPath = folderBrowsing.SelectedPath;
            }

        }
    }
}
