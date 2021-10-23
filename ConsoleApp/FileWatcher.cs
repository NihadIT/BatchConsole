using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    // Listening to the file
    class FileWatcher
    {   
        public static void Proceed()
        {
            string path = Directory.GetCurrentDirectory();
            using var watcher = new FileSystemWatcher(path);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Error += OnError;
            watcher.Filter = "file.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.Read();
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
            ChangeLines();
        }
        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"\nStacktrace: {ex.StackTrace}\n");
                PrintException(ex.InnerException);
            }
        }
        public static void ChangeLines()
        {
            IEnumerable<string> lines = File.ReadAllLines("file.txt").Where(line => line != "");
            string[] new_args = lines.ToArray();
            Program.Main(new_args);
        }
    }
}
