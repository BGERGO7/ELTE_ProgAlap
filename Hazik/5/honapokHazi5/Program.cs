namespace honapokHazi5;

class Program
{
    static void Main(string[] args)
    {
        //https://progenv.inf.elte.hu/hu/tasks/161
        
        //deklaracio
        string[] honapok = new string[]
        {
            "januar", "februar", "marcius", "aprilis", "majus", "junius",
            "julius", "augusztus", "szeptember", "oktober", "november", "december"
        };
        int i = 0;
        int j = 0;

        
        // beolvasas
        int n = int.Parse(Console.ReadLine()!);

        string[] t = new string[n];
        for (int k = 0; k < n; k++)
        {
            t[k] = Console.ReadLine()!;
        }
        
        //algoritmus

        while (i < 12 && j < n)
        {
            j = 0;
            while (j < n && t[j] != honapok[i])
            {
                j++;
            }

            if (j < n)
            {
                i++;
            }
        }
        
        bool van = (i < 12);
        
        //kiiras
        if (!van)
        {
            Console.WriteLine("IGEN");
        }
        else
        {
            Console.WriteLine("NEM");
        }
    }
}