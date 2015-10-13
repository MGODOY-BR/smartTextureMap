using smartTextureMap.Intelligence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string fileName = args[0];
                string newFileName =
                    Path.Combine(
                        Path.GetPathRoot(fileName),
                        Path.GetFileNameWithoutExtension(fileName) + ".smartMap" + Path.GetExtension(fileName));

                SmartTextureMap smartTextureMap = new SmartTextureMap();
                smartTextureMap.Load(fileName);
                smartTextureMap.Generate(newFileName);
            }
        }
    }
}
