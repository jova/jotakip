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
    /// Interaction logic for PersonelIslemleriPage.xaml
    /// </summary>
    public partial class PersonelIslemleriPage : BasePage<BaseViewModel>
    {
        public PersonelIslemleriPage()
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
                case "OdaEklemeBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdaEklemePage());
                    return;
                case "OdaCikarmaBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdaCikarmaPage());
                    return;
                case "OdaGuncellemeBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdaGuncellemePage());
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
