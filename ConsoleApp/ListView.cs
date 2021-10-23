using System;
using NLog;

namespace ConsoleApp
{
    public class ListView
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Show(string[] args) 
        {
            try
            {
                Console.WriteLine($"Total items = {args.Length}");

                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"Arg[{i}] = [{args[i]}]");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                logger.Debug(e.ToString());
            }
            finally
            {
                Console.ReadLine();
                Program.Main(args);
            }
        }
    }
}
