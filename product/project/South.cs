using System;

namespace mars.rover
{
    public class South : Heading
    {
        public Heading turn_left()
        {
            return new East();
        }

        public Heading turn_right()
        {
            return new West();
        }

        public void move_forward_from(Coordinate x, Coordinate y)
        {
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