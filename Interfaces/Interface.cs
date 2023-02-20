using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AplicativoPokemon.pokemon;
using RestSharp;

namespace AplicativoPokemon.Interfaces
{
    public class Interface
    {
        private string username { get; set; }
        private Tamagochi? myPokemon { get; set; }

        public void MainMenu()
        {
            try
            {
                username = telaBoasVindas();
                int escolha = 0;
                while(escolha != (int)'3')
                {
                    Console.Clear();
                    Console.WriteLine($"Ola {username}, o que gostaria de fazer?\n"+
                                      $"1. Adotar um Pokemon\n"+
                                      $"2. Exibir meu pokemon \n"+
                                      $"3. Sair");

                    escolha = Console.Read();
                    

                    switch (escolha)
                    {
                        case (int)'1':
                            Console.Clear();
                            this.myPokemon = new Tamagochi();
                            this.myPokemon.pokemon = EscolherPokemon();
                            break;
                        case (int)'2':
                            PokeShowStats(this.myPokemon);
                            Console.ReadLine();
                            break;
                        case (int)'3':
                            FinalMessage();
                            break;
                        default:
                            Console.WriteLine("Opcao invalida");
                            Console.ReadLine();
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            
        }

        public void FinalMessage()
        {
            Console.WriteLine("Obrigado por usar o Tamagochi Pokemon\n" +
                              "Feito por: Gabriel Barreto");
        }

        public void PokeShowStats(Tamagochi myPokemo)
        {
            Console.Write("Bug sem sentido");
            Console.Clear();
            if(myPokemo != null)
            {
                char escolha='0';
                while(escolha != '4')
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine($"------------ Seu Pokemon ------------\n"+
                                          myPokemo.ToString());
                        Console.WriteLine($"Deseja interagir com seu Pokemon?\n"+
                                          $"1. Alimenta-lo\n"+
                                          $"2. Brincar\n"+
                                          $"3. Colocar para dormir\n"+
                                          $"4. Sair da Tela de interacao");

                        escolha = ((char)Console.Read());
                        switch (escolha)
                        {
                            case '1':
                                myPokemo.AlimentarMascote();
                                escolha = '0';
                                break;
                            case '2':
                                myPokemo.BrincarMascote();
                                escolha = '0';
                                break;
                            case '3':
                                myPokemo.Descansar();
                                escolha = '0';
                                break;
                            case '4':
                                break;
                            default:
                                Console.WriteLine("Digite uma opcao valida!");
                                escolha = '0';
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                

            }
            else
            {
                throw new Exception("Pokemon nao encontrado");
            }
           

        }


        public string telaBoasVindas()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Ola! Boas vindas ao Tamagochi Pokemon, antes de comecarmos, diga-nos o seu nome: ");
                    string nome = Console.ReadLine();
                    Console.Clear();
                    if (nome != null)
                    {
                        return nome;
                    }
                
                }
                catch (IOException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private Pokemon FazerRequisicao(string URL)
        {
            var client = new RestClient(URL);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                Pokemon poke = JsonSerializer.Deserialize<Pokemon>(response.Content);
                return poke;

            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        private Pokemon EscolherPokemon()
        {
            Pokemon pokeEscolhido = null;
            bool aceitou = false;
            while (!aceitou)
            {
                Console.Clear();
                Console.WriteLine($"Digite o numero do pokemon que deseja adotar: \n" +
                                  $"1. Pikachu\n" +
                                  $"2. Charmander\n" +
                                  $"3. Bulbassauro\n" +
                                  $"4. Squitle");
                try
                {
                    var escolha = Console.ReadLine()[0];

                    switch (escolha)
                    {
                        case '1':
                            pokeEscolhido = FazerRequisicao("https://pokeapi.co/api/v2/pokemon/pikachu");
                            Console.WriteLine(pokeEscolhido.ToString());
                            break;

                        case '2':
                            pokeEscolhido = FazerRequisicao("https://pokeapi.co/api/v2/pokemon/charmander");
                            Console.WriteLine(pokeEscolhido.ToString());
                            break;

                        case '3':
                            pokeEscolhido = FazerRequisicao("https://pokeapi.co/api/v2/pokemon/bulbasaur");
                            Console.WriteLine(pokeEscolhido.ToString());
                            break;

                        case '4':
                            pokeEscolhido = FazerRequisicao("https://pokeapi.co/api/v2/pokemon/squirtle");
                            Console.WriteLine(pokeEscolhido.ToString());
                            break;

                        default:
                            Console.WriteLine("Opcao digitada eh invalida!");
                            pokeEscolhido = null;
                            break;

                    }
                    if(pokeEscolhido != null)
                    {
                        Console.WriteLine("Deseja confirmar a escolha desse pokemon? (y)sim (n)nao");
                        if (Console.Read() == (int)'y')
                        {
                            aceitou = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return pokeEscolhido;

        }



    }
}
