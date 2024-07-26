using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;

namespace PNB.Data
{
    public class SqlDataAccess
    {
        public int ExecuteNonQuerySuccess;
        public string cs1 = "";

        public SqlDataAccess()
        {
            //In thisoverride, in order to retrieve Connection String we use GetConnString() method
            GetConnString();
        }

        public SqlDataAccess(string connectionString)
        {
            cs1 = connectionString;
        }
        string GetConnString()
        {
            if (string.IsNullOrEmpty(cs1))
                cs1 = Configuration.ConnectionString;
            return cs1;
        }
        public DataTable Execute(string queryString, out string err)
        {
            err = "";
            DataTable dt = new DataTable();

            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(GetConnString());
                command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                dt.Load(command.ExecuteReader());
                dt.TableName = "Table 1";
            }
            //catch (SqlException se)
            //{
            //    err = se.Message;
            //    dt = null;
            //}
            catch (Exception ee)
            {
                err = ee.Message;
                dt = null;
            }
            return dt;
        }
        public DataSet Execute(string queryString)
        {
            DataSet ds = new DataSet();

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(GetConnString());
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                adapter.Fill(ds, "dataset");
            }
            catch //(Exception ee)
            {
                ds = null;
            }
            return ds;
        }

        public int ExecuteNonQuery(string spName, SqlParameter[] parameters)
        {
            int result = -2;
            try
            {
                SqlConnection connection = new SqlConnection(GetConnString());
                SqlCommand command = new SqlCommand(spName, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                command.Connection.Open();

                result = command.ExecuteNonQuery();
                connection.Close();
                ExecuteNonQuerySuccess++;
            }
            catch (SqlException se)
            {
                if (se.ErrorCode != -2146232060)/// A network-related or instance-specific error occurred while establishing a connection to 
                    Logger.Log(se, "DB");

                result = se.ErrorCode;
            }
            catch (Exception ee)
            {
                Logger.Log(ee, "DB");
                result = ee.HResult;
            }

            return result;
        }
        public int ExecuteNonQuery(string queryString)
        {
            int result = -1;
            try
            {
                SqlConnection connection = new SqlConnection(GetConnString());

                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.Text;
                command.Connection.Open();

                result = command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {

            }
            catch (Exception ee) { Logger.Log(ee); }
            return result;
        }


        public static void Upgrade()
        {
            ThreadPool.QueueUserWorkItem(InternalDBBackup, null);
        }
        private static void InternalDBBackup(object obj)
        {
            SqlDataAccess sqldata = new SqlDataAccess();

            ///Execute 'UpdateTables' SP
            /// TODO
            string[] queries = new string[23];
            queries[00] = "DROP TABLE TextData;";
            queries[01] = "DROP TABLE NumericData;";
            queries[02] = "DROP TABLE BooleanData;";
            queries[03] = "DROP TABLE SessionData;";
            queries[04] = "DROP TABLE Users;";
            queries[05] = "DROP TABLE Alarms;";
            queries[06] = "DROP PROCEDURE DELETEALLDATA;";
            queries[07] = "DROP PROCEDURE INSERTALARM;";
            queries[08] = "DROP PROCEDURE INSERTBOOLEANDATA;";
            queries[09] = "DROP PROCEDURE INSERTNUMERICDATA;";
            queries[10] = "DROP PROCEDURE INSERTSESSION;";
            queries[11] = "DROP PROCEDURE INSERTTEXTDATA;";
            queries[12] = "CREATE TABLE SessionData ([Id] UNIQUEIDENTIFIER DEFAULT(newsequentialid()) NOT NULL,[terminalTime] BIGINT NOT NULL,[serverTime]   BIGINT NOT NULL,[comment] NVARCHAR(MAX)   NOT NULL,[visualCheck]  BIT NOT NULL,[userId] BIGINT NOT NULL,[rfCode] BIGINT NOT NULL,[terminalId]   BIGINT NOT NULL,CONSTRAINT[PK_SessionData] PRIMARY KEY CLUSTERED([Id] ASC));";
            queries[13] = "CREATE TABLE Alarms([Id] BIGINT NOT NULL,[RFTag]  BIGINT NOT NULL,[MetaID] BIGINT NOT NULL,   [State]  INT NULL,    [time]   BIGINT NULL,    PRIMARY KEY CLUSTERED([Id] ASC));";
            queries[14] = "CREATE TABLE BooleanData([id] UNIQUEIDENTIFIER NOT NULL, [Vid] BIGINT NOT NULL, [data1] BIT NOT NULL, CONSTRAINT[FK_BooleanData_ToTable] FOREIGN KEY([id]) REFERENCES SessionData([Id]));";
            queries[15] = "CREATE TABLE NumericData ([id] UNIQUEIDENTIFIER NOT NULL,[Vid] BIGINT NOT NULL,[data1] FLOAT(53) NOT NULL,CONSTRAINT[FK_NumericData_ToTable] FOREIGN KEY([id]) REFERENCES SessionData([Id]));";
            queries[16] = "CREATE TABLE TextData ([id] UNIQUEIDENTIFIER NOT NULL,[Vid] BIGINT NOT NULL,[data1] NCHAR(500) NOT NULL, CONSTRAINT[FK_TextData_ToTable] FOREIGN KEY([id]) REFERENCES SessionData([Id]));";
            queries[17] = "CREATE PROCEDURE DeleteAllData AS BEGIN delete from Alarms;delete from TextData;delete from BooleanData;delete from NumericData;delete from SessionData;END";
            queries[18] = "CREATE PROCEDURE InsertAlarm  @id bigint,@RFTag bigint,@MetaID bigint,@state int,@time bigint  AS BEGIN SET NOCOUNT ON INSERT INTO dbo.Alarms(id,RFTag,MetaID,State,time)VALUES(@id,@RFTag,@MetaID,@state,@time)END";
            queries[19] = "CREATE PROCEDURE InsertBooleanData @id uniqueidentifier,@Vid bigint,@data1 bit AS BEGIN  SET NOCOUNT ON     INSERT INTO dbo.BooleanData(id,Vid,data1)VALUES(@id,@Vid,@data1)END";
            queries[20] = "CREATE PROCEDURE InsertNumericData @id uniqueidentifier,@Vid bigint,@data1 float AS BEGIN  SET NOCOUNT ON     INSERT INTO dbo.numericData(id,Vid,data1)VALUES(@id,@Vid,@data1)END";
            queries[21] = "CREATE PROCEDURE InsertTextData @id uniqueidentifier,@Vid bigint, @data1  nvarchar(max) AS BEGIN SET NOCOUNT ON     INSERT INTO dbo.TextData(id, Vid, data1)VALUES(@id, @Vid, @data1)END";
            queries[22] = "CREATE PROCEDURE InsertSession   @id as uniqueidentifier OUT, @terminalTime bigint = NULL,@serverTime  bigint = NULL   , @comment nchar(100) = NULL   , @visualCheck bit = NULL, @userid2  bigint = NULL   , @rfCode bigint = NULL, @terminalId bigint = NULL AS BEGIN declare @returnid table(id uniqueidentifier) INSERT INTO dbo.SessionData   (terminalTime,serverTime,comment,visualCheck,userId,rfCode,terminalId)     output inserted.id into @returnid VALUES(@terminalTime,@serverTime,@comment,@visualCheck,@userid2,@rfCode,@terminalId)select @id = r.id from @returnid r END";

            foreach (string sql in queries)
            {
                Logger.Debug("Executing Query: " + sql);
                int res = sqldata.ExecuteNonQuery(sql);
            }
        }
    }

    public class SqlHelper
    {
        public class DBServer
        {
            public string ServerName;
            public string InstanceName;
            public string Version;
        }
        public static string ExportTableData(string table, string path)
        {
            string path1 = $"{path}{table} - {Util.ConvertDateTimeToFileName(false)}.xml";
            string strSql = $"SELECT * FROM {table};";

            SqlDataAccess sqlda = new SqlDataAccess();
            DataTable dt = sqlda.Execute(strSql, out string err);
            dt.TableName = table;

            try
            {
                dt.WriteXml(path1);
            }
            catch (Exception ee) { path1 = ee.Message; }
            return path1;
        }

        public static DBServer[] GetInstanceNames()
        {
            List<DBServer> names = new List<DBServer>();
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in dt.Rows)
            {
                DBServer dbs = new DBServer();
                names.Add(dbs);

                dbs.ServerName = row[0].ToString().Trim();
                dbs.InstanceName = row[1].ToString().Trim();
                dbs.Version = row[2].ToString().Trim();
            }
            return names.ToArray();
        }

    }
}
