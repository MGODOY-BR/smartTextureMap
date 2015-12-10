using smartTextureMap.CommandPrompt;
using smartTextureMap.Forms;
using smartTextureMap.Intelligence;
using smartTextureMap.IO;
using smartTextureMap.Support;
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
            ContextMap contextMap = null;
            try
            {
                if (args.Length == 0)
                {
                    contextMap = LaunchGraphicUserInterface();
                }
                else
                {
                    contextMap = LaunchCommandPrompt(args);
                }
            }
            catch (Exception ex)
            {
                OutputManager.WriteLine(contextMap, ex.Message);
                if (ex.InnerException != null)
                {
                    OutputManager.WriteLine(contextMap, " ----> " + ex.InnerException.Message);
                }
                OutputManager.WriteLine(contextMap);
            }
        }

        /// <summary>
        /// Launchs command prompt
        /// </summary>
        /// <param name="args"></param>
        private static ContextMap LaunchCommandPrompt(string[] args)
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

            SmartTextureMap smartTextureMap = new SmartTextureMap();
            smartTextureMap.Load(fileName);
            smartTextureMap.Generate(NewFileUtil.GetNewFullName(fileName));

            OutputManager.WriteLine(smartTextureMap.ContextMap);
            OutputManager.WriteLine(smartTextureMap.ContextMap, "Discovered " + smartTextureMap.FormList.Count + " shapes");
            OutputManager.WriteLine(smartTextureMap.ContextMap);
            OutputManager.WriteLine(smartTextureMap.ContextMap, "File was generated with success. It took " + DateTime.Now.Subtract(dateTime).ToString());

            return smartTextureMap.ContextMap;
        }

        /// <summary>
        /// Lanuchs GUI
        /// </summary>
        private static ContextMap LaunchGraphicUserInterface()
        {
            OutputManager.SetOutPutWay(new FormOutput());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Form_ThreadException;
            Application.Run(new PrincipalForm());

            return new ContextMap();
        }

        /// <summary>
        /// Handles the errors happens in GUI mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), e.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
