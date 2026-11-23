using System.Xml;

namespace p261123_1;

class Program
{
    
    public struct KiKinek
    {
        public int ki;
        public int kinek;
    }

     const int MaxN = 100;
    static void Main(string[] args)
    {
        int m;
        int n;
        KiKinek[] ajandek = new KiKinek[MaxN];
        
        int db;
        int[] akiknemadtak = new int[MaxN];

        beolvasas(out m, out n, ref ajandek);

        megold(m, n, ref ajandek, out db, ref akiknemadtak);
        
        kiiras(db, akiknemadtak);
    }

    public static void beolvasas(out int m, out int n, ref KiKinek[] ajandek)
    {
        Console.WriteLine("Hany fos a csalad?");
        m = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Hany ajandekozas tortent?");
        n = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Ki adott kinek");
            string[] tmp  = Console.ReadLine().Split(' ');
            ajandek[i].ki = Int32.Parse(tmp[0]);
            ajandek[i].kinek = Int32.Parse(tmp[1]);
        }
    }

    public static void megold(int m, int n, ref KiKinek[] ajandek, out int db, ref int[] akiknemadtak)
    {
        db = 0;
        for (int j = 1; j <= m; j++)
        {
            int i = 0;
            while (i<=n && ajandek[i].ki != j)
            {
                i++;
            }

            if (i >= n)
            {
                db++;
                akiknemadtak[db] = j;
            }
        }
    }

    public static void kiiras(int db, int[] akiknemadtak)
    {
        Console.WriteLine(db+"-n nem adtak ajandekot");
        foreach (var x in akiknemadtak)
        {
            Console.WriteLine(x);
        }
    }
}