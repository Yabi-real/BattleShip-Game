using System;
namespace BattleShip
{
	public class GameBoard
	{
		
		/// <summary>
        /// ALL OF THE IMPOTANT DATA FIELDS THAT NEED TO BE FILLED
        /// </summary>

    
        private char[,] boardChars = new char[10, 10];
     
        int rowB;
        int column;

        public GameBoard(int rowMax, int colMax)
        {
            boardChars = new char[rowMax, colMax];
        }


        public char[,] BoardChars
        {
            get
            {
                return boardChars;
            }
            set
            {
                boardChars = value;
            }
        }///getter and setter for  the board 2Darray

        /// <summary>
        /// -----------------------NONE OF THE TOP IS BOTTOM FOR THE CODE---------------------------------
        /// </summary>
        public char GetUserChar(char character)
        {

            Console.WriteLine("Pick a ship to place on the board:");
            character = Console.ReadLine()[0];
            Console.WriteLine(character);
            
            return character;

        }
        public int RowPlacement(int rowB)
        {
            Console.WriteLine("Please a number for the column");
            rowB = int.Parse(Console.ReadLine());
            Console.WriteLine(rowB);
            return rowB;

        }

        public int ColumnPlacement(int column)
        {

            Console.WriteLine("Please a number for the row");
            column = int.Parse(Console.ReadLine());
            Console.WriteLine(column);
            return column;

        }
        public void setPositon(int rowY, int columnX, char val)
        {

            boardChars[rowY, columnX] = val;


        }

        public void DefaultBoard()
        {
            for (int row = 0; row < boardChars.GetLength(0); row++)
            {
                for (int col = 0; col < boardChars.GetLength(1); col++)
                {
                    boardChars[row, col] = '-';
                }
            }
        }

        public void SearchAndDestroy()

        {

            char searchChar = 'a';
            char replaceChar = 'a';

            searchChar = GetUserChar(searchChar);
            replaceChar = GetUserChar(replaceChar);

            for (int row = 0; row < boardChars.GetLength(0); row++)
            {
                for (int col = 0; col < boardChars.GetLength(1); col++)
                {                    if (boardChars[rowB, column] == searchChar)
                    {
        
                        boardChars[rowB, column] = replaceChar;

                    }

                }

            }

        }
/// <summary>
/// -----------------------NONE OF THE TOP IS USEFUL FOR THE CODE---------------------------------
/// </summary>
        public void DisplayBoard()
		{
            ///This is just to display the board and the rows and columns the user can choose from
            for (int row = 0; row < boardChars.GetLength(1); row++)
            {
                Console.Write($"   C{row}");
            }
            for (int row = 0; row < boardChars.GetLength(0); row++) {

                Console.Write("\n");
                Console.Write($"R{row}");

                for (int col = 0; col < boardChars.GetLength(1); col++)
                {
                    Console.Write($"| { boardChars[row, col] } |");
            }
                Console.WriteLine();
        }

            Console.Write("|-");
            for (int dash = 0; dash < boardChars.GetLength(1) * 4; dash++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-");

        }

        public void DisplayBoardHidden(int row,int col)
        {
            ///This is just to display the board and the rows and columns the user can choose from
            for (row = 0; row < boardChars.GetLength(1); row++)
            {
                Console.Write($"   C{row}");
            }
            for (row = 0; row < boardChars.GetLength(0); row++)
            {

                Console.Write("\n");
                Console.Write($"R{row}");

                for ( col = 0; col < boardChars.GetLength(1); col++)
                {
                    if (boardChars[row, col] == 'X' || boardChars[row, col] == 'O' || boardChars[row, col] == '-') 
                    {
                        Console.Write($"| {boardChars[row, col]} |");
                    }
                    else
                    {
                        Console.Write($"| - |");
                    }

                }
                Console.WriteLine();
            }

            Console.Write("|-");
            for (int dash = 0; dash < boardChars.GetLength(1) * 4; dash++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-");

        }

    }


}

