using System;
using Xamarin.Forms;
using System.Threading;

namespace Hotel
{
	public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
			InitializeComponent();
		}

        private async void ButtonClick(object sender, EventArgs e)
        {
            int answer = Client.ClientLogin(loginField.Text, passField.Text);
            switch (answer)
            {
                case 1:
                    if (Device.RuntimePlatform == Device.UWP) 
                    {  
                        AppPageUWP appPageUWP = new AppPageUWP(loginField.Text);
                        App.Current.MainPage = new NavigationPage(appPageUWP);
                        await App.Current.MainPage.Navigation.PopToRootAsync();
                        break;
                    }
                    else
                    {
                        AppPage appPage = new AppPage(loginField.Text);
                        App.Current.MainPage = new NavigationPage(appPage);
                        await App.Current.MainPage.Navigation.PopToRootAsync();
                        break;           
                    }                    
                case 2:
                    errorText.Text = "Заполните все поля";
                    errorText.TextColor = Color.Red;
                    break;
                case 3:
                    errorText.Text = "Неверный логин или пароль";
                    errorText.TextColor = Color.Red;
                    break;
            }            
        }
    }
}