using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public interface ISubPieceFactory
    {
        PieceType Type { get; }
        IPiece Create(Player color);
    }
}
