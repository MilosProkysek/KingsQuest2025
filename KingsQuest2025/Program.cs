using KingsQuest2025.Data;

namespace KingsQuest2025
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Vitej statecny rytiri v hre Kraluv Ukol!\n");

            //UI init
            View.GameView gameView = new View.GameView();

            //Game init
            Room currentRoom = new Room()
            {
                Name = "Sal",
                Description = "Prostorna mistnost, bohate zdobena zlatem."
            };

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

            Character King = new Character()
            {
                Name = "Kral",
                Description = "Stary moudry kral."
            };
            currentRoom.Characters.Add(King);

            currentRoom.Neighbours.Add(RoomZbrojnice);
            currentRoom.Neighbours.Add(RoomDrak);

            RoomZbrojnice.Neighbours.Add(currentRoom);
            RoomDrak.Neighbours.Add(currentRoom);

            string userInputString;
            do
            {
                currentRoom.Describe();
                gameView.DisplayMessage("Co budes delat?:");

                userInputString = Console.ReadLine() ?? "";
                string[] userInput = userInputString.ToLower().Split(' ');

                switch (userInput[0])
                {
                    case "jdi":
                        gameView.DisplayMessage($"Jdes do:{userInput[1]}");
                        Room nextRoom = currentRoom.Neighbours.Find(r => r.Name.ToLower() == userInput[1]);
                        if (nextRoom != null)
                        {
                            currentRoom = nextRoom;
                        }
                        else
                        {
                            gameView.DisplayMessage("Tam jit nemuzes!");
                        }

                        break;
                    case "mluv":
                        gameView.DisplayMessage($"Mluvis s:{userInput[1]}");
                        Character talkTo = currentRoom.Characters.Find(c => c.Name.ToLower() == userInput[1]);
                        if (talkTo != null)
                        {
                            talkTo.Talk();
                        }
                        else
                        {
                            gameView.DisplayMessage("Tam jit nemuzes!");
                        }

                        break;
                    case "konec":
                        gameView.DisplayMessage("Sbohem statecny rytiri!");
                        break;
                    default:
                        gameView.DisplayMessage("Neznamy prikaz.");
                        break;
                }
            } while (userInputString != "konec");

        }
    }
}