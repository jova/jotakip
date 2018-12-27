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
    /// Interaction logic for OdayaEklemePage.xaml
    /// </summary>
    public partial class DepartmanlarPage : BasePage<BaseViewModel>
    {
        public DepartmanlarPage()
        {
            InitializeComponent();
            fillComboBox();
        }

        private Department department;

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
                this.NavigationService.Navigate(new DepartmanIslemleriPage());
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
            IPersonalService personalService = IocUtil.Resolve<IPersonalService>();
            department = DepartmanComboBox.SelectedItem as Department;
            fillPersonalDataGrid(Convert.ToInt32(DepartmanComboBox.SelectedValue));
            if (department != null && department.ManagerId != 0) YoneticiText.Text = personalService.Get(department.ManagerId).Name + " " + personalService.Get(department.ManagerId).LastName;
        }

        private void fillPersonalDataGrid(int id)
        {
            IPersonalService personalService = IocUtil.Resolve<IPersonalService>();
            PersonellerDataGrid.ItemsSource = personalService.GetList().Where(x => x.DepartmentId == id);
        }
    }
}
