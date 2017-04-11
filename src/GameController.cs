using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// The GameController is responsible for controlling the game,
    /// managing user input, and displaying the current state of the
    /// game.
    /// </summary>
    class GameController
    {
        private BattleshipsGame _theGame;
        private Player _human;
        private AIPlayer _ai;

        private Stack<GameState> _state = new Stack<GameState>();
        private AIOption _aiSetting;

        /// <summary>
        /// Returns the current state of the game, indicating which screen is
        /// currently being used
        /// </summary>
        /// <value>The current state</value>
        /// <returns>The current state</returns>
        public GameState CurrentState { get { return _state.Peek(); } }

        /// <summary>
        /// Returns the human player.
        /// </summary>
        /// <value>the human player</value>
        /// <returns>the human player</returns>
        public Player HumanPlayer { get { return _human; } }

        /// <summary>
        /// Returns the computer player.
        /// </summary>
        /// <value>the computer player</value>
        /// <returns>the conputer player</returns>
        public Player ComputerPlayer { get { return _ai; } }
    }
}
