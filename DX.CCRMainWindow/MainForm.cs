using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ServiceProcess;
using DX.Service;
using DX.Utilities;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using DX.Log;

namespace DX.CCRMainWindow
{
    public partial class MainForm : Form
    {
        private DXLog logger { get; set; }

        public delegate void SetTextCallBack(string text);                  //在子线程内 修改 主线程控件的值
        public delegate void SetButtonCallBack(int index, int status);      //在子线程内 修改 主线程控件的状态
        OCRService service = new OCRService();
        private string m_location;
        private string m_serviceName;
        private string m_description;
        private bool m_showing = false;
        private Bitmap m_bkBitmap;
        WinServiceUtil serviceUtil = new WinServiceUtil();
        Button[,] serviceButtons = new Button[1, 5];
        private enum ButtonNames { Install = 0, UnInstall, Start, Stop, Restrart };
        private enum ServiceStatus { Uninstalled = 0, Installed, Running, Stopped };

        public MainForm()
        {
            DXLog.InitLog();
            this.logger = DXLog.GetLogger(typeof(MainForm));

            InitializeComponent();
        }

        //启动服务
        private void btn_start_service_Click(object sender, EventArgs e)
        {
            m_serviceName = Constants.SERVICENAME;
            new Thread(new ThreadStart(StartService)).Start();
        }
        private void btn_stop_service_Click(object sender, EventArgs e)
        {
            m_serviceName = Constants.SERVICENAME;
            new Thread(new ThreadStart(StopService)).Start();
        }

        private void btn_restart_service_Click(object sender, EventArgs e)
        {
            m_serviceName = Constants.SERVICENAME;
            new Thread(new ThreadStart(RestartService)).Start();
        }
        private void InstallService()
        {
            serviceUtil.ConfigService(m_serviceName, m_description, m_location, true);
        }
        private void UninstallService()
        {
            serviceUtil.ConfigService(m_serviceName, m_description, m_location, false);
        }
        private void StartService()
        {
            serviceUtil.StartService(m_serviceName);
        }
        private void StopService()
        {
            serviceUtil.StopService(m_serviceName);
        }
        private void RestartService()
        {
            serviceUtil.RestartService(m_serviceName);
        }
        //安装服务
        private void btn_install_service_Click(object sender, EventArgs e)
        {
            m_serviceName = Constants.SERVICENAME;
            m_description = Constants.SERVICDESCRIPTION;
            m_location = AppDomain.CurrentDomain.BaseDirectory + Constants.SERVICENAME + ".exe";
            new Thread(new ThreadStart(InstallService)).Start();
        }
        //卸载服务
        private void btn_uninstall_service_Click(object sender, EventArgs e)
        {
            m_serviceName = Constants.SERVICENAME;
            m_description = Constants.SERVICDESCRIPTION;
            m_location = AppDomain.CurrentDomain.BaseDirectory + Constants.SERVICENAME + ".exe";
            new Thread(new ThreadStart(UninstallService)).Start();
        }
        private void SetTextboxS(string text)
        {
            if (this.tb_state_s.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(SetTextboxS);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tb_state_s.Text = text;
            }
        }
        private void SetButtonGroupStatus(int index, int status)
        {
            if (this.serviceButtons[index, 0].InvokeRequired)
            {
                SetButtonCallBack d = new SetButtonCallBack(SetButtonGroupStatus);
                this.Invoke(d, new object[] { index, status });
            }
            else
            {
                switch (status)
                {
                    case 0://未安装
                        serviceButtons[index, (int)ButtonNames.Install].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.UnInstall].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.Start].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.Stop].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.Restrart].Enabled = false;
                        break;
                    case 1://已安装
                        serviceButtons[index, (int)ButtonNames.Install].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.UnInstall].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.Start].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.Stop].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.Restrart].Enabled = false;
                        break;
                    case 2://正在运行
                        serviceButtons[index, (int)ButtonNames.Install].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.UnInstall].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.Start].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.Stop].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.Restrart].Enabled = true;
                        break;
                    case 3://已停止
                        serviceButtons[index, (int)ButtonNames.Install].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.UnInstall].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.Start].Enabled = true;
                        serviceButtons[index, (int)ButtonNames.Stop].Enabled = false;
                        serviceButtons[index, (int)ButtonNames.Restrart].Enabled = true;
                        break;
                }
            }
        }        

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_bkBitmap = (Bitmap)Bitmap.FromFile(Constants.BKIMAGE, false);
            pictureBox1.Image = m_bkBitmap;
            InitButtonArray();
            new Thread(new ThreadStart(pollingThread)).Start();

        }
        private void pollingThread()
        {
            while (true)
            {
                try
                {
                    var serviceControllers = ServiceController.GetServices();

                    var server = serviceControllers.FirstOrDefault(service => service.ServiceName == SystemConstant.CCRSKID_SERVICE);
                    if (server != null)
                    {
                        if (server.Status == ServiceControllerStatus.Running)
                        {
                            SetTextboxS(Constants.SERVICESTATERUNING);
                            SetButtonGroupStatus(0, (int)ServiceStatus.Running);
                        }
                        else if (server.Status == ServiceControllerStatus.Stopped)
                        {
                            SetTextboxS(Constants.SERVICESTATESTOPED);
                            SetButtonGroupStatus(0, (int)ServiceStatus.Stopped);
                        }
                    }
                    else
                    {
                        SetTextboxS(Constants.SERVICEUNINSTALL);
                        SetButtonGroupStatus(0, (int)ServiceStatus.Uninstalled);
                    }

                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "," + ex.StackTrace);
                }
                Thread.Sleep(3000);
            }
        }
        private void InitButtonArray()
        {
            serviceButtons[0, (int)ButtonNames.Install] = btn_install_service;
            serviceButtons[0, (int)ButtonNames.UnInstall] = btn_uninstall_service;
            serviceButtons[0, (int)ButtonNames.Start] = btn_start_service;
            serviceButtons[0, (int)ButtonNames.Stop] = btn_stop_service;
            serviceButtons[0, (int)ButtonNames.Restrart] = btn_restart_service;
        }
        //右上角关闭触发事件
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to close？", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void btn_show_image_Click(object sender, EventArgs e)
        {
            if (!m_showing)
            {
                service.InitOCRService(false, Constants.CAMERAPATH);
                timer1.Enabled = true;
                m_showing = true;
                btn_show_image.Text = "停止播放";
            }
            else
            {
                m_showing = false;
                timer1.Enabled = false;
                service.ReleaseOCRService();
 
                pictureBox1.Image = m_bkBitmap;
                btn_show_image.Text = "显示画面";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Mat img = service.GetCurrFrame();
                Bitmap bitmap = BitmapConverter.ToBitmap(img);

                pictureBox1.Image = bitmap;
            }
            catch(Exception ex)
            {
                logger.Error("Show real image error,{0}", ex.ToString());
            }

        }

        private void btn_view_log_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.LOGPATH);
        }

        private void btn_view_pictures_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.SNAPIMAGEPATH);
        }
    }
}
