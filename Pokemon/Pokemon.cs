using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPokemon.pokemon
{
    public class Pokemon
    {
        public List<Habilidade> abilities { get;  set; }

        public List<Types> types { get;  set; }

        public int height { get; set; }
        public int weight { get; set; }

        public string name { get; set; }


        public override string ToString()
        {
            string tipos= "", habilidades = "";
            foreach(var tipo in types)
            {
                tipos += tipo.ToString() + " ";
            }
            foreach(var habilidade in abilities)
            {
                habilidades += habilidade.ToString() + " ";
            }

            return $"Nome: {name}\n" +
                   $"Altura: {height}\n" +
                   $"Peso: {weight}\n" +
                   $"Tipo(s): {tipos}\n" +
                   $"Habilidades: {habilidades}";
        }
    }
}
