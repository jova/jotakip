using Business;
using Business.Abstract;
using DoddleReport;
using DoddleReport.iTextSharp;
using Entities.Concrete;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for PersonelSorgulamaPage.xaml
    /// </summary>
    public partial class RaporlarPage : BasePage<BaseViewModel>
    {
        public RaporlarPage()
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
                this.NavigationService.Navigate(new MainMenuPage());
            }
            else if (b.Name == "PersonelDokumAlBorder")
            {
                IPersonalService personalService = IocUtil.Resolve<IPersonalService>();
                IDepartmentService departmentService = IocUtil.Resolve<IDepartmentService>();
                Department department = departmentService.Get(Convert.ToInt32(DepartmanComboBox.SelectedValue));
                var report = new Report(personalService.GetList().Where(x => x.DepartmentId == department.Id).ToReportSource(), new PdfReportWriter());
                report.TextFields.Title = "Personel Dökümü";
                report.TextFields.SubTitle = department.Name + " Personelleri";
                using (Stream stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\personel-dokum.pdf"))
                {
                    report.WriteReport(stream);
                }
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\personel-dokum.pdf");
            }
            else if (b.Name == "UrunDokumAlBorder")
            {
                IPersonalService personalService = IocUtil.Resolve<IPersonalService>();
                IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();

                Personal personal = PersonellerDataGrid.SelectedItem as Personal;

                var report = new Report(warehouseService.GetProducts().Where(x => x.AssignedById == personal.Id).ToReportSource(), new PdfReportWriter());

                report.TextFields.Title = "Ürün Dökümü";

                report.TextFields.SubTitle = personal.Name + " " + personal.LastName + " Ürünleri";

                using (Stream stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\urun-dokum.pdf"))
                {
                    report.WriteReport(stream);
                }
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\urun-dokum.pdf");
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

        private void UrunDokumAl(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void PersonelDokumAl(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
