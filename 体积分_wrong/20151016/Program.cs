using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20151016
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            double x, y;
            double xlb = 1, xub = 0, ylb = 1, yub = 0;
            double sum = 0;
            while(xlb>xub||ylb>yub)
            {
                while(flag)
                {
                    try
                    {
                        xlb = Convert.ToDouble(Console.ReadLine());
                        flag = !flag;
                    }
                    catch
                    {
                        Console.WriteLine();
                    }
                }
                flag = !flag;
                while (flag)
                {
                    try
                    {
                        xub = Convert.ToDouble(Console.ReadLine());
                        flag = !flag;
                    }
                    catch
                    {
                        Console.WriteLine();
                    }
                }
                flag = !flag;
                while (flag)
                {
                    try
                    {
                        ylb = Convert.ToDouble(Console.ReadLine());
                        flag = !flag;
                    }
                    catch
                    {
                        Console.WriteLine();
                    }
                }
                flag = !flag;
                while (flag)
                {
                    try
                    {
                        yub = Convert.ToDouble(Console.ReadLine());
                        flag = !flag;
                    }
                    catch
                    {
                        Console.WriteLine();
                    }
                }
                flag = !flag;
                x = xlb;
                y = ylb;
                while(x<=xub)
                {
                    while(y<=yub)
                    {
                        sum += 0.000001 * Math.Sin(y) + y * Math.Sin(0.000001);
                        y += 0.000001;
                    }
                    x += 0.000001;
                }
                Console.WriteLine(sum);
                Console.ReadKey();
            }
        }
    }
}
