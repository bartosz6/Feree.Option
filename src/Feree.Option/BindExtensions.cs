using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public static class BindExtensions
    {
        public static async Task<Option<TOut>> BindAsync<TIn, TOut>(this Task<Option<TIn>> prev,
            Func<TIn, Task<Option<TOut>>> next) =>
            await prev is Some<TIn> some
                ? await next(some) ?? OptionFactory.None<TOut>()
                : OptionFactory.None<TOut>();
    }
}