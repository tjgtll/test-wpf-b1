using b1_task2.BLL.Models;
using b1_task2.BLL.Services;
using b1_task2.WPF.Forms;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace b1_task2.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IService<ChartOfAccountDTO> _chartOfAccountService;
        private IService<BalanceSheetDTO> _balanceSheetService;
        private IExcelFileManagerService _excelFileManagerService;
        private OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*",
            Title = "Выберите файл для импорта"
        };
        private const string messageBoxSuccess = "Файл импортирован";
        private const string messageBoxError = "Ошибка";
        private const string path = "bin/files";
        public ObservableCollection<FileInfo> Files { get; set; }
        public MainWindow() : base()
        {
            InitializeComponent();
            this.Close();
        }

        public MainWindow(
            IService<ChartOfAccountDTO> chartOfAccountService,
            IService<BalanceSheetDTO> balanceSheetService,
            IExcelFileManagerService excelFileManagerService)
        {
            InitializeComponent();
            _balanceSheetService = balanceSheetService;
            _chartOfAccountService = chartOfAccountService;
            _excelFileManagerService = excelFileManagerService;
            //ChartOfAccounts = _chartOfAccountService.GetAll();
            Files = new ObservableCollection<FileInfo>();
            UpdateFiles();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string fileName)
            {
                if (Guid.TryParse(fileName[0..(fileName.Length - 4)], out Guid guid))
                {
                    var balanceSheetDTO = _balanceSheetService.GetById(guid);
                    var balance = new Balance(balanceSheetDTO);
                    balance.ShowDialog();
                }
                else
                {
                    MessageBox.Show(messageBoxError);
                }
            }
        }

        private void ImportFile(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                string destinationFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string filePath;
                using (var fileStream = openFileDialog.OpenFile())
                {
                    var result = _excelFileManagerService.ImportFile(fileStream, destinationFolderPath, fileName);
                    if (result != null)
                    {
                        Directory.CreateDirectory(destinationFolderPath);
                        string destinationFilePath = Path.Combine(destinationFolderPath, $"{result}.xls");
                        File.Copy(openFileDialog.FileName, destinationFilePath);
                        MessageBox.Show(messageBoxSuccess);
                        UpdateFiles();
                    }
                    else
                    {
                        MessageBox.Show(messageBoxError);
                    }
                }
            }
        }

        private void ShowReferenceData(object sender, RoutedEventArgs e)
        {

        }

        private void ShowFiles(object sender, RoutedEventArgs e)
        {
            UpdateFiles();
        }

        private void UpdateFiles()
        {
            Files.Clear();
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            foreach (var file in directoryInfo.GetFiles())
            {
                Files.Add(file);
            }
            DataContext = this;
        }
    }
}
