using System;
using System.Collections.Generic;
using System.Text;

namespace Jorbozeh.Model
{
    public class Card
    {
        public string CardDeck { get; set; }
        public int CardBatch { get; set; }
        public string CardTitle { get; set; }
        public string CardDesc { get; set; }
        public string CardSubDesc { get; set; }
        public string CardImage { get; set; }

        public Card(string cardDeck, int cardBatch, string cardTitle, string cardDesc, string cardSubDesc, string cardImage)
        {
            CardDeck = cardDeck;
            CardBatch = cardBatch;
            CardTitle = cardTitle;
            CardDesc = cardDesc;
            CardSubDesc = cardSubDesc;
            CardImage = cardImage;
        }

        public override string ToString()
        {
            return $"Deck: {CardDeck}, Batch: {CardBatch}, Title: {CardTitle}, Desc: {CardDesc}, SubDesc: {CardSubDesc}";
        }
    }
}
