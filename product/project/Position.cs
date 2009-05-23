using System;

namespace mars.rover
{
    public class Position
    {
        public Position(int x, int y, Heading heading)
        {
        }

        public virtual void change_heading_to_left()
        {
            throw new NotImplementedException();
        }

        public virtual void change_heading_to_right()
        {
            throw new NotImplementedException();
        }

        public virtual void advance()
        {
            throw new NotImplementedException();
        }
    }
}