using Business;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for SorgulamalarPage.xaml
    /// </summary>
    public partial class SorgulamalarPage : BasePage<BaseViewModel>
    {
        public SorgulamalarPage()
        {
            InitializeComponent();
            if (Session.CurrentUser.UserType == Core.UserType.BuyerManager)
            {
                AtikSorgulamaBorder.IsEnabled = false;
                AtikSorgulamaBorder.Opacity = 0.5;
                PersonelSorgulamaBorder.IsEnabled = false;
                PersonelSorgulamaBorder.Opacity = 0.5;
            }
            else if (Session.CurrentUser.UserType == Core.UserType.DepartmentManager)
            {
                AtikSorgulamaBorder.IsEnabled = false;
                AtikSorgulamaBorder.Opacity = 0.5;
                StokSorgulamaBorder.IsEnabled = false;
                StokSorgulamaBorder.Opacity = 0.5;
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
                case "PersonelSorgulamaBorder":
                    this.NavigationService.Navigate(new PersonelSorgulamaPage());
                    return;
                case "StokSorgulamaBorder":
                    this.NavigationService.Navigate(new StokSorgulamaPage());
                    return;
                case "AtikSorgulamaBorder":
                    this.NavigationService.Navigate(new AtikSorgulamaPage());
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
