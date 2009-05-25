using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public interface EventProcessor : Command
    {
        void process<Command, Input>(Input input) where Command : ParameterizedCommand<Input>;
    }
}