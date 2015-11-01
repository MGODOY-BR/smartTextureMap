
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence{
	/// <summary>
	/// Represents a stack of squares used to reduce redundances
	/// </summary>
	public class AdjacentSquareStack {

		/// <summary>
		/// Represents a stack of squares used to reduce redundances
		/// </summary>
		public AdjacentSquareStack() {
		}

		/// <summary>
		/// It´s the angle key which all the squares have in common in adjacency
		/// </summary>
		private String _angleKey;

		/// <summary>
		/// It´s the last square analised by TryCollect
		/// </summary>
		private LogicalSquare _lastSquare;


		/// <summary>
		/// It's a list of squares accepted by TryCollect operation
		/// </summary>
		private HashSet<LogicalSquare> _acceptedSquareList;

		/// <summary>
		/// Try to collect a square and returns a boolean indicating whether the square was accept or ignored.
		/// </summary>
		/// <param name="square"></param>
		/// <returns></returns>
		public bool TryToCollect(LogicalSquare square) {
			// TODO implement here
			return False;
		}

		/// <summary>
		/// Gets a equivalent logical square to replace all the logical squares collected
		/// </summary>
		/// <returns></returns>
		public LogicalSquare GetEquivalent() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Gets a list of collected squares
		/// </summary>
		/// <returns></returns>
		public HashSet<LogicalSquare> GetList() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Cleans the object
		/// </summary>
		public void Clear() {
			// TODO implement here
		}

		/// <summary>
		/// Checks if some square was accepted
		/// </summary>
		/// <returns></returns>
		public bool CheckForSomeSquareAccepted() {
			// TODO implement here
			return False;
		}

	}
}