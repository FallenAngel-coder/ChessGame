using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        public Queen(Player player)
        {
            Color = player;
        }

        public override IPiece Copy()
        {
            return new Queen(Color) { HasMoved = this.HasMoved };
        }
    }
}