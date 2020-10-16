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

        public async Task AddCard(int cardId, string desc)
        {

            await firebase
              .Child("Cards")
              .PostAsync(new Card() {  CardDesc = desc, CardSubDesc= desc, CardTitle = desc });
        }

        public async Task<Card> GetFirstCard()
        {
            try
            {
                IReadOnlyCollection<FirebaseObject<Card>> res =  await firebase.Child("Simple").OrderByKey().LimitToFirst(1).OnceAsync<Card>();
            Console.WriteLine($"{res}");
            return new Card();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }

        }

        public async Task<List<Card>> GetAllCards()
        {
            try
            {
                Console.WriteLine("starting to read cards");

                var cards = await firebase.Child("Simple").OnceAsync<List<Card>>();
                //Console.WriteLine($"cards ==> {cards}");
                Console.WriteLine("JOINED: "+string.Join("\n", cards.Select(d => d.ToString())));

/*                foreach (var c in cards)
                {
                    Console.WriteLine($"c ==> {c}");
                    Card cc = Newtonsoft.Json.JsonConvert.DeserializeObject<Card>(c.Object.ToString());
                    Console.WriteLine($"c ==> {cc}");

                }*/
                return null;
/*                return (await firebase
                  .Child("Simple")
                  .OnceAsync<Card>()).Select(item => new Card
                  {
                      CardDesc = (string)item.Object.CardDesc,
                      CardSubDesc = (string)item.Object.CardSubDesc,
                      CardImage = (string)item.Object.CardImage,
                      CardTitle = (string)item.Object.CardTitle
                  }).ToList();*/
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }

        }
    }
}
