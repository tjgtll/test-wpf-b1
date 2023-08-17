using b1_task2.BLL.Models;
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

namespace b1_task2.WPF.Forms
{
    /// <summary>
    /// Interaction logic for Balance.xaml
    /// </summary>
    public partial class Balance : Window
    {
        public BalanceSheetDTO BalanceSheet { get; set; }
        public List<BankAccountMovementDTO> BankAccountMovements { get; set; }

        List<List<BankAccountMovementDTO>> listOfTables = new List<List<BankAccountMovementDTO>>();
        public Balance(BalanceSheetDTO balanceSheetDTO)
        {
            InitializeComponent();
            BalanceSheet = balanceSheetDTO;
            dataGrid.ItemsSource = BalanceSheet.AccountMovement;
            balanceSheetNameTextBlock.Text = BalanceSheet.BankName;
            balanceSheetDateTextBlock.Text =
                $"за период с {BalanceSheet.StartDateTime.ToString("dd.MM.yyyy")} " +
                $"по {BalanceSheet.EndDateTime.ToString("dd.MM.yyyy")}";
        }
    }
}
