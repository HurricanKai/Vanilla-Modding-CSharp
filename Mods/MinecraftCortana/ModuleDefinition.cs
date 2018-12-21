using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftCortana
{
    public class ModuleDefinition : ICustomCommandModule
    {
        public String Name { get; } = "Minecraft Cortana";

        public CustomCommand[] CustomCommands { get; } = new CustomCommand[]
            {
                new CortanaCommand(),
                new CortanaSetup()
            };
    }
}
