namespace mars.rover
{
    public interface Plateau
    {
        bool within_x_axis(Coordinate x);
        bool within_y_axis(Coordinate y);
    }
}