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
    /// Interaction logic for DemirbasEklemePage.xaml
    /// </summary>
    public partial class DemirbasEklemePage : BasePage<BaseViewModel>
    {
        public DemirbasEklemePage()
        {
            InitializeComponent();

            string listele = "SELECT * FROM tblDemirbasTur";
            //SqlDataAdapter KategoriData = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet ds = new DataSet();
            //KategoriData.Fill(ds, "t");
            KategoriComboBox.ItemsSource = ds.Tables["t"].DefaultView;
            KategoriComboBox.DisplayMemberPath = "demirbasTurAdi";
            KategoriComboBox.SelectedValuePath = "demirbasTurID";

            listele = "SELECT * FROM tblFakulte";
            //SqlDataAdapter FakulteData = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet dsf = new DataSet();
            //FakulteData.Fill(dsf, "t");
            FakulteComboBox.ItemsSource = dsf.Tables["t"].DefaultView;
            FakulteComboBox.DisplayMemberPath = "fakulteAdi";
            FakulteComboBox.SelectedValuePath = "fakulteID";
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
                case "EkleBorder":
                    if (string.IsNullOrEmpty(NameText.Text) || string.IsNullOrEmpty(AdetText.Text) || string.IsNullOrEmpty(FiyatText.Text) || string.IsNullOrEmpty(TarihDP.Text) || KategoriComboBox.SelectedItem == null || FakulteComboBox.SelectedItem == null || DepartmanComboBox.SelectedItem == null)
                        break;
                    else
                    {
                        string temp = AdetText.Text;
                        temp = temp.Replace(" ", "");
                        int adet = Convert.ToInt32(temp);
                        temp = FiyatText.Text;
                        temp = temp.Replace(" ", "");
                        int fiyat = Convert.ToInt32(temp);
                        //Sistem.DemirbasEkle(NameText.Text, Convert.ToInt32(KategoriComboBox.SelectedValue), Convert.ToInt32(adet), Convert.ToInt32(fiyat), Convert.ToInt32(FakulteComboBox.SelectedValue), Convert.ToInt32(DepartmanComboBox.SelectedValue), TarihDP.SelectedDate.Value.ToString("dd/MM/yyyy"));
                        await this.AnimateOut();
                        this.NavigationService.Navigate(new StokIslemleriPage());                        
                    }
                    break;
                case "GeriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new StokIslemleriPage());
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

        private void FakulteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int fakulteID = Convert.ToInt32(FakulteComboBox.SelectedValue);
            string listele = "SELECT * FROM tblDepartman WHERE fakulteID = '" + fakulteID + "'";
            //SqlDataAdapter Data = new SqlDataAdapter(listele, Sistem.SQLBaglan());
            DataSet ds = new DataSet();
            //Data.Fill(ds, "t");
            DepartmanComboBox.ItemsSource = ds.Tables["t"].DefaultView;
            DepartmanComboBox.DisplayMemberPath = "departmanAdi";
            DepartmanComboBox.SelectedValuePath = "departmanID";
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
