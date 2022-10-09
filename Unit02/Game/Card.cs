using System;


namespace Unit02.Game
{
    /// <summary>
    /// A card that has a value of 1-13.
    /// 
    /// The responsibility of Card is to keep track of its currently drawn value.
    /// </summary> 
    public class Card
    {
        public int value;
        
        /// <summary>
        /// Constructs a new instance of Card.
        /// </summary>
        public Card()
        {
            Draw();
        }

        /// <summary>
        /// Generates a new random value.
        /// </summary>
        public void Draw()
        {
            // creates the roll
            Random random = new Random();
            value = random.Next(1, 14);

        }
    }
}