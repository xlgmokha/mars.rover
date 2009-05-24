namespace mars.rover.presentation.infrastructure
{
    public interface ParameterizedCommand<T>
    {
        void run_with(T item);
    }
}