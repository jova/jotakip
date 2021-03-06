﻿using Business;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for StokSorgulamaPage.xaml
    /// </summary>
    public partial class StokSorgulamaPage : BasePage<BaseViewModel>
    {
        public StokSorgulamaPage()
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
            IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();
            UrunlerDataGrid.ItemsSource = warehouseService.GetProducts();
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
            if (kriter == "ID") UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.Id.ToString() == kelimeara);
            else if (kriter == "Ad") UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.Name.ToLower().Contains(kelimeara));
            else if (kriter == "Tarih") UrunlerDataGrid.ItemsSource = warehouseService.GetProducts().Where(x => x.Date.Contains(kelimeara));
        }
    }
}
