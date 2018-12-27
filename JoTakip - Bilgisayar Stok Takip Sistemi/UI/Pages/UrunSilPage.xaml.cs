using Business;
using Business.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace UI
{
    /// <summary>
    /// Interaction logic for DemirbasCikarmaPage.xaml
    /// </summary>
    public partial class UrunSilPage : BasePage<BaseViewModel>
    {
        public UrunSilPage()
        {
            InitializeComponent();
            fillDataGrid();
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
                case "SilBorder":
                    if (UrunDataGrid.SelectedItems.Count == 1)
                    {
                        IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
                        Product product = UrunDataGrid.SelectedItem as Product;
                        warehouseService.DeleteProduct(product);
                        this.NavigationService.Navigate(new UrunSilPage());
                    }
                    return;

                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new StokIslemleriPage());
                    return;

                default:
                    break;
            }
        }

        private void fillDataGrid()
        {
            IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
            UrunDataGrid.ItemsSource = warehouseService.GetProducts();
        }

        private void ProductChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UrunDataGrid.SelectedItems.Count > 0)
            {
                SilBorder.IsEnabled = true;
                SilBorder.Opacity = 1;
            }
            else
            {
                SilBorder.IsEnabled = false;
                SilBorder.Opacity = 0.5;
            }
        }
    }
}
