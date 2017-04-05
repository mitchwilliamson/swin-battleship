using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    class Player
    {
        private Random _random = new Random();
        private Dictionary<ShipName, Ship> _ships = new Dictionary<ShipName, Ship>();
        private _playerGrid = new SeaGrid(_ships);

        private int _shots;
        private int _hits;
        private int _misses;

    }
}
