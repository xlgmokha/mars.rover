using System.Linq;
using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public class SynchronousCommandPump : CommandPump<string>
    {
        readonly Registry<ParameterizedCommand<string>> commands;
        readonly CommandProcessor processor;
        readonly CommandFactory factory;

        public SynchronousCommandPump(Registry<ParameterizedCommand<string>> commands, CommandProcessor processor, CommandFactory factory)
        {
            this.commands = commands;
            this.processor = processor;
            this.factory = factory;
        }

        public virtual void run<Command>(string input) where Command : ParameterizedCommand<string>
        {
            processor.add(factory.create_for(() => get<Command>().run_against(input)));
        }

        ParameterizedCommand<string> get<T>()
        {
            return commands.First(y => y is T);
        }

        public virtual void run()
        {
            processor.run();
        }
    }
}