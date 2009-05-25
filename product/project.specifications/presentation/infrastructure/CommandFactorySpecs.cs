using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.common;
using mars.rover.presentation.infrastructure;

namespace specifications.presentation.infrastructure
{
    public class CommandFactorySpecs
    {
    }

    public class when_creating_a_command_for_an_action : observations_for_a_sut_without_a_contract<CommandFactory>
    {
        it should_return_a_command_that_executes_the_action_when_invoked = () => was_executed.should_be_equal_to(true);

        context c = () => { was_executed = false; };

        because b = () =>
                        {
                            result = sut.create_for(() => was_executed = true);
                            result.run();
                        };

        static Command result;
        static bool was_executed;
    }
}