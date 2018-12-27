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
    /// Interaction logic for OdaCikarmaPage.xaml
    /// </summary>
    public partial class AtamaIptalPage : BasePage<BaseViewModel>
    {
        public AtamaIptalPage()
        {
            InitializeComponent();
            fillComboBox();
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
                Product product = UrunlerDataGrid.SelectedItem as Product;
                productService.UnAssignProduct(product);
                if (cbAtik.IsChecked == true)
                {
                    IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
                    IWasteProductService wasteProductService = IocUtil.Resolve<IWasteProductService>();
                    wasteProductService.Add(product);
                    warehouseService.DeleteProduct(product);
                }
                Personal personal = PersonellerDataGrid.SelectedItem as Personal;
                fillUrunlerDataGrid(personal.Id);
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

        private void fillUrunlerDataGrid(int id)
        {
            IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
            UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.AssignedById == id);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid == PersonellerDataGrid)
            {
                Personal personal = dataGrid.SelectedItem as Personal;
                if (personal != null) fillUrunlerDataGrid(personal.Id);
            }
            if (UrunlerDataGrid.SelectedItems.Count > 0 && PersonellerDataGrid.SelectedItems.Count > 0)
            {
                AtamaIptalBorder.IsEnabled = true;
                AtamaIptalBorder.Opacity = 1;
            }
            else
            {
                AtamaIptalBorder.IsEnabled = false;
                AtamaIptalBorder.Opacity = 0.5;
            }
        }
    }
}
