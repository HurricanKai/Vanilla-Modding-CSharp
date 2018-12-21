using System.Collections.Generic;

namespace Core
{
    public interface ICustomCommandModule
    {
        string Name { get; }
        CustomCommand[] CustomCommands { get; }
    }
}