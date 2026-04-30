using ChessGame.Model.Abstractions;
using ChessGame.Model.Moves;
using ChessGame.Services.Abstractions;
using ChessGame.Services.DTO.Messages;
using ChessGame.Services.Interfaces;
using System.Windows;


namespace ChessGame.Services.DTO.Handlers
{
    public class DoubleMoveHandler : IMessageHandler<DtoDoubleMove>
    {
        private readonly IGameService _gameService;
        private readonly IDtoMoveFactory _moveFactory;

        public DoubleMoveHandler(IDtoMoveFactory moveFactory, IGameService gameService)
        {
            _moveFactory = moveFactory;
            _gameService = gameService;
        }

        public Task HandleAsync(DtoDoubleMove message)
        {
            var move = _moveFactory.GetMoveFromDTO(message);
            _gameService.TryMakeMove(move);
            return Task.CompletedTask;
        }
    }
}
