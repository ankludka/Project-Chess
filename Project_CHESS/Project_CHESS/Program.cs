using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CHESS
{
    class Program
    {
        static void Main(string[] args)
        {
            Board plansza = new Board();
            plansza.askForColor();
            plansza.show();
            while (true)
            {
                plansza.askForMove();
                plansza.show();
            }

//            Console.ReadKey();
        }
        
    }
}
