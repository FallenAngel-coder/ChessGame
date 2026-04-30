using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.Moves
{
    public static class MoveHelper
    {
        public static IEnumerable<Position> Ray(Position from, IBoard board, Direction[] dirs, Player color)
        {
            foreach (var dir in dirs)
            {
                for (var pos = from + dir; board.IsInside(pos); pos += dir)
                {
                    if (board.IsEmpty(pos))
                    {
                        yield return pos;
                        continue;
                    }

                    if (board[pos].Color != color)
                    {
                        yield return pos;
                    }

                    break;
                }
            }
        }
    }
}