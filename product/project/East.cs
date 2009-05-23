namespace mars.rover
{
    public class East : Heading
    {
        public Heading turn_left()
        {
            return new North();
        }

        public Heading turn_right()
        {
            return new South();
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
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