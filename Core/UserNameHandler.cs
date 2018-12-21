using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class UserNameHandler : LogHandler
    {
        public override String Pattern => "^Setting user: (.{3,24})";

        public override void Handle(Context ctx, Match match)
        {
            ctx.User.Username = match.Groups[1].Value;
            Console.WriteLine("Detected Username: " + ctx.User.Username);
        }
    }
}
