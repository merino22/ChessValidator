using ChessValidator.core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Entities
{
    public class Board
    {
        private Tile[,] _board;
        private List<string> _errors;
        private List<string> _movementList;

        public Board(List<string> initialPositions)
        {
            this._board = new Tile[8,8]
            {
                { new Tile("a8"), new Tile("b8"), new Tile("c8"), new Tile("d8"), new Tile("e8"), new Tile("f8"), new Tile("g8"), new Tile("h8")},
                { new Tile("a7"), new Tile("b7"), new Tile("c7"), new Tile("d7"), new Tile("e7"), new Tile("f7"), new Tile("g7"), new Tile("h7")},
                { new Tile("a6"), new Tile("b6"), new Tile("c6"), new Tile("d6"), new Tile("e6"), new Tile("f6"), new Tile("g6"), new Tile("h6")},
                { new Tile("a5"), new Tile("b5"), new Tile("c5"), new Tile("d5"), new Tile("e5"), new Tile("f5"), new Tile("g5"), new Tile("h5")},
                { new Tile("a4"), new Tile("b4"), new Tile("c4"), new Tile("d4"), new Tile("e4"), new Tile("f4"), new Tile("g4"), new Tile("h4")},
                { new Tile("a3"), new Tile("b3"), new Tile("c3"), new Tile("d3"), new Tile("e3"), new Tile("f3"), new Tile("g3"), new Tile("h3")},
                { new Tile("a2"), new Tile("b2"), new Tile("c2"), new Tile("d2"), new Tile("e2"), new Tile("f2"), new Tile("g2"), new Tile("h2")},
                { new Tile("a1"), new Tile("b1"), new Tile("c1"), new Tile("d1"), new Tile("e1"), new Tile("f1"), new Tile("g1"), new Tile("h1")}
            };
            this._movementList = initialPositions;
            SetInitialPositions();
        }

        public Tile[,] GetBoard()
        {
            return this._board;
        }

        public void SetInitialPositions()
        {
            List<string> messages = new List<string>();
            MovementParser parser = new MovementParser();
            foreach (var position in this._movementList)
            {
                //Console.WriteLine(position);
                Piece newPiece = parser.GetNewPiece(position);
                Movement tmpMovement = parser.GetNewMovement(position);
                messages.Add(SetTile(newPiece, tmpMovement));
            }

            foreach(var message in messages)
            {
                Console.WriteLine(message);
            }
        }

        public string SetTile(Piece piece, Movement movement)
        {
            Tile[,] cBoard = this.GetBoard();
            //List<string> messages = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(cBoard[i, j].GetCoordinate() == piece.GetPosition())
                    {
                        if(piece.GetCode() == 'T')
                        {
                            if (movement._startMove[0] == movement._endMove[0] && (int.Parse(movement._endMove[1].ToString()) > 0 && int.Parse(movement._endMove[1].ToString()) < 9) && (int.Parse(movement._startMove[1].ToString()) > 0 && int.Parse(movement._startMove[1].ToString()) < 9))
                            {
                                return "Movement" + piece.GetCode() + movement._startMove[0] + "-" + movement._startMove[1] + " is valid.";
                            }
                            else if (movement._startMove[1] == movement._endMove[1])
                            {
                                return "Movement" + piece.GetCode() + movement._startMove[0] + "-" + movement._startMove[1] + " is valid.";
                            }
                            else
                            {
                                return "Movement" + piece.GetCode() + movement._startMove[0] + "-" + movement._startMove[1] + " is invalid.";
                            }
                        }
                        else if(piece.GetCode() == 'C')
                        {
                            return "HEHE";
                        }
                        else
                        {
                            if (movement._startMove[0] == movement._endMove[0] && (int.Parse(movement._endMove[1].ToString()) > 0 && int.Parse(movement._endMove[1].ToString()) < 9) && ((int.Parse(movement._endMove[1].ToString()) - int.Parse(movement._startMove[1].ToString())) == 1))
                            {
                                return "Movement" + piece.GetCode() + movement._startMove[0] + "-" + movement._startMove[1] + " is valid.";
                            }
                            else
                            {
                                return "Movement" + piece.GetCode() + movement._startMove[0] + "-" + movement._startMove[1] + " is invalid.";
                            }
                        }
                        //cBoard[i, j].SetFree(!cBoard[i,j].GetFree());
                        //cBoard[i, j].SetPiece(piece);
                    }
                }
            }
            return "ERROR: MOVEMENT NOT FOUND";
        }
        
        private List<string> GetPossibleMovements(Piece piece)
        {
            List<string> possibleMoves = new List<string>();
            Tile[,] cBoard = this.GetBoard();
            int[,] coords = GetPosition(piece.GetPosition());

            switch (piece.GetCode())
            {
                case 'C':
                    string pos = cBoard[coords[0, 0] + 2, coords[0, 1] + 1].GetCoordinate();
                    string pos2 = cBoard[coords[0, 0] + 2, coords[0, 1] - 1].GetCoordinate();
                    string pos3 = cBoard[coords[0, 0] - 2, coords[0, 1] + 1].GetCoordinate();
                    string pos4 = cBoard[coords[0, 0] - 2, coords[0, 1] - 1].GetCoordinate();
                    string pos5 = cBoard[coords[0, 0] + 1, coords[0, 1] + 2].GetCoordinate();
                    string pos6 = cBoard[coords[0, 0] + 1, coords[0, 1] - 2].GetCoordinate();
                    string pos7 = cBoard[coords[0, 0] - 1, coords[0, 1] + 2].GetCoordinate();
                    string pos8 = cBoard[coords[0, 0] - 1, coords[0, 1] - 2].GetCoordinate();
                    break;
                case 'T':

                    break;
                default:

                    break;
            }
            return possibleMoves;
        }

        private int[,] GetPosition(string pos)
        {
            Tile[,] cBoard = this.GetBoard();
            int[,] position = new int[1,2];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(cBoard[i,j].GetCoordinate() == pos)
                    {
                        position[0, 0] = i;
                        position[0, 1] = j;
                        break;
                    }
                }
            }
            return position;
        }

        public void GetMoves(int[,] coords)
        {
            MovementParser parser = new MovementParser();
            foreach (var movement in this._movementList)
            {
                Piece tmpPiece = parser.GetNewPiece(movement);
                Movement tmpMovement = parser.GetNewMovement(movement);
            }
        }

        public void printBoard()
        {
            Tile[,] cBoard = this.GetBoard();

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.Write(cBoard[i, j].GetPiece().GetName());
                    Console.Write(' ');
                }
                Console.Write('\n');
            }
        }
    }
}
