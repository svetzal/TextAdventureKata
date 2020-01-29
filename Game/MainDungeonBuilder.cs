using System.Data;
using System.Linq;
using Engine;
using Engine.Locations;

namespace Game
{
    public class MainDungeonBuilder : DungeonBuilder
    {
        private const string KeyLabel = "key";
        
        public ILocation Build()
        {
            var entranceRoom = new NormalLocation
            {
                NearbySensation = "you feel chilled air",
                DetailedSensation = "The room is chilly, and sounds small.",
            };

            var stinkyRoom = new NormalLocation
            {
                NearbySensation = "you smell something foul",
                DetailedSensation = "The room stinks of death.",
            };

            var boringRoom = new NormalLocation
            {
                NearbySensation = "you feel a cold damp breeze",
                DetailedSensation = "The room is uninteresting.",
            };

            var mustyRoom = new NormalLocation
            {
                NearbySensation = "you smell a faint musty odour",
                DetailedSensation = "The room smells musty.",
            };

            var keyRoom = new NormalLocation
            {
                NearbySensation = "you hear water dripping",
                DetailedSensation =
                    "Water drips nearby, and the room echoes hollowly. You feel something sharp and key-like under your foot.",
            };

            var key = new InventoryItem
            {
                Name = KeyLabel,
            };
            keyRoom.Items.Add(key);

            var exitRoom = new NormalLocation()
            {
                NearbySensation = "you hear the howling of the winter wind",
                Logic = (engine, ui) =>
                {
                    engine.Halt();
                    if (engine.Inventory.Any(x => x.Name == KeyLabel))
                    {
                        ui.Render("You used the key to exit the dungeon! You won!");
                    }
                    else
                    {
                        ui.Render("You exited the dungeon without the key. You have lost.");
                    }

                    return true;
                }
            };

            Connect(DirectionCalculator.North, exitRoom, entranceRoom);
            Connect(DirectionCalculator.North, entranceRoom, stinkyRoom);
            Connect(DirectionCalculator.East, stinkyRoom, boringRoom);
            Connect(DirectionCalculator.South, boringRoom, mustyRoom);
            Connect(DirectionCalculator.East, mustyRoom, keyRoom);

            return entranceRoom;
        }
    }
}