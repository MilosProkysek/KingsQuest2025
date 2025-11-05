using KingsQuest2025.Data;
using KingsQuest2025.GameService;

namespace KingsQuest2025
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Game init
            Game game = new Game();
            GameService.GameService gameService = new GameService.GameService();
            gameService.Init(game);


            //UI init
            View.GameView gameView = new View.GameView();
            gameView.DisplayMessage("Vitej statecny rytiri v hre Kraluv Ukol!\n");



            string userInputString;
            do
            {
                gameView.CurrentRoomInfo(game.CurrentRoom);
                gameView.DisplayMessage("Co budes delat?:");

                userInputString = Console.ReadLine() ?? "";
                string[] userInput = userInputString.ToLower().Split(' ');

                switch (userInput[0])
                {
                    case "jdi":
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
    }
}