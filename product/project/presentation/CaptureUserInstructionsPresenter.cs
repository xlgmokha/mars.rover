using System;
using System.Linq;
using mars.rover.common;
using mars.rover.domain;
using mars.rover.presentation.model;

namespace mars.rover.presentation
{
    public class CaptureUserInstructionsPresenter : Presenter
    {
        readonly CaptureUserInstructionsView view;
        readonly Registry<HeadingFactory> factories;
        readonly Registry<Navigation> navigations;
        Mars plateau;
        Rover rover;

        public CaptureUserInstructionsPresenter(CaptureUserInstructionsView view, Registry<HeadingFactory> factories,
                                                Registry<Navigation> navigations)
        {
            this.view = view;
            this.factories = factories;
            this.navigations = navigations;
        }

        public virtual void run()
        {
            view.attach_to(this);
        }

        public virtual void provide_upper_right_coordinates(string line)
        {
            var coordinates = line.Split(new[] {' '});
            plateau = new Mars(Convert.ToUInt32(coordinates[0]), Convert.ToUInt32(coordinates[1]));
        }

        public virtual void deploy_rover_to(string line)
        {
            var coordinates = line.Split(new[] {' '});
            rover = new Rover(Convert.ToUInt32(coordinates[0]), Convert.ToUInt32(coordinates[1]),
                              find_heading_for(coordinates[2]));
        }

        public virtual void navigate_rover_using(string line)
        {
            line.each(x => navigations.Single(y => y.is_satisfied_by(x)).run_against(rover));
            view.display(rover.x, rover.y, rover.heading.ToString());
        }

        Heading find_heading_for(string heading)
        {
            return factories.Single(x => x.is_satisfied_by(heading)).create(plateau);
        }
    }
}