using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        int _firstCard = 0;
        bool _isPlaying = true;
        string _guess = "";
        int _totalScore = 300;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {

            Card card = new Card();
            _firstCard = card.value;

        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoOutputs();
                DoUpdates();
            }
        }

        /// <summary>
        /// Asks the user if they want to play.
        /// </summary>
        public void GetInputs()
        {
            Console.WriteLine("");
            Console.Write("Play Again? [y/n] ");
            string drawCard = Console.ReadLine();
            _isPlaying = (drawCard == "y");
        }

        /// <summary>
        /// Updates the player's score and the card for the next round. 
        /// If the player's guess was correct they are awarded 100 points, if they are incorrect they lose 75 points.
        /// </summary>
        public void DoUpdates()
        {
            if (!_isPlaying)
            {
                return;
            }

            Card card = new Card();
            int newCard = card.value;

            Console.WriteLine($"The next card is: {newCard}");

            // awards points if guess is correct

            if (_firstCard > newCard && _guess == "l" || _firstCard < newCard && _guess == "h")
            {
                _totalScore += 100;
            Console.WriteLine($"Your guess was correct!");

            }
            else
            {
                _totalScore -= 75;
            Console.WriteLine($"Your guess was incorrect");

            }
            
            Console.WriteLine($"Your score is now: {_totalScore}");
        
            // if score is 0, end the game
            _isPlaying = (_totalScore > 0);

            // update so newCard is now the _firstCard for the next round
            _firstCard = newCard;

        }

        /// <summary>
        /// Displays the first card and asks the player for their guess of the next card
        /// </summary>
        public void DoOutputs()
        {
            if (!_isPlaying)
            {
                return;
            }
            Console.WriteLine($"The card is: {_firstCard}");
            Console.Write($"Higher or lower? (h/l): ");
            _guess = Console.ReadLine();

        }
    }
}