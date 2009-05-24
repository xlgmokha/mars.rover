namespace mars.rover.domain
{
    public class West : Heading
    {
        readonly Plateau plateau;

        public West(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public Heading turn_left()
        {
            return new South(plateau);
        }

        public Heading turn_right()
        {
            return new North(plateau);
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
            if (plateau.within_x_axis(x.minus(1)))
                x.decrement();
        }

        public bool Equals(Heading other)
        {
            if (null == other) return false;
            return other is West;
        }

        public override string ToString()
        {
            return "West";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Heading);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}