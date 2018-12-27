using Business;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for DemirbasAtamalariPage.xaml
    /// </summary>
    public partial class DepartmanIslemleriPage : BasePage<BaseViewModel>
    {
        public DepartmanIslemleriPage()
        {
            InitializeComponent();
            if (Session.CurrentUser.UserType != Core.UserType.Admin)
            {
                YoneticiAtaBorder.IsEnabled = false;
                YoneticiAtaBorder.Opacity = 0.5;
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
                case "YoneticiAtaBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new YoneticiAtaPage());
                    return;
                case "DepartmanlarBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new DepartmanlarPage());
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
