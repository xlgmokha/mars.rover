namespace mars.rover
{
    public class West : Heading
    {
        public Heading turn_left()
        {
            return new South();
        }

        public Heading turn_right()
        {
            return new North();
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
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