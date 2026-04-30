using System.Collections.Generic;
using System.Linq;
using ChessGame.Model;
using ChessGame.Model.Moves;
using ChessGame.Services.Interfaces;

namespace ChessGame.Services
{
    public class ChessRulesService : IChessRulesService
    {
        private readonly IMoveFactory _moveFactory;
        private static readonly PieceType[] _promotionTypes = new[]
            {
            PieceType.Queen, PieceType.Rook, PieceType.Bishop, PieceType.Knight
        };

        public ChessRulesService(IMoveFactory moveFactory)
        {
            _moveFactory = moveFactory;
        }
        public IEnumerable<Move> GetLegalMoves(IBoard board, Player player, Position pos)
        {
            if (board.IsEmpty(pos)) return Enumerable.Empty<Move>();

            var piece = board[pos];
            if (piece.Color != player) return Enumerable.Empty<Move>();

            var candidates = piece.GetMoves(pos, board);
            var legalMoves = new List<Move>();

            foreach (var move in candidates)
            {
                if (piece.Type == PieceType.Pawn && IsLastRank(move.ToPos, piece.Color))
                {
                    var promotionMoves = _moveFactory.CreatePromotionMoves(
                        move.FromPos, move.ToPos, _promotionTypes);
                    legalMoves.AddRange(promotionMoves);
                }
                else
                {
                    legalMoves.Add(move);
                }
            }

            return legalMoves.Where(m => IsMoveLegal(board, m));
        }
        private bool IsLastRank(Position pos, Player color)
        {
            return color == Player.White ? pos.Row == 0 : pos.Row == 7;
        }
        public bool HasAnyLegalMoves(IBoard board, Player player)
        {
            foreach (var pos in board.PiecePositionsFor(player))
            {
                if (GetLegalMoves(board, player, pos).Any())
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsMoveLegal(IBoard board, Move move)
        {
            IBoard copy = board.Copy();

            var piece = copy[move.FromPos];

            move.Execute(copy);

            bool isCheck = IsInCheck(copy, piece.Color);

            return !isCheck;
        }

        public bool IsInCheck(IBoard board, Player player)
        {
            var kingPos = board.FindKing(player);
            if (kingPos == null) return false;

            var opponent = player.Opponent();

            foreach (var pos in board.PiecePositionsFor(opponent))
            {
                var piece = board[pos];
                var attacks = piece.GetMoves(pos, board);

                if (attacks.Any(m => m.ToPos == kingPos))
                    return true;
            }

            return false;
        }

        public Position GetKingInCheck(IBoard board)
        {
            if (IsInCheck(board, Player.White)) return board.FindKing(Player.White);
            if (IsInCheck(board, Player.Black)) return board.FindKing(Player.Black);
            return null;
        }
    }
}