using System.Linq;
using mars.rover.common;
using mars.rover.domain;
using mars.rover.presentation;
using mars.rover.presentation.model;

namespace mars.rover.service.application
{
    public class NavigateRoverCommand : ParameterizedCommand<string>
    {
        readonly Registry<Navigation> navigations;
        readonly CaptureUserInstructionsView view;
        NASA nasa;

        public NavigateRoverCommand(Registry<Navigation> navigations, CaptureUserInstructionsView view, NASA nasa)
        {
            this.navigations = navigations;
            this.nasa = nasa;
            this.view = view;
        }

        public void run_against(string navigation_commands)
        {
            var rover = nasa.waiting();
            navigation_commands.each(x => navigations.First(y => y.is_satisfied_by(x)).run_against(rover));
            view.display(rover.ToString());
        }
    }
}