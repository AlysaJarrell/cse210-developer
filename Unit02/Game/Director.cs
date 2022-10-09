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
        /// Asks the user if they want to roll.
        /// </summary>
        public void GetInputs()
        {
            Console.WriteLine("");
            Console.Write("Play Again? [y/n] ");
            string drawCard = Console.ReadLine();
            _isPlaying = (drawCard == "y");
        }

        /// <summary>
        /// Updates the player's score.
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
        

            _isPlaying = (_totalScore > 0);

            // update so newCard is now the _firstCard for the next roundl
            _firstCard = newCard;

        }

        /// <summary>
        /// Displays the dice and the score. Also asks the player if they want to roll again. 
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