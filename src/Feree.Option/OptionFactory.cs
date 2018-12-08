namespace Feree.Option
{
    public static class OptionFactory
    {
        public static IOption<T> Some<T>(T value) => new Some<T>(value);
        public static IOption<T> None<T>() => new None<T>();
    }
}