using System;
using System.Linq;
using Engine;
using Engine.Locations;

namespace Game
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var ui = new TextUserInterface(Console.Out, Console.In);
            var engine = new TextAdventureEngine(new DungeonBuilder().Build(), DirectionCalculator.RandomDirection());
            while (engine.Running)
            {
                ui.Render(engine.Orientation, engine.Location);
                var command = ui.GetCommand();
                var result = engine.ProcessCommand(command);
                ui.Render(result);

                if (engine.Location.GetType() == typeof(ExitLocation))
                {
                    engine.Halt();
                    if (engine.Inventory.Any(x => x.Name == "key"))
                    {
                        ui.Render("You used the key to exit the dungeon! You won!");
                    }
                    else
                    {
                        ui.Render("You exited the dungeon without the key. You have lost.");
                    }
                }
            }
        }
    }
}