using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace System
{
    //Ref: http://blogs.msdn.com/b/wesdyer
    public static class Memoizing
    {
        public static Func<R> Memoize<R>(this Func<R> f)
        {
            R value = default(R);
            bool hasValue = false;
            return () =>
            {
                if (!hasValue)
                {
                    hasValue = true;
                    value = f();
                }
                return value;
            };
        }
        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var map = new Dictionary<A, R>();
            return a =>
            {
                R value;
                if (map.TryGetValue(a, out value))
                    return value;
                value = f(a);
                map.Add(a, value);
                return value;
            };
        }
        static Func<A, R> MemoizeFix<A, R>(this Func<Func<A, R>, Func<A, R>> f)
        {
            Func<A, R> g = null;
            Func<A, R> h = null;
            g = a => f(h)(a);
            h = g.Memoize();
            return h;
        }
    }
}
