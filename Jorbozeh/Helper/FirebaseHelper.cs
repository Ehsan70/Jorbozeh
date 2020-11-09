using Firebase.Database;
using Firebase.Database.Query;
using Jorbozeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Jorbozeh.Helper
{
    public class FirebaseHelper
    {
        //Source: https://github.com/susairajs/Xamarin-Firebase-RealtimeDatabase
        FirebaseClient firebase = new FirebaseClient("https://jorbozeh-6ae59.firebaseio.com/");
        const String FB_CARDS_KEY = "Cards";

        public async Task<Card> GetCard(string cardId)
        {
            Card c = await firebase.Child("Simple").Child(cardId).OnceSingleAsync<Card>();
            Console.WriteLine($"c is : {c}");
            return c;
        }
        public async Task<Card> GetFirstCard()
        {
            try
            {
                IReadOnlyCollection<FirebaseObject<List<Card>>> res =  await firebase.Child("Simple").OnceAsync<List<Card>>();
            Console.WriteLine($"{res}");
            return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }

        }

        public async Task<List<CardDeck>> GetDeckInfo()
        {
            // Gets list of all the cards in firebase
            IReadOnlyCollection<FirebaseObject<CardDeck>> cds = await firebase.Child(FB_CARDS_KEY).OnceAsync<CardDeck>();
            var lst = new List<CardDeck>();
            foreach (FirebaseObject<CardDeck> cd in cds)
            {
                var cardDeck = new CardDeck(cd.Object.Name, cd.Object.PersianName, cd.Object.Availibility, cd.Object.Detail);
                lst.Add(cardDeck);
            }
            return lst;
        }

        public async Task<List<Card>> GetCardsByDeck(string cardDeckKey)
        {
            // Example of cardDeckKey is Simple, Hot, DoubleHot, etc
            // cardDeckKey is how the cards are found in firebase
            IReadOnlyCollection<FirebaseObject<Card>> cc = await firebase.Child(cardDeckKey).OnceAsync<Card>();
            var lst = new List<Card>();
            foreach (FirebaseObject<Card> c in cc)
            {
                var card = new Card(c.Object.CardTitle, c.Object.CardBatch, c.Object.CardTitle, c.Object.CardDesc, c.Object.CardSubDesc, c.Object.CardImage);
                lst.Add(card);
            }
            return lst;
        }
    }
}
