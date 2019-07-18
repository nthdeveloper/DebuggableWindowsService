using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DebuggableWindowsService
{
    /// <summary>
    /// Windows service class whose OnStart and OnStop methods are called 
    /// when the Windows service is started or stopped.
    /// </summary>
    public partial class SampleWindowsService : ServiceBase
    {
        SampleBackgroundService sampleBackgroundService;

        public SampleWindowsService()
        {
            InitializeComponent();
        }

        //Called when the Windows service is started
        protected override void OnStart(string[] args)
        {
            sampleBackgroundService = new SampleBackgroundService();
            sampleBackgroundService.Start();
        }

        //Called when the Windows service is stopped
        protected override void OnStop()
        {
            sampleBackgroundService.Stop();
        }
    }
}
