using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class LeaveHandler : LogHandler
    {
        public override String Pattern => "^(.{3,24}) left the game";

        public override void Handle(Context ctx, Match match)
        {
            var s = match.Groups[1].Value;
            ctx.World.Players.Remove(ctx.World.Players.First(x => x.Username == s));
            Console.WriteLine("Removed Player " + s);
        }
    }
}
