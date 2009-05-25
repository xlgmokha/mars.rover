using mars.rover.presentation.infrastructure;
using mars.rover.service.application;

namespace mars.rover.presentation
{
    public class CaptureUserInstructionsPresenter : Presenter
    {
        readonly CaptureUserInstructionsView view;
        readonly EventProcessor pump;

        public CaptureUserInstructionsPresenter(CaptureUserInstructionsView view, EventProcessor pump)
        {
            this.view = view;
            this.pump = pump;
        }

        public virtual void run()
        {
            view.attach_to(this);
        }

        public virtual void provide_upper_right_coordinates(string line)
        {
            pump.process<CreateMarsCommand, string>(line);
        }

        public virtual void deploy_rover_to(string deployment_coordinates)
        {
            pump.process<DeployRoverCommand, string>(deployment_coordinates);
        }

        public virtual void navigate_rover_using(string navigation_commands)
        {
            pump.process<NavigateRoverCommand, string>(navigation_commands);
        }

        public void process_output()
        {
            pump.run();
        }
    }
}