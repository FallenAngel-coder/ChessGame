using ChessGame.Model.MoveStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public class BishopFactory : ISubPieceFactory
    {
        public PieceType Type => PieceType.Bishop;

        public IPiece Create(Player color)
            => new Bishop(color);
    }
}
