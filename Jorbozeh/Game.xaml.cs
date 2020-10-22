using Jorbozeh.Helper;
using Jorbozeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Jorbozeh
{
    public partial class Game : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<Card> allCards;

        public Game(List<CardDeck> cardDecks)
        {
            InitializeComponent();
            InitCards(cardDecks);
        }

        async void InitCards(List<CardDeck> cardDecks)
        {
            foreach(CardDeck cd in cardDecks)
            {
                var cards = await firebaseHelper.GetCardsByDeck(cd.Name);
                if (allCards == null)
                {
                    Console.WriteLine($"Initialized allCards with {cd.Name} ");
                    allCards = new List<Card>(cards);
                }
                else
                {
                    Console.WriteLine($"Add {cd.Name} to allCards");
                    allCards.AddRange(cards);
                }
            }
            Console.WriteLine($"There are {allCards.Count} in the game!");
        }

        void NextCard_btn_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            var currectCard = random.Next(0, allCards.Count);
            cardDesc.Text = allCards[currectCard].CardDesc;
            cardSubDesc.Text = allCards[currectCard].CardSubDesc;
            cardTitle.Text = allCards[currectCard].CardTitle;
        }
    }
}
