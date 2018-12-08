using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public abstract class Some
    {
    }
    public sealed class Some<T> : Some, IOption<T>
    {
        public T Value { get; }

        internal Some(T value) => Value = value == null ? throw new ArgumentNullException(nameof(value)) : value;

        public static implicit operator T(Some<T> some) => some.Value;
        
        public static explicit operator Some<T>(T value) => new Some<T>(value);
        
        public override string ToString() => Value.ToString();

        public IOption<TOut> Bind<TOut>(Func<T, IOption<TOut>> next) => next(Value);
        public Task<IOption<TOut>> BindAsync<TOut>(Func<T, Task<IOption<TOut>>> next) => next(Value);
    }
}