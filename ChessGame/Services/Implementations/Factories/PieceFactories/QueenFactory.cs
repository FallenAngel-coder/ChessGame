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
        public PieceType Type => PieceType.Queen;

        public Piece Create(Player color)
            => new Queen(color, new QueenMoveStrategy());
    }
}
