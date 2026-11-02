namespace Hazi4;

class Program
{
    const int MaxN = 100;
    
    const int MaxB = 1000000;
    
    static void Main(string[] args)
    {
        
        //https://progenv.inf.elte.hu/hu/tasks/56
        Console.Error.WriteLine("Napok szama");

        //deklaracio
        int n;
        int[] b = new int[MaxB];

        int e;
        
        //beolvasas
        bool error = false;
        do
        {
            Console.Error.Write("N: ");
            error = (!Int32.TryParse(Console.ReadLine(), out n) || n < 1 || n > MaxN);
            if (error)
            {
                Console.Error.WriteLine("HIBA! 0 es " + MaxN + " kozotti szam kell");
            }

        } while (error);
        
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Error.Write((i+1) + ". nap: ");
                error = (!Int32.TryParse(Console.ReadLine(), out b[i]) || b[i] < 0 || b[i] > MaxB);
                

                if (error)
                {
                    Console.Error.WriteLine("HIBA! 0 es " + MaxB + " kozotti szam kell");
                }
            } while (error);
        }
        
        //algoritmus
        
        e = 0;
        
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                if (b[i] > 0)
                {
                    e++;
                }
            }
            else if (b[i] > b[i - 1])
            {
                e++;
            }
        }
        
        //kiiras
        
        Console.WriteLine(e);
        Console.Error.WriteLine("Eladasok szama: " + e);
    }
}