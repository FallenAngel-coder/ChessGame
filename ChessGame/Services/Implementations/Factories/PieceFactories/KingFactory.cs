using ChessGame.Model.MoveStrategies;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class KingFactory : ISubPieceFactory
    {

        public PieceType Type => PieceType.King;

        public Piece Create(Player color)
            => new King(color, new KingMoveStrategy());
    }
}
