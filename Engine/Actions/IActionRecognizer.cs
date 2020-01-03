namespace Engine.Actions
{
    public interface IActionRecognizer<out T>
    {
        bool CanRecognize(string[] parts);
        T Recognize(string[] parts);
    }
}