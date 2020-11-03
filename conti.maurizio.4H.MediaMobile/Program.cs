using System;

namespace conti.maurizio._4H.MediaMobile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MediaMobile!");

            Campioni c = new Campioni();
            c.Finestra = 3;

            Console.WriteLine(c.Valori);
            Console.WriteLine(c.GraficoTemperatura);
            Console.WriteLine($"Min:{c.MinTemperatura}, Max:{c.MaxTemperatura}, Offset:{c.OffsetTemperatura}");

/*            Console.WriteLine( c );

            c.Finestra = 4;
            Console.WriteLine(c);

            c.Finestra = 5;
            Console.WriteLine(c); */
        }

    }
}
