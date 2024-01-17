using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPageUWP : ContentPage
	{
        readonly string login;
        readonly string name;
        readonly string surname;
        public ContactPageUWP(string login)
        {
            this.login = login;
            name = UserName.GetUserName(login);
            surname = UserName.GetUserSurname(login);
            InitializeComponent();
            GuestName.Text = name + " " + surname;
        }

        private async void ExitButtonClick(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            Thread.Sleep(5);
            await App.Current.MainPage.Navigation.PopToRootAsync();
            MainPage mainPage = new MainPage();
            App.Current.MainPage = new NavigationPage(mainPage);
        }

        private async void MainButtonClick(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new AppPageUWP(login));
        }

        private async void ServicesButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicePageUWP(login));
        }
        private async void AboutUsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutSUSPageUWP(login));
        }
        private void ContacsButtonClick(object sender, EventArgs e)
        {

        }
    }
}
