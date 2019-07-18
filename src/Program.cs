using log4net;
using System;
using System.IO;
using System.Reflection;
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
            //Set the working directory to the folder that this executable resides
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ILog logger = LogManager.GetLogger(typeof(Program));

#if DEBUG   //Run as a regular console application in Debug mode
            //Manually create an instance of SampleBackgroundService class and call its start method          

            logger.Info("Starting services...");

            SampleBackgroundService _backgroundService = new SampleBackgroundService();
            _backgroundService.Start();

            logger.Info("Services started. Press enter to stop...");
            Console.ReadLine();

            logger.Info("Stopping service...");
            _backgroundService.Stop();
            logger.Info("Stopped.");

#else       //Create and run the real Windows service instance in Release mode
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
