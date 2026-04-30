using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class CompositeMoveStrategy : IMoveStrategy
    {
        private readonly IEnumerable<IMoveStrategy> _strategies;

        public CompositeMoveStrategy(IEnumerable<IMoveStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IEnumerable<Move> GetMoves(Position from, IBoard board, Piece piece)
        {
            return _strategies.SelectMany(s => s.GetMoves(from, board, piece));
        }
    }
}
