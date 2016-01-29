using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LanguageExtensions
{
    public static class MemberInfo
    {
        public static string GetMemberName<T>(Expression<Func<T>> propertyLambda)
        {
            Check.NotNull(propertyLambda, "propertyLambda");
            var result =
                    ((propertyLambda.Body as MemberExpression) ??
                    ((propertyLambda.Body as UnaryExpression)?.Operand as MemberExpression))
                        ?.Member.Name;
            if (result == null)
                throw new ArgumentException($"Expression '{ propertyLambda.ToString() }' is unsupported.");
            return result;
        }

        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(
            Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member =
                ((propertyLambda.Body as MemberExpression) ??
                ((propertyLambda.Body as UnaryExpression)?.Operand as MemberExpression));
            if (member == null)
                throw new ArgumentException($"Expression '{ propertyLambda.ToString() }' refers to a method, not a property.");

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"Expression '{ propertyLambda.ToString() }' refers to a field, not a property.");

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException($"Expression '{ propertyLambda.ToString() }' refers to a property that is not from type { type }.");

            return propInfo;
        }
    }
}
