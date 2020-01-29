using System;
using System.Linq;

namespace Engine.Actions
{
    public class PickUpAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            try
            {
                var item = engine.CurrentLocation.Items.First(x => x.Name == parts.Last());
                engine.Inventory.Add(item);
                return $"You picked up the {item.Name}";
            }
            catch (InvalidOperationException ex)
            {
                return $"There is no {parts.Last()} here.";
            }
        }
    }
}