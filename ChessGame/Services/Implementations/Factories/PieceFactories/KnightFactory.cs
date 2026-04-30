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
        public PieceType Type => PieceType.Knight;

        public Piece Create(Player color)
            => new Knight(color, new KnightMoveStrategy());
    }
}
