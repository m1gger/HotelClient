using System;
using Xamarin.Forms;

namespace Hotel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            int answer = Client.ClientRegister(nameField.Text, surnameField.Text, loginField.Text, passField.Text);           
            switch(answer)
            {
                case 1:
                    errorText.Text = "Регистрация прошла успешно";
                    errorText.TextColor = Color.Green;
                    break;
                case 2:
                    errorText.Text = "Заполните все поля";
                    errorText.TextColor = Color.Red;
                    break;
                case 4:
                    errorText.Text = "Данный логин уже занят";
                    errorText.TextColor = Color.Red;
                    break;
            }
        }

        private async void LoginButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
