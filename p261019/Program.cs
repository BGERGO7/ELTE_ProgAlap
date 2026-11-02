namespace p261019;

class Program
{
    const int MaxN = 100;
    const int MaxV = 100;

    static void Main(string[] args)
    {
        //https://progalap.elte.hu/specifikacio/v1/?uuid=8a897066-e9da-489c-be12-908ef63afc3c
        //https://progalap.elte.hu/stuki/v1/?uuid=2e50f97c-e537-45b5-9189-9aedf9bf46ec
        Console.WriteLine("matrix proba");

        int dbn;
        int dbv;
        int[,] p = new int[MaxN, MaxV];

        int[] napiMinErt = new int[MaxN];
        int[] napiMinVersenyzo = new int[MaxN];
        int[] osszPontok = new int[MaxV];

        int maxPontos;
        int dbKik;
        int[] kik = new int[MaxV];
        bool van0;
        int nap0;
        int minn;
        int minv;
        
        beolvas(out dbn, out dbv, ref p);
        
        napi(dbn, dbv, ref p, ref napiMinErt, ref napiMinVersenyzo);
        dump("napiMinErt", dbn, ref napiMinErt);
        dump("napiMinVersenyzo", dbn, ref napiMinVersenyzo);
        versenyzo(dbn, dbv, ref p, ref osszPontok);
        dump("osszPontok", dbn, ref osszPontok);
        maxPontos = maximumKivalasztas(dbv, osszPontok);
        kivalogatas(dbv, ref osszPontok, out dbKik, ref kik);
        van0 = kereses(dbn, napiMinErt, out nap0);
        minimumKivalasztas(dbn, ref napiMinErt, napiMinVersenyzo, out minn, out minv);
        
        kiir(maxPontos, dbKik, ref kik, van0, nap0, minn, minv);
    }
    
    static void beolvas(out int dbn, out int dbv, ref int[,] p)
    {
        Console.Write("#napi #versenyzo?: ");
        string[] tmp = Console.ReadLine().Split('\t');
        dbn = Int32.Parse(tmp[0]);
        dbv = Int32.Parse(tmp[1]);

        for (int i = 0; i < dbn; i++)
        {
            Console.WriteLine((i) + ". napon a versenyzok pontjai");
            string[] sor = Console.ReadLine().Split('\t');
            for (int j = 0; j < dbv; j++)
            {
                p[i, j] = Int32.Parse(sor[j]);
            }
        }
    }

    static void napi(int dbn, int dbv, ref int[,] p, ref int[] napiMinErt, ref int[] napiMinVersenyzo)
    {
        for (int i = 0; i < dbn; i++)
        {
            int min = 0;
            for (int j = 1; j < dbv; j++)
            {
                if (p[i, j] < p[i, min])
                {
                    min = j;
                }
            } 
            napiMinErt[i] = p[i, min];
            napiMinVersenyzo[i] = min + 1;
        }
    }

    static void versenyzo(int dbn, int dbv, ref int[,] p, ref int[] osszPontok)
    {
        for (int j = 0; j < dbv; j++)
        {
            osszPontok[j] = 0;
            for (int i = 0; i < dbn; i++)
            {
                osszPontok[j] += p[i, j];
            }
        }
    }

    static int maximumKivalasztas(int dbv, int[] osszPontok)
    {
        int maxPontos = 0;
        for (int j = 1; j < dbv; j++)
        {
            if (osszPontok[j] > osszPontok[maxPontos])
            {
                maxPontos = j;
            }
        }
        return (maxPontos + 1);
    }

    static void kivalogatas(int dbv, ref int[] osszPontok, out int dbKik, ref int[] kik)
    {
        dbKik = 0;
        for (int j = 0; j < dbv; j++)
        {
            if (osszPontok[j] > 20)
            {
                kik[dbKik] = j + 1;
                dbKik++;
            }
        }
    }

    static void minimumKivalasztas(int dbn, ref int[] napiMinErt, int[] napiMinVersenyzo, out int minn, out int minv)
    {
        minn = 0;
        for (int i = 1; i < dbn; i++)
        {
            if (napiMinErt[i] < napiMinErt[minn])
            {
                minn = i;
            }
        }

        minv = napiMinVersenyzo[minn];
        minn++;
    }

    static bool kereses(int dbn, int[] napiMinErt, out int nap0)
    {
        nap0 = 0;
        while (nap0 < dbn && napiMinErt[nap0] != 0)
        {
            nap0++;
        }

        bool l = nap0 < dbn;
        nap0++;

        return l;
    }

    static void dump(string cim, int db, ref int[] tomb)
    {
        Console.WriteLine(cim + " (" + db + ")");
        for (int i = 0; i < db; i++)
        {
            Console.Write(" " + tomb[i]);
        }

        Console.WriteLine();
    }

    static void kiir(int maxPontos, int dbKik, ref int[] kik, bool van0, int nap0, int minn, int minv)
    {
        Console.WriteLine("Ki szerezte a legtobb pontot osszesen: " + maxPontos);
        Console.WriteLine("Kik szereztek legalbb 20 pontot: "+ dbKik);
        for (int i = 0; i < dbKik; i++)
        {
            Console.WriteLine(" " + kik[i]);
        }
        Console.WriteLine(van0 ? "VAN: " + nap0 : "NINCS");
        Console.WriteLine(minn + " " + minv);
    }
}