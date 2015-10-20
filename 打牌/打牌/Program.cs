using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打牌
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 定义
            int n1 = 0, n2 = 0, n3 = 0, n4 = 0;//桌数
            int n = 0;//步数
            bool flag = true;
            #endregion
            #region 输入
            while(flag)
            {
                try
                {
                    Console.WriteLine("请输入1人桌的数目：");
                    n1 = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("输入错误，重新输入");
                }
            }
            flag = true;
            while(flag)
            {
                try
                {
                    Console.WriteLine("请输入2人桌的数目：");
                    n2 = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("输入错误，重新输入");
                }
            }
            flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("请输入3人桌的数目：");
                    n3 = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("输入错误，请重新输入");
                }
            }
            flag = true;
            while(flag)
            {
                try
                {
                    Console.WriteLine("请输入4人桌的数目：");
                    n4 = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("输入错误，重新输入");
                }
            }
            #endregion
            #region 计算
            n += (n1 / 3 * 2);
            n += (n2 / 3 * 2);
            n3 += (n1 / 3);
            n3 += (n2 / 3 * 2);
            n1 = n1 % 3;
            n2 = n2 % 3;
            Console.WriteLine(n);
            if(n2>=n1)
            {
                n2 -= n1;
                n += n1;
                n1 = 0;
            }
            else
            {
                n1 -= n2;
                n2 = 0;
                n += n2;
            }
            Console.WriteLine(n);
            switch(n1+n2)
            {
                case 0:
                    {
                        flag = true;
                    }
                    break;
                case 1:
                    {
                        if(n1==1)
                        {
                            if(n3==0)
                            {
                                if(n4<2)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    n4 -= 2;
                                    n += 2;
                                    n3 += 3;
                                    n1 -= 1;
                                    flag = true;
                                }
                            }
                            else
                            {
                                n3 -= 1;
                                n += 1;
                                n4 += 1;
                                n1 -= 1;
                                flag = true;
                            }
                        }
                        else
                        {
                            if(n4==0)
                            {
                                if(n3<2)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    n3 -= 2;
                                    n4 += 2;
                                    n += 2;
                                    n2 -= 1;
                                    flag = true;
                                }
                            }
                            else
                            {
                                n4 -= 1;
                                n += 1;
                                n3 += 2;
                                n2 -= 1;
                                flag = true;
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        if(n1==2)
                        {
                            if(n4==0)
                            {
                                if(n3<2)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    n3 -= 2;
                                    n += 2;
                                    n1 -= 2;
                                    n4 += 2;
                                    flag = true;
                                }
                            }
                            else
                            {
                                n4 -= 1;
                                n3 += 3;
                                n += 2;
                                n1 -= 2;
                                flag = true;
                            }
                        }
                        else
                        {
                            n2 -= 2;
                            n += 2;
                            n4 += 1;
                            flag = true;
                        }
                    }
                    break;
            }
            #endregion
            #region 输出
            if (n1 == 0 && n2 == 0 && flag)
            {
                Console.WriteLine(n);
            }
            else
            {
                Console.WriteLine("NO");
            }
            Console.ReadKey();
            #endregion
        }
    }
}
