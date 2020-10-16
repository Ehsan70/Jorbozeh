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

        public async Task<List<Card>> GetAllCards()
        {
            try
            {
                return (await firebase
                  .Child("Simple")
                  .OnceAsync<Card>()).Select(item => new Card
                  {
                      CardDesc = (string)item.Object.CardDesc,
                      CardSubDesc = (string)item.Object.CardSubDesc,
                      CardImage = (string)item.Object.CardImage,
                      CardTitle = (string)item.Object.CardTitle
                  }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }

        }
    }
}
