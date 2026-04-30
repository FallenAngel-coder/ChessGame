using ChessGame.Model.MoveStrategies;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class KnightFactory : ISubPieceFactory
    {
        private readonly IMoveStrategy _moveStrategy;
        public PieceType Type => PieceType.Knight;
        public KnightFactory(IMoveStrategy moveStrategy)
        {
            _moveStrategy = moveStrategy;
        }
        public Piece Create(Player color)
            => new Knight(color, _moveStrategy);
    }
}
