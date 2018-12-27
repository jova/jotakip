using Business;
using Business.Abstract;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for AtikSorgulamaPage.xaml
    /// </summary>
    public partial class AtikSorgulamaPage : BasePage<BaseViewModel>
    {
        public AtikSorgulamaPage()
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
            if (b.Name == "GeriBorder")
            {
                await this.AnimateOut();
                this.NavigationService.Navigate(new SorgulamalarPage());
            }
        }

        private void fillDataGrid()
        {
            IWasteProductService wasteProductService = IocUtil.Resolve<IWasteProductService>();
            UrunlerDataGrid.ItemsSource = wasteProductService.GetList();
        }

        private void FiltreText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string kelimeara = FiltreText.Text.ToLower();
            string kriter = KriterComboBox.Text;
            IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
            if (string.IsNullOrEmpty(kelimeara))
            {
                UrunlerDataGrid.ItemsSource = warehouseService.GetProducts();
                return;
            }
            else if (kriter == "Ad") UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.Name.ToLower().Contains(kelimeara));
            else if (kriter == "Tarih") UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.Date.Contains(kelimeara));
        }
    }
}
