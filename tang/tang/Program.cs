using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tang
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("G:\\临时停尸房\\图片.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] photo = br.ReadBytes((int)fs.Length);
            StreamWriter sw = new StreamWriter("d:\\bbb.jpg");
        }
    }
}
