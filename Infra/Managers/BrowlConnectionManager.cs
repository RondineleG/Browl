namespace Browl.Infra.Managers;
public class BrowlConnectionManager : BaseConnectionManager
{
	public BrowlConnectionManager()
	{
		conn = new Lazy<System.Data.IDbConnection>(() => ConnectionFactory.GetOpenConnection());
	}
}
