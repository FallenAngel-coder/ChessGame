using ChessGame.Model.Abstractions;
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
        public PieceType Type => PieceType.Pawn;

        public Piece Create(Player color)
        {
            var pawnStrategies = new List<IMoveStrategy>
            {
                new PawnForwardStrategy(),
                new PawnCaptureStrategy(),
                new PawnDoubleStrategy(),
                new PawnEnPassantStrategy()
            };

            return new Pawn(color, new CompositeMoveStrategy(pawnStrategies));
        }
    }
}
