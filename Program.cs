using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            // Show empy chess board.
            PrintBoard(myBoard);
            PrintSeparator();

            // Ask user x and y.
            Cell currentCell = SetCurrentCell();
            currentCell.CurrentlyOccupied = true;
            PrintSeparator();

            // Calculate all legal moves for the piece.
            myBoard.MarkLegalMoves(currentCell, "Knight");

            // Print the chess board.
            PrintBoard(myBoard);
            PrintSeparator();

            // Whait for another input.
            Console.ReadLine();

        }

        private static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("======================");
        }

        private static Cell SetCurrentCell()
        {
            // Ask for row and column coordinate for the piece and return a cell location.
            //private const SIZE = 7;

            // Row coordinate.
            Console.WriteLine("Enter current row number");
            int currentRow = int.Parse(Console.ReadLine());

            // Column coordinate.
            Console.WriteLine("Enter current column number");
            int currentColumn = int.Parse(Console.ReadLine());

            //TODO handle invalid input

            myBoard.Grid[currentRow, currentColumn].CurrentlyOccupied = true;

            return myBoard.Grid[currentRow, currentColumn];
        }

        private static void PrintBoard(Board myBoard)
        {
            // Print chessbpard in console.
            // X for piece location, + for legal move, 0 for empty square.
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell cell = myBoard.Grid[i, j];

                    if (cell.CurrentlyOccupied == true)
                    {
                        Console.Write("X");
                    }
                    if (cell.CurrentlyOccupied == false && cell.LegalNextMove == false)
                    {
                        Console.Write(".");
                    }
                    if (cell.CurrentlyOccupied == false && cell.LegalNextMove == true)
                    {
                        Console.Write("+");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
