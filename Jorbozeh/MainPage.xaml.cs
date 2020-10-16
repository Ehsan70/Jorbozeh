using Jorbozeh.Helper;
using Jorbozeh.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jorbozeh
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public MainPage()
        {
            InitializeComponent();
        }

        async void NextCard_btn_Clicked(object sender, EventArgs e)
        {
            cardDesc.Text = "changes Button_Clicked";
            //await firebaseHelper.AddCard(22, "11111");
            List<Model.Card> res = await firebaseHelper.GetAllCards();
            foreach(var c in res)
            {
                if (c is null)
                {
                    Console.WriteLine("Object is null");
                }
                else
                {
                    Console.WriteLine(c.ToString());
                }
            }
        }
    }
}
