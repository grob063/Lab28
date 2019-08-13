using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab28a.Models
{
    public class DrawCard
    {
        public int Remaining { get; set; }
        public bool IsGood { get; set; }
        public Card[] Cards { get; set; }
        public string Deck_id { get; set; }
        public string Image { get; set; }
    }
}
