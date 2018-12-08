using System;
using System.Threading.Tasks;

namespace Feree.Option
{
    public interface IOption<out T>
    {
        IOption<TOut> Bind<TOut>(Func<T, IOption<TOut>> next);
        Task<IOption<TOut>> BindAsync<TOut>(Func<T, Task<IOption<TOut>>> next);
    }
}