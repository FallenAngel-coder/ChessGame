using ChessGame.Model;
using ChessGame.Model.MoveStrategies;

namespace ChessGame
{
    public interface IPiece
    {
        PieceType Type { get; }
        Player Color { get; }
        bool HasMoved { get; set; }
        IPiece Copy();
    }
}