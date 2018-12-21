using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class CloseSingleplayerHandler : LogHandler
    {
        public override String Pattern => "^Stopping singleplayer server as player logged out";

        public override void Handle(Context ctx, Match match)
        {
            ctx.World = new World();
            Console.WriteLine("Reseting World, World was Closed");
        }
    }
}
