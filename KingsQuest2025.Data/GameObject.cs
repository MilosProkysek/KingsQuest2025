using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsQuest2025.Data
{
    public class GameObject : IGameObject
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description { get; set; }
    }
}
