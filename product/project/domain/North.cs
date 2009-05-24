namespace mars.rover.domain
{
    public class North : Heading
    {
        readonly Plateau plateau;

        public North(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public Heading turn_left()
        {
            return new West(plateau);
        }

        public Heading turn_right()
        {
            return new East(plateau);
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
            if (plateau.within_y_axis(y.plus(1)))
                y.increment();
        }

        public bool Equals(Heading other)
        {
            if (null == other) return false;
            return other is North;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Heading);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return "North";
        }
    }
}