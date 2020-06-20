using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBooks : ContentPage
    {
        public MyBooks()
        {
            InitializeComponent();
            { 

                var images = new List<string>()
               {"https://www.creativindie.com/wp-content/uploads/2012/07/stock-image-site-pinterest-graphic.jpg",
                "https://i.huffpost.com/gen/1039678/original.jpg",
                "https://cdn6.f-cdn.com/contestentries/1397507/22020034/5b7fabfd102b5_thumb900.jpg"

             };
               // MainCarousalView.ItemsSource = images;
              
            }
        }
    }
}
