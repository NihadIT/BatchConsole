using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NLog;

namespace ConsoleApp
{
    class TreatmentList
    {
        static IFile convIfile;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public TreatmentList(IFile Ifile)
        {
            convIfile = Ifile;
        }
        public void Perform(string[] args)
        {
            try
            {
                IPAddress ip;
                List<string> ipList = new List<string>();
                string ipString = null;
                Console.WriteLine("Enter the IP address(quit - finish):");

                while (ipString != "quit")
                {
                    ipString = Console.ReadLine();
                    if (ipString != null && ipString != "quit")
                    {  //IP address validation
                        bool ValidateIP = IPAddress.TryParse(ipString, out ip);
                        if (ValidateIP && FindInFile(ipString) == false)
                            ipList.Add(ipString);
                        else
                            Console.WriteLine("Format is invalid or there are duplicates");
                    }
                }
                convIfile.SaveToFile(convIfile.RemoveDuplicates(ipList));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                logger.Debug(e.ToString());
            }
            finally
            {
                Console.Clear();
                FileWatcher.ChangeLines();
            }
        }
        private static bool FindInFile(string ipString)
        {
            string fileText = File.ReadAllText("file.txt");

            if (fileText.Contains(ipString))
            {
                Console.WriteLine("\nAccess disallowed");
                return true;
            }
            else
            {
                Console.WriteLine("Access allowed");
                return false;
            }
        }
    }
}
