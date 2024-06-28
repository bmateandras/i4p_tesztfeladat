using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace Tesztfeladat_1
{
    public class Program
    {
        public List<string> karakterek = new List<string>{ "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
        public string uzenet = Console.ReadLine();
        public string kulcs = Console.ReadLine();

        public static string rejtjelezett(string uzenet, string kulcs, List<string> karakterek)
        {
            string rejtjelezett = "";
            int ossz = 0;
            int masodik = 0;
            int m = 0;
            int i = 0;

            for (i = 0; i < uzenet.Length; i++)
            {
                int j = 0;
                
                while (Convert.ToString(uzenet[i]) != karakterek[j])
                {
                    j++;
                    if (karakterek.Contains(Convert.ToString(uzenet[i])) == false ) throw new ArgumentException("Próbálja az angol abc kiskarakteres betűivel");
                }
               
                int elso = j;

                for (int k = m; k < (m + 1); k++)
                {
                    int l = 0;
                    while (Convert.ToString(kulcs[k]) != karakterek[l])
                    {
                        l++;
                    }
                    if (uzenet.Length > kulcs.Length) throw new ArgumentException("A kulcs legyen legalább olyan hosszú mint az üzenet.");
                    masodik = l;

                }
                m++;
                ossz = (elso + masodik);
                rejtjelezett = rejtjelezett + karakterek[(ossz + 27) % 27];
                
               
            }
           
            return rejtjelezett;
            

        }
        


        public static string megoldas(string rejtjelezett, string kulcs, List<string> karakterek)
        {
            string megoldas = "";
            int m = 0;
            int kul = 0;
            int masodik = 0;
            for (int i = 0; i < rejtjelezett.Length; i++)
            {
                int j = 0;
                while (Convert.ToString(rejtjelezett[i]) != karakterek[j])
                {
                    j++;
                    if (karakterek.Contains(Convert.ToString(rejtjelezett[i])) == false) throw new ArgumentException("Próbálja az angol abc kiskarakteres betűivel");
                }
                int elso = j;

                for (int k = m; k < (m + 1); k++)
                {
                    int l = 0;
                    while (Convert.ToString(kulcs[k]) != karakterek[l])
                    {
                        l++;
                    }
                    if (rejtjelezett.Length > kulcs.Length) throw new ArgumentException("A kulcs legyen legalább olyan hosszú mint az üzenet.");
                    masodik = l;

                }
                m++;
                kul = (elso - masodik);
                megoldas = megoldas + karakterek[(kul + 27) % 27];
                

            }
            return megoldas;

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a kódolandó üzenetet:");
            string uzenet = Console.ReadLine();
            Console.WriteLine("Adja meg a kódolandó üzenethez a kulcsot:");
            string kulcs = Console.ReadLine();
            List<string> karakterek = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
            Console.WriteLine("A rejtjelezett üzenet:");
            Console.WriteLine(rejtjelezett(uzenet, kulcs, karakterek));
            Console.WriteLine("Adja meg a megoldandó üzenetet:");
            string kodolt = Console.ReadLine();
            Console.WriteLine("Adja meg a megoldandó üzenet kulcsát:");
            string kulcs2 = Console.ReadLine();
            Console.WriteLine("A megoldott üzenet:");
            Console.WriteLine(megoldas(kodolt, kulcs2, karakterek));
            
        }

    }
}
    

