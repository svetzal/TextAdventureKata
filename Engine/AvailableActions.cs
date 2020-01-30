using System.Collections.Generic;
using System.Linq;
using Engine.Actions;

namespace Engine
{
    public class AvailableActions
    {
        private readonly List<IActionRecognizer<IWrittenAction>> _recognizers =
            new List<IActionRecognizer<IWrittenAction>>
            {
                new ActionRecognizer<GreetingAction>(parts => parts.Count() == 4
                                                              && parts[0] == "my"
                                                              && parts[1] == "name"
                                                              && parts[2] == "is"),
                new ActionRecognizer<QuitAction>(parts => parts.Length == 1 && parts[0] == "quit"),
                new ActionRecognizer<TurnAction>(parts => parts.Length == 2 && parts[0] == "turn"),
                new ActionRecognizer<MoveAction>(parts => parts.Length == 2 && parts[0] == "move"),
                new ActionRecognizer<PickUpAction>(parts => parts.Length == 3
                                                            && parts[0] == "pick"
                                                            && parts[1] == "up")
            };

        public IWrittenAction Find(string[] parts)
        {
            var recognizer = _recognizers.FirstOrDefault(r => r.CanRecognize(parts));
            if (recognizer == null) recognizer = new ActionRecognizer<ErrorAction>(_ => true);
            return recognizer.Recognize(parts);
        }
    }
}