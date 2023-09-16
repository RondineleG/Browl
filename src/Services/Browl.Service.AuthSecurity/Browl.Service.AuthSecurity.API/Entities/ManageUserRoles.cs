using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Browl.Service.AuthSecurity.API.Entities
{
	public class ManageUserRoles
	{
		public string RoleId { get; set; }
		public string RoleName { get; set; }
		public bool Selected { get; set; }
	}
}
