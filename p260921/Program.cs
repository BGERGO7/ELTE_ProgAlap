using System.Globalization;
using System.Xml;

namespace p260921;

class Program
{ 
    struct KartyaErtek
    {
        public string fig;
        public int ert;
    }
    
    const int db = 8;
    static readonly KartyaErtek[] pakli =
    {
        new KartyaErtek { fig = "7", ert = 7 },
        new KartyaErtek { fig = "8", ert = 8 },
        new KartyaErtek{fig = "9", ert = 9},
        new KartyaErtek{fig = "t", ert = 10},
        new KartyaErtek{fig = "a", ert = 2},
        new KartyaErtek{fig = "f", ert = 3},
        new KartyaErtek{fig = "k", ert = 4},
        new KartyaErtek{fig = "A", ert = 11}
    };
    
    static void Main(string[] args)
    {
        Console.WriteLine("Blackjack");
        
        // 1. oszto 1. lapja
        Random osztoRnd = new Random();
        int osztoKartyaErtek = osztoRnd.Next(db);
        int osztoOssz = osztoKartyaErtek;
        string osztoKartya = pakli[osztoKartyaErtek].fig;
        Console.WriteLine("Az oszto elso kartyaja: " + osztoKartya);
        
        // 2. jatekos
        string kartya;
        int ertek = 0;
        string valasz;
        
        do
        {
            Random rnd = new Random();
            int kartyaRandom = rnd.Next(db);
            
            kartya = pakli[kartyaRandom].fig;
            
            Console.WriteLine("A kartyad: " + kartya);
            
            int i = 0;
            while (kartya != pakli[i].fig)
            {
                i++;
            }

            ertek = ertek + pakli[i].ert;
            
            Console.WriteLine("Osszeg: " + ertek);
            if (ertek > 21)
            {
                Console.WriteLine("Tul sok!");
                System.Environment.Exit(0);
            }
            do
            {
                Console.Write("Huzol meg? (i/n) ");
                valasz = Console.ReadLine();
            } while (valasz != "i" && valasz != "n");
        } while (valasz != "n");

        // 3. oszto jatszik
        do
        {
            osztoKartyaErtek = osztoRnd.Next(db);
            osztoKartya = pakli[osztoKartyaErtek].fig;
            Console.WriteLine("Oszto huz: " + osztoKartya);
            osztoOssz = osztoOssz + osztoKartyaErtek;
            Console.WriteLine("Oszto ertek: " + osztoOssz);
            if (osztoOssz > 21)
            {
                Console.WriteLine("Tul sok!");
                Console.WriteLine("Nyertel!");
                System.Environment.Exit(0);
            }
        } while (osztoOssz < 17);
        
        // 4. osszehasonlitas

        if (osztoOssz > ertek)
        {
            Console.WriteLine("Vesztettel");
        }
        else if(osztoOssz < ertek)
        {
            Console.WriteLine("Nyertel!");
        }
        else
        {
            Console.WriteLine("Dontetlen");
        }
    }
}