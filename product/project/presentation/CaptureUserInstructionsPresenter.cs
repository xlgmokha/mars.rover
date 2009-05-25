using mars.rover.presentation.infrastructure;

namespace mars.rover.presentation
{
    public class CaptureUserInstructionsPresenter : Presenter
    {
        readonly CaptureUserInstructionsView view;
        readonly CommandPump pump;

        public CaptureUserInstructionsPresenter(CaptureUserInstructionsView view, CommandPump pump)
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
            pump.run<CreateMarsCommand, string>(line);
        }

        public virtual void deploy_rover_to(string deployment_coordinates)
        {
            pump.run<DeployRoverCommand, string>(deployment_coordinates);
        }

        public virtual void navigate_rover_using(string navigation_commands)
        {
            pump.run<NavigateRoverCommand, string>(navigation_commands);
        }

        public void go()
        {
            pump.run();
        }
    }
}