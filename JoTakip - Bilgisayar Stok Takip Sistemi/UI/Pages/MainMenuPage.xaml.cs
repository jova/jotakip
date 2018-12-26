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
using Business.Abstract;
using Business;

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
            //NameText.Text += Session.CurrentUser.Name + " " + Session.CurrentUser.LastName;
            //YetkiText.Text += Session.CurrentUser.UserType == Core.UserType.Admin ? "Yönetici" : "Satış Elemanı";
            //if (Session.CurrentUser.Gender == Core.Gender.Male) ImgFemaleUser.Visibility = Visibility.Hidden;
            //else ImgMaleUser.Visibility = Visibility.Hidden;
        }

        // Mouse Enter
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(153,153,153));
            b.Background = brush;
        }

        // Mouse Leave
        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(110, 110, 110));
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
                case "PersonelIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new PersonelIslemleriPage());
                    return;
                case "DepartmanIslemleriBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new DepartmanIslemleriPage());
                    return;
                case "SorgulamalarBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new SorgulamalarPage());
                    return;
                case "RaporlarBorder":
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new RaporlarPage());
                    return;
                //WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
                //folderDialog.ShowNewFolderButton = false;
                //folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                //WinForms.DialogResult result = folderDialog.ShowDialog();
                //if (result == WinForms.DialogResult.OK)
                //{
                //    String sPath = folderDialog.SelectedPath;
                //    Sistem.RaporOlustur(sPath);
                //}
                //return;
                default:
                    break;
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await this.AnimateOut();
            Session.CurrentUser = null;
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
