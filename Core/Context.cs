using System.Collections.Generic;

namespace Core
{
    public class Context
    {
        public User User { get; } = new User();
        public World World { get; set; } = new World();
        public List<ICustomCommandModule> CustomModules = new List<ICustomCommandModule>();
    }
}