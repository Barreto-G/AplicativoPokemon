using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPokemon.pokemon
{
    public class Tamagochi
    {
        public Pokemon pokemon;
        int fome = 5;
        int descanso = 5;
        int humor = 5;

        public void BrincarMascote()
        {
            if (humor != 10) 
            {
                humor++;
                fome--;
                descanso--;
            }
            else
            {
                Console.WriteLine("Seu Mascote nao aguenta mais brincar");
                Console.ReadKey();
            }

        }

        public void AlimentarMascote()
        {
            if (fome != 10)
            {
                fome+=2;
                descanso--;
            }
            else
            {
                Console.WriteLine("Seu mascote esta cheio");
                Console.ReadKey();
            }

        }

        public void Descansar()
        {
            if(descanso != 10)
            {
                descanso+=2;
                fome--;
            }
            else
            {
                Console.WriteLine("Seu mascote esta sem sono");
                Console.ReadKey();
            }

        }

        public override string ToString()
        {
            string fominha ="", descansado = "", humorado = "";
            #region fome
            if (this.fome < 5)
            {
                fominha = "Seu pokemon esta com fome\n";
            }
            else if(this.fome >= 5 && this.fome <= 10) 
            {
                fominha = "Seu pokemon esta bem alimentado\n";
            }
            else
            {
                fominha = "Seu Pokemon esta cheio\n";
            }
            #endregion

            #region humor
            if (this.humor < 5)
            {
                humorado = "Seu pokemon esta triste\n";
            }
            else if (this.humor >= 5 && this.humor <= 10)
            {
                humorado = "Seu pokemon esta feliz\n";
            }
            else
            {
                humorado = "Seu Pokemon esta muito feliz\n";
            }
            #endregion

            #region sono
            if (this.descanso < 5)
            {
                descansado = "Seu pokemon esta com sono\n";
            }
            else if (this.descanso >= 5 && this.descanso <= 10)
            {
                descansado = "Seu pokemon esta descansado\n";
            }
            else
            {
                descansado = "Seu Pokemon esta bem descansado\n";
            }
            #endregion
            return pokemon.ToString() +"\n"+ fominha + descansado + humorado;
        }
    }
}
