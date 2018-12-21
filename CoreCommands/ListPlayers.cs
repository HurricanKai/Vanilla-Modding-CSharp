using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommands
{
    public class ListPlayers : CustomCommand
    {
        public override String Command => "listplayers";
        public override String[] Usage => new string[]
            {
                Command
            };

        public override void Handle(String[] args)
        {
            EmitCommand("say @a");
        }
    }
}
