using KingsQuest2025.Data;
using KingsQuest2025.GameService;
using KingsQuest2025.View;

namespace KingsQuest2025.Controller
{
    public class GameController
    {
        public GameView GameView { get; private set; }

        public GameService.GameService GameService { get; private set; }

        public GameController(GameService.GameService gameService)
        {
            GameView = new GameView();
            GameService = gameService;
        }

        public void Show()
        {
            GameView.DisplayMessage("msg_welcome");

            string userInputString;
            COMMAND_TYPE command_type = COMMAND_TYPE.UNKNOWN;
            do
            {
                GameView.CurrentRoomInfo(GameService.GetGame().CurrentRoom);
                GameView.DisplayMessage("Co budes delat?:");

                //userInputString = gameView.ReadUserInput();
                //string[] userInput = userInputString.ToLower().Split(' ');
                //string command = GetUserCommand(userInput[0]);

                //string[] userInput = { "xxx", "ZbrojniXX" };

                IGameObject[] commandObjects = new IGameObject[] {GetGameObjectByName("Zbrojnice") };

                string[] userInput = GameView.ReadUserInput().ToLower().Split(' ');
                command_type = GetUserCommand(userInput[0]); 
                GameService.DoCommand(command_type, commandObjects);


            } while (command_type != COMMAND_TYPE.EXIT);
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

        private IGameObject GetGameObjectByName(string name)
        {
            IGameObject obj = GameService.GetGame().CurrentRoom.Neighbours.Find(r => r.Name.ToLower() == name.ToLower());
            if(obj != null)
            {
                return obj;
            }
            return null;
        }

    }
}
