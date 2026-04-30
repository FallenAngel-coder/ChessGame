using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class PawnCaptureStrategy : IMoveStrategy
    {
        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            var pawn = piece as Pawn;
            if (pawn == null)
                yield break;

            foreach (var dir in pawn.CaptureDirections)
            {
                Position target = from + pawn.Forward + dir;

                if (!board.IsInside(target))
                    continue;

                var targetPiece = board[target];

                if (targetPiece != null && targetPiece.Color != pawn.Color)
                {
                    yield return new NormalMove(from, target);
                }
            }
        }
    }
}
