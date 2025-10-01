using KingsQuest2025.Data;

namespace KingsQuest2025
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Vitej statecny rytiri v hre Kraluv Ukol!\n");

            //Game init
            Room currentRoom = new Room() { 
                Name = "Sal",
                Description = "Prostorna mistnost, bohate zdobena zlatem."};

            Room RoomZbrojnice = new Room()
            {
                Name = "Zbrojnice",
                Description = "Velka tmava mistnost plna zelezneho harampadi."
            };

            Room RoomDrak = new Room()
            {
                Name = "Sluj",
                Description = "Draci sluj plna draka."
            };

            currentRoom.Neigbours.Add(RoomZbrojnice);
            currentRoom.Neigbours.Add(RoomDrak);

            RoomZbrojnice.Neigbours.Add(currentRoom);
            RoomDrak.Neigbours.Add(currentRoom);

            string userInputString;
            do
            {
                currentRoom.Describe();
                Console.Write("\nCo budes delat?: ");

                userInputString = Console.ReadLine() ?? "";
                string[] userInput = userInputString.ToLower().Split(' ');

                switch (userInput[0])
                {
                    case "jdi":
                        Console.WriteLine($"Jdes do:{userInput[1]}");
                        Room nextRoom = currentRoom.Neigbours.Find(r => r.Name.ToLower() == userInput[1]);
                        if (nextRoom != null)
                        {
                            currentRoom = nextRoom;
                        }
                        else
                        {
                            Console.WriteLine("Tam jit nemuzes!");
                        }

                        break;
                    case "konec":
                        Console.WriteLine("Sbohem statecny rytiri!");
                        break;
                    default:
                        Console.WriteLine("Neznamy prikaz.");
                        break;
                }
            } while (userInputString != "konec");

        }
    }
}