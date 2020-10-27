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
        private Random random = new Random();
        private const int BATCH_COUNT = 10;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<Card> allCards;
        public List<Card>[] allBatchedCards = new List<Card>[BATCH_COUNT];
        public List<int>[] drawnCards = new List<int>[BATCH_COUNT];
        private int currentBatch = 0;

        public Game(List<CardDeck> cardDecks)
        {
            InitializeComponent();
            for(int x = 0; x < BATCH_COUNT; x++)
            {
                drawnCards[x] = new List<int>();
                allBatchedCards[x] = new List<Card>();
            }
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

            foreach (Card card in allCards)
            {
                switch (card.CardBatch)
                {
                    case 0:
                        allBatchedCards[0].Add(card);
                        break;
                    case 1:
                        allBatchedCards[1].Add(card);
                        break;
                    case 2:
                        allBatchedCards[2].Add(card);
                        break;
                    case 3:
                        allBatchedCards[3].Add(card);
                        break;
                    case 4:
                        allBatchedCards[4].Add(card);
                        break;
                    case 5:
                        allBatchedCards[5].Add(card);
                        break;
                    case 6:
                        allBatchedCards[6].Add(card);
                        break;
                    case 7:
                        allBatchedCards[7].Add(card);
                        break;
                    case 8:
                        allBatchedCards[8].Add(card);
                        break;
                    default:
                        allBatchedCards[9].Add(card);
                        break;

                }
            }

            Console.WriteLine($"There are {allCards.Count} in the game!");
        }

        void NextCard_btn_Clicked(object sender, EventArgs e)
        {
            int currectCardNum = random.Next(allBatchedCards[currentBatch].Count);
            while (drawnCards[currentBatch].Contains(currectCardNum) && drawnCards[currentBatch].Count != allBatchedCards[currentBatch].Count)
            {
                currectCardNum = random.Next(drawnCards[currentBatch].Count);
            }
            drawnCards[currentBatch].Add(currectCardNum);

            Console.WriteLine($"currentBatch: {currentBatch} \t currectCard:{currectCardNum} \t card: {allBatchedCards[currentBatch][currectCardNum]}");
            cardDesc.Text = allBatchedCards[currentBatch][currectCardNum].CardDesc;
            cardSubDesc.Text = allBatchedCards[currentBatch][currectCardNum].CardSubDesc;
            cardTitle.Text = allBatchedCards[currentBatch][currectCardNum].CardTitle;
            if (drawnCards[currentBatch].Count == allBatchedCards[currentBatch].Count)
                currentBatch++;
        }
    }
}
