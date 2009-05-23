using System;

namespace mars.rover
{
    public class NASAPresenter : Presenter, SpecifyTopLeftCoordinates
    {
        readonly NASA nasa;

        public NASAPresenter(NASA nasa)
        {
            this.nasa = nasa;
        }

        public virtual void run()
        {
            nasa.report_top_left_coordinates_to(this);
        }

        public void run_with(Coordinate item)
        {
            throw new NotImplementedException();
        }
    }

    public interface SpecifyTopLeftCoordinates : CallbackCommand<Coordinate>
    {
    }

    public interface CallbackCommand<T> : ParameterizedCommand<T>
    {
    }
}