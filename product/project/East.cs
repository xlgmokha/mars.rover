namespace mars.rover
{
    public class East : Heading
    {
        readonly Plateau plateau;

        public East(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public Heading turn_left()
        {
            return new North(plateau);
        }

        public Heading turn_right()
        {
            return new South(plateau);
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
            if (plateau.within_x_axis(x.plus(1)))
                x.increment();
        }

        public bool Equals(Heading other)
        {
            if (null == other) return false;
            return other is East;
        }

        public override string ToString()
        {
            return "East";
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