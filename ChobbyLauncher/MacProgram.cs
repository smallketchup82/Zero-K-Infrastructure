using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Steamworks;

namespace ChobbyLauncher
{
    internal static class MacProgram
    {
        private static int Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Trace.Listeners.Add(new ConsoleTraceListener());
            NativeLibrary.SetDllImportResolver(typeof(SteamAPI).Assembly, (name, assembly, path) =>
                name.StartsWith("steam_api", StringComparison.Ordinal)
                    ? NativeLibrary.Load(Path.Combine(AppContext.BaseDirectory, "libsteam_api.dylib"))
                    : IntPtr.Zero);
            try
            {
                var data = Environment.GetEnvironmentVariable("ZEROK_DATA_DIR");
                if (string.IsNullOrEmpty(data)) throw new InvalidOperationException("ZEROK_DATA_DIR is required");
                Directory.CreateDirectory(data);
                Directory.SetCurrentDirectory(data);
                var launcher = new Chobbyla(data, "zkmenu:dev", "native-macos");
                if (!launcher.IsBundled) throw new InvalidOperationException("ZEROK_ENGINE_PATH is required");
                if (!launcher.Prepare().GetAwaiter().GetResult()) return 1;
                Environment.Exit(launcher.Run(0, Console.Out) ? 0 : 1);
                return 0;
            }
            catch (Exception error)
            {
                Console.Error.WriteLine(error);
                Environment.Exit(1);
                return 1;
            }
        }
    }
}
