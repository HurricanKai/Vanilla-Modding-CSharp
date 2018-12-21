using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class CustomCommandHandler : LogHandler
    {
        public override String Pattern => @"((^\[CHAT\] <[^ ]{0,24}>)|(^<[^ ]{0,24}>)) \.([^ ]*)( (.*))*$"; // prefix is '.'

        public override void Handle(Context ctx, Match match)
        {
            var command = match.Groups[4].Value;
            var arguments = match.Groups[6].Value.Trim().Split(' ').Where(x => x != "").ToArray();

            if (command == "setworld")
            {
                World.WorldName = arguments[0];
                StructureBlock.DetectStructureIndex();
                Console.WriteLine("Set World: " + World.WorldName);
                return;
            }

            bool handled = false;
            foreach (var module in ctx.CustomModules)
                foreach (var c in module.CustomCommands)
                {
                    if (c.Command != command) continue;
                    c.HandleCommand(arguments, ctx);
                    handled = true;
                }

            if (!handled)
            {
                ctx.World.SendCommands("CCH", "/say could not find command \"" + command + "\"");
            }

            Console.WriteLine("Executed Command " + command);
        }
    }
}
