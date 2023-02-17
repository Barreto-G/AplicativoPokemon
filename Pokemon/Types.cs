using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPokemon.Pokemon
{
    public class Types
    {
        public int slot { get; set; }

        public Type type { get; set; }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}
