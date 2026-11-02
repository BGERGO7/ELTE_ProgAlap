namespace p20261012;

class Program
{
    const int maxDbH = 100;

    struct Hely
    {
        public string n;
        public int dba;
        public string[] ak;
    }

    static void beolvas(out int dbh, ref Hely[] h)
    {
        Console.Write("Hany helyen voltal? ");
        dbh = int.Parse(Console.ReadLine());
        for (int i = 0; i < dbh; i++)
        {
            Console.WriteLine("A(z) " + (i + 1) +". hely adatai");
            Console.Write("A helyszin neve: ");
            h[i].n = Console.ReadLine();
            Console.Write("A helyszinen levo allatok szama: ");
            h[i].dba = int.Parse(Console.ReadLine());
            Console.Write("A helyszinen levo allatok: ");
            h[i].ak = Console.ReadLine().Split(',');
        }
    }

    static int osszAllat(int dbh, Hely[] h)
    {
        int osszA = 0;
        for (int i = 0; i < dbh; i++)
        {
            osszA += h[i].dba;
        }

        return osszA;
    }

    static bool vanKacsaFgv(int dbh, Hely[] h)
    {
        int i = 0;
        while (i < dbh && !vanMiHol("kacsa", h[i]))
        {
            i++;
        }
        return i < dbh;
    }

    static int hanyHelyenMajomFgv(int dbh, Hely[] h)
    {
        int db = 0;
        for (int i = 0; i < dbh; i++)
        {
            if (vanMiHol("majom", h[i]))
            {
                db++;
            }
        }
        
        return db;
    }

    static bool vanMiHol(string mi, Hely hol)
    {
        int j = 0;
        while (j < hol.dba && hol.ak[j] != mi)
        {
            j++;
        }
        return j < hol.dba;
    }

    static void kiir(int osszA, bool vanKacsa, int hanyHelyenMajom)
    {
        Console.WriteLine("Osszes allat szama: " + osszA);
        Console.WriteLine("Van-e kacsa valahol: " + (vanKacsa ? "IGEN" : "NEM"));
        Console.WriteLine("Hany helyen van majom: " + hanyHelyenMajom);
    }
    
    static void Main(string[] args)
    {
        //deklaraciio
        int dbh;
        Hely[] h = new Hely[maxDbH];

        //beolvasas
        beolvas(out dbh, ref h);
        
        //algoritmus
        int osszA = osszAllat(dbh, h);
        bool vanKacsa = vanKacsaFgv(dbh, h);
        int hanyHelyenMajom = hanyHelyenMajomFgv(dbh, h);
        
        //kiiras
        kiir(osszA, vanKacsa, hanyHelyenMajom);
    }
}