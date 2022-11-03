namespace Unit03.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Word _word = new Word();
        private bool _isPlaying = true;
        private Jumper _jumper = new Jumper();
        private TerminalService _terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by displaying the first hint and 
        /// the Jumper then running the main game loop.
        /// </summary>
        public void StartGame()
        {

            while (_isPlaying)
            {
                DoOutputs();
                DoUpdates();
            }
            // this calls DoOutputs one more time after the user is done playing so 
            // that we can display the hint and the jumper.
            DoOutputs();

        // gives the game over message depending on if they guessed the word or died.
            if (_word.IsFound() == true)
            {
                _terminalService.WriteText("Congrats! You guessed the Word!\n");
            }
            if (_jumper.IsDead() == true)
            {
                _terminalService.WriteText("Sorry! You died before you could guess the word. \n");
            }
        }

        /// <summary>
        /// Gets the players letter guess.
        /// </summary>
        public string GetInputs()
        {
            // _terminalService.WriteText(_word._pickWord.ToString());
            string letter = _terminalService.ReadText("\nEnter a letter (a-z): ");
            return letter;
        }

        /// <summary>
        /// Checks the letter that was guessed. 
        ///Cuts a line of parachute if guess isn't correct, 
        ///and checks to see if the game should continue being played.
        /// </summary>
        public void DoUpdates()
        {  
            if(!_word.CheckGuess(GetInputs()))
            {
                _jumper.CutLine();
            }
            _isPlaying = (!_word.IsFound());
            if (_isPlaying == true)
                _isPlaying = (!_jumper.IsDead()); 

        }

        /// <summary>
        /// Provides a hint for user and displayes the Jumper and its parachute.
        /// </summary>
        private void DoOutputs()
        {
            _terminalService.WriteText(_word.GetHint()); 
            _terminalService.WriteText(" ");
           _terminalService.WriteText(_jumper.GetChute());
            
        }
    }
}