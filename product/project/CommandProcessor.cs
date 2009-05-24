namespace mars.rover
{
    public interface CommandProcessor : Command
    {
        void add(Command command);
    }
}