﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace DebuggableWindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public const string SERVICE_NAME = "Sample Background Service";

        private readonly ServiceProcessInstaller m_ServiceProcessInstaller;
        private readonly ServiceInstaller m_ServiceInstaller;

        public ProjectInstaller()
        {
            m_ServiceInstaller = new ServiceInstaller();
            m_ServiceInstaller.ServiceName = SERVICE_NAME;
            m_ServiceInstaller.Description = "";
            m_ServiceInstaller.StartType = ServiceStartMode.Automatic;
            m_ServiceInstaller.DelayedAutoStart = true;

            m_ServiceProcessInstaller = new ServiceProcessInstaller();
            m_ServiceProcessInstaller.Account = ServiceAccount.LocalSystem;

            Installers.Add(m_ServiceProcessInstaller);
            Installers.Add(m_ServiceInstaller);

            InitializeComponent();
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
        }
    }
}
