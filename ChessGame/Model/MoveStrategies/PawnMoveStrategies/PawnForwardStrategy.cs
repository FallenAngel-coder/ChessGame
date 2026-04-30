using ChessGame.Model.Attributes;
using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    [PawnMoveStrategies]
    public class PawnForwardStrategy : IMoveStrategy
    {
        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            var pawn = piece as Pawn;
            if (pawn == null)
                yield break;

            Position oneStep = from + pawn.Forward;

            if (!board.IsInside(oneStep) || !board.IsEmpty(oneStep))
                yield break;

            yield return new NormalMove(from, oneStep);
        }
    }
}
