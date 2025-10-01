using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsQuest2025.Data
{
    public interface IGameObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
