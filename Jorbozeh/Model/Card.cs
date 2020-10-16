using System;
using System.Collections.Generic;
using System.Text;

namespace Jorbozeh.Model
{
    public class Card
    {
        public string CardTitle { get; set; }
        public string CardDesc { get; set; }
        public string CardSubDesc { get; set; }
        public string CardImage { get; set; }

        public override string ToString()
        {
            return $"Id: {1}, Title: {CardTitle}, Desc: {CardDesc}, SubDesc: {CardSubDesc}";
        }
    }
}
