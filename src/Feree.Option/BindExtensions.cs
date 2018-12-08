using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public static class BindExtensions
    {
        public static async Task<IOption<TOut>> BindAsync<TIn, TOut>(this Task<IOption<TIn>> prev,
            Func<TIn, Task<IOption<TOut>>> next) =>
            await prev is Some<TIn> some
                ? await next(some)
                : OptionFactory.None<TOut>();
    }
}