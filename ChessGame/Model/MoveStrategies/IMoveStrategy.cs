using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public interface IMoveStrategy
    {
        IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece);
    }
}
