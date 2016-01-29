using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageExtensions
{
    public static class Binding
    {
        public static Func<T2, T3> Bind<T1, T2, T3>(this Func<T1, T2, T3> function, T1 o1)
            => Currying.Curry(function)(o1);
        public static Func<T2, T3, T4> Bind<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> function, T1 o1)
            => (o2,o3) => Currying.Curry(function)(o1)(o2)(o3);
        public static Func<T2, T3, T4, T5> Bind<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> function, T1 o1)
            => (o2, o3, o4) => Currying.Curry(function)(o1)(o2)(o3)(o4); 
    }
}
