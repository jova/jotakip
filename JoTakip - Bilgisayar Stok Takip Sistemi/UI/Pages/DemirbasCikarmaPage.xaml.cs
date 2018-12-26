using System;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace UI
{
    /// <summary>
    /// Interaction logic for DemirbasCikarmaPage.xaml
    /// </summary>
    public partial class DemirbasCikarmaPage : BasePage<BaseViewModel>
    {
        public DemirbasCikarmaPage()
        {
            InitializeComponent();
            fillDataGrid();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153, 152, 136));
            b.Background = brush;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            b.Background = brush;
        }

        private async void Border_MouseDownAsync(object sender, MouseButtonEventArgs e)
        {
            Border b = sender as Border;
            switch (b.Name)
            {
                case "CikarBorder":
                    if (DemirbasDataGrid.SelectedItems.Count == 1)
                    {
                        DataRowView drv = (DataRowView)DemirbasDataGrid.SelectedItem;
                        String result = (drv[0]).ToString();
                        //Sistem.DemirbasCikar(Convert.ToInt32(result.ToString()));
                        this.NavigationService.Navigate(new DemirbasCikarmaPage());
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
            string listele = "SELECT demirbasID, CONVERT(nvarchar(20), fakulteID) + '.' +  CONVERT(nvarchar(20), departmanID) + '.' +  CONVERT(nvarchar(20), demirbasTuruID) + '.' +  CONVERT(nvarchar(20), demirbasID) AS 'Kod', demirbasAdi, fiyat, adet, satinAlinanTarih, demirbasTurAdi FROM tblDemirbas INNER JOIN tblDemirbasTur ON tblDemirbas.demirbasTuruID = tblDemirbasTur.demirbasTurID";
            //SqlCommand cmd = new SqlCommand(listele, Sistem.SQLBaglan());
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            //adapter.Fill(table);
            DemirbasDataGrid.ItemsSource = table.DefaultView;
        }
    }
}
