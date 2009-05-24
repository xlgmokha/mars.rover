using mars.rover.domain;

namespace mars.rover.presentation.model
{
    internal class UnknownHeadingFactory : HeadingFactory
    {
        public UnknownHeadingFactory() : base(null, null)
        {
        }

        public override bool is_satisfied_by(string item)
        {
            return true;
        }

        public override Heading create(Plateau plateau)
        {
            return new UnknownHeading();
        }

        class UnknownHeading : Heading
        {
            public bool Equals(Heading other)
            {
                if (null == other) return false;
                return other is UnknownHeading;
            }

            public Heading turn_left()
            {
                return this;
            }

            public Heading turn_right()
            {
                return this;
            }

            public void move_forward_from(Coordinate x, Coordinate y)
            {
            }

            public override string ToString()
            {
                return "Unknown";
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
}