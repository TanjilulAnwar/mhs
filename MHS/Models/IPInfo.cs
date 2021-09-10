using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHS.Models
{
    public class IPInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string description { get; set; }
        public bool is_active { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

    }
}
