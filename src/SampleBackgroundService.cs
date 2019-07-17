using log4net;
using System;
using System.Threading;

namespace DebuggableWindowsService
{
    class SampleBackgroundService
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

        bool stopRequested;

        public void Start()
        {
            logger.Debug("Start called.");

            Thread thr = new Thread(serviceThread);
            thr.Start();
        }

        public void Stop()
        {
            logger.Debug("Stop called.");
            stopRequested = true;
        }

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
