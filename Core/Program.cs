using fNbt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    class Program
    {
        private static List<LogHandler> logHandlers = new List<LogHandler>();

        private static Context ctx = new Context();
        const string path = @"C:\Users\HurricanKai\AppData\Roaming\.minecraft\raw.log";
        private static CancellationTokenSource _cts;
        public static async Task Main()
        {
            /*var v = new NbtFile();
            v.LoadFromFile(@"C:\Users\HurricanKai\AppData\Roaming\.minecraft\saves\BackgroundTest\generated\minecraft\structures\a.nbt");
            Console.WriteLine(v.ToString("  "));
            Console.WriteLine(v.FileCompression);
            Console.ReadLine();*/


            logHandlers.Add(new UserNameHandler());
            logHandlers.Add(new JoinHandler());
            logHandlers.Add(new LeaveHandler());
            logHandlers.Add(new CloseSingleplayerHandler());
            logHandlers.Add(new CustomCommandHandler());

            foreach (var file in Directory.EnumerateFiles("./Modules/", "*.dll"))
            {
                var assembly = Assembly.LoadFrom(file);
                ctx.CustomModules.AddRange(assembly.GetTypes().Where(x => typeof(ICustomCommandModule).IsAssignableFrom(x)).Select(x => (ICustomCommandModule)Activator.CreateInstance(x)));
            }


            _cts = new CancellationTokenSource();
            var ct = _cts.Token;
            var t = Run(ct);
            await Task.Delay(-1, ct);
            await t; // wont ever happen
        }

        // [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static async Task Run(CancellationToken ct)
        {
            Console.WriteLine("Using Path " + path);
            using (var fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (var reader = new StreamReader(fs))
            {
                string line;
#if !DEBUG
                Console.WriteLine("Reading out old Logs");
                Console.WriteLine();
#endif
                while ((line = await reader.ReadLineAsync()) != null)
                {
#if !DEBUG
                    Console.WriteLine(line);
#endif
                }
#if !DEBUG
                Console.WriteLine();
#endif
                Console.WriteLine("Starting Processing");
                while (!_cts.IsCancellationRequested)
                {
                    if ((line = await reader.ReadLineAsync()) != null)
                    {
                        await Changed(line);
                        await reader.ReadToEndAsync();
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                }
            }
        }

        private static async Task Changed(string line)
        {
            await Process(line);
        }

        private static async Task Process(string line)
        {
            foreach (var handler in logHandlers)
            {
                var matches = Regex.Matches(line, handler.Pattern);
                if (matches.Count == 1 && matches.Cast<Match>().All(x => x.Success))
                {
                    handler.Handle(ctx, matches[0]);
                }
            }
        }
    }
}
