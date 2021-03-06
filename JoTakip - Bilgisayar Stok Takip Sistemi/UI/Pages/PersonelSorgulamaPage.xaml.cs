﻿using Business;
using Business.Abstract;
using Entities.Concrete;
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
    /// Interaction logic for PersonelSorgulamaPage.xaml
    /// </summary>
    public partial class PersonelSorgulamaPage : BasePage<BaseViewModel>
    {
        public PersonelSorgulamaPage()
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
                this.NavigationService.Navigate(new SorgulamalarPage());
            }
        }

        private void fillComboBox()
        {
            IDepartmentService departmentService = IocUtil.Resolve<IDepartmentService>();
            if (Session.CurrentUser.UserType == Core.UserType.DepartmentManager)
            {
                DepartmanComboBox.ItemsSource = departmentService.GetList().Where(x => x.ManagerId == Session.CurrentUser.Id);
                DepartmanComboBox.DisplayMemberPath = "Name";
                DepartmanComboBox.SelectedValuePath = "Id";
            }
            else
            {
                DepartmanComboBox.ItemsSource = departmentService.GetList();
                DepartmanComboBox.DisplayMemberPath = "Name";
                DepartmanComboBox.SelectedValuePath = "Id";
            }
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
        }
    }
}
