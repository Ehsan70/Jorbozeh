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
        List<CardDeck> SelectedCardDecks = new List<CardDeck>();
        public WelcomePage()
        {
            InitializeComponent();
            decks.ItemsSource = new List<CardDeck>() {
                new CardDeck()
                {
                    Name = "Simple", PersianName="ساده", Availibility="Public", Detail="ساده"
                },
                new CardDeck(){
                    Name = "Simple", PersianName="1ساده", Availibility="Public", Detail="ساده1"
                },
                new CardDeck(){
                    Name = "Simple", PersianName="ساده2", Availibility="Public", Detail="ساده2"
                }
            };
            decks.ItemTapped += Decks_ItemTapped;
        }

        private void Decks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView l = (ListView)sender;
            CardDeck d = (CardDeck)e.Item;
            if (SelectedCardDecks.Contains(d))
            {
                SelectedCardDecks.Remove(d);
                l.BackgroundColor = Color.Red;
            }
            else
            {
                SelectedCardDecks.Add(d);
                l.BackgroundColor = Color.Blue;

            }

            DisplayAlert("SelectedCardDecks", $"{l.SelectedItem} + {string.Join("\n", SelectedCardDecks)}", "ok");
        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Game());
        }

    }
}