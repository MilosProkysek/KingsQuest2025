using System.Xml.Linq;

namespace KingsQuest2025.View
{
    public class GameView
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void CurrentRoomInfo(Room currentRoom)
        {
            Console.WriteLine($"{currentRoom.Name}");
            Console.WriteLine($"{currentRoom.Description}");
            Console.Write("V sale jsou: ");
            PrintGameObjects(currentRoom.Characters);
            Console.WriteLine();
            Console.WriteLine("V sale se nachazi: Trun");
            Console.Write("Odsud muzes jit do: ");
            PrintGameObjects(currentRoom.Neighbours);
            Console.WriteLine();
        }

        private void PrintGameObjects<T>(List<T> col) where T : IGameObject
        {
            foreach (T gameObject in col)
            {
                Console.Write($"{gameObject.Name},");
            }
        }
    }
}
