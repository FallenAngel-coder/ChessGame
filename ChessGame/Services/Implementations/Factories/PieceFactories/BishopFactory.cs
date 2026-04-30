using ChessGame.Model.MoveStrategies;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class BishopFactory : ISubPieceFactory
    {
        private readonly IMoveStrategy _moveStrategy;

        public PieceType Type => PieceType.Bishop;

        public BishopFactory(IMoveStrategy moveStrategy) 
        {
            _moveStrategy = moveStrategy;
        }
        public Piece Create(Player color)
            => new Bishop(color, _moveStrategy);
    }
}
