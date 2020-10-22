using System;
using System.Collections.Generic;
using System.Text;

namespace Jorbozeh
{
    class CardDeck
    {
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
