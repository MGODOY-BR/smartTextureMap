using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap.Support
{
    /// <summary>
    /// Represents a reading made by the axys engine
    /// </summary>
    public class Reading : IEquatable<Reading>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Result { get; set; }

        public Point Point { get; private set; }

        public Reading()
        {

        }

        public Reading(int x, int y, bool result)
        {
            this.X = x;
            this.Y = y;
            this.Result = result;

            this.Point = new Point(x, y);
        }

        public bool Equals(Reading other)
        {
            #region Entries validation
            
            if (other == null)
            {
                return false;
            }

            #endregion

            return this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Result.Equals(other.Result);
        }
    }
}
