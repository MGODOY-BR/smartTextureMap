using smartTextureMap.CommandPrompt;
using smartTextureMap.Intelligence;
using smartTextureMap.IO;
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
            if (args.Length == 0)
            {
                throw new ArgumentException("File name is missed.");
            }

            OutputManager.SetOutPutWay(new CommandPromptOutput());

            try
            {
                if (args.Length == 1)
                {
                    DateTime dateTime = DateTime.Now;
                    OutputManager.WriteLine("Wait, processing...");

                    string fileName = args[0];
                    string newFileName =
                        Path.Combine(
                            Path.GetPathRoot(fileName),
                            Path.GetFileNameWithoutExtension(fileName) + ".smartMap" + Path.GetExtension(fileName));

                    SmartTextureMap smartTextureMap = new SmartTextureMap();
                    smartTextureMap.Load(fileName);
                    smartTextureMap.Generate(newFileName);

                    OutputManager.WriteLine();
                    OutputManager.WriteLine("Discovered " + smartTextureMap.FormList.Count + " shapes");
                    OutputManager.WriteLine();
                    OutputManager.WriteLine("File was generated with success. It took " + DateTime.Now.Subtract(dateTime).ToString());
                }
            }
            catch (Exception ex)
            {
                OutputManager.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    OutputManager.WriteLine(" ----> " + ex.InnerException.Message);
                }
                OutputManager.WriteLine();
                //OutputManager.WriteLine(ex.ToString());
            }
        }
    }
}
