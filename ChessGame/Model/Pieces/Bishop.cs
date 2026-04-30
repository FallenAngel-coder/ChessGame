using ChessGame.Model;
using ChessGame.Model.Moves;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.Bishop;
        public override Player Color { get; }

        public Bishop(Player player)
        {
            Color = player;
        }

        public override IPiece Copy()
        {
            return new Bishop(Color) { HasMoved = this.HasMoved };
        }
    }
}