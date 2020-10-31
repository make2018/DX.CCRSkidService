using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DX.Log;
using DX.OPC;
using DX.Contract;
using DX.Utilities;
using OPCAutomation;
//using DX.Database;

namespace DX.Service
{
    public class OPCService
    {
        private DXLog logger = DXLog.GetLogger(typeof(OPCService));

        private OPCServer MyServer { get; set; }
        private OPCGroup MyGroup { get; set; }
        private Dictionary<String, OPCItem> MyItem { get; set; }
        private String opcPath { get; set; }
        private OPCWrapper wrapper { get; set; }

        public void Close()
        {
            try
            {
                if (this.MyServer != null)
                {
                    wrapper.Close(this.MyServer);
                }
            }
            catch (Exception e)
            {
                logger.Error("close opc service failed.{0}", e.ToString());
            }
        }
        public Dictionary<string, OPCContract> ReadDataFromOPC()
        {
            string actionCode = string.Empty;
            OPCContract contract = new OPCContract();

            if (this.HaveData())
            {
                logger.Info("Begin read data from opc");
            }

            return new Dictionary<string, OPCContract>() { { actionCode, contract } };
        }
        public void InitOPCService(string opcPath, List<String> keys)
        {
            try
            {
                Dictionary<string, int> items = new Dictionary<string, int>();

                foreach (var key in keys)
                {
                    items.Add(key, 0);
                }

                this.opcPath = opcPath;
                logger.Info("Opc path is {0}", opcPath);
                wrapper = new OPCWrapper();
                String serverName = wrapper.GetOPCServerName();

                if (!String.IsNullOrEmpty(Constants.OPCName))
                {
                    serverName = Constants.OPCName;
                }

                logger.Info("Server Name is {0}", serverName);

                this.MyServer = wrapper.ConnectRemoteServer(Configurations.Get(Constants.OPCIP), serverName);
                this.MyGroup = wrapper.CreateGroup(this.MyServer, "DXGroup");
                MyItem = new Dictionary<string, OPCItem>();

                foreach (var key in items.Keys)
                {
                    String realKey = opcPath + key;
                    var item = wrapper.AddGroupItem(this.MyGroup, realKey, items[key]);
                    if (item != null)
                    {
                        MyItem.Add(realKey, item);
                    }
                    else
                    {
                        logger.Warn("No item was found for key {0}", realKey);
                    }
                }

                logger.Info("Init opc service.");
            }
            catch (Exception ex)
            {
                logger.Error("Init opc service failed, {0}", ex.ToString());
            }
        }
        public Boolean HaveData()
        {
            String realKey = this.opcPath + Constants.OPC_START;
            var result = wrapper.ReadItem(this.MyItem[realKey]);

            if (result != null && result.ToString().Equals("1"))
            {
                return true;
            }

            return false;
        }
        private string GetItemValue(List<String> keys)
        {
            string result = string.Empty;

            foreach (var key in keys)
            {
                int a = 1;
                var tem = wrapper.ReadItem(this.MyItem[key]).ToString();
                if (tem != null)
                {

                    result += tem.ToString() + ",";
                }
                else
                    result += "Error,";
            }
            return result;
        }
        //所有PLC状态
        public string[] GetPlcStates()//7
        {
            try
            {
                string strValue = GetItemValue(new List<String>
                {
                    this.opcPath+Constants.OPC_START,
                    this.opcPath+Constants.OPC_DONE,
                    //this.opcPath+Constants.OPC_LIFT,
                    this.opcPath+Constants.OPC_RESULT0,
                  //this.opcPath+Constants.OPC_MOBY1,
                    //this.opcPath+Constants.OPC_MOBY2,
                    //this.opcPath+Constants.OPC_MOBY3,
                });
                if (strValue != null)
                {
                    strValue = strValue.TrimEnd(',');
                    strValue = strValue.Replace("True", "1");
                    strValue = strValue.Replace("False", "0");
                    string[] result = strValue.Split(',');
                    return result;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {                
                logger.Error("Faile to get plc states from OPC, {0}", ex.ToString());
                return null;
            }
        }
        public void UpdateIdenDone(int value)
        {
            try
            {
                OPCItem item;
                MyItem.TryGetValue("FAW.ssg122.CCR_Skid.iden_Done", out item);
                wrapper.WriteItem(item, value);
            }
            catch (Exception ex)
            {
                logger.Error("Write idendone to OPC failed, {0}", ex.ToString());
            }
        }
        public void UpdateIdenResult(char[] value)
        {
            try
            {
                OPCItem item;
                for (int i = 0; i < 4; i++)
                {
                    string key = "FAW.ssg122.CCR_Skid.iden_Result[" + i.ToString() + "]";
                    MyItem.TryGetValue(key, out item);
                    char ch = value[i];
                    wrapper.WriteItem(item, value[i]);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Write idenresult to OPC failed, {0}", ex.ToString());
            }
        }
    }
}
