using System;
namespace BattleShip
{
	public class Ship
	{
		int bowX;
		int bowY;
		int length;
		String name;

		public Ship(int inComingLength, String inComingName)
		{

			length = inComingLength;

			name = inComingName;
			///this comstructor houses all of the ships incoming points

		}
		public int getLength(){

			return length;
			///getter for the length to be set and grabbed in other classes
		}

		public void decrementLength()
		{
			if (length > 0)
			{
				length--;
			}
			///this is just used for the length decrement to end the game if all the ships have been it. every
			///time the ship has been hit then the ships length goes down.
		}
		public String getName()
		{

			return name;
			///getter for the name but this has not been used but it will 
		}

	}
}

