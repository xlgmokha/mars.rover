using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.common;
using mars.rover.presentation.infrastructure;

namespace specifications.presentation.infrastructure
{
    public class SynchronousCommandProcessorSpecs
    {
    }

    public class when_running_a_series_of_commands_synchronously :
        observations_for_a_sut_with_a_contract<CommandProcessor, SynchronousCommandProcessor>
    {
        it should_run_each_command = () =>
                                         {
                                             first.was_told_to(x => x.run());
                                             second.was_told_to(x => x.run());
                                         };

        context c = () =>
                        {
                            first = an<Command>();
                            second = an<Command>();
                        };

        because b = () =>
                        {
                            sut.add(first);
                            sut.add(second);
                            sut.run();
                        };

        static Command first;
        static Command second;
    }
}