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
    /// Interaction logic for OdaEklemePage.xaml
    /// </summary>
    public partial class OdaEklemePage : BasePage<BaseViewModel>
    {
        public OdaEklemePage()
        {
            InitializeComponent();
            string listele = "SELECT personelID, personelAdi + ' ' + personelSoyadi AS 'AdSoyad' FROM tblPersonel";
            //SqlDataAdapter PersonelData = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet ds = new DataSet();
            //PersonelData.Fill(ds, "t");
            OdaSorumlusuComboBox.ItemsSource = ds.Tables["t"].DefaultView;
            OdaSorumlusuComboBox.DisplayMemberPath = "AdSoyad";
            OdaSorumlusuComboBox.SelectedValuePath = "personelID";
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
                case "OdaEkleBorder":
                    if (OdaSorumlusuComboBox.SelectedIndex == -1)
                    {
                        /*if (Sistem.OdaEkle(NameText.Text))
                        {
                            await this.AnimateOut();
                            this.NavigationService.Navigate(new OdaIslemleriPage());
                            return;
                        }*/
                    }
                    else
                    {
                        /*if (Sistem.OdaEkle(NameText.Text, Convert.ToInt32(OdaSorumlusuComboBox.SelectedValue)))
                        {
                            await this.AnimateOut();
                            this.NavigationService.Navigate(new OdaIslemleriPage());
                            return;
                        }*/
                    }
                    return;
                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdaIslemleriPage());
                    return;
                default:
                    break;
            }
        }

        private void NameText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9-_\s]");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
    }
}
