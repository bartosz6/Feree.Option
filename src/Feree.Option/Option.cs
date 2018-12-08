using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public abstract class Option<T>
    {
        public abstract Option<TOut> Bind<TOut>(Func<T, Option<TOut>> next);
        public abstract Task<Option<TOut>> BindAsync<TOut>(Func<T, Task<Option<TOut>>> next);
        
        public static implicit operator Option<T>(T value) => value == null 
            ? (Option<T>) new None<T>() 
            : new Some<T>(value);
    }
}