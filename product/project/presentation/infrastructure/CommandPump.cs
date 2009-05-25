using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public interface CommandPump : Command
    {
        void run<Command, Input>(Input input) where Command : ParameterizedCommand<Input>;
    }
}