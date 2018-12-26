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
    /// Interaction logic for OdaGuncellemePage.xaml
    /// </summary>
    public partial class OdaGuncellemePage : BasePage<BaseViewModel>
    {
        public OdaGuncellemePage()
        {
            InitializeComponent();
            fillDataGrid();
            fillComboBox();
        }

        private void OdaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView drv = (DataRowView)OdaDataGrid.SelectedItem;
            String result = (drv[1]).ToString();
            NameText.Text = result;
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
                case "GuncelleBorder":
                    if (OdaSorumlusuComboBox.SelectedIndex != -1 && OdaDataGrid.SelectedItems.Count == 1)
                    {
                        DataRowView drv = (DataRowView)OdaDataGrid.SelectedItem;
                        int odaID = Convert.ToInt32(drv[0]);
                        //Sistem.OdaSorumluAta(odaID, Convert.ToInt32(OdaSorumlusuComboBox.SelectedValue));
                        this.NavigationService.Navigate(new OdaGuncellemePage());
                    }
                    return;
                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new PersonelIslemleriPage());
                    return;
                default:
                    break;
            }
        }

        private void fillDataGrid()
        {
            string listele = "SELECT odaID, odaAdi, personelAdi + ' ' + personelSoyadi AS 'AdSoyad' FROM tblOda LEFT JOIN tblPersonel ON tblOda.personelID = tblPersonel.personelID";
            //SqlCommand cmd = new SqlCommand(listele, Sistem.SQLBaglan());
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            //adapter.Fill(table);
            OdaDataGrid.ItemsSource = table.DefaultView;
        }


        private void fillComboBox()
        {
            string listele = "SELECT personelID, personelAdi + ' ' + personelSoyadi AS 'AdSoyad' FROM tblPersonel";
            //SqlDataAdapter PersonelData = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet ds = new DataSet();
            //PersonelData.Fill(ds, "t");
            OdaSorumlusuComboBox.ItemsSource = ds.Tables["t"].DefaultView;
            OdaSorumlusuComboBox.DisplayMemberPath = "AdSoyad";
            OdaSorumlusuComboBox.SelectedValuePath = "personelID";
        }
    }
}
