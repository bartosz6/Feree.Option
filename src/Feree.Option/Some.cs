using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public sealed class Some<T> : Option<T>, IEquatable<T>
    {
        public T Value { get; }
        internal Some(T value) => Value = value == null ? throw new ArgumentNullException(nameof(value)) : value;
        public override string ToString() => Value.ToString();
        public override Option<TOut> Bind<TOut>(Func<T, Option<TOut>> next) => next(Value) ?? new None<TOut>();
        public override async Task<Option<TOut>> BindAsync<TOut>(Func<T, Task<Option<TOut>>> next) => await next(Value) ?? new None<TOut>();
        public override TOut Map<TOut>(Func<T, TOut> onSome, Func<TOut> onNone) => onSome(Value);
        public override Task<TOut> MapAsync<TOut>(Func<T, Task<TOut>> onSome, Func<Task<TOut>> onNone) => onSome(Value);
        public static implicit operator T(Some<T> some) => some.Value;
        public override bool Equals(Option<T> other) => other is Some<T> some && some.Value.Equals(Value);
        public bool Equals(T other) => other != null && other.Equals(Value);
        public override bool Equals(object obj) => obj is Some<T> some && some.Value.Equals(Value) || obj is T value && value.Equals(Value);
        public override int GetHashCode() => Value.GetHashCode();
    }
}