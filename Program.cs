using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class Kulcstalalo
{
    public  static string uzenet1;
    public static string uzenet2;
    public static string elsoval;
    public static string kulcsreszlet;
    public static string uzenetreszlet;
    public static string kulcsreszlet2 = "";
    public static string wordListPath = "words.txt";
    public static string uzenetkieg = "";
    public static string uzenet1reszletfejt = "";
    public static string szotaras;
    public static string feltet;
    public static string kulcstovabb;
    List<string> wordList = Fajltoltes(wordListPath);
    public static List<string> karakterek = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };

   
    private static string kulcsreszletmegoldas(string uzenet1, string elsoval, List<string> karakterek)
    {
       
        string kulcsreszlet = "";
        int m = 0;
        int kul = 0;
        int masodik = 0;
        for (int i = 0; i < elsoval.Length; i++)
        {
            int j = 0;
            while (Convert.ToString(elsoval[i]) != karakterek[j])
            {
                j++;
                
            }
            int elso = j;

            for (int k = m; k < (m + 1); k++)
            {
                int l = 0;
                while (Convert.ToString(uzenet1[k]) != karakterek[l])
                {
                    l++;
                }
                
                masodik = l;

            }
            m++;
            kul = (masodik - elso);
           
            kulcsreszlet = kulcsreszlet + karakterek[(kul + 27) % 27];

        }
        return kulcsreszlet;

    }
    private static string kulcsreszletmegoldas2(string uzenet2, string uzenetkieg, List<string> karakterek)
    {
       
        int m = kulcsreszlet.Length;
        int kul = 0;
        int masodik = 0;
        for (int i = 0; i < uzenetkieg.Length; i++)
        {
            int j = 0;
            while (Convert.ToString(uzenetkieg[i]) != karakterek[j])
            {
                j++;

            }
            int elso = j;

            for (int k = m; k < (m + 1); k++)
            {
                int l = 0;
                while (Convert.ToString(uzenet2[k]) != karakterek[l])
                {
                    l++;
                }

                masodik = l;

            }
            m++;
            kul = (masodik - elso);

            kulcsreszlet2 = kulcsreszlet2 + karakterek[(kul + 27) % 27];
            
        }
        return kulcsreszlet2;

    }
    private static string uzenetreszletmegoldas(string uzenet1, string elsoval , string kulcsreszlet, List<string> karakterek)
    {
       
        string uzenet2reszletmegoldas = "";
        int m = 0;
        int kul = 0;
        int masodik = 0;
        kulcsreszlet = kulcsreszletmegoldas(uzenet1, elsoval, karakterek);
        for (int i = 0; i < kulcsreszlet.Length; i++)
        {
            int j = 0;
            while (Convert.ToString(kulcsreszlet[i]) != karakterek[j])
            {
                j++;
                if (karakterek.Contains(Convert.ToString(kulcsreszlet[i])) == false) throw new ArgumentException("Próbálja az angol abc kiskarakteres betűivel");
            }
            int elso = j;

            for (int k = m; k < (m + 1); k++)
            {
                int l = 0;
                while (Convert.ToString(uzenet2[k]) != karakterek[l])
                {
                    l++;
                }

                masodik = l;

            }
            m++;
            kul = (masodik - elso);
            uzenet2reszletmegoldas = uzenet2reszletmegoldas + karakterek[(kul + 27) % 27];

        }
        
        return uzenet2reszletmegoldas;

    }
    private static string uzenetreszletmegoldas2(string uzenet1, string feltet, string kulcstovabb, List<string> karakterek)
    {

        string uzenetreszletmegoldas2 = "";
        int m = 0;
        int kul = 0;
        int masodik = 0;
        for (int i = 0; i < kulcstovabb.Length; i++)
        {
            int j = 0;
            while (Convert.ToString(kulcstovabb[i]) != karakterek[j])
            {
                j++;
                
            }
            int elso = j;

            for (int k = m; k < (m + 1); k++)
            {
                int l = 0;
                while (Convert.ToString(uzenet1[k]) != karakterek[l])
                {
                    l++;
                }

                masodik = l;

            }
            m++;
            kul = (masodik - elso);
            uzenetreszletmegoldas2 = uzenetreszletmegoldas2 + karakterek[(kul + 27) % 27];

        }
        
        return uzenetreszletmegoldas2;
        
    }


    private static List<string> Fajltoltes(string filePath)
    {
        return File.ReadAllLines(filePath).ToList();
    }
 
    public static List<string> FindKey(string uzenet2reszletmegoldas, string uzenet2, string uzenet1, string elsoval, List<string> wordList)
    {
        
        List<string> lehetkulcs = new List<string>();
        List<string> karakterek = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
        
            uzenet2reszletmegoldas = uzenetreszletmegoldas(uzenet1, elsoval, kulcsreszletmegoldas(uzenet1, elsoval, karakterek), karakterek);

        if (uzenet2reszletmegoldas.Contains(" ") == false)
        {
            foreach (string word in wordList)
            {
                if (word.Contains(uzenet2reszletmegoldas))
                {
                    Console.WriteLine("Szótár szerint lehetséges:");
                    Console.WriteLine(word);
                }


            }
        }
        else
        {
            Console.WriteLine("Adja meg az eddig sikeresen eltalált részt:");
            string bekert = Console.ReadLine();
            string szotaras = uzenet2reszletmegoldas.Substring((bekert.Length + 1), uzenet2reszletmegoldas.Length - (bekert.Length + 1));
            foreach (string word in wordList)
            {
                if (word.StartsWith(szotaras))
                {
                    Console.WriteLine("Szótár szerint lehetséges:");
                    Console.WriteLine(word);
                }


            }
        }

        Console.WriteLine("Adja meg a szóból a szótár alapján hiányzó karaktereket:");
            uzenetkieg = Console.ReadLine();
        kulcstovabb = kulcsreszlet + kulcsreszletmegoldas2(uzenet2, uzenetkieg, karakterek);
         feltet = uzenet2reszletmegoldas + uzenetkieg;
           
            string kulcsresz = kulcstovabb;
            uzenet1reszletfejt = uzenetreszletmegoldas2(uzenet1, feltet, kulcstovabb, karakterek);
      
        Console.WriteLine(uzenet1reszletfejt);
        
        lehetkulcs.Add(kulcsresz);
        
            return lehetkulcs;
        
    }
    
    public static void Main(string[] args)
    {
        
        
        Console.WriteLine("Adja meg a két kódolt üzenetet:");
        uzenet1 = Console.ReadLine();
        uzenet2 = Console.ReadLine();
        List<string> karakterek = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
        string wordListPath = "words.txt";
        List<string> wordList = Fajltoltes(wordListPath);
        
        Console.WriteLine("Adja meg a feltételezetten ismert részletet:");
        elsoval = Console.ReadLine();
        Console.WriteLine("Kulcsrészlet:");
        kulcsreszlet = kulcsreszletmegoldas(uzenet1, elsoval, karakterek);
        Console.WriteLine(kulcsreszlet);
        uzenetreszlet = uzenetreszletmegoldas(uzenet1, elsoval, kulcsreszlet, karakterek);
        Console.WriteLine("Üzenetrészlet:");
        Console.WriteLine(uzenetreszlet);
        List<string> lehetkulcs = FindKey(uzenetreszlet, uzenet2, uzenet1, elsoval, wordList);
       

        foreach (string kulcsresz in lehetkulcs)
        {
          Console.WriteLine("Lehetséges kulcs: " + kulcsresz);
        }
       
         Console.WriteLine("Amennyiben nincs meg valamelyik üzenet teljes kódja futassa újra a programot a szerzett információval.");


    }


}
