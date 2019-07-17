using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DebuggableWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ILog logger = LogManager.GetLogger(typeof(Program));

#if DEBUG
            logger.Info("Starting services...");

            SampleBackgroundService _backgroundService = new SampleBackgroundService();
            _backgroundService.Start();

            logger.Info("Services started. Press enter to stop...");
            Console.ReadLine();

            logger.Info("Stopping service...");
            _backgroundService.Stop();
            logger.Info("Stopped.");
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SampleWindowsService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
