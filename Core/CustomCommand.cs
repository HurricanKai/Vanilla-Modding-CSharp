using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class CustomCommand
    {
        public abstract string Command { get; }
        public abstract void Handle(string[] args);

        public virtual string[] Usage { get; } = new string[0];
        protected virtual string CommandName { get { return GetType().Name; } }

        private List<string> commands = new List<string>();
        protected Context ctx;
        internal void HandleCommand(string[] args, Context ctx)
        {
            try
            {
                commands.Clear();
                this.ctx = ctx;
                Handle(args);
                if (commands.Count > 0)
                {
                    ctx.World.CreateStructureBlock(new StructureBlock() { Name = CommandName, Commands = commands.ToArray() });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured while trying to process command " + Command);
                Console.WriteLine(ex);
            }
        }

        protected void EmitCommand(string s)
        {
            commands.Add(s);
        }
    }
}