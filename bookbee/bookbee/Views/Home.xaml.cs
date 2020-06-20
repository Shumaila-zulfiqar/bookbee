using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace bookbee.Views
{
    //  [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private const string V = "100";
        public ObservableCollection<string> ListItems { get; set; }
        // public string Aspect { get; }
        //  public string Margin { get; }

        public Home()
        {
            InitializeComponent();
            ListItems = new ObservableCollection<string>()
            { "embeded1.jpg", "embeded2.jpeg" , "embeded3.jpeg" , "embeded4.jpeg"};
            this.BindingContext = this;
    //   var slide2 = new ObservableCollection() { Title = "Make Your Personal Library", Source = "bookbee.Assets.embeded3.jpeg" };
        //   var slide3 = new ObservableCollection() { Title = "Find Your Favourite Books", Source = "bookbee.Assets.embeded3.jpeg " };
       //     var slide4 = new ObservableCollection() { Title = "Find Your Favourite Authors", Source = "bookbee.Assets.embeded4.jpeg" };
            //  ResourceId.Add(slide1);
      //      ListItems.Add(slide2);
      //      ListItems.Add(slide3);
        //    ListItems.Add(slide4);
        
         //   MainCarousalView.ItemsSource = ListItems;
            Device.StartTimer(TimeSpan.FromSeconds(7), (Func<bool>)(() =>
            {
               MainCarousalView.Position = (MainCarousalView.Position + 1) % ListItems.Count;
                return true;
            }));

            //  BackgroundImage = "help.jpg"; Aspect = "AspectFit"; HeightRequest = 'V' ; Margin = "50 50 50 50";

        }

        private async void camera_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }



            var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        DefaultCamera = CameraDevice.Front,
                        SaveToAlbum = true
                    }
                    );
            if (file == null)
                return;

            string path = file.Path;
            var image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            await Navigation.PushAsync(new upload(path, image));

            /*path.Text = file.AlbumPath;

            img.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });*/


        }

        private async void upload_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("ALERT", "pick photo not supported", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            string path = file.Path;
            var image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            await Navigation.PushAsync(new upload(path, image));




            /*path.Text = "photo path" + file.Path;

            img.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });*/
        }

        private async void mybooks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyBooks());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new About());
        }
    }
}