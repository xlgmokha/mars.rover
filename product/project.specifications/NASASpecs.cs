using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class NASASpecs
    {
    }

    public class when_nasa_deploys_a_rover_to_a_position_on_mars : observations_for_a_sut_without_a_contract<NASA>
    {
        it should_return_a_new_rover = () => result.should_not_be_null();

        because b = () => { result = sut.deploy_rover_to(1, 2, Headings.North); };

        static Rover result;
    }
}