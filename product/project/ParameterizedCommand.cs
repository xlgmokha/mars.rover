namespace mars.rover
{
    public interface ParameterizedCommand<T>
    {
        void run_with(T item);
    }
}