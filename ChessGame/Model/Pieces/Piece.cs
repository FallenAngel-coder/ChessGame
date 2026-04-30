using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public abstract class Piece
    {
        protected IMoveStrategy MoveStrategy { get; }

        protected Piece(IMoveStrategy moveStrategy)
        {
            MoveStrategy = moveStrategy;
        }

        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; }

        public IEnumerable<Move> GetMoves(Position from, IBoard board)
            => MoveStrategy.GetMoves(from, board, this);

        public abstract Piece Copy();
    }
}