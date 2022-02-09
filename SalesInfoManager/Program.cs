using NLog;
using SailsInfoManager.SalesInfoManager;

namespace SalesInfoManager
{
    class Program
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            ConsoleManager consoleManager = new ConsoleManager(logger);
            consoleManager.StartApp();
        }
    }
}
