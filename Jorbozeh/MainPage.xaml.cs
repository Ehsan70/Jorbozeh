using Jorbozeh.Helper;
using Jorbozeh.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Jorbozeh
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Card> cards;

        public MainPage()
        {
            InitializeComponent();
            InitCards();
        }

        async void InitCards()
        {
            cards = await firebaseHelper.GetAllCards();
        }

        void NextCard_btn_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            var currectCard = random.Next(0, cards.Count);
            cardDesc.Text = cards[currectCard].CardDesc;
            cardSubDesc.Text = cards[currectCard].CardSubDesc;
            cardTitle.Text = cards[currectCard].CardTitle;
        }
    }
}
