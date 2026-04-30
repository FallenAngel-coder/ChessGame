using ChessGame.Model.MoveStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public class RookFactory : ISubPieceFactory
    {
        public PieceType Type => PieceType.Rook;
        public IPiece Create(Player color)
            => new Rook(color);
    }
}
