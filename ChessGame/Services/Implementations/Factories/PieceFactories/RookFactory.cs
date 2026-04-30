using ChessGame.Model.MoveStrategies;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class RookFactory : ISubPieceFactory
    {
        private readonly IMoveStrategy _moveStrategy;
        public PieceType Type => PieceType.Rook;
        public RookFactory(IMoveStrategy moveStrategy)
        {
            _moveStrategy = moveStrategy;
        }
        public Piece Create(Player color)
            => new Rook(color, _moveStrategy);
    }
}
