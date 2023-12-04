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
using System.Xml.Linq;
using Var1.BD;

namespace Var1
{
    /// <summary>
    /// Логика взаимодействия для registr.xaml
    /// </summary>
    public partial class registr : Window
    {
        public registr()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            M.Show();
            this.Close();
        }

        private void Button_Click(object sender, object e)
        {
            if (Appconnect.ModelODB.User.Count(x => x.UserLogin == login.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть, придумай свой",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    UserLogin = login.Text,
                    UserName = name.Text,
                    UserPassword = passwordBox.Password,
                    UserID = 2
                };
                Appconnect.ModelODB.User.Add(userObj);
                Appconnect.ModelODB.SaveChanges();
                MessageBox.Show("Данные успешно добавлены",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        public void TextBox_GotFocus2(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void е_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
