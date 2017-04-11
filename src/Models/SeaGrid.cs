using System;
using System.Collections.Generic;

namespace Battleship.Models
{
    public class SeaGrid : ISeaGrid
    {
        private const int _WIDTH = 10;
        private const int _HEIGHT = 10;

        private Tile[,] _gameTiles;
        private Dictionary<ShipName, Ship> _ships;
        private int _shipsKilled = 0;

        public event EventHandler<EventArgs> Changed;

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
            try
            {
                int size = newShip.Size;
                int currentRow = row;
                int currentCol = col;
                int dRow, dCol;

                if (direction == Direction.LeftRight)
                {
                    dRow = 0;
                    dCol = 1;
                }
                else
                {
                    dRow = 1;
                    dCol = 0;
                }

                for (int i = 0; i < size - 1; i++)
                {
                    if(currentRow < 0 || currentRow >= Width || currentCol < 0 || currentCol >= Height)
                    {
                        throw new InvalidOperationException("Ship can't fit on the board!");
                    }

                    _gameTiles[currentRow, currentCol].Ship = newShip;

                    currentCol += dCol;
                    currentCol += dRow;
                }
            }
            catch (Exception ex)
            {
                newShip.Remove();
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                EventHandler<EventArgs> handler = Changed;
                handler(this, EventArgs.Empty);
            }
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
            try
            {
                if (_gameTiles[row, col].Shot)
                {
                    return new AttackResult(ResultOfAttack.ShotAlready, "have already attacked [" + col.ToString() + "," + row.ToString() + "]!", row, col);
                }

                _gameTiles[row, col].Shoot();

                if (_gameTiles[row, col].Ship == null)
                {
                    return new AttackResult(ResultOfAttack.Miss, "missed", row, col);
                }

                if (_gameTiles[row, col].Ship.IsDestroyed)
                {
                    _gameTiles[row, col].Shot = true;
                    _shipsKilled += 1;
                    return new AttackResult(ResultOfAttack.Destroyed, _gameTiles[row, col].Ship, "destroyed the enemy's", row, col);
                }

                return new AttackResult(ResultOfAttack.Hit, "hit something!", row, col);
            }
            finally
            {
                EventHandler<EventArgs> handler = Changed;
                handler(this, EventArgs.Empty);
            }
        }
    }
}