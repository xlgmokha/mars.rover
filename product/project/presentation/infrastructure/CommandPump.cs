using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public interface CommandPump<Input> : Command
    {
        void run<Command>(Input input) where Command : ParameterizedCommand<Input>;
    }
}