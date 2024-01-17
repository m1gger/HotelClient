using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppPageUWP : ContentPage
    {
        readonly string login;
        readonly string name;
        readonly string surname;
        private string roomstype;
        readonly DateTime checkIn;
        readonly DateTime checkOut;
        public ObservableCollection<string> ImageUrls { get; set; }

        public AppPageUWP(string login)
        {
            this.login = login;
            name = UserName.GetUserName(login);
            surname = UserName.GetUserSurname(login);
            string[] parts = UserName.GetUsersRoom(login).Split(' ');
            try
            {
                checkIn = DateTime.Parse(parts[1]);
                checkOut = DateTime.Parse(parts[2]);
            }
            catch { }
            roomstype = parts[0];
            InitializeComponent();            
        }

        public AppPageUWP(string login, DateTime checkIn, DateTime checkOut, string type)
        {
            this.login = login;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            name = UserName.GetUserName(login);
            surname = UserName.GetUserSurname(login);
            roomstype = type;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            GuestName.Text = name + " " + surname;
            DateTime todate = DateTime.Now;
            if(todate > checkOut)
            {
                roomstype = "-1";
            }
            switch (roomstype)
            {
                case "Single":
                    DateButtonStack.Children.Remove(dateButton);
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "Вместимость 1 человек";
                    bed.Text = "Большая кровать (1.8 x 2)М²";
                    square.Text = "Площадь 30 квадратных метров";
                    ImageUrls = new ObservableCollection<string>
                    {
                            "https://i.imgur.com/F9hbJEF.jpeg",
                            "https://i.imgur.com/2D3J0gh.jpeg",
                            "https://i.imgur.com/3B4WMgz.jpeg"
                    };
                    BindingContext = this;
                    break;
                case "Lux":
                    DateButtonStack.Children.Remove(dateButton);
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "Вместимость 4 человека";
                    bed.Text = "Очень большая кровать (3 x 2)М²";
                    square.Text = "Площадь 60 квадратных метров";
                    ImageUrls = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/Tmm1lCV.jpg",
                        "https://i.imgur.com/Q5lxTsj.jpg",
                        "https://i.imgur.com/cJuzvKH.jpg"
                    };
                    BindingContext = this;
                    break;
                case "Twin":
                    DateButtonStack.Children.Remove(dateButton);
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "• Вместимость 2 человека";
                    bed.Text = "• Очень большая кровать (3 x 2)М²";
                    square.Text = " • Площадь 60 квадратных метров";
                    ImageUrls = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/jDeTVqJ.jpg",
                        "https://i.imgur.com/l5ZnaJ8.jpg",
                        "https://i.imgur.com/yqqnU0S.jpg"
                    };
                    BindingContext = this;

                    break;
                case "Super Lux":
                    DateButtonStack.Children.Remove(dateButton);
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "• Вместимость 2 человека";
                    bed.Text = "• Очень большая кровать (3 x 2)М²";
                    square.Text = " • Площадь 60 квадратных метров";
                    ImageUrls = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/E7vO3T5.jpeg",
                        "https://i.imgur.com/h7qkz6u.jpeg",
                        "https://i.imgur.com/JB53JRk.jpeg"
                    };
                    BindingContext = this;
                    break;
                case "King-Size":
                    DateButtonStack.Children.Remove(dateButton);
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "• Вместимость 2 человека";
                    bed.Text = "• Очень большая кровать (3 x 2)М²";
                    square.Text = " • Площадь 60 квадратных метров";
                    ImageUrls = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/c1F99VX.jpg",
                        "https://i.imgur.com/93PsGWC.jpg",
                        "https://i.imgur.com/yFFVNTv.jpg"
                    };
                    BindingContext = this;
                    break;
                default:
                    isGuest.Text = "Сейчас вы не проживаете в отеле";
                    isGuest.TextColor = Color.Red;
                    Liniya.HeightRequest = 62;
                    ImageUrls = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/F9hbJEF.jpeg",
                        "https://i.imgur.com/2D3J0gh.jpeg",
                        "https://i.imgur.com/3B4WMgz.jpeg",
                        "https://i.imgur.com/Tmm1lCV.jpg",
                        "https://i.imgur.com/Q5lxTsj.jpg",
                        "https://i.imgur.com/cJuzvKH.jpg",
                        "https://i.imgur.com/jDeTVqJ.jpg",
                        "https://i.imgur.com/l5ZnaJ8.jpg",
                        "https://i.imgur.com/yqqnU0S.jpg",
                        "https://i.imgur.com/E7vO3T5.jpeg",
                        "https://i.imgur.com/h7qkz6u.jpeg",
                        "https://i.imgur.com/JB53JRk.jpeg",
                        "https://i.imgur.com/c1F99VX.jpg",
                        "https://i.imgur.com/93PsGWC.jpg",
                        "https://i.imgur.com/yFFVNTv.jpg"
                    };
                    BindingContext = this;
                    dateButton.Text = "Выбрать дату";
                    dateButton.TextTransform = TextTransform.None;
                    dateButton.FontSize = 25;
                    dateButton.Margin = new Thickness(15, 20);
                    dateButton.FontAttributes = FontAttributes.Bold;
                    dateButton.BackgroundColor = Color.FromHex("#2196f3");
                    dateButton.TextColor = Color.White;
                    dateButton.CornerRadius = 15;
                    dateButton.Clicked += FindRoom;
                    break;
            }
        }
        private async void FindRoom(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new FindedRoomPage(login));
        }
        private async void ExitButtonClick(object sender, EventArgs e)
        {
            Thread.Sleep(5);
            await Navigation.PopToRootAsync();
            await App.Current.MainPage.Navigation.PopToRootAsync();
            MainPage mainPage = new MainPage();
            App.Current.MainPage = new NavigationPage(mainPage);
        }

        private void MainButtonClick(object sender, EventArgs e)
        {
            
        }

        private async void ServicesButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicePageUWP(login));
        }
        private async void AboutUsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutSUSPageUWP(login));
        }
        private async void ContacsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPageUWP(login));
        }
    }
}