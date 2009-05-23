namespace mars.rover
{
    public class Rover
    {
        public Coordinate y { get; private set; }
        public Coordinate x { get; private set; }
        public Heading heading { get; private set; }

        public Rover(Coordinate x, Coordinate y, Heading heading)
        {
            this.x = x;
            this.y = y;
            this.heading = heading;
        }

        public virtual void turn_left()
        {
            heading = heading.turn_left();
        }

        public virtual void turn_right()
        {
            heading = heading.turn_right();
        }

        public virtual void move_forward()
        {
            heading.move_forward_from(x, y);
        }
    }
}