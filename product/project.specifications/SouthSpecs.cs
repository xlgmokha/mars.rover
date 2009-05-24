using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class SouthSpecs
    {
        
    }
    public class when_at_the_most_southern_point_on_the_plateau_and_attempting_to_move_forward_one_grid_point :
        observations_for_a_sut_with_a_contract<Heading, South>
    {
        it should_not_move_from_its_current_position = () =>
                                                           {
                                                               y.should_be_equal_to<Coordinate>(0);
                                                               x.should_be_equal_to<Coordinate>(0);
                                                           };

        context c = () =>
                        {
                            y = new Coordinate(0);
                            x = new Coordinate(0);
                        };

        because b = () => sut.move_forward_from(x, y);

        public override Heading create_sut()
        {
            return new South(new Mars(5, 5));
        }

        static Coordinate y;
        static Coordinate x;
    }
}