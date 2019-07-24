using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Infrastructure
{
   public class DBHelper
    {
        #region "Private Members"

        private string _ConnString;
        private DbConnection _Connection;
        private DbCommand _Command;
        private DbProviderFactory _Factory = null;

        #endregion

        #region "Cunstructor"
        ///<summary>
        /// Cunstructor
        ///</summary>        
        public DBHelper()
        {
            this._ConnString = string.Empty;
            this.CreateConnection();
        }
        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or Sets the Connection string for the database
        /// </summary>
        public string ConnString
        {
            get { return _ConnString; }
            set
            {
                if (value != string.Empty)
                {
                    _ConnString = value;
                }
            }
        }

        /// <summary>
        /// Gets the Connection object for the database
        /// </summary>
        public DbConnection Connection
        {
            get { return _Connection; }
        }

        /// <summary>
        /// Gets the Command object for the database
        /// </summary>
        public DbCommand Command
        {
            get { return _Command; }
        }

        #endregion

        # region "Methods"

        public void CreateConnection()
        {
            var ConnectionStrindsfsdg = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            CreateDBObjects(ConfigurationManager.ConnectionStrings["ConnString"].ToString(),
                ConfigurationManager.ConnectionStrings["ConnString"].ProviderName);
        }

        /// <summary>
        /// Determines the correct provider to use and sets up the Connection and Command
        /// objects for use in other methods
        /// </summary>
        /// <param name="connectString">The full Connection string to the database</param>
        /// <param name="providerlist">The enum value of providers from dbutilities.Providers</param>
        public void CreateDBObjects(string connectString, string strProvider)
        {
            _Factory = DbProviderFactories.GetFactory(strProvider);
            _Connection = _Factory.CreateConnection();
            _Command = _Factory.CreateCommand();

            _Connection.ConnectionString = connectString;
            _Command.Connection = Connection;
        }

        #region "Parameters"

        /// <summary>
        /// Creates a parameter and adds it to the Command object
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The paremeter value</param>
        /// <returns></returns>
        public int AddParameter(string name, object value)
        {
            DbParameter parm = _Factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;
            return Command.Parameters.Add(parm);
        }

        /// <summary>
        /// Creates a parameter and adds it to the Command object
        /// </summary>
        /// <param name="parameter">A parameter object</param>        
        public int AddParameter(DbParameter parameter)
        {
            return Command.Parameters.Add(parameter);
        }

        /// <summary>
        /// Creates a parameter and adds it to the Command object
        /// </summary>
        /// <param name="name">A parameter Name</param>
        /// <param name="Value">A parameter Value</param>
        /// <param name="dbType">A parameter data type</param>
        public int AddParameter(string name, object value, DbType dbtype)
        {
            DbParameter parm = _Factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;
            parm.DbType = dbtype;
            return Command.Parameters.Add(parm);
        }

        /// <summary>
        /// Creates a parameter and adds it to the Command object
        /// </summary>
        /// <param name="name">A parameter Name</param>
        /// <param name="Value">A parameter Value</param>
        /// <param name="dbType">A parameter data type</param>
        /// <param name="size">A prameter size in int</param>
        public int AddParameter(string name, object value, DbType dbtype, int size)
        {
            DbParameter parm = _Factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;
            parm.DbType = dbtype;
            parm.Size = size;
            return Command.Parameters.Add(parm);
        }

        /// <summary>
        /// Creates a parameter and adds it to the Command object
        /// </summary>
        /// <param name="name">A parameter Name</param>
        /// <param name="Value">A parameter Value</param>
        /// <param name="dbType">A parameter data type</param>
        /// <param name="Direction">A prameter Direction</param>
        public int AddParameter(string name, object value, DbType dbtype, ParameterDirection direction)
        {
            DbParameter parm = _Factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;
            parm.DbType = dbtype;
            parm.Direction = direction;
            return Command.Parameters.Add(parm);
        }

        /// <summary>
        /// Creates a parameter and adds it to the Command object
        /// </summary>
        /// <param name="name">A parameter Name</param>
        /// <param name="Value">A parameter Value</param>
        /// <param name="dbType">A parameter data type</param>
        /// <param name="size">A prameter size in int</param>
        /// <param name="Direction">A prameter Direction</param>
        public int AddParameter(string name, object value, DbType dbtype, int size, ParameterDirection direction)
        {
            DbParameter parm = _Factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;
            parm.DbType = dbtype;
            parm.Size = size;
            parm.Direction = direction;
            return Command.Parameters.Add(parm);
        }

        #endregion

        #region "DB Transactions"

        /// <summary>
        /// Starts a transaction for the Command object
        /// </summary>
        private void BeginTransaction()
        {
            if (Connection.State.Equals(ConnectionState.Closed))
            {
                Connection.Open();
            }
            Command.Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        /// Commits a transaction for the Command object
        /// </summary>
        private void CommitTransaction()
        {
            Command.Transaction.Commit();
            Connection.Close();
        }

        /// <summary>
        /// Rolls back the transaction for the Command object
        /// </summary>
        private void RollbackTransaction()
        {
            Command.Transaction.Rollback();
            Connection.Close();
        }

        #endregion

        #region "Execute DB Functions"

        /// <summary>
        /// Executes a statement that does not return a result set, such as an INSERT, UPDATE, DELETE, or a data definition statement
        /// </summary>
        /// <param name="query">The query, either SQL or Procedures</param>
        /// <param name="Commandtype">The Command type, text, storedprocedure, or tabledirect</param>
        /// <param name="Connectionstate">The Connection state</param>
        /// <returns>An integer value</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            Command.CommandText = commandText;
            Command.CommandType = commandType;
            int i = -1;

            try
            {
                if (Connection.State.Equals(ConnectionState.Closed))
                {
                    Connection.Open();
                }

                //BeginTransaction();

                i = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //RollbackTransaction();
                throw (ex);
            }
            finally
            {
                //CommitTransaction();
                Command.Parameters.Clear();

                if (Connection.State.Equals(ConnectionState.Open))
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }

            return i;
        }

        /// <summary>
        /// Executes a statement that returns a single value. 
        /// If this method is called on a query that returns multiple rows and columns, only the first column of the first row is returned.
        /// </summary>
        /// <param name="query">The query, either SQL or Procedures</param>
        /// <param name="Commandtype">The Command type, text, storedprocedure, or tabledirect</param>
        /// <param name="Connectionstate">The Connection state</param>
        /// <returns>An object that holds the return value(s) from the query</returns>
        public object ExecuteScaler(string commandText, CommandType commandType)
        {
            Command.CommandText = commandText;
            Command.CommandType = commandType;

            object obj = null;
            try
            {
                if (Connection.State.Equals(ConnectionState.Closed))
                {
                    Connection.Open();
                }

                BeginTransaction();
                obj = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw (ex);
            }
            finally
            {
                CommitTransaction();
                Command.Parameters.Clear();

                if (Connection.State.Equals(ConnectionState.Open))
                {
                    Connection.Close();
                    Connection.Dispose();
                    Command.Dispose();
                }
            }

            return obj;
        }

        /// <summary>
        /// Executes a SQL statement that returns a result set.
        /// </summary>
        /// <param name="query">The query, either SQL or Procedures</param>
        /// <param name="Commandtype">The Command type, text, storedprocedure, or tabledirect</param>
        /// <param name="Connectionstate">The Connection state</param>
        /// <returns>A datareader object</returns>
        public DbDataReader ExecuteReader(string query, CommandType Commandtype)
        {
            //this.CreateConnection();
            Command.CommandText = query;
            Command.CommandType = Commandtype;
            DbDataReader reader = null;
            try
            {
                if (Connection.State.Equals(ConnectionState.Closed))
                {
                    Connection.Open();
                }
                reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Command.Parameters.Clear();
            }

            return reader;
        }

        /// <summary>
        /// Generates a dataset
        /// </summary>
        /// <param name="query">The query, either SQL or Procedures</param>
        /// <param name="Commandtype">The Command type, text, storedprocedure, or tabledirect</param>
        /// <param name="Connectionstate">The Connection state</param>
        /// <returns>A dataset containing data from the database</returns>
        public DataSet GetDataSet(string query, CommandType Commandtype)
        {
            DbDataAdapter adapter = _Factory.CreateDataAdapter();
            Command.CommandText = query;
            Command.CommandType = Commandtype;
            adapter.SelectCommand = Command;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Parameters.Clear();

                if (Connection.State.Equals(ConnectionState.Open))
                {
                    Connection.Close();
                    Connection.Dispose();
                    Command.Dispose();
                }
            }
            return ds;
        }

        /// <summary>
        /// Generates a dataset
        /// </summary>
        /// <param name="query">The query, either SQL or Procedures</param>
        /// <param name="Commandtype">The Command type, text, storedprocedure, or tabledirect</param>
        /// <param name="Connectionstate">The Connection state</param>
        /// <returns>A dataset containing data from the database</returns>
        public DataSet GetDataSet(string query, CommandType Commandtype, string tableName)
        {
            DbDataAdapter adapter = _Factory.CreateDataAdapter();
            Command.CommandText = query;
            Command.CommandType = Commandtype;
            adapter.SelectCommand = Command;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, tableName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Parameters.Clear();

                if (Connection.State.Equals(ConnectionState.Open))
                {
                    Connection.Close();
                    Connection.Dispose();
                    Command.Dispose();
                }
            }
            return ds;
        }

        #endregion

        #endregion
    }
}
