using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class BishopMoveStrategy : MoveStrategyBase<Bishop>
    {
        private static readonly Direction[] dirs =
            {
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        protected override IEnumerable<Move> GetMoves(Position from, IBoard board, Bishop piece)
        {
            return MoveHelper.Ray(from, board, dirs, piece.Color)
                .Select(to => new NormalMove(from, to));
        }
    }
}
