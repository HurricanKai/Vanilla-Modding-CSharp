using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCommands
{
    public class ModuleDefinition : ICustomCommandModule
    {
        public String Name { get; } = "Core";

        public CustomCommand[] CustomCommands { get; } = new CustomCommand[]
            {
                new ListModules(),
                new ListPlayers(),
                new Help()
            };
    }
}
