using KingsQuest2025.Data;
using KingsQuest2025.GameService;
using KingsQuest2025.Controller;
using System.Data;

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
            //View.GameView gameView = new View.GameView();
            //gameView.DisplayMessage("msg_welcome");
            GameController gameController = new GameController(gameService);
            gameController.Show();

            //string userInputString;
            //COMMAND_TYPE command_type = COMMAND_TYPE.UNKNOWN;
            //do
            //{
            //    gameView.CurrentRoomInfo(game.CurrentRoom);
            //    gameView.DisplayMessage("Co budes delat?:");

            //    //userInputString = gameView.ReadUserInput();
            //    //string[] userInput = userInputString.ToLower().Split(' ');
            //    //string command = GetUserCommand(userInput[0]);

            //    string[] userInput = {"xxx","ZbrojniXX" };

            //    command_type = gameView.ReadUserInput();
            //    gameService.DoCommand(command_type);

                
            //} while (command_type != COMMAND_TYPE.EXIT);

        }

    }
}