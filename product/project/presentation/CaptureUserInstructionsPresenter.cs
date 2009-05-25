using mars.rover.presentation.infrastructure;

namespace mars.rover.presentation
{
    public class CaptureUserInstructionsPresenter : Presenter
    {
        readonly CaptureUserInstructionsView view;
        readonly CommandPump<string> pump;

        public CaptureUserInstructionsPresenter(CaptureUserInstructionsView view, CommandPump<string> pump)
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
            pump.run<CreateMarsCommand>(line);
        }

        public virtual void deploy_rover_to(string deployment_coordinates)
        {
            pump.run<DeployRoverCommand>(deployment_coordinates);
        }

        public virtual void navigate_rover_using(string navigation_commands)
        {
            pump.run<NavigateRoverCommand>(navigation_commands);
        }

        public void go()
        {
            pump.run();
        }
    }
}