namespace mars.rover
{
    public class North : Heading
    {
        public Heading turn_left()
        {
            return new West();
        }

        public Heading turn_right()
        {
            return new East();
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
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