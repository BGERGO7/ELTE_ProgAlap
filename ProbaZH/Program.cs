using System;

namespace ProbaZH
{
    internal class Program
    {
        struct Nap
        {
            public int s;
            public string n;
            public int e;
        }

        private const int MaxDb = 1000;
        
        static void Main(string[] args)
        {
            // deklaracio
            int db = 0;
            Nap[] ny = new Nap[MaxDb];
            bool voltCsokkenoHet;
            int csokkenoHet = 0;

            // beolvasas
            bool error;
            do
            {
                string input = Console.ReadLine();
                error = !Int32.TryParse(input, out db) || db < 7 || db > 1000;
                if (error)
                {
                    Console.WriteLine("HIBAS DB!");
                }
            } while (error);
            
            for (int index = 0; index < db; index++)
            {
                do
                {
                    string[] adatok = Console.ReadLine().Split(' ');
                    
                    error = !Int32.TryParse(adatok[2], out ny[index].e) || ny[index].e < 0;
                    
                    if (error)
                    {
                        Console.WriteLine("HIBAS EGYENLEG!");
                    }
                    else
                    {
                        ny[index].s = Int32.Parse(adatok[0]);
                        ny[index].n = adatok[1];
                        ny[index].e = Int32.Parse(adatok[2]);
                    }
                    
                } while (error);
            }    

            
            int i = 2;
            voltCsokkenoHet = false;
            while (i <= db - 7 && !voltCsokkenoHet)
            {
                int j = i;
                while (j <= i + 6 && ny[j].e < ny[j - 1].e)
                {
                    j++;
                }

                if (j <= i + 6)
                {
                    i++;
                }
                else
                {
                    voltCsokkenoHet = true;
                }
            }

            if (voltCsokkenoHet)
            {
                csokkenoHet = i + 1;
            }

            // kiiras
           
            Console.WriteLine(voltCsokkenoHet ? "IGEN" : "NEM");

            if (voltCsokkenoHet)
            {
                Console.WriteLine("A csokkeno het kezdete (sorszám): " + csokkenoHet);
            }
        }
    }
}