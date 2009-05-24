using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.domain;

namespace specifications.domain
{
    public class NorthSpecs
    {
    }

    public class when_at_the_most_northern_point_on_the_plateau_and_attempting_to_move_forward_one_grid_point :
        observations_for_a_sut_with_a_contract<Heading, North>
    {
        it should_not_move_from_its_current_position = () =>
                                                           {
                                                               y.should_be_equal_to<Coordinate>(5);
                                                               x.should_be_equal_to<Coordinate>(5);
                                                           };

        context c = () =>
                        {
                            y = new Coordinate(5);
                            x = new Coordinate(5);
                        };

        because b = () => sut.move_forward_from(x, y);

        public override Heading create_sut()
        {
            return new North(new Mars(5, 5));
        }

        static Coordinate y;
        static Coordinate x;
    }
}