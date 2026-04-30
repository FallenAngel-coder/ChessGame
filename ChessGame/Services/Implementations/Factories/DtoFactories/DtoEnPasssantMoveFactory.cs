using ChessGame.Model;
using ChessGame.Services.DTO.Messages;
using ChessGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Factories
{
    public class DtoEnPasssantMoveFactory : ISpecificDtoMoveFactory
    {
        private readonly IGameService _gameService;

        public DtoEnPasssantMoveFactory(IGameService gameService)
        {
            _gameService = gameService;
        }

        public DtoType TargetDtoType => DtoType.EnPassant;
        public MoveType TargetMoveType => MoveType.EnPassant;

        public Move GetMoveFromDTO(IDtoMessage message)
        {
            var dto = (DtoEnPassantMove)message;
            var legalMoves = _gameService.GetLegalMoves(dto.FromPos);
            var localMove = legalMoves.FirstOrDefault(m => m.ToPos == dto.ToPos && m.Type == TargetMoveType);

            return localMove ?? throw new InvalidOperationException("Нелегальний double хід.");
        }

        public IDtoMessage GetMoveToDTO(Move move)
        {
            return new DtoEnPassantMove(move.FromPos, move.ToPos);
        }
    }
}