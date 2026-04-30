using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class RookMoveStrategy : MoveStrategyBase<Rook>
    {
        private static readonly Direction[] dirs =
        {
            Direction.North, Direction.South,
            Direction.West, Direction.East
        };

        protected override IEnumerable<Move> GetMoves(Position from, IBoard board, Rook rook)
        {
            return MoveHelper.Ray(from, board, dirs, rook.Color)
                .Select(to => new NormalMove(from, to));
        }
    }
}
