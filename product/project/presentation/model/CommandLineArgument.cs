namespace mars.rover.presentation.model
{
    public class CommandLineArgument
    {
        readonly string argument;

        CommandLineArgument(string argument)
        {
            this.argument = argument;
        }

        static public implicit operator CommandLineArgument(string argument)
        {
            return new CommandLineArgument(argument);
        }

        public override string ToString()
        {
            return argument;
        }

        public bool Equals(CommandLineArgument other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.argument, argument);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CommandLineArgument)) return false;
            return Equals((CommandLineArgument) obj);
        }

        public override int GetHashCode()
        {
            return (argument != null ? argument.GetHashCode() : 0);
        }
    }
}