using System.Linq;
using Engine;
using Engine.Actions;
using Engine.Locations;
using Xunit;

namespace EngineTests.Actions
{
    public class PickUpActionShould
    {
        public PickUpActionShould()
        {
            _item = new InventoryItem
            {
                Name = "key"
            };
            _room = new NormalLocation();
            _engine = new TextAdventureEngine(_room, DirectionCalculator.North);
        }

        private readonly PickUpAction _pickUpAction = new PickUpAction();
        private readonly InventoryItem _item;
        private readonly NormalLocation _room;
        private readonly TextAdventureEngine _engine;

        [Fact]
        public void FailToPickUpItemWhenNotPresent()
        {
            _room.Items.Add(_item);
            _pickUpAction.Execute(_engine, new[] {"pick", "up", "blah"});
            Assert.Empty(_engine.Inventory);
        }

        [Fact]
        public void PickUpItemWhenPresent()
        {
            _room.Items.Add(_item);
            _pickUpAction.Execute(_engine, new[] {"pick", "up", _item.Name});
            Assert.Equal(_item, _engine.Inventory.First());
        }
    }
}