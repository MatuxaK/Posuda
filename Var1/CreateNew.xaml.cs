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
    /// Логика взаимодействия для CreateNew.xaml
    /// </summary>
    public partial class CreateNew : Window
    {
        public CreateNew()
        {
            InitializeComponent();
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-VPAM3HS\\SQLEXPRESS;Initial Catalog=YchPR2;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Открытие подключения
                    connection.Open();

                    // Подготовка SQL-запроса
                    string query = "INSERT INTO [Product] (ProductArticleNumber, ProductName, ProductDescription, ProductCategory, ProductPhoto, ProductQuantityInStock, ProductCost, ProductManufacturer, ProductDiscountAmount) VALUES (@Article, @Name, @Description, @Category ,@Photo, @Quantity, @Cost, @Manufacturer, @Discount)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Параметры для передачи значений
                        command.Parameters.AddWithValue("@Article", article.Text);
                        command.Parameters.AddWithValue("@Name", name.Text);
                        command.Parameters.AddWithValue("@Description", description.Text);
                        command.Parameters.AddWithValue("@Category", category.Text);
                        command.Parameters.AddWithValue("@Photo", photo.Text);
                        command.Parameters.AddWithValue("@Quantity", quantity.Text);
                        command.Parameters.AddWithValue("@Cost", price.Text);
                        command.Parameters.AddWithValue("@Manufacturer", provider.Text);
                        command.Parameters.AddWithValue("@DIscount", discount.Text);

                        // Выполнение SQL-запроса
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // В случае ошибки выводим сообщение
                    MessageBox.Show("Ошибка: " + ex.Message);
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LK_Admin LK = new LK_Admin();
            LK.Show();
            this.Close();
        }
    }
}
