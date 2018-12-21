using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class JoinHandler : LogHandler
    {
        public override String Pattern => "^(.{3,24}) joined the game";

        public override void Handle(Context ctx, Match match)
        {
            var s = match.Groups[1].Value;
            ctx.World.Players.Add(new User() { Username = s });
            Console.WriteLine("Detected new Player " + s);
        }
    }
}
