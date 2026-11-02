namespace p260928;

class Program
{
    const int MaxN = 100;
    
    const int MaxM = 1000;
    
    static void Main(string[] args)
    {
        
        // https://progenv.inf.elte.hu/hu/tasks/60
        Console.Error.WriteLine("Esos napok szama");
        
        //deklaracio
        int n;
        int[] m = new int[MaxN];
        
        int s;
        //beolvasas
        bool error = false;
        do
        {
            Console.Error.Write("N: ");
           // n=Int32.Parse(Console.ReadLine());
           error = (!Int32.TryParse(Console.ReadLine(), out n) || n < 0 || MaxN < n);
           if (error)
           {
               Console.Error.WriteLine("HIBA! 0 es " + MaxN + " kozotti szam kell");
           }

        } while (error);
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Error.Write((i+1) + ". meres: ");
                error = (!Int32.TryParse(Console.ReadLine(), out m[i]) || m[i]<0 || MaxM < m[i]);
                //m[i] = Int32.Parse(Console.ReadLine());

                if (error)
                {
                    Console.Error.WriteLine("HIBA! 0 es " + MaxM + " kozotti szam kell");
                }
            } while (error);
        }
        
        //algoritmus implementalasa

        s = 0;
        for (int i = 0; i < n; i++)
        {
            if (m[i] > 0)
            {
                s++;
            }
        }

        // kiiras
        Console.WriteLine(s);
        Console.Error.WriteLine("Esos napok szama: " + s);
    }
}