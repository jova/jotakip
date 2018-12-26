using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using WinForms = System.Windows.Forms; 
using System.IO;
using System.Diagnostics; 

namespace UI
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : BasePage<BaseViewModel>
    {
        public MainMenuPage()
        {
            InitializeComponent();
            //NameText.Text += Sistem.MevcutKullanici.Ad + " " + Sistem.MevcutKullanici.Soyad;
            //YetkiText.Text += Sistem.MevcutKullanici.Yetki;
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
                case "StokIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new StokIslemleriPage());
                    return;
                case "OdaIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new OdaIslemleriPage());
                    return;
                case "DemirbasAtamalariBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new DemirbasAtamalariPage());
                    return;
                case "SorgulamalarBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new SorgulamalarPage());
                    return;
                case "RaporlarBorder":
                    WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
                    folderDialog.ShowNewFolderButton = false;
                    folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                    WinForms.DialogResult result = folderDialog.ShowDialog();
                    if (result == WinForms.DialogResult.OK)
                    {
                        String sPath = folderDialog.SelectedPath;
                        //Sistem.RaporOlustur(sPath);
                    }
                    return;
                default:
                    break;
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await this.AnimateOut();
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
