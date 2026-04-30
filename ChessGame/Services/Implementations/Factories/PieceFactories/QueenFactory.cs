using ChessGame.Model.MoveStrategies;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class QueenFactory : ISubPieceFactory
    {
        private readonly IMoveStrategy _moveStrategy;
        public PieceType Type => PieceType.Queen;
        public QueenFactory(IMoveStrategy moveStrategy)
        {
            _moveStrategy = moveStrategy;
        }
        public Piece Create(Player color)
            => new Queen(color, _moveStrategy);
    }
}
