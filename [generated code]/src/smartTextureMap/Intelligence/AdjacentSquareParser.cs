
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
		/// Tries to fit a square in an adjacent square in stack
		/// </summary>
		public AdjacentSquareParser() {
		}

		/// <summary>
		/// It´s a list of adjacent square stacks
		/// </summary>
		private HashSet<AdjacentSquareStack> _adjacentSquareStackList;

		/// <summary>
		/// Gets a list of adjacent square stack discovered.
		/// </summary>
		/// <returns></returns>
		public HashSet<AdjacentSquareStack> GetList() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Parses a square  try fit it in a adjaente square parser
		/// </summary>
		/// <param name="square"></param>
		public void Parse(LogicalSquare square) {
			// TODO implement here
		}

		/// <summary>
		/// Cleans all the adjacente square stack list
		/// </summary>
		public void Clear() {
			// TODO implement here
		}

		/// <summary>
		/// Gets a list of equivalent square replaced in adjacent square stack
		/// </summary>
		/// <returns></returns>
		public HashSet<LogicalSquare> GetEquivalentSquares() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Gets a list of accepted square list from adjacente square stacks.
		/// </summary>
		/// <returns></returns>
		public HashSet<LogicalSquare> GetAcceptedSquareList() {
			// TODO implement here
			return null;
		}

	}
}