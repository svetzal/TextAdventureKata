using System.Collections.Generic;

namespace Engine
{
    public class GameRunner
    {
        private readonly TextAdventureEngine _engine;
        private readonly TextUserInterface _ui;

        public GameRunner(TextAdventureEngine engine, TextUserInterface ui)
        {
            this._engine = engine;
            this._ui = ui;
        }
        
        public void Execute(IEnumerator<string> commands)
        {
            while (_engine.Running)
            {
                _ui.Render(_engine.CurrentOrientation, _engine.CurrentLocation);
                var command = GetNext(commands);
                var result = _engine.ProcessCommand(command);
                _ui.Render(result);
                _engine.CurrentLocation.Logic?.Invoke(_engine, _ui);
            }
        }

        private static string GetNext(IEnumerator<string> commands)
        {
            commands.MoveNext();
            return commands.Current;
        }
    }
}