using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
            decks.HasUnevenRows = true;
            decks.ItemsSource = new List<CardDeck>() {
                new CardDeck()
                {
                    Name = "Simple", PersianName="ساده", Availibility="Public", Detail="کارای ساده و معمولی‌"
                },
                new CardDeck(){
                    Name = "Moostafa", PersianName="مووستفا", Availibility="Public", Detail="مووستفا هم بازی"
                },
                new CardDeck(){
                    Name = "Hot", PersianName="داغ", Availibility="Public", Detail="یه خورده صمیمی‌ تر بشیم"
                },
                new CardDeck(){
                    Name = "DoubleHot", PersianName="خیلی‌ داغ", Availibility="Public", Detail="خیلی‌ خیلی‌ صمیمی‌ بشیم"
                }
            };
            decks.ItemTapped += Decks_ItemTapped;
        }
        public ICommand TapCommand => new Command<string>(async (url) => await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred));


        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });

        private void Decks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = (ListView)sender;
            CardDeck d = (CardDeck)e.Item;
            if (SelectedCardDecks.Contains(d))
            {
                DisplayAlert("Confirm", $"Remove {string.Join("\n", d.Name)}", "ok");
                SelectedCardDecks.Remove(d);
            }
            else
            {
                DisplayAlert("Confirm", $"Add {string.Join("\n", d.Name)}", "ok");
                SelectedCardDecks.Add(d);
            }
        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {

            // TODO: make sure user select a card deck
            if(SelectedCardDecks.Count == 0)
            {
                DisplayAlert("لطفا حداقل یک دسته کارت انتخاب کنید", "روی دسته کارت کلیک کنید تا انتخاب شود", "چشم");
                return;

            }
            if (TermsCheckbox.IsChecked)
            {
                Navigation.PushModalAsync(new Game(SelectedCardDecks));
            }
            else
            {
                DisplayAlert("لطفاً با شرایط و ضوابط موافقت کنید", "روی کادر شرایط و ضوابط کلیک کنید", "چشم");
            }
        }

    }
}