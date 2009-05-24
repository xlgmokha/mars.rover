using System;
using System.Collections.Generic;
using System.Linq;

namespace mars.rover
{
    public class CaptureUserInstructionsPresenter : Presenter
    {
        readonly CaptureUserInstructionsView view;
        IList<HeadingFactory> factories;
        IList<Navigation> navigations;
        NASA nasa;
        Mars plateau;
        Rover rover;

        public CaptureUserInstructionsPresenter(CaptureUserInstructionsView view)
        {
            this.view = view;
            factories = new List<HeadingFactory>
                            {
                                new DefaultHeadingFactory("N", x => new North(x)),
                                new DefaultHeadingFactory("E", x => new East(x)),
                                new DefaultHeadingFactory("W", x => new West(x)),
                                new DefaultHeadingFactory("S", x => new South(x)),
                            };
            navigations = new List<Navigation>
                              {
                                  new Navigation('L', x => x.turn_left()),
                                  new Navigation('R', x => x.turn_right()),
                                  new Navigation('M', x => x.move_forward()),
                              };
        }

        public virtual void run()
        {
            view.attach_to(this);
        }

        public virtual void provide_upper_right_coordinates(string line)
        {
            var coordinates = line.Split(new[] {' '});
            plateau = new Mars(Convert.ToUInt32(coordinates[0]), Convert.ToUInt32(coordinates[1]));
            nasa = new NASA(plateau);
        }

        public virtual void deploy_rover_to(string line)
        {
            var coordinates = line.Split(new[] {' '});
            rover = nasa.deploy_rover_to(Convert.ToUInt32(coordinates[0]), Convert.ToUInt32(coordinates[1]),
                                         find_heading_for(coordinates[2]));
        }

        public virtual void navigate_rover_using(string line)
        {
            foreach (var command in line)
                navigations.Single(x => x.is_satisfied_by(command)).navigate(rover);

            view.display(rover.x, rover.y, rover.heading.ToString());
        }

        Heading find_heading_for(string heading)
        {
            return factories.Single(x => x.is_satisfied_by(heading)).create(plateau);
        }
    }

    public interface HeadingFactory : Specification<string>
    {
        Heading create(Plateau plateau);
    }

    public class Navigation : Specification<char>
    {
        readonly char command_text;
        readonly Action<Rover> navigation;

        public Navigation(char command_text, Action<Rover> navigation)
        {
            this.command_text = command_text;
            this.navigation = navigation;
        }

        public virtual void navigate(Rover rover)
        {
            navigation(rover);
        }

        public virtual bool is_satisfied_by(char item)
        {
            return char.ToUpperInvariant(command_text).Equals(char.ToUpperInvariant(item));
        }
    }

    public class DefaultHeadingFactory : HeadingFactory
    {
        string code;
        Func<Plateau, Heading> factory;

        public DefaultHeadingFactory(string code, Func<Plateau, Heading> factory)
        {
            this.code = code;
            this.factory = factory;
        }

        public bool is_satisfied_by(string item)
        {
            return string.Equals(code, item, StringComparison.OrdinalIgnoreCase);
        }

        public Heading create(Plateau plateau)
        {
            return factory(plateau);
        }
    }

    public interface Specification<T>
    {
        bool is_satisfied_by(T item);
    }
}