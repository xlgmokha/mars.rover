using System.Linq;
using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public class SynchronousCommandPump : EventProcessor
    {
        readonly Registry<ParameterizedCommand<string>> commands;
        readonly CommandProcessor processor;
        readonly CommandFactory factory;

        public SynchronousCommandPump(Registry<ParameterizedCommand<string>> commands, CommandProcessor processor,
                                      CommandFactory factory)
        {
            this.commands = commands;
            this.processor = processor;
            this.factory = factory;
        }

        public virtual void process<Command, Input>(Input input) where Command : ParameterizedCommand<Input>
        {
            processor.add(factory.create_for(() => get<Command, Input>().run_against(input)));
        }

        public virtual void run()
        {
            processor.run();
        }

        ParameterizedCommand<Input> get<Command, Input>()
        {
            return new AdaptedCommand<Input>(commands.First(y => y is Command));
        }

        class AdaptedCommand<T> : ParameterizedCommand<T>
        {
            readonly ParameterizedCommand<string> command;

            public AdaptedCommand(ParameterizedCommand<string> command)
            {
                this.command = command;
            }

            public void run_against(T item)
            {
                command.run_against(item as string);
            }
        }
    }
}