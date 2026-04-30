using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public abstract class Piece
    {
        private readonly IMoveStrategy _moveStrategy;
        protected IMoveStrategy MoveStrategy => _moveStrategy;

        protected Piece(IMoveStrategy strategy)
        {
            _moveStrategy = strategy;
        }

        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; }

        public IEnumerable<Move> GetMoves(Position from, IBoard board)
            => _moveStrategy.GetMoves(from, board, this);

        public abstract Piece Copy();
    }
}
