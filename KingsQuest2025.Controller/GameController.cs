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

                string[] userInput = { "xxx", "ZbrojniXX" };

                command_type = GameView.ReadUserInput();
                GameService.DoCommand(command_type);


            } while (command_type != COMMAND_TYPE.EXIT);
        }
        
    }
}
