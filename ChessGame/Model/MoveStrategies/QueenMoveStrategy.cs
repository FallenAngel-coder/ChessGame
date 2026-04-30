using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class QueenMoveStrategy : IMoveStrategy
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
            return MoveHelper.Ray(from, board, dirs, piece.Color)
                .Select(to => new NormalMove(from, to));
        }
    }
}
