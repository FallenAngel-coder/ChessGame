using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model
{
    public interface IMoveStrategy
    {
        bool CanHandle(IPiece piece);
        IEnumerable<Move> GetMoves(Position from, IBoard board, IPiece piece);
    }
}
