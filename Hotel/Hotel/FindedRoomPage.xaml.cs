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
    public partial class FindedRoomPage : ContentPage
    {
        private readonly string login;
        private List<Room> rooms;
        private DateTime checkOut;
        private DateTime checkIn;
        readonly private ObservableCollection<string> SingleRoomImageUrls = new ObservableCollection<string>
        {
            "https://i.imgur.com/F9hbJEF.jpeg",
            "https://i.imgur.com/2D3J0gh.jpeg",
            "https://i.imgur.com/3B4WMgz.jpeg"
        };
        readonly private ObservableCollection<string> TwinRoomImageUrls = new ObservableCollection<string>
        {
            "https://i.imgur.com/jDeTVqJ.jpg",
            "https://i.imgur.com/l5ZnaJ8.jpg",
            "https://i.imgur.com/yqqnU0S.jpg"
        };
        readonly private ObservableCollection<string> LuxRoomImageUrls = new ObservableCollection<string>
        {
            "https://i.imgur.com/Tmm1lCV.jpg",
            "https://i.imgur.com/Q5lxTsj.jpg",
            "https://i.imgur.com/cJuzvKH.jpg"
        };
        readonly private ObservableCollection<string> SuperLuxRoomImageUrls = new ObservableCollection<string>
        {
            "https://i.imgur.com/E7vO3T5.jpeg",
            "https://i.imgur.com/h7qkz6u.jpeg",
            "https://i.imgur.com/JB53JRk.jpeg"
        };
        readonly private ObservableCollection<string> KingSizeRoomImageUrls = new ObservableCollection<string>
        {
            "https://i.imgur.com/c1F99VX.jpg",
            "https://i.imgur.com/93PsGWC.jpg",
            "https://i.imgur.com/yFFVNTv.jpg"
        };

        public FindedRoomPage(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void SelectedCheckIn(object sender, DateChangedEventArgs e) 
        {
            checkIn = e.NewDate;
        }

        private void SelectedCheckOut(object sender, DateChangedEventArgs e)
        {            
            checkOut = e.NewDate;
        }

        private void FindButtonClicked(object sender, EventArgs e)
        {
            RoomsList.Children.Clear();
            rooms = Client.ClientFindRoom(checkIn, checkOut);
            foreach (Room room in rooms)
            {
                StackLayout RoomStack = new StackLayout();
                StackLayout BookStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                Frame ListFrame = new Frame
                {
                    Margin = new Thickness(25, 0, 25, 25),
                    Padding = new Thickness(25, 25),
                    BackgroundColor = Color.FromHex("#e5e5e5"),
                    CornerRadius = 20,
                    Content = RoomStack
                };
                RoomStack.Margin = new Thickness(0);
                Label labelType = new Label();
                Label labelCount = new Label();
                Label labelCost = new Label();
                Label labelCapacity = new Label();
                labelType.Text = "Комната типа" + " " + room.Type;
                labelType.FontAttributes = FontAttributes.Bold;
                labelCapacity.Text = "Вместимость" + " " + room.Capacity;
                labelCapacity.FontAttributes = FontAttributes.Bold;
                labelCount.Text = "Количество свободных комнат" + " " + room.Id.ToString();
                labelCount.FontAttributes = FontAttributes.Bold;
                labelCost.Text = "Цена:" + " " + room.Cost.ToString();
                labelCost.FontAttributes = FontAttributes.Bold;
                RoomStack.Children.Add(labelType);
                RoomStack.Children.Add(labelCount);
                RoomStack.Children.Add(labelCapacity);
                RoomStack.Children.Add(labelCost);
                switch (room.Type)
                {
                    case "Single":
                        
                        var carousel = CreateCarousel(SingleRoomImageUrls);
                        var BookButton = CreateButton("Single");
                        Frame carouselFrame = new Frame
                        {
                            Padding = new Thickness(0),                           
                            HeightRequest = 200,
                            CornerRadius = 20,
                            HasShadow = true,
                            Content = carousel,
                            Margin = new Thickness(0, 0, 100, 0)
                        };
                        if (Device.RuntimePlatform != Device.UWP)
                        {
                            carouselFrame.Margin = new Thickness(0);
                            BookStack.Orientation = StackOrientation.Vertical;
                        }
                        BookButton.Clicked += BookButtonClicked;
                        BookStack.Children.Add(carouselFrame);
                        BookStack.Children.Add(BookButton);
                        RoomStack.Children.Add(BookStack);
                        RoomsList.Children.Add(ListFrame);
                        break;
                    case "Twin":
                        var carousel1 = CreateCarousel(TwinRoomImageUrls);
                        var BookButton1 = CreateButton("Twin");
                        Frame carouselFrame1 = new Frame
                        {
                            Padding = new Thickness(0),
                            Margin = new Thickness(0, 0, 100, 0),
                            HeightRequest = 200,
                            CornerRadius = 20,
                            HasShadow = true,
                            Content = carousel1
                        };
                        if (Device.RuntimePlatform != Device.UWP)
                        {
                            carouselFrame1.Margin = new Thickness(0);
                            BookStack.Orientation = StackOrientation.Vertical;
                        }
                        BookButton1.Clicked += BookButtonClicked;
                        BookStack.Children.Add(carouselFrame1);
                        BookStack.Children.Add(BookButton1);
                        RoomStack.Children.Add(BookStack);
                        RoomsList.Children.Add(ListFrame);
                        break;
                    case "Lux":
                        var carousel2 = CreateCarousel(LuxRoomImageUrls);
                        var BookButton2 = CreateButton("Lux");
                        Frame carouselFrame2 = new Frame
                        {
                            Padding = new Thickness(0),
                            Margin = new Thickness(0, 0, 100, 0),
                            HeightRequest = 200,
                            CornerRadius = 20,
                            HasShadow = true,
                            Content = carousel2
                        };
                        if (Device.RuntimePlatform != Device.UWP)
                        {
                            carouselFrame2.Margin = new Thickness(0);
                            BookStack.Orientation = StackOrientation.Vertical;
                        }
                        BookButton2.Clicked += BookButtonClicked;
                        BookStack.Children.Add(carouselFrame2);
                        BookStack.Children.Add(BookButton2);
                        RoomStack.Children.Add(BookStack);
                        RoomsList.Children.Add(ListFrame);
                        break;
                    case "Super-Lux":
                        var carousel3 = CreateCarousel(SuperLuxRoomImageUrls);
                        var BookButton3 = CreateButton("Super-Lux");
                        Frame carouselFrame3 = new Frame
                        {
                            Padding = new Thickness(0),
                            Margin = new Thickness(0, 0, 100, 0),
                            HeightRequest = 200,
                            CornerRadius = 20,
                            HasShadow = true,
                            Content = carousel3
                        };
                        if (Device.RuntimePlatform != Device.UWP)
                        {
                            carouselFrame3.Margin = new Thickness(0);
                            BookStack.Orientation = StackOrientation.Vertical;
                        }
                        BookButton3.Clicked += BookButtonClicked;
                        BookStack.Children.Add(carouselFrame3);
                        BookStack.Children.Add(BookButton3);
                        RoomStack.Children.Add(BookStack);
                        RoomsList.Children.Add(ListFrame);
                        break;
                    case "King-Size":
                        var carousel4 = CreateCarousel(KingSizeRoomImageUrls);
                        var BookButton4 = CreateButton("King-Size");
                        Frame carouselFrame4 = new Frame
                        {
                            Padding = new Thickness(0),
                            Margin = new Thickness(0, 0, 100, 0),
                            HeightRequest = 200,
                            CornerRadius = 20,
                            HasShadow = true,
                            Content = carousel4
                        };
                        if (Device.RuntimePlatform != Device.UWP)
                        {
                            carouselFrame4.Margin = new Thickness(0);
                            BookStack.Orientation = StackOrientation.Vertical;
                        }
                        BookButton4.Clicked += BookButtonClicked;
                        BookStack.Children.Add(carouselFrame4);
                        BookStack.Children.Add(BookButton4);
                        RoomStack.Children.Add(BookStack);
                        RoomsList.Children.Add(ListFrame);
                        break;
                }
            }
        }

        private async void BookButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (Device.RuntimePlatform == Device.UWP)
            {
                AppPageUWP appPageUWP = new AppPageUWP(login, checkIn, checkOut, clickedButton.ClassId);
                App.Current.MainPage = new NavigationPage(appPageUWP);
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                AppPage appPage = new AppPage(login, checkIn, checkOut, clickedButton.ClassId);
                App.Current.MainPage = new NavigationPage(appPage);
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }

            switch (clickedButton.ClassId)
            {
                case "Single":
                    Client.ClientBook(login, "Single", checkIn, checkOut);
                    break;
                case "Twin":
                    Client.ClientBook(login, "Twin", checkIn, checkOut);
                    break;
                case "Lux":
                    Client.ClientBook(login, "Lux", checkIn, checkOut);
                    break;
                case "Super-Lux":
                    Client.ClientBook(login, "Super Lux", checkIn, checkOut);
                    break;
                case "King-Size":
                    Client.ClientBook(login, "King-Size", checkIn, checkOut);
                    break;
            }
        }

        private static Button CreateButton(string id)
        {
            Button button = new Button
            {
                Text = "Забронировать",
                TextTransform = TextTransform.None,
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromHex("#2196f3"),
                TextColor = Color.White,
                CornerRadius = 15,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                ClassId = id,
                Margin = new Thickness(50, 150, 0, 0)
                
            };
            if (Device.RuntimePlatform != Device.UWP)
            {
                button.Margin = new Thickness(0, 10, 0, 0);
                button.HorizontalOptions = LayoutOptions.Center;
            }
            return button;
        }

        private static Xamarin.Forms.CarouselView CreateCarousel(ObservableCollection<string> imageUrls)
        {
            var carouselView = new Xamarin.Forms.CarouselView
            {
                Margin = new Thickness(0),
            };
            carouselView.SetBinding(Xamarin.Forms.CarouselView.ItemsSourceProperty, "ImageUrls");
            carouselView.ItemsSource = imageUrls;
            var dataTemplate = new DataTemplate(() =>
            {
                var image = new Image
                {
                    Aspect = Aspect.AspectFill
                };
                image.SetBinding(Image.SourceProperty, ".");

                return image;
            });
            carouselView.ItemTemplate = dataTemplate;
            return carouselView;
        }           
    }
}