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
using System.Windows.Shapes;

namespace Var1
{
    /// <summary>
    /// Логика взаимодействия для Gost.xaml
    /// </summary>
    public partial class Gost : Window
    {
        public Gost()
        {
            InitializeComponent();
            PopulateProductListView();
        }
        private void PopulateProductListView()
        {
            string connectionString = "Data Source=DESKTOP-VPAM3HS\\SQLEXPRESS;Initial Catalog=YchPR2;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductPhoto, ProductName, ProductDescription FROM Product";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imagePath = reader.GetString(0);
                            string name = reader.GetString(1);
                            string description = reader.GetString(2);

                            productListView.Items.Add(new { ImagePath = imagePath, Name = name, Description = description });
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, object e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow W = new MainWindow();
                W.Show();
                this.Close();
            }
        }

        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
