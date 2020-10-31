using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DX.Utilities;

namespace DX.Database
{
    public class DBUtil
    {
        public static String MysqlConnectionString = Configurations.Get("MysqlConnString");

        public static IDbDataParameter SetParam(IDbCommand inCommand, string inParamName, DbType inType, object inValue)
        {
            IDbDataParameter parameter;
            int index = inCommand.Parameters.IndexOf(inParamName);
            if (index < 0)
            {
                parameter = inCommand.CreateParameter();
                inCommand.Parameters.Add(parameter);
                parameter.ParameterName = inParamName;
                parameter.DbType = inType;
            }
            else
            {
                parameter = (IDbDataParameter)inCommand.Parameters[index];
            }
            parameter.Value = inValue;
            return parameter;
        }
    }
}
