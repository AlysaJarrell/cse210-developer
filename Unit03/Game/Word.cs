using System;
using System.Collections.Generic;

namespace Unit03.Game 
{
    /// <summary>
    /// <para>The word that is to be guessed by the user.</para>
    /// <para>
    /// The responsibility of Word is to keep track of all possible words and which one is chosen for the round.
    /// </para>
    /// </summary>
    public class Word
    {
        private string _secretWord;
        private List<string> _guesses = new List<string>();


        /// <summary>
        /// Constructs a new instance of Word. 
        /// </summary>
        public Word()
        {
            _secretWord = GetWord();
        }    

        /// <summary>
        /// Gets a random word for the game.
        /// </summary>
        /// <returns>A new word.</returns>
        private string GetWord()
        {
            List<string> _words = new List<string>{"pineapple", "carrot", "taco", "monitor", "mountain", "computer", "jacket", "location", "sweater", "random", "keyboard"};
            int _length = _words.Count +1;
            Random random = new Random();
            int _pickWordIndex = random.Next(0,_length);
            string _pickword = _words[_pickWordIndex];

            return _pickword;
        }

        /// <summary>
        /// Checks if the latest guess is in the word. If it is-- add it to a list of guesses.
        /// </summary>
        /// <returns> True if guess is in the word. False if not.</returns>
        public bool CheckGuess(string letter)
        {
            if (_secretWord.Contains(letter))
            {
                _guesses.Add(letter);
                return true;
            }
            else
            {
                return false;
            }
        }
 
        /// <summary>
        /// Writes a hint for the user based off of the letters that have been guessed correctly.
        /// </summary>
        public string GetHint()
        {
            string hint = "";
            foreach (var letter in _secretWord)
            {
                if (_guesses.Contains(Char.ToString(letter)))
                    hint += $" {letter} ";
                else
                    hint += " _ ";
            }
            return hint;

        }

        ///<summary>
        /// Checks if the Word IsFound.
        ///</summary> 
        ///<returns>True when the word IsFound and ends the game.
        public bool IsFound()
        {   
            string hint = GetHint();

            if (hint.Contains("_"))
                return false;
            else
                return true;
            
        }

    }
}