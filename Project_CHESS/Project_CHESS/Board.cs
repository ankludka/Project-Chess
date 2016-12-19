using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CHESS
{
    public class Board
    {
        public Piece[,] board = new Piece[9, 9];
        string playerColor;

        public void show() //Wyswietlenie szachowinicy
        {
            Console.Clear();
            Console.WriteLine("Tura gracza: " + playerColor + "\n");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                        if (i == 0 && j == 0) Console.Write("    ");
                        else if (i == 0) Console.Write(j.ToString() + "      ");
                        else if (j == 0) Console.Write("" + i.ToString() + " ");
                        else if (board[i, j] == null) Console.Write("(    ) ");
                        else Console.Write(board[i, j].symbol + " ");
                }
                Console.WriteLine();
            }
        }
        public void askForColor() //Wczytanie koloru gracza
        {
            string tmp;
            Console.WriteLine("\nChcesz grac bialymi czy czarnymi? (W/B)");
            tmp = Console.ReadLine();
            if (tmp == "b" || tmp == "B") playerColor = "black";
            else playerColor = "white";
        }
        public void askForMove() //Wczytanie pozycji poczatkowej i koncowej figury z konsoli;
        {
            int a, b, c, d;
            try
            {
                Console.WriteLine("Wiersz poczatkowy:");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Kolumna poczatkowa:");
                b = int.Parse(Console.ReadLine());
                Console.WriteLine("Wiersz docelowy:");
                c = int.Parse(Console.ReadLine());
                Console.WriteLine("Kolumna docelowa:");
                d = int.Parse(Console.ReadLine());
                checkMove(a, b, c, d);
            }
            catch
            {
                Console.WriteLine("wtf?");
                Console.ReadKey();
            }
            
        }
        void changeColor ()
        {
            if (playerColor == "white") playerColor = "black";
            else playerColor = "white";
        }

        public bool checkPlayerColor(int a, int b) //sprawdza kolor figury na polu z ktorego gracz chce sie ruszyc
        {
            if (board[a, b].color == playerColor) return true;
            else return false;
        }
        public bool checkDestColor(int c, int d) //sprawdza kolor figury na polu docelowym
        {
            if (board[c, d].color != playerColor) return true;
            else return false;
        }
        public bool checkIfEmpty(int a, int b) //sprawdza czy pole jest puste
        {
            if (board[a, b] == null) return true;
            else return false;
        }
        public bool checkIfOnTable (int a, int b, int c, int d)
        {
            if (a < 9 && a > 0 && b < 9 && b > 0 && c < 9 && c > 0 && d < 9 && d > 0)
            {
                return true;
            }
            else return false;
        }

        public void makeMove(int a, int b, int c, int d) //zrobienie ruchu
        {
            board[c, d] = board[a, b];
            board[a, b] = null;
            changeColor();
        }

        public bool blackPawnMove(int a, int b, int c, int d)
        {
            if (c - a == 1 && b - d == 0 && board[c, d] == null) { board[a, b].firstMove = true; return true; }
            else if (c - a == 2 && b - d == 0 && !board[a, b].firstMove && board[c, d] == null) { board[a, b].firstMove = true; return true; }
            else return blackPawnAttack(a, b, c, d);
        }
        public bool blackPawnAttack(int a, int b, int c, int d)
        {
            if (c - a == 1 && (b - d == 1 || d - b == 1) && board[c, d] != null && board[c, d].color != playerColor) return true;
            else return false;
        }

        public bool rookMove(int a, int b, int c, int d)
        {
            if (a - c != 0 && b - d == 0) // pionowo
            {
                if (c > a) // pionowo  w dol
                {
                    if (c - a > 1)
                    {
                        for (int i = a + 1; i < c; i++)
                        {
                            if (board[i, b] != null) return false;
                        }
                        return true;
                    }
                    else return true;
                }
                else // pionowo w gore
                {
                    if (a - c > 1)
                    {
                        for (int i = c + 1; i < a; i++)
                        {
                            if (board[i, b] != null) return false;
                        }
                        return true;
                    }
                    else return true;
                }
            }
            else if (a - c == 0 && b - d != 0) //poziomo
            {
                if (b > d) // poziomo  w lewo
                {
                    if (b - d > 1)
                    {
                        for (int i = b - 1; i > d; i--)
                        {
                            if (board[a, i] != null) return false;
                        }
                        return true;
                    }
                    else return true;
                }
                else // poziomo w prawo
                {
                    if (d - b > 1)
                    {
                        for (int i = b + 1; i < d; i++)
                        {
                            if (board[a, i] != null) return false;
                        }
                        return true;
                    }
                    else return true;
                }
            }
            else return false;
        }
        public bool knightMove(int a, int b, int c, int d)
        {
            return true;
        }

        public bool whitePawnAttack(int a, int b, int c, int d)
        {
            if (a - c == 1 && (b - d == 1 || d - b == 1) && board[c, d] != null && board[c, d].color != playerColor) return true;
            else return false;
        }
        public bool whitePawnMove(int a, int b, int c, int d)
        {
            if (a - c == 1 && b - d == 0 && board[c, d] == null) { board[a, b].firstMove = true; return true; }
            else if (a - c == 2 && b - d == 0 && !board[a, b].firstMove && board[c, d] == null) { board[a, b].firstMove = true; return true; }
            else return whitePawnAttack(a, b, c, d);
        }

        public void wrongMove()
        {
            Console.WriteLine("\nZly ruch!\n");
            Console.ReadKey();
        }

        public void checkMove(int a, int b, int c, int d) //sprawdzenie ruchu
        {
            if (checkIfOnTable(a, b, c, d) && !checkIfEmpty(a, b) && checkPlayerColor(a, b) && checkIfEmpty(c, d) || checkDestColor(c, d))
            {
                
                switch (board[a, b].symbol)
                {
                    case "B_Pawn":
                        {
                            if (blackPawnMove(a, b, c, d)) makeMove(a, b, c, d);
                            else wrongMove();
                        } break;
                        
                    case "W_Pawn":
                        {
                            if (whitePawnMove(a, b, c, d)) makeMove(a, b, c, d);
                            else wrongMove();
                        } break;
                    case "B_Rook":
                        {
                            if (rookMove(a, b, c, d)) makeMove(a, b, c, d);
                            else wrongMove();
                        } break;
                    case "W_Rook":
                        {
                            if (rookMove(a, b, c, d)) makeMove(a, b, c, d);
                            else wrongMove();
                        } break;
                    case "B_Knig":
                        {
                            if (knightMove(a, b, c, d)) makeMove(a, b, c, d);
                            else wrongMove();
                        } break;
                    case "W_Knig":
                        {
                            if (knightMove(a, b, c, d)) makeMove(a, b, c, d);
                            else wrongMove();
                        }
                        break;

                }
            }


      








            else
            {
                wrongMove();
            }
        } 

        public Board () //inicjalizacja szachownicy, stan poczatkowy
        {
            //czarna strona
            board[1, 1] = new BRook();
            board[1, 2] = new BKnight();
            board[1, 3] = new BBishop();
            board[1, 4] = new BQueen();
            board[1, 5] = new BKing();
            board[1, 6] = new BBishop();
            board[1, 7] = new BKnight();
            board[1, 8] = new BRook();
            
            board[2, 1] = new BPawn();
            board[2, 2] = new BPawn();
            board[2, 3] = new BPawn();
            board[2, 4] = new BPawn();
            board[2, 5] = new BPawn();
            board[2, 6] = new BPawn();
            board[2, 7] = new BPawn();
            board[2, 8] = new BPawn();

            //biala strona
            board[8, 1] = new WRook();
            board[8, 2] = new WKnight();
            board[8, 3] = new WBishop();
            board[8, 4] = new WQueen();
            board[8, 5] = new WKing();
            board[8, 6] = new WBishop();
            board[8, 7] = new WKnight();
            board[8, 8] = new WRook();

            board[7, 1] = new WPawn();
            board[7, 2] = new WPawn();
            board[7, 3] = new WPawn();
            board[7, 4] = new WPawn();
            board[7, 5] = new WPawn();
            board[7, 6] = new WPawn();
            board[7, 7] = new WPawn();
            board[7, 8] = new WPawn();
            playerColor = "white";

        }
    }
}
