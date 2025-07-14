using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AvisTester;

class Program
{

    static string ala = forWeb.Getweb();

    static int b = for3.seconde();


    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEntre le lien de l avis Google (ou tape 'exit' pour quitter) :");
            string url = Console.ReadLine();

            Console.ResetColor();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" ");
            }

            if (string.IsNullOrWhiteSpace(url) || !url.Contains("maps.app.goo.gl"))
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Lien invalide.");
                Console.ResetColor();
                break;
            }

            if (url.ToLower() == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exit");
                Console.ResetColor();
                break;
            }

            while (2 > 1) {

            string forS = b.ToString();

            bool isonline = await CheckIfOnline(url);

            if (isonline && url!= null && url.Contains("maps.app.goo.gl") &&  ala != null)
            {

                    for (int i2 = 0; i2 < 5; i2++)
                    {
                    Console.WriteLine(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Parfait ! L avis est EN LIGNE.");
                    await SendDiscordWebhook(url, true, ala);
                    await Task.Delay(b);
            }
            else
            {
                    for (int i2 = 0; i2 < 5; i2++)
                    {
                        Console.WriteLine(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nonnnnn ! L avis est HORS LIGNE ou le lien est invalide.");
                    await SendDiscordWebhook(url, false, ala);
                    await Task.Delay(b);

                break;
                }

            Console.ResetColor();

            }
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


    static async Task SendDiscordWebhook(string url, bool isOnline, string webhook)
    {
        using (HttpClient client = new HttpClient())
        {
            var content = new
            {
                username = "Avis Checker Bot [Askov]",
                embeds = new[]
                {
                    new {
                        title = "Verif avis Google",
                        description = $"Lien : {url}",
                        color = isOnline ? 0x00FF00 : 0xFF0000,
                        fields = new[]
                        {
                            new { name = "Statut", value = isOnline ? "✅ EN LIGNE" : "❌ HORS LIGNE", inline = true },
                            new { name = "Date", value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), inline = true },
                            new { name = "Contact", value = ("Discord : ask0v_"), inline = true }
                            
                        }
                    }
                }
            };

            string json = JsonSerializer.Serialize(content);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(ala, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Erreur en envoyant le webhook Discord.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Rentre un webhook valide ou contact ask0v_ sur discord");
                
            }

        }
    }


}
