using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftCortana
{
    public class CortanaSetup : CustomCommand
    {
        public override String Command => "setupcortana";
        public override String[] Usage { get; }

        public CortanaSetup()
        {
            Usage = new string[]
                {
                    Command + " <locale>"
                };
        }

        public override void Handle(String[] args)
        {
            if (args.Length > 0)
                CortanaCommand.Setup(args[0]);
        }
    }
}
