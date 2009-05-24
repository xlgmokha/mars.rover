namespace mars.rover
{
    public class Plateau
    {
        readonly Coordinate top_x_coordinate;
        readonly Coordinate top_y_coordinate;

        public Plateau(uint top_x_coordinate, uint top_y_coordinate)
        {
            this.top_x_coordinate = top_x_coordinate;
            this.top_y_coordinate = top_y_coordinate;
        }

        public virtual bool within_boundary(Coordinate x, Coordinate y)
        {
            return top_y_coordinate.CompareTo(y) >= 0 && top_x_coordinate.CompareTo(x) >= 0;
        }
    }
}