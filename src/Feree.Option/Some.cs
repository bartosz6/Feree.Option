using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public sealed class Some<T> : Option<T>
    {
        public T Value { get; }

        internal Some(T value) => Value = value == null ? throw new ArgumentNullException(nameof(value)) : value;

        public static implicit operator T(Some<T> some) => some.Value;
        
        public override string ToString() => Value.ToString();

        public override Option<TOut> Bind<TOut>(Func<T, Option<TOut>> next) => next(Value) ?? new None<TOut>();

        public override async Task<Option<TOut>> BindAsync<TOut>(Func<T, Task<Option<TOut>>> next) => await next(Value) ?? new None<TOut>();
    }
}