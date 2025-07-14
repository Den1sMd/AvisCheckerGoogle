using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisTester
{
    public static class for3
    {
        public static int seconde()
        {
            Console.WriteLine("Toutes les combien de secondes veux-tu que la vérification soit effectuée ? (Saisis une valeur en secondes)");

            string forseconde = Console.ReadLine();

            int RealSec;

            if (int.TryParse(forseconde, out RealSec))
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    Console.WriteLine(" ");
                }


                return RealSec * 1000;
            }

            else
            {
                return 0;
            }


        }
    }
}
