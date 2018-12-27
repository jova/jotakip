using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for PersonelIslemleriPage.xaml
    /// </summary>
    public partial class PersonelIslemleriPage : BasePage<BaseViewModel>
    {
        public PersonelIslemleriPage()
        {
            InitializeComponent();
            if (Session.CurrentUser.UserType != Core.UserType.Admin)
            {
                PersonelEkleBorder.IsEnabled = false;
                PersonelEkleBorder.Opacity = 0.5;
            }
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
                case "UrunAtaBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new UrunAtaPage());
                    return;
                case "AtamaIptalBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new AtamaIptalPage());
                    return;
                case "PersonelEkleBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new PersonelEklePage());
                    return;
                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new MainMenuPage());
                    return;
                default:
                    break;
            }
        }
    }
}
