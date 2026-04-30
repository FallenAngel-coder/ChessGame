using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        public Queen(Player player, IMoveStrategy moveStrategy)
            : base(moveStrategy)
        {
            Color = player;
        }

        public override Piece Copy()
        {
            return new Queen(Color, MoveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}