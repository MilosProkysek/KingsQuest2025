using System.Globalization;
using System.Xml.Linq;

using KingsQuest2025.Data;
using KingsQuest2025.GameService;

namespace KingsQuest2025.View
{
    public class GameView
    {
        public void DisplayMessage(string message_key)
        {
            string message = global::KingsQuest2025.View.Lang.ResourceManager.GetString(message_key) ?? message_key;
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
            Console.Write("Muzes delat:");
            Console.Write(Lang.CMD_GO + " <jmeno mistnosti> - jit do jine mistnosti, ");
        }

        private void PrintGameObjects<T>(List<T> col) where T : IGameObject
        {
            foreach (T gameObject in col)
            {
                Console.Write($"{gameObject.Name},");
            }
        }

        public COMMAND_TYPE ReadUserInput()
        {
            string userInputString = Console.ReadLine() ?? "";
            string[] userInput = userInputString.ToLower().Split(' ');
            COMMAND_TYPE command = GetUserCommand(userInput[0]);

            //[to do]
            return command;
        }

        private static COMMAND_TYPE GetUserCommand(string commandString)
        {
            //string localizedCommand = View.Lang.ResourceManager.GetString(commandString, new System.Globalization.CultureInfo("cs-CZ"));
            var resourceSet = View.Lang.ResourceManager.GetResourceSet(
        Thread.CurrentThread.CurrentUICulture, true, true);

            string commandName = "";

            foreach (System.Collections.DictionaryEntry entry in resourceSet)
            {
                if (entry.Value?.ToString() == commandString)
                {
                    commandName = entry.Key.ToString();
                }
            }

            switch (commandName)
            {
                case "CMD_GO":
                    return COMMAND_TYPE.GO;
                case "CMD_TALK":
                    return COMMAND_TYPE.TALK;
                case "CMD_EXIT":
                    return COMMAND_TYPE.EXIT;
                default:
                    return COMMAND_TYPE.UNKNOWN;
            }
        }

    }
}
