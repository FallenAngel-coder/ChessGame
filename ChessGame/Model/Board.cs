using ChessGame.Model.Abstractions;
using ChessGame.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Model
{
    public class Board : IBoard
    {
        public const int Size = 8;
        private readonly Piece[,] pieces = new Piece[Size, Size];
        private readonly Dictionary<Player, Position> pawnSkipPositions = new Dictionary<Player, Position>
        {
            [Player.White] = null,
            [Player.Black] = null,
        };
        private readonly IPieceCounterStrategy _pieceCounter;

        public Board(IPieceCounterStrategy pieceCounter = null)
        {
            _pieceCounter = pieceCounter ?? new StandardPieceCounter();
        }
        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Position pos]
        {
            get { return pieces[pos.Row, pos.Column]; }
            set { pieces[pos.Row, pos.Column] = value; }
        }
        public Position GetPawnSkipPosition(Player player)
        {
            return pawnSkipPositions[player];
        }

        public void SetPawnSkipPosition(Player player, Position pos)
        {
            pawnSkipPositions[player] = pos;
        }
        public bool IsInside(Position pos)
        {
            return pos.Row >= 0 && pos.Row < Size && pos.Column >= 0 && pos.Column < Size;
        }

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }

        public IEnumerable<Position> PiecePositions()
        {
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    Position pos = new Position(r, c);
                    if (!IsEmpty(pos))
                    {
                        yield return pos;
                    }
                }
            }
        }

        public IEnumerable<Position> PiecePositionsFor(Player player)
        {
            return PiecePositions().Where(pos => this[pos].Color == player);
        }

        public Position FindKing(Player player)
        {
            return PiecePositionsFor(player)
                .FirstOrDefault(pos => this[pos].Type == PieceType.King);
        }

        public IBoard Copy()
        {
            Board copy = new Board(_pieceCounter);
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (pieces[r, c] != null)
                    {
                        copy.pieces[r, c] = pieces[r, c].Copy();
                    }
                }
            }

            copy.pawnSkipPositions[Player.White] = this.pawnSkipPositions[Player.White];
            copy.pawnSkipPositions[Player.Black] = this.pawnSkipPositions[Player.Black];

            return copy;
        }

        public string GeneratePositionHash()
        {
            var sb = new StringBuilder();
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    Piece p = pieces[r, c];
                    if (p == null)
                    {
                        sb.Append('-');
                    }
                    else
                    {
                        sb.Append(p.Color == Player.White ? "W" : "B");
                        sb.Append((int)p.Type);
                    }
                }
            }
            return sb.ToString();
        }

        public ICountingPieces CountPieces()
        {
            return _pieceCounter.Count(this);
        }
    }
}