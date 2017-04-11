using System;

namespace Battleship.Models
{
    /// <summary>
    /// The SeaGridAdapter allows for the change in a sea grid view. Whenever a ship is
    /// presented it changes the view into a sea tile instead of a ship tile.
    /// </summary>
    public class SeaGridAdapter : ISeaGrid
    {
        private SeaGrid _myGrid;

        /// <summary>
        /// Create the SeaGridAdapter, with the grid, and it will allow it to be changed
        /// </summary>
        /// <param name="grid">the grid that needs to be adapted</param>
        public SeaGridAdapter(SeaGrid playerGrid)
        {
            _myGrid = playerGrid;
            //EventHandler handler = new EventHandler<MyGrid_Changed>();
            //handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// MyGrid_Changed causes the grid to be redrawn by raising a changed event
        /// </summary>
        /// <param name="sender">the object that caused the change</param>
        /// <param name="e">what needs to be redrawn</param>
        public void MyGrid_Changed(object sender, EventArgs e)
        {
            //RaiseEvent Changed(Me, e)
        }

        public TileView Item(int x, int y)
        {
            TileView result = _myGrid.Item(x, y);

            return result == TileView.Ship ? TileView.Sea : result;
        }

        /// <summary>
        /// HitTile calls oppon _MyGrid to hit a tile at the row, col
        /// </summary>
        /// <param name="row">the row its hitting at</param>
        /// <param name="col">the column its hitting at</param>
        /// <returns>The result from hitting that tile</returns>
        public AttackResult HitTile(int row, int col)
        {
            return _myGrid.HitTile(row, col);
        }


        /// <summary>
        /// Indicates that the grid has been changed
        /// </summary>
        public EventHandler Changed;
        

    }
}