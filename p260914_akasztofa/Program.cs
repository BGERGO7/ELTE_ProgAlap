using System.Net.Mime;

namespace p260914_akasztofa;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Akasztofa");
        
        //deklaracio
        string szo;
        char k;
        string tippeltBetuk = "";

        string[] szavak = {
            // Állatok (20 db)
            "kutya", "macska", "eger", "hal", "madar", "farkas", "roka", "medve", "oroszlan", "tigris",
            "lo", "tehen", "sertes", "kecske", "barany", "csirke", "kacsa", "liba", "pulyka", "nyul",
    
            // Növények, gyümölcsök, ételek (20 db)
            "alma", "barack", "dio", "fa", "virag", "korte", "szilva", "cseresznye", "szolo", "dinnye",
            "repa", "burgonya", "hagyma", "fokhagyma", "paradicsom", "paprika", "uborka", "salata", "kenyer", "sajt",
    
            // Tárgyak, eszközök (20 db)
            "haz", "szek", "asztal", "ablak", "ajto", "toll", "ceruza", "konyv", "fuzet", "taska",
            "kulcs", "ora", "tukor", "lampa", "szonyeg", "pohar", "tanyer", "villa", "kanal", "kes",
    
            // Természet, időjárás, helyek (20 db)
            "nap", "viz", "fold", "tuz", "szel", "eso", "ho", "eg", "felho", "hegy",
            "erdo", "folyo", "to", "tenger", "utca", "ut", "hid", "kert", "park", "udvar",
    
            // Egyéb főnevek és fogalmak (20 db)
            "jatek", "program", "vilag", "zene", "kep", "hang", "szin", "ido", "ev", "honap",
            "nap", "het", "perc", "masodperc", "szo", "mondat", "betu", "szam", "bolt", "penz"
        };
        
        Random random = new Random();
        szo = szavak[random.Next(szavak.Length)];
        
        int db;
        int osszdb;

        const int MAXCHARDB = 26;
        int megvandb = 0;
        char[] megvan = new char[MAXCHARDB];

        int proba = 10;
        
        //szo = "alma";
        
        osszdb = 0;
        
        do
        {
            do
            {
                if (proba <= 0)
                {
                    Console.WriteLine("Nincs tobb probalkozasod");
                    Console.WriteLine("A szo: " + szo );
                    Environment.Exit(1);
                }
                //beolvasas
                Console.Write("Kovetkezo karakter?: ");
                string tmp = Console.ReadLine();
                k = tmp[0];
                proba--;
                tippeltBetuk += k + ", ";
                Console.WriteLine("Eddig tippelt betuk: " + tippeltBetuk);
            } while (megvan.Contains(k));
            
            
            //algoritmus
            db = 0;
            
            for (int i = 0; i < szo.Length; i++)
            {
                if (szo[i] == k)
                {
                    db++;
                }
            }
            //kiiras
            //Console.WriteLine(db);
            Console.WriteLine("Probalkozasok szama: " + proba);
            osszdb += db;
            //Console.WriteLine(osszdb);
            if (db > 0)
            {
                megvan[megvandb] = k;
                megvandb++;
            }

            string eddig = "";
            for (int i = 0; i < szo.Length; i++)
            {
                if (!megvan.Contains(szo[i]))
                {
                    eddig += '_';
                }
                else
                {
                    eddig += szo[i];
                }
            }
            Console.WriteLine(eddig);
        } while (osszdb < szo.Length);

        Console.WriteLine("Gratulalok, kitalaltad!");
        Console.WriteLine("A szo: " + szo );
    }
}