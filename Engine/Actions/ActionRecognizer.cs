using System;

namespace Engine.Actions
{
    public class ActionRecognizer<T> : IActionRecognizer<IWrittenAction> where T : IWrittenAction, new()
    {
        private readonly Func<string[], bool> _recognizer;

        public ActionRecognizer(Func<string[], bool> recognizer)
        {
            _recognizer = recognizer;
        }

        public bool CanRecognize(string[] parts)
        {
            return _recognizer(parts);
        }

        public IWrittenAction Recognize(string[] parts)
        {
            return new T();
        }
    }
}