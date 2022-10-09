using System;


namespace Unit02.Game
{
    /// <summary>
    /// A small cube with a different number of spots on each of its six sides.
    /// 
    /// The responsibility of Die is to keep track of its currently rolled value and the points its
    /// worth.
    /// </summary> 
    public class Card
    {
        public int value;
        
        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
        public Card()
        {
            Draw();
        }

        /// <summary>
        /// Generates a new random value and calculates the points for the die. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
        public void Draw()
        {
            // creates the roll
            Random random = new Random();
            value = random.Next(1, 14);

        }
    }
}