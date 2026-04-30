using ChessGame.Model.MoveStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public class KingFactory : ISubPieceFactory
    {
        public PieceType Type => PieceType.King;

        public IPiece Create(Player color)
            => new King(color);
    }
}
