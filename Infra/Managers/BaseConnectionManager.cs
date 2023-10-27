using System.Data;

namespace Browl.Infra.Managers;
public class BaseConnectionManager : IDisposable
{
	public Lazy<IDbConnection> conn;
	public IDbTransaction trans;
	public ConnType type;

	public BaseConnectionManager()
	{
		type = ConnType.Single;
	}

	public void BegginMultiTransaction()
	{
		type = ConnType.Multiple;
		if (trans == null || trans.Connection == null)
			trans = conn.Value.BeginTransaction();
	}

	public void Rollback()
	{
		if (trans != null)
		{
			trans.Rollback();
		}
	}

	public void Commit()
	{
		if (type == ConnType.Single || trans == null)
		{
			return;
		}
		try
		{
			trans.Commit();
		}	
		catch 
		{
			trans.Rollback();
			throw;
		}
	}



	public void Dispose()
	{
		if(trans != null)
		{
			trans.Dispose();
			trans = null;
		}

		if(conn != null)
		{
			conn.Value.Dispose();
			conn = null;
		}

		GC.SuppressFinalize(this);
	}
}

public enum ConnType
{
	Single,
	Multiple
}
