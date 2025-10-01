using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsQuest2025.Data
{
    public class Character : GameObject
    {
        public void Talk()
        {
            Console.WriteLine($"Ahoj, jmenuji se {Name}.");
        }
    }
}
