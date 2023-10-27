using System.Data;

using Browl.Infra.Managers;

namespace Browl.Infra.Repositories;
public class BaseRepository
{
	public BaseRepository(BaseConnectionManager connectionManager)
	{
		ConnectionManager = connectionManager;
	}

	internal protected BaseConnectionManager ConnectionManager { get; set; }

	protected IDbConnection _conn { get { return ConnectionManager.conn.Value; } }

	protected IDbTransaction _trans { get { return ConnectionManager.trans; } }

	public void Commit() => ConnectionManager.Commit();

	public void Rollback() => ConnectionManager.Rollback();
}
