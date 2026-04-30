using ChessGame.Model;
using ChessGame.Model.Abstractions;
using ChessGame.Model.Moves;
using ChessGame.Model.MoveStrategies;
using ChessGame.Services;

namespace ChessGame
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        public Pawn(Player player)
        {
            Color = player;
        }

        public override IPiece Copy()
        {
            return new Pawn(Color) { HasMoved = this.HasMoved };
        }
    }
}