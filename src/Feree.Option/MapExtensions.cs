using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public static class MapExtensions
    {
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<Option<TIn>> prev,
            Func<TIn, Task<TOut>> onSome, Func<Task<TOut>> onNone) =>
            await prev is Some<TIn> some
                ? await onSome(some.Value)
                : await onNone();
        
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<Option<TIn>> prev,
            Func<TIn, TOut> onSome, Func<TOut> onNone) =>
            await prev is Some<TIn> some
                ? onSome(some.Value)
                : onNone();
    }
}