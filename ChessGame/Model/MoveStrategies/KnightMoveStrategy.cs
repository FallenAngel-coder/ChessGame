using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class KnightMoveStrategy : IMoveStrategy
    {
        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            foreach (var pos in PotentialPositions(from))
            {
                if (!board.IsInside(pos))
                    continue;

                if (board.IsEmpty(pos) || board[pos].Color != piece.Color)
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
