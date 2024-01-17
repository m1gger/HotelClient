using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hotel
{
    public partial class AppPage : FlyoutPage
    {
        readonly string login;
        readonly string name;
        readonly string surname;
        public AppPage(string login)
        {
            this.login = login;
            name = UserName.GetUserName(login);
            surname = UserName.GetUserSurname(login);
            InitializeComponent();
            Detail = new NavigationPage(new MainInFlyout(login));
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public AppPage(string login, DateTime checkIn, DateTime checkOut, string type)
        {
            this.login = login;
            name = UserName.GetUserName(login);
            surname = UserName.GetUserSurname(login);
            InitializeComponent();
            Detail = new NavigationPage(new MainInFlyout(login, checkIn, checkOut, type));
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            Username.Text = name + " " + surname;
        }

        private async void ExitButtonClick(object sender, EventArgs e)
        {   
            Thread.Sleep(5);
            await App.Current.MainPage.Navigation.PopToRootAsync();
            MainPage mainPage = new MainPage();
            App.Current.MainPage = new NavigationPage(mainPage);
        }

        private void MainButtonClick(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainInFlyout(login));
            IsPresented = false;
        }


        private void ServicesButtonClick(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Services());
            IsPresented = false;
        }
        private void AboutUsButtonClick(object sender,EventArgs e) 
        {
            Detail = new NavigationPage(new AboutSUS());
            IsPresented = false;
        }
        private void ContacsButtonClick (object sender, EventArgs e) 
        {
            Detail=new NavigationPage(new Contacs());
            IsPresented = false;
        }
    }
}

