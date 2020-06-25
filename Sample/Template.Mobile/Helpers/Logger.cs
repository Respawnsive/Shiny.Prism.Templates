using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Shiny.Logging;

namespace Template.Mobile.Helpers
{
    public class Logger
    {
        public delegate void WriteDelegate(params (string key, string value)[] args);

        public static WriteDelegate Write(Exception ex, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            var systemArgs = GetSystemArgs(filePath, lineNumber, memberName);

            return (customArgs) => Log.Write(ex, systemArgs.Concat(customArgs).ToArray());
        }

        public static WriteDelegate Write(string eventName, string description = null, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            var systemArgs = GetSystemArgs(filePath, lineNumber, memberName);

            return (customArgs) => Log.Write(eventName, description, systemArgs.Concat(customArgs).ToArray());
        }

        private static (string key, string value)[] GetSystemArgs(string filePath = "", int lineNumber = 0, string memberName = "")
        {
            return new[]
            {
                ("Class", Path.GetFileNameWithoutExtension(filePath.Replace('\\', Path.DirectorySeparatorChar))),
                ("Line", lineNumber.ToString()),
                ("Caller", memberName)
            };
        }
    }
}
