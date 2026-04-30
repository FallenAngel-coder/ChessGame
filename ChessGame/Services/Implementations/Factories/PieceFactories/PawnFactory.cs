using ChessGame.Model.Abstractions;
using ChessGame.Model.Attributes;
using ChessGame.Model.MoveStrategies;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class PawnFactory : ISubPieceFactory
    {
        private readonly CompositeMoveStrategy _moveStrategy;

        public PieceType Type => PieceType.Pawn;

        public PawnFactory(IEnumerable<IMoveStrategy> pawnStrategies)
        {
            _moveStrategy = new CompositeMoveStrategy(pawnStrategies);
        }

        public Piece Create(Player color)
            => new Pawn(color, _moveStrategy);
    }
}
