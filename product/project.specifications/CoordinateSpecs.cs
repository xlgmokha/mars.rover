using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class CoordinateSpecs
    {
    }

    public class when_a_coordinate_is_compared_to_another_coordinate : observations_for_a_static_sut
    {
        it should_tell_which_is_greater = () => new Coordinate(2).CompareTo(1).should_be_greater_than(0);
        it should_tell_which_is_lower = () => new Coordinate(1).CompareTo(2).should_be_less_than(0);
        it should_tell_when_they_are_equal = () => new Coordinate(1).CompareTo(1).should_be_equal_to(0);

        static int result;
    }
}