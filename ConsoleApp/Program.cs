using ConsoleApp.Interfaces;
using Ninject;
using System;
using System.Reflection;
using System.Threading;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StandardKernel _Kernal = new StandardKernel();
            _Kernal.Load(Assembly.GetExecutingAssembly());
            IFile _ifile = _Kernal.Get<IFile>();
            TreatmentList treatment = new TreatmentList(_ifile);

            Console.WriteLine("\tMenu:\n's' - show IP list\n" +
                        "'a' - enter IP address\n'0' or other - exit");

            new Thread(() => { FileWatcher.Proceed(); }).Start();
            string s = Console.ReadLine();
            switch (s)
            {
                case "s":
                    ListView.Show(args);
                    break;
                case "a":
                    treatment.Perform(args);
                    break;
                case "0":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    goto case "0";
            }
        }
    }
}
