namespace mars.rover
{
    public class South : Heading
    {
        readonly Plateau plateau;

        public South(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public Heading turn_left()
        {
            return new East(plateau);
        }

        public Heading turn_right()
        {
            return new West(plateau);
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
            if (plateau.within_y_axis(y.minus(1)))
                y.decrement();
        }

        public bool Equals(Heading other)
        {
            if (null == other) return false;
            return other is South;
        }

        public override string ToString()
        {
            return "South";
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