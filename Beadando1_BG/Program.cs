// Bükki Gergely
// C706RO
// c706ro@inf.elte.hu

namespace Beadando1_BG;

class Program
{
    struct Tavolsag
    {
        public int k;
        public int p;
    }

    const int maxN = 100;

    static void beolvas(out int n, ref Tavolsag[] t)
    {
        Console.Error.Write("Telepulesek szama: ");
        n = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Error.WriteLine("A(z) " + (i+1) +". telepules adatai: ");
            string[] tmp = Console.ReadLine().Split(" ");
            t[i].k = Int32.Parse(tmp[0]);
            t[i].p = Int32.Parse(tmp[1]);
        }
    }
    
    static void Main(string[] args)
    {
        // deklaracio
        int n;
        Tavolsag[] t = new Tavolsag[maxN];
        int s;
        
        // beolvasas
        beolvas(out n, ref t);

        // algoritmus
        s = 0;
        for (int i = 1; i < n; i++)
        {
            if (t[i].k > t[s].k)
            {
                s = i;
            }
        }

        // kiiras
        Console.Error.WriteLine("A telepules sorszama:");
        Console.WriteLine(s+1);
    }
}