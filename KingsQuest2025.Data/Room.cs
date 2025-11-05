namespace KingsQuest2025.Data
{
    public class Room : GameObject
    {
        private List<Room> _neighbours;
        public List<Room> Neighbours
        {
            get
            {
                if (_neighbours == null)
                {
                    _neighbours = new List<Room>();
                }
                return _neighbours;
            }
            set { _neighbours = value; }
        }

        private List<Character> _characters;
        public List<Character> Characters
        {
            get
            {
                if (_characters == null)
                {
                    _characters = new List<Character>();
                }
                return _characters;
            }
            set { _characters = value; }
        }
    }
}
