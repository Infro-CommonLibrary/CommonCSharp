using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Disposable
    {
        public static T Using<T, U>(Func<U> factory, Func<U, T> map) where U : IDisposable
        {
            using (U result = factory())
            {
                return map(result);
            }
        }
    }
}
