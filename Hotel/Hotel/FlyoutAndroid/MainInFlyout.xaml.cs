using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainInFlyout : ContentPage
    {
        readonly string login;
        readonly string name;
        readonly string surname;
        private bool isAdded;
        private string roomstype;
        readonly DateTime checkIn;
        readonly DateTime checkOut;
        public MainInFlyout(string login)
        {
            this.login = login;
            isAdded = false;
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
        public MainInFlyout(string login, DateTime checkIn, DateTime checkOut, string type)
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
            switch (roomstype)
            {
                case "Single":
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "Вместимость 1 человек";
                    bed.Text = "Большая кровать (1.8 x 2)М²";
                    square.Text = "Площадь 30 квадратных метров";
                    ObservableCollection<string> imageUrls = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/F9hbJEF.jpeg",
                        "https://i.imgur.com/2D3J0gh.jpeg",
                        "https://i.imgur.com/3B4WMgz.jpeg"
                    };
                    carouselView.ItemsSource = imageUrls;
                    break;
                case "Lux":
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "Вместимость 4 человека";
                    bed.Text = "Очень большая кровать (3 x 2)М²";
                    square.Text = "Площадь 60 квадратных метров";
                    ObservableCollection<string> imageUrls1 = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/Tmm1lCV.jpg",
                        "https://i.imgur.com/Q5lxTsj.jpg",
                        "https://i.imgur.com/cJuzvKH.jpg"
                    };
                    carouselView.ItemsSource = imageUrls1;
                    break;
                case "Twin":
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "• Вместимость 2 человека";
                    bed.Text = "• Очень большая кровать (3 x 2)М²";
                    square.Text = " • Площадь 60 квадратных метров";
                    ObservableCollection<string> imageUrls2 = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/jDeTVqJ.jpg",
                        "https://i.imgur.com/l5ZnaJ8.jpg",
                        "https://i.imgur.com/yqqnU0S.jpg"
                    };
                    carouselView.ItemsSource = imageUrls2;

                    break;
                case "Super Lux":
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "• Вместимость 2 человека";
                    bed.Text = "• Очень большая кровать (3 x 2)М²";
                    square.Text = " • Площадь 60 квадратных метров";
                    ObservableCollection<string> imageUrls3 = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/E7vO3T5.jpeg",
                        "https://i.imgur.com/h7qkz6u.jpeg",
                        "https://i.imgur.com/JB53JRk.jpeg"
                    };
                    carouselView.ItemsSource = imageUrls3;
                    break;
                case "King-Size":
                    isGuest.Text = "Сейчас вами занята комната " + roomstype + " c " + checkIn.ToString("d") + " по " + checkOut.ToString("d");
                    capacity.Text = "• Вместимость 2 человека";
                    bed.Text = "• Очень большая кровать (3 x 2)М²";
                    square.Text = " • Площадь 60 квадратных метров";

                    ObservableCollection<string> imageUrls4 = new ObservableCollection<string>
                    {
                        "https://i.imgur.com/c1F99VX.jpg",
                        "https://i.imgur.com/93PsGWC.jpg",
                        "https://i.imgur.com/yFFVNTv.jpg"
                    };
                    carouselView.ItemsSource = imageUrls4;
                    break;
                default:
                    isGuest.Text = "Сейчас вы не проживаете в отеле";
                    isGuest.TextColor = Color.Red;
                    ObservableCollection<string> imageUrls5 = new ObservableCollection<string>
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
                    carouselView.ItemsSource = imageUrls5;                    
                    Button findRoomButton = new Button
                    {
                        CornerRadius = 20,
                        Text = "Выбрать дату",
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.FromHex("#2196f3"),
                        TextColor = Color.White,
                        Margin = new Thickness(0, 20),
                        TextTransform = TextTransform.None,
                        FontSize = 20
                    };
                    findRoomButton.Clicked += FindRoom;                   
                    if(!isAdded)
                    {
                        appPageStack.Children.Remove(parametersFrame);
                        appPageStack.Children.Add(findRoomButton);
                        isAdded = true;
                    }
                    break;
            }
        }
        private async void FindRoom(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new FindedRoomPage(login));
        }
    }
}