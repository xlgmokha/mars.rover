using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class RoverSpecs
    {
    }

    public abstract class when_facing_north : observations_for_a_sut_without_a_contract<Rover>
    {
        public override Rover create_sut()
        {
            return new Rover(1, 2, Headings.North);
        }
    }

    public abstract class when_facing_east : observations_for_a_sut_without_a_contract<Rover>
    {
        public override Rover create_sut()
        {
            return new Rover(1, 2, Headings.East);
        }
    }

    public abstract class when_facing_west : observations_for_a_sut_without_a_contract<Rover>
    {
        public override Rover create_sut()
        {
            return new Rover(1, 2, Headings.West);
        }
    }

    public abstract class when_facing_south : observations_for_a_sut_without_a_contract<Rover>
    {
        public override Rover create_sut()
        {
            return new Rover(1, 2, Headings.South);
        }
    }

    public class when_a_rover_that_is_facing_north_is_told_to_turn_90_degrees_to_the_left : when_facing_north
    {
        it should_be_facing_west = () => sut.heading.should_be_equal_to(Headings.West);

        because b = () => sut.turn_left();
    }

    public class when_a_rover_that_is_facing_north_is_told_to_turn_90_degrees_to_the_right : when_facing_north
    {
        it should_be_facing_east = () => sut.heading.should_be_equal_to(Headings.East);

        because b = () => sut.turn_right();
    }

    public class when_a_rover_that_is_facing_east_is_told_to_turn_90_degrees_to_the_left : when_facing_east
    {
        it should_be_facing_north = () => sut.heading.should_be_equal_to(Headings.North);

        because b = () => sut.turn_left();
    }

    public class when_a_rover_that_is_facing_east_is_told_to_turn_90_degrees_to_the_right : when_facing_east
    {
        it should_be_facing_south = () => sut.heading.should_be_equal_to(Headings.South);

        because b = () => sut.turn_right();
    }

    public class when_a_rover_that_is_facing_south_is_told_to_turn_90_degrees_to_the_left : when_facing_south
    {
        it should_be_facing_east = () => sut.heading.should_be_equal_to(Headings.East);

        because b = () => sut.turn_left();
    }

    public class when_a_rover_that_is_facing_south_is_told_to_turn_90_degrees_to_the_right : when_facing_south
    {
        it should_be_facing_west = () => sut.heading.should_be_equal_to(Headings.West);

        because b = () => sut.turn_right();
    }

    public class when_a_rover_that_is_facing_west_is_told_to_turn_90_degrees_to_the_left : when_facing_west
    {
        it should_be_facing_south = () => sut.heading.should_be_equal_to(Headings.South);

        because b = () => sut.turn_left();
    }

    public class when_a_rover_that_is_facing_west_is_told_to_turn_90_degrees_to_the_right : when_facing_west
    {
        it should_be_facing_north = () => sut.heading.should_be_equal_to(Headings.North);

        because b = () => sut.turn_right();
    }

    public class when_facing_north_and_moving_forward_one_grid_point : when_facing_north
    {
        it should_increment_its_y_coordinate = () => sut.y.should_be_equal_to<Coordinate>(3);

        because b = () => sut.move_forward();
    }

    public class when_facing_south_and_moving_forward_one_grid_point : when_facing_south
    {
        it should_decrement_its_y_coordinate = () => sut.y.should_be_equal_to<Coordinate>(1);

        because b = () => sut.move_forward();
    }

    public class when_facing_west_and_moving_forward_one_grid_point : when_facing_west
    {
        it should_decrement_its_x_coordinate = () => sut.x.should_be_equal_to<Coordinate>(0);

        because b = () => sut.move_forward();
    }

    public class when_facing_east_and_moving_forward_one_grid_point : when_facing_east
    {
        it should_increment_its_x_coordinate = () => sut.x.should_be_equal_to<Coordinate>(2);

        because b = () => sut.move_forward();
    }
}