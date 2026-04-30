using ChessGame.Services.Interfaces.Utils;
using ChessGame.Services.Interfaces.Utils.PieceFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Utils.PieceFactories
{
    public class PieceFactory : IPieceFactory
    {
        private readonly Dictionary<PieceType, ISubPieceFactory> _map;

        public PieceFactory(IEnumerable<ISubPieceFactory> subFactories)
        {
            _map = subFactories.ToDictionary(x => x.Type);
        }

        public Piece CreatePiece(PieceType type, Player color)
        {
            if (!_map.TryGetValue(type, out var factory))
                throw new InvalidOperationException($"Missing factory for {type}");

            return factory.Create(color);
        }
    }
}
