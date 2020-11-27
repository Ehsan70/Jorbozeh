using System;
using System.Collections.Generic;
using System.Text;

namespace Jorbozeh
{
    public class CardDeck
    {
        public CardDeck(string name, string persianName, string availibility, string detail)
        {
            PersianName = persianName;
            Name = name;
            Detail = detail;
            Availibility= availibility;
        }
        public string PersianName { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Availibility { get; set; }
        public override string ToString()
        {
            return $"Deck Name: {Name}, Persian Name: {PersianName}, Detail: {Detail}, Availibility: {Availibility}";
        }
    }
}
