using KingsQuest2025.Data;
using System.Net.Http.Headers;

namespace KingsQuest2025.GameService
{
    public enum COMMAND_TYPE
    {
        GO,
        TALK,
        EXIT,
        UNKNOWN
    }

    public class GameService
    {
        private Game game;

        public bool ChangeRoom(string newRoomName)
        {
            Room nextRoom = game.CurrentRoom.Neighbours.Find(r => r.Name.ToLower() == newRoomName.ToLower());
            if (nextRoom == null)
            {
                return false;
            }
            game.CurrentRoom = nextRoom;
            return true;

        }

        public void Init(KingsQuest2025.Data.Game game)
        {
            this.game = game;

            Room roomSal = new Room()
            {
                Name = "Sal",
                Description = "Prostorna mistnost, bohate zdobena zlatem."
            };

            Room roomZbrojnice = new Room()
            {
                Name = "Zbrojnice",
                Description = "Velka tmava mistnost plna zelezneho harampadi."
            };

            Room roomDrak = new Room()
            {
                Name = "Sluj",
                Description = "Draci sluj plna draka."
            };

            Character king = new Character()
            {
                Name = "Kral",
                Description = "Stary moudry kral."
            };
            roomSal.Characters.Add(king);

            roomSal.Neighbours.Add(roomZbrojnice);
            roomSal.Neighbours.Add(roomDrak);

            roomZbrojnice.Neighbours.Add(roomSal);
            roomDrak.Neighbours.Add(roomSal);

            game.CurrentRoom = roomSal;
        }
    }
}
