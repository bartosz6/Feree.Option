using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public sealed class None<T> : Option<T>
    {
        internal None()
        {
        }

        public override Option<TOut> Bind<TOut>(Func<T, Option<TOut>> next) => new None<TOut>();

        public override Task<Option<TOut>> BindAsync<TOut>(Func<T, Task<Option<TOut>>> next) =>
            Task.FromResult((Option<TOut>) new None<TOut>());
    }
}