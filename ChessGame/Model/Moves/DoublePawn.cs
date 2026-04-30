using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.Moves
{
    public class DoublePawn : Move
    {
        public override MoveType Type => MoveType.DoublePawn;

        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly Position _skippedPos;
        public DoublePawn(Position fromPos, Position toPos)
        {
            FromPos = fromPos;
            ToPos = toPos;
            _skippedPos = new Position((fromPos.Row + toPos.Row) / 2, fromPos.Column);
        }

        public override void Execute(IBoard board)
        {
            Player player = board[FromPos].Color;
            board.SetPawnSkipPosition(player, _skippedPos);
        }
    }
}
