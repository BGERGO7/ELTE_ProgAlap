using System.Globalization;

namespace p261117_Szaloncukor;

class Program
{
    const int MaxN = 1000;
    
    static void Main(string[] args)
    {
        int dbgy;
        int dbf;
        string[] gyartok = new string[MaxN];
        string[] fajtak = new string[MaxN];
        int[,] arak = new  int[MaxN, MaxN];
        int[] gyartoFele = new int[MaxN];
        int[] fajtaDarab = new int[MaxN];


        beolvas(out dbgy, out dbf, ref gyartok, ref fajtak, ref arak, ref gyartoFele, ref fajtaDarab);

        megold_1(dbgy, dbf,ref arak,  ref gyartok, ref fajtak);
        megold_2(dbf, ref fajtak, ref fajtaDarab);
        megold_3(dbf, ref fajtak);
        megold_4(dbgy, ref gyartok, ref gyartoFele);
        megold_5(dbgy, dbf, ref arak, ref gyartok);
        
        //kiir();
    }

    static void beolvas(out int dbgy, out int dbf, ref string[] gyartok, ref string[] fajtak, ref int[,] arak,
        ref int[] gyartoFele, ref int[] fajtaDarab)
    {
        dbgy = 0;
        dbf = 0;
        Console.Error.Write("N=? : ");
        int n = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Error.Write("gyarto=? : ");
            string gy = Console.ReadLine();
            Console.Error.Write("fajta=? : ");
            string f = Console.ReadLine();
            Console.Error.Write("ar=? : ");
            int ar = Int32.Parse(Console.ReadLine());
            int gyi;
            int fi;
            if (!kereses(gy, dbgy, ref gyartok, out gyi))
            {
                dbgy++;
            }

            if (!kereses(f, dbf, ref fajtak, out fi))
            {
                dbf++;
            }
            
            
            fajtak[fi] = f;
            gyartok[gyi] = gy;
            arak[gyi, fi] = ar;
            gyartoFele[gyi]++;
            fajtaDarab[fi]++;
        }
        
        /*DUMP*/
        Console.Error.Write(dbgy+"\t"+dbf);
        Console.Error.WriteLine();
        for (int i = 0; i < dbf; i++)
        {
            Console.Error.Write("\t" + fajtak[i]+ "/"+fajtaDarab[i]);
            
        }

        Console.Error.WriteLine();
        for (int i = 0; i < dbgy; i++)
        {
            Console.Error.Write("\t" + gyartok[i]+ "/"+gyartoFele[i]);
            for (int j = 0; i < dbf; j++)
            {
                Console.Error.Write("\t" + arak[i, j]);
            }

            Console.Error.WriteLine();
        }
        /**/
    }
    
    static bool kereses(string a ,int db, ref string[] x, out int ind)
    {
        ind = 0;
        while ((ind < db) && (a!=x[ind]))
        {
            ind++;
        }
        
        return (ind>=db);
    }

    static void megold_1(int dbgy, int dbf, ref int[,] arak, ref string[] gyartok, ref string[] fajtak)
    {
        int mini = -1;
        int minj = -1;
        int minAr = 20001;
        for (int i = 0; i < dbgy; i++)
        {
            for (int j = 0; j < dbf; j++)
            {
                if (minAr>arak[i, j])
                {
                    minAr = arak[i, j];
                    mini = i;
                    minj = j;
                }
            }
        }
        Console.Out.WriteLine("#");
        Console.WriteLine(fajtak[minj] + " " + gyartok[mini]);
    }

    static void megold_2(int dbf, ref string[] fajtak, ref int[] fajtaDarab)
    {
        int ind = 0;
        while ((ind < dbf) && (fajtaDarab[ind] == 1))
        {
            ind++;
        }

        bool van = (ind < dbf);
        Console.WriteLine("#");
        Console.WriteLine(van ? fajtak[ind] : "NINCS");
    }

    static void megold_3(int dbf, ref string[] fajtak)
    {
        Console.WriteLine("#");
        Console.WriteLine(dbf);
        for (int i = 0; i < dbf; i++)
        {
            Console.WriteLine(fajtak[i]);
        }
    }

    static void megold_4(int dbgy, ref string[] gyartok, ref int[] gyartoFele)
    {
        int maxi = 0;
        for (int i = 1; i < dbgy; i++)
        {
            if (gyartoFele[i] > gyartoFele[maxi])
            {
                maxi = i;
            }
        }
        Console.WriteLine("#");
    }
    static void megold_5(int dbgy, int dbf, ref int[,] arak, ref string[] gyartok)
    {
        int ind = 0;
        while ((ind < dbgy) && (!mindentOlcson(ind, dbgy, dbf, ref arak)))
        {
            ind++;
        }

        bool van = (ind < dbgy);
        Console.WriteLine("#");
        Console.WriteLine(van ? gyartok[ind] : "NINCS");
    }

    static bool mindentOlcson(int ind, int dbgy, int dbf, ref int[,] arak)
    {
        int j = 0;
        while ((j<dbf) && ((arak[ind, j]==0) || vanNalaDragabb(ind,dbgy,j, arak)))
        {
            j++;
        }
        return (j>=dbf);
    }

    static bool vanNalaDragabb(int ind, int dbgy, int j, int[,] arak)
    {

        int i = 0;
        while ((i<dbgy) && ((arak[i,j]==0 || (ind==i) || (arak[i,j] >= arak[ind, j]))))
        {
            i++;
        }
        return (i<dbgy);
    }
}