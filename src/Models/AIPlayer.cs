using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace Battleship.Models
{
    /// <summary>
    /// The AIPlayer is a type of player. It can readomly deploy ships, it also has the
    /// functionality to generate coordinates and shoot at tiles
    /// </summary>
    abstract class AIPlayer : Player
    {
        /// <summary>
        /// Location can store the location of the last hit made by an
        /// AI Player. The use of which determines the difficulty.
        /// </summary>
        protected class Location
        {
            private int _row;
            private int _column;

            /// <summary>
            /// The row of the shot
            /// </summary>
            /// <value>The row of the shot</value>
            /// <returns>The row of the shot</returns>
            public int Row { get { return _row; } set { _row = value; } }

            /// <summary>
            /// The column of the shot
            /// </summary>
            /// <value>The column of the shot</value>
            /// <returns>The column of the shot</returns>
            public int Column { get { return _column; } set { _column = value; } }

            /// <summary>
            /// Sets the last hit made to the local variables
            /// </summary>
            /// <param name="row">the row of the location
            public Location(int row, int col)
            {
                _row = row;
                _column = col;
            }

            /// <summary>
            /// Check if two locations are equal
            /// </summary>
            /// <param name="this">location 1</param>
            /// <param name="other">location 2</param>
            /// <returns>true if location 1 and location 2 are at the same spot</returns>
            public override bool Equals(object obj)
            {

         
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Location otherLoc = (Location)obj;

                return this.Row == otherLoc.Row && this.Column == otherLoc.Column;
            }

            public static bool operator ==(Location lhs, Location rhs)
            {
                return Equals(lhs, rhs);
            }

            public static bool operator !=(Location lhs, Location rhs)
            {
                return !Equals(lhs, rhs);
            }
        }

        public AIPlayer(BattleshipsGame controller) : base(controller)
        {

        }

        /// <summary>
        /// Generate a valid row, column to shoot at
        /// </summary>
        /// <param name="row">output the row for the next shot</param>
        /// <param name="column">output the column for the next show</param>
        abstract protected void GenerateCoords(int row, int column);

        /// <summary>
        /// The last shot had the following result. Child classes can use this
        /// to prepare for the next shot.
        /// </summary>
        /// <param name="result">The result of the shot</param>
        /// <param name="row">the row shot</param>
        /// <param name="col">the column shot</param>
        abstract protected void ProcessShot(int row, int col, AttackResult result);

        /// <summary>
        /// The AI takes its attacks until its go is over.
        /// </summary>
        /// <returns>The result of the last attack</returns>
        override public AttackResult Attack()
        {
            AttackResult result;
            int row = 0;
            int column = 0;

            do
            {
                Delay();

                GenerateCoords(row, column);
                result = _game.Shoot(row, column);
                ProcessShot(row, column, result);

            } while (result.Value != ResultOfAttack.Miss && result.Value != ResultOfAttack.GameOver && !SwinGameSDK.SwinGame.WindowCloseRequested());

            return result;
        }


        /// <summary>
        /// Wait a short period to simulate the think time
        /// </summary>
        private void Delay()
        {
            for (int i = 0; i < 150; i++)
            {
                if (SwinGame.WindowCloseRequested()) return;
                SwinGame.Delay(5);
                SwinGame.ProcessEvents();
                SwinGame.RefreshScreen();
            }
        }
    }
}
