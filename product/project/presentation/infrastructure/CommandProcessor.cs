using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public interface CommandProcessor : Command
    {
        void add(Command command);
    }
}