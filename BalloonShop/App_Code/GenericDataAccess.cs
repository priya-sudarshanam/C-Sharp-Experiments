using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for GenericDataAccess
/// </summary>
public static class GenericDataAccess
{
	static GenericDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //executes command and returns the result as a Datatable object
    public static DataTable ExecuteSelectCommand(DbCommand command)
    {
        DataTable table;
        try
        {
            //open data connection, execute command and save results in a
            //datatable
            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            //close reader
            reader.Close();

        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            //close the connection
            command.Connection.Close();

        }
        return table;
    }

    public static DbCommand CreateCommand()
    {
         string dataProviderName = BalloonShopConfiguration.DbProviderName;
         string connectionString = BalloonShopConfiguration.DbConnectionString;
         DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
         DbConnection conn = factory.CreateConnection();
         conn.ConnectionString = connectionString;

         DbCommand comm = conn.CreateCommand();
         comm.CommandType = CommandType.StoredProcedure;

         return comm;

    }
}