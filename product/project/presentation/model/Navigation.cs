using System;
using mars.rover.common;
using mars.rover.domain;

namespace mars.rover.presentation.model
{
    public class Navigation : Specification<char>, ParameterizedCommand<Rover>
    {
        readonly char command_text;
        readonly Action<Rover> navigation;

        public Navigation(char command_text, Action<Rover> navigation)
        {
            this.command_text = command_text;
            this.navigation = navigation;
        }

        public virtual void run_against(Rover rover)
        {
            navigation(rover);
        }

        public virtual bool is_satisfied_by(char item)
        {
            return char.ToUpperInvariant(command_text).Equals(char.ToUpperInvariant(item));
        }
    }
}