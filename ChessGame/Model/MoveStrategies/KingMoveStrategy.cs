using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class KingMoveStrategy : IMoveStrategy
    {
        private static readonly Direction[] dirs =
        {
            Direction.North, Direction.South,
            Direction.West, Direction.East,
            Direction.NorthEast, Direction.NorthWest,
            Direction.SouthEast, Direction.SouthWest
        };

        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            foreach (var dir in dirs)
            {
                Position to = from + dir;

                if (!board.IsInside(to))
                    continue;

                if (board.IsEmpty(to) || board[to].Color != piece.Color)
                {
                    yield return new NormalMove(from, to);
                }
            }
        }
    }
}
