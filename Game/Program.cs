using System;
using System.Collections.Generic;
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
            var engine =
                new TextAdventureEngine(new MainDungeonBuilder().Build(), DirectionCalculator.RandomDirection());
            var gameRunner = new GameRunner(engine, ui);

            using var inputEnumerator = ui.Commands().GetEnumerator();
            gameRunner.Execute(inputEnumerator);
        }
    }
}