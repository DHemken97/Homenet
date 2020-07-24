using System.ServiceProcess;

namespace Homenet.ServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceRunner()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
