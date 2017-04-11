using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Player
    {
        protected Random _random = new Random();

        private Dictionary<ShipName, Ship> _ships = new Dictionary<ShipName, Ship>();
        private SeaGrid _playerGrid;
        private ISeaGrid _enemyGrid;
        protected BattleshipsGame _game;


        private int _shots;
        private int _hits;
        private int _misses;

        /// <summary>
        /// Returns the game that the player is part of.
        /// </summary>
        /// <value>The game</value>
        /// <returns>The game that the player is playing</returns>
        public BattleshipsGame Game
        {
            get { return _game; }
            set { _game = value; }
        }

        /// <summary>
        /// Sets the grid of the enemy player
        /// </summary>
        /// <value>The enemy's sea grid</value>
        public ISeaGrid Enemy { set { _enemyGrid = value; } }

        /// <summary>
        /// The EnemyGrid is a ISeaGrid because you shouldn't be allowed to see the enemies ships
        /// </summary>
        public ISeaGrid EnemyGrid { get => _enemyGrid; set => _enemyGrid = value; }

        /// <summary>
        /// The PlayerGrid is just a normal SeaGrid where the players ships can be deployed and seen
        /// </summary>
        public SeaGrid PlayerGrid { get => _playerGrid; set => _playerGrid = value; }

        public Player(BattleshipsGame controller)
        {
            _playerGrid = new SeaGrid(_ships);
            _game = controller;

            foreach(ShipName name in Enum.GetValues(typeof(ShipName)))
            {
                if (name != ShipName.None)
                    _ships.Add(name, new Ship(name));
            }

            RandomizeDeployment();
        }

        /// <summary>
        /// ReadyToDeploy returns true if all ships are deployed
        /// </summary>
        public bool ReadyToDeploy { get { return _playerGrid.AllDeployed; } }

        /// <summary>
        /// Check if all ships are destroyed... -1 for the none ship
        /// </summary>
        public bool IsDestroyed { get { return _playerGrid.ShipsKilled == Enum.GetValues(typeof(ShipName)).Length - 1; } }

        public int Shots { get => _shots; set => _shots = value; }
        public int Hits { get => _hits; set => _hits = value; }
        public int Missed { get => _misses; set => _misses = value; }

        /// <summary>
        /// Returns the Player's ship with the given name.
        /// </summary>
        /// <param name="name">the name of the ship to return</param>
        /// <value>The ship</value>
        /// <returns>The ship with the indicated name</returns>
        /// <remarks>The none ship returns nothing/null</remarks>
        public Ship Ship(ShipName name)
        {
            if (name == ShipName.None) return null;
            return _ships[name];
        }

        public int Score
        {
            get
            {
                if (IsDestroyed) return 0;
                return (Hits * 12) - Shots - (PlayerGrid.ShipsKilled * 20);
            }
        }

        /// <summary>
        /// Makes it possible to enumerate over the ships the player
        /// has.
        /// </summary>
        /// <returns>A Ship enumerator</returns>
        public IEnumerator<Ship> GetShipEnumerator()
        {
            Ship[] result = new Ship[_ships.Values.Count];
            _ships.Values.CopyTo(result, 0);
            List<Ship> lst = new List<Ship>();
            lst.AddRange(result);
            return lst.GetEnumerator();
        }

        /// <summary>
        /// Vitual Attack allows the player to shoot
        /// </summary>
        virtual public AttackResult Attack()
        {
            return null;
        }

        /// <summary>
        /// Shoot at a given row/column
        /// </summary>
        /// <param name="row">the row to attack</param>
        /// <param name="col">the column to attack</param>
        /// <returns>the result of the attack</returns>
        public AttackResult Shoot(int row, int col)
        {
            _shots += 1;
            AttackResult result;
            result = EnemyGrid.HitTile(row, col);

            switch (result.Value)
            {
                case ResultOfAttack.Hit:
                    _hits += 1;
                    break;
                case ResultOfAttack.Miss:
                    _misses += 1;
                    break;
                case ResultOfAttack.Destroyed:
                    _hits += 1;
                    break;
                case ResultOfAttack.ShotAlready:
                    break;
                case ResultOfAttack.GameOver:
                    break;
                default:
                    break;
            }

            return result;
        }

        public void RandomizeDeployment()
        {
            bool placementSuccessful;
            Direction heading;

            foreach(ShipName shipToPlace in Enum.GetValues(typeof(ShipName)))
            {
                if (shipToPlace == ShipName.None) continue;

                placementSuccessful = false;

                // generate random position until the ship can be placed
                do
                {
                    int dir = _random.Next(2);
                    int x = _random.Next(0, 11);
                    int y = _random.Next(0, 11);

                    heading = dir == 0 ? Direction.UpDown : Direction.LeftRight;

                    try
                    {
                        PlayerGrid.MoveShip(x, y, shipToPlace, heading);
                        placementSuccessful = true;
                    }
                    catch (Exception ex)
                    {
                        placementSuccessful = false;
                    }

                } while (!placementSuccessful);
            }
        }
    }
}
