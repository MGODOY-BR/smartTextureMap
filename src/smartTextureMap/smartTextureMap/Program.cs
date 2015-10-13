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
            try
            {
                if (args.Length == 1)
                {
                    DateTime dateTime = DateTime.Now;
                    Console.WriteLine("Wait, processing...");

                    string fileName = args[0];
                    string newFileName =
                        Path.Combine(
                            Path.GetPathRoot(fileName),
                            Path.GetFileNameWithoutExtension(fileName) + ".smartMap" + Path.GetExtension(fileName));

                    SmartTextureMap smartTextureMap = new SmartTextureMap();
                    smartTextureMap.Load(fileName);
                    smartTextureMap.Generate(newFileName);

                    Console.WriteLine();
                    Console.WriteLine("Discovered " + smartTextureMap.FormList.Count + " shapes");
                    Console.WriteLine();
                    Console.WriteLine("File was generated with success. It took " + DateTime.Now.Subtract(dateTime).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.Write(" - " + ex.InnerException.Message);
                }
                Console.WriteLine();
                //Console.WriteLine(ex.ToString());
            }
        }
    }
}
