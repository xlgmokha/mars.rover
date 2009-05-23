namespace mars.rover
{
    public class NASA
    {
        public virtual void report_top_left_coordinates_to(SpecifyTopLeftCoordinates callback)
        {
        }

        public virtual Rover deploy_rover_to(uint x_coordinate, uint y_coordinate, Heading heading)
        {
            return new Rover(x_coordinate, y_coordinate, heading);
        }
    }
}