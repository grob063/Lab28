using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab28a.Models
{
    public class NewDeck
    {
         public bool Shuffled { get; set; }
         public bool Success { get; set; }
         public string Deck_id { get; set; }
         public int Remaining { get; set; }       
    }

}
