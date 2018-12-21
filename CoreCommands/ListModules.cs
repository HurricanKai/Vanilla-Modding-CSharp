using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCommands
{
    public class ListModules : CustomCommand
    {
        public override string Command => "listmods";
        
        public override String[] Usage => new string[]
            {
                Command
            };
        public override void Handle(string[] args)
        {
            // we ignore args
            foreach (var module in ctx.CustomModules)
                EmitCommand($"say {module.Name} with {module.CustomCommands.Length} Custom Commands");
        }
    }
}
