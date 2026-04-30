using ChessGame.Model;
using ChessGame.Model.Abstractions;
using ChessGame.Model.Moves;
using ChessGame.Model.MoveStrategies;
using ChessGame.Model.PromotionStrategies;
using ChessGame.Services;

namespace ChessGame
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        public Direction Forward { get; }
        public IEnumerable<Direction> CaptureDirections { get; }

        public Pawn(Player player, IMoveStrategy strategy)
            : base(strategy)
        {
            Color = player;

            Forward = player == Player.White ? Direction.North : Direction.South;
            CaptureDirections = new[] { Direction.West, Direction.East };
        }

        public override Piece Copy()
        {
            return new Pawn(Color, MoveStrategy)
            {
                HasMoved = this.HasMoved
            };
        }
    }
}