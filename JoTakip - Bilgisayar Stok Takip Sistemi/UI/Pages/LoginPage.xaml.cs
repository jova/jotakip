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

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<BaseViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {

            /*if (!String.IsNullOrEmpty(UsernameText.Text) && !String.IsNullOrEmpty(PasswordText.Password))
            {
                if (Sistem.Login(UsernameText.Text, PasswordText.Password))
                {
                    await this.AnimateOut();

                }
                else
                {
                    ErrorText.Visibility = Visibility.Visible;
                }
            }*/
        }
    }
}
