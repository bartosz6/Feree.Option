using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public abstract class None
    {
    }
    
    public sealed class None<T> : None, IOption<T>
    {
        internal None()
        {
        }

        public IOption<TOut> Bind<TOut>(Func<T, IOption<TOut>> next) => new None<TOut>();

        public Task<IOption<TOut>> BindAsync<TOut>(Func<T, Task<IOption<TOut>>> next) =>
            Task.FromResult((IOption<TOut>) new None<TOut>());
    }
}