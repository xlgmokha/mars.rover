using System.Collections.Generic;
using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public class SynchronousCommandProcessor : CommandProcessor
    {
        readonly Queue<Command> commands = new Queue<Command>();

        public void add(Command command)
        {
            commands.Enqueue(command);
        }

        public void run()
        {
            while (commands.Count > 0)
                commands.Dequeue().run();
        }
    }
}