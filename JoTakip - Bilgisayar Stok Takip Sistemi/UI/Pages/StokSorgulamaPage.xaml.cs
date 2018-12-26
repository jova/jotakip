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
            if (b.Name == "GeriBorder")
            {
                await this.AnimateOut();
                this.NavigationService.Navigate(new SorgulamalarPage());
            }
        }

        private void fillDataGrid()
        {
            //string listele = "SELECT demirbasID, CONVERT(nvarchar(20), fakulteID) + '.' +  CONVERT(nvarchar(20), departmanID) + '.' +  CONVERT(nvarchar(20), demirbasTuruID) + '.' +  CONVERT(nvarchar(20), demirbasID) AS 'Kod', demirbasAdi, fiyat, adet, satinAlinanTarih, demirbasTurAdi FROM tblDemirbas INNER JOIN tblDemirbasTur ON tblDemirbas.demirbasTuruID = tblDemirbasTur.demirbasTurID";
            //SqlCommand cmd = new SqlCommand(listele, Sistem.SQLBaglan());
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            //adapter.Fill(table);
            DemirbasDataGrid.ItemsSource = table.DefaultView;
        }

        private void FiltreText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string listele = string.Empty;
            string kelimeara = FiltreText.Text;
            string kriter = KriterComboBox.Text;
            if (kriter == "ID")
                listele = "SELECT demirbasID, CONVERT(nvarchar(20), fakulteID) + '.' +  CONVERT(nvarchar(20), departmanID) + '.' +  CONVERT(nvarchar(20), demirbasTuruID) + '.' +  CONVERT(nvarchar(20), demirbasID) AS 'Kod', demirbasAdi, fiyat, adet, satinAlinanTarih, demirbasTurAdi FROM tblDemirbas INNER JOIN tblDemirbasTur ON tblDemirbas.demirbasTuruID = tblDemirbasTur.demirbasTurID WHERE tblDemirbas.demirbasID LIKE '%" + kelimeara + "%'";
            else if (kriter == "Ad")
                listele = "SELECT demirbasID, CONVERT(nvarchar(20), fakulteID) + '.' +  CONVERT(nvarchar(20), departmanID) + '.' +  CONVERT(nvarchar(20), demirbasTuruID) + '.' +  CONVERT(nvarchar(20), demirbasID) AS 'Kod', demirbasAdi, fiyat, adet, satinAlinanTarih, demirbasTurAdi FROM tblDemirbas INNER JOIN tblDemirbasTur ON tblDemirbas.demirbasTuruID = tblDemirbasTur.demirbasTurID WHERE tblDemirbas.demirbasAdi LIKE '%" + kelimeara + "%'";
            else if (kriter == "Kategori")
                listele = "SELECT demirbasID, CONVERT(nvarchar(20), fakulteID) + '.' +  CONVERT(nvarchar(20), departmanID) + '.' +  CONVERT(nvarchar(20), demirbasTuruID) + '.' +  CONVERT(nvarchar(20), demirbasID) AS 'Kod', demirbasAdi, fiyat, adet, satinAlinanTarih, demirbasTurAdi FROM tblDemirbas INNER JOIN tblDemirbasTur ON tblDemirbas.demirbasTuruID = tblDemirbasTur.demirbasTurID WHERE tblDemirbasTur.demirbasTurAdi LIKE '%" + kelimeara + "%'";
            else
                return;
            //SqlDataAdapter adap = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataTable tablo = new DataTable();
            //adap.Fill(tablo);
            DemirbasDataGrid.ItemsSource = tablo.DefaultView;
        }
    }
}
