using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.domain;

namespace specifications.domain
{
    public class CoordinateSpecs
    {
    }

    public class when_a_coordinate_is_compared_to_another_coordinate : observations_for_a_static_sut
    {
        it should_tell_which_is_greater = () => new Coordinate(2).CompareTo(1).should_be_greater_than(0);
        it should_tell_which_is_lower = () => new Coordinate(1).CompareTo(2).should_be_less_than(0);
        it should_tell_when_they_are_equal = () => new Coordinate(1).CompareTo(1).should_be_equal_to(0);
    }

    public class when_one_coordinate_is_added_to_another_coordinate :
        observations_for_a_sut_without_a_contract<Coordinate>
    {
        it should_return_a_new_coordinate_with_the_proper_grid_point = () => result.should_be_equal_to<Coordinate>(2);

        context c = () =>
                        {
                            uint initial = 1;
                            provide_a_basic_sut_constructor_argument(initial);
                        };

        because b = () => { result = sut.plus(1); };

        static Coordinate result;
    }

    public class when_one_coordinate_is_subtracted_from_another_coordinate :
        observations_for_a_sut_without_a_contract<Coordinate>
    {
        it should_return_a_new_coordinate_with_the_proper_grid_point = () => result.should_be_equal_to<Coordinate>(0);

        context c = () =>
                        {
                            uint initial = 1;
                            provide_a_basic_sut_constructor_argument(initial);
                        };

        because b = () => { result = sut.minus(1); };

        static Coordinate result;
    }
}