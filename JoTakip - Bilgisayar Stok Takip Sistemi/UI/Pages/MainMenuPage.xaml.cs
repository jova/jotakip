using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Business;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : BasePage<BaseViewModel>
    {
        public MainMenuPage()
        {
            InitializeComponent();
            NameText.Text += Session.CurrentUser.Name + " " + Session.CurrentUser.LastName;
            if (Session.CurrentUser.UserType == Core.UserType.Admin) YetkiText.Text += "Yönetici";
            else if (Session.CurrentUser.UserType == Core.UserType.BuyerManager) YetkiText.Text += "Satış Elemanı";
            else if (Session.CurrentUser.UserType == Core.UserType.DepartmentManager) YetkiText.Text += "Departman Yöneticisi";
            if (Session.CurrentUser.Gender == Core.Gender.Male) ImgFemaleUser.Visibility = Visibility.Hidden;
            else ImgMaleUser.Visibility = Visibility.Hidden;
            if (Session.CurrentUser.UserType == Core.UserType.BuyerManager)
            {
                DepartmanIslemleriBorder.IsEnabled = false;
                DepartmanIslemleriBorder.Opacity = 0.5;
                RaporlarBorder.IsEnabled = false;
                RaporlarBorder.Opacity = 0.5;
            }
            else if (Session.CurrentUser.UserType== Core.UserType.DepartmentManager)
            {
                StokIslemleriBorder.IsEnabled = false;
                StokIslemleriBorder.Opacity = 0.5;
                PersonelIslemleriBorder.IsEnabled = false;
                PersonelIslemleriBorder.Opacity = 0.5;
                RaporlarBorder.IsEnabled = false;
                RaporlarBorder.Opacity = 0.5;
            }
        }

        // Mouse Enter
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153,153,153));
            b.Background = brush;
        }

        // Mouse Leave
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
                case "StokIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new StokIslemleriPage());
                    return;
                case "PersonelIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new PersonelIslemleriPage());
                    return;
                case "DepartmanIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new DepartmanIslemleriPage());
                    return;
                case "SorgulamalarBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new SorgulamalarPage());
                    return;
                case "RaporlarBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new RaporlarPage());
                    return;
                default:
                    break;
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await this.AnimateOut();
            Session.CurrentUser = null;
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
