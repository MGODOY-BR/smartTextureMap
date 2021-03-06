﻿using smartTextureMap.IO;
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap.Test.Trace
{
    public class TraceOutput : IOutput
    {
        public void Clear(object sender, ContextMap context)
        {
        }

        public void WriteLine(object sender, ContextMap context)
        {
            System.Diagnostics.Trace.WriteLine("");
        }

        public void WriteLine(object sender, ContextMap context, string stringFormat, params object[] args)
        {
            if (args.Length == 0)
            {
                System.Diagnostics.Trace.WriteLine(stringFormat);
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(
                    String.Format(stringFormat, args));
            }
        }
    }
}
