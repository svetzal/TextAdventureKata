using System;
using Engine;

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
            }
        }
    }
}