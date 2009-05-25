using System;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.domain;
using mars.rover.presentation.model;
using Rhino.Mocks;

namespace specifications.presentation.model
{
    public class NavigationSpecs
    {
    }

    public class when_applying_a_navigation_against_a_rover : observations_for_a_sut_without_a_contract<Navigation>
    {
        it should_direct_the_rover_correctly = () => rover.received(x => x.turn_left());

        context c = () =>
                        {
                            an<object>();
                            rover = MockRepository.GenerateStub<Rover>(new Coordinate(0), new Coordinate(0),
                                                                       an<Heading>());
                            provide_a_basic_sut_constructor_argument('l');
                            provide_a_basic_sut_constructor_argument((Action<Rover>) (x => x.turn_left()));
                        };

        because b = () => sut.run_against(rover);

        static Rover rover;
    }

    public class when_checking_if_a_navigation_knows_how_to_process_input_from_nasa :
        observations_for_a_sut_without_a_contract<Navigation>
    {
        context c = () =>
                        {
                            code = 'l';
                            provide_a_basic_sut_constructor_argument(code);
                        };

        static protected char code;
    }

    public class when_input_is_recognized : when_checking_if_a_navigation_knows_how_to_process_input_from_nasa
    {
        it should_return_true = () => result.should_be_equal_to(true);

        because b = () => { result = sut.is_satisfied_by(char.ToUpperInvariant(code)); };

        static bool result;
    }

    public class when_input_is_not_recognized : when_checking_if_a_navigation_knows_how_to_process_input_from_nasa
    {
        it should_return_false = () => result.should_be_equal_to(false);

        because b = () => { result = sut.is_satisfied_by('M'); };

        static bool result;
    }
}