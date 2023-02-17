using AplicativoPokemon.Pokemon;
using RestSharp;
using System.Text.Json;
using System.Web;
internal class Program
{
    private static void Main(string[] args)
    {
        Pokemon seuPokemon = EscolherPokemon();
        Console.Clear();
        Console.WriteLine("Seu Pokemon Escolhido foi: ");
        Console.WriteLine(seuPokemon.ToString());



        Console.ReadKey();
        
    }

    private static Pokemon EscolherPokemon()
    {
        Pokemon pokeEscolhido = null;
        bool aceitou = false;
        while (!aceitou)
        {
            Console.Clear();
            Console.WriteLine($"Boas vindas ao Tamagochi Pokemon!\n" +
                              $"Digite o numero do pokemon que deseja cuidar: \n" +
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
                Console.WriteLine("Deseja confirmar a escolha desse pokemon? (y)sim (n)nao");
                if (Console.Read() == (int)'y')
                {
                    aceitou = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return pokeEscolhido;
        
    }
    private static Pokemon FazerRequisicao(string URL)
    {
        var client = new RestClient(URL);
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);
        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {

            Pokemon poke = JsonSerializer.Deserialize<Pokemon>(response.Content);
            return poke;

        }
        else
        {
            throw new Exception(response.ErrorMessage);
        }
    }
}