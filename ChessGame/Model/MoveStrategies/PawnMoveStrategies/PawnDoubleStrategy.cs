using ChessGame.Model.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.MoveStrategies
{
    public class PawnDoubleStrategy : MoveStrategyBase<Pawn>
    {
        protected override IEnumerable<Move> GetMoves(Position from, IBoard board, Pawn pawn)
        {
            var player = pawn.Color;
            var forward = player.Forward(); 

            Position twoStep = from + forward + forward;

            if (!board.IsInside(twoStep) || !board.IsEmpty(twoStep))
                yield break;

            if (!pawn.HasMoved)
                yield return new DoublePawn(from, twoStep);
        }
    }
}
