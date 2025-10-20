using System;
using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BattleShip
{
    public class Game
    {
        private int totalShips;
        Ship[] battleShipInput = new Ship[6];

        Ship Destroyer1 = new Ship(2, "Destroyer");
        Ship Destroyer2 = new Ship(2, "Destroyer2");
        Ship Submarines1 = new Ship(3, "Submarines");
        Ship Submarines2 = new Ship(3, "Submarines2");
        Ship BattleShip = new Ship(4, "BattleShip");
        Ship Carrier = new Ship(5, "Carrier");

        private bool cheatsOn;

        GameBoard playingField;
     
        Random randy = new Random();

        public void GameBattleShip()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("------------            ------------");
            Console.WriteLine("-----------  WELCOME TO  -----------");
            Console.WriteLine("----------  BATTLE SHIP!  ----------");
            Console.WriteLine("------------            ------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("------------------------------------");


            cheatsOn = AskUserForCheats();
            playingField = new GameBoard(10, 10);
            playingField.DefaultBoard();
            playingField.DisplayBoard();
            ShipInside(); // sets ships into the array
            totalShips = battleShipInput.Length;
            FillBoardRandom();

            if (cheatsOn == true)
            {

                playingField.DisplayBoard();

            }
            gamePlay();
        }

        public void ShipInside()
        {

            battleShipInput[0] = Destroyer1;
            battleShipInput[1] = Destroyer2;
            battleShipInput[2] = Submarines1;
            battleShipInput[3] = Submarines2;
            battleShipInput[4] = BattleShip;
            battleShipInput[5] = Carrier;

        }

        public void gamePlay()
        {
            /// make sure if there is a hit on the board and a mis or if they already picked the spot
            do
            {
                Console.WriteLine("LINE 60 " + AllShipsDestroyed());
                while (!AllShipsDestroyed())
                {
                    Console.ReadLine();
                    Console.Write("Rows Number?: ");
                    string rowYTemp = Console.ReadLine();
                    int rowY = Int32.Parse(rowYTemp);

                    Console.Write("Cols Number?: ");
                    string colXTemp = Console.ReadLine();
                    int colX = Int32.Parse(colXTemp);

                    ///this will take in the row and columns entered by the usre and check to see if there is a hit miss or already picked spot
                    if (playingField.BoardChars[rowY, colX] >= 'A' && playingField.BoardChars[rowY, colX] <= 'A' + battleShipInput.Length)
                    {
                        battleShipInput[playingField.BoardChars[rowY, colX] - 'A'].decrementLength();
                        playingField.BoardChars[rowY, colX] = 'X';
                        Console.WriteLine($"Row :{rowY} Col:{colX} GOT A HIT!!!");

                    }
                    else if (playingField.BoardChars[rowY, colX] == 'X' || playingField.BoardChars[rowY, colX] == 'O')
                    {

                        Console.WriteLine($"Row :{rowY} Col:{colX} SAME SPOT HIT");

                    }

                    else if (playingField.BoardChars[rowY, colX] == '-')
                    {

                        playingField.BoardChars[rowY, colX] = 'O';
                        Console.WriteLine($"Row :{rowY} Col:{colX} MISS");
                    }

                    playingField.DisplayBoardHidden(rowY, colX);
                    //playingField.DisplayBoard();
                    ///THis will display the board and its cheats around the game
                }
               
            } while (PlayAgain());

            Console.WriteLine("Thanks for playing");

        }
        
        public bool AllShipsDestroyed()
        {
            int totalSpacesLeft = 0;

            for (int i = 0; i < totalShips; i++)
            {

                totalSpacesLeft += battleShipInput[i].getLength();
                /// total spaces that have all been hit will continue to add up this method
            }

            return (totalSpacesLeft <= 0) ? true : false;
            /// if this method has reach 0 then the game should be over and return true

        }

        public bool AskUserForCheats()
        {

            Console.WriteLine("Would you like cheats Enabled? Yes for cheats");
            string input = Console.ReadLine();
            Console.WriteLine(input);
            ///the input of the it is just being enabled the cheats
            if (input == "Yes")

            {

                return true;
                ///this is to show if they would like cheats to be allowed
            }
            else if(input == "No")
            {

                return false;

            }
            ///this is just to show cheats to show people who dont want to play fair and square it will return a bool and display ships

            else
            {

                return false;

            }
        }
        
        public bool PlayAgain()
        {

            string input = "";

            do {
                Console.Write("Play Again? type Yes or No (Exact)");
                input = Console.ReadLine();

            } while (input != "Yes" && input != "No");
            ///this is validation to make sure the think the enter is either yes or no
            if (input == "Yes")
            {

                GameBattleShip();

                return true;

            }///if its true the the game will go again

            else if (input == "No")
            {
                return false;

            }

            else
            {

                return false;
            }
            ///if not then the game will end
        }

        public bool isIntersectingWithShips(int rowY, int columnX, int vertical, int shipsPlaced)
        {



            for (int iteratior = (vertical == 0) ? rowY : columnX; (vertical == 0) ? iteratior < rowY + battleShipInput[shipsPlaced].getLength() : iteratior < columnX + battleShipInput[shipsPlaced].getLength(); iteratior++)
            {
                ///this for loop is running through the length of each ship that is being place length and it is continously going when a ship comes in
                ///it uses the length of the ships.

                if (playingField.BoardChars[(vertical == 0) ? iteratior : rowY, (vertical == 0) ? columnX : iteratior] >= 'A' && playingField.BoardChars[(vertical == 0) ? iteratior : rowY, (vertical == 0) ? columnX : iteratior] <= 'A' + battleShipInput.Length - 1 ){

                    ///this is to see if there is already a battle ship in the board and making sure to return if there is the true is being returned

                    return true;
            }

            }

            return false;
            ///if there is no ships on the spot then it will just send false and continue to place ship parts

        }
        


            public void FillBoardRandom()
            {

                int shipsPlaced = 0;
                   
                while (shipsPlaced < totalShips)
                {

                ///This while loop will continue to place ships into the board and make sure there arent any ships around it by first grabbing a random row and colmn
                ///and putting a value on the board and then making sure it does not already have a battle ship there and randomly selects if its vertical or horizontal
                    int rowY = randy.Next(0, playingField.BoardChars.GetLength(0) - battleShipInput[shipsPlaced].getLength() + 1);
                    int columnX = randy.Next(0, playingField.BoardChars.GetLength(1) - battleShipInput[shipsPlaced].getLength() + 1);
                    int vertical = randy.Next(0, 2);

                    if (!isIntersectingWithShips(rowY, columnX, vertical, shipsPlaced)) {

                        for(int iteratior = (vertical==0)? rowY:columnX; (vertical == 0)?iteratior < rowY + battleShipInput[shipsPlaced].getLength() : iteratior < columnX + battleShipInput[shipsPlaced].getLength(); iteratior++) {
                        ///for loop is checking to see if its vertical and uses different rows and columns to add on the next ships
                        playingField.setPositon((vertical == 0) ? iteratior : rowY, (vertical == 0) ? columnX : iteratior, (char)(shipsPlaced + 'A'));
                        ///this is just going to the set posiotion method and placing the points on the board and it takes the row colomn and ships placed
                    }

                    shipsPlaced++;
                    ///this will grow until it reaches all the ships
                    }
                }

            }

        }

    }