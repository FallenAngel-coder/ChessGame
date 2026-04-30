using ChessGame.Model.Attributes;
using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    [PawnMoveStrategies]
    public class PawnEnPassantStrategy : IMoveStrategy
    {
        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            var pawn = piece as Pawn;
            if (pawn == null)
                yield break;

            var opponent = pawn.Color.Opponent();

            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + pawn.Forward + dir;

                if (to == board.GetPawnSkipPosition(opponent))
                {
                    yield return new EnPassant(from, to);
                }
            }
        }
    }
}
