using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoImporter.Markets
{
    public class QuoteInfo
    {
        //API Returning always 24h accumulated values for volume,volumeavgprice and numoftrades
        public double ask { get; set; }
        public double bid { get; set; }
        public double last { get; set; }
        public double volume { get; set; }
        public DateTime timestamp { get; set; }
    }
}
