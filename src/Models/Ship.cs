using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Ship
    {
        private ShipName _shipName;
        private int _sizeOfShip;
        private int _hitsTaken = 0;
        private List<Tile> _tiles;
        private int _row;
        private int _col;
        private Direction _direction;

        public string Name
        {
            get { return _shipName == ShipName.AircraftCarrier ? "Aircraft Carrier" : _shipName.ToString(); }
        }

        public int Size { get { return _sizeOfShip; } }
        public int Hits { get { return _hitsTaken; } }
        public int Row { get { return _row; } }
        public int Column { get { return _col; } }
        public Direction Direction { get { return _direction; } }

        public Ship(ShipName ship)
        {
            _shipName = ship;
            _tiles = new List<Tile>();

            _sizeOfShip = (int)_shipName;
        }

        /// <summary>
        /// Adds the ship tile
        /// </summary>
        /// <param name="tile">one of the tiles the ship is on</param>
        public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }

        /// <summary>
        /// Clears the tile back to a sea tile
        /// </summary>
        public void Remove()
        {
            foreach(var tile in _tiles)
            {
                tile.ClearShip();
            }
            _tiles.Clear();
        }

        /// <summary>
        /// Register the hit on the ship
        /// </summary>
        public void Hit()
        {
            _hitsTaken++;
        }

        /// <summary>
        /// Returns if the ship is deployed, if its delayed it has more than
        /// 0 tiles
        /// </summary>
        public bool IsDeployed { get { return _tiles.Count > 0; } }
        public bool IsDestroyed { get { return Hits == Size;  } }

        /// <summary>
        /// Record that the ship is now deployed
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Deployed(Direction direction, int row, int col)
        {
            _row = row;
            _col = col;
            _direction = direction;
        }
    }
}
