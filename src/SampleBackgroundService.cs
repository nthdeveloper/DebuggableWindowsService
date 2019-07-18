using log4net;
using System;
using System.Threading;

namespace DebuggableWindowsService
{
    /// <summary>
    /// Contains actual background operations that our Windows service performs
    /// </summary>
    class SampleBackgroundService
    {
        //Get a logger for this class from log4net LogManager
        private static ILog logger = LogManager.GetLogger(typeof(SampleBackgroundService));

        bool stopRequested;

        //Starts the thread
        public void Start()
        {
            logger.Debug("Start called.");

            Thread thr = new Thread(serviceThread);
            thr.Start();
        }

        //Stops the thread
        public void Stop()
        {
            logger.Debug("Stop called.");
            stopRequested = true;
        }

        //Service thread that performs background tasks and writes logs
        private void serviceThread()
        {
            logger.Debug("Service thread started.");

            while (!stopRequested)
            {
                Thread.Sleep(1000);
                if (stopRequested)
                    break;

                logger.Info("I'm running...");

                Thread.Sleep(1000);
                if (stopRequested)
                    break;

                logger.Warn("I am tired :(");
                Thread.Sleep(1000);

                logger.Error("Something really bad happened!");
            }

            logger.Debug("Service thread exiting.");
        }
    }
}
