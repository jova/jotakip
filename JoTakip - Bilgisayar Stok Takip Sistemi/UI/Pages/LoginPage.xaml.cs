using Business;
using Business.Abstract;
using Core;
using Entities.Concrete;
using System;
using System.Linq;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<BaseViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
            /*User user = new User { Username = "ersoy", Password = "1234", Name = "Ersoy", LastName = "TORAMAN", Gender = Gender.Male ,UserType = UserType.Admin, DepartmentId = 1, StillEmployed = true };
            IUserService userService = IocUtil.Resolve<IUserService>();
            userService.Add(user);*/
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            ILoginService loginService = IocUtil.Resolve<ILoginService>();

            if (!String.IsNullOrEmpty(UsernameText.Text) && !String.IsNullOrEmpty(PasswordText.Password))
            {
                if (loginService.Login(UsernameText.Text, PasswordText.Password))
                {
                    IUserService userService = IocUtil.Resolve<IUserService>();

                    Session.CurrentUser = userService.GetList().Single(x => x.Username == UsernameText.Text);
                    await this.AnimateOut();
                    this.NavigationService.Navigate(new MainMenuPage());
                }
                else
                {
                    ErrorText.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
