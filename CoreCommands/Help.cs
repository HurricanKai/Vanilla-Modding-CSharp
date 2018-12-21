using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommands
{
    public class Help : CustomCommand
    {
        public override String Command => "help";

        public override String[] Usage => new string[]
            {
                Command
            };
        public override void Handle(String[] args)
        {
            if (args.Length == 0)
            {
                // ,{\"text\":\".....\\n\",\"color\":\"gold\"}
                var s = "/tellraw @p [\"\",{\"text\":\"Help\\n\",\"color\":\"gold\"},{\"text\":\"\\n\",\"color\":\"gold\"}";
                foreach (var command in ctx.CustomModules.SelectMany(x => x.CustomCommands.SelectMany(x2 => x2.Usage)))
                {
                    s += ",{\"text\":\"." + command + "\\n\",\"color\":\"gold\"}";
                }
                s += "]";
                EmitCommand(s);
            }
        }
    }
}
