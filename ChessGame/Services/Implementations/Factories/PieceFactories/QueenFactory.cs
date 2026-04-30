using ChessGame.Model.MoveStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public class QueenFactory : ISubPieceFactory
    {
        public PieceType Type => PieceType.Queen;
        public IPiece Create(Player color)
            => new Queen(color);
    }
}
