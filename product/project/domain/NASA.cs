namespace mars.rover.domain
{
    public class NASA
    {
        Plateau plateau;

        public NASA(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public virtual Rover deploy_rover_to(uint x_coordinate, uint y_coordinate, Heading heading)
        {
            return new Rover(x_coordinate, y_coordinate, heading);
        }
    }
}