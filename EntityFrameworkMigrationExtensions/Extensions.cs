using EntityFrameworkMigrationExtensions.Operations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMigrationExtensions
{
    public static class Extensions
    {
        public static void GrantPermission(this DbMigration migration, string table, string user, Permission permission)
        {
            ((IDbMigration)migration)
              .AddOperation(new GrantPermissionOperation(table, user, permission));
        }
    }
}
