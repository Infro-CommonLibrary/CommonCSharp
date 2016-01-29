using System;

namespace LanguageExtensions
{
    public static class Currying
    {
        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> function)
            => a => b => function(a, b);

        public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> function)
            => a => b => c => function(a, b, c);

        public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> function)
            => a => b => c => d => function(a, b, c, d);

        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, T6>>>>> Curry<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> function)
            => a => b => c => d => e => function(a, b, c, d, e);

        public static CurryDynamic CurryObject<T1, T2, O1>(this Func<T1, T2, O1> function)
        {
            return new CurryDynamic(typeof(O1), typeof(T1), typeof(T2));
        }
    }

    public class CurryDynamic
    {
        public CurryDynamic(Type Output, params Type[] inputs)
        {
            //You Aren't Going To Need It
            throw new NotImplementedException("You aren't going to need it fail.");
        }
    }
}