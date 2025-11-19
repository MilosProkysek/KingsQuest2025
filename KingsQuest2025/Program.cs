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
            GameController gameController = new GameController(gameService);
            gameController.Show();
          
        }

    }
}