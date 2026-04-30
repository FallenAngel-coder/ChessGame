using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model
{
    public abstract class MoveStrategyBase<TPiece> : IMoveStrategy where TPiece : IPiece
    {
        public bool CanHandle(IPiece piece) => piece is TPiece;

        public IEnumerable<Move> GetMoves(Position from, IBoard board, IPiece piece)
        {
            return GetMoves(from, board, (TPiece)piece);
        }

        protected abstract IEnumerable<Move> GetMoves(Position from, IBoard board, TPiece piece);
    }
}
