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
                Name = "Korunni sal krale Vaclava",
                Description = "Prostorna mistnost, bohate zdobena zlatem."};

            string userInputString;
            do
            {
                currentRoom.Describe();
                Console.Write("\nCo budes delat?: ");

                userInputString = Console.ReadLine() ?? "";
                string[] userInput = userInputString.Split(' ');

                switch (userInput[0])
                {
                    case "jdi":
                        Console.WriteLine($"Jdes do:{userInput[1]}");
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