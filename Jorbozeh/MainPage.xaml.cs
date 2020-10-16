using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jorbozeh
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            cardDesc.Text = "changes after init";
            Console.WriteLine("got init");

            //nextCard_btn.Clicked += nextCard_btn_Clicked;
            /*            Title = "Code Button Click";

                        Label label = new Label
                        {
                            Text = "Click the Button below",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.Center
                        };

                        Button button = new Button
                        {
                            Text = "Click to Rotate Text!",
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        button.Clicked += async (sender, args) => await label.RelRotateTo(360, 1000);

                        Content = new StackLayout
                        {
                            Children =
                        {
                            label,
                            button
                        }
                        };*/

        }

        /*        async void nextCardClicked(object sender, EventArgs e)
                {
                    cardDesc.Text = "changes";
                    await DisplayAlert("Alert", "You have been alerted", "OK");
                    Debug.WriteLine("Answer: " );
                }*/

        public void NextCard_btn_Clsadficked(object sender, EventArgs e)
        {
            Console.WriteLine("next card got clicked");
            cardDesc.Text = "changes";
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("next card got clicked Button_Clicked");
            await DisplayAlert("Test", "Clicked!!", "OK");

            cardDesc.Text = "changes Button_Clicked";
        }
    }
}
