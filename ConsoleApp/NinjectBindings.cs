using ConsoleApp.Interfaces;
using ConsoleApp.Mocks;

namespace ConsoleApp
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IFile>().To<FileConvert>();
        }
    }
}
