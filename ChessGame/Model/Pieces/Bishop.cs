using ChessGame.Model;
using ChessGame.Model.Moves;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.Bishop;
        public override Player Color { get; }

        public Bishop(Player player, IMoveStrategy moveStrategy)
            : base(moveStrategy)
        {
            Color = player;
        }

        public override Piece Copy()
        {
            return new Bishop(Color, MoveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}