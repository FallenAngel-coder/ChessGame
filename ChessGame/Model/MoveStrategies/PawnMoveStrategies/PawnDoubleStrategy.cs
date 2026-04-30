using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class PawnDoubleStrategy : IMoveStrategy
    {
        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            var pawn = piece as Pawn;
            if (pawn == null)
                yield break;

            Position twoStep = from + pawn.Forward + pawn.Forward;

            if (!board.IsInside(twoStep) || !board.IsEmpty(twoStep))
                yield break;

            if (!pawn.HasMoved)
                yield return new DoublePawn(from, twoStep);
        }
    }
}
