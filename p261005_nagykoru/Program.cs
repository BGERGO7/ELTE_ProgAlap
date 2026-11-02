namespace p261005_nagykoru;

class Program
{

    struct Tanulo
    {
        public int szulido;
        public string nev;
    }

    private const int MaxN = 100;

    static void Beolvasas(out int n, ref Tanulo[] t, out int ma)
    {
        bool hiba = false;

        do
        {
            Console.Error.WriteLine("N: ");
            //n = Int32.Parse(Console.ReadLine());
            hiba = (!Int32.TryParse(Console.ReadLine(), out n) || n < 0 || MaxN < n);
            if (hiba)
            {
                Console.Error.WriteLine("HIBA! 1 es " + MaxN + " kozotti szam kell!");
            }

        } while (hiba);
        
        for (int j = 0; j < n; j++)
        {
            hiba = false;
            do
            {
                Console.Error.WriteLine(j + 1 + ". tanulo");
                /* SPLIT * /
                string[] tmp = Console.ReadLine().Split(' ');
                t[j].szulido = Int32.Parse(tmp[0]);
                t[j].nev = tmp[1];
                hiba = (!Int32.TryParse(tmp[0], out t[j].szulido) || t[j].szulido < 0);
                if (hiba)
                {
                    Console.Error.WriteLine("HIBA! 0 nal nahubb szam kell!");
                }
                /* */
                /*IndexOf + SUBSTRING*/
                string tmp = Console.ReadLine();
                int pos = tmp.IndexOf(" ");
                //Console.Error.WriteLine("#"+tmp.Substring(0, pos) + "#");
                hiba = (!Int32.TryParse(tmp.Substring(0, pos), out t[j].szulido) || t[j].szulido < 0);
                if (hiba)
                {
                    Console.Error.WriteLine("HIBA! 0 nal nahubb szam kell!");
                }
                tmp = tmp.Substring(pos + 1);
                //Console.Error.WriteLine("#"+tmp+ "#");
                t[j].nev = tmp;
                
                /* */
                
            } while (hiba);
        }
        
        hiba = false;

        do
        {
            Console.Error.WriteLine("Ma: ");
            //ma = Int32.Parse(Console.ReadLine());
            hiba = (!Int32.TryParse(Console.ReadLine(), out ma) || ma < 0);
            if (hiba)
            {
                Console.Error.WriteLine("HIBA! 0 nal nagyobb szam kell!");
            }

        } while (hiba);
    }

    static void Megold(int n,ref Tanulo[] t,int ma, out bool van)
    {
        int i = 0;

        while ((i < n) && (ma - t[i].szulido <= 6574))
        {
            i++;
        }
        
        van = (i < n);
    }

    static void Kiiras(bool van)
    {
        Console.WriteLine(van ? "VAN" : "NINCS");
    }
    
    static void Main(string[] args)
    {
        
        // https://progalap.elte.hu/specifikacio/v1/?uuid=065afb13-5be6-478f-ae28-fafb3b03664e
        // https://progalap.elte.hu/stuki/v1/?uuid=f5f82e62-e62c-4249-a732-c386eacc20e9
        // https://progenv.inf.elte.hu/hu/tasks/157
        Console.Error.WriteLine("Nagykoru");
        
        //deklaracio
        int n;
        Tanulo[] t = new Tanulo[MaxN];
        int ma;

        bool van;

        //beolvasas
        Beolvasas(out n, ref t, out ma);
        
        // algoritmus
        Megold(n,ref t,ma, out van);
        
        //kiiras
        Kiiras(van);
        
    }
}