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
    /// Interaction logic for DemirbasAtamalariPage.xaml
    /// </summary>
    public partial class DemirbasAtamalariPage : BasePage<BaseViewModel>
    {
        public DemirbasAtamalariPage()
        {
            InitializeComponent();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153, 152, 136));
            b.Background = brush;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            b.Background = brush;
        }

        private async void Border_MouseDownAsync(object sender, MouseButtonEventArgs e)
        {
            Border b = sender as Border;
            switch (b.Name)
            {
                case "OdayaEklemeBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdayaEklemePage());
                    return;
                case "OdadanCikarmaBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdadanCikarmaPage());
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
