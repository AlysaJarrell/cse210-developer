using System;
using System.Collections.Generic;


namespace Unit03.Game 
{
    /// <summary>
    /// <para>The display of the jumper and its parachute. </para>
    /// <para> The responsibility of Jumper is to keep track of it's parachute. When the chute runs out the game is over.
    ///</summary>
    public class Jumper
    {
        private List<string> _parachute = new List<string>();

        /// <summary>
        /// Constructs a new instance of Jumper. 
        /// </summary>
        public Jumper()
        {
            BuildChute();
        }

        /// <summary>
        /// Builds the parachute in a List _parachute by adding strings for each line.
        /// </summary>
        private void BuildChute()
        {
            _parachute.Add(@"   ___   ");
            _parachute.Add(@"  /___\  ");
            _parachute.Add(@"  \   /  ");
            _parachute.Add(@"   \ /   ");
            _parachute.Add(@"    O    ");
            _parachute.Add(@"   /|\   ");
            _parachute.Add(@"   / \   ");
            _parachute.Add(@"         ");
            _parachute.Add(@" ^^^^^^^ ");

        }

        /// <summary>
        /// Returns the _parachute to be printed as strings on individual lines.
        /// </summary>
        public string GetChute()
        {
            return String.Join("\n", _parachute);
        }

        ///<summary>
        /// Removes a line of the parachute when a guess is wrong.
        ///</summary>
        public void CutLine()
        {
            _parachute.RemoveAt(0);

            if (_parachute.Count == 5)
            {
                _parachute.RemoveAt(0);
                _parachute.Insert(0, @"    X    ");
            }
        }
        

        ///<summary>
        /// Checks if the Jumper IsDead by checking if there is still parachute above it.
        ///</summary>
        ///<returns> True when there is no more parachute. Causing the game to be over. </return>
        public bool IsDead()
        {
            if (_parachute.Count > 5)
                return false;
            else
                return true;
            // if the parachute is gone IsDead == true and game should end
        }


    } 

}