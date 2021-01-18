using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Seed.Model;

namespace VerusDate.Seed
{
    public static class Utils
    {
        public static string baseapi => "http://localhost:7071/api/";

        public static JsonSerializerOptions GetOptions()
        {
            return new JsonSerializerOptions();
        }
    }

    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var http = new HttpClient();

            Thread.Sleep(1000);

            //var profiles = ProfileSeed.GetProfile(null, true, true, true, true, true).Generate(10);
            //int count = 0;

            //foreach (var item in profiles)
            //{
            //    await http.PostAsJsonAsync(Utils.baseapi + "Profile/Add?enable_seed=true", item, Utils.GetOptions());

            //    count++;
            //    Console.WriteLine("Usuário criado: " + count);
            //}

            var eventos = EventSeed.GetEventVM().Generate(5);
            int count = 0;

            foreach (var item in eventos)
            {
                await http.PostAsJsonAsync(Utils.baseapi + "Event/Add", item, Utils.GetOptions());

                count++;
                Console.WriteLine("Evento criado: " + count);
            }
        }
    }
}