using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Utilities
{
    public class Constants
    {
        //
        public static String SERVICENAME = Configurations.Get("SERVICENAME");
        public static String SERVICDESCRIPTION = Configurations.Get("SERVICDESCRIPTION");
        public static String SERVICESTATERUNING = Configurations.Get("SERVICESTATERUNING");//2020-04-25
        public static String SERVICESTATESTOPED = Configurations.Get("SERVICESTATESTOPED");//2020-04-25
        public static String SERVICEINSTALL = Configurations.Get("SERVICEINSTALL");//2020-04-25
        public static String SERVICEUNINSTALL = Configurations.Get("SERVICEUNINSTALL");//2020-04-25

        public static String OPCIP = Configurations.Get("OPCIP");
        public static String OPCPATH = Configurations.Get("OPCPATH");
        public static String OPCName = Configurations.Get("OPCNAME");
        public static String OPCKEEPALIVEPATH = Configurations.Get("OPCKEEPALIVEPATH");

        public static String CAMERAPATH = Configurations.Get("CAMERAPATH"); 
        public static String LOGPATH = Configurations.Get("LOGPATH");
        public static String SNAPIMAGEPATH = Configurations.Get("SNAPIMAGEPATH");
        public static String BKIMAGE = Configurations.Get("BKIMAGE");

        //工作时间区间
        public static String DAYTime_0 = "06:00";
        public static String DAYTime_1 = "09:00";
        public static String DAYTime_2 = "10:00";
        public static String DAYTime_3 = "11:00";
        public static String DAYTime_4 = "12:30";
        public static String DAYTime_5 = "13:30";
        public static String DAYTime_6 = "14:30";
        public static String DAYTime_7 = "15:30";
        public static String DAYTime_8 = "16:30";
        //PLC
        public static String OPC_DONE = Configurations.Get("OPC_DONE");
        public static String OPC_LIFT = Configurations.Get("OPC_LIFT");
        public static String OPC_RESULT = Configurations.Get("OPC_RESULT");
        public static String OPC_RESULT0 = Configurations.Get("OPC_RESULT0");
        public static String OPC_RESULT1 = Configurations.Get("OPC_RESULT1");
        public static String OPC_RESULT2 = Configurations.Get("OPC_RESULT2");
        public static String OPC_RESULT3 = Configurations.Get("OPC_RESULT3");
        public static String OPC_START = Configurations.Get("OPC_START");

        public static String OPC_MOBY0 = Configurations.Get("OPC_MOBY0");
        public static String OPC_MOBY1 = Configurations.Get("OPC_MOBY1");
        public static String OPC_MOBY2 = Configurations.Get("OPC_MOBY2");
        public static String OPC_MOBY3 = Configurations.Get("OPC_MOBY3");
        public static String OPC_09 = Configurations.Get("OPC_09");
        public static String OPC_10 = Configurations.Get("OPC_10");
        public static String OPC_11 = Configurations.Get("OPC_11");
        public static String OPC_12 = Configurations.Get("OPC_12");
        public static String OPC_13 = Configurations.Get("OPC_13");

        public static List<String> Keys = new List<string>()
        {
            OPC_START,
            OPC_DONE,
            OPC_RESULT0,
            OPC_RESULT1,
            OPC_RESULT2,
            OPC_RESULT3,
        };
        //T_output
        public static String O_1 = "O_one";
        public static String O_2 = "O_two";
        public static String O_3 = "O_three";
        public static String O_4 = "O_four";
        public static String O_5 = "O_five";
        public static String O_6 = "O_six";
        public static String O_7 = "O_seven";
        public static String O_8 = "O_eight";

        public static List<String> OValues = new List<string>()//
        {
            O_1,
            O_2,
            O_3,
            O_4,
            O_5,
            O_6,
            O_7,
            O_8,
        };
    }        
}
