using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueBuddy.Models
{
    public class Account
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public int Level { get; set; }

        public string Tier { get; set; }

        public string Division { get; set; }

        public int LP { get; set; }

        public long SummonerId { get; set; }

    }
}
