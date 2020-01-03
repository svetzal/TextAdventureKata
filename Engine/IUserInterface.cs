using Engine.Locations;

namespace Engine
{
    public interface IUserInterface
    {
        void Render(string message);
        void Render(int orientation, ILocation location);
    }
}