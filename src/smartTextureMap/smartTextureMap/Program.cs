using smartTextureMap.CommandPrompt;
using smartTextureMap.Forms;
using smartTextureMap.Intelligence;
using smartTextureMap.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartTextureMap
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    LaunchGraphicUserInterface();
                }
                else
                {
                    LaunchCommandPrompt(args);
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
            }
        }

        /// <summary>
        /// Launchs command prompt
        /// </summary>
        /// <param name="args"></param>
        private static void LaunchCommandPrompt(string[] args)
        {
            OutputManager.SetOutPutWay(new CommandPromptOutput());

            string fileName = args[0];
            string destination = Path.GetPathRoot(fileName);

            if (args.Length == 2)
            {
                destination = args[1];

                if (!Directory.Exists(destination))
                {
                    throw new ArgumentException("Directory has not found.");
                }
            }

            DateTime dateTime = DateTime.Now;
            OutputManager.WriteLine("Wait, processing...");

            string newFileName =
                Path.Combine(
                    destination,
                    Path.GetFileNameWithoutExtension(fileName) + ".smartMap" + Path.GetExtension(fileName));

            SmartTextureMap smartTextureMap = new SmartTextureMap();
            smartTextureMap.Load(fileName);
            smartTextureMap.Generate(newFileName);

            OutputManager.WriteLine();
            OutputManager.WriteLine("Discovered " + smartTextureMap.FormList.Count + " shapes");
            OutputManager.WriteLine();
            OutputManager.WriteLine("File was generated with success. It took " + DateTime.Now.Subtract(dateTime).ToString());
        }

        /// <summary>
        /// Lanuchs GUI
        /// </summary>
        private static void LaunchGraphicUserInterface()
        {
            OutputManager.SetOutPutWay(new FormOutput());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PrincipalForm());
        }
    }
}
