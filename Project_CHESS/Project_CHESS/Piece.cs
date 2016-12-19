using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CHESS
{
    public class Piece
    {
        public string symbol;
        public string name;
        public string color;
        public bool firstMove;
    }
    

    // black pieces
    class BPawn : Piece
    {

        public BPawn()
        {
            symbol = "B_Pawn";
            name = "pawn";
            color = "black";
            firstMove = false;
        }
    }
    class BRook : Piece
    {
        public BRook()
        {
            symbol = "B_Rook";
            name = "rook";
            color = "black";
        }
    }
    class BKnight : Piece
    {
        public BKnight()
        {
            symbol = "B_Knig";
            name = "knight";
            color = "black";
        }
    }
    class BBishop : Piece
    {
        public BBishop()
        {
            symbol = "B_Bish";
            name = "bishop";
            color = "black";
        }
    }
    class BQueen : Piece
    {
        public BQueen()
        {
            symbol = "B_Quee";
            name = "queen";
            color = "black";
        }
    }
    class BKing : Piece
    {
        public bool moved;
        public BKing()
        {
            symbol = "B_King";
            name = "king";
            color = "black";
            moved = false;
        }
    }


    //white pieces
    class WPawn : Piece
    {
        public bool enpassante;
        public WPawn()
        {
            symbol = "W_Pawn";
            name = "pawn";
            color = "white";
            enpassante = false;
        }
    }
    class WRook : Piece
    {
        public WRook()
        {
            symbol = "W_Rook";
            name = "rook";
            color = "white";
        }
    }
    class WKnight : Piece
    {
        public WKnight()
        {
            symbol = "W_Knig";
            name = "Knight";
            color = "white";
        }
    }
    class WBishop : Piece
    {
        public WBishop()
        {
            symbol = "W_Bish";
            name = "bishop";
            color = "white";
        }
    }
    class WQueen : Piece
    {
        public WQueen()
        {
            symbol = "W_Quee";
            name = "queen";
            color = "white";
        }
    }
    class WKing : Piece
    {
        public bool moved;
        public WKing()
        {
            symbol = "W_King";
            name = "king";
            color = "white";
            moved = false;
        }
    }

}
