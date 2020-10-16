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
        public MainPage()
        {
            InitializeComponent();
        }

        void NextCard_btn_Clicked(object sender, EventArgs e)
        {
            cardDesc.Text = "changes Button_Clicked";
        }
    }
}
