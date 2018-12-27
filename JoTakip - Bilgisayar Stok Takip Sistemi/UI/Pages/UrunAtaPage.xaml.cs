using Business;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for UrunAtaPage.xaml
    /// </summary>
    public partial class UrunAtaPage : BasePage<BaseViewModel>
    {
        public UrunAtaPage()
        {
            InitializeComponent();
            fillComboBox();
            fillUrunlerDataGrid();
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
                this.NavigationService.Navigate(new PersonelIslemleriPage());
            }
            else
            {
                IProductService productService = IocUtil.Resolve<IProductService>();
                Personal personal = PersonellerDataGrid.SelectedItem as Personal;
                Product product = UrunlerDataGrid.SelectedItem as Product;
                productService.AssignProduct(personal, product);
                fillUrunlerDataGrid();
            }
        }

        private void fillComboBox()
        {
            IDepartmentService departmentService = IocUtil.Resolve<IDepartmentService>();
            DepartmanComboBox.ItemsSource = departmentService.GetList();
            DepartmanComboBox.DisplayMemberPath = "Name";
            DepartmanComboBox.SelectedValuePath = "Id";
        }

        private void DepartmanComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPersonalDataGrid(Convert.ToInt32(DepartmanComboBox.SelectedValue));
        }

        private void fillPersonalDataGrid(int id)
        {
            IPersonalService personalService = IocUtil.Resolve<IPersonalService>();
            PersonellerDataGrid.ItemsSource = personalService.GetList().Where(x => x.DepartmentId == id);
        }

        private void fillUrunlerDataGrid()
        {
            IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
            UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.AssignedById == 0);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UrunlerDataGrid.SelectedItems.Count > 0 && PersonellerDataGrid.SelectedItems.Count > 0)
            {
                UrunAtaBorder.IsEnabled = true;
                UrunAtaBorder.Opacity = 1;
            }
            else
            {
                UrunAtaBorder.IsEnabled = false;
                UrunAtaBorder.Opacity = 0.5;
            }
        }
    }
}
