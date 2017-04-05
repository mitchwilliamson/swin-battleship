using System;
using System.Collections.Generic;

namespace Battleship.Models
{
    class SeaGrid : ISeaGrid
    {
        private const int _WIDTH = 10;
        private const int _HEIGHT = 10;

        private Tile[,] _gameTiles;
        private Dictionary<ShipName, Ship> _ships;
        private int _shipsKilled = 0;

        // public event EventHandler ISeaGrid.Changed; - to be fixed

        /// <summary>
        /// The width of the sea grid.
        /// </summary>
        /// <value>The width of the sea grid.</value>
        /// <returns>The width of the sea grid.</returns>
        public int Width { get { return _WIDTH; } }

        /// <summary>
        /// The height of the sea grid
        /// </summary>
        /// <value>The height of the sea grid</value>
        /// <returns>The height of the sea grid</returns>
        public int Height { get { return _HEIGHT; } }

        /// <summary>
        /// Returns the number of ships killed
        /// </summary>
        public int ShipsKilled { get { return _shipsKilled; } }

        /// <summary>
        /// Show the tile view
        /// </summary>
        /// <param name="x">x coordinate of the tile</param>
        /// <param name="y">y coordiante of the tile</param>
        /// <returns></returns>
        public TileView Item(int x, int y)
        {
            return _gameTiles[x, y].View;
        }

        /// <summary>
        /// AllDeployed checks if all the ships are deployed
        /// </summary>
        public bool AllDeployed
        {
            get
            {
                foreach (var s in _ships.Values)
                {
                    if (!s.IsDeployed) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// SeaGrid constructor, a seagrid has a number of tiles stored in an array
        /// </summary>
        public SeaGrid(Dictionary<ShipName, Ship> ships)
        {
            for (int i = 0; i < Width - 1; i++)
            {
                for (int j = 0; j < Height - 1; j++)
                {
                    _gameTiles[i, j] = new Tile(i, j, null);
                }
            }

            _ships = ships;
        }

        /// <summary>
        /// MoveShips allows for ships to be placed on the seagrid
        /// </summary>
        /// <param name="row">the row selected</param>
        /// <param name="col">the column selected</param>
        /// <param name="ship">the ship selected</param>
        /// <param name="direction">the direction the ship is going</param>
        public void MoveShip(int row, int col, ShipName ship, Direction direction)
        {
            Ship newShip = _ships[ship];
            newShip.Remove();
            AddShip(row, col, direction, newShip);
        }

        /// <summary>
        /// AddShip add a ship to the SeaGrid
        /// </summary>
        /// <param name="row">row coordinate</param>
        /// <param name="col">col coordinate</param>
        /// <param name="direction">direction of ship</param>
        /// <param name="newShip">the ship</param>
        private void AddShip(int row, int col, Direction direction, Ship newShip)
        {
            // TODO
        }

        /// <summary>
        /// HitTile hits a tile at a row/col, and whatever tile has been hit, a
        /// result will be displayed.
        /// </summary>
        /// <param name="row">the row at which is being shot</param>
        /// <param name="col">the cloumn at which is being shot</param>
        /// <returns>An attackresult (hit, miss, sunk, shotalready)</returns>
        public AttackResult HitTile(int row, int col)
        {
            // TODO
        }
    }
}