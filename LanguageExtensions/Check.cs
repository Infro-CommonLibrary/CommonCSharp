using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Check
    {
        public static T NotNull<T>(Expression<Func<T>> propertyLambda) where T : class =>
            NotNull<T>(propertyLambda.Compile()(), MemberInfo.GetMemberName(propertyLambda));
        public static T? NotNull<T>(Expression<Func<T?>> propertyLambda) where T : struct =>
            NotNull<T>(propertyLambda.Compile()(), MemberInfo.GetMemberName(propertyLambda));
        public static string NotEmpty(Expression<Func<string>> propertyLambda) =>
            NotEmpty(propertyLambda.Compile()(), MemberInfo.GetMemberName(propertyLambda));

        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, string parameterName) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"The argument {parameterName} is Null or Whitespace", parameterName);
            }

            return value;
        }
    }
}
