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
    /// Логика взаимодействия для Klient.xaml
    /// </summary>
    public partial class Klient : Window
    {
        public Klient()
        {
            InitializeComponent();
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
                            products.Add(new Product { Article = article, ImagePath = imagePath, Name = name, Description = description });
                        }
                        StringBuilder sb = new StringBuilder();
                        foreach (Product product in products)
                        {
                            sb.Append($"Article: {product.Article}, Image Path: {product.ImagePath}, Name: {product.Name}, Description: {product.Description}\n");
                        }
                        productListView.Items.Clear();
                        // Привязка данных к ListView
                        productListView.ItemsSource = products;
                    }
                }
            }
        }
        public class Product
        {
            public string Article { get; set; }
            public string ImagePath { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }



        private void Edit(object sender, EventArgs e)
        {
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-VPAM3HS\\SQLEXPRESS;Initial Catalog=YchPR2;Integrated Security=True";
                    string updateQuery = "UPDATE Product SET ProductPhoto = @NewPhoto, ProductName = @NewName, ProductDescription = @NewDescription WHERE ProductArticleNumber = @Article";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@NewPhoto", photo.Text); // замените photo.Text на фактический идентификатор TextBox для фото
                            command.Parameters.AddWithValue("@NewName", name.Text); // замените name.Text на фактический идентификатор TextBox для имени
                            command.Parameters.AddWithValue("@NewDescription", description.Text); // замените description.Text на фактический идентификатор TextBox для описания
                            command.Parameters.AddWithValue("@Article", article.Text);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            // rowsAffected содержит количество строк, которые были обновлены в таблице
                        }
                    }
                }
                catch (Exception ex)
                {
                    // В случае ошибки выводим сообщение
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
