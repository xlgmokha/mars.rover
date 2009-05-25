using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.domain;
using mars.rover.presentation.model;

namespace specifications.presentation.model
{
    public class HeadingFactorySpecs
    {
    }

    public class when_checking_if_a_heading_factory_can_produce_a_heading_for_a_type_that_it_cannot :
        observations_for_a_sut_without_a_contract<HeadingFactory>
    {
        it should_return_false = () => result.should_be_equal_to(false);

        context c = () => { provide_a_basic_sut_constructor_argument("S"); };
        because b = () => { result = sut.is_satisfied_by("N"); };

        static bool result;
    }

    public class when_checking_if_a_heading_factory_can_produce_a_heading_for_a_type_that_it_can :
        observations_for_a_sut_without_a_contract<HeadingFactory>
    {
        it should_return_true = () => result.should_be_equal_to(true);

        context c = () => { provide_a_basic_sut_constructor_argument("S"); };
        because b = () => { result = sut.is_satisfied_by("s"); };

        static bool result;
    }

    public class when_telling_the_factory_to_produce_a_heading :
        observations_for_a_sut_without_a_contract<HeadingFactory>
    {
        it should_return_the_correct_type = () => { result.should_be_equal_to(heading); };

        context c = () =>
                        {
                            heading = an<Heading>();
                            plateau = an<Plateau>();
                            Func<Plateau, Heading> factory = x => heading;
                            provide_a_basic_sut_constructor_argument("E");
                            provide_a_basic_sut_constructor_argument(factory);
                        };

        because b = () => { result = sut.create(plateau); };

        static Heading result;
        static Heading heading;
        static Plateau plateau;
    }
}