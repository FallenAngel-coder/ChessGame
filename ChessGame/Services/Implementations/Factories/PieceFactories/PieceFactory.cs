using ChessGame.Services.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services
{
    public class PieceFactory : IPieceFactory
    {
        private readonly IReadOnlyDictionary<PieceType, ISubPieceFactory> _factories;

        public PieceFactory(IEnumerable<ISubPieceFactory> factories)
        {
            _factories = factories.ToDictionary(f => f.Type);
        }

        public IPiece CreatePiece(PieceType type, Player color)
        {
            if (!_factories.TryGetValue(type, out var factory))
                throw new ArgumentException($"No factory registered for {type}");

            return factory.Create(color);
        }
    }
}
