using System.IO;

namespace mars.rover.presentation
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
            writer.WriteLine("enter upper right coordinates:");
            presenter.provide_upper_right_coordinates(reader.ReadLine());

            for (var i = 0; i < 2; i++)
            {
                writer.WriteLine("enter coordinates to deploy a rover to:");
                presenter.deploy_rover_to(reader.ReadLine());

                writer.WriteLine("enter commands to navigate rover:");
                presenter.navigate_rover_using(reader.ReadLine());
            }
            presenter.go();
        }

        public void display(string location)
        {
            writer.WriteLine(location);
        }
    }
}