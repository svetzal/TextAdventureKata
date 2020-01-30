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

        public TextAdventureEngine(ILocation location, int newOrientation)
        {
            CurrentOrientation = newOrientation;
            CurrentLocation = location;
            Inventory = new List<InventoryItem>();
        }

        public States CurrentState { get; private set; }
        public int CurrentOrientation { get; set; }
        public ILocation CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }

        public bool Running => CurrentState == States.NeedsInput;

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