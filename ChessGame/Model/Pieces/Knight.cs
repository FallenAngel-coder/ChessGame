using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        public Knight(Player player, IMoveStrategy moveStrategy)
            : base(moveStrategy)
        {
            Color = player;
        }

        public override Piece Copy()
        {
            return new Knight(Color, MoveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}