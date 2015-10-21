using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace way2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            int total=100;
            for(;total<1000;total++)
            {
                a = total / 100;
                b = (total % 100) / 10;
                c = total % 10;
                if(a*a*a+b*b*b+c*c*c==total)
                {
                    Console.WriteLine(total);
                }
            }
            Console.ReadKey();
        }
    }
}
