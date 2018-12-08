namespace Feree.Option
{
    public static class OptionFactory
    {
        public static Option<T> Some<T>(T value) => new Some<T>(value);
        public static Option<T> None<T>() => new None<T>();
    }
}