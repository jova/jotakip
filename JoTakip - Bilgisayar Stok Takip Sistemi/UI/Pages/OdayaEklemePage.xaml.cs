using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for OdayaEklemePage.xaml
    /// </summary>
    public partial class OdayaEklemePage : BasePage<BaseViewModel>
    {
        public OdayaEklemePage()
        {
            InitializeComponent();
            fillComboBox();
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
                case "OdayaEkleBorder":
                    if (!string.IsNullOrEmpty(IDText.Text) && !string.IsNullOrEmpty(AdetText.Text) && !string.IsNullOrEmpty(AdetText.Text) && OdaComboBox.SelectedIndex != -1)
                    {
                        string temp = AdetText.Text;
                        temp = temp.Replace(" ", "");
                        int adet = Convert.ToInt32(temp);
                        /*if (Sistem.StokKontrol(Convert.ToInt32(IDText.Text), Convert.ToInt32(adet)))
                        {
                            if (Sistem.OdayaDemirbasAta(Convert.ToInt32(OdaComboBox.SelectedValue), Convert.ToInt32(IDText.Text), Convert.ToInt32(adet)))
                            {
                                this.NavigationService.Navigate(new OdayaEklemePage());
                            }
                        }*/
                    }
                    return;
                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new DemirbasAtamalariPage());
                    return;
                default:
                    break;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void fillDataGrid()
        {
            string listele = "SELECT demirbasID, CONVERT(nvarchar(20), tblDemirbas.fakulteID) + '.' +  CONVERT(nvarchar(20), tblDemirbas.departmanID) + '.' +  CONVERT(nvarchar(20), tblDemirbas.demirbasTuruID) + '.' +  CONVERT(nvarchar(20), tblDemirbas.demirbasID) AS 'Kod', demirbasAdi, fiyat, adet, satinAlinanTarih, demirbasTurAdi FROM tblDemirbas INNER JOIN tblDemirbasTur ON tblDemirbas.demirbasTuruID = tblDemirbasTur.demirbasTurID";
            //SqlCommand cmd = new SqlCommand(listele, Sistem.SQLBaglan());
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            //adapter.Fill(table);
            DemirbasDataGrid.ItemsSource = table.DefaultView;
        }

        private void fillComboBox()
        {
            string listele = "SELECT odaID, odaAdi FROM tblOda";
            //SqlDataAdapter PersonelData = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet ds = new DataSet();
            //PersonelData.Fill(ds, "t");
            OdaComboBox.ItemsSource = ds.Tables["t"].DefaultView;
            OdaComboBox.DisplayMemberPath = "odaAdi";
            OdaComboBox.SelectedValuePath = "odaID";
        }

        private void DemirbasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView drv = (DataRowView)DemirbasDataGrid.SelectedItem;
            IDText.Text = (drv[0]).ToString();
            NameText.Text = (drv[1]).ToString();
        }
    }
}
