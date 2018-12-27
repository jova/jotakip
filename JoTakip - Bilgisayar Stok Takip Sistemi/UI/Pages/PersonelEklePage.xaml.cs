using Business;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for OdaGuncellemePage.xaml
    /// </summary>
    public partial class PersonelEklePage : BasePage<BaseViewModel>
    {
        public PersonelEklePage()
        {
            InitializeComponent();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            b.Background = brush;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(110, 110, 110));
            b.Background = brush;
        }

        private async void Border_MouseDownAsync(object sender, MouseButtonEventArgs e)
        {
            Border b = sender as Border;
            switch (b.Name)
            {
                case "PersonelEkleBorder":
                    IUserService userService = IocUtil.Resolve<IUserService>();
                    User user = new User { Name = NameText.Text,
                        LastName = LastNameText.Text,
                        Gender = (GenderComboBox.SelectedItem.ToString() == "Erkek" ? Core.Gender.Male : Core.Gender.Female),
                        Username = UserNameText.Text,
                        Password = PasswordText.Text,
                        DepartmentId = 2,
                        StillEmployed = true,
                        UserType = Core.UserType.BuyerManager};
                    userService.Add(user);
                    this.NavigationService.Navigate(new PersonelEklePage());
                    break;

                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new PersonelIslemleriPage());
                    return;

                default:
                    break;
            }
        }

        private void NameText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9-_\s]");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameText.Text.Trim()) || string.IsNullOrEmpty(LastNameText.Text.Trim()) || string.IsNullOrEmpty(UserNameText.Text.Trim()) || string.IsNullOrEmpty(PasswordText.Text.Trim()))
            {
                PersonelEkleBorder.IsEnabled = false;
                PersonelEkleBorder.Opacity = 0.5;
            }
            else if (!string.IsNullOrEmpty(NameText.Text.Trim()) && !string.IsNullOrEmpty(LastNameText.Text.Trim()) && !string.IsNullOrEmpty(UserNameText.Text.Trim()) && !string.IsNullOrEmpty(PasswordText.Text.Trim()))
            {
                PersonelEkleBorder.IsEnabled = true;
                PersonelEkleBorder.Opacity = 1;
            }
        }
    }
}
