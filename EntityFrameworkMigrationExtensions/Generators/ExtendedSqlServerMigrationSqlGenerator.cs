using EntityFrameworkMigrationExtensions.Operations;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace EntityFrameworkMigrationExtensions.Generators
{
    public class ExtendedSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            var operation = migrationOperation as GrantPermissionOperation;
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine(
                      "GRANT {0} ON {1} TO {2}",
                      operation.Permission.ToString().ToUpper(),
                      operation.Table,
                      operation.User);

                    Statement(writer);
                }
            }
            base.Generate(migrationOperation);
        }
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedUtcColumn(addColumnOperation.Column);
            AddDefaultValue(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedUtcColumn(createTableOperation.Columns);
            foreach (var v in createTableOperation.Columns) AddDefaultValue(v);
            base.Generate(createTableOperation);
        }
        private static void AddDefaultValue(ColumnModel Column)
        {
            if (Column.Annotations.Any(o => o.Key == "DefaultValue"))
            {
                Column.DefaultValueSql = Column.Annotations["DefaultValue"].NewValue.ToString();
            }
        }
        private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreatedUtcColumn(columnModel);
            }
        }
        private static void SetCreatedUtcColumn(PropertyModel column)
        {
            if (column.Name == "CreatedUtc")
            {
                column.DefaultValueSql = "GETUTCDATE()";
            }
        }
    }
}