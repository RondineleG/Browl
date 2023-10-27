using System.Data.Common;
using System.Data.SqlClient;

using Browl.CrossCutting;

namespace Browl.Infra
{
	internal static class ConnectionFactory
    {
		public static DbConnection GetOpenConnection()
		{
			var connection = new SqlConnection(ConnectionStrings.BrowlConnectionString);

			if(connection.State != System.Data.ConnectionState.Open)
				connection.Open();

			return connection;
		}

    }
}
