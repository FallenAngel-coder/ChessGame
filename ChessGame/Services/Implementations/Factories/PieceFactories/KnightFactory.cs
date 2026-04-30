using ChessGame.Model.MoveStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public class KnightFactory : ISubPieceFactory
    {
        public PieceType Type => PieceType.Knight;

        public IPiece Create(Player color)
            => new Knight(color);
    }
}
