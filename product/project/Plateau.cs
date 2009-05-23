namespace mars.rover
{
    public class Plateau
    {
        readonly uint top_x_coordinate;
        readonly uint top_y_coordinate;

        public Plateau(uint top_x_coordinate, uint top_y_coordinate)
        {
            this.top_x_coordinate = top_x_coordinate;
            this.top_y_coordinate = top_y_coordinate;
        }

        public virtual bool within_boundary(uint x, uint y)
        {
            return y <= top_y_coordinate && x <= top_x_coordinate;
        }
    }
}