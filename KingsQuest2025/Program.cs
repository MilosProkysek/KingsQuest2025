using KingsQuest2025.Data;
using KingsQuest2025.GameService;
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
            View.GameView gameView = new View.GameView();
            gameView.DisplayMessage("msg_welcome");



            string userInputString;
            COMMAND_TYPE command_type = COMMAND_TYPE.UNKNOWN;
            do
            {
                gameView.CurrentRoomInfo(game.CurrentRoom);
                gameView.DisplayMessage("Co budes delat?:");

                //userInputString = gameView.ReadUserInput();
                //string[] userInput = userInputString.ToLower().Split(' ');
                //string command = GetUserCommand(userInput[0]);

                string[] userInput = {"xxx","ZbrojniXX" };

                command_type = gameView.ReadUserInput();                   

                switch (command_type)
                {
                    case COMMAND_TYPE.GO:
                        gameView.DisplayMessage($"Jdes do:{userInput[1]}");                        
                        
                        if (!gameService.ChangeRoom(userInput[1]))
                        {
                            gameView.DisplayMessage("Tam jit nemuzes!");
                        }

                        break;
                    case COMMAND_TYPE.TALK:
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
                    case COMMAND_TYPE.EXIT:
                        gameView.DisplayMessage("Sbohem statecny rytiri!");
                        break;
                    default:
                        gameView.DisplayMessage("Neznamy prikaz.");
                        break;
                }
            } while (command_type != COMMAND_TYPE.EXIT);

        }

    }
}