using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class PawnForwardStrategy : MoveStrategyBase<Pawn>
    {
        protected override IEnumerable<Move> GetMoves(Position from, IBoard board, Pawn pawn)
        {
            var moves = new List<Move>();
            var player = pawn.Color;
            var forward = player.Forward();

            var oneStep = from + forward;

            if (board.IsEmpty(oneStep))
            {
                moves.Add(new NormalMove(from, oneStep));
            }

            return moves;
        }
    }
}
