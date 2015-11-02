using smartTextureMap.Support;
using smartTextureMap.Support.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap.Exceptions
{
    /// <summary>
    /// Occurs after an operation which doesn't support the catheti
    /// </summary>
    public class InvalidCathetiException : ApplicationException
    {
        /// <summary>
        /// It´s a list with the catheti used in operation which had the error
        /// </summary>
        private List<Cathetus> _cathetusList = new List<Cathetus>();

        /// <summary>
        /// It´s the reason of exception
        /// </summary>
        private String _reason;

        /// <summary>
        /// Creates the exception
        /// </summary>
        public InvalidCathetiException(String reason, params Cathetus[] args)
        {
            #region Entries validation
            
            if (String.IsNullOrEmpty(reason))
            {
                throw new ArgumentNullException("reason");
            }

            #endregion

            this._cathetusList.AddRange(args);
            this._reason = reason;
        }

        public override string Message
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(this._reason);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Cathetus list:");
                foreach (var item in this._cathetusList)
                {
                    stringBuilder.AppendLine(item.ToString());
                }

                return stringBuilder.ToString();
            }
        }
    }
}
