using System.Text.RegularExpressions;

namespace Engine
{
    public class CommandParser
    {
        public string[] Parse(string command)
        {
            return Regex.Split(command.Trim().ToLower(), "\\s+");
        }
    }
}