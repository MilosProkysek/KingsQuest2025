using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsQuest2025.Data
{
    public class Game
    {
        public Room CurrentRoom { get; set; }

        public List<IGameObject> Inventory { get; set; }
    }
}
