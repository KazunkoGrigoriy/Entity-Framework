using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.Entity;

namespace HomeWork17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLbaseEntities context;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            context.SaveChanges();
            dataGrid.ItemsSource = context.TableClient.Local.ToBindingList<TableClient>();

        }

        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                context.SaveChanges();
                dataGrid.ItemsSource = context.TableClient.Local.ToBindingList<TableClient>();
            }

            //if (e.Key == Key.Right)
            //{
            //    SqlConnectionStringBuilder strConSQL = new SqlConnectionStringBuilder()
            //    {
            //        DataSource = @"(localdb)\MSSQLLocalDB",
            //        InitialCatalog = "SQLbase",
            //        IntegratedSecurity = false,
            //        UserID = "username",
            //        Password = "Ytpyf.24017"
            //    };
            //    SqlConnection sqlConnection = new SqlConnection() { ConnectionString = strConSQL.ConnectionString };

            //    sqlConnection.Open();

            //    string path = Environment.CurrentDirectory + "\\database.mdb;";
            //    OleDbConnection strConAccess = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path);
            //    OleDbConnection accessConnection = new OleDbConnection() { ConnectionString = strConAccess.ConnectionString };
            //    try
            //    {
            //        accessConnection.Open();
            //        Oleda = new OleDbDataAdapter();
            //        Oledt = new DataTable();
            //        DataRowView row = (DataRowView)dataGrid.SelectedItems[0];
            //        var r = row["Email"];
            //        var ole = "SELECT * FROM TablePurchase WHERE Email = '" + r + "'";

            //        Oleda.SelectCommand = new OleDbCommand(ole, accessConnection);

            //        Oleda.Fill(Oledt);
            //        dataGrid1.ItemsSource = Oledt.DefaultView;
            //        accessConnection.Close();
            //    }
            //    catch (Exception a)
            //    {
            //        MessageBox.Show("К базе данных MS Access подключиться не удалось");
            //    }
            //    sqlConnection.Close();
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new SQLbaseEntities();

            context.TableClient.Load();

            dataGrid.ItemsSource = context.TableClient.Local.ToBindingList<TableClient>();
        }

    }
}
