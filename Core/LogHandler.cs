using System.Text.RegularExpressions;

namespace Core
{
    public abstract class LogHandler
    {
        public abstract string Pattern { get; }
        public abstract void Handle(Context ctx, Match match);
    }
}