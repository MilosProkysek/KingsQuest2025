using KingsQuest2025.Data;
using KingsQuest2025.GameService;

namespace KingsQuest2025
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Lang init
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("cs-CZ");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            //Game init
            Game game = new Game();
            GameService.GameService gameService = new GameService.GameService();
            gameService.Init(game);


            //UI init
            View.GameView gameView = new View.GameView();
            gameView.DisplayMessage("msg_welcome");



            string userInputString;
            do
            {
                gameView.CurrentRoomInfo(game.CurrentRoom);
                gameView.DisplayMessage("Co budes delat?:");

                userInputString = gameView.ReadUserInput();
                string[] userInput = userInputString.ToLower().Split(' ');
                string command = GetUserCommand(userInput[0]);


                switch (command)
                {
                    case "CMD_GO":
                        gameView.DisplayMessage($"Jdes do:{userInput[1]}");                        
                        
                        if (!gameService.ChangeRoom(userInput[1]))
                        {
                            gameView.DisplayMessage("Tam jit nemuzes!");
                        }

                        break;
                    case "mluv":
                        gameView.DisplayMessage($"Mluvis s:{userInput[1]}");
                        Character talkTo = game.CurrentRoom.Characters.Find(c => c.Name.ToLower() == userInput[1]);
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

        private static string GetUserCommand(string commandString)
        {
            //string localizedCommand = View.Lang.ResourceManager.GetString(commandString, new System.Globalization.CultureInfo("cs-CZ"));
            var resourceSet = View.Lang.ResourceManager.GetResourceSet(
        Thread.CurrentThread.CurrentUICulture, true, true);

            foreach (System.Collections.DictionaryEntry entry in resourceSet)
            {
                if (entry.Value?.ToString() == commandString)
                {
                    return entry.Key.ToString();
                }
            }
            return "";
        }
    }
}