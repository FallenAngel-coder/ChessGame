using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Rook : Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override Player Color { get; }

        public Rook(Player player, IMoveStrategy moveStrategy)
            : base(moveStrategy)
        {
            Color = player;
        }

        public override Piece Copy()
        {
            return new Rook(Color, MoveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}