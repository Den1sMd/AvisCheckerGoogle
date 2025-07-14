using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisTester
{
    public static class forWeb
    {
        public static string Getweb()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Rentre ton webhook");
            string webhook = Console.ReadLine();
            Console.ResetColor();

            for (int i2 = 0; i2 < 5; i2++)
            {
                Console.WriteLine(" ");
            }

            if (webhook == null || !webhook.Contains("discord.com/api/webhooks/")) {
                Console.WriteLine("Mauvais webhook");

                for (int i2 = 0; i2 < 5; i2++)
                {
                    Console.WriteLine(" ");
                }

                return null;
                
            }
            else
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    Console.WriteLine(" ");
                }

                return webhook;
            }

            
        }
    }
}
