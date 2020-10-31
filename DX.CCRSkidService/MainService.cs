using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using DX.Log;
using DX.Service;

namespace DX.CCRSkidService
{
    public partial class MainService : ServiceBase
    {
        private DXLog logger { get; set; }
        private ServiceHolder hollder { get; set; }
        public MainService()
        {
            InitializeComponent();
        }

        //public void StartTest()
        //{
        //    this.OnStart(null);
        //}
        protected override void OnStart(string[] args)
        {
            DXLog.InitLog();
            this.logger = DXLog.GetLogger(typeof(MainService));
            logger.Info("Main service start.");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Run));
        }
        private void Run(object obj)
        {
            try
            {
                logger.Info("Main thread runing.");
                hollder = new ServiceHolder();
                hollder.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }
        protected override void OnStop()
        {
            try
            {
                if (hollder != null)
                {
                    hollder.Stop();
                }
            }
            catch (Exception)
            {
                logger.Info("Main service stop.");
            }
        }
    }
}
