using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.domain;
using Rhino.Mocks;

namespace specifications.domain
{
    public class NASASpecs
    {
    }

    public class when_retrieving_the_last_deployed_rover : observations_for_a_sut_without_a_contract<NASA>
    {
        it should_return_the_last_deployed_rover = () => result.should_be_equal_to(rover);

        context c =
            () => { rover = MockRepository.GenerateMock<Rover>(new Coordinate(0), new Coordinate(0), an<Heading>()); };

        because b = () =>
                        {
                            sut.deploy(rover);
                            result = sut.waiting();
                        };

        static Rover rover;
        static Rover result;
    }
}