using Jorbozeh.Helper;
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
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public  WelcomePage()
        {
            InitializeComponent();
            UpdateCards();
        }

        async void UpdateCards()
        {
            decks.HasUnevenRows = true;
            decks.ItemsSource = await firebaseHelper.GetDeckInfo();
            decks.ItemTapped += Decks_ItemTapped;
        }
        public ICommand TapCommand => new Command<string>(async (url) => await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred));


        public ICommand ClickCommand => new Command<string>((url) =>
        {
            // TODO: make the link clickable
            Device.OpenUri(new System.Uri(url));
        });

        private void Decks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = (ListView)sender;
            CardDeck d = (CardDeck)e.Item;
            if (SelectedCardDecks.Contains(d))
            {
                DisplayAlert("", $"دسته کارت حذف شد ({string.Join("\n", d.PersianName)})", "اِی وای");
                SelectedCardDecks.Remove(d);
            }
            else
            {
                DisplayAlert("", $"دسته کارت اضافه شد ({string.Join("\n", d.PersianName)})", "آخ جون");
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