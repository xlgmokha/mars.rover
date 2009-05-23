using System;

namespace mars.rover
{
    public class NASA
    {
        public virtual void report_top_left_coordinates_to(SpecifyTopLeftCoordinates callback)
        {
        }

        public virtual Rover deploy_rover_to(int x_coordinate, int y_coordinate, Heading heading)
        {
            return new Rover(new Position(x_coordinate,y_coordinate,heading));
        }
    }
}