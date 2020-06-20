using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace bookbee
{
    //[ContentProperty  (nameof(Resource))]
    public class ImageResourceExtension : IValueConverter
    {
        public string Source { get; set; }
     //   public string Title { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Source = (string)value;

            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require

            var imageSource = ImageSource.FromResource("bookbee.Assets." + Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            return imageSource;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}