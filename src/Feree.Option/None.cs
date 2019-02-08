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
            Task.FromResult(OptionFactory.None<TOut>());
        public override TOut Map<TOut>(Func<T, TOut> onSome, Func<TOut> onNone) => onNone();
        public override Task<TOut> MapAsync<TOut>(Func<T, Task<TOut>> onSome, Func<Task<TOut>> onNone) => onNone();
        public override bool Equals(Option<T> other) => other is None<T>;
        public override bool Equals(object obj) => obj is None<T>;
        public override int GetHashCode() => 0;
    }
}