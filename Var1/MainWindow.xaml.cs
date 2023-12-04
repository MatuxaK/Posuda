using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Var1.BD;

namespace Var1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int failedAttempts = 0;
        public MainWindow()
        {
            InitializeComponent();
            Appconnect.ModelODB = new YchPR2Entities1();
        }

        private void regestration_Click(object sender, RoutedEventArgs e)
        {
            registr R = new registr();
            R.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = Appconnect.ModelODB.User.FirstOrDefault(x => x.UserLogin == login.Text && x.UserPassword == Parol.Password);
                string correctCaptcha = "";
                string enteredCaptcha = CaptchaTextBox.Text;
                Random random = new Random();
                for (int i = 0; i < 4; i++)
                {
                    correctCaptcha += Convert.ToChar(random.Next(65, 90));
                }
                CaptchaVieW.Text = correctCaptcha;
                
                
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка при авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    
                    failedAttempts++;
                    if (failedAttempts == 1)
                    {
                        CaptchaVieW.Visibility = Visibility.Visible;
                        CaptchaLabel.Visibility = Visibility.Visible;
                        CaptchaTextBox.Visibility = Visibility.Visible;
                    }
                    else
                    if (enteredCaptcha != correctCaptcha)
                    {
                        MessageBox.Show("Вы неправильно ввели Captcha и были заблокированы на 10 секунд");
                        Thread.Sleep(10000); // Блокировка на 10 секунд
                        return;
                    }
                }                
                else if (login.Text == userObj.UserLogin && Parol.Password == userObj.UserPassword)
                {
                    switch (userObj.UserID)
                    {
                        case 1:
                            LK_Admin A = new LK_Admin();
                            A.Show();
                            this.Close();
                            break;
                        case 2:
                            LK_Admin AA = new LK_Admin();
                            AA.Show();
                            this.Close();
                            break;
                        case 3:
                            LK_Admin AAA = new LK_Admin();
                            AAA.Show();
                            this.Close();
                            break;
                        case 4:
                            Manager M = new Manager();
                            M.Show();
                            this.Close();
                            break;
                        case 5:
                            Manager MM = new Manager();
                            MM.Show();
                            this.Close();
                            break;
                        case 6:
                            Manager MMM = new Manager();
                            MMM.Show();
                            this.Close();
                            break;
                        case 7:
                            Klient K = new Klient();
                            K.Show();
                            this.Close();
                            break;
                        case 8:
                            Klient KK = new Klient();
                            KK.Show();
                            this.Close();
                            break;
                        case 9:
                            Klient KKK = new Klient();
                            KKK.Show();
                            this.Close();
                            break;
                        case 10:
                            Klient KKKK = new Klient();
                            KKKK.Show();
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }          
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Gost G = new Gost();
            G.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            registr R = new registr();
            R.Show();
            this.Close();
        }
    }
}
