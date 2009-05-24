namespace mars.rover.common
{
    public interface ParameterizedCommand<T>
    {
        void run_against(T item);
    }
}