using System.Collections.Generic;

namespace ConsoleApp.Interfaces
{
    interface IFile
    {
        List<string> RemoveDuplicates(List<string> ipList);
        void SaveToFile(List<string> ipList);
    }
}
