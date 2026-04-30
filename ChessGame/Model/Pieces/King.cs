using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        public King(Player player, IMoveStrategy moveStrategy)
            : base(moveStrategy)
        {
            Color = player;
        }

        public override Piece Copy()
        {
            return new King(Color, MoveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}