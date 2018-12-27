using Business;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for StokIslemleriPage.xaml
    /// </summary>
    public partial class StokIslemleriPage : BasePage<BaseViewModel>
    {
        public StokIslemleriPage()
        {
            InitializeComponent();
            if (Session.CurrentUser.UserType == Core.UserType.BuyerManager)
            {
                UrunSilBorder.IsEnabled = false;
                UrunSilBorder.Opacity = 0.5;
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
            await this.AnimateOut();
            switch (b.Name)
            {
                case "SatinAlBorder":
                    this.NavigationService.Navigate(new SatinAlPage());
                    return;
                case "UrunSilBorder":
                    this.NavigationService.Navigate(new UrunSilPage());
                    return;
                case "GeriBorder":
                    this.NavigationService.Navigate(new MainMenuPage());
                    return;
                default:
                    break;
            }
        }
    }
}
