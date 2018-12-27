using Business;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for SatinAlPage.xaml
    /// </summary>
    public partial class SatinAlPage : BasePage<BaseViewModel>
    {
        public SatinAlPage()
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
                case "SatinAlBorder":
                    IProductService productService = IocUtil.Resolve<IProductService>();
                    Product product = new Product { Name = NameText.Text.Trim(), Date = DateTime.Now.ToString("dd/MM/yyyy")};
                    productService.BuyProduct(product, Convert.ToInt32(AdetText.Text));
                    this.NavigationService.Navigate(new SatinAlPage());
                    break;

                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new StokIslemleriPage());
                    return;      
                    
                default:
                    break;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            if (string.IsNullOrEmpty(NameText.Text.Trim()) || string.IsNullOrEmpty(AdetText.Text.Trim()))
            {
                SatinAlBorder.IsEnabled = false;
                SatinAlBorder.Opacity = 0.5;
            }
            else if (!string.IsNullOrEmpty(NameText.Text.Trim()) && !string.IsNullOrEmpty(AdetText.Text.Trim()))
            {
                SatinAlBorder.IsEnabled = true;
                SatinAlBorder.Opacity = 1;
            }
        }
    }
}
