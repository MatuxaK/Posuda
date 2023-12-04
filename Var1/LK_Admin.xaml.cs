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
using Var1.BD;

namespace Var1
{
    /// <summary>
    /// Логика взаимодействия для LK_Admin.xaml
    /// </summary>
    public partial class LK_Admin : Window
    {
        public LK_Admin()
        {
            InitializeComponent();
            Appconnect.ModelODB = new YchPR2Entities1();
            PopulateProductListView();
        }
        private void PopulateProductListView()
        {
            string connectionString = "Data Source=DESKTOP-VPAM3HS\\SQLEXPRESS;Initial Catalog=YchPR2;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductArticleNumber, ProductPhoto, ProductName, ProductDescription FROM Product";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();
                        while (reader.Read())
                        {
                            string article = reader.GetString(0);
                            string imagePath = reader.GetString(1);
                            string name = reader.GetString(2);
                            string description = reader.GetString(3);
                            products.Add(new Product { ProductArticleNumber = article, ImagePath = imagePath, Name = name, Description = description });
                        }

                        // Привязка данных к ListView
                        productListView.ItemsSource = products;
                    }
                }
            }
        }
        public class Product
        {
            public string ProductArticleNumber { get; set; }
            public string ImagePath { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        private void DeleteProductFromDatabase(string article)
        {
            string connectionString = "Data Source=DESKTOP-VPAM3HS\\SQLEXPRESS;Initial Catalog=YchPR2;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Product WHERE ProductArticleNumber = @Article";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Article", article);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (productListView.SelectedItem != null)
            {
                var selectedProduct = productListView.SelectedItem as Product;
                DeleteProductFromDatabase(selectedProduct.ProductArticleNumber);
                PopulateProductListView();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow W = new MainWindow();
                W.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Editxaml E = new Editxaml();
            E.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CreateNew CN = new CreateNew();
            CN.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
