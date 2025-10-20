// See https://aka.ms/new-console-template for more information

/// <summary>
/// Discription is that this is a game where you can try to hit the ships on the board
/// and try not to use the cheats and see how fast you can get them or how long it takes you.
/// It has random spots picked and you have to try to hit all the ships and it will ask if you would
/// like to play again. if you do it will start the game over.
/// </summary>

using System;
using BattleShip;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            Game sum = new Game();
            sum.GameBattleShip();
            ///this class will house all of the positions, choices, and display to run the game
        }
    }
}




