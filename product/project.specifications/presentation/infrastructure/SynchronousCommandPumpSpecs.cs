using System;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.common;
using mars.rover.presentation.infrastructure;
using Rhino.Mocks;

namespace specifications.presentation.infrastructure
{
    public class SynchronousCommandPumpSpecs
    {
    }

    public class when_putting_a_command_on_the_command_processor :
        observations_for_a_sut_with_a_contract<EventProcessor, SynchronousCommandPump>
    {
        it should_place_the_correct_command_on_the_processor =
            () => processor.received(x => x.add(Arg<Command>.Is.Anything));

        context c = () =>
                        {
                            processor = the_dependency<CommandProcessor>();
                            registry = the_dependency<Registry<ParameterizedCommand<string>>>();
                            factory = the_dependency<CommandFactory>();
                            correct = an<Correct>();
                            incorrect = an<InCorrect>();
                            registry.is_told_to(x => x.all()).it_will_return(correct, incorrect);
                        };

        because b = () => sut.process<Correct, string>("blah");

        static CommandProcessor processor;
        static Registry<ParameterizedCommand<string>> registry;
        static CommandFactory factory;
        static Correct correct;
        static InCorrect incorrect;
    }

    public class InCorrect : ParameterizedCommand<string>
    {
        public void run_against(string item)
        {
            throw new NotImplementedException();
        }
    }

    public class Correct : ParameterizedCommand<string>
    {
        public void run_against(string item)
        {
            throw new NotImplementedException();
        }
    }
}