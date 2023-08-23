using System.Reflection;

namespace Core
{
    public abstract class CoreBase
    {
        public abstract bool RegisterClass();
    }

    public abstract class WindowBase : CoreBase
    {
    }

    public abstract class LinuxBase : CoreBase
    {

    }

    
}