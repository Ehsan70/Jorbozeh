using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jorbozeh
{
    [ContentProperty (nameof(Source))]
    class ImageResourceExtention : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if(Source == null)
            {
                return null;
            }
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtention).GetTypeInfo().Assembly);
            return imageSource;
        }
    }
}
