using ChessGame.Model;
using ChessGame.Model.Abstractions;
using ChessGame.Model.Moves;
using ChessGame.Services.Interfaces.Utils;

namespace ChessGame.Services.Implementations.Utils
{
    public class MoveFactory : IMoveFactory
    {
        private readonly IPieceFactory _pieceFactory;

        public MoveFactory(IPieceFactory pieceFactory)
        {
            _pieceFactory = pieceFactory;
        }

        public Move CreateNormalMove(Position from, Position to)
            => new NormalMove(from, to);

        public IEnumerable<Move> CreatePromotionMoves(
            Position from,
            Position to,
            IEnumerable<PieceType> promotionTypes)
        {
            foreach (var type in promotionTypes)
            {
                yield return new PawnPromotion(
                    from,
                    to,
                    type,
                    _pieceFactory
                );
            }
        }
    }
}