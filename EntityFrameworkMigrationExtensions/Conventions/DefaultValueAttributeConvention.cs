using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LanguageExtensions;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace EntityFrameworkMigrationExtensions.Conventions
{
    public class DefaultValueAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<DefaultValueAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DefaultValueAttribute attribute)
        {
            Check.NotNull(() => configuration);
            Check.NotNull(() => attribute);
        }
    }
}
