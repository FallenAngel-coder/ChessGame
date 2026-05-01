using ChessLibrary.Enums;
using ChessLibrary.Game;

namespace ChessLibrary.Game.Factories
{
    public interface IGameStateFactory
    {
        IGameState Create(Player player);
    }
}
