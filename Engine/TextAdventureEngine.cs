using System;
using System.Collections.Generic;
using Engine.Locations;

namespace Engine
{
    public class TextAdventureEngine
    {
        public enum States
        {
            NeedsInput,
            Terminating
        }

        private readonly AvailableActions _availableActions = new AvailableActions();
        private readonly CommandParser _parser = new CommandParser();

        public TextAdventureEngine(ILocation location, int orientation)
        {
            Orientation = orientation;
            Location = location;
            Inventory = new List<InventoryItem>();
        }

        public int Orientation { get; set; }

        public ILocation Location { get; set; }

        public bool Running => CurrentState == States.NeedsInput;

        public States CurrentState { get; private set; }

        public string Greeting => "Hello, World!";
        public List<InventoryItem> Inventory { get; set; }

        public string ProcessCommand(string command)
        {
            var parts = _parser.Parse(command);
            var action = _availableActions.Find(parts);
            return action.Execute(this, parts);
        }

        public void Halt()
        {
            CurrentState = States.Terminating;
        }
    }
}