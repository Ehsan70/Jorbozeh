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
        public int currentCardIndex = 0;
        private int currentBatchIndex = 0;

        public Game(List<CardDeck> cardDecks)
        {
            InitializeComponent();
            for(int x = 0; x < BATCH_COUNT; x++)
            {
                allBatchedCards[x] = new List<Card>();
            }
            InitCards(cardDecks);
        }

        public static List<T> Shuffle<T>(List<T> list)
        {
            Random rnd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int k = rnd.Next(0, i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
            return list;
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

            for (int i = 0; i < BATCH_COUNT; i++)
            {
                allBatchedCards[i] = Shuffle<Card>(allBatchedCards[i]);
            }
            Console.WriteLine($"Shuffled cards.");

        }

        void NextCard_btn_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine($"Drawing card currentBatchIndex is {currentBatchIndex } currentCardIndex is {currentCardIndex}");
            while (allBatchedCards[currentBatchIndex].Count == 0)
            {
                currentBatchIndex++;
                if (currentBatchIndex > 9)
                {
                    Console.WriteLine($"Game finished: currentBatchIndex:{currentBatchIndex } currentCardIndex is {currentCardIndex}");

                    //TODO: game finished handle it
                    //break;
                    currentBatchIndex = 0;
                    currentCardIndex = 0;
                    return;
                }
            }
            cardDesc.Text = allBatchedCards[currentBatchIndex][currentCardIndex].CardDesc;
            cardSubDesc.Text = allBatchedCards[currentBatchIndex][currentCardIndex].CardSubDesc;
            cardTitle.Text = allBatchedCards[currentBatchIndex][currentCardIndex].CardTitle;
            if (allBatchedCards[currentBatchIndex].Count <= (currentCardIndex+1))
            {
                Console.WriteLine($"currentBatchIndex is {currentBatchIndex } currentCardIndex is {currentCardIndex}");
                currentBatchIndex++;
                currentCardIndex = 0;
                Console.WriteLine($"Update: currentBatchIndex is {currentBatchIndex } currentCardIndex is {currentCardIndex}");

            }
            else
            {
                Console.WriteLine($"Increaseing card index : currentBatchIndex is {currentBatchIndex } currentCardIndex is {currentCardIndex}");
                currentCardIndex++;
            }
        }
    }
}
