using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMigrationExtensions.Operations
{
    public enum Permission
    {
        Select,
        Update,
        Delete
    }

    public class GrantPermissionOperation : MigrationOperation
    {
        public GrantPermissionOperation(string table, string user, Permission permission)
          : base(null)
        {
            Table = table;
            User = user;
            Permission = permission;
        }

        public string Table { get; private set; }
        public string User { get; private set; }
        public Permission Permission { get; private set; }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }
    }
}
