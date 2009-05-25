using mars.rover.domain;

namespace mars.rover.presentation.model
{
    internal class UnknownNavigation : Navigation
    {
        public UnknownNavigation() : base('?', null)
        {
        }

        public override void run_against(Rover rover)
        {
        }

        public override bool is_satisfied_by(char item)
        {
            return true;
        }
    }
}