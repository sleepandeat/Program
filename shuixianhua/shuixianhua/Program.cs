using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuixianhua
{
    class Program
    {
        static void Main(string[] args)
        {
            //这是一个求水仙花数的程序
            //水仙花数：
            //存在这样的三位数abc，若a*a*a+b*b*b+c*c*c=abc，则abc是水仙花数
            int a, b, c;
            for(a=1;a<10;a++)
            {
                for(b=0;b<10;b++)
                {
                    for(c=0;c<10;c++)
                    {
                        if(a*a*a+b*b*b+c*c*c==100*a+10*b+c)
                        {
                            Console.WriteLine(100*a+10*b+c);
                        }
                    }
                    c = 0;
                }
                b = 0;
            }
            Console.ReadKey();
        }
    }
}
