using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class KnightMoveStrategy : MoveStrategyBase<Knight>
    {
        protected override IEnumerable<Move> GetMoves(Position from, IBoard board, Knight knight)
        {
            foreach (var pos in PotentialPositions(from))
            {
                if (!board.IsInside(pos))
                    continue;

                if (board.IsEmpty(pos) || board[pos].Color != knight.Color)
                    yield return new NormalMove(from, pos);
            }
        }

        private IEnumerable<Position> PotentialPositions(Position from)
        {
            foreach (Direction vDir in new[] { Direction.North, Direction.South })
            {
                foreach (Direction hDir in new[] { Direction.West, Direction.East })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }
    }
}
