
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence{
	/// <summary>
	/// Tries to fit a square in an adjacent square in stack
	/// </summary>
	public class AdjacentSquareParser {

		/// <summary>
		/// It´s a list of adjacent square stacks
		/// </summary>
		private List<AdjacentSquareStack> _adjacentSquareStackList = new List<AdjacentSquareStack>();

		/// <summary>
		/// Gets a list of adjacent square stack discovered.
		/// </summary>
		/// <returns></returns>
		public List<AdjacentSquareStack> GetList()
        {
			return this._adjacentSquareStackList;
		}

        /// <summary>
        /// Parses a square and tries fit it in a adjacente square parser
        /// </summary>
        /// <param name="square"></param>
        public void TryToFit(LogicalSquare square)
        {
            #region Entries validation
            
            if (square == null)
            {
                throw new ArgumentNullException("square");
            }

            #endregion

            bool notFit = false;

            foreach (var stackItem in this._adjacentSquareStackList)
            {
                notFit = stackItem.TryToCollect(square);

                if(notFit)
                {
                    break;
                }
            }

            if (!notFit)
            {
                AdjacentSquareStack newStack = new AdjacentSquareStack();
                newStack.TryToCollect(square);

                this._adjacentSquareStackList.Add(newStack);
            }
        }

        /// <summary>
        /// Cleans all the adjacente square stack list
        /// </summary>
        public void Clear()
        {
            this._adjacentSquareStackList.Clear();
		}

		/// <summary>
		/// Gets a list of equivalent square replaced in adjacent square stack
		/// </summary>
		/// <returns></returns>
		public List<LogicalSquare> GetEquivalentSquares()
        {
            List<LogicalSquare> logicalList = new List<LogicalSquare>();
            foreach (var stackItem in this._adjacentSquareStackList)
            {
                #region Entries validation

                if (stackItem == null)
                {
                    throw new ArgumentNullException("stackItem");
                }
                if (stackItem.GetEquivalent() == null)
                {
                    continue;
                }

                #endregion

                logicalList.Add(stackItem.GetEquivalent());
            }

            return logicalList;
		}

		/// <summary>
		/// Gets a list of accepted square list from adjacent square stacks.
		/// </summary>
		/// <returns></returns>
		public List<LogicalSquare> GetAcceptedSquareList() {
            List<LogicalSquare> logicalList = new List<LogicalSquare>();
            foreach (var stackItem in this._adjacentSquareStackList)
            {
                #region Entries validation

                if (stackItem == null)
                {
                    throw new ArgumentNullException("stackItem");
                }
                if (stackItem.GetList() == null)
                {
                    continue;
                }
                if (stackItem.GetList().Count < 2)
                {
                    continue;
                }

                #endregion

                logicalList.AddRange(stackItem.GetList());
            }

            return logicalList;
        }

    }
}