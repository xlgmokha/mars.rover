using System.IO;

namespace mars.rover
{
    public class CaptureUserInstructionsConsoleView : CaptureUserInstructionsView
    {
        readonly TextReader reader;
        readonly TextWriter writer;

        public CaptureUserInstructionsConsoleView(TextReader reader, TextWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void attach_to(CaptureUserInstructionsPresenter presenter)
        {
            writer.WriteLine("Enter upper right coordinates:");
            presenter.provide_upper_right_coordinates(reader.ReadLine());

            writer.WriteLine("enter coordinates to deploy a rover to:");
            presenter.deploy_rover_to(reader.ReadLine());

            writer.WriteLine("enter commands to navigate rover:");
            presenter.navigate_rover_using(reader.ReadLine());
        }

        public void display(uint x, uint y, string heading)
        {
            writer.WriteLine("{0} {1} {2}", x, y, heading);
        }
    }
}