namespace KingsQuest2025.Data
{
    public class Room
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Room> _neigbours;
        public List<Room> Neigbours
        {
            get
            {
                if (_neigbours == null)
                {
                    _neigbours = new List<Room>();
                }
                return _neigbours;
            }
            set { _neigbours = value; }
        }

        public string Description { get; set; }

        public void Describe()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine($"{Description}");
            Console.WriteLine("V sale jsou: Kral, Princezna");
            Console.WriteLine("V sale se nachazi: Trun");
            Console.WriteLine("Odsud muzes jit do: ");
            foreach (Room room in Neigbours)
            {
                Console.Write($"{room.Name},");
            }
        }
    }
}
