using ChessGame.Model;
using ChessGame.Model.Moves;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public class Bishop : Piece
    {
        private readonly IMoveStrategy _moveStrategy;
        public override PieceType Type => PieceType.Bishop;
        public override Player Color { get; }

        public Bishop(Player player, IMoveStrategy moveStrategy) : base(moveStrategy)
        {
            Color = player;
            _moveStrategy = moveStrategy;
        }

        public override Piece Copy()
        {
            return new Bishop(Color, _moveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}