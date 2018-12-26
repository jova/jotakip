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

        private void fillComboBox()
        {
            string listele = "SELECT personelID, personelAdi + ' ' + personelSoyadi AS 'AdSoyad' FROM tblPersonel";
            //SqlDataAdapter PersonelData = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet ds = new DataSet();
            //PersonelData.Fill(ds, "t");
            PersonelComboBox.ItemsSource = ds.Tables["t"].DefaultView;
            PersonelComboBox.DisplayMemberPath = "AdSoyad";
            PersonelComboBox.SelectedValuePath = "personelID";
        }

        private void PersonelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDataGrid(Convert.ToInt32(PersonelComboBox.SelectedValue));
        }

        private void fillDataGrid(int id)
        {
            string sorgu = "SELECT odaID, odaAdi, personelAdi + ' ' + personelSoyadi AS 'AdSoyad' FROM tblOda LEFT JOIN tblPersonel ON tblPersonel.personelID = tblOda.personelID WHERE tblOda.personelID = '" + id + "'";
            //SqlCommand cmd = new SqlCommand(sorgu, Sistem.SQLBaglan());
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            //adapter.Fill(table);
            OdaDataGrid.ItemsSource = table.DefaultView;
        }

        private void fillDemirbasDataGrid(int odaID)
        {
            string listele = "SELECT tblDemirbas.demirbasID, CONVERT(nvarchar(20), tblDemirbas.fakulteID) + '.' +  CONVERT(nvarchar(20), tblDemirbas.departmanID) + '.' +  CONVERT(nvarchar(20), tblDemirbas.demirbasTuruID) + '.' +  CONVERT(nvarchar(20), tblDemirbas.demirbasID) AS 'Kod', tblDemirbas.demirbasAdi, tblDemirbasTur.demirbasTurAdi,  tblOdaDemirbas.adet FROM tblOdaDemirbas LEFT JOIN tblDemirbas ON tblOdaDemirbas.demirbasID = tblDemirbas.demirbasID LEFT JOIN tblOda ON tblOdaDemirbas.OdaID = tblOda.odaID LEFT JOIN tblDemirbasTur ON tblDemirbasTur.demirbasTurID = tblDemirbas.demirbasTuruID WHERE tblOdaDemirbas.odaID = '" + odaID + "'";
            //SqlCommand cmd = new SqlCommand(listele, Sistem.SQLBaglan());
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            //adapter.Fill(table);
            DemirbasDataGrid.ItemsSource = table.DefaultView;
        }

        private void OdaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int odaID = 0;
            if (OdaDataGrid.SelectedItems.Count == 1)
            {
                DataRowView drv = (DataRowView)OdaDataGrid.SelectedItem;
                odaID = Convert.ToInt32((drv[0]).ToString());
                fillDemirbasDataGrid(odaID);
            }
        }
    }
}
