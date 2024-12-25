using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project37_CodeFirstBasic.Data
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Platform { get; set; } = "";

        public decimal Rating { get; set; }
        public List<Game> Games { get; set; }

    }
}
