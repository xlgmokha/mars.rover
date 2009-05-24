using System.Collections.Generic;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;
using mars.rover.common;
using mars.rover.presentation;
using mars.rover.presentation.model;

namespace specifications
{
    public class ProgramSpecs
    {
    }

    public abstract class behaves_like_a_program :
        observations_for_a_sut_with_a_contract<ParameterizedCommand<IEnumerable<CommandLineArgument>>, Program>
    {
        context c = () => { presenter = the_dependency<Presenter>(); };

        static protected Presenter presenter;
    }

    public class when_the_program_begins : behaves_like_a_program
    {
        it should_wait_for_instructions_from_nasa = () => presenter.received(x => x.run());

        because b = () => sut.run_against(args);

        static readonly IEnumerable<CommandLineArgument> args = new List<CommandLineArgument> {""};
    }
}