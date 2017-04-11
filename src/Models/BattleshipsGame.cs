using System;

namespace Battleship.Models
{
    /// <summary>
    /// The BattleShipsGame controls a big part of the game. It will add the two players
    /// to the game and make sure that both players ships are all deployed before starting the game.
    /// It also allows players to shoot and swap turns between player. It will also check if players 
    /// are destroyed.
    /// </summary>
    public class BattleshipsGame
    {
        /// <summary>
        /// The attack delegate type is used to send notifications of the end of an
        /// attack by a player or the AI.
        /// </summary>
        /// <param name="sender">the game sending the notification</param>
        /// <param name="result">the result of the attack</param>
        public delegate void AttackCompletedHandler(object sender, AttackResult result);

        /// <summary>
        /// The AttackCompleted event is raised when an attack has completed.
        /// </summary>
        /// <remarks>
        /// This is used by the UI to play sound effects etc.
        /// </remarks>
        public event EventHandler AttackCompleted;

        private Player[] _players = new Player[2];
        private int _playerIndex = 0;


        /// <summary>
        /// The current player.
        /// </summary>
        /// <value>The current player</value>
        /// <returns>The current player</returns>
        /// <remarks>This value will switch between the two players as they have their attacks</remarks>
        public Player Player { get { return _players[_playerIndex]; } }

        /// <summary>
        /// AddDeployedPlayer adds both players and will make sure
        /// that the AI player deploys all ships
        /// </summary>
        /// <param name="p"></param>
        public void AddDeployedPlayer(Player p)
        {
            if (_players[0] == null)
                _players[0] = p;
            else if (_players[1] == null)
                _players[1] = p;
            else
                throw new ApplicationException("You cannot add another player, the game already has two players.");
        }

        /// <summary>
        /// Assigns each player the other's grid as the enemy grid. This allows each player
        /// to examine the details visable on the other's sea grid.
        /// </summary>
        private void CompleteDeployment()
        {
            _players[0].Enemy = new SeaGridAdapter(_players[1].PlayerGrid);
            _players[1].Enemy = new SeaGridAdapter(_players[0].PlayerGrid);
        }

        internal AttackResult Shoot(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}