using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    /// <summary>
    /// Tile knows its location on the grid, if it is a ship and if it has been 
    /// shot before
    /// </summary>
    class Tile
    {
        private int _rowValue;
        private int _columnValue;
        private Ship _ship = null;
        private bool _shot = false;

        public bool Shot { get { return _shot; } set { _shot = value; } }
        public int Row { get { return _rowValue; } }
        public int Column { get { return _columnValue; } }

        /// <summary>
        /// Ship allows for a tile to check if there is ship and add a ship to a tile
        /// </summary>
        public Ship Ship
        {
            get { return _ship; }
            set
            {
                if(_ship == null)
                {
                    _ship = value;
                    if (value != null)
                        _ship.AddTile(this);
                }
                else
                {
                    throw new InvalidOperationException("There is already a ship at [" + Row.ToString() + ", " + Column.ToString() + "]");
                }
            }
        }

        /// <summary>
        /// The tile constructor will know where it is on the grid, and is its a ship
        /// </summary>
        /// <param name="row">the row on the grid</param>
        /// <param name="col">the col on the grid</param>
        /// <param name="ship">what ship it is</param>
        public Tile(int row, int col, Ship ship)
        {
            _rowValue = row;
            _columnValue = col;
            _ship = ship;
        }

        /// <summary>
        /// Clearship will remove the ship from the tile
        /// </summary>
        public void ClearShip()
        {
            _ship = null;
        }

        /// <summary>
        /// View is able to tell the grid what the tile is
        /// </summary>
        public TileView View
        {
            get
            {
                if(_ship == null)
                {
                    return _shot ? TileView.Miss : TileView.Sea;
                }
                else
                {
                    return _shot ? TileView.Hit : TileView.Ship;
                }
            }
        }

        /// <summary>
        /// Shoot allows a tile to be shot at, and if the tile has been hit before
        /// it will give an error
        /// </summary>
        public void Shoot()
        {
            if(!Shot)
            {
                Shot = true;
                if (_ship != null)
                    _ship.Hit();
            }
            else
            {
                throw new ApplicationException("You have already shot this square");
            }
        }
    }
}
