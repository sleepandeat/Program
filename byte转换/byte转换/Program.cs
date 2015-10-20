using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byte转换
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buf = new byte[4];
            string data;
            buf[0] = 1;
            buf[1] = 2;
            buf[2] = 3;
            buf[3] = 4;
            data = Convert.ToString(buf);
            Console.WriteLine(data);
            Console.ReadKey();
        }
    }
}
