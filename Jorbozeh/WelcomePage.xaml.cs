using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jorbozeh
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public List<CardDeck> SelectedCardDecks = new List<CardDeck>();
        public WelcomePage()
        {
            InitializeComponent();
            decks.ItemsSource = new List<CardDeck>() {
                new CardDeck()
                {
                    Name = "Simple", PersianName="ساده", Availibility="Public", Detail="ساده"
                },
                new CardDeck(){
                    Name = "Moostafa", PersianName="مووستفا", Availibility="Public", Detail="مووستفا1"
                },
                new CardDeck(){
                    Name = "Hot", PersianName="داغ", Availibility="Public", Detail="داغ2"
                },
                new CardDeck(){
                    Name = "DoubleHot", PersianName="خیلی‌ داغ", Availibility="Public", Detail="داغ3"
                }
            };
            decks.ItemTapped += Decks_ItemTapped;
        }

        private void Decks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = (ListView)sender;
            CardDeck d = (CardDeck)e.Item;
            if (SelectedCardDecks.Contains(d))
            {
                SelectedCardDecks.Remove(d);
                lv.BackgroundColor = Color.Red;
            }
            else
            {
                SelectedCardDecks.Add(d);
                lv.BackgroundColor = Color.Blue;

            }

            DisplayAlert("Confirm", $"Add {string.Join("\n", SelectedCardDecks)}", "ok");
        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Game(SelectedCardDecks));
        }

    }
}