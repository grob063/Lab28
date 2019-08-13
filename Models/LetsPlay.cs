using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab28a.Models
{
    public class LetsPlay
    {
        public int Remaining { get; set; }
        public bool Drawns { get; set; }
        public List<Card> Cards { get; set; }
        public bool IsDeck { get; set; }
    }
}
