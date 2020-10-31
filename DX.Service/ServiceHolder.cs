using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DX.Utilities;
using DX.Log;

namespace DX.Service
{
    public class ServiceHolder
    {

        private string[] strStates = new string[7];//读出状态        

        private DXLog logger = DXLog.GetLogger(typeof(ServiceHolder));

        private OPCService InOPCService = new OPCService();
        private OCRService ocrService = new OCRService();

        public void Run()
        {            
            ThreadPool.QueueUserWorkItem(new WaitCallback(CameraListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(OPCListener));
        }
        public void Stop()
        {
            InOPCService.Close();
        }
        //OPC监听线程
        private void OPCListener(object obj)
        {
            InOPCService.InitOPCService(Constants.OPCPATH, Constants.Keys);

            while (true)
            {                
                try
                {
                    //读出PLC启动状态
                    strStates = InOPCService.GetPlcStates();

                    int len = strStates.Length;

                    if (strStates[0] == "1" && strStates[1] == "0")//iden_start && !iden_done  停稳触发拍照识别(不比较)
                    {
                        char[] value = { '0', '0', '0', '0' };
                        string strSkid = ocrService.StartSkidOCR();

                        InOPCService.UpdateIdenDone(1);
                        value = strSkid.ToCharArray();

                        InOPCService.UpdateIdenResult(value);
                    }
                    Thread.Sleep(int.Parse(Configurations.Get("OPCDuration")) * 1000);
                }
                catch (Exception ex)
                {
                    logger.Error("Read data from OPC failed, {0}", ex.ToString());
                    Thread.Sleep(int.Parse(Configurations.Get("OPCDuration")) * 100);
                }
                
            }
        }
        //相机线程:刷新相机缓存
        private void CameraListener(object obj)
        {
            try
            {
                ocrService.InitOCRService(false, Constants.CAMERAPATH);
                ocrService.ConsecutiveRead(1, false, "capture");
            }
            catch(Exception ex)
            {
                logger.Error("Camera listener failed, {0}", ex.ToString());
            }
        }
    }
}
