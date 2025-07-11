using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEntre le lien de l'avis Google (ou tape 'exit' pour quitter) :");
            Console.ResetColor();

            string url = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine("❌ Lien invalide.");
                continue;
            }

            if (url.ToLower() == "exit")
            {
                Console.WriteLine("Exit");
                break;
            }

            bool isOnline = await CheckIfOnline(url);

            if (isOnline)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Parfait ! L avis est EN LIGNE.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nonnnnn ! L avis est HORS LIGNE ou le lien est invalide.");
            }

            Console.ResetColor();
        }
    }

    static async Task<bool> CheckIfOnline(string url)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                HttpResponseMessage response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
        }
        catch
        {
            return false;
        }
    }
}
