using ChessGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.DTO.Messages
{
    [DtoType(DtoType.DoubleMove)]
    public class DtoDoubleMove : IDtoMessage
    {
        public DtoType MessageType => DtoType.DoubleMove;
        public Position FromPos { get; set; }
        public Position ToPos { get; set; }

        public DtoDoubleMove() { }
        public DtoDoubleMove(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
        }
    }
}
