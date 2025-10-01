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


        public void Describe()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine($"{Description}");
            Console.Write("V sale jsou: ");
            PrintGameObjects(Characters);
            Console.WriteLine();
            Console.WriteLine("V sale se nachazi: Trun");
            Console.Write("Odsud muzes jit do: ");
            PrintGameObjects(Neighbours);
            Console.WriteLine();
        }

        private void PrintGameObjects(List<object> col)
        {
            foreach (IGameObject gameObject in col)
            {
                Console.Write($"{gameObject.Name},");
            }
        }
    }
}
