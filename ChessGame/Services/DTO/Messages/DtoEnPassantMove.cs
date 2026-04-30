using ChessGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.DTO.Messages
{
    [DtoType(DtoType.EnPassant)]
    public class DtoEnPassantMove : IDtoMessage
    {
        public DtoType MessageType => DtoType.EnPassant;
        public Position FromPos { get; set; }
        public Position ToPos { get; set; }

        public DtoEnPassantMove() { }
        public DtoEnPassantMove(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
        }
    }
}
