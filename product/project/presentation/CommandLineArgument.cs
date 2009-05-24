namespace mars.rover.presentation
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
    }
}