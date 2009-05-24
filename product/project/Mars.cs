namespace mars.rover
{
    public class Mars : Plateau
    {
        readonly Coordinate top_x_coordinate;
        readonly Coordinate top_y_coordinate;

        public Mars(uint top_x_coordinate, uint top_y_coordinate)
        {
            this.top_x_coordinate = top_x_coordinate;
            this.top_y_coordinate = top_y_coordinate;
        }

        public virtual bool within_x_axis(Coordinate x)
        {
            return top_x_coordinate.CompareTo(x) >= 0;
        }

        public virtual bool within_y_axis(Coordinate y)
        {
            return top_y_coordinate.CompareTo(y) >= 0;
        }
    }
}